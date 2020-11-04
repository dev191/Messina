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
using ApplicationDataLayer.DBType;
using MyCollection;
using System.Reflection;

namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per Associazione_EQ_PMS.
	/// </summary>
	public class Associazione_EQ_PMS : System.Web.UI.Page
	{
		protected S_Controls.S_Button cmdAssocia;
		public string TotEQ = "";
		public string p_totEQSTDinEQ = "";
		public string p_totEQinPMS = "";
		public string p_totEQnoPMS = "";
		public string p_totEQSTDinPMP = "";
		public string p_totEQSTDEQinPMP = "";
		public string p_totEQSTD = "";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();

			sbValid.Append("this.value = 'Attendere ...';");

			sbValid.Append("this.disabled = true;");

			sbValid.Append("document.getElementById('" + cmdAssocia.ClientID + "').disabled = true;");

			sbValid.Append(this.Page.GetPostBackEventReference(this.cmdAssocia));
			sbValid.Append(";");
			this.cmdAssocia.Attributes.Add("onclick", sbValid.ToString());

			if (!Page.IsPostBack)
			{				
				Conta();
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
			this.cmdAssocia.Click += new System.EventHandler(this.cmdAssocia_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdAssocia_Click(object sender, System.EventArgs e)
		{
			Classi.ManProgrammata.AssEQ_PMS _ass = new TheSite.Classi.ManProgrammata.AssEQ_PMS();
			int Associate = _ass.Associa();
			Classi.SiteJavaScript.msgBox(this.Page,string.Format("ASSOCIAZIONI GENERATE PER APPARECCHIATURE NEL PIANO DI MANUTENZIONE STANDARD N. {0} ",Associate));
			Conta();
		}

		private void Conta()
		{
			string[] Parametri = new string[7];
			Classi.ManProgrammata.AssEQ_PMS _ass = new TheSite.Classi.ManProgrammata.AssEQ_PMS();
			Parametri = _ass.GetValueParametri();
			TotEQ = Parametri[0].ToString();
			p_totEQSTDinEQ = Parametri[1].ToString();
			p_totEQinPMS = Parametri[2].ToString();
			p_totEQnoPMS = Parametri[3].ToString();
			p_totEQSTDinPMP = Parametri[4].ToString();
			p_totEQSTDEQinPMP = Parametri[5].ToString();
			p_totEQSTD = Parametri[6].ToString();
		}
	}
}
