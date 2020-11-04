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

namespace TheSite.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per ListaApparecchiatureServ.
	/// </summary>
	public class ListaApparecchiatureServ : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DtgListaApparecchiature;
		int bl_id;
		int servizio_id;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.QueryString["bl_id"]!=null)
				bl_id=Convert.ToInt32(Request.QueryString["bl_id"]);
			if(Request.QueryString["servizio_id"]!=null)
				servizio_id=Convert.ToInt32(Request.QueryString["servizio_id"]);
			Apparecchiature();
		}

		private void Apparecchiature()
		{
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.AnagrafeImpianti.SeviceDettail  _SeviceDettail = new Classi.AnagrafeImpianti.SeviceDettail(Context.User.Identity.Name);

			DataSet Ds;				
			Ds = _SeviceDettail.GetApparecchiature(bl_id,servizio_id);
			this.DtgListaApparecchiature.DataSource = Ds.Tables[0];

			if (Ds.Tables[0].Rows.Count == 0 )
			{
				DtgListaApparecchiature.CurrentPageIndex=0;
			}
			else
			{
				int Pagina = 0;
				if ((Ds.Tables[0].Rows.Count % DtgListaApparecchiature.PageSize) >0)
				{
					Pagina ++;
				}
				if (DtgListaApparecchiature.PageCount != Convert.ToInt16((Ds.Tables[0].Rows.Count / DtgListaApparecchiature.PageSize) + Pagina))
				{					
					DtgListaApparecchiature.CurrentPageIndex=0;					
				}
			}

			DtgListaApparecchiature.DataBind();
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
			this.DtgListaApparecchiature.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DtgListaApparecchiature_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DtgListaApparecchiature_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DtgListaApparecchiature.CurrentPageIndex=e.NewPageIndex;
			Apparecchiature();
		}
	}
}
