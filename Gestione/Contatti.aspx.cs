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
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per EditRuoli.
	/// </summary>
	public class Contatti : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected System.Web.UI.WebControls.DataGrid DataGridEsegui;		
		protected System.Web.UI.WebControls.Label lblRecord;
		protected System.Web.UI.WebControls.LinkButton lkbNuovo;

		int FunId = 0;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected System.Web.UI.WebControls.Label lblMessaggi;
		protected WebControls.PageTitle PageTitle1;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Button btnsAnnulla;
		protected System.Web.UI.WebControls.Label Label1;
		protected S_Controls.S_TextBox txtsNome;
		protected S_Controls.S_TextBox txtsCognome;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected S_Controls.S_ComboBox cmbsGruppo;		


		TheSite.Gestione.Richiedenti _fp;

		int itemId = 0;

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
			
			lblMessaggi.Text = "";
			FunId = Int32.Parse(Request["FunId"]);
			string id_tipo = "";

			if (Request["ItemId"] != null) 
			{
				itemId = Int32.Parse(Request["ItemId"]);
			}
			if (!Page.IsPostBack )
			{
				
				DataSet _MyDs = new DataSet();
				Classi.ClassiAnagrafiche.Richiedenti _Richiedenti = new TheSite.Classi.ClassiAnagrafiche.Richiedenti();
				_MyDs = _Richiedenti.GetSingleData(itemId); 
					
				if (_MyDs.Tables[0].Rows.Count == 1)
				{					
					DataRow _Dr = _MyDs.Tables[0].Rows[0];
					//						this.txtsdescrizione .Text= (string) _Dr["DESCRIZIONE"];

					if (_Dr["cognome"] != DBNull.Value)
						this.txtsCognome.Text = (string) _Dr["cognome"];
						
					if (_Dr["nome"] != DBNull.Value)
						this.txtsNome.Text = _Dr["nome"].ToString();						
					
												
					this.lblOperazione.Text = "Gestione Contatti";

					id_tipo = _Dr["id_tipo"].ToString();
					this.getAllGruppo(id_tipo);

					this.BindDataGrid();
				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Richiedenti)
				{
					_fp = (TheSite.Gestione.Richiedenti) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore);
				}
			}
		}

		private void BindDataGrid()
		{
			Classi.ClassiAnagrafiche.Contatti _Contatti = new TheSite.Classi.ClassiAnagrafiche.Contatti();
			DataSet _MyDsContatti = _Contatti.GetData(itemId);
			this.DataGridEsegui.DataSource = _MyDsContatti;
			this.DataGridEsegui.DataBind();
			this.lblRecord.Text=_MyDsContatti.Tables[0].Rows.Count.ToString();
		}
	
		private void getAllGruppo(string id_tipo)
		{
			this.cmbsGruppo.Items.Clear();
			Classi.ClassiAnagrafiche.Richiedenti_tipo _Richiedenti = new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo();
				
			DataSet _MyDs = _Richiedenti.GetAllData().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{				
				this.cmbsGruppo.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione","id", "- Selezionare una Gruppo -", "");
				this.cmbsGruppo.DataTextField = "descrizione";
				this.cmbsGruppo.DataValueField = "id";
				if(id_tipo!="")
					this.cmbsGruppo.SelectedValue=id_tipo;
				this.cmbsGruppo.DataBind();
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
			this.lkbNuovo.Click += new System.EventHandler(this.lkbNuovo_Click);
			this.btnsAnnulla.Click += new System.EventHandler(this.btnsAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			Response.Redirect((String) ViewState["UrlReferrer"]);
		}

		private void lkbNuovo_Click(object sender, System.EventArgs e)
		{
			this.DataGridEsegui.ShowFooter =true;
			this.DataGridEsegui.EditItemIndex = -1;
			BindDataGrid();

		}
		private void btnsAnnulla_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Richiedenti.aspx");
		}

		public DataSet loadTipoContatti()
		{
			Classi.ClassiAnagrafiche.Contatti_tipo _Contatti = new TheSite.Classi.ClassiAnagrafiche.Contatti_tipo();
			DataSet _MyDs = _Contatti.GetAllData().Copy();
			return _MyDs;
		}
		public int GetTipoContattiID( object ID)
		{
			int YourInteger = Int32.Parse( ((DataRowView)ID)["ID_TIPO"].ToString() );
			return YourInteger; 
			
		}
		protected void jskDataGrid_Edit(object sender, DataGridCommandEventArgs e) 
		{
			this.DataGridEsegui.ShowFooter =false;
			this.DataGridEsegui.EditItemIndex = e.Item.ItemIndex;
			BindDataGrid();
		}

		protected void jskDataGrid_Cancel(object sender, DataGridCommandEventArgs e) 
		{
			this.DataGridEsegui.ShowFooter =false;
			this.DataGridEsegui.EditItemIndex = -1;
			BindDataGrid();

		}
		protected void jskDataGrid_Delete(object sender, DataGridCommandEventArgs e) 
		{

			S_ControlsCollection _SCollection_0 = new S_ControlsCollection();


			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_idRichiedente";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = 0;
			s_IdIn.Value = itemId;

			S_Controls.Collections.S_Object s_IdTipoContatto = new S_Object();
			s_IdTipoContatto.ParameterName = "p_idTipoContatto";
			s_IdTipoContatto.DbType = CustomDBType.Integer;
			s_IdTipoContatto.Direction = ParameterDirection.Input;
			s_IdTipoContatto.Index = 1;
			s_IdTipoContatto.Value = 0;

			S_Controls.Collections.S_Object s_IdDescrizione = new S_Object();
			s_IdDescrizione.ParameterName = "p_Descrizione";
			s_IdDescrizione.DbType = CustomDBType.VarChar;
			s_IdDescrizione.Direction = ParameterDirection.Input;
			s_IdDescrizione.Index = 2;
			s_IdDescrizione.Size=10;
			s_IdDescrizione.Value = String.Empty;
				

			_SCollection_0.Add(s_IdIn);
			_SCollection_0.Add(s_IdTipoContatto);
			_SCollection_0.Add(s_IdDescrizione);
			Classi.ClassiAnagrafiche.Contatti _Contatti = new TheSite.Classi.ClassiAnagrafiche.Contatti();

			_Contatti.Delete(_SCollection_0,Int32.Parse(e.Item.Cells[1].Text));
				
			this.DataGridEsegui.ShowFooter =false;
			this.DataGridEsegui.EditItemIndex = -1;
			BindDataGrid();
		}
		protected void jskDataGrid_Update(object sender, DataGridCommandEventArgs e) 
		{
			try
			{
				string itemValue;
				string itemValue_1;
				
				if(this.DataGridEsegui.ShowFooter)
				{
					itemValue = ((System.Web.UI.WebControls.DropDownList)e.Item.FindControl("cmbsTipologia_New")).SelectedValue;
					itemValue_1 = ((System.Web.UI.WebControls.TextBox)e.Item.FindControl("txts_DescrizioneNew")).Text;
				}
				else
				{
					itemValue = ((System.Web.UI.WebControls.DropDownList)e.Item.FindControl("cmbsTipologia_Edit")).SelectedValue;
					itemValue_1 = ((System.Web.UI.WebControls.TextBox)e.Item.FindControl("txts_DescrizioneEdit")).Text;
				}


				S_ControlsCollection _SCollection_0 = new S_ControlsCollection();


				S_Controls.Collections.S_Object s_IdIn = new S_Object();
				s_IdIn.ParameterName = "p_idRichiedente";
				s_IdIn.DbType = CustomDBType.Integer;
				s_IdIn.Direction = ParameterDirection.Input;
				s_IdIn.Index = 0;
				s_IdIn.Value = itemId;

				S_Controls.Collections.S_Object s_IdTipoContatto = new S_Object();
				s_IdTipoContatto.ParameterName = "p_idTipoContatto";
				s_IdTipoContatto.DbType = CustomDBType.Integer;
				s_IdTipoContatto.Direction = ParameterDirection.Input;
				s_IdTipoContatto.Index = 1;
				s_IdTipoContatto.Value = Int32.Parse(itemValue);

				S_Controls.Collections.S_Object s_IdDescrizione = new S_Object();
				s_IdDescrizione.ParameterName = "p_Descrizione";
				s_IdDescrizione.DbType = CustomDBType.VarChar;
				s_IdDescrizione.Direction = ParameterDirection.Input;
				s_IdDescrizione.Index = 2;
				s_IdDescrizione.Value = itemValue_1;

				

				_SCollection_0.Add(s_IdIn);
				_SCollection_0.Add(s_IdTipoContatto);
				_SCollection_0.Add(s_IdDescrizione);
				Classi.ClassiAnagrafiche.Contatti _Contatti = new TheSite.Classi.ClassiAnagrafiche.Contatti();

				if(this.DataGridEsegui.ShowFooter)
					_Contatti.Add(_SCollection_0);
				else
					_Contatti.Update(_SCollection_0,Int32.Parse(e.Item.Cells[1].Text));
				
				this.DataGridEsegui.ShowFooter =false;
				this.DataGridEsegui.EditItemIndex = -1;
				BindDataGrid();

			}
			catch(Exception ex)
			{
				this.lblMessaggi.Text=ex.Message;

			}
		}


	}
}
