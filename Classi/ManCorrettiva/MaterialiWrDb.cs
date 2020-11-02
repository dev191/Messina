// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.ManCorrettiva.MaterialiWrDb
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

namespace TheSite.Classi.ManCorrettiva
{
  public class MaterialiWrDb : AbstractBase
  {
    private int _Wr_id;
    private int _Materiali_Id;
    private int _Stato;
    private string _DataIniziale;
    private string _DataFinale;

    public MaterialiWrDb(
      int Wr_Id,
      int Materiali_Id,
      int Stato,
      string DataIniziale,
      string DataFinale)
    {
      this._Wr_id = Wr_Id;
      this._Materiali_Id = Materiali_Id;
      this._Stato = Stato;
      this._DataIniziale = DataIniziale;
      this._DataFinale = DataFinale;
    }

    public MaterialiWrDb()
    {
    }

    public int Wr_Id
    {
      get => this._Wr_id;
      set => this._Wr_id = value;
    }

    public int Materiali_Id
    {
      get => this._Materiali_Id;
      set => this._Materiali_Id = value;
    }

    public int Stato
    {
      get => this._Stato;
      set => this._Stato = value;
    }

    public string DataIniziale
    {
      get => this._DataIniziale;
      set => this._DataIniziale = value;
    }

    public string DataFinale
    {
      get => this._DataFinale;
      set => this._DataFinale = value;
    }

    public override DataSet GetData() => (DataSet) null;

    public override DataSet GetSingleData(int itemId) => (DataSet) null;

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      return 0;
    }

    public override DataSet GetData(S_ControlsCollection CollezioneControlli) => (DataSet) null;

    public GestioneMateriali GetTipizzato() => this.TblGestioneMateriali(new GestioneMateriali());

    private GestioneMateriali TblGestioneMateriali(GestioneMateriali ds)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_wrid");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject1).set_Value((object) Convert.ToInt32(this._Wr_id));
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_id_materiale");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject2).set_Value((object) Convert.ToInt32(this._Materiali_Id));
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_dataaggiornamentoDal");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject3).set_Value((object) this._DataIniziale.ToString());
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_dataaggiornamentoAl");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject4).set_Value((object) this._DataFinale.ToString());
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_stato");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size(50);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject5).set_Value((object) Convert.ToInt32(this._Stato));
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("io_cursor");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) controlsCollection).Count);
      controlsCollection.Add(sObject6);
      DataSet dataSet = new OracleDataLayer(this.s_ConnStr).GetRows((object) controlsCollection, "Pack_WrMateriali.getMateriali").Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
          ds.Tables[nameof (TblGestioneMateriali)].ImportRow(dataSet.Tables[0].Rows[index]);
      }
      return ds;
    }
  }
}
