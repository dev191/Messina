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
using System.IO;
using ICSharpCode;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;

namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per SfogliaPiani.
	/// </summary>
	public class SfogliaPiani : System.Web.UI.Page
	{
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_Button btnsRicerca;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.DropDownList cmbStato;
		protected System.Web.UI.WebControls.DropDownList cmbsTipoDocumenti;
		protected System.Web.UI.WebControls.TextBox txtDescrizione;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.GridTitle GridTitle1;
		protected System.Web.UI.WebControls.DropDownList DropAnno;
		Classi.ManProgrammata.RecuperoDocPmp _RecuproDocPmp= new Classi.ManProgrammata.RecuperoDocPmp();
		public static string HelpLink = string.Empty;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
				HelpLink = _SiteModule.HelpLink;
				BindStato();
				GridTitle1.hplsNuovo.Visible=false;
			}
			// Inserire qui il codice utente necessario per inizializzare la pagina.
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
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			DataGridRicerca.CurrentPageIndex =0;
			RicercaPiani();
		}


		private void RicercaPiani()
		{
			//DataGridRicerca.CurrentPageIndex =0;
			DataGridRicerca.Visible=true;
		//	GridTitle1.Visible=true;
		//	DataGridRicerca.Visible=false;
		//	Gridtitle2.Visible=false;

			S_ControlsCollection _SCollection = new S_ControlsCollection();		

			S_Controls.Collections.S_Object s_p_BL_ID = new S_Object();
			s_p_BL_ID.ParameterName = "p_BL_ID";
			s_p_BL_ID.DbType = CustomDBType.Integer;
			s_p_BL_ID.Direction = ParameterDirection.Input;
			s_p_BL_ID.Index =_SCollection.Count;
			if(RicercaModulo1.Idbl=="")
				s_p_BL_ID.Value=DBNull.Value;
			else
				s_p_BL_ID.Value=RicercaModulo1.Idbl;			
			_SCollection.Add(s_p_BL_ID);

			S_Controls.Collections.S_Object s_p_NOME_DOC = new S_Object();
			s_p_NOME_DOC.ParameterName = "p_NOME_DOC";
			s_p_NOME_DOC.DbType = CustomDBType.VarChar;
			s_p_NOME_DOC.Direction = ParameterDirection.Input;
			s_p_NOME_DOC.Size=225;
			s_p_NOME_DOC.Index = _SCollection.Count;
			if(txtDescrizione.Text=="")
				s_p_NOME_DOC.Value=DBNull.Value;
			else
				s_p_NOME_DOC.Value=txtDescrizione.Text;			
			_SCollection.Add(s_p_NOME_DOC);
		
             
			S_Controls.Collections.S_Object s_p_ID_STATO = new S_Object();
			s_p_ID_STATO.ParameterName = "p_ID_STATO";
			s_p_ID_STATO.DbType = CustomDBType.Integer;
			s_p_ID_STATO.Direction = ParameterDirection.Input;
			s_p_ID_STATO.Index =_SCollection.Count;
			if (cmbStato.SelectedIndex==0)
				s_p_ID_STATO.Value=DBNull.Value;
			else
				s_p_ID_STATO.Value=Convert.ToInt32(cmbStato.SelectedIndex);			
			_SCollection.Add(s_p_ID_STATO);

			S_Controls.Collections.S_Object s_p_DATA_INVIO = new S_Object();
			s_p_DATA_INVIO.ParameterName = "p_DATA_INVIO";
			s_p_DATA_INVIO.DbType = CustomDBType.VarChar;
			s_p_DATA_INVIO.Direction = ParameterDirection.Input;
			s_p_DATA_INVIO.Size=225;
			s_p_DATA_INVIO.Index = _SCollection.Count;
			if (CalendarPicker1.Datazione.Text =="")
				s_p_DATA_INVIO.Value=DBNull.Value;
			else
				s_p_DATA_INVIO.Value=CalendarPicker1.Datazione.Text;			
			_SCollection.Add(s_p_DATA_INVIO);

			S_Controls.Collections.S_Object s_p_DATA_INSERIMENTo = new S_Object();
			s_p_DATA_INSERIMENTo.ParameterName = "p_DATA_INSERIMENTo";
			s_p_DATA_INSERIMENTo.DbType = CustomDBType.VarChar;
			s_p_DATA_INSERIMENTo.Direction = ParameterDirection.Input;
			s_p_DATA_INSERIMENTo.Size=225;
			s_p_DATA_INSERIMENTo.Index = _SCollection.Count;
			if(CalendarPicker2.Datazione.Text =="")
				s_p_DATA_INSERIMENTo.Value= DBNull.Value;
			else
				s_p_DATA_INSERIMENTo.Value= CalendarPicker2.Datazione.Text;			
			_SCollection.Add(s_p_DATA_INSERIMENTo);

			S_Controls.Collections.S_Object s_p_anno = new S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.VarChar;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Size=225;
			s_p_anno.Index = _SCollection.Count;
			s_p_anno.Value=Convert.ToInt32(DropAnno.SelectedValue);			
			_SCollection.Add(s_p_anno);


			DataSet _MyDs = _RecuproDocPmp.GetPiani(_SCollection, cmbsTipoDocumenti.SelectedValue);	

			if (_MyDs.Tables[0].Rows.Count == 0 )
			{
				DataGridRicerca.CurrentPageIndex=0;
				GridTitle1.DescriptionTitle="Nessun dato trovato."; 
			}
			else
			{
				GridTitle1.DescriptionTitle="";
				this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();	
			}
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();
		}

		private void BindStato()
		{
			DropAnno.Items.Clear(); 
			ListItem item=null;
			for(int i=2008;i<=2020;i++)
			{
				item=new ListItem(i.ToString(),i.ToString()); 
				DropAnno.Items.Add(item);  
			}
			this.cmbStato.Items.Clear();
								
			DataSet Ds = _RecuproDocPmp.GetAllStato();
		
			if (Ds.Tables[0].Rows.Count > 0)
			{
				this.cmbStato.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					Ds.Tables[0], "descrizione", "id", "- Selezionare uno Stato -", "");
				this.cmbStato.DataTextField = "descrizione";
				this.cmbStato.DataValueField = "id";
				this.cmbStato.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Gruppo -";
				this.cmbStato.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
			
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
			RicercaPiani();
			
		}

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Download")
			{

                string PathDir=Server.MapPath("../Doc_DB");
				PathDir=PathDir + @"\Manutenzione Programmata";//Manutenzione Programmata
			

				string PathDirAnnuale=PathDir + @"\PAM" + DropAnno.SelectedValue;//Cartella del Piano annuale

				string PathDirMensile=PathDir + @"\PMP" + DropAnno.SelectedValue;//Cartella de Piano Mensile

				string DestPath="";
				if(cmbsTipoDocumenti.SelectedValue=="2" )//Piano mensile
				{
					
					PathDirMensile =PathDirMensile + @"\" + e.CommandArgument.ToString().Split(',')[1];//Cartella de Piano Mensile
				
					DestPath=PathDirMensile;
				}
				else//Piano Annuale
				{
					DestPath=PathDirAnnuale;
				}
				string FileName=DestPath + @"\" + e.CommandArgument.ToString().Split(',')[0];
		
				Response.Clear();
				Response.ContentType = "application/xls";
				Response.AddHeader("content-disposition", "inline; filename=" + Path.GetFileName(FileName));
	   
				Response.WriteFile(FileName);
			}
		}

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			string varapp="";
			if(Request.QueryString["FunId"]!=null)
				varapp="FunId=" + Request.QueryString["FunId"]; 

			if(Request["VarApp"]!=null)
				varapp+="&VarApp=" + Request["VarApp"];
			
			Server.Transfer("SfogliaPiani.aspx?" + varapp);
		}
	}
}
