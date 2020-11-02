// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.Utente
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace TheSite.Classi
{
  public class Utente : AbstractBase
  {
    private string s_Name = string.Empty;
    private string username = string.Empty;

    public Utente()
    {
    }

    public Utente(int Id)
      : this(Id, string.Empty)
    {
    }

    public Utente(int Id, string Name)
    {
      this.Id = Id;
      this.Name = Name;
    }

    public Utente(string UserName) => this.username = UserName;

    public DataSet GetMap()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_UserName");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Value((object) this.username);
      ((ParameterObject) sObject1).set_Index(0);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject1);
      controlsCollection.Add(sObject2);
      return new OracleDataLayer(this.s_ConnStr).GetRows((object) controlsCollection, "PACK_UTENTI.SP_GETVISIBLEMAP").Copy();
    }

    public int Login(Page LoginPage)
    {
      S_ControlsCollection _SColl = new S_ControlsCollection();
      _SColl.AddItems((object) LoginPage.Controls);
      return this.Login(_SColl);
    }

    public int Login(S_ControlsCollection _SColl)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(2);
      _SColl.Add(sObject);
      _SColl.SortByDBIndex();
      DataSet dataSet = new OracleDataLayer(this.s_ConnStr).GetRows((object) _SColl, "PACK_UTENTI.SP_AUTENTICA_UTENTI").Copy();
      return dataSet.Tables[0].Rows.Count > 0 ? Convert.ToInt32(dataSet.Tables[0].Rows[0]["UTENTE_ID"].ToString()) : 0;
    }

    public int ChangePassword(S_ControlsCollection _SColl)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(2);
      _SColl.Add(sObject);
      return new OracleDataLayer(this.s_ConnStr).GetRowsAffected((object) _SColl, "PACK_UTENTI.SP_EXECUTECHANGEPASSWORD");
    }

    public string[] GetRuoli(string UserName)
    {
      ArrayList arrayList = new ArrayList();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_utente_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Value((object) 0);
      ((ParameterObject) sObject1).set_Index(0);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_UserName");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Value((object) UserName);
      ((ParameterObject) sObject2).set_Index(1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_Index(2);
      controlsCollection.Add(sObject1);
      controlsCollection.Add(sObject2);
      controlsCollection.Add(sObject3);
      DataSet dataSet = new OracleDataLayer(this.s_ConnStr).GetRows((object) controlsCollection, "PACK_UTENTI.SP_RUOLI_UTENTI").Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataSet.Tables[0].Rows)
          arrayList.Add((object) row["DESCRIZIONE"].ToString());
      }
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        bool flag = false;
        foreach (DataRow row in (InternalDataCollectionBase) dataSet.Tables[0].Rows)
        {
          if (row["DESCRIZIONE"].ToString().ToUpper() == "CALLCENTER" || row["DESCRIZIONE"].ToString().ToUpper() == "ADMINISTRATOR")
            flag = true;
        }
        if (!flag)
        {
          DataRow row = dataSet.Tables[0].Rows[0];
          if (row["ID_PROGETTO"].ToString() == "1")
            arrayList.Add((object) "MA");
          if (row["ID_PROGETTO"].ToString() == "2")
            arrayList.Add((object) "PA");
        }
      }
      return (string[]) arrayList.ToArray(typeof (string));
    }

    public DataSet GetRuoli(int itemId)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_utente_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Value((object) itemId);
      ((ParameterObject) sObject1).set_Index(0);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_UserName");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Value((object) " ");
      ((ParameterObject) sObject2).set_Index(1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_Index(2);
      controlsCollection.Add(sObject1);
      controlsCollection.Add(sObject2);
      controlsCollection.Add(sObject3);
      return new OracleDataLayer(this.s_ConnStr).GetRows((object) controlsCollection, "PACK_UTENTI.SP_RUOLI_UTENTI").Copy();
    }

    public string GetUserRolesFromTicket()
    {
      FormsAuthenticationTicket authenticationTicket = FormsAuthentication.Decrypt(HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value);
      string str1 = string.Empty;
      string userData = authenticationTicket.UserData;
      char[] chArray = new char[1]{ ';' };
      foreach (string str2 in userData.Split(chArray))
      {
        if (str2.Length > 0)
          str1 = str1 + "'" + str2 + "',";
      }
      return str1.Substring(0, str1.Length - 1);
    }

    public override DataSet GetData()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(0);
      controlsCollection.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_UTENTI.SP_GETALLUTENTI";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public override DataSet GetData(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_UTENTI.SP_GETUTENTI";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public DataSet GetData1(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_UTENTI.SP_GETUTENTI1";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public override DataSet GetSingleData(int itemId)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Utente_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) itemId);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_UTENTI.SP_GETSINGLEUTENTE";
      DataSet dataSet = oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
      this.Id = itemId;
      return dataSet;
    }

    public int UpdateRuoli(S_ControlsCollection CollezioneControlli, ExecuteType Operazione)
    {
      int num1 = ((CollectionBase) CollezioneControlli).Count + 1 + 1;
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_CurrentUser");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(num1);
      ((ParameterObject) sObject1).set_Value((object) HttpContext.Current.User.Identity.Name);
      int num2 = num1 + 1;
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Operazione");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(num2);
      ((ParameterObject) sObject2).set_Value((object) Operazione.ToString());
      int num3 = num2 + 1;
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_Index(num3);
      CollezioneControlli.Add(sObject1);
      CollezioneControlli.Add(sObject2);
      CollezioneControlli.Add(sObject3);
      return new OracleDataLayer(this.s_ConnStr).GetRowsAffected((object) CollezioneControlli, "PACK_UTENTI.SP_EXECUTEUTENTIRUOLI");
    }

    public string Name
    {
      get => this.s_Name;
      set => this.s_Name = value;
    }

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      int num1 = ((CollectionBase) CollezioneControlli).Count + 1;
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(num1);
      ((ParameterObject) sObject1).set_Value((object) itemId);
      int num2 = num1 + 1;
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_CurrentUser");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(num2);
      ((ParameterObject) sObject2).set_Value((object) HttpContext.Current.User.Identity.Name);
      int num3 = num2 + 1;
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Operazione");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(num3);
      ((ParameterObject) sObject3).set_Value((object) Operazione.ToString());
      int num4 = num3 + 1;
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject4).set_Index(num4);
      CollezioneControlli.Add(sObject1);
      CollezioneControlli.Add(sObject2);
      CollezioneControlli.Add(sObject3);
      CollezioneControlli.Add(sObject4);
      return new OracleDataLayer(this.s_ConnStr).GetRowsAffected((object) CollezioneControlli, "PACK_UTENTI.SP_EXECUTEUTENTI");
    }
  }
}
