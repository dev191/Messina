// Decompiled with JetBrains decompiler
// Type: TheSite.SoddisfazioneCliente.KPI
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi.SoddCliente;
using TheSite.WebControls;

namespace TheSite.SoddisfazioneCliente
{
  public class KPI : Page
  {
    protected DropDownList DrPriorita;
    protected DropDownList DropAnno;
    protected S_Button btnsRicerca;
    protected S_Button btnReset;
    protected Repeater Repeater1;
    protected DropDownList DrMese;
    protected Repeater Repeater2;
    protected Repeater Repeater3;
    protected RicercaModulo RicercaModulo1;
    protected HtmlTable tblFuoriSLA;
    protected HtmlTable tblTotAtt;
    protected HtmlTable TabXLS;
    protected Repeater RepeaterREI;
    protected Repeater RepeaterXls;
    protected HtmlTable TabREI;
    protected HtmlTable tblPianiMens;
    public string TPriorita = "";
    public int Twr_pres;
    public int Twr_no_pres;
    public int Twr_tot;
    public int TfuoriSLA;
    public double Trisultato;
    public string TPriorita1 = "";
    public int Twr_pres1;
    public int Twr_no_pres1;
    public int Twr_tot1;
    public int TfuoriSLA1;
    public double Trisultato1;
    public string TPriorita2 = "";
    public int Twr_pres2;
    public int Twr_no_pres2;
    public int Twr_tot2;
    public int TfuoriSLA2;
    public double Trisultato2;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      this.LoadAnno();
      this.clearRep();
    }

    private void clearRep()
    {
      this.tblTotAtt.Visible = false;
      this.tblFuoriSLA.Visible = false;
      this.tblPianiMens.Visible = false;
      this.TabREI.Visible = false;
      this.TabXLS.Visible = false;
    }

    private void LoadAnno()
    {
      for (int index = 2008; index <= 2020; ++index)
        this.DropAnno.Items.Add(new ListItem(index.ToString(), index.ToString()));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.RicercaFuoriSLA();
      this.RicercaPiani();
      this.ContaAttivita();
      this.RicercaREI();
      this.RicercaXLS();
    }

    private void RicercaFuoriSLA()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_priorita");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) Convert.ToInt32(this.DrPriorita.SelectedValue));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_mese");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Size(2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) this.DrMese.SelectedValue);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_anno");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Size(4);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) this.DropAnno.SelectedValue);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_idbl");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Size(4);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Value((object) this.RicercaModulo1.BlId);
      CollezioneControlli.Add(sObject4);
      DataSet kpi = new Soddisfato().GetKPI(CollezioneControlli);
      foreach (DataRow row in (InternalDataCollectionBase) kpi.Tables[0].Rows)
      {
        switch (row["priorita"].ToString())
        {
          case "Emergenza (2 ore)":
            this.TPriorita = "Tot " + row["priorita"].ToString();
            this.Twr_pres += Convert.ToInt32(row["wr_pres"]);
            this.Twr_no_pres += Convert.ToInt32(row["wr_no_pres"]);
            this.Twr_tot += Convert.ToInt32(row["wr_tot"]);
            this.TfuoriSLA += Convert.ToInt32(row["fuoriSLA"]);
            continue;
          case "Critico (4 ore)":
            this.TPriorita1 = "Tot " + row["priorita"].ToString();
            this.Twr_pres1 += Convert.ToInt32(row["wr_pres"]);
            this.Twr_no_pres1 += Convert.ToInt32(row["wr_no_pres"]);
            this.Twr_tot1 += Convert.ToInt32(row["wr_tot"]);
            this.TfuoriSLA1 += Convert.ToInt32(row["fuoriSLA"]);
            continue;
          case "Urgente (10 ore)":
            this.TPriorita2 = "Tot " + row["priorita"].ToString();
            this.Twr_pres2 += Convert.ToInt32(row["wr_pres"]);
            this.Twr_no_pres2 += Convert.ToInt32(row["wr_no_pres"]);
            this.Twr_tot2 += Convert.ToInt32(row["wr_tot"]);
            this.TfuoriSLA2 += Convert.ToInt32(row["fuoriSLA"]);
            continue;
          default:
            continue;
        }
      }
      this.Trisultato = this.TfuoriSLA == 0 ? 100.0 : Math.Round(1.0 - Convert.ToDouble(this.TfuoriSLA) / Convert.ToDouble(this.Twr_tot), 1) * 100.0;
      this.Trisultato1 = this.TfuoriSLA1 == 0 ? 100.0 : Math.Round(1.0 - Convert.ToDouble(this.TfuoriSLA1) / Convert.ToDouble(this.Twr_tot1), 1) * 100.0;
      this.Trisultato2 = this.TfuoriSLA2 == 0 ? 100.0 : Math.Round(1.0 - Convert.ToDouble(this.TfuoriSLA2) / Convert.ToDouble(this.Twr_tot2), 1) * 100.0;
      if (kpi.Tables[0].Rows.Count == 0)
        return;
      this.Repeater1.DataSource = (object) kpi;
      this.Repeater1.DataBind();
      this.tblFuoriSLA.Visible = true;
    }

    private void RicercaPiani()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_mese");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) this.DrMese.SelectedValue);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_anno");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Size(4);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) this.DropAnno.SelectedValue);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_idbl");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Size(4);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) this.RicercaModulo1.BlId);
      CollezioneControlli.Add(sObject3);
      DataSet pianiMensili = new Soddisfato().GetPianiMensili(CollezioneControlli);
      if (pianiMensili.Tables[0].Rows.Count == 0)
        return;
      this.Repeater2.DataSource = (object) pianiMensili;
      this.Repeater2.DataBind();
      this.tblPianiMens.Visible = true;
    }

    private void RicercaREI()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_mese");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) this.DrMese.SelectedValue);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_anno");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Size(4);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) this.DropAnno.SelectedValue);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_idbl");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Size(4);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) this.RicercaModulo1.BlId);
      CollezioneControlli.Add(sObject3);
      DataSet rei = new Soddisfato().GetREI(CollezioneControlli);
      if (rei.Tables[0].Rows.Count == 0)
        return;
      this.RepeaterREI.DataSource = (object) rei;
      this.RepeaterREI.DataBind();
      this.TabREI.Visible = true;
    }

    private void RicercaXLS()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_mese");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) this.DrMese.SelectedValue);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_anno");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Size(4);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) this.DropAnno.SelectedValue);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_idbl");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Size(4);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) this.RicercaModulo1.BlId);
      CollezioneControlli.Add(sObject3);
      DataSet xls = new Soddisfato().GetXls(CollezioneControlli);
      if (xls.Tables[0].Rows.Count == 0)
        return;
      this.RepeaterXls.DataSource = (object) xls;
      this.RepeaterXls.DataBind();
      this.TabXLS.Visible = true;
    }

    public double RisultatoKPI(object TotWrSla, object TotWr) => Math.Round(1.0 - Convert.ToDouble(TotWrSla) / Convert.ToDouble(TotWr), 1) * 100.0;

    public double Risultato(object PP1, object PPOL1, object PE1, object PEOL1)
    {
      double num1 = Convert.ToDouble(PP1);
      double num2 = Convert.ToDouble(PPOL1);
      double num3 = Convert.ToDouble(PE1);
      double num4 = Convert.ToDouble(PEOL1);
      return Math.Round((1.0 - (num2 + num4) / (num1 + num3)) * 100.0, 1);
    }

    public double RisSlittamento(object PP1, object PPOL1)
    {
      double num1 = Convert.ToDouble(PP1);
      double num2 = Convert.ToDouble(PPOL1);
      return num1 != 0.0 ? Math.Round(num1 / num2 * 100.0, 1) : 100.0;
    }

    public double RisSlittamentoEnto10(object TotAtt, object neiTempi, object nei10g)
    {
      double num1 = Convert.ToDouble(TotAtt);
      double num2 = Convert.ToDouble(neiTempi);
      double num3 = Convert.ToDouble(nei10g);
      double num4 = 0.0;
      if (num1 == 0.0)
        num4 = 100.0;
      else if (num2 != 0.0)
      {
        if (num1 / num2 >= 98.0 && num3 / num1 <= 2.0 && num1 - num3 == 0.0)
          num4 = Math.Round(num2 / num1, 1);
      }
      else
        num4 = 0.0;
      return num4;
    }

    public double RisRei(object TotRei, object TotSla)
    {
      double num1 = Convert.ToDouble(TotRei);
      double num2 = Convert.ToDouble(TotSla);
      return num1 != 0.0 ? (num2 == 0.0 ? 0.0 : Math.Round((1.0 - num1 / num2) * 100.0, 1)) : 100.0;
    }

    private void ContaAttivita()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_mese");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) this.DrMese.SelectedValue);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_anno");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Size(4);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) this.DropAnno.SelectedValue);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_idbl");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Size(4);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) this.RicercaModulo1.BlId);
      CollezioneControlli.Add(sObject3);
      this.Repeater3.DataSource = (object) new Soddisfato().numAttivita(CollezioneControlli);
      this.Repeater3.DataBind();
      this.tblTotAtt.Visible = true;
    }
  }
}
