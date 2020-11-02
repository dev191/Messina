// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.Schedula.OttimizzaPiano
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
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata.Schedula
{
  public class OttimizzaPiano : Page
  {
    protected DataPanel PanelRicerca;
    protected S_ComboBox cmbsAnno;
    protected S_ComboBox cmbsEdificio;
    protected S_ComboBox cmbsComune;
    protected S_Button btnsRicerca;
    protected DataGrid DataGridRicerca;
    protected PageTitle PageTitle1;
    protected GridTitle GridTitle1;
    public static string HelpLink = string.Empty;
    private clMyCollection _myColl = new clMyCollection();
    protected Button cmdReset;
    protected S_ComboBox cmbsServizio;
    private OttimizzaPianoEQ _fp;

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      OttimizzaPiano.HelpLink = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).HelpLink;
      this.PageTitle1.Title = "Ottimizza il Piano della Manutenzione Programmata";
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.Append("this.value = 'Attendere ...';");
      stringBuilder1.Append("this.disabled = true;");
      stringBuilder1.Append("document.getElementById('" + ((Control) this.btnsRicerca).ClientID + "').disabled = true;");
      stringBuilder1.Append(this.Page.GetPostBackEventReference((Control) this.btnsRicerca));
      stringBuilder1.Append(";");
      ((WebControl) this.btnsRicerca).Attributes.Add("onclick", stringBuilder1.ToString());
      StringBuilder stringBuilder2 = new StringBuilder();
      stringBuilder2.Append("document.getElementById('" + ((Control) this.cmbsComune).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsAnno).Attributes.Add("onchange", stringBuilder2.ToString());
      StringBuilder stringBuilder3 = new StringBuilder();
      stringBuilder3.Append("document.getElementById('" + ((Control) this.cmbsEdificio).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsComune).Attributes.Add("onchange", stringBuilder3.ToString());
      StringBuilder stringBuilder4 = new StringBuilder();
      stringBuilder4.Append("document.getElementById('" + ((Control) this.cmbsServizio).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsEdificio).Attributes.Add("onchange", stringBuilder4.ToString());
      if (this.IsPostBack)
        return;
      this.CaricaCombiAnni();
      this.BindControls();
      if (!(this.Context.Handler is OttimizzaPianoEQ))
        return;
      this._fp = (OttimizzaPianoEQ) this.Context.Handler;
      if (this._fp == null)
        return;
      this._myColl = this._fp._Contenitore;
      this._myColl.SetValues(this.Page.Controls);
      this.Ricerca(true);
    }

    private void CaricaCombiAnni() => ((ListControl) this.cmbsAnno).SelectedValue = DateTime.Now.Year.ToString();

    private void BindControls()
    {
      this.BindComuni(int.Parse(((ListControl) this.cmbsAnno).SelectedValue));
      this.BindEdifici(int.Parse(((ListControl) this.cmbsAnno).SelectedValue), 0);
      this.BindServizi(int.Parse(((ListControl) this.cmbsAnno).SelectedValue), 0, 0);
    }

    private void BindComuni(int anno)
    {
      ((ListControl) this.cmbsComune).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet comuni = new TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP().GetComuni(anno);
      if (comuni.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsComune).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(comuni.Tables[0], "COMUNE", "IDCOMUNE", "-- Selezionare un Comune --", "0");
        ((ListControl) this.cmbsComune).DataTextField = "COMUNE";
        ((ListControl) this.cmbsComune).DataValueField = "IDCOMUNE";
        ((Control) this.cmbsComune).DataBind();
      }
      else
        ((ListControl) this.cmbsComune).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Comune -", "0"));
    }

    private void BindEdifici(int anno, int id_comune)
    {
      ((ListControl) this.cmbsEdificio).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet edifici = new TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP().GetEdifici(anno, id_comune);
      if (edifici.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsEdificio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(edifici.Tables[0], "EDIFICIO", "IDEDIFICIO", "-- Selezionare un Edificio --", "0");
        ((ListControl) this.cmbsEdificio).DataTextField = "EDIFICIO";
        ((ListControl) this.cmbsEdificio).DataValueField = "IDEDIFICIO";
        ((Control) this.cmbsEdificio).DataBind();
      }
      else
        ((ListControl) this.cmbsEdificio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Edificio -", "0"));
    }

    private void BindServizi(int anno, int id_comune, int id_edificio)
    {
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet servizi = new TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP().GetServizi(anno, id_comune, id_edificio);
      if (servizi.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(servizi.Tables[0], "SERVIZIO", "IDSERVIZIO", "-- Selezionare un Servizio --", "0");
        ((ListControl) this.cmbsServizio).DataTextField = "SERVIZIO";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", "0"));
    }

    private S_ControlsCollection GetControl()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      this.cmbsComune.set_DBDefaultValue((object) "0");
      this.cmbsEdificio.set_DBDefaultValue((object) "0");
      this.cmbsServizio.set_DBDefaultValue((object) "0");
      int num1 = (int) short.Parse(((ListControl) this.cmbsAnno).SelectedValue);
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_anno");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(1);
      ((ParameterObject) sObject1).set_Size(10);
      ((ParameterObject) sObject1).set_Value((object) num1);
      controlsCollection.Add(sObject1);
      int num2 = 0;
      if (((ListControl) this.cmbsComune).SelectedValue != "0")
        num2 = int.Parse(((ListControl) this.cmbsComune).SelectedValue);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_comune");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(2);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Value((object) num2);
      controlsCollection.Add(sObject2);
      int num3 = 0;
      if (((ListControl) this.cmbsEdificio).SelectedValue != "0")
        num3 = int.Parse(((ListControl) this.cmbsEdificio).SelectedValue);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_edificio");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(3);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Value((object) num3);
      controlsCollection.Add(sObject3);
      int num4 = 0;
      if (((ListControl) this.cmbsServizio).SelectedValue != "0")
        num4 = int.Parse(((ListControl) this.cmbsServizio).SelectedValue);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_servizio");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(4);
      ((ParameterObject) sObject4).set_Size(10);
      ((ParameterObject) sObject4).set_Value((object) num4);
      controlsCollection.Add(sObject4);
      return controlsCollection;
    }

    private void Ricerca(bool reset)
    {
      S_ControlsCollection control1 = this.GetControl();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pageindex");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(16);
      ((ParameterObject) sObject1).set_Value((object) (this.DataGridRicerca.CurrentPageIndex + 1));
      control1.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pagesize");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(17);
      ((ParameterObject) sObject2).set_Value((object) this.DataGridRicerca.PageSize);
      control1.Add(sObject2);
      TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP creaOttimizzaRdlMp = new TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP();
      DataSet dataSet = creaOttimizzaRdlMp.GetDataPaging(control1).Copy();
      if (reset)
      {
        S_ControlsCollection control2 = this.GetControl();
        this.GridTitle1.NumeroRecords = creaOttimizzaRdlMp.GetDataCount(control2).ToString();
      }
      this.DataGridRicerca.Visible = true;
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.DataGridRicerca.DataBind();
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Ricerca(true);
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca(false);
    }

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    private void cmbsComune_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.BindEdifici(int.Parse(((ListControl) this.cmbsAnno).SelectedValue), int.Parse(((ListControl) this.cmbsComune).SelectedValue));
      this.BindServizi(int.Parse(((ListControl) this.cmbsAnno).SelectedValue), int.Parse(((ListControl) this.cmbsComune).SelectedValue), 0);
    }

    private void cmbsAnno_SelectedIndexChanged(object sender, EventArgs e) => this.BindControls();

    private void cmbsEdificio_SelectedIndexChanged(object sender, EventArgs e) => this.BindServizi(int.Parse(((ListControl) this.cmbsAnno).SelectedValue), int.Parse(((ListControl) this.cmbsComune).SelectedValue), int.Parse(((ListControl) this.cmbsEdificio).SelectedValue));

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsAnno).SelectedIndexChanged += new EventHandler(this.cmbsAnno_SelectedIndexChanged);
      ((ListControl) this.cmbsEdificio).SelectedIndexChanged += new EventHandler(this.cmbsEdificio_SelectedIndexChanged);
      ((ListControl) this.cmbsComune).SelectedIndexChanged += new EventHandler(this.cmbsComune_SelectedIndexChanged);
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.cmdReset.Click += new EventHandler(this.cmdReset_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void cmdReset_Click(object sender, EventArgs e) => this.Response.Redirect("OttimizzaPiano.aspx");
  }
}
