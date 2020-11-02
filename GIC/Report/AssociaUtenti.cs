// Decompiled with JetBrains decompiler
// Type: TheSite.GIC.Report.AssociaUtenti
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.GIC.Classi;
using TheSite.WebControls;

namespace TheSite.GIC.Report
{
  public class AssociaUtenti : Page
  {
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected S_TextBox txtsUserName;
    protected S_ComboBox CmbProgetto;
    protected S_TextBox txtsCognome;
    protected S_TextBox txtsNome;
    protected S_TextBox txtsEmail;
    protected S_TextBox txtsTelefono;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    protected S_Button btnsSalva;
    public static string HelpLink = string.Empty;
    protected S_Button btnsIndietro;
    private string idSchema;
    private string Schema;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Admin/EditUtenti.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.DataGridRicerca.Columns[1].Visible = siteModule.IsEditable;
      this.idSchema = this.Request.QueryString["id"];
      this.Schema = this.Request.QueryString["schema"];
      AssociaUtenti.FunId = siteModule.ModuleId;
      AssociaUtenti.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle + " allo Schema: " + this.Schema;
      if (this.IsPostBack)
        return;
      this.BindProgetti(0);
      ((Control) this.btnsSalva).Visible = false;
      this.Ricerca();
    }

    private void BindProgetti(int progetto)
    {
      ((ListControl) this.CmbProgetto).Items.Clear();
      DataSet data = new Progetti().GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.CmbProgetto).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "descrizione", "id_progetto", "- Selezionare un Progetto -", "0");
        ((ListControl) this.CmbProgetto).DataTextField = "descrizione";
        ((ListControl) this.CmbProgetto).DataValueField = "id_progetto";
        ((Control) this.CmbProgetto).DataBind();
        ((ListControl) this.CmbProgetto).SelectedValue = progetto.ToString();
      }
      else
        ((ListControl) this.CmbProgetto).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Progetto  -", "-1"));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      ((Button) this.btnsIndietro).Click += new EventHandler(this.btnsIndietro_Click);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e) => this.Ricerca();

    private void Ricerca()
    {
      ParsingViste parsingViste = new ParsingViste();
      this.txtsUserName.set_DBDefaultValue((object) "%");
      this.txtsCognome.set_DBDefaultValue((object) "%");
      this.txtsNome.set_DBDefaultValue((object) "%");
      this.txtsEmail.set_DBDefaultValue((object) "%");
      this.txtsTelefono.set_DBDefaultValue((object) "%");
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) ((Control) this.PanelRicerca).Controls);
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_idSchema");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject).set_Value((object) this.idSchema);
      CollezioneControlli.Add(sObject);
      DataSet dataSet = parsingViste.GetDataUtenti(CollezioneControlli).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
      if (dataSet.Tables[0].Rows.Count > 0)
        ((Control) this.btnsSalva).Visible = true;
      else
        ((Control) this.btnsSalva).Visible = false;
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      ParsingViste parsingViste = new ParsingViste();
      this.txtsUserName.set_DBDefaultValue((object) "%");
      this.txtsCognome.set_DBDefaultValue((object) "%");
      this.txtsNome.set_DBDefaultValue((object) "%");
      this.txtsEmail.set_DBDefaultValue((object) "%");
      this.txtsTelefono.set_DBDefaultValue((object) "%");
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) ((Control) this.PanelRicerca).Controls);
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_idSchema");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject).set_Value((object) this.idSchema);
      CollezioneControlli.Add(sObject);
      parsingViste.DeleteSchemaUtenti(CollezioneControlli);
      foreach (DataGridItem dataGridItem in this.DataGridRicerca.Items)
      {
        bool flag = ((CheckBox) dataGridItem.FindControl("ChkSel")).Checked;
        string text = dataGridItem.Cells[2].Text;
        if (flag)
          this.Salva(text);
      }
    }

    private void Salva(string Username) => new ParsingViste().InsertSchemaUtenti(Username, int.Parse(this.idSchema));

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      CheckBox control = (CheckBox) e.Item.Cells[0].FindControl("ChkSel");
      if (DataBinder.Eval(e.Item.DataItem, "IDSCHEMA") != DBNull.Value)
        control.Checked = true;
      else
        control.Checked = false;
    }

    private void btnsIndietro_Click(object sender, EventArgs e) => this.Response.Redirect("DefaultReport.aspx");
  }
}
