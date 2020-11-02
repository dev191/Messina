<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="VisualPdf.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorretiva.VisualPdf" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>VisualPdf</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Tablepdf" style="Z-INDEX: 102; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center">
						<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></TD>
				</TR>
				<TR height="100%">
					<TD style="HEIGHT: 100%">
						<P>
							<asp:Literal id="Literal1" runat="server"></asp:Literal></P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
