<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="EditSpecializzazioni.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditSpecializzazioni" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditSpecializzazioni</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR vAlign="top" align="center" height="95%">
					<TD>
						<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" align="center">
							<TBODY>
								<TR>
									<TD style="WIDTH: 5%; HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" Width="536px" CssClass="TitleOperazione"></asp:label><cc2:messagepanel id="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"></cc2:messagepanel></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 1%" vAlign="top" align="left">
										<hr noShade SIZE="1">
									</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center"></TD>
									<TD vAlign="top" align="left"><asp:panel id="PanelEdit" runat="server">
											<TABLE id="tblSearch75" cellSpacing="1" cellPadding="2" width="100%" border="0">
												<TR>
													<TD style="WIDTH: 84px" align="left">Descrizione
														<asp:RequiredFieldValidator id="rvfdescrizione" runat="server" ErrorMessage="Inserire la descrizione" ControlToValidate="txtsdescrizione">*</asp:RequiredFieldValidator></TD>
													<TD>
														<cc1:S_TextBox id="txtsdescrizione" tabIndex="1" runat="server" DBDirection="Input" DBSize="100"
															DBParameterName="p_descrizione" DBIndex="0" width="304px" MaxLength="100"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 84px" align="left">
														<P>Servizio
															<asp:RequiredFieldValidator id="rfvServizio" runat="server" ErrorMessage="Scegliere un servizio." ControlToValidate="cmbsServizio">*</asp:RequiredFieldValidator></P>
													</TD>
													<TD>
														<CC1:S_COMBOBOX id="cmbsServizio" tabIndex="9" runat="server" Width="304px" DBDirection="Input"
															DBSize="10" DBParameterName="p_SERVIZIO" DBIndex="3" DBDataType="Integer"></CC1:S_COMBOBOX></TD>
												</TR>
											</TABLE>
										</asp:panel></TD>
								</TR>
								<tr>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left">
										<cc1:s_button id="btnsSalva" tabIndex="2" runat="server" Text="Salva" CssClass="btn"></cc1:s_button>&nbsp;
										<cc1:s_button id="btnsElimina" tabIndex="3" runat="server" Text="Elimina" CommandType="Delete"
											CssClass="btn"></cc1:s_button>&nbsp;
										<asp:button id="btnAnnulla" tabIndex="4" runat="server" Text="Annulla" CausesValidation="False"
											CssClass="btn"></asp:button></TD>
								</tr>
								<TR>
									<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 1%" vAlign="top" align="left">
										<hr noShade SIZE="1">
									</TD>
								</TR>
				</TR>
				<TR>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblFirstAndLast" runat="server"></asp:label>&nbsp;
					</TD>
				</TR>
			</TABLE>
			<asp:validationsummary id="vlsEdit" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD></TR></TBODY></TABLE></form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
