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
	public class EditPianoFerie : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
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


		TheSite.Gestione.Addetti _fp;

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
				
				DataSet _MyDs = new DataSet();
				Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
				_MyDs = _Addetti.GetSingleData(itemId); 
					
				if (_MyDs.Tables[0].Rows.Count == 1)
				{	
					DataRow _Dr = _MyDs.Tables[0].Rows[0];
					this.txtsCognome.Text= (string) _Dr["COGNOME"];
					
					if (_Dr["NOME"] != DBNull.Value)
						this.txtsNome.Text = (string) _Dr["NOME"];

					this.lblOperazione.Text = "Piano Ferie Addetto: " + this.txtsCognome.Text + " " + this.txtsNome.Text;
					this.lblFirstAndLast.Visible = true;						
					lblFirstAndLast.Text = _Addetti.GetFirstAndLastUser(_Dr);


					this.BindDataGrid();
				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Addetti) 
				{
					_fp = (TheSite.Gestione.Addetti) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}	
			}
		}

		private void BindDataGrid()
		{
			Classi.ClassiAnagrafiche.PianoFerie _PianoFerie = new TheSite.Classi.ClassiAnagrafiche.PianoFerie();
			DataSet _MyDsPianoFerie = _PianoFerie.GetData(itemId);
			this.DataGridEsegui.DataSource = _MyDsPianoFerie;
			this.DataGridEsegui.DataBind();
			this.lblRecord.Text=_MyDsPianoFerie.Tables[0].Rows.Count.ToString();
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
			this.DataGridEsegui.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridEsegui_ItemDataBound);
			this.btnsAnnulla.Click += new System.EventHandler(this.btnsAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
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
			Server.Transfer("Addetti.aspx");
		}

		public DataSet loadMotivoAssenza()
		{
			Classi.ClassiAnagrafiche.Motivo_assenza _Motivo_assenza = new TheSite.Classi.ClassiAnagrafiche.Motivo_assenza();
			DataSet _MyDs = _Motivo_assenza.GetAllData().Copy();
			return _MyDs;
		}

		public int GetPianoFerieID( object ID)
		{
			int YourInteger = Int32.Parse( ((DataRowView)ID)["ID_MOTIVO"].ToString() );
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

			S_Controls.Collections.S_Object s_IdAddetto = new S_Object();
			s_IdAddetto.ParameterName = "p_idAddetto";
			s_IdAddetto.DbType = CustomDBType.Integer;
			s_IdAddetto.Direction = ParameterDirection.Input;
			s_IdAddetto.Index = 0;
			s_IdAddetto.Value = itemId;

			S_Controls.Collections.S_Object s_IdTipoMotivo = new S_Object();
			s_IdTipoMotivo.ParameterName = "p_idMotivo";
			s_IdTipoMotivo.DbType = CustomDBType.Integer;
			s_IdTipoMotivo.Direction = ParameterDirection.Input;
			s_IdTipoMotivo.Index = 1;
			s_IdTipoMotivo.Value = 0;

			S_Controls.Collections.S_Object s_dataStart = new S_Object();
			s_dataStart.ParameterName = "p_dataStart";
			s_dataStart.DbType = CustomDBType.VarChar;
			s_dataStart.Direction = ParameterDirection.Input;
			s_dataStart.Index = 2;
			s_dataStart.Size=10;
			s_dataStart.Value = String.Empty;

			S_Controls.Collections.S_Object s_dataEnd = new S_Object();
			s_dataEnd.ParameterName = "p_dataEnd";
			s_dataEnd.DbType = CustomDBType.VarChar;
			s_dataEnd.Direction = ParameterDirection.Input;
			s_dataEnd.Index = 3;
			s_dataEnd.Size=10;
			s_dataEnd.Value = String.Empty;
				

			_SCollection_0.Add(s_IdAddetto);
			_SCollection_0.Add(s_IdTipoMotivo);
			_SCollection_0.Add(s_dataStart);
			_SCollection_0.Add(s_dataEnd);

			Classi.ClassiAnagrafiche.PianoFerie _PianoFerie = new TheSite.Classi.ClassiAnagrafiche.PianoFerie();
			
			_PianoFerie.Delete(_SCollection_0,Int32.Parse(e.Item.Cells[1].Text));
				
			this.DataGridEsegui.ShowFooter =false;
			this.DataGridEsegui.EditItemIndex = -1;
			BindDataGrid();
		}
		protected void jskDataGrid_Update(object sender, DataGridCommandEventArgs e) 
		{
			try
			{
				string dataStart;
				string dataEnd;
				string motivo;
				string s_oraStart;
				string s_minStart;
				string s_oraEnd;
				string s_minEnd;
				
				if(this.DataGridEsegui.ShowFooter)
				{
					s_oraStart= ((System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtOraStartN")).Text;
					s_minStart= ((System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtMinStartN")).Text;
					dataStart = ((WebControls.CalendarPicker)e.Item.FindControl("Calendar_DataStartNew")).Datazione.Text;
					
					s_oraEnd= ((System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtOraEndN")).Text;
					s_minEnd= ((System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtMinEndN")).Text;
					dataEnd = ((WebControls.CalendarPicker)e.Item.FindControl("Calendar_DataEndNew")).Datazione.Text;
					motivo = ((System.Web.UI.WebControls.DropDownList)e.Item.FindControl("cmbsMotivo_New")).SelectedValue;

				}
				else
				{
					s_oraStart= ((System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtOraStartE")).Text;
					s_minStart= ((System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtMinStartE")).Text;
					dataStart = ((WebControls.CalendarPicker)e.Item.FindControl("Calendar_DataStartEdit")).Datazione.Text;
					
					s_oraEnd= ((System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtOraEndE")).Text;
					s_minEnd= ((System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtMinEndE")).Text;
					
					dataEnd = ((WebControls.CalendarPicker)e.Item.FindControl("Calendar_DataEndEdit")).Datazione.Text;
					motivo = ((System.Web.UI.WebControls.DropDownList)e.Item.FindControl("cmbsMotivo_Edit")).SelectedValue;
				}

				if(dataStart=="" || dataEnd=="")
				{
					this.lblMessaggi.Text="La data di inizio o la data di fine deve essere valorizzata";
					return;
				}


				DateTime sDateStartapp=System.Convert.ToDateTime(dataStart);
				
				string sDateStart=sDateStartapp.ToShortDateString()+" "+s_oraStart+":"+s_minStart;
				string DataInizio= sDateStartapp.Year.ToString()+sDateStartapp.Month.ToString().PadLeft(2,'0')+sDateStartapp.Day.ToString().PadLeft(2,'0')+s_oraStart.ToString().PadLeft(2,'0')+s_minStart.ToString().PadLeft(2,'0');
				
				DateTime sDateEndapp=System.Convert.ToDateTime(dataEnd);

				string sDateSEnd=sDateEndapp.ToShortDateString()+" "+s_oraEnd+":"+s_minEnd;
				string DataFine= sDateEndapp.Year.ToString()+sDateEndapp.Month.ToString().PadLeft(2,'0')+sDateEndapp.Day.ToString().PadLeft(2,'0')+s_oraEnd.ToString().PadLeft(2,'0')+s_minEnd.ToString().PadLeft(2,'0');
				
				if(Convert.ToInt64(DataInizio)>=Convert.ToInt64(DataFine))
				{
					this.lblMessaggi.Text="La data di fine deve essere superiore alla data di inizio";
					return;
				}
				S_ControlsCollection _SCollection_0 = new S_ControlsCollection();


				S_Controls.Collections.S_Object s_IdAddetto = new S_Object();
				s_IdAddetto.ParameterName = "p_idAddetto";
				s_IdAddetto.DbType = CustomDBType.Integer;
				s_IdAddetto.Direction = ParameterDirection.Input;
				s_IdAddetto.Index = 0;
				s_IdAddetto.Value = itemId;

				S_Controls.Collections.S_Object s_IdTipoMotivo = new S_Object();
				s_IdTipoMotivo.ParameterName = "p_idMotivo";
				s_IdTipoMotivo.DbType = CustomDBType.Integer;
				s_IdTipoMotivo.Direction = ParameterDirection.Input;
				s_IdTipoMotivo.Index = 1;
				s_IdTipoMotivo.Value = Int32.Parse(motivo);

				S_Controls.Collections.S_Object s_dataStart = new S_Object();
				s_dataStart.ParameterName = "p_dataStart";
				s_dataStart.DbType = CustomDBType.VarChar;
				s_dataStart.Direction = ParameterDirection.Input;
				s_dataStart.Index = 2;
				s_dataStart.Value = sDateStart;

				S_Controls.Collections.S_Object s_dataEnd = new S_Object();
				s_dataEnd.ParameterName = "p_dataEnd";
				s_dataEnd.DbType = CustomDBType.VarChar;
				s_dataEnd.Direction = ParameterDirection.Input;
				s_dataEnd.Index = 3;
				s_dataEnd.Value = sDateSEnd;
				

				_SCollection_0.Add(s_IdAddetto);
				_SCollection_0.Add(s_IdTipoMotivo);
				_SCollection_0.Add(s_dataStart);
				_SCollection_0.Add(s_dataEnd);

				Classi.ClassiAnagrafiche.PianoFerie _PianoFerie = new TheSite.Classi.ClassiAnagrafiche.PianoFerie();

				if(this.DataGridEsegui.ShowFooter)
					_PianoFerie.Add(_SCollection_0);
				else
					_PianoFerie.Update(_SCollection_0,Int32.Parse(e.Item.Cells[1].Text));
				
				this.DataGridEsegui.ShowFooter =false;
				this.DataGridEsegui.EditItemIndex = -1;
				BindDataGrid();

			}
			catch(Exception ex)
			{
				this.lblMessaggi.Text=ex.Message;

			}
		}

		private void DataGridEsegui_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Footer) 
			{
				System.Web.UI.WebControls.TextBox oraStart= (System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtOraStartN");
				System.Web.UI.WebControls.TextBox minStart= (System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtMinStartN");
				WebControls.CalendarPicker dataStart = (WebControls.CalendarPicker)e.Item.FindControl("Calendar_DataStartNew");
								
				System.Web.UI.WebControls.TextBox  oraEnd= (System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtOraEndN");
				System.Web.UI.WebControls.TextBox minEnd= (System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtMinEndN");
				WebControls.CalendarPicker dataEnd = (WebControls.CalendarPicker)e.Item.FindControl("Calendar_DataEndNew");
	

				oraEnd.Attributes.Add("onpaste","return nonpaste();");
				oraEnd.Attributes.Add("onblur","Formatta('" + oraEnd.ClientID + "');");
				oraEnd.Attributes.Add("maxlength","2");
				oraEnd.Attributes.Add("onkeypress","SoloNumeri();");

				minEnd.Attributes.Add("onpaste","return nonpaste();");
				minEnd.Attributes.Add("onblur","Formatta('" + minEnd.ClientID + "');");
				minEnd.Attributes.Add("maxlength","2");
				minEnd.Attributes.Add("onkeypress","SoloNumeri();");

				oraStart.Attributes.Add("onpaste","return nonpaste();");
				oraStart.Attributes.Add("onblur","Formatta('" + oraStart.ClientID + "');");
				oraStart.Attributes.Add("maxlength","2");
				oraStart.Attributes.Add("onkeypress","SoloNumeri();");

				minStart.Attributes.Add("onpaste","return nonpaste();");
				minStart.Attributes.Add("onblur","Formatta('" + minStart.ClientID + "');");
				minStart.Attributes.Add("maxlength","2");
				minStart.Attributes.Add("onkeypress","SoloNumeri();");
                
				ImageButton ImbInsert = (ImageButton) e.Item.FindControl("Imagebutton1");
				ImbInsert.Attributes.Add("onclick","return Controlla('" + oraStart.ClientID + "','" + minStart.ClientID  + "','"+ oraEnd.ClientID+"','"+ minEnd.ClientID+"');");  

			}
			if (e.Item.ItemType == ListItemType.EditItem)
			{
				System.Web.UI.WebControls.TextBox oraStart= (System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtOraStartE");
				System.Web.UI.WebControls.TextBox minStart= (System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtMinStartE");
				WebControls.CalendarPicker dataStart = (WebControls.CalendarPicker)e.Item.FindControl("Calendar_DataStartEdit");
			
				System.Web.UI.WebControls.TextBox  oraEnd= (System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtOraEndE");
				System.Web.UI.WebControls.TextBox minEnd= (System.Web.UI.WebControls.TextBox) e.Item.FindControl("TxtMinEndE");
				WebControls.CalendarPicker dataEnd = (WebControls.CalendarPicker)e.Item.FindControl("Calendar_DataEndEdit");
				
				oraEnd.Attributes.Add("onpaste","return nonpaste();");
				oraEnd.Attributes.Add("onblur","Formatta('" + oraEnd.ClientID + "');");
				oraEnd.Attributes.Add("maxlength","2");
				oraEnd.Attributes.Add("onkeypress","SoloNumeri();");

				minEnd.Attributes.Add("onpaste","return nonpaste();");
				minEnd.Attributes.Add("onblur","Formatta('" + minEnd.ClientID + "');");
				minEnd.Attributes.Add("maxlength","2");
				minEnd.Attributes.Add("onkeypress","SoloNumeri();");

				oraStart.Attributes.Add("onpaste","return nonpaste();");
				oraStart.Attributes.Add("onblur","Formatta('" + oraStart.ClientID + "');");
				oraStart.Attributes.Add("maxlength","2");
				oraStart.Attributes.Add("onkeypress","SoloNumeri();");

				minStart.Attributes.Add("onpaste","return nonpaste();");
				minStart.Attributes.Add("onblur","Formatta('" + minStart.ClientID + "');");
				minStart.Attributes.Add("maxlength","2");
				minStart.Attributes.Add("onkeypress","SoloNumeri();");

				ImageButton ImbUpdate= (ImageButton) e.Item.FindControl("ImbUpdate");
				ImbUpdate.Attributes.Add("onclick","return Controlla('" + oraStart.ClientID + "','" + minStart.ClientID  + "','"+ oraEnd.ClientID+"','"+ minEnd.ClientID+"');");  
			
			}
		}

	}
}
