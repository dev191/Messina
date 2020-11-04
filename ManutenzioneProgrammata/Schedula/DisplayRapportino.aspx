<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Page language="c#" Codebehind="DisplayRapportino.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.Schedula.DisplayRapportino" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>DisplayRapportino</TITLE>
		<META name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<META name="CODE_LANGUAGE" content="C#">
		<META name="vs_defaultClientScript" content="JavaScript">
		<META name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<BODY onbeforeunload="parent.left.valorizza()">
		<FORM id="Form1" method="post" runat="server">
			<TABLE>
				<TR>
					<TD align="left">
						<CR:CRYSTALREPORTVIEWER id="CRView" runat="server" hasdrillupbutton="False" displaygrouptree="False" width="350px"
							height="50px"></CR:CRYSTALREPORTVIEWER></TD>
				</TR>
				<TR>
					<TD>
						<ASP:TEXTBOX id="txtTipo" runat="server" visible="False"></ASP:TEXTBOX>
						<ASP:TEXTBOX id="txtHid" runat="server" visible="False"></ASP:TEXTBOX></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 3px">
					</TD>
				</TR>
				<TR>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD>
					</TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT language="javascript">parent.left.calcola();</SCRIPT>
	</BODY>
</HTML>
