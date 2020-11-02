<%@ Page language="c#" Codebehind="ErrorPage.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ErrorPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ErrorPage</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style type="text/css"> BODY { BACKGROUND-IMAGE: url(images/bg.jpg); MARGIN: 0px; FONT: 15px verdana; TEXT-DECORATION: none }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<div align="center"><IMG src="images/logo2.jpg"><IMG src="Images/logo_ati2.jpg">
				<br>
				<br>
				<br>
				<br>
				Spiacenti si è verificato un Errore.
				<br>
				E' stata innoltrata la segnalazione, provvederemo al più presto.
			</div>
			<br>
			<div style="FONT-SIZE: 8px; FONT-FAMILY: Verdana, Arial">
				<p align="center"><br>
					<%= System.Configuration.ConfigurationSettings.AppSettings["ApplicationDeveloper"]%>
				</p>
			</div>
		</form>
	</body>
</HTML>
