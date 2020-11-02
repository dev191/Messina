// Decompiled with JetBrains decompiler
// Type: HelpApplication.SiteMenu
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Xml;

namespace HelpApplication
{
  public class SiteMenu
  {
    private string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];
    private string menuselect = string.Empty;
    private HttpContext Context;
    private XmlDocument _xdoc;

    public SiteMenu(HttpContext context) => this.Context = context;

    public SiteMenu(string MenuSelect, HttpContext context)
    {
      this.menuselect = MenuSelect;
      this.Context = context;
    }

    public XmlDocument GetMenu(string app)
    {
      this._xdoc = new XmlDocument();
      XmlNode node = this._xdoc.CreateNode(XmlNodeType.Element, "menu", "");
      this._xdoc.AppendChild(node);
      this.ItemMenu(0, node);
      return this._xdoc;
    }

    private void ItemMenu(int IdMenuPadre, XmlNode _xNode)
    {
      foreach (DataRow row in (InternalDataCollectionBase) this.GetItemMenuData(IdMenuPadre).Tables[0].Rows)
      {
        XmlNode node1 = this._xdoc.CreateNode(XmlNodeType.Element, "menuItem", "");
        XmlNode node2 = this._xdoc.CreateNode(XmlNodeType.Element, "text", "");
        node2.InnerText = row["DESCRIZIONE"].ToString();
        node1.AppendChild(node2);
        if (row["LINK_HELP"] != DBNull.Value && row["LINK_HELP"].ToString() != "")
        {
          string str1 = row["FUNZIONE_ID"].ToString();
          string str2 = "Help/" + row["LINK_HELP"].ToString() + "?FunId=" + str1;
          XmlNode node3 = this._xdoc.CreateNode(XmlNodeType.Element, "url", "");
          string str3 = str2.Replace("aspx", "htm");
          node3.InnerText = str3;
          node1.AppendChild(node3);
        }
        XmlNode node4 = this._xdoc.CreateNode(XmlNodeType.Element, "target", "");
        node4.InnerText = row["TARGET"].ToString();
        node1.AppendChild(node4);
        XmlNode node5 = this._xdoc.CreateNode(XmlNodeType.Element, "tooltip", "");
        node5.InnerText = row["TOOLTIP"].ToString();
        node1.AppendChild(node5);
        XmlNode node6 = this._xdoc.CreateNode(XmlNodeType.Element, "cssclass", "");
        node6.InnerText = row["CSSCLASS"].ToString();
        node1.AppendChild(node6);
        _xNode.AppendChild(node1);
        if (row["LINK_HELP"] != DBNull.Value && this.ElaborateUrl(row["LINK_HELP"].ToString(), this.menuselect) == this.menuselect)
        {
          XmlNode node3 = this._xdoc.CreateNode(XmlNodeType.Element, "expand", "");
          node3.InnerText = "true";
          _xNode.ParentNode.AppendChild(node3);
        }
        if ((!(row["TOTF"].ToString().Trim() == "") ? Convert.ToInt32(row["TOTF"].ToString()) : 0) > 0)
        {
          XmlNode node3 = this._xdoc.CreateNode(XmlNodeType.Element, "subMenu", "");
          node1.AppendChild(node3);
          this.ItemMenu(Convert.ToInt32(row["FUNZIONE_MENU_ID"]), node3);
        }
      }
    }

    private string ElaborateUrl(string UrlHelp, string UrlHelpRequest)
    {
      if (UrlHelpRequest == "")
        return (string) null;
      if (UrlHelp.Length < UrlHelpRequest.Length || UrlHelp.Length == UrlHelpRequest.Length)
        return UrlHelp;
      int startIndex = UrlHelp.Length - UrlHelpRequest.Length;
      return UrlHelp = UrlHelp.Substring(startIndex);
    }

    private DataSet GetItemMenuData(int IdMenuPadre)
    {
      HttpContext current = HttpContext.Current;
      ParameterObjectCollection objectCollection = new ParameterObjectCollection();
      ParameterObject parameterObject1 = new ParameterObject();
      parameterObject1.set_ParameterName("p_Menu_Padre_Id");
      parameterObject1.set_DbType((CustomDBType) 1);
      parameterObject1.set_Direction(ParameterDirection.Input);
      parameterObject1.set_Value((object) IdMenuPadre);
      parameterObject1.set_Index(0);
      ParameterObject parameterObject2 = new ParameterObject();
      parameterObject2.set_ParameterName("p_UserName");
      parameterObject2.set_DbType((CustomDBType) 2);
      parameterObject2.set_Direction(ParameterDirection.Input);
      if (this.Context.User.Identity.Name != "")
        parameterObject2.set_Value((object) this.Context.User.Identity.Name);
      else
        parameterObject2.set_Value((object) "admin");
      parameterObject2.set_Index(1);
      ParameterObject parameterObject3 = new ParameterObject();
      parameterObject3.set_ParameterName("IO_CURSOR");
      parameterObject3.set_DbType((CustomDBType) 8);
      parameterObject3.set_Direction(ParameterDirection.Output);
      parameterObject3.set_Index(2);
      objectCollection.Add(parameterObject1);
      objectCollection.Add(parameterObject2);
      objectCollection.Add(parameterObject3);
      return new OracleDataLayer(this.s_ConnStr).GetRows((object) objectCollection, "PACK_UTENTI.SP_MENU_UTENTI").Copy();
    }
  }
}
