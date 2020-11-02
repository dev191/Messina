// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.SiteModule
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;

namespace TheSite.Classi
{
  public class SiteModule
  {
    private int i_ModuleId = 0;
    private string s_ModuleSrc = (string) null;
    private string s_ModuleTitle = (string) null;
    private bool b_IsEditable = false;
    private bool b_IsPrintable = false;
    private bool b_IsDeletable = false;
    private string s_Link = (string) null;
    private string s_HelpLink = (string) null;
    private string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];

    public SiteModule()
    {
    }

    public SiteModule(int ModuleId)
    {
      this.i_ModuleId = ModuleId;
      if (this.i_ModuleId <= 0)
        return;
      this.GetSetting();
    }

    public SiteModule(string MenuSRC)
    {
      this.s_ModuleSrc = MenuSRC.Trim();
      if (!(this.s_ModuleSrc.Trim() != ""))
        return;
      this.GetSettingPage();
    }

    public void GetSettingPage()
    {
      HttpContext current = HttpContext.Current;
      if (current.Request.Cookies[FormsAuthentication.FormsCookieName] == null)
      {
        current.Response.Cookies[FormsAuthentication.FormsCookieName].Value = (string) null;
        current.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = new DateTime(1999, 10, 12);
        current.Response.Cookies[FormsAuthentication.FormsCookieName].Path = "/";
        current.Response.Redirect(current.Request.ApplicationPath + "/Default.aspx");
        current.Response.End();
        Console.WriteLine("Entrato");
      }
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_path");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.s_ModuleSrc);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_UserName");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Index(1);
      string empty = string.Empty;
      string str1 = current.User == null ? FormsAuthentication.Decrypt(current.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name : current.User.Identity.Name;
      ((ParameterObject) sObject2).set_Value((object) str1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_Index(2);
      controlsCollection.Add(sObject1);
      controlsCollection.Add(sObject2);
      controlsCollection.Add(sObject3);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str2 = "SITO.SP_GETSETTINGS_PAGE";
      DataSet dataSet = oracleDataLayer.GetRows((object) controlsCollection, str2).Copy();
      if (dataSet.Tables[0].Rows.Count != 1)
        return;
      this.s_ModuleTitle = dataSet.Tables[0].Rows[0]["DESCRIZIONE"].ToString();
      Decimal num = (Decimal) dataSet.Tables[0].Rows[0]["ISMODIFICA"];
      this.i_ModuleId = int.Parse(dataSet.Tables[0].Rows[0]["FUNZIONE_ID"].ToString());
      this.b_IsEditable = num < 0M;
      this.b_IsPrintable = (Decimal) dataSet.Tables[0].Rows[0]["ISSTAMPA"] < 0M;
      this.b_IsDeletable = (Decimal) dataSet.Tables[0].Rows[0]["ISCANCELLAZIONE"] < 0M;
      if (dataSet.Tables[0].Rows[0]["LINK"] != DBNull.Value)
        this.s_Link = dataSet.Tables[0].Rows[0]["LINK"].ToString();
      if (dataSet.Tables[0].Rows[0]["LINK_HELP"] == DBNull.Value)
        return;
      this.s_HelpLink = ConfigurationSettings.AppSettings["LinkHelp"] + dataSet.Tables[0].Rows[0]["LINK_HELP"].ToString();
    }

    public void GetSetting()
    {
      if (this.ModuleId == 0)
        return;
      HttpContext current = HttpContext.Current;
      if (current.Request.Cookies[FormsAuthentication.FormsCookieName] == null)
      {
        current.Response.Cookies[FormsAuthentication.FormsCookieName].Value = (string) null;
        current.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = new DateTime(1999, 10, 12);
        current.Response.Cookies[FormsAuthentication.FormsCookieName].Path = "/";
        current.Response.Redirect(current.Request.ApplicationPath + "/Default.aspx");
        current.Response.End();
        Console.WriteLine("Entrato");
      }
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Funzione_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.ModuleId);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_UserName");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Index(1);
      string empty = string.Empty;
      string str1 = current.User == null ? FormsAuthentication.Decrypt(current.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name : current.User.Identity.Name;
      ((ParameterObject) sObject2).set_Value((object) str1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_Index(2);
      controlsCollection.Add(sObject1);
      controlsCollection.Add(sObject2);
      controlsCollection.Add(sObject3);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str2 = "SITO.SP_GETSETTINGS";
      DataSet dataSet = oracleDataLayer.GetRows((object) controlsCollection, str2).Copy();
      if (dataSet.Tables[0].Rows.Count != 1)
        return;
      this.s_ModuleTitle = dataSet.Tables[0].Rows[0]["DESCRIZIONE"].ToString();
      this.b_IsEditable = (Decimal) dataSet.Tables[0].Rows[0]["ISMODIFICA"] < 0M;
      this.b_IsPrintable = (Decimal) dataSet.Tables[0].Rows[0]["ISSTAMPA"] < 0M;
      this.b_IsDeletable = (Decimal) dataSet.Tables[0].Rows[0]["ISCANCELLAZIONE"] < 0M;
      if (dataSet.Tables[0].Rows[0]["LINK"] != DBNull.Value)
        this.s_Link = dataSet.Tables[0].Rows[0]["LINK"].ToString();
      if (dataSet.Tables[0].Rows[0]["LINK_HELP"] == DBNull.Value)
        return;
      this.s_HelpLink = ConfigurationSettings.AppSettings["LinkHelp"] + dataSet.Tables[0].Rows[0]["LINK_HELP"].ToString();
    }

    public int ModuleId => this.i_ModuleId;

    public string ModuleSrc => this.s_ModuleSrc;

    public string ModuleTitle => this.s_ModuleTitle;

    public bool IsEditable => this.b_IsEditable;

    public bool IsPrintable => this.b_IsPrintable;

    public bool IsDeletable => this.b_IsDeletable;

    public string Link => this.s_Link;

    public string HelpLink => this.s_HelpLink;
  }
}
