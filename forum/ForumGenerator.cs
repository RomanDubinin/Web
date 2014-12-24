using System;
using System.Collections;
using System.Resources;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Text;

namespace RSDNMag.Forum
{
	public class ForumGenerator
	{
		#region Construction
		string slider, sliderDiv;
		readonly ResourceManager res;
		readonly string current;
		readonly int forum;
		readonly int pageSize;
		string forumName;
		
		public ForumGenerator(string forumName, string current, int forum, int pageSize)
		{
			res = new ResourceManager("RSDNMag.Forum.Resources.Forum", this.GetType().Assembly);
			this.forum = forum;
			this.forumName = forumName;
			this.pageSize = pageSize;
			
			if (current != String.Empty)
				this.current = current;
			else
				this.current = "0";
		}
		#endregion


		public string Generate()
		{
			Initialize();
			
			var connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

			string query = BuildQuery();

			string source = String.Empty;
			var topics = new ArrayList(10);
			var topicNumbers = new Hashtable(10);

			var adapter = new SqlDataAdapter(query, connection);
			adapter.SelectCommand.Parameters.Add("@forum", forum);
			var dataSet = new DataSet("sender");//name
			adapter.Fill(dataSet);
			DataTable table = dataSet.Tables[0];
			int i = 0;

			foreach (DataRow r in table.Rows)
			{
				Post msgData;
				if ((Boolean)r["answers"])
				{
					source = RootBuild(i, r);
					msgData = new TopicPost(source, (Int32)r["forum_post_id"]);
				}
				else
				{
					source = NodeBuild(i, r);
					msgData = new Post(source, (Int32)r["forum_post_id"]);
				}

				if ((Int32)r["answer"] == -1)
				{
					topics.Add(msgData);
					topicNumbers.Add(r["topic_id"], i);
				}
				else
				{
					int value = (Int32)topicNumbers[r["topic_id"]];	
					
					var topicPost = (TopicPost)topics[value];
					
					if ((Int32)r["level"] == 2)
						topicPost.ChildNodes.Add(msgData);

					ArrayList enumeration = topicPost.GetEnumeration();

					foreach (object o in enumeration)
					{
						if ((Int32)r["answer"] == ((Post)o).ID)
						{
							((TopicPost) o).ChildNodes.Add(msgData);
							break;
						}
					}
				}
				i++;
			}
			return BuildResult(topics, dataSet);
		}


		#region ItemsGenerator
		void Initialize()
		{
			slider = res.GetString("Slider".ToString());
			sliderDiv = res.GetString("SliderDiv".ToString());
		}

		string NodeBuild(int index, DataRow datarow)
		{
			return CommonReplace(index, sliderDiv, datarow);
		}

		string RootBuild(int index, DataRow datarow)
		{
			return CommonReplace(index, slider, datarow);
		}

		string CommonReplace(int index, string source, DataRow datarow)
		{			
			return source.Replace("IDPLACE", datarow["forum_post_id"].ToString()).
						  Replace("|", index.ToString()).
						  Replace("Text", datarow["topic"].ToString()).
						  Replace("TOPICID", datarow["topic_id"].ToString()).
						  Replace("Author", datarow["author"].ToString()).
						  Replace("Change", ((Int32)datarow["level"] * 15).ToString()).
						  Replace("TOPICLEVEL", datarow["level"].ToString()).
						  Replace("Date", datarow["date"].ToString());	
		}
		#endregion


		#region Builders
		string BuildResult(IEnumerable topics, DataSet dataSet)
		{
			var pagesCount = CalculatePages(dataSet);

			if (dataSet.Tables.Count > 2)
				forumName = dataSet.Tables[2].Rows[0].ItemArray[0].ToString();

			var result = new StringBuilder(res.GetString("ForumCaption".ToString()).Replace("forumname", forumName));
			result.Append(res.GetString("ForumSurface".ToString()));
			result.Append(res.GetString("ForumHeader".ToString()));

			foreach (var topic in topics)
				result.Append(topic);

			result.Append(res.GetString("ForumFooter".ToString()));
			result.Append("</DIV></DIV>");
			result.Append(res.GetString("ForumPages".ToString())
							 .Replace("pagecount", pagesCount.ToString())
							 .Replace("forumname", forumName)
							 .Replace("pagenumber", (Int32.Parse(current) + 1).ToString()));

			if (pagesCount > 1)
			{
				if ((Int32.Parse(current) + 1) == pagesCount)
					result = result.Replace("displaytype", "display:none");
				else
					result = result.Replace("displaytype", "display:inline");

				if ((Int32.Parse(current) + 1) != 1)
					result = result.Replace("disptype", "display:inline");
				else
					result = result.Replace("disptype", "display:none");
			}
			else
			{
				result = result.Replace("displaytype", "display:none")
							   .Replace("disptype", "display:none");
			}	
			return result.ToString();
		}


		int CalculatePages(DataSet dataSet)
		{
			var itemsCount = (Int32)dataSet.Tables[1].Rows[0].ItemArray[0];
			var pagesCount = itemsCount/pageSize;

			if(itemsCount%pageSize != 0 )
				pagesCount++;

			return pagesCount;
		}


		string BuildQuery()
		{
			string query = String.Format(@"
				SELECT forum_post_id, author, topic, date, answer, topic_id, level, answers FROM forum_post
				WHERE topic_id IN
					(SELECT TOP {0} topic_id FROM forum_post 
					WHERE forum_id = @forum AND level = 1 AND topic_id NOT IN
						(SELECT TOP {1} topic_id FROM forum_post
						WHERE forum_id = @forum AND level = 1 ORDER BY forum_post_id ASC)
					ORDER BY forum_post_id ASC)
				ORDER BY level ASC, forum_post_id ASC;
				SELECT count(*) FROM forum_post 
				WHERE forum_id = @forum AND answer = -1", 
				pageSize, Int32.Parse(current) * pageSize);

			if (forumName == String.Empty)
				query += @" SELECT name FROM forum WHERE forum_id = @forum";
	
			return query;
		}
		#endregion
	}
}

