// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditLivelli
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

namespace TheSite.Gestione
{
  public class EditLivelli : Page
  {
    protected Label lblOperazione;
    protected MessagePanel PanelMess;
    protected S_TextBox txtsCodice;
    protected S_TextBox txtsDescrizione;
    protected Panel PanelEdit;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    protected RequiredFieldValidator rfvCodice;
    private int itemId = 0;
    private int FunId = 0;
    private Livelli _fp;
    private DataSet _MyDs = new DataSet();
    private S_ControlsCollection _SCollection = new S_ControlsCollection();
    protected RangeValidator RVPrezzo2;
    protected CompareValidator CVPrezzo1;
    protected CompareValidator CVPrezzo2;
    protected TextBox txtsPrezzo;
    protected TextBox txtsPrezzoDecimali;
    private TheSite.Classi.ClassiAnagrafiche.Livelli _Livelli = new TheSite.Classi.ClassiAnagrafiche.Livelli();

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      if (this.itemId != 0)
      {
        this._MyDs = this._Livelli.GetSingleData(this.itemId);
        if (this._MyDs.Tables[0].Rows.Count == 1)
        {
          DataRow row = this._MyDs.Tables[0].Rows[0];
          ((TextBox) this.txtsCodice).Text = (string) row["codicelivello"];
          if (row["descrizionelivello"] != DBNull.Value)
            ((TextBox) this.txtsDescrizione).Text = row["descrizionelivello"].ToString();
          if (row["prezzounitario"] != DBNull.Value)
          {
            this.txtsPrezzo.Text = TheSite.Classi.Function.GetTypeNumber(row["prezzounitario"], NumberType.Intero).ToString();
            this.txtsPrezzoDecimali.Text = TheSite.Classi.Function.GetTypeNumber(row["prezzounitario"], NumberType.Decimale).ToString();
          }
          this.lblOperazione.Text = "Modifica Livello: " + ((TextBox) this.txtsCodice).Text;
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.lblFirstAndLast.Text = this._Livelli.GetFirstAndLastUser(row);
        }
      }
      else
      {
        this.txtsPrezzo.Text = "0";
        this.txtsPrezzoDecimali.Text = "00";
        this.lblOperazione.Text = "Inserimento Livello";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
      {
        this.AbilitaControlli(false);
        this.lblOperazione.Text = "Visualizzazione Livello: " + ((TextBox) this.txtsCodice).Text;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Livelli))
        return;
      this._fp = (Livelli) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
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

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.txtsCodice).Enabled = enabled;
      ((WebControl) this.txtsDescrizione).Enabled = enabled;
      this.txtsPrezzo.Enabled = enabled;
      this.txtsPrezzoDecimali.Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
      ((WebControl) this.btnsElimina).Enabled = enabled;
    }

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      try
      {
        this.txtsCodice.set_DBDefaultValue((object) DBNull.Value);
        this.txtsDescrizione.set_DBDefaultValue((object) DBNull.Value);
        this._SCollection.AddItems((object) this.PanelEdit.Controls);
        S_Object sObject = new S_Object();
        ((ParameterObject) sObject).set_ParameterName("p_Prezzo");
        ((ParameterObject) sObject).set_DbType((CustomDBType) 4);
        ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject).set_Index(3);
        ((ParameterObject) sObject).set_Value((object) double.Parse(this.txtsPrezzo.Text + "," + this.txtsPrezzoDecimali.Text));
        this._SCollection.Add(sObject);
        switch (this._Livelli.Delete(this._SCollection, this.itemId))
        {
          case -7:
            this.PanelMess.ShowError("Impossibile eliminare in quanto ci sono percentuali assocciate", true);
            break;
          case -5:
            this.PanelMess.ShowError("Impossibile eliminare in quanto ci sono Addetti assocciati", true);
            break;
          case -1:
            this.Server.Transfer("Livelli.aspx");
            break;
        }
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      this.txtsCodice.set_DBDefaultValue((object) DBNull.Value);
      this.txtsDescrizione.set_DBDefaultValue((object) DBNull.Value);
      ((TextBox) this.txtsCodice).Text = ((TextBox) this.txtsCodice).Text.Trim();
      ((TextBox) this.txtsDescrizione).Text = ((TextBox) this.txtsDescrizione).Text.Trim();
      this._SCollection.AddItems((object) this.PanelEdit.Controls);
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_Prezzo");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(3);
      ((ParameterObject) sObject).set_Value((object) double.Parse(this.txtsPrezzo.Text + "," + this.txtsPrezzoDecimali.Text));
      this._SCollection.Add(sObject);
      try
      {
        int num = this.itemId != 0 ? this._Livelli.Update(this._SCollection, this.itemId) : this._Livelli.Add(this._SCollection);
        if (num > 0 && num != -11)
          this.Server.Transfer("Livelli.aspx");
        else
          SiteJavaScript.msgBox(this.Page, "Il Livello  é stato già inserito");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Livelli.aspx");
  }
}
