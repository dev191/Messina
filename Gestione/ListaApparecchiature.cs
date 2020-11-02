// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.ListaApparecchiature
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
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class ListaApparecchiature : Page
  {
    protected DataGrid DataGrid1;
    protected RicercaModulo RicercaModulo1;
    protected PageTitle PageTitle1;
    protected GridTitleServer GridTitleServer1;
    protected HtmlInputHidden hiddenblid;
    private clMyCollection _myColl = new clMyCollection();
    protected DataPanel DataPanel1;
    protected S_Button btRicerca;
    protected S_Button brreset;
    private DescrizioneApparecchiatura _fp = (DescrizioneApparecchiatura) null;
    public static int FunId = 0;
    protected S_ComboBox cmbsPiano;
    protected S_ComboBox cmbsServizio;
    protected RequiredFieldValidator RQServizio;
    protected S_ComboBox cmbsApparecchiatura;
    protected CodiceApparecchiature CodiceApparecchiature1;
    protected UserStanze UserStanze1;
    public static string HelpLink = string.Empty;

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      this.GridTitleServer1.hplsNuovo.Visible = siteModule.IsEditable;
      this.DataGrid1.Columns[0].Visible = siteModule.IsEditable;
      this.DataGrid1.Columns[1].Visible = siteModule.IsEditable;
      ListaApparecchiature.FunId = this.Request.QueryString["FunId"] == null ? siteModule.ModuleId : Convert.ToInt32(this.Request.QueryString["FunId"]);
      ListaApparecchiature.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      this.RicercaModulo1.DelegateIDBLEdificio1 += new DelegateIDBLEdificio(this.BindBl);
      this.RicercaModulo1.DelegateIDBLEdificio1 += new DelegateIDBLEdificio(this.BindPiano);
      this.RicercaModulo1.DelegateIDBLEdificio1 += new DelegateIDBLEdificio(this.BindApparecchiatura);
      this.CodiceApparecchiature1.NameComboApparecchiature = "cmbsApparecchiatura";
      this.CodiceApparecchiature1.NameComboServizio = "cmbsServizio";
      this.CodiceApparecchiature1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.UserStanze1.NameComboPiano = "cmbsPiano";
      this.GridTitleServer1.NuovoRec1 += new NuovoRec(this.btNuovo);
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("if (typeof(seledificio) == 'function') { ");
      stringBuilder.Append("if (seledificio() == false) { return false; }} ");
      stringBuilder.Append("this.value = 'Attendere ...';");
      stringBuilder.Append("this.disabled = true;");
      stringBuilder.Append("document.getElementById('" + ((Control) this.btRicerca).ClientID + "').disabled = true;");
      stringBuilder.Append(this.Page.GetPostBackEventReference((Control) this.btRicerca));
      stringBuilder.Append(";");
      ((WebControl) this.btRicerca).Attributes.Add("onclick", stringBuilder.ToString());
      if (this.IsPostBack)
        return;
      this.GridTitleServer1.hplsNuovo.Visible = false;
      ((WebControl) this.cmbsServizio).Enabled = false;
      ((WebControl) this.cmbsPiano).Enabled = false;
      ((WebControl) this.cmbsApparecchiatura).Enabled = false;
      this.CodiceApparecchiature1.Visible = false;
      this.GridTitleServer1.NumeroRecords = "";
      if (!(this.Context.Handler is DescrizioneApparecchiatura))
        return;
      this._fp = (DescrizioneApparecchiatura) this.Context.Handler;
      if (this._fp == null)
        return;
      this._myColl = this._fp._Contenitore;
      this._myColl.SetValues(this.Page.Controls);
      this.GridTitleServer1.hplsNuovo.Visible = true;
      this.BindServizio(this.IDBL);
      this.BindApparecchiatura(((ListControl) this.cmbsServizio).SelectedValue);
      this.BindPiano(this.IDBL);
      this.execute();
    }

    private void btNuovo(string sender)
    {
      if (((ListControl) this.cmbsServizio).SelectedIndex == 0 || ((ListControl) this.cmbsServizio).SelectedIndex == -1)
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Context.Items.Add((object) "CODEDI", (object) this.RicercaModulo1.BlId);
      this.Context.Items.Add((object) "IDBL", (object) this.IDBL);
      this.Context.Items.Add((object) "SDESCRIZIONE", (object) ((ListControl) this.cmbsServizio).Items[((ListControl) this.cmbsServizio).SelectedIndex].Text);
      this.Context.Items.Add((object) "SID", (object) ((ListControl) this.cmbsServizio).SelectedValue);
      this.Server.Transfer("DescrizioneApparecchiatura.aspx");
    }

    public void imageButton_Click(object sender, CommandEventArgs e)
    {
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Context.Items.Add((object) "CODEDI", (object) this.RicercaModulo1.BlId);
      this.Context.Items.Add((object) "IDBL", (object) this.IDBL);
      string[] strArray = e.CommandArgument.ToString().Split(Convert.ToChar(","));
      this.Context.Items.Add((object) "IDEQ", (object) strArray[0]);
      this.Context.Items.Add((object) "DISMESSO", (object) strArray[1]);
      this.Server.Transfer("DescrizioneApparecchiatura.aspx");
    }

    private string IDBL
    {
      get => this.hiddenblid.Value;
      set => this.hiddenblid.Value = value;
    }

    private void BindBl(string idbl)
    {
      this.DataGrid1.CurrentPageIndex = 0;
      this.GridTitleServer1.hplsNuovo.Visible = true;
      if (idbl != "")
      {
        this.IDBL = idbl;
        ((WebControl) this.cmbsServizio).Enabled = true;
        ((WebControl) this.cmbsPiano).Enabled = true;
        ((WebControl) this.cmbsApparecchiatura).Enabled = true;
        this.CodiceApparecchiature1.Visible = true;
        this.BindServizio(this.IDBL);
        this.BindPiano(this.IDBL);
        this.execute();
      }
      else
      {
        string script = "<script language=JavaScript>alert('Selezionare un Edificio!');" + "<" + "/" + "script>";
        if (!this.IsStartupScriptRegistered("clientScriptedificio"))
          this.RegisterStartupScript("clientScriptedificio", script);
        this.IDBL = "";
        ((ListControl) this.cmbsServizio).Items.Clear();
        ((WebControl) this.cmbsServizio).Enabled = false;
        ((WebControl) this.cmbsPiano).Enabled = false;
        ((WebControl) this.cmbsApparecchiatura).Enabled = false;
        this.CodiceApparecchiature1.Visible = false;
      }
    }

    private void execute()
    {
      DatiApparecchiatura datiApparecchiatura = new DatiApparecchiatura(this.Context.User.Identity.Name);
      int itemId = 0;
      if (this.IDBL != "")
        itemId = int.Parse(this.IDBL);
      if (((ListControl) this.cmbsServizio).SelectedIndex == 0)
      {
        this.RQServizio.Visible = true;
      }
      else
      {
        int id_servizio = int.Parse(((ListControl) this.cmbsServizio).SelectedValue.Split(Convert.ToChar(" "))[0]);
        int id_piano = int.Parse(((ListControl) this.cmbsPiano).SelectedValue.Split(Convert.ToChar(" "))[0]);
        int id_codapp = !(this.CodiceApparecchiature1.CodiceHidden.Value == "") ? int.Parse(this.CodiceApparecchiature1.CodiceHidden.Value) : -1;
        string descStanza = this.UserStanze1.DescStanza;
        int id_stapp = !(((ListControl) this.cmbsApparecchiatura).SelectedValue == "") ? int.Parse(((ListControl) this.cmbsApparecchiatura).SelectedValue) : -1;
        DataSet apparecchiature = datiApparecchiatura.GetApparecchiature(itemId, id_servizio, id_piano, descStanza, id_stapp, id_codapp);
        if (apparecchiature.Tables[0].Rows.Count > 0)
        {
          this.DataGrid1.Visible = true;
          this.DataGrid1.DataSource = (object) apparecchiature.Tables[0];
          this.DataGrid1.DataBind();
        }
        else
          this.DataGrid1.Visible = false;
        if (this.IDBL != "")
          this.GridTitleServer1.NumeroRecords = string.Format("Apparecchiature legate all'edificio: {0}", (object) apparecchiature.Tables[0].Rows.Count.ToString());
        else
          this.GridTitleServer1.hplsNuovo.Visible = false;
      }
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsServizio).SelectedIndexChanged += new EventHandler(this.cmbsServizio_SelectedIndexChanged);
      ((ListControl) this.cmbsApparecchiatura).SelectedIndexChanged += new EventHandler(this.cmbsApparecchiatura_SelectedIndexChanged);
      ((Button) this.btRicerca).Click += new EventHandler(this.btRicerca_Click);
      ((Button) this.brreset).Click += new EventHandler(this.brreset_Click);
      this.DataGrid1.ItemCreated += new DataGridItemEventHandler(this.DataGrid1_ItemCreated);
      this.DataGrid1.ItemCommand += new DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
      this.DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
      this.DataGrid1.ItemDataBound += new DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.execute();
    }

    private void DeleteItem(string id)
    {
      Console.WriteLine(id);
      if (id == "")
        return;
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) int.Parse(id));
      CollezioneControlli.Add(sObject);
      try
      {
        DatiApparecchiatura datiApparecchiatura = new DatiApparecchiatura(this.Context.User.Identity.Name);
        DataSet apparecchiatura = datiApparecchiatura.GetApparecchiatura(int.Parse(id));
        if (apparecchiatura.Tables[0].Rows.Count > 0)
          this.deleteFile(apparecchiatura.Tables[0].Rows[0]);
        datiApparecchiatura.Delete(CollezioneControlli, 0);
        this.DataGrid1.CurrentPageIndex = 0;
        this.execute();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        this.Page.RegisterStartupScript("messaggio", "<script language'javascript'>alert(\"Impossibile cancellare l'apparecchiatura perchè è utilizzata in altre tabelle\");</script>");
      }
    }

    private void deleteFile(DataRow Dr)
    {
      try
      {
        string path = Path.Combine(this.Server.MapPath("../EQImages"), Dr["image_eq_assy"].ToString());
        if (!File.Exists(path))
          return;
        File.Delete(path);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        this.Page.RegisterStartupScript("messaggio", "<script language'javascript'>alert(\"Impossibile cancellare il file immagine probabilmente in uso.\");</script>");
      }
    }

    private void DataGrid1_ItemCreated(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.EditItem)
        return;
      ((WebControl) e.Item.Cells[1].Controls[1]).Attributes.Add("onclick", "return confirm(\"Sei sicuro di Cancellare l'apparecchiatura?\");");
    }

    private void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Pager || e.Item.ItemType == ListItemType.Header)
        return;
      ImageButton commandSource = (ImageButton) e.CommandSource;
      if (!(commandSource.CommandName == "Delete"))
        return;
      this.DeleteItem(commandSource.CommandArgument);
    }

    private void BindServizio(string CodEdificio)
    {
      ((WebControl) this.cmbsServizio).Enabled = true;
      ((WebControl) this.cmbsApparecchiatura).Enabled = true;
      this.CodiceApparecchiature1.Visible = true;
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet allServiziEdifici = new DatiApparecchiatura(this.Context.User.Identity.Name).GetAllServiziEdifici(int.Parse(CodEdificio));
      if (allServiziEdifici.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(allServiziEdifici.Tables[0], "DESCRIZIONE", "ID", "- Selezionare un Servizio -", "");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "ID";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", string.Empty));
    }

    private void BindPiano(string CodEdificio)
    {
      ((ListControl) this.cmbsPiano).Items.Clear();
      if (CodEdificio == "")
        CodEdificio = "0";
      DataSet pianiBuilding = new TheSite.Classi.ClassiAnagrafiche.Buildings().GetPianiBuilding(int.Parse(CodEdificio));
      if (pianiBuilding.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsPiano).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(pianiBuilding.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "-1");
        ((ListControl) this.cmbsPiano).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsPiano).DataValueField = "ID";
        ((Control) this.cmbsPiano).DataBind();
      }
      else
        ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", "-1"));
      ((WebControl) this.cmbsPiano).Enabled = true;
    }

    private void btRicerca_Click(object sender, EventArgs e)
    {
      if (this.IDBL == "")
      {
        this.DataGrid1.CurrentPageIndex = 0;
        this.DataGrid1.Visible = false;
        this.GridTitleServer1.hplsNuovo.Visible = true;
        this.GridTitleServer1.NumeroRecords = "";
      }
      else
      {
        this.DataGrid1.CurrentPageIndex = 0;
        this.DataGrid1.Visible = false;
        this.GridTitleServer1.hplsNuovo.Visible = true;
        this.execute();
      }
    }

    private void brreset_Click(object sender, EventArgs e) => this.Response.Redirect("ListaApparecchiature.aspx?FunId=" + (object) ListaApparecchiature.FunId);

    private void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton1")).Attributes.Add("title", "Modifica");
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton2")).Attributes.Add("title", "Elimina");
      if (!(e.Item.Cells[7].Text.Trim().ToUpper() == "DISMESSA"))
        return;
      e.Item.ForeColor = Color.Tomato;
      e.Item.ToolTip = "Apparecchiatura Dismessa";
    }

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e) => this.BindApparecchiatura(this.RicercaModulo1.BlId);

    private void BindApparecchiatura(string CodEdificio)
    {
      ((ListControl) this.cmbsApparecchiatura).Items.Clear();
      Apparecchiature apparecchiature = new Apparecchiature(this.Context.User.Identity.Name);
      if (CodEdificio != string.Empty && ((ListControl) this.cmbsServizio).SelectedValue != "0")
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
        string[] strArray = ((ListControl) this.cmbsServizio).SelectedValue.Split(Convert.ToChar(" "));
        ((ParameterObject) sObject2).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == "" ? 0 : int.Parse(strArray[0])));
        CollezioneControlli.Add(sObject2);
        DataSet dataSet = apparecchiature.GetDataServizi(CollezioneControlli).Copy();
        if (dataSet.Tables[0].Rows.Count > 0)
        {
          ((BaseDataBoundControl) this.cmbsApparecchiatura).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Standard -", "-1");
          ((ListControl) this.cmbsApparecchiatura).DataTextField = "DESCRIZIONE";
          ((ListControl) this.cmbsApparecchiatura).DataValueField = "ID";
          ((Control) this.cmbsApparecchiatura).DataBind();
        }
        else
          ((ListControl) this.cmbsApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuno Standard -", "0"));
        ((WebControl) this.cmbsApparecchiatura).Enabled = true;
        this.CodiceApparecchiature1.Visible = true;
      }
      else
        ((ListControl) this.cmbsApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuno Standard -", "0"));
    }

    private void cmbsApparecchiatura_SelectedIndexChanged(object sender, EventArgs e) => this.CodiceApparecchiature1.CodiceApparecchiatura = "";
  }
}
