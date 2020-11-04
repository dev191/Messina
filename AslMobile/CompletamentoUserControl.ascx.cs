namespace TheSite.AslMobile
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.Mobile;
	using System.Web.UI.MobileControls;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;
	using System.Web.UI;
	using System.Data.OracleClient;

	//using System.ComponentModel;
	//using System.Web.SessionState;

	public delegate void MyDelegate(Hashtable HS,int operazione);



	/// <summary>
	///		Descrizione di riepilogo per CompletamentoUserControl.
	/// </summary>
	public abstract class CompletamentoUserControl : System.Web.UI.MobileControls.MobileUserControl
	{
		protected System.Web.UI.MobileControls.Panel Panel1;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific1;

		public Hashtable _HS
		{
			get
			{
				if(ViewState["_HS"]!=null)
					return (Hashtable)ViewState["_HS"];
				else
					return null;
			}
			set
			{
				ViewState.Add("_HS",value);
			}
		}

		public string txtEdificio;
		public string txtDitta;
		protected System.Web.UI.MobileControls.Panel Panel2;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific2;
		public string txtNomeCompleto;

		public		DataGrid	 p_GridRisultati;


		public MyDelegate myDelegate;

		public DropDownList pcmbsAddetti1;
		public DropDownList pcmbsAddetti0;
		public string date;
		private void Page_Load(object sender, System.EventArgs e)
		{
			System.Web.UI.MobileControls.RegularExpressionValidator RqOrdine=(System.Web.UI.MobileControls.RegularExpressionValidator)Panel1.Controls[0].FindControl("RegularExpressionValidator1");
			RqOrdine.Visible=true;
			System.Web.UI.MobileControls.Calendar cal = (System.Web.UI.MobileControls.Calendar)Panel2.Controls[0].FindControl("Calendar1");
			cal.SelectedDates.Clear();
		}


		public void load()
		{

			string NomeCompleto = "";// this.txtNomeCompleto;
			string codDitta = this.txtDitta;
			string cod = this.txtEdificio;
			string codEdificio=(cod=="")?"%":cod;
			DropDownList pcmbsAddetti0 = (DropDownList)Panel1.Controls[0].Controls[0].FindControl("cmbsAddetti0");
			DropDownList pcmbsAddetti1 = (DropDownList)Panel1.Controls[0].Controls[0].FindControl("cmbsAddetti1");
 
			Class.ClassRichiesta  _Richiesta = new Class.ClassRichiesta(Context.User.Identity.Name);
			DataSet Ds=_Richiesta.GetAddetti(NomeCompleto, codEdificio, codDitta);
			if (Ds.Tables[0].Rows.Count >0)
			{
				pcmbsAddetti0.DataSource = Ds.Tables[0];
				pcmbsAddetti0.DataTextField = "NOMINATIVO";
				pcmbsAddetti0.DataValueField = "ID";				
				pcmbsAddetti0.DataBind();
				pcmbsAddetti1.DataSource = Ds.Tables[0];
				pcmbsAddetti1.DataTextField = "NOMINATIVO";
				pcmbsAddetti1.DataValueField = "ID";				
				pcmbsAddetti1.DataBind();
			}
		}


		protected void Calendar_Click(object sender, System.EventArgs e)
		{

			Panel1.Visible=false;
			Panel2.Visible=true;
		}
		protected void ModificaODL_Click(object sender, System.EventArgs e)
		{
			this.pcmbsAddetti0 = (DropDownList)Panel1.Controls[0].Controls[0].FindControl("cmbsAddetti0");
			Panel1.Visible=true;
			Panel2.Visible=false;

			System.Web.UI.MobileControls.RegularExpressionValidator RqOrdine=(System.Web.UI.MobileControls.RegularExpressionValidator)Panel1.Controls[0].FindControl("RegularExpressionValidator1");
			RqOrdine.Visible=false;
			if(this._HS==null)
			{
				this._HS = new Hashtable();
			}

			foreach(DataGridItem o_Litem in this.p_GridRisultati.Items)
			{	
				int id = Int32.Parse(o_Litem.Cells[0].Text);
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel");

				if(this._HS.ContainsKey(id))
				{
					this._HS.Remove(id);
				}
				if(	cb.Checked)			
					this._HS.Add(id,cb.Checked);
			}
			myDelegate(_HS,1);

		}
		protected void CompletaODL_Click(object sender, System.EventArgs e)
		{
			this.pcmbsAddetti1 = (DropDownList)Panel1.Controls[0].Controls[0].FindControl("cmbsAddetti1");
			this.date = this.GetValue(Panel1,"txtData"); 

			System.Web.UI.MobileControls.RegularExpressionValidator RqOrdine=(System.Web.UI.MobileControls.RegularExpressionValidator)Panel1.Controls[0].FindControl("RegularExpressionValidator1");
			RqOrdine.Visible=true;
			if(RqOrdine.IsValid)
			{
				Panel1.Visible=true;
				Panel2.Visible=false;

				string data = this.GetValue(Panel1,"txtData");

				if(this._HS==null)
				{
					this._HS = new Hashtable();
				}

				foreach(DataGridItem o_Litem in this.p_GridRisultati.Items)
				{	
					int id = Int32.Parse(o_Litem.Cells[0].Text);
					System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel");

					if(this._HS.ContainsKey(id))
					{
						this._HS.Remove(id);
					}
					if(	cb.Checked)			
						this._HS.Add(id,cb.Checked);
				}

				myDelegate(_HS,2);
			}

		}
		protected void OnChiudi(object sender, System.EventArgs e)
		{
			Panel1.Visible=true;
			Panel2.Visible=false;
		}


		protected void Calendar_SelectionChangedDataStart(Object sender, EventArgs e)
		{
			this.SetValue(Panel1,"txtData",((System.Web.UI.MobileControls.Calendar)(sender)).SelectedDate.ToShortDateString());
			Panel1.Visible=true;
			Panel2.Visible=false;
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

		///		Metodo necessario per il supporto della finestra di progettazione. Non modificare
		///		il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			Panel1.Visible=true;
			Panel2.Visible=false;
			((System.Web.UI.WebControls.TextBox)Panel1.Controls[0].FindControl("txtData")).Enabled=false;
			this.Load += new System.EventHandler(this.Page_Load);
			

		}
		#endregion
		private void SetValue(Control Ctrl,string NameField, string value)
		{
			
			Control Ct=Ctrl.Controls[0].FindControl(NameField);
			value=value.Replace("\n"," ");
			value=value.Replace("\r",""); 
			if (Ct is System.Web.UI.MobileControls.Label)
				((System.Web.UI.MobileControls.Label)Ctrl.Controls[0].FindControl(NameField)).Text=value;

			if (Ct is System.Web.UI.MobileControls.TextBox)
				((System.Web.UI.MobileControls.TextBox)Ctrl.Controls[0].FindControl(NameField)).Text=value;

			if (Ct is System.Web.UI.WebControls.TextBox)
				((System.Web.UI.WebControls.TextBox)Ctrl.Controls[0].FindControl(NameField)).Text=value;
		}

		private string GetValue(Control Ctrl,string NameField)
		{
			Control Ct=Ctrl.Controls[0].FindControl(NameField);

			if (Ct is System.Web.UI.MobileControls.Label)
				return ((System.Web.UI.MobileControls.Label)Ctrl.Controls[0].FindControl(NameField)).Text;

			if (Ct is System.Web.UI.MobileControls.TextBox)
				return ((System.Web.UI.MobileControls.TextBox)Ctrl.Controls[0].FindControl(NameField)).Text;

			if (Ct is System.Web.UI.WebControls.TextBox)
				return ((System.Web.UI.WebControls.TextBox)Ctrl.Controls[0].FindControl(NameField)).Text;

			if (Ct is DropDownList)
				return ((DropDownList)Ctrl.Controls[0].FindControl(NameField)).SelectedValue;

			return "";
		}
	}
}
