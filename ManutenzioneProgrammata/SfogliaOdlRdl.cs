// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.SfogliaOdlRdl
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManProgrammata;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class SfogliaOdlRdl : Page
  {
    protected S_ComboBox cmbsAnnoDa;
    protected S_ComboBox cmbsAnnoA;
    protected S_ComboBox cmbsMeseA;
    protected S_ComboBox cmbsDitta;
    protected S_ComboBox cmbsServizio;
    protected S_TextBox txtDescrizione;
    protected S_TextBox txtRichiestaLavoro;
    protected S_TextBox txtOrdineLavoro;
    protected S_ComboBox cmbsStdApparecchiature;
    protected DataGrid DataGrid1;
    protected S_ComboBox cmbsMeseDa;
    protected RicercaModulo RicercaModulo1;
    protected TheSite.WebControls.Addetti Addetti1;
    protected PageTitle PageTitle1;
    protected GridTitle GridTitle1;
    protected CodiceApparecchiature CodiceApparecchiature1;
    public static int FunId = 0;
    protected DataPanel DataPanel1;
    protected S_Button btRicerca;
    protected S_Button btUltimo;
    protected S_Button btReset;
    protected S_ComboBox cmbsstatolavoro;
    public static string HelpLink = string.Empty;
    private clMyCollection _myColl = new clMyCollection();
    private SfogliaRdlOdl_MP _fp = (SfogliaRdlOdl_MP) null;
    protected S_ComboBox cmbsstatolavoro_odl;
    private CompletamentoMP _fp2 = (CompletamentoMP) null;
    public bool completare = false;

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      SfogliaOdlRdl.FunId = siteModule.ModuleId;
      SfogliaOdlRdl.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      ((WebControl) this.txtRichiestaLavoro).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtRichiestaLavoro).Attributes.Add("onpaste", "return nonpaste();");
      ((WebControl) this.txtOrdineLavoro).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtOrdineLavoro).Attributes.Add("onpaste", "return nonpaste();");
      this.RicercaModulo1.DelegateCodiceEdificio1 = new DelegateCodiceEdificio(this.BindServizi);
      this.CodiceApparecchiature1.NameComboApparecchiature = "cmbsStdApparecchiature";
      this.CodiceApparecchiature1.NameComboServizio = "cmbsServizio";
      this.CodiceApparecchiature1.NameUserControlRicercaModulo = "RicercaModulo1";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("this.value = 'Attendere ...';");
      stringBuilder.Append("this.disabled = true;");
      stringBuilder.Append("document.getElementById('" + ((Control) this.btRicerca).ClientID + "').disabled = true;");
      stringBuilder.Append(this.Page.GetPostBackEventReference((Control) this.btRicerca));
      stringBuilder.Append(";");
      ((WebControl) this.btRicerca).Attributes.Add("onclick", stringBuilder.ToString());
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      this.GridTitle1.Visible = false;
      this.BindControls();
      if (this.Context.Handler is SfogliaRdlOdl_MP)
      {
        this._fp = (SfogliaRdlOdl_MP) this.Context.Handler;
        if (this._fp != null)
        {
          this._myColl = this._fp._Contenitore;
          this._myColl.SetValues(this.Page.Controls);
          this.Ricerca(true);
        }
      }
      if (!(this.Context.Handler is CompletamentoMP))
        return;
      this._fp2 = (CompletamentoMP) this.Context.Handler;
      if (this._fp2 == null)
        return;
      this._myColl = this._fp2._ContenitoreSfoglia;
      this._myColl.SetValues(this.Page.Controls);
      this.Ricerca(true);
    }

    private void BindControls()
    {
      this.CaricaCombiAnni();
      this.BindServizi("");
      this.BindApparecchiatura();
      this.BindStatoLavoro("");
    }

    private void CaricaCombiAnni()
    {
      string s = DateTime.Now.Year.ToString();
      for (int index = 2000; index <= (int) short.Parse(s) + 5; ++index)
      {
        ((ListControl) this.cmbsAnnoA).Items.Add(index.ToString());
        ((ListControl) this.cmbsAnnoDa).Items.Add(index.ToString());
      }
      ((ListControl) this.cmbsAnnoA).SelectedValue = s;
      ((ListControl) this.cmbsAnnoDa).SelectedValue = s;
    }

    private void BindAddetti(string idbl)
    {
      int p_ditta_id = 0;
      if (((ListControl) this.cmbsDitta).SelectedValue != "")
        p_ditta_id = int.Parse(((ListControl) this.cmbsDitta).SelectedValue);
      this.Addetti1.Set_BL_ID_DITTA_ID(idbl, p_ditta_id);
    }

    private void CaricaDitte()
    {
      string text = ((TextBox) this.RicercaModulo1.TxtCodice).Text;
      if (text != "")
        this.BindDitte(int.Parse(new TheSite.Classi.Function().GetIdBL(text).Tables[0].Rows[0][0].ToString()));
      else
        this.BindDitte(0);
    }

    private void BindServizi(string CodEdificio)
    {
      this.CaricaDitte();
      this.BindAddetti(CodEdificio);
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
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) data.Tables[0];
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", "0"));
    }

    private void BindDitte(int idbl)
    {
      ((ListControl) this.cmbsDitta).Items.Clear();
      Ditte ditte = new Ditte();
      int idditta = idbl <= 0 ? 0 : int.Parse(ditte.GetDittaBl(idbl).Tables[0].Rows[0]["id_ditta"].ToString());
      DataSet ditteFornitoriRuoli = ditte.GetDitteFornitoriRuoli(idditta);
      if (ditteFornitoriRuoli.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsDitta).DataSource = (object) ditteFornitoriRuoli.Tables[0];
        ((ListControl) this.cmbsDitta).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsDitta).DataValueField = "id";
        ((Control) this.cmbsDitta).DataBind();
      }
      else
        ((ListControl) this.cmbsDitta).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Ditta  -", "0"));
    }

    private void BindStatoLavoro(string idstato)
    {
      ((ListControl) this.cmbsstatolavoro).Items.Clear();
      DataSet statoLavoro = new SfogliaRdlOdl("").GetStatoLavoro();
      if (statoLavoro.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsstatolavoro).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(statoLavoro.Tables[0], "descrizione", "id", "- Tutti gli Stati -", "");
        ((ListControl) this.cmbsstatolavoro).DataTextField = "descrizione";
        ((ListControl) this.cmbsstatolavoro).DataValueField = "id";
        ((Control) this.cmbsstatolavoro).DataBind();
        if (!(idstato != ""))
          return;
        try
        {
          ((ListControl) this.cmbsstatolavoro).SelectedValue = idstato;
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
      else
        ((ListControl) this.cmbsstatolavoro).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuno Stato di Lavoro  -", string.Empty));
    }

    private void BindApparecchiatura()
    {
      ((ListControl) this.cmbsStdApparecchiature).Items.Clear();
      Apparecchiature apparecchiature = new Apparecchiature(this.Context.User.Identity.Name);
      DataSet dataSet;
      if (!this.IsPostBack)
      {
        dataSet = apparecchiature.GetData().Copy();
      }
      else
      {
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Size(50);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
        CollezioneControlli.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_Servizio");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
        CollezioneControlli.Add(sObject2);
        dataSet = apparecchiature.GetData(CollezioneControlli).Copy();
      }
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsStdApparecchiature).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE", "ID", "- Selezionare una Apparecchiatura -", "");
        ((ListControl) this.cmbsStdApparecchiature).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsStdApparecchiature).DataValueField = "ID";
        ((Control) this.cmbsStdApparecchiature).DataBind();
      }
      else
        ((ListControl) this.cmbsStdApparecchiature).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Apparecchiatura -", string.Empty));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btRicerca).Click += new EventHandler(this.btRicerca_Click);
      ((Button) this.btUltimo).Click += new EventHandler(this.btUltimo_Click);
      ((Button) this.btReset).Click += new EventHandler(this.btReset_Click);
      this.DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
      this.DataGrid1.ItemDataBound += new DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btReset_Click(object sender, EventArgs e) => this.Response.Redirect("SfogliaOdlRdl.aspx?FunID=" + this.ViewState["FunId"]);

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e) => this.BindApparecchiatura();

    private void cmbsDitta_SelectedIndexChanged(object sender, EventArgs e) => this.BindAddetti(((TextBox) this.RicercaModulo1.TxtCodice).Text);

    private void Ricerca(bool reset)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      string str1 = "01" + "/" + ((ListControl) this.cmbsMeseDa).SelectedValue + "/" + ((ListControl) this.cmbsAnnoDa).SelectedValue;
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("P_DaData");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Size(10);
      ((ParameterObject) sObject1).set_Value((object) str1);
      CollezioneControlli.Add(sObject1);
      string str2 = DateTime.DaysInMonth((int) short.Parse(((ListControl) this.cmbsAnnoA).SelectedValue), (int) short.Parse(((ListControl) this.cmbsMeseA).SelectedValue)).ToString() + "/" + ((ListControl) this.cmbsMeseA).SelectedValue + "/" + ((ListControl) this.cmbsAnnoA).SelectedValue;
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("P_AData");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Value((object) str2);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("P_servizio");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == "0" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("P_ditta");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) (((ListControl) this.cmbsDitta).SelectedValue == "0" ? 0 : int.Parse(((ListControl) this.cmbsDitta).SelectedValue)));
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("P_odl");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) (((TextBox) this.txtOrdineLavoro).Text == "" ? 0 : int.Parse(((TextBox) this.txtOrdineLavoro).Text)));
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("P_bl_id");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size(50);
      ((ParameterObject) sObject6).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("P_campus");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Size(50);
      ((ParameterObject) sObject7).set_Value((object) this.RicercaModulo1.Campus);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("P_addetto_id");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Size(250);
      ((ParameterObject) sObject8).set_Value((object) this.Addetti1.NomeCompleto);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("P_rdl");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(8);
      ((ParameterObject) sObject9).set_Value((object) (((TextBox) this.txtRichiestaLavoro).Text == "" ? 0 : int.Parse(((TextBox) this.txtRichiestaLavoro).Text)));
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("P_descrizione");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(9);
      ((ParameterObject) sObject10).set_Size(250);
      ((ParameterObject) sObject10).set_Value((object) ((TextBox) this.txtDescrizione).Text);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("P_statoric");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(10);
      ((ParameterObject) sObject11).set_Value((object) (((ListControl) this.cmbsstatolavoro).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsstatolavoro).SelectedValue)));
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("P_standard");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(11);
      ((ParameterObject) sObject12).set_Value((object) (((ListControl) this.cmbsStdApparecchiature).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsStdApparecchiature).SelectedValue)));
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("P_apparecchiatura");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Size(50);
      ((ParameterObject) sObject13).set_Index(12);
      ((ParameterObject) sObject13).set_Value((object) this.CodiceApparecchiature1.CodiceApparecchiatura);
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("p_TipoManutenzione");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(13);
      ((ParameterObject) sObject14).set_Value((object) TipoManutenzioneType.ManutenzioneProgrammata);
      CollezioneControlli.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("P_statoOdl");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject15).set_Value((object) ((ListControl) this.cmbsstatolavoro_odl).SelectedValue);
      CollezioneControlli.Add(sObject15);
      S_Object sObject16 = new S_Object();
      ((ParameterObject) sObject16).set_ParameterName("pageindex");
      ((ParameterObject) sObject16).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject16).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject16).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject16).set_Value((object) (this.DataGrid1.CurrentPageIndex + 1));
      CollezioneControlli.Add(sObject16);
      S_Object sObject17 = new S_Object();
      ((ParameterObject) sObject17).set_ParameterName("pagesize");
      ((ParameterObject) sObject17).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject17).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject17).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject17).set_Value((object) this.DataGrid1.PageSize);
      CollezioneControlli.Add(sObject17);
      SfogliaRdlOdl sfogliaRdlOdl = new SfogliaRdlOdl(this.Context.User.Identity.Name);
      DataSet data = sfogliaRdlOdl.GetData(CollezioneControlli);
      if (reset)
      {
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        this.GridTitle1.NumeroRecords = sfogliaRdlOdl.GetDataCount(CollezioneControlli).ToString();
      }
      this.DataGrid1.DataSource = (object) data.Tables[0];
      this.DataGrid1.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.DataGrid1.DataBind();
      if (int.Parse(this.GridTitle1.NumeroRecords) > 0)
      {
        this.GridTitle1.Visible = true;
        this.DataGrid1.Visible = true;
      }
      else
      {
        this.DataGrid1.Visible = false;
        this.GridTitle1.Visible = false;
      }
    }

    private void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      Label control1 = (Label) e.Item.Cells[11].FindControl("lblComp");
      LinkButton control2 = (LinkButton) e.Item.Cells[11].FindControl("Linkbutton2");
      if (DataBinder.Eval(e.Item.DataItem, "WO_DATA") != DBNull.Value)
      {
        control1.Visible = true;
        control2.Visible = false;
      }
      else
      {
        this.completare = true;
        control2.CommandArgument = DataBinder.Eval(e.Item.DataItem, "wo_id").ToString();
        control2.Text = "Completa";
        control2.CommandName = "lkin";
        control1.Visible = false;
        control2.Visible = true;
      }
    }

    private void btRicerca_Click(object sender, EventArgs e)
    {
      this.DataGrid1.CurrentPageIndex = 0;
      this.Ricerca(true);
    }

    public void LinkButton1_Click(object sender, CommandEventArgs e)
    {
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Context.Items.Add((object) "wo_id", e.CommandArgument);
      this.Server.Transfer("SfogliaRdlOdl_MP.aspx?FunId=" + (object) SfogliaOdlRdl.FunId);
    }

    private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca(false);
    }

    public void LinkButton2_Click(object sender, CommandEventArgs e)
    {
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer("CompletamentoMP.aspx?id_wo=" + e.CommandArgument + "&FunId=" + (object) SfogliaOdlRdl.FunId);
    }

    private void btUltimo_Click(object sender, EventArgs e)
    {
      ((ListControl) this.cmbsMeseDa).SelectedValue = DateTime.Now.Month.ToString().PadLeft(2, Convert.ToChar("0"));
      ((ListControl) this.cmbsAnnoDa).SelectedValue = DateTime.Now.Year.ToString();
      ((ListControl) this.cmbsMeseA).SelectedValue = DateTime.Now.Month.ToString().PadLeft(2, Convert.ToChar("0"));
      ((ListControl) this.cmbsAnnoA).SelectedValue = DateTime.Now.Year.ToString();
      this.Ricerca(true);
    }
  }
}
