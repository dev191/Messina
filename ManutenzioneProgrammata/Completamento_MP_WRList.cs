// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.Completamento_MP_WRList
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManProgrammata;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class Completamento_MP_WRList : Page
  {
    protected DataGrid DataGridRicerca;
    protected S_Button btnsCompletaOdl;
    protected Label Label1;
    protected Label Label2;
    protected Label Label3;
    protected Label Label4;
    protected Label Label5;
    protected Label Label6;
    protected Label Label7;
    protected Label LblODL;
    protected Label LblLocalita;
    protected Label LblCodEdificio;
    protected Label LblIndirizzo;
    protected Label LblDataEmissione;
    protected Label LblDataPianificata;
    protected Label LblAddetto;
    protected DataPanel DatapanelCompleta;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    protected UserOption Option1;
    public static string HelpLink = string.Empty;
    protected Button BtnChiudi;
    protected CalendarPicker CalendarPicker1;
    public static int FunId = 0;
    protected HtmlInputHidden hiddenreload;
    protected Button hidRef;
    private CompletamentoMP _fp;

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((Control) this.btnsCompletaOdl).Visible = siteModule.IsEditable;
      Completamento_MP_WRList.FunId = siteModule.ModuleId;
      Completamento_MP_WRList.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      string script = "<script language=JavaScript>var dettaglio;\n" + "function chiudi() {\n" + "if (dettaglio!=null)" + "if (document.Form1.hidRicerca.value=='0'){" + " dettaglio.close();}" + " else{" + "document.Form1.hidRicerca.value='1';}}<" + "/" + "script>";
      if (!this.IsClientScriptBlockRegistered("clientScript"))
        this.RegisterClientScriptBlock("clientScript", script);
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("if (typeof(ControllaData) == 'function') { ");
      stringBuilder.Append("if (ControllaData() == false) { return false; }} ");
      stringBuilder.Append(this.Page.GetPostBackEventReference((Control) this.btnsCompletaOdl));
      stringBuilder.Append(";");
      ((WebControl) this.btnsCompletaOdl).Attributes.Add("onclick", stringBuilder.ToString());
      if (!this.Page.IsPostBack)
      {
        this.Session.Remove("DatiListMP");
        if (this.Context.Handler is CompletamentoMP)
        {
          this._fp = (CompletamentoMP) this.Context.Handler;
          this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
        }
        if (this.Context.Handler is SfogliaRdlOdl_MP)
        {
          this.ViewState.Add("mioContenitore", (object) ((SfogliaRdlOdl_MP) this.Context.Handler)._Contenitore);
          this.ViewState.Add("paginardl", (object) "paginardl");
        }
        this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
        if (this.Request.QueryString["wo_id"] != null)
          this.wo_id = this.Request.QueryString["wo_id"];
        if (this.Context.Items[(object) "wo_id"] != null)
          this.wo_id = (string) this.Context.Items[(object) "wo_id"];
        this.Ricerca(int.Parse(this.wo_id));
      }
      else
      {
        if (!(this.hiddenreload.Value == "1"))
          return;
        this.Ricerca(int.Parse(this.wo_id));
      }
    }

    private string wo_id
    {
      get => this.ViewState[nameof (wo_id)] != null ? (string) this.ViewState[nameof (wo_id)] : string.Empty;
      set => this.ViewState.Add(nameof (wo_id), (object) value);
    }

    private void Ricerca(int wo_id)
    {
      this.hiddenreload.Value = "";
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_WO_ID");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Size(4);
      ((ParameterObject) sObject).set_Value((object) wo_id);
      CollezioneControlli.Add(sObject);
      Completamento completamento = new Completamento();
      DataRow row = completamento.GetDatiWO(CollezioneControlli).Copy().Tables[0].Rows[0];
      this.LblODL.Text = row[nameof (wo_id)].ToString();
      if (row["Localita"].ToString().Trim() != "()")
        this.LblLocalita.Text = row["Localita"].ToString();
      this.LblCodEdificio.Text = row["Edificio"].ToString();
      this.LblIndirizzo.Text = row["Indirizzo"].ToString();
      if (row["DataEmissione"].ToString() != "")
        this.LblDataEmissione.Text = DateTime.Parse(row["DataEmissione"].ToString()).ToLongDateString();
      string str = row["DataPianificata"].ToString();
      if (str.Length > 0)
      {
        DateTime dateTime = Convert.ToDateTime(str);
        this.LblDataPianificata.Text = TheSite.Classi.Function.ImpostaMese(dateTime.Month, false) + " - " + dateTime.Year.ToString();
        this.LblDataPianificata.ToolTip = str;
      }
      this.LblAddetto.Text = row["Addetto"].ToString();
      DataSet dataSet = completamento.GetDatiWR(CollezioneControlli).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((Control) this.DatapanelCompleta).Visible = true;
        this.DataGridRicerca.Visible = true;
      }
      else
      {
        ((Control) this.DatapanelCompleta).Visible = false;
        this.DataGridRicerca.Visible = false;
      }
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      ((Button) this.btnsCompletaOdl).Click += new EventHandler(this.btnsCompletaOdl_Click);
      this.BtnChiudi.Click += new EventHandler(this.BtnChiudi_Click);
      this.hidRef.Click += new EventHandler(this.hidRef_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      string empty = string.Empty;
      switch ((StateType) short.Parse(e.Item.Cells[10].Text))
      {
        case StateType.AttivitaCompletata:
          UserOption control1 = (UserOption) e.Item.Cells[9].FindControl("UserOption1");
          control1.OptChiusaSospesa.Items[0].Selected = true;
          control1.OptChiusaSospesa.Enabled = false;
          control1.TxtMotivoSospensione.Enabled = false;
          if (e.Item.Cells[8].Text != "&nbsp;")
            control1.TxtMotivoSospensione.Text = e.Item.Cells[8].Text;
          CheckBox control2 = (CheckBox) e.Item.Cells[2].FindControl("ChkSel");
          control2.Checked = true;
          control2.Enabled = false;
          break;
        case StateType.EmessaInLavorazione:
          UserOption control3 = (UserOption) e.Item.Cells[9].FindControl("UserOption1");
          control3.OptChiusaSospesa.Items[0].Selected = true;
          string str1 = "Disabilita('" + control3.OptChiusaSospesa.ClientID + "','" + control3.TxtMotivoSospensione.ClientID + "')";
          control3.OptChiusaSospesa.Attributes.Add("onclick", str1);
          control3.TxtMotivoSospensione.Enabled = false;
          if (!(e.Item.Cells[8].Text != "&nbsp;"))
            break;
          control3.TxtMotivoSospensione.Text = e.Item.Cells[8].Text;
          break;
        case StateType.RichiestaSospesa:
          UserOption control4 = (UserOption) e.Item.Cells[9].FindControl("UserOption1");
          control4.OptChiusaSospesa.Items[1].Selected = true;
          string str2 = "Disabilita('" + control4.OptChiusaSospesa.ClientID + "','" + control4.TxtMotivoSospensione.ClientID + "')";
          control4.OptChiusaSospesa.Attributes.Add("onclick", str2);
          control4.TxtMotivoSospensione.Enabled = true;
          ((CheckBox) e.Item.Cells[2].FindControl("ChkSel")).Checked = true;
          if (!(e.Item.Cells[8].Text != "&nbsp;"))
            break;
          control4.TxtMotivoSospensione.Text = e.Item.Cells[8].Text;
          break;
      }
    }

    private void BtnChiudi_Click(object sender, EventArgs e)
    {
      if (this.ViewState["paginardl"] == null)
      {
        this.Server.Transfer("CompletamentoMP.aspx?FunId=" + (object) Completamento_MP_WRList.FunId);
      }
      else
      {
        this.Context.Items.Add((object) "wo_id", (object) this.wo_id);
        this.Server.Transfer("SfogliaRdlOdl_MP.aspx?FunId=" + (object) Completamento_MP_WRList.FunId);
      }
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.SaveDati(this.DataGridRicerca);
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca(int.Parse(this.wo_id));
      this.GetDati(this.DataGridRicerca);
    }

    private void btnsCompletaOdl_Click(object sender, EventArgs e)
    {
      string str = "<script language=JavaScript>" + "window.returnValue =window.showModalDialog(\"Completa_WO.aspx?wo=" + this.LblODL.Text + "&data=" + ((TextBox) this.CalendarPicker1.Datazione).Text + "\", \"dial\",\"" + "menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no',align='center'" + "\")\n" + "document.getElementById('hiddenreload').value='1';\n" + "__doPostBack('','');\n" + "<" + "/" + "script>";
      this.SaveDati(this.DataGridRicerca);
      if ((this.Session["DatiListMP"] == null ? new Hashtable() : (Hashtable) this.Session["DatiListMP"]).Count == 0)
        SiteJavaScript.msgBox(this.Page, "Nessuna RDL Selezionata.");
      else
        SiteJavaScript.WindowOpen(this.Page, 0, "Completa_WO.aspx?wo=" + this.LblODL.Text + "&data=" + ((TextBox) this.CalendarPicker1.Datazione).Text, 800, 600, "dettaglio");
    }

    private void SaveDati(DataGrid Ctrl)
    {
      Hashtable hashtable = this.Session["DatiListMP"] == null ? new Hashtable() : (Hashtable) this.Session["DatiListMP"];
      foreach (DataGridItem dataGridItem in Ctrl.Items)
      {
        CheckBox control1 = (CheckBox) dataGridItem.Cells[2].Controls[1];
        HyperLink control2 = (HyperLink) dataGridItem.Cells[3].Controls[0];
        if (hashtable.ContainsKey((object) control2.Text))
          hashtable.Remove((object) control2.Text);
        if (control1.Checked && control1.Enabled)
        {
          WRList wrList = new WRList();
          UserOption control3 = (UserOption) dataGridItem.Cells[9].FindControl("UserOption1");
          wrList.id = control2.Text;
          wrList.stato = control3.OptChiusaSospesa.Items[0].Selected;
          wrList.descrizione = control3.TxtMotivoSospensione.Text;
          hashtable.Add((object) wrList.id, (object) wrList);
        }
      }
      this.Session.Remove("DatiListMP");
      this.Session.Add("DatiListMP", (object) hashtable);
    }

    private void GetDati(DataGrid Ctrl)
    {
      if (this.Session["DatiListMP"] == null)
        return;
      Hashtable hashtable = (Hashtable) this.Session["DatiListMP"];
      foreach (DataGridItem dataGridItem in Ctrl.Items)
      {
        CheckBox control1 = (CheckBox) dataGridItem.Cells[2].Controls[1];
        HyperLink control2 = (HyperLink) dataGridItem.Cells[3].Controls[0];
        if (hashtable.ContainsKey((object) control2.Text))
        {
          control1.Checked = true;
          WRList wrList = (WRList) hashtable[(object) control2.Text];
          UserOption control3 = (UserOption) dataGridItem.Cells[9].FindControl("UserOption1");
          if (!wrList.stato)
          {
            control3.OptChiusaSospesa.Items[0].Selected = false;
            control3.OptChiusaSospesa.Items[1].Selected = true;
            control3.TxtMotivoSospensione.Enabled = true;
          }
          else
          {
            control3.OptChiusaSospesa.Items[0].Selected = true;
            control3.OptChiusaSospesa.Items[1].Selected = false;
          }
          control3.TxtMotivoSospensione.Text = wrList.descrizione;
        }
      }
    }

    private void hidRef_Click(object sender, EventArgs e) => this.Ricerca(Convert.ToInt32(this.wo_id));
  }
}
