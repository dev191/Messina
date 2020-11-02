// Decompiled with JetBrains decompiler
// Type: TheSite.Admin.EditMenu
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace TheSite.Admin
{
  public class EditMenu : Page
  {
    protected Label lblOperazione;
    protected MessagePanel PanelMess;
    protected RequiredFieldValidator rfvDescrizione;
    protected S_TextBox txtsDescrizione;
    protected S_ComboBox cmbsFunzione;
    protected S_ComboBox cmbsMenuPadre;
    protected S_TextBox txtsCssClass;
    protected Panel PanelEdit;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    protected S_TextBox txtsToolTip;
    protected S_TextBox txtsImage;
    protected S_TextBox txtsTarget;
    protected S_TextBox txtsViewOrder;
    protected S_CheckBox ckbsValido;
    protected RegularExpressionValidator rgeViewOrder;
    protected CompareValidator cmvFunzione;
    protected LinkButton lkbInfo;
    protected Panel pnlShowInfo;
    protected LinkButton lnkChiudi;
    protected DataList dtlInfo;
    private int FunId = 0;
    private int itemId = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request.Params["FunId"]);
      if (this.Request.Params["ItemId"] != null)
        this.itemId = int.Parse(this.Request.Params["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      if (this.itemId != 0)
      {
        TheSite.Classi.Menu menu = new TheSite.Classi.Menu();
        DataSet dataSet = menu.GetSingleData(this.itemId).Copy();
        if (dataSet.Tables[0].Rows.Count == 1)
        {
          this.BindControls();
          DataRow row = dataSet.Tables[0].Rows[0];
          ((TextBox) this.txtsDescrizione).Text = (string) row["DESCRIZIONE"];
          if (row["CSSCLASS"] != DBNull.Value)
            ((TextBox) this.txtsCssClass).Text = (string) row["CSSCLASS"];
          if (row["TOOLTIP"] != DBNull.Value)
            ((TextBox) this.txtsToolTip).Text = (string) row["TOOLTIP"];
          if (row["IMAGE"] != DBNull.Value)
            ((TextBox) this.txtsImage).Text = (string) row["IMAGE"];
          if (row["TARGET"] != DBNull.Value)
            ((TextBox) this.txtsTarget).Text = (string) row["TARGET"];
          if (row["VIEWORDER"] != DBNull.Value)
            ((TextBox) this.txtsViewOrder).Text = row["VIEWORDER"].ToString();
          if (row["FUNZIONE_ID"] != DBNull.Value)
            ((ListControl) this.cmbsFunzione).SelectedValue = row["FUNZIONE_ID"].ToString();
          if (row["MENU_PADRE_ID"] != DBNull.Value)
            ((ListControl) this.cmbsMenuPadre).SelectedValue = row["MENU_PADRE_ID"].ToString();
          if (row["ENABLE"] != DBNull.Value)
            ((CheckBox) this.ckbsValido).Checked = Convert.ToBoolean((Decimal) row["ENABLE"]);
          this.lblFirstAndLast.Text = menu.GetFirstAndLastUser(row);
          this.lblOperazione.Text = "Modifica";
          this.lblFirstAndLast.Visible = true;
          ((Control) this.btnsElimina).Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
        }
      }
      else
      {
        this.lblOperazione.Text = "Nuovo";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
        this.BindControls();
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.lkbInfo.Click += new EventHandler(this.lkbInfo_Click);
      this.lnkChiudi.Click += new EventHandler(this.lnkChiudi_Click);
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      ((Button) this.btnsElimina).Click += new EventHandler(this.btnsElimina_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      this.txtsCssClass.set_DBDefaultValue((object) DBNull.Value);
      this.txtsToolTip.set_DBDefaultValue((object) DBNull.Value);
      this.txtsImage.set_DBDefaultValue((object) DBNull.Value);
      this.txtsTarget.set_DBDefaultValue((object) DBNull.Value);
      this.txtsViewOrder.set_DBDefaultValue((object) DBNull.Value);
      this.ckbsValido.set_DBDefaultValue((object) "-1");
      TheSite.Classi.Menu menu = new TheSite.Classi.Menu();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        if ((this.itemId != 0 ? menu.Update(CollezioneControlli, this.itemId) : menu.Add(CollezioneControlli)) <= 0)
          return;
        this.Response.Redirect((string) this.ViewState["UrlReferrer"]);
      }
      catch (Exception ex)
      {
        string str = "Errore: ";
        this.PanelMess.ShowError(!(ex.Message.Substring(0, 8) == "ORA-00001") ? str + "aggiornamento non riuscito" : str + "menu già presente", true);
      }
    }

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      this.txtsCssClass.set_DBDefaultValue((object) DBNull.Value);
      this.txtsToolTip.set_DBDefaultValue((object) DBNull.Value);
      this.txtsImage.set_DBDefaultValue((object) DBNull.Value);
      this.txtsTarget.set_DBDefaultValue((object) DBNull.Value);
      this.txtsViewOrder.set_DBDefaultValue((object) DBNull.Value);
      this.ckbsValido.set_DBDefaultValue((object) "-1");
      TheSite.Classi.Menu menu = new TheSite.Classi.Menu();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        if (menu.Delete(CollezioneControlli, this.itemId) != -1)
          return;
        this.Response.Redirect((string) this.ViewState["UrlReferrer"]);
      }
      catch
      {
        this.PanelMess.ShowError("Errore: cancellazione non riuscita", true);
      }
    }

    private void lkbInfo_Click(object sender, EventArgs e)
    {
      TheSite.Classi.Menu menu = new TheSite.Classi.Menu();
      int itemParentId = (int) short.Parse(((ListControl) this.cmbsMenuPadre).SelectedValue);
      this.pnlShowInfo.Visible = true;
      this.dtlInfo.DataSource = (object) menu.GetInfoOrder(itemParentId).Tables[0];
      this.dtlInfo.DataBind();
    }

    private void lnkChiudi_Click(object sender, EventArgs e) => this.pnlShowInfo.Visible = false;

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Response.Redirect((string) this.ViewState["UrlReferrer"]);

    private void BindControls()
    {
      ((BaseDataBoundControl) this.cmbsFunzione).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new Funzione().GetData().Tables[0], "DESCRIZIONE", "ID", "-- SELEZIONARE --", "0");
      ((ListControl) this.cmbsFunzione).DataTextField = "DESCRIZIONE";
      ((ListControl) this.cmbsFunzione).DataValueField = "ID";
      ((Control) this.cmbsFunzione).DataBind();
      DataView DataViewOrigine = new DataView(new TheSite.Classi.Menu().GetData().Tables[0].Copy());
      if (this.itemId != 0)
        DataViewOrigine.RowFilter = "ID <> " + (object) this.itemId;
      ((BaseDataBoundControl) this.cmbsMenuPadre).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(DataViewOrigine, "DESCRIZIONE", "ID", "", "0");
      ((ListControl) this.cmbsMenuPadre).DataTextField = "DESCRIZIONE";
      ((ListControl) this.cmbsMenuPadre).DataValueField = "ID";
      ((Control) this.cmbsMenuPadre).DataBind();
    }
  }
}
