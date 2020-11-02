// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.Helper
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System.Web;

namespace TheSite.Classi
{
  public class Helper
  {
    public static string GetApplicationName()
    {
      string str = "Cofely Italia s.p.a.";
      if (HttpContext.Current.User.IsInRole("MA") && !HttpContext.Current.User.IsInRole("PA"))
        str = "Martino";
      if (!HttpContext.Current.User.IsInRole("MA") && HttpContext.Current.User.IsInRole("PA"))
        str = "Papardo";
      return str;
    }
  }
}
