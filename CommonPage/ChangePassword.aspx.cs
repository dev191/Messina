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
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;

namespace TheSite.CommonPage
{
	/// <summary>
	/// Descrizione di riepilogo per ChangePassword.
	/// </summary>
	public class ChangePassword : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPassword;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected S_Controls.S_TextBox txtsPasword;
		protected S_Controls.S_TextBox txtsNewPasword;
		protected S_Controls.S_TextBox txtsConfermaPasword;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvconferma;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvnuovapawd;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.Button BttConferma;
        protected WebControls.PageTitle PageTitle1;
		public static int FunId = 0;
		public static string HelpLink = string.Empty;

	    private int i_IdUtente=0;//Ritorna l'id dell'utente

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];

			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;

			BttConferma.Attributes.Add("onclick","nascondi();");
	
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
			this.BttConferma.Click += new System.EventHandler(this.BttConferma_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BttConferma_Click(object sender, System.EventArgs e)
		{
			if (IsValid)
			{
				changePwd();
			}
		}
		private void changePwd()
		{
			if(!IsUtente())
			{
			  PanelMess.ShowError("Non hai inserito la Tua Password!", true);
			  return;
			}

			Classi.Sicurezza _Sicurezza = new Classi.Sicurezza();
			Classi.Utente _Utente = new TheSite.Classi.Utente();

			this.txtsNewPasword.Text = _Sicurezza.EncryptMD5(this.txtsNewPasword.Text);

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_Utente_Id = new S_Object();
			s_p_Utente_Id.ParameterName = "p_Utente_Id";
			s_p_Utente_Id.DbType = CustomDBType.Integer;
			s_p_Utente_Id.Direction = ParameterDirection.Input;
			s_p_Utente_Id.Index = 0;
			s_p_Utente_Id.Value=i_IdUtente;
			_SColl.Add(s_p_Utente_Id);

			S_Controls.Collections.S_Object s_p_Password = new S_Object();
			s_p_Password.ParameterName = "p_Password";
			s_p_Password.DbType = CustomDBType.VarChar;
			s_p_Password.Direction = ParameterDirection.Input;
			s_p_Password.Index = 1;
			s_p_Password.Size=50;
            s_p_Password.Value=this.txtsNewPasword.Text;
			_SColl.Add(s_p_Password);
      
			i_IdUtente = _Utente.ChangePassword(_SColl);
	
			if (i_IdUtente > 0)
				PanelMess.ShowMessage("Cambio Password completato con successo!", true);
			else
				PanelMess.ShowError("Errore nel cambio della Password!", true);


		}
		/// <summary>
		/// Verifica che l'utente corrente abbia inserito la propria password
		/// Ritorna True se è l'utente corrente in caso contrario false.
		/// </summary>
		private bool IsUtente()
		{
			Classi.Sicurezza _Sic = new Classi.Sicurezza();
			Classi.Utente _Utente = new TheSite.Classi.Utente();
			txtsPasword.Text = _Sic.EncryptMD5(txtsPasword.Text);

			string UserName=Context.User.Identity.Name;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_UserName = new S_Object();
			s_p_UserName.ParameterName = "p_UserName";
			s_p_UserName.DbType = CustomDBType.VarChar;
			s_p_UserName.Direction = ParameterDirection.Input;
			s_p_UserName.Index = 0;
			s_p_UserName.Size=50;
            s_p_UserName.Value =UserName;
			_SColl.Add(s_p_UserName);

			S_Controls.Collections.S_Object s_p_Password = new S_Object();
			s_p_Password.ParameterName = "p_Password";
			s_p_Password.DbType = CustomDBType.VarChar;
			s_p_Password.Direction = ParameterDirection.Input;
			s_p_Password.Index = 1;
			s_p_Password.Size=50;
			s_p_Password.Value=txtsPasword.Text;
			_SColl.Add(s_p_Password);

			i_IdUtente = _Utente.Login(_SColl);

			if (i_IdUtente > 0)
			 return true;
			else
			 return false;
		}

	}
}
