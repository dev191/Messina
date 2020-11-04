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

namespace TheSite
{
	/// <summary>
	/// Descrizione di riepilogo per MainContent.
	/// </summary>
	public class MainContent : System.Web.UI.Page
	{
		public bool VisibleMap=false;
		public string FunId=string.Empty;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{
				if (IsMap()==true)//Ritorna True se puo vedere la mappa interattiva
				  VisibleMap=true;
			}
		}
		public string ImageSrc()
		{	
			string _ImageSrc="";
			if (Context.User.IsInRole("MA") && !Context.User.IsInRole("PA"))
				_ImageSrc="Images/PagInMartino.jpg";
			if (!Context.User.IsInRole("MA") && Context.User.IsInRole("PA"))
				_ImageSrc="Images/PagInPapardo.jpg";
            if (Context.User.IsInRole("MA") && Context.User.IsInRole("PA"))
				_ImageSrc="Images/cofatheclogo.jpg";
			if (Context.User.IsInRole("AMMINISTRATORI") || Context.User.IsInRole("callcenter"))
				_ImageSrc="Images/cofatheclogo.jpg";
			return  _ImageSrc;
		}
		private bool IsMap()
		{
		  Classi.Utente _Utente = new TheSite.Classi.Utente(Context.User.Identity.Name);
          DataSet Ds=_Utente.GetMap();
			if (Ds.Tables[0].Rows.Count>0)
			{
				if (Ds.Tables[0].Rows[0]["FUNZIONE_ID"]!=DBNull.Value)
					FunId=Ds.Tables[0].Rows[0]["FUNZIONE_ID"].ToString();

				if (Ds.Tables[0].Rows[0]["LETTURA"]!=DBNull.Value)
					return (int.Parse(Ds.Tables[0].Rows[0]["LETTURA"].ToString())==-1)?true:false;
				else
					return false;
			}
			else
				return false;
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
