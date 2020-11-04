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
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using TheSite.AnagrafeImpianti; 
using System.Reflection;

namespace TheSite.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per SelezioneCertificati.
	/// </summary>
	public class NavigazioneCertificati : System.Web.UI.Page
	{
		protected Csy.WebControls.DataPanel DataPanel1;
		protected S_Controls.S_Button S_btReset;
		protected S_Controls.S_Button S_btRicerca;
		protected S_Controls.S_ComboBox S_CbAnno;
		protected S_Controls.S_ComboBox S_CbTipo;
	    protected WebControls.PageTitle PageTitle1;
		protected WebControls.RicercaModulo  RicercaModulo1;
		protected WebControls.GridTitle GridTitle1;  
 
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected S_Controls.S_TextBox S_Txtnomefile;
		protected S_Controls.S_TextBox S_Txtdescrizione;

		protected System.Web.UI.HtmlControls.HtmlTable tablevvf;
		protected System.Web.UI.HtmlControls.HtmlTable tableispesel;
	    protected WebControls.Matricole Matricole1;
		protected WebControls.Fascicolo Fascicolo1; 
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;

		public static int FunId = 0;
		protected System.Web.UI.WebControls.CheckBox chscollaudo;
		protected S_Controls.Collections.S_Object S_Checkcollaudo = new S_Controls.Collections.S_Object();


		public static string HelpLink = string.Empty;

		private void Page_Load(object sender, System.EventArgs e)
		{


			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
	    
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if (!IsPostBack)
			{   
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];

				BindingComboAnno();
				setvisible(false);
				GridTitle1.Visible=false;
			}
			
			//Creazione dei primi Parametri
			RicercaModulo1.TxtCodice.DBParameterName="P_bl_id";
			RicercaModulo1.TxtCodice.DBIndex =0;
			RicercaModulo1.TxtCodice.DBDataType=CustomDBType.VarChar;
			RicercaModulo1.TxtCodice.DBDirection= ParameterDirection.Input;
			RicercaModulo1.TxtCodice.DBSize=8;
			RicercaModulo1.TxtCodice.DBDefaultValue=""; 

			RicercaModulo1.TxtRicerca.DBParameterName="P_campus";
			RicercaModulo1.TxtRicerca.DBIndex =1;
			RicercaModulo1.TxtRicerca.DBDirection= ParameterDirection.Input;
			RicercaModulo1.TxtRicerca.DBDataType=CustomDBType.VarChar; 
			RicercaModulo1.TxtRicerca.DBSize=128; 
			RicercaModulo1.TxtRicerca.DBDefaultValue=""; 
            
			
			Matricole1.Matricola.DBParameterName="P_matricola";
			Matricole1.Matricola.DBIndex =5;
			Matricole1.Matricola.DBDirection= ParameterDirection.Input;
			Matricole1.Matricola.DBDataType=CustomDBType.VarChar; 
			Matricole1.Matricola.DBSize=20; 
			Matricole1.Matricola.DBDefaultValue=""; 

			CalendarPicker1.Datazione.DBParameterName="P_datav";
			CalendarPicker1.Datazione.DBIndex =6;
			CalendarPicker1.Datazione.DBDirection= ParameterDirection.Input;
			CalendarPicker1.Datazione.DBDataType=CustomDBType.VarChar; 
			CalendarPicker1.Datazione.DBSize=20; 
			CalendarPicker1.Datazione.DBDefaultValue=""; 

			CalendarPicker2.Datazione.DBParameterName="P_dataf";
			CalendarPicker2.Datazione.DBIndex =9;
			CalendarPicker2.Datazione.DBDirection= ParameterDirection.Input;
			CalendarPicker2.Datazione.DBDataType=CustomDBType.VarChar; 
			CalendarPicker2.Datazione.DBSize=20; 
			CalendarPicker2.Datazione.DBDefaultValue="";

			//S_Controls.Collections.S_Object S_Checkcollaudo = new S_Controls.Collections.S_Object();
			S_Checkcollaudo.ParameterName = "P_check";
			S_Checkcollaudo.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			S_Checkcollaudo.Direction = ParameterDirection.Input;
			S_Checkcollaudo.Size=10; 
			S_Checkcollaudo.Index = 10;
			S_Checkcollaudo.Value =DBNull.Value;
			
			Fascicolo1.TxtFascicolo.DBParameterName="P_fascicolo";
			Fascicolo1.TxtFascicolo.DBIndex =8;
			Fascicolo1.TxtFascicolo.DBDirection= ParameterDirection.Input;
			Fascicolo1.TxtFascicolo.DBDataType=CustomDBType.VarChar; 
			Fascicolo1.TxtFascicolo.DBSize=20; 
			Fascicolo1.TxtFascicolo.DBDefaultValue=""; 

			GridTitle1.hplsNuovo.Visible=false; 

			S_CbTipo.Attributes.Add("OnChange","expandcollapse(this);");
            
			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();

			sbValid.Append("if (typeof(selezionedata) == 'function') { ");

			sbValid.Append("if (selezionedata('" + S_CbAnno.ClientID  + "') == false) { return false; }} ");
			sbValid.Append("this.value = 'Attendere ...';");

			sbValid.Append("this.disabled = true;");

			sbValid.Append("document.getElementById('" + S_btRicerca.ClientID + "').disabled = true;");

			sbValid.Append(this.Page.GetPostBackEventReference(this.S_btRicerca));
			sbValid.Append(";");
			this.S_btRicerca.Attributes.Add("onclick", sbValid.ToString());

		 
		}

		private void BindingComboAnno()
		{
			DateTime d1 = DateTime.Now;
			 S_CbAnno.Items.Add(new ListItem("",""));
			for (int i = 1970; i <= (d1.Year +15) ; i++)
               S_CbAnno.Items.Add(new ListItem(i.ToString(),i.ToString()));    
		   
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
			this.S_btRicerca.Click += new System.EventHandler(this.S_btRicerca_Click);
			this.S_btReset.Click += new System.EventHandler(this.S_btReset_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void S_btRicerca_Click(object sender, System.EventArgs e)
		{
          Execute(true);   
		}

		private void Execute(bool reset )
		{
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			Classi.AnagrafeImpianti.Certificati   _Certificati = new Classi.AnagrafeImpianti.Certificati(Context.User.Identity.Name);
		
			SetDefaultValueControl(DataPanel1);
			
			
			if (S_CbTipo.SelectedValue!="6")
			{
				Matricole1.Matricola.Text="";
				CalendarPicker1.Datazione.Text="";
				S_CbAnno.SelectedIndex=0;
			}
			if (S_CbTipo.SelectedValue!="8")
			{
				Fascicolo1.TxtFascicolo.Text="";  
				CalendarPicker2.Datazione.Text="";
				//S_Checkcollaudo.Checked=false;
				 
			}
			//if (S_CbTipo.SelectedValue=="8")//VVF
				
				

			if (S_CbTipo.SelectedValue=="6")//ISPELS
			{
				tablevvf.Style.Add("display","none");
				tablevvf.Style.Add("visibility","hidden");
				tableispesel.Style.Add("display","block");
				tableispesel.Style.Add("visibility","visible");

				DataGrid1.Columns[5].Visible =true;
				DataGrid1.Columns[6].Visible =false;
				DataGrid1.Columns[7].Visible =false;
				DataGrid1.Columns[8].Visible =false;
				DataGrid1.Columns[9].Visible =true;
				DataGrid1.Columns[10].Visible =true;
				DataGrid1.Columns[11].Visible =true;
			}
			if (S_CbTipo.SelectedValue=="8")//VVF
			{
				
				
				if (chscollaudo.Visible==false)
				{S_Checkcollaudo.Value=DBNull.Value;}
				else
				{
					if (chscollaudo.Checked==true)
					{
					S_Checkcollaudo.Value =1;
					}
					else
					{
					S_Checkcollaudo.Value =0;
					}
				
				}
				
				tableispesel.Style.Add("display","none");
				tableispesel.Style.Add("visibility","hidden");
				tablevvf.Style.Add("display","block");
				tablevvf.Style.Add("visibility","visible");

				DataGrid1.Columns[5].Visible =true;
				DataGrid1.Columns[6].Visible =true;
				DataGrid1.Columns[7].Visible =true;
				DataGrid1.Columns[8].Visible =true;
				DataGrid1.Columns[9].Visible =false;
				DataGrid1.Columns[10].Visible =false;
				DataGrid1.Columns[11].Visible =false;
				
			}
			if (S_CbTipo.SelectedValue!="8" && S_CbTipo.SelectedValue!="6")//L46/90
			{
				tablevvf.Style.Add("display","none");
				tablevvf.Style.Add("visibility","hidden");
				tableispesel.Style.Add("display","none");
				tableispesel.Style.Add("visibility","hidden");

				DataGrid1.Columns[5].Visible =true;
				DataGrid1.Columns[6].Visible =false;
				DataGrid1.Columns[7].Visible =false;
				DataGrid1.Columns[8].Visible =false;
				DataGrid1.Columns[9].Visible =false;
				DataGrid1.Columns[10].Visible =false;
				DataGrid1.Columns[11].Visible =false;
			}
  
			CollezioneControlli.AddItems(DataPanel1.Controls);
			CollezioneControlli.Add(S_Checkcollaudo);



				   // nuovi parametri paginazione

					S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
					s_p_pageindex.ParameterName = "pageindex";
					s_p_pageindex.DbType = CustomDBType.Integer;
					s_p_pageindex.Direction = ParameterDirection.Input;
					s_p_pageindex.Index = 16;
					s_p_pageindex.Value=DataGrid1.CurrentPageIndex +1;	
		
					CollezioneControlli.Add(s_p_pageindex);

					S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
					s_p_pagesize.ParameterName = "pagesize";
					s_p_pagesize.DbType = CustomDBType.Integer;
					s_p_pagesize.Direction = ParameterDirection.Input;
					s_p_pagesize.Index = 17;
					s_p_pagesize.Value= DataGrid1.PageSize;	
		
					CollezioneControlli.Add(s_p_pagesize);

					DataSet _MyDs = _Certificati.GetData(CollezioneControlli);

			if (reset){
				// elimino i due parametri per la paginazione
				CollezioneControlli.RemoveAt(CollezioneControlli.Count  -3) ;
				CollezioneControlli.RemoveAt(CollezioneControlli.Count  -3) ;

				int _totalRecords = _Certificati.GetDataCount(CollezioneControlli);
				this.GridTitle1.NumeroRecords=_totalRecords.ToString();
			}

			this.DataGrid1.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);

			DataGrid1.DataSource =_MyDs.Tables[0] ;
			DataGrid1.DataBind();

		
				
			if (int.Parse (this.GridTitle1.NumeroRecords) >0)
			{

				setvisible(true);
				GridTitle1.Visible=true;
				GridTitle1.DescriptionTitle="";
			}
			else
			{	
				GridTitle1.Visible=true;
				GridTitle1.DescriptionTitle="Nessun dato trovato.";
				setvisible(false);
			}
		
			chscollaudo.Visible=true;
		}
		private void SetDefaultValueControl(Control Ctrls)
		{
			foreach (Control Ctrl in Ctrls.Controls)
			{
				if (Ctrl.Controls.Count >0) SetDefaultValueControl(Ctrl);
				if((Ctrl is S_Controls.S_CheckBox) || (Ctrl is S_Controls.S_ComboBox) 
					|| (Ctrl is S_Controls.S_HyperLink) || (Ctrl is S_Controls.S_Label) || (Ctrl is S_Controls.S_ListBox) 
					|| (Ctrl is S_Controls.S_OptionButton) || (Ctrl is S_Controls.S_TextBox)) 
				{
					Type MyType = Ctrl.GetType();
					PropertyInfo Mypropertyinfo = MyType.GetProperty("DBDefaultValue");
					Mypropertyinfo.SetValue(Ctrl, "", null);
					Console.WriteLine(MyType.Name);  
				}
			}
		}

		private void setvisible(bool visible)
		{
			GridTitle1.VisibleRecord=visible;
			GridTitle1.hplsNuovo.Visible =false;
			DataGrid1.Visible =visible;
			//modifica
			chscollaudo.Visible=false;
		}
		private void S_btReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("NavigazioneCertificati.aspx?FunId=" + ViewState["FunId"]);
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			DataGrid1.CurrentPageIndex=e.NewPageIndex;
			Execute(false);
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
			{
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton1");
				_img1.Attributes.Add("title","Visualizza Certificato");	

				if (e.Item.Cells[8].Text=="0" || e.Item.Cells[8].Text=="")//Collaudo
					e.Item.Cells[8].Text ="No";
				else
				    e.Item.Cells[8].Text="Si";
			}
		}

//		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			Context.Items.Add("var_afm_dwgs_dwg_name",DataGrid1.SelectedItem.Cells[2].Text);
//			Server.Transfer("VisualDWF.aspx"); 
//		}
		public void imageButton_Click(Object sender , CommandEventArgs e)
		{
			Context.Items.Add("var_afm_dwgs_dwg_name",(string)e.CommandArgument);
			Server.Transfer("VisualDWF.aspx");
		}


	
	}
}