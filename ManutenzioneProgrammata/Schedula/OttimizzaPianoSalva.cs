// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.Schedula.OttimizzaPianoSalva
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
using TheSite.Classi.ManOrdinaria;
using TheSite.Classi.ManProgrammata;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata.Schedula
{
  public class OttimizzaPianoSalva : Page
  {
    protected Label lblpmp;
    protected TextBox txtAnno;
    protected TextBox txtEQ;
    protected TextBox txtId_bl;
    protected TextBox txtbl_id;
    protected DataGrid DataGridRicerca;
    protected S_Button btSalva;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    private DataSet _MyDs = new DataSet();
    private DataTable DtAddetti;
    protected TextBox txtfiglia;
    protected HtmlInputHidden Hidden1;
    protected TextBox txtOldDD;
    protected TextBox txtOldMM;
    protected TextBox txtOldAddetto;
    protected UserMeseGiorno mmgg;

    private void Page_Load(object sender, EventArgs e)
    {
      this.txtfiglia.Text = "0";
      this.Hidden1.Value = "0";
      if (this.Page.IsPostBack)
        return;
      this.PageTitle1.VisibleLogut = false;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.txtAnno.Text = this.Request.Params["anno"];
      this.txtEQ.Text = this.Request.Params["EQ_ID"];
      this.txtId_bl.Text = this.Request.Params["id_bl"];
      this.txtbl_id.Text = this.Request.Params["bl_id"];
      this.Session.Remove("DatiListP");
      this.PageTitle1.Title = "OTTIMIZZA IL PIANO";
      this.lblpmp.Text = "Piano Manutenzione Programmata Apparecchiatura: " + this.txtEQ.Text + " - Anno: " + this.txtAnno.Text;
      this.DtAddetti = this.BindAddettiDitta(this.txtbl_id.Text, "");
      this.GetDataGrid();
    }

    private void GetDataGrid()
    {
      Planner planner = new Planner();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_EQ_ID");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.txtEQ.Text);
      ((ParameterObject) sObject1).set_Size(50);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Anno");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) this.txtAnno.Text);
      ((ParameterObject) sObject2).set_Size(4);
      CollezioneControlli.Add(sObject2);
      this._MyDs = planner.GetPassiPianoDett(CollezioneControlli).Copy();
      this.DataGridRicerca.DataSource = (object) this._MyDs.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = this._MyDs.Tables[0].Rows.Count.ToString();
    }

    private DataTable BindAddettiDitta(string bl_id, string nomecompleto) => new Richiesta().GetAddetti(nomecompleto, bl_id, 0).Tables[0];

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      DataRowView dataItem = (DataRowView) e.Item.DataItem;
      this.SetControl(true, dataItem, e);
      UserMeseGiorno control1 = (UserMeseGiorno) e.Item.Cells[5].FindControl("UserMeseGiorno1");
      ((WebControl) control1.cmbGiorni).Enabled = false;
      ((WebControl) control1.cmbMesi).Enabled = false;
      DropDownList control2 = (DropDownList) e.Item.Cells[7].Controls[1];
      foreach (DataRow row in (InternalDataCollectionBase) this.DtAddetti.Rows)
        control2.Items.Add(new ListItem(row["nome"].ToString() + " " + row["cognome"].ToString(), row["ID"].ToString()));
      control2.SelectedValue = dataItem.Row["ADDETTO_ID"].ToString();
    }

    private void SetControl(bool visiblecontrol, DataRowView drv, DataGridItemEventArgs e)
    {
      UserMeseGiorno control = (UserMeseGiorno) e.Item.Cells[5].FindControl("UserMeseGiorno1");
      if (!visiblecontrol)
      {
        control.Visible = false;
      }
      else
      {
        string str1 = "ImpostaGiorni(this.value,'" + ((Control) control.cmbGiorni).ClientID + "')";
        ((WebControl) control.cmbMesi).Attributes.Add("onchange", str1);
        if (drv.Row["DATA"].ToString() != "")
        {
          DateTime dateTime = Convert.ToDateTime(drv.Row["DATA"].ToString());
          int num = dateTime.Month;
          string mese = num.ToString();
          num = dateTime.Day;
          string str2 = num.ToString();
          ((ListControl) control.cmbMesi).SelectedValue = mese;
          this.ImpostaGiorni(mese, control.cmbGiorni);
          ((ListControl) control.cmbGiorni).SelectedValue = str2;
        }
        else
          this.ImpostaGiorni(((ListControl) control.cmbMesi).SelectedValue, control.cmbGiorni);
      }
    }

    private void ImpostaGiorni(string mese, S_ComboBox Giorni)
    {
      int num;
      switch (mese)
      {
        case "4":
        case "6":
        case "9":
        case "11":
          num = 30;
          break;
        case "2":
          num = 28;
          break;
        default:
          num = 31;
          break;
      }
      ((ListControl) Giorni).Items.Clear();
      for (int index = 1; index <= num; ++index)
      {
        ListItem listItem = new ListItem(index.ToString(), index.ToString());
        ((ListControl) Giorni).Items.Add(listItem);
      }
    }

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (e.CommandName == "Dettaglio")
      {
        foreach (DataGridItem dataGridItem in this.DataGridRicerca.Items)
        {
          dataGridItem.Cells[0].Controls[0].FindControl("lnkDett").Visible = false;
          this.DataGridRicerca.Columns[1].Visible = true;
          dataGridItem.Cells[1].Controls[0].FindControl("lnkAnn").Visible = false;
          UserMeseGiorno control = (UserMeseGiorno) e.Item.Cells[5].FindControl("UserMeseGiorno1");
          ((WebControl) control.cmbGiorni).Enabled = true;
          ((WebControl) control.cmbMesi).Enabled = true;
          this.txtOldDD.Text = ((ListControl) control.cmbGiorni).SelectedValue;
          this.txtOldMM.Text = ((ListControl) control.cmbMesi).SelectedValue;
        }
        ImageButton control1 = (ImageButton) e.Item.Cells[0].Controls[0].FindControl("lnkAnn");
        control1.Visible = true;
        control1.ImageUrl = "../../images/annulla.gif";
        ImageButton control2 = (ImageButton) e.Item.Cells[0].Controls[0].FindControl("lnkDett");
        control2.Visible = true;
        control2.ImageUrl = "../../images/salva.gif";
        control2.CommandName = "Aggiorna";
        DropDownList control3 = (DropDownList) e.Item.Cells[7].Controls[0].FindControl("cmdAddetto");
        control3.Enabled = true;
        this.txtOldAddetto.Text = control3.SelectedValue;
      }
      else if (e.CommandName == "Aggiorna")
      {
        foreach (TableRow tableRow in this.DataGridRicerca.Items)
        {
          tableRow.Cells[0].Controls[0].FindControl("lnkDett").Visible = true;
          UserMeseGiorno control = (UserMeseGiorno) e.Item.Cells[5].FindControl("UserMeseGiorno1");
          ((WebControl) control.cmbGiorni).Enabled = false;
          ((WebControl) control.cmbMesi).Enabled = false;
        }
        this.DataGridRicerca.Columns[1].Visible = false;
        DropDownList control1 = (DropDownList) e.Item.Cells[7].Controls[0].FindControl("cmdAddetto");
        control1.Enabled = false;
        ImageButton control2 = (ImageButton) e.Item.Cells[0].Controls[0].FindControl("lnkDett");
        control2.ImageUrl = "../../images/edit.gif";
        control2.CommandName = "Dettaglio";
        UserMeseGiorno control3 = (UserMeseGiorno) e.Item.Cells[5].FindControl("UserMeseGiorno1");
        string text1 = e.Item.Cells[6].Text;
        string selectedValue = control1.SelectedValue;
        string data = ((ListControl) control3.cmbGiorni).SelectedValue + "/" + ((ListControl) control3.cmbMesi).SelectedValue + "/" + this.txtAnno.Text;
        string text2 = this.txtId_bl.Text;
        string text3 = this.txtAnno.Text;
        string text4 = this.txtEQ.Text;
        this.txtOldDD.Text = "";
        this.txtOldMM.Text = "";
        this.txtOldAddetto.Text = "";
        this.Ottimizza(text1, selectedValue, data, text2, text3, text4);
      }
      else
      {
        foreach (TableRow tableRow in this.DataGridRicerca.Items)
        {
          tableRow.Cells[0].Controls[0].FindControl("lnkDett").Visible = true;
          UserMeseGiorno control = (UserMeseGiorno) e.Item.Cells[5].FindControl("UserMeseGiorno1");
          ((WebControl) control.cmbGiorni).Enabled = false;
          ((WebControl) control.cmbMesi).Enabled = false;
          ((ListControl) control.cmbMesi).SelectedValue = this.txtOldMM.Text;
          ((ListControl) control.cmbGiorni).SelectedValue = this.txtOldDD.Text;
        }
        this.DataGridRicerca.Columns[1].Visible = false;
        DropDownList control1 = (DropDownList) e.Item.Cells[7].Controls[0].FindControl("cmdAddetto");
        control1.Enabled = false;
        control1.SelectedValue = this.txtOldAddetto.Text;
        ImageButton control2 = (ImageButton) e.Item.Cells[0].Controls[0].FindControl("lnkDett");
        control2.ImageUrl = "../../images/edit.gif";
        control2.CommandName = "Dettaglio";
      }
    }

    private int Ottimizza(
      string pmsd,
      string addetto,
      string data,
      string edificio,
      string anno,
      string apparecchiatura)
    {
      TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP creaOttimizzaRdlMp = new TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP();
      try
      {
        creaOttimizzaRdlMp.beginTransaction();
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_anno");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) Convert.ToInt32(anno));
        CollezioneControlli.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_data");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Value((object) data);
        CollezioneControlli.Add(sObject2);
        S_Object sObject3 = new S_Object();
        ((ParameterObject) sObject3).set_ParameterName("p_addetto");
        ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject3).set_Index(2);
        ((ParameterObject) sObject3).set_Value((object) Convert.ToInt32(addetto));
        CollezioneControlli.Add(sObject3);
        S_Object sObject4 = new S_Object();
        ((ParameterObject) sObject4).set_ParameterName("p_edificio");
        ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject4).set_Index(3);
        ((ParameterObject) sObject4).set_Value((object) Convert.ToInt32(edificio));
        CollezioneControlli.Add(sObject4);
        S_Object sObject5 = new S_Object();
        ((ParameterObject) sObject5).set_ParameterName("p_eq");
        ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject5).set_Index(4);
        ((ParameterObject) sObject5).set_Value((object) apparecchiatura);
        CollezioneControlli.Add(sObject5);
        S_Object sObject6 = new S_Object();
        ((ParameterObject) sObject6).set_ParameterName("p_pmsd");
        ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject6).set_Index(5);
        ((ParameterObject) sObject6).set_Value((object) Convert.ToInt32(pmsd));
        CollezioneControlli.Add(sObject6);
        int num = creaOttimizzaRdlMp.Update(CollezioneControlli, 0);
        creaOttimizzaRdlMp.commitTransaction();
        string empty = string.Empty;
        SiteJavaScript.msgBox(this.Page, "Aggiornamento effettuato con successo.");
        string url = "OttimizzaPianoEQ.aspx?ID_BL=" + edificio + "&anno=" + anno + "&servizio=" + (object) num + "&p=ottimizza";
        this.txtfiglia.Text = "1";
        this.Hidden1.Value = "1";
        SiteJavaScript.OpenerReload(this.Page, url);
      }
      catch (Exception ex)
      {
        creaOttimizzaRdlMp.rollbackTransaction();
        Console.WriteLine(ex.Message);
        string empty = string.Empty;
        SiteJavaScript.msgBox(this.Page, "Si è verificato un errore durante l'aggiornamento del Piano di Lavoro.");
      }
      return 0;
    }
  }
}
