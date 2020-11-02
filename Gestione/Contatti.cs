// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.Contatti
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
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class Contatti : Page
  {
    protected Label lblOperazione;
    protected DataGrid DataGridEsegui;
    protected Label lblRecord;
    protected LinkButton lkbNuovo;
    private int FunId = 0;
    protected MessagePanel PanelMess;
    protected Label lblMessaggi;
    protected PageTitle PageTitle1;
    protected Button btnAnnulla;
    protected Button btnsAnnulla;
    protected Label Label1;
    protected S_TextBox txtsNome;
    protected S_TextBox txtsCognome;
    protected Panel PanelEdit;
    protected S_ComboBox cmbsGruppo;
    private Richiedenti _fp;
    private int itemId = 0;

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      this.lblMessaggi.Text = "";
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      DataSet dataSet = new DataSet();
      DataSet singleData = new TheSite.Classi.ClassiAnagrafiche.Richiedenti().GetSingleData(this.itemId);
      if (singleData.Tables[0].Rows.Count == 1)
      {
        DataRow row = singleData.Tables[0].Rows[0];
        if (row["cognome"] != DBNull.Value)
          ((TextBox) this.txtsCognome).Text = (string) row["cognome"];
        if (row["nome"] != DBNull.Value)
          ((TextBox) this.txtsNome).Text = row["nome"].ToString();
        this.lblOperazione.Text = "Gestione Contatti";
        this.getAllGruppo(row["id_tipo"].ToString());
        this.BindDataGrid();
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Richiedenti))
        return;
      this._fp = (Richiedenti) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    private void BindDataGrid()
    {
      DataSet data = new TheSite.Classi.ClassiAnagrafiche.Contatti().GetData(this.itemId);
      this.DataGridEsegui.DataSource = (object) data;
      this.DataGridEsegui.DataBind();
      this.lblRecord.Text = data.Tables[0].Rows.Count.ToString();
    }

    private void getAllGruppo(string id_tipo)
    {
      ((ListControl) this.cmbsGruppo).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo().GetAllData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsGruppo).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "id", "- Selezionare una Gruppo -", "");
      ((ListControl) this.cmbsGruppo).DataTextField = "descrizione";
      ((ListControl) this.cmbsGruppo).DataValueField = "id";
      if (id_tipo != "")
        ((ListControl) this.cmbsGruppo).SelectedValue = id_tipo;
      ((Control) this.cmbsGruppo).DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.lkbNuovo.Click += new EventHandler(this.lkbNuovo_Click);
      this.btnsAnnulla.Click += new EventHandler(this.btnsAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Response.Redirect((string) this.ViewState["UrlReferrer"]);

    private void lkbNuovo_Click(object sender, EventArgs e)
    {
      this.DataGridEsegui.ShowFooter = true;
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindDataGrid();
    }

    private void btnsAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Richiedenti.aspx");

    public DataSet loadTipoContatti() => new Contatti_tipo().GetAllData().Copy();

    public int GetTipoContattiID(object ID) => int.Parse(((DataRowView) ID)["ID_TIPO"].ToString());

    protected void jskDataGrid_Edit(object sender, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.ShowFooter = false;
      this.DataGridEsegui.EditItemIndex = e.Item.ItemIndex;
      this.BindDataGrid();
    }

    protected void jskDataGrid_Cancel(object sender, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.ShowFooter = false;
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindDataGrid();
    }

    protected void jskDataGrid_Delete(object sender, DataGridCommandEventArgs e)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_idRichiedente");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.itemId);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_idTipoContatto");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) 0);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Descrizione");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Value((object) string.Empty);
      CollezioneControlli.Add(sObject1);
      CollezioneControlli.Add(sObject2);
      CollezioneControlli.Add(sObject3);
      new TheSite.Classi.ClassiAnagrafiche.Contatti().Delete(CollezioneControlli, int.Parse(e.Item.Cells[1].Text));
      this.DataGridEsegui.ShowFooter = false;
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindDataGrid();
    }

    protected void jskDataGrid_Update(object sender, DataGridCommandEventArgs e)
    {
      try
      {
        string selectedValue;
        string text;
        if (this.DataGridEsegui.ShowFooter)
        {
          selectedValue = ((ListControl) e.Item.FindControl("cmbsTipologia_New")).SelectedValue;
          text = ((TextBox) e.Item.FindControl("txts_DescrizioneNew")).Text;
        }
        else
        {
          selectedValue = ((ListControl) e.Item.FindControl("cmbsTipologia_Edit")).SelectedValue;
          text = ((TextBox) e.Item.FindControl("txts_DescrizioneEdit")).Text;
        }
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_idRichiedente");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) this.itemId);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_idTipoContatto");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Value((object) int.Parse(selectedValue));
        S_Object sObject3 = new S_Object();
        ((ParameterObject) sObject3).set_ParameterName("p_Descrizione");
        ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject3).set_Index(2);
        ((ParameterObject) sObject3).set_Value((object) text);
        CollezioneControlli.Add(sObject1);
        CollezioneControlli.Add(sObject2);
        CollezioneControlli.Add(sObject3);
        TheSite.Classi.ClassiAnagrafiche.Contatti contatti = new TheSite.Classi.ClassiAnagrafiche.Contatti();
        if (this.DataGridEsegui.ShowFooter)
          contatti.Add(CollezioneControlli);
        else
          contatti.Update(CollezioneControlli, int.Parse(e.Item.Cells[1].Text));
        this.DataGridEsegui.ShowFooter = false;
        this.DataGridEsegui.EditItemIndex = -1;
        this.BindDataGrid();
      }
      catch (Exception ex)
      {
        this.lblMessaggi.Text = ex.Message;
      }
    }
  }
}
