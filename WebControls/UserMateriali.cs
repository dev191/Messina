// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.UserMateriali
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManCorrettiva;

namespace TheSite.WebControls
{
  public class UserMateriali : UserControl
  {
    protected S_TextBox txtMateriale;
    protected HtmlInputHidden hidDettMat;
    public string TextRicMat;
    public string idTextRicMat;
    public string idModuloMat = string.Empty;
    protected S_TextBox txtquantita;
    protected S_TextBox txttotale;
    protected Label lblunita;
    protected Label lblprezzounitario;
    protected ImageButton imbCancel;
    protected ImageButton imbUpdate;
    protected S_TextBox txtid;
    protected S_TextBox lbldes;
    private int idMateriale = 0;
    protected S_TextBox txtwrdIn;
    protected S_TextBox txtwrid;

    public HtmlInputHidden HidDettMat => this.hidDettMat;

    public S_TextBox TxtMateriali
    {
      get => this.txtMateriale;
      set => this.txtMateriale = value;
    }

    public S_TextBox Lbldes => this.lbldes;

    public string DescrizioneMateriali
    {
      get => ((TextBox) this.txtMateriale).Text;
      set => ((TextBox) this.txtMateriale).Text = value;
    }

    public string UnitMisura
    {
      get => this.lblunita.Text;
      set => this.lblunita.Text = value;
    }

    public string DettaglioMat
    {
      get => ((TextBox) this.lbldes).Text;
      set => ((TextBox) this.lbldes).Text = value;
    }

    public string idMat
    {
      get => ((TextBox) this.txtid).Text;
      set => ((TextBox) this.txtid).Text = value;
    }

    public string wrId
    {
      get => ((TextBox) this.txtwrid).Text;
      set => ((TextBox) this.txtwrid).Text = value;
    }

    public string wrIdIn
    {
      get => ((TextBox) this.txtwrdIn).Text;
      set => ((TextBox) this.txtwrdIn).Text = value;
    }

    public string PrezzoUnitario
    {
      get => this.lblprezzounitario.Text;
      set => this.lblprezzounitario.Text = value;
    }

    public string Quantita
    {
      get => ((TextBox) this.txtquantita).Text;
      set => ((TextBox) this.txtquantita).Text = value;
    }

    public string Totale
    {
      get => ((TextBox) this.txttotale).Text;
      set => ((TextBox) this.txttotale).Text = value;
    }

    public string Materiale
    {
      get => ((TextBox) this.lbldes).Text;
      set => ((TextBox) this.lbldes).Text = value;
    }

    private void Page_Load(object sender, EventArgs e)
    {
      this.TextRicMat = ((Control) this.txtMateriale).ClientID;
      this.idModuloMat = this.ClientID;
      ((WebControl) this.txtquantita).Attributes.Add("onkeypress", "SoloNumeri();");
      SiteJavaScript.ShowFrameMateriale(this.Page, 1);
      if (((TextBox) this.lbldes).Text != "")
      {
        this.lblprezzounitario.Text = Convert.ToString(((TextBox) this.lbldes).Text.Split(';')[2]);
        this.lblunita.Text = Convert.ToString(((TextBox) this.lbldes).Text.Split(';')[1]);
        this.idMateriale = Convert.ToInt32(((TextBox) this.lbldes).Text.Split(';')[0]);
      }
      ((WebControl) this.txtquantita).Attributes.Add("onkeyup", "calcolaPrezzoTotale('" + this.lblprezzounitario.ClientID + "','" + ((Control) this.txtquantita).ClientID + "','" + ((Control) this.txttotale).ClientID + "');");
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((TextBox) this.txtMateriale).TextChanged += new EventHandler(this.txtMateriale_TextChanged);
      this.imbUpdate.Click += new ImageClickEventHandler(this.imbUpdate_Click);
      this.imbCancel.Click += new ImageClickEventHandler(this.imbCancel_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void txtMateriale_TextChanged(object sender, EventArgs e)
    {
    }

    private void imbCancel_Click(object sender, ImageClickEventArgs e)
    {
    }

    private void imbUpdate_Click(object sender, ImageClickEventArgs e)
    {
      double prezzoUnitario = Convert.ToDouble(this.lblprezzounitario.Text);
      int int32 = Convert.ToInt32(((TextBox) this.txtquantita).Text);
      double prezzoTotale = Convert.ToDouble(((TextBox) this.txttotale).Text);
      if (this.idMat == "")
        this.EseguiDataBaseMateriale(0, ExecuteType.Insert, this.idMateriale, prezzoUnitario, int32, prezzoTotale);
      else
        this.EseguiDataBaseMateriale(Convert.ToInt32(this.idMat), ExecuteType.Update, this.idMateriale, prezzoUnitario, int32, prezzoTotale);
    }

    private int EseguiDataBaseMateriale(
      int id,
      ExecuteType Operazione,
      int idMateriale,
      double prezzoUnitario,
      int quantita,
      double prezzoTotale)
    {
      int num1 = !(Operazione.ToString() == "Insert") ? Convert.ToInt32(((TextBox) this.txtwrid).Text) : Convert.ToInt32(((TextBox) this.txtwrdIn).Text);
      ClManCorrettiva clManCorrettiva = new ClManCorrettiva();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      int num2 = 0;
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_ID");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      S_Object sObject2 = sObject1;
      int num3 = num2;
      int num4 = num3 + 1;
      ((ParameterObject) sObject2).set_Index(num3);
      ((ParameterObject) sObject1).set_Value((object) id);
      CollezioneControlli.Add(sObject1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_WrId");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      S_Object sObject4 = sObject3;
      int num5 = num4;
      int num6 = num5 + 1;
      ((ParameterObject) sObject4).set_Index(num5);
      ((ParameterObject) sObject3).set_Value((object) num1);
      CollezioneControlli.Add(sObject3);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_IdMateriale");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      S_Object sObject6 = sObject5;
      int num7 = num6;
      int num8 = num7 + 1;
      ((ParameterObject) sObject6).set_Index(num7);
      ((ParameterObject) sObject5).set_Value((object) idMateriale);
      CollezioneControlli.Add(sObject5);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_PrezzoUnitario");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      S_Object sObject8 = sObject7;
      int num9 = num8;
      int num10 = num9 + 1;
      ((ParameterObject) sObject8).set_Index(num9);
      ((ParameterObject) sObject7).set_Value((object) prezzoUnitario);
      CollezioneControlli.Add(sObject7);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_Quantita");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      S_Object sObject10 = sObject9;
      int num11 = num10;
      int num12 = num11 + 1;
      ((ParameterObject) sObject10).set_Index(num11);
      ((ParameterObject) sObject9).set_Value((object) quantita);
      CollezioneControlli.Add(sObject9);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_Totale");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      S_Object sObject12 = sObject11;
      int num13 = num12;
      int num14 = num13 + 1;
      ((ParameterObject) sObject12).set_Index(num13);
      ((ParameterObject) sObject11).set_Value((object) prezzoTotale);
      CollezioneControlli.Add(sObject11);
      return clManCorrettiva.ExecuteMateriali(CollezioneControlli, Operazione);
    }
  }
}
