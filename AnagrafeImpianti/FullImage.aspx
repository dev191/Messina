<%@ Page language="c#" Codebehind="FullImage.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.FullImage" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>FullImage</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body  MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="center">
						<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></TD>
				</TR>
				<TR>
					<TD align="left"><INPUT id="btback1" style="WIDTH: 136px; HEIGHT: 19px" type="button" value="Indietro" onclick="javascript:history.back();" class=btn>
					
					</TD>
				</TR>
				<TR height="100%">
					<TD style="HEIGHT: 100%" align="center">
						<img id="imgdoc" runat="server" border="0">
					</TD>
				</TR>
				<TR>
					<TD align="left"><INPUT id="btback2" style="WIDTH: 136px; HEIGHT: 19px" type="button" value="Indietro" onclick="javascript:history.back();" class=btn>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
