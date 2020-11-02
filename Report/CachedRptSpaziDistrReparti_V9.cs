// Decompiled with JetBrains decompiler
// Type: TheSite.Report.CachedRptSpaziDistrReparti_V9
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
  public class CachedRptSpaziDistrReparti_V9 : Component, ICachedReport
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
      RptSpaziDistrReparti_V9 spaziDistrRepartiV9 = new RptSpaziDistrReparti_V9();
      ((Component) spaziDistrRepartiV9).Site = this.Site;
      return (ReportDocument) spaziDistrRepartiV9;
    }

    public virtual string GetCustomizedCacheKey(RequestContext request) => (string) null;
  }
}
