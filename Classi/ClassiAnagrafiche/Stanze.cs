// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.ClassiAnagrafiche.Stanze
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System.Collections;
using System.Data;

namespace TheSite.Classi.ClassiAnagrafiche
{
  public class Stanze : AbstractBase
  {
    private DataSet _Ds;
    private OracleDataLayer _OraDl;
    private S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

    public override DataSet GetData() => (DataSet) null;

    public override DataSet GetData(S_ControlsCollection CollezioneControlli) => (DataSet) null;

    public override DataSet GetSingleData(int itemId) => (DataSet) null;

    public DataSet GetAllDestinazioni(string descrizione)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(225);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) descrizione);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      this._OraDl = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_RM.SP_GETALLDESTINAZIONEUSO";
      this._Ds = this._OraDl.GetRows((object) controlsCollection, str).Copy();
      return this._Ds;
    }

    public DataSet GetDestinazioniMura(string descrizione)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(225);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) descrizione);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      this._OraDl = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_RM.SP_GETDESTINAZIONEMURA";
      this._Ds = this._OraDl.GetRows((object) controlsCollection, str).Copy();
      return this._Ds;
    }

    public DataSet GetAllCategoria()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(1);
      controlsCollection.Add(sObject);
      this._OraDl = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_RM.SP_GETALLCATEGORIA";
      this._Ds = this._OraDl.GetRows((object) controlsCollection, str).Copy();
      return this._Ds;
    }

    public DataSet GetAllReparto(string descrizione)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(225);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) descrizione);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      this._OraDl = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_RM.SP_GETALLREPARTO";
      this._Ds = this._OraDl.GetRows((object) controlsCollection, str).Copy();
      return this._Ds;
    }

    public DataSet GetRepartoMura(string descrizione)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(225);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) descrizione);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      this._OraDl = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_RM.SP_GETREPARTOMURA";
      this._Ds = this._OraDl.GetRows((object) controlsCollection, str).Copy();
      return this._Ds;
    }

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      return 0;
    }

    public int AddStanze(S_ControlsCollection CollezioneControlli) => this.ExecuteStanze(CollezioneControlli, ExecuteType.Insert, 0);

    public int UpdateStanze(S_ControlsCollection CollezioneControlli, int itemID) => this.ExecuteStanze(CollezioneControlli, ExecuteType.Update, itemID);

    public int DeleteStanze(S_ControlsCollection CollezioneControlli, int itemID) => this.ExecuteStanze(CollezioneControlli, ExecuteType.Delete, itemID);

    protected int ExecuteStanze(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_ID");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) itemId);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Operazione");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) Operazione.ToString());
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      CollezioneControlli.Add(sObject3);
      this._OraDl = new OracleDataLayer(this.s_ConnStr);
      return this._OraDl.GetRowsAffected((object) CollezioneControlli, "PACK_RM.SP_EXECUTEPIANISTANZE");
    }
  }
}
