// Decompiled with JetBrains decompiler
// Type: TheSite.AnagrafeImpianti.DataRoom
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
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManOrdinaria;
using TheSite.WebControls;

namespace TheSite.AnagrafeImpianti
{
  public class DataRoom : Page
  {
    protected S_Button S_btMostra;
    protected S_Button btReset;
    protected DataPanel PanelRicerca;
    protected S_ComboBox cmbsPiano;
    protected DataGrid MyDataGrid1;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    protected CodiceStdApparecchiatura CodiceStdApparecchiatura1;
    protected CodiceApparecchiature CodiceApparecchiature1;
    protected RicercaModulo RicercaModulo1;
    protected UserStanzeRic UserStanze1;
    protected HtmlInputHidden hiddenblid;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    private TheSite.Classi.AnagrafeImpianti.DataRoom _DataRoom = new TheSite.Classi.AnagrafeImpianti.DataRoom();
    private S_ControlsCollection _SCollection = new S_ControlsCollection();
    private DataSet Ds;
    private clMyCollection _myColl = new clMyCollection();
    protected S_ComboBox cmbsServizio;
    protected S_ComboBox cmbsApparecchiatura;
    private NavigazioneAppDEMO _fp;
    private string WebCadIndietro = string.Empty;

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      DataRoom.FunId = siteModule.ModuleId;
      DataRoom.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindPiano);
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindServizio);
      this.UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.UserStanze1.NameComboPiano = "cmbsPiano";
      this.CodiceApparecchiature1.NameComboApparecchiature = "cmbsApparecchiatura";
      this.CodiceApparecchiature1.NameComboServizio = "cmbsServizio";
      this.CodiceStdApparecchiatura1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.CodiceApparecchiature1.NameUserControlRicercaModulo = "RicercaModulo1";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("if (typeof(selezionedata) == 'function') { ");
      stringBuilder.Append("if (selezionedata('" + ((Control) this.S_btMostra).ClientID + "') == false) { return false; }} ");
      stringBuilder.Append("this.value = 'Attendere ...';");
      stringBuilder.Append("this.disabled = true;");
      stringBuilder.Append("document.getElementById('" + ((Control) this.S_btMostra).ClientID + "').disabled = true;");
      stringBuilder.Append(this.Page.GetPostBackEventReference((Control) this.S_btMostra));
      stringBuilder.Append(";");
      ((WebControl) this.S_btMostra).Attributes.Add("onclick", stringBuilder.ToString());
      if (!this.IsPostBack)
      {
        if (this.Request.QueryString["FunId"] != null)
          this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
        this.setvisiblecontrol(false);
        this.GridTitle1.Visible = false;
        if (this.Context.Handler is NavigazioneAppDEMO)
        {
          if (this.Request["FromWebCad"] != null)
          {
            this.PageTitle1.VisibleLogut = false;
            this.WebCadIndietro = "true";
          }
          else
            this.PageTitle1.VisibleLogut = true;
        }
        else
        {
          this.BindTuttiPiani();
          this.BindServizio("0");
          this.BindApparecchiatura();
          if (this.Request.QueryString["FromWebCad"] != null)
          {
            ((ListControl) this.cmbsPiano).SelectedValue = this.Request.QueryString["id_piano_cad"];
            ((TextBox) this.RicercaModulo1.TxtCodice).Text = this.GetCodiceEdificio(Convert.ToInt32(this.Request.QueryString["id_edificio_cad"]));
            this.Execute(true);
            this.PageTitle1.VisibleLogut = false;
            this.WebCadIndietro = "true";
          }
        }
      }
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsServizio).SelectedIndexChanged += new EventHandler(this.cmbsServizio_SelectedIndexChanged);
      ((Button) this.S_btMostra).Click += new EventHandler(this.S_btMostra_Click);
      ((Button) this.btReset).Click += new EventHandler(this.btReset_Click);
      this.MyDataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged);
      this.Load += new EventHandler(this.Page_Load);
    }

    private string GetCodiceEdificio(int idBl)
    {
      DataSet singleData = new WebCad.Classi.ClassiAnagrafiche.Buildings().GetSingleData(idBl);
      return singleData.Tables[0].Rows.Count > 0 ? singleData.Tables[0].Rows[0]["bl_id"].ToString() : "ND";
    }

    private void setvisiblecontrol(bool Visibile)
    {
      this.GridTitle1.VisibleRecord = Visibile;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.MyDataGrid1.Visible = Visibile;
    }

    private void S_btMostra_Click(object sender, EventArgs e)
    {
      this.MyDataGrid1.CurrentPageIndex = 0;
      this.Execute(true);
    }

    public void imagebutton1_Click(object sender, CommandEventArgs e)
    {
      string[] strArray = e.CommandArgument.ToString().Split(Convert.ToChar("="));
      string str1 = strArray[1];
      string str2 = strArray[0].ToString().Split(Convert.ToChar("&"))[0];
      string str3 = strArray[2].Split('&')[0];
      string str4 = strArray[3];
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer("NavigazioneAppDEMO.aspx?var_stanza=" + str2 + "&var_bl_id=" + str1 + "&var_piani=" + str3 + "&TitoloStanza=" + str4 + "&FunId=" + (object) DataRoom.FunId + "&FromWebcad=" + this.Request["FromWebcad"] + "&WebCadIndietro=" + this.WebCadIndietro);
    }

    public void imagebutton2_Click(object sender, CommandEventArgs e)
    {
      string[] strArray = e.CommandArgument.ToString().Split(Convert.ToChar("="));
      string str1 = strArray[1];
      string str2 = strArray[0].ToString().Split(Convert.ToChar("&"))[0];
      string str3 = strArray[2];
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer("NavigazioneAppDEMO.aspx?var_piani=" + str2 + "&var_bl_id=" + str1 + "&TitoloPiano=" + str3 + "&FunId=" + (object) DataRoom.FunId + "&FromWebcad=" + this.Request["FromWebcad"]);
    }

    private void BindTuttiPiani()
    {
      ((ListControl) this.cmbsPiano).Items.Clear();
      DataSet allPiani = new TheSite.Classi.ClassiAnagrafiche.Buildings().GetAllPiani();
      if (allPiani.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsPiano).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(allPiani.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "");
        ((ListControl) this.cmbsPiano).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsPiano).DataValueField = "ID";
        ((Control) this.cmbsPiano).DataBind();
      }
      else
        ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", string.Empty));
    }

    private void BindPiano(string CodEdificio)
    {
      ((ListControl) this.cmbsPiano).Items.Clear();
      DataSet piani = new Richiesta().GetPiani(CodEdificio);
      if (piani.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsPiano).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(piani.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "");
        ((ListControl) this.cmbsPiano).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsPiano).DataValueField = "ID";
        ((Control) this.cmbsPiano).DataBind();
      }
      else
        ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", string.Empty));
    }

    private void Execute(bool reset)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(1);
      if (((TextBox) this.RicercaModulo1.TxtCodice).Text == string.Empty)
        ((ParameterObject) sObject1).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
      this._SCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_piani");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Index(2);
      if (((ListControl) this.cmbsPiano).SelectedValue == "")
        ((ParameterObject) sObject2).set_Value((object) -1);
      else
        ((ParameterObject) sObject2).set_Value((object) int.Parse(((ListControl) this.cmbsPiano).SelectedValue));
      this._SCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_rm");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Index(3);
      ((ParameterObject) sObject3).set_Value((object) this.UserStanze1.DescStanza);
      this._SCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_idservizio");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(10);
      ((ParameterObject) sObject4).set_Index(4);
      if (((ListControl) this.cmbsServizio).SelectedValue == "")
        ((ParameterObject) sObject4).set_Value((object) -1);
      else
        ((ParameterObject) sObject4).set_Value((object) int.Parse(((ListControl) this.cmbsServizio).SelectedValue));
      this._SCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_idcodappar");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size(10);
      ((ParameterObject) sObject5).set_Index(5);
      if (this.CodiceApparecchiature1.CodiceHidden.Value == "")
        ((ParameterObject) sObject5).set_Value((object) -1);
      else
        ((ParameterObject) sObject5).set_Value((object) int.Parse(this.CodiceApparecchiature1.CodiceHidden.Value));
      this._SCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_eqstd");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject6).set_Index(6);
      if (((ListControl) this.cmbsApparecchiatura).SelectedValue == "")
        ((ParameterObject) sObject6).set_Value((object) -1);
      else
        ((ParameterObject) sObject6).set_Value((object) int.Parse(((ListControl) this.cmbsApparecchiatura).SelectedValue));
      this._SCollection.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("pageindex");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) this._SCollection).Count + 1);
      ((ParameterObject) sObject7).set_Value((object) (this.MyDataGrid1.CurrentPageIndex + 1));
      this._SCollection.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("pagesize");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) this._SCollection).Count + 1);
      ((ParameterObject) sObject8).set_Value((object) this.MyDataGrid1.PageSize);
      this._SCollection.Add(sObject8);
      this.Ds = this._DataRoom.RicercaDataRoomSTD(this._SCollection);
      if (reset)
      {
        ((CollectionBase) this._SCollection).RemoveAt(((CollectionBase) this._SCollection).Count - 1);
        ((CollectionBase) this._SCollection).RemoveAt(((CollectionBase) this._SCollection).Count - 1);
        ((CollectionBase) this._SCollection).RemoveAt(((CollectionBase) this._SCollection).Count - 1);
        this.GridTitle1.NumeroRecords = this._DataRoom.RicercaDataRoomSTDCount(this._SCollection).ToString();
      }
      this.MyDataGrid1.DataSource = (object) this.Ds;
      this.GridTitle1.Visible = true;
      if (int.Parse(this.GridTitle1.NumeroRecords) > 0)
      {
        this.setvisiblecontrol(true);
        this.GridTitle1.DescriptionTitle = "";
      }
      else
      {
        this.GridTitle1.DescriptionTitle = "Nessun dato trovato.";
        this.setvisiblecontrol(false);
      }
      this.MyDataGrid1.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.MyDataGrid1.DataBind();
    }

    private void btReset_Click(object sender, EventArgs e) => this.Response.Redirect("DataRoom.aspx?FunId=" + (object) DataRoom.FunId);

    private void MyDataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.MyDataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.Execute(false);
    }

    private void BindServizio(string CodEdificio)
    {
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
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
        this.BindApparecchiatura();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", string.Empty));
    }

    private void BindApparecchiatura()
    {
      if (((ListControl) this.cmbsServizio).SelectedValue != "" || ((TextBox) this.RicercaModulo1.TxtCodice).Text != "")
      {
        ((ListControl) this.cmbsApparecchiatura).Items.Clear();
        Apparecchiature apparecchiature = new Apparecchiature(this.Context.User.Identity.Name);
        DataSet dataSet;
        if (!this.IsPostBack)
        {
          dataSet = apparecchiature.GetData().Copy();
        }
        else
        {
          S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
          S_Object sObject1 = new S_Object();
          ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
          ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
          ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject1).set_Size(50);
          ((ParameterObject) sObject1).set_Index(0);
          ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
          CollezioneControlli.Add(sObject1);
          S_Object sObject2 = new S_Object();
          ((ParameterObject) sObject2).set_ParameterName("p_Servizio");
          ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject2).set_Index(1);
          ((ParameterObject) sObject2).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
          CollezioneControlli.Add(sObject2);
          dataSet = apparecchiature.GetData(CollezioneControlli).Copy();
        }
        if (dataSet.Tables[0].Rows.Count > 0)
        {
          ((BaseDataBoundControl) this.cmbsApparecchiatura).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Standard -", "");
          ((ListControl) this.cmbsApparecchiatura).DataTextField = "DESCRIZIONE";
          ((ListControl) this.cmbsApparecchiatura).DataValueField = "ID";
          ((Control) this.cmbsApparecchiatura).DataBind();
        }
        else
          ((ListControl) this.cmbsApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Standard -", string.Empty));
      }
      else
        ((ListControl) this.cmbsApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Standard -", string.Empty));
    }

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e) => this.BindApparecchiatura();

    private string IDBL
    {
      get => this.hiddenblid.Value;
      set => this.hiddenblid.Value = value;
    }
  }
}
