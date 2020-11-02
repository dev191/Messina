// Decompiled with JetBrains decompiler
// Type: TheSite.SoddisfazioneCliente.KPI_vod_report
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.ManProgrammata;

namespace TheSite.SoddisfazioneCliente
{
  public class KPI_vod_report : Page
  {
    protected Label lblAnno;
    protected Button BtGenera;
    protected Button BtSalva;
    protected DropDownList DropMeseFine;
    protected DropDownList DropMeseIni;
    protected Label Label1;
    protected DropDownList DropAnno;
    protected Label lblMessage;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      this.BtGenera.Attributes.Add("onClick", "checkMesi();return false;");
      this.LoadCombo();
    }

    private void LoadCombo()
    {
      InvioDocPmP invioDocPmP = new InvioDocPmP();
      for (int index = 2008; index <= 2028; ++index)
        this.DropAnno.Items.Add(new ListItem(index.ToString(), index.ToString()));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.BtGenera.Click += new EventHandler(this.BtGenera_Click);
      this.BtSalva.Click += new EventHandler(this.BtSalva_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void BtGenera_Click(object sender, EventArgs e)
    {
      this.BtSalva.Visible = true;
      string str = new KPIVod.KPIVod(ConfigurationSettings.AppSettings["ConnectionString"]).WriteReport(Path.Combine(this.Server.MapPath("../MasterExcel"), "KPI_Vodafone.xls"), Path.Combine(this.Server.MapPath("../Doc_Db"), "KPI\\KPI Vod\\KPI Eseguiti"), Convert.ToInt32(this.DropMeseIni.SelectedValue), Convert.ToInt32(this.DropMeseFine.SelectedValue), Convert.ToInt32(this.DropAnno.SelectedValue));
      this.Response.ClearContent();
      this.Response.ClearHeaders();
      this.Response.ContentType = "application/vnd.ms-excel";
      this.Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileName(str));
      this.Response.WriteFile(str);
      this.Response.Flush();
      this.Response.Close();
      if (!File.Exists(str))
        return;
      File.Delete(str);
    }

    private void BtSalva_Click(object sender, EventArgs e)
    {
      string path = new KPIVod.KPIVod(ConfigurationSettings.AppSettings["ConnectionString"]).WriteReport(Path.Combine(this.Server.MapPath("../MasterExcel"), "KPI_Vodafone.xls"), Path.Combine(this.Server.MapPath("../Doc_Db"), "KPI\\KPI Vod\\KPI Eseguiti"), Convert.ToInt32(this.DropMeseIni.SelectedValue), Convert.ToInt32(this.DropMeseFine.SelectedValue), Convert.ToInt32(this.DropAnno.SelectedValue));
      TheSite.Classi.SoddCliente.KPI kpi = new TheSite.Classi.SoddCliente.KPI();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("P_NOMEFILE");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) Path.GetFileName(path));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("P_USERNAME");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Value((object) this.Context.User.Identity.Name);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("P_DATESTART");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Value((object) (this.DropMeseIni.SelectedValue + "/" + this.DropAnno.SelectedValue));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("P_DATEEND");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Size(10);
      ((ParameterObject) sObject4).set_Value((object) (this.DropMeseFine.SelectedValue + "/" + this.DropAnno.SelectedValue));
      CollezioneControlli.Add(sObject4);
      kpi.SaveReportVod(CollezioneControlli);
      string script = "<script language=JavaScript>alert('Il file è stato salvato correttamente.');</script>";
      if (this.IsClientScriptBlockRegistered("clientScriptexp"))
        return;
      this.RegisterStartupScript("clientScriptexp", script);
    }
  }
}
