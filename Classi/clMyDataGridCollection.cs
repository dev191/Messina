// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.clMyDataGridCollection
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TheSite.Classi
{
  public class clMyDataGridCollection
  {
    public Hashtable SetControl(DataGrid _MyGrid, Hashtable _HS, int pagina)
    {
      foreach (DataGridItem dataGridItem in _MyGrid.Items)
      {
        for (int index = 0; index < dataGridItem.Cells.Count; ++index)
          this.SetVal(dataGridItem.Cells[index].Controls, _HS, pagina);
      }
      return _HS;
    }

    public void GetControl(DataGrid _MyGrid, Hashtable _HS, int pagina)
    {
      foreach (DataGridItem dataGridItem in _MyGrid.Items)
      {
        for (int index = 0; index < dataGridItem.Cells.Count; ++index)
          this.GetVal(dataGridItem.Cells[index].Controls, _HS, pagina);
      }
    }

    private void SetVal(ControlCollection ControlliWeb, Hashtable _HS, int pagina)
    {
      clMyDataGridCollection.clMyControl clMyControl = new clMyDataGridCollection.clMyControl();
      foreach (Control control in ControlliWeb)
      {
        if (control is TextBox)
        {
          clMyControl.Valore = ((TextBox) control).Text;
          clMyControl.NomeControllo = control.ClientID + pagina.ToString();
          string nomeControllo = clMyControl.NomeControllo;
          if (_HS.ContainsKey((object) nomeControllo))
            _HS.Remove((object) nomeControllo);
          _HS.Add((object) nomeControllo, (object) clMyControl.Valore);
        }
        if (control is HtmlInputHidden)
        {
          clMyControl.Valore = ((HtmlInputControl) control).Value;
          clMyControl.NomeControllo = control.ClientID + pagina.ToString();
          string nomeControllo = clMyControl.NomeControllo;
          if (_HS.ContainsKey((object) nomeControllo))
            _HS.Remove((object) nomeControllo);
          _HS.Add((object) nomeControllo, (object) clMyControl.Valore);
        }
        if (control is Label)
        {
          clMyControl.Valore = ((Label) control).Text;
          clMyControl.NomeControllo = control.ClientID + pagina.ToString();
          string nomeControllo = clMyControl.NomeControllo;
          if (_HS.ContainsKey((object) nomeControllo))
            _HS.Remove((object) nomeControllo);
          _HS.Add((object) nomeControllo, (object) clMyControl.Valore);
        }
        if (control is CheckBox)
        {
          clMyControl.Valore = Convert.ToString(((CheckBox) control).Checked);
          clMyControl.NomeControllo = control.ClientID + pagina.ToString();
          string nomeControllo = clMyControl.NomeControllo;
          if (_HS.ContainsKey((object) nomeControllo))
            _HS.Remove((object) nomeControllo);
          _HS.Add((object) nomeControllo, (object) clMyControl.Valore);
        }
        if (control is ListBox)
        {
          clMyControl.Valore = ((ListControl) control).SelectedValue;
          clMyControl.NomeControllo = control.ClientID + pagina.ToString();
          string nomeControllo = clMyControl.NomeControllo;
          if (_HS.ContainsKey((object) nomeControllo))
            _HS.Remove((object) nomeControllo);
          _HS.Add((object) nomeControllo, (object) clMyControl.Valore);
        }
        if (control is DropDownList)
        {
          clMyControl.Valore = ((ListControl) control).SelectedValue;
          clMyControl.NomeControllo = control.ClientID + pagina.ToString();
          string nomeControllo = clMyControl.NomeControllo;
          if (_HS.ContainsKey((object) nomeControllo))
            _HS.Remove((object) nomeControllo);
          _HS.Add((object) nomeControllo, (object) clMyControl.Valore);
        }
        if (control is RadioButton)
        {
          clMyControl.Valore = Convert.ToString(((CheckBox) control).Checked);
          clMyControl.NomeControllo = control.ClientID + pagina.ToString();
          string nomeControllo = clMyControl.NomeControllo;
          if (_HS.ContainsKey((object) nomeControllo))
            _HS.Remove((object) nomeControllo);
          _HS.Add((object) nomeControllo, (object) clMyControl.Valore);
        }
        if (control.Controls.Count > 0)
          this.SetVal(control.Controls, _HS, pagina);
      }
    }

    private void GetVal(ControlCollection ControlliWeb, Hashtable _HS, int pagina)
    {
      string empty = string.Empty;
      foreach (Control control in ControlliWeb)
      {
        if (control is TextBox)
        {
          string str = control.ClientID + pagina.ToString();
          if (_HS.ContainsKey((object) str))
            ((TextBox) control).Text = _HS[(object) str].ToString();
        }
        if (control is HtmlInputHidden)
        {
          string str = control.ClientID + pagina.ToString();
          if (_HS.ContainsKey((object) str))
            ((HtmlInputControl) control).Value = _HS[(object) str].ToString();
        }
        if (control is Label)
        {
          string str = control.ClientID + pagina.ToString();
          if (_HS.ContainsKey((object) str))
            ((Label) control).Text = _HS[(object) str].ToString();
        }
        if (control is CheckBox)
        {
          string str = control.ClientID + pagina.ToString();
          if (_HS.ContainsKey((object) str))
            ((CheckBox) control).Checked = bool.Parse(_HS[(object) str].ToString());
        }
        if (control is ListBox)
        {
          string str = control.ClientID + pagina.ToString();
          if (_HS.ContainsKey((object) str))
            ((ListControl) control).SelectedValue = _HS[(object) str].ToString();
        }
        if (control is DropDownList)
        {
          string str = control.ClientID + pagina.ToString();
          if (_HS.ContainsKey((object) str))
            ((ListControl) control).SelectedValue = _HS[(object) str].ToString();
        }
        if (control is RadioButton)
        {
          string str = control.ClientID + pagina.ToString();
          if (_HS.ContainsKey((object) str))
            ((CheckBox) control).Checked = bool.Parse(_HS[(object) str].ToString());
        }
        if (control.Controls.Count > 0)
          this.GetVal(control.Controls, _HS, pagina);
      }
    }

    //public class clMyControl
    //{
    //  private string _valore;
    //  private string _NomeControllo;

    //  public string Valore
    //  {
    //    get => this._valore;
    //    set => this._valore = value;
    //  }

    //  public string NomeControllo
    //  {
    //    get => this._NomeControllo;
    //    set => this._NomeControllo = value;
    //  }
    //}
  }
}
