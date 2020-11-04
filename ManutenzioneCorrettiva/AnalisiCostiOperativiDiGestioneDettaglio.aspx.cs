using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCollection;
using System.Web.UI.HtmlControls;
using System.Reflection;
using TheSite.WebControls;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using TheSite.Classi.ClassiDettaglio;
using S_Controls.Collections;
using System.Globalization;


namespace TheSite.ManutenzioneCorrettiva
{
	/// <summary>
	/// Descrizione di riepilogo per AnalisiMaterialiImpiegati.
	/// </summary>
	public class AnalisiCostiOperativiDiGestioneDettaglio : System.Web.UI.Page
	{
		private string wrId;
		protected materiali mtImpegnati;
		protected Csy.WebControls.DataPanel DataPanelRicerca;
		protected CostiManodopera cstAddetti;
		protected System.Web.UI.WebControls.Button btnChiudi;
		protected Csy.WebControls.DataPanel DataPanelRicerca1;
		protected System.Web.UI.WebControls.Button BntIndietro;
		protected PageTitle PgTitleCostiGestioneDettaglio;
		public Classi.SiteModule _SiteModule;
		protected System.Web.UI.WebControls.Label LblOdL;
		protected System.Web.UI.WebControls.Label LblRdL;
		protected System.Web.UI.WebControls.Label LblRichiedente;
		protected System.Web.UI.WebControls.Label LblTelefono;
		protected System.Web.UI.WebControls.Label LblDataRichiesta;
		protected System.Web.UI.WebControls.Label LblFabbricato;
		protected System.Web.UI.WebControls.Label LblServizi;
		protected System.Web.UI.WebControls.Label LblDescIntervento;
		protected System.Web.UI.WebControls.Label LblDataPianificata;
		protected System.Web.UI.WebControls.Label LblDataInizio;
		protected System.Web.UI.WebControls.Label LblDataFine;
		protected System.Web.UI.WebControls.Label LblStatoRic;
		protected System.Web.UI.WebControls.Label LblAddetto;
		protected System.Web.UI.WebControls.Label LblTipoIntervento;
		protected System.Web.UI.WebControls.Label LblSpesaPresunta;
		protected System.Web.UI.WebControls.Label LblOdLCommit;
		protected System.Web.UI.WebControls.Label LblAnnMatUtil;
		protected System.Web.UI.HtmlControls.HtmlTableRow TrMs;
		protected System.Web.UI.WebControls.Label LblUrgenza;
		bool IsEditable = false;
		EditCompletamento _fp;
		string chiamante="";
		protected System.Web.UI.WebControls.Literal LblTotale;
		Double tot;

		private void Page_Load(object sender, System.EventArgs e)
		{
			wrId = Request["WR_ID"];
			PgTitleCostiGestioneDettaglio.Title="DETTAGLIO COSTI OPERATIVI DI GESTIONE RDL " + wrId;
			LblRdL.Text=wrId;
			CaricaIntestazione();
			//DataPanelRicerca.Width=800;
			cstAddetti.wrId = Convert.ToInt32(wrId);
			mtImpegnati.wrId= Convert.ToInt32(wrId);
			string _mypage = "AnalisiCostiOperativiDiGestioneDettaglio.aspx";
			_SiteModule = new TheSite.Classi.SiteModule(_mypage);
			this.IsEditable = _SiteModule.IsEditable;
			if(!Page.IsPostBack)
			{
				Classi.ManCorrettiva.ClManCorrettiva _Totale = new TheSite.Classi.ManCorrettiva.ClManCorrettiva();
				DataSet DsManodopera = _Totale.TotManodopera(Convert.ToInt32(wrId));
				if(DsManodopera.Tables[0].Rows.Count>0)
					tot=Convert.ToDouble(DsManodopera.Tables[0].Rows[0]["totaddetto"])+Convert.ToDouble(DsManodopera.Tables[0].Rows[0]["totmateriale"]);
		
				LblTotale.Text= FormattaDecimali(tot,2);
				
		
			}


			#region Recupero la proprieta di ricerca
			
			Type myType=Context.Handler.GetType();   
			if(Request.QueryString["chiamante"]!=null)
				chiamante=Request.QueryString["chiamante"].ToString();
			PropertyInfo myPropInfo = myType.GetProperty("_Contenitore");
			if(myPropInfo!=null)
				this.ViewState.Add("mioContenitore",myPropInfo.GetValue(Context.Handler,null));
			#endregion
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
			this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
			this.BntIndietro.Click += new System.EventHandler(this.BntIndietro_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnChiudi_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("AnalisiCostiOperativiDiGestione.aspx");
		}

		protected string FormattaDecimali(object numero,object cifre)
		{
			NumberFormatInfo nfi = new CultureInfo( "it-IT", false ).NumberFormat;
			nfi.NumberDecimalDigits = Convert.ToInt32(cifre);			
			decimal numFormattato;
			if(numero!=System.DBNull.Value)
			{
				numFormattato = Convert.ToDecimal(numero);
				return numFormattato.ToString("N",nfi);
			}
			else
				return String.Empty;
		}

		private void CaricaIntestazione()
		{
			DateTime appo;

			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ManCorrettiva.ClManCorrettiva  _intestazione = new TheSite.Classi.ManCorrettiva.ClManCorrettiva();

			DataSet _MyDs;

			S_Controls.Collections.S_Object s_p_wr_id = new S_Object();
			s_p_wr_id.ParameterName = "p_wr_id";
			s_p_wr_id.DbType = CustomDBType.Integer;
			s_p_wr_id.Direction = ParameterDirection.Input;
			s_p_wr_id.Index = 0;
			s_p_wr_id.Value =wrId;
			CollezioneControlli.Add(s_p_wr_id);				
			

			_MyDs = _intestazione.GetSingleRdL(CollezioneControlli);

			if (_MyDs.Tables[0].Rows.Count>0)
			{
				if(_MyDs.Tables[0].Rows[0]["addetto"]!= DBNull.Value)
					LblAddetto.Text=_MyDs.Tables[0].Rows[0]["addetto"].ToString();

				if(_MyDs.Tables[0].Rows[0]["annotazionimateriale"]!= DBNull.Value)
					LblAnnMatUtil.Text=_MyDs.Tables[0].Rows[0]["annotazionimateriale"].ToString();
			
				if(_MyDs.Tables[0].Rows[0]["datafine"]!= DBNull.Value)
				{
					appo= Convert.ToDateTime(_MyDs.Tables[0].Rows[0]["datafine"]);
					LblDataFine.Text=appo.ToString("g");
				}

				if(_MyDs.Tables[0].Rows[0]["datainizio"]!= DBNull.Value)
				{
					appo= Convert.ToDateTime(_MyDs.Tables[0].Rows[0]["datainizio"]);
					LblDataInizio.Text=appo.ToString("g");
				}
				if(_MyDs.Tables[0].Rows[0]["datapianificata"]!= DBNull.Value)
				{
					appo= Convert.ToDateTime(_MyDs.Tables[0].Rows[0]["datapianificata"]);
					LblDataPianificata.Text=appo.ToString("g");
				}
				if(_MyDs.Tables[0].Rows[0]["datarichiesta"]!= DBNull.Value)
				{
					appo= Convert.ToDateTime(_MyDs.Tables[0].Rows[0]["datarichiesta"]);
					LblDataRichiesta.Text=appo.ToString("g");
				}

				if(_MyDs.Tables[0].Rows[0]["descintervento"]!= DBNull.Value)
					LblDescIntervento.Text=_MyDs.Tables[0].Rows[0]["descintervento"].ToString();

				if(_MyDs.Tables[0].Rows[0]["fabbricato"]!= DBNull.Value)
					LblFabbricato.Text=_MyDs.Tables[0].Rows[0]["fabbricato"].ToString();
				
				if(_MyDs.Tables[0].Rows[0]["odl"]!= DBNull.Value)
				{
					LblOdL.Text=_MyDs.Tables[0].Rows[0]["odl"].ToString();
					PgTitleCostiGestioneDettaglio.Title="DETTAGLIO COSTI OPERATIVI DI GESTIONE RDL  " + wrId +" OdL  " +LblOdL.Text;
				}

				if(_MyDs.Tables[0].Rows[0]["ordinedilavorocommittente"]!= DBNull.Value)
					LblOdLCommit.Text=_MyDs.Tables[0].Rows[0]["ordinedilavorocommittente"].ToString();
				
				if(_MyDs.Tables[0].Rows[0]["richiedente"]!= DBNull.Value)
					LblRichiedente.Text=_MyDs.Tables[0].Rows[0]["richiedente"].ToString();

				if(_MyDs.Tables[0].Rows[0]["servizi"]!= DBNull.Value)
					LblServizi.Text=_MyDs.Tables[0].Rows[0]["servizi"].ToString();

				if(_MyDs.Tables[0].Rows[0]["spesapresunta"]!= DBNull.Value)
					LblSpesaPresunta.Text=_MyDs.Tables[0].Rows[0]["spesapresunta"].ToString();

				if(_MyDs.Tables[0].Rows[0]["statorichiesta"]!= DBNull.Value)
					LblStatoRic.Text=_MyDs.Tables[0].Rows[0]["statorichiesta"].ToString();

				if(_MyDs.Tables[0].Rows[0]["telefono"]!= DBNull.Value)
					LblTelefono.Text=_MyDs.Tables[0].Rows[0]["telefono"].ToString();

				if(_MyDs.Tables[0].Rows[0]["tipointerveto"]!= DBNull.Value)
					LblTipoIntervento.Text=_MyDs.Tables[0].Rows[0]["tipointerveto"].ToString();

				if(_MyDs.Tables[0].Rows[0]["urgenza"]!= DBNull.Value)
					LblUrgenza.Text=_MyDs.Tables[0].Rows[0]["urgenza"].ToString();


				if (_MyDs.Tables[0].Rows[0]["tipomanutenzione"]!= DBNull.Value)
					if (_MyDs.Tables[0].Rows[0]["tipomanutenzione"].ToString()!="3")
					TrMs.Attributes.Add("style","DISPLAY:none");
			}
		}

		private void BntIndietro_Click(object sender, System.EventArgs e)
		{
			
			
			if (chiamante=="")
				Server.Transfer("AnalisiCostiOperativiDiGestione.aspx");
			else
			{
				string appo =chiamante.Split('.')[1].ToString();
				string appo1=appo.Split('_')[0].ToString();
				string url= appo1+".aspx?wr_id="+wrId+"&c=c";
				Server.Transfer(url);
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


	}
}
