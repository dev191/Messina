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
using S_Controls.Collections;
using System.Reflection;
using MyCollection;

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per TipoManutenzione.
	/// </summary>
	public class TipoManutenzione : System.Web.UI.Page
	{
		protected RicercaAnagrafica1 RicercaAnagrafica1;
		MyCollection.clMyCollection _myColl = new clMyCollection();
		TheSite.Gestione.EditAnagrafica  _fp=null;

		public MyCollection.clMyCollection _Contenitore
		{
			get 
			{
				return _myColl;
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			RicercaAnagrafica1.Pagina=PageType.TipoManutenzione;
			RicercaAnagrafica1.Coll=_myColl;
			if (!Page.IsPostBack)
			{
				if(Context.Handler is TheSite.Gestione.EditAnagrafica)
				{
					_fp = (TheSite.Gestione.EditAnagrafica)Context.Handler;
					if (_fp!=null) 
					{						
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);

						RicercaAnagrafica1.Ricerca();
						
						//metodo pubblico per ricerca dentro ascx
					}
				
				}
			
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
