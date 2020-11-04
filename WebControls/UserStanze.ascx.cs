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
	///		Descrizione di riepilogo per UserStanze.
	/// </summary>
	public class UserStanze : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox TxtIdStanza;
		protected S_Controls.S_TextBox s_txtDescStanza;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			ShowFramest(1);
		}
		private void ShowFramest(int NumDirectory)
		{
			string dir="";	
			for (int i = 0; i < NumDirectory; i++)
			{
				dir+="../";
			}
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append( "<script language=\"javascript\">\n");
			_StrBld.Append("function ShowFramest(sender,e){\n");
			_StrBld.Append("var ctrl = document.getElementById(\"PopupAppst\").style;\n");
			_StrBld.Append("x = e.clientX;\n");
			_StrBld.Append("y = e.clientY;\n");
			_StrBld.Append("ctrl.left = 50;\n");
			_StrBld.Append("ctrl.top = y+30;\n");  
			_StrBld.Append("if (ctrl.display =='none') ctrl.display='block';\n");

			_StrBld.Append("ctrl2= document.getElementById(\"" + s_txtDescStanza.ClientID +"\").value;\n");
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
			
			if (NameLblId!="")
			{
				S_Label lblid=(S_Label)this.Page.FindControl(NameLblId);
				if (lblid!=null )
				{
					_StrBld.Append("var ctrl3=\"&blid=\" +  document.getElementById(\"" + lblid.ClientID  +"\").innerText;\n");
					_StrBld.Append("var ctrl4=\"&campus=\" + document.getElementById(\"" +  lblid.ClientID +"\").innerText;\n");					
					_StrBld.Append("ctrl2+= ctrl3 + ctrl4;\n");
				}
			}
			//Verivico se è presente la combo Piano e presente e la aggiungo come parametro
			if (NameComboPiano!="")
			{
				DropDownList cbp=(DropDownList)this.Page.FindControl(NameComboPiano);
				if (cbp!=null )
				{
					_StrBld.Append("var val3=\"&piano=\";\n");
					_StrBld.Append("var ctrl7= document.getElementById(\"" + cbp.ClientID +"\");\n");
					_StrBld.Append("if (ctrl7!=\"undefined\" && ctrl7!=null){\n");
					_StrBld.Append("    if (ctrl7.selectedIndex!=-1) val3+=ctrl7.options[ctrl7.selectedIndex].value;\n");
					_StrBld.Append("}\n");
					_StrBld.Append("ctrl2+=val3;\n");
				}
			}
			
			
			_StrBld.Append("var idUsercontrol1=\"&idUsercontrol1=\" + \"" + this.ClientID + "\";\n");
			_StrBld.Append("document.getElementById(\"docstanza\").src=\"" + dir + "CommonPage/ListaStanze.aspx?codstanza=\" + ctrl2 + idUsercontrol1;\n");  
			//			_StrBld.Append("alert(document.getElementById(\"docstanza\").src);\n");  
			_StrBld.Append("}\n");
			_StrBld.Append("</script>\n");
			this.Page.RegisterStartupScript("startst", _StrBld.ToString());
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
		/// Ottiene imposta il Nome della combo Piano
		/// </summary>
		public string NameComboPiano
		{
			get 
			{
				if( ViewState["s_NameComboPiano"]==null)
					return string.Empty;
				else
					return (string)ViewState["s_NameComboPiano"];
			}
			set 
			{
				ViewState["s_NameComboPiano"] = value;
			}
		}

		public string DescStanza
		{
			get 
			{
				if (s_txtDescStanza.Text.Length > 0)
					return s_txtDescStanza.Text;
				else
					return string.Empty;
			}
			set
			{
				s_txtDescStanza.Text=value;
			}
		}

		public string IdStanza
		{
			get 
			{
				if (TxtIdStanza.Text.Length > 0)
					return TxtIdStanza.Text;
				else
					return string.Empty;
			}
			set
			{TxtIdStanza.Text=value;}
			
		}

		public  TextBox s_TxtIdStanza
		{
			get {return TxtIdStanza;}
		}

		public  TextBox s_TxtDescStanza
		{
			get {return s_txtDescStanza;}
		}
		
		public string NameLblId
		{
			get 
			{
				if( ViewState["s_NomeLblID"]==null)
					return string.Empty;
				else
					return (string)ViewState["s_NomeLblID"];
			}
			set 
			{
				ViewState["s_NomeLblID"] = value;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
