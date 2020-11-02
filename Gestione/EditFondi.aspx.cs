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
using StampaRapportiPdf.Classi;

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per EditFondi.
	/// </summary>
	public class EditFondi : System.Web.UI.Page    // System.Web.UI.Page
	{
		int itemId = 0;
		int FunId = 0;
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvEqstd;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected S_Controls.S_ComboBox cmbsAnno;
		protected S_Controls.S_ComboBox cmbsTipoIntervento;
		protected S_Controls.S_TextBox txtsimporto_netto_intero;
		protected S_Controls.S_TextBox txtsimporto_netto_decimale;
		protected S_Controls.S_TextBox txtsdescrizione;
		protected S_Controls.S_TextBox txtsNote;
		protected S_Controls.S_TextBox txtsimporto_lordo_decimale;
		protected S_Controls.S_TextBox txtsimporto_lordo_intero;		
		Fondi _fp;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//Imposto i controlli lato client
			txtsimporto_lordo_decimale.Attributes.Add("onblur","imposta_dec(this.id);");			
			txtsimporto_lordo_decimale.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtsimporto_lordo_decimale.Attributes.Add("onpaste","return false;");

			txtsimporto_netto_decimale.Attributes.Add("onblur","imposta_dec(this.id);");
			txtsimporto_netto_decimale.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtsimporto_netto_decimale.Attributes.Add("onpaste","return false;");

			txtsimporto_lordo_intero.Attributes.Add("onblur","imposta_int(this.id);");
			txtsimporto_lordo_intero.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtsimporto_lordo_intero.Attributes.Add("onpaste","return false;");

			txtsimporto_netto_intero.Attributes.Add("onblur","imposta_int(this.id);");
			txtsimporto_netto_intero.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtsimporto_netto_intero.Attributes.Add("onpaste","return false;");

			
			
			FunId = Int32.Parse(Request["FunId"]);			

			if (Request["itemId"] != null) 
			{
				itemId = Int32.Parse(Request["itemId"]);				
			}

			if (!Page.IsPostBack )
			{					
				CaricaCombo();
				if (itemId != 0) 
				{					
					Classi.ClassiAnagrafiche.Fondi	_Fondi = new TheSite.Classi.ClassiAnagrafiche.Fondi();				
					DataSet _MyDs = _Fondi.GetSingleData(itemId).Copy();
					
															
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];

						if (_Dr["Descrizione"] != DBNull.Value)
							this.txtsdescrizione.Text = (string) _Dr["descrizione"];

						if (_Dr["Note"] != DBNull.Value)
							this.txtsNote.Text = (string) _Dr["Note"];	
						
						if (_Dr["importo_netto"] != DBNull.Value)
						{							
							txtsimporto_netto_intero.Text =  Classi.Function.GetTypeNumber(_Dr["importo_netto"],Classi.NumberType.Intero).ToString();				
							txtsimporto_netto_decimale.Text =  Classi.Function.GetTypeNumber(_Dr["importo_netto"],Classi.NumberType.Decimale).ToString();
						}

						if (_Dr["importo_lordo"] != DBNull.Value)
						{
							txtsimporto_lordo_intero.Text =  Classi.Function.GetTypeNumber(_Dr["importo_lordo"],Classi.NumberType.Intero).ToString();
							txtsimporto_lordo_decimale.Text =  Classi.Function.GetTypeNumber(_Dr["importo_lordo"],Classi.NumberType.Decimale).ToString();								
						}							

						lblOperazione.Text = "Modifica Fondo: " + this.txtsdescrizione.Text;						
										
						
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");

						cmbsAnno.SelectedValue=_Dr["anno"].ToString();
						cmbsTipoIntervento.SelectedValue=_Dr["tipointervento_id"].ToString();
											
					}		
				}					
				else
				{
					lblOperazione.Text = "Inserimento Fondo";						
					btnsElimina.Visible=false;
				}	

				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Fondi) 
				{
					_fp = (TheSite.Gestione.Fondi) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}	
				
				if (Request["TipoOper"] == "read")				
					Abilita(false);				
				else				
					Abilita(true);	

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
			this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
			this.btnsElimina.Click += new System.EventHandler(this.btnsElimina_Click);
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region FunzioniPrivate
		/// <summary>
		/// Restituisce il valore intero o decimale di un numero   
		/// </summary>
		/// <param name="numero">numero in input</param>
		/// <param name="intero">true per l'intero false per il decimale</param>
		/// <returns>ritorna una stringa</returns>
		

		private void Abilita(bool tipo)
		{
			txtsimporto_netto_decimale.Enabled=tipo;
			txtsimporto_netto_intero.Enabled=tipo;

			txtsimporto_lordo_decimale.Enabled=tipo;
			txtsimporto_lordo_intero.Enabled=tipo;

			txtsNote.Enabled=tipo;
			txtsdescrizione.Enabled=tipo;
			
			cmbsAnno.Enabled=tipo;
			cmbsTipoIntervento.Enabled=tipo;

			btnsElimina.Enabled=tipo;
			btnsSalva.Enabled=tipo;
		}

		private void CaricaCombo()
		{
			//Carico il Combo degli Anni
			string anno_corrente = DateTime.Now.Year.ToString();
			for (int i = 1950; i <= 2051; i++)
			{ 	
				ListItem _L1 = new ListItem();
				ListItem _L2 = new ListItem();
				_L1.Text=i.ToString();
				_L1.Value=i.ToString();
				_L2.Text=i.ToString();
				_L2.Value=i.ToString();				
				cmbsAnno.Items.Add(_L2);
			}

			cmbsAnno.SelectedValue=anno_corrente;		

			//Caricol il combo Del Tipo Intervento
			cmbsTipoIntervento.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ClassiAnagrafiche.TipoIntervento  _TipoIntervento = new TheSite.Classi.ClassiAnagrafiche.TipoIntervento();

			DataSet _MyDs;
			_MyDs = _TipoIntervento.GetData();
			

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsTipoIntervento.DataSource =_MyDs.Tables[0];
				this.cmbsTipoIntervento.DataTextField = "descrizione_breve";
				this.cmbsTipoIntervento.DataValueField = "id";
				this.cmbsTipoIntervento.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Tipo Intervento -";
				this.cmbsTipoIntervento.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		private bool ControllaDup()
		{
			Classi.ClassiAnagrafiche.Fondi _Fondi = new TheSite.Classi.ClassiAnagrafiche.Fondi();
			
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();			
			
			// anno
			S_Controls.Collections.S_Object s_anno = new S_Object();
			s_anno.ParameterName = "p_anno";
			s_anno.DbType = CustomDBType.Integer;
			s_anno.Direction = ParameterDirection.Input;
			s_anno.Index = 1;
			s_anno.Value = cmbsAnno.SelectedValue;
			CollezioneControlli.Add(s_anno);
			// Tipo Intervento
			S_Controls.Collections.S_Object s_tipoint = new S_Object();
			s_tipoint.ParameterName = "p_TipoIntervento";
			s_tipoint.DbType = CustomDBType.Integer;
			s_tipoint.Direction = ParameterDirection.Input;
			s_tipoint.Index = 2;
			s_tipoint.Value = cmbsTipoIntervento.SelectedValue;
			CollezioneControlli.Add(s_tipoint);
			
			DataSet _MyDs= _Fondi.GetData(CollezioneControlli);
			if (_MyDs.Tables[0].Rows.Count==0)
				return true;
			else
				return false;
		}

		public void Aggiorna(TheSite.Classi.ExecuteType tipo)
		{
			Classi.ClassiAnagrafiche.Fondi _Fondi = new TheSite.Classi.ClassiAnagrafiche.Fondi();
			
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();			
			
			// anno
			S_Controls.Collections.S_Object s_anno = new S_Object();
			s_anno.ParameterName = "p_anno";
			s_anno.DbType = CustomDBType.Integer;
			s_anno.Direction = ParameterDirection.Input;
			s_anno.Index = 1;
			s_anno.Value = cmbsAnno.SelectedValue;
			CollezioneControlli.Add(s_anno);
			// Tipo Intervento
			S_Controls.Collections.S_Object s_tipoint = new S_Object();
			s_tipoint.ParameterName = "p_TipoIntervento";
			s_tipoint.DbType = CustomDBType.Integer;
			s_tipoint.Direction = ParameterDirection.Input;
			s_tipoint.Index = 2;
			s_tipoint.Value = cmbsTipoIntervento.SelectedValue;
			CollezioneControlli.Add(s_tipoint);
			// Importo Netto
			S_Controls.Collections.S_Object s_imp_net = new S_Object();
			s_imp_net.ParameterName = "p_importo_netto";
			s_imp_net.DbType = CustomDBType.Double;
			s_imp_net.Direction = ParameterDirection.Input;
			s_imp_net.Index = 3;
			s_imp_net.Value = Double.Parse(txtsimporto_netto_intero.Text + "," + txtsimporto_netto_decimale.Text);
			CollezioneControlli.Add(s_imp_net);
			// Importo Lordo
			S_Controls.Collections.S_Object s_imp_lor = new S_Object();
			s_imp_lor.ParameterName = "p_importo_lordo";
			s_imp_lor.DbType = CustomDBType.Double;
			s_imp_lor.Direction = ParameterDirection.Input;
			s_imp_lor.Index = 4;
			s_imp_lor.Value = Double.Parse(txtsimporto_lordo_intero.Text + "," + txtsimporto_lordo_decimale.Text);
			CollezioneControlli.Add(s_imp_lor);
			// Descrizione
			S_Controls.Collections.S_Object s_descr = new S_Object();
			s_descr.ParameterName = "p_descrizione";
			s_descr.DbType = CustomDBType.VarChar;
			s_descr.Direction = ParameterDirection.Input;
			s_descr.Index = 5;
			s_descr.Size=255;
			s_descr.Value = txtsdescrizione.Text.Trim();
			CollezioneControlli.Add(s_descr);
			// Note
			S_Controls.Collections.S_Object s_note = new S_Object();
			s_note.ParameterName = "p_note";
			s_note.DbType = CustomDBType.VarChar;
			s_note.Direction = ParameterDirection.Input;
			s_note.Index = 6;
			s_note.Size=500;
			s_note.Value = txtsNote.Text.Trim();
			CollezioneControlli.Add(s_note);
			int i_RowsAffected=0;

			try
			{	
				if (tipo==Classi.ExecuteType.Insert)
					i_RowsAffected = _Fondi.Add(CollezioneControlli);

				if (tipo==Classi.ExecuteType.Update)
					i_RowsAffected = _Fondi.Update(CollezioneControlli, itemId);	

				if (tipo==Classi.ExecuteType.Delete)
					i_RowsAffected = _Fondi.Delete(CollezioneControlli, itemId);

				Server.Transfer("Fondi.aspx");				
			}

			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}
			

		}
		#endregion		
		

		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Fondi.aspx");
		}

		private void btnsSalva_Click(object sender, System.EventArgs e)
		{	
			string mes="Attenzione la tipologia intervento: " + cmbsTipoIntervento.SelectedItem.Text; 
			mes+=" è già presente per l'anno: " + cmbsAnno.SelectedItem.Text;
			if(itemId==0)
				if(ControllaDup())
					Aggiorna(TheSite.Classi.ExecuteType.Insert);	
				else
					Classi.SiteJavaScript.msgBox(this.Page,mes); 
			else
				Aggiorna(TheSite.Classi.ExecuteType.Update);	
		}

		private void btnsElimina_Click(object sender, System.EventArgs e)
		{				
			Aggiorna(TheSite.Classi.ExecuteType.Delete);			
		}


		public clMyCollection _Contenitore
		{ 
			get 
			{
				if(this.ViewState["mioContenitore"]!=null)
					return (clMyCollection)this.ViewState["mioContenitore"];
				else
					return new clMyCollection();
			}
		}
	}
}
