<%@ Register TagPrefix="uc1" TagName="BottomMenu" Src="../../WebControls/BottomMenu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="Associazione_EQ_PMS.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.Associazione_EQ_PMS" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Schedula</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" title="Associazione delle Apparecchiature alle Procedure di Manutenzione Programmata"
							runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left" width="90%" height="1%">
						<hr noShade SIZE="1">
					</TD>
				</TR>
				<TR vAlign="top" height="10%">
					<TD vAlign="top" align="center" width="90%">
						<TABLE class="DataPanel100" cellSpacing="1" cellPadding="1" align="center">
							<tr>
								<td colSpan="4">APPARECCHIATURE</td>
							</tr>
							<tr>
								<td width="5%">&nbsp;</td>
								<td width="50%">- Totale popolate:
								</td>
								<td align="right" width="2%"><%= TotEQ.ToString() %></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td></td>
								<td>- Associate al Piano di Manutenzione Standard:
								</td>
								<td align="right"><%= p_totEQinPMS.ToString() %></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td></td>
								<td>- Non associate al Piano di Manutenzione Standard:
								</td>
								<td align="right"><%= p_totEQnoPMS.ToString() %></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="4">STANDARD APPARECCHIATURE</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>- Totale popolati:
								</td>
								<td align="right"><%= p_totEQSTD.ToString() %></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>- Associati alle apparecchiature:
								</td>
								<td align="right"><%= p_totEQSTDinEQ.ToString() %></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>- Compresi nelle Procedure di Manutenzione Programmata:
								</td>
								<td align="right"><%= p_totEQSTDinPMP.ToString() %></td>
								<td>&nbsp;</td>
							</tr>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left" width="90%" height="1%">
						<hr noShade SIZE="1">
					</TD>
				</TR>
				<tr>
					<td vAlign="top" align="center"><cc1:s_button id="cmdAssocia" runat="server" Visible="true" Text="Associa Apparecchiature al Piano di Manutenzione Standard"
							CssClass="btn"></cc1:s_button></td>
				</tr>
				<tr vAlign="bottom">
					<td vAlign="bottom"><uc1:bottommenu id="BottomMenu1" runat="server"></uc1:bottommenu></td>
				</tr>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
