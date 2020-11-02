// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.SchedeEq.DatiShcedeEq
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Data;
using TheSite.SchemiXSD;

namespace TheSite.Classi.SchedeEq
{
  public class DatiShcedeEq : AbstractBase
  {
    private int _EqId;
    private string _MoltepliciEqId;

    public DatiShcedeEq(int CEqId) => this._EqId = CEqId;

    public DatiShcedeEq(string CMoltepliciEqId) => this._MoltepliciEqId = CMoltepliciEqId;

    public DatiShcedeEq()
    {
    }

    public override DataSet GetData() => (DataSet) null;

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      return 0;
    }

    public override DataSet GetData(S_ControlsCollection CollezioneControlli) => (DataSet) null;

    public override DataSet GetSingleData(int itemId) => (DataSet) null;

    public NewDataSet GetDsTipizzato()
    {
      NewDataSet ds = new NewDataSet();
      int[] numArray = this.ArrayEqId(this._MoltepliciEqId);
      for (int index = 0; index < numArray.Length; ++index)
        ds = this.TblMan(this.TblMan(this.TblMan(this.TblAllegati(this.TblTblPmpPassi(this.TblDatiTecnici(this.TblGenerale(ds, numArray[index]), numArray[index]), numArray[index]), numArray[index]), numArray[index], 1), numArray[index], 2), numArray[index], 3);
      return ds;
    }

    private NewDataSet TblMan(NewDataSet ds, int idEq, int TipoManutenzione)
    {
      int num1 = 0;
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("PEqId");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      S_Object sObject2 = sObject1;
      int num2 = num1;
      int num3 = num2 + 1;
      ((ParameterObject) sObject2).set_Index(num2);
      ((ParameterObject) sObject1).set_Value((object) idEq);
      controlsCollection.Add(sObject1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("PTipoManutenzione");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      S_Object sObject4 = sObject3;
      int num4 = num3;
      int num5 = num4 + 1;
      ((ParameterObject) sObject4).set_Index(num4);
      ((ParameterObject) sObject3).set_Value((object) TipoManutenzione);
      controlsCollection.Add(sObject3);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("io_cursor");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Output);
      S_Object sObject6 = sObject5;
      int num6 = num5;
      int num7 = num6 + 1;
      ((ParameterObject) sObject6).set_Index(num6);
      controlsCollection.Add(sObject5);
      DataSet dataSet = new OracleDataLayer(this.s_ConnStr).GetRows((object) controlsCollection, "PACK_SCHEDE_EQ.getInterventiEQMan").Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        switch (TipoManutenzione)
        {
          case 1:
            for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
              ds.Tables["TblManRic"].ImportRow(dataSet.Tables[0].Rows[index]);
            break;
          case 2:
            for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
              ds.Tables["TblManProg"].ImportRow(dataSet.Tables[0].Rows[index]);
            break;
          case 3:
            for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
              ds.Tables["TblManStra"].ImportRow(dataSet.Tables[0].Rows[index]);
            break;
        }
      }
      return ds;
    }

    private NewDataSet TblGenerale(NewDataSet ds, int idEq)
    {
      int num1 = 0;
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("PEqId");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      S_Object sObject2 = sObject1;
      int num2 = num1;
      int num3 = num2 + 1;
      ((ParameterObject) sObject2).set_Index(num2);
      ((ParameterObject) sObject1).set_Value((object) idEq);
      controlsCollection.Add(sObject1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("io_cursor");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      S_Object sObject4 = sObject3;
      int num4 = num3;
      int num5 = num4 + 1;
      ((ParameterObject) sObject4).set_Index(num4);
      controlsCollection.Add(sObject3);
      DataSet dataSet = new OracleDataLayer(this.s_ConnStr).GetRows((object) controlsCollection, "PACK_SCHEDE_EQ.getDatiRpt").Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
          ds.Tables[nameof (TblGenerale)].ImportRow(dataSet.Tables[0].Rows[index]);
      }
      return ds;
    }

    private NewDataSet TblDatiTecnici(NewDataSet ds, int idEq)
    {
      int num1 = 0;
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("PEqId");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      S_Object sObject2 = sObject1;
      int num2 = num1;
      int num3 = num2 + 1;
      ((ParameterObject) sObject2).set_Index(num2);
      ((ParameterObject) sObject1).set_Value((object) idEq);
      controlsCollection.Add(sObject1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("io_cursor");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      S_Object sObject4 = sObject3;
      int num4 = num3;
      int num5 = num4 + 1;
      ((ParameterObject) sObject4).set_Index(num4);
      controlsCollection.Add(sObject3);
      DataSet dataSet = new OracleDataLayer(this.s_ConnStr).GetRows((object) controlsCollection, "PACK_SCHEDE_EQ.getDatiTecnici").Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
          ds.Tables[nameof (TblDatiTecnici)].ImportRow(dataSet.Tables[0].Rows[index]);
        int count = dataSet.Tables[0].Rows.Count;
        if (count % 2 == 0)
        {
          for (int index = 0; index < count / 2; ++index)
          {
            DataRow row = ds.Tables["TblDatiTecniciEstesa"].NewRow();
            row[0] = dataSet.Tables[0].Rows[2 * index][3];
            row[1] = dataSet.Tables[0].Rows[2 * index][4];
            row[2] = dataSet.Tables[0].Rows[2 * index + 1][3];
            row[3] = dataSet.Tables[0].Rows[2 * index + 1][4];
            row[4] = dataSet.Tables[0].Rows[2 * index][1];
            ds.Tables["TblDatiTecniciEstesa"].Rows.Add(row);
          }
        }
        if (count % 2 == 1)
        {
          for (int index = 0; index < (count - 1) / 2; ++index)
          {
            DataRow row = ds.Tables["TblDatiTecniciEstesa"].NewRow();
            row[0] = dataSet.Tables[0].Rows[2 * index][3];
            row[1] = dataSet.Tables[0].Rows[2 * index][4];
            row[2] = dataSet.Tables[0].Rows[2 * index + 1][3];
            row[3] = dataSet.Tables[0].Rows[2 * index + 1][4];
            row[4] = dataSet.Tables[0].Rows[2 * index][1];
            ds.Tables["TblDatiTecniciEstesa"].Rows.Add(row);
          }
          DataRow row1 = ds.Tables["TblDatiTecniciEstesa"].NewRow();
          row1[0] = dataSet.Tables[0].Rows[count - 1][3];
          row1[1] = dataSet.Tables[0].Rows[count - 1][4];
          row1[2] = (object) "";
          row1[3] = (object) "";
          row1[4] = dataSet.Tables[0].Rows[count - 1][1];
          ds.Tables["TblDatiTecniciEstesa"].Rows.Add(row1);
        }
      }
      return ds;
    }

    private NewDataSet TblTblPmpPassi(NewDataSet ds, int idEq)
    {
      int num1 = 0;
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("PEqId");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      S_Object sObject2 = sObject1;
      int num2 = num1;
      int num3 = num2 + 1;
      ((ParameterObject) sObject2).set_Index(num2);
      ((ParameterObject) sObject1).set_Value((object) idEq);
      controlsCollection.Add(sObject1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("io_cursor");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      S_Object sObject4 = sObject3;
      int num4 = num3;
      int num5 = num4 + 1;
      ((ParameterObject) sObject4).set_Index(num4);
      controlsCollection.Add(sObject3);
      DataSet dataSet = new OracleDataLayer(this.s_ConnStr).GetRows((object) controlsCollection, "PACK_SCHEDE_EQ.getPmpPassi").Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
          ds.Tables["TblPmpPassi"].ImportRow(dataSet.Tables[0].Rows[index]);
      }
      return ds;
    }

    private NewDataSet TblAllegati(NewDataSet ds, int idEq)
    {
      int num1 = 0;
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("PEqId");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      S_Object sObject2 = sObject1;
      int num2 = num1;
      int num3 = num2 + 1;
      ((ParameterObject) sObject2).set_Index(num2);
      ((ParameterObject) sObject1).set_Value((object) idEq);
      controlsCollection.Add(sObject1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("io_cursor");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      S_Object sObject4 = sObject3;
      int num4 = num3;
      int num5 = num4 + 1;
      ((ParameterObject) sObject4).set_Index(num4);
      controlsCollection.Add(sObject3);
      DataSet dataSet = new OracleDataLayer(this.s_ConnStr).GetRows((object) controlsCollection, "PACK_SCHEDE_EQ.geteqallegati").Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
          ds.Tables[nameof (TblAllegati)].ImportRow(dataSet.Tables[0].Rows[index]);
        int count = dataSet.Tables[0].Rows.Count;
        if (count % 2 == 0)
        {
          for (int index = 0; index < count / 2; ++index)
          {
            DataRow row = ds.Tables["TblAllegatiEstesa"].NewRow();
            row[0] = dataSet.Tables[0].Rows[2 * index][1];
            row[1] = dataSet.Tables[0].Rows[2 * index][2];
            row[2] = dataSet.Tables[0].Rows[2 * index + 1][1];
            row[3] = dataSet.Tables[0].Rows[2 * index + 1][2];
            row[4] = dataSet.Tables[0].Rows[2 * index][3];
            ds.Tables["TblAllegatiEstesa"].Rows.Add(row);
          }
        }
        if (count % 2 == 1)
        {
          for (int index = 0; index < (count - 1) / 2; ++index)
          {
            DataRow row = ds.Tables["TblAllegatiEstesa"].NewRow();
            row[0] = dataSet.Tables[0].Rows[2 * index][1];
            row[1] = dataSet.Tables[0].Rows[2 * index][2];
            row[2] = dataSet.Tables[0].Rows[2 * index + 1][1];
            row[3] = dataSet.Tables[0].Rows[2 * index + 1][2];
            row[4] = dataSet.Tables[0].Rows[2 * index][3];
            ds.Tables["TblAllegatiEstesa"].Rows.Add(row);
          }
          DataRow row1 = ds.Tables["TblAllegatiEstesa"].NewRow();
          row1[0] = dataSet.Tables[0].Rows[count - 1][1];
          row1[1] = dataSet.Tables[0].Rows[count - 1][2];
          row1[2] = (object) "";
          row1[3] = (object) "";
          row1[4] = dataSet.Tables[0].Rows[count - 1][3];
          ds.Tables["TblAllegatiEstesa"].Rows.Add(row1);
        }
      }
      return ds;
    }

    private int[] ArrayEqId(string StringaEqId)
    {
      string[] strArray = StringaEqId.Split(',');
      int[] numArray = new int[strArray.Length];
      for (int index = 0; index < numArray.Length; ++index)
        numArray[index] = Convert.ToInt32(strArray[index]);
      return numArray;
    }

    public int EqId
    {
      get => this._EqId;
      set => this._EqId = value;
    }

    public string MoltepliciEqId
    {
      get => this._MoltepliciEqId;
      set => this._MoltepliciEqId = value;
    }

    private enum Manutenzione
    {
      Richiesta = 1,
      Programmata = 2,
      Straordinaria = 3,
    }
  }
}
