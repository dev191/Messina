using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using ApplicationSecurity;

namespace TheSite.RichiesteDati
{
	/// <summary>
	/// Descrizione di riepilogo per Autentica.
	/// </summary>
	public class Autentica : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label user;
		protected System.Web.UI.WebControls.Label lblH;
		protected System.Web.UI.WebControls.Label password;
		private string usr;
		private string pwd;

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				user.Text=Request.Params["user"];
				password.Text=Request.Params["password"];

				//user.Text="callcenter";
				//password.Text="callcenter01";

				usr=Request.Params["user"];
				//usr="callcenter";
				Sicurezza sic = new Sicurezza();
				pwd=sic.EncryptMD5(Request.Params["password"]);
				//pwd=sic.EncryptMD5("callcenter01");


				/*PROCEDURE SP_AUTENTICA_UTENTI (p_UserName in varchar2, 
											   p_Password in varchar2,
											   IO_CURSOR IN OUT T_CURSOR)*/

				S_ControlsCollection _SColl = new S_ControlsCollection();

				S_Controls.Collections.S_Object UserName = new S_Object();
				UserName.ParameterName = "p_UserName";
				UserName.DbType = CustomDBType.VarChar;
				UserName.Size=50;
				UserName.Direction = ParameterDirection.Input;
				UserName.Value=usr;
				UserName.Index = 0;
				_SColl.Add(UserName);

				S_Controls.Collections.S_Object Password = new S_Object();
				Password.ParameterName = "p_Password";
				Password.DbType = CustomDBType.VarChar;
				Password.Size=50;
				Password.Direction = ParameterDirection.Input;
				Password.Value=pwd;
				Password.Index = 1;
				_SColl.Add(Password);

				Classi.Utente _Utente = new TheSite.Classi.Utente();

				int res  = _Utente.Login(_SColl);

				Response.Clear();
				Response.ClearHeaders();
				Response.ClearContent();

				Response.AddHeader("autenticato",res.ToString());
			}
			catch (Exception exc)
			{
				lblH.Text=exc.ToString();
			}

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
