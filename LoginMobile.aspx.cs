using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
using TheSite.AslMobile.Class;  
using System.Web.Security;


namespace TheSite
{
	/// <summary>
	/// Descrizione di riepilogo per MobileWebForm1.
	/// </summary>
	public class MobileWebForm1 : System.Web.UI.MobileControls.MobilePage
	{

		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific1;
		protected System.Web.UI.MobileControls.Panel Panel1;
		protected System.Web.UI.MobileControls.Form frmLogin;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if (!AslMobile.Class.ClassGlobal.IsMobileDevice) 
				Response.Redirect("Default.aspx");
//				Response.Redirect("../Ater/Default.aspx");

			if (Request.IsAuthenticated)
				Response.Redirect("Default.aspx");
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

		protected void OnLogin(object sender, System.EventArgs e)
		{
            System.Web.UI.MobileControls.TextBox  txtUserID=(System.Web.UI.MobileControls.TextBox)Panel1.Controls[0].FindControl("txtUserID");
			System.Web.UI.MobileControls.TextBox  txtPassword=(System.Web.UI.MobileControls.TextBox)Panel1.Controls[0].FindControl("txtPassword");
			System.Web.UI.MobileControls.Label  lblInvalidLogin=(System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblInvalidLogin");
			if(IsAuthenticated(txtUserID.Text, txtPassword.Text))
			{
				
				MobileFormsAuthentication.RedirectFromLoginPage(txtPassword.Text,true);
			}
			else
			{
				lblInvalidLogin.Visible =true;
				lblInvalidLogin.Text = "*-Credenziali non Valide";
			}

		}
		private bool IsAuthenticated(String user, String password)
		{//Check the values against forms authentication store.
			//return true;
			TheSite.AslMobile.Class.ClassUser _User=new TheSite.AslMobile.Class.ClassUser();  
			//Creazione Della Collection di Parametri
            OracleParameterCollection Coll= new OracleParameterCollection();

			//Creazione del Parametro Password
			OracleParameter  PaPas=new OracleParameter();
			PaPas.ParameterName="p_Password";
			PaPas.Size=50;
			PaPas.Direction=ParameterDirection.Input;
			PaPas.OracleType=OracleType.VarChar;
			PaPas.Value =_User.EncryptMD5(password);
			Coll.Add(PaPas);

			//Creazione del Parametro Del Cursore
			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);

			//Creazione del Parametro User
			OracleParameter  PaUser=new OracleParameter();
			PaUser.ParameterName="p_UserName";
			PaUser.OracleType=OracleType.VarChar;
			PaUser.Size=50;
			PaUser.Direction=ParameterDirection.Input;
			PaUser.Value =user;
			Coll.Add(PaUser);

			try
			{
				 int result =_User.Autentica(Coll);
				if (result>0)
                    return true;
				else
					return false;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}

		}


		
	}
}
