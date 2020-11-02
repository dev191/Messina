// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.ClassiAnagrafiche.Fondi
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

namespace TheSite.Classi.ClassiAnagrafiche
{
  public class Fondi : AbstractBase
  {
    private string s_Name = string.Empty;

    public Fondi()
    {
    }

    public Fondi(int Id)
      : this(Id, string.Empty)
    {
    }

    public Fondi(int Id, string Name)
    {
      this.Id = Id;
      this.Name = Name;
    }

    public override DataSet GetData() => (DataSet) null;

    public override DataSet GetData(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MS.SP_GETFONDI";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public DataSet GetAllFondi()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) controlsCollection).Count + 1);
      controlsCollection.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MS.SP_GETALLFONDO";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetFondiManutenzione(int tipoman_id)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_TIPO_MAN");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) tipoman_id);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count + 1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MS.SP_GETFONDOMANUTENZIONE";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public override DataSet GetSingleData(int itemId)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Fondo_Id");
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
      string str1 = "PACK_MS.SP_GETSINGLEFONDO";
      DataSet dataSet1 = oracleDataLayer.GetRows((object) controlsCollection, str1).Copy();
      string str2 = "PACK_MS.SP_GETMANUTENZIONEFONDO";
      DataSet dataSet2 = oracleDataLayer.GetRows((object) controlsCollection, str2).Copy();
      dataSet2.Tables[0].TableName = "tt";
      dataSet1.Tables.Add(dataSet2.Tables[0].Copy());
      this.Id = itemId;
      return dataSet1;
    }

    public int DeleteManutenzioneFondo(int fondo)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject1).set_Value((object) fondo);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Operazione");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject2).set_Value((object) "delete");
      ((ParameterObject) sObject2).set_Size(50);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) controlsCollection).Count);
      controlsCollection.Add(sObject3);
      return new OracleDataLayer(this.s_ConnStr).GetRowsAffected((object) controlsCollection, "PACK_MS.SP_EXECUTEFONDI_INTERVENTO");
    }

    public int UpdateInsertManutenzioneFondo(
      int fondo,
      ArrayList TipoIntevento,
      S_ControlsCollection Ctrl)
    {
      int num = 0;
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject1).set_Value((object) fondo);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Operazione");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject2).set_Value((object) "delete");
      ((ParameterObject) sObject2).set_Size(50);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) controlsCollection).Count);
      controlsCollection.Add(sObject3);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      try
      {
        num = oracleDataLayer.GetRowsAffected((object) controlsCollection, "PACK_MS.SP_EXECUTEFONDI_INTERVENTO");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      foreach (string s in TipoIntevento)
      {
        ((CollectionBase) controlsCollection).Clear();
        S_Object sObject4 = new S_Object();
        ((ParameterObject) sObject4).set_ParameterName("p_id");
        ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject4).set_Index(((CollectionBase) controlsCollection).Count);
        ((ParameterObject) sObject4).set_Value((object) fondo);
        controlsCollection.Add(sObject4);
        S_Object sObject5 = new S_Object();
        ((ParameterObject) sObject5).set_ParameterName("p_tipointervento");
        ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject5).set_Index(((CollectionBase) controlsCollection).Count);
        ((ParameterObject) sObject5).set_Value((object) int.Parse(s));
        controlsCollection.Add(sObject5);
        S_Object sObject6 = new S_Object();
        ((ParameterObject) sObject6).set_ParameterName("p_Operazione");
        ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject6).set_Index(((CollectionBase) controlsCollection).Count);
        ((ParameterObject) sObject6).set_Size(50);
        ((ParameterObject) sObject6).set_Value((object) "insert");
        controlsCollection.Add(sObject6);
        S_Object sObject7 = new S_Object();
        ((ParameterObject) sObject7).set_ParameterName("p_IdOut");
        ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject7).set_Direction(ParameterDirection.Output);
        ((ParameterObject) sObject7).set_Index(((CollectionBase) controlsCollection).Count);
        controlsCollection.Add(sObject7);
        num = oracleDataLayer.GetRowsAffected((object) controlsCollection, "PACK_MS.SP_EXECUTEFONDI_INTERVENTO");
      }
      return num;
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
      return new OracleDataLayer(this.s_ConnStr).GetRowsAffected((object) CollezioneControlli, "PACK_MS.SP_EXECUTEFONDI");
    }
  }
}
