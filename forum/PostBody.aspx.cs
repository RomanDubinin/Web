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
	public class PostBody : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl ForumText;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.QueryString["id"] != null)
			{
				string query = @"SELECT body FROM forum_post WHERE forum_post_id = @id";
				
				SqlConnection connection = new SqlConnection
					(ConfigurationSettings.AppSettings["ConnectionString"]);
			
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.Add("@id", Int32.Parse(Request.QueryString["id"]));
					connection.Open();
				
					SqlDataReader reader = command.ExecuteReader();
			
					reader.Read();
					ForumText.InnerHtml = reader.GetString(0);
					reader.Close();
				}

				connection.Close();
			}				
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
