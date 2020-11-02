// Decompiled with JetBrains decompiler
// Type: TheSite.CommonPage.Sollecito
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.ManOrdinaria;
using TheSite.WebControls;

namespace TheSite.CommonPage
{
  public class Sollecito : Page
  {
    protected HyperLink HyperLink1;
    protected Panel PanelEdit;
    protected S_TextBox txtsMotivo;
    protected S_Button btnsAggiungi;
    protected HyperLink Hyperlink2;
    protected RichiedentiSollecito RichiedentiSollecito1;

    private void Page_Load(object sender, EventArgs e)
    {
      this.idric = this.Request.QueryString["idric"];
      ((WebControl) this.btnsAggiungi).Attributes.Add("onclick", "return ControllaRichiedente('" + ((Control) this.RichiedentiSollecito1.s_RichNome).ClientID + "','" + ((Control) this.RichiedentiSollecito1.s_RichCognome).ClientID + "')");
      if (this.Request.QueryString["VarApp"] == null)
        return;
      this.RichiedentiSollecito1.Progetto = this.Request.QueryString["VarApp"];
    }

    private string idric
    {
      get => (string) this.ViewState["s_Idric"];
      set => this.ViewState["s_Idric"] = (object) value;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsAggiungi).Click += new EventHandler(this.btnsAggiungi_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsAggiungi_Click(object sender, EventArgs e)
    {
      this.txtsMotivo.set_DBDefaultValue((object) DBNull.Value);
      ((TextBox) this.txtsMotivo).Text = ((TextBox) this.txtsMotivo).Text.Trim();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_ID_RICHIEDENTE");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Size(10);
      ((ParameterObject) sObject1).set_Value((object) int.Parse(((TextBox) this.RichiedentiSollecito1.s_RichID).Text));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_NomeCompleto");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) this.RichiedentiSollecito1.NomeCompleto.ToString());
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_CognomeCompleto");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Value((object) this.RichiedentiSollecito1.CognomeCompleto.ToString());
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_ID_Gruppo");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Value((object) Convert.ToInt32(this.RichiedentiSollecito1.IdGruppo));
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_Motivo");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Size(50);
      ((ParameterObject) sObject5).set_Value((object) ((TextBox) this.txtsMotivo).Text);
      CollezioneControlli.Add(sObject5);
      new Solleciti().ExecuteAddSollecito(CollezioneControlli, int.Parse(this.idric));
      string script = "<script language=JavaScript>\n" + "var oVDiv=parent.document.getElementById('PopupAddSoll').style;\n" + "oVDiv.display = 'none';" + "<" + "/" + "script>";
      if (this.IsStartupScriptRegistered("clientScriptChiudi"))
        return;
      this.RegisterStartupScript("clientScriptChiudi", script);
    }
  }
}
