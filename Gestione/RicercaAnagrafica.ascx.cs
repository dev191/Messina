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



using MyCollection; 
//using ApplicationDataLayer;
//using ApplicationDataLayer.DBType;
//using ApplicationDataLayer.Collections;

using System.IO;

namespace TheSite.Gestione
{
	/// <summary>
	///		Descrizione di riepilogo per TemplateAnagrafica.
	/// </summary>

	public class RicercaAnagrafica1 : System.Web.UI.UserControl
	{
		protected S_Controls.S_TextBox txtsDescrizione;
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_TextBox txtsNote;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;
		public static int FunId = 0;
		public static string HelpLink = string.Empty;
		protected S_Controls.S_TextBox txtsCodice;
		public static string pag = string.Empty;
		public static string s_pagdir;
		public static string Codice= string.Empty;
		protected S_Controls.S_Button btnReset;
		MyCollection.clMyCollection _myColl;
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];			
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;	

			this.DataGridRicerca.Columns[1].Visible = true;
			this.DataGridRicerca.Columns[2].Visible = _SiteModule.IsEditable;				
						
			FunId = _SiteModule.ModuleId;
			ViewState["FunId"]=Int32.Parse(FunId.ToString());
			HelpLink = _SiteModule.HelpLink;
		
						

			switch(Pagina)
			{
				case PageType.Servizi:			
					s_pagdir="Servizi";
					this.GridTitle1.hplsNuovo.NavigateUrl = "../Gestione/EditAnagrafica.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId+"&Pagina=Servizi";
					Codice="Codice Servizio";
					break;
				case PageType.TipologiaDitta:		
					s_pagdir="TipologiaDitta";
					this.GridTitle1.hplsNuovo.NavigateUrl = "../Gestione/EditAnagrafica.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId +"&Pagina=TipologiaDitta";
					Codice="Codice Tipologia Ditta";
					break;
				case PageType.TipoManutenzione :			
					s_pagdir="TipoManutenzione";
					this.GridTitle1.hplsNuovo.NavigateUrl = "../Gestione/EditAnagrafica.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId +"&Pagina=TipoManutenzione";
					Codice="Codice Tipo Manutenzione";
					break;				
			}
			pag+= "?ItemID=";	
			
			this.PageTitle1.Title = _SiteModule.ModuleTitle;			
			
			if (!Page.IsPostBack)
			{	
				if (Request.Params["Ricarica"] == "yes")
					Ricerca();
			}
		}

		#region Proprietà
		public PageType Pagina
		{		
			get 
			{
				return (PageType) ViewState["paget"];
			}

			set	
			{	
				ViewState["paget"] = value;
			}
		}
		
		public MyCollection.clMyCollection Coll
		{
			get
			{
			return _myColl;
			}
			set
			{
			_myColl=value;
			}
		
		}
		# endregion
		

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
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			Ricerca();
		}
		public void Ricerca1(S_ControlsCollection _SCollection)
		{
			DataSet _MyDs = new DataSet();
			switch(Pagina)
			{	
				case PageType.Servizi:			
					Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi();
					_MyDs = _Servizi.GetServiziAnagrafica(_SCollection).Copy();					
					break;
				case PageType.TipologiaDitta:			
					Classi.ClassiAnagrafiche.TipologiaDitta  _TipoDitte =  new TheSite.Classi.ClassiAnagrafiche.TipologiaDitta();
					_MyDs = _TipoDitte.GetData(_SCollection).Copy();					
					break;
				case PageType.TipoManutenzione:			
					Classi.ClassiAnagrafiche.TipoManutenzione  _TipoManutenzione = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione();
					_MyDs = _TipoManutenzione.GetData(_SCollection);					
					break;
			}
			
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			if (_MyDs.Tables[0].Rows.Count == 0 )
			{
				DataGridRicerca.CurrentPageIndex=0;
			}
			else
			{
				int Pag = 0;
				if ((_MyDs.Tables[0].Rows.Count % DataGridRicerca.PageSize) >0)
				{
					Pag ++;
				}
				if (DataGridRicerca.PageCount != Convert.ToInt16((_MyDs.Tables[0].Rows.Count / DataGridRicerca.PageSize) + Pag))
				{					
					DataGridRicerca.CurrentPageIndex=0;					
				}
			}

			this.DataGridRicerca.DataBind();					
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
		
         }
		public void Ricerca()
		{			
			this.txtsDescrizione.DBDefaultValue = "%";			
			this.txtsNote.DBDefaultValue = "%";	
			this.txtsCodice.DBDefaultValue = "%";
					
			this.txtsDescrizione.Text=this.txtsDescrizione.Text.Trim();
			this.txtsNote.Text=this.txtsNote.Text.Trim();
			this.txtsCodice.Text=this.txtsCodice.Text.Trim();

			S_ControlsCollection _SCollection = new S_ControlsCollection();
			_SCollection.AddItems(this.PanelRicerca.Controls);
						
			DataSet _MyDs = new DataSet();
			switch(Pagina)
			{	
				case PageType.Servizi:			
					Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi();
					_MyDs = _Servizi.GetServiziAnagrafica(_SCollection).Copy();
					break;
				case PageType.TipologiaDitta:			
					Classi.ClassiAnagrafiche.TipologiaDitta  _TipoDitte =  new TheSite.Classi.ClassiAnagrafiche.TipologiaDitta();
					_MyDs = _TipoDitte.GetData(_SCollection).Copy();
					break;
				case PageType.TipoManutenzione:			
					Classi.ClassiAnagrafiche.TipoManutenzione  _TipoManutenzione = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione();
					_MyDs = _TipoManutenzione.GetData(_SCollection);
					break;
			}
			
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			if (_MyDs.Tables[0].Rows.Count == 0 )
			{
				DataGridRicerca.CurrentPageIndex=0;
			}
			else
			{
				int Pag = 0;
				if ((_MyDs.Tables[0].Rows.Count % DataGridRicerca.PageSize) >0)
				{
					Pag ++;
				}
				if (DataGridRicerca.PageCount != Convert.ToInt16((_MyDs.Tables[0].Rows.Count / DataGridRicerca.PageSize) + Pag))
				{					
					DataGridRicerca.CurrentPageIndex=0;					
				}
			}

			this.DataGridRicerca.DataBind();					
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			if(e.Item.ItemType == ListItemType.Header)
			{
				switch(Pagina)
				{
					case PageType.Servizi:												
						e.Item.Cells[4].Text="Codice Servizio";
						break;
					case PageType.TipologiaDitta:							
						e.Item.Cells[4].Text="Codice Tipologia Ditta";
						break;
					case PageType.TipoManutenzione:								
						e.Item.Cells[4].Text="Codice Tipo Manutenzione";
						break;
				}
			}

			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{					
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton1");
				_img1.Attributes.Add("title","Visualizza");

				ImageButton _img2 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton2");
				_img2.Attributes.Add("title","Modifica");

				string descrizione="";
				string note="";
				//Tronco la descrizione per i primi 50 caratteri e valorizzo il valore nel TOOLTIP
				if (e.Item.Cells[3].Text.Trim().Length > 50) 
				{
					descrizione=e.Item.Cells[3].Text.Trim().Substring(0,49) + "...";        									
					e.Item.Cells[3].ToolTip=e.Item.Cells[3].Text;
					e.Item.Cells[3].Text=descrizione;
				}				
				//Tronco le note per i primi 60 caratteri e valorizzo il valore nel TOOLTIP
				if (e.Item.Cells[4].Text.Trim().Length > 68) 
				{
					note=e.Item.Cells[4].Text.Trim().Substring(0,68) + "...";        									
					e.Item.Cells[4].ToolTip=e.Item.Cells[4].Text;
					e.Item.Cells[4].Text=note;
				}				
			}
		}

		public void imageButton_Click(Object sender , CommandEventArgs e)
		{	Context.Items.Add("ItemId",e.CommandArgument);
			Context.Items.Add("FunId=", ViewState["FunId"].ToString());
			string s_oper="read";
			Context.Items.Add("TipoOper",s_oper);
			Context.Items.Add("Pagina",s_pagdir);
			_myColl.AddControl(this.Page.Controls, ParentType.Page);	

			Server.Transfer("EditAnagrafica.aspx");
		}
		public void imageButton_Click1(Object sender , CommandEventArgs e)
		{
			Context.Items.Add("ItemId",e.CommandArgument);
			Context.Items.Add("FunId=", ViewState["FunId"].ToString());
			string s_oper="write";
			Context.Items.Add("TipoOper",s_oper);
			Context.Items.Add("Pagina",s_pagdir);
			_myColl.AddControl(this.Page.Controls, ParentType.Page);	

			Server.Transfer("EditAnagrafica.aspx");
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			switch(Pagina)
			{ 
				case PageType.Servizi:  
					Response.Redirect("servizi.aspx?FunId=" + ViewState["FunId"]);
					break;
				case PageType.TipologiaDitta: 
					Response.Redirect("TipologiaDitta.aspx?FunId=" + ViewState["FunId"]);
					break;
				case PageType.TipoManutenzione: 
					Response.Redirect("TipoManutenzione.aspx?FunId=" + ViewState["FunId"]);
					break;
			}
		}


		

		

		

		
	}
}
