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

namespace TheSite.ManutenzioneCorretiva
{
	/// <summary>
	/// Descrizione di riepilogo per RapportoTecnicoIntervento.
	/// </summary>
	public class RapportoTecnicoIntervento : System.Web.UI.Page
	{
		protected S_Controls.S_Label S_lblbuonolavoro;
		protected System.Web.UI.WebControls.Repeater repeater1;
		protected S_Controls.S_Label S_Lblditta;
		protected WebControls.PageTitle PageTitle1; 
		protected System.Web.UI.HtmlControls.HtmlTableRow TRAnnotazioniVal;
		protected System.Web.UI.HtmlControls.HtmlTableRow TRAnnotazioniNoVal;
		public string WO_Id=string.Empty;
		public string image="../Images/3.jpg";
		public string descprog="";
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			PageTitle1.VisibleLogut =false;
			if(!IsPostBack)
			{
				if(Request.QueryString["WO_Id"]!=null)
				{
					this.WO_Id =(string)Request.QueryString["WO_Id"];					
					Execute();
				}
			}
		}
		/// <summary>
		/// Eseguo la store procedure e recupero i campi
		/// Eseguo il Binding sul Repeater
		/// </summary>
		private void Execute()
		{
		  
			Classi.ManOrdinaria.RichiestaIntervento  _RichiestaIntervento= new Classi.ManOrdinaria.RichiestaIntervento(Context.User.Identity.Name);
			DataSet Ds=_RichiestaIntervento.GetSingleData(int.Parse(this.WO_Id));
			if(Ds.Tables[0].Rows[0]["id_progetto"].ToString()=="1")
			{
				image="../Images/Martino_logo.gif";
				descprog="Martino";
			}
			else
			{
				image="../Images/papardo_logo.gif";
				descprog="Papardo";
			}
			repeater1.DataSource= Ds;
			repeater1.DataBind(); 
		//	S_lblbuonolavoro.Text=this.WO_Id;
			
		}
		public string evaluta;
		public string EvalBool(Object obj, bool val)
		{
			if ((obj == null) || (obj == DBNull.Value) || (obj.ToString() == ""))
			{
				return (val==true)?"visibility: hidden":"visibility: none";
			}

				return (val==false)?"visibility: hidden":"visibility: none";
		}
		/// <summary>
		/// Verifica del campo se è presente un valore nel campo
		/// altrimenti in base al numero passato  viene generato un numero di caratteri
		/// </summary>
		/// <param name="obj"> E' il Campo da verificare</param>
		/// <param name="Line">il Numero di caratteri di linea da generare</param>
		/// <returns></returns>
		public string EvalField(Object obj,Int32 Line)
		{
			if ((obj == null) || (obj == DBNull.Value))
			{
				string s=string.Empty;
				return s.PadLeft(Line,Convert.ToChar("_")) ;
			}
			else
			{
				return obj.ToString(); 
			}

		}
		
		public string Chk(string Sodd, string val)
		{
			string chk="";
			if (Sodd==val)
				chk="checked ";

			return chk;
		}
		public string GetStringData(Object Data,string Tipo)
		{
			
			string StrReturn="";		
					
			
			if(Tipo=="Data")
			{
				//DATA
				if (Data.ToString() != "")
				{
					StrReturn = System.DateTime.Parse(Data.ToString()).ToShortDateString();				
				}
			}
			else
			{			
				//ORA
				if (Data.ToString() != "")
				{
					StrReturn = System.DateTime.Parse(Data.ToString()).ToShortTimeString();				
				}
			}
			return StrReturn;
		
		}
        /// <summary>
        /// Formatta la data
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
		public string FormateDate(Object obj)
		{
			if ((obj == null) || (obj == DBNull.Value) || (obj.ToString() == ""))
			{
				return "_____/_____/_____";
			}
			else
			{
			 return  System.DateTime.Parse(obj.ToString()).ToShortDateString();  
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
			this.repeater1.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.repeater1_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void repeater1_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
		
		}
	}
}
