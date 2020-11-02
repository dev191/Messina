// Decompiled with JetBrains decompiler
// Type: TheSite.Report.RptGiudizioServizio
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using System.ComponentModel;

namespace TheSite.Report
{
  public class RptGiudizioServizio : ReportClass
  {
    public RptGiudizioServizio() => base.\u002Ector();

    public virtual string ResourceName
    {
      get => "RptGiudizioServizio.rpt";
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

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section10 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(2);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section Section6 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(3);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section Section3 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(4);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section7 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(5);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section11 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(6);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section4 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(7);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Section Section5 => ((ReportDocument) this).get_ReportDefinition().get_Sections().get_Item(8);
  }
}
