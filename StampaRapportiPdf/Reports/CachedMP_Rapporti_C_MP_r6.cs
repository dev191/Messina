// Decompiled with JetBrains decompiler
// Type: TheSite.StampaRapportiPDF.Reports.CachedMP_Rapporti_C_MP_r6
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System;
using System.ComponentModel;
using System.Drawing;

namespace TheSite.StampaRapportiPDF.Reports
{
  [ToolboxBitmap(typeof (ExportOptions), "report.bmp")]
  public class CachedMP_Rapporti_C_MP_r6 : Component, ICachedReport
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
      MP_Rapporti_C_MP_r6 mpRapportiCMpR6 = new MP_Rapporti_C_MP_r6();
      ((Component) mpRapportiCMpR6).Site = this.Site;
      return (ReportDocument) mpRapportiCMpR6;
    }

    public virtual string GetCustomizedCacheKey(RequestContext request) => (string) null;
  }
}
