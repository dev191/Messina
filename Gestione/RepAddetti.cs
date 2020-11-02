// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.RepAddetti
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class RepAddetti : Page
  {
    protected DataPanel PanelRicerca;
    protected S_Button btnsRicerca;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    private EditRepAddetti _fp;
    protected S_TextBox txtsadd;
    protected S_TextBox txtsditta;
    protected S_ComboBox cmbsGiorno;
    protected S_Button BtnReset;
    private clMyCollection _myColl = new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Gestione/EditRepAddetti1.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[1].Visible = siteModule.IsEditable;
      if (!this.Page.IsPostBack)
      {
        this.BindGiorni();
        if (this.Context.Handler is EditRepAddetti)
        {
          this._fp = (EditRepAddetti) this.Context.Handler;
          if (this._fp != null)
          {
            this._myColl = this._fp._Contenitore;
            this._myColl.SetValues(this.Page.Controls);
            this.Ricerca();
          }
        }
      }
      RepAddetti.FunId = siteModule.ModuleId;
      RepAddetti.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
    }

    public clMyCollection _Contenitore => this._myColl;

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.DataGridRicerca.ItemCreated += new DataGridItemEventHandler(this.DataGridRicerca_ItemCreated);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.DeleteCommand += new DataGridCommandEventHandler(this.DataGridRicerca_DeleteCommand);
      ((Button) this.BtnReset).Click += new EventHandler(this.BtnReset_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void Ricerca()
    {
      TheSite.Classi.ClassiAnagrafiche.Addetti addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
      this.txtsadd.set_DBDefaultValue((object) "%");
      this.txtsditta.set_DBDefaultValue((object) "%");
      this.cmbsGiorno.set_DBDefaultValue((object) "0");
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) ((Control) this.PanelRicerca).Controls);
      DataSet dataSet = addetti.GetDataAddRep(CollezioneControlli).Copy();
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

    private void BindGiorni()
    {
      ((ListControl) this.cmbsGiorno).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Addetti().GetDays().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsGiorno).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "giorno", "id", "- Selezionare un Giorno -", "0");
      ((ListControl) this.cmbsGiorno).DataTextField = "giorno";
      ((ListControl) this.cmbsGiorno).DataValueField = "id";
      ((Control) this.cmbsGiorno).DataBind();
    }

    private void btnsRicerca_Click(object sender, EventArgs e) => this.Ricerca();

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }

    private void DataGridRicerca_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
      int itemId = (int) short.Parse(e.CommandArgument.ToString());
      try
      {
        TheSite.Classi.ClassiAnagrafiche.Addetti addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_addetto_id");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) 0);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_giorno_id");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Value((object) 0);
        S_Object sObject3 = new S_Object();
        ((ParameterObject) sObject3).set_ParameterName("p_orain");
        ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject3).set_Index(2);
        ((ParameterObject) sObject3).set_Value((object) "%");
        S_Object sObject4 = new S_Object();
        ((ParameterObject) sObject4).set_ParameterName("p_oraout");
        ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject4).set_Index(3);
        ((ParameterObject) sObject4).set_Value((object) "%");
        CollezioneControlli.Add(sObject1);
        CollezioneControlli.Add(sObject2);
        CollezioneControlli.Add(sObject3);
        CollezioneControlli.Add(sObject4);
        string Operazione = "Delete";
        if (addetti.ExecuteUpdateAddRep(CollezioneControlli, Operazione, itemId) != -1)
          return;
        this.Ricerca();
      }
      catch (Exception ex)
      {
        ex.Message.ToString().ToUpper();
      }
    }

    private void DataGridRicerca_ItemCreated(object sender, DataGridItemEventArgs e) => ((WebControl) e.Item.FindControl("Imagebutton1"))?.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");

    private void BtnReset_Click(object sender, EventArgs e) => this.Response.Redirect("RepAddetti.aspx?FunId=" + (object) RepAddetti.FunId);
  }
}
