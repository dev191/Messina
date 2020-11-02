// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.CompletamentoMP
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
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManOrdinaria;
using TheSite.Classi.ManProgrammata;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class CompletamentoMP : Page
  {
    protected S_TextBox txtsRichiesta;
    protected S_ComboBox cmbsServizio;
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected S_ComboBox cmbsMeseDa;
    protected S_ComboBox cmbsAnnoDa;
    protected S_ComboBox cmbsAnnoA;
    protected S_ComboBox cmbsDitta;
    protected S_ComboBox cmbsMeseA;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    protected RicercaModulo RicercaModulo1;
    protected CalendarPicker CalendarPicker1;
    protected TheSite.WebControls.Addetti Addetti1;
    protected S_Button btnsCompletaOdl;
    protected S_Button btnsModificaODL;
    protected DataPanel DatapanelCompleta;
    protected S_ComboBox cmbsAddettoCompl;
    protected S_ComboBox cmbsAddettoMod;
    public static string HelpLink = string.Empty;
    private clMyCollection _myColl = new clMyCollection();
    protected S_Button btnSChiudi;
    protected Button cmdReset;
    private Completamento_MP_WRList _fp;

    public clMyCollection _Contenitore => this._myColl;

    public clMyCollection _ContenitoreSfoglia => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((Control) this.btnsModificaODL).Visible = siteModule.IsEditable;
      ((Control) this.btnsCompletaOdl).Visible = siteModule.IsEditable;
      CompletamentoMP.FunId = siteModule.ModuleId;
      CompletamentoMP.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      ((WebControl) this.txtsRichiesta).Attributes.Add("onkeypress", "ControllaCaratteri();");
      ((WebControl) this.btnsRicerca).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsCompletaOdl).Attributes.Add("onclick", "Valorizza('1')");
      ((WebControl) this.btnsModificaODL).Attributes.Add("onclick", "Valorizza('2')");
      this.Addetti1.btnAddetto.Attributes.Add("onclick", "Valorizza('2')");
      string script = "<script language=JavaScript>var dettaglio;\n" + "function chiudi() {\n" + "if (dettaglio!=null)" + "if (document.Form1.hidRicerca.value=='0'){" + " dettaglio.close();}" + " else{" + "document.Form1.hidRicerca.value='1';}}<" + "/" + "script>";
      if (!this.IsClientScriptBlockRegistered("clientScript"))
        this.RegisterClientScriptBlock("clientScript", script);
      this.RicercaModulo1.DelegateCodiceEdificio1 = new DelegateCodiceEdificio(this.BindServizi);
      if (this.Page.IsPostBack)
        return;
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      this.BindControls();
      if (this.Context.Handler is Completamento_MP_WRList)
      {
        this._fp = (Completamento_MP_WRList) this.Context.Handler;
        if (this._fp != null)
        {
          this._myColl = this._fp._Contenitore;
          this._myColl.SetValues(this.Page.Controls);
          this.Ricerca();
        }
      }
      if (this.Request.QueryString["id_wo"] != null)
      {
        ((Control) this.btnSChiudi).Visible = true;
        this.Ricerca(int.Parse(this.Request.QueryString["id_wo"]));
        PropertyInfo property = this.Context.Handler.GetType().GetProperty("_Contenitore");
        if (property != null)
          this.ViewState.Add("mioContenitore", property.GetValue((object) this.Context.Handler, (object[]) null));
      }
      else
        ((Control) this.btnSChiudi).Visible = false;
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      this.Session.Remove("CheckedListMP");
    }

    public void LinkWR(object sender, EventArgs e)
    {
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer("Completamento_MP_WRList.aspx");
    }

    private void BindControls()
    {
      this.CaricaCombiAnni();
      this.BindServizi("");
    }

    private void CaricaCombiAnni()
    {
      string str = DateTime.Now.Year.ToString();
      for (int index = 1950; index <= 2051; ++index)
      {
        ListItem listItem1 = new ListItem();
        ListItem listItem2 = new ListItem();
        listItem1.Text = index.ToString();
        listItem1.Value = index.ToString();
        listItem2.Text = index.ToString();
        listItem2.Value = index.ToString();
        ((ListControl) this.cmbsAnnoA).Items.Add(listItem1);
        ((ListControl) this.cmbsAnnoDa).Items.Add(listItem2);
      }
      ((ListControl) this.cmbsAnnoA).SelectedValue = str;
      ((ListControl) this.cmbsAnnoDa).SelectedValue = str;
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
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", string.Empty));
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
        ((ListControl) this.cmbsDitta).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Ditta  -", string.Empty));
    }

    private void BindAddettiDitta(string bl_id, int ditta_id)
    {
      ((ListControl) this.cmbsAddettoMod).Items.Clear();
      ((ListControl) this.cmbsAddettoCompl).Items.Clear();
      DataSet addetti = new Richiesta().GetAddetti("", bl_id, ditta_id);
      if (addetti.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsAddettoMod).DataSource = (object) addetti.Tables[0];
        ((ListControl) this.cmbsAddettoMod).DataTextField = "NOMINATIVO";
        ((ListControl) this.cmbsAddettoMod).DataValueField = "ID";
        ((Control) this.cmbsAddettoMod).DataBind();
        ((BaseDataBoundControl) this.cmbsAddettoCompl).DataSource = (object) addetti.Tables[0];
        ((ListControl) this.cmbsAddettoCompl).DataTextField = "NOMINATIVO";
        ((ListControl) this.cmbsAddettoCompl).DataValueField = "ID";
        ((Control) this.cmbsAddettoCompl).DataBind();
      }
      else
      {
        string Text = "- Nessun Addetto  -";
        ((ListControl) this.cmbsAddettoMod).Items.Add(GestoreDropDownList.ItemMessaggio(Text, ""));
        ((ListControl) this.cmbsAddettoCompl).Items.Add(GestoreDropDownList.ItemMessaggio(Text, ""));
      }
    }

    private void Ricerca()
    {
      this.txtsRichiesta.set_DBDefaultValue((object) "0");
      this.cmbsDitta.set_DBDefaultValue((object) "0");
      this.cmbsServizio.set_DBDefaultValue((object) "0");
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_TipoManutenzione");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Size(4);
      ((ParameterObject) sObject1).set_Value((object) TipoManutenzioneType.ManutenzioneProgrammata);
      CollezioneControlli.Add(sObject1);
      string str1 = 1.ToString() + "/" + (object) (int) short.Parse(((ListControl) this.cmbsMeseDa).SelectedValue) + "/" + (object) (int) short.Parse(((ListControl) this.cmbsAnnoDa).SelectedValue);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_AnnoDa");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Value((object) str1);
      CollezioneControlli.Add(sObject2);
      string str2 = DateTime.DaysInMonth((int) short.Parse(((ListControl) this.cmbsAnnoA).SelectedValue), (int) short.Parse(((ListControl) this.cmbsMeseA).SelectedValue)).ToString() + "/" + (object) (int) short.Parse(((ListControl) this.cmbsMeseA).SelectedValue) + "/" + (object) (int) short.Parse(((ListControl) this.cmbsAnnoA).SelectedValue);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_AnnoA");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Value((object) str2);
      CollezioneControlli.Add(sObject3);
      int num1 = 0;
      if (((ListControl) this.cmbsDitta).SelectedValue != "")
        num1 = int.Parse(((ListControl) this.cmbsDitta).SelectedValue);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_Ditta");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(4);
      ((ParameterObject) sObject4).set_Value((object) num1);
      CollezioneControlli.Add(sObject4);
      int num2 = 0;
      if (((ListControl) this.cmbsServizio).SelectedValue != "")
        num2 = int.Parse(((ListControl) this.cmbsServizio).SelectedValue);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_Servizio");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Size(4);
      ((ParameterObject) sObject5).set_Value((object) num2);
      CollezioneControlli.Add(sObject5);
      int num3 = 0;
      if (((TextBox) this.txtsRichiesta).Text.Trim() != "")
        num3 = int.Parse(((TextBox) this.txtsRichiesta).Text.Trim());
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_Wo_Id");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size(4);
      ((ParameterObject) sObject6).set_Value((object) num3);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_Id_Bl");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Size(20);
      ((ParameterObject) sObject7).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text.Trim());
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_Nome_Completo");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Size(4);
      ((ParameterObject) sObject8).set_Value((object) this.Addetti1.NomeCompleto);
      CollezioneControlli.Add(sObject8);
      DataSet dataSet = new Completamento().GetData(CollezioneControlli).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((Control) this.DatapanelCompleta).Visible = true;
        DataRow row = dataSet.Tables[0].Rows[0];
        ((ListControl) this.cmbsAddettoCompl).SelectedValue = row["id_addetto"].ToString();
        ((ListControl) this.cmbsAddettoMod).SelectedValue = row["id_addetto"].ToString();
      }
      else
        ((Control) this.DatapanelCompleta).Visible = false;
    }

    private void Ricerca(int wo_id)
    {
      this.DatapanelCompleta.set_Collapsed(false);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet dataSet = new Completamento().GetSingleData(wo_id).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        DataRow row = dataSet.Tables[0].Rows[0];
        ((TextBox) this.txtsRichiesta).Text = row["ID"].ToString();
        if (row["idditta"] != null)
          ((ListControl) this.cmbsDitta).SelectedValue = row["idditta"].ToString();
        this.BindAddettiDitta(this.RicercaModulo1.BlId, int.Parse(((ListControl) this.cmbsDitta).SelectedValue));
        ((TextBox) this.RicercaModulo1.TxtCodice).Text = row["Edificio"].ToString();
        this.RicercaModulo1.Ricarica();
        this.Addetti1.NomeCompleto = row["Addetto"].ToString();
        this.BindAddetti(row["Edificio"].ToString());
        DateTime dateTime = DateTime.Parse(row["DataPianificata"].ToString());
        ((ListControl) this.cmbsAnnoA).SelectedValue = dateTime.Year.ToString();
        ((ListControl) this.cmbsAnnoDa).SelectedValue = dateTime.Year.ToString();
        ((ListControl) this.cmbsMeseA).SelectedValue = dateTime.Month.ToString().PadLeft(2, Convert.ToChar("0"));
        ((ListControl) this.cmbsMeseDa).SelectedValue = dateTime.Month.ToString().PadLeft(2, Convert.ToChar("0"));
        ((ListControl) this.cmbsAddettoCompl).SelectedValue = row["id_addetto"].ToString();
        ((ListControl) this.cmbsAddettoMod).SelectedValue = row["id_addetto"].ToString();
        ((Control) this.DatapanelCompleta).Visible = true;
      }
      else
        ((Control) this.DatapanelCompleta).Visible = false;
    }

    private void MemorizzaCheck()
    {
      Hashtable hashtable = new Hashtable();
      foreach (DataGridItem dataGridItem in this.DataGridRicerca.Items)
      {
        int num = int.Parse(dataGridItem.Cells[0].Text);
        if (this.Session["CheckedListMP"] != null)
          hashtable = (Hashtable) this.Session["CheckedListMP"];
        CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        if (hashtable.ContainsKey((object) num))
          hashtable.Remove((object) num);
        hashtable.Add((object) num, (object) control.Checked);
        this.Session.Remove("CheckedListMP");
        this.Session.Add("CheckedListMP", (object) hashtable);
      }
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.cmdReset.Click += new EventHandler(this.cmdReset_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      ((Button) this.btnsCompletaOdl).Click += new EventHandler(this.btnsCompletaOdl_Click);
      ((Button) this.btnsModificaODL).Click += new EventHandler(this.btnsModificaODL_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void cmbsDitta_SelectedIndexChanged(object sender, EventArgs e) => this.BindAddetti(((TextBox) this.RicercaModulo1.TxtCodice).Text);

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.Session.Remove("CheckedListMP");
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.BindAddettiDitta(this.RicercaModulo1.BlId, int.Parse(((ListControl) this.cmbsDitta).SelectedValue));
      this.Ricerca();
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      string str1 = e.Item.Cells[9].Text.Trim();
      if (str1.Length > 0)
      {
        DateTime dateTime = Convert.ToDateTime(e.Item.Cells[9].Text.Trim());
        string str2 = TheSite.Classi.Function.ImpostaMese(dateTime.Month, false);
        string str3 = dateTime.Year.ToString();
        e.Item.Cells[9].Text = str2 + " - " + str3;
        e.Item.Cells[9].ToolTip = str1;
      }
      TheSite.Classi.Function function = new TheSite.Classi.Function();
      int wo_id = (int) short.Parse(e.Item.Cells[0].Text);
      DataSet wrfromWo = function.GetWRfromWO(wo_id);
      int count = wrfromWo.Tables[0].Rows.Count;
      if (count > 0)
      {
        string str2 = "Riferimento a RDL n°:";
        for (int index = 0; count > index; ++index)
        {
          string str3 = wrfromWo.Tables[0].Rows[index]["wr_id"].ToString();
          str2 = str2 + "\n" + str3;
        }
        e.Item.Cells[2].ToolTip = str2;
      }
      if (this.Session["CheckedListMP"] == null)
        return;
      Hashtable hashtable = (Hashtable) this.Session["CheckedListMP"];
      if (!hashtable.ContainsKey((object) wo_id))
        return;
      ((CheckBox) e.Item.Cells[1].FindControl("ChkSel")).Checked = bool.Parse(hashtable[(object) wo_id].ToString());
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.MemorizzaCheck();
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString() + "&FunID=" + (object) CompletamentoMP.FunId);
    }

    private void btnSChiudi_Click(object sender, EventArgs e) => this.Server.Transfer("SfogliaOdlRdl.aspx?FunID=" + (object) CompletamentoMP.FunId);

    private void btnsCompletaOdl_Click(object sender, EventArgs e)
    {
      this.MemorizzaCheck();
      int num = 0;
      IDictionaryEnumerator enumerator = ((Hashtable) this.Session["CheckedListMP"]).GetEnumerator();
      while (enumerator.MoveNext())
      {
        if ((bool) enumerator.Value)
          ++num;
      }
      if (num == 0)
        SiteJavaScript.msgBox(this.Page, "Nessuna RDL Selezionata.");
      else
        SiteJavaScript.WindowOpen(this.Page, 0, "Completa_WO.aspx?addetto=" + ((ListControl) this.cmbsAddettoCompl).SelectedValue + "&data=" + ((TextBox) this.CalendarPicker1.Datazione).Text, 800, 600, "dettaglio");
    }

    private void btnsModificaODL_Click(object sender, EventArgs e)
    {
      this.MemorizzaCheck();
      int num = 0;
      IDictionaryEnumerator enumerator = ((Hashtable) this.Session["CheckedListMP"]).GetEnumerator();
      while (enumerator.MoveNext())
      {
        if ((bool) enumerator.Value)
          ++num;
      }
      if (num == 0)
        SiteJavaScript.msgBox(this.Page, "Nessuna RDL Selezionata.");
      else
        SiteJavaScript.WindowOpen(this.Page, 0, "Aggiona_WO.aspx?addetto=" + ((ListControl) this.cmbsAddettoMod).SelectedValue, 800, 600, "dettaglio");
    }

    private void cmdReset_Click(object sender, EventArgs e) => this.Response.Redirect("CompletamentoMP.aspx?FunID=" + this.ViewState["FunId"]);
  }
}
