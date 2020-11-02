
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
using System.Xml;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;
using System.IO;
using TheSite.Classi.ClassiDettaglio;
   
namespace TheSite.AnagrafeImpianti
{


	/// <summary>
	/// Descrizione di riepilogo per Apparecchiatura.
	/// Fabio Civerchia
	/// </summary>
	
	public class Apparecchiatura : System.Web.UI.Page    // System.Web.UI.Page
	{
		
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvQtyUnit;
		protected System.Web.UI.WebControls.TextBox txtDescrizione;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvProductName;
		protected S_Controls.S_ComboBox S_Cbtipologia;
		protected System.Web.UI.WebControls.Button btnSalva;
		protected WebControls.PageTitle PageTitle1;
		protected System.Web.UI.WebControls.Panel PanelDatoTecnico;
		protected System.Web.UI.WebControls.Panel PanelGriglia;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblDescrizioneApparecchiatura;
		protected WebControls.GridTitleServer GridTitleServer1; 
		protected WebControls.GridTitleServer GridTitleServer2;
		private DataView dvApparecchiature;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		int idstd=0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			GridTitleServer1.NuovoRec1  +=new  WebControls.NuovoRec(this.btNuovo);
			GridTitleServer2.NuovoRec1  +=new  WebControls.NuovoRec(this.btnewtipologia);
            PageTitle1.VisibleLogut =false;

			if(!IsPostBack)
			{
				if (Context.Items["EQ_ID"]!=null)
					this.EQ_ID=(string)Context.Items["EQ_ID"];
                
				if (Context.Items["IDEQ"]!=null)
					this.IDEQ=(string)Context.Items["IDEQ"];

				if (Request.QueryString["EQ_ID"]!=null)
					this.EQ_ID=(string)Request.QueryString["EQ_ID"];
                
				if (Request.QueryString["IDEQ"]!=null)
					this.IDEQ=(string)Request.QueryString["IDEQ"];

				this.Session.Remove("dvApparecchiature");
 
				GetDataSource();
				BindDatiTecnici();

			}
			//Rendo il Link dell'help invisibile
			//GridTitleServer1.hplsNuovo.Visible=false; 
			GridTitleServer1.hplsNuovo.Text="Nuovo Dato Tecnico";
			GridTitleServer2.hplsNuovo.Text="Inserisci una Nuova Tipologia Tecnica";
			GridTitleServer2.lblRecord.Visible =false;
			GridTitleServer2.hplsNuovo.CausesValidation =false;
		}
		/// <summary>
		/// Crea la stuttura del Dataset
		/// Recupera l'informazione dell'apparecchio dalla tabella
		/// </summary>
		/// <returns></returns>
		
		
		/// <summary>
		/// Recupera tutte le descrizioni tecniche di quella determinata apparecchiatura
		/// ed effettua il binding con la combo
		/// </summary>
		private void BindDatiTecnici()
		{
			
			Classi.ClassiDettaglio.DatiTecnici _DatiTecnici= new Classi.ClassiDettaglio.DatiTecnici("");
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_p_id = new S_Object();
			s_p_id.ParameterName = "p_id";
			s_p_id.DbType = CustomDBType.Integer ;
			s_p_id.Direction = ParameterDirection.Input;
			s_p_id.Index = 0;
			s_p_id.Value =Convert.ToInt32(this.IDEQ);
            CollezioneControlli.Add (s_p_id);
			DataSet _MyDs=_DatiTecnici.GetDataApp(CollezioneControlli);

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.S_Cbtipologia.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare la Descrizione Tecnica -", "");
				this.S_Cbtipologia.DataTextField = "DESCRIZIONE";
				this.S_Cbtipologia.DataValueField = "ID";
				this.S_Cbtipologia.DataBind();
				this.ID_APPARECCHIATURA=_MyDs.Tables[0].Rows[0]["EQSTD_ID"].ToString();
			}
			else
			{
				string s_Messagggio = "- Nessuna Descrizione Tecnica -";
				this.S_Cbtipologia.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
				
				RecuperaStd();
			}
		}
		/// <summary>
		/// Effettua il Bind sulla griglia e recupera tali informazioni dalla tabella EQ campo Comments
		/// 
		/// </summary>
		/// 

		private void RecuperaStd()
		{
			Classi.ClassiDettaglio.DatiTecnici _DatiTec= new Classi.ClassiDettaglio.DatiTecnici("");
			 S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
			 S_Controls.Collections.S_Object s_p_id = new S_Object();
			 s_p_id.ParameterName = "p_eqid";
			 s_p_id.DbType = CustomDBType.Integer ;
			 s_p_id.Direction = ParameterDirection.Input;
			 s_p_id.Index = 0;
			 s_p_id.Value =Convert.ToInt32(this.IDEQ);
			 CollezioneControlli.Add (s_p_id);
			 DataSet _MyDs1=_DatiTec.RecStd(CollezioneControlli);

			if (_MyDs1.Tables[0].Rows.Count > 0)
			{
				this.ID_APPARECCHIATURA=_MyDs1.Tables[0].Rows[0]["id"].ToString();
				lblDescrizioneApparecchiatura.Text =string.Format("<b>Codice Apparecchiatura:</b> {0} <b>Descrizione:</b> {1}",
					this.EQ_ID,_MyDs1.Tables[0].Rows[0]["description"]);

			}

		}
		private void GetDataSource()
		{
			DataSet _Ds=new DataSet();
			//Creazione del DataTable
			DataTable _Dt =new DataTable ("tecniche");
			//Craezione delle colonne e aggiunte al DataTable
			_Dt.Columns.Add(new DataColumn("id", typeof(Int32)));
			//Definisco la prima colonna di tipo contatore
			_Dt.Columns[0].AutoIncrement = true;
			_Dt.Columns[0].AutoIncrementSeed = 1;
			_Dt.Columns[0].AutoIncrementStep = 1;

			_Dt.Columns.Add(new DataColumn("eq_id", typeof(string)));// Rappresenta l'EQ_ID della tabella EQ
			_Dt.Columns.Add(new DataColumn("eqstd_id", typeof(Int32)));//Rappresenta l'EQSTD_ID della tabella EQ
			_Dt.Columns.Add(new DataColumn("eqstdapparecchiatura_id", typeof(Int32)));//rappresenta l'ID della tabella EQSTDAPPARECCHIATURA
			_Dt.Columns.Add(new DataColumn("tipologia", typeof(string)));//Rappresenta la Descrizione della Tipologia EQSTDAPPARECCHIATURA
			_Dt.Columns.Add(new DataColumn("descrizione", typeof(string)));//Descrizione 
			
			//Aggiunta del Datatable al dataset
			_Ds.Tables.Add(_Dt); 

			Classi.ClassiDettaglio.DatiTecniciApparecchiatura  _DatiTecniciApparecchiatura=new Classi.ClassiDettaglio.DatiTecniciApparecchiatura(Context.User.Identity.Name);
			DataSet _DsTemp;
			//Da Cambiare
			_DsTemp =_DatiTecniciApparecchiatura.GetSingleDatitecnici(int.Parse(this.IDEQ));
			this.Session["dvApparecchiature"] = _DsTemp; 
			dvApparecchiature = ((DataSet)this.Session["dvApparecchiature"]).Tables[0].DefaultView;  
			

			if (_DsTemp.Tables[0].Rows.Count>0)
			
			{
				lblDescrizioneApparecchiatura.Text =string.Format("<b>Codice Apparecchiatura:</b> {0} <b>Descrizione:</b> {1}",
					this.EQ_ID,_DsTemp.Tables[0].Rows[0]["description"]);

				this.ID_APPARECCHIATURA =_DsTemp.Tables[0].Rows[0]["EQSTD_ID"].ToString();
				GridTitleServer1.Visible =true;
				GridTitleServer1.NumeroRecords=string.Format("Record: {0}",  _DsTemp.Tables[0].Rows.Count);
				DataGrid1.DataSource = _DsTemp.Tables[0];
				DataGrid1.DataBind();
			}
			else
			{
				
              GridTitleServer1.NumeroRecords="Nessun Dato Tecnico";
			  DataGrid1.DataSource = _DsTemp.Tables[0];
			  DataGrid1.DataBind();
				RecuperaStd();
			}
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
			this.DataGrid1.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemCreated);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Si verifica quaundo si vuole inserire una nuova descirzione
		/// </summary>
		/// <param name="sender"></param>
		private void btNuovo(string sender)
		{
			PanelDatoTecnico.Visible=true;
			txtDescrizione.Text ="";
			btnSalva.CommandArgument = "Add";
				
		}

		private void btnewtipologia(string sender)
		{
			Context.Items.Add("ID_APPARECCHIATURA",this.ID_APPARECCHIATURA);
			Context.Items.Add("EQ_ID",this.EQ_ID);
			Context.Items.Add("IDEQ",this.IDEQ);
			Server.Transfer("DatiTecnici.aspx"); 
		}

		private void btnSalva_Click(object sender, System.EventArgs e)
		{
			if (this.IsValid) 
			 SaveItem();
		}
		private void SaveItem()
		{//MARIANNA
			string operazione="";
			int id=0;
		//	DataSet Ds =((DataSet)(this.Session["dvApparecchiature"]));
			if (btnSalva.CommandArgument == "Add")//si tratta di un salvataggio
			{
				id=0;
				operazione="Insert";
				execute(id,operazione);
				
			}
			else //In Modifica
			{
				operazione="Update";
				id=Convert.ToInt32(DataGrid1.DataKeys[DataGrid1.SelectedIndex]);
					PanelDatoTecnico.Visible=false;
				execute(id,operazione);

			}
			
		}

		private void execute(int id, string operazione)
		{
			//imposta i dati per il salvataggio
			DatiTecniciApparecchiatura _DatiTecniciApparecchiatura=new DatiTecniciApparecchiatura(Context.User.Identity.Name);
			
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			             
			S_Controls.Collections.S_Object s_p_eqdatitecniciid = new S_Object();
			s_p_eqdatitecniciid.ParameterName = "p_eqdatitecniciid";
			s_p_eqdatitecniciid.DbType = CustomDBType.Integer;
			s_p_eqdatitecniciid.Direction = ParameterDirection.Input;
			s_p_eqdatitecniciid.Index = CollezioneControlli.Count;
			s_p_eqdatitecniciid.Value =	id;
			CollezioneControlli.Add (s_p_eqdatitecniciid);
						
			S_Controls.Collections.S_Object s_p_eq_id = new S_Object();
			s_p_eq_id.ParameterName = "p_eq_id";
			s_p_eq_id.DbType = CustomDBType.Integer;
			s_p_eq_id.Direction = ParameterDirection.Input;
			s_p_eq_id.Index = CollezioneControlli.Count;
			s_p_eq_id.Value =	this.IDEQ;
			CollezioneControlli.Add (s_p_eq_id);

			S_Controls.Collections.S_Object s_p_eqstdapparecchiatura = new S_Object();
			s_p_eqstdapparecchiatura.ParameterName = "p_eqstdapparecchiatura";
			s_p_eqstdapparecchiatura.DbType = CustomDBType.Integer;
			s_p_eqstdapparecchiatura.Direction = ParameterDirection.Input;
			s_p_eqstdapparecchiatura.Index = CollezioneControlli.Count;
			int tipologia=0;
			if (this.S_Cbtipologia.SelectedValue!="")
				tipologia=Convert.ToInt32(S_Cbtipologia.SelectedValue);

			s_p_eqstdapparecchiatura.Value =tipologia;
			CollezioneControlli.Add (s_p_eqstdapparecchiatura);

			S_Controls.Collections.S_Object s_p_descrizione = new S_Object();
			s_p_descrizione.ParameterName = "p_descrizione";
			s_p_descrizione.DbType = CustomDBType.VarChar ;
			s_p_descrizione.Direction = ParameterDirection.Input;
			s_p_descrizione.Index = CollezioneControlli.Count;
			s_p_descrizione.Size=4000; 
			s_p_descrizione.Value =txtDescrizione.Text;
			CollezioneControlli.Add (s_p_descrizione);

			S_Controls.Collections.S_Object s_p_Operazione = new S_Object();
			s_p_Operazione.ParameterName = "p_Operazione";
			s_p_Operazione.DbType = CustomDBType.VarChar ;
			s_p_Operazione.Direction = ParameterDirection.Input;
			s_p_Operazione.Index = CollezioneControlli.Count;
			s_p_Operazione.Size=4000; 
			s_p_Operazione.Value =operazione;
			CollezioneControlli.Add (s_p_Operazione);

			Int32 result=_DatiTecniciApparecchiatura.Update(CollezioneControlli,0);
 
			this.Session.Remove("dvApparecchiature");

			GetDataSource();
			BindDatiTecnici();
			txtDescrizione.Text="";
		}
	
	
		/// <summary>
		/// Evento Delete scatenato alla pressione del bottone delete sul data grid
		/// </summary>
		/// <param name="e"></param>
		private void DeleteItem(string ID)
		{		
			//MARIANNA
			PanelDatoTecnico.Visible=false;
			int id=Convert.ToInt32(ID);
			string operazione="Delete";			
			
            execute(id,operazione);
		}



		private void DataGrid1_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType== ListItemType.Item) || (e.Item.ItemType==ListItemType.AlternatingItem) ||
				(e.Item.ItemType==ListItemType.EditItem))
			{
				TableCell myTableCell;
				myTableCell = e.Item.Cells[7];
				Button myDeleteButton=(Button)myTableCell.Controls[0];
				myDeleteButton.Attributes.Add("onclick","return confirm('Sei sicuro di Cancellare la Descrizione?');");
			}
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if ((e.Item.ItemType == ListItemType.Pager) ||
				(e.Item.ItemType == ListItemType.Header)) return;

			Button btn  = (Button)e.CommandSource;

			if (btn.Text == "Delete")
			{
				DeleteItem(DataGrid1.DataKeys[e.Item.ItemIndex].ToString());
			}
			else
			{
				PanelDatoTecnico.Visible=true;
				txtDescrizione.Text = e.Item.Cells[5].Text;
			    S_Cbtipologia.SelectedValue=e.Item.Cells[3].Text;
			}

			btnSalva.CommandArgument = "";
		}


	}
}
