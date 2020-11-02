// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.GestioneCompleta
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
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManCorrettiva;
using TheSite.Classi.ManOrdinaria;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorrettiva
{
  public class GestioneCompleta : Page
  {
    public SiteModule _SiteModule;
    protected S_TextBox S_Txtrichiesta;
    protected S_TextBox S_Txtoperatore;
    protected S_TextBox S_Ttxtordinelavoro;
    protected S_ComboBox S_cbditta;
    protected S_ComboBox S_cbgruppo;
    protected S_TextBox S_Txtdescrizione;
    protected S_ComboBox S_Cburgenza;
    protected DataPanel DataPanel1;
    protected PageTitle PageTitle1;
    protected CalendarPicker CalendarPicker1;
    protected CalendarPicker CalendarPicker2;
    protected RicercaModulo RicercaModulo1;
    public static int FunId = 0;
    protected S_ComboBox cmbsServizio;
    protected S_Button S_Btreset;
    protected S_Button S_btMostra;
    protected DataGrid DataGrid1;
    protected GridTitle GridTitle1;
    protected TheSite.WebControls.Addetti Addetti1;
    protected TheSite.WebControls.Richiedenti Richiedenti1;
    private bool IsEditable = false;
    public static string HelpLink = string.Empty;
    private clMyCollection _myColl = new clMyCollection();
    protected CompareValidator CompareValidator1;
    protected S_Button cmdExcel;
    protected S_ComboBox cmbTipoManutenzione;
    private EditCompletamento _fp = (EditCompletamento) null;

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      this._SiteModule = new SiteModule("./ManutenzioneCorrettiva/GestioneCompleta.aspx");
      this.IsEditable = this._SiteModule.IsEditable;
      this.DataGrid1.Columns[0].Visible = this.IsEditable;
      GestioneCompleta.HelpLink = this._SiteModule.HelpLink;
      this.PageTitle1.Title = this._SiteModule.ModuleTitle;
      this.RicercaModulo1.DelegateIDBLEdificio1 += new DelegateIDBLEdificio(this.BindServizio);
      if (!this.IsPostBack)
      {
        if (this.Request.QueryString["FunId"] != null)
          this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
        this.CompareValidator1.ControlToValidate = this.CalendarPicker2.ID + ":" + ((Control) this.CalendarPicker2.Datazione).ID;
        this.CompareValidator1.ControlToCompare = this.CalendarPicker1.ID + ":" + ((Control) this.CalendarPicker1.Datazione).ID;
        this.LoadDitte();
        this.LoadGruppo();
        this.BindServizio("");
        this.Setvisible(false);
        if (this.Context.Handler is EditCompletamento)
        {
          this._fp = (EditCompletamento) this.Context.Handler;
          if (this._fp != null)
          {
            this._myColl = this._fp._Contenitore;
            this._myColl.SetValues(this.Page.Controls);
            this.Execute(true);
          }
        }
      }
      ((WebControl) this.S_Txtrichiesta).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.S_Txtrichiesta).Attributes.Add("onpaste", "return nonpaste();");
      ((WebControl) this.S_Ttxtordinelavoro).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.S_Ttxtordinelavoro).Attributes.Add("onpaste", "return nonpaste();");
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("if (typeof(Page_ClientValidate) == 'function') { ");
      stringBuilder.Append("if (Page_ClientValidate() == false) { return false; }} ");
      stringBuilder.Append("this.value = 'Attendere...';");
      stringBuilder.Append("this.disabled = true;");
      stringBuilder.Append(this.Page.GetPostBackEventReference((Control) this.S_btMostra));
      stringBuilder.Append(";");
      ((WebControl) this.S_btMostra).Attributes.Add("onclick", stringBuilder.ToString());
    }

    private void BindServizio(string CodEdificio)
    {
      this.LoadUrgenza(CodEdificio);
      int idprog = 0;
      if (this.Request.QueryString["VarApp"] != null)
        idprog = Convert.ToInt32(this.Request.QueryString["VarApp"].ToString());
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      Servizi servizi = new Servizi(this.Context.User.Identity.Name);
      DataSet dataSet = !(CodEdificio != "") ? servizi.GetServiziPerProg(idprog, 0) : servizi.GetServiziPerProg(idprog, int.Parse(CodEdificio));
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", string.Empty));
      this.Addetti1.Set_BL_ID(CodEdificio);
    }

    private void LoadUrgenza(string Codice)
    {
      string progetto = "";
      if (this.Request.QueryString["VarApp"] != null)
        progetto = this.Request.QueryString["VarApp"];
      if (Codice != "")
      {
        ((BaseDataBoundControl) this.S_Cburgenza).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new Urgenza().GetPriorita(Convert.ToInt32(Codice), progetto).Tables[0], "DESCRIPTION", "ID", "Selezionare una Priorità", "0");
        ((ListControl) this.S_Cburgenza).DataTextField = "DESCRIPTION";
        ((ListControl) this.S_Cburgenza).DataValueField = "ID";
        ((Control) this.S_Cburgenza).DataBind();
      }
      else
      {
        ((BaseDataBoundControl) this.S_Cburgenza).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new Urgenza().GetPriorita(0, progetto).Tables[0], "DESCRIPTION", "ID", "Selezionare una Priorità", "0");
        ((ListControl) this.S_Cburgenza).DataTextField = "DESCRIPTION";
        ((ListControl) this.S_Cburgenza).DataValueField = "ID";
        ((Control) this.S_Cburgenza).DataBind();
      }
    }

    private void LoadGruppo()
    {
      string id_prog = "";
      if (this.Request.QueryString["VarApp"] != null)
        id_prog = this.Request.QueryString["VarApp"];
      ((BaseDataBoundControl) this.S_cbgruppo).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new Richiedenti_tipo().GetAllAddProg(id_prog).Copy().Tables[0], "descrizione", "id", "Selezionare un Gruppo", "0");
      ((ListControl) this.S_cbgruppo).DataTextField = "descrizione";
      ((ListControl) this.S_cbgruppo).DataValueField = "id";
      ((Control) this.S_cbgruppo).DataBind();
    }

    private void LoadDitte()
    {
      ((ListControl) this.S_cbditta).Items.Clear();
      DataSet data = new GestioneRdl(this.Context.User.Identity.Name).GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.S_cbditta).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "descrizione", "ditta_id", "- Selezionare una Ditta -", "");
        ((ListControl) this.S_cbditta).DataTextField = "descrizione";
        ((ListControl) this.S_cbditta).DataValueField = "ditta_id";
        ((Control) this.S_cbditta).DataBind();
      }
      else
        ((ListControl) this.S_cbditta).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Ditta -", string.Empty));
    }

    private void Execute(bool reset)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_operatore");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.S_Txtoperatore).Text);
      ((ParameterObject) sObject1).set_Size(250);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_servizio_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_campus");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) this.RicercaModulo1.Campus);
      ((ParameterObject) sObject3).set_Size(250);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Value((object) this.RicercaModulo1.BlId);
      ((ParameterObject) sObject4).set_Size(250);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_wr_id");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Value((object) (((TextBox) this.S_Txtrichiesta).Text == "" ? 0 : int.Parse(((TextBox) this.S_Txtrichiesta).Text)));
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_wo_id");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject6).set_Value((object) (((TextBox) this.S_Ttxtordinelavoro).Text == "" ? 0 : int.Parse(((TextBox) this.S_Ttxtordinelavoro).Text)));
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_gruppo");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject7).set_Value((object) (((ListControl) this.S_cbgruppo).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.S_cbgruppo).SelectedValue)));
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_richiedente");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject8).set_Size(35);
      ((ParameterObject) sObject8).set_Value((object) this.Richiedenti1.NomeCompleto);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject9).set_Size(2000);
      ((ParameterObject) sObject9).set_Value((object) ((TextBox) this.S_Txtdescrizione).Text);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_urgenza");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject10).set_Value((object) (((ListControl) this.S_Cburgenza).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.S_Cburgenza).SelectedValue)));
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_ditta");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject11).set_Value((object) (((ListControl) this.S_cbditta).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.S_cbditta).SelectedValue)));
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_dates");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject12).set_Size(10);
      ((ParameterObject) sObject12).set_Value(((TextBox) this.CalendarPicker1.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_datee");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject13).set_Size(10);
      ((ParameterObject) sObject13).set_Value(((TextBox) this.CalendarPicker2.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("p_addetto");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject14).set_Size(250);
      ((ParameterObject) sObject14).set_Value((object) this.Addetti1.NomeCompleto);
      CollezioneControlli.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("p_tipomanutenzione");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject15).set_Value((object) int.Parse(((ListControl) this.cmbTipoManutenzione).SelectedValue));
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
      ClManCorrettiva clManCorrettiva = new ClManCorrettiva(this.Context.User.Identity.Name);
      this.DataGrid1.DataSource = (object) clManCorrettiva.GetDataCompletamento(CollezioneControlli).Tables[0];
      if (reset)
      {
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        int completamentoCount = clManCorrettiva.GetDataCompletamentoCount(CollezioneControlli);
        this.GridTitle1.NumeroRecords = completamentoCount.ToString();
        if (completamentoCount % this.DataGrid1.PageSize == 0)
        {
          int num1 = completamentoCount / this.DataGrid1.PageSize;
        }
        else
        {
          int num2 = completamentoCount / this.DataGrid1.PageSize;
        }
      }
      else
        double.Parse(this.GridTitle1.NumeroRecords);
      if (int.Parse(this.GridTitle1.NumeroRecords) > 0)
      {
        this.Setvisible(true);
        this.DataGrid1.Visible = true;
        this.GridTitle1.DescriptionTitle = "";
      }
      else
      {
        this.GridTitle1.DescriptionTitle = "Nessun dato trovato.";
        this.Setvisible(false);
      }
      this.DataGrid1.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.DataGrid1.DataBind();
    }

    private void Setvisible(bool visible)
    {
      this.DataGrid1.Visible = visible;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.GridTitle1.Visible = visible;
    }

    public string evalLenght(object sender)
    {
      if (sender == null || sender == DBNull.Value)
        return "";
      return sender.ToString().Length < 31 ? sender.ToString() : sender.ToString().Substring(0, 30);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.S_btMostra).Click += new EventHandler(this.S_btMostra_Click);
      ((Button) this.S_Btreset).Click += new EventHandler(this.S_Btreset_Click);
      ((Button) this.cmdExcel).Click += new EventHandler(this.cmdExcel_Click);
      this.DataGrid1.ItemCommand += new DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
      this.DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
      this.DataGrid1.ItemDataBound += new DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void S_Btreset_Click(object sender, EventArgs e)
    {
      string str = "";
      if (this.Request["VarApp"] != null)
        str = "&VarApp=" + this.Request["VarApp"];
      this.Response.Redirect("GestioneCompleta.aspx?FunId=" + this.ViewState["FunId"] + str);
    }

    private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.Execute(false);
    }

    private void S_btMostra_Click(object sender, EventArgs e)
    {
      this.DataGrid1.CurrentPageIndex = 0;
      this.Execute(true);
    }

    private void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[0].FindControl("lnkDett")).Attributes.Add("title", "Completa Ordine di Lavoro");
      if (e.Item.Cells[2].Text.Trim().Length > 20)
      {
        string str = e.Item.Cells[2].Text.Trim().Substring(0, 18) + "...";
        e.Item.Cells[2].ToolTip = e.Item.Cells[2].Text;
        e.Item.Cells[2].Text = str;
      }
      if (e.Item.Cells[11].Text.Trim().Length > 20)
      {
        string str = e.Item.Cells[11].Text.Trim().Substring(0, 18) + "...";
        e.Item.Cells[11].ToolTip = e.Item.Cells[11].Text;
        e.Item.Cells[11].Text = str;
      }
      if (e.Item.Cells[5].Text.Trim().Length > 12)
      {
        string str = e.Item.Cells[5].Text.Trim().Substring(0, 10) + "...";
        e.Item.Cells[5].ToolTip = e.Item.Cells[5].Text;
        e.Item.Cells[5].Text = str;
      }
      if (e.Item.Cells[8].Text.Trim().Length <= 12)
        return;
      string str1 = e.Item.Cells[8].Text.Trim().Substring(0, 10) + "...";
      e.Item.Cells[8].ToolTip = e.Item.Cells[8].Text;
      e.Item.Cells[8].Text = str1;
    }

    private void cmdExcel_Click(object sender, EventArgs e)
    {
      Export export = new Export();
      DataTable dataTable = new DataTable();
      DataTable table = this.GetWordExcel().Tables[0];
      if (table.Rows.Count != 0)
      {
        export.ExportDetails(table, (Export.ExportFormat) 2, "exp.xls");
      }
      else
      {
        string script = "<script language=JavaScript>alert('Nessun elemento da esportare');" + "<" + "/" + "script>";
        if (this.IsClientScriptBlockRegistered("clientScriptexp"))
          return;
        this.RegisterStartupScript("clientScriptexp", script);
      }
    }

    public DataSet GetWordExcel()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_operatore");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.S_Txtoperatore).Text);
      ((ParameterObject) sObject1).set_Size(250);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_servizio_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_campus");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) this.RicercaModulo1.Campus);
      ((ParameterObject) sObject3).set_Size(250);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Value((object) this.RicercaModulo1.BlId);
      ((ParameterObject) sObject4).set_Size(250);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_wr_id");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Value((object) (((TextBox) this.S_Txtrichiesta).Text == "" ? 0 : int.Parse(((TextBox) this.S_Txtrichiesta).Text)));
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_wo_id");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject6).set_Value((object) (((TextBox) this.S_Ttxtordinelavoro).Text == "" ? 0 : int.Parse(((TextBox) this.S_Ttxtordinelavoro).Text)));
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_gruppo");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject7).set_Value((object) (((ListControl) this.S_cbgruppo).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.S_cbgruppo).SelectedValue)));
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_richiedente");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject8).set_Size(35);
      ((ParameterObject) sObject8).set_Value((object) this.Richiedenti1.NomeCompleto);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject9).set_Size(2000);
      ((ParameterObject) sObject9).set_Value((object) ((TextBox) this.S_Txtdescrizione).Text);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_urgenza");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject10).set_Value((object) (((ListControl) this.S_Cburgenza).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.S_Cburgenza).SelectedValue)));
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_ditta");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject11).set_Value((object) (((ListControl) this.S_cbditta).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.S_cbditta).SelectedValue)));
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_dates");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject12).set_Size(10);
      ((ParameterObject) sObject12).set_Value(((TextBox) this.CalendarPicker1.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_datee");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject13).set_Size(10);
      ((ParameterObject) sObject13).set_Value(((TextBox) this.CalendarPicker2.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("p_addetto");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject14).set_Size(250);
      ((ParameterObject) sObject14).set_Value((object) this.Addetti1.NomeCompleto);
      CollezioneControlli.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("p_tipomanutenzione");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject15).set_Value((object) int.Parse(((ListControl) this.cmbTipoManutenzione).SelectedValue));
      CollezioneControlli.Add(sObject15);
      return new ClManCorrettiva(this.Context.User.Identity.Name).GetDataCompletamentoExcel(CollezioneControlli);
    }

    private void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      string str = "";
      if (this.Request["VarApp"] != null)
        str = "&VarApp=" + this.Request["VarApp"];
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString() + str);
    }
  }
}
