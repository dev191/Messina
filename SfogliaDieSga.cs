// Decompiled with JetBrains decompiler
// Type: TheSite.SfogliaDieSga
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManCorrettiva;
using TheSite.Classi.ManStraordinaria;
using TheSite.WebControls;

namespace TheSite
{
  public class SfogliaDieSga : Page
  {
    protected ValidationSummary ValidationSummary1;
    protected S_Button cmdExcel;
    protected Button cmdReset;
    protected S_Button btnsRicerca;
    protected S_ComboBox cmbsTipoIntervento;
    protected S_ComboBox cmbsTipoManutenzione;
    protected S_TextBox txtDescrizione;
    protected S_ComboBox cmbsGruppo;
    protected S_ComboBox cmbsServizio;
    protected S_ComboBox cmbsStatus;
    protected S_TextBox txtsOrdine;
    protected S_TextBox txtsRichiesta;
    protected S_ComboBox cmbsTipoDocumenti;
    protected DataGrid DataGridRicerca;
    protected DataPanel PanelRicerca;
    protected TheSite.WebControls.Addetti Addetti1;
    protected TheSite.WebControls.Richiedenti Richiedenti1;
    protected GridTitle GridTitle1;
    public SiteModule _SiteModule;
    protected PageTitle PageTitle1;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      this.BindServizio("");
      this.BindGruppo();
      this.BindStatus();
      this.BindTipoInterventoAter();
      this.BinTipoManutenzione();
    }

    private void BinTipoManutenzione()
    {
      DataSet tipoManutenzione = new ClManCorrettiva().GetTipoManutenzione();
      if (tipoManutenzione.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsTipoManutenzione).DataSource = (object) tipoManutenzione;
      ((ListControl) this.cmbsTipoManutenzione).DataTextField = "descrizione";
      ((ListControl) this.cmbsTipoManutenzione).DataValueField = "id";
      ((Control) this.cmbsTipoManutenzione).DataBind();
      ((WebControl) this.cmbsTipoManutenzione).Attributes.Add("OnChange", "Visualizza(this.value);");
    }

    private void BindServizio(string CodEdificio)
    {
      this.GridTitle1.DescriptionTitle = "";
      this.Addetti1.Set_BL_ID(CodEdificio);
      this.DataGridRicerca.Visible = false;
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      Servizi servizi = new Servizi(this.Context.User.Identity.Name);
      DataSet data;
      if (CodEdificio != "")
      {
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) CodEdificio);
        ((ParameterObject) sObject1).set_Size(8);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_ID_Servizio");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Value((object) 0);
        CollezioneControlli.Add(sObject1);
        CollezioneControlli.Add(sObject2);
        data = servizi.GetData(CollezioneControlli);
      }
      else
        data = servizi.GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "0");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("Non Definito", "-1"));
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("Non Definito", "-1"));
    }

    private void BindGruppo()
    {
      ((ListControl) this.cmbsGruppo).Items.Clear();
      DataSet guppo = new GestioneRdl(this.Context.User.Identity.Name).GetGuppo();
      if (guppo.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsGruppo).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(guppo.Tables[0], "descrizione", "richiedenti_tipo_id", "- Selezionare un Gruppo -", "");
        ((ListControl) this.cmbsGruppo).DataTextField = "descrizione";
        ((ListControl) this.cmbsGruppo).DataValueField = "richiedenti_tipo_id";
        ((Control) this.cmbsGruppo).DataBind();
      }
      else
        ((ListControl) this.cmbsGruppo).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Gruppo -", string.Empty));
    }

    private void BindStatus()
    {
      ((ListControl) this.cmbsStatus).Items.Clear();
      DataSet status = new Richiesta().GetStatus();
      if (status.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsStatus).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(status.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Stato -", "");
        ((ListControl) this.cmbsStatus).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsStatus).DataValueField = "ID";
        ((Control) this.cmbsStatus).DataBind();
      }
      else
        ((ListControl) this.cmbsStatus).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Stato -", string.Empty));
    }

    private void BindTipoInterventoAter()
    {
      ((ListControl) this.cmbsTipoIntervento).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet data = new TipoIntervento().GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsTipoIntervento).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "descrizione_breve", "ID", "- Selezionare il Tipo Intervento -", "");
        ((ListControl) this.cmbsTipoIntervento).DataTextField = "descrizione_breve";
        ((ListControl) this.cmbsTipoIntervento).DataValueField = "id";
        ((Control) this.cmbsTipoIntervento).DataBind();
      }
      else
        ((ListControl) this.cmbsTipoIntervento).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Tipo Intervento -", string.Empty));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
