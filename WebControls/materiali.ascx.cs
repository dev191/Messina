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
	using ApplicationDataLayer.DBType;
	using TheSite.Classi.ManCorrettiva;
	using System.Globalization;
	public class materiali : System.Web.UI.UserControl
	{
		
		protected System.Web.UI.WebControls.DataGrid DataGridEsegui;
		protected System.Web.UI.WebControls.Label lblRecord;
		protected System.Web.UI.WebControls.LinkButton lkbNuovo;
		protected System.Web.UI.WebControls.Label lblTot;
		int _wrId;
		Double tot;
		decimal valoreColonna;

	
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append("<script language=\"javascript\">\n");
			_StrBld.Append("Segnalibro();");			
			_StrBld.Append("</script>");
			Page.RegisterStartupScript("loc",_StrBld.ToString());

	

			if (!Page.IsPostBack )
			{
				DataTable TbDati;
				ClManCorrettiva ioDati = new ClManCorrettiva();
				DataSet DsMateriali = ioDati.GetListaMateriali(_wrId).Copy();
				TbDati = AggiungiColonnaTotProgressivo(DsMateriali.Tables[0]);
				DataGridEsegui.DataSource =TbDati; 
				DataGridEsegui.DataBind();
				lblRecord.Text = DsMateriali.Tables[0].Rows.Count.ToString(); 	

				ValorizzaTot();
			
			}
		}
		private void ValorizzaTot()
		{
			Classi.ManCorrettiva.ClManCorrettiva _Totale = new TheSite.Classi.ManCorrettiva.ClManCorrettiva();
			DataSet DsManodoperaCosti = _Totale.TotManodopera(Convert.ToInt32(_wrId));			
			if(DsManodoperaCosti.Tables[0].Rows.Count>0)
				tot=Convert.ToDouble(DsManodoperaCosti.Tables[0].Rows[0]["totmateriale"]);
			lblTot.Text=Convert.ToString(tot);
		}
		private DataTable AggiungiColonnaTotProgressivo(DataTable tb)
		{
			DataTable tbRet;
			DataColumn dc = new DataColumn("Totale_Progressivo");
			dc.DataType = System.Type.GetType("System.String");
			tb.Columns.Add(dc);
			if(tb.Rows.Count >0)
			{
				tb.Rows[0][7]= FormattaDecimali(tb.Rows[0][5],2);
				for(int i =1;i<tb.Rows.Count;i++)
				{
					valoreColonna = Convert.ToDecimal(tb.Rows[i-1][7]) + Convert.ToDecimal(tb.Rows[i][5]);
					tb.Rows[i][7] = FormattaDecimali(valoreColonna,2);
                   }
//				lblTot.Text=Convert.ToString(valoreColonna);
				}
			tbRet = tb;
			
			return tbRet;
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
		private void DataGridEsegui_UpdateCommand(object source, DataGridCommandEventArgs e)
		{
			
//			DropDownList cmbMateriali;
//			TextBox txtPrezzoUnitario, txtQuantita, txtCalcolaTotale;
//
//			cmbMateriali      = (DropDownList) e.Item.FindControl("cmbMaterialiEdit");
//			txtPrezzoUnitario = (TextBox) e.Item.FindControl("txtprezzoEdit");
//			txtQuantita       =(TextBox)e.Item.FindControl("txtquantitaEdit");
//			txtCalcolaTotale  = (TextBox) e.Item.FindControl("txttotaleEdit");
//			
//
//			int idMateriale       = Convert.ToInt32(cmbMateriali.SelectedValue.Split(';')[0]);
//			double prezzoUnitario = Convert.ToDouble(txtPrezzoUnitario.Text);
//			int quantita;
//			if(txtQuantita.Text != "")
//				quantita         = Convert.ToInt32(txtQuantita.Text);
//			else
//				quantita = 0;
//			double prezzoTotale   = Convert.ToDouble(txtCalcolaTotale.Text);
//			int id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());			
//			int i_Result = EseguiDataBaseMateriale(id, Classi.ExecuteType.Update,
//				idMateriale, prezzoUnitario, quantita, prezzoTotale);
		
			DataGridEsegui.EditItemIndex = -1;
			BindGrid();
			
		}		
		private void DataGridEsegui_EditCommand(object source, DataGridCommandEventArgs e)
		{	
			DataGridEsegui.EditItemIndex = (int) e.Item.ItemIndex;
			BindGrid();
		}
		private void DataGridEsegui_CancelCommand(object source, DataGridCommandEventArgs e)
		{			
			DataGridEsegui.EditItemIndex = -1;
			BindGrid();
		}		

		private void DataGridEsegui_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			DropDownList cmbMateriali;
			TextBox txtPrezzoUnitario, txtQuantita, txtCalcolaTotale;
			switch(((ImageButton)e.CommandSource).CommandName)
			{

				case "Insert":
					cmbMateriali = ((DropDownList) e.Item.FindControl("cmbMaterialiInsert"));
					txtPrezzoUnitario = (TextBox) e.Item.FindControl("txtprezzoInsert");
					txtQuantita       =(TextBox)e.Item.FindControl("txtquantitaInset");
					txtCalcolaTotale  = (TextBox) e.Item.FindControl("txttotaleInsert");

					int idMateriale       = Convert.ToInt32(cmbMateriali.SelectedValue.Split(';')[0]);
					double prezzoUnitario = Convert.ToDouble(txtPrezzoUnitario.Text);
					int quantita;
					if(txtQuantita.Text != "")
						quantita = Convert.ToInt32(txtQuantita.Text);
					else
						quantita=0;
					double prezzoTotale   = Convert.ToDouble(txtCalcolaTotale.Text);
					int i_Result = EseguiDataBaseMateriale(0, Classi.ExecuteType.Insert,
						idMateriale, prezzoUnitario, quantita, prezzoTotale);	
					DataGridEsegui.EditItemIndex = -1;
//					lblTot.Text=prezzoTotale.ToString();
					
					BindGrid();
					break;
				case "Delete":
					int id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());	
					int i_ResultDel = EseguiDataBaseMateriale(id, Classi.ExecuteType.Delete,0, 0, 0, 0);
					DataGridEsegui.EditItemIndex = -1;
		
					BindGrid();
					break;
				default:
					// Do nothing.
					break;
			}
			
		}
		private void lkbNuovo_Click(object sender, System.EventArgs e)
		{
			DataGridEsegui.EditItemIndex=-1;
			BindGrid();
			DataGridEsegui.ShowFooter = true;
		}
		private void BindGrid()
		{
			DataTable tbDati;
			ClManCorrettiva ioDati = new ClManCorrettiva();
			DataSet DsMateriali = ioDati.GetListaMateriali(_wrId).Copy();
			tbDati = AggiungiColonnaTotProgressivo(DsMateriali.Tables[0]);
			DataGridEsegui.DataSource = tbDati;
			DataGridEsegui.DataBind();
			lblRecord.Text =  DsMateriali.Tables[0].Rows.Count.ToString();
			DataGridEsegui.ShowFooter = false;

			ValorizzaTot();
		}
		protected DataTable GetMateriali()
		{
			
			ClManCorrettiva ioDati = new ClManCorrettiva();
			DataSet DsMateriali = ioDati.getBindComboMateriali().Copy();
			return DsMateriali.Tables[0];
		}	
		protected int GetIndex(string item)
		{
			if (item.Length > 0 )
			{
				ClManCorrettiva ioDati = new ClManCorrettiva();
				DataSet DsMateriali = ioDati.getBindComboMateriali().Copy();
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
		private int  EseguiDataBaseMateriale(int id, Classi.ExecuteType Operazione, 
			int idMateriale, double  prezzoUnitario, int quantita, double prezzoTotale)
		{
			int i_Result = 0;
			ClManCorrettiva ioDati = new ClManCorrettiva();
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			int cntParametro = 0;

			S_Object pId = new S_Object(); 
			pId.ParameterName = "p_ID";
			pId.DbType = CustomDBType.Integer;
			pId.Direction = ParameterDirection.Input;
			pId.Index = cntParametro++;
			pId.Value = id;
			_SCollection.Add(pId);

			S_Object pIdwr = new S_Object();
			pIdwr.ParameterName = "p_WrId";
			pIdwr.DbType = CustomDBType.Integer;
			pIdwr.Direction = ParameterDirection.Input;
			pIdwr.Index = cntParametro++;
			pIdwr.Value = _wrId;
			_SCollection.Add(pIdwr);

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
			pQuantita.Value = quantita;
			_SCollection.Add(pQuantita);
			
			S_Object pTotale = new S_Object();
			pTotale.ParameterName = "p_Totale";
			pTotale.DbType = CustomDBType.Double;
			pTotale.Direction = ParameterDirection.Input;
			pTotale.Index = cntParametro++;
			pTotale.Value = prezzoTotale;
			_SCollection.Add(pTotale);

			i_Result = ioDati.ExecuteMateriali(_SCollection, Operazione);			
	
			//Faccio i conti
//			Classi.ManCorrettiva.ClManCorrettiva _Totale = new TheSite.Classi.ManCorrettiva.ClManCorrettiva();
//			DataSet DsManodoperaCosti = _Totale.TotManodopera(Convert.ToInt32(_wrId));			
//			if(DsManodoperaCosti.Tables[0].Rows.Count>0)
//				tot=Convert.ToDouble(DsManodoperaCosti.Tables[0].Rows[0]["totmateriale"]);
//			lblTot.Text=Convert.ToString(tot);
			//

			return i_Result;
		}

		private void DataGridEsegui_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			DropDownList cmbMateriali;
			TextBox txtPrezzoUnitario;
			TextBox txtUnitaMisura;
			TextBox txtQuantita;
			
			
			if(e.Item.ItemType== ListItemType.Footer)
			{
				
				TextBox txtCalcolaTotale;
				txtPrezzoUnitario = (TextBox) e.Item.FindControl("txtprezzoInsert");
				txtUnitaMisura = (TextBox) e.Item.FindControl("txtunitaInsert");
				txtQuantita =(TextBox)e.Item.FindControl("txtquantitaInset");
				txtCalcolaTotale = (TextBox) e.Item.FindControl("txttotaleInsert");
				cmbMateriali = (DropDownList) e.Item.FindControl("cmbMaterialiInsert");
				
			
					UserMateriali UserMateriali1In;
					UserMateriali1In= (UserMateriali) e.Item.FindControl("UserMateriali1In");
					UserMateriali1In.wrIdIn=_wrId.ToString();
				
//				DataGridEsegui.Columns[3].Visible=false;
//				DataGridEsegui.Columns[4].Visible=false;
//				DataGridEsegui.Columns[5].Visible=false;
//				DataGridEsegui.Columns[6].Visible=false;
//				DataGridEsegui.Columns[7].Visible=false;
//				DataGridEsegui.Columns[1].Visible=false;

//				string funzioneJsCmbValue = "cmbSelezione('" 
//					+  cmbMateriali.ClientID + "','" 
//					+ txtPrezzoUnitario.ClientID + "','" 
//					+ txtUnitaMisura.ClientID + "','" 
//					+ txtQuantita.ClientID + "','" 
//					+ txtCalcolaTotale.ClientID + "');";
//				cmbMateriali.Attributes.Add("onchange",funzioneJsCmbValue);
//				string funzioneJsCalcolaTotale = "calcolaPrezzoTotale('"
//					+ txtPrezzoUnitario.ClientID + "','"
//					+ txtQuantita.ClientID + "','"
//					+ txtCalcolaTotale.ClientID + "');";
//				txtQuantita.Attributes.Add("onkeyup",funzioneJsCalcolaTotale);
//				string [] arValueCmb =  cmbMateriali.SelectedValue.Split(';');
//				txtPrezzoUnitario.Attributes.Add("value",arValueCmb[1].ToString());
//				txtUnitaMisura.Attributes.Add("value",arValueCmb[2].ToString());
//				txtQuantita.Attributes.Add("onkeypress","ControllaCaratteri();");
			}
			if(e.Item.ItemType== ListItemType.EditItem)
			{
				TextBox txtCalcolaTotale;
				txtPrezzoUnitario = (TextBox) e.Item.FindControl("txtprezzoEdit");
				txtUnitaMisura = (TextBox) e.Item.FindControl("txtunitaEdit");
				txtQuantita =(TextBox)e.Item.FindControl("txtquantitaEdit");
				txtCalcolaTotale = (TextBox) e.Item.FindControl("txttotaleEdit");
				cmbMateriali = (DropDownList) e.Item.FindControl("cmbMaterialiEdit");
			
				UserMateriali UserMateriali1;
				UserMateriali1= (UserMateriali) e.Item.FindControl("UserMateriali1");
			//	int i = DataGridEsegui.EditItemIndex;
			//	int appo= (int)DataGridEsegui.DataKeyField[i];
				int id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());			
				UserMateriali1.idMat=Convert.ToString(id);
				UserMateriali1.wrId=_wrId.ToString();

				ClManCorrettiva ioDati =new ClManCorrettiva();
				DataSet DsMateriali = ioDati.getMaterialiId(id).Copy();
				UserMateriali1.DescrizioneMateriali=DsMateriali.Tables[0].Rows[0]["descr"].ToString();
				UserMateriali1.PrezzoUnitario=DsMateriali.Tables[0].Rows[0]["prezzo_unitario"].ToString();
				UserMateriali1.UnitMisura=DsMateriali.Tables[0].Rows[0]["unita"].ToString();
				UserMateriali1.Quantita=DsMateriali.Tables[0].Rows[0]["quantita"].ToString();
				UserMateriali1.Totale=DsMateriali.Tables[0].Rows[0]["totale"].ToString();
				UserMateriali1.Materiale =DsMateriali.Tables[0].Rows[0]["materiale"].ToString();
			


//				string funzioneJsCmbValue = "cmbSelezione('" 
//					+  cmbMateriali.ClientID + "','" 
//					+ txtPrezzoUnitario.ClientID + "','" 
//					+ txtUnitaMisura.ClientID + "','" 
//					+ txtQuantita.ClientID + "','" 
//					+ txtCalcolaTotale.ClientID + "');";
//				cmbMateriali.Attributes.Add("onchange",funzioneJsCmbValue);
//				string funzioneJsCalcolaTotale = "calcolaPrezzoTotale('"
//					+ txtPrezzoUnitario.ClientID + "','"
//					+ txtQuantita.ClientID + "','"
//					+ txtCalcolaTotale.ClientID  + "');";
//				txtQuantita.Attributes.Add("onkeyup",funzioneJsCalcolaTotale);
//				txtQuantita.Attributes.Add("onkeypress","ControllaCaratteri();");			
			}
			if(e.Item.ItemType == ListItemType.Item)
			{
				

	
			}
			

		}
		public int wrId
		{
			get{ return _wrId;}
			set{ _wrId = value;}
		}
		public void AggiornaDati()
		{
			BindGrid();
		}
		protected string FormattaDecimali(object numero,object cifre)
		{
			NumberFormatInfo nfi = new CultureInfo( "it-IT", false ).NumberFormat;
			nfi.NumberDecimalDigits = Convert.ToInt32(cifre);
			decimal numFormattato = Convert.ToDecimal(numero);
			return numFormattato.ToString("N",nfi);
		}

		
	}
}