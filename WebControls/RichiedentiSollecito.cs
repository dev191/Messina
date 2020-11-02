// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.RichiedentiSollecito
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ManOrdinaria;

namespace TheSite.WebControls
{
  public class RichiedentiSollecito : UserControl
  {
    protected Panel RichiedenteShowInfo;
    protected DataGrid DataGridRichiedente;
    public string idtxtRichNome = string.Empty;
    public string idtxtRichCognome = string.Empty;
    public string idtxtRichID = string.Empty;
    protected S_TextBox txtRichID;
    protected S_TextBox txtRichNome;
    protected S_TextBox txtRichCognome;
    protected S_TextBox txtstelefono;
    protected S_TextBox txtsemail;
    protected S_TextBox txtstanza;
    protected S_ComboBox cmbsGruppo;
    protected Button cmdRichiedente;
    protected LinkButton lnkVisContatti;
    protected Panel Panel1;
    protected LinkButton Linkbutton1;
    protected DataGrid DataGridEsegui;
    protected Panel PanelContatti;
    protected LinkButton lnkChiudi;
    protected CheckBox CkSendMail;
    public HtmlInputHidden idProg;
    public string idtxtRichGruppo = "";

    public void SendMail()
    {
    }

    private void Page_Load(object sender, EventArgs e)
    {
      this.idtxtRichNome = ((Control) this.txtRichNome).ClientID;
      this.idtxtRichCognome = ((Control) this.txtRichCognome).ClientID;
      this.idtxtRichID = ((Control) this.txtRichID).ClientID;
      this.idtxtRichGruppo = ((Control) this.cmbsGruppo).ClientID;
      ((WebControl) this.txtRichNome).Attributes.Add("onkeydown", "SvuotaID()");
      ((WebControl) this.txtRichCognome).Attributes.Add("onkeydown", "SvuotaID()");
      ((WebControl) this.cmbsGruppo).Attributes.Add("onchange", "SvuotaIDCmb()");
      if (this.IsPostBack)
        return;
      this.BindGruppo(((ListControl) this.cmbsGruppo).SelectedValue);
      if (this.Request.QueryString["VarApp"] == null)
        return;
      this.Progetto = this.Request.QueryString["VarApp"];
    }

    public S_TextBox s_RichNome => this.txtRichNome;

    public S_TextBox s_RichID => this.txtRichID;

    public S_TextBox s_RichCognome => this.txtRichCognome;

    public S_TextBox s_telefono => this.txtstelefono;

    public S_TextBox s_email => this.txtsemail;

    public S_TextBox s_stanza => this.txtstanza;

    public S_ComboBox s_RichGruppo => this.cmbsGruppo;

    public int IdGruppo => Convert.ToInt32(((ListControl) this.cmbsGruppo).SelectedValue);

    public string NomeCompleto => ((TextBox) this.txtRichNome).Text;

    public string CognomeCompleto => ((TextBox) this.txtRichCognome).Text;

    public bool IsSendMail => this.CkSendMail.Checked;

    public string telefono => ((TextBox) this.txtstelefono).Text;

    public string email => ((TextBox) this.txtsemail).Text;

    public string stanza => ((TextBox) this.txtstanza).Text;

    public string NomePannello => this.RichiedenteShowInfo.ClientID;

    public string Progetto
    {
      get => this.idProg.Value;
      set => this.idProg.Value = value;
    }

    public string Apici(object s) => s.ToString().Replace("'", "`");

    public void BindGruppo(string id_tipo)
    {
      ((ListControl) this.cmbsGruppo).Items.Clear();
      DataSet dataSet = new Richiedenti_tipo().GetAllAddProg(this.Progetto).Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsGruppo).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "id", "- - - - - - -", "0");
        ((ListControl) this.cmbsGruppo).DataTextField = "descrizione";
        ((ListControl) this.cmbsGruppo).DataValueField = "id";
        ((Control) this.cmbsGruppo).DataBind();
      }
      else
        ((ListControl) this.cmbsGruppo).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Gruppo -", string.Empty));
    }

    private void lnkChiudi_Click(object sender, EventArgs e)
    {
      this.DataGridRichiedente.CurrentPageIndex = 0;
      this.RichiedenteShowInfo.Visible = false;
    }

    private void DataGridRichiedente_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRichiedente.CurrentPageIndex = e.NewPageIndex;
      this.RicercaRichiedenti();
    }

    private void cmdRichiedente_Click(object sender, EventArgs e)
    {
      this.DataGridRichiedente.CurrentPageIndex = 0;
      this.RicercaRichiedenti();
    }

    private void RicercaRichiedenti()
    {
      string str1 = "<script language=\"javascript\">\n";
      string str2 = "</script>\n";
      Richiesta richiesta = new Richiesta();
      this.RichiedenteShowInfo.Visible = true;
      this.DataGridRichiedente.DataSource = (object) richiesta.GetRichiedenti(this.NomeCompleto, this.CognomeCompleto, this.Progetto, ((ListControl) this.cmbsGruppo).SelectedValue);
      this.DataGridRichiedente.DataBind();
      this.Page.RegisterStartupScript("script_richiedente", str1 + "RichiedentiSetVisible(true, '" + this.RichiedenteShowInfo.ClientID + "');" + str2);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.cmdRichiedente.Click += new EventHandler(this.cmdRichiedente_Click);
      this.lnkVisContatti.Click += new EventHandler(this.lnkVisContatti_Click);
      this.Load += new EventHandler(this.Page_Load);
      this.DataGridRichiedente.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRichiedente_PageIndexChanged);
    }

    private void lnkVisContatti_Click(object sender, EventArgs e)
    {
      if (int.Parse(((TextBox) this.txtRichID).Text) != 0)
      {
        string str1 = "<script language=\"javascript\">\n";
        string str2 = "</script>\n";
        Contatti contatti = new Contatti();
        this.PanelContatti.Visible = true;
        DataSet data = contatti.GetData(int.Parse(((TextBox) this.txtRichID).Text));
        if (data.Tables[0].Rows.Count > 0)
        {
          this.DataGridEsegui.DataSource = (object) data;
          this.DataGridEsegui.DataBind();
          this.Page.RegisterStartupScript("script_contatto", str1 + "RichiedentiSetVisible(true, '" + this.PanelContatti.ClientID + "');" + str2);
        }
        else
        {
          string script = "<script language=JavaScript>alert(\"Nessun contatto per il richiedente selezionato.\");" + "<" + "/" + "script>";
          if (this.Page.IsClientScriptBlockRegistered("clientScriptcontatti"))
            return;
          this.Page.RegisterStartupScript("clientScriptcontatti", script);
        }
      }
      else
      {
        string script = "<script language=JavaScript>alert(\"Nessun contatto per il richiedente selezionato.\");" + "<" + "/" + "script>";
        if (this.Page.IsClientScriptBlockRegistered("clientScriptcontatti"))
          return;
        this.Page.RegisterStartupScript("clientScriptcontatti", script);
      }
    }
  }
}
