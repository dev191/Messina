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
	public class PmpS : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.DataGrid DataGridEsegui;		
		protected System.Web.UI.WebControls.Label lblRecord;
		protected System.Web.UI.WebControls.LinkButton lkbNuovo;

		TheSite.Gestione.Pmp _fp;

		int FunId = 0;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected S_Controls.S_Button btnsSalvaTutto;
		protected System.Web.UI.WebControls.Label lblMessaggi;
		protected WebControls.PageTitle PageTitle1;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Button btnsAnnulla;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid DataGridDettaglio;		

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

			if (Request["ItemId"] != null) 
			{
				itemId = Int32.Parse(Request["ItemId"]);
			}
			if (!Page.IsPostBack )
			{

				//leggo le info del pmp e le metto nel datagrid del dettaglio
				//string id_pmp ="";
				Classi.ClassiAnagrafiche.Pmp _Pmp = new TheSite.Classi.ClassiAnagrafiche.Pmp();					
				DataSet _MyDsPmp = _Pmp.GetSingleData(itemId).Copy();
				//id_pmp = _MyDsPmp.Tables[0].Rows[0]["pmp_id"].ToString();
				this.DataGridDettaglio.DataSource = _MyDsPmp.Tables[0];
				this.DataGridDettaglio.DataBind();

				//leggo i passi
				Classi.PmpS _PmpS = new TheSite.Classi.PmpS();					
				//this.lblFirstAndLast.Text = _PmpS.GetFirstAndLastUser(_Dr);

				DataSet _MyDsPmpS = _PmpS.GetSingleData(itemId).Copy();

				DataView _dv = new DataView(_MyDsPmpS.Tables[0]);
				_dv.Sort = "PASSO ASC";

				this.DataGridEsegui.DataSource = _dv;//_MyDsPmpS.Tables[0];
				this.DataGridEsegui.DataBind();

				Session.Add("PmpS", _MyDsPmpS.Tables[0]);

				this.lblRecord.Text = _MyDsPmpS.Tables[0].Rows.Count.ToString();	
				this.DataGridEsegui.Columns[1].Visible = true;
				this.DataGridEsegui.Columns[2].Visible = false;
				this.DataGridEsegui.Columns[3].Visible = false;

				this.lblOperazione.Text = "";
				
				this.PageTitle1.Title = "Passi per Procedura di Manutenzione Programmata ";// + id_pmp;
				//this.lblFirstAndLast.Visible = true;

				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Pmp) 
				{
					_fp = (TheSite.Gestione.Pmp) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}
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
		
//		this.DataGridEsegui.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_CancelCommand);
//		this.DataGridEsegui.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_EditCommand);
//		this.DataGridEsegui.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_UpdateCommand);
//		this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
//		this.btnsElimina.Click += new System.EventHandler(this.btnsElimina_Click);
//		this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
//		this.Load += new System.EventHandler(this.Page_Load);
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{    
			this.lkbNuovo.Click += new System.EventHandler(this.lkbNuovo_Click);
			this.DataGridEsegui.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridEsegui_ItemCreated);
			this.DataGridEsegui.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_ItemCommand);
			this.DataGridEsegui.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_CancelCommand);
			this.DataGridEsegui.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_EditCommand);
			this.DataGridEsegui.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_UpdateCommand);
			this.DataGridEsegui.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_DeleteCommand);
			this.DataGridEsegui.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridEsegui_ItemDataBound);
			this.DataGridEsegui.SelectedIndexChanged += new System.EventHandler(this.DataGridEsegui_SelectedIndexChanged);
			this.btnsSalvaTutto.Click += new System.EventHandler(this.btnsSalvaTutto_Click);
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void DataGridEsegui_UpdateCommand(object source, DataGridCommandEventArgs e)
		{
			//ENTRO QUI QUANDO CONFERMO UNA MODIFICA
			S_Controls.S_TextBox txtIstruzioni = ((S_Controls.S_TextBox) e.Item.FindControl("txts_IstruzioniEdit"));
			S_Controls.S_TextBox txtTempo = ((S_Controls.S_TextBox) e.Item.FindControl("txts_TempoEdit"));

			if (txtIstruzioni.Text.Trim() != "" && txtTempo.Text.Trim() != "")
			{

//				if ((txtTempo.Text.Trim()))
//				{
				
					int id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());			

					DataTable o_Dt = (DataTable)Session["PmpS"]; 

					// Memorizzo gli elementi selezionati nel DataTable				
					string filtro = "PASSO=" + id.ToString();
					DataRow[] _Dr =  o_Dt.Select(filtro);										
					_Dr[0]["ISTRUZIONE"]=txtIstruzioni.Text.Trim();
					_Dr[0]["TEMPO"]=txtTempo.Text.Trim();

					Session.Remove("PmpS");
					Session.Add("PmpS", o_Dt);
					o_Dt.AcceptChanges();

							
					this.DataGridEsegui.EditItemIndex = -1;
					this.BindGrid();
					this.DataGridEsegui.Columns[1].Visible = true;
					this.DataGridEsegui.Columns[2].Visible = false;
					this.DataGridEsegui.Columns[3].Visible = false;
					this.DataGridEsegui.Columns[4].Visible = true;

					btnsSalvaTutto.Enabled=true;
//				}
//				else
//				{
//					lblMessaggi.Text = "Il tempo deve essere un valore numerico!";
//				}
			}
			else
			{
				lblMessaggi.Text = "E' necessario valorizzare entrambi i campi!";
			}
		}		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void DataGridEsegui_EditCommand(object source, DataGridCommandEventArgs e)
		{		
			this.DataGridEsegui.EditItemIndex = (int) e.Item.ItemIndex;
			this.BindGrid();
			S_Controls.S_TextBox txt = (S_Controls.S_TextBox) this.DataGridEsegui.Items[Int16.Parse(e.Item.ItemIndex.ToString())].Cells[7].FindControl("txts_TempoEdit");								
			
			if(txt!=null)
			{
				txt.Attributes.Add("onkeypress","SoloNumeri();");
				txt.Attributes.Add("onpaste","return false;");
			}

			this.DataGridEsegui.Columns[1].Visible = false;
			this.DataGridEsegui.Columns[2].Visible = true;
			this.DataGridEsegui.Columns[3].Visible = false;
			this.DataGridEsegui.Columns[4].Visible = false;

			btnsSalvaTutto.Enabled=false;
		}

		private void DataGridEsegui_CancelCommand(object source, DataGridCommandEventArgs e)
		{			
			this.DataGridEsegui.EditItemIndex = -1;
			this.BindGrid();
			this.DataGridEsegui.Columns[1].Visible = true;
			this.DataGridEsegui.Columns[2].Visible = false;
			this.DataGridEsegui.Columns[3].Visible = false;
			this.DataGridEsegui.Columns[4].Visible = true;

			btnsSalvaTutto.Enabled=true;
		}		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void DataGridEsegui_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			S_Controls.S_TextBox txtIstruzioni;
			S_Controls.S_TextBox txtTempo;
			int id;
			switch(((ImageButton)e.CommandSource).CommandName)
			{
				case "Insert":
					txtIstruzioni = ((S_Controls.S_TextBox) e.Item.FindControl("txts_IstruzioniNew"));
					txtTempo = ((S_Controls.S_TextBox) e.Item.FindControl("txts_TempoNew"));

					if (txtIstruzioni.Text.Trim() != "" && txtTempo.Text.Trim() != "")
					{
						DataTable o_Dt = (DataTable)Session["PmpS"]; 

						// Memorizzo gli elementi selezionati nel DataTable				
						DataRow _Dr =  o_Dt.NewRow(); //Select(filtro);										
						_Dr["PASSO"]=DataGridEsegui.Items.Count + 1;
						_Dr["ISTRUZIONE"]=txtIstruzioni.Text.Trim();
						_Dr["TEMPO"]=txtTempo.Text.Trim();
						o_Dt.Rows.Add(_Dr);
						o_Dt.AcceptChanges();

						Session.Remove("PmpS");
						Session.Add("PmpS", o_Dt);
						
						this.DataGridEsegui.EditItemIndex = -1;
						this.BindGrid();
						this.DataGridEsegui.Columns[1].Visible = true;
						this.DataGridEsegui.Columns[2].Visible = false;
						this.DataGridEsegui.Columns[3].Visible = false;
						this.DataGridEsegui.Columns[4].Visible = true;

						btnsSalvaTutto.Enabled=true;
					}
					else
					{
						lblMessaggi.Text = "E' necessario valorizzare entrambi i campi!";
					}
					break;
				case "Su":

				
					id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());			

					if (id != 1)
					{
						DataTable o_Dt = (DataTable)Session["PmpS"]; 

						// Memorizzo gli elementi selezionati nel DataTable				
						string filtro = "PASSO=" + id.ToString();
						string filtro2 = "PASSO=" + (id - 1).ToString();

						DataRow[] _Dr =  o_Dt.Select(filtro);
						DataRow[] _Dr2 =  o_Dt.Select(filtro2);
						_Dr[0]["PASSO"] = id - 1;//DataGridEsegui.Items.Count + 1;
						_Dr2[0]["PASSO"] = id;//DataGridEsegui.Items.Count + 1;
	
						o_Dt.AcceptChanges();

						Session.Remove("PmpS");
						Session.Add("PmpS", o_Dt);
						
						this.DataGridEsegui.EditItemIndex = -1;
						this.BindGrid();
//						this.DataGridEsegui.Columns[1].Visible = true;
//						this.DataGridEsegui.Columns[2].Visible = false;
//						this.DataGridEsegui.Columns[3].Visible = false;
//						this.DataGridEsegui.Columns[4].Visible = true;
					}
					break;

				case "Giu":
					id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());			

					if (id != DataGridEsegui.Items.Count)
					{
						DataTable o_Dt = (DataTable)Session["PmpS"]; 

						// Memorizzo gli elementi selezionati nel DataTable				
						string filtro = "PASSO=" + id.ToString();
						string filtro2 = "PASSO=" + (id + 1).ToString();

						DataRow[] _Dr =  o_Dt.Select(filtro);
						DataRow[] _Dr2 =  o_Dt.Select(filtro2);
						_Dr[0]["PASSO"] = id + 1;//DataGridEsegui.Items.Count + 1;
						_Dr2[0]["PASSO"] = id;//DataGridEsegui.Items.Count + 1;
	
						o_Dt.AcceptChanges();

						Session.Remove("PmpS");
						Session.Add("PmpS", o_Dt);
						
						this.DataGridEsegui.EditItemIndex = -1;
						this.BindGrid();
					}
					break;

				default:
					// Do nothing.
					break;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lkbNuovo_Click(object sender, System.EventArgs e)
		{
			BindGrid();			
			this.DataGridEsegui.ShowFooter = true;
//			S_Controls.S_TextBox txt = (S_Controls.S_TextBox) this.DataGridEsegui.Columns[7]
//			if(txt!=null)
//				txt.Attributes.Add("onkeypress","SoloNumeri();");			
			
			this.DataGridEsegui.Columns[1].Visible = false;
			this.DataGridEsegui.Columns[2].Visible = false;
			this.DataGridEsegui.Columns[3].Visible = true;
			this.DataGridEsegui.Columns[4].Visible = false;		
			btnsSalvaTutto.Enabled=false;
		}

		private void BindGrid()
		{
			Classi.PmpS _PmpS = new TheSite.Classi.PmpS();

			DataTable _MyDt = (DataTable)Session["PmpS"]; //_PmpS.GetSingleData(itemId).Copy();
			DataView _dv = new DataView(_MyDt);
			_dv.Sort = "PASSO ASC";
			this.DataGridEsegui.DataSource = _dv;//_MyDt;
			this.DataGridEsegui.DataBind();

			this.lblRecord.Text = _MyDt.Rows.Count.ToString();	
			this.DataGridEsegui.ShowFooter = false;
		}

		private int cancellaTutto(Classi.PmpS _PmpS){

			int i_Result = 0;
			int i_MaxParametri = 0;
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();;
			S_Controls.Collections.S_Object s_Istruz;
			S_Controls.Collections.S_Object s_Tmp;
			S_Controls.Collections.S_Object s_Step;
			//Classi.PmpS _PmpS = new TheSite.Classi.PmpS();
			
			//ISTRUZIONI
			s_Istruz = new S_Object();
			s_Istruz.ParameterName = "p_Istruzioni";
			s_Istruz.DbType = CustomDBType.VarChar;
			s_Istruz.Direction = ParameterDirection.Input;
			s_Istruz.Size = 4000; 
			s_Istruz.Index = i_MaxParametri;
			s_Istruz.Value = "";		

			i_MaxParametri ++;
						
			//TEMPO
			s_Tmp = new S_Object();
			s_Tmp.ParameterName = "p_Tempo";
			s_Tmp.DbType = CustomDBType.Integer;
			s_Tmp.Direction = ParameterDirection.Input;
			s_Tmp.Size = 10; 
			s_Tmp.Index = i_MaxParametri;
			s_Tmp.Value = 0;		

			//PASSO
			s_Step = new S_Object();
			s_Step.ParameterName = "p_seq_id";
			s_Step.DbType = CustomDBType.Integer;
			s_Step.Direction = ParameterDirection.Input;
			s_Step.Size = 10; 
			s_Step.Index = i_MaxParametri;
			s_Step.Value = 0;		
						
			_SCollection.Add(s_Istruz);
			_SCollection.Add(s_Tmp);
			_SCollection.Add(s_Step);
				
			i_Result = _PmpS.Delete(_SCollection,itemId);

			return i_Result;
		}

	


		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		protected int GetIndex(string item)
		{
			if (item.Length > 0 )
				return int.Parse(item);
			else
				return 0;
		}
		
		private int ExecuteAllUpdate()
		{

			int i_Result = 0;
			int i_MaxParametri = 0;
			DataRow riga;
			S_Controls.Collections.S_ControlsCollection _SCollection;
			S_Controls.Collections.S_Object s_Istruz;
			S_Controls.Collections.S_Object s_Tmp;
			S_Controls.Collections.S_Object s_Step;

			Classi.PmpS _PmpS = new TheSite.Classi.PmpS();
			DataTable TabellaStep = (DataTable)Session["PmpS"]; 
			//inizio la transazione
			_PmpS.beginTransaction();

			try
			{
				
				//prima cancello tutto
				this.cancellaTutto(_PmpS);
				//poi riscrivo tutto
				for (int i=0; i < TabellaStep.Rows.Count; i++)
				//foreach (DataRow riga in TabellaStep)
				{
					
					i_Result = 0;
					i_MaxParametri = 0;
					
					riga = TabellaStep.Rows[i];
					_SCollection = new S_Controls.Collections.S_ControlsCollection();
								
					//ISTRUZIONI
					s_Istruz = new S_Object();
					s_Istruz.ParameterName = "p_Istruzioni";
					s_Istruz.DbType = CustomDBType.VarChar;
					s_Istruz.Direction = ParameterDirection.Input;
					s_Istruz.Size = 4000; 
					s_Istruz.Index = i_MaxParametri;
					s_Istruz.Value = riga["ISTRUZIONE"];		

					i_MaxParametri ++;
					
					//TEMPO
					s_Tmp = new S_Object();
					s_Tmp.ParameterName = "p_Tempo";
					s_Tmp.DbType = CustomDBType.Integer;
					s_Tmp.Direction = ParameterDirection.Input;
					s_Tmp.Size = 10; 
					s_Tmp.Index = i_MaxParametri;
					s_Tmp.Value = riga["TEMPO"];		

					//PASSO
					s_Step = new S_Object();
					s_Step.ParameterName = "p_seq_id";
					s_Step.DbType = CustomDBType.Integer;
					s_Step.Direction = ParameterDirection.Input;
					s_Step.Size = 10; 
					s_Step.Index = i_MaxParametri;
					s_Step.Value = riga["PASSO"];		
					
					_SCollection.Add(s_Istruz);
					_SCollection.Add(s_Tmp);
					_SCollection.Add(s_Step);

					
					i_Result = _PmpS.Update(_SCollection,itemId);
				}
				_PmpS.commitTransaction();
			}
			catch
			{
				_PmpS.rollbackTransaction();
				return 0;
			}

			return i_Result;
		}
		
		private void DataGridEsegui_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			
			int id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());			

			DataTable o_Dt = (DataTable)Session["PmpS"]; 
			string filtro = "PASSO=" + id.ToString();
			DataRow[] _Dr =  o_Dt.Select(filtro);										
			_Dr[0].Delete();
			
			o_Dt.AcceptChanges();
			Session.Remove("PmpS");
			Session.Add("PmpS", o_Dt);

			this.DataGridEsegui.EditItemIndex = -1;
			this.BindGrid();
			
			this.DataGridEsegui.Columns[1].Visible = true;
			this.DataGridEsegui.Columns[2].Visible = false;
			this.DataGridEsegui.Columns[3].Visible = false;
			this.DataGridEsegui.Columns[4].Visible = true;
			btnsSalvaTutto.Enabled=true;


		}

		private void btnsSalvaTutto_Click(object sender, System.EventArgs e)
		{
			this.ExecuteAllUpdate();
			Server.Transfer("Pmp.aspx");
		}

		private void DataGridEsegui_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

		}

		private void DataGridEsegui_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{	
			if (e.Item.ItemType == ListItemType.Footer) 
			{
				S_Controls.S_TextBox txt = (S_Controls.S_TextBox) ((TableCell)e.Item.Cells[7]).FindControl("txts_TempoNew");								
				if(txt!=null)
				{
					txt.Attributes.Add("onkeypress","SoloNumeri();");			
					txt.Attributes.Add("onpaste","return false;");
				}
			}	

		}

		private void btnsAnnulla_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Pmp.aspx");
		}

		private void DataGridEsegui_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
