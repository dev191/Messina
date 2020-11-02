// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.CostiGesioneCumulativi.CostiOperativiCumulativo
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
using TheSite.SchemiXSD;

namespace TheSite.Classi.CostiGesioneCumulativi
{
  public class CostiOperativiCumulativo : AbstractBase
  {
    private string userName = "";

    public CostiOperativiCumulativo(string userName) => this.userName = userName;

    public dsRapportino ImpostaRpt(string[] arOdl)
    {
      try
      {
        RichiestaIntervento richiestaIntervento = new RichiestaIntervento(this.userName);
        dsRapportino dsRapportino = new dsRapportino();
        foreach (string s in arOdl)
        {
          bool flag = false;
          DataRow row1 = dsRapportino.Tables["MainTable"].NewRow();
          row1["WR_ID"] = (object) Convert.ToInt32(s);
          DataRow row2 = richiestaIntervento.GetSingleData(this.getWo(int.Parse(s))).Tables[0].Rows[0];
          row1["WO_ID"] = (object) Convert.ToInt32(row2["VAR_WO_WO_ID"]);
          dsRapportino.Tables["rapportoTecnicoIntervento"].ImportRow(row2);
          ClManCorrettiva clManCorrettiva = new ClManCorrettiva();
          DataTable dataTable1 = clManCorrettiva.GetListaManodopera(Convert.ToInt32(s)).Tables[0].Copy();
          dataTable1.TableName = "ListaManodopera";
          if (dataTable1.Rows.Count == 0)
          {
            DataRow row3 = dsRapportino.Tables["ListaManodopera"].NewRow();
            row3["ID"] = (object) "-1";
            row3["IdAddetto"] = (object) 0;
            row3["IdAddettoWR"] = (object) 0;
            row3["CognomeNome"] = (object) DBNull.Value;
            row3["Livello"] = (object) "<b>TOTALE</b>";
            row3["PrezzoUnitario"] = (object) DBNull.Value;
            row3["OreLavorate"] = (object) DBNull.Value;
            row3["Totale"] = (object) 0;
            row3["DescrizioneIntervento"] = (object) DBNull.Value;
            row3["WR_ID"] = (object) Convert.ToInt32(s);
            dsRapportino.Tables["ListaManodopera"].Rows.Add(row3);
            row1["HA_MANODOPERA"] = (object) "-1";
          }
          else
          {
            if (!dataTable1.Columns.Contains("WR_ID"))
              dataTable1.Columns.Add(new DataColumn()
              {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "WR_ID"
              });
            flag = true;
            row1["HA_MANODOPERA"] = (object) "1";
            foreach (DataRow row3 in (InternalDataCollectionBase) dataTable1.Rows)
            {
              row3["WR_ID"] = (object) Convert.ToInt32(s);
              dsRapportino.Tables["ListaManodopera"].ImportRow(row3);
            }
          }
          DataTable dataTable2 = clManCorrettiva.GetListaMateriali(Convert.ToInt32(s)).Tables[0].Copy();
          dataTable2.TableName = "ListaMateriali";
          if (dataTable2.Rows.Count == 0)
          {
            DataRow row3 = dsRapportino.Tables["ListaMateriali"].NewRow();
            row3["ID"] = (object) "-1";
            row3["MATERIALE"] = (object) DBNull.Value;
            row3["PREZZO_UNITARIO"] = (object) DBNull.Value;
            row3["UNITAMISURA"] = (object) "";
            row3["QUANTITA"] = (object) 0;
            row3["PREZZOTOTALE"] = (object) 0;
            row3["ID_MATERIALI"] = (object) -1;
            row3["WR_ID"] = (object) Convert.ToInt32(s);
            dsRapportino.Tables["ListaMateriali"].Rows.Add(row3);
            row1["HA_MATERIALI"] = (object) "-1";
          }
          else
          {
            if (!dataTable2.Columns.Contains("WR_ID"))
              dataTable2.Columns.Add(new DataColumn()
              {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "WR_ID"
              });
            flag = true;
            row1["HA_MATERIALI"] = (object) "1";
            foreach (DataRow row3 in (InternalDataCollectionBase) dataTable2.Rows)
            {
              row3["WR_ID"] = (object) Convert.ToInt32(s);
              dsRapportino.Tables["ListaMateriali"].ImportRow(row3);
            }
          }
          dsRapportino.Tables["MainTable"].Rows.Add(row1);
          float num1 = 0.0f;
          float num2 = 0.0f;
          if (flag)
          {
            foreach (DataRow row3 in (InternalDataCollectionBase) dsRapportino.Tables["ListaManodopera"].Rows)
            {
              if (Convert.ToInt32(row3["WR_ID"]) == Convert.ToInt32(s))
                num1 += float.Parse(Convert.ToString(row3["TOTALE"]));
            }
            foreach (DataRow row3 in (InternalDataCollectionBase) dsRapportino.Tables["ListaMateriali"].Rows)
            {
              if (Convert.ToInt32(row3["WR_ID"]) == Convert.ToInt32(s))
                num2 += float.Parse(Convert.ToString(row3["PREZZOTOTALE"]));
            }
            DataRow row4 = dsRapportino.Tables["TOTALI"].NewRow();
            row4["TotaleManodopera"] = (object) num1;
            row4["TotaleMateriali"] = (object) num2;
            row4["WR_ID"] = (object) Convert.ToInt32(s);
            dsRapportino.Tables["TOTALI"].Rows.Add(row4);
          }
          else
          {
            DataRow row3 = dsRapportino.Tables["TOTALI"].NewRow();
            row3["TotaleManodopera"] = (object) -1;
            row3["TotaleMateriali"] = (object) -1;
            row3["WR_ID"] = (object) Convert.ToInt32(s);
            dsRapportino.Tables["TOTALI"].Rows.Add(row3);
          }
        }
        return dsRapportino;
      }
      catch (Exception ex)
      {
        return (dsRapportino) null;
      }
    }

    private int getWo(int wrId)
    {
      int num = -1;
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_wr");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Value((object) wrId);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count + 1);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count + 1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "pack_CostiGestioneCumulativi.SP_GET_WOID_FROM_WRID2";
      DataSet dataSet = oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
      foreach (DataRow row in (InternalDataCollectionBase) dataSet.Tables[0].Rows)
        num = Convert.ToInt32(row["WO_ID"]);
      dataSet.Dispose();
      return num;
    }

    public override DataSet GetData() => (DataSet) null;

    public override DataSet GetData(S_ControlsCollection CollezioneControlli) => (DataSet) null;

    public override DataSet GetSingleData(int wr_id) => (DataSet) null;

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      return 0;
    }
  }
}
