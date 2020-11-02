
namespace WebCad.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using S_Controls;
	/// <summary>
	///		Descrizione di riepilogo per CodiceApparecchiature.
	/// </summary>
	public class CodiceApparecchiature : System.Web.UI.UserControl
	{
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCodEq;
		protected S_Controls.S_TextBox S_txtcodapparecchiatura;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.

//			String scriptString = "<script language=JavaScript> var idthis='" + this.ClientID +"'";
//			scriptString += "<";
//			scriptString += "/";
//			scriptString += "script>";
//			if(!this.Page.IsClientScriptBlockRegistered("clientScript2"))
//				this.Page.RegisterClientScriptBlock("clientScript2", scriptString);
            if (this.S_txtcodapparecchiatura.Text=="")
				this.hidCodEq.Value="";
			ShowFrame2(1);
		}
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

			_StrBld.Append("ctrl2= document.getElementById(\"" + S_txtcodapparecchiatura.ClientID +"\").value;\n");
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
				S_ComboBox cbs=(S_ComboBox)this.Page.FindControl(NameComboServizio);
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
			//Verivico se è presente la combo apparecchiature e presente e la aggiungo come parametro
			if (NameComboApparecchiature!="")
			{
				S_ComboBox cba=(S_ComboBox)this.Page.FindControl(NameComboApparecchiature);
				if (cba!=null )
				{
					_StrBld.Append("var val2=\"&appaid=\";\n");
					_StrBld.Append("var ctrl6= document.getElementById(\"" + cba.ClientID +"\");\n");
					_StrBld.Append("if (ctrl6!=\"undefined\" && ctrl6!=null){\n");
					_StrBld.Append("    if (ctrl6.selectedIndex!=-1) val2+=ctrl6.options[ctrl6.selectedIndex].value;\n");
					_StrBld.Append("}\n");
					_StrBld.Append("ctrl2+=val2;\n");
				}
			}

			//Verivico se è presente la combo Piano e presente e la aggiungo come parametro
			if (NameComboPiano!="")
			{
				S_ComboBox cbp=(S_ComboBox)this.Page.FindControl(NameComboPiano);
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
			//Verivico se è presente la combo Stanza e presente e la aggiungo come parametro
			if (NameComboStanza!="")
			{
				S_ComboBox cbst=(S_ComboBox)this.Page.FindControl(NameComboStanza);
				if (cbst!=null )
				{
					_StrBld.Append("var val4=\"&stanza=\";\n");
					_StrBld.Append("var ctrl8= document.getElementById(\"" + cbst.ClientID +"\");\n");
					_StrBld.Append("if (ctrl8!=\"undefined\" && ctrl8!=null){\n");
					_StrBld.Append("    if (ctrl8.selectedIndex!=-1) val4+=ctrl8.options[ctrl8.selectedIndex].value;\n");
					_StrBld.Append("}\n");
					_StrBld.Append("ctrl2+=val4;\n");
				}
			}
             _StrBld.Append("ctrl2+='&dismissione="+this.Dismissione+"';\n");
			_StrBld.Append("var idUsercontrol=\"&idUsercontrol=\" + \"" + this.ClientID + "\";\n");
			_StrBld.Append("document.getElementById(\"docapp\").src=\"" + dir + "CommonPage/ListaApparecchiature.aspx?codapp=\" + ctrl2 + idUsercontrol;\n");  
//			_StrBld.Append("alert(document.getElementById(\"docapp\").src);\n");  
			_StrBld.Append("}\n");
			_StrBld.Append("</script>\n");
			this.Page.RegisterStartupScript("startsc", _StrBld.ToString());
		}

		#region Procedura commentata
		
//		private void ShowFrame2(int NumDirectory)
//		{
//			string dir="";	
//			for (int i = 0; i < NumDirectory; i++)
//			{
//				dir+="../";
//			}
//			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
//			_StrBld.Append( "<script language=\"javascript\">\n");
//			_StrBld.Append("function ShowFrame2(sender,e,sender2,sender3,sender4){\n");
//			_StrBld.Append("var ctrl = document.getElementById(\"PopupApp\").style;\n");
//			_StrBld.Append("x = e.clientX;\n");
//			_StrBld.Append("y = e.clientY;\n");
//			_StrBld.Append("ctrl.left = 50;\n");
//			_StrBld.Append("ctrl.top = y+30;\n");  
//			_StrBld.Append("if (ctrl.display =='none') ctrl.display='block';\n");
//			_StrBld.Append("ctrl2= document.getElementById(sender).value;\n");
//
//			_StrBld.Append("var ctrl3= document.getElementById(sender2);\n");
//			_StrBld.Append("var ctrl4= document.getElementById(sender3);\n");
//			_StrBld.Append("var val1=\"&blid=\";\n");
//			_StrBld.Append("var val2=\"&servizioid=\";\n");
//			_StrBld.Append("if (ctrl3!=\"undefined\" && ctrl3!=null) val1+=ctrl3.value;\n");
//			_StrBld.Append("if (ctrl4!=\"undefined\" && ctrl4!=null){\n");
//			_StrBld.Append("    if (ctrl4.selectedIndex!=-1) val2+=ctrl4.options[ctrl4.selectedIndex].value;\n");
//			_StrBld.Append("}\n");
//			_StrBld.Append("document.getElementById(\"docapp\").src=\"" + dir + "CommonPage/ListaApparecchiature.aspx?codapp=\" + ctrl2 + val1 + val2 + sender4;\n");  
//			_StrBld.Append("}\n");
//			_StrBld.Append("</script>\n");
//		    this.Page.RegisterStartupScript("startsc", _StrBld.ToString());
//		}

		//		public string ControlBlId
		//		{
		//			get {return (String) ViewState["s_ControlBlId"];}
		//			set {ViewState["s_ControlBlId"] = value;}
		//		}
		//		public string Controldservizioid
		//		{
		//			get {return (String) ViewState["s_Controldservizioid"];}
		//			set {ViewState["s_Controldservizioid"] = value;}
		//		}
	#endregion

	/// <summary>
	/// Ottiene imposata il Nome dell'User control Ricerca Modulo
	/// Viene impostato nel Page load
	/// </summary>
		public string NameUserControlRicercaModulo
		{
			get {
				if( ViewState["s_NameUserControlRicercaModulo"]==null)
				  return string.Empty;
				else
					return (string)ViewState["s_NameUserControlRicercaModulo"];
			}
			set {
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
		/// <summary>
		/// Ottiene imposta il Nome della combo Apparecchiature
		/// </summary>
		public string NameComboApparecchiature
		{
			get 
			{
				if( ViewState["s_NameComboApparecchiature"]==null)
					return string.Empty;
				else
					return (string)ViewState["s_NameComboApparecchiature"];
			}
			set 
			{
				ViewState["s_NameComboApparecchiature"] = value;
			}
		}
		/// <summary>
		/// Ottiene imposta il Nome della combo Stanza
		/// </summary>
		public string NameComboStanza
		{
			get 
			{
				if( ViewState["s_NameComboStanza"]==null)
					return string.Empty;
				else
					return (string)ViewState["s_NameComboStanza"];
			}
			set 
			{
				ViewState["s_NameComboStanza"] = value;
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

		public string CodiceApparecchiatura
		{
			get 
			{
				if (S_txtcodapparecchiatura.Text.Length > 0)
					return S_txtcodapparecchiatura.Text;
				else
					return string.Empty;
			}
			set
			{
				S_txtcodapparecchiatura.Text=value;
			}
		}
		
		public Classi.DismissioneType Dismissione
		{
			get 
			{
				 if (ViewState["Dismissione"]!=null) 
					return (Classi.DismissioneType)ViewState["Dismissione"];
				else
					 return Classi.DismissioneType.NO;

			}
			set
			{
				ViewState.Add("Dismissione",value);
			}
		}

		public System.Web.UI.HtmlControls.HtmlInputHidden CodiceHidden
		{
			get 
			{
				return hidCodEq;				
			}
			
		}

		public S_Controls.S_TextBox s_CodiceApparecchiatura
		{
			get 
			{
				return S_txtcodapparecchiatura;				
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
