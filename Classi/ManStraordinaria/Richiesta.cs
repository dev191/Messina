// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.ManStraordinaria.Richiesta
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
using TheSite.Classi.ClassiDettaglio;

namespace TheSite.Classi.ManStraordinaria
{
  public class Richiesta : AbstractBase
  {
    public Richiesta()
    {
    }

    public Richiesta(int Id) => this.Id = Id;

    public override DataSet GetData() => (DataSet) null;

    public override DataSet GetData(S_ControlsCollection CollezioneControlli) => (DataSet) null;

    public override DataSet GetSingleData(int itemId)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Wr_Id");
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
      string str = "PACK_MAN_STRA.SP_GETSINGLERICHIESTA";
      DataSet dataSet = oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
      this.Id = itemId;
      return dataSet;
    }

    public int Crea(S_ControlsCollection CollezioneControlli)
    {
      int num1 = ((CollectionBase) CollezioneControlli).Count + 1;
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_CurrentUser");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(num1);
      ((ParameterObject) sObject1).set_Value((object) HttpContext.Current.User.Identity.Name);
      int num2 = num1 + 1;
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(num2);
      CollezioneControlli.Add(sObject1);
      CollezioneControlli.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MAN_STRA.SP_CREA";
      return oracleDataLayer.GetRowsAffected((object) CollezioneControlli, str);
    }

    public bool IsValidBlId(string BlId)
    {
      string name = HttpContext.Current.User.Identity.Name;
      Edificio edificio = new Edificio(name);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(8);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) BlId);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_UserName");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) name);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Campus");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(128);
      ((ParameterObject) sObject3).set_Value((object) "");
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject4).set_Index(3);
      controlsCollection.Add(sObject1);
      controlsCollection.Add(sObject2);
      controlsCollection.Add(sObject3);
      controlsCollection.Add(sObject4);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_EDIFICI.SP_GETEDIFICI";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Tables[0].Rows.Count == 1;
    }

    public DataSet GetListaRDL(S_ControlsCollection CollezioneControlli, string utente)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_utente");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) utente);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MAN_STRA.SP_GetListaRDL";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public DataSet GetStatusRdl(int wr_id)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Wr_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) wr_id);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count + 1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MAN_STRA.SP_GETSTATUSRDL";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetAllTipoTrasmissione()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(1);
      controlsCollection.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_COMMON.SP_GETALLTIPOTRASMISSIONE";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetSingleRdl(int itemId)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Wr_Id");
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
      string str = "PACK_MAN_STRA.SP_GETSINGLERDL";
      DataSet dataSet = oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
      this.Id = itemId;
      return dataSet;
    }

    public DataSet GetSingleRdlLabel(int itemId)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Wr_Id");
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
      string str = "PACK_ELIMINA_RDL.SP_GETSINGLERDL";
      DataSet dataSet = oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
      this.Id = itemId;
      return dataSet;
    }

    public DataSet GetRDLNonEmesse(string bl_id)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) bl_id);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(0);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MAN_STRA.SP_GetRDLNonEmesse";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetRDLApprovate(string bl_id)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) bl_id);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(0);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MAN_STRA.SP_GetRDLApprovate";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetStatus()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_sql");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(2000);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) "Select id_status as ID, status_desc as DESCRIZIONE from wr_status where in_ord=1");
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_COMMON.SP_DYNAMIC_SELECT";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetStatusAccorpa()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_sql");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(2000);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) "Select id_status as ID, status_desc as DESCRIZIONE from wr_status where in_gest=1");
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_COMMON.SP_DYNAMIC_SELECT";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetStatusAnalisi()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_sql");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(2000);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) "Select id_status as ID, status_desc as DESCRIZIONE from wr_status where in_str=1");
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_COMMON.SP_DYNAMIC_SELECT";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetAddetti(string NomeCompleto, string BL_ID)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_NomeCompleto");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) NomeCompleto);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) BL_ID);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_UserName");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) HttpContext.Current.User.Identity.Name);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject4).set_Index(3);
      controlsCollection.Add(sObject4);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MAN_STRA.SP_GetAddetti";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetAddetti(string NomeCompleto, string BL_ID, int ditta_id)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_NomeCompleto");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) NomeCompleto);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) BL_ID);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_ditta_id");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) ditta_id);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_UserName");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) HttpContext.Current.User.Identity.Name);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject5).set_Index(4);
      controlsCollection.Add(sObject5);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_ADDETTI.SP_GETADDETTORUOLO";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetRichiedenti(string NomeCompleto)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_NomeCompleto");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) NomeCompleto);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MAN_STRA.SP_GetRichiedenti";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetSfogliaRDL(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_utente");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) HttpContext.Current.User.Identity.Name);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MAN_STRA.SP_GetSfogliaRDL";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public DataSet GetSfogliaRDLCount(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_utente");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) HttpContext.Current.User.Identity.Name);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MAN_STRA.SP_GetSfogliaRDLCount";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public DataSet GetSfogliaRDLDaEliminare(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_utente");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) HttpContext.Current.User.Identity.Name);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_ELIMINA_RDL.SP_GetSfogliaRDL";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public DataSet GetSfogliaRDLDaEliminareCount(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_utente");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) HttpContext.Current.User.Identity.Name);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_ELIMINA_RDL.SP_GetSfogliaRDLCount";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public int EmettiRdl(ParamRichiesta parametri)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Wr_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) parametri.wr_id);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_stato");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) (int) parametri.status_id);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_CurrentUser");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) parametri.utente);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_urgenza");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) parametri.urgenza_id);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_richiedente");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) parametri.richiedente);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size(4000);
      ((ParameterObject) sObject6).set_Value((object) parametri.descrizione);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_datapianificata");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Size(30);
      ((ParameterObject) sObject7).set_Value((object) parametri.data_pianificata);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_servizio_id");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Value((object) parametri.servizio_id);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_trasmissione_id");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(8);
      ((ParameterObject) sObject9).set_Value((object) parametri.trasmissione_id);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_manutenzione_id");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(9);
      ((ParameterObject) sObject10).set_Value((object) parametri.tipo_mautenzione_id);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(10);
      ((ParameterObject) sObject11).set_Value((object) parametri.bl_id);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_addetto_id");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(11);
      ((ParameterObject) sObject12).set_Value((object) parametri.addetto_id);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_id_ditta");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(12);
      ((ParameterObject) sObject13).set_Value((object) parametri.id_ditta);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("p_stdApparecchiatura_id");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(13);
      ((ParameterObject) sObject14).set_Value((object) parametri.stdApparecchiatura_id);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("p_eq_id");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Index(14);
      ((ParameterObject) sObject15).set_Value((object) parametri.eq_id);
      S_Object sObject16 = new S_Object();
      ((ParameterObject) sObject16).set_ParameterName("p_tipointervento");
      ((ParameterObject) sObject16).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject16).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject16).set_Index(15);
      ((ParameterObject) sObject16).set_Value((object) parametri.tipoInterventoAter);
      S_Object sObject17 = new S_Object();
      ((ParameterObject) sObject17).set_ParameterName("p_numeropreventivo");
      ((ParameterObject) sObject17).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject17).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject17).set_Index(16);
      ((ParameterObject) sObject17).set_Size(8);
      ((ParameterObject) sObject17).set_Value((object) parametri.numero_preventivo);
      S_Object sObject18 = new S_Object();
      ((ParameterObject) sObject18).set_ParameterName("p_importopreventivo");
      ((ParameterObject) sObject18).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject18).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject18).set_Index(17);
      ((ParameterObject) sObject18).set_Value((object) double.Parse(parametri.importo_preventivo));
      S_Object sObject19 = new S_Object();
      ((ParameterObject) sObject19).set_ParameterName("p_pdfpreventivo");
      ((ParameterObject) sObject19).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject19).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject19).set_Index(18);
      ((ParameterObject) sObject19).set_Size(250);
      ((ParameterObject) sObject19).set_Value((object) parametri.PdfPreventivo);
      S_Object sObject20 = new S_Object();
      ((ParameterObject) sObject20).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject20).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject20).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject20).set_Index(19);
      controlsCollection.Add(sObject1);
      controlsCollection.Add(sObject2);
      controlsCollection.Add(sObject3);
      controlsCollection.Add(sObject4);
      controlsCollection.Add(sObject5);
      controlsCollection.Add(sObject6);
      controlsCollection.Add(sObject7);
      controlsCollection.Add(sObject8);
      controlsCollection.Add(sObject9);
      controlsCollection.Add(sObject10);
      controlsCollection.Add(sObject11);
      controlsCollection.Add(sObject12);
      controlsCollection.Add(sObject13);
      controlsCollection.Add(sObject14);
      controlsCollection.Add(sObject15);
      controlsCollection.Add(sObject16);
      controlsCollection.Add(sObject17);
      controlsCollection.Add(sObject18);
      controlsCollection.Add(sObject19);
      controlsCollection.Add(sObject20);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      int num = 0;
      switch (parametri.status_id)
      {
        case StateType.EmessaInLavorazione:
          num = oracleDataLayer.GetRowsAffected((object) controlsCollection, "PACK_EMETTI_RDL_STR.SP_EMETTI");
          break;
        case StateType.RichiestaRifiutata:
          num = oracleDataLayer.GetRowsAffected((object) controlsCollection, "PACK_EMETTI_RDL_STR.SP_RIFIUTA");
          break;
        case StateType.RichiestaSospesa:
          num = oracleDataLayer.GetRowsAffected((object) controlsCollection, "PACK_EMETTI_RDL_STR.SP_SOSPENDI");
          break;
      }
      return num;
    }

    public DataSet GetAnalisiRDL(S_ControlsCollection CollezioneControlli, string utente)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_CurrentUser");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) utente);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MAN_STRA.SP_GETANALISIRDL";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public DataSet GetHWR(S_ControlsCollection CollezioneControlli, string utente)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MAN_STRA.SP_GETHWR";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public DataSet GetRapportino(int wr_id)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_wr_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) wr_id);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MAN_STRA.SP_GETRAPPORTINO";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public int DeleteRdL(S_ControlsCollection CollezioneControlli)
    {
      int count = ((CollectionBase) CollezioneControlli).Count;
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_Id_Out");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(count);
      CollezioneControlli.Add(sObject);
      return new OracleDataLayer(this.s_ConnStr).GetRowsAffected((object) CollezioneControlli, "PACK_ELIMINA_RDL.SP_DELETERDL");
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
      return new OracleDataLayer(this.s_ConnStr).GetRowsAffected((object) CollezioneControlli, "PACK_FUNZIONI.SP_EXECUTEFUNZIONI");
    }
  }
}
