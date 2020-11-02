// Decompiled with JetBrains decompiler
// Type: MyCollection.clMyCollection
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MyCollection
{
  [Serializable]
  public class clMyCollection
  {
    private ArrayList _myArray = new ArrayList();

    public void AddControl(ControlCollection ControlliWeb, ParentType _myParent)
    {
      foreach (Control control in ControlliWeb)
      {
        clMyControl clMyControl = new clMyControl(_myParent);
        if (control is TextBox)
        {
          clMyControl.Valore = ((TextBox) control).Text;
          clMyControl.NomeControllo = control.ClientID;
          this._myArray.Add((object) clMyControl);
        }
        if (control is HtmlInputHidden)
        {
          clMyControl.Valore = ((HtmlInputControl) control).Value;
          clMyControl.NomeControllo = control.ClientID;
          this._myArray.Add((object) clMyControl);
        }
        if (control is Label)
        {
          clMyControl.Valore = ((Label) control).Text;
          clMyControl.NomeControllo = control.ClientID;
          this._myArray.Add((object) clMyControl);
        }
        if (control is CheckBox)
        {
          clMyControl.Valore = Convert.ToString(((CheckBox) control).Checked);
          clMyControl.NomeControllo = control.ClientID;
          this._myArray.Add((object) clMyControl);
        }
        if (control is ListBox)
        {
          clMyControl.Valore = ((ListControl) control).SelectedValue;
          clMyControl.NomeControllo = control.ClientID;
          this._myArray.Add((object) clMyControl);
        }
        if (control is DropDownList)
        {
          clMyControl.Valore = ((ListControl) control).SelectedValue;
          clMyControl.NomeControllo = control.ClientID;
          this._myArray.Add((object) clMyControl);
        }
        if (control is RadioButton)
        {
          clMyControl.Valore = Convert.ToString(((CheckBox) control).Checked);
          clMyControl.NomeControllo = control.ClientID;
          this._myArray.Add((object) clMyControl);
        }
        if (control.Controls.Count > 0)
          this.AddControl(control.Controls, _myParent);
      }
    }

    public void SetValues(ControlCollection Controlli)
    {
      foreach (Control control in Controlli)
      {
        foreach (clMyControl clMyControl in this._myArray)
        {
          if (clMyControl.NomeControllo == control.ClientID)
          {
            if (control is TextBox)
              ((TextBox) control).Text = clMyControl.Valore;
            if (control is HtmlInputHidden)
              ((HtmlInputControl) control).Value = clMyControl.Valore;
            if (control is Label)
              ((Label) control).Text = clMyControl.Valore;
            if (control is CheckBox)
              ((CheckBox) control).Checked = Convert.ToBoolean(clMyControl.Valore);
            if (control is ListBox)
              ((ListControl) control).SelectedValue = clMyControl.Valore;
            if (control is DropDownList)
              ((ListControl) control).SelectedValue = clMyControl.Valore;
            if (control is RadioButton)
              ((CheckBox) control).Checked = Convert.ToBoolean(clMyControl.Valore);
          }
        }
        if (control.Controls.Count > 0)
          this.SetValues(control.Controls);
      }
    }
  }
}
