using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace RSDNMag.Forum
{
	public class Default : Page
	{
		protected HtmlInputHidden StateBox;
		protected HtmlInputHidden CountBox;
		protected HtmlInputHidden PerPageBox;
		protected HtmlInputHidden IDBox;
		protected HtmlGenericControl main;
	
		private void Page_Load(object sender, EventArgs e)
		{
			int forum = 1;
			int perPage = 10;

			if (Request.QueryString["forum"] != null)
				forum = Int32.Parse(Request.QueryString["forum"]);

			if (PerPageBox.Value != String.Empty)
				perPage = Int32.Parse(PerPageBox.Value);
			
			main.InnerHtml = new ForumGenerator(StateBox.Value, CountBox.Value, forum, perPage).Generate();
			IDBox.Value = forum.ToString();
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
