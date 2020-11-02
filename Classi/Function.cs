// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.Function
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

namespace TheSite.Classi
{
  public class Function
  {
    private string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];
    private DataSet _Ds;

    public static void Tronca(
      string descrizione,
      int numcarvisual,
      ArrayList itmTooltip,
      int numcarvistool)
    {
      switch (numcarvistool)
      {
        case -1:
          itmTooltip[0] = (object) descrizione;
          break;
        case 0:
          itmTooltip[0] = (object) "";
          break;
        default:
          if (descrizione.Length > numcarvistool)
          {
            if (descrizione.Substring(numcarvistool) != " ")
            {
              int length = descrizione.LastIndexOf(" ", numcarvistool);
              itmTooltip[0] = (object) (descrizione.Substring(0, length).ToString() + "...");
              break;
            }
            itmTooltip[0] = (object) (descrizione.Substring(0, numcarvistool) + "...");
            break;
          }
          itmTooltip[0] = (object) descrizione;
          break;
      }
      if (descrizione.Length > numcarvisual)
      {
        if (descrizione.Substring(numcarvisual) != " ")
        {
          int length = descrizione.LastIndexOf(" ", numcarvisual);
          if (length == -1)
            return;
          itmTooltip[1] = (object) (descrizione.Substring(0, length).ToString() + "...");
        }
        else
          itmTooltip[1] = (object) (descrizione.Substring(0, numcarvisual) + "...");
      }
      else
        itmTooltip[1] = (object) descrizione;
    }

    public DataSet ControllaDuplicato(
      string tabella,
      string campo_input,
      string valore,
      string campo_output)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_tabella");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) tabella);
      ((ParameterObject) sObject1).set_Size(50);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_campo_input");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) campo_input);
      ((ParameterObject) sObject2).set_Size(50);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_valore");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) valore);
      ((ParameterObject) sObject3).set_Size(50);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_campo_output");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) campo_output);
      ((ParameterObject) sObject4).set_Size(50);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject5).set_Index(4);
      controlsCollection.Add(sObject1);
      controlsCollection.Add(sObject2);
      controlsCollection.Add(sObject3);
      controlsCollection.Add(sObject4);
      controlsCollection.Add(sObject5);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_COMMON.SP_SEARCHDUPLICATO";
      this._Ds = oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
      return this._Ds;
    }

    public DataSet ControllaDuplicatoRDL(
      string tabella,
      string campo_input,
      string valore,
      string valore2,
      string campo_output,
      string operazione)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_tabella");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) tabella);
      ((ParameterObject) sObject1).set_Size(50);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_campo_input");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) campo_input);
      ((ParameterObject) sObject2).set_Size(50);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_valore");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) valore);
      ((ParameterObject) sObject3).set_Size(50);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_valore2");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) valore2);
      ((ParameterObject) sObject4).set_Size(50);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_campo_output");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) campo_output);
      ((ParameterObject) sObject5).set_Size(50);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_operazione");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Value((object) operazione);
      ((ParameterObject) sObject6).set_Size(50);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject7).set_Index(6);
      controlsCollection.Add(sObject1);
      controlsCollection.Add(sObject2);
      controlsCollection.Add(sObject3);
      controlsCollection.Add(sObject4);
      controlsCollection.Add(sObject5);
      controlsCollection.Add(sObject6);
      controlsCollection.Add(sObject7);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_COMMON.SP_SEARCHDUPLICATORDL";
      this._Ds = oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
      return this._Ds;
    }

    public DataSet ControllaDuplicatoPeriodo(
      string tabella,
      string campo_input,
      string campo_input1,
      string valore,
      string valore1,
      string campo_output)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_tabella");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) tabella);
      ((ParameterObject) sObject1).set_Size(50);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_campo_input");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) campo_input);
      ((ParameterObject) sObject2).set_Size(50);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_campo_input1");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) campo_input1);
      ((ParameterObject) sObject3).set_Size(50);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_valore");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) valore);
      ((ParameterObject) sObject4).set_Size(50);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_valore1");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) valore);
      ((ParameterObject) sObject5).set_Size(50);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_campo_output");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Value((object) campo_output);
      ((ParameterObject) sObject6).set_Size(50);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject7).set_Index(6);
      controlsCollection.Add(sObject1);
      controlsCollection.Add(sObject2);
      controlsCollection.Add(sObject3);
      controlsCollection.Add(sObject4);
      controlsCollection.Add(sObject5);
      controlsCollection.Add(sObject6);
      controlsCollection.Add(sObject7);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_COMMON.SP_SEARCHDUPLICATOPERIODO";
      this._Ds = oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
      return this._Ds;
    }

    public DataSet GetIdBL(string bl_id)
    {
      string str1 = "select bl.id as id from bl where bl.bl_id='" + bl_id + "'";
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_sql");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(2000);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) str1);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str2 = "PACK_COMMON.SP_DYNAMIC_SELECT";
      return oracleDataLayer.GetRows((object) controlsCollection, str2).Copy();
    }

    public DataSet GetWRfromWO(int wo_id)
    {
      string str1 = "select wr.wr_id,wr.bl_id from  wr where wr.wo_id=" + (object) wo_id;
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_sql");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(2000);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) str1);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str2 = "PACK_COMMON.SP_DYNAMIC_SELECT";
      return oracleDataLayer.GetRows((object) controlsCollection, str2).Copy();
    }

    public static string GetTypeNumber(object numero, NumberType tipo)
    {
      if (double.IsNaN(double.Parse(numero.ToString())))
        return "";
      char[] charArray = ",".ToCharArray();
      string[] strArray = numero.ToString().Split(charArray);
      return strArray.Length > 1 ? (tipo == NumberType.Intero ? strArray[0] : strArray[1]) : (tipo == NumberType.Intero ? strArray[0] : "00");
    }

    public static string ImpostaMese(int mese, bool esteso)
    {
      if (esteso)
      {
        switch (mese)
        {
          case 1:
            return "Gennaio";
          case 2:
            return "Febbraio";
          case 3:
            return "Marzo";
          case 4:
            return "Aprile";
          case 5:
            return "Maggio";
          case 6:
            return "Giugno";
          case 7:
            return "Luglio";
          case 8:
            return "Agosto";
          case 9:
            return "Settembre";
          case 10:
            return "Ottobre";
          case 11:
            return "Novembre";
          case 12:
            return "Dicembre";
          default:
            return "";
        }
      }
      else
      {
        switch (mese)
        {
          case 1:
            return "Gen";
          case 2:
            return "Feb";
          case 3:
            return "Mar";
          case 4:
            return "Apr";
          case 5:
            return "Mag";
          case 6:
            return "Giu";
          case 7:
            return "Lug";
          case 8:
            return "Ago";
          case 9:
            return "Set";
          case 10:
            return "Ott";
          case 11:
            return "Nov";
          case 12:
            return "Dic";
          default:
            return "";
        }
      }
    }
  }
}
