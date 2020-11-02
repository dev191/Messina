// Decompiled with JetBrains decompiler
// Type: WebCad.LeftFrame2
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebCad.Classi.ClassiAnagrafiche;
using WebCad.WebControls;
using WebCad.WiewCad;

namespace WebCad
{
  public class LeftFrame2 : Page
  {
    protected MyDropDownList CategorieDropDownList;
    protected MyDropDownList repartiDropDownList;
    protected MyDropDownList destUsoDropDownList;
    protected WebUserControlTreeView WebUserControlTreeView1;
    protected HtmlInputHidden hiddenEq;
    protected HtmlInputHidden hiddenStanze;
    protected HtmlInputHidden hiddenEqstd;
    protected HtmlSelect ListBoxEQSTD;
    protected HtmlSelect listBoxEQ;
    protected HtmlSelect ListBoxStanze;
    protected HtmlInputHidden stanzeDescription;
    protected HtmlInputHidden eqDescription;
    protected HtmlInputHidden eqStdDescription;
    protected TextBox idEdif;
    protected TextBox idPian;
    protected HtmlInputHidden hiddenPlanimetria;
    protected Button btnVisualizzaEq;
    protected Button btnVisualizza;
    protected Button Reset;
    protected string scriptDaEseguire = "";
    protected string contesto;
    protected TextBox idServ;
    protected Button btnVisualizzaBlTree;
    protected TextBox txtFiltraBlTree;
    protected string listBoxEQClId;

    private void Page_Load(object sender, EventArgs e)
    {
      this.listBoxEQClId = this.listBoxEQ.ClientID;
      this.ListBoxStanze.Attributes.Add("onkeydown", "deleteitem(this,event);");
      this.ListBoxEQSTD.Attributes.Add("onkeydown", "deleteitem(this,event);");
      this.listBoxEQ.Attributes.Add("onkeydown", "deleteitem(this,event);");
      if (!this.IsPostBack)
      {
        this.BindCategorie();
        this.BindReparti();
        this.BindDestUso();
        this.ViewState["contesto"] = (object) "edificio";
      }
      this.contesto = Convert.ToString(this.ViewState["contesto"]);
      if (this.Request["FromPaginaCreazioneRdl"] != null)
      {
        this.InpostaNodoAlbero();
        this.RiempiTxtEdificioPianoServ();
      }
      if (this.Request["FromPaginaApprovaEmettiRdl"] == null)
        return;
      this.InpostaNodoAlbero();
      this.RiempiTxtEdificioPianoServPlanimetria();
    }

    private void SetBlFl(int idBl, int idFl)
    {
      this.ViewState[nameof (idBl)] = (object) idBl;
      this.ViewState[nameof (idFl)] = (object) idFl;
    }

    private void InpostaNodoAlbero()
    {
      string BlId = this.Request["BlId"];
      int int32 = Convert.ToInt32(this.Request["IdPiano"]);
      this.WebUserControlTreeView1.SelezionaNodo(this.BlId_To_IdBl(BlId).ToString(), int32.ToString());
    }

    private void RiempiTxtEdificioPianoServ()
    {
      string BlId = this.Request["BlId"];
      int int32 = Convert.ToInt32(this.Request["IdPiano"]);
      int num = 0;
      if (this.Request["IdServizio"] != string.Empty)
        num = Convert.ToInt32(this.Request["IdServizio"]);
      this.idEdif.Text = this.BlId_To_IdBl(BlId).ToString();
      this.idPian.Text = int32.ToString();
      this.idServ.Text = num.ToString();
    }

    private void RiempiTxtEdificioPianoServPlanimetria()
    {
      string BlId = this.Request["BlId"];
      int int32 = Convert.ToInt32(this.Request["IdPiano"]);
      int num = 0;
      if (this.Request["IdServizio"] != string.Empty)
        num = Convert.ToInt32(this.Request["IdServizio"]);
      this.idEdif.Text = this.BlId_To_IdBl(BlId).ToString();
      this.idPian.Text = int32.ToString();
      this.idServ.Text = num.ToString();
      this.hiddenPlanimetria.Value = this.Request["Planimetria"];
    }

    private int BlId_To_IdBl(string BlId) => new Buildings().GetIdBl(BlId);

    private void BindCategorie()
    {
      this.CategorieDropDownList.SetDataSet("descrizione", "idcategoria", "Tutte le categorie", new Categorie().GetData());
      this.CategorieDropDownList.SetLabel("Categorie");
    }

    private void BindReparti()
    {
      this.repartiDropDownList.SetDataSet("reparto", "idreparto", "Tutti i reparti", new Reparti().GetData());
      this.repartiDropDownList.SetLabel("Reparti");
    }

    private void BindDestUso()
    {
      this.destUsoDropDownList.SetDataSet("reparto", "idreparto", "Tutte le destinazioni d'uso", new DestUso().GetData());
      this.destUsoDropDownList.SetLabel("Destinazione d'uso");
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.btnVisualizzaBlTree.Click += new EventHandler(this.btnVisualizzaBlTree_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void LoadListStanze()
    {
      string[] strArray1 = this.stanzeDescription.Value.Split(',');
      string[] strArray2 = this.hiddenStanze.Value.Split(',');
      this.ListBoxStanze.Items.Clear();
      int index = 0;
      foreach (string str in strArray2)
      {
        this.ListBoxStanze.Items.Add(new ListItem(strArray1[index], str));
        ++index;
      }
    }

    private void LoadListEq()
    {
      string[] strArray1 = this.eqDescription.Value.Split(',');
      string[] strArray2 = this.hiddenEq.Value.Split(',');
      this.listBoxEQ.Items.Clear();
      int index = 0;
      foreach (string str in strArray2)
      {
        this.listBoxEQ.Items.Add(new ListItem(strArray1[index], str));
        ++index;
      }
    }

    private void LoadListEqStd()
    {
      string[] strArray1 = this.eqStdDescription.Value.Split(',');
      string[] strArray2 = this.hiddenEqstd.Value.Split(',');
      this.ListBoxEQSTD.Items.Clear();
      int index = 0;
      foreach (string str in strArray2)
      {
        this.ListBoxEQSTD.Items.Add(new ListItem(strArray1[index], str));
        ++index;
      }
    }

    private void SetParametri(string tipo, int td)
    {
      ParametriRicerca parametriRicerca = new ParametriRicerca();
      parametriRicerca.tipoDataSet = td;
      parametriRicerca.tipo = tipo;
      parametriRicerca.blId = Convert.ToInt32(this.idEdif.Text);
      parametriRicerca.flId = Convert.ToInt32(this.idPian.Text);
      parametriRicerca.fileDwg = this.hiddenPlanimetria.Value;
      this.SetBlFl(Convert.ToInt32(this.idEdif.Text), Convert.ToInt32(this.idPian.Text));
      this.LoadListStanze();
      string str1 = "";
      foreach (ListItem listItem in this.ListBoxStanze.Items)
        str1 = !(str1 == "") ? str1 + "," + listItem.Value : str1 + listItem.Value;
      parametriRicerca.rmIds = str1;
      parametriRicerca.catId = !(this.CategorieDropDownList.getTesto() != "") ? 0 : Convert.ToInt32(this.CategorieDropDownList.getTesto());
      parametriRicerca.repartoId = !(this.repartiDropDownList.getTesto() != "") ? 0 : Convert.ToInt32(this.repartiDropDownList.getTesto());
      parametriRicerca.destUsoId = !(this.destUsoDropDownList.getTesto() != "") ? 0 : Convert.ToInt32(this.destUsoDropDownList.getTesto());
      this.LoadListEq();
      string str2 = "";
      foreach (ListItem listItem in this.listBoxEQ.Items)
        str2 = !(str2 == "") ? str2 + "," + listItem.Value : str2 + listItem.Value;
      parametriRicerca.eqIds = str2;
      this.LoadListEqStd();
      string str3 = "";
      foreach (ListItem listItem in this.ListBoxEQSTD.Items)
        str3 = !(str3 == "") ? str3 + "," + listItem.Value : str3 + listItem.Value;
      parametriRicerca.stdEqIds = str3;
      this.Session["parametri"] = (object) parametriRicerca;
    }

    private void btnVisualizzaBlTree_Click(object sender, EventArgs e)
    {
      this.WebUserControlTreeView1.BindData(new Edifici().GetDataByCampus(this.txtFiltraBlTree.Text));
      this.idEdif.Text = Convert.ToString(this.ViewState["idBl"]);
      this.idPian.Text = Convert.ToString(this.ViewState["idFl"]);
    }
  }
}
