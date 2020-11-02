// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditFondi
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
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace TheSite.Gestione
{
  public class EditFondi : Page
  {
    private int itemId = 0;
    private int FunId = 0;
    protected Label lblOperazione;
    protected MessagePanel PanelMess;
    protected RequiredFieldValidator rfvEqstd;
    protected Panel PanelEdit;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    protected S_TextBox txtsimporto_netto_intero;
    protected S_TextBox txtsimporto_netto_decimale;
    protected S_TextBox txtsdescrizione;
    protected S_TextBox txtsNote;
    protected S_TextBox txtsimporto_lordo_decimale;
    protected S_TextBox txtsimporto_lordo_intero;
    protected S_TextBox TxtCodFondo;
    protected DropDownList cmbPeriodo;
    protected CheckBox CkDefault;
    protected ListBox ListTipoManutenzioneAdd;
    protected ListBox ListTipoManutenzione;
    protected Button BtAdd;
    protected Button BtRemove;
    protected ValidationSummary ValidationSummary1;
    protected RequiredFieldValidator Rq1;
    protected RequiredFieldValidator Rq4;
    protected DropDownList DrMeseini;
    protected DropDownList DrAnnoIni;
    protected DropDownList DrAnnofine;
    protected DropDownList DrPiano;
    protected DropDownList secondomese;
    private Fondi _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      ((WebControl) this.txtsimporto_lordo_decimale).Attributes.Add("onblur", "imposta_dec(this.id);");
      ((WebControl) this.txtsimporto_lordo_decimale).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsimporto_lordo_decimale).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtsimporto_netto_decimale).Attributes.Add("onblur", "imposta_dec(this.id);");
      ((WebControl) this.txtsimporto_netto_decimale).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsimporto_netto_decimale).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtsimporto_lordo_intero).Attributes.Add("onblur", "imposta_int(this.id);");
      ((WebControl) this.txtsimporto_lordo_intero).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsimporto_lordo_intero).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtsimporto_netto_intero).Attributes.Add("onblur", "imposta_int(this.id);");
      ((WebControl) this.txtsimporto_netto_intero).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsimporto_netto_intero).Attributes.Add("onpaste", "return false;");
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["itemId"] != null)
        this.itemId = int.Parse(this.Request["itemId"]);
      if (this.Page.IsPostBack)
        return;
      this.CaricaCombo();
      this.LoadAnno();
      if (this.itemId != 0)
      {
        DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Fondi().GetSingleData(this.itemId).Copy();
        if (dataSet.Tables[0].Rows.Count == 1)
        {
          DataRow row1 = dataSet.Tables[0].Rows[0];
          if (row1["Descrizione"] != DBNull.Value)
            ((TextBox) this.txtsdescrizione).Text = (string) row1["descrizione"];
          if (row1["Note"] != DBNull.Value)
            ((TextBox) this.txtsNote).Text = (string) row1["Note"];
          if (row1["codicefondo"] != DBNull.Value)
            ((TextBox) this.TxtCodFondo).Text = (string) row1["codicefondo"];
          if (row1["meseini"] != DBNull.Value)
            this.DrMeseini.SelectedValue = row1["meseini"].ToString();
          if (row1["annoini"] != DBNull.Value)
            this.DrAnnoIni.SelectedValue = row1["annoini"].ToString();
          if (row1["mesefine"] != DBNull.Value)
            this.secondomese.SelectedValue = row1["mesefine"].ToString();
          if (row1["annofine"] != DBNull.Value)
            this.DrAnnofine.SelectedValue = row1["annofine"].ToString();
          if (row1["periodicita"] != DBNull.Value)
            this.cmbPeriodo.SelectedValue = row1["periodicita"].ToString();
          if (row1["importo_netto"] != DBNull.Value)
          {
            ((TextBox) this.txtsimporto_netto_intero).Text = TheSite.Classi.Function.GetTypeNumber(row1["importo_netto"], NumberType.Intero).ToString();
            ((TextBox) this.txtsimporto_netto_decimale).Text = TheSite.Classi.Function.GetTypeNumber(row1["importo_netto"], NumberType.Decimale).ToString();
          }
          if (row1["importo_lordo"] != DBNull.Value)
          {
            ((TextBox) this.txtsimporto_lordo_intero).Text = TheSite.Classi.Function.GetTypeNumber(row1["importo_lordo"], NumberType.Intero).ToString();
            ((TextBox) this.txtsimporto_lordo_decimale).Text = TheSite.Classi.Function.GetTypeNumber(row1["importo_lordo"], NumberType.Decimale).ToString();
          }
          this.CkDefault.Checked = row1["predefinito"] != DBNull.Value && row1["predefinito"].ToString() == "1";
          this.lblOperazione.Text = "Modifica Fondo: " + ((TextBox) this.txtsdescrizione).Text;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          foreach (DataRow row2 in (InternalDataCollectionBase) dataSet.Tables[1].Rows)
            this.ListTipoManutenzioneAdd.Items.Add(new ListItem(row2["descrizione"].ToString(), row2["tipointervento_id"].ToString()));
          for (int index = this.ListTipoManutenzione.Items.Count - 1; index >= 0; --index)
          {
            if (this.ListTipoManutenzioneAdd.Items.FindByText(this.ListTipoManutenzione.Items[index].Text) != null)
              this.ListTipoManutenzione.Items.RemoveAt(index);
          }
          if (this.ListTipoManutenzioneAdd.Items.Count > 0)
            this.ListTipoManutenzioneAdd.Items[0].Selected = true;
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Fondo";
        ((Control) this.btnsElimina).Visible = false;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (this.Context.Handler is Fondi)
      {
        this._fp = (Fondi) this.Context.Handler;
        this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
      }
      if (this.Request["TipoOper"] == "read")
        this.Abilita(false);
      else
        this.Abilita(true);
    }

    private void LoadMese()
    {
      this.secondomese.Items.Add(new ListItem("- Nessun Mese -", "0"));
      this.DrMeseini.Items.Add(new ListItem("- Nessun Mese -", "0"));
      ArrayList arrayList = new ArrayList();
      arrayList.Add((object) new ListItem("Gennaio", "1"));
      arrayList.Add((object) new ListItem("Febbraio", "2"));
      arrayList.Add((object) new ListItem("Marzo", "3"));
      arrayList.Add((object) new ListItem("Aprile", "4"));
      arrayList.Add((object) new ListItem("Maggio", "5"));
      arrayList.Add((object) new ListItem("Giugno", "6"));
      arrayList.Add((object) new ListItem("Luglio", "7"));
      arrayList.Add((object) new ListItem("Agosto", "8"));
      arrayList.Add((object) new ListItem("Settembre", "9"));
      arrayList.Add((object) new ListItem("Ottobre", "10"));
      arrayList.Add((object) new ListItem("Novembre", "11"));
      arrayList.Add((object) new ListItem("Dicembre", "12"));
      for (int index = 0; index <= arrayList.Count - 1; ++index)
      {
        this.secondomese.Items.Add((ListItem) arrayList[index]);
        this.DrMeseini.Items.Add((ListItem) arrayList[index]);
      }
    }

    private void LoadAnno()
    {
      this.DrAnnofine.Items.Add(new ListItem("- Nessun Anno -", "0"));
      this.DrAnnoIni.Items.Add(new ListItem("- Nessun Anno -", "0"));
      for (int index = 2000; index <= DateTime.Now.Year + 20; ++index)
      {
        this.DrAnnofine.Items.Add(new ListItem(index.ToString(), index.ToString()));
        this.DrAnnoIni.Items.Add(new ListItem(index.ToString(), index.ToString()));
      }
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.BtAdd.Click += new EventHandler(this.BtAdd_Click);
      this.BtRemove.Click += new EventHandler(this.BtRemove_Click);
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      ((Button) this.btnsElimina).Click += new EventHandler(this.btnsElimina_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void Abilita(bool tipo)
    {
      ((WebControl) this.txtsimporto_netto_decimale).Enabled = tipo;
      ((WebControl) this.txtsimporto_netto_intero).Enabled = tipo;
      ((WebControl) this.txtsimporto_lordo_decimale).Enabled = tipo;
      ((WebControl) this.txtsimporto_lordo_intero).Enabled = tipo;
      ((WebControl) this.txtsNote).Enabled = tipo;
      ((WebControl) this.txtsdescrizione).Enabled = tipo;
      this.ListTipoManutenzione.Enabled = tipo;
      this.ListTipoManutenzioneAdd.Enabled = tipo;
      this.DrMeseini.Enabled = tipo;
      this.secondomese.Enabled = tipo;
      this.DrAnnofine.Enabled = tipo;
      this.DrAnnoIni.Enabled = tipo;
      ((WebControl) this.btnsElimina).Enabled = tipo;
      ((WebControl) this.btnsSalva).Enabled = tipo;
    }

    private void CaricaCombo()
    {
      this.ListTipoManutenzione.Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet data = new TheSite.Classi.ClassiAnagrafiche.TipoIntervento().GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        this.ListTipoManutenzione.DataSource = (object) data.Tables[0];
        this.ListTipoManutenzione.DataTextField = "descrizione_breve";
        this.ListTipoManutenzione.DataValueField = "id";
        this.ListTipoManutenzione.DataBind();
      }
      else
        this.ListTipoManutenzione.Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Tipo Intervento -", string.Empty));
    }

    public void Aggiorna(ExecuteType tipo)
    {
      TheSite.Classi.ClassiAnagrafiche.Fondi fondi = new TheSite.Classi.ClassiAnagrafiche.Fondi();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_ControlsCollection Ctrl = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_meseini");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(10);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) this.DrMeseini.SelectedValue);
      CollezioneControlli.Add(sObject1);
      Ctrl.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_mesefine");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) this.secondomese.SelectedValue);
      CollezioneControlli.Add(sObject2);
      Ctrl.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_annoini");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) this.DrAnnoIni.SelectedValue);
      CollezioneControlli.Add(sObject3);
      Ctrl.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_annofine");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(10);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Value((object) this.DrAnnofine.SelectedValue);
      CollezioneControlli.Add(sObject4);
      Ctrl.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_periodicita");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Value((object) this.cmbPeriodo.SelectedValue);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_importo_netto");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject6).set_Value((object) double.Parse(((TextBox) this.txtsimporto_netto_intero).Text + "," + ((TextBox) this.txtsimporto_netto_decimale).Text));
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_importo_lordo");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject7).set_Value((object) double.Parse(((TextBox) this.txtsimporto_lordo_intero).Text + "," + ((TextBox) this.txtsimporto_lordo_decimale).Text));
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject8).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject8).set_Value((object) ((TextBox) this.txtsdescrizione).Text.Trim());
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_note");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject9).set_Size(500);
      ((ParameterObject) sObject9).set_Value((object) ((TextBox) this.txtsNote).Text.Trim());
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_codicefondo");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject10).set_Size(500);
      ((ParameterObject) sObject10).set_Value((object) ((TextBox) this.TxtCodFondo).Text.Trim());
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_predefinito");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject11).set_Value((object) (this.CkDefault.Checked ? 1 : 0));
      CollezioneControlli.Add(sObject11);
      int num = 0;
      ArrayList TipoIntevento = new ArrayList();
      foreach (ListItem listItem in this.ListTipoManutenzioneAdd.Items)
        TipoIntevento.Add((object) listItem.Value);
      try
      {
        if (tipo == ExecuteType.Insert)
        {
          int fondo = fondi.Add(CollezioneControlli);
          fondi.UpdateInsertManutenzioneFondo(fondo, TipoIntevento, Ctrl);
        }
        if (tipo == ExecuteType.Update)
        {
          num = fondi.Update(CollezioneControlli, this.itemId);
          fondi.UpdateInsertManutenzioneFondo(this.itemId, TipoIntevento, Ctrl);
        }
        if (tipo != ExecuteType.Delete)
          return;
        fondi.DeleteManutenzioneFondo(this.itemId);
        num = fondi.Delete(CollezioneControlli, this.itemId);
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Fondi.aspx");

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.CreaPiano())
          return;
        string str = "Attenzione il fondo: " + ((TextBox) this.TxtCodFondo).Text;
        if (this.itemId == 0)
          this.Aggiorna(ExecuteType.Insert);
        else
          this.Aggiorna(ExecuteType.Update);
      }
      catch (Exception ex)
      {
        SiteJavaScript.msgBox(this.Page, ex.Message);
      }
    }

    private bool CreaPiano()
    {
      long num1 = (long) int.Parse(this.cmbPeriodo.SelectedValue);
      long num2 = DateAndTime.DateDiff(DateInterval.Month, new DateTime(int.Parse(this.DrAnnoIni.SelectedValue), int.Parse(this.DrMeseini.SelectedValue), 1), new DateTime(int.Parse(this.DrAnnofine.SelectedValue), int.Parse(this.secondomese.SelectedValue), 1));
      if (num2 <= 0L)
      {
        this.Page.RegisterStartupScript("al", "<script language='javascript'>alert('Intervallo di date non crea un periodo corretto!');</script>");
        return true;
      }
      if (num2 % num1 > 0L)
      {
        this.Page.RegisterStartupScript("al", "<script language='javascript'>alert('Intervallo di date non crea un periodo corretto!');</script>");
        return true;
      }
      this.DrPiano.Items.Clear();
      string descri = this.GetDescri(this.cmbPeriodo.SelectedValue);
      long num3 = num2 / num1;
      for (int index = 1; (long) index <= num3; ++index)
        this.DrPiano.Items.Add(new ListItem(index.ToString() + "° " + descri, index.ToString()));
      return false;
    }

    private string GetDescri(string val)
    {
      if (val == "1")
        return "Mese";
      if (val == "2")
        return "Bimestre";
      if (val == "3")
        return "Trimestre";
      if (val == "4")
        return "Quadrimestre";
      if (val == "6")
        return "Semestre";
      return val == "12" ? "Anno" : "";
    }

    private void btnsElimina_Click(object sender, EventArgs e) => this.Aggiorna(ExecuteType.Delete);

    private void BtAdd_Click(object sender, EventArgs e)
    {
      for (int index = this.ListTipoManutenzione.Items.Count - 1; index >= 0; --index)
      {
        if (this.ListTipoManutenzione.Items[index].Selected)
        {
          this.ListTipoManutenzioneAdd.Items.Add(this.ListTipoManutenzione.Items[index]);
          this.ListTipoManutenzione.Items.RemoveAt(index);
        }
      }
    }

    private void BtRemove_Click(object sender, EventArgs e)
    {
      for (int index = this.ListTipoManutenzioneAdd.Items.Count - 1; index >= 0; --index)
      {
        if (this.ListTipoManutenzioneAdd.Items[index].Selected)
        {
          this.ListTipoManutenzione.Items.Add(this.ListTipoManutenzioneAdd.Items[index]);
          this.ListTipoManutenzioneAdd.Items.RemoveAt(index);
        }
      }
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();
  }
}
