namespace TheSite.WebControls
{
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

	/// <summary>
	///		Descrizione di riepilogo per CostiAddetti.
	/// </summary>
	public class CostiAddetti : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid DataGridEsegui;
		//int itemId = 0;
		public static int FunId = 0;
		int wr_id =0;
		protected System.Web.UI.WebControls.LinkButton lkbNuovo;
		protected System.Web.UI.WebControls.Label lblRecord;
		protected System.Web.UI.WebControls.Label lblTot1;
		int addetto_id =0;
		


		private void Page_Load(object sender, System.EventArgs e)
		{
			//codice funzione
			if (Request["FunId"] != null) 
			{
				FunId = Int32.Parse(Request["FunId"].ToString());	
			}
			if (Request["wr_id"] != null)
			{
				wr_id= Convert.ToInt32(Request.Params["wr_id"]);
			}
			if (Request["addetto_id"] != null)
			{
				addetto_id= Convert.ToInt32(Request.Params["addetto_id"]);
			}
			wr_id=79;
			BindGrid();
		}


		public DataTable GetAddetti()
		{
			Classi.CostiOperativi.CostoAddetti _Addetti = new TheSite.Classi.CostiOperativi.CostoAddetti();
			return _Addetti.GetAddetti().Tables[0];

		}

		private void BindGrid()
		{
			Classi.CostiOperativi.CostoAddetti _Addetti = new TheSite.Classi.CostiOperativi.CostoAddetti();
			DataSet _MyDs;
			
		
	
			_MyDs= _Addetti.GetSingleData(wr_id).Copy();

			this.DataGridEsegui.DataSource = _MyDs.Tables[0];
			this.DataGridEsegui.DataBind();

			this.lblRecord.Text = _MyDs.Tables[0].Rows.Count.ToString();	
			this.DataGridEsegui.ShowFooter = false;
		}

		private void DataGridEsegui_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			S_Controls.S_ComboBox cmbaddettoNew;
			S_Controls.S_TextBox txtdescrizioneNew; 
			S_Controls.S_TextBox txtOreLavorateNew;
					
			Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
			int i_Result=0;
   
			switch(((ImageButton)e.CommandSource).CommandName)
			{
				case "Insert":
					cmbaddettoNew = ((S_Controls.S_ComboBox) e.Item.FindControl("cmbaddettoNew"));
					txtdescrizioneNew = ((S_Controls.S_TextBox) e.Item.FindControl("txtdescrizioneNew")); 
					txtOreLavorateNew = ((S_Controls.S_TextBox) e.Item.FindControl("txtOreLavorateNew")); 

					
//					if (ddlstanzaNew.Text!= string.Empty)
//						i_Result = _Buildings.AddStanze(ControlsStanze(int.Parse(cmbPiani.SelectedValue), ddlstanzaNew.Text,ddldescrizionenew.Text));   
//					else
//						PanelMess.ShowError("Inserire una stanza");
					try
					{
						if (i_Result > 0)
						{
							this.DataGridEsegui.EditItemIndex = -1;
							this.BindGrid();
							this.DataGridEsegui.Columns[1].Visible = true;
							this.DataGridEsegui.Columns[2].Visible = false;
							this.DataGridEsegui.Columns[3].Visible = false;
						}
						else
						{
							
							this.DataGridEsegui.Columns[1].Visible = false;
							this.DataGridEsegui.Columns[2].Visible = false;
							this.DataGridEsegui.Columns[3].Visible = true;
						}
					}
					catch (Exception ex) 
					{
						Console.WriteLine(ex.Message);  
						//string s_Err = "Errore: Inserimento non riuscito";
//						PanelMess.ShowError(s_Err, true);
					}
					break;
				case "Delete":
					cmbaddettoNew = ((S_Controls.S_ComboBox) e.Item.FindControl("cmbaddettoNew"));
					txtdescrizioneNew = ((S_Controls.S_TextBox) e.Item.FindControl("txtdescrizioneNew")); 
					txtOreLavorateNew = ((S_Controls.S_TextBox) e.Item.FindControl("txtOreLavorateNew")); 

					
					int id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());
					 

					try
					{
//						i_Result = _Buildings.DeleteStanze(ControlsStanze(0, (DBNull.Value).ToString(),(DBNull.Value).ToString()),id);  
			
						if (i_Result >0)
						{
						
							this.DataGridEsegui.EditItemIndex = -1;
							this.BindGrid();
						}
					}
					catch (Exception ex) 
					{
						Console.WriteLine(ex.Message); 
						//string s_Err = "Errore: Cancellazione della stanza non riuscita";
//						PanelMess.ShowError(s_Err, true);
					}

					this.DataGridEsegui.Columns[1].Visible = true;
					this.DataGridEsegui.Columns[2].Visible = false;
					this.DataGridEsegui.Columns[3].Visible = false;
					break;
				
			
				default:
					// Do nothing.
					break;

			}
		}

		private void DataGridEsegui_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.DataGridEsegui.EditItemIndex = -1;
			this.BindGrid();
			this.DataGridEsegui.Columns[1].Visible = true;
			this.DataGridEsegui.Columns[2].Visible = false;
			this.DataGridEsegui.Columns[3].Visible = false;	
		}

		private void DataGridEsegui_EditCommand(object source, DataGridCommandEventArgs e)
		{		
			this.DataGridEsegui.EditItemIndex = (int) e.Item.ItemIndex;
			this.BindGrid();
			this.DataGridEsegui.Columns[1].Visible = false;
			this.DataGridEsegui.Columns[2].Visible = true;
			this.DataGridEsegui.Columns[3].Visible = false;
		}

		


		private void DataGridEsegui_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

			if(e.Item.ItemType == ListItemType.Footer)
			{
				S_Controls.S_ComboBox cmbaddettoNew;
				S_Controls.S_TextBox txtdescrizioneNew; 
				S_Controls.S_TextBox txtOreLavorateNew;
				S_Controls.S_Label lbllivelloNew;
				S_Controls.S_Label lblPrezzoUnitatioNew;
				

				cmbaddettoNew = ((S_Controls.S_ComboBox) e.Item.FindControl("cmbaddettoNew"));
				txtdescrizioneNew = ((S_Controls.S_TextBox) e.Item.FindControl("txtdescrizioneNew")); 
				txtOreLavorateNew = ((S_Controls.S_TextBox) e.Item.FindControl("txtOreLavorateNew")); 
				lbllivelloNew = ((S_Controls.S_Label) e.Item.FindControl("lbllivelloNew"));	
				lblPrezzoUnitatioNew = ((S_Controls.S_Label) e.Item.FindControl("lblPrezzoUnitatioNew"));	
				
			    cmbaddettoNew.Attributes.Add("onchange", 
					 "addetto('" + cmbaddettoNew.ClientID + "','" 
					+ lbllivelloNew.ClientID + "','"  
					+ lblPrezzoUnitatioNew.ClientID + "');");
				
			}
		}

		private void DataGridEsegui_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());
	
			S_Controls.S_ComboBox cmbaddettoNew;
			S_Controls.S_TextBox txtdescrizioneNew; 
			S_Controls.S_TextBox txtOreLavorateNew;
			
			cmbaddettoNew = ((S_Controls.S_ComboBox) e.Item.FindControl("cmbaddettoNew"));
			txtdescrizioneNew = ((S_Controls.S_TextBox) e.Item.FindControl("txtdescrizioneNew")); 
			txtOreLavorateNew = ((S_Controls.S_TextBox) e.Item.FindControl("txtOreLavorateNew")); 

			
			Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
			
			int i_Result=0;
			
			try
			{
			//	i_Result = _Buildings.UpdateStanze(ControlsStanze(int.Parse(cmbPiani.SelectedValue), ddlstanza.Text,ddldescrizione.Text),id);   
			
				if (i_Result > 0)
				{
					//this.PanelMessFunzioni.ShowMessage("Modifica della stanza effettuata con successo.", true);
					this.DataGridEsegui.EditItemIndex = -1;
					this.BindGrid();
					this.DataGridEsegui.Columns[1].Visible = true;
					this.DataGridEsegui.Columns[2].Visible = false;
					this.DataGridEsegui.Columns[3].Visible = false;
				}
				else
				{
					//this.PanelMessFunzioni.ShowError("Modifica non eseguita", true);
					this.DataGridEsegui.Columns[1].Visible = false;
					this.DataGridEsegui.Columns[2].Visible = true;
					this.DataGridEsegui.Columns[3].Visible = false;
				}
			}
			catch(Exception ex) 
			{
				Console.WriteLine(ex.Message);
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
			this.DataGridEsegui.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_ItemCommand);
			this.DataGridEsegui.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_CancelCommand);
			this.DataGridEsegui.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_EditCommand);
			this.DataGridEsegui.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_UpdateCommand);
			this.DataGridEsegui.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridEsegui_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lkbNuovo_Click(object sender, System.EventArgs e)
		{
		
				this.DataGridEsegui.ShowFooter = true;
				this.DataGridEsegui.Columns[1].Visible = false;
				this.DataGridEsegui.Columns[2].Visible = false;
				this.DataGridEsegui.Columns[3].Visible = true;
	
		}
	}
}
