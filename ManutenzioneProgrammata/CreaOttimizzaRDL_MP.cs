// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.CreaOttimizzaRDL_MP
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class CreaOttimizzaRDL_MP : Page
  {
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected GridTitle GridTitle1;
    public static string HelpLink = string.Empty;
    protected S_Button btnsCrea;
    protected S_Button btnsSelezionaTutti;
    protected S_Button btnsDeSelezionaTutti;
    protected S_Button btnsConfermaSelezioni;
    protected Label LblElementiSelezionati;
    protected TextBox txtTotSelezionati;
    protected PageTitle PageTitle1;
    protected S_ComboBox cmbsEdificio;
    protected S_ComboBox cmbsComune;
    protected S_ComboBox cmbsServizio;
    protected DataGrid DataGridRicerca;
    protected S_ComboBox cmbsAnno;
    protected Button cmdReset;
    protected Panel PanelCrea;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((WebControl) this.btnsRicerca).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsConfermaSelezioni).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsSelezionaTutti).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsDeSelezionaTutti).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsCrea).Attributes.Add("onclick", "Valorizza('1')");
      CreaOttimizzaRDL_MP.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = "Emetti Richieste di Lavoro";
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
      StringBuilder stringBuilder5 = new StringBuilder();
      stringBuilder4.Append("this.value = 'Attendere ...';");
      stringBuilder4.Append("this.disabled = true;");
      stringBuilder4.Append("document.getElementById('" + ((Control) this.btnsCrea).ClientID + "').disabled = true;");
      stringBuilder4.Append(this.Page.GetPostBackEventReference((Control) this.btnsCrea));
      stringBuilder4.Append(";");
      ((WebControl) this.btnsCrea).Attributes.Add("onclick", stringBuilder4.ToString());
      StringBuilder stringBuilder6 = new StringBuilder();
      stringBuilder4.Append("this.value = 'Attendere ...';");
      stringBuilder4.Append("this.disabled = true;");
      stringBuilder4.Append("document.getElementById('" + ((Control) this.btnsConfermaSelezioni).ClientID + "').disabled = true;");
      stringBuilder4.Append(this.Page.GetPostBackEventReference((Control) this.btnsConfermaSelezioni));
      stringBuilder4.Append(";");
      ((WebControl) this.btnsConfermaSelezioni).Attributes.Add("onclick", stringBuilder4.ToString());
      StringBuilder stringBuilder7 = new StringBuilder();
      stringBuilder4.Append("this.value = 'Attendere ...';");
      stringBuilder4.Append("this.disabled = true;");
      stringBuilder4.Append("document.getElementById('" + ((Control) this.btnsSelezionaTutti).ClientID + "').disabled = true;");
      stringBuilder4.Append(this.Page.GetPostBackEventReference((Control) this.btnsSelezionaTutti));
      stringBuilder4.Append(";");
      ((WebControl) this.btnsSelezionaTutti).Attributes.Add("onclick", stringBuilder4.ToString());
      StringBuilder stringBuilder8 = new StringBuilder();
      stringBuilder4.Append("this.value = 'Attendere ...';");
      stringBuilder4.Append("this.disabled = true;");
      stringBuilder4.Append("document.getElementById('" + ((Control) this.btnsDeSelezionaTutti).ClientID + "').disabled = true;");
      stringBuilder4.Append(this.Page.GetPostBackEventReference((Control) this.btnsDeSelezionaTutti));
      stringBuilder4.Append(";");
      ((WebControl) this.btnsDeSelezionaTutti).Attributes.Add("onclick", stringBuilder4.ToString());
      if (this.Page.IsPostBack)
        return;
      this.CaricaCombiAnni();
      this.BindControls();
      this.LblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
      this.txtTotSelezionati.Text = "0";
      this.Session.Remove("CheckedList");
      this.Session.Remove("DatiList");
      this.Session.Remove("DataSet");
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
      if (int.Parse(this.GridTitle1.NumeroRecords) > 0)
        this.PanelCrea.Visible = true;
      else
        this.PanelCrea.Visible = false;
    }

    private void GetControlli()
    {
      clMyDataGridCollection dataGridCollection = new clMyDataGridCollection();
      if (this.Session["CheckedList"] == null)
        return;
      dataGridCollection.GetControl(this.DataGridRicerca, (Hashtable) this.Session["CheckedList"], this.DataGridRicerca.CurrentPageIndex);
    }

    private void SetControlli()
    {
      clMyDataGridCollection dataGridCollection = new clMyDataGridCollection();
      Hashtable _HS = new Hashtable();
      if (this.Session["CheckedList"] != null)
        _HS = (Hashtable) this.Session["CheckedList"];
      Hashtable hashtable = dataGridCollection.SetControl(this.DataGridRicerca, _HS, this.DataGridRicerca.CurrentPageIndex);
      this.Session.Remove("CheckedList");
      this.Session.Add("CheckedList", (object) hashtable);
    }

    private void SetDati()
    {
      Hashtable hashtable = new Hashtable();
      if (this.Session["DatiList"] != null)
        hashtable = (Hashtable) this.Session["DatiList"];
      foreach (DataGridItem dataGridItem in this.DataGridRicerca.Items)
      {
        int num = int.Parse(dataGridItem.Cells[0].Text);
        CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        if (hashtable.ContainsKey((object) num))
          hashtable.Remove((object) num);
        if (control.Checked)
          hashtable.Add((object) num, (object) num);
      }
      this.Session.Remove("DatiList");
      this.Session.Add("DatiList", (object) hashtable);
      this.LblElementiSelezionati.Text = "Elementi Selezionati - " + hashtable.Count.ToString() + " -";
      this.txtTotSelezionati.Text = hashtable.Count.ToString();
    }

    private void SetDati(bool val)
    {
      Hashtable hashtable = new Hashtable();
      if (this.Session["DatiList"] != null)
        hashtable = (Hashtable) this.Session["DatiList"];
      foreach (DataGridItem dataGridItem in this.DataGridRicerca.Items)
      {
        int num = int.Parse(dataGridItem.Cells[0].Text);
        CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        control.Checked = val;
        if (hashtable.ContainsKey((object) num))
          hashtable.Remove((object) num);
        if (control.Checked)
          hashtable.Add((object) num, (object) num);
      }
      this.Session.Remove("DatiList");
      this.Session.Add("DatiList", (object) hashtable);
      this.LblElementiSelezionati.Text = "Elementi Selezionati - " + hashtable.Count.ToString() + " -";
      this.txtTotSelezionati.Text = hashtable.Count.ToString();
    }

    private void SelezionaTutti(bool val)
    {
      if (!val)
      {
        this.Session.Remove("CheckedList");
        this.Session.Remove("DatiList");
        this.LblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
        this.txtTotSelezionati.Text = "0";
      }
      else
        this.SetControlli();
      DataSet dataSet = new TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP().GetData(this.GetControl()).Copy();
      for (int index = 0; index <= this.DataGridRicerca.PageCount; ++index)
      {
        this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
        this.DataGridRicerca.DataBind();
        this.DataGridRicerca.CurrentPageIndex = index;
        this.SetDati(val);
        if (val)
          this.SetControlli();
      }
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Ricerca(true);
      this.GetControlli();
    }

    private void Resetta()
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.LblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
      this.txtTotSelezionati.Text = "0";
      this.Session.Remove("CheckedList");
      this.Session.Remove("DatiList");
    }

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
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      ((Button) this.btnsCrea).Click += new EventHandler(this.btnsCrea_Click);
      ((Button) this.btnsSelezionaTutti).Click += new EventHandler(this.btnsSelezionaTutti_Click);
      ((Button) this.btnsDeSelezionaTutti).Click += new EventHandler(this.btnsDeSelezionaTutti_Click);
      ((Button) this.btnsConfermaSelezioni).Click += new EventHandler(this.btnsConfermaSelezioni_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Resetta();
      this.Ricerca(true);
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca(false);
      this.GetControlli();
    }

    private void btnsConfermaSelezioni_Click(object sender, EventArgs e)
    {
      this.SetDati();
      this.SetControlli();
    }

    private void btnsSelezionaTutti_Click(object sender, EventArgs e) => this.SelezionaTutti(true);

    private void btnsDeSelezionaTutti_Click(object sender, EventArgs e) => this.SelezionaTutti(false);

    private void btnsCrea_Click(object sender, EventArgs e)
    {
      TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP creaOttimizzaRdlMp = new TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP();
      if (this.Session["DatiList"] != null)
      {
        creaOttimizzaRdlMp.beginTransaction();
        try
        {
          IDictionaryEnumerator enumerator = ((Hashtable) this.Session["DatiList"]).GetEnumerator();
          string empty = string.Empty;
          int num1 = 0;
          while (enumerator.MoveNext())
          {
            S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
            int num2 = (int) enumerator.Value;
            S_Object sObject1 = new S_Object();
            ((ParameterObject) sObject1).set_ParameterName("i_Indice");
            ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject1).set_Index(0);
            ((ParameterObject) sObject1).set_Value((object) num2);
            CollezioneControlli.Add(sObject1);
            S_Object sObject2 = new S_Object();
            ((ParameterObject) sObject2).set_ParameterName("p_UserName");
            ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
            ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject2).set_Index(1);
            ((ParameterObject) sObject2).set_Value((object) HttpContext.Current.User.Identity.Name);
            ((ParameterObject) sObject2).set_Size(50);
            CollezioneControlli.Add(sObject2);
            int num3 = creaOttimizzaRdlMp.Add(CollezioneControlli);
            num1 += num3;
          }
          creaOttimizzaRdlMp.commitTransaction();
          this.DataGridRicerca.CurrentPageIndex = 0;
          this.Resetta();
          this.Ricerca(true);
          SiteJavaScript.msgBox(this.Page, string.Format("SONO STATI INSERITI N. {0} Richieste di Lavoro.", (object) num1));
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          creaOttimizzaRdlMp.rollbackTransaction();
          string empty = string.Empty;
          SiteJavaScript.msgBox(this.Page, "Si è verificato un errore durante la creazione delle Richieste di Lavoro.");
        }
      }
      else
        SiteJavaScript.msgBox(this.Page, "Nessun Edificio selezionato.");
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      string str1 = e.Item.Cells[10].Text.Trim();
      if (str1.Length <= 0)
        return;
      string str2 = str1.Substring(2, 2);
      int mese = (int) short.Parse(str1.Substring(0, 2));
      string str3 = TheSite.Classi.Function.ImpostaMese(mese, false);
      e.Item.Cells[10].Text = str2 + " - " + str3;
      e.Item.Cells[10].ToolTip = str2 + " - " + TheSite.Classi.Function.ImpostaMese(mese, true);
    }

    private void cmbsComune_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.BindEdifici(int.Parse(((ListControl) this.cmbsAnno).SelectedValue), int.Parse(((ListControl) this.cmbsComune).SelectedValue));
      this.BindServizi(int.Parse(((ListControl) this.cmbsAnno).SelectedValue), int.Parse(((ListControl) this.cmbsComune).SelectedValue), 0);
    }

    private void cmbsAnno_SelectedIndexChanged(object sender, EventArgs e) => this.BindControls();

    private void cmbsEdificio_SelectedIndexChanged(object sender, EventArgs e) => this.BindServizi(int.Parse(((ListControl) this.cmbsAnno).SelectedValue), int.Parse(((ListControl) this.cmbsComune).SelectedValue), int.Parse(((ListControl) this.cmbsEdificio).SelectedValue));

    private void cmdReset_Click(object sender, EventArgs e) => this.Response.Redirect("CreaOttimizzaRDL_MP.aspx");
  }
}
