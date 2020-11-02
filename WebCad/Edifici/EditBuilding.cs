// Decompiled with JetBrains decompiler
// Type: WebCad.Edifici.EditBuilding
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
using WebCad.Classi.ClassiAnagrafiche;
using WebCad.MyCollection;

namespace WebCad.Edifici
{
  public class EditBuilding : Page
  {
    protected S_TextBox S_TextBox1;
    protected S_TextBox S_TEXTBOX2;
    private int itemId = 0;
    private int pianoId = 0;
    public static int FunId = 0;
    public static int TabId = 0;
    protected RequiredFieldValidator rfvCAP;
    protected RequiredFieldValidator rfvPiani;
    protected Button btnAssociaP;
    protected Button btnEliminaP;
    protected Panel PanelEditPiani;
    protected Label lblFirstAndLast;
    protected DataGrid DataGridEsegui;
    protected Label lblRecord;
    protected Panel PanelEditStanze;
    protected DataGrid DataGridPiani;
    protected HtmlInputHidden HiddenPianiStanze;
    public string edificio = "";
    public string piano = "";
    protected ListBox ListBoxLeftP;
    protected ListBox ListBoxRightP;
    private WebCad.Stanze _RM = new WebCad.Stanze();

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      this.PanelEditPiani.Visible = false;
      if (this.Request["IdEdif"] != null)
        this.itemId = int.Parse(this.Request["IdEdif"].ToString());
      if (this.Request["IdPian"] != null)
        this.pianoId = int.Parse(this.Request["IdPian"].ToString());
      if (this.Request["Edificio"] != null)
        this.edificio = this.Request["Edificio"].ToString();
      if (this.Request["Piano"] != null)
        this.piano = this.Request["Piano"].ToString();
      if (this.Page.IsPostBack)
        return;
      this.DataGridEsegui.Columns[1].Visible = true;
      this.DataGridEsegui.Columns[2].Visible = false;
      this.DataGridEsegui.Columns[3].Visible = false;
      this.BindGrid();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    private void AbilitaControlli(bool enabled)
    {
      this.DataGridPiani.Enabled = enabled;
      this.DataGridEsegui.Enabled = enabled;
    }

    public DataTable GetPianiEdificio() => new Buildings().GetPianiBuilding(this.itemId).Tables[0];

    protected int GetIndex(string item) => item.Length > 0 ? int.Parse(item) : 0;

    private void lkbNuovo_Click(object sender, EventArgs e)
    {
      this.BindGrid();
      this.DataGridEsegui.ShowFooter = true;
      this.DataGridEsegui.Columns[1].Visible = false;
      this.DataGridEsegui.Columns[2].Visible = false;
      this.DataGridEsegui.Columns[3].Visible = true;
    }

    private S_ControlsCollection ControlsStanze(
      int Piano,
      string Stanza,
      string DescrizioneStanza,
      double Mq,
      int id_rm_cat,
      int id_rm_reparto,
      int id_rm_dest_uso)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_BL_ID");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(10);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject1).set_Value((object) this.itemId);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_piani");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject2).set_Value((object) Piano);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject3).set_Value((object) Stanza);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_descstanza");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject4).set_Value((object) DescrizioneStanza);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_id_rm_cat");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size(10);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject5).set_Value((object) id_rm_cat);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_id_rm_reparto");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Size(10);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject6).set_Value((object) id_rm_reparto);
      controlsCollection.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_id_rm_dest_uso");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(10);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject7).set_Value((object) id_rm_dest_uso);
      controlsCollection.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_mq");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Size(10);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject8).set_Value((object) Mq);
      controlsCollection.Add(sObject8);
      return controlsCollection;
    }

    private void BindGrid()
    {
      this.HiddenPianiStanze.Value = "";
      DataSet dataSet = new Buildings().GetPiano(this.itemId, this.pianoId).Copy();
      this.DataGridEsegui.DataSource = (object) dataSet.Tables[0];
      this.DataGridEsegui.DataBind();
      this.lblRecord.Text = dataSet.Tables[0].Rows.Count.ToString();
      this.DataGridEsegui.ShowFooter = false;
    }
  }
}
