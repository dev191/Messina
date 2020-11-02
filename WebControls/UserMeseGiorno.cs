// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.UserMeseGiorno
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Web.UI;

namespace TheSite.WebControls
{
  public class UserMeseGiorno : UserControl
  {
    protected S_ComboBox cmbsMesi;
    protected S_ComboBox cmbsGiorni;

    public S_ComboBox cmbMesi
    {
      get => this.cmbsMesi;
      set => this.cmbsMesi = value;
    }

    public S_ComboBox cmbGiorni
    {
      get => this.cmbsGiorni;
      set => this.cmbsGiorni = value;
    }

    private void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
