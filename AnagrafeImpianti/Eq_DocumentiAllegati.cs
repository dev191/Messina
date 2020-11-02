// Decompiled with JetBrains decompiler
// Type: TheSite.AnagrafeImpianti.Eq_DocumentiAllegati
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;
using TheSite.WebControls;

namespace TheSite.AnagrafeImpianti
{
  public class Eq_DocumentiAllegati : Page
  {
    protected DataGrid MyDataGrid1;
    protected int id_eq = 0;
    protected S_Label S_lblcodicecomponente;
    protected S_Label S_lblstdapparecchiature;
    protected S_Label S_Lblservizio;
    protected S_Label S_lblcodiceedificio;
    protected S_Label S_lbledificio;
    protected S_Label S_lblpiano;
    protected S_Label S_lblstanza;
    protected string eq_id = "";
    protected PageTitle PageTitle1;
    protected string BtnHidden;

    private void Page_Load(object sender, EventArgs e)
    {
      this.BtnHidden = string.Empty;
      if (this.Request["FromWebCad"] != null)
      {
        this.BtnHidden = "style=\"visibility: hidden\"";
        this.PageTitle1.VisibleLogut = false;
      }
      if (this.Request.QueryString["eq_id"] != null)
      {
        this.eq_id = this.Request.QueryString["eq_id"];
        this.PageTitle1.Title = "Documenti Allegato per l'apparecchiatura " + this.eq_id;
      }
      if (!(this.Request.QueryString["id_eq"] != ""))
        return;
      this.id_eq = int.Parse(this.Request["id_eq"]);
      this.BindGrid();
      this.DettagliApparecchiatura();
    }

    private void DettagliApparecchiatura()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_eq_std");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) this.eq_id);
      ((ParameterObject) sObject).set_Size(50);
      CollezioneControlli.Add(sObject);
      DataSet data = new SchedaApparecchiatura("").GetData(CollezioneControlli);
      if (data.Tables[0].Rows.Count <= 0)
        return;
      ((Label) this.S_lblcodicecomponente).Text = data.Tables[0].Rows[0]["var_eq_eq_id"].ToString();
      ((Label) this.S_lblstdapparecchiature).Text = data.Tables[0].Rows[0]["var_eqstd_description"].ToString();
      ((Label) this.S_lblcodiceedificio).Text = data.Tables[0].Rows[0]["var_eq_bl_id"].ToString();
      ((Label) this.S_lbledificio).Text = data.Tables[0].Rows[0]["var_bl_name"].ToString();
      ((Label) this.S_lblpiano).Text = data.Tables[0].Rows[0]["var_eq_fl_id"].ToString();
      ((Label) this.S_Lblservizio).Text = data.Tables[0].Rows[0]["servizio"].ToString();
      try
      {
        ((Label) this.S_lblstanza).Text = data.Tables[0].Rows[0]["stanza"].ToString();
      }
      catch (Exception ex)
      {
        this.Response.Write(ex.Message);
      }
    }

    private void BindGrid()
    {
      AllegatiEQ allegatiEq = new AllegatiEQ();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_eq");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Size(10);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) this.id_eq);
      CollezioneControlli.Add(sObject);
      this.MyDataGrid1.DataSource = (object) allegatiEq.GetData(CollezioneControlli).Copy().Tables[0];
      this.MyDataGrid1.DataBind();
      this.MyDataGrid1.ShowFooter = false;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
