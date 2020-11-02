// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditPianoFerie
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
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class EditPianoFerie : Page
  {
    protected Label lblOperazione;
    protected Label lblFirstAndLast;
    protected DataGrid DataGridEsegui;
    protected Label lblRecord;
    protected LinkButton lkbNuovo;
    private int FunId = 0;
    protected MessagePanel PanelMess;
    protected Label lblMessaggi;
    protected PageTitle PageTitle1;
    protected Button btnAnnulla;
    protected Button btnsAnnulla;
    protected Label Label1;
    protected S_TextBox txtsNome;
    protected S_TextBox txtsCognome;
    protected Panel PanelEdit;
    private Addetti _fp;
    private int itemId = 0;

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      this.lblMessaggi.Text = "";
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      DataSet dataSet = new DataSet();
      TheSite.Classi.ClassiAnagrafiche.Addetti addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
      DataSet singleData = addetti.GetSingleData(this.itemId);
      if (singleData.Tables[0].Rows.Count == 1)
      {
        DataRow row = singleData.Tables[0].Rows[0];
        ((TextBox) this.txtsCognome).Text = (string) row["COGNOME"];
        if (row["NOME"] != DBNull.Value)
          ((TextBox) this.txtsNome).Text = (string) row["NOME"];
        this.lblOperazione.Text = "Piano Ferie Addetto: " + ((TextBox) this.txtsCognome).Text + " " + ((TextBox) this.txtsNome).Text;
        this.lblFirstAndLast.Visible = true;
        this.lblFirstAndLast.Text = addetti.GetFirstAndLastUser(row);
        this.BindDataGrid();
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Addetti))
        return;
      this._fp = (Addetti) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    private void BindDataGrid()
    {
      DataSet data = new TheSite.Classi.ClassiAnagrafiche.PianoFerie().GetData(this.itemId);
      this.DataGridEsegui.DataSource = (object) data;
      this.DataGridEsegui.DataBind();
      this.lblRecord.Text = data.Tables[0].Rows.Count.ToString();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.lkbNuovo.Click += new EventHandler(this.lkbNuovo_Click);
      this.DataGridEsegui.ItemDataBound += new DataGridItemEventHandler(this.DataGridEsegui_ItemDataBound);
      this.btnsAnnulla.Click += new EventHandler(this.btnsAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Response.Redirect((string) this.ViewState["UrlReferrer"]);

    private void lkbNuovo_Click(object sender, EventArgs e)
    {
      this.DataGridEsegui.ShowFooter = true;
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindDataGrid();
    }

    private void btnsAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Addetti.aspx");

    public DataSet loadMotivoAssenza() => new Motivo_assenza().GetAllData().Copy();

    public int GetPianoFerieID(object ID) => int.Parse(((DataRowView) ID)["ID_MOTIVO"].ToString());

    protected void jskDataGrid_Edit(object sender, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.ShowFooter = false;
      this.DataGridEsegui.EditItemIndex = e.Item.ItemIndex;
      this.BindDataGrid();
    }

    protected void jskDataGrid_Cancel(object sender, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.ShowFooter = false;
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindDataGrid();
    }

    protected void jskDataGrid_Delete(object sender, DataGridCommandEventArgs e)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_idAddetto");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.itemId);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_idMotivo");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) 0);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_dataStart");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Value((object) string.Empty);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_dataEnd");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(10);
      ((ParameterObject) sObject4).set_Value((object) string.Empty);
      CollezioneControlli.Add(sObject1);
      CollezioneControlli.Add(sObject2);
      CollezioneControlli.Add(sObject3);
      CollezioneControlli.Add(sObject4);
      new TheSite.Classi.ClassiAnagrafiche.PianoFerie().Delete(CollezioneControlli, int.Parse(e.Item.Cells[1].Text));
      this.DataGridEsegui.ShowFooter = false;
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindDataGrid();
    }

    protected void jskDataGrid_Update(object sender, DataGridCommandEventArgs e)
    {
      try
      {
        string text1;
        string text2;
        string text3;
        string text4;
        string text5;
        string text6;
        string selectedValue;
        if (this.DataGridEsegui.ShowFooter)
        {
          text1 = ((TextBox) e.Item.FindControl("TxtOraStartN")).Text;
          text2 = ((TextBox) e.Item.FindControl("TxtMinStartN")).Text;
          text3 = ((TextBox) ((CalendarPicker) e.Item.FindControl("Calendar_DataStartNew")).Datazione).Text;
          text4 = ((TextBox) e.Item.FindControl("TxtOraEndN")).Text;
          text5 = ((TextBox) e.Item.FindControl("TxtMinEndN")).Text;
          text6 = ((TextBox) ((CalendarPicker) e.Item.FindControl("Calendar_DataEndNew")).Datazione).Text;
          selectedValue = ((ListControl) e.Item.FindControl("cmbsMotivo_New")).SelectedValue;
        }
        else
        {
          text1 = ((TextBox) e.Item.FindControl("TxtOraStartE")).Text;
          text2 = ((TextBox) e.Item.FindControl("TxtMinStartE")).Text;
          text3 = ((TextBox) ((CalendarPicker) e.Item.FindControl("Calendar_DataStartEdit")).Datazione).Text;
          text4 = ((TextBox) e.Item.FindControl("TxtOraEndE")).Text;
          text5 = ((TextBox) e.Item.FindControl("TxtMinEndE")).Text;
          text6 = ((TextBox) ((CalendarPicker) e.Item.FindControl("Calendar_DataEndEdit")).Datazione).Text;
          selectedValue = ((ListControl) e.Item.FindControl("cmbsMotivo_Edit")).SelectedValue;
        }
        if (text3 == "" || text6 == "")
        {
          this.lblMessaggi.Text = "La data di inizio o la data di fine deve essere valorizzata";
        }
        else
        {
          DateTime dateTime1 = Convert.ToDateTime(text3);
          string str1 = dateTime1.ToShortDateString() + " " + text1 + ":" + text2;
          string str2 = dateTime1.Year.ToString() + dateTime1.Month.ToString().PadLeft(2, '0') + dateTime1.Day.ToString().PadLeft(2, '0') + text1.ToString().PadLeft(2, '0') + text2.ToString().PadLeft(2, '0');
          DateTime dateTime2 = Convert.ToDateTime(text6);
          string str3 = dateTime2.ToShortDateString() + " " + text4 + ":" + text5;
          string str4 = dateTime2.Year.ToString() + dateTime2.Month.ToString().PadLeft(2, '0') + dateTime2.Day.ToString().PadLeft(2, '0') + text4.ToString().PadLeft(2, '0') + text5.ToString().PadLeft(2, '0');
          if (Convert.ToInt64(str2) >= Convert.ToInt64(str4))
          {
            this.lblMessaggi.Text = "La data di fine deve essere superiore alla data di inizio";
          }
          else
          {
            S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
            S_Object sObject1 = new S_Object();
            ((ParameterObject) sObject1).set_ParameterName("p_idAddetto");
            ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject1).set_Index(0);
            ((ParameterObject) sObject1).set_Value((object) this.itemId);
            S_Object sObject2 = new S_Object();
            ((ParameterObject) sObject2).set_ParameterName("p_idMotivo");
            ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject2).set_Index(1);
            ((ParameterObject) sObject2).set_Value((object) int.Parse(selectedValue));
            S_Object sObject3 = new S_Object();
            ((ParameterObject) sObject3).set_ParameterName("p_dataStart");
            ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
            ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject3).set_Index(2);
            ((ParameterObject) sObject3).set_Value((object) str1);
            S_Object sObject4 = new S_Object();
            ((ParameterObject) sObject4).set_ParameterName("p_dataEnd");
            ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
            ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject4).set_Index(3);
            ((ParameterObject) sObject4).set_Value((object) str3);
            CollezioneControlli.Add(sObject1);
            CollezioneControlli.Add(sObject2);
            CollezioneControlli.Add(sObject3);
            CollezioneControlli.Add(sObject4);
            TheSite.Classi.ClassiAnagrafiche.PianoFerie pianoFerie = new TheSite.Classi.ClassiAnagrafiche.PianoFerie();
            if (this.DataGridEsegui.ShowFooter)
              pianoFerie.Add(CollezioneControlli);
            else
              pianoFerie.Update(CollezioneControlli, int.Parse(e.Item.Cells[1].Text));
            this.DataGridEsegui.ShowFooter = false;
            this.DataGridEsegui.EditItemIndex = -1;
            this.BindDataGrid();
          }
        }
      }
      catch (Exception ex)
      {
        this.lblMessaggi.Text = ex.Message;
      }
    }

    private void DataGridEsegui_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Footer)
      {
        TextBox control1 = (TextBox) e.Item.FindControl("TxtOraStartN");
        TextBox control2 = (TextBox) e.Item.FindControl("TxtMinStartN");
        CalendarPicker control3 = (CalendarPicker) e.Item.FindControl("Calendar_DataStartNew");
        TextBox control4 = (TextBox) e.Item.FindControl("TxtOraEndN");
        TextBox control5 = (TextBox) e.Item.FindControl("TxtMinEndN");
        CalendarPicker control6 = (CalendarPicker) e.Item.FindControl("Calendar_DataEndNew");
        control4.Attributes.Add("onpaste", "return nonpaste();");
        control4.Attributes.Add("onblur", "Formatta('" + control4.ClientID + "');");
        control4.Attributes.Add("maxlength", "2");
        control4.Attributes.Add("onkeypress", "SoloNumeri();");
        control5.Attributes.Add("onpaste", "return nonpaste();");
        control5.Attributes.Add("onblur", "Formatta('" + control5.ClientID + "');");
        control5.Attributes.Add("maxlength", "2");
        control5.Attributes.Add("onkeypress", "SoloNumeri();");
        control1.Attributes.Add("onpaste", "return nonpaste();");
        control1.Attributes.Add("onblur", "Formatta('" + control1.ClientID + "');");
        control1.Attributes.Add("maxlength", "2");
        control1.Attributes.Add("onkeypress", "SoloNumeri();");
        control2.Attributes.Add("onpaste", "return nonpaste();");
        control2.Attributes.Add("onblur", "Formatta('" + control2.ClientID + "');");
        control2.Attributes.Add("maxlength", "2");
        control2.Attributes.Add("onkeypress", "SoloNumeri();");
        ((WebControl) e.Item.FindControl("Imagebutton1")).Attributes.Add("onclick", "return Controlla('" + control1.ClientID + "','" + control2.ClientID + "','" + control4.ClientID + "','" + control5.ClientID + "');");
      }
      if (e.Item.ItemType != ListItemType.EditItem)
        return;
      TextBox control7 = (TextBox) e.Item.FindControl("TxtOraStartE");
      TextBox control8 = (TextBox) e.Item.FindControl("TxtMinStartE");
      CalendarPicker control9 = (CalendarPicker) e.Item.FindControl("Calendar_DataStartEdit");
      TextBox control10 = (TextBox) e.Item.FindControl("TxtOraEndE");
      TextBox control11 = (TextBox) e.Item.FindControl("TxtMinEndE");
      CalendarPicker control12 = (CalendarPicker) e.Item.FindControl("Calendar_DataEndEdit");
      control10.Attributes.Add("onpaste", "return nonpaste();");
      control10.Attributes.Add("onblur", "Formatta('" + control10.ClientID + "');");
      control10.Attributes.Add("maxlength", "2");
      control10.Attributes.Add("onkeypress", "SoloNumeri();");
      control11.Attributes.Add("onpaste", "return nonpaste();");
      control11.Attributes.Add("onblur", "Formatta('" + control11.ClientID + "');");
      control11.Attributes.Add("maxlength", "2");
      control11.Attributes.Add("onkeypress", "SoloNumeri();");
      control7.Attributes.Add("onpaste", "return nonpaste();");
      control7.Attributes.Add("onblur", "Formatta('" + control7.ClientID + "');");
      control7.Attributes.Add("maxlength", "2");
      control7.Attributes.Add("onkeypress", "SoloNumeri();");
      control8.Attributes.Add("onpaste", "return nonpaste();");
      control8.Attributes.Add("onblur", "Formatta('" + control8.ClientID + "');");
      control8.Attributes.Add("maxlength", "2");
      control8.Attributes.Add("onkeypress", "SoloNumeri();");
      ((WebControl) e.Item.FindControl("ImbUpdate")).Attributes.Add("onclick", "return Controlla('" + control7.ClientID + "','" + control8.ClientID + "','" + control10.ClientID + "','" + control11.ClientID + "');");
    }
  }
}
