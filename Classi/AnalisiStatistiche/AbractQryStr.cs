// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.AnalisiStatistiche.AbractQryStr
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

namespace TheSite.Classi.AnalisiStatistiche
{
  public abstract class AbractQryStr
  {
    public abstract void AddCntr(object Control, string key);

    public abstract void RemCntr(string Key);

    public abstract string Name(string key);

    public abstract string Stato(string key);

    public abstract string QryStr(string key);

    public abstract string TotQueryString();
  }
}
