// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.AnalisiStatistiche.bindCombo
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
using System.Web;
using System.Web.UI.WebControls;

namespace TheSite.Classi.AnalisiStatistiche
{
  public class bindCombo : AbstractBase
  {
    private string _nomeSoredProcedure;
    private string _tipoValue;
    private string _testoItemZero;
    private DropDownList _cmb;

    public bindCombo(string nomeSoredProcedure, DropDownList cmb, string tipoValue)
    {
      this._cmb = cmb;
      this._tipoValue = tipoValue;
      this._nomeSoredProcedure = nomeSoredProcedure;
      this._testoItemZero = "";
    }

    public override DataSet GetData() => (DataSet) null;

    public override DataSet GetData(S_ControlsCollection CollezioneControlli) => new OracleDataLayer(this.s_ConnStr).GetRows((object) CollezioneControlli, this._nomeSoredProcedure).Copy();

    public override DataSet GetSingleData(int itemId) => (DataSet) null;

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      return 0;
    }

    public void getComboBox()
    {
      DataSet dataSet = this.BindCmb(this._nomeSoredProcedure);
      DataTable table = new DataTable();
      DataColumn column1 = this.colonna("testo", "System.String");
      DataColumn column2 = this.colonna("valore", this._tipoValue);
      table.Columns.Add(column2);
      table.Columns.Add(column1);
      DataRow row1 = table.NewRow();
      row1[1] = (object) this._testoItemZero;
      switch (this._tipoValue)
      {
        case "System.String":
          row1[0] = (object) "";
          break;
        case "System.Int32":
          row1[0] = (object) 0;
          break;
        default:
          row1[0] = (object) "";
          break;
      }
      table.Rows.Add(row1);
      for (int index = 0; index <= dataSet.Tables[0].Rows.Count - 1; ++index)
      {
        DataRow row2 = table.NewRow();
        row2[0] = dataSet.Tables[0].Rows[index][0];
        row2[1] = dataSet.Tables[0].Rows[index][1];
        table.Rows.Add(row2);
      }
      DataView dataView = new DataView(table);
      this._cmb.DataTextField = "Testo";
      this._cmb.DataValueField = "Valore";
      this._cmb.DataSource = (object) dataView;
      this._cmb.DataBind();
    }

    private DataSet BindCmb(string StoredProcedure)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      if (StoredProcedure == "PACK_RPT_PIANO_MAN_PROG.GetEdifici")
      {
        S_Object sObject = new S_Object();
        ((ParameterObject) sObject).set_ParameterName("p_username");
        ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject).set_Size(50);
        ((ParameterObject) sObject).set_Value((object) HttpContext.Current.User.Identity.Name);
        ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count);
        CollezioneControlli.Add(sObject);
      }
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      CollezioneControlli.Add(sObject1);
      DataSet dataSet = new DataSet();
      return this.GetData(CollezioneControlli).Copy();
    }

    private DataColumn colonna(string nome, string tipo) => new DataColumn(nome)
    {
      DataType = Type.GetType(tipo)
    };

    public string testoItemZero
    {
      get => this._testoItemZero;
      set => this._testoItemZero = value;
    }

    public string nomeSoredProcedure
    {
      get => this._nomeSoredProcedure;
      set => this._nomeSoredProcedure = value;
    }

    public string tipoValue
    {
      get => this._tipoValue;
      set => this._tipoValue = value;
    }

    public DropDownList cmb
    {
      get => this._cmb;
      set => this._cmb = value;
    }
  }
}
