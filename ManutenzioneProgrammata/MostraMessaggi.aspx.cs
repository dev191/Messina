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
using System.Data.OracleClient;

namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Summary description for MostraMessaggi.
	/// </summary>
	public class MostraMessaggi : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblErroreINIT;
		protected System.Web.UI.WebControls.Label lblAnno;
		protected System.Web.UI.WebControls.Label lblMEse;
		protected System.Web.UI.WebControls.Label lblEdificio;
		protected System.Web.UI.WebControls.Label lblServizio;
		protected System.Web.UI.WebControls.Label lblClasseelemento;
		protected System.Web.UI.WebControls.Label lblFINEerr;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
				GeneraMessaggio();
		}
		private void GeneraMessaggio()
		{
			
			Hashtable _HS = new Hashtable();
			_HS = (Hashtable) Session["DataERRmp"];
			lblAnno.Text = "Anno: " + _HS["Anno"].ToString();
			lblMEse.Text = "Mese: " + _HS["MeseEsteso"].ToString();
			lblEdificio.Text = "Edificio: " + _HS["Eedificio"].ToString();
			lblServizio.Text = "Categoria Tenologica: " +  _HS["Servizio"].ToString();
			lblClasseelemento.Text = "Classe Elemento: " + _HS["ClasseElemento"].ToString();
			_HS.Clear();
			if(Session["DataERRmp"] != null)
			{
				Session.Remove("DataERRmp");
			}
		}

		private string recuperaEqId()
		{
			string strEqId=String.Empty;
			if(Session["DatiList"]!=null)
			{
				Hashtable _HS = (Hashtable)Session["DatiList"];
				IDictionaryEnumerator myEnumerator = _HS.GetEnumerator();								
				while (myEnumerator.MoveNext())	
				{
					strEqId += myEnumerator.Value + ",";
				}
					
				strEqId = strEqId.Remove(strEqId.Length-1,1);
				//Session.Remove("DatiList");
			}
			else
			{
				Response.Write("Sessione Vuota");
				Response.End();
			}
			return strEqId;
		}
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
