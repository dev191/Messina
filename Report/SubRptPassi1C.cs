// Decompiled with JetBrains decompiler
// Type: TheSite.Report.SubRptPassi1C
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.ComponentModel;

namespace TheSite.Report
{
  public class SubRptPassi1C : ReportClass
  {
    public SubRptPassi1C() => base.\u002Ector();

    public virtual string ResourceName
    {
      get => "SubRptPassi1C.rpt";
      set
      {
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(0);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section PageHeaderSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(1);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section GroupHeaderSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(2);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section Section6 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(3);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section DetailSection2 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(4);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section7 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(5);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section GroupFooterSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(6);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section Section4 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(7);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section PageFooterSection1 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(8);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public IParameterField Parameter_Pm_tblMainID_PMP => (IParameterField) ((ReportDocument) this).get_DataDefinition().get_ParameterFields().get_Item(0);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IParameterField Parameter_Pm_tblMainWO_ID => (IParameterField) ((ReportDocument) this).get_DataDefinition().get_ParameterFields().get_Item(1);
  }
}
