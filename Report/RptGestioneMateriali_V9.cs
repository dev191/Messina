// Decompiled with JetBrains decompiler
// Type: TheSite.Report.RptGestioneMateriali_V9
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using System.ComponentModel;

namespace TheSite.Report
{
  public class RptGestioneMateriali_V9 : ReportClass
  {
    public RptGestioneMateriali_V9() => base.\u002Ector();

    public virtual string ResourceName
    {
      get => "RptGestioneMateriali_V9.rpt";
      set
      {
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section Section1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(0);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section Section2 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(1);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupHeaderSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(2);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section3 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(3);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupFooterSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(4);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section4 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(5);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section Section5 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(6);
  }
}
