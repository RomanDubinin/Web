using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

namespace RSDNMag.Forum
{
	public class SendPost : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox AuthorName;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox Topic;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox Msg;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button OK;
		int topicID = 0;
		int level = 0;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.QueryString["topic"] != String.Empty && !this.IsPostBack)
				Topic.Text = "Re: " + Request.QueryString["topic"];
				
			level = Int32.Parse(Request.QueryString["level"]);
				
			if (Request.QueryString["topicID"] == "-1") 
			{
				SqlConnection connection = new SqlConnection
					(ConfigurationSettings.AppSettings["ConnectionString"]);
				string query = "SELECT count(*) FROM forum_post WHERE answer = -1";
				    	
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Connection.Open();				
					topicID = Int32.Parse(command.ExecuteScalar().ToString());
				}

				connection.Close();				
			}
			else
				topicID = Int32.Parse(Request.QueryString["topicID"]);
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.OK.Click += new System.EventHandler(this.OK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void OK_Click(object sender, System.EventArgs e)
		{
			string query = @"
				UPDATE forum_post SET answers = 1
				WHERE forum_post_id = @answer;
				INSERT INTO forum_post
				(author, topic, body, date, answer, forum_id, topic_id, level)
				VALUES
				(@author, @topic, @body, @date, @answer, @forum, @topicID, @level)";

			SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

			using (SqlCommand command = new SqlCommand(query, connection))
			{
				command.Connection.Open();
				command.Parameters.Add("@author", parse(AuthorName.Text));
				command.Parameters.Add("@topic", parse(Topic.Text));
				command.Parameters.Add("@body", parse(Msg.Text));
				command.Parameters.Add("@date", DateTime.Now);
				command.Parameters.Add("@level", level + 1);
				command.Parameters.Add("@answer", Request.QueryString["answer"]);
				command.Parameters.Add("@forum", Request.QueryString["ID"]);
				command.Parameters.Add("@topicID", topicID);
				command.ExecuteNonQuery();
			}
			
			connection.Close();			
			Response.Redirect("include\\send.htm");
		}


		string parse(string text)
		{
			return text.Replace("<", "&#060")
				.Replace(">", "&#062")
				.Replace("\n", "<br>")
				.Replace("[url]", "(<a href=")
				.Replace("[/url]", ">ссылка</a>)")
				.Replace("[b]", "<strong>")
				.Replace("[/b]", "</strong>")
				.Replace("[i]", "<em>")
				.Replace("[/i]", "</em>")
				.Replace("[u]", "<u>")
				.Replace("[/u]", "</u>");		
		}
	}
}
