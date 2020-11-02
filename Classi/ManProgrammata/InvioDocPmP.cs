// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.ManProgrammata.InvioDocPmP
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;

namespace TheSite.Classi.ManProgrammata
{
  public class InvioDocPmP
  {
    protected string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];

    public int GetIdProgetto(string Bl_id)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(10);
      ((ParameterObject) sObject1).set_Value((object) Bl_id);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      controlsCollection.Add(sObject2);
      return new OracleDataLayer(this.s_ConnStr).GetRowsAffected((object) controlsCollection, "PACK_PIANI_APPROVATI.SP_GETIDPROGETTO");
    }

    public int IsValidStatus(int p_bl_id, int p_mese, int p_anno, int p_stato, string username)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName(nameof (p_bl_id));
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject1).set_Value((object) p_bl_id);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName(nameof (p_mese));
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject2).set_Value((object) p_mese);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName(nameof (p_anno));
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject3).set_Value((object) p_anno);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName(nameof (p_stato));
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject4).set_Value((object) p_stato);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_UserName");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject5).set_Size(20);
      ((ParameterObject) sObject5).set_Value((object) username);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) controlsCollection).Count);
      controlsCollection.Add(sObject6);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_PIANI_APPROVATI.SP_ISVALIDI";
      return oracleDataLayer.GetRowsAffected((object) controlsCollection, str);
    }

    public DataSet GetEdifici(string username)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_username");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject1).set_Size(20);
      ((ParameterObject) sObject1).set_Value((object) username);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_PIANI_APPROVATI.sp_getedifici";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetDestinatari(int bl_id, bool Eseguito)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_bl");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject1).set_Value((object) bl_id);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      controlsCollection.Add(sObject2);
      string str = !Eseguito ? "PACK_PIANI_APPROVATI.SP_GETDESTINATARIPROPOSTO" : "PACK_PIANI_APPROVATI.SP_GETDESTINATARIESEGUITO";
      return new OracleDataLayer(this.s_ConnStr).GetRows((object) controlsCollection, str);
    }

    public int SaveAnni(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count);
      CollezioneControlli.Add(sObject);
      return new OracleDataLayer(this.s_ConnStr).GetRowsAffected((object) CollezioneControlli, "PACK_PIANI_APPROVATI.SP_EXECUTE_PianiAnnuali");
    }

    public int SaveMesi(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count);
      CollezioneControlli.Add(sObject);
      return new OracleDataLayer(this.s_ConnStr).GetRowsAffected((object) CollezioneControlli, "PACK_PIANI_APPROVATI.SP_EXECUTE_PianiMensili");
    }

    public string GetMailByUser()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_UserName");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject1).set_Value((object) HttpContext.Current.User.Identity.Name);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      controlsCollection.Add(sObject2);
      DataSet rows = new OracleDataLayer(this.s_ConnStr).GetRows((object) controlsCollection, "PACK_PIANI_APPROVATI.SP_GETMAILBYUSER");
      return rows.Tables[0].Rows.Count > 0 ? rows.Tables[0].Rows[0][0].ToString() : "";
    }
  }
}
