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

namespace TheSite.ManutenzioneCorretiva
{
	/// <summary>
	/// Descrizione di riepilogo per Report.
	/// </summary>
	
	public class Report : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected S_Controls.S_ComboBox cmbsAnno;
		protected System.Web.UI.WebControls.Button BtnRicerca;
		protected S_Controls.S_Label lblAterFondo;
		protected S_Controls.S_Label lblInSqlFondo;
		protected S_Controls.S_Label lblRicqFondo;
		protected S_Controls.S_Label lblServenFondo;
		protected S_Controls.S_Label lblAterSpeso;
		protected S_Controls.S_Label lblInSqlSpeso;
		protected S_Controls.S_Label lblRicqSpeso;
		protected S_Controls.S_Label lblServenlSpeso;
		protected S_Controls.S_Label lblAterSaldo;
		protected S_Controls.S_Label lblInSqlSaldo;
		protected S_Controls.S_Label lblRicqSaldo;
		protected S_Controls.S_Label lblServenlSaldo;
		protected S_Controls.S_Label lblAterPresunto;
		protected S_Controls.S_Label lblInsqlPresunto;
		protected S_Controls.S_Label lblRiicqresunto;
		protected S_Controls.S_Label lblServenPresunto;
		protected Csy.WebControls.DataPanel DataPanel3;
		protected System.Web.UI.WebControls.CheckBox CheckExcel;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdfondi;
		protected System.Web.UI.WebControls.CheckBox CheckDescrizione;
		protected System.Web.UI.WebControls.CheckBox CheckServizio;
		protected System.Web.UI.HtmlControls.HtmlTable TblExcel;
		public static string HelpLink = string.Empty;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			HelpLink = _SiteModule.HelpLink;
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{
				CaricaAnno();				
				TblExcel.Visible=false;
				//this.PageTitle1. = "SFOGLIA RDL CORRETTIVA";
			}
		}
		/// <summary>
		/// Esegue il bindig dei Dati
		/// </summary>
		private void CaricaAnno()
		{
			//Carico il Combo degli Anni
			string anno_corrente = DateTime.Now.Year.ToString();
			for (int i = 2000; i <= 2010; i++)
			{ 	
				ListItem _L1 = new ListItem();
				ListItem _L2 = new ListItem();
				_L1.Text=i.ToString();
				_L1.Value=i.ToString();
				_L2.Text=i.ToString();
				_L2.Value=i.ToString();				
				cmbsAnno.Items.Add(_L2);
			}
			cmbsAnno.SelectedValue = DateTime.Now.Year.ToString();
		}
		private void CaricaTabella()
		{
			Classi.ManStraordinaria.Report _Report = new TheSite.Classi.ManStraordinaria.Report(); 
					
			DataSet _MyDs = _Report.GetDatiFondo(Int16.Parse(cmbsAnno.SelectedValue)).Copy();			
					

			if (_MyDs.Tables[0].Rows.Count != 0)
			{
				TblExcel.Visible=true;

				Table _TblFondi = new Table();								
				
				// -------- Intestazione di Riga --------------------------------------

				TableRow _tr = new TableRow();								
				
				TableCell  _tdintblank = new TableCell();
				_tdintblank.Text="&nbsp;";
				_tr.Cells.Add(_tdintblank);

				foreach (DataRow _Dr in _MyDs.Tables[0].Rows)
				{					
					TableCell  _td = new TableCell();
					_td.Text="<b>" +  _Dr["descrizione_breve"].ToString() + "</b>";					
					_tr.Cells.Add(_td);
				}

				//-------- Creo la Riga con l'importo del Fondo ------------------------

				TableRow _tr1 = new TableRow();
				//Intestazione di Riga
				TableCell  _tdintFondo = new TableCell();
				_tdintFondo.Text="<b>Importo netto Fondo</b>";	
				_tdintFondo.Attributes.Add("align","left");
				_tr1.Cells.Add(_tdintFondo);				
				foreach (DataRow _Dr in _MyDs.Tables[0].Rows)
				{
					TableCell  _td = new TableCell();
					string imp = Double.Parse(_Dr["IMPORTO_NETTO"].ToString()).ToString("C");
					_td.Text=imp;
					_td.Attributes.Add("onclick","ApriReportFondo('"+_Dr["id"].ToString()+"')");
					_td.Attributes.Add("style","cursor:hand");
					_td.ToolTip="Visualizza il Report per Tipo Intervento: " + _Dr["descrizione_breve"].ToString(); 
					
					_tr1.Cells.Add(_td);
				}
				_tr1.Attributes.Add("align","right");
				
				
				//---------- Creo la Riga con l'importo dell'importo netto Speso ---------+

				TableRow _tr2 = new TableRow();
				//Intestazione di Riga
				TableCell  _tdintSpeso = new TableCell();
				_tdintSpeso.Text="<b>Importo netto Speso</b>";
				_tdintSpeso.Attributes.Add("align","left");
				_tr2.Cells.Add(_tdintSpeso);								
				foreach (DataRow _Dr in _MyDs.Tables[0].Rows)
				{
					TableCell  _td = new TableCell();
					_td.Text=CalcolaSpeso(_Dr["tipointervento_id"].ToString(),cmbsAnno.SelectedValue);
					_td.Attributes.Add("onclick","ApriReport(cmbsAnno.value," + _Dr["tipointervento_id"].ToString()+",'"+_Dr["descrizione_breve"].ToString() +"');");
					_td.Attributes.Add("style","cursor:hand");
					_td.ToolTip="Visualizza il Report per Tipo Intervento: " + _Dr["descrizione_breve"].ToString(); 
					_tr2.Cells.Add(_td);
				}
				_tr2.Attributes.Add("align","right");
				
				//----------- Creo la Riga con l'importo del Saldo ----------------

				TableRow _tr4 = new TableRow();
				//Intestazione di Riga
				TableCell  _tdintSaldo = new TableCell();
				_tdintSaldo.Text="<b>Saldo</b>";
				_tdintSaldo.Attributes.Add("align","left");
				_tr4.Cells.Add(_tdintSaldo);												
				foreach (DataRow _Dr in _MyDs.Tables[0].Rows)
				{
					TableCell  _td = new TableCell();
					Conti _Sld =CalcolaSaldo(_Dr["tipointervento_id"].ToString(),cmbsAnno.SelectedValue);
					_td.Text=_Sld.Saldo;
					_td.Attributes.Add("onclick","ApriReportSaldo(cmbsAnno.value," + _Dr["tipointervento_id"].ToString()+",'"+_Dr["descrizione_breve"].ToString() +"','"+_Sld.Fondo+"');");
					_td.Attributes.Add("style","cursor:hand");
					_td.ToolTip="Visualizza il Report per Tipo Intervento: " + _Dr["descrizione_breve"].ToString(); 
					_tr4.Cells.Add(_td);
				}
				_tr4.Attributes.Add("align","right");
				
				//------------ Creo la Riga con l'importo del Presunto ---------------

				TableRow _tr3 = new TableRow();								
				//Intestazione di Riga
				TableCell  _tdintPresunto = new TableCell();
				_tdintPresunto.Text="<b>Presunto</b>";
				_tdintPresunto.Attributes.Add("align","left");
				_tr3.Cells.Add(_tdintPresunto);								
				foreach (DataRow _Dr in _MyDs.Tables[0].Rows)
				{
					TableCell  _td = new TableCell();
					_td.Text=CalcolaPresunto(_Dr["tipointervento_id"].ToString(),cmbsAnno.SelectedValue);
					_td.Attributes.Add("onclick","ApriReportPresunto(cmbsAnno.value," + _Dr["tipointervento_id"].ToString()+",'"+_Dr["descrizione_breve"].ToString() +"');");
					_td.Attributes.Add("style","cursor:hand");
					_td.ToolTip="Visualizza il Report per Tipo Intervento: " + _Dr["descrizione_breve"].ToString(); 
					_tr3.Cells.Add(_td);
				}
				_tr3.Attributes.Add("align","right");

				_TblFondi.Rows.Add(_tr); // Riga Intestazione
				_TblFondi.Rows.Add(_tr1);// Riga importo netto Fondo
				_TblFondi.Rows.Add(_tr2);// Riga importo netto Speso
				_TblFondi.Rows.Add(_tr4);// Riga Saldo
				_TblFondi.Rows.Add(_tr3);// Riga Presunto
				
				
				_TblFondi.Attributes.Add("border","1");
				
				tdfondi.Controls.Add(_TblFondi);			
			}
			else
			{
				TblExcel.Visible=false;
			}
			
		}
		private string CalcolaSpeso(string idTipoIntervento,string anno)
		{		
			Classi.ManStraordinaria.Report _Report = new TheSite.Classi.ManStraordinaria.Report();
			DataSet _MyDs = _Report.GetDatiSpeso(Int16.Parse(idTipoIntervento),Int16.Parse(anno));
			DataRow _Dr;
			string importo="€ 0,00";
			if(_MyDs.Tables[0].Rows.Count!=0)
			{
				_Dr = _MyDs.Tables[0].Rows[0];
				if (_Dr[0] != DBNull.Value)
					importo=Double.Parse(_Dr[0].ToString()).ToString("C");
			}	
			return importo;
		}
		private string CalcolaPresunto(string idTipoIntervento,string anno)
		{
			Classi.ManStraordinaria.Report _Report = new TheSite.Classi.ManStraordinaria.Report();
			DataSet _MyDs = _Report.GetDatiPresunto(Int16.Parse(idTipoIntervento),Int16.Parse(anno));
			DataRow _Dr;
			string importo="€ 0,00";
			if(_MyDs.Tables[0].Rows.Count!=0)
			{
				_Dr = _MyDs.Tables[0].Rows[0];
				if (_Dr[0] != DBNull.Value)
					importo=Double.Parse(_Dr[0].ToString()).ToString("C");
			}	
			return importo;
		}
		private Conti CalcolaSaldo(string idTipoIntervento,string anno)
		{
			Classi.ManStraordinaria.Report _Report = new TheSite.Classi.ManStraordinaria.Report();
			DataSet _MyDs = _Report.GetDatiSaldo(Int16.Parse(idTipoIntervento),Int16.Parse(anno));
			DataRow _Dr;			
			Conti _S = new Conti();
			if(_MyDs.Tables[0].Rows.Count!=0)
			{
				_Dr = _MyDs.Tables[0].Rows[0];
				if (_Dr["Saldo"] != DBNull.Value)
					_S.Saldo=Double.Parse(_Dr["Saldo"].ToString()).ToString("C");
				if (_Dr["Fondo"] != DBNull.Value)
					_S.Fondo=Double.Parse(_Dr["Fondo"].ToString()).ToString("C");
			}	
			return _S;
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
			this.BtnRicerca.Click += new System.EventHandler(this.BtnRicerca_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BtnRicerca_Click(object sender, System.EventArgs e)
		{
			CaricaTabella();
		}

		
	}
	public class Conti
	{
		public string Saldo;
		public string Fondo;		
	}
}
