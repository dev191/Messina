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
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;

namespace TheSite.SoddisfazioneCliente
{
	/// <summary>
	/// Descrizione di riepilogo per KpiPianiProp.
	/// </summary>
	public class KpiPianiProp : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DrPriorita;
		protected System.Web.UI.WebControls.DropDownList DropAnno;
		protected S_Controls.S_Button btnsRicerca;
		protected S_Controls.S_Button btnReset;
		protected System.Web.UI.WebControls.Repeater Repeater1;
		protected System.Web.UI.WebControls.DropDownList DrMese;
		protected System.Web.UI.WebControls.Repeater Repeater2;
		protected System.Web.UI.WebControls.Repeater Repeater3;
		protected System.Web.UI.HtmlControls.HtmlTable pianiMens;
		protected System.Web.UI.HtmlControls.HtmlTable totAtt;
		protected WebControls.RicercaModulo RicercaModulo1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
				LoadAnno();
		}
		private void LoadAnno()
		{
			for(int i=2008;i<=2020;i++)
				DropAnno.Items.Add(new ListItem(i.ToString(),i.ToString()));  
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
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			Ricerca();
		}
		private void Ricerca()
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new  S_Controls.Collections.S_ControlsCollection();
			


			S_Controls.Collections.S_Object s_p_mese = new S_Controls.Collections.S_Object();
			s_p_mese.ParameterName = "p_mese";
			s_p_mese.DbType = CustomDBType.VarChar;
			s_p_mese.Size=2;
			s_p_mese.Direction = ParameterDirection.Input;
			s_p_mese.Index = CollezioneControlli.Count;
			s_p_mese.Value =  DrMese.SelectedValue;		
			CollezioneControlli.Add(s_p_mese);

			S_Controls.Collections.S_Object s_p_anno = new S_Controls.Collections.S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.VarChar;
			s_p_anno.Size=4;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Index = CollezioneControlli.Count;
			s_p_anno.Value =  DropAnno.SelectedValue;		
			CollezioneControlli.Add(s_p_anno);
			
			S_Controls.Collections.S_Object s_p_idbl = new S_Controls.Collections.S_Object();
			s_p_idbl.ParameterName = "p_idbl";
			s_p_idbl.DbType = CustomDBType.VarChar;
			s_p_idbl.Size=4;
			s_p_idbl.Direction = ParameterDirection.Input;
			s_p_idbl.Index = CollezioneControlli.Count;
			s_p_idbl.Value =  RicercaModulo1.BlId;	
			CollezioneControlli.Add(s_p_idbl);

			Classi.SoddCliente.Soddisfato _Kpi = new TheSite.Classi.SoddCliente.Soddisfato();
			DataSet Ds = _Kpi.GetPianiMensili(CollezioneControlli);

			Repeater1.DataSource=Ds;
			Repeater1.DataBind(); 
		
		}
	}
}
