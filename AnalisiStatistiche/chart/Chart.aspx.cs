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

namespace chart
{
	
	/// <summary>
	/// Descrizione di riepilogo per Chart.
	/// </summary>
	public class Chart : System.Web.UI.Page
	{
		
		protected Int32 latoFrame,Npx,Nhh,Rdisco,ScalaLinare,ScalaLogaritmica,i_Tipologia,Anno;
		protected string urlChart,S_optBtnRdlDispersioneAC,S_optBtnRdlDispersioneRA,S_optBtnRdlDispersioneRC;
		protected float zoom,esponente;
		private enum TipoM {Richiesta = 1,Programmata,Straordinaria,Entrambe};

		protected System.Web.UI.WebControls.TextBox TxtNore;
		protected System.Web.UI.WebControls.DropDownList drpzoom;
		protected System.Web.UI.WebControls.RadioButton RbtLineare;
		protected System.Web.UI.WebControls.RadioButton RbtLogaritmica;
		protected System.Web.UI.WebControls.TextBox TxtEsponente;
		protected System.Web.UI.WebControls.TextBox txtRaggioLabel;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator2;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator3;
		protected System.Web.UI.WebControls.Button sbtSubmit;
		protected System.Web.UI.WebControls.RangeValidator RangeValidatorRaggioLabel;
		protected System.Web.UI.WebControls.TextBox TxtAnno;

	
		private void Page_Load(object sender, System.EventArgs e)

		{
			if(!IsPostBack)
			{
				TxtAnno.Text =  System.DateTime.Now.Year.ToString();
			}
			RecuperoParametri();
			ImpostaChart();
			DysplayChart();

			
	
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
			this.sbtSubmit.Click += new System.EventHandler(this.Submit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void ImpostaChart()
		{

				
			RbtLineare.Attributes.Add("onclick","enableLiniare();");
			RbtLogaritmica.Attributes.Add("onclick","enableLogaritmica();");
			if(RbtLineare.Checked ==true)
			{
				TxtEsponente.Enabled= false;
				drpzoom.Enabled= true;
				ScalaLinare =1;
			}
			else
			{
				ScalaLinare = 0;
				TxtEsponente.Enabled= true;
				drpzoom.SelectedIndex=4;
				drpzoom.Enabled= false;
			}
			if(RbtLogaritmica.Checked == true)
			{
				ScalaLogaritmica =1;
			}
			else
			{
				ScalaLogaritmica = 0;
			}
			Anno = Convert.ToInt32(TxtAnno.Text.ToString());
			esponente = Convert.ToSingle(TxtEsponente.Text.ToString());
			Rdisco = Convert.ToInt32(txtRaggioLabel.Text.ToString());	
			Npx =3;
			Nhh = Convert.ToInt32(Convert.ToInt32(TxtNore.Text));
			if(!IsPostBack)
			{
				impostaZoom();
			}
			zoom = Convert.ToSingle(drpzoom.SelectedValue);	
		}
		private void impostaZoom()
		{

			drpzoom.Items.Add(new ListItem("20%","0,20" ));
			drpzoom.Items.Add(new ListItem("25%","0,25" ));
			drpzoom.Items.Add(new ListItem("50%","0,50" ));
			drpzoom.Items.Add(new ListItem("75%","0,75" ));
			drpzoom.Items.Add(new ListItem("100%","1,0" ));
			drpzoom.Items.Add(new ListItem("125%","1,2" ));
			drpzoom.Items.Add(new ListItem("150%","1,5" ));
			drpzoom.Items.Add(new ListItem("200%","2,0" ));
			drpzoom.Items.Add(new ListItem("500%","5,0"));
			drpzoom.SelectedIndex=4;
			
		}
		private void Submit_Click(object sender, System.EventArgs e)
		{
			DysplayChart();
		}

		private void RecuperoParametri()
		{
			switch(Request["tipologia"])
			{
				case "1":
					i_Tipologia =(int)TipoM.Richiesta;
					break;
				case "2":
					i_Tipologia=(int)TipoM.Programmata;
					break;
				case "3":
					i_Tipologia = (int)TipoM.Straordinaria;
					break;
				case "4":
					i_Tipologia = (int)TipoM.Entrambe;
					break;
				default:
					i_Tipologia= 0;
					break;
			}
			S_optBtnRdlDispersioneAC=Request["S_optBtnRdlDispersioneAC"];
			S_optBtnRdlDispersioneRA=Request["S_optBtnRdlDispersioneRA"];
			S_optBtnRdlDispersioneRC=Request["S_optBtnRdlDispersioneRC"];

		}
		private void DysplayChart()
		{
			if(RbtLineare.Checked == true)
			{
				latoFrame =  Convert.ToInt32(zoom *  Npx * 2 * Nhh) +2*Rdisco + Convert.ToInt32(2* 10* Npx*zoom+ 50);
			}
			if(RbtLogaritmica.Checked  == true)
			{
				float MezzoLatoFrame = Convert.ToSingle(Math.Log(zoom *  Npx * Nhh )* Math.Exp(esponente) + Rdisco +25);
				float FlatoFrame = 2.0F * MezzoLatoFrame+50;
				latoFrame =   Convert.ToInt32(FlatoFrame);
			}

			urlChart = "./pagine/demo.aspx?Npx=" + Npx + "&Nhh=" + Nhh + "&zoom=" + zoom + "&Rdisco=" + 
				Rdisco + "&ScalaLinare=" + ScalaLinare  + "&ScalaLogaritmica=" + ScalaLogaritmica +  
				"&esponente=" + esponente + "&Anno=" + Anno + "&S_optBtnRdlDispersioneAC=" + S_optBtnRdlDispersioneAC +
				"&S_optBtnRdlDispersioneRA="+S_optBtnRdlDispersioneRA+"&S_optBtnRdlDispersioneRC="+S_optBtnRdlDispersioneRC
				+"&i_Tipologia=" +i_Tipologia;
		}
	}

}
