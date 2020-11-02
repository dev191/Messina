<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="EditAnagrafica.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditAnagrafica" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditAnagrafica</title>
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
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" CssClass="TitleOperazione" Width="616px"></asp:label><cc2:messagepanel id="PanelMess" runat="server" ErrorIconUrl="~/Images/ico_critical.gif" MessageIconUrl="~/Images/ico_info.gif"></cc2:messagepanel></TD>
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
											<TABLE id="tblSearch75" cellSpacing="1" cellPadding="2" border="0">
												<TR>
													<TD style="WIDTH: 134px" align="left" width="134">Descrizione
														<asp:RequiredFieldValidator id="rfvDescrizione" runat="server" ControlToValidate="txtsDescrizione" ErrorMessage="Inserire la descrizione ">*</asp:RequiredFieldValidator></TD>
													<TD width="75%">
														<cc1:S_TextBox id="txtsDescrizione" tabIndex="1" runat="server" Width="344px" MaxLength="255" DBIndex="0"
															DBParameterName="p_Descrizione" DBSize="255" DBDirection="Input"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 134px" align="left" width="134">
														<P><%=Codice%>&nbsp;
															<asp:RequiredFieldValidator id="RvfCodice" runat="server" ControlToValidate="txtsCodice" ErrorMessage="Inserire il Codice">*</asp:RequiredFieldValidator></P>
													</TD>
													<TD width="75%">
														<cc1:S_TextBox id="txtsCodice" tabIndex="2" runat="server" Width="344px" MaxLength="10" DBIndex="2"
															DBParameterName="p_Codice" DBSize="5" DBDirection="Input"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 134px" align="left" width="134">Note
													</TD>
													<TD width="75%">
														<cc1:S_TextBox id="txtsNote" tabIndex="3" runat="server" Width="346px" DBIndex="1" DBParameterName="p_note"
															DBSize="500" DBDirection="Input" Height="137px" TextMode="MultiLine"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD align="center" colSpan="4"></TD>
												</TR>
											</TABLE>
										</asp:panel></TD>
								</TR>
								<tr>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="4" runat="server" Text="Salva" CssClass="btn"></cc1:s_button>&nbsp;
										<cc1:s_button id="btnsElimina" tabIndex="5" runat="server" Text="Elimina" CommandType="Delete"
											CausesValidation="False" CssClass="btn"></cc1:s_button>&nbsp;
										<asp:button id="btnAnnulla" tabIndex="6" runat="server" Text="Annulla" CausesValidation="False"
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
			<asp:ValidationSummary id="vlsEdit" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></TD></TR></TBODY></TABLE></form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
