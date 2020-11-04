<%@ Page language="c#" Codebehind="DisplayReportGiudizio.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnalisiStatistiche.DysplayReportGiudizio" %>
<%@ Register TagPrefix="cr1" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>DysplayReport</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<BODY ms_positioning="GridLayout">
		<FORM id="FrmReport" method="post" runat="server">
			<TABLE id="tblMain" cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
				<TR>
					<TD colspan="3"><CR1:CRYSTALREPORTVIEWER id="rptEngineOra" runat="server" borderstyle="None" width="350px" height="50px"
							displaygrouptree="False" enabledrilldown="False" hasdrillupbutton="False" hassearchbutton="False"></CR1:CRYSTALREPORTVIEWER></TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
