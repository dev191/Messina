// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.TipoManutenzione
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using MyCollection;
using System;
using System.Web.UI;

namespace TheSite.Gestione
{
  public class TipoManutenzione : Page
  {
    protected RicercaAnagrafica1 RicercaAnagrafica1;
    private clMyCollection _myColl = new clMyCollection();
    private EditAnagrafica _fp = (EditAnagrafica) null;

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      this.RicercaAnagrafica1.Pagina = PageType.TipoManutenzione;
      this.RicercaAnagrafica1.Coll = this._myColl;
      if (this.Page.IsPostBack || !(this.Context.Handler is EditAnagrafica))
        return;
      this._fp = (EditAnagrafica) this.Context.Handler;
      if (this._fp == null)
        return;
      this._myColl = this._fp._Contenitore;
      this._myColl.SetValues(this.Page.Controls);
      this.RicercaAnagrafica1.Ricerca();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
