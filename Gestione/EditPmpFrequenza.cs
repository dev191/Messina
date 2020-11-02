// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditPmpFrequenza
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace TheSite.Gestione
{
  public class EditPmpFrequenza : Page
  {
    protected MessagePanel PanelMess;
    protected Panel PanelEdit;
    private int itemId = 0;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    protected Label lblOperazione;
    private int FunId = 0;
    protected S_TextBox txtsfrequenza;
    protected RequiredFieldValidator rfvfrequenza;
    protected RequiredFieldValidator rvffrequenza_des;
    protected S_TextBox txtsfrequenza_des;
    protected S_ComboBox cmbsTipoCadenza;
    protected S_ComboBox cmbsGiorni;
    protected S_ComboBox cmbsMesi;
    protected S_ComboBox cmbsAnni;
    protected S_ComboBox cmbsCalcola;
    protected Repeater rpserv;
    protected HtmlTableRow r1;
    protected HtmlTableRow r2;
    protected HtmlTableRow r3;
    protected HtmlTableCell r4;
    private PmpFrequenza _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      if (this.itemId != 0)
      {
        DataSet dataSet = new DataSet();
        TheSite.Classi.ClassiAnagrafiche.PmpFrequenza pmpFrequenza = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza();
        DataSet singleData = pmpFrequenza.GetSingleData(this.itemId);
        if (singleData.Tables[0].Rows.Count == 1)
        {
          DataRow row = singleData.Tables[0].Rows[0];
          ((TextBox) this.txtsfrequenza).Text = (string) row["FREQUENZA"];
          if (row["FREQUENZA_DES"] != DBNull.Value)
            ((TextBox) this.txtsfrequenza_des).Text = (string) row["FREQUENZA_DES"];
          if (row["mese_std"] != DBNull.Value)
            ((ListControl) this.cmbsTipoCadenza).SelectedValue = row["mese_std"].ToString();
          if (row["N_GIORNI"] != DBNull.Value)
            ((ListControl) this.cmbsGiorni).SelectedValue = row["N_GIORNI"].ToString();
          if (row["N_MESI"] != DBNull.Value)
            ((ListControl) this.cmbsMesi).SelectedValue = row["N_MESI"].ToString();
          if (row["N_ANNI"] != DBNull.Value)
            ((ListControl) this.cmbsAnni).SelectedValue = row["N_ANNI"].ToString();
          if (row["CALCOLA"] != DBNull.Value)
            ((ListControl) this.cmbsCalcola).SelectedValue = row["CALCOLA"].ToString();
          this.lblOperazione.Text = "Modifica Frequenza: " + ((TextBox) this.txtsfrequenza).Text;
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.lblFirstAndLast.Text = pmpFrequenza.GetFirstAndLastUser(row);
          this.LoadServizi(row["mese_std"].ToString(), row["FREQUENZA"].ToString());
        }
      }
      else
      {
        this.LoadServizi("0", "0");
        this.lblOperazione.Text = "Inserimento Frequenza";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
      {
        this.AbilitaControlli(false);
        this.lblOperazione.Text = "Visualizzazione Frequenza: " + ((TextBox) this.txtsfrequenza).Text;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is PmpFrequenza))
        return;
      this._fp = (PmpFrequenza) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.txtsfrequenza).Enabled = enabled;
      ((WebControl) this.txtsfrequenza_des).Enabled = enabled;
      ((WebControl) this.cmbsTipoCadenza).Enabled = enabled;
      ((WebControl) this.cmbsGiorni).Enabled = enabled;
      ((WebControl) this.cmbsMesi).Enabled = enabled;
      ((WebControl) this.cmbsAnni).Enabled = enabled;
      ((WebControl) this.cmbsCalcola).Enabled = enabled;
      ((WebControl) this.btnsElimina).Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      ((Button) this.btnsElimina).Click += new EventHandler(this.btnsElimina_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        int num;
        if (this.itemId == 0)
        {
          TheSite.Classi.ClassiAnagrafiche.PmpFrequenza pmpFrequenza = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza();
          num = pmpFrequenza.Add(CollezioneControlli);
          pmpFrequenza.DeleteFreqStag(num);
          if (((ListControl) this.cmbsTipoCadenza).SelectedValue == "1")
            this.SaveStag(num);
        }
        else
        {
          TheSite.Classi.ClassiAnagrafiche.PmpFrequenza pmpFrequenza = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza();
          num = pmpFrequenza.Update(CollezioneControlli, this.itemId);
          pmpFrequenza.DeleteFreqStag(num);
          if (((ListControl) this.cmbsTipoCadenza).SelectedValue == "1")
            this.SaveStag(num);
        }
        if (num == -11)
          SiteJavaScript.msgBox(this.Page, "Tipo Frequenza già presente.");
        else
          this.Server.Transfer("PmpFrequenza.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void SaveStag(int Freq)
    {
      foreach (RepeaterItem repeaterItem in this.rpserv.Items)
      {
        string s = ((HtmlInputControl) repeaterItem.FindControl("idser")).Value;
        string selectedValue = ((ListControl) repeaterItem.FindControl("drmese")).SelectedValue;
        if (!(selectedValue == "0"))
          new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza().InsertFreqStag(Freq, ((TextBox) this.txtsfrequenza).Text, int.Parse(selectedValue), int.Parse(s));
      }
    }

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      try
      {
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
        TheSite.Classi.ClassiAnagrafiche.PmpFrequenza pmpFrequenza = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza();
        pmpFrequenza.DeleteFreqStag(this.itemId);
        if (pmpFrequenza.Delete(CollezioneControlli, this.itemId) != -1)
          return;
        this.Server.Transfer("PmpFrequenza.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("PmpFrequenza.aspx");

    private void LoadServizi(string cadenza, string frequenza)
    {
      this.rpserv.DataSource = (object) new TheSite.Classi.ClassiDettaglio.Servizi().GetServizi().Tables[0];
      this.rpserv.DataBind();
      ((WebControl) this.cmbsTipoCadenza).Attributes.Add("onclick", "SetVisible();");
      this.Page.RegisterStartupScript("visib", "<script language='javascript'>SetVisible();</script>");
      DataSet dataStag = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza().GetDataStag(frequenza);
      foreach (RepeaterItem repeaterItem in this.rpserv.Items)
      {
        HtmlInputHidden control = (HtmlInputHidden) repeaterItem.FindControl("idser");
        foreach (DataRow row in (InternalDataCollectionBase) dataStag.Tables[0].Rows)
        {
          if (row["servizi_id"].ToString() == control.Value)
          {
            ((ListControl) repeaterItem.FindControl("drmese")).SelectedValue = row["idmese"].ToString();
            break;
          }
        }
      }
    }
  }
}
