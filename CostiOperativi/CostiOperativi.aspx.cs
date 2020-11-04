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
using MyCollection;
using System.Reflection;


namespace TheSite.CostiOperativi
{
	/// <summary>
	/// Descrizione di riepilogo per CostiOperativi.
	/// </summary>
	public class CostiOperativi : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BntIndietro;
		public Classi.SiteModule _SiteModule;
		bool IsEditable = false;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			string _mypage = "../CostiOperativi/CostiOperativi.aspx";
			_SiteModule = new TheSite.Classi.SiteModule(_mypage);
			this.IsEditable = _SiteModule.IsEditable;
			if(!Page.IsPostBack)
			{
				#region Recupero la proprieta di ricerca
				// Recupero il tipo dall'oggetto context.
				Type myType=Context.Handler.GetType();       
				// recupero il PropertyInfo object passando il nome della proprietà da recuperare.
				PropertyInfo myPropInfo = myType.GetProperty("_Contenitore");
			
				// verifico che questa proprietà esista.
				if(myPropInfo!=null)
					this.ViewState.Add("mioContenitore",myPropInfo.GetValue(Context.Handler,null));

				//				this.ViewState.Add("mioContenitore",this.GetProperty(Context.Handler,"_Contenitore",new clMyCollection()));
				#endregion

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
			this.BntIndietro.Click += new System.EventHandler(this.BntIndietro_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BntIndietro_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("../ManutenzioneCorrettiva/SfogliaRdlPaging.aspx");
		}
		public MyCollection.clMyCollection _Contenitore
		{
			get 
			{
				if(this.ViewState["mioContenitore"]!=null)
					return (MyCollection.clMyCollection)this.ViewState["mioContenitore"];
				else
					return new MyCollection.clMyCollection();
			}
		}
		
	}
}
