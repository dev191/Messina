// Decompiled with JetBrains decompiler
// Type: WebCad.Apparecchiature.VisualDWF
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebCad.Classi.AnagrafeImpianti;
using WebCad.WebControls;

namespace WebCad.Apparecchiature
{
  public class VisualDWF : Page
  {
    protected DataPanel DataPanel1;
    protected Repeater Repeater1;
    protected Literal Literal1;
    protected PageTitle PageTitle1;
    private string _filname;
    private string _vvf = string.Empty;
    private string _ispesl = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      this.PageTitle1.VisibleLogut = false;
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["var_afm_dwgs_dwg_name"] != null)
      {
        this.vvf = this.Request.QueryString["var_vvf"] == null ? string.Empty : this.Request.QueryString["var_vvf"];
        this.ispesl = this.Request.QueryString["var_ispesl"] == null ? string.Empty : this.Request.QueryString["var_ispesl"];
        this.filname = this.Request.QueryString["var_afm_dwgs_dwg_name"];
        this.Execute();
      }
      if (this.Context.Items[(object) "var_afm_dwgs_dwg_name"] == null)
        return;
      this.vvf = this.Context.Items[(object) "var_vvf"] == null ? string.Empty : (string) this.Context.Items[(object) "var_vvf"];
      this.ispesl = this.Context.Items[(object) "var_ispesl"] == null ? string.Empty : (string) this.Context.Items[(object) "var_ispesl"];
      this.filname = (string) this.Context.Items[(object) "var_afm_dwgs_dwg_name"];
      this.Execute();
    }

    private string filname
    {
      get => this._filname;
      set => this._filname = value;
    }

    private string ispesl
    {
      get => this._ispesl;
      set => this._ispesl = value;
    }

    private string vvf
    {
      get => this._vvf;
      set => this._vvf = value;
    }

    private void Execute()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_filname");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) this.filname);
      ((ParameterObject) sObject).set_Size(50);
      CollezioneControlli.Add(sObject);
      DataSet data = new DocDWF().GetData(CollezioneControlli);
      this.Repeater1.DataSource = (object) data;
      this.Repeater1.DataBind();
      if (data.Tables[0].Rows.Count <= 0)
        return;
      this.GetFile(data.Tables[0].Rows[0]["var_percorso_root"].ToString(), data.Tables[0].Rows[0]["var_percorso_child"].ToString());
    }

    private void GetFile(string PathRoot, string PathChild)
    {
      PathRoot = PathRoot.Replace(" ", "_");
      PathChild = PathChild.Replace(" ", "_").Replace("/", "_");
      string str1 = "../Doc_DB/" + PathRoot + "/" + PathChild + "/" + this.filname;
      string empty = string.Empty;
      if (this.filname.ToUpper().EndsWith("DWF"))
      {
        string str2 = "codebase=\"http://www.autodesk.com/global/expressviewer/installer/ExpressViewerSetup_ITA.cab\"";
        this.Literal1.Text = "<embed src=\"" + str1 + "\" height=\"100%\" width=\"100%\" " + str2 + "></embed>";
      }
      else if (this.filname.ToUpper().EndsWith("PDF"))
      {
        string str2 = "type=\"application/pdf\"";
        this.Literal1.Text = "<embed src=\"" + str1 + "\" height=\"100%\" width=\"100%\" " + str2 + "></embed>";
      }
      else
        this.Literal1.Text = "<img src=\"" + str1 + "\" border=\"0\">";
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.Repeater1.ItemDataBound += new RepeaterItemEventHandler(this.Repeater1_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      DataRowView dataItem = (DataRowView) e.Item.DataItem;
      string str1 = string.Empty;
      if (this.vvf != string.Empty)
      {
        string str2 = str1 + "<td><b>Numero Fascicolo: </b>" + dataItem["var_afm_dwgs_n_fascicolo_vvf"] + "</td>\n" + "<td><b>Data Parere Favorevole: </b>" + dataItem["var_afm_dwgs_data_p_fav"] + "</td>\n";
        str1 = Convert.ToInt32(dataItem["var_afm_dwgs_collaudo"].ToString()) != 1 ? str2 + "<td><b>Collaudo: </b>NO</td>" : str2 + "<td><b>Collaudo: </b>SI</td>";
      }
      if (this.ispesl != string.Empty)
        str1 = str1 + "<td><b>Numero Matricola: </b>" + dataItem["var_afm_dwgs_matricola_ispesl"] + "</td>\n" + "<td><b>Data Prima Verifica: </b>" + dataItem["var_afm_dwgs_data_p_ver"] + "</td>\n" + "<td><b>Anno Scadenza: </b>" + dataItem["var_afm_dwgs_anno_scadenza"] + "</td>\n";
      ((Literal) e.Item.FindControl("lite")).Text = str1;
    }
  }
}
