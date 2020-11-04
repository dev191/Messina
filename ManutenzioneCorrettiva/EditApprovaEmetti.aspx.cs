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


namespace TheSite.ManutenzioneCorrettiva
{
	/// <summary>
	/// Descrizione di riepilogo per ApprovaEmetti.
	/// </summary>

	public class EditApprovaEmetti : System.Web.UI.Page
	{
		public Classi.SiteModule _SiteModule;
		bool IsEditable=false;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			// ***********************  MODIFICA PER I PERMESSI SULLA PAGINA CORRENTE **********************
			string _mypage="./ManutenzioneCorrettiva/EditApprovaEmetti.aspx";			
			_SiteModule = new TheSite.Classi.SiteModule(_mypage);
			// *********************************************************************************************
			this.IsEditable=_SiteModule.IsEditable;
			if(!IsPostBack)
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
