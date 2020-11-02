// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System.Collections;
using System.Data;

namespace TheSite.Classi.AnagrafeImpianti
{
  public class AnagrafeDocDWF : AbstractBase
  {
    private string username;

    public AnagrafeDocDWF(string UserName) => this.username = UserName;

    public override DataSet GetData() => (DataSet) null;

    public override DataSet GetData(S_ControlsCollection CollezioneControlli) => (DataSet) null;

    public override DataSet GetSingleData(int itemId)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_bl");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) itemId);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_id_doc");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject2).set_Value((object) 0);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_username");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Value((object) this.username);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) controlsCollection).Count + 1);
      controlsCollection.Add(sObject4);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_DWF.GETDODDWF";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetSingleData(int IdBl, int idDoc)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_bl");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) IdBl);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_id_doc");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject2).set_Value((object) idDoc);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_username");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Value((object) this.username);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) controlsCollection).Count + 1);
      controlsCollection.Add(sObject4);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_DWF.GETDODDWF";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetTipologiaFile()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_username");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) this.username);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count + 1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_DWF.GETTIPOLOGIAFILE";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetCategoriaGenerali()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_username");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) this.username);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count + 1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_DWF.GETCATEGORIEGENERALI";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetCategoria(int idCategoriaGenerale)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_cat");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) idCategoriaGenerale);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_username");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) this.username);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) controlsCollection).Count + 1);
      controlsCollection.Add(sObject3);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_DWF.GETCATEGORIE";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetTipologiaDoc(int idCategoria)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_cat");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) idCategoria);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_username");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) this.username);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) controlsCollection).Count + 1);
      controlsCollection.Add(sObject3);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_DWF.GETTIPOLOGIADOCUMENTO";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetDescrizione(int idTipoDoc)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_tip");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) idTipoDoc);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_username");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) this.username);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) controlsCollection).Count + 1);
      controlsCollection.Add(sObject3);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_DWF.GETDESCRIZIONE";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetCountDocDwf(int idBl)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_bl");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) idBl);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count + 1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_DWF.GETCOUNTDOCDWF";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet PathFileDoc(int idDOC)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_doc_dwf");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) idDOC);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count + 1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_DWF.GETPATHFILEDOCDWF";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public override int Update(S_ControlsCollection CollezioneControlli, int itemId) => base.Update(CollezioneControlli, itemId);

    public override int Delete(S_ControlsCollection CollezioneControlli, int itemId) => base.Delete(CollezioneControlli, itemId);

    public override int Add(S_ControlsCollection CollezioneControlli) => base.Add(CollezioneControlli);

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_operazione");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject1).set_Size(30);
      switch (Operazione)
      {
        case ExecuteType.Insert:
          ((ParameterObject) sObject1).set_Value((object) "INSERT");
          break;
        case ExecuteType.Update:
          ((ParameterObject) sObject1).set_Value((object) "UPDATE");
          break;
        case ExecuteType.Delete:
          ((ParameterObject) sObject1).set_Value((object) "DELETE");
          break;
      }
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Username");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject2).set_Value((object) this.username);
      ((ParameterObject) sObject2).set_Size(50);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject3);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      return Operazione == ExecuteType.Delete ? oracleDataLayer.GetRowsAffected((object) CollezioneControlli, "PACK_DWF.DELETEDOCDWF") : oracleDataLayer.GetRowsAffected((object) CollezioneControlli, "PACK_DWF.DOCDWF");
    }
  }
}
