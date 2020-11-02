using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

namespace StampaRapportiPdf.Classi
{
	/// <summary>
	/// Descrizione di riepilogo per SiteJavaScript.
	/// </summary>
	public class SiteJavaScript
	{
		#region Dichiarazioni

		private static string s_TestataScript = "<script language=\"javascript\">\n";
		private static string s_CodaScript = "</script>\n";
		public static string LastFunction = string.Empty;

		#endregion

//		public static SiteJavaScript()
//		{
//
//		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="CurrentPage"></param>
		public static void ConfirmDelete(Page CurrentPage)
		{
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append(s_TestataScript);
			_StrBld.Append("function ConfirmDelete() {\n");
			_StrBld.Append("flag = confirm(\'Si vuole cancellare l'informazione seleziona?\');\n");
			_StrBld.Append("return flag;\n");
			_StrBld.Append("}\n");
			_StrBld.Append(s_CodaScript);

			RegistrationScript(CurrentPage, "ConfirmDelete", _StrBld.ToString());
			LastFunction = "ConfirmDelete()";
		}

		/// <summary>
		/// Questa funzione permette a l'iframe di sparire e apparire
		/// Lo script è presente in  RicercaModulo.ascx
		/// </summary>
		/// <param name="CurrentPage"> E' la pagina a cui va reggistarto lo script</param>
		/// <param name="NumDirectory">Indica quante directori deve salire</param>
		public static void ShowFrameSollecito(Page CurrentPage, int NumDirectory)
		{
			string dir="";	
			for (int i = 0; i < NumDirectory; i++)
			{
				dir+="../";
			}
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append(s_TestataScript);
			_StrBld.Append("function ShowFrameAddSoll(sender,idquery,e){\n");
			_StrBld.Append("var ctrl = document.getElementById(\"PopupAddSoll\").style;\n");
			_StrBld.Append("x = e.clientX;\n");
			_StrBld.Append("y = e.clientY;\n");
			_StrBld.Append("ctrl.left = 10;\n");
			_StrBld.Append("ctrl.top = y+30;\n");  
			//	_StrBld.Append("ctrl.display = (ctrl.display == 'none')?'block':'none';\n");
			//	_StrBld.Append("if (ctrl.display =='none') return;\n");
			_StrBld.Append("if (ctrl.display =='none') ctrl.display='block';\n");
			_StrBld.Append("ctrl2= document.getElementById(sender).value;\n");
			//	_StrBld.Append("document.getElementById(\"doc\").src=\"" + dir + "CommonPage/ListaEdifici.aspx?\" + idquery + \"=\" + ctrl2 + \"&idmodulo=\" + idmodulo;\n");  		
			_StrBld.Append("document.getElementById(\"docAddSoll\").src=\"" + dir + "CommonPage/Sollecito.aspx?\" + idquery + \"=\" + ctrl2;\n");// + \"&idmodulo=\" + idmodulo + \"&ms=\" + ms;\n");  			
			_StrBld.Append("}\n");
			_StrBld.Append(s_CodaScript);
			RegisterStartUpScritp(CurrentPage,"Sollecito", _StrBld.ToString());
		}

		public static void ShowFrameVisSollecito(Page CurrentPage, int NumDirectory)
		{
			string dir="";	
			for (int i = 0; i < NumDirectory; i++)
			{
				dir+="../";
			}
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append(s_TestataScript);
			_StrBld.Append("function ShowFrameVisSoll(sender,idquery,e){\n");
			_StrBld.Append("var ctrl = document.getElementById(\"PopupVisSoll\").style;\n");
			_StrBld.Append("x = e.clientX;\n");
			_StrBld.Append("y = e.clientY;\n");
			_StrBld.Append("ctrl.left = 10;\n");
			_StrBld.Append("ctrl.top = y+30;\n");  
			//	_StrBld.Append("ctrl.display = (ctrl.display == 'none')?'block':'none';\n");
			//	_StrBld.Append("if (ctrl.display =='none') return;\n");
			_StrBld.Append("if (ctrl.display =='none') ctrl.display='block';\n");
			_StrBld.Append("ctrl2= document.getElementById(sender).value;\n");
			//	_StrBld.Append("document.getElementById(\"doc\").src=\"" + dir + "CommonPage/ListaEdifici.aspx?\" + idquery + \"=\" + ctrl2 + \"&idmodulo=\" + idmodulo;\n");  		
			_StrBld.Append("document.getElementById(\"docVisSoll\").src=\"" + dir + "CommonPage/RiepilogoSolleciti.aspx?\" + idquery + \"=\" + ctrl2;\n");// + \"&idmodulo=\" + idmodulo + \"&ms=\" + ms;\n");  			
			_StrBld.Append("}\n");
			_StrBld.Append(s_CodaScript);
			RegisterStartUpScritp(CurrentPage,"VisSollecito", _StrBld.ToString());
		}
		
		public static void ShowFrame(Page CurrentPage, int NumDirectory)
		{
			string dir="";	
			for (int i = 0; i < NumDirectory; i++)
			{
				dir+="../";
			}
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append(s_TestataScript);
			_StrBld.Append("function ShowFrame(sender,idquery,e,idmodulo,ms){\n");
			_StrBld.Append("var ctrl = document.getElementById(\"Popup\").style;\n");
			_StrBld.Append("x = e.clientX;\n");
			_StrBld.Append("y = e.clientY;\n");
			_StrBld.Append("ctrl.left = 50;\n");
			_StrBld.Append("ctrl.top = y+30;\n");  
			//	_StrBld.Append("ctrl.display = (ctrl.display == 'none')?'block':'none';\n");
			//	_StrBld.Append("if (ctrl.display =='none') return;\n");
			_StrBld.Append("if (ctrl.display =='none') ctrl.display='block';\n");
			_StrBld.Append("ctrl2= document.getElementById(sender).value;\n");
			//	_StrBld.Append("document.getElementById(\"doc\").src=\"" + dir + "CommonPage/ListaEdifici.aspx?\" + idquery + \"=\" + ctrl2 + \"&idmodulo=\" + idmodulo;\n");  		
			_StrBld.Append("document.getElementById(\"doc\").src=\"" + dir + "CommonPage/ListaEdifici.aspx?\" + idquery + \"=\" + ctrl2 + \"&idmodulo=\" + idmodulo + \"&ms=\" + ms;\n");  
			_StrBld.Append("}\n");
			_StrBld.Append(s_CodaScript);
			RegisterStartUpScritp(CurrentPage,"start", _StrBld.ToString());
		}

		public static void ShowFrameReperibili(Page CurrentPage, int NumDirectory)
		{
			string dir="";	
			for (int i = 0; i < NumDirectory; i++)
			{
				dir+="../";
			}
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append(s_TestataScript);
			_StrBld.Append("function ShowFrameRep(sender,idquery,e){\n");
			_StrBld.Append("var ctrl = document.getElementById(\"PopupRep\").style;\n");
			_StrBld.Append("x = e.clientX;\n");
			_StrBld.Append("y = e.clientY;\n");
			_StrBld.Append("ctrl.left = 10;\n");
			_StrBld.Append("ctrl.top = y+30;\n");  
			//	_StrBld.Append("ctrl.display = (ctrl.display == 'none')?'block':'none';\n");
			//	_StrBld.Append("if (ctrl.display =='none') return;\n");
			_StrBld.Append("if (ctrl.display =='none') ctrl.display='block';\n");
			_StrBld.Append("ctrl2= document.getElementById(sender).value;\n");
			//	_StrBld.Append("document.getElementById(\"doc\").src=\"" + dir + "CommonPage/ListaEdifici.aspx?\" + idquery + \"=\" + ctrl2 + \"&idmodulo=\" + idmodulo;\n");  		
			_StrBld.Append("document.getElementById(\"docRep\").src=\"" + dir + "CommonPage/RiepilogoReperibilita.aspx?\" + idquery + \"=\" + ctrl2;\n");// + \"&idmodulo=\" + idmodulo + \"&ms=\" + ms;\n");  			
			_StrBld.Append("}\n");
			_StrBld.Append(s_CodaScript);
			RegisterStartUpScritp(CurrentPage,"Reperibili", _StrBld.ToString());
		}

		public static void ShowFrameReperibiliBL(Page CurrentPage, int NumDirectory)
		{
			string dir="";	
			for (int i = 0; i < NumDirectory; i++)
			{
				dir+="../";
			}
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append(s_TestataScript);
			_StrBld.Append("function ShowFrameRep(sender,idquery,e){\n");
			_StrBld.Append("var ctrl = document.getElementById(\"PopupRep\").style;\n");
			//_StrBld.Append("x = e.clientX;\n");
			//_StrBld.Append("y = e.clientY;\n");
			//_StrBld.Append("ctrl.left = 10;\n");
			//_StrBld.Append("ctrl.top = y+30;\n");  
			//	_StrBld.Append("ctrl.display = (ctrl.display == 'none')?'block':'none';\n");
			//	_StrBld.Append("if (ctrl.display =='none') return;\n");
			_StrBld.Append("if (ctrl.display =='none') ctrl.display='block';\n");
			_StrBld.Append("ctrl2= document.getElementById(sender).value;\n");
			//	_StrBld.Append("document.getElementById(\"doc\").src=\"" + dir + "CommonPage/ListaEdifici.aspx?\" + idquery + \"=\" + ctrl2 + \"&idmodulo=\" + idmodulo;\n");  		
			_StrBld.Append("document.getElementById(\"docRep\").src=\"" + dir + "CommonPage/RiepilogoReperibilita.aspx?\" + idquery + \"=\" + ctrl2;\n");// + \"&idmodulo=\" + idmodulo + \"&ms=\" + ms;\n");  			
			_StrBld.Append("}\n");
			_StrBld.Append(s_CodaScript);
			RegisterStartUpScritp(CurrentPage,"Reperibili", _StrBld.ToString());
		}


//		public static string ShowFrameReperibiliString(Page CurrentPage, int NumDirectory)
//		{
//			string dir="";	
//			for (int i = 0; i < NumDirectory; i++)
//			{
//				dir+="../";
//			}
//			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
//			_StrBld.Append(s_TestataScript);
//			_StrBld.Append("function ShowFrameRep(sender,idquery,e){\n");
//			_StrBld.Append("var ctrl = document.getElementById(\"PopupRep\").style;\n");
//			_StrBld.Append("x = e.clientX;\n");
//			_StrBld.Append("y = e.clientY;\n");
//			_StrBld.Append("ctrl.left = 10;\n");
//			_StrBld.Append("ctrl.top = y+30;\n");  
//			//	_StrBld.Append("ctrl.display = (ctrl.display == 'none')?'block':'none';\n");
//			//	_StrBld.Append("if (ctrl.display =='none') return;\n");
//			_StrBld.Append("if (ctrl.display =='none') ctrl.display='block';\n");
//			_StrBld.Append("ctrl2= document.getElementById(sender).value;\n");
//			//	_StrBld.Append("document.getElementById(\"doc\").src=\"" + dir + "CommonPage/ListaEdifici.aspx?\" + idquery + \"=\" + ctrl2 + \"&idmodulo=\" + idmodulo;\n");  		
//			_StrBld.Append("document.getElementById(\"docRep\").src=\"" + dir + "CommonPage/RiepilogoReperibilita.aspx?\" + idquery + \"=\" + ctrl2;\n");// + \"&idmodulo=\" + idmodulo + \"&ms=\" + ms;\n");  			
//			_StrBld.Append("}\n");
//			_StrBld.Append(s_CodaScript);
//
//			return _StrBld.ToString();
//		}

		public static void ShowWindowOpen(Page CurrentPage, int NumDirectory,string url,int width,int height)
		{
			string dir="";	
			for (int i = 0; i < NumDirectory; i++)
			{
				dir+="../";
			}
			
			if(NumDirectory>0)
				url=dir+url;
			string s = "window.open('"+ url+ "','name','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no',width='"+width+"',height='"+height+"',align='center');";			
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append(s_TestataScript);
			_StrBld.Append("function ApriPopPup(){\n");			
			_StrBld.Append(s);  
			_StrBld.Append("}\n");
			_StrBld.Append(s_CodaScript);
			RegisterStartUpScritp(CurrentPage,"start", _StrBld.ToString());
		}

		public static void WindowModeless(Page CurrentPage, int NumDirectory,string url,int width,int height)
		{
			string dir="";	
			for (int i = 0; i < NumDirectory; i++)
			{
				dir+="../";
			}
			
			if(NumDirectory>0)
				url=dir+url;
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			string s = "window.showModalDialog('"+ url+ "','','help:0;resizable:1;dialogWidth:" + width + "px;dialogHeight:" + height + "px');";														
			_StrBld.Append(s_TestataScript);
			_StrBld.Append(s);
			_StrBld.Append("\n");
			_StrBld.Append(s_CodaScript);			
			RegisterStartUpScritp(CurrentPage,url,_StrBld.ToString());
		}

		public static void WindowOpen(Page CurrentPage, int NumDirectory,string url,int width,int height)
		{
			string dir="";	
			for (int i = 0; i < NumDirectory; i++)
			{
				dir+="../";
			}
			
			if(NumDirectory>0)
				url=dir+url;
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			string s = "window.open('"+ url+ "','name','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no',width='"+width+"',height='"+height+"',align='center');";			
			_StrBld.Append(s_TestataScript);
			_StrBld.Append(s);
			_StrBld.Append("\n");
			_StrBld.Append(s_CodaScript);			
			RegisterStartUpScritp(CurrentPage,url,_StrBld.ToString());
		}
		public static void WindowOpen(Page CurrentPage, int NumDirectory,string url,int width,int height,string namewindow)
		{
			string dir="";	
			for (int i = 0; i < NumDirectory; i++)
			{
				dir+="../";
			}
			
			if(NumDirectory>0)
				url=dir+url;
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
 
			string s = namewindow + "=window.open('"+ url+ "','name','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no',width='"+width+"',height='"+height+"',align='center');";			
			_StrBld.Append(s_TestataScript);
			_StrBld.Append(s);
			_StrBld.Append("\n");
			_StrBld.Append(s_CodaScript);			
			RegisterStartUpScritp(CurrentPage,url,_StrBld.ToString());
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="CurrentPage"></param>
		/// <param name="messaggio"></param>
		public static void msgBox(Page CurrentPage,string messaggio)
		{	
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append(s_TestataScript);			
			string mes="alert('"+ messaggio.Replace("'",@"\'")  +"');"; 							
			_StrBld.Append(mes);
			_StrBld.Append(s_CodaScript);
			RegisterStartUpScritp(CurrentPage,"msgBox", _StrBld.ToString());
		}

		public static void OpenerReload(Page CurrentPage, string url)
		{	
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append(s_TestataScript);	
			string scripturl = "var wi='" + url + "';";
			string mes="opener.document.location.reload(wi);"; 		
			_StrBld.Append(scripturl);					
			_StrBld.Append(mes);
			_StrBld.Append(s_CodaScript);
			RegisterStartUpScritp(CurrentPage,"Reload", _StrBld.ToString());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="CurrentPage"></param>
		/// <param name="NumDirectory"></param>
		public static void ShowFrameMatricole(Page CurrentPage, int NumDirectory)
		{
			string dir="";	
			for (int i = 0; i < NumDirectory; i++)
			{
				dir+="../";
			}
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append(s_TestataScript);
			_StrBld.Append("function ShowFrameMatricole(sender,idquery,e,idmodulo){\n");
			_StrBld.Append("var ctrl = document.getElementById(\"Popupmatricole\").style;\n");
			_StrBld.Append("x = e.clientX;\n");
			_StrBld.Append("y = e.clientY;\n");
			_StrBld.Append("ctrl.left = 50;\n");
			_StrBld.Append("ctrl.top = y+20;\n");  
			_StrBld.Append("if (ctrl.display =='none') ctrl.display='block';\n");
			_StrBld.Append("ctrl2= document.getElementById(sender).value;\n");
			_StrBld.Append("document.getElementById(\"docmatricole\").src=\"" + dir + "CommonPage/ListaMatricole.aspx?\" + idquery + \"=\" + ctrl2 + \"&idmodulo=\" + idmodulo;\n");  
			_StrBld.Append("}\n");
			_StrBld.Append(s_CodaScript);
			RegisterStartUpScritp(CurrentPage,"matricole", _StrBld.ToString());
		}
		public static void ShowFrameFascicolo(Page CurrentPage, int NumDirectory)
		{
			string dir="";	
			for (int i = 0; i < NumDirectory; i++)
			{
				dir+="../";
			}
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append(s_TestataScript);
			_StrBld.Append("function ShowFrameFascicolo(sender,idquery,e,idmodulo){\n");
			_StrBld.Append("var ctrl = document.getElementById(\"Popupfascicolo\").style;\n");
			_StrBld.Append("x = e.clientX;\n");
			_StrBld.Append("y = e.clientY;\n");
			_StrBld.Append("ctrl.left = 50;\n");
			_StrBld.Append("ctrl.top = y+20;\n");  
			_StrBld.Append("if (ctrl.display =='none') ctrl.display='block';\n");
			_StrBld.Append("ctrl2= document.getElementById(sender).value;\n");
			_StrBld.Append("document.getElementById(\"docfascicolo\").src=\"" + dir + "CommonPage/ListaFascicoli.aspx?\" + idquery + \"=\" + ctrl2 + \"&idmodulo=\" + idmodulo;\n");  
			_StrBld.Append("}\n");
			_StrBld.Append(s_CodaScript);
			RegisterStartUpScritp(CurrentPage,"fascicoli", _StrBld.ToString());
		}
		public static void ShowFramePMP(Page CurrentPage, int NumDirectory)
		{
			string dir="";	
			for (int i = 0; i < NumDirectory; i++)
			{
				dir+="../";
			}

			//document.getElementById("cmdsStdApparecchiatura").value;
			
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append(s_TestataScript);
			_StrBld.Append("function ShowFrameMatricole(sender,idquery,e,idmodulo){\n");
			_StrBld.Append("var ctrl = document.getElementById(\"Popupmatricole\").style;\n");
			_StrBld.Append("var ideqstd = document.getElementById(\"cmdsStdApparecchiatura\").value;\n");
			_StrBld.Append("var idservizio = document.getElementById(\"cmbsServizio\").value;\n");
			_StrBld.Append("x = e.clientX;\n");
			_StrBld.Append("y = e.clientY;\n");
			_StrBld.Append("ctrl.left = 50;\n");
			_StrBld.Append("ctrl.top = y+20;\n");  
			_StrBld.Append("if (ctrl.display =='none') ctrl.display='block';\n");
			_StrBld.Append("ctrl2= document.getElementById(sender).value;\n");
			_StrBld.Append("document.getElementById(\"docmatricole\").src=\"" + dir + "CommonPage/ListaPMP.aspx?\" + idquery + \"=\" + ctrl2 + \"&idmodulo=\" + idmodulo+ \"&ideqstd=\" + ideqstd+ \"&idservizio=\" + idservizio;\n");  
			_StrBld.Append("}\n");
			_StrBld.Append(s_CodaScript);
			RegisterStartUpScritp(CurrentPage,"matricole", _StrBld.ToString());
		}
		/// <summary>
		/// Questa funzione permette a l'iframe di sparire e apparire
		/// Lo script è presente in  RicercaModulo.ascx
		/// </summary>
		/// <param name="CurrentPage"> E' la pagina a cui va reggistarto lo script</param>
		/// <param name="NumDirectory">Indica quante directori deve salire</param>
		public static void ShowInfo(Page CurrentPage)
		{
			System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
			_StrBld.Append(s_TestataScript);
			_StrBld.Append("function ShowInfo(){\n");
			_StrBld.Append("var ctrl = document.getElementById(\"Popup\").style;\n");
			_StrBld.Append("x = e.clientX;\n");
			_StrBld.Append("y = e.clientY;\n");
			_StrBld.Append("ctrl.left = 50;\n");
			_StrBld.Append("ctrl.top = y+30;\n");  

			_StrBld.Append("if (ctrl.display =='none') ctrl.display='block';\n");
			_StrBld.Append("}\n");
			_StrBld.Append(s_CodaScript);
			RegisterStartUpScritp(CurrentPage, "ShowInfo", _StrBld.ToString());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="CurrentPage"></param>
		/// <param name="ScriptId"></param>
		/// <param name="Script"></param>
		private static void RegistrationScript(Page CurrentPage, string ScriptId, string Script)
		{
			CurrentPage.RegisterClientScriptBlock(ScriptId, Script);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="CurrentPage"></param>
		/// <param name="ScriptId"></param>
		/// <param name="Script"></param>
		private static void RegisterStartUpScritp(Page CurrentPage, string ScriptId,string Script)
		{
			if(!CurrentPage.IsStartupScriptRegistered(ScriptId))
				CurrentPage.RegisterStartupScript(ScriptId, Script);
		}
//		/// <summary>
//		/// Indica se la richiesta è stata effetuata da un Browser Mobile
//		/// </summary>
//		public static bool IsMobileDevice 
//		{
//			get 
//			{
//				HttpContext context = HttpContext.Current;
//				return context.Request.Browser["IsMobileDevice"] == "true" || context.Request.Browser.Platform == "WinCE";
//			}
//		}
		
	}
}
