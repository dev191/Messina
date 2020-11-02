<%@ Page language="c#" Codebehind="VisualizzaSchedaHtml.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ShedeEq.VisualizzaSchedaHtml" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>VisualizzaSchedaHtml</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="TblMain" width="100%">
				<TR>
					<TD><CR:CRYSTALREPORTVIEWER id="CryVwSchedaEq" runat="server" displaygrouptree="False" width="350px" height="50px"
							enabledrilldown="False" hasdrillupbutton="False" hassearchbutton="False" borderstyle="None" pagetotreeratio="10"></CR:CRYSTALREPORTVIEWER></TD>
				</TR>
				<TR>
					<TD><ASP:BUTTON id="btnIndietro" runat="server" width="150px" cssclass="btn" text="Nuova Ricerca"></ASP:BUTTON></TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
