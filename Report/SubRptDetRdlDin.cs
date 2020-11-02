// Decompiled with JetBrains decompiler
// Type: TheSite.Report.SubRptDetRdlDin
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.ComponentModel;

namespace TheSite.Report
{
  public class SubRptDetRdlDin : ReportClass
  {
    public SubRptDetRdlDin() => base.\u002Ector();

    public virtual string ResourceName
    {
      get => "SubRptDetRdlDin.rpt";
      set
      {
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section ReportHeaderSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(0);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section PageHeaderSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(1);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupHeaderSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(2);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupHeaderSection2 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(3);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section Section3 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(4);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupFooterSection2 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(5);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupFooterSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(6);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section ReportFooterSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(7);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section PageFooterSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(8);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IParameterField Parameter_Pm_tblMainWO_ID => (IParameterField) ((ReportDocument) this).get_DataDefinition().get_ParameterFields().get_Item(0);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public IParameterField Parameter_Pm_tblMainID_PMP => (IParameterField) ((ReportDocument) this).get_DataDefinition().get_ParameterFields().get_Item(1);
  }
}
