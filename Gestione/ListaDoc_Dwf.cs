// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.ListaDoc_Dwf
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
  public class ListaDoc_Dwf : Page
  {
    protected DataGrid DataGrid1;
    private clMyCollection _myColl = new clMyCollection();
    protected HtmlInputHidden hiddenblid;
    protected DataPanel DataPanel1;
    protected RicercaModulo RicercaModulo1;
    protected GridTitleServer GridTitleServer1;
    protected S_Button btRicerca;
    protected S_Button btReset;
    protected S_Label lblError;
    protected PageTitle PageTitle1;
    private DescrizioneDoc_Dwf _fp = (DescrizioneDoc_Dwf) null;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      this.GridTitleServer1.hplsNuovo.Visible = siteModule.IsEditable;
      this.DataGrid1.Columns[0].Visible = siteModule.IsEditable;
      this.DataGrid1.Columns[1].Visible = siteModule.IsEditable;
      ListaDoc_Dwf.FunId = siteModule.ModuleId;
      ListaDoc_Dwf.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      this.RicercaModulo1.DelegateIDBLEdificio1 += new DelegateIDBLEdificio(this.BindBl);
      this.GridTitleServer1.NuovoRec1 += new NuovoRec(this.btNuovo);
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("this.value = 'Attendere ...';");
      stringBuilder.Append("this.disabled = true;");
      stringBuilder.Append("document.getElementById('" + ((Control) this.btRicerca).ClientID + "').disabled = true;");
      stringBuilder.Append(this.Page.GetPostBackEventReference((Control) this.btRicerca));
      stringBuilder.Append(";");
      ((WebControl) this.btRicerca).Attributes.Add("onclick", stringBuilder.ToString());
      this.GridTitleServer1.hplsNuovo.Visible = false;
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      this.GridTitleServer1.NumeroRecords = "";
      if (!(this.Context.Handler is DescrizioneDoc_Dwf))
        return;
      this._fp = (DescrizioneDoc_Dwf) this.Context.Handler;
      if (this._fp == null)
        return;
      this._myColl = this._fp._Contenitore;
      this._myColl.SetValues(this.Page.Controls);
      this.GridTitleServer1.hplsNuovo.Visible = true;
      this.execute();
    }

    private void btNuovo(string sender)
    {
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Context.Items.Add((object) "CODEDI", (object) this.RicercaModulo1.BlId);
      this.Context.Items.Add((object) "IDBL", (object) this.IDBL);
      this.Server.Transfer("DescrizioneDoc_Dwf.aspx");
    }

    public void imageButton_Click(object sender, CommandEventArgs e)
    {
      string str1 = ((string) e.CommandArgument).Split(Convert.ToChar(","))[0];
      string str2 = ((string) e.CommandArgument).Split(Convert.ToChar(","))[1];
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Context.Items.Add((object) "CODEDI", (object) this.RicercaModulo1.BlId);
      this.Context.Items.Add((object) "IDDOC", (object) str1);
      this.Context.Items.Add((object) "IDBL", (object) this.IDBL);
      this.Context.Items.Add((object) "FILE", (object) str2);
      this.Server.Transfer("DescrizioneDoc_Dwf.aspx");
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
      this.IDBL = idbl;
      this.execute();
    }

    private void execute()
    {
      ((Label) this.lblError).Text = "";
      AnagrafeDocDWF anagrafeDocDwf = new AnagrafeDocDWF(this.Context.User.Identity.Name);
      int itemId = 0;
      if (this.IDBL != "")
        itemId = int.Parse(this.IDBL);
      DataSet singleData = anagrafeDocDwf.GetSingleData(itemId);
      if (singleData.Tables[0].Rows.Count > 0)
      {
        this.DataGrid1.Visible = true;
        this.DataGrid1.DataSource = (object) singleData.Tables[0];
        this.DataGrid1.DataBind();
      }
      else
        this.DataGrid1.Visible = false;
      if (this.IDBL != "")
        this.GridTitleServer1.NumeroRecords = string.Format("Documenti legati all'edificio: {0}", (object) singleData.Tables[0].Rows.Count.ToString());
      else
        this.GridTitleServer1.hplsNuovo.Visible = false;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btRicerca).Click += new EventHandler(this.btRicerca_Click);
      ((Button) this.btReset).Click += new EventHandler(this.btReset_Click);
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

    public string valutastringa(object obj)
    {
      if (obj == DBNull.Value || !(obj.ToString() != ""))
        return string.Empty;
      return obj.ToString().Length > 50 ? obj.ToString().Substring(0, obj.ToString().IndexOf(" ", 30)) : obj.ToString();
    }

    public string valutatooltip(object obj) => obj != DBNull.Value && obj.ToString() != "" ? obj.ToString().Replace("'", "`") : string.Empty;

    private void DeleteItem(string id)
    {
      Console.WriteLine(id);
      ((Label) this.lblError).Text = "";
      if (id == "")
        return;
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_id_doc_dwf");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) int.Parse(id));
      CollezioneControlli.Add(sObject);
      AnagrafeDocDWF anagrafeDocDwf = new AnagrafeDocDWF(this.Context.User.Identity.Name);
      try
      {
        DataSet dataSet = anagrafeDocDwf.PathFileDoc(int.Parse(id));
        if (dataSet.Tables[0].Rows.Count > 0)
          this.deleteFile(dataSet.Tables[0].Rows[0]);
        anagrafeDocDwf.Delete(CollezioneControlli, 0);
        this.DataGrid1.CurrentPageIndex = 0;
        this.execute();
      }
      catch (Exception ex)
      {
        ((Label) this.lblError).Text = ex.Message;
      }
    }

    private void deleteFile(DataRow Dr)
    {
      string path1 = this.Server.MapPath("../Doc_DB");
      string path2_1 = Dr["Parent"].ToString().Replace(" ", "_").Replace("/", "_");
      string path2_2 = Dr["Child"].ToString().Replace(" ", "_").Replace("/", "_");
      string path = Path.Combine(Path.Combine(Path.Combine(path1, path2_1), path2_2), Dr["filename"].ToString());
      if (!File.Exists(path))
        return;
      File.Delete(path);
    }

    private void DataGrid1_ItemCreated(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.EditItem)
        return;
      ((WebControl) e.Item.Cells[1].Controls[1]).Attributes.Add("onclick", "return confirm('Sei sicuro di Cancellare il Documento?');");
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

    private void btReset_Click(object sender, EventArgs e) => this.Response.Redirect("ListaDoc_Dwf.aspx?FunId=" + this.ViewState["FunId"]);

    private void btRicerca_Click(object sender, EventArgs e)
    {
      if (this.IDBL == "")
      {
        string script = "<script language=JavaScript>alert('Selezionare un Edificio!');" + "<" + "/" + "script>";
        if (this.IsStartupScriptRegistered("clientScriptedificio"))
          return;
        this.RegisterStartupScript("clientScriptedificio", script);
      }
      else
      {
        this.DataGrid1.CurrentPageIndex = 0;
        this.GridTitleServer1.hplsNuovo.Visible = true;
        this.execute();
      }
    }

    private void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton1")).Attributes.Add("title", "Modifica");
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton2")).Attributes.Add("title", "Elimina");
    }
  }
}
