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

namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Summary description for PianoManutenzioneProgrammata.
	/// </summary>
	public class PianoManutenzioneProgrammata : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblAnno;
		protected System.Web.UI.WebControls.Label lblmese;
		protected System.Web.UI.WebControls.TextBox txtAnno;
		protected System.Web.UI.WebControls.DropDownList drpMese;
		protected Csy.WebControls.DataPanel DataPanelRicerca;
		protected System.Web.UI.WebControls.Label lblEdificio;
		protected System.Web.UI.WebControls.DropDownList drpEdificio;
		protected System.Web.UI.WebControls.DropDownList drpCategoriaTecnologica;
		protected System.Web.UI.WebControls.Label lblClasseElemento;
		protected System.Web.UI.WebControls.DropDownList drpClasseElemento;
		protected System.Web.UI.WebControls.Label lnlCategoriaTecnologica;
		protected System.Web.UI.WebControls.Button btnGenera;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected WebControls.PageTitle PageTitle1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.PageTitle1.Title = "Stampa Piano Manutenzione Programmata";
			if(!IsPostBack)
			{
				InizializzaControlli();
			}
		}
		private void InizializzaControlli()
		{
			InitdrpMese();
			InitTxtAnno();
			InitDrp();
//			InitDrpEdificio();
//			InitDrpClasseElemento();
//			InitdrpCategoriaTecnologica();
		}

		private void InitdrpMese()
		{
			drpMese.SelectedIndex = System.DateTime.Today.Month-1;
		}
		private void InitTxtAnno()
		{
			txtAnno.Text = System.DateTime.Today.Year.ToString();
		}
		private void InitDrp()
		{
			TheSite.Classi.AnalisiStatistiche.bindCombo CaricaDpr = new TheSite.Classi.AnalisiStatistiche.bindCombo("PACK_RPT_PIANO_MAN_PROG.GetEdifici",drpEdificio,"System.String");
			CaricaDpr.getComboBox();
			drpEdificio.Items.Remove("");

			
			CaricaDpr.nomeSoredProcedure ="PACK_RPT_PIANO_MAN_PROG.GetServizi";
			CaricaDpr.testoItemZero = "Tutte le unità tecnologiche";
			CaricaDpr.tipoValue ="System.Int32";
			CaricaDpr.cmb = drpCategoriaTecnologica;
			CaricaDpr.getComboBox();
//			drpCategoriaTecnologica.Items.Remove("");

			CaricaDpr.nomeSoredProcedure ="PACK_RPT_PIANO_MAN_PROG.GetEqstd";
			CaricaDpr.testoItemZero = "Tutte le classi elemento";
			CaricaDpr.tipoValue ="System.Int32";
			CaricaDpr.cmb = drpClasseElemento;
			CaricaDpr.getComboBox();
			//drpClasseElemento.Items.Remove("");

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
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnGenera_Click(object sender, System.EventArgs e)
		{
			string QryStr = "?Anno=" + txtAnno.Text + "&Mese=" + drpMese.SelectedValue 
							+ "&ID_EDIFICIO=" + drpEdificio.SelectedValue 
							+ "&ID_SERVIZIO=" + drpCategoriaTecnologica.SelectedValue 
							+ "&ID_EQSTD=" + drpClasseElemento.SelectedValue;
			Hashtable _HS = new Hashtable();
			_HS.Clear();
			_HS.Add("Anno",txtAnno.Text);
			_HS.Add("MeseEsteso",drpMese.SelectedItem.Text);
			_HS.Add("Eedificio",drpEdificio.SelectedItem.Text);
			_HS.Add("Servizio",drpCategoriaTecnologica.SelectedItem.Text);
			_HS.Add("ClasseElemento",drpClasseElemento.SelectedItem.Text);
			if(Session["DataERRmp"] != null)
			{
				Session.Remove("DataERRmp");
			}
			Session.Add("DataERRmp",_HS);
			Server.Transfer("MostraPianoMP.aspx" + QryStr);
		}
	}
}
