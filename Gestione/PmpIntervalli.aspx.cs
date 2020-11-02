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


namespace TheSite.Gestione
{
	/// <summary>
	/// Summary description for PmpIntervalli.
	/// </summary>
	public class PmpIntervalli : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lkbNuovo;
		protected System.Web.UI.WebControls.Label lblRecord;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.PageTitle PageTitle1;
		public int cnt =0;
		public int cntm =0;
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.PageTitle1.Title = "Pmp Intervalli";
			this.DataGridRicerca.Columns[1].Visible = true;
			this.DataGridRicerca.Columns[2].Visible = false;
			this.DataGridRicerca.Columns[3].Visible = false;
			if(!IsPostBack)
			Ricerca();
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
			this.lkbNuovo.Click += new System.EventHandler(this.lkbNuovo_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_CancelCommand);
			this.DataGridRicerca.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_EditCommand);
			this.DataGridRicerca.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_UpdateCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Carica Combo Mesi
		protected DataTable GetMesi()
		{
			TheSite.Classi.ClassiAnagrafiche.PmpIntervalli PmpIntervalli = new TheSite.Classi.ClassiAnagrafiche.PmpIntervalli();
			DataSet DsMesi = PmpIntervalli.GetMesi();
			return DsMesi.Tables[0];
		}

		protected int GetIndex(string item)
		{
			if (item.Length > 0 )
			{
				TheSite.Classi.ClassiAnagrafiche.PmpIntervalli PmpIntervalli = new TheSite.Classi.ClassiAnagrafiche.PmpIntervalli();
				DataSet DsMesi = PmpIntervalli.GetMesi();
				cntm =0;
				foreach(DataRow rw in DsMesi.Tables[0].Rows)
				{
					if(rw[1].ToString().Trim()==item.Trim())
					{
						//cntm= Convert.ToInt32(rw[0]);
						return cntm;
					}
					cntm++;
				}
				return 0;
			}

			else
				return 0;
		}
#endregion

		#region Carica Combo Servizi
		protected DataTable GetServizi()
		{
			TheSite.Classi.ClassiAnagrafiche.PmpIntervalli PmpIntervalli = new TheSite.Classi.ClassiAnagrafiche.PmpIntervalli();
			DataSet DsMServizi = PmpIntervalli.GetServizi();
			return DsMServizi.Tables[0];
		}


		protected int GetIndexServ(string item)
		{
			if (item.Length > 0 )
			{
				TheSite.Classi.ClassiAnagrafiche.PmpIntervalli PmpIntervalli = new TheSite.Classi.ClassiAnagrafiche.PmpIntervalli();
				DataSet DsMServizi = PmpIntervalli.GetServizi();
				cnt =0;
				foreach(DataRow rw in DsMServizi.Tables[0].Rows)
				{
					if(rw[1].ToString().Trim()==item.Trim())
					{
						return cnt;
					}
					cnt++;
				}
				return 0;
			}

			else
				return 0;
		}
		#endregion

		#region Ricerca
		private void Ricerca()
		{	
			TheSite.Classi.ClassiAnagrafiche.PmpIntervalli PmpIntervalli = new TheSite.Classi.ClassiAnagrafiche.PmpIntervalli();
			DataSet Ds=PmpIntervalli.GetData();
	
			if (Ds.Tables[0].Rows.Count >= 0) 
			{
				DataGridRicerca.Visible=true;				
				//DataTable dt=Ds.Tables[0];
				DataGridRicerca.DataSource=Ds.Tables[0];;
				lblRecord.Text=(Ds.Tables[0].Rows.Count)==0? "0":Ds.Tables[0].Rows.Count.ToString();
				DataGridRicerca.DataBind(); 
			}
			else
			{
				lblRecord.Text="Nessun dato trovato.";
				DataGridRicerca.Visible=false;				
			}

			DataGridRicerca.ShowFooter = false;

		}
		#endregion

		#region genera parametri per store

		private int  EseguiDataBase(int id, Classi.ExecuteType Operazione, 
			int idserv, int  p_interval_1_1, int p_interval_1_2, int p_interval_2_1, int p_interval_2_2)
		{



			int i_Result = 0;
			TheSite.Classi.ClassiAnagrafiche.PmpIntervalli PmpIntervalli = new TheSite.Classi.ClassiAnagrafiche.PmpIntervalli();
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			int cntParametro = 0;

			S_Object pId = new S_Object(); 
			pId.ParameterName = "p_id_intervallo";
			pId.DbType = CustomDBType.Integer;
			pId.Direction = ParameterDirection.Input;
			pId.Index = cntParametro++;
			pId.Value = id;
			_SCollection.Add(pId);

			S_Object p_servizi_id = new S_Object();
			p_servizi_id.ParameterName = "p_servizi_id";
			p_servizi_id.DbType = CustomDBType.Integer;
			p_servizi_id.Direction = ParameterDirection.Input;
			p_servizi_id.Index = cntParametro++;
			p_servizi_id.Value =idserv;
			_SCollection.Add(p_servizi_id);

			S_Object s_p_interval_1_1 = new S_Object();
			s_p_interval_1_1.ParameterName = "p_interval_1_1";
			s_p_interval_1_1.DbType = CustomDBType.Double;
			s_p_interval_1_1.Direction = ParameterDirection.Input;
			s_p_interval_1_1.Index = cntParametro++;
			s_p_interval_1_1.Value = p_interval_1_1;
			_SCollection.Add(s_p_interval_1_1);

			S_Object s_p_interval_1_2 = new S_Object();
			s_p_interval_1_2.ParameterName = "p_interval_1_2";
			s_p_interval_1_2.DbType = CustomDBType.Integer;
			s_p_interval_1_2.Direction = ParameterDirection.Input;
			s_p_interval_1_2.Index = cntParametro++;
			s_p_interval_1_2.Value =p_interval_1_2;
			_SCollection.Add(s_p_interval_1_2);
			
			S_Object s_p_interval_2_1 = new S_Object();
			s_p_interval_2_1.ParameterName = "p_interval_2_1";
			s_p_interval_2_1.DbType = CustomDBType.Double;
			s_p_interval_2_1.Direction = ParameterDirection.Input;
			s_p_interval_2_1.Index = cntParametro++;
			s_p_interval_2_1.Value = p_interval_2_1;
			_SCollection.Add(s_p_interval_2_1);

			S_Object s_p_interval_2_2 = new S_Object();
			s_p_interval_2_2.ParameterName = "p_interval_2_2";
			s_p_interval_2_2.DbType = CustomDBType.Double;
			s_p_interval_2_2.Direction = ParameterDirection.Input;
			s_p_interval_2_2.Index = cntParametro++;
			s_p_interval_2_2.Value =p_interval_2_2;
			_SCollection.Add(s_p_interval_2_2);

			if (Operazione.ToString().ToUpper()== "INSERT")
				i_Result = PmpIntervalli.Add(_SCollection);	
			else if (Operazione.ToString().ToUpper()== "UPDATE")
				i_Result = PmpIntervalli.Update(_SCollection, id);	
			else 
				i_Result= PmpIntervalli.Delete(_SCollection, id);

			return i_Result;
		}
		#endregion		

		#region Eventi DataGrid
		private void DataGridRicerca_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.DataGridRicerca.EditItemIndex = -1;
			this.Ricerca();
			this.DataGridRicerca.Columns[1].Visible = true;
			this.DataGridRicerca.Columns[2].Visible = false;
			this.DataGridRicerca.Columns[3].Visible = false;
		}

		private void DataGridRicerca_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.DataGridRicerca.EditItemIndex = (int) e.Item.ItemIndex;
			this.Ricerca();
			this.DataGridRicerca.Columns[1].Visible = false;
			this.DataGridRicerca.Columns[2].Visible = true;
			this.DataGridRicerca.Columns[3].Visible = false;
			ImageButton _imgSalva = (ImageButton) this.DataGridRicerca.Items[Int16.Parse(e.Item.ItemIndex.ToString())].Cells[4].FindControl("imbUpdate");								
			S_Controls.S_ComboBox  _cmb_1_1 = (S_Controls.S_ComboBox) this.DataGridRicerca.Items[Int16.Parse(e.Item.ItemIndex.ToString())].Cells[5].FindControl("CmbInt1_1Edit");							
			S_Controls.S_ComboBox  _cmb_1_2 = (S_Controls.S_ComboBox) this.DataGridRicerca.Items[Int16.Parse(e.Item.ItemIndex.ToString())].Cells[6].FindControl("CmbInt1_2Edit");							
			S_Controls.S_ComboBox  _cmb_2_1 = (S_Controls.S_ComboBox) this.DataGridRicerca.Items[Int16.Parse(e.Item.ItemIndex.ToString())].Cells[8].FindControl("CmbInt2_2Edit");	
			S_Controls.S_ComboBox  _cmb_2_2 = (S_Controls.S_ComboBox) this.DataGridRicerca.Items[Int16.Parse(e.Item.ItemIndex.ToString())].Cells[7].FindControl("CmbInt2_1Edit");		
			
			string funzione = "return controllaPeriodo(" + _cmb_1_1.ClientID + "," + _cmb_1_2.ClientID + "," + _cmb_2_1.ClientID + "," + _cmb_2_2.ClientID + ")" ;		
			
			if(_imgSalva!=null)
			{
				_imgSalva.Attributes.Add("title","Salva");
				_imgSalva.Attributes.Add("onclick",funzione);				
			}
		}


		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			S_Controls.S_ComboBox cmbServizio;
			S_Controls.S_ComboBox cmbInt1_1;
			S_Controls.S_ComboBox cmbInt1_2;
			S_Controls.S_ComboBox cmbInt2_1;
			S_Controls.S_ComboBox cmbInt2_2;

			switch(((ImageButton)e.CommandSource).CommandName)
			{

				case "Insert":
					cmbServizio = ((S_Controls.S_ComboBox) e.Item.FindControl("CmbServizioInsert"));
					cmbInt1_1= ((S_Controls.S_ComboBox) e.Item.FindControl("CmbInt1_1Insert"));
					cmbInt1_2= ((S_Controls.S_ComboBox) e.Item.FindControl("CmbInt1_2Insert"));
					cmbInt2_1= ((S_Controls.S_ComboBox) e.Item.FindControl("CmbInt2_1Insert"));
					cmbInt2_2= ((S_Controls.S_ComboBox) e.Item.FindControl("CmbInt2_2Insert"));



					int i_Result = this.EseguiDataBase(0,TheSite.Classi.ExecuteType.Insert,	Convert.ToInt32(cmbServizio.SelectedValue.ToString()), Convert.ToInt32(cmbInt1_1.SelectedValue), Convert.ToInt32(cmbInt1_2.SelectedValue), Convert.ToInt32(cmbInt2_1.SelectedValue), Convert.ToInt32(cmbInt2_2.SelectedValue));
			
					try
					{
						if (i_Result > 0)
						{
						//	this.lblMessage.Text = "Inserimento eseguito correttamente";
						//	lblMessage.CssClass = "";
							this.DataGridRicerca.EditItemIndex = -1;
							this.Ricerca();
							this.DataGridRicerca.Columns[1].Visible = true;
							this.DataGridRicerca.Columns[2].Visible = false;
							this.DataGridRicerca.Columns[3].Visible = false;
						}
						else
						{
							//lblMessage.Text = "Inserimento non eseguito";
						//	lblMessage.CssClass = "LabelErrore";
							this.DataGridRicerca.Columns[1].Visible = false;
							this.DataGridRicerca.Columns[2].Visible = false;
							this.DataGridRicerca.Columns[3].Visible = true;
						}
					}
					catch (Exception ex)
					{
						string s_Err = "Errore: Inserimento non riuscito";
					//	PanelMess.ShowError(s_Err, true);
					}
					break;
				case "Delete":
					cmbServizio = ((S_Controls.S_ComboBox) e.Item.FindControl("CmbServizioInsert"));
					cmbInt1_1= ((S_Controls.S_ComboBox) e.Item.FindControl("CmbInt1_1Insert"));
					cmbInt1_2= ((S_Controls.S_ComboBox) e.Item.FindControl("CmbInt1_2Insert"));
					cmbInt2_1= ((S_Controls.S_ComboBox) e.Item.FindControl("CmbInt2_1Insert"));
					cmbInt2_2= ((S_Controls.S_ComboBox) e.Item.FindControl("CmbInt2_2Insert"));

					int id = int.Parse(DataGridRicerca.DataKeys[(int)e.Item.ItemIndex].ToString());	
					try
					{
						int i_ResultDel = this.EseguiDataBase(id, Classi.ExecuteType.Delete,
							0, 0, 0, 0, 0);
			
						if (i_ResultDel == -1)
						{
							//this.lblMessage.Text = "Cancellazione eseguita correttamente";
							//lblMessage.CssClass = "";
							this.DataGridRicerca.EditItemIndex = -1;
							this.Ricerca();
						}
						else
						{
							//lblMessage.Text = "Associazione Ruolo - Cancellazione non eseguita";
							//lblMessage.CssClass = "LabelErrore";						
						}
					}
					catch (Exception ex) 
					{
						string s_Err = "Errore: Cancellazione non riuscita";
					//	PanelMess.ShowError(s_Err, true);
					}

					this.DataGridRicerca.Columns[1].Visible = true;
					this.DataGridRicerca.Columns[2].Visible = false;
					this.DataGridRicerca.Columns[3].Visible = false;
					break;
				default:
					// Do nothing.
					break;

			}
		}

		private void DataGridRicerca_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

			S_Controls.S_ComboBox	cmbServizio = ((S_Controls.S_ComboBox) e.Item.FindControl("CmbServizioEdit"));
			S_Controls.S_ComboBox   cmbInt1_1= ((S_Controls.S_ComboBox) e.Item.FindControl("CmbInt1_1Edit"));
			S_Controls.S_ComboBox   cmbInt1_2= ((S_Controls.S_ComboBox) e.Item.FindControl("CmbInt1_2Edit"));
			S_Controls.S_ComboBox   cmbInt2_1= ((S_Controls.S_ComboBox) e.Item.FindControl("CmbInt2_1Edit"));
			S_Controls.S_ComboBox   cmbInt2_2= ((S_Controls.S_ComboBox) e.Item.FindControl("CmbInt2_2Edit"));


			int id = int.Parse(DataGridRicerca.DataKeys[(int)e.Item.ItemIndex].ToString());			
			try
			{
				int i_Result = this.EseguiDataBase(id ,TheSite.Classi.ExecuteType.Update,	Convert.ToInt32(cmbServizio.SelectedValue.ToString()), Convert.ToInt32(cmbInt1_1.SelectedValue), Convert.ToInt32(cmbInt1_2.SelectedValue), Convert.ToInt32(cmbInt2_1.SelectedValue), Convert.ToInt32(cmbInt2_2.SelectedValue));

				if (i_Result > 0)
				{
				//	this.lblMessage.Text = "Associazione Ruolo - Modifica Eseguita correttamente";
					//lblMessage.CssClass = "";
					this.DataGridRicerca.EditItemIndex = -1;
					this.Ricerca();
					this.DataGridRicerca.Columns[1].Visible = true;
					this.DataGridRicerca.Columns[2].Visible = false;
					this.DataGridRicerca.Columns[3].Visible = false;
				}
				else
				{
					//lblMessage.Text = "Associazione Ruolo - Modifica non eseguita";
					//lblMessage.CssClass = "LabelErrore";
					this.DataGridRicerca.Columns[1].Visible = false;
					this.DataGridRicerca.Columns[2].Visible = true;
					this.DataGridRicerca.Columns[3].Visible = false;
				}
			}
			catch 
			{
				string s_Err = "Errore: Associazione  non riuscita";
			//	PanelMess.ShowError(s_Err, true);
			}
		}

		private void lkbNuovo_Click(object sender, System.EventArgs e)
		{		
			this.DataGridRicerca.ShowFooter = true;
			this.DataGridRicerca.Columns[1].Visible = false;
			this.DataGridRicerca.Columns[2].Visible = false;
			this.DataGridRicerca.Columns[3].Visible = true;
		}

		#endregion

		

	}
}
