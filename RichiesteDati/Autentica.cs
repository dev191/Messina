// Decompiled with JetBrains decompiler
// Type: TheSite.RichiesteDati.Autentica
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using ApplicationSecurity;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace TheSite.RichiesteDati
{
  public class Autentica : Page
  {
    protected Label user;
    protected Label lblH;
    protected Label password;
    private string usr;
    private string pwd;

    private void Page_Load(object sender, EventArgs e)
    {
      try
      {
        this.user.Text = this.Request.Params["user"];
        this.password.Text = this.Request.Params["password"];
        this.usr = this.Request.Params["user"];
        this.pwd = new Sicurezza().EncryptMD5(this.Request.Params["password"]);
        S_ControlsCollection _SColl = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_UserName");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Size(50);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Value((object) this.usr);
        ((ParameterObject) sObject1).set_Index(0);
        _SColl.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_Password");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject2).set_Size(50);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Value((object) this.pwd);
        ((ParameterObject) sObject2).set_Index(1);
        _SColl.Add(sObject2);
        int num = new Utente().Login(_SColl);
        this.Response.Clear();
        this.Response.ClearHeaders();
        this.Response.ClearContent();
        this.Response.AddHeader("autenticato", num.ToString());
      }
      catch (Exception ex)
      {
        this.lblH.Text = ex.ToString();
      }
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
