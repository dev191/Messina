// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.CostiAddetti
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.CostiOperativi;

namespace TheSite.WebControls
{
  public class CostiAddetti : UserControl
  {
    protected DataGrid DataGridEsegui;
    public static int FunId = 0;
    private int wr_id = 0;
    protected LinkButton lkbNuovo;
    protected Label lblRecord;
    protected Label lblTot1;
    private int addetto_id = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Request["FunId"] != null)
        CostiAddetti.FunId = int.Parse(this.Request["FunId"].ToString());
      if (this.Request["wr_id"] != null)
        this.wr_id = Convert.ToInt32(this.Request.Params["wr_id"]);
      if (this.Request["addetto_id"] != null)
        this.addetto_id = Convert.ToInt32(this.Request.Params["addetto_id"]);
      this.wr_id = 79;
      this.BindGrid();
    }

    public DataTable GetAddetti() => new CostoAddetti().GetAddetti().Tables[0];

    private void BindGrid()
    {
      DataSet dataSet = new CostoAddetti().GetSingleData(this.wr_id).Copy();
      this.DataGridEsegui.DataSource = (object) dataSet.Tables[0];
      this.DataGridEsegui.DataBind();
      this.lblRecord.Text = dataSet.Tables[0].Rows.Count.ToString();
      this.DataGridEsegui.ShowFooter = false;
    }

    private void DataGridEsegui_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      Buildings buildings = new Buildings();
      int num = 0;
      switch (((ImageButton) e.CommandSource).CommandName)
      {
        case "Insert":
          S_ComboBox control1 = (S_ComboBox) e.Item.FindControl("cmbaddettoNew");
          S_TextBox control2 = (S_TextBox) e.Item.FindControl("txtdescrizioneNew");
          S_TextBox control3 = (S_TextBox) e.Item.FindControl("txtOreLavorateNew");
          try
          {
            if (num > 0)
            {
              this.DataGridEsegui.EditItemIndex = -1;
              this.BindGrid();
              this.DataGridEsegui.Columns[1].Visible = true;
              this.DataGridEsegui.Columns[2].Visible = false;
              this.DataGridEsegui.Columns[3].Visible = false;
              break;
            }
            this.DataGridEsegui.Columns[1].Visible = false;
            this.DataGridEsegui.Columns[2].Visible = false;
            this.DataGridEsegui.Columns[3].Visible = true;
            break;
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
            break;
          }
        case "Delete":
          S_ComboBox control4 = (S_ComboBox) e.Item.FindControl("cmbaddettoNew");
          S_TextBox control5 = (S_TextBox) e.Item.FindControl("txtdescrizioneNew");
          S_TextBox control6 = (S_TextBox) e.Item.FindControl("txtOreLavorateNew");
          int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString());
          try
          {
            if (num > 0)
            {
              this.DataGridEsegui.EditItemIndex = -1;
              this.BindGrid();
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
          this.DataGridEsegui.Columns[1].Visible = true;
          this.DataGridEsegui.Columns[2].Visible = false;
          this.DataGridEsegui.Columns[3].Visible = false;
          break;
      }
    }

    private void DataGridEsegui_CancelCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindGrid();
      this.DataGridEsegui.Columns[1].Visible = true;
      this.DataGridEsegui.Columns[2].Visible = false;
      this.DataGridEsegui.Columns[3].Visible = false;
    }

    private void DataGridEsegui_EditCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.EditItemIndex = e.Item.ItemIndex;
      this.BindGrid();
      this.DataGridEsegui.Columns[1].Visible = false;
      this.DataGridEsegui.Columns[2].Visible = true;
      this.DataGridEsegui.Columns[3].Visible = false;
    }

    private void DataGridEsegui_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Footer)
        return;
      S_ComboBox control1 = (S_ComboBox) e.Item.FindControl("cmbaddettoNew");
      S_TextBox control2 = (S_TextBox) e.Item.FindControl("txtdescrizioneNew");
      S_TextBox control3 = (S_TextBox) e.Item.FindControl("txtOreLavorateNew");
      S_Label control4 = (S_Label) e.Item.FindControl("lbllivelloNew");
      S_Label control5 = (S_Label) e.Item.FindControl("lblPrezzoUnitatioNew");
      ((WebControl) control1).Attributes.Add("onchange", "addetto('" + ((Control) control1).ClientID + "','" + ((Control) control4).ClientID + "','" + ((Control) control5).ClientID + "');");
    }

    private void DataGridEsegui_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
      int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString());
      S_ComboBox control1 = (S_ComboBox) e.Item.FindControl("cmbaddettoNew");
      S_TextBox control2 = (S_TextBox) e.Item.FindControl("txtdescrizioneNew");
      S_TextBox control3 = (S_TextBox) e.Item.FindControl("txtOreLavorateNew");
      Buildings buildings = new Buildings();
      int num = 0;
      try
      {
        if (num > 0)
        {
          this.DataGridEsegui.EditItemIndex = -1;
          this.BindGrid();
          this.DataGridEsegui.Columns[1].Visible = true;
          this.DataGridEsegui.Columns[2].Visible = false;
          this.DataGridEsegui.Columns[3].Visible = false;
        }
        else
        {
          this.DataGridEsegui.Columns[1].Visible = false;
          this.DataGridEsegui.Columns[2].Visible = true;
          this.DataGridEsegui.Columns[3].Visible = false;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.lkbNuovo.Click += new EventHandler(this.lkbNuovo_Click);
      this.DataGridEsegui.ItemCommand += new DataGridCommandEventHandler(this.DataGridEsegui_ItemCommand);
      this.DataGridEsegui.CancelCommand += new DataGridCommandEventHandler(this.DataGridEsegui_CancelCommand);
      this.DataGridEsegui.EditCommand += new DataGridCommandEventHandler(this.DataGridEsegui_EditCommand);
      this.DataGridEsegui.UpdateCommand += new DataGridCommandEventHandler(this.DataGridEsegui_UpdateCommand);
      this.DataGridEsegui.ItemDataBound += new DataGridItemEventHandler(this.DataGridEsegui_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void lkbNuovo_Click(object sender, EventArgs e)
    {
      this.DataGridEsegui.ShowFooter = true;
      this.DataGridEsegui.Columns[1].Visible = false;
      this.DataGridEsegui.Columns[2].Visible = false;
      this.DataGridEsegui.Columns[3].Visible = true;
    }
  }
}
