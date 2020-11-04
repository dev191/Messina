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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using TheSite.Classi.SchedeEq;
using TheSite.SchemiXSD;
using System.IO;
using System.Configuration;
using MyCollection;

namespace TheSite.ShedeEq
{
	/// <summary>
	/// Descrizione di riepilogo per VisualizzaSchedaHtml.
	/// </summary>
	public class VisualizzaSchedaHtml : System.Web.UI.Page
	{
		protected CrystalReportViewer CryVwSchedaEq;
		protected ReportDocument  crReportDocument;
		public TheSite.ShedeEq.FiltraApparecchiature fp;
		protected System.Web.UI.WebControls.Button btnIndietro;
		MyCollection.clMyCollection _myColl = new MyCollection.clMyCollection();
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		TheSite.ShedeEq.FiltraApparecchiature _fp;
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
		private void Page_Load(object sender, System.EventArgs e)
		{
			bool FromWebCad = false;
			if(Request["FromWebCad"]!= null)
			{
					FromWebCad = true;				
			}
			if(!IsPostBack)
			{
			
				if(Context.Handler is TheSite.ShedeEq.FiltraApparecchiature)
				{
					_fp = (TheSite.ShedeEq.FiltraApparecchiature) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore);	
					
				}
				if(FromWebCad)
				{
					btnIndietro.Visible = false;
				}
				
			}
			ImpostaRpt(FromWebCad);
		}

		private void ImpostaRpt(bool FromWebCad)
		{
			string Eq_id= String.Empty;
			if(FromWebCad)
			{
				Eq_id = Request["id_eq"];
			}
			else
			{
				Eq_id = recuperaEqId();	
			}
			DatiShcedeEq myDati = new DatiShcedeEq(Eq_id);
			NewDataSet ds = myDati.GetDsTipizzato();
			if(ds.Tables["TblGenerale"].Rows.Count >0)
			{
				foreach(DataRow dr in ds.Tables["TblGenerale"].Rows)
				{
					if(dr["EQ_IMAGE_EQ_ASSY"] != DBNull.Value)
					{
						if(ControllaFoto(dr["EQ_IMAGE_EQ_ASSY"].ToString()))
						{
							dr["EQ_IMMAGINI_IMMAGINE"] = GetPhoto(dr["EQ_IMAGE_EQ_ASSY"].ToString());
						}
						else
						{
							dr["EQ_IMMAGINI_IMMAGINE"] = GetPhoto("ImmagineNonDisponibile.jpg");
						}
					}
					else
					{
						dr["EQ_IMMAGINI_IMMAGINE"] = GetPhoto("ImmagineNonDisponibile.jpg");
					}
				}
			}
			
//			DataGrid1.DataSource = ds.Tables["TblAllegatiEstesa"];
//			DataGrid1.DataBind();
//			DataGrid2.DataSource = ds.Tables["TblManRic"];
//			DataGrid2.DataBind();
//			DataGrid3.DataSource = ds.Tables["TblManProg"];
//			DataGrid3.DataBind();
//			DataGrid4.DataSource = ds.Tables["TblManStra"];
//			DataGrid4.DataBind();
			//	ds.WriteXmlSchema(@"c:/tmp/ScmReport.xsd");
			//
			string pathRptSource = Server.MapPath(Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]);
			crReportDocument.Load(pathRptSource + "RptChedeEq_V9.rpt");
			crReportDocument.SetDataSource(ds);

			CryVwSchedaEq.ReportSource = crReportDocument;
//			DataGrid1.DataSource = ds.Tables["TblAllegati"];
//			DataGrid1.DataBind();


		}
		private bool ControllaFoto(string NomePhoto)
		{
			bool ret;
			if(File.Exists(Server.MapPath("../EQImages/" + NomePhoto)))
				ret= true;
			else
				ret= false;
			return ret;
		}
		private  byte[] GetPhoto(string fileName)
		{
			string filePath = Server.MapPath(Request.ApplicationPath + ConfigurationSettings.AppSettings["ImmaginiEq"] + fileName );
			if(File.Exists(filePath))
			{
				FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
				BinaryReader br = new BinaryReader(fs);
				byte[] photo = br.ReadBytes((int)fs.Length);
				br.Close();
				fs.Close();
				return photo;
			}
			else
			{
				return null;
			}
			
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
			this.btnIndietro.Click += new System.EventHandler(this.btnIndietro_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private string recuperaEqId()
		{
			string strEqId=String.Empty;
			if(Session["DatiList"]!=null)
			{
				Hashtable _HS = (Hashtable)Session["DatiList"];
				IDictionaryEnumerator myEnumerator = _HS.GetEnumerator();								
				while (myEnumerator.MoveNext())	
				{
					strEqId += myEnumerator.Value + ",";
				}
				strEqId = strEqId.Remove(strEqId.Length-1,1);
				//Session.Remove("DatiList");
			}
			else
			{
				Response.Write("Sessione Vuota");
				Response.End();
			}
			return strEqId;
		}

		private void btnIndietro_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("FiltraApparecchiature.aspx");
		}
	}
}
