// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.Fatturazione.Contabilita
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

namespace TheSite.Classi.Fatturazione
{
  public class Contabilita : AbstractBase
  {
    private string s_Servizio = string.Empty;
    private string s_Descrizione = string.Empty;
    public string UserName;

    public Contabilita(string UserName) => this.UserName = UserName;

    public Contabilita()
    {
    }

    public Contabilita(int Id)
      : this(Id, string.Empty, string.Empty)
    {
    }

    public Contabilita(int Id, string Servizio, string UserName)
    {
      this.Id = Id;
      this.Servizio = Servizio;
      this.UserName = UserName;
    }

    public string Servizio
    {
      get => this.s_Servizio;
      set => this.s_Servizio = value;
    }

    public string Descrizione
    {
      get => this.s_Descrizione;
      set => this.s_Descrizione = value;
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
      string str = "PACK_CONTABILITA.SP_GETALLFATTURE";
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
      string str = "PACK_CONTABILITA.SP_GETFATTURE";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public DataSet GetSingleRdlFatt(int itemId)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_FATTURA_ID");
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
      string str = "PACK_CONTABILITA.SP_GETWRFATTURA";
      DataSet dataSet = oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
      this.Id = itemId;
      return dataSet;
    }

    public override DataSet GetSingleData(int itemId)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_FATTURA_ID");
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
      string str = "PACK_CONTABILITA.SP_GETSINGLEFATTURA";
      DataSet dataSet = oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
      this.Id = itemId;
      return dataSet;
    }

    public DataSet GetTipoServizio()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(0);
      controlsCollection.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_CONTABILITA.SP_GETALLTIPOSERVIZIO";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetIntestatario()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(0);
      controlsCollection.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_CONTABILITA.SP_GETINTESTATARIO";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetDestinatario()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(0);
      controlsCollection.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_CONTABILITA.SP_GETDESTINATARIO";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      int count = ((CollectionBase) CollezioneControlli).Count;
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_CurrentUser");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(17);
      ((ParameterObject) sObject1).set_Value((object) HttpContext.Current.User.Identity.Name);
      int num1 = count + 1;
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Operazione");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(18);
      ((ParameterObject) sObject2).set_Value((object) Operazione.ToString());
      int num2 = num1 + 1;
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_Index(19);
      CollezioneControlli.Add(sObject1);
      CollezioneControlli.Add(sObject2);
      CollezioneControlli.Add(sObject3);
      return new OracleDataLayer(this.s_ConnStr).GetRowsAffected((object) CollezioneControlli, "PACK_CONTABILITA.SP_EXECUTEFAT");
    }
  }
}
