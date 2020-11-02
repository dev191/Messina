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
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using TheSite.SchemiXSD;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using TheSite.Classi.AnalisiStatistiche;
using System.Configuration;

namespace TheSite.ReportGestioneSpazi
{
	
	/// <summary>
	/// Descrizione di riepilogo per DisplayReportSpazi.
	/// </summary>
	public class DisplayReportSpazi : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected bool S_Categorie, S_Destinazione, S_Reparti, S_Misure;
		protected string tipoDocumento;

		private enum nomiProcedure
		{		
			SP_GET_DISTR_REPARTI,
			SP_GET_DISTR_DEST_USO,
			SP_GET_DISTR_CAT,
			SP_GET_DISTR_MISURE
		}

		private enum nomiReport
		{
			RptSpaziDistrReparti_V9,
			RptSpaziDistrDestUso_V9,
			RptSpaziDistrCategorie_V9,
			RptSpaziDistrMusure_V9
		}

		private ReportDocument crReportDocument;
		private ExportOptions crExportOptions;
		protected CrystalDecisions.Web.CrystalReportViewer rptEngineOra;
		private DiskFileDestinationOptions crDiskFileDestinationOptions;

		private string stringaEdifici="";
		private string stringaReparto="";
		private string stringaDestinazione="";
		private string idCategoria="";
		private string stringaStanza="";
		protected System.Web.UI.WebControls.Label LabelMessaggio;
		private string piano="";

		private string operatoreMq="";
		protected System.Web.UI.WebControls.Button Button1;
		private string valoreMq ="";
	
		private void Page_Load(object sender, System.EventArgs e)
		{   
			// html o pdf?
			tipoDocumento = Request["tipoDocumento"];
			//recupera i parametri relativi al ripo dir eport da visualizzare
			S_Categorie		 = Convert.ToBoolean(Request["S_Categorie"]);
			S_Destinazione	 = Convert.ToBoolean(Request["S_Destinazione"]);
			S_Reparti		 = Convert.ToBoolean(Request["S_Reparti"]);
			S_Misure		 = Convert.ToBoolean(Request["S_Misure"]);

			stringaEdifici=Request["stringaEdifici"];
			stringaReparto=Request["stringaReparto"];
			stringaDestinazione=Request["stringaDestinazione"];
			idCategoria=Request["idCategoria"];
			stringaStanza=Request["stringaStanza"];
			piano=Request["piano"];
			operatoreMq=Request["operatoreMq"];
			valoreMq=Request["valoreMq"];
//			if (!IsPostBack)
//			{
				IpostaRpt();
//			}
		}

		#region Codice generato da Progettazione Web Form
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: questa chiamata è richiesta da Progettazione Web Form ASP.NET.
			//
			InitializeComponent();
			crReportDocument = new ReportDocument();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void IpostaRpt()
		{
			DsGestioneSpazi ds = new DsGestioneSpazi();
			ds = recuperaDataSet(ds);
			bindReport(ds);
		}	

		private void bindReport(DsGestioneSpazi dsRpt)
		{			
				
			string pathRptSource = Server.MapPath(Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]);

			string rptPath = Server.MapPath("../report/"+GetReportSource());
			crReportDocument.Load(rptPath);
			crReportDocument.SetDataSource(dsRpt);
			crReportDocument.SetParameterValue("tipo",tipoDocumento);
			
			switch(tipoDocumento)
			{
				case  "PDF" :
					string Fname = pathRptSource  + Session.SessionID.ToString() + ".pdf" ;
					crDiskFileDestinationOptions = new DiskFileDestinationOptions();
					crDiskFileDestinationOptions.DiskFileName = Fname;
					crExportOptions = crReportDocument.ExportOptions;
					crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
					crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
					crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
					crReportDocument.Export();
					Response.ClearContent();
					Response.ClearHeaders();
					Response.ContentType = "application/pdf";
					Response.WriteFile(Fname);
					Response.Flush();
					Response.Close();
					System.IO.File.Delete(Fname);
					break;
				case "HTML" :
					rptEngineOra.DisplayGroupTree=false;
					rptEngineOra.DisplayToolbar=true;
					rptEngineOra.SeparatePages = false;
					rptEngineOra.ReportSource = crReportDocument;
					break;
				default:
					// non fai nulla
					break;
			}
		}

		private DsGestioneSpazi recuperaDataSet(DsGestioneSpazi ds)
		{
			try
			{
				int index=0;
				Classi.AnalisiStatistiche.wrapDb _IODB = new TheSite.Classi.AnalisiStatistiche.wrapDb();
				S_Controls.Collections.S_ControlsCollection _Scollection = new S_Controls.Collections.S_ControlsCollection();

				S_Controls.Collections.S_Object p_Id_Edificio  = new S_Controls.Collections.S_Object();
				p_Id_Edificio.ParameterName = "p_Id_Edificio";
				p_Id_Edificio.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				p_Id_Edificio.Direction = ParameterDirection.Input;
				p_Id_Edificio.Size =300;
				p_Id_Edificio.Index = index++;
				p_Id_Edificio.Value = stringaEdifici;
				_Scollection.Add(p_Id_Edificio);

				S_Controls.Collections.S_Object p_Id_Piano  = new S_Controls.Collections.S_Object();
				p_Id_Piano.ParameterName = "p_Id_Piano";
				p_Id_Piano.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
				p_Id_Piano.Direction = ParameterDirection.Input;
				p_Id_Piano.Index = index++;
				if (piano=="")
					p_Id_Piano.Value = 0;
				else
					p_Id_Piano.Value = Convert.ToInt32(piano);
				_Scollection.Add(p_Id_Piano);

				S_Controls.Collections.S_Object p_Id_Stanza  = new S_Controls.Collections.S_Object();
				p_Id_Stanza.ParameterName = "p_Id_Stanza";
				p_Id_Stanza.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				p_Id_Stanza.Direction = ParameterDirection.Input;
				p_Id_Stanza.Size =255;
				p_Id_Stanza.Index = index++;
				p_Id_Stanza.Value = stringaStanza;
				_Scollection.Add(p_Id_Stanza);

				S_Controls.Collections.S_Object p_Str_Dest_Uso  = new S_Controls.Collections.S_Object();
				p_Str_Dest_Uso.ParameterName = "p_Str_Dest_Uso";
				p_Str_Dest_Uso.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				p_Str_Dest_Uso.Direction = ParameterDirection.Input;
				p_Str_Dest_Uso.Size =256;
				p_Str_Dest_Uso.Index = index++;
				p_Str_Dest_Uso.Value = stringaDestinazione;
				_Scollection.Add(p_Str_Dest_Uso);

				S_Controls.Collections.S_Object p_Str_Reparto  = new S_Controls.Collections.S_Object();
				p_Str_Reparto.ParameterName = "p_Str_Reparto";
				p_Str_Reparto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				p_Str_Reparto.Direction = ParameterDirection.Input;
				p_Str_Reparto.Size =255;
				p_Str_Reparto.Index = index++;
				p_Str_Reparto.Value = stringaReparto;
				_Scollection.Add(p_Str_Reparto);

				S_Controls.Collections.S_Object p_Str_Cat  = new S_Controls.Collections.S_Object();
				p_Str_Cat.ParameterName = "p_Str_Cat";
				p_Str_Cat.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				p_Str_Cat.Direction = ParameterDirection.Input;
				p_Str_Cat.Size =255;
				p_Str_Cat.Index = index++;
				p_Str_Cat.Value = idCategoria;
				_Scollection.Add(p_Str_Cat);

				S_Controls.Collections.S_Object p_Operatore_Area  = new S_Controls.Collections.S_Object();
				p_Operatore_Area.ParameterName = "p_Operatore_Area";
				p_Operatore_Area.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				p_Operatore_Area.Direction = ParameterDirection.Input;
				p_Operatore_Area.Size =255;
				p_Operatore_Area.Index = index++;
				p_Operatore_Area.Value = operatoreMq;
				_Scollection.Add(p_Operatore_Area);

				S_Controls.Collections.S_Object p_Int_MQ2  = new S_Controls.Collections.S_Object();
				p_Int_MQ2.ParameterName = "p_Int_MQ2";
				p_Int_MQ2.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
				p_Int_MQ2.Direction = ParameterDirection.Input;
				p_Int_MQ2.Index = index++;
				if (valoreMq=="")
					p_Int_MQ2.Value = 0;
				else
					p_Int_MQ2.Value = Convert.ToInt32(valoreMq);
				_Scollection.Add(p_Int_MQ2);

				S_Controls.Collections.S_Object IO_CURSOR  = new S_Controls.Collections.S_Object();
				IO_CURSOR.ParameterName = "IO_CURSOR";
				IO_CURSOR.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
				IO_CURSOR.Direction = ParameterDirection.Output;
				IO_CURSOR.Index = index++;
				_Scollection.Add(IO_CURSOR);

				_IODB.s_storedProcedureName="PACK_RPT_GESTIONE_SPAZI."+GetNomeStrPrd();
				DataSet _MyDataset = _IODB.GetData(_Scollection).Copy();
		
				SchemiXSD.DsGestioneSpazi.parametriRow rigaParametri = (SchemiXSD.DsGestioneSpazi.parametriRow)ds.parametri.NewRow();
				rigaParametri.edifici=stringaEdifici.Replace("','", " ");
				rigaParametri.stanza=stringaStanza;
				rigaParametri.categoria=idCategoria;
				rigaParametri.destUso=stringaDestinazione;
				rigaParametri.reparto=stringaReparto;
				rigaParametri.opMq=operatoreMq;
				rigaParametri.Mq=valoreMq;
				ds.Tables["parametri"].Rows.Add(rigaParametri);
				
				int i = 0;
				//string xml="";
				for(i=0; i<= _MyDataset.Tables[0].Rows.Count-1;i++)
				{ 
					if (!Convert.ToBoolean(S_Misure))
					{
						ds.Tables["tabellina"].ImportRow(_MyDataset.Tables[0].Rows[i]);
					}   
					else 
					{
						ds.Tables["tabellina2"].ImportRow(_MyDataset.Tables[0].Rows[i]);
						
					}
				}
				if(i==0)
				{
					throw new Eccezioni.NoDataForReportFoundException();
				}
				//xml=ds.GetXml();
				return ds;
			}
			catch(Eccezioni.NoDataForReportFoundException ex)
			{
				LabelMessaggio.Text="Non ho trovato alcun item per i parametri di ricerca delezionati";
				rptEngineOra.Visible=false;
				return null;
			}
			catch(Exception ex)
			{
				//Server.Transfer("Error.aspx?msgErr=" + ex.Message);
				throw ex;
				//return null;
			}
		}

		private string GetNomeStrPrd()
		{

			if (S_Categorie) return nomiProcedure.SP_GET_DISTR_CAT.ToString();
			else if (S_Destinazione) return nomiProcedure.SP_GET_DISTR_DEST_USO.ToString();
			else if (S_Misure) return nomiProcedure.SP_GET_DISTR_MISURE.ToString();
			else if (S_Reparti) return nomiProcedure.SP_GET_DISTR_REPARTI.ToString();
			else return "";

		}

		private string GetReportSource()
		{

			if (S_Categorie) return nomiReport.RptSpaziDistrCategorie_V9.ToString()+".rpt";
			else if (S_Destinazione) return nomiReport.RptSpaziDistrDestUso_V9.ToString()+".rpt";
			else if (S_Misure) return nomiReport.RptSpaziDistrMusure_V9.ToString()+".rpt";
			else if (S_Reparti) return nomiReport.RptSpaziDistrReparti_V9.ToString()+".rpt";
			else return "";

		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ReportGestioneSpazi.aspx");
		}
	}
}
