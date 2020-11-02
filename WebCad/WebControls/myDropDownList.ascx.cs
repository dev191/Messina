namespace WebCad.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descrizione di riepilogo per myDropDownList.
	/// </summary>
	public class MyDropDownList : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.Label Label1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
		}

		public void SetDataSet(string nomeCampoDati, DataSet ds)
		{
			SetDataSet(nomeCampoDati,nomeCampoDati,"",ds);
		}

		public void SetDataSet(string nomeCampoDati, string valoreCampoDati, DataSet ds)
		{
			SetDataSet(nomeCampoDati,valoreCampoDati,"",ds);
		}

		public void SetDataSet(string nomeCampoDati, string valoreCampoDati, string primo, DataSet ds)
		{
			string xml = ds.GetXml();
			DropDownList1.DataTextField=nomeCampoDati;
			DropDownList1.DataValueField=valoreCampoDati;
			DropDownList1.DataSource=ds;
			DropDownList1.DataBind();
			if (primo!="") 
				DropDownList1.Items.Insert(0, new ListItem(primo, ""));
			if (DropDownList1.Items.Count>0)
				DropDownList1.SelectedIndex=0;
		}

		public bool isPopolated()
		{
			if (DropDownList1.Items.Count==0)
				return false;
			return true;
		}

		public void SetLabel(string testo)
		{
			Label1.Text=testo;
		}

		public string getTesto()
		{
			return DropDownList1.SelectedValue;
		}

		public string getClientID()
		{
			return DropDownList1.ClientID;
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

		}
		#endregion
	}
}
