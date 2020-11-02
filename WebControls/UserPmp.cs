// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.UserPmp
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManProgrammata;

namespace TheSite.WebControls
{
  public class UserPmp : UserControl
  {
    protected S_TextBox txtmatricola;
    public string idTextRicMat = string.Empty;
    protected S_TextBox txtdescrizione;
    protected HtmlInputHidden txtid;
    public string idModuloMat = string.Empty;
    public string idEqStd = string.Empty;
    public DelegateCodicePMP DelegateCodicePMP1;

    private void Page_Load(object sender, EventArgs e)
    {
      this.idTextRicMat = ((Control) this.txtmatricola).ClientID;
      this.idModuloMat = this.ClientID;
      ((WebControl) this.txtdescrizione).Attributes.Add("readonly", "");
      SiteJavaScript.ShowFramePMP(this.Page, 1);
    }

    public S_TextBox Codice => this.txtmatricola;

    public S_TextBox Descrizione => this.txtdescrizione;

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((TextBox) this.txtmatricola).TextChanged += new EventHandler(this.txtmatricola_TextChanged);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void txtmatricola_TextChanged(object sender, EventArgs e)
    {
      if (((TextBox) this.txtmatricola).Text.Trim() == "")
      {
        this.txtid.Value = "0";
        ((TextBox) this.txtdescrizione).Text = "";
        if (this.DelegateCodicePMP1 == null)
          return;
        this.DelegateCodicePMP1(int.Parse(this.txtid.Value));
      }
      else
        this.Execute();
    }

    public S_TextBox Matricola => this.txtmatricola;

    public HtmlInputHidden CodiceNum => this.txtid;

    private void Execute()
    {
      ProcAndSteps procAndSteps = new ProcAndSteps();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(8);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.txtmatricola).Text);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_idEqst");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(8);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) 0);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_idServizio");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(8);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) 0);
      CollezioneControlli.Add(sObject3);
      DataSet dataSet = procAndSteps.GetAllPMP(CollezioneControlli).Copy();
      if (dataSet.Tables[0].Rows.Count == 1)
      {
        DataRow row = dataSet.Tables[0].Rows[0];
        ((TextBox) this.txtdescrizione).Text = row["descrizione"].ToString();
        ((TextBox) this.txtmatricola).Text = row["id"].ToString();
        this.txtid.Value = row["idnumerico"].ToString();
      }
      if (this.DelegateCodicePMP1 == null)
        return;
      this.DelegateCodicePMP1(int.Parse(this.txtid.Value));
    }
  }
}
