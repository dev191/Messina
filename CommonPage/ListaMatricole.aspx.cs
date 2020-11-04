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
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType; 

namespace TheSite.CommonPage
{
	/// <summary>
	/// Descrizione di riepilogo per ListaMatricole.
	/// </summary>
	public class ListaMatricole : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	    protected WebControls.GridTitle GridTitle1; 

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{
				if(Request.QueryString["idric"]!=null)
					this.idric =	Request.QueryString["idric"]; 
				else
					this.idric =string.Empty; 
				///Eseguo il Binding sulla Griglia
				///
				if(Request.QueryString["idmodulo"]!=null)
					this.idmodulo =	Request.QueryString["idmodulo"]; 
				else
					this.idmodulo =string.Empty;

				Execute();
			}
			String scriptString = "<script language=JavaScript> var idmodulo='" + this.idmodulo +"'";
			scriptString += "<";
			scriptString += "/";
			scriptString += "script>";

			if(!this.IsClientScriptBlockRegistered("clientScriptmatricola"))
				this.RegisterClientScriptBlock("clientScriptmatricola", scriptString);

			GridTitle1.hplsNuovo.Visible=false;

		}

		private string idmodulo
		{
			get {return (String) ViewState["s_idmodulo"];}
			set {ViewState["s_idmodulo"] = value;}
		}

		private string idric
		{
			get {return (String) ViewState["s_Idric"];}
			set {ViewState["s_Idric"] = value;}
		}

		private void Execute()
		{

			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			Classi.AnagrafeImpianti.Certificati   _Certificati = new Classi.AnagrafeImpianti.Certificati(Context.User.Identity.Name);		
			
			S_Controls.Collections.S_Object s_P_matricola = new S_Controls.Collections.S_Object();
			s_P_matricola.ParameterName = "P_matricola";
			s_P_matricola.DbType = CustomDBType.VarChar;
			s_P_matricola.Direction = ParameterDirection.Input;
			s_P_matricola.Index = 0;
			s_P_matricola.Size=250;
			s_P_matricola.Value = this.idric;			
			CollezioneControlli.Add(s_P_matricola);

			DataSet Ds = _Certificati.GetDataMatricolole(CollezioneControlli);

			DataGrid1.DataSource= Ds;
			GridTitle1.NumeroRecords=(Ds.Tables[0].Rows.Count)==0? "0":Ds.Tables[0].Rows.Count.ToString();
			DataGrid1.DataBind();
		}
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			DataGrid1.CurrentPageIndex=e.NewPageIndex;
			Execute();
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);

		}
		#endregion
	}
}
