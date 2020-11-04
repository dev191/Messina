namespace TheSite.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using S_Controls;

	/// <summary>
	///		Descrizione di riepilogo per CodiceStdApparecchiatura.
	/// </summary>
	public class CodiceStdApparecchiatura : System.Web.UI.UserControl
	{
		protected S_Controls.S_TextBox S_txtcodStdapparecchiatura;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCodStd;

		private void Page_Load(object sender, System.EventArgs e)
		{
			ShowFrame2(1);
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

		private void ShowFrame2(int NumDirectory)
		{
			string dir="";	
			for (int i = 0; i < NumDirectory; i++)
			{
				dir+="../";
			}
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append( "<script language=\"javascript\">\n");
			_StrBld.Append("function ShowFrame2(sender,e){\n");
			_StrBld.Append("var ctrl = document.getElementById(\"PopupApp\").style;\n");
			_StrBld.Append("x = e.clientX;\n");
			_StrBld.Append("y = e.clientY;\n");
			_StrBld.Append("ctrl.left = 50;\n");
			_StrBld.Append("ctrl.top = y+30;\n");  
			_StrBld.Append("if (ctrl.display =='none') ctrl.display='block';\n");

			_StrBld.Append("ctrl2= document.getElementById(\"" + S_txtcodStdapparecchiatura.ClientID +"\").value;\n");
			//Se l'user control esiste ricerco nei campi i valori nella query string
			if (NameUserControlRicercaModulo!="")
			{
				RicercaModulo Ric=(RicercaModulo)this.Page.FindControl(NameUserControlRicercaModulo);
				if (Ric!= null)
				{
					//Recupero BLID e IL Campo Campus
					_StrBld.Append("var ctrl3=\"&blid=\" + document.getElementById(\"" + Ric.TxtCodice.ClientID +"\").value;\n");
					_StrBld.Append("var ctrl4=\"&campus=\" + document.getElementById(\"" + Ric.TxtRicerca.ClientID +"\").value;\n");					
					_StrBld.Append("ctrl2+= ctrl3 + ctrl4;\n");
				}
			}
			//Verivico se è presente la combo servizio e presente e la aggiungo come parametro
			if (NameComboServizio!="")
			{
				DropDownList cbs=(DropDownList)this.Page.FindControl(NameComboServizio);
				if (cbs!=null )
				{
					_StrBld.Append("var val1=\"&servizioid=\";\n");
					_StrBld.Append("var ctrl5= document.getElementById(\"" + cbs.ClientID +"\");\n");
					_StrBld.Append("if (ctrl5!=\"undefined\" && ctrl5!=null){\n");
					_StrBld.Append("    if (ctrl5.selectedIndex!=-1) val1+=ctrl5.options[ctrl5.selectedIndex].value;\n");
					_StrBld.Append("}\n");
					_StrBld.Append("ctrl2+=val1;\n");
				}
			}
			
			_StrBld.Append("var idUsercontrol=\"&idUsercontrol=\" + \"" + this.ClientID + "\";\n");
			_StrBld.Append("document.getElementById(\"docapp\").src=\"" + dir + "CommonPage/ListaStdApparecchiature.aspx?codapp=\" + ctrl2 + idUsercontrol;\n");  
			//			_StrBld.Append("alert(document.getElementById(\"docapp\").src);\n");  
			_StrBld.Append("}\n");
			_StrBld.Append("</script>\n");
			this.Page.RegisterStartupScript("startsc", _StrBld.ToString());
		}
		
		/// <summary>
		/// Ottiene imposata il Nome dell'User control Ricerca Modulo
		/// Viene impostato nel Page load
		/// </summary>
		public string NameUserControlRicercaModulo
		{
			get 
			{
				if( ViewState["s_NameUserControlRicercaModulo"]==null)
					return string.Empty;
				else
					return (string)ViewState["s_NameUserControlRicercaModulo"];
			}
			set 
			{
				ViewState["s_NameUserControlRicercaModulo"] = value;
			}
		}
		/// <summary>
		/// Ottiene imposta il Nome della combo Servizio
		/// </summary>
		public string NameComboServizio
		{
			get 
			{
				if( ViewState["s_NameComboServizio"]==null)
					return string.Empty;
				else
					return (string)ViewState["s_NameComboServizio"];
			}
			set 
			{
				ViewState["s_NameComboServizio"] = value;
			}
		}

		
		public string CodiceStd
		{
			get 
			{
				if (S_txtcodStdapparecchiatura.Text.Length > 0)
					return S_txtcodStdapparecchiatura.Text;
				else
					return string.Empty;
			}
			set
			{
				S_txtcodStdapparecchiatura.Text=value;
			}
		}
		public System.Web.UI.HtmlControls.HtmlInputHidden CodiceHidden
		{
			get 
			{
				return hidCodStd;				
			}
			
		}

		public S_Controls.S_TextBox s_CodiceStdApparecchiatura
		{
			get 
			{
				return S_txtcodStdapparecchiatura;				
			}
			
		}
	}
}
