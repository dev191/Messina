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
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
    
namespace TheSite.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per DatiTecnici.
	/// </summary>
	public class DatiTecnici : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Panel PanelNuovoDatoTecnico;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btRitorna;
		protected System.Web.UI.WebControls.Button btsalvaTipologia;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtDescrizioneTipologia;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected S_Controls.S_ComboBox cmbsApparecchiatura;
		protected WebControls.GridTitle GridTitle1;
		protected System.Web.UI.WebControls.Button btNuovo;
		protected WebControls.PageTitle PageTitle1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			PageTitle1.VisibleLogut=false; 
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{
				if (Context.Items["EQ_ID"]!=null)
					this.EQ_ID=(string)Context.Items["EQ_ID"];
				
				if (Context.Items["ID_APPARECCHIATURA"]!=null)
					this.ID_APPARECCHIATURA=(string)Context.Items["ID_APPARECCHIATURA"];
					
				if (Context.Items["IDEQ"]!=null)
					this.EQ_ID=(string)Context.Items["IDEQ"];

				BindApparecchiature();
				btsalvaTipologia.CommandArgument = "Add";
			}
			 GridTitle1.hplsNuovo.Visible=false;
			 PageTitle1.Title="Descrizione del Dato Tecnico";
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
			this.cmbsApparecchiatura.SelectedIndexChanged += new System.EventHandler(this.cmbsApparecchiatura_SelectedIndexChanged);
			this.btNuovo.Click += new System.EventHandler(this.btNuovo_Click);
			this.btsalvaTipologia.Click += new System.EventHandler(this.btsalvaTipologia_Click);
			this.btRitorna.Click += new System.EventHandler(this.btRitorna_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Effettua il Binding delle Apparecchiaure sulla combo
		/// </summary>
		private void BindApparecchiature()
		{
			this.cmbsApparecchiatura.Items.Clear();
		
			Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature = new TheSite.Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);
			
			DataSet _MyDs = _Apparecchiature.GetData().Copy();
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsApparecchiatura.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare una Apparecchiatura -", "");
				this.cmbsApparecchiatura.DataTextField = "DESCRIZIONE";
				this.cmbsApparecchiatura.DataValueField = "ID";
				this.cmbsApparecchiatura.DataBind();
				if (this.ID_APPARECCHIATURA!="0")					
				this.cmbsApparecchiatura.SelectedValue=this.ID_APPARECCHIATURA;  
				BindingGrid();
			}
			else
			{
				string s_Messagggio = "- Nessuna Apparecchiatura -";
				this.cmbsApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}
		/// <summary>
		/// Effettua il savataggio della Tipologia
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btsalvaTipologia_Click(object sender, System.EventArgs e)
		{

			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id = new S_Controls.Collections.S_Object();
			s_p_id.ParameterName = "p_id";
			s_p_id.DbType = CustomDBType.Integer;
			s_p_id.Direction = ParameterDirection.Input;
			s_p_id.Index =0;
			if (btsalvaTipologia.CommandArgument == "Add")
				s_p_id.Value =Int32.Parse(this.cmbsApparecchiatura.SelectedValue);	
			else
               s_p_id.Value =Int32.Parse(DataGrid1.DataKeys[DataGrid1.SelectedIndex].ToString());	
			
			CollezioneControlli.Add(s_p_id);

			S_Controls.Collections.S_Object s_p_descrizione = new S_Controls.Collections.S_Object();
			s_p_descrizione.ParameterName = "p_descrizione";
			s_p_descrizione.DbType = CustomDBType.VarChar;
			s_p_descrizione.Direction = ParameterDirection.Input;
			s_p_descrizione.Index = 1;
			s_p_descrizione.Value =txtDescrizioneTipologia.Text;			
			s_p_descrizione.Size = 50;
			CollezioneControlli.Add(s_p_descrizione);

			Classi.ClassiDettaglio.DatiTecnici _DatiTecnici= new Classi.ClassiDettaglio.DatiTecnici(Context.User.Identity.Name);
			Int32 result=0;
			if (btsalvaTipologia.CommandArgument == "Add")
			{
				result= _DatiTecnici.Add(CollezioneControlli);
				cmbsApparecchiatura.Enabled =true;
			}
			else
			{
				cmbsApparecchiatura.Enabled =false;
				result= _DatiTecnici.Update(CollezioneControlli,Int32.Parse(this.cmbsApparecchiatura.SelectedValue));
			}
			
			BindingGrid();
		}

		private void btRitorna_Click(object sender, System.EventArgs e)
		{

			Context.Items.Add("ID_APPARECCHIATURA",this.ID_APPARECCHIATURA);
			Context.Items.Add("EQ_ID",this.EQ_ID);
			Context.Items.Add("IDEQ",this.IDEQ);
			Server.Transfer("ListaDatiApparecchiatura.aspx"); 
		}
		/// <summary>
		/// Intercetto l'evento change della combo apparecchaiture e carco la griglia con le Tipologie Tecniche 
		/// della Apparecchiature appena selezionata.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmbsApparecchiatura_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindingGrid();
		}
		/// <summary>
		/// Effetua il Bindg sulla griglia recuperando tutte le informazioni dalla tabella EQSTDAPPARECCHIATURA
		/// </summary>
		private void BindingGrid()
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id = new S_Controls.Collections.S_Object();
			s_p_id.ParameterName = "p_id";
			s_p_id.DbType = CustomDBType.Integer;
			s_p_id.Direction = ParameterDirection.Input;
			s_p_id.Index =0;
			s_p_id.Value = (this.cmbsApparecchiatura.SelectedValue=="")?Int32.Parse(this.ID_APPARECCHIATURA):Int32.Parse(this.cmbsApparecchiatura.SelectedValue);			
			CollezioneControlli.Add(s_p_id);

			Classi.ClassiDettaglio.DatiTecnici _DatiTecnici= new Classi.ClassiDettaglio.DatiTecnici(Context.User.Identity.Name);
            DataSet Ds=_DatiTecnici.GetData(CollezioneControlli);
			if (Ds.Tables[0].Rows.Count >0)  
			{
			 GridTitle1.NumeroRecords =Ds.Tables[0].Rows.Count.ToString();
			}
			DataGrid1.DataSource=Ds;
			DataGrid1.DataBind();
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if ((e.Item.ItemType == ListItemType.Pager) ||
				(e.Item.ItemType == ListItemType.Header)) return;

			Button btn  = (Button)e.CommandSource;

			if (btn.Text == "Modifica")
			{
				
				txtDescrizioneTipologia.Text = e.Item.Cells[3].Text;
				cmbsApparecchiatura.SelectedValue=e.Item.Cells[2].Text;
				cmbsApparecchiatura.Enabled =false;
			}

			btsalvaTipologia.CommandArgument = "Edit";
	
		}

		private void btNuovo_Click(object sender, System.EventArgs e)
		{
			cmbsApparecchiatura.Enabled =true;
			txtDescrizioneTipologia.Text ="";
			btsalvaTipologia.CommandArgument = "Add";
		}

	
		#region Proprietà

		//Property che indica il nome dell'apparecchiatura
		private string EQ_ID
		{
			get
			{ 
				if ( ViewState["EQ_ID"]!=null)
					return (string)ViewState["EQ_ID"];
				else
					return string.Empty;
			}
			set{ViewState["EQ_ID"]=value;}
		}
		//Property che indica L'id dell'apparecchiatura
		private string IDEQ
		{
			get
			{ 
				if ( ViewState["IDEQ"]!=null)
					return (string)ViewState["IDEQ"];
				else
					return string.Empty;
			}
			set{ViewState["IDEQ"]=value;}
		}
		//Property che indica la tipologia dell'apparecchiatura
		private string ID_APPARECCHIATURA
		{
			get
			{ 
				if ( ViewState["ID_APPARECCHIATURA"]!=null)
					return (string)ViewState["ID_APPARECCHIATURA"];
				else
					return string.Empty;
			}
			set{ViewState["ID_APPARECCHIATURA"]=value;}
		}

		#endregion

	}
}
