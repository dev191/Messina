<%@ Page language="c#" Codebehind="DisplayReportSpazi.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ReportGestioneSpazi.DisplayReportSpazi" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DisplayReportSpazi</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:Button id="Button1" runat="server" Text="Nuovo Report"></asp:Button></P>
			<P>
				<CR:CrystalReportViewer id="rptEngineOra" runat="server" Width="350px" Height="50px"></CR:CrystalReportViewer></P>
			<P>
				<asp:Label id="LabelMessaggio" runat="server"></asp:Label></P>
		</form>
	</body>
</HTML>
