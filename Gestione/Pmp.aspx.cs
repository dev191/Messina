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
using StampaRapportiPdf.Classi;

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per Addetti.
	/// </summary>
	public class Pmp : System.Web.UI.Page    // System.Web.UI.Page
	{	
		protected Csy.WebControls.DataPanel PanelRicerca;		
		protected S_Controls.S_Button btnsRicerca;		
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;	
		protected WebControls.PageTitle PageTitle1;
		public static int FunId=0;
		public static string HelpLink = string.Empty;
		TheSite.Gestione.EditPmp _fpEdit;
		TheSite.Gestione.PmpS _fpStep;
		protected S_Controls.S_TextBox txtsdescrizione;
		protected S_Controls.S_ComboBox cmbspmpfrequenza;
		protected S_Controls.S_ComboBox cmbseq_std;
		protected S_Controls.S_ComboBox cmbstr_id;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected System.Web.UI.WebControls.Button cmdReset;
		clMyCollection _myColl = new clMyCollection();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitle1.hplsNuovo.NavigateUrl = "../Gestione/EditPmp.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;
			FunId = _SiteModule.ModuleId;
			this.DataGridRicerca.Columns[1].Visible = _SiteModule.IsEditable;				
			
			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbseq_std.ClientID + "').disabled = true;");
			this.cmbsServizio.Attributes.Add("onchange", sbValid.ToString());
			
			sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsServizio.ClientID + "').disabled = true;");
			this.cmbseq_std.Attributes.Add("onchange", sbValid.ToString());
			
			if (!Page.IsPostBack)
			{
				
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];

				BindServizio(); //carico la combo dei servizi
				BindSpecStd();//BindTr();
				BindPmPFrequenza();
				BindEqstd(0);
				//se vengo dalla pagina editPmp
				if(Context.Handler is TheSite.Gestione.EditPmp) 
				{	
					_fpEdit = (TheSite.Gestione.EditPmp) Context.Handler;
					if (_fpEdit!=null)
					{
						_myColl=_fpEdit._Contenitore;
						_myColl.SetValues(this.Page.Controls);
						Ricerca();
					}
				}
				//se vengo dalla pagina pmps
				if(Context.Handler is TheSite.Gestione.PmpS) 
				{	
					_fpStep = (TheSite.Gestione.PmpS) Context.Handler;
					if (_fpStep!=null)
					{
						_myColl=_fpStep._Contenitore;
						_myColl.SetValues(this.Page.Controls);
						Ricerca();
					}
				}
			}
			else
			{
//				if (cmbsServizio.SelectedIndex ==0)
//				{
//					if (cmbseq_std.SelectedIndex ==0)
//					{
//						BindSpecStd();//BindTr();
//						BindEqstd(0);
//					}
//					else
//					{
//						BindSpecStd();
//					
//					}
//				}
//				else
//				{
//
//				}
			}	
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
		}

		public clMyCollection _Contenitore
		{
			get 
			{
				return _myColl;
			}
		}
		private void BindServizio()
		{
			//carico la combo dei servizi
			this.cmbsServizio.Items.Clear();
		
			Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi();
				
			DataSet _MyDs = _Servizi.GetServizi().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{				
				this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "serv","id", "- Selezionare un Servizio -", "0");
				this.cmbsServizio.DataTextField = "serv";
				this.cmbsServizio.DataValueField = "id";
				this.cmbsServizio.DataBind();
//				BindEqstd();
//				BindSpecServizi();
			}	
			
		}

		private void BindEqstd(int id_serv)
		{
			
			this.cmbseq_std.Items.Clear();
		
				S_ControlsCollection _SColl = new S_ControlsCollection();

				S_Controls.Collections.S_Object s_Id = new S_Object();
				s_Id.ParameterName = "p_servizio_id";
				s_Id.DbType = CustomDBType.Integer;
				s_Id.Direction = ParameterDirection.Input;
				s_Id.Index = 0;
				s_Id.Value = id_serv;
				_SColl.Add(s_Id);

				TheSite.Classi.ClassiAnagrafiche.Eqstd _Eqstd = new TheSite.Classi.ClassiAnagrafiche.Eqstd();						
				DataSet _MyDs = _Eqstd.GetSingleServ(_SColl).Copy();
			  
				if (_MyDs.Tables[0].Rows.Count > 0)
				{
					this.cmbseq_std.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
						_MyDs.Tables[0], "eq_std", "id", "- Selezionare uno Standard -", "0");
					this.cmbseq_std.DataTextField = "eq_std";
					this.cmbseq_std.DataValueField = "id";
					this.cmbseq_std.DataBind();
			    }
				else
				{
					string s_Messagggio = "- Nessun Standard  -";
					this.cmbseq_std.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
						
				}
		}

		private void BindSpecStd()
		{
			//cambio il valore della combo delle specializzazioni 
			this.cmbstr_id.Items.Clear();
			  
			Classi.ClassiAnagrafiche.Pmp _Pmp = new TheSite.Classi.ClassiAnagrafiche.Pmp();
				
			DataSet _MyDs = _Pmp.GetAllTr().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{				
				this.cmbstr_id.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione","id", "- Selezionare una Specializzazione -", "0");
				this.cmbstr_id.DataTextField = "descrizione";
				this.cmbstr_id.DataValueField = "id";
				this.cmbstr_id.DataBind();
			}	
			else
			{
				string s_Messagggio = "- Nessuna Specializzazione  -";
				this.cmbstr_id.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
			}
		}

		private void BindSpecStd(int id_serv)
		{
			//cambio il valore della combo delle specializzazioni in base al servizio passato
			this.cmbstr_id.Items.Clear();
			  
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_servizio_id";
			s_Id.DbType = CustomDBType.Integer;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = 0;
			s_Id.Value = id_serv;
			_SColl.Add(s_Id);

			Classi.ClassiAnagrafiche.Pmp _Pmp = new TheSite.Classi.ClassiAnagrafiche.Pmp();

			DataSet _MyDs = _Pmp.GetSpecData(_SColl).Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{				
				this.cmbstr_id.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione","id", "- Selezionare una Specializzazione -", "0");
				this.cmbstr_id.DataTextField = "descrizione";
				this.cmbstr_id.DataValueField = "id";
				this.cmbstr_id.DataBind();
			}	
			else
			{
				string s_Messagggio = "- Nessuna Specializzazione  -";
				this.cmbstr_id.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
			}
		}

//		private void BindTr()
//		{
//			this.cmbstr_id.Items.Clear();
//		
//			Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
//				
//			DataSet _MyDs = _Addetti.GetDataTR().Copy();
//			  
//			if (_MyDs.Tables[0].Rows.Count > 0)
//			{				
//				this.cmbstr_id.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
//					_MyDs.Tables[0], "descrizione","id", "- Selezionare una Specializzazione -", "0");
//				this.cmbstr_id.DataTextField = "descrizione";
//				this.cmbstr_id.DataValueField = "id";
//				this.cmbstr_id.DataBind();
//			}			
//		}
//
		private void BindPmPFrequenza()
		{
			
			this.cmbspmpfrequenza.Items.Clear();
		
			Classi.ClassiAnagrafiche.PmpFrequenza _PmpFrequenza = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza();
				
			DataSet _MyDs = _PmpFrequenza.GetData().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{				
				this.cmbspmpfrequenza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "fqdes","id", "- Selezionare una Frequenza -", "0");
				this.cmbspmpfrequenza.DataTextField = "fqdes";
				this.cmbspmpfrequenza.DataValueField = "id";
				this.cmbspmpfrequenza.DataBind();
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
			this.cmbsServizio.SelectedIndexChanged += new System.EventHandler(this.cmbsServizio_SelectedIndexChanged);
			this.cmbseq_std.SelectedIndexChanged += new System.EventHandler(this.cmbseq_std_SelectedIndexChanged);
			this.cmbstr_id.SelectedIndexChanged += new System.EventHandler(this.cmbstr_id_SelectedIndexChanged);
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.SelectedIndexChanged += new System.EventHandler(this.DataGridRicerca_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Ricerca()
		{
			Classi.ClassiAnagrafiche.Pmp _Pmp= new Classi.ClassiAnagrafiche.Pmp();
			this.txtsdescrizione.DBDefaultValue = "%";
			this.cmbsServizio.DBDefaultValue = "0";
			this.cmbseq_std.DBDefaultValue="0";
			this.cmbspmpfrequenza.DBDefaultValue="0";
			this.cmbstr_id.DBDefaultValue="0";

			S_ControlsCollection _SCollection = new S_ControlsCollection();
			_SCollection.AddItems(this.PanelRicerca.Controls);
			DataSet _MyDs = _Pmp.GetData(_SCollection).Copy();

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			if (_MyDs.Tables[0].Rows.Count == 0 )
			{
				DataGridRicerca.CurrentPageIndex=0;
			}
			else
			{
				int Pagina = 0;
				if ((_MyDs.Tables[0].Rows.Count % DataGridRicerca.PageSize) >0)
				{
					Pagina ++;
				}
				if (DataGridRicerca.PageCount != Convert.ToInt16((_MyDs.Tables[0].Rows.Count / DataGridRicerca.PageSize) + Pagina))
				{					
					DataGridRicerca.CurrentPageIndex=0;					
				}
			}


			this.DataGridRicerca.DataBind();		
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
		}
		
		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
				Ricerca();		
		}

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Dettaglio")
			{	
				_myColl.AddControl(this.Page.Controls, ParentType.Page);
				string s_url = e.CommandArgument.ToString();							
				Server.Transfer(s_url);		
			}
		}

		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			if (cmbsServizio.SelectedIndex>0)
//			{
				BindEqstd(int.Parse(cmbsServizio.SelectedValue));
				BindSpecStd(int.Parse(cmbsServizio.SelectedValue));
//			}
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
			Ricerca();
		}

		private void DataGridRicerca_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void cmbseq_std_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			if (cmbseq_std.SelectedIndex>0)
//			{
				if (cmbsServizio.SelectedIndex==0)
				{
					DataSet _MyDs;
					Classi.ClassiAnagrafiche.Pmp _Pmp = new TheSite.Classi.ClassiAnagrafiche.Pmp();

					int id_std = int.Parse(cmbseq_std.SelectedValue);
					_MyDs = _Pmp.GetStdData(id_std);
					DataRow _Dr = _MyDs.Tables[0].Rows[0];

					int id_serv = int.Parse(_Dr["id"].ToString());

					BindSpecStd(id_serv);
				}
//			}
		}

		private void cmbstr_id_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Pmp.aspx?FunID=" + ViewState["FunId"]);
		}

		
	}
}
