// Decompiled with JetBrains decompiler
// Type: WebCad.Servizi
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

namespace WebCad
{
  public class Servizi
  {
    protected string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];

    public DataSet GetServiziEdifici(int bl_id)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_bl");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) bl_id);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_id_servizio");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) 0);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_Index(2);
      controlsCollection.Add(sObject1);
      controlsCollection.Add(sObject2);
      controlsCollection.Add(sObject3);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_CAD.SP_GETSERVIZIEDIFICI";
      return oracleDataLayer.GetRows((object) controlsCollection, str);
    }

    public DataSet GetStanzeBuilding(int id_bl, int id_piano, string descrizione)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) id_bl);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_piano");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) id_piano);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("descr");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(200);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) descrizione);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject4).set_Index(3);
      controlsCollection.Add(sObject4);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_CAD.SP_STANZE_EDIFICIO";
      return oracleDataLayer.GetRows((object) controlsCollection, str);
    }

    public DataSet GetAllEQSTD(int idBl, int idFl, int IdServio, string descrizione)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) idBl);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_fl_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) idFl);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pServizioId");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) IdServio);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_descr");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(200);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) descrizione);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject5).set_Index(4);
      controlsCollection.Add(sObject5);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_CAD.SP_GETALLEQSTD";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetEQ(int id_bl, int id_corpo, int id_stanza, int id_eq)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) id_bl);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_stanza");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) id_stanza);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_corpo");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) id_corpo);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_eq_id");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) id_eq);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject5).set_Index(4);
      controlsCollection.Add(sObject5);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_CAD.SP_GETEQ";
      return oracleDataLayer.GetRows((object) controlsCollection, str);
    }

    public DataSet GetRM(int id_bl, int id_corpo, int id_stanza)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject1).set_Value((object) id_bl);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_stanza");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject2).set_Value((object) id_stanza);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_corpo");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject3).set_Value((object) id_corpo);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) controlsCollection).Count);
      controlsCollection.Add(sObject4);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_CAD.SP_GETRM";
      return oracleDataLayer.GetRows((object) controlsCollection, str);
    }

    public DataSet GetBL(int id_bl)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject1).set_Value((object) id_bl);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_CAD.SP_GETBL";
      return oracleDataLayer.GetRows((object) controlsCollection, str);
    }
  }
}
