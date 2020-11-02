// Decompiled with JetBrains decompiler
// Type: TheSite.Report.RptMpDettagliLocaliLungo
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using System.ComponentModel;

namespace TheSite.Report
{
  public class RptMpDettagliLocaliLungo : ReportClass
  {
    public RptMpDettagliLocaliLungo() => base.\u002Ector();

    public virtual string ResourceName
    {
      get => "RptMpDettagliLocaliLungo.rpt";
      set
      {
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section Section1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(0);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section2 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(1);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupHeaderSection2 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(2);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section6 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(3);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section Section10 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(4);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section GroupHeaderSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(5);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section Section3 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(6);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupFooterSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(7);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section GroupFooterSection2 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(8);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section Section7 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(9);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupFooterSection3 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(10);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupFooterSection6 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(11);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupFooterSection7 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(12);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section Section4 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(13);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section PageFooterSection4 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(14);
  }
}
