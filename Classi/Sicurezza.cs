// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.Sicurezza
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TheSite.Classi
{
  public class Sicurezza
  {
    public string EncryptMD5(string cleanString)
    {
      byte[] bytes = new UnicodeEncoding().GetBytes(cleanString);
      return BitConverter.ToString(((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(bytes));
    }

    public string EncryptSHA1(string cleanString) => this.ToString(new SHA1CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(cleanString)));

    public bool IsInRole(string role) => HttpContext.Current.User.IsInRole(role);

    public bool IsInRoles(string roles)
    {
      HttpContext current = HttpContext.Current;
      string str = roles;
      char[] chArray = new char[1]{ ';' };
      foreach (string role in str.Split(chArray))
      {
        if (role != "" && role != null && current.User.IsInRole(role))
          return true;
      }
      return false;
    }

    private string ToString(byte[] bytes)
    {
      char[] chArray = new char[bytes.Length];
      for (int index = 0; index < bytes.Length; ++index)
      {
        int num = (int) bytes[index];
        chArray[index] = Convert.ToChar(num);
      }
      return new string(chArray);
    }
  }
}
