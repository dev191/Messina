// Decompiled with JetBrains decompiler
// Type: GIC.App_Code.Util
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System.Text.RegularExpressions;
using System.Web;

namespace GIC.App_Code
{
  public class Util
  {
    private Util()
    {
    }

    public static string RemoveHTML(string text)
    {
      text = HttpUtility.HtmlDecode(text);
      return Regex.Replace(text, "<(.|\\n)*?>", string.Empty);
    }

    public static string Truncate(string input, int characterLimit)
    {
      string str1 = input;
      if (str1.Length > characterLimit && characterLimit > 0)
      {
        string str2 = str1.Substring(0, characterLimit);
        if (input.Substring(str2.Length, 1) != " ")
        {
          int length = str2.LastIndexOf(" ");
          if (length != -1)
            str2 = str2.Substring(0, length);
        }
        str1 = str2 + "...";
      }
      return str1;
    }

    public static string Truncate(object input, int characterLimit) => Util.Truncate(input.ToString(), characterLimit);

    public static bool CheckString(string stringa, string delimitatore) => stringa.StartsWith(delimitatore) && stringa.EndsWith(delimitatore);
  }
}
