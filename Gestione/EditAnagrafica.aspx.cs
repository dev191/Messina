namespace TheSite.Gestione
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
	using System.Reflection;

	/// <summary>
	/// Descrizione di riepilogo per EditAnagrafica
	/// </summary>
	public enum PageType
	{
		Servizi,
		Ditte,
		TipologiaDitta,
		TipoManutenzione
	}
	public class EditAnagrafica : System.Web.UI.Page
	{
		protected Csy.WebControls.MessagePanel PanelMess;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected S_Controls.S_TextBox txtsNote;
		protected S_Controls.S_TextBox txtsCodice;
		protected S_Controls.S_TextBox txtsDescrizione;
		int itemId = 0;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDescrizione;
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected System.Web.UI.WebControls.Label lblOperazione;
		int FunId = 0;
		protected System.Web.UI.WebControls.RequiredFieldValidator RvfCodice;
		protected string s_Pagina;
		string strNomePagina;
		public static string Codice= string.Empty;
		

		#region proprieta collection
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
		#endregion
	
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			FunId = Int32.Parse(Request["FunId"]);			
//
//			if (Request["ItemId"] != null) 
//			{
//				itemId = Int32.Parse(Request.Params["ItemId"]);				
//			}
			if (Request["Pagina"] != null) 
			{
				s_Pagina = Request["Pagina"];				
			}
			
			if (!Page.IsPostBack )
			{	
				#region Recupero la proprieta di ricerca
				// Recupero il tipo dall'oggetto context.
				Type myType=Context.Handler.GetType();       
				// recupero il PropertyInfo object passando il nome della proprietà da recuperare.
				PropertyInfo myPropInfo = myType.GetProperty("_Contenitore");
				// verifico che questa proprietà esista.
				if(myPropInfo!=null)
					this.ViewState.Add("mioContenitore",myPropInfo.GetValue(Context.Handler,null));
				#endregion
				
//				Context.Items.Add("FunId=", FunId);
//				string s_oper="read";
//				Context.Items.Add("TipoOper",s_oper);
//				Context.Items.Add("Pagina",s_pagdir);


				 if (Context.Items["FunId"]!=null)
					//FunId=Int32.Parse(Context.Items["FunId"]);
					FunId= Int32.Parse(Context.Items["FunId"].ToString());
				if (Context.Items["ItemId"]!=null)
					//itemId = Int32.Parse(Context.Items["ItemId"]);
				{itemId = Int32.Parse(Context.Items["ItemId"].ToString());
				ViewState["ItemId"]=Int32.Parse(Context.Items["ItemId"].ToString());}
				else 
				{
				ViewState["ItemId"]=0;
				}
					
				if (Context.Items["Pagina"]!=null)
					s_Pagina =(string) Context.Items["Pagina"];
					ViewState["s_Pagina"]=s_Pagina;
					

				switch(s_Pagina)
				{					
					case "Servizi":			
						strNomePagina = "Servizio";
						Codice="Codice Servizio";
						break;
					case "TipologiaDitta":			
						strNomePagina = "Tipologia Ditta";
						Codice="Codice Tipologia Ditta";
						break;
					case "TipoManutenzione" :			
						strNomePagina = "Tipo Manutenzione";
						Codice="Codice Tipo Manutenzione";
						break;									
				}

				if (itemId != 0) 
				{
					DataSet _MyDs = new DataSet();
					switch(s_Pagina)
					{					
						
						case "Servizi":			
							Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi();	
							_MyDs = _Servizi.GetSingleData(itemId).Copy();																
							break;
						case "TipologiaDitta":			
							Classi.ClassiAnagrafiche.TipologiaDitta  _TipoDitte =  new TheSite.Classi.ClassiAnagrafiche.TipologiaDitta();
							_MyDs = _TipoDitte.GetSingleData(itemId).Copy();									
							break;
						case "TipoManutenzione" :			
							Classi.ClassiAnagrafiche.TipoManutenzione  _TipoManutenzione = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione();
							_MyDs = _TipoManutenzione.GetSingleData(itemId);
							break;									
					}
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						this.txtsDescrizione.Text= (string) _Dr["DESCRIZIONE"];
						if (_Dr["NOTE"] != DBNull.Value)
							this.txtsNote.Text = (string) _Dr["NOTE"];
						if (_Dr["CODICE"] != DBNull.Value)
							this.txtsCodice.Text = (string) _Dr["CODICE"];
												
						this.lblOperazione.Text = "Modifica " + strNomePagina;

						this.lblFirstAndLast.Visible = true;						
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");				
						
						switch(s_Pagina)
						{
							case "Servizi":			
								Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi();	
								lblFirstAndLast.Text=_Servizi.GetFirstAndLastUser(_Dr);
								break;
							case "TipologiaDitta":			
								Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
								lblFirstAndLast.Text=_Ditte.GetFirstAndLastUser(_Dr);
								break;
							case "TipoManutenzione" :			
								Classi.ClassiAnagrafiche.TipoManutenzione  _TipoManutenzione = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione();
								lblFirstAndLast.Text = _TipoManutenzione.GetFirstAndLastUser(_Dr);
								break;	
						}

					}
				}
				else
				{
					this.lblOperazione.Text = "Inserimento " + strNomePagina;

					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;					
				}				
				if ((string) Context.Items["TipoOper"] == "read")				
					AbilitaControlli(false);
				//ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
			}

		}	
		private void AbilitaControlli(bool enabled)
		{
			this.txtsNote.Enabled = enabled;
			this.txtsDescrizione.Enabled = enabled;
			this.txtsCodice.Enabled =enabled;
			this.btnsElimina.Enabled=enabled;
			this.btnsSalva.Enabled=enabled;

			this.lblOperazione.Text = "Visualizzazione " + strNomePagina;
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

		private void btnsSalva_Click(object sender, System.EventArgs e)
		{		
			
			this.txtsNote.DBDefaultValue = DBNull.Value;
			this.txtsDescrizione.DBDefaultValue = DBNull.Value;
			this.txtsCodice.DBDefaultValue = DBNull.Value;
			
			
			this.txtsNote.Text=this.txtsNote.Text.Trim();
			this.txtsDescrizione.Text=this.txtsDescrizione.Text.Trim();
			this.txtsCodice.Text = this.txtsCodice.Text.Trim();
			
			
			int i_RowsAffected = 0;

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			_SCollection.AddItems(this.PanelEdit.Controls);

			try
			{		int itemId1= Int32.Parse(ViewState["ItemId"].ToString());
					string s_Pagina1 = (string) ViewState["s_Pagina"];
				if ( itemId1== 0)
				{
			
					switch (s_Pagina)
					{
						case "Servizi":			
							Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi();	
							i_RowsAffected = _Servizi.Add(_SCollection);
							break;
						case "TipologiaDitta":			
							Classi.ClassiAnagrafiche.TipologiaDitta  _TipoDitte =  new TheSite.Classi.ClassiAnagrafiche.TipologiaDitta();
							i_RowsAffected = _TipoDitte.Add(_SCollection);
							break;
						case "TipoManutenzione" :			
							Classi.ClassiAnagrafiche.TipoManutenzione  _TipoManutenzione = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione();
							i_RowsAffected = _TipoManutenzione.Add(_SCollection);
							break;	
					}
				}
				else
				{	
					switch(s_Pagina1)
					{
						case "Servizi":			
							Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi();	
							i_RowsAffected = _Servizi.Update(_SCollection, itemId1);			
							break;
						case "TipologiaDitta":			
							Classi.ClassiAnagrafiche.TipologiaDitta  _TipoDitte =  new TheSite.Classi.ClassiAnagrafiche.TipologiaDitta();
							i_RowsAffected = _TipoDitte.Update(_SCollection,itemId1);
							break;
						case "TipoManutenzione" :			
							Classi.ClassiAnagrafiche.TipoManutenzione  _TipoManutenzione = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione();
							i_RowsAffected = _TipoManutenzione.Update(_SCollection,itemId1);
							break;	
					}	
				
				}

				if ( i_RowsAffected > 0 && i_RowsAffected!=-11)
				{
					Server.Transfer(ViewState["s_Pagina"].ToString()+".aspx");					
				}
				else
				{
					Classi.SiteJavaScript.msgBox(this.Page,"La Descrizione é stata già inserita");
							
				
				}
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}			
		}

		private void btnsElimina_Click(object sender, System.EventArgs e)
		{
			try
			{	
				this.txtsNote.DBDefaultValue = DBNull.Value;
				this.txtsDescrizione.DBDefaultValue = DBNull.Value;
				this.txtsCodice.DBDefaultValue =DBNull.Value;
				
				int itemId1= Int32.Parse(ViewState["ItemId"].ToString());
				string s_Pagina1 = (string) ViewState["s_Pagina"];
				
				int i_RowsAffected = 0;

				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

				_SCollection.AddItems(this.PanelEdit.Controls);			

				switch(s_Pagina1)
				{
					case"Servizi":			
						Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi();	
						i_RowsAffected = _Servizi.Delete(_SCollection, itemId1);
						break;
					case "TipologiaDitta":			
						Classi.ClassiAnagrafiche.TipologiaDitta  _TipoDitta =  new TheSite.Classi.ClassiAnagrafiche.TipologiaDitta();
						i_RowsAffected = _TipoDitta.Delete(_SCollection, itemId1);
						break;
					case "TipoManutenzione" :	
						Classi.ClassiAnagrafiche.TipoManutenzione  _TipoManutenzione = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione();
						i_RowsAffected = _TipoManutenzione.Delete(_SCollection,itemId1);
						break;	
				}
				if ( i_RowsAffected == -1 )
					Server.Transfer(ViewState["s_Pagina"].ToString()+".aspx");			
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}
		}

		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			Server.Transfer(ViewState["s_Pagina"].ToString()+".aspx");					
		}
		}
	

	}

