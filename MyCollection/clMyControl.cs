// Decompiled with JetBrains decompiler
// Type: MyCollection.clMyControl
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;

namespace MyCollection
{
  [Serializable]
  public class clMyControl
  {
    private string _valore;
    private string _NomeControllo;
    public ParentType _parent = ParentType.Page;

    public clMyControl(ParentType myParent) => this._parent = myParent;

    public string Valore
    {
      get => this._valore;
      set => this._valore = value;
    }

    public string NomeControllo
    {
      get => this._NomeControllo;
      set => this._NomeControllo = value;
    }
  }
}
