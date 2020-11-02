// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.Pmp
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
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class Pmp : Page
  {
    protected DataPanel PanelRicerca;
    protected S_Button btnsRicerca;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    private EditPmp _fpEdit;
    private PmpS _fpStep;
    protected S_TextBox txtsdescrizione;
    protected S_ComboBox cmbspmpfrequenza;
    protected S_ComboBox cmbseq_std;
    protected S_ComboBox cmbstr_id;
    protected S_ComboBox cmbsServizio;
    protected Button cmdReset;
    private clMyCollection _myColl = new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Gestione/EditPmp.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      Pmp.FunId = siteModule.ModuleId;
      this.DataGridRicerca.Columns[1].Visible = siteModule.IsEditable;
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.Append("document.getElementById('" + ((Control) this.cmbseq_std).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsServizio).Attributes.Add("onchange", stringBuilder1.ToString());
      StringBuilder stringBuilder2 = new StringBuilder();
      stringBuilder2.Append("document.getElementById('" + ((Control) this.cmbsServizio).ClientID + "').disabled = true;");
      ((WebControl) this.cmbseq_std).Attributes.Add("onchange", stringBuilder2.ToString());
      if (!this.Page.IsPostBack)
      {
        if (this.Request.QueryString["FunId"] != null)
          this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
        this.BindServizio();
        this.BindSpecStd();
        this.BindPmPFrequenza();
        this.BindEqstd(0);
        if (this.Context.Handler is EditPmp)
        {
          this._fpEdit = (EditPmp) this.Context.Handler;
          if (this._fpEdit != null)
          {
            this._myColl = this._fpEdit._Contenitore;
            this._myColl.SetValues(this.Page.Controls);
            this.Ricerca();
          }
        }
        if (this.Context.Handler is PmpS)
        {
          this._fpStep = (PmpS) this.Context.Handler;
          if (this._fpStep != null)
          {
            this._myColl = this._fpStep._Contenitore;
            this._myColl.SetValues(this.Page.Controls);
            this.Ricerca();
          }
        }
      }
      Pmp.FunId = siteModule.ModuleId;
      Pmp.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
    }

    public clMyCollection _Contenitore => this._myColl;

    private void BindServizio()
    {
      ((ListControl) this.cmbsServizio).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiDettaglio.Servizi().GetServizi().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "serv", "id", "- Selezionare un Servizio -", "0");
      ((ListControl) this.cmbsServizio).DataTextField = "serv";
      ((ListControl) this.cmbsServizio).DataValueField = "id";
      ((Control) this.cmbsServizio).DataBind();
    }

    private void BindEqstd(int id_serv)
    {
      ((ListControl) this.cmbseq_std).Items.Clear();
      S_ControlsCollection _SColl = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_servizio_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) id_serv);
      _SColl.Add(sObject);
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Eqstd().GetSingleServ(_SColl).Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbseq_std).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "eq_std", "id", "- Selezionare uno Standard -", "0");
        ((ListControl) this.cmbseq_std).DataTextField = "eq_std";
        ((ListControl) this.cmbseq_std).DataValueField = "id";
        ((Control) this.cmbseq_std).DataBind();
      }
      else
        ((ListControl) this.cmbseq_std).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Standard  -", "-1"));
    }

    private void BindSpecStd()
    {
      ((ListControl) this.cmbstr_id).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Pmp().GetAllTr().Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbstr_id).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "id", "- Selezionare una Specializzazione -", "0");
        ((ListControl) this.cmbstr_id).DataTextField = "descrizione";
        ((ListControl) this.cmbstr_id).DataValueField = "id";
        ((Control) this.cmbstr_id).DataBind();
      }
      else
        ((ListControl) this.cmbstr_id).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Specializzazione  -", "-1"));
    }

    private void BindSpecStd(int id_serv)
    {
      ((ListControl) this.cmbstr_id).Items.Clear();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_servizio_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) id_serv);
      CollezioneControlli.Add(sObject);
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Pmp().GetSpecData(CollezioneControlli).Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbstr_id).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "id", "- Selezionare una Specializzazione -", "0");
        ((ListControl) this.cmbstr_id).DataTextField = "descrizione";
        ((ListControl) this.cmbstr_id).DataValueField = "id";
        ((Control) this.cmbstr_id).DataBind();
      }
      else
        ((ListControl) this.cmbstr_id).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Specializzazione  -", "-1"));
    }

    private void BindPmPFrequenza()
    {
      ((ListControl) this.cmbspmpfrequenza).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza().GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbspmpfrequenza).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "fqdes", "id", "- Selezionare una Frequenza -", "0");
      ((ListControl) this.cmbspmpfrequenza).DataTextField = "fqdes";
      ((ListControl) this.cmbspmpfrequenza).DataValueField = "id";
      ((Control) this.cmbspmpfrequenza).DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsServizio).SelectedIndexChanged += new EventHandler(this.cmbsServizio_SelectedIndexChanged);
      ((ListControl) this.cmbseq_std).SelectedIndexChanged += new EventHandler(this.cmbseq_std_SelectedIndexChanged);
      ((ListControl) this.cmbstr_id).SelectedIndexChanged += new EventHandler(this.cmbstr_id_SelectedIndexChanged);
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.cmdReset.Click += new EventHandler(this.cmdReset_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.SelectedIndexChanged += new EventHandler(this.DataGridRicerca_SelectedIndexChanged);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void Ricerca()
    {
      TheSite.Classi.ClassiAnagrafiche.Pmp pmp = new TheSite.Classi.ClassiAnagrafiche.Pmp();
      this.txtsdescrizione.set_DBDefaultValue((object) "%");
      this.cmbsServizio.set_DBDefaultValue((object) "0");
      this.cmbseq_std.set_DBDefaultValue((object) "0");
      this.cmbspmpfrequenza.set_DBDefaultValue((object) "0");
      this.cmbstr_id.set_DBDefaultValue((object) "0");
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) ((Control) this.PanelRicerca).Controls);
      DataSet dataSet = pmp.GetData(CollezioneControlli).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      if (dataSet.Tables[0].Rows.Count == 0)
      {
        this.DataGridRicerca.CurrentPageIndex = 0;
      }
      else
      {
        int num = 0;
        if (dataSet.Tables[0].Rows.Count % this.DataGridRicerca.PageSize > 0)
          ++num;
        if (this.DataGridRicerca.PageCount != (int) Convert.ToInt16(dataSet.Tables[0].Rows.Count / this.DataGridRicerca.PageSize + num))
          this.DataGridRicerca.CurrentPageIndex = 0;
      }
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
    }

    private void btnsRicerca_Click(object sender, EventArgs e) => this.Ricerca();

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.BindEqstd(int.Parse(((ListControl) this.cmbsServizio).SelectedValue));
      this.BindSpecStd(int.Parse(((ListControl) this.cmbsServizio).SelectedValue));
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }

    private void DataGridRicerca_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void cmbseq_std_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (((ListControl) this.cmbsServizio).SelectedIndex != 0)
        return;
      this.BindSpecStd(int.Parse(new TheSite.Classi.ClassiAnagrafiche.Pmp().GetStdData(int.Parse(((ListControl) this.cmbseq_std).SelectedValue)).Tables[0].Rows[0]["id"].ToString()));
    }

    private void cmbstr_id_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void cmdReset_Click(object sender, EventArgs e) => this.Response.Redirect("Pmp.aspx?FunID=" + this.ViewState["FunId"]);
  }
}
