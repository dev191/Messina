// Decompiled with JetBrains decompiler
// Type: TheSite.AnagrafeImpianti.Apparecchiatura
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
using TheSite.Classi;
using TheSite.Classi.ClassiDettaglio;
using TheSite.WebControls;

namespace TheSite.AnagrafeImpianti
{
  public class Apparecchiatura : Page
  {
    protected RequiredFieldValidator rfvQtyUnit;
    protected TextBox txtDescrizione;
    protected RequiredFieldValidator rfvProductName;
    protected S_ComboBox S_Cbtipologia;
    protected Button btnSalva;
    protected PageTitle PageTitle1;
    protected Panel PanelDatoTecnico;
    protected Panel PanelGriglia;
    protected DataGrid DataGrid1;
    protected Label lblDescrizioneApparecchiatura;
    protected GridTitleServer GridTitleServer1;
    protected GridTitleServer GridTitleServer2;
    private DataView dvApparecchiature;
    protected ValidationSummary ValidationSummary1;
    private int idstd = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      this.GridTitleServer1.NuovoRec1 += new NuovoRec(this.btNuovo);
      this.GridTitleServer2.NuovoRec1 += new NuovoRec(this.btnewtipologia);
      this.PageTitle1.VisibleLogut = false;
      if (!this.IsPostBack)
      {
        if (this.Context.Items[(object) "EQ_ID"] != null)
          this.EQ_ID = (string) this.Context.Items[(object) "EQ_ID"];
        if (this.Context.Items[(object) "IDEQ"] != null)
          this.IDEQ = (string) this.Context.Items[(object) "IDEQ"];
        if (this.Request.QueryString["EQ_ID"] != null)
          this.EQ_ID = this.Request.QueryString["EQ_ID"];
        if (this.Request.QueryString["IDEQ"] != null)
          this.IDEQ = this.Request.QueryString["IDEQ"];
        this.Session.Remove("dvApparecchiature");
        this.GetDataSource();
        this.BindDatiTecnici();
      }
      this.GridTitleServer1.hplsNuovo.Text = "Nuovo Dato Tecnico";
      this.GridTitleServer2.hplsNuovo.Text = "Inserisci una Nuova Tipologia Tecnica";
      this.GridTitleServer2.lblRecord.Visible = false;
      this.GridTitleServer2.hplsNuovo.CausesValidation = false;
    }

    private void BindDatiTecnici()
    {
      TheSite.Classi.ClassiDettaglio.DatiTecnici datiTecnici = new TheSite.Classi.ClassiDettaglio.DatiTecnici("");
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) Convert.ToInt32(this.IDEQ));
      CollezioneControlli.Add(sObject);
      DataSet dataApp = datiTecnici.GetDataApp(CollezioneControlli);
      if (dataApp.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.S_Cbtipologia).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataApp.Tables[0], "DESCRIZIONE", "ID", "- Selezionare la Descrizione Tecnica -", "");
        ((ListControl) this.S_Cbtipologia).DataTextField = "DESCRIZIONE";
        ((ListControl) this.S_Cbtipologia).DataValueField = "ID";
        ((Control) this.S_Cbtipologia).DataBind();
        this.ID_APPARECCHIATURA = dataApp.Tables[0].Rows[0]["EQSTD_ID"].ToString();
      }
      else
      {
        ((ListControl) this.S_Cbtipologia).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Descrizione Tecnica -", string.Empty));
        this.RecuperaStd();
      }
    }

    private void RecuperaStd()
    {
      TheSite.Classi.ClassiDettaglio.DatiTecnici datiTecnici = new TheSite.Classi.ClassiDettaglio.DatiTecnici("");
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_eqid");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) Convert.ToInt32(this.IDEQ));
      CollezioneControlli.Add(sObject);
      DataSet dataSet = datiTecnici.RecStd(CollezioneControlli);
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      this.ID_APPARECCHIATURA = dataSet.Tables[0].Rows[0]["id"].ToString();
      this.lblDescrizioneApparecchiatura.Text = string.Format("<b>Codice Apparecchiatura:</b> {0} <b>Descrizione:</b> {1}", (object) this.EQ_ID, dataSet.Tables[0].Rows[0]["description"]);
    }

    private void GetDataSource()
    {
      DataSet dataSet = new DataSet()
      {
        Tables = {
          new DataTable("tecniche")
          {
            Columns = {
              new DataColumn("id", typeof (int)),
              new DataColumn("eq_id", typeof (string)),
              new DataColumn("eqstd_id", typeof (int)),
              new DataColumn("eqstdapparecchiatura_id", typeof (int)),
              new DataColumn("tipologia", typeof (string)),
              new DataColumn("descrizione", typeof (string))
            }
          }
        }
      };
      DataSet singleDatitecnici = new DatiTecniciApparecchiatura(this.Context.User.Identity.Name).GetSingleDatitecnici(int.Parse(this.IDEQ));
      this.Session["dvApparecchiature"] = (object) singleDatitecnici;
      this.dvApparecchiature = ((DataSet) this.Session["dvApparecchiature"]).Tables[0].DefaultView;
      if (singleDatitecnici.Tables[0].Rows.Count > 0)
      {
        this.lblDescrizioneApparecchiatura.Text = string.Format("<b>Codice Apparecchiatura:</b> {0} <b>Descrizione:</b> {1}", (object) this.EQ_ID, singleDatitecnici.Tables[0].Rows[0]["description"]);
        this.ID_APPARECCHIATURA = singleDatitecnici.Tables[0].Rows[0]["EQSTD_ID"].ToString();
        this.GridTitleServer1.Visible = true;
        this.GridTitleServer1.NumeroRecords = string.Format("Record: {0}", (object) singleDatitecnici.Tables[0].Rows.Count);
        this.DataGrid1.DataSource = (object) singleDatitecnici.Tables[0];
        this.DataGrid1.DataBind();
      }
      else
      {
        this.GridTitleServer1.NumeroRecords = "Nessun Dato Tecnico";
        this.DataGrid1.DataSource = (object) singleDatitecnici.Tables[0];
        this.DataGrid1.DataBind();
        this.RecuperaStd();
      }
    }

    private string EQ_ID
    {
      get => this.ViewState[nameof (EQ_ID)] != null ? (string) this.ViewState[nameof (EQ_ID)] : string.Empty;
      set => this.ViewState[nameof (EQ_ID)] = (object) value;
    }

    private string IDEQ
    {
      get => this.ViewState[nameof (IDEQ)] != null ? (string) this.ViewState[nameof (IDEQ)] : string.Empty;
      set => this.ViewState[nameof (IDEQ)] = (object) value;
    }

    private string ID_APPARECCHIATURA
    {
      get => this.ViewState[nameof (ID_APPARECCHIATURA)] != null ? (string) this.ViewState[nameof (ID_APPARECCHIATURA)] : string.Empty;
      set => this.ViewState[nameof (ID_APPARECCHIATURA)] = (object) value;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DataGrid1.ItemCreated += new DataGridItemEventHandler(this.DataGrid1_ItemCreated);
      this.DataGrid1.ItemCommand += new DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
      this.btnSalva.Click += new EventHandler(this.btnSalva_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btNuovo(string sender)
    {
      this.PanelDatoTecnico.Visible = true;
      this.txtDescrizione.Text = "";
      this.btnSalva.CommandArgument = "Add";
    }

    private void btnewtipologia(string sender)
    {
      this.Context.Items.Add((object) "ID_APPARECCHIATURA", (object) this.ID_APPARECCHIATURA);
      this.Context.Items.Add((object) "EQ_ID", (object) this.EQ_ID);
      this.Context.Items.Add((object) "IDEQ", (object) this.IDEQ);
      this.Server.Transfer("DatiTecnici.aspx");
    }

    private void btnSalva_Click(object sender, EventArgs e)
    {
      if (!this.IsValid)
        return;
      this.SaveItem();
    }

    private void SaveItem()
    {
      if (this.btnSalva.CommandArgument == "Add")
      {
        this.execute(0, "Insert");
      }
      else
      {
        string operazione = "Update";
        int int32 = Convert.ToInt32(this.DataGrid1.DataKeys[this.DataGrid1.SelectedIndex]);
        this.PanelDatoTecnico.Visible = false;
        this.execute(int32, operazione);
      }
    }

    private void execute(int id, string operazione)
    {
      DatiTecniciApparecchiatura tecniciApparecchiatura = new DatiTecniciApparecchiatura(this.Context.User.Identity.Name);
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_eqdatitecniciid");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) id);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_eq_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) this.IDEQ);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_eqstdapparecchiatura");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      int num = 0;
      if (((ListControl) this.S_Cbtipologia).SelectedValue != "")
        num = Convert.ToInt32(((ListControl) this.S_Cbtipologia).SelectedValue);
      ((ParameterObject) sObject3).set_Value((object) num);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Size(4000);
      ((ParameterObject) sObject4).set_Value((object) this.txtDescrizione.Text);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_Operazione");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Size(4000);
      ((ParameterObject) sObject5).set_Value((object) operazione);
      CollezioneControlli.Add(sObject5);
      tecniciApparecchiatura.Update(CollezioneControlli, 0);
      this.Session.Remove("dvApparecchiature");
      this.GetDataSource();
      this.BindDatiTecnici();
      this.txtDescrizione.Text = "";
    }

    private void DeleteItem(string ID)
    {
      this.PanelDatoTecnico.Visible = false;
      this.execute(Convert.ToInt32(ID), "Delete");
    }

    private void DataGrid1_ItemCreated(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.EditItem)
        return;
      ((WebControl) e.Item.Cells[7].Controls[0]).Attributes.Add("onclick", "return confirm('Sei sicuro di Cancellare la Descrizione?');");
    }

    private void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Pager || e.Item.ItemType == ListItemType.Header)
        return;
      if (((Button) e.CommandSource).Text == "Delete")
      {
        this.DeleteItem(this.DataGrid1.DataKeys[e.Item.ItemIndex].ToString());
      }
      else
      {
        this.PanelDatoTecnico.Visible = true;
        this.txtDescrizione.Text = e.Item.Cells[5].Text;
        ((ListControl) this.S_Cbtipologia).SelectedValue = e.Item.Cells[3].Text;
      }
      this.btnSalva.CommandArgument = "";
    }
  }
}
