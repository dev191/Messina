// Decompiled with JetBrains decompiler
// Type: TheSite.Report.CachedRptMpDettagliLocaliLungoDinamico
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System;
using System.ComponentModel;
using System.Drawing;

namespace TheSite.Report
{
  [ToolboxBitmap(typeof (ExportOptions), "report.bmp")]
  public class CachedRptMpDettagliLocaliLungoDinamico : Component, ICachedReport
  {
    public virtual bool IsCacheable
    {
      get => true;
      set
      {
      }
    }

    public virtual bool ShareDBLogonInfo
    {
      get => false;
      set
      {
      }
    }

    public virtual TimeSpan CacheTimeOut
    {
      get => (TimeSpan) CachedReportConstants.DEFAULT_TIMEOUT;
      set
      {
      }
    }

    public virtual ReportDocument CreateReport()
    {
      RptMpDettagliLocaliLungoDinamico localiLungoDinamico = new RptMpDettagliLocaliLungoDinamico();
      ((Component) localiLungoDinamico).Site = this.Site;
      return (ReportDocument) localiLungoDinamico;
    }

    public virtual string GetCustomizedCacheKey(RequestContext request) => (string) null;
  }
}
