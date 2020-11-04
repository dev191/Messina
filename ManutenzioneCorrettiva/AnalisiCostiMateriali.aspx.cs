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
using System.Globalization;

namespace TheSite.ManutenzioneCorrettiva
{
	/// <summary>
	/// Descrizione di riepilogo per GestioneMateriali.
	/// </summary>
	public class AnalisiCostiMateriali : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_ComboBox cmbsMateriale;
		protected S_Controls.S_TextBox txtRdl;
		protected S_Controls.S_Button btnsRicerca;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.CalendarPicker CalendarPicker2;
		protected WebControls.PageTitle PageTitle1;
		public static int FunId = 0;
		protected S_Controls.S_ComboBox cmbsStato;
		protected System.Web.UI.WebControls.LinkButton lkbNuovo;
		protected System.Web.UI.WebControls.Label lblRecord;
		protected System.Web.UI.HtmlControls.HtmlInputHidden wr_id;
		protected S_Controls.S_Button BtnReset;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected S_Controls.S_Button ExpPdf;
		private AnalisiCostiMateriali _AnalisiCostiMateriali;
		public string dascmat="";
		public string prezzo="";
		public string id="";
	    public static string HelpLink = string.Empty;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			HelpLink = _SiteModule.HelpLink;
			this.btnsRicerca.Attributes.Add("onclick", "return validateRange();");
			ExpPdf.Attributes.Add("onclick","OpenPopUp();");
			txtRdl.DBDefaultValue=-1;
			DataGridRicerca.Visible=false;
			this.PageTitle1.Title = "ANALISI COSTI MATERIALI";
			if(!IsPostBack)
				BindMateriali();
		}
		
		private void BindMateriali()
		{
		  	
			TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali _Materiali = new TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali();
			this.cmbsMateriale.Items.Clear();
			DataSet _myDS = _Materiali.GetData().Copy();
			if(_myDS.Tables[0].Rows.Count > 0)
			{
				this.cmbsMateriale.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_myDS.Tables[0],"descrizione","id", "- Selezionare Materiale -", "-1");
				this.cmbsMateriale.DataTextField = "descrizione";
				this.cmbsMateriale.DataValueField = "id";
				this.cmbsMateriale.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Materiale-";
				this.cmbsMateriale.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		  
		}

		protected DataTable GetMateriali()
		{
			TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali ioDati = new TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali();
			DataSet DsMateriali = ioDati.GetData().Copy();
			return DsMateriali.Tables[0];
		}
		protected int GetIndex(string item)
		{
			if (item.Length > 0 )
			{
				TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali ioDati = new TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali();
				DataSet DsMateriali = ioDati.GetData().Copy();
				int cnt =0;
				foreach(DataRow rw in DsMateriali.Tables[0].Rows)
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

		protected string FormattaDecimali(object numero,object cifre)
		{
			if(numero==DBNull.Value) return "";
			NumberFormatInfo nfi = new CultureInfo( "it-IT", false ).NumberFormat;
			nfi.NumberDecimalDigits = Convert.ToInt32(cifre);
			decimal numFormattato = Convert.ToDecimal(numero);
			return numFormattato.ToString("N",nfi);
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
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.lkbNuovo.Click += new System.EventHandler(this.lkbNuovo_Click);
			this.DataGridRicerca.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemCreated);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_CancelCommand);
			this.DataGridRicerca.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_EditCommand);
			this.DataGridRicerca.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_UpdateCommand);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			Ricerca();
		}

		private void Ricerca()
		{
			///Istanzio un nuovo oggetto Collection per aggiungere i parametri
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
					
			//Id_WR
			S_Controls.Collections.S_Object s_p_wrid = new S_Controls.Collections.S_Object();
			s_p_wrid.ParameterName = "p_wrid";
			s_p_wrid.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_wrid.Direction = ParameterDirection.Input;
			s_p_wrid.Size =50;
			s_p_wrid.Index = _SCollection.Count;
			s_p_wrid.Value =(txtRdl.Text ==string.Empty)? 0:Int32.Parse(txtRdl.Text);
			_SCollection.Add(s_p_wrid);

			//id_materiale
			S_Controls.Collections.S_Object s_p_id_materiale = new S_Controls.Collections.S_Object();
			s_p_id_materiale.ParameterName = "p_id_materiale";
			s_p_id_materiale.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_id_materiale.Direction = ParameterDirection.Input;
			s_p_id_materiale.Size =50;
			s_p_id_materiale.Index = _SCollection.Count;
			s_p_id_materiale.Value =Convert.ToInt32(cmbsMateriale.SelectedValue.ToString().Split(';')[0]);
			_SCollection.Add(s_p_id_materiale);

			//data aggiornamento Dal
			S_Controls.Collections.S_Object s_p_dataaggiornamentoDal = new S_Controls.Collections.S_Object();
			s_p_dataaggiornamentoDal.ParameterName = "p_dataaggiornamentoDal";
			s_p_dataaggiornamentoDal.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_dataaggiornamentoDal.Direction = ParameterDirection.Input;
			s_p_dataaggiornamentoDal.Size =50;
			s_p_dataaggiornamentoDal.Index = _SCollection.Count;
			s_p_dataaggiornamentoDal.Value =CalendarPicker1.Datazione.Text;
			_SCollection.Add(s_p_dataaggiornamentoDal);

			//data aggiornamento Al
			S_Controls.Collections.S_Object s_p_dataaggiornamentoAl = new S_Controls.Collections.S_Object();
			s_p_dataaggiornamentoAl.ParameterName = "p_dataaggiornamentoAl";
			s_p_dataaggiornamentoAl.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_dataaggiornamentoAl.Direction = ParameterDirection.Input;
			s_p_dataaggiornamentoAl.Size =50;
			s_p_dataaggiornamentoAl.Index = _SCollection.Count;
			s_p_dataaggiornamentoAl.Value =CalendarPicker2.Datazione.Text;
			_SCollection.Add(s_p_dataaggiornamentoAl);

			//Id stato
			S_Controls.Collections.S_Object s_p_stato = new S_Controls.Collections.S_Object();
			s_p_stato.ParameterName = "p_stato";
			s_p_stato.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_stato.Direction = ParameterDirection.Input;
			s_p_stato.Size =50;
			s_p_stato.Index = _SCollection.Count;
			s_p_stato.Value =Convert.ToInt32(cmbsStato.SelectedValue);
			_SCollection.Add(s_p_stato);

			TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali _Materiali = new TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali();
			
			///Eseguo il Binding sulla Griglia.
			DataSet Ds=_Materiali.GetData(_SCollection);

			
			
			if (Ds.Tables[0].Rows.Count >= 0) 
			{
				DataGridRicerca.Visible=true;
				
				lblRecord.Text="";
				DataTable dt=Ds.Tables[0];
				string curCat; 
				string prevCat=string.Empty; 
				int i = 0; 
				int QtaIn=0;
				int QtaOut=0;
				while (i <= dt.Rows.Count - 1) 
				{ 
					curCat = dt.Rows[i]["ID_MATERIALE"].ToString(); 
					if (i==0)
						prevCat = dt.Rows[i]["ID_MATERIALE"].ToString(); 


					if (curCat != prevCat) 
					{ 
						prevCat = curCat; 
						DataRow shRow =dt.NewRow(); 
						shRow["Descrizione"] = "Materiale"; 
						shRow["prezzo_unitario"] = QtaIn; 
						shRow["totale"] = QtaOut; 
						shRow["quantita"] = QtaIn+QtaOut; 
						shRow["id"] = -1;
						dt.Rows.InsertAt(shRow, i);
						QtaIn=0;
						QtaOut=0;
						i += 1; 
						
					} 
					
					
					if (Convert.ToInt32(dt.Rows[i]["quantita"])>0)
						QtaIn+=Convert.ToInt32(dt.Rows[i]["quantita"]);
					else
						QtaOut+=Convert.ToInt32(dt.Rows[i]["quantita"]);
					
					i += 1; 
				}
				if(dt.Rows.Count>0)
				{
					DataRow shRow =dt.NewRow(); 
					shRow["Descrizione"] = "Materiale"; 
					shRow["prezzo_unitario"] = QtaIn; 
					shRow["totale"] = QtaOut; 
					shRow["quantita"] = QtaIn+QtaOut; 
					shRow["id"] = -1;
					dt.Rows.InsertAt(shRow, i);
					
				}
				DataGridRicerca.DataSource=dt;
				lblRecord.Text=(Ds.Tables[0].Rows.Count)==0? "0":Ds.Tables[0].Rows.Count.ToString();
				DataGridRicerca.DataBind(); 

			}
			else
			{
				lblRecord.Text="Nessun dato trovato.";
				DataGridRicerca.Visible=false;				
			}

		DataGridRicerca.ShowFooter=false;
		}

	
		private void DataGridRicerca_EditCommand(object source, DataGridCommandEventArgs e)
		{	
			DataGridRicerca.EditItemIndex = (int) e.Item.ItemIndex;	
//			wr_id.Value= int.Parse(e.Item.Cells[0].ToString());
			int i=  int.Parse(DataGridRicerca.DataKeys[(int)e.Item.ItemIndex].ToString());
			Ricerca();
		
		}
		private void DataGridRicerca_CancelCommand(object source, DataGridCommandEventArgs e)
		{			
			DataGridRicerca.EditItemIndex = -1;		
			Ricerca();
		}		
		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DropDownList cmbMateriali;
			TextBox txtPrezzoUnitario;
			TextBox txtUnitaMisura;
			TextBox txtQuantita;
			
			
			if(e.Item.ItemType== ListItemType.Footer)
			{
				TextBox txtCalcolaTotale;
				TextBox TxtDescMat;
				TextBox txtprezzo;
				TextBox IdMateriale;
				txtPrezzoUnitario = (TextBox) e.Item.FindControl("txtprezzoInsert");
				TxtDescMat = (TextBox) e.Item.FindControl("TxtDescMat");
				txtprezzo = (TextBox) e.Item.FindControl("txtprezzoInsert");
				txtQuantita =(TextBox)e.Item.FindControl("txtquantitaInset");
				txtCalcolaTotale = (TextBox) e.Item.FindControl("txttotaleInsert");
				cmbMateriali = (DropDownList) e.Item.FindControl("cmbMaterialiInsert");
				IdMateriale=(TextBox) e.Item.FindControl("IdMateriale");
				dascmat=TxtDescMat.ClientID;
				prezzo=txtprezzo.ClientID;
				id=IdMateriale.ClientID;

				string funzioneJsCmbValue = "cmbSelezione('" 
					+  cmbMateriali.ClientID + "','" 
					+ txtPrezzoUnitario.ClientID + "','" 
					//+ txtUnitaMisura.ClientID + "','" 
					+ txtQuantita.ClientID + "','" 
					+ txtCalcolaTotale.ClientID + "');";
				cmbMateriali.Attributes.Add("onchange",funzioneJsCmbValue);
				string funzioneJsCalcolaTotale = "calcolaPrezzoTotale('"
					+ txtPrezzoUnitario.ClientID + "','"
					+ txtQuantita.ClientID + "','"
					+ txtCalcolaTotale.ClientID + "');";
				txtQuantita.Attributes.Add("onkeyup",funzioneJsCalcolaTotale);
				string [] arValueCmb =  cmbMateriali.SelectedValue.Split(';');
				txtPrezzoUnitario.Attributes.Add("value",arValueCmb[1].ToString());
//				txtUnitaMisura.Attributes.Add("value",arValueCmb[2].ToString());
				txtQuantita.Attributes.Add("onkeypress","ControllaCaratteri();");
			}
			if(e.Item.ItemType== ListItemType.EditItem)
			{
				TextBox txtCalcolaTotale;
				txtPrezzoUnitario = (TextBox) e.Item.FindControl("txtprezzoEdit");
				txtUnitaMisura = (TextBox) e.Item.FindControl("txtunitaEdit");
				txtQuantita =(TextBox)e.Item.FindControl("txtquantitaEdit");
				txtCalcolaTotale = (TextBox) e.Item.FindControl("txttotaleEdit");
				cmbMateriali = (DropDownList) e.Item.FindControl("cmbMaterialiEdit");
				

				string funzioneJsCmbValue = "cmbSelezione('" 
					+  cmbMateriali.ClientID + "','" 
					+ txtPrezzoUnitario.ClientID + "','" 
//					+ txtUnitaMisura.ClientID + "','" 
					+ txtQuantita.ClientID + "','" 
					+ txtCalcolaTotale.ClientID + "');";
				cmbMateriali.Attributes.Add("onchange",funzioneJsCmbValue);
				string funzioneJsCalcolaTotale = "calcolaPrezzoTotale('"
					+ txtPrezzoUnitario.ClientID + "','"
					+ txtQuantita.ClientID + "','"
					+ txtCalcolaTotale.ClientID  + "');";
				txtQuantita.Attributes.Add("onkeyup",funzioneJsCalcolaTotale);
				txtQuantita.Attributes.Add("onkeypress","ControllaCaratteri();");			
			}
			if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType== ListItemType.AlternatingItem)
			{
				Label subh;
//				Label LblIn;
//				Label LblOut;
//				Label LblTotale;
				DataRowView Dv= (DataRowView)e.Item.DataItem;
				subh= (Label) e.Item.FindControl("lblDescrizione");
//				LblIn= (Label) e.Item.FindControl("lblprezzo");
//				LblOut= (Label) e.Item.FindControl("lbltotale");
//				LblTotale= (Label) e.Item.FindControl("lblquantita");
//				
				if (subh.Text==("Materiale"))
				{
//					subh.Text="<b>&nbsp;&nbsp;&nbsp;Entrata:</b>"+Dv["prezzo_unitario"].ToString()+"<b>&nbsp;&nbsp;&nbsp;Uscita:</b>"+Dv["totale"].ToString()+ "&nbsp;&nbsp;&nbsp;<b>Saldo:</b>"+ Dv["quantita"].ToString();
					string str="<b>&nbsp;&nbsp;&nbsp;Entrata:&nbsp;</b>"+Dv["prezzo_unitario"].ToString()+"<b>&nbsp;&nbsp;&nbsp;Uscita:&nbsp;</b>"+Dv["totale"].ToString()+ "&nbsp;&nbsp;&nbsp;<b>Saldo:&nbsp;</b>"+ Dv["quantita"].ToString();
					e.Item.Cells.RemoveAt(6);
					e.Item.Cells.RemoveAt(5);
					e.Item.Cells.RemoveAt(4);
					e.Item.Cells.RemoveAt(3);
					e.Item.Cells.RemoveAt(2);
					e.Item.Cells.RemoveAt(1);
                    e.Item.Cells[0].ColumnSpan = 7;
					e.Item.Cells[0].Text=str;

//					e.Item.Cells.RemoveAt(1);
//					e.Item.Cells.RemoveAt(2);
//					e.Item.Cells.RemoveAt(3);									
//					LblTotale.Visible=false;
//					LblOut.Visible=false;
//					LblIn.Visible=false;
					
				}
	
			}
			
		}

		private void DataGridRicerca_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DropDownList cmbMateriali;
			TextBox txtPrezzoUnitario, txtQuantita, txtCalcolaTotale,IdMateriale;

			cmbMateriali      = (DropDownList) e.Item.FindControl("cmbMaterialiEdit");
			txtPrezzoUnitario = (TextBox) e.Item.FindControl("txtprezzoEdit");
			txtQuantita       =(TextBox)e.Item.FindControl("txtquantitaEdit");
			txtCalcolaTotale  = (TextBox) e.Item.FindControl("txttotaleEdit");
			DataRowView Dv= (DataRowView)e.Item.DataItem;
			IdMateriale  = (TextBox) e.Item.FindControl("IdMateriale");					

			int idMateriale       = Convert.ToInt32(IdMateriale.Text);
			double prezzoUnitario = Convert.ToDouble(txtPrezzoUnitario.Text);
			int quantita;
			if(txtQuantita.Text != "")
				quantita         = Convert.ToInt32(txtQuantita.Text);
			else
				quantita = 0;
			double prezzoTotale   = Convert.ToDouble(txtCalcolaTotale.Text);
			int id = int.Parse(DataGridRicerca.DataKeys[(int)e.Item.ItemIndex].ToString());			
			int i_Result = EseguiDataBaseMateriale(id, Classi.ExecuteType.Update,
				idMateriale, prezzoUnitario, quantita, prezzoTotale);
			DataGridRicerca.EditItemIndex = -1;
			Ricerca();
		}

		private int  EseguiDataBaseMateriale(int id, Classi.ExecuteType Operazione, 
			int idMateriale, double  prezzoUnitario, int quantita, double prezzoTotale)
		{
			int i_Result = 0;
			TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali ioDati = new TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali();
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			int cntParametro = 0;

			S_Object pId = new S_Object(); 
			pId.ParameterName = "p_id";
			pId.DbType = CustomDBType.Integer;
			pId.Direction = ParameterDirection.Input;
			pId.Index = cntParametro++;
			pId.Value = id;
			_SCollection.Add(pId);

//			S_Object pIdwr = new S_Object();
//			pIdwr.ParameterName = "p_WrId";
//			pIdwr.DbType = CustomDBType.Integer;
//			pIdwr.Direction = ParameterDirection.Input;
//			pIdwr.Index = cntParametro++;
//			pIdwr.Value =Convert.ToInt32(_wrId);
//			_SCollection.Add(pIdwr);

			S_Object pIdMateriale = new S_Object();
			pIdMateriale.ParameterName = "p_IdMateriale";
			pIdMateriale.DbType = CustomDBType.Integer;
			pIdMateriale.Direction = ParameterDirection.Input;
			pIdMateriale.Index = cntParametro++;
			pIdMateriale.Value = idMateriale;
			_SCollection.Add(pIdMateriale);

			S_Object pPrezzoUnitario = new S_Object();
			pPrezzoUnitario.ParameterName = "p_PrezzoUnitario";
			pPrezzoUnitario.DbType = CustomDBType.Double;
			pPrezzoUnitario.Direction = ParameterDirection.Input;
			pPrezzoUnitario.Index = cntParametro++;
			pPrezzoUnitario.Value = prezzoUnitario;
			_SCollection.Add(pPrezzoUnitario);

			S_Object pQuantita = new S_Object();
			pQuantita.ParameterName = "p_Quantita";
			pQuantita.DbType = CustomDBType.Integer;
			pQuantita.Direction = ParameterDirection.Input;
			pQuantita.Index = cntParametro++;
			pQuantita.Value =Math.Abs(quantita);
			_SCollection.Add(pQuantita);
			
			S_Object pTotale = new S_Object();
			pTotale.ParameterName = "p_Totale";
			pTotale.DbType = CustomDBType.Double;
			pTotale.Direction = ParameterDirection.Input;
			pTotale.Index = cntParametro++;
			pTotale.Value = Math.Abs(prezzoTotale);
			_SCollection.Add(pTotale);

			if (Operazione.ToString().ToUpper()== "INSERT")
						i_Result = ioDati.Add(_SCollection);	
			else if (Operazione.ToString().ToUpper()== "UPDATE")
					i_Result = ioDati.Update(_SCollection, id);	
			else 
				i_Result= ioDati.Delete(_SCollection, id);

			return i_Result;
		}

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DropDownList cmbMateriali;
			TextBox txtPrezzoUnitario, txtQuantita, txtCalcolaTotale,IdMateriale;
							
			switch(((ImageButton)e.CommandSource).CommandName)
			{

				case "Insert":
					cmbMateriali = ((DropDownList) e.Item.FindControl("cmbMaterialiInsert"));
					txtPrezzoUnitario = (TextBox) e.Item.FindControl("txtprezzoInsert");
					txtQuantita       =(TextBox)e.Item.FindControl("txtquantitaInset");
					txtCalcolaTotale  = (TextBox) e.Item.FindControl("txttotaleInsert");
					IdMateriale  = (TextBox) e.Item.FindControl("IdMateriale");
					

					int idMateriale       = Convert.ToInt32(IdMateriale.Text);
					double prezzoUnitario = Convert.ToDouble(txtPrezzoUnitario.Text);
					int quantita;
					if(txtQuantita.Text != "")
						quantita = Convert.ToInt32(txtQuantita.Text);
					else
						quantita=0;
					double prezzoTotale   = Convert.ToDouble(txtCalcolaTotale.Text);
					int i_Result = EseguiDataBaseMateriale(0, Classi.ExecuteType.Insert,
						idMateriale, prezzoUnitario, quantita, prezzoTotale);	
					DataGridRicerca.EditItemIndex = -1;
					Ricerca();
					break;
				case "Delete":
					int id = int.Parse(DataGridRicerca.DataKeys[(int)e.Item.ItemIndex].ToString());	
					int i_ResultDel = EseguiDataBaseMateriale(id, Classi.ExecuteType.Delete,0, 0, 0, 0);
					DataGridRicerca.EditItemIndex = -1;
					Ricerca();
					break;
				default:
					// Do nothing.
					break;
			}
		}

		private void lkbNuovo_Click(object sender, System.EventArgs e)
		{
			DataGridRicerca.EditItemIndex=-1;
			Ricerca();
			DataGridRicerca.Visible=true;
            DataGridRicerca.ShowFooter = true;
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AnalisiCostiMateriali.aspx"); 
		}

		private void DataGridRicerca_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			System.Web.UI.WebControls.ImageButton  _img = (System.Web.UI.WebControls.ImageButton) (e.Item.FindControl("imbDelete"));								
			if(_img!=null)
			{
					_img.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");	
				
			}
		}


		
	}
}
