// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorretiva.AccorpaRdl
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManOrdinaria;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorretiva
{
  public class AccorpaRdl : Page
  {
    protected LinkButton RicAccorpante;
    protected LinkButton RicAccorpate;
    protected S_ComboBox cmbsServizio;
    protected CompareValidator CompareValidator1;
    protected S_TextBox txtRdl;
    protected PageTitle PageTitle1;
    protected CalendarPicker CalendarPicker1;
    protected CalendarPicker CalendarPicker2;
    protected RicercaModulo RicercaModulo1;
    protected GridTitle GridTitle1;
    protected Addetti Addetti1;
    protected Richiedenti Richiedenti1;
    public static int FunId = 0;
    protected S_Label lblDescription;
    protected HtmlInputHidden HiddenVisible;
    protected LinkButton VisualAccorpate;
    protected DataPanel DataPanel1;
    protected S_TextBox txtsRichiesta;
    protected S_TextBox txtsOrdine;
    protected S_ComboBox cmbsStatus;
    protected S_ComboBox cmbsUrgenza;
    protected S_TextBox txtDescrizione;
    protected S_ComboBox cmbsGruppo;
    protected S_Button btnsRicerca;
    protected DataGrid DataGridRicerca;
    protected S_Button btAccorpa;
    protected HtmlTable TableAccorpa;
    protected S_Label lblStato;
    protected S_Button btReset;
    protected S_Label lblPadreAccorpante;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      ((WebControl) this.txtRdl).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtRdl).Attributes.Add("onpaste", "return nonpaste();");
      ((WebControl) this.txtsRichiesta).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsRichiesta).Attributes.Add("onpaste", "return nonpaste();");
      ((WebControl) this.txtsOrdine).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsOrdine).Attributes.Add("onpaste", "return nonpaste();");
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      AccorpaRdl.FunId = siteModule.ModuleId;
      AccorpaRdl.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindServizio);
      if (!this.IsPostBack)
      {
        if (this.Request.QueryString["FunId"] != null)
          this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
        if (this.Context.Items[(object) "ric"] != null)
          this.HiddenVisible.Value = (string) this.Context.Items[(object) "ric"];
        if (this.Request.QueryString["ric"] != null)
          this.HiddenVisible.Value = this.Request.QueryString["ric"];
        if (this.Context.Items[(object) "rdl"] != null)
          ((TextBox) this.txtRdl).Text = (string) this.Context.Items[(object) "rdl"];
        ((Control) this.DataPanel1).Visible = false;
        this.CompareValidator1.ControlToValidate = this.CalendarPicker2.ID + ":" + ((Control) this.CalendarPicker2.Datazione).ID;
        this.CompareValidator1.ControlToCompare = this.CalendarPicker1.ID + ":" + ((Control) this.CalendarPicker1.Datazione).ID;
        this.DataGridRicerca.Visible = false;
        this.GridTitle1.Visible = false;
        ((Control) this.GridTitle1.hplsNuovo).Visible = false;
        this.TableAccorpa.Visible = false;
        this.BindServizio("");
        this.BindGruppo();
        this.BindUrgenza();
        this.BindStatus();
        this.Session.Remove("CheckedList");
      }
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("if (typeof(validaContenuto) == 'function') { ");
      stringBuilder.Append("if (validaContenuto() == false) { return false; }} ");
      stringBuilder.Append(this.Page.GetPostBackEventReference((Control) this.RicAccorpate));
      stringBuilder.Append(";");
      this.RicAccorpate.Attributes.Add("onclick", stringBuilder.ToString());
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.GridTitle1.NumeroRecords = "";
      this.SetVisible();
    }

    private void SetVisible()
    {
      if (this.HiddenVisible.Value == "1")
      {
        ((Label) this.lblDescription).Text = "Visualizza Accorpate";
        ((Control) this.cmbsStatus).Visible = false;
        ((Control) this.lblStato).Visible = false;
      }
      else if (this.HiddenVisible.Value == "2")
        ((Label) this.lblDescription).Text = "Criteri ricerca RdL Accorpante";
      else if (this.HiddenVisible.Value == "3")
        ((Label) this.lblDescription).Text = "Criteri ricerca Accorpate";
      if (!(this.HiddenVisible.Value == "1") && !(this.HiddenVisible.Value == "2") && !(this.HiddenVisible.Value == "3"))
        return;
      ((Control) this.DataPanel1).Visible = true;
    }

    private void BindStatus()
    {
      ((ListControl) this.cmbsStatus).Items.Clear();
      Richiesta richiesta = new Richiesta();
      DataSet dataSet1 = new DataSet();
      DataSet dataSet2 = !(this.HiddenVisible.Value == "3") ? richiesta.GetStatusAccorpa() : richiesta.GetStatus();
      if (dataSet2.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsStatus).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet2.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Stato -", "");
        ((ListControl) this.cmbsStatus).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsStatus).DataValueField = "ID";
        ((Control) this.cmbsStatus).DataBind();
      }
      else
        ((ListControl) this.cmbsStatus).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Stato -", string.Empty));
    }

    private void BindServizio(string CodEdificio)
    {
      this.Addetti1.Set_BL_ID(CodEdificio);
      this.DataGridRicerca.Visible = false;
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      Servizi servizi = new Servizi(this.Context.User.Identity.Name);
      DataSet data;
      if (CodEdificio != "")
      {
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) CodEdificio);
        ((ParameterObject) sObject1).set_Size(8);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_ID_Servizio");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Value((object) 0);
        CollezioneControlli.Add(sObject1);
        CollezioneControlli.Add(sObject2);
        data = servizi.GetData(CollezioneControlli);
      }
      else
        data = servizi.GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "0");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("Non Definito", "-1"));
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("Non Definito", "-1"));
    }

    private void BindGruppo()
    {
      ((ListControl) this.cmbsGruppo).Items.Clear();
      DataSet guppo = new GestioneRdl(this.Context.User.Identity.Name).GetGuppo();
      if (guppo.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsGruppo).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(guppo.Tables[0], "descrizione", "richiedenti_tipo_id", "- Selezionare un Gruppo -", "");
        ((ListControl) this.cmbsGruppo).DataTextField = "descrizione";
        ((ListControl) this.cmbsGruppo).DataValueField = "richiedenti_tipo_id";
        ((Control) this.cmbsGruppo).DataBind();
      }
      else
        ((ListControl) this.cmbsGruppo).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Gruppo -", string.Empty));
    }

    private void BindUrgenza()
    {
      ((ListControl) this.cmbsUrgenza).Items.Clear();
      DataSet urgenza = new GestioneRdl(this.Context.User.Identity.Name).GetUrgenza();
      if (urgenza.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsUrgenza).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(urgenza.Tables[0], "descrizione", "id_priority", "- Selezionare una Urgenza -", "");
        ((ListControl) this.cmbsUrgenza).DataTextField = "descrizione";
        ((ListControl) this.cmbsUrgenza).DataValueField = "id_priority";
        ((Control) this.cmbsUrgenza).DataBind();
      }
      else
        ((ListControl) this.cmbsUrgenza).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Urgenza -", string.Empty));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.VisualAccorpate.Click += new EventHandler(this.VisualAccorpate_Click);
      this.RicAccorpante.Click += new EventHandler(this.RicAccorpante_Click);
      this.RicAccorpate.Click += new EventHandler(this.RicAccorpate_Click);
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      ((Button) this.btReset).Click += new EventHandler(this.btReset_Click);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
      ((Button) this.btAccorpa).Click += new EventHandler(this.btAccorpa_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void RicAccorpate_Click(object sender, EventArgs e)
    {
      this.Context.Items[(object) "ric"] = (object) "3";
      this.Context.Items[(object) "rdl"] = (object) ((TextBox) this.txtRdl).Text;
      this.Server.Transfer("AccorpaRdl.aspx");
    }

    private void RicAccorpante_Click(object sender, EventArgs e)
    {
      this.Context.Items[(object) "ric"] = (object) "2";
      this.Server.Transfer("AccorpaRdl.aspx");
    }

    private void VisualAccorpate_Click(object sender, EventArgs e)
    {
      this.Context.Items[(object) "ric"] = (object) "1";
      this.Server.Transfer("AccorpaRdl.aspx");
    }

    private void RicercaAccorpante() => this.BindRicerche(new TheSite.Classi.ManProgrammata.AccorpaRdl(this.Context.User.Identity.Name).Accorpante(this.CreaCriteri()));

    private void RicercaAccorpate() => this.BindRicerche(new TheSite.Classi.ManProgrammata.AccorpaRdl(this.Context.User.Identity.Name).Accorpate(this.CreaCriteri()));

    private void VisualizzaAccorpate() => this.BindRicerche(new TheSite.Classi.ManProgrammata.AccorpaRdl(this.Context.User.Identity.Name).VisualizzaAccorpate(this.CreaCriteri()));

    private void BindRicerche(DataSet Ds)
    {
      if (Ds.Tables[0].Rows.Count > 0)
      {
        this.GridTitle1.Visible = true;
        this.DataGridRicerca.Visible = true;
        this.DataGridRicerca.Columns[6].HeaderText = !(this.HiddenVisible.Value == "1") ? "Stato" : "Accorpante";
        this.DataGridRicerca.DataSource = (object) Ds.Tables[0];
        this.DataGridRicerca.DataBind();
        this.GridTitle1.NumeroRecords = Ds.Tables[0].Rows.Count.ToString();
        if (this.HiddenVisible.Value == "3")
        {
          this.TableAccorpa.Visible = true;
          this.DataGridRicerca.Columns[0].Visible = true;
          ((Label) this.lblPadreAccorpante).Text = ((TextBox) this.txtRdl).Text;
        }
        else
        {
          this.DataGridRicerca.Columns[0].Visible = false;
          this.TableAccorpa.Visible = false;
        }
      }
      else
      {
        this.GridTitle1.Visible = false;
        this.DataGridRicerca.Visible = false;
        this.TableAccorpa.Visible = false;
      }
    }

    private S_ControlsCollection CreaCriteri()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_campus");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.RicercaModulo1.TxtRicerca).Text);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Wr_Id");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Value((object) (((TextBox) this.txtsRichiesta).Text == "" ? 0 : int.Parse(((TextBox) this.txtsRichiesta).Text)));
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_Addetto");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Value((object) this.Addetti1.NomeCompleto);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_DataDa");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Size(10);
      ((ParameterObject) sObject5).set_Value(((TextBox) this.CalendarPicker1.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_DataA");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size(10);
      ((ParameterObject) sObject6).set_Value(((TextBox) this.CalendarPicker2.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      controlsCollection.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_Wo_Id");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Size(50);
      ((ParameterObject) sObject7).set_Value((object) (((TextBox) this.txtsOrdine).Text == "" ? 0 : int.Parse(((TextBox) this.txtsOrdine).Text)));
      controlsCollection.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_ID_Servizio");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      controlsCollection.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_Status");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(8);
      if (this.HiddenVisible.Value == "1")
        ((ParameterObject) sObject9).set_Value((object) 3);
      else
        ((ParameterObject) sObject9).set_Value((object) (((ListControl) this.cmbsStatus).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsStatus).SelectedValue)));
      controlsCollection.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_Richiedente");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(9);
      ((ParameterObject) sObject10).set_Size(50);
      ((ParameterObject) sObject10).set_Value((object) this.Richiedenti1.NomeCompleto);
      controlsCollection.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_Priority");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(10);
      ((ParameterObject) sObject11).set_Value((object) (((ListControl) this.cmbsUrgenza).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsUrgenza).SelectedValue)));
      controlsCollection.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_Descrizione");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(11);
      ((ParameterObject) sObject12).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject12).set_Value((object) ((TextBox) this.txtDescrizione).Text);
      controlsCollection.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_Gruppo");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(12);
      ((ParameterObject) sObject13).set_Value((object) (((ListControl) this.cmbsGruppo).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsGruppo).SelectedValue)));
      controlsCollection.Add(sObject13);
      if (this.HiddenVisible.Value == "3")
      {
        S_Object sObject14 = new S_Object();
        ((ParameterObject) sObject14).set_ParameterName("p_RDL_PADRE");
        ((ParameterObject) sObject14).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject14).set_Index(13);
        ((ParameterObject) sObject14).set_Size(50);
        ((ParameterObject) sObject14).set_Value((object) (((TextBox) this.txtRdl).Text == "" ? 0 : int.Parse(((TextBox) this.txtRdl).Text)));
        controlsCollection.Add(sObject14);
      }
      return controlsCollection;
    }

    private void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      DataRowView dataItem = (DataRowView) e.Item.DataItem;
      Label label = new Label();
      switch (this.HiddenVisible.Value)
      {
        case "1":
          e.Item.Cells[1].Controls.Add((Control) new Label()
          {
            Text = dataItem["WO"].ToString()
          });
          label.Text = dataItem["Accorpante"].ToString();
          e.Item.Cells[6].Controls.Add((Control) label);
          break;
        case "2":
          e.Item.Cells[1].Controls.Add((Control) new HyperLink()
          {
            NavigateUrl = ("javascript:seleziona('" + dataItem["WR"].ToString() + "');"),
            Text = dataItem["WO"].ToString()
          });
          label.Text = dataItem["Status"].ToString();
          e.Item.Cells[6].Controls.Add((Control) label);
          break;
        default:
          e.Item.Cells[1].Controls.Add((Control) new Label()
          {
            Text = dataItem["WO"].ToString()
          });
          label.Text = dataItem["Status"].ToString();
          e.Item.Cells[6].Controls.Add((Control) label);
          break;
      }
      if (this.Session["CheckedList"] == null)
        return;
      Hashtable hashtable = (Hashtable) this.Session["CheckedList"];
      int num = int.Parse(dataItem["WR"].ToString());
      if (!hashtable.ContainsKey((object) num))
        return;
      ((CheckBox) e.Item.Cells[0].FindControl("ckaccorpate")).Checked = bool.Parse(hashtable[(object) num].ToString());
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.Session.Remove("CheckedList");
      this.DataGridRicerca.CurrentPageIndex = 0;
      switch (this.HiddenVisible.Value)
      {
        case "2":
          this.RicercaAccorpante();
          break;
        case "3":
          this.RicercaAccorpate();
          break;
        default:
          this.VisualizzaAccorpate();
          break;
      }
    }

    private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      switch (this.HiddenVisible.Value)
      {
        case "2":
          this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
          this.RicercaAccorpante();
          break;
        case "3":
          this.MemorizzaCheck();
          this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
          this.RicercaAccorpate();
          break;
        default:
          this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
          this.VisualizzaAccorpate();
          break;
      }
    }

    private void MemorizzaCheck()
    {
      Hashtable hashtable = new Hashtable();
      foreach (DataGridItem dataGridItem in this.DataGridRicerca.Items)
      {
        int num = int.Parse(dataGridItem.Cells[3].Text);
        if (this.Session["CheckedList"] != null)
          hashtable = (Hashtable) this.Session["CheckedList"];
        CheckBox control = (CheckBox) dataGridItem.Cells[0].FindControl("ckaccorpate");
        if (hashtable.ContainsKey((object) num))
          hashtable.Remove((object) num);
        hashtable.Add((object) num, (object) control.Checked);
        this.Session.Remove("CheckedList");
        this.Session.Add("CheckedList", (object) hashtable);
      }
    }

    private void btAccorpa_Click(object sender, EventArgs e)
    {
      this.MemorizzaCheck();
      if (this.Session["CheckedList"] == null)
        return;
      IDictionaryEnumerator enumerator = ((Hashtable) this.Session["CheckedList"]).GetEnumerator();
      TheSite.Classi.ManProgrammata.AccorpaRdl accorpaRdl = new TheSite.Classi.ManProgrammata.AccorpaRdl(this.Context.User.Identity.Name);
      accorpaRdl.beginTransaction();
      try
      {
        while (enumerator.MoveNext())
        {
          if (Convert.ToBoolean(enumerator.Value))
          {
            S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
            S_Object sObject1 = new S_Object();
            ((ParameterObject) sObject1).set_ParameterName("p_wr_padre");
            ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject1).set_Index(0);
            ((ParameterObject) sObject1).set_Value((object) int.Parse(((Label) this.lblPadreAccorpante).Text));
            CollezioneControlli.Add(sObject1);
            S_Object sObject2 = new S_Object();
            ((ParameterObject) sObject2).set_ParameterName("p_wr_figlia");
            ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject2).set_Index(1);
            ((ParameterObject) sObject2).set_Value((object) Convert.ToInt32(enumerator.Key));
            CollezioneControlli.Add(sObject2);
            S_Object sObject3 = new S_Object();
            ((ParameterObject) sObject3).set_ParameterName("p_utente");
            ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
            ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject3).set_Index(2);
            ((ParameterObject) sObject3).set_Size(50);
            ((ParameterObject) sObject3).set_Value((object) this.Context.User.Identity.Name);
            CollezioneControlli.Add(sObject3);
            accorpaRdl.Add(CollezioneControlli);
          }
        }
        accorpaRdl.commitTransaction();
        this.Session.Remove("CheckedList");
        this.DataGridRicerca.CurrentPageIndex = 0;
        this.RicercaAccorpate();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private void btReset_Click(object sender, EventArgs e)
    {
      string empty = string.Empty;
      string str;
      if ((str = this.HiddenVisible.Value) != null)
      {
        if ((object) string.IsInterned(str) != (object) "1")
          ;
      }
      this.Response.Redirect("AccorpaRdl.aspx?FunId=" + this.ViewState["FunId"]);
    }
  }
}
