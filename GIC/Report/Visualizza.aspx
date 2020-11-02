<%@ Page language="c#" Codebehind="Visualizza.aspx.cs" AutoEventWireup="false" Inherits="GIC.Report.Visualizza" %>
<%@ Register TagPrefix="uc1" TagName="ConsultazioniDataGrid" Src="UserControl/ConsultazioniDataGrid.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Visualizza</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:ConsultazioniDataGrid id="ConsultazioniDataGrid1" runat="server"></uc1:ConsultazioniDataGrid>
		</form>
	</body>
</HTML>
