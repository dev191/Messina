// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.Addetti
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.ManOrdinaria;

namespace TheSite.WebControls
{
  public class Addetti : UserControl
  {
    protected LinkButton lnkChiudi;
    protected TextBox txtAddetto;
    protected TextBox TxtIdAddetto;
    protected Panel AddettiShowInfo;
    protected DataGrid DataGridAddetto;
    protected Button cmdAddetto;
    protected TextBox hidBL_ID;
    protected TextBox hidDITTA_ID;
    public string IdTxtIdAddetto = string.Empty;
    public string idtxtAddetto = string.Empty;
    private string bl_id = "%";
    private int ditta_id = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      this.idtxtAddetto = this.txtAddetto.ClientID;
      this.IdTxtIdAddetto = this.TxtIdAddetto.ClientID;
    }

    private void RicercaAddetti()
    {
      string str1 = "<script language=\"javascript\">\n";
      string str2 = "</script>\n";
      Richiesta richiesta = new Richiesta();
      this.AddettiShowInfo.Visible = true;
      if (this.hidDITTA_ID.Text != "")
        this.DataGridAddetto.DataSource = (object) richiesta.GetAddetti(this.NomeCompleto, this.hidBL_ID.Text, int.Parse(this.hidDITTA_ID.Text));
      else
        this.DataGridAddetto.DataSource = (object) richiesta.GetAddetti(this.NomeCompleto, this.hidBL_ID.Text);
      this.DataGridAddetto.DataBind();
      this.Page.RegisterStartupScript("script_addetti", str1 + "AddettiSetVisible(true, '" + this.AddettiShowInfo.ClientID + "');" + str2);
    }

    public string Apici(object s) => s.ToString().Replace("'", "`");

    public string NomePannello => this.AddettiShowInfo.ClientID;

    public string NomeCompleto
    {
      get => this.txtAddetto.Text;
      set => this.txtAddetto.Text = value;
    }

    public string IdAddetto
    {
      get => this.TxtIdAddetto.Text;
      set => this.TxtIdAddetto.Text = value;
    }

    public TextBox TextIdAddetto => this.TxtIdAddetto;

    public void Set_BL_ID(string p_bl_id)
    {
      this.bl_id = p_bl_id;
      if (this.bl_id == "")
        this.bl_id = "%";
      this.hidBL_ID.Text = this.bl_id;
    }

    public Button btnAddetto => this.cmdAddetto;

    public void Set_BL_ID_DITTA_ID(string p_bl_id, int p_ditta_id)
    {
      this.bl_id = p_bl_id;
      if (this.bl_id == "")
        this.bl_id = "%";
      this.hidBL_ID.Text = this.bl_id;
      this.ditta_id = p_ditta_id;
      this.hidDITTA_ID.Text = this.ditta_id.ToString();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.cmdAddetto.Click += new EventHandler(this.cmdAddetto_Click);
      this.lnkChiudi.Click += new EventHandler(this.lnkChiudi_Click);
      this.DataGridAddetto.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridAddetto_PageIndexChanged);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void lnkChiudi_Click(object sender, EventArgs e)
    {
      this.DataGridAddetto.CurrentPageIndex = 0;
      this.AddettiShowInfo.Visible = false;
    }

    private void DataGridAddetto_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridAddetto.CurrentPageIndex = e.NewPageIndex;
      this.RicercaAddetti();
    }

    private void cmdAddetto_Click(object sender, EventArgs e)
    {
      this.DataGridAddetto.CurrentPageIndex = 0;
      this.RicercaAddetti();
    }
  }
}
