<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CostiManodopera" Src="../WebControls/CostiManodopera.ascx" %>
<%@ Page language="c#" Codebehind="CostiOperativi.aspx.cs" AutoEventWireup="false" Inherits="TheSite.CostiOperativi.CostiOperativi" %>
<%@ Register TagPrefix="uc1" TagName="materiali" Src="../WebControls/materiali.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>CostiOperativi</TITLE>
		<META name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<META name="CODE_LANGUAGE" content="C#">
		<META name="vs_defaultClientScript" content="JavaScript">
		<META name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form2" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center">
							<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></TD>
					</TR>
					<TR vAlign="top">
						<TD align="center" valign="bottom">&nbsp;</TD>
					</TR>
					<TR vAlign="top">
						<TD align="center" valign="bottom">
							COSTI MANO D'OPERA</TD>
					</TR>
					<TR vAlign="top">
						<TD vAlign="top" width="100%">
							<uc1:CostiManodopera id="Costimanodopera2" runat="server" width="100%"></uc1:CostiManodopera>
						</TD>
					</TR>
					<TR vAlign="top">
						<TD align="center" valign="bottom">&nbsp;</TD>
					</TR>
					<TR vAlign="top">
						<TD valign="bottom" align="left">COSTI MATERILI</TD>
					</TR>
					<TR vAlign="top" width="100%">
						<TD vAlign="top" width="100%">
							<uc1:materiali id="Materiali2" runat="server"></uc1:materiali>
						</TD>
					</TR>
					<tr>
						<td>
							<asp:Button id="BntIndietro" runat="server" Text="Indietro"></asp:Button>
						</td>
					</tr>
				</TBODY>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
