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
using WebCad.Classi.ClassiAnagrafiche;
using WebCad.Classi;
using WebCad.WebControls;

namespace WebCad.Edifici
{
	/// <summary>
	/// Summary description for EditBuilding.
	/// </summary>
	public class EditBuilding : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected S_Controls.S_TextBox S_TextBox1;
		protected S_Controls.S_TextBox S_TEXTBOX2;
		int itemId = 0;
		int pianoId = 0;
		public static int FunId = 0;
		public static int TabId = 0;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvCAP;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPiani;
		protected System.Web.UI.WebControls.Button btnAssociaP;
		protected System.Web.UI.WebControls.Button btnEliminaP;
		protected System.Web.UI.WebControls.Panel PanelEditPiani;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.DataGrid DataGridEsegui;
		protected System.Web.UI.WebControls.Label lblRecord;
		protected System.Web.UI.WebControls.Panel PanelEditStanze;
		protected System.Web.UI.WebControls.DataGrid DataGridPiani;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenPianiStanze;
		public string edificio="";
		public string piano="";
		protected System.Web.UI.WebControls.ListBox ListBoxLeftP;
		protected System.Web.UI.WebControls.ListBox ListBoxRightP;		
		
		Stanze _RM = new Stanze();

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
			PanelEditPiani.Visible=false;
			//aggiungo la funzione javascript per la navigazione tra i tab

			//ID del Elififcio
			if (Request["IdEdif"] != null) 
			{
				itemId = Int32.Parse(Request["IdEdif"].ToString());				
			}

			if (Request["IdPian"] != null) 
			{
				pianoId = Int32.Parse(Request["IdPian"].ToString());				
			}

			if (Request["Edificio"] != null) 
			{
				edificio = Request["Edificio"].ToString();				
			}

			if (Request["Piano"] != null) 
			{
				piano = Request["Piano"].ToString();				
			}

			if (!Page.IsPostBack)
			{
				//btnsSalva.Attributes.Add("onclick","javascript:SelezionaListBox();");
				this.DataGridEsegui.Columns[1].Visible = true;
				this.DataGridEsegui.Columns[2].Visible = false;
				this.DataGridEsegui.Columns[3].Visible = false;
				this.BindGrid();

			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{   
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void AbilitaControlli(bool enabled)
		{
			// Lista Piani
			this.DataGridPiani.Enabled=enabled;
			//Lista
			this.DataGridEsegui.Enabled=enabled;
		}

		public DataTable GetPianiEdificio()
		{
			Buildings _Buildings = new Buildings();
			return _Buildings.GetPianiBuilding(itemId).Tables[0];
		}

		protected int GetIndex(string item)
		{
			if (item.Length > 0 )
				return int.Parse(item);
			else
				return 0;
		}

		private void lkbNuovo_Click(object sender, System.EventArgs e)
		{
			BindGrid();
			this.DataGridEsegui.ShowFooter = true;			
			this.DataGridEsegui.Columns[1].Visible = false;
			this.DataGridEsegui.Columns[2].Visible = false;
			this.DataGridEsegui.Columns[3].Visible = true;
		}

		#region datalayer Stanze
		private S_Controls.Collections.S_ControlsCollection ControlsStanze(int Piano, string Stanza, string DescrizioneStanza, Double Mq, int id_rm_cat, int id_rm_reparto,int id_rm_dest_uso)
		{
			
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			//id dell'edicio
			S_Controls.Collections.S_Object s_Edificio = new S_Object();
			s_Edificio.ParameterName = "p_BL_ID";
			s_Edificio.DbType = CustomDBType.Integer;
			s_Edificio.Direction = ParameterDirection.Input;
			s_Edificio.Size = 10; 
			s_Edificio.Index = _SCollection.Count;
			s_Edificio.Value = itemId;		
			_SCollection.Add(s_Edificio);
			
			//id del piano
			S_Controls.Collections.S_Object s_Piano = new S_Object();
			s_Piano.ParameterName = "p_piani";
			s_Piano.DbType = CustomDBType.Integer;
			s_Piano.Direction = ParameterDirection.Input;
			s_Piano.Size = 10; 
			s_Piano.Index = _SCollection.Count;
			s_Piano.Value = Piano;		
			_SCollection.Add(s_Piano); 
			

			//Descrizione della Stanza
			S_Controls.Collections.S_Object s_Stanza = new S_Object();
			s_Stanza.ParameterName = "p_descrizione";
			s_Stanza.DbType = CustomDBType.VarChar;
			s_Stanza.Direction = ParameterDirection.Input;
			s_Stanza.Size = 50; 
			s_Stanza.Index = _SCollection.Count;
			s_Stanza.Value = Stanza;		
			_SCollection.Add(s_Stanza); 
			

			///Descrizione estesa della stanza
			S_Controls.Collections.S_Object s_DescStanza = new S_Object();
			s_DescStanza.ParameterName = "p_descstanza";
			s_DescStanza.DbType = CustomDBType.VarChar;
			s_DescStanza.Direction = ParameterDirection.Input;
			s_DescStanza.Size = 255; 
			s_DescStanza.Index = _SCollection.Count;
			s_DescStanza.Value = DescrizioneStanza;		
			_SCollection.Add(s_DescStanza); 
			
			//id della categoria
			S_Controls.Collections.S_Object s_p_id_rm_cat = new S_Object();
			s_p_id_rm_cat.ParameterName = "p_id_rm_cat";
			s_p_id_rm_cat.DbType = CustomDBType.Integer;
			s_p_id_rm_cat.Direction = ParameterDirection.Input;
			s_p_id_rm_cat.Size = 10; 
			s_p_id_rm_cat.Index = _SCollection.Count;
			s_p_id_rm_cat.Value = id_rm_cat;		
			_SCollection.Add(s_p_id_rm_cat); 

			//id del reparto
			S_Controls.Collections.S_Object s_p_id_rm_reparto = new S_Object();
			s_p_id_rm_reparto.ParameterName = "p_id_rm_reparto";
			s_p_id_rm_reparto.DbType = CustomDBType.Integer;
			s_p_id_rm_reparto.Direction = ParameterDirection.Input;
			s_p_id_rm_reparto.Size = 10; 
			s_p_id_rm_reparto.Index = _SCollection.Count;
			s_p_id_rm_reparto.Value = id_rm_reparto;		
			_SCollection.Add(s_p_id_rm_reparto); 

			//id della destinazione d'uso
			S_Controls.Collections.S_Object s_p_id_rm_dest_uso = new S_Object();
			s_p_id_rm_dest_uso.ParameterName = "p_id_rm_dest_uso";
			s_p_id_rm_dest_uso.DbType = CustomDBType.Integer;
			s_p_id_rm_dest_uso.Direction = ParameterDirection.Input;
			s_p_id_rm_dest_uso.Size = 10; 
			s_p_id_rm_dest_uso.Index = _SCollection.Count;
			s_p_id_rm_dest_uso.Value = id_rm_dest_uso;		
			_SCollection.Add(s_p_id_rm_dest_uso);

			//mq netti
			S_Controls.Collections.S_Object s_p_mq = new S_Object();
			s_p_mq.ParameterName = "p_mq";
			s_p_mq.DbType = CustomDBType.Double;
			s_p_mq.Direction = ParameterDirection.Input;
			s_p_mq.Size = 10; 
			s_p_mq.Index = _SCollection.Count;
			s_p_mq.Value = Mq;		
			_SCollection.Add(s_p_mq);

			return _SCollection;
		}
#endregion


//		private void BindGridPiani()
//		{
//			HiddenPianiStanze.Value="";
//
//			Buildings _Buildings = new Buildings();
//			DataSet _MyDs;
//	
//			_MyDs= _Buildings.GetPianiBuilding(itemId).Copy();
//
//			this.DataGridPiani.DataSource = _MyDs.Tables[0];
//			this.DataGridPiani.DataBind();
//
//			//this.LabelPiano.Text = _MyDs.Tables[0].Rows.Count.ToString();	
//			this.DataGridPiani.ShowFooter = false;
//		}

		private void BindGrid()
		{
			HiddenPianiStanze.Value="";

			Buildings _Buildings = new Buildings();
			DataSet _MyDs;
	
			_MyDs= _Buildings.GetPiano(itemId,pianoId).Copy();

			this.DataGridEsegui.DataSource = _MyDs.Tables[0];
			this.DataGridEsegui.DataBind();

			this.lblRecord.Text = _MyDs.Tables[0].Rows.Count.ToString();	
			this.DataGridEsegui.ShowFooter = false;
		}

	}
}
