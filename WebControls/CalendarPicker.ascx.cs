namespace TheSite.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	
	
	/// <summary>
	///		Summary description for DateSelector.
	/// </summary>
	public  class CalendarPicker : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lbl_Date;
		protected System.Web.UI.HtmlControls.HtmlInputButton btCalendar;
		protected S_Controls.S_TextBox S_TxtDatecalendar;
		protected System.Web.UI.WebControls.Image imgCalendar;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			string scriptStr = "javascript:return popUpCalendar(" +  this.S_TxtDatecalendar.ClientID + "," + getClientID() + @", 'dd/mm/yyyy', '__doPostBack(\'" + getClientID() + @"\')')";
			btCalendar.Attributes.Add("onclick", scriptStr);
			System.Text.StringBuilder strscript=new System.Text.StringBuilder();			
     		//this.S_TxtDatecalendar.Attributes.Add("readonly",""); 
			//S_TxtDatecalendar.Attributes.Add("onkeydown","deletedate(this,event);");
			S_TxtDatecalendar.Attributes.Add("onblur","checkDate(this);");
			strscript.Append ("<script language=JavaScript>\n");
			strscript.Append ("function deletedate(sender,e){\n");
			strscript.Append ("if ((event.keyCode==46) && (window.confirm('Eliminare la data?'))){\n");
			strscript.Append ("sender.value=\"\";\n");
			strscript.Append ("	}\n");
			strscript.Append ("}\n");

			strscript.Append ("</script>");
        
			if(!this.Page.IsStartupScriptRegistered("PopupCalendarStartup"))
				this.Page.RegisterStartupScript("PopupCalendarStartup", strscript.ToString());

			if(!this.Page.IsClientScriptBlockRegistered("Popupcalcss"))
				this.Page.RegisterClientScriptBlock("Popupcalcss", "<LINK href=\"../images/cal/popcalendar.css\" type=\"text/css\" rel=\"stylesheet\">");

			if(!this.Page.IsClientScriptBlockRegistered("Popupcaljs"))
				this.Page.RegisterClientScriptBlock("Popupcaljs", "<script language=\"javascript\" src=\"../images/cal/popcalendar.js\"></script>");
			

			
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
		
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		// Get the id of the control rendered on client side
		// Very essential for Javascript Calendar scripts to locate the textbox

		public S_Controls.S_TextBox Datazione
		{
			get {return S_TxtDatecalendar;}
		}

		public string getClientID()
		{
			return S_TxtDatecalendar.ClientID;
			}
		public System.Web.UI.HtmlControls.HtmlInputButton  ButtonCalendar
		{
			get {return btCalendar;}
		}
		// This propery sets/gets the calendar date
		public string CalendarDate
		{
			get
			{
				return S_TxtDatecalendar.Text;
			}
			set
			{
				S_TxtDatecalendar.Text = value;
			}
		}
		// This Property sets or gets the the label for 
		// Dateselector user control
		public string Text
		{
			get
			{
				return lbl_Date.Text;
			}
			set
			{
				lbl_Date.Text = value;
			}
		}

		public void CreateValidator(string message,ValidatorDisplay dispaly)
		{
			RequiredFieldValidator Valida= new RequiredFieldValidator();
			Valida.ControlToValidate =this.S_TxtDatecalendar.ID;
			Valida.ErrorMessage =message;
			Valida.Display =dispaly;
			this.Controls.Add(Valida);   
		}

	}

}
