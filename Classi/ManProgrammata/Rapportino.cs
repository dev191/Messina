// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.ManProgrammata.Rapportino
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System.Collections;
using System.Data;
using System.Web;

namespace TheSite.Classi.ManProgrammata
{
  public class Rapportino : AbstractBase
  {
    private string s_Descrizione = string.Empty;
    private OracleDataLayer _OraDl;
    public string UserName;

    public Rapportino() => this._OraDl = new OracleDataLayer(this.s_ConnStr);

    public void beginTransaction() => this._OraDl.BeginTransaction();

    public void commitTransaction() => this._OraDl.CommitTransaction();

    public void rollbackTransaction() => this._OraDl.RollbackTransaction();

    public override DataSet GetData() => (DataSet) null;

    public DataTable GetMonth(int anno)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_anno");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) anno);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_SCHEDULA.Rapportino_GetMesi";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy().Tables[0];
    }

    public DataSet GetComuni(int anno, string MeseDa, string MeseA)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Anno");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) anno);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("Mese1");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) MeseDa);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("Mese2");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Value((object) MeseA);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject4).set_Index(3);
      controlsCollection.Add(sObject4);
      string str = "PACK_SCHEDULA.Rapportino_GetComuni";
      return this._OraDl.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetEdifici(
      int anno,
      int id_comune,
      string Mese1,
      string Mese2,
      string username)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_anno");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(1);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) anno);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_comune");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(2);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) id_comune);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName(nameof (Mese1));
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(1);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Value((object) Mese1);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName(nameof (Mese2));
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(2);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Value((object) Mese2);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_username");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject5).set_Size(20);
      ((ParameterObject) sObject5).set_Value((object) username);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject6).set_Index(3);
      controlsCollection.Add(sObject6);
      string str = "PACK_SCHEDULA.Rapportino_GetEdifici";
      return this._OraDl.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetServizi(
      int anno,
      int id_comune,
      int id_edificio,
      string Mese1,
      string Mese2)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Anno");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) anno);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_comune");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) id_comune);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_edificio");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Value((object) id_edificio);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName(nameof (Mese1));
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Value((object) Mese1);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName(nameof (Mese2));
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Size(50);
      ((ParameterObject) sObject5).set_Value((object) Mese2);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_username");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(4);
      ((ParameterObject) sObject6).set_Size(50);
      ((ParameterObject) sObject6).set_Value((object) HttpContext.Current.User.Identity.Name);
      controlsCollection.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject7).set_Index(5);
      controlsCollection.Add(sObject7);
      string str = "PACK_SCHEDULA.Rapportino_GetServizi";
      return this._OraDl.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetAddetti(
      int anno,
      int id_comune,
      int id_edificio,
      int id_servizio,
      string Mese1,
      string Mese2)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Anno");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) anno);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_comune");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) id_comune);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_edificio");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) id_edificio);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_servizio");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) id_servizio);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName(nameof (Mese1));
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Size(50);
      ((ParameterObject) sObject5).set_Value((object) Mese1);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName(nameof (Mese2));
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size(50);
      ((ParameterObject) sObject6).set_Value((object) Mese2);
      controlsCollection.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_username");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(4);
      ((ParameterObject) sObject7).set_Size(50);
      ((ParameterObject) sObject7).set_Value((object) HttpContext.Current.User.Identity.Name);
      controlsCollection.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject8).set_Index(5);
      controlsCollection.Add(sObject8);
      string str = "PACK_SCHEDULA.Rapportino_GetAddetti";
      return this._OraDl.GetRows((object) controlsCollection, str).Copy();
    }

    public override DataSet GetSingleData(int itemId) => (DataSet) null;

    public override DataSet GetData(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_SCHEDULA.Rapportino_RicercaPaging";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public DataSet GetDataSel(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_SCHEDULA.Rapportino_Ricerca";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public int getCount(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_SCHEDULA.Rapportino_RicercaCount";
      return int.Parse(oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy().Tables[0].Rows[0][0].ToString());
    }

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      return 0;
    }
  }
}
