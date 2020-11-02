namespace TheSite.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descrizione di riepilogo per CalendarPicker.
	/// </summary>
	public class CalendarPickerOLD : System.Web.UI.UserControl
	{
		protected S_Controls.S_TextBox S_TxtDatecalendar;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Popupdata;
		protected System.Web.UI.HtmlControls.HtmlGenericControl docdata;
		public string idModuloCale=string.Empty;
		public string namediv=string.Empty;
		protected System.Web.UI.HtmlControls.HtmlInputButton btCalendar;
		public string nameframe=string.Empty;
		public string  namebutton=string.Empty;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			idModuloCale=this.ClientID;
			namediv=Popupdata.ClientID;
            nameframe=docdata.ClientID;
			namebutton=btCalendar.ClientID;

			S_TxtDatecalendar.Attributes.Add("onkeydown","deletedate(this,event);");
 
			this.S_TxtDatecalendar.Attributes.Add("readonly",""); 
			btCalendar.Attributes.Add("onclick","ShowCalendar('" + idModuloCale + "',event,'" + namediv + "','" + nameframe +"','" + namebutton + "');");  
//             onclick="ShowCalendar('<%=idModuloCale%>',event,'<%=namediv%>','<%=nameframe%>','<%=namebutton%>');"
 
			System.Text.StringBuilder strscript=new System.Text.StringBuilder();
			strscript.Append ("<script language=JavaScript>\n");
			strscript.Append ("function ShowCalendar(sender,e,namediv,nameframe,namebutton){\n");
			strscript.Append ("var crtl=document.getElementById(namediv).style;\n"); 

//			strscript.Append ("var crtlbt=document.getElementById(namebutton).style;\n");

//			strscript.Append ("var x = crtlbt.left;\n");
//			strscript.Append ("var y = crtlbt.top;\n");

			strscript.Append ("var x = e.clientX;\n");
			strscript.Append ("var y = e.clientY;\n");
		
//			strscript.Append ("var x = e.screenX;\n");
//			strscript.Append ("var y = e.screenY;\n");
			
			strscript.Append ("crtl.left = x-20;\n");
			strscript.Append ("crtl.top = y+10;\n");
			strscript.Append ("crtl.display = (crtl.display == 'none')?'block':'none';\n");
			strscript.Append ("document.getElementById(nameframe).src='../CommonPage/PageCalendar.aspx?idmodulocal=' + sender + '&namediv=' + namediv;\n");	
			strscript.Append ("}\n");

			strscript.Append ("function deletedate(sender,e){\n");
			strscript.Append ("if ((event.keyCode==46) && (window.confirm('Eliminare la data?'))){\n");
			strscript.Append ("sender.value=\"\";\n");
			strscript.Append ("	}\n");
			strscript.Append ("}\n");

			strscript.Append ("</script>");
        
			if(!this.Page.IsStartupScriptRegistered("PopupCalendarStartup"))
				this.Page.RegisterStartupScript("PopupCalendarStartup", strscript.ToString());
			

		}
		public S_Controls.S_TextBox Datazione
		{
			get {return S_TxtDatecalendar;}
		}
	
		public System.Web.UI.HtmlControls.HtmlInputButton  ButtonCalendar
		{
			get {return btCalendar;}
		}

		public void CreateValidator(string message,ValidatorDisplay dispaly)
		{
		  RequiredFieldValidator Valida= new RequiredFieldValidator();
          Valida.ControlToValidate =this.S_TxtDatecalendar.ID;
		  Valida.ErrorMessage =message;
          Valida.Display =dispaly;
          this.Controls.Add(Valida);   
		}
		#region Codice generato da Progettazione Web Form
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: questa chiamata è richiesta da Progettazione Web Form ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
