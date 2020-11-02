// Decompiled with JetBrains decompiler
// Type: TheSite.GIC.Classi.ParsingViste
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Configuration;
using System.Data;

namespace TheSite.GIC.Classi
{
  public class ParsingViste
  {
    protected string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];

    public int MakeParsing_old(string NomeVista, int IdVista)
    {
      DataTable datiVista = this.GetDatiVista(NomeVista);
      Convert.ToInt32(datiVista.Rows[0][1].ToString());
      string str1 = datiVista.Rows[0][0].ToString();
      int length1 = str1.ToUpper().IndexOf("FROM");
      string[] strArray1 = str1.ToUpper().Substring(0, length1).Replace("SELECT", "").Split(',');
      DataTable table = new DataTable("DatiGl");
      this.MakeTableDatiGl(table);
      string str2 = " AS ";
      for (int index = 0; index < strArray1.Length; ++index)
      {
        int length2 = strArray1[index].Length;
        int length3 = strArray1[index].IndexOf(str2);
        string str3 = strArray1[index].Substring(0, length3);
        string str4 = strArray1[index].Substring(length3 + str2.Length, length2 - (length3 + str2.Length));
        string[] strArray2 = str3.Split('.');
        string str5 = strArray2[0].Replace("/n", "");
        strArray2[1].Replace("/n", "");
        str4.Replace("/n", "");
        string str6 = str5.Replace("/t", "");
        string str7 = strArray2[1].Replace("/t", "");
        string str8 = str4.Replace("/t", "");
        string Tabella = str6.Trim();
        string Origine = str7.Trim();
        string str9 = str8.Trim();
        DataRow row = table.NewRow();
        row["TABELLA"] = (object) Tabella;
        row["ORIGINE"] = (object) Origine;
        row["ALIAS"] = (object) str9;
        row["ID_VISTA"] = (object) IdVista;
        row["TIPODATO"] = (object) this.GetTipoDato(Tabella, Origine);
        table.Rows.Add(row);
      }
      for (int index = 0; index < table.Rows.Count; ++index)
        this.InsertGlossario(table.Rows[index]);
      return 0;
    }

    public int MakeParsing(string NomeVista, int IdVista)
    {
      DataTable schemaVista = this.GetSchemaVista(NomeVista);
      for (int index = 0; index < schemaVista.Rows.Count; ++index)
      {
        string Colonna = schemaVista.Rows[index][0].ToString();
        string tipo;
        switch (schemaVista.Rows[index][1].ToString())
        {
          case "VARCHAR2":
            tipo = "T";
            break;
          case "CHAR":
            tipo = "T";
            break;
          case "DATE":
            tipo = "D";
            break;
          case "FLOAT":
            tipo = "N";
            break;
          case "LONG":
            tipo = "N";
            break;
          case "NUMBER":
            tipo = "N";
            break;
          default:
            tipo = "T";
            break;
        }
        this.InsertGlossario(Colonna, tipo, NomeVista, IdVista);
      }
      return 0;
    }

    private int InsertGlossario(string Colonna, string tipo, string NomeVista, int IdVista)
    {
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pOrigine");
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(32);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) Colonna);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pTabella");
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Size(32);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) NomeVista);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pTipoDato");
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Size(32);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) tipo);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("pAlias");
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Size(32);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) Colonna);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("pIdVista");
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Size(32);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) IdVista.ToString());
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("pOut");
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Size(32);
      ((ParameterObject) sObject6).set_Index(5);
      controlsCollection.Add(sObject6);
      return oracleDataLayer.GetRowsAffected((object) controlsCollection, "IL_PACK_INTERROGAZIONI.InsertGlossario");
    }

    private int InsertGlossario(DataRow dr)
    {
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pOrigine");
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(32);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) dr["ORIGINE"].ToString());
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pTabella");
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Size(32);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) dr["TABELLA"].ToString());
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pTipoDato");
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Size(32);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) dr["TIPODATO"].ToString());
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("pAlias");
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Size(32);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) dr["ALIAS"].ToString());
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("pIdVista");
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Size(32);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) dr["ID_VISTA"].ToString());
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("pOut");
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Size(32);
      ((ParameterObject) sObject6).set_Index(5);
      controlsCollection.Add(sObject6);
      return oracleDataLayer.GetRowsAffected((object) controlsCollection, "IL_PACK_INTERROGAZIONI.InsertGlossario");
    }

    public int InsertSchemaUtenti(string Username, int IdSchema)
    {
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pIdSchema");
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Size(32);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) IdSchema);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pUtente");
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) Username);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pId");
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Size(32);
      ((ParameterObject) sObject3).set_Index(2);
      controlsCollection.Add(sObject3);
      return oracleDataLayer.GetRowsAffected((object) controlsCollection, "IL_PACK_INTERROGAZIONI.IL_SpInsertSchemaUtenti");
    }

    public void DeleteSchemaUtenti(S_ControlsCollection CollezioneControlli)
    {
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject).set_Value((object) DBNull.Value);
      ((ParameterObject) sObject).set_Size(32);
      CollezioneControlli.Add(sObject);
      oracleDataLayer.GetRowsAffected((object) CollezioneControlli, "IL_PACK_INTERROGAZIONI.IL_SpDelSchemaUt");
    }

    private string GetTipoDato(string Tabella, string Origine)
    {
      string appSetting = ConfigurationSettings.AppSettings["UserId"];
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pOwner");
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(32);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) appSetting);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pCampo");
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Size(32);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) Origine);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pTabella");
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Size(32);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) Tabella);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("io_cursor");
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject4).set_Index(3);
      controlsCollection.Add(sObject4);
      string str;
      switch (Convert.ToString(oracleDataLayer.ExecuteProcedure((object) controlsCollection, "IL_PACK_INTERROGAZIONI.GetTipoDato").Tables[0].Rows[0][0]))
      {
        case "VARCHAR2":
          str = "T";
          break;
        case "CHAR":
          str = "T";
          break;
        case "DATE":
          str = "D";
          break;
        case "FLOAT":
          str = "N";
          break;
        case "LONG":
          str = "N";
          break;
        case "NUMBER":
          str = "N";
          break;
        default:
          str = "T";
          break;
      }
      return str;
    }

    private int MakeTableDatiGl(DataTable table)
    {
      table.Columns.Add(new DataColumn()
      {
        DataType = Type.GetType("System.String"),
        ColumnName = "ORIGINE",
        AutoIncrement = false,
        Caption = "TABELLA",
        ReadOnly = false,
        Unique = false
      });
      table.Columns.Add(new DataColumn()
      {
        DataType = Type.GetType("System.String"),
        ColumnName = "TABELLA",
        AutoIncrement = false,
        Caption = "TABELLA",
        ReadOnly = false,
        Unique = false
      });
      table.Columns.Add(new DataColumn()
      {
        DataType = Type.GetType("System.String"),
        ColumnName = "ALIAS",
        AutoIncrement = false,
        Caption = "ALIAS",
        ReadOnly = false,
        Unique = false
      });
      table.Columns.Add(new DataColumn()
      {
        DataType = Type.GetType("System.Int32"),
        ColumnName = "ID_VISTA",
        AutoIncrement = false,
        Caption = "ID_VISTA",
        ReadOnly = false,
        Unique = false
      });
      table.Columns.Add(new DataColumn()
      {
        DataType = Type.GetType("System.String"),
        ColumnName = "TIPODATO",
        AutoIncrement = false,
        Caption = "TIPODATO",
        ReadOnly = false,
        Unique = false
      });
      return 0;
    }

    public DataSet GetDataUtenti(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "IL_PACK_INTERROGAZIONI.SP_GETUTENTI_VISTE";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    private DataTable GetDatiVista(string NomeVista)
    {
      string appSetting = ConfigurationSettings.AppSettings["UserId"];
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("Ppropprietario");
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(32);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) appSetting);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("PNomeVista");
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Size(32);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) NomeVista);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("io_cursor");
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Index(2);
      controlsCollection.Add(sObject3);
      return oracleDataLayer.ExecuteProcedure((object) controlsCollection, "IL_PACK_INTERROGAZIONI.GetBodyViste").Tables[0];
    }

    private DataTable GetSchemaVista(string NomeVista)
    {
      string appSetting = ConfigurationSettings.AppSettings["UserId"];
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pOwner");
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(32);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) appSetting);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pTabella");
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Size(32);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) NomeVista.Trim());
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("io_cursor");
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Index(2);
      controlsCollection.Add(sObject3);
      return oracleDataLayer.ExecuteProcedure((object) controlsCollection, "IL_PACK_INTERROGAZIONI.GetSchema").Tables[0];
    }
  }
}
