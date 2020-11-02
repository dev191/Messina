// Decompiled with JetBrains decompiler
// Type: WebCad.Apparecchiature.SchedaApparecchiatura
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using WebCad.Classi;
using WebCad.Classi.AnagrafeImpianti;
using WebCad.Classi.ClassiDettaglio;
using WebCad.WebControls;

namespace WebCad.Apparecchiature
{
  public class SchedaApparecchiatura : Page
  {
    protected S_Label S_lblcodicecomponente;
    protected S_Label S_lblstdapparecchiature;
    protected S_Label S_lblcodiceedificio;
    protected S_Label S_lbledificio;
    protected S_Label S_lblpiano;
    protected S_Label S_lbltecnico;
    protected S_Label S_lblmarca;
    protected S_Label S_lblmodello;
    protected S_Label S_lbltipo;
    protected S_Label S_lblgaranzia;
    protected S_Label S_lblTitoloPage;
    protected Panel Panel1;
    protected DataList DataList1;
    protected DataPanel DataPanelPassi;
    protected DataList Datalist2;
    protected DataPanel DataPanel1;
    protected DataPanel DataPanelCaratteristiche;
    protected PageTitle PageTitle1;
    public string Imagename = "eq_image=";
    public static int FunId = 0;
    protected S_Button btnsRichieste;
    protected S_Label S_lblstanza;
    protected S_Label S_lblqta;
    public static string HelpLink = string.Empty;
    private int IDEQ = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      if (!this.IsPostBack)
      {
        if (this.Context.Items[(object) "eq_id"] != null)
          this.eq_id = (string) this.Context.Items[(object) "eq_id"];
        if (this.Request.QueryString["eq_id"] != null)
        {
          this.eq_id = this.Request.QueryString["eq_id"];
          this.PageTitle1.Visible = false;
        }
        this.Execute();
      }
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("\r\n<script type=\"text/javascript\">");
      stringBuilder.Append("function hideControl(c,c2){");
      stringBuilder.Append("var ctrl = document.getElementById(c).style;\n");
      stringBuilder.Append("if(ctrl.display=='none')\n");
      stringBuilder.Append("{\tctrl.display ='block';\n");
      stringBuilder.Append("\tdocument.getElementById(c2).src='../Images/downarrows_trans.gif';\n");
      stringBuilder.Append("}else{\t\n");
      stringBuilder.Append("\tctrl.display ='none';\n");
      stringBuilder.Append("\tdocument.getElementById(c2).src='../Images/uparrows_trans.gif';\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append("</script>");
      this.RegisterClientScriptBlock("exmpandi", stringBuilder.ToString());
    }

    private string eq_id
    {
      get => this.ViewState["s_eq_id"] == null ? string.Empty : (string) this.ViewState["s_eq_id"];
      set
      {
        if (value == null)
          this.ViewState["s_eq_id"] = (object) string.Empty;
        else
          this.ViewState["s_eq_id"] = (object) value;
      }
    }

    private void Execute()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_eq_std");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) this.eq_id);
      ((ParameterObject) sObject).set_Size(50);
      CollezioneControlli.Add(sObject);
      DataSet data = new WebCad.Classi.ClassiDettaglio.SchedaApparecchiatura("").GetData(CollezioneControlli);
      if (data.Tables[0].Rows.Count > 0)
      {
        ((Label) this.S_lblcodicecomponente).Text = data.Tables[0].Rows[0]["var_eq_eq_id"].ToString();
        ((Label) this.S_lblstdapparecchiature).Text = data.Tables[0].Rows[0]["var_eqstd_description"].ToString();
        ((Label) this.S_lblcodiceedificio).Text = data.Tables[0].Rows[0]["var_eq_bl_id"].ToString();
        ((Label) this.S_lbledificio).Text = data.Tables[0].Rows[0]["var_bl_name"].ToString();
        ((Label) this.S_lblpiano).Text = data.Tables[0].Rows[0]["var_eq_fl_id"].ToString();
        try
        {
          ((Label) this.S_lblstanza).Text = data.Tables[0].Rows[0]["stanza"].ToString();
          ((Label) this.S_lblqta).Text = data.Tables[0].Rows[0]["quantita"].ToString();
        }
        catch (Exception ex)
        {
          this.Response.Write(ex.Message);
        }
        ((Label) this.S_lbltecnico).Text = data.Tables[0].Rows[0]["var_sottocomponente"].ToString();
        ((Label) this.S_lblmarca).Text = data.Tables[0].Rows[0]["var_vn_id"].ToString();
        ((Label) this.S_lblmodello).Text = data.Tables[0].Rows[0]["var_eq_option1"].ToString();
        ((Label) this.S_lbltipo).Text = data.Tables[0].Rows[0]["var_eq_option2"].ToString();
        ((Label) this.S_lblgaranzia).Text = data.Tables[0].Rows[0]["var_garanzia"].ToString();
        this.Imagename += data.Tables[0].Rows[0]["var_eq_image_eq_assy"].ToString();
        this.BindAttivita(data.Tables[0].Rows[0]["var_eqstd_id"].ToString());
        DatiTecniciApparecchiatura tecniciApparecchiatura = new DatiTecniciApparecchiatura(this.Context.User.Identity.Name);
        this.IDEQ = Convert.ToInt32(data.Tables[0].Rows[0]["var_eq_id"]);
        DataSet singleDatitecnici = tecniciApparecchiatura.GetSingleDatitecnici(this.IDEQ);
        if (singleDatitecnici.Tables[0].Rows.Count > 0)
        {
          this.DataList1.DataSource = (object) singleDatitecnici;
          this.DataList1.DataBind();
        }
        else
          this.DataPanelCaratteristiche.set_TitleText("Nessuna Caratteristiche Tecniche.");
      }
      else
      {
        ((Label) this.S_lblcodicecomponente).Text = "";
        ((Label) this.S_lblstdapparecchiature).Text = "";
        ((Label) this.S_lblcodiceedificio).Text = "";
        ((Label) this.S_lbledificio).Text = "";
        ((Label) this.S_lblpiano).Text = "";
        ((Label) this.S_lbltecnico).Text = "";
        ((Label) this.S_lblmarca).Text = "";
        ((Label) this.S_lblmodello).Text = "";
        ((Label) this.S_lbltipo).Text = "";
        ((Label) this.S_lblgaranzia).Text = "";
      }
    }

    private void DescrizioniTecniche(string Description)
    {
      try
      {
        DataSet dataSet = new DataSet();
        XmlTextReader xmlTextReader = new XmlTextReader((TextReader) new StringReader(Description));
        int num = (int) dataSet.ReadXml((XmlReader) xmlTextReader, XmlReadMode.Auto);
        this.DataList1.DataSource = (object) dataSet;
        this.DataList1.DataBind();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private void BindAttivita(string eqstd_id)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_eqstd_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) int.Parse(eqstd_id));
      CollezioneControlli.Add(sObject);
      this.Datalist2.DataSource = (object) new Passi("").GetData(CollezioneControlli);
      this.Datalist2.DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.Datalist2.ItemDataBound += new DataListItemEventHandler(this.Datalist2_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void Datalist2_ItemDataBound(object sender, DataListItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.EditItem)
        return;
      string clientId = e.Item.Controls[15].ClientID;
      HtmlAnchor control1 = (HtmlAnchor) e.Item.Controls[1];
      HtmlImage control2 = (HtmlImage) e.Item.Controls[1].Controls[0];
      control1.HRef = "javascript:hideControl('" + clientId + "','" + control2.ClientID + "');";
      Repeater control3 = (Repeater) e.Item.FindControl("repetarpassi");
      control3.DataSource = (object) this.BindingPassi(this.Datalist2.DataKeys[e.Item.ItemIndex].ToString());
      control3.DataBind();
    }

    private DataSet BindingPassi(string id) => new Passi("").GetSingleData(int.Parse(id));

    private void btnsRichieste_Click(object sender, EventArgs e) => this.Response.Redirect("RichiesteApparecchiatura.aspx?FunId=" + (object) SchedaApparecchiatura.FunId);
  }
}
