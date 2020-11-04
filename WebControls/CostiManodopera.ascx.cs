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

	/// <summary>
	///		Descrizione di riepilogo per CostiManodopera.
	/// </summary>
	public class CostiManodopera : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid DataGridEsegui;
		protected System.Web.UI.WebControls.Label lblRecord;
		protected System.Web.UI.WebControls.LinkButton lkbNuovo;
		int _wrId;
		protected System.Web.UI.WebControls.Label lblTot1;		
		Double totale;
		Double tot;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.QueryString["ItemId"]!=null)
			{
				_wrId = Convert.ToInt32(Request.QueryString["ItemId"]);
			}
			if(Request["WR_ID"]!=null)
			{
				_wrId = Convert.ToInt32(Request["WR_ID"]);
			}
			//Faccio i conti
			Classi.ManCorrettiva.ClManCorrettiva _Totale = new TheSite.Classi.ManCorrettiva.ClManCorrettiva();
			DataSet DsManodoperaCosti = _Totale.TotManodopera(Convert.ToInt32(wrId));			
			if(DsManodoperaCosti.Tables[0].Rows.Count>0)
				tot=Convert.ToDouble(DsManodoperaCosti.Tables[0].Rows[0]["totaddetto"]);//Convert.ToDouble(DsManodoperaCosti.Tables[0].Rows[0]["totaddetto"])+;
			lblTot1.Text=Convert.ToString(tot);
			//
			if (!Page.IsPostBack )
			{
				
				DataTable TbDati;
				ClManCorrettiva ioDati = new ClManCorrettiva();
				DataSet DsManodopera = ioDati.GetListaManodopera(_wrId).Copy() ;
				TbDati = AggiungiColonnaTotProgressivo(DsManodopera.Tables[0]);

				DataRow o_Dr = TbDati.NewRow();
				o_Dr["ID"]=0;				
				o_Dr["IdAddetto"]=0;
				o_Dr["IdAddettoWR"]=0;
				o_Dr["CognomeNome"] =DBNull.Value;
				o_Dr["Livello"] ="<b>TOTALE</b>";
				o_Dr["PrezzoUnitario"] =DBNull.Value;
				o_Dr["OreLavorate"]=DBNull.Value;
				o_Dr["Totale"]=0;
				o_Dr["DescrizioneIntervento"]=DBNull.Value;								
				TbDati.Rows.Add(o_Dr);				
				lblRecord.Text = DsManodopera.Tables[0].Rows.Count.ToString(); 	
				DataGridEsegui.DataSource =TbDati; 
				DataGridEsegui.DataBind();
				
			//	ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();

			}
		}
		private DataTable AggiungiColonnaTotProgressivo(DataTable tb)
		{
			return tb;

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
			
			DropDownList cmbNomeCognome;
			TextBox txtDescIntervento, txtPrezzoUnitario, txtOreLavorate, txtTotale;//
			Label lblIdAddettoEdit,lblIdAddettoWREdit;
			
			lblIdAddettoEdit = (Label) e.Item.FindControl("lblIdAddettoEdit");
			lblIdAddettoWREdit = (Label) e.Item.FindControl("lblIdAddettoWREdit");
			cmbNomeCognome     = (DropDownList) e.Item.FindControl("cmbAddettoEdit");
			txtDescIntervento = (TextBox) e.Item.FindControl("txtDescInterventoEdit");
			txtPrezzoUnitario = (TextBox) e.Item.FindControl("txtPrezzoUnitarioEdit");
			txtOreLavorate    = (TextBox)e.Item.FindControl("txtOreLavorateEdit");
			txtTotale  = (TextBox) e.Item.FindControl("TexTotaleEdit");
			
			string descrizioneIntervento = txtDescIntervento.Text;
			int idManodopera       = Convert.ToInt32(cmbNomeCognome.SelectedValue.Split(';')[0]);
			double prezzoUnitario = Convert.ToDouble(txtPrezzoUnitario.Text);
			int oreLavorate;
			if(txtOreLavorate.Text != "")
				oreLavorate  = Convert.ToInt32(txtOreLavorate.Text);
			else
				oreLavorate = 0;
			double prezzoTotale   = Convert.ToDouble(txtTotale.Text);
			int id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());			
			int i_Result = EseguiDataBaseManodopera(id, Classi.ExecuteType.Update,
				descrizioneIntervento,idManodopera, prezzoUnitario, oreLavorate, prezzoTotale);

			
			DataGridEsegui.EditItemIndex = -1;
			BindGrid();
			if(lblIdAddettoEdit.Text==lblIdAddettoWREdit.Text)
			{
				e.Item.Style["background-color"] = "green";
			}
			
		}		
		private void DataGridEsegui_EditCommand(object source, DataGridCommandEventArgs e)
		{	
			DataGridEsegui.EditItemIndex = (int) e.Item.ItemIndex;
			BindGrid();
			
		}

		public bool GetStato(string IdAddettoVal, string IdAddettoWRVal)
		{
			if(IdAddettoVal==IdAddettoWRVal)
			{
				return false;
			}
			else
			{
				return true; 
			}
		}
		


		private void DataGridEsegui_CancelCommand(object source, DataGridCommandEventArgs e)
		{			
			DataGridEsegui.EditItemIndex = -1;
			BindGrid();
		}		

		private void DataGridEsegui_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			int appo=0;
			DropDownList cmbNomeCognome;
			TextBox txtDescIntervento, txtPrezzoUnitario, txtOreLavorate, txtTotale; // 
			Label lblIdAddettoInsert, lblIdAddettoWRInsert;//, lblTestValInsert;, lblPrezzoUnitario;
			switch(((ImageButton)e.CommandSource).CommandName)
			{

				case "Insert":
					lblIdAddettoInsert = (Label) e.Item.FindControl("lblIdAddettoInsert");
					lblIdAddettoWRInsert = (Label) e.Item.FindControl("lblIdAddettoWRInsert");
					cmbNomeCognome    = (DropDownList) e.Item.FindControl("cmbAddettoInsert");
					txtDescIntervento = (TextBox) e.Item.FindControl("txtDescInterventoInsert");
					txtPrezzoUnitario = (TextBox) e.Item.FindControl("txtPrezzoUnitarioInsert");
					txtOreLavorate    = (TextBox)e.Item.FindControl("txtOreLavorateInsert");
					txtTotale         = (TextBox) e.Item.FindControl("TexTotaleInsert");

					string descrizioneIntervento = txtDescIntervento.Text;
					int idManodopera      = Convert.ToInt32(cmbNomeCognome.SelectedValue.Split(';')[0]);
					double prezzoUnitario = Convert.ToDouble(txtPrezzoUnitario.Text);
					int oreLavorate;
					if(txtOreLavorate.Text != "")
						oreLavorate = Convert.ToInt32(txtOreLavorate.Text);
					else
						oreLavorate=0;
					double prezzoTotale   = Convert.ToDouble(txtTotale.Text);


					int i_Result = EseguiDataBaseManodopera(0, Classi.ExecuteType.Insert,
						descrizioneIntervento, idManodopera, prezzoUnitario, oreLavorate, prezzoTotale);	
					DataGridEsegui.EditItemIndex = -1;

					if(lblIdAddettoInsert.Text==lblIdAddettoWRInsert.Text)
					{
						e.Item.Style["background-color"] = "#ffcc33";
					}

					appo=Convert.ToInt32(lblRecord.Text)+1;
					lblRecord.Text=appo.ToString();
						BindGrid();
					
					
					break;
				case "Delete":
					int id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());	
					int i_ResultDel = EseguiDataBaseManodopera(id, Classi.ExecuteType.Delete,String.Empty,0, 0, 0, 0);
					DataGridEsegui.EditItemIndex = -1;
					appo=Convert.ToInt32(lblRecord.Text)-1;
					lblRecord.Text=appo.ToString();
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
			DataSet DsManodopera = ioDati.GetListaManodopera(_wrId).Copy() ;
			tbDati = AggiungiColonnaTotProgressivo(DsManodopera.Tables[0]);

			//per inserire una riga

			DataRow o_Dr = tbDati.NewRow();
			o_Dr["ID"]=0;				
			o_Dr["IdAddetto"]=0;
			o_Dr["IdAddettoWR"]=0;
			o_Dr["CognomeNome"] =DBNull.Value;
			o_Dr["Livello"] ="<b>TOTALE</b>";
			o_Dr["PrezzoUnitario"] =DBNull.Value;
			o_Dr["OreLavorate"]=DBNull.Value;
			o_Dr["Totale"]=0;
			o_Dr["DescrizioneIntervento"]=DBNull.Value;
			tbDati.Rows.Add(o_Dr);
			
			DataGridEsegui.DataSource = tbDati;
			DataGridEsegui.DataBind();
			lblRecord.Text =  DsManodopera.Tables[0].Rows.Count.ToString();
			///////
		
			DataGridEsegui.ShowFooter = false;
		}
		protected DataTable GetManodopera()
		{
			ClManCorrettiva ioDati = new ClManCorrettiva();
			DataSet DsMateriali = ioDati.getBindComboManodopera().Copy();
			return DsMateriali.Tables[0];
		}	
		protected int GetIndex(string item)
		{
			if (item.Length > 0 )
			{
				ClManCorrettiva ioDati = new ClManCorrettiva();
				DataSet DsMateriali = ioDati.getBindComboManodopera().Copy();
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
		private int  EseguiDataBaseManodopera(int id, Classi.ExecuteType Operazione, 
				string descrizioneIntervento, int idManodopera, double  prezzoUnitario, int oreLavorate, double prezzoTotale)
		{
			int i_Result = 0;
			ClManCorrettiva ioDati = new ClManCorrettiva();
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			int cntParametro = 0;

			S_Object pId = new S_Object(); 
			pId.ParameterName = "p_id";
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

			S_Object pDescrizioneIntervento = new S_Object();
			pDescrizioneIntervento.ParameterName = "p_descrizione_Interv";
			pDescrizioneIntervento.DbType = CustomDBType.VarChar;
			pDescrizioneIntervento.Direction = ParameterDirection.Input;
			pDescrizioneIntervento.Index = cntParametro++;
			if(descrizioneIntervento == String.Empty)
			pDescrizioneIntervento.Value = DBNull.Value;
			else
			pDescrizioneIntervento.Value = descrizioneIntervento;
			_SCollection.Add(pDescrizioneIntervento);

			S_Object pIdManodopera = new S_Object();
			pIdManodopera.ParameterName = "p_IdAddetto";
			pIdManodopera.DbType = CustomDBType.Integer;
			pIdManodopera.Direction = ParameterDirection.Input;
			pIdManodopera.Index = cntParametro++;
			pIdManodopera.Value = idManodopera;
			_SCollection.Add(pIdManodopera);

			S_Object pPrezzoUnitario = new S_Object();
			pPrezzoUnitario.ParameterName = "p_PrezzoUnitario";
			pPrezzoUnitario.DbType = CustomDBType.Double;
			pPrezzoUnitario.Direction = ParameterDirection.Input;
			pPrezzoUnitario.Index = cntParametro++;
			pPrezzoUnitario.Value = prezzoUnitario;
			_SCollection.Add(pPrezzoUnitario);

			S_Object pOreLavorate = new S_Object();
			pOreLavorate.ParameterName = "p_Ore_lavorate";
			pOreLavorate.DbType = CustomDBType.Integer;
			pOreLavorate.Direction = ParameterDirection.Input;
			pOreLavorate.Index = cntParametro++;
			pOreLavorate.Value = oreLavorate;
			_SCollection.Add(pOreLavorate);
			
			S_Object pTotale = new S_Object();
			pTotale.ParameterName = "p_Totale";
			pTotale.DbType = CustomDBType.Double;
			pTotale.Direction = ParameterDirection.Input;
			pTotale.Index = cntParametro++;
			pTotale.Value = prezzoTotale;
			_SCollection.Add(pTotale);

			i_Result = ioDati.ExecuteManodopera(_SCollection, Operazione);			
	
			//Faccio i conti
			Classi.ManCorrettiva.ClManCorrettiva _Totale = new TheSite.Classi.ManCorrettiva.ClManCorrettiva();
			DataSet DsManodoperaCosti = _Totale.TotManodopera(Convert.ToInt32(_wrId));			
			if(DsManodoperaCosti.Tables[0].Rows.Count>0)
				tot=Convert.ToDouble(DsManodoperaCosti.Tables[0].Rows[0]["totaddetto"]);//Convert.ToDouble(DsManodoperaCosti.Tables[0].Rows[0]["totaddetto"])+;
			lblTot1.Text=Convert.ToString(tot);
			//
			return i_Result;
		}

		private void DataGridEsegui_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DropDownList cmbNomeCognome;
			TextBox  txtLivello,txtPrezzoUnitario,txtOreLavorate, txtTotale;
			Label lblIdAddetto,lblIdAddettoWR;
			Label sumtot;
			sumtot        = (Label) e.Item.FindControl("lblTotale");
			ImageButton img1= (ImageButton) e.Item.FindControl("imbEdit");
 
			if (sumtot != null )
			{
				totale+=Convert.ToDouble(sumtot.Text);
				 if (e.Item.ItemIndex == Convert.ToInt32(lblRecord.Text)-1)
				{
						
						sumtot.Text=FormattaDecimali(totale,2);
						img1.Visible=false;
					 
					 
					 for(int i=0; i<=9; i++)
					 {
						 if (i!= 6)
						 e.Item.Cells[i].BorderStyle=System.Web.UI.WebControls.BorderStyle.None;
					 }		 
					 
				}
				
			}
			if(e.Item.ItemType== ListItemType.Footer)
			{
				lblIdAddetto = (Label) e.Item.FindControl("lblIdAddettoInsert");
				lblIdAddettoWR = (Label) e.Item.FindControl("lblIdAddettoWRInsert");
				cmbNomeCognome    = (DropDownList) e.Item.FindControl("cmbAddettoInsert");
				txtLivello        = (TextBox) e.Item.FindControl("txtLivelloInsert");
				txtPrezzoUnitario = (TextBox) e.Item.FindControl("txtPrezzoUnitarioInsert");
				txtOreLavorate    = (TextBox) e.Item.FindControl("txtOreLavorateInsert");
				txtTotale         = (TextBox) e.Item.FindControl("TexTotaleInsert");
			

				
				string funzioneJsCmbValue = "cmbSelezione('" 
					+  cmbNomeCognome.ClientID + "','" 
					+ txtLivello.ClientID + "','" 
					+ txtPrezzoUnitario.ClientID + "','" 					
					+ txtOreLavorate.ClientID + "','" 
					+ txtTotale.ClientID + "');";

					cmbNomeCognome.Attributes.Add("onchange",funzioneJsCmbValue);

				string funzioneJsCalcolaTotale = "calcolaPrezzoTotale('"
					+ txtPrezzoUnitario.ClientID + "','"
					+ txtOreLavorate.ClientID + "','"
					+ txtTotale.ClientID + "');";
				txtOreLavorate.Attributes.Add("onkeyup",funzioneJsCalcolaTotale);
				string [] arValueCmb =  cmbNomeCognome.SelectedValue.Split(';');
				txtPrezzoUnitario.Attributes.Add("value",arValueCmb[2].ToString());

				txtLivello.Attributes.Add("value",arValueCmb[1].ToString());
				txtOreLavorate.Attributes.Add("onkeypress","ControllaCaratteri();");

				if(lblIdAddetto.Text==lblIdAddettoWR.Text)
				{
					e.Item.Style["background-color"] = "#ffcc33";
				}
				totale=totale + Convert.ToInt32(txtTotale.Text);

				
			}
			if(e.Item.ItemType== ListItemType.EditItem)
			{
				lblIdAddetto = (Label) e.Item.FindControl("lblIdAddettoEdit");
				lblIdAddettoWR = (Label) e.Item.FindControl("lblIdAddettoWREdit");
				cmbNomeCognome    = (DropDownList) e.Item.FindControl("cmbAddettoEdit");
				txtLivello        = (TextBox) e.Item.FindControl("txtLivelloEdit");
				txtPrezzoUnitario = (TextBox) e.Item.FindControl("txtPrezzoUnitarioEdit");
				txtOreLavorate    = (TextBox) e.Item.FindControl("txtOreLavorateEdit");
				txtTotale         = (TextBox) e.Item.FindControl("TexTotaleEdit");


				string funzioneJsCmbValue = "cmbSelezione('" 
					+  cmbNomeCognome.ClientID + "','" 
					+ txtLivello.ClientID + "','" 
					+ txtPrezzoUnitario.ClientID + "','" 				
					+ txtOreLavorate.ClientID + "','" 
					+ txtTotale.ClientID + "');";

					cmbNomeCognome.Attributes.Add("onchange",funzioneJsCmbValue);

				string funzioneJsCalcolaTotale = "calcolaPrezzoTotale('"
					+ txtPrezzoUnitario.ClientID + "','"
					+ txtOreLavorate.ClientID + "','"
					+ txtTotale.ClientID  + "');";
				txtOreLavorate.Attributes.Add("onkeyup",funzioneJsCalcolaTotale);
				txtOreLavorate.Attributes.Add("onkeypress","ControllaCaratteri();");	
	
				if(lblIdAddetto.Text==lblIdAddettoWR.Text)
				{
					e.Item.Style["background-color"] = "#ffcc33";
				}
			}
			
			if(e.Item.ItemType== ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				lblIdAddetto = (Label) e.Item.FindControl("lblIdAddetto");
				lblIdAddettoWR = (Label) e.Item.FindControl("lblIdAddettoWR");
				int i;
				if(lblIdAddetto.Text==lblIdAddettoWR.Text)
				{
					e.Item.Cells[3].Style["border-bottom-color"]="red";
					e.Item.Cells[3].Style["border-bottom-width"] = "2px";
					e.Item.Cells[3].Style["border-bottom-style"] = "solid";
					e.Item.Cells[3].Style["border-top-color"]="red";
					e.Item.Cells[3].Style["border-top-width"] = "2px";
					e.Item.Cells[3].Style["border-top-style"] = "solid";
					e.Item.Cells[3].Style["border-left-color"]="red";
					e.Item.Cells[3].Style["border-left-width"] = "2px";
					e.Item.Cells[3].Style["border-left-style"] = "solid";
					for(i=4; i<9; i++)
					{
						e.Item.Cells[i].Style["border-bottom-color"]="red";
						e.Item.Cells[i].Style["border-bottom-width"] = "2px";
						e.Item.Cells[i].Style["border-bottom-style"] = "solid";
						e.Item.Cells[i].Style["border-top-color"]="red";
						e.Item.Cells[i].Style["border-top-width"] = "2px";
						e.Item.Cells[i].Style["border-top-style"] = "solid";					
					}
					e.Item.Cells[9].Style["border-bottom-color"]="red";
					e.Item.Cells[9].Style["border-bottom-width"] = "2px";
					e.Item.Cells[9].Style["border-bottom-style"] = "solid";
					e.Item.Cells[9].Style["border-top-color"]="red";
					e.Item.Cells[9].Style["border-top-width"] = "2px";
					e.Item.Cells[9].Style["border-top-style"] = "solid";
					e.Item.Cells[9].Style["border-right-color"]="red";
					e.Item.Cells[9].Style["border-right-width"] = "2px";
					e.Item.Cells[9].Style["border-right-style"] = "solid";
				}
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
			decimal numFormattato;
			if(numero!=System.DBNull.Value)
			{
				numFormattato = Convert.ToDecimal(numero);
				return numFormattato.ToString("N",nfi);
			}
			else
				return String.Empty;
		}


	}
}