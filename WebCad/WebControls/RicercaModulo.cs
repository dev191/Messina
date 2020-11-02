// Decompiled with JetBrains decompiler
// Type: WebCad.WebControls.RicercaModulo
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
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebCad.Classi;
using WebCad.Classi.ClassiDettaglio;

namespace WebCad.WebControls
{
  public class RicercaModulo : UserControl
  {
    protected S_TextBox txtsCodEdificio;
    protected Label lblDenominazione;
    protected Label lblComune;
    protected Label lblDitta;
    protected HtmlInputHidden lblEmail;
    protected Label lblIndirizzo;
    protected Label lblTelefono;
    protected Label lblCdC;
    protected Label lblBlId;
    protected HtmlInputHidden hiddenidbl;
    protected HtmlTable tbla;
    private Edificio _Edificio = new Edificio("");
    public string idTextCod;
    public string idTextRic;
    public string idModulo;
    public string multisele;
    protected Panel PanelDettagli;
    protected S_TextBox txtRicerca;
    public DelegateCodiceEdificio DelegateCodiceEdificio1;
    public DelegateIDBLEdificio DelegateIDBLEdificio1;
    protected HtmlTable tblModulo;
    public DelegateCodiceServizio DelegateCodiceServizio1;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteJavaScript.ShowFrame(this.Page, 1);
      this.idTextCod = ((Control) this.txtsCodEdificio).ClientID;
      this.idTextRic = ((Control) this.txtRicerca).ClientID;
      this.idModulo = this.ClientID;
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

    public S_TextBox TxtCodice
    {
      get => this.txtsCodEdificio;
      set => this.txtsCodEdificio = value;
    }

    public S_TextBox TxtRicerca => this.txtRicerca;

    public string BlId => this.lblBlId.Text.Length > 0 ? this.lblBlId.Text : string.Empty;

    public string Idbl => this.hiddenidbl.Value.Length > 0 ? this.hiddenidbl.Value : string.Empty;

    public string Nome => this.lblDenominazione.Text.Length > 0 ? this.lblDenominazione.Text : string.Empty;

    public Label LbLIdBL
    {
      get => this.lblBlId;
      set => this.lblBlId = value;
    }

    public HtmlInputHidden _txthidbl
    {
      get => this.hiddenidbl;
      set => this.hiddenidbl = value;
    }

    public string Indirizzo => this.lblIndirizzo.Text.Length > 0 ? this.lblIndirizzo.Text : string.Empty;

    public string Comune => this.lblComune.Text.Length > 0 ? this.lblComune.Text : string.Empty;

    public string Ditta => this.lblDitta.Text.Length > 0 ? this.lblDitta.Text : string.Empty;

    public string Telefono => this.lblTelefono.Text.Length > 0 ? this.lblTelefono.Text : string.Empty;

    public string Email => this.lblEmail.Value.Length > 0 ? this.lblEmail.Value : string.Empty;

    public string Campus => ((TextBox) this.txtRicerca).Text.Length > 0 ? ((TextBox) this.txtRicerca).Text : string.Empty;

    public string ClasseTab
    {
      get => this.ClasseTab;
      set => this.tblModulo.Attributes.Add("class", value);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((TextBox) this.txtsCodEdificio).TextChanged += new EventHandler(this.txtsCodEdificio_TextChanged);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void txtsCodEdificio_TextChanged(object sender, EventArgs e) => this.Ricarica();

    public void Ricarica()
    {
      int.Parse(ConfigurationSettings.AppSettings["edi_cod"]);
      if (((TextBox) this.txtsCodEdificio).Text.Trim().Length == 0)
      {
        this.ClearCampi();
        if (this.DelegateCodiceEdificio1 != null && ((TextBox) this.txtsCodEdificio).Text != "")
        {
          this.DelegateCodiceServizio1();
          this.DelegateCodiceEdificio1(((TextBox) this.txtsCodEdificio).Text);
        }
        if (this.DelegateIDBLEdificio1 == null)
          return;
        this.DelegateIDBLEdificio1("");
      }
      else
      {
        if (this.DelegateCodiceEdificio1 != null)
          this.DelegateCodiceEdificio1(((TextBox) this.txtsCodEdificio).Text);
        Edificio edificio = new Edificio(this.Context.User.Identity.Name);
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Size(8);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.txtsCodEdificio).Text);
        CollezioneControlli.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_Campus");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Size(50);
        ((ParameterObject) sObject2).set_Index(2);
        ((ParameterObject) sObject2).set_Value((object) "");
        CollezioneControlli.Add(sObject2);
        DataSet dataSet = edificio.GetData(CollezioneControlli).Copy();
        if (dataSet.Tables[0].Rows.Count == 1)
        {
          DataRow row = dataSet.Tables[0].Rows[0];
          if (this.DelegateIDBLEdificio1 != null)
            this.DelegateIDBLEdificio1(row["ID"].ToString());
          this.hiddenidbl.Value = row["ID"].ToString();
          this._Edificio.BlId = (string) row["BL_ID"];
          this.lblBlId.Text = this._Edificio.BlId;
          if (row["DENOMINAZIONE"] != DBNull.Value)
          {
            this._Edificio.Name = (string) row["DENOMINAZIONE"];
            this.lblDenominazione.Text = this._Edificio.Name;
          }
          if (row["INDIRIZZO"] != DBNull.Value)
          {
            this._Edificio.Address1 = (string) row["INDIRIZZO"];
            this.lblIndirizzo.Text = this._Edificio.Address1;
          }
          if (row["CAMPUS"] != DBNull.Value)
          {
            this._Edificio.Campus = (string) row["CAMPUS"];
            ((TextBox) this.txtRicerca).Text = this._Edificio.Campus;
          }
          if (row["COMUNE"] != DBNull.Value)
          {
            this._Edificio.City_Id = (string) row["COMUNE"];
            this.lblComune.Text = this._Edificio.City_Id;
          }
          if (row["REFERENTE"] != DBNull.Value)
          {
            this._Edificio.Contact_Name = (string) row["REFERENTE"];
            this.lblDitta.Text = this._Edificio.Contact_Name;
          }
          if (row["TELEFONO_REFERENTE"] != DBNull.Value)
          {
            this._Edificio.Contact_Phone = (string) row["TELEFONO_REFERENTE"];
            this.lblTelefono.Text = this._Edificio.Contact_Phone;
          }
          if (row["CENTRODICOSTO"] != DBNull.Value)
          {
            this._Edificio.Centro_Costo = (string) row["CENTRODICOSTO"];
            this.lblCdC.Text = this._Edificio.Centro_Costo;
          }
          if (row["EMAIL"] == DBNull.Value)
            return;
          this._Edificio.Option2 = (string) row["EMAIL"];
          this.lblEmail.Value = this._Edificio.Option2;
        }
        else
          this.ClearCampi();
      }
    }

    private void ClearCampi()
    {
      this.hiddenidbl.Value = string.Empty;
      this.lblBlId.Text = string.Empty;
      this.lblDenominazione.Text = string.Empty;
      this.lblIndirizzo.Text = string.Empty;
      ((TextBox) this.txtRicerca).Text = string.Empty;
      this.lblComune.Text = string.Empty;
      this.lblDitta.Text = string.Empty;
      this.lblTelefono.Text = string.Empty;
      this.lblCdC.Text = string.Empty;
      this.lblEmail.Value = string.Empty;
    }
  }
}
