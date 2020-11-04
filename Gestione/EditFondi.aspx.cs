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
using MyCollection;




namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per EditFondi.
	/// </summary>
	public class EditFondi : System.Web.UI.Page
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
		protected S_Controls.S_TextBox txtsimporto_netto_intero;
		protected S_Controls.S_TextBox txtsimporto_netto_decimale;
		protected S_Controls.S_TextBox txtsdescrizione;
		protected S_Controls.S_TextBox txtsNote;
		protected S_Controls.S_TextBox txtsimporto_lordo_decimale;
		protected S_Controls.S_TextBox txtsimporto_lordo_intero;
		protected S_Controls.S_TextBox TxtCodFondo;
		protected System.Web.UI.WebControls.DropDownList cmbPeriodo;
		protected System.Web.UI.WebControls.CheckBox CkDefault;

		protected System.Web.UI.WebControls.ListBox ListTipoManutenzioneAdd;
		protected System.Web.UI.WebControls.ListBox ListTipoManutenzione;
		protected System.Web.UI.WebControls.Button BtAdd;
		protected System.Web.UI.WebControls.Button BtRemove;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Rq1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Rq4;
		protected System.Web.UI.WebControls.DropDownList DrMeseini;
		protected System.Web.UI.WebControls.DropDownList DrAnnoIni;
		protected System.Web.UI.WebControls.DropDownList DrAnnofine;
		protected System.Web.UI.WebControls.DropDownList DrPiano;
		protected System.Web.UI.WebControls.DropDownList secondomese;
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
	
//			Rq2.ControlToValidate= CalendarPicker1.ID + ":" + CalendarPicker1.Datazione.ID;
//			Rq3.ControlToValidate= CalendarPicker2.ID + ":" + CalendarPicker2.Datazione.ID;

			FunId = Int32.Parse(Request["FunId"]);			

			if (Request["itemId"] != null) 
			{
				itemId = Int32.Parse(Request["itemId"]);				
			}

			if (!Page.IsPostBack )
			{					
				CaricaCombo();
		//		LoadMese();
				LoadAnno();
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
						
						if (_Dr["codicefondo"] != DBNull.Value)
							this.TxtCodFondo.Text = (string) _Dr["codicefondo"];
	
						if (_Dr["meseini"] != DBNull.Value)
							this.DrMeseini.SelectedValue = _Dr["meseini"].ToString();	

						if (_Dr["annoini"] != DBNull.Value)
							DrAnnoIni.SelectedValue = _Dr["annoini"].ToString();	

						if (_Dr["mesefine"] != DBNull.Value)
							this.secondomese.SelectedValue = _Dr["mesefine"].ToString();

						if (_Dr["annofine"] != DBNull.Value)
							DrAnnofine.SelectedValue = _Dr["annofine"].ToString();

						if (_Dr["periodicita"] != DBNull.Value)
							this.cmbPeriodo.SelectedValue =  _Dr["periodicita"].ToString();	

						//CreaPiano();

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
					
						if (_Dr["predefinito"] != DBNull.Value)
						{
								if(_Dr["predefinito"].ToString()=="1")
									CkDefault.Checked=true;
								else
									CkDefault.Checked=false;
						}
						else
							CkDefault.Checked=false;

						lblOperazione.Text = "Modifica Fondo: " + this.txtsdescrizione.Text;						
										
						
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");


						foreach(DataRow riga in _MyDs.Tables[1].Rows)
							ListTipoManutenzioneAdd.Items.Add(new ListItem(riga["descrizione"].ToString(),riga["tipointervento_id"].ToString())); 
							
						for ( int i = ListTipoManutenzione.Items.Count - 1; i >= 0; i-- )
						{
							if ( ListTipoManutenzioneAdd.Items.FindByText(ListTipoManutenzione.Items[i].Text)!=null)
								ListTipoManutenzione.Items.RemoveAt(i);
						}
						
						if(ListTipoManutenzioneAdd.Items.Count>0)
							ListTipoManutenzioneAdd.Items[0].Selected=true;
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
		private void LoadMese()
		{
			secondomese.Items.Add(new ListItem("- Nessun Mese -","0"));
			DrMeseini.Items.Add(new ListItem("- Nessun Mese -","0"));
			ArrayList ar=new ArrayList();
			ar.Add(new ListItem("Gennaio","1")); 
			ar.Add(new ListItem("Febbraio","2")); 
			ar.Add(new ListItem("Marzo","3")); 
			ar.Add(new ListItem("Aprile","4")); 
			ar.Add(new ListItem("Maggio","5")); 
			ar.Add(new ListItem("Giugno","6")); 
			ar.Add(new ListItem("Luglio","7")); 
			ar.Add(new ListItem("Agosto","8")); 
			ar.Add(new ListItem("Settembre","9")); 
			ar.Add(new ListItem("Ottobre","10")); 
			ar.Add(new ListItem("Novembre","11")); 
			ar.Add(new ListItem("Dicembre","12")); 
			for(int i=0;i<=ar.Count-1;i++)
			{
				secondomese.Items.Add((ListItem)ar[i]);
				DrMeseini.Items.Add((ListItem)ar[i]);
			}
		}
		private void LoadAnno()
		{
			DrAnnofine.Items.Add(new ListItem("- Nessun Anno -","0"));
			DrAnnoIni.Items.Add(new ListItem("- Nessun Anno -","0"));

			for (int i=2000; i<= DateTime.Now.Year +20; i++)
			{
				DrAnnofine.Items.Add(new ListItem(i.ToString(),i.ToString()));
				DrAnnoIni.Items.Add(new ListItem(i.ToString(),i.ToString()));
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
			this.BtAdd.Click += new System.EventHandler(this.BtAdd_Click);
			this.BtRemove.Click += new System.EventHandler(this.BtRemove_Click);
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
			
			ListTipoManutenzione.Enabled=tipo;
			ListTipoManutenzioneAdd.Enabled=tipo;
			DrMeseini.Enabled=tipo;
			secondomese.Enabled=tipo;
			DrAnnofine.Enabled=tipo;
			DrAnnoIni.Enabled=tipo;
              
			btnsElimina.Enabled=tipo;
			btnsSalva.Enabled=tipo;
		}

		private void CaricaCombo()
		{
			
			//Caricol il combo Del Tipo Intervento
			ListTipoManutenzione.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ClassiAnagrafiche.TipoIntervento  _TipoIntervento = new TheSite.Classi.ClassiAnagrafiche.TipoIntervento();

			DataSet _MyDs;
			_MyDs = _TipoIntervento.GetData();
			

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.ListTipoManutenzione.DataSource =_MyDs.Tables[0];
				this.ListTipoManutenzione.DataTextField = "descrizione_breve";
				this.ListTipoManutenzione.DataValueField = "id";
				this.ListTipoManutenzione.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Tipo Intervento -";
				this.ListTipoManutenzione.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}


		public void Aggiorna(TheSite.Classi.ExecuteType tipo)
		{
			Classi.ClassiAnagrafiche.Fondi _Fondi = new TheSite.Classi.ClassiAnagrafiche.Fondi();
			
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
			S_Controls.Collections.S_ControlsCollection CollezioneControlli2 = new S_Controls.Collections.S_ControlsCollection();			
			
			
			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_meseini";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Size=10;
			p.Index = CollezioneControlli.Count;
			p.Value=DrMeseini.SelectedValue;   
			CollezioneControlli.Add(p);
			CollezioneControlli2.Add(p);
			
			p = new S_Object();
			p.ParameterName = "p_mesefine";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Size=10;
			p.Index = CollezioneControlli.Count;
			p.Value=secondomese.SelectedValue;   
			CollezioneControlli.Add(p);
			CollezioneControlli2.Add(p);
			
			p = new S_Object();
			p.ParameterName = "p_annoini";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Size=10;
			p.Index = CollezioneControlli.Count;
			p.Value=DrAnnoIni.SelectedValue;   
			CollezioneControlli.Add(p);
			CollezioneControlli2.Add(p);

			p = new S_Object();
			p.ParameterName = "p_annofine";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Size=10;
			p.Index = CollezioneControlli.Count;
			p.Value=DrAnnofine.SelectedValue;   
			CollezioneControlli.Add(p);
			CollezioneControlli2.Add(p);
			
			p = new S_Object();
			p.ParameterName = "p_periodicita";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = CollezioneControlli.Count;
			p.Value=cmbPeriodo.SelectedValue;  
			CollezioneControlli.Add(p);

			// Importo Netto
			S_Controls.Collections.S_Object s_imp_net = new S_Object();
			s_imp_net.ParameterName = "p_importo_netto";
			s_imp_net.DbType = CustomDBType.Double;
			s_imp_net.Direction = ParameterDirection.Input;
			s_imp_net.Index = CollezioneControlli.Count;
			s_imp_net.Value = Double.Parse(txtsimporto_netto_intero.Text + "," + txtsimporto_netto_decimale.Text);
			CollezioneControlli.Add(s_imp_net);
			// Importo Lordo
			S_Controls.Collections.S_Object s_imp_lor = new S_Object();
			s_imp_lor.ParameterName = "p_importo_lordo";
			s_imp_lor.DbType = CustomDBType.Double;
			s_imp_lor.Direction = ParameterDirection.Input;
			s_imp_lor.Index = CollezioneControlli.Count;
			s_imp_lor.Value = Double.Parse(txtsimporto_lordo_intero.Text + "," + txtsimporto_lordo_decimale.Text);
			CollezioneControlli.Add(s_imp_lor);
			// Descrizione
			S_Controls.Collections.S_Object s_descr = new S_Object();
			s_descr.ParameterName = "p_descrizione";
			s_descr.DbType = CustomDBType.VarChar;
			s_descr.Direction = ParameterDirection.Input;
			s_descr.Index = CollezioneControlli.Count;
			s_descr.Size=255;
			s_descr.Value = txtsdescrizione.Text.Trim();
			CollezioneControlli.Add(s_descr);
			// Note
			S_Controls.Collections.S_Object s_note = new S_Object();
			s_note.ParameterName = "p_note";
			s_note.DbType = CustomDBType.VarChar;
			s_note.Direction = ParameterDirection.Input;
			s_note.Index = CollezioneControlli.Count;
			s_note.Size=500;
			s_note.Value = txtsNote.Text.Trim();
			CollezioneControlli.Add(s_note);

			// Codice Fondo
			S_Controls.Collections.S_Object s_codfondo = new S_Object();
			s_codfondo.ParameterName = "p_codicefondo";
			s_codfondo.DbType = CustomDBType.VarChar;
			s_codfondo.Direction = ParameterDirection.Input;
			s_codfondo.Index = CollezioneControlli.Count;
			s_codfondo.Size=500;
			s_codfondo.Value = TxtCodFondo.Text.Trim();
			CollezioneControlli.Add(s_codfondo);

			S_Controls.Collections.S_Object s_prede = new S_Object();
			s_prede.ParameterName = "p_predefinito";
			s_prede.DbType = CustomDBType.Integer;
			s_prede.Direction = ParameterDirection.Input;
			s_prede.Index = CollezioneControlli.Count;
			s_prede.Value =(CkDefault.Checked==true)?1:0;
			CollezioneControlli.Add(s_prede);


			int i_RowsAffected=0;
			ArrayList TipMan=new ArrayList();
			foreach(ListItem ite in ListTipoManutenzioneAdd.Items)
				TipMan.Add(ite.Value); 

	
			try
			{	
				if (tipo==Classi.ExecuteType.Insert)
				{
					i_RowsAffected = _Fondi.Add(CollezioneControlli);
					_Fondi.UpdateInsertManutenzioneFondo( i_RowsAffected,TipMan,CollezioneControlli2);
				}

				if (tipo==Classi.ExecuteType.Update)
				{
					i_RowsAffected = _Fondi.Update(CollezioneControlli, itemId);	
					_Fondi.UpdateInsertManutenzioneFondo(itemId ,TipMan,CollezioneControlli2);
				}

				if (tipo==Classi.ExecuteType.Delete)
				{
					_Fondi.DeleteManutenzioneFondo(itemId);
					i_RowsAffected = _Fondi.Delete(CollezioneControlli, itemId);
					
				}

				
				//Server.Transfer("Fondi.aspx");				
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
			try
			{
				if (CreaPiano())
					return;
				string mes="Attenzione il fondo: " + TxtCodFondo.Text; 
			
				if(itemId==0)
//					if(ControllaDup())
						Aggiorna(TheSite.Classi.ExecuteType.Insert);	
//					else
//						Classi.SiteJavaScript.msgBox(this.Page,mes); 
				else
					Aggiorna(TheSite.Classi.ExecuteType.Update);
	

				//Server.Transfer("Fondi.aspx");
			}
			catch (Exception ex)
			{
				Classi.SiteJavaScript.msgBox(this.Page,ex.Message); 
			}
		}
		private bool CreaPiano()
		{
		
			long periodo=int.Parse(cmbPeriodo.SelectedValue);
			DateTime times=new DateTime(int.Parse(DrAnnoIni.SelectedValue),int.Parse(DrMeseini.SelectedValue),1);
			DateTime timee=new DateTime(int.Parse(DrAnnofine.SelectedValue),int.Parse(secondomese.SelectedValue),1);
			
		    long month =DateAndTime.DateDiff(DateInterval.Month,times,timee); 
			if (month<=0)
			{
				Page.RegisterStartupScript("al","<script language='javascript'>alert('Intervallo di date non crea un periodo corretto!');</script>");
				return true;
			}
			if((month%periodo)>0)
			{
				Page.RegisterStartupScript("al","<script language='javascript'>alert('Intervallo di date non crea un periodo corretto!');</script>");
				return true;
			}else
			{
				DrPiano.Items.Clear();
				string desc=GetDescri(cmbPeriodo.SelectedValue);
				long intervallo=month/periodo;
				for(int i=1;i<=intervallo;i++)
				{
					string val=i.ToString() + "° " + desc;  
					DrPiano.Items.Add(new ListItem(val,i.ToString())); 
				}
			}
			return false;
		}
		private string GetDescri(string val)
		{
			if (val=="1") return "Mese";
			if (val=="2") return "Bimestre";
			if (val=="3") return "Trimestre";
			if (val=="4") return "Quadrimestre";
			if (val=="6") return "Semestre";
			if (val=="12") return "Anno";
			return "";
		}


		private void btnsElimina_Click(object sender, System.EventArgs e)
		{				
			Aggiorna(TheSite.Classi.ExecuteType.Delete);			
		}

		private void BtAdd_Click(object sender, System.EventArgs e)
		{
			for ( int i = ListTipoManutenzione.Items.Count - 1; i >= 0; i-- )
			{
				if ( ListTipoManutenzione.Items[i].Selected )
				{
					ListTipoManutenzioneAdd.Items.Add(ListTipoManutenzione.Items[i]);
					ListTipoManutenzione.Items.RemoveAt(i);
				}
			}
		}

		private void BtRemove_Click(object sender, System.EventArgs e)
		{
			for ( int i = ListTipoManutenzioneAdd.Items.Count - 1; i >= 0; i-- )
			{
				if ( ListTipoManutenzioneAdd.Items[i].Selected )
				{
					ListTipoManutenzione.Items.Add(ListTipoManutenzioneAdd.Items[i]);
					ListTipoManutenzioneAdd.Items.RemoveAt(i);
				}
			}
		}



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
	}
	public enum DateInterval 
	{ 
		Day, 
		DayOfYear, 
		Hour, 
		Minute, 
		Month, 
		Quarter, 
		Second, 
		Weekday, 
		WeekOfYear, 
		Year 
	} 

	public class DateAndTime 
	{ 
		public static long DateDiff(DateInterval interval, DateTime dt1, DateTime dt2) 
		{ 
			return DateDiff(interval, dt1, dt2, System.Globalization.DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek); 
		} 
 
		private static int GetQuarter(int nMonth) 
		{ 
			if (nMonth <= 3) 
				return 1; 
			if (nMonth <= 6) 
				return 2; 
			if (nMonth <= 9) 
				return 3; 
			return 4; 
		} 
 
		public static long DateDiff(DateInterval interval, DateTime dt1, DateTime dt2, DayOfWeek eFirstDayOfWeek) 
		{ 
			if (interval == DateInterval.Year) 
				return dt2.Year - dt1.Year; 
 
			if (interval == DateInterval.Month) 
			{
				//return (dt2.Month - dt1.Month) + (12 * (dt2.Year - dt1.Year)); 
				int monthsApart = 12 * (dt1.Year - dt2.Year) + dt1.Month - dt2.Month;
				return Math.Abs(monthsApart);

			}
			TimeSpan ts = dt2 - dt1; 
             
			if (interval == DateInterval.Day || interval == DateInterval.DayOfYear) 
				return Round(ts.TotalDays); 
             
			if (interval == DateInterval.Hour) 
				return Round(ts.TotalHours); 
 
			if (interval == DateInterval.Minute) 
				return Round(ts.TotalMinutes); 
 
			if (interval == DateInterval.Second) 
				return Round(ts.TotalSeconds); 
 
			if (interval == DateInterval.Weekday ) 
			{ 
				return Round(ts.TotalDays / 7.0); 
			} 
 
			if (interval == DateInterval.WeekOfYear) 
			{ 
				while (dt2.DayOfWeek != eFirstDayOfWeek) 
					dt2 = dt2.AddDays(-1); 
				while (dt1.DayOfWeek != eFirstDayOfWeek) 
					dt1 = dt1.AddDays(-1); 
				ts = dt2 - dt1; 
				return Round(ts.TotalDays / 7.0); 
			} 
 
			if (interval == DateInterval.Quarter) 
			{ 
				double d1Quarter = GetQuarter(dt1.Month); 
				double d2Quarter = GetQuarter(dt2.Month); 
				double d1 = d2Quarter - d1Quarter; 
				double d2 = (4 * (dt2.Year - dt1.Year)); 
				return Round(d1 + d2); 
			} 
 
			return 0; 
 
		} 
 
		private static long Round(double dVal) 
		{ 
			if (dVal >= 0) 
				return (long)Math.Floor(dVal); 
			return (long)Math.Ceiling(dVal); 
		} 
	} 

}
