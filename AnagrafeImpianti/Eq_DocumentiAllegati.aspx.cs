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
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using TheSite.Classi.ClassiDettaglio;
using MyCollection; 

namespace TheSite.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per Eq_DocumentiAllegati.
	/// </summary>
	public class Eq_DocumentiAllegati : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid MyDataGrid1;
		protected int id_eq=0;
		protected S_Controls.S_Label S_lblcodicecomponente;
		protected S_Controls.S_Label S_lblstdapparecchiature;
		protected S_Controls.S_Label S_Lblservizio;
		protected S_Controls.S_Label S_lblcodiceedificio;
		protected S_Controls.S_Label S_lbledificio;
		protected S_Controls.S_Label S_lblpiano;
		protected S_Controls.S_Label S_lblstanza;
		protected string eq_id="";
		protected WebControls.PageTitle PageTitle1;
		protected string BtnHidden;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			BtnHidden = String.Empty;
			if(Request["FromWebCad"] != null)
			{
				BtnHidden = "style=\"visibility: hidden\"";
				PageTitle1.VisibleLogut = false;
			}
			if (Request.QueryString["eq_id"]!=null)
			{
				this.eq_id =(string)Request.QueryString["eq_id"];
				PageTitle1.Title="Documenti Allegato per l'apparecchiatura " + eq_id;	
			}
			if (Request.QueryString["id_eq"]!="")
			{
				id_eq=int.Parse(Request["id_eq"]);
				BindGrid();
				DettagliApparecchiatura();
			}

			// Inserire qui il codice utente necessario per inizializzare la pagina.
		}

		private void DettagliApparecchiatura()
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new  S_Controls.Collections.S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_p_eq_std = new S_Controls.Collections.S_Object();
			s_p_eq_std.ParameterName = "p_eq_std";
			s_p_eq_std.DbType = CustomDBType.VarChar;
			s_p_eq_std.Direction = ParameterDirection.Input;
			s_p_eq_std.Index = 0;
			s_p_eq_std.Value =eq_id;			
			s_p_eq_std.Size = 50;
			CollezioneControlli.Add(s_p_eq_std);

			Classi.ClassiDettaglio.SchedaApparecchiatura  _SchedaApparecchiatura =new Classi.ClassiDettaglio.SchedaApparecchiatura(""); 

			DataSet Ds = _SchedaApparecchiatura.GetData(CollezioneControlli);
			if (Ds.Tables[0].Rows.Count>0)
			{
				S_lblcodicecomponente.Text=Ds.Tables[0].Rows[0]["var_eq_eq_id"].ToString();
				S_lblstdapparecchiature.Text=Ds.Tables[0].Rows[0]["var_eqstd_description"].ToString();
				S_lblcodiceedificio.Text=Ds.Tables[0].Rows[0]["var_eq_bl_id"].ToString();
				S_lbledificio.Text=Ds.Tables[0].Rows[0]["var_bl_name"].ToString();
				S_lblpiano.Text=Ds.Tables[0].Rows[0]["var_eq_fl_id"].ToString();
				S_Lblservizio.Text=Ds.Tables[0].Rows[0]["servizio"].ToString();
				try
				{
					S_lblstanza.Text=Ds.Tables[0].Rows[0]["stanza"].ToString();
				}
				catch(Exception ex)
				{
					Response.Write(ex.Message);
				}
			
			}
		}

		private void BindGrid()
		{
			
			Classi.ClassiAnagrafiche.AllegatiEQ _AllegatiEQ = new TheSite.Classi.ClassiAnagrafiche.AllegatiEQ ();
			DataSet _MyDs;
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_Apparecchiatura = new S_Object();
			s_Apparecchiatura.ParameterName = "p_eq";
			s_Apparecchiatura.DbType = CustomDBType.Integer;
			s_Apparecchiatura.Direction = ParameterDirection.Input;
			s_Apparecchiatura.Size = 10; 
			s_Apparecchiatura.Index = 0;
			s_Apparecchiatura.Value = id_eq;		
			_SCollection.Add(s_Apparecchiatura);
		
			_MyDs= _AllegatiEQ.GetData(_SCollection).Copy();

			this.MyDataGrid1.DataSource = _MyDs.Tables[0];
			this.MyDataGrid1.DataBind();

//			this.lblRecord.Text = _MyDs.Tables[0].Rows.Count.ToString();	
			this.MyDataGrid1.ShowFooter = false;
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
