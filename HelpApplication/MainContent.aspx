<%@ Page language="c#" Codebehind="MainContent.aspx.cs" AutoEventWireup="false" Inherits="HelpApplication.MainContent" %>
<%@ Register TagPrefix="cc1" Namespace="arTreeMenu" Assembly="arTreeMenu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainContent</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css"> BODY { MARGIN: 0px; FONT: 15px verdana; TEXT-DECORATION: none }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<div align="center">
				<br>
				<br>
				<table>
					<tr>
						<td align="center" colSpan="2">
							<IMG src="Images/WFP_LOGOS.jpg" border="0" useMap="#Map" style="WIDTH: 801px; HEIGHT: 400px">
						</td>
					</tr>
				</table>
			</div>
			<br>
			<div style="FONT-SIZE: 1px; FONT-FAMILY: Verdana, Arial">
				<p align="center"><br>
					<%= System.Configuration.ConfigurationSettings.AppSettings["ApplicationDeveloper"]%>
				</p>
			</div>
		</form>
	</body>
</HTML>
