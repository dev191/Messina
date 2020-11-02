// Decompiled with JetBrains decompiler
// Type: TheSite.Report.RptPianoMp
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using System.ComponentModel;

namespace TheSite.Report
{
  public class RptPianoMp : ReportClass
  {
    public RptPianoMp() => base.\u002Ector();

    public virtual string ResourceName
    {
      get => "RptPianoMp.rpt";
      set
      {
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(0);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section2 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(1);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupHeaderSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(2);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupHeaderSection2 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(3);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section GroupHeaderSection3 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(4);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupHeaderSection4 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(5);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupHeaderSection5 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(6);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section3 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(7);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section GroupFooterSection5 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(8);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section GroupFooterSection7 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(9);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupFooterSection6 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(10);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section GroupFooterSection4 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(11);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupFooterSection3 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(12);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section GroupFooterSection2 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(13);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupFooterSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(14);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section4 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(15);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section Section5 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(16);
  }
}
