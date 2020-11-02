// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.RicercaRDL
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManOrdinaria;

namespace TheSite.WebControls
{
  public class RicercaRDL : UserControl
  {
    public string idTextCod;
    public string idTextRic;
    public string idTextRicA;
    public string idModulo;
    public string operazione;
    public string multisele;
    protected Panel PanelDettagli;
    protected S_TextBox txtsRDL;
    protected HtmlInputHidden hiddenidRDL;
    public DelegateCodiceRDL DelegateCodiceRDL1;
    protected CompareValidator CompareValidator1;
    public DelegateIDRDL DelegateIDRDL1;
    protected CalendarPicker CalendarPicker1;
    protected CalendarPicker CalendarPicker2;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteJavaScript.ShowFrameRDL(this.Page, 1);
      this.idTextCod = ((Control) this.txtsRDL).ClientID;
      this.idTextRic = ((Control) this.CalendarPicker1.Datazione).ClientID;
      this.idTextRicA = ((Control) this.CalendarPicker2.Datazione).ClientID;
      this.idModulo = this.ClientID;
      if (this.IsPostBack)
        return;
      this.Ricarica();
      this.CompareValidator1.ControlToValidate = this.CalendarPicker2.ID + ":" + ((Control) this.CalendarPicker2.Datazione).ID;
      this.CompareValidator1.ControlToCompare = this.CalendarPicker1.ID + ":" + ((Control) this.CalendarPicker1.Datazione).ID;
    }

    public string opera
    {
      get => this.operazione;
      set => this.operazione = value;
    }

    public string NameComboMan
    {
      get => this.ViewState["cmbsServizio"] == null ? string.Empty : (string) this.ViewState["cmbsServizio"];
      set => this.ViewState["cmbsServizio"] = (object) value;
    }

    public string TipoMan
    {
      get => this.ViewState[nameof (TipoMan)] == null ? string.Empty : (string) this.ViewState[nameof (TipoMan)];
      set => this.ViewState[nameof (TipoMan)] = (object) value;
    }

    public string multiselect
    {
      get => this.multisele;
      set => this.multisele = value;
    }

    public bool visualizzadettagli
    {
      get => this.PanelDettagli.Visible;
      set => this.PanelDettagli.Visible = value;
    }

    public S_TextBox TxtRicerca => this.CalendarPicker1.Datazione;

    public string IdRDL => this.hiddenidRDL.Value.Length > 0 ? this.hiddenidRDL.Value : string.Empty;

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((TextBox) this.txtsRDL).TextChanged += new EventHandler(this.txtsRDL_TextChanged);
      this.Load += new EventHandler(this.Page_Load);
    }

    public void Ricarica()
    {
      int num = int.Parse(ConfigurationSettings.AppSettings["edi_cod"]);
      if (((TextBox) this.txtsRDL).Text.Trim().Length != num && ((TextBox) this.txtsRDL).Text.Trim().Length > 0)
        return;
      if (((TextBox) this.txtsRDL).Text.Trim().Length == 0)
      {
        this.ClearCampi();
        if (this.DelegateCodiceRDL1 != null)
          this.DelegateCodiceRDL1(((TextBox) this.txtsRDL).Text);
        if (this.DelegateIDRDL1 == null)
          return;
        this.DelegateIDRDL1("");
      }
      else
      {
        if (this.DelegateCodiceRDL1 != null)
          this.DelegateCodiceRDL1(((TextBox) this.txtsRDL).Text);
        GestioneRdl gestioneRdl = new GestioneRdl(HttpContext.Current.User.Identity.Name);
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject = new S_Object();
        ((ParameterObject) sObject).set_ParameterName("p_wr_id");
        ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject).set_Size(50);
        ((ParameterObject) sObject).set_Index(0);
        ((ParameterObject) sObject).set_Value((object) ((TextBox) this.txtsRDL).Text);
        CollezioneControlli.Add(sObject);
        DataSet dataSet = gestioneRdl.GetRDL1(CollezioneControlli).Copy();
        if (dataSet.Tables[0].Rows.Count == 1)
        {
          DataRow row = dataSet.Tables[0].Rows[0];
          if (this.DelegateIDRDL1 != null)
            this.DelegateIDRDL1(row["ID"].ToString());
          this.hiddenidRDL.Value = row["ID"].ToString();
          if (row["descrizione"] == DBNull.Value)
            return;
          ((TextBox) this.CalendarPicker1.Datazione).Text = (string) row["descrizione"];
        }
        else
          this.ClearCampi();
      }
    }

    private void ClearCampi()
    {
      this.hiddenidRDL.Value = string.Empty;
      ((TextBox) this.CalendarPicker1.Datazione).Text = string.Empty;
      ((TextBox) this.CalendarPicker2.Datazione).Text = string.Empty;
    }

    private void txtsRDL_TextChanged(object sender, EventArgs e) => this.Ricarica();
  }
}
