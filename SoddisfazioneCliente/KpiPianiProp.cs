// Decompiled with JetBrains decompiler
// Type: TheSite.SoddisfazioneCliente.KpiPianiProp
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi.SoddCliente;
using TheSite.WebControls;

namespace TheSite.SoddisfazioneCliente
{
  public class KpiPianiProp : Page
  {
    protected DropDownList DrPriorita;
    protected DropDownList DropAnno;
    protected S_Button btnsRicerca;
    protected S_Button btnReset;
    protected Repeater Repeater1;
    protected DropDownList DrMese;
    protected Repeater Repeater2;
    protected Repeater Repeater3;
    protected HtmlTable pianiMens;
    protected HtmlTable totAtt;
    protected RicercaModulo RicercaModulo1;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      this.LoadAnno();
    }

    private void LoadAnno()
    {
      for (int index = 2008; index <= 2020; ++index)
        this.DropAnno.Items.Add(new ListItem(index.ToString(), index.ToString()));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e) => this.Ricerca();

    private void Ricerca()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_mese");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) this.DrMese.SelectedValue);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_anno");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Size(4);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) this.DropAnno.SelectedValue);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_idbl");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Size(4);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) this.RicercaModulo1.BlId);
      CollezioneControlli.Add(sObject3);
      this.Repeater1.DataSource = (object) new Soddisfato().GetPianiMensili(CollezioneControlli);
      this.Repeater1.DataBind();
    }
  }
}
