// Decompiled with JetBrains decompiler
// Type: TheSite.CommonPage.ChangePassword
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.CommonPage
{
  public class ChangePassword : Page
  {
    protected RequiredFieldValidator rfvPassword;
    protected MessagePanel PanelMess;
    protected S_TextBox txtsPasword;
    protected S_TextBox txtsNewPasword;
    protected S_TextBox txtsConfermaPasword;
    protected ValidationSummary ValidationSummary1;
    protected RequiredFieldValidator rfvconferma;
    protected RequiredFieldValidator rfvnuovapawd;
    protected CompareValidator CompareValidator1;
    protected Button BttConferma;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    private int i_IdUtente = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ChangePassword.FunId = siteModule.ModuleId;
      ChangePassword.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      this.BttConferma.Attributes.Add("onclick", "nascondi();");
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.BttConferma.Click += new EventHandler(this.BttConferma_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void BttConferma_Click(object sender, EventArgs e)
    {
      if (!this.IsValid)
        return;
      this.changePwd();
    }

    private void changePwd()
    {
      if (!this.IsUtente())
      {
        this.PanelMess.ShowError("Non hai inserito la Tua Password!", true);
      }
      else
      {
        Sicurezza sicurezza = new Sicurezza();
        Utente utente = new Utente();
        ((TextBox) this.txtsNewPasword).Text = sicurezza.EncryptMD5(((TextBox) this.txtsNewPasword).Text);
        S_ControlsCollection _SColl = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_Utente_Id");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) this.i_IdUtente);
        _SColl.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_Password");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Size(50);
        ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.txtsNewPasword).Text);
        _SColl.Add(sObject2);
        this.i_IdUtente = utente.ChangePassword(_SColl);
        if (this.i_IdUtente > 0)
          this.PanelMess.ShowMessage("Cambio Password completato con successo!", true);
        else
          this.PanelMess.ShowError("Errore nel cambio della Password!", true);
      }
    }

    private bool IsUtente()
    {
      Sicurezza sicurezza = new Sicurezza();
      Utente utente = new Utente();
      ((TextBox) this.txtsPasword).Text = sicurezza.EncryptMD5(((TextBox) this.txtsPasword).Text);
      string name = this.Context.User.Identity.Name;
      S_ControlsCollection _SColl = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_UserName");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) name);
      _SColl.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Password");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.txtsPasword).Text);
      _SColl.Add(sObject2);
      this.i_IdUtente = utente.Login(_SColl);
      return this.i_IdUtente > 0;
    }
  }
}
