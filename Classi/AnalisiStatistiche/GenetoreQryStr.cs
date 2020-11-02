// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.AnalisiStatistiche.GenetoreQryStr
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System.Collections;
using System.Text;

namespace TheSite.Classi.AnalisiStatistiche
{
  public class GenetoreQryStr
  {
    private Hashtable _HSControl = new Hashtable();

    public void Add(object ControlValue, string key) => this._HSControl.Add((object) key, ControlValue);

    public void Rem(string Key) => this._HSControl.Remove((object) Key);

    public string QryStr(string key) => key + "=" + this._HSControl[(object) key].ToString();

    public string TotQueryString()
    {
      IDictionaryEnumerator enumerator = this._HSControl.GetEnumerator();
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("?");
      while (enumerator.MoveNext())
      {
        stringBuilder.Append(enumerator.Key.ToString());
        stringBuilder.Append("=");
        stringBuilder.Append(enumerator.Value.ToString());
        stringBuilder.Append("&");
      }
      return stringBuilder.ToString();
    }
  }
}
