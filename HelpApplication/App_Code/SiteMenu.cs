using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections;
using System.Web;
using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;

namespace HelpApplication
{
	/// <summary>
	/// Descrizione di riepilogo per SiteMenu.
	/// </summary>
	public class SiteMenu
	{
		#region Dichiarazioni

		private string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];						

		#endregion
		private string menuselect=string.Empty;
		System.Web.HttpContext Context;
		public SiteMenu(System.Web.HttpContext context)
		{ 
			
			Context=context;
		}
		public SiteMenu(string MenuSelect,System.Web.HttpContext context)
		{
			
			menuselect=MenuSelect;
			Context=context;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		
		System.Xml.XmlDocument _xdoc;
		public System.Xml.XmlDocument GetMenu(string app)
		{
			_xdoc = new System.Xml.XmlDocument();
	
		    XmlNode Nodo=_xdoc.CreateNode(XmlNodeType.Element,"menu","");
			_xdoc.AppendChild(Nodo);
			this.ItemMenu(0,Nodo);
			return _xdoc;
		}

		private void ItemMenu(int IdMenuPadre,XmlNode _xNode)
		{
		
			DataSet _MyDs = this.GetItemMenuData(IdMenuPadre);	

			foreach(DataRow DtRo in _MyDs.Tables[0].Rows)
			{	
				XmlNode nodo=_xdoc.CreateNode(XmlNodeType.Element,"menuItem","");


				XmlNode nodo2=_xdoc.CreateNode(XmlNodeType.Element,"text","");
				nodo2.InnerText= DtRo["DESCRIZIONE"].ToString();
				nodo.AppendChild(nodo2);

				if (DtRo["LINK_HELP"] != DBNull.Value && DtRo["LINK_HELP"].ToString() != "")
				{
					string s_FunzioneId = DtRo["FUNZIONE_ID"].ToString();
//					string s_Link =  DtRo["LINK_HELP"].ToString().Replace("Default.aspx?page=","Help/");
					string s_Link =  "Help/"  + DtRo["LINK_HELP"].ToString();
					s_Link += "?FunId=" + s_FunzioneId;
			        nodo2=_xdoc.CreateNode(XmlNodeType.Element,"url","");
					s_Link=s_Link.Replace("aspx","htm");
					nodo2.InnerText= s_Link;
					nodo.AppendChild(nodo2);
				}
				nodo2=_xdoc.CreateNode(XmlNodeType.Element,"target","");
				nodo2.InnerText= DtRo["TARGET"].ToString();
				nodo.AppendChild(nodo2);
				nodo2=_xdoc.CreateNode(XmlNodeType.Element,"tooltip","");
				nodo2.InnerText= DtRo["TOOLTIP"].ToString();
				nodo.AppendChild(nodo2);
				nodo2=_xdoc.CreateNode(XmlNodeType.Element,"cssclass","");
				nodo2.InnerText= DtRo["CSSCLASS"].ToString();
				nodo.AppendChild(nodo2);
				
				_xNode.AppendChild(nodo);
			

				if(DtRo["LINK_HELP"]!=DBNull.Value)
					if(ElaborateUrl(DtRo["LINK_HELP"].ToString(),menuselect)==menuselect)
					{
						nodo2=_xdoc.CreateNode(XmlNodeType.Element,"expand","");
						nodo2.InnerText= "true";
						_xNode.ParentNode.AppendChild(nodo2);
					}
               
				int i_Totf = 0;
				if (DtRo["TOTF"].ToString().Trim() == "")
					i_Totf = 0;
				else
					i_Totf = Convert.ToInt32(DtRo["TOTF"].ToString());
				if (i_Totf > 0)
				{
					nodo2=_xdoc.CreateNode(XmlNodeType.Element,"subMenu","");
					nodo.AppendChild(nodo2);
					ItemMenu(Convert.ToInt32(DtRo["FUNZIONE_MENU_ID"]), nodo2);
				}

				
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="IdMenuPadre"></param>
		/// <param name="xTextWriter"></param>
		
		
		private string ElaborateUrl(string UrlHelp,string UrlHelpRequest)
		{
		 if(UrlHelpRequest=="") return null;
		 if(UrlHelp.Length<UrlHelpRequest.Length) return UrlHelp;
		 if(UrlHelp.Length==UrlHelpRequest.Length) return UrlHelp;
		 int Lung=UrlHelp.Length - UrlHelpRequest.Length;
		 return UrlHelp=UrlHelp.Substring(Lung);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="IdMenuPadre"></param>
		/// <returns></returns>
		private DataSet GetItemMenuData(int IdMenuPadre)
		{			
			
			System.Web.HttpContext context = System.Web.HttpContext.Current;

			ParameterObjectCollection _PColl = new ParameterObjectCollection();
			
			ApplicationDataLayer.Collections.ParameterObject _PMenuPadreId = new ParameterObject();

			_PMenuPadreId.ParameterName = "p_Menu_Padre_Id";
			_PMenuPadreId.DbType = CustomDBType.Integer;
			_PMenuPadreId.Direction = ParameterDirection.Input;
			_PMenuPadreId.Value = IdMenuPadre;
			_PMenuPadreId.Index = 0;

			
			ApplicationDataLayer.Collections.ParameterObject _PRuoli = new ApplicationDataLayer.Collections.ParameterObject();
			_PRuoli.ParameterName = "p_UserName";
			_PRuoli.DbType = CustomDBType.VarChar;
			_PRuoli.Direction = ParameterDirection.Input;
			//_PRuoli.Value = "admin";
			if( Context.User.Identity.Name!="")
				_PRuoli.Value = Context.User.Identity.Name;
			else
				_PRuoli.Value = "admin";
			_PRuoli.Index = 1;
			
			ApplicationDataLayer.Collections.ParameterObject _PCursor = new ApplicationDataLayer.Collections.ParameterObject();
			_PCursor.ParameterName = "IO_CURSOR";
			_PCursor.DbType = CustomDBType.Cursor;
			_PCursor.Direction = ParameterDirection.Output;
			_PCursor.Index = 2;

			_PColl.Add(_PMenuPadreId);
			_PColl.Add(_PRuoli);
			_PColl.Add(_PCursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			DataSet _MyDs = _OraDl.GetRows(_PColl, "PACK_UTENTI.SP_MENU_UTENTI").Copy();

			return  _MyDs;

		}

	}
}
