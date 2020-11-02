// Decompiled with JetBrains decompiler
// Type: TheSite.Eccezioni.NoDataForReportFoundException
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;

namespace TheSite.Eccezioni
{
  public class NoDataForReportFoundException : Exception
  {
    public string Message;

    public NoDataForReportFoundException() => this.Message = "La ricerca effettuata non ha prodotto dati";
  }
}
