// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.DescrizioneDoc_Dwf
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class DescrizioneDoc_Dwf : Page
  {
    protected S_Label S_Lblcodedificio;
    protected S_ComboBox cmbsCategoriaGenerale;
    protected S_ComboBox cmbsCategoria;
    protected HtmlTable TableVVf;
    protected S_TextBox txtNFascicoloVVF;
    protected S_CheckBox checkCollaudoVVF;
    protected S_ComboBox cmbsTipoFile;
    protected S_ComboBox cmbsTipologiaDocumento;
    protected S_TextBox txtISPESL;
    protected S_ComboBox S_CbAnno;
    protected HtmlTable TableISPESL;
    protected S_Button btNuovo;
    protected S_Button btSalva;
    protected S_Button btBack;
    protected S_Label S_LblCodiceDoc;
    protected CalendarPicker CalendarPicker1VVF;
    protected CalendarPicker CalendarPicker2VVF;
    protected CalendarPicker CalendarPicker3VVF;
    protected S_Label S_Lblerror;
    protected HtmlInputFile Uploader;
    protected RequiredFieldValidator RequiredFieldValidator1;
    protected RequiredFieldValidator RequiredFieldValidator2;
    protected RequiredFieldValidator RequiredFieldValidator3;
    protected RequiredFieldValidator RequiredFieldValidator4;
    protected ValidationSummary ValidationSummary1;
    protected RequiredFieldValidator RequiredFieldValidator5;
    protected CalendarPicker CalendarPicker4ISPESL;
    protected S_Label S_LblFileName;
    protected S_Label lblFirstAndLast;
    protected S_CheckBox CheckRinomina;
    protected S_TextBox txtNumeroPagina;
    protected PageTitle PageTitle1;
    private int Dimension = 0;
    public static int FunId = 0;
    protected S_TextBox txtsdescrizione;
    protected S_ComboBox cmbsServizio;
    protected S_ComboBox cmbsPiano;
    public static string HelpLink = string.Empty;

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      DescrizioneDoc_Dwf.FunId = siteModule.ModuleId;
      DescrizioneDoc_Dwf.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      ((WebControl) this.txtNumeroPagina).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtNumeroPagina).Attributes.Add("onpaste", "return nonpaste();");
      ((WebControl) this.CheckRinomina).Attributes.Add("onclick", "abilita(this);");
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.Append("document.getElementById('" + ((Control) this.cmbsCategoria).ClientID + "').disabled = true;");
      stringBuilder1.Append("document.getElementById('" + ((Control) this.cmbsTipologiaDocumento).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsCategoriaGenerale).Attributes.Add("onchange", stringBuilder1.ToString());
      StringBuilder stringBuilder2 = new StringBuilder();
      stringBuilder2.Append("document.getElementById('" + ((Control) this.cmbsCategoria).ClientID + "').disabled = true;");
      stringBuilder2.Append("document.getElementById('" + ((Control) this.cmbsCategoriaGenerale).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsTipologiaDocumento).Attributes.Add("onchange", stringBuilder2.ToString());
      StringBuilder stringBuilder3 = new StringBuilder();
      stringBuilder3.Append("document.getElementById('" + ((Control) this.cmbsCategoriaGenerale).ClientID + "').disabled = true;");
      stringBuilder3.Append("document.getElementById('" + ((Control) this.cmbsTipologiaDocumento).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsCategoria).Attributes.Add("onchange", stringBuilder3.ToString());
      if (this.IsPostBack)
        return;
      ((WebControl) this.txtNumeroPagina).Attributes.Add("disabled", "");
      PropertyInfo property = this.Context.Handler.GetType().GetProperty("_Contenitore");
      if (property != null)
        this.ViewState.Add("mioContenitore", property.GetValue((object) this.Context.Handler, (object[]) null));
      ((WebControl) this.btNuovo).Enabled = false;
      ((Button) this.btNuovo).CommandArgument = "";
      this.TableVVf.Visible = false;
      this.TableISPESL.Visible = false;
      if (this.Context.Items[(object) "CODEDI"] != null)
        ((Label) this.S_Lblcodedificio).Text = (string) this.Context.Items[(object) "CODEDI"];
      if (this.Context.Items[(object) "IDBL"] != null)
        this.BL_ID = (string) this.Context.Items[(object) "IDBL"];
      if (this.Context.Items[(object) "IDDOC"] != null)
        this.IDDOC = (string) this.Context.Items[(object) "IDDOC"];
      if (this.Context.Items[(object) "FILE"] != null)
        ((Label) this.S_LblCodiceDoc).Text = (string) this.Context.Items[(object) "FILE"];
      this.BindPiano(this.BL_ID);
      this.BindServizio(this.BL_ID);
      this.BindTipoDocumento();
      this.BindCategorieGenerali();
      this.BindingComboAnno();
      if (!(this.IDDOC != ""))
        return;
      this.GetData();
    }

    private string BL_ID
    {
      get => this.ViewState[nameof (BL_ID)] != null ? (string) this.ViewState[nameof (BL_ID)] : string.Empty;
      set => this.ViewState.Add(nameof (BL_ID), (object) value);
    }

    private string IDDOC
    {
      get => this.ViewState[nameof (IDDOC)] != null ? (string) this.ViewState[nameof (IDDOC)] : string.Empty;
      set => this.ViewState.Add(nameof (IDDOC), (object) value);
    }

    private string MAX
    {
      get => this.ViewState[nameof (MAX)] != null ? (string) this.ViewState[nameof (MAX)] : string.Empty;
      set => this.ViewState.Add(nameof (MAX), (object) value);
    }

    private void GetData()
    {
      AnagrafeDocDWF anagrafeDocDwf = new AnagrafeDocDWF(this.Context.User.Identity.Name);
      if (int.Parse(this.IDDOC) == 0)
        return;
      DataSet singleData = anagrafeDocDwf.GetSingleData(int.Parse(this.BL_ID), int.Parse(this.IDDOC));
      if (singleData.Tables[0].Rows.Count <= 0)
        return;
      DataRow row = singleData.Tables[0].Rows[0];
      if (row["anno_scadenza"] != DBNull.Value)
        ((ListControl) this.S_CbAnno).SelectedValue = row["anno_scadenza"].ToString();
      if (row["pianoid"] != DBNull.Value)
        ((ListControl) this.cmbsPiano).SelectedValue = row["pianoid"].ToString();
      if (row["idservizio"] != DBNull.Value)
        ((ListControl) this.cmbsServizio).SelectedValue = row["idservizio"].ToString();
      if (row["documento_id"] != DBNull.Value)
        ((ListControl) this.cmbsTipoFile).SelectedValue = row["documento_id"].ToString();
      if (row["descrizionegenerale"] != DBNull.Value)
      {
        ((ListControl) this.cmbsCategoriaGenerale).SelectedValue = row["descrizionegenerale"].ToString();
        this.BindCategorie(int.Parse(((ListControl) this.cmbsCategoriaGenerale).SelectedValue));
      }
      if (row["categoria"] != DBNull.Value)
      {
        ((ListControl) this.cmbsCategoria).SelectedValue = row["categoria"].ToString();
        this.BindTipologiaDoc(int.Parse(((ListControl) this.cmbsCategoria).SelectedValue.Split(Convert.ToChar(","))[0]));
        this.SetVisibleTable(((ListControl) this.cmbsCategoria).SelectedValue);
      }
      if (row["tipologia"] != DBNull.Value)
      {
        ((ListControl) this.cmbsTipologiaDocumento).SelectedValue = row["tipologia"].ToString();
        int.Parse(((ListControl) this.cmbsTipologiaDocumento).SelectedValue.Split(Convert.ToChar(","))[0]);
      }
      if (row["descrizione1"] != DBNull.Value)
        ((TextBox) this.txtsdescrizione).Text = row["descrizione1"].ToString();
      if (row["n_fascicolo_vvf"] != DBNull.Value)
        ((TextBox) this.txtNFascicoloVVF).Text = row["n_fascicolo_vvf"].ToString();
      if (row["data_rilascio_cpi"] != DBNull.Value)
        ((TextBox) this.CalendarPicker1VVF.Datazione).Text = DateTime.Parse(row["data_rilascio_cpi"].ToString()).ToShortDateString();
      if (row["data_scadenza_cpi"] != DBNull.Value)
        ((TextBox) this.CalendarPicker2VVF.Datazione).Text = DateTime.Parse(row["data_scadenza_cpi"].ToString()).ToShortDateString();
      if (row["data_parere_favorevole"] != DBNull.Value)
        ((TextBox) this.CalendarPicker3VVF.Datazione).Text = DateTime.Parse(row["data_parere_favorevole"].ToString()).ToShortDateString();
      if (row["collaudo"] != DBNull.Value)
        ((CheckBox) this.checkCollaudoVVF).Checked = !(row["collaudo"].ToString() == "0");
      if (row["matricola_ispesl"] != DBNull.Value)
        ((TextBox) this.txtISPESL).Text = row["matricola_ispesl"].ToString();
      if (row["data_prima_verifica"] != DBNull.Value)
        ((TextBox) this.CalendarPicker4ISPESL.Datazione).Text = DateTime.Parse(row["data_prima_verifica"].ToString()).ToShortDateString();
      if (row["NOMEDWF"] != DBNull.Value)
        ((Label) this.S_LblFileName).Text = row["NOMEDWF"].ToString();
      if (row["CODICEDWF"] != DBNull.Value)
        ((Label) this.S_LblCodiceDoc).Text = row["CODICEDWF"].ToString();
      if (row["pagine_documento"] != DBNull.Value)
        this.MAX = row["pagine_documento"].ToString();
      ((Label) this.lblFirstAndLast).Text = anagrafeDocDwf.GetFirstAndLastUser(row);
      this.DisableControl(false, (Control) this.Page);
      if (row["NOMEDWF"] != DBNull.Value && row["CODICEDWF"] != DBNull.Value && row["NOMEDWF"].ToString() == row["CODICEDWF"].ToString())
        ((CheckBox) this.CheckRinomina).Checked = true;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("if (typeof(Page_ClientValidate) == 'function') { ");
      stringBuilder.Append("if (Page_ClientValidate() == false) { return false; } ");
      stringBuilder.Append("if (confirm('Sei sicuro di sostituire il file?') == false) { return false; }} ");
      stringBuilder.Append("this.value = 'Attendere ...';");
      stringBuilder.Append("this.disabled = true;");
      stringBuilder.Append("document.getElementById('" + ((Control) this.btSalva).ClientID + "').disabled = true;");
      stringBuilder.Append(this.Page.GetPostBackEventReference((Control) this.btSalva));
      stringBuilder.Append(";");
      ((WebControl) this.btSalva).Attributes.Add("onclick", stringBuilder.ToString());
      ((WebControl) this.btSalva).Enabled = true;
      ((WebControl) this.btNuovo).Enabled = true;
      ((WebControl) this.btBack).Enabled = true;
      this.RequiredFieldValidator5.Enabled = true;
    }

    private void BindingComboAnno()
    {
      DateTime now = DateTime.Now;
      ((ListControl) this.S_CbAnno).Items.Add(new ListItem("", ""));
      for (int index = 1970; index <= now.Year + 15; ++index)
        ((ListControl) this.S_CbAnno).Items.Add(new ListItem(index.ToString(), index.ToString()));
    }

    private void BindServizio(string CodEdificio)
    {
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet serviziEdifici = new DatiApparecchiatura(this.Context.User.Identity.Name).GetServiziEdifici(int.Parse(this.BL_ID));
      if (serviziEdifici.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(serviziEdifici.Tables[0], "DESCRIZIONE", "ID", "- Selezionare un Servizio -", "");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "ID";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", string.Empty));
    }

    private void BindPiano(string CodEdificio)
    {
      ((ListControl) this.cmbsPiano).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet pianiBuilding = new TheSite.Classi.ClassiAnagrafiche.Buildings().GetPianiBuilding(int.Parse(this.BL_ID));
      if (pianiBuilding.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsPiano).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(pianiBuilding.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "-1");
        ((ListControl) this.cmbsPiano).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsPiano).DataValueField = "ID";
        ((Control) this.cmbsPiano).DataBind();
      }
      else
        ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", string.Empty));
    }

    private void BindTipoDocumento()
    {
      ((ListControl) this.cmbsTipoFile).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet tipologiaFile = new AnagrafeDocDWF(this.Context.User.Identity.Name).GetTipologiaFile();
      if (tipologiaFile.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsTipoFile).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(tipologiaFile.Tables[0], "DESCRIZIONE", "ID", "- Selezionare la Tipologia del File -", "");
        ((ListControl) this.cmbsTipoFile).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsTipoFile).DataValueField = "ID";
        ((Control) this.cmbsTipoFile).DataBind();
      }
      else
        ((ListControl) this.cmbsTipoFile).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Tipologia del File -", string.Empty));
    }

    private void BindCategorieGenerali()
    {
      ((ListControl) this.cmbsCategoriaGenerale).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet categoriaGenerali = new AnagrafeDocDWF(this.Context.User.Identity.Name).GetCategoriaGenerali();
      if (categoriaGenerali.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsCategoriaGenerale).DataSource = (object) categoriaGenerali.Tables[0];
        ((ListControl) this.cmbsCategoriaGenerale).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsCategoriaGenerale).DataValueField = "ID";
        ((Control) this.cmbsCategoriaGenerale).DataBind();
        this.BindCategorie(int.Parse(((ListControl) this.cmbsCategoriaGenerale).SelectedValue));
      }
      else
        ((ListControl) this.cmbsCategoriaGenerale).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Categoria Generale -", string.Empty));
    }

    private void BindCategorie(int idCategoriaGenerale)
    {
      ((ListControl) this.cmbsCategoria).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet categoria = new AnagrafeDocDWF(this.Context.User.Identity.Name).GetCategoria(idCategoriaGenerale);
      if (categoria.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsCategoria).DataSource = (object) categoria.Tables[0];
        ((ListControl) this.cmbsCategoria).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsCategoria).DataValueField = "ID";
        ((Control) this.cmbsCategoria).DataBind();
        this.BindTipologiaDoc(int.Parse(((ListControl) this.cmbsCategoria).SelectedValue.Split(Convert.ToChar(","))[0]));
        this.SetVisibleTable(((ListControl) this.cmbsCategoria).SelectedValue);
      }
      else
        ((ListControl) this.cmbsCategoria).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Categoria Generale -", string.Empty));
    }

    private void BindTipologiaDoc(int idCategoria)
    {
      ((ListControl) this.cmbsTipologiaDocumento).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet tipologiaDoc = new AnagrafeDocDWF(this.Context.User.Identity.Name).GetTipologiaDoc(idCategoria);
      if (tipologiaDoc.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsTipologiaDocumento).DataSource = (object) tipologiaDoc.Tables[0];
        ((ListControl) this.cmbsTipologiaDocumento).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsTipologiaDocumento).DataValueField = "ID";
        ((Control) this.cmbsTipologiaDocumento).DataBind();
        int.Parse(((ListControl) this.cmbsTipologiaDocumento).SelectedValue.Split(Convert.ToChar(","))[0]);
        this.SetVisibleTable(idCategoria.ToString());
      }
      else
        ((ListControl) this.cmbsTipologiaDocumento).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Tipologia del Documento -", string.Empty));
    }

    private void execute()
    {
      string empty1 = string.Empty;
      AnagrafeDocDWF anagrafeDocDwf = new AnagrafeDocDWF(this.Context.User.Identity.Name);
      string str1 = empty1 + ((Label) this.S_Lblcodedificio).Text.Replace(".", "_") + "_" + ((ListControl) this.cmbsServizio).SelectedValue.Split(Convert.ToChar(" "))[1] + "_" + ((ListControl) this.cmbsTipologiaDocumento).SelectedValue.Split(Convert.ToChar(","))[1] + "_" + ((ListControl) this.cmbsCategoria).SelectedValue.Split(Convert.ToChar(","))[1] + "_";
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string FileName = string.Empty;
      if (((TextBox) this.txtNumeroPagina).Text == "")
        ((TextBox) this.txtNumeroPagina).Text = "1";
      int num;
      string str2;
      if (((Label) this.S_LblCodiceDoc).Text == "")
      {
        num = int.Parse(((TextBox) this.txtNumeroPagina).Text);
        str2 = str1 + ((TextBox) this.txtNumeroPagina).Text + "_R0" + Path.GetExtension(this.Uploader.PostedFile.FileName);
        if (((CheckBox) this.CheckRinomina).Checked)
        {
          if (this.ExistFile(str2))
          {
            ((Label) this.S_Lblerror).Text = "Il file è gia presente impossibile inserire. Inserire un numero di pagina diverso.";
            return;
          }
        }
        else if (this.ExistFile(""))
        {
          ((Label) this.S_Lblerror).Text = "Il file è gia presente impossibile inserire. Rinominare il File.";
          return;
        }
      }
      else if (this.IsSelectFile())
      {
        string extension = Path.GetExtension(this.Uploader.PostedFile.FileName);
        str2 = str1 + ((TextBox) this.txtNumeroPagina).Text + "_R0" + extension;
        num = int.Parse(((TextBox) this.txtNumeroPagina).Text);
        if (!((CheckBox) this.CheckRinomina).Checked && ((Label) this.S_LblFileName).Text != Path.GetFileName(this.Uploader.PostedFile.FileName))
        {
          if (this.ExistFile(""))
          {
            ((Label) this.S_Lblerror).Text = "Il file è gia presente impossibile inserire. Rinominare il File.";
            return;
          }
          FileName = ((Label) this.S_LblFileName).Text;
        }
        else if (((CheckBox) this.CheckRinomina).Checked && Path.GetExtension(((Label) this.S_LblFileName).Text) != str2)
          FileName = ((Label) this.S_LblFileName).Text;
      }
      else
      {
        string extension = Path.GetExtension(((Label) this.S_LblCodiceDoc).Text);
        str2 = str1 + this.MAX + "_R0" + extension;
        num = int.Parse(this.MAX);
      }
      string str3 = !((CheckBox) this.CheckRinomina).Checked ? this.PostFile("") : this.PostFile(str2);
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_doc_dwf");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) (this.IDDOC == "" ? 0 : int.Parse(this.IDDOC)));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_nomedwf");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) str3);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_nfascicolo");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(20);
      ((ParameterObject) sObject3).set_Value((object) ((TextBox) this.txtNFascicoloVVF).Text);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_datarilascio_cpi");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(15);
      ((ParameterObject) sObject4).set_Value((object) ((TextBox) this.CalendarPicker1VVF.Datazione).Text);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_datascadenza_cpi");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Size(15);
      ((ParameterObject) sObject5).set_Value((object) ((TextBox) this.CalendarPicker2VVF.Datazione).Text);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_dataparere_cpi");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size(15);
      ((ParameterObject) sObject6).set_Value((object) ((TextBox) this.CalendarPicker3VVF.Datazione).Text);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_collaudo");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Value((object) (((CheckBox) this.checkCollaudoVVF).Checked ? 1 : 0));
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_matricola");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Size(20);
      ((ParameterObject) sObject8).set_Value((object) ((TextBox) this.txtISPESL).Text);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_dataprimaverifica");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(8);
      ((ParameterObject) sObject9).set_Size(15);
      ((ParameterObject) sObject9).set_Value((object) ((TextBox) this.CalendarPicker4ISPESL.Datazione).Text);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_anno");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(9);
      ((ParameterObject) sObject10).set_Size(4);
      ((ParameterObject) sObject10).set_Value((object) ((ListControl) this.S_CbAnno).Items[((ListControl) this.S_CbAnno).SelectedIndex].Value);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_ddr_id");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(10);
      ((ParameterObject) sObject11).set_Value((object) ((ListControl) this.cmbsCategoriaGenerale).SelectedValue);
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject12).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(11);
      ((ParameterObject) sObject12).set_Value((object) ((TextBox) this.txtsdescrizione).Text);
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_documento_id");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(12);
      ((ParameterObject) sObject13).set_Value((object) ((ListControl) this.cmbsTipoFile).SelectedValue);
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("p_id_bl");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(13);
      ((ParameterObject) sObject14).set_Value((object) int.Parse(this.BL_ID));
      CollezioneControlli.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Size(8);
      ((ParameterObject) sObject15).set_Index(14);
      ((ParameterObject) sObject15).set_Value((object) ((Label) this.S_Lblcodedificio).Text);
      CollezioneControlli.Add(sObject15);
      S_Object sObject16 = new S_Object();
      ((ParameterObject) sObject16).set_ParameterName("p_piano_id");
      ((ParameterObject) sObject16).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject16).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject16).set_Index(15);
      ((ParameterObject) sObject16).set_Value((object) Convert.ToInt32(((ListControl) this.cmbsPiano).SelectedValue.ToString()));
      CollezioneControlli.Add(sObject16);
      S_Object sObject17 = new S_Object();
      ((ParameterObject) sObject17).set_ParameterName("p_servizio_id");
      ((ParameterObject) sObject17).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject17).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject17).set_Index(16);
      ((ParameterObject) sObject17).set_Value((object) int.Parse(((ListControl) this.cmbsServizio).SelectedValue.Split(Convert.ToChar(" "))[0]));
      CollezioneControlli.Add(sObject17);
      S_Object sObject18 = new S_Object();
      ((ParameterObject) sObject18).set_ParameterName("p_iddocdwf_tipologie");
      ((ParameterObject) sObject18).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject18).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject18).set_Index(17);
      ((ParameterObject) sObject18).set_Value((object) int.Parse(((ListControl) this.cmbsTipologiaDocumento).SelectedValue.Split(Convert.ToChar(","))[0]));
      CollezioneControlli.Add(sObject18);
      S_Object sObject19 = new S_Object();
      ((ParameterObject) sObject19).set_ParameterName("p_iddocdwf_categorie");
      ((ParameterObject) sObject19).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject19).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject19).set_Index(18);
      ((ParameterObject) sObject19).set_Value((object) int.Parse(((ListControl) this.cmbsCategoria).SelectedValue.Split(Convert.ToChar(","))[0]));
      CollezioneControlli.Add(sObject19);
      S_Object sObject20 = new S_Object();
      ((ParameterObject) sObject20).set_ParameterName("p_paginedocumento");
      ((ParameterObject) sObject20).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject20).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject20).set_Index(19);
      ((ParameterObject) sObject20).set_Value((object) num);
      CollezioneControlli.Add(sObject20);
      S_Object sObject21 = new S_Object();
      ((ParameterObject) sObject21).set_ParameterName("p_codicedwf");
      ((ParameterObject) sObject21).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject21).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject21).set_Index(20);
      ((ParameterObject) sObject21).set_Size(50);
      ((ParameterObject) sObject21).set_Value((object) str2);
      CollezioneControlli.Add(sObject21);
      S_Object sObject22 = new S_Object();
      ((ParameterObject) sObject22).set_ParameterName("p_dimensionefile");
      ((ParameterObject) sObject22).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject22).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject22).set_Index(21);
      ((ParameterObject) sObject22).set_Value((object) this.Dimension);
      CollezioneControlli.Add(sObject22);
      try
      {
        this.IDDOC = (!(this.IDDOC == "") ? anagrafeDocDwf.Update(CollezioneControlli, int.Parse(this.IDDOC)) : anagrafeDocDwf.Add(CollezioneControlli)).ToString();
        if (FileName != string.Empty)
          this.DeleteFile(FileName);
        this.GetData();
      }
      catch (Exception ex)
      {
        ((Label) this.S_Lblerror).Text = ex.Message;
      }
    }

    private void DeleteFile(string FileName)
    {
      string path1 = this.Server.MapPath("../Doc_DB");
      string path2_1 = ((ListControl) this.cmbsCategoria).Items[((ListControl) this.cmbsCategoria).SelectedIndex].Text.Replace(" ", "_").Replace("/", "_");
      string path2_2 = ((ListControl) this.cmbsTipologiaDocumento).Items[((ListControl) this.cmbsTipologiaDocumento).SelectedIndex].Text.Replace(" ", "_").Replace("/", "_");
      string path = Path.Combine(Path.Combine(Path.Combine(path1, path2_1), path2_2), FileName);
      if (!File.Exists(path))
        return;
      File.Delete(path);
    }

    private string PostFile(string RenameFile)
    {
      if (this.Uploader.PostedFile != null)
      {
        if (this.Uploader.PostedFile.FileName != "")
        {
          try
          {
            string path2_1 = Path.GetFileName(this.Uploader.PostedFile.FileName);
            string path1 = this.Server.MapPath("../Doc_DB");
            string path2_2 = ((ListControl) this.cmbsCategoria).Items[((ListControl) this.cmbsCategoria).SelectedIndex].Text.Replace(" ", "_").Replace("/", "_");
            string path2_3 = ((ListControl) this.cmbsTipologiaDocumento).Items[((ListControl) this.cmbsTipologiaDocumento).SelectedIndex].Text.Replace(" ", "_").Replace("/", "_");
            string str1 = Path.Combine(path1, path2_2);
            if (!Directory.Exists(str1))
              Directory.CreateDirectory(str1);
            string str2 = Path.Combine(str1, path2_3);
            if (!Directory.Exists(str2))
              Directory.CreateDirectory(str2);
            Path.Combine(str2, path2_1);
            this.Dimension = this.Uploader.PostedFile.ContentLength;
            string filename;
            if (RenameFile == "")
            {
              filename = Path.Combine(str2, path2_1);
            }
            else
            {
              filename = Path.Combine(str2, RenameFile);
              path2_1 = RenameFile;
            }
            this.Uploader.PostedFile.SaveAs(filename);
            return path2_1;
          }
          catch (Exception ex)
          {
            ((Label) this.S_Lblerror).Text = string.Format("Errore nell'invio del File: {0}", (object) ex.Message);
            Console.WriteLine(ex.Message);
            return "";
          }
        }
      }
      return "";
    }

    private bool ExistFile(string RenameFileName)
    {
      if (this.Uploader.PostedFile == null || !(this.Uploader.PostedFile.FileName != ""))
        return false;
      string fileName = Path.GetFileName(this.Uploader.PostedFile.FileName);
      string path1 = this.Server.MapPath("../Doc_DB");
      string path2_1 = ((ListControl) this.cmbsCategoria).Items[((ListControl) this.cmbsCategoria).SelectedIndex].Text.Replace(" ", "_").Replace("/", "_");
      string path2_2 = ((ListControl) this.cmbsTipologiaDocumento).Items[((ListControl) this.cmbsTipologiaDocumento).SelectedIndex].Text.Replace(" ", "_").Replace("/", "_");
      string str1 = Path.Combine(path1, path2_1);
      if (!Directory.Exists(str1))
        Directory.CreateDirectory(str1);
      string str2 = Path.Combine(str1, path2_2);
      if (!Directory.Exists(str2))
        Directory.CreateDirectory(str2);
      string empty = string.Empty;
      return File.Exists(!(RenameFileName == "") ? Path.Combine(str2, RenameFileName) : Path.Combine(str2, fileName));
    }

    private bool IsSelectFile() => this.Uploader.PostedFile != null && this.Uploader.PostedFile.FileName != "";

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsCategoriaGenerale).SelectedIndexChanged += new EventHandler(this.cmbsCategoriaGenerale_SelectedIndexChanged);
      ((ListControl) this.cmbsCategoria).SelectedIndexChanged += new EventHandler(this.cmbsCategoria_SelectedIndexChanged);
      ((ListControl) this.cmbsTipologiaDocumento).SelectedIndexChanged += new EventHandler(this.cmbsTipologiaDocumento_SelectedIndexChanged);
      ((Button) this.btNuovo).Click += new EventHandler(this.btNuovo_Click);
      ((Button) this.btSalva).Click += new EventHandler(this.btSalva_Click);
      ((Button) this.btBack).Click += new EventHandler(this.btBack_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btSalva_Click(object sender, EventArgs e)
    {
      ((Label) this.S_Lblerror).Text = "";
      this.execute();
    }

    private void btNuovo_Click(object sender, EventArgs e)
    {
      this.DisableControl(true, (Control) this.Page);
      ((Label) this.S_Lblerror).Text = "";
      this.IDDOC = "";
      this.MAX = "";
      ((Label) this.S_LblCodiceDoc).Text = "";
      ((Label) this.S_LblFileName).Text = "";
      ((WebControl) this.btSalva).Enabled = true;
      ((WebControl) this.btNuovo).Enabled = false;
      ((WebControl) this.btBack).Enabled = true;
      this.RequiredFieldValidator5.Enabled = true;
    }

    private void cmbsTipologiaDocumento_SelectedIndexChanged(object sender, EventArgs e) => int.Parse(((ListControl) this.cmbsTipologiaDocumento).SelectedValue.Split(Convert.ToChar(","))[0]);

    private void cmbsCategoriaGenerale_SelectedIndexChanged(object sender, EventArgs e) => this.BindCategorie(int.Parse(((ListControl) this.cmbsCategoriaGenerale).SelectedValue));

    private void cmbsCategoria_SelectedIndexChanged(object sender, EventArgs e) => this.BindTipologiaDoc(int.Parse(((ListControl) this.cmbsCategoria).SelectedValue.Split(Convert.ToChar(","))[0]));

    private void SetVisibleTable(string value)
    {
      this.TableVVf.Visible = false;
      this.TableISPESL.Visible = false;
      if (value.Split(Convert.ToChar(","))[0] == "8" || value == "8")
      {
        this.TableVVf.Visible = true;
        ((TextBox) this.txtISPESL).Text = "";
        ((TextBox) this.CalendarPicker4ISPESL.Datazione).Text = "";
        ((ListControl) this.S_CbAnno).SelectedIndex = 0;
        this.CalendarPicker1VVF.CreateValidator("Inserire la Data Rilascio CPI", ValidatorDisplay.None);
        this.CalendarPicker2VVF.CreateValidator("Inserire la Data Scadenza CPI", ValidatorDisplay.None);
        this.CalendarPicker3VVF.CreateValidator("Inserire la Data Parere Favorevole", ValidatorDisplay.None);
      }
      if (!(value.Split(Convert.ToChar(","))[0] == "6") && !(value == "6"))
        return;
      this.TableISPESL.Visible = true;
      ((TextBox) this.txtNFascicoloVVF).Text = "";
      ((CheckBox) this.checkCollaudoVVF).Checked = false;
      ((TextBox) this.CalendarPicker1VVF.Datazione).Text = "";
      ((TextBox) this.CalendarPicker2VVF.Datazione).Text = "";
      ((TextBox) this.CalendarPicker3VVF.Datazione).Text = "";
      this.CalendarPicker4ISPESL.CreateValidator("Inserire la Data Prima Verifica", ValidatorDisplay.None);
    }

    private void btBack_Click(object sender, EventArgs e) => this.Server.Transfer("ListaDoc_Dwf.aspx");

    private void DisableControl(bool disable, Control Contrl)
    {
      foreach (Control control in Contrl.Controls)
      {
        if (control is TextBox)
          ((WebControl) control).Enabled = disable;
        if (control is CheckBox)
          ((WebControl) control).Enabled = disable;
        if (control is DropDownList)
          ((WebControl) control).Enabled = disable;
        if (control is Button)
          ((WebControl) control).Enabled = disable;
        if (control.Controls.Count > 0)
          this.DisableControl(disable, control);
      }
    }
  }
}
