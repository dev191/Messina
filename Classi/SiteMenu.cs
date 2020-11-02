// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.SiteMenu
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Xml;

namespace TheSite.Classi
{
  public class SiteMenu
  {
    private string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];

    public StringWriter GetMenu(string url)
    {
      XmlDocument xmlDocument = new XmlDocument();
      StringWriter stringWriter = new StringWriter();
      XmlTextWriter xTextWriter = new XmlTextWriter((TextWriter) stringWriter);
      xTextWriter.Formatting = Formatting.Indented;
      xTextWriter.Indentation = 2;
      xTextWriter.WriteStartDocument(true);
      xTextWriter.WriteStartElement("menu");
      this.ItemMenu(0, xTextWriter, url);
      xTextWriter.WriteEndElement();
      xTextWriter.WriteEndDocument();
      xTextWriter.Close();
      return stringWriter;
    }

    private void ItemMenu(int IdMenuPadre, XmlTextWriter xTextWriter, string url)
    {
      if (IdMenuPadre > 0)
        xTextWriter.WriteStartElement("subMenu");
      try
      {
        DataSet itemMenuData = this.GetItemMenuData(IdMenuPadre);
        if (itemMenuData.Tables[0].Rows.Count <= 0)
          return;
        Sicurezza sicurezza = new Sicurezza();
        foreach (DataRow row in (InternalDataCollectionBase) itemMenuData.Tables[0].Rows)
        {
          xTextWriter.WriteStartElement("menuItem");
          xTextWriter.WriteElementString("text", row["DESCRIZIONE"].ToString());
          if (row["LINK"] != DBNull.Value && row["LINK"].ToString() != "")
          {
            string str1 = row["FUNZIONE_ID"].ToString();
            string str2 = row["LINK"].ToString() + "?FunId=" + str1 + url;
            xTextWriter.WriteElementString(nameof (url), str2);
          }
          xTextWriter.WriteElementString("target", row["TARGET"].ToString());
          xTextWriter.WriteElementString("tooltip", row["TOOLTIP"].ToString());
          xTextWriter.WriteElementString("cssclass", row["CSSCLASS"].ToString());
          if ((!(row["TOTF"].ToString().Trim() == "") ? Convert.ToInt32(row["TOTF"].ToString()) : 0) > 0)
            this.ItemMenu(Convert.ToInt32(row["FUNZIONE_MENU_ID"]), xTextWriter, url);
          xTextWriter.WriteEndElement();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (IdMenuPadre > 0)
          xTextWriter.WriteEndElement();
      }
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
      parameterObject2.set_Value((object) current.User.Identity.Name);
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
