<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Page language="c#" Codebehind="EditRichiedenti.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditRichiedenti" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditRichiedenti</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR vAlign="top" align="center" height="95%">
					<TD>
						<TABLE id="tblFormInput1" cellSpacing="0" cellPadding="1" align="center">
							<TBODY>
								<TR>
									<TD style="WIDTH: 5%; HEIGHT: 4.82%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 4.82%" vAlign="top" align="left">
										<b>
											<asp:label id="lblOperazione" runat="server" Width="608px" CssClass="TitleOperazione"></asp:label></b>
										<cc2:messagepanel id="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"></cc2:messagepanel></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 1%" vAlign="top" align="left" colspan="2">
										<hr noShade SIZE="2">
									</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center"></TD>
									<TD vAlign="top" align="left"><asp:panel id="PanelEdit" runat="server">
											<TABLE id="tblSearch75" cellSpacing="1" cellPadding="2" border="0">
												<TR>
													<TD align="left"><B>Nome</B>
														<asp:RequiredFieldValidator id="rvfnome" runat="server" ControlToValidate="txtsNome" ErrorMessage="Inserire il nome">*</asp:RequiredFieldValidator></TD>
													<TD>
														<cc1:S_TextBox id="txtsNome" tabIndex="1" runat="server" width="50%" DBIndex="1" DBParameterName="p_nome"
															DBSize="128" DBDirection="Input"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD align="left"><B>Cognome
															<asp:RequiredFieldValidator id="rfvcognome" runat="server" ControlToValidate="txtsCognome" ErrorMessage="Inserire il cognome">*</asp:RequiredFieldValidator></B></TD>
													<TD>
														<cc1:S_TextBox id="txtsCognome" tabIndex="2" runat="server" width="50%" DBIndex="2" DBParameterName="p_cognome"
															DBSize="255" DBDirection="Input" DBDataType="VarChar"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD align="left"><B>Gruppo</B>
														<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="cmbsGruppo" ErrorMessage="Inserire il gruppo d'appartenenza">*</asp:RequiredFieldValidator></TD>
													<TD>
														<cc1:S_ComboBox id="cmbsGruppo" runat="server" Width="196px" DBIndex="3" DBParameterName="p_idGruppo"
															DBDataType="Integer" AutoPostBack="False"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD align="left"><B>Telefono</B>
													</TD>
													<TD>
														<cc1:S_TextBox id="txtstelefono" runat="server" DBIndex="4" DBParameterName="p_phone" DBSize="128"
															DBDirection="Input" MaxLength="20"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD align="left"><B>Email</B>
														<asp:RegularExpressionValidator id="REVtxtsemail" runat="server" Width="3px" ControlToValidate="txtsEmail" ErrorMessage="Formato Email non  Valido"
															ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Height="8px">*</asp:RegularExpressionValidator></TD>
													<TD>
														<cc1:S_TextBox id="txtsemail" runat="server" DBIndex="5" DBParameterName="p_email" DBSize="128"
															DBDirection="Input" MaxLength="50"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD align="left"><B>Stanza</B>
													</TD>
													<TD>
														<cc1:S_TextBox id="txtsstanza" runat="server" DBIndex="6" DBParameterName="p_stanza" DBSize="128"
															DBDirection="Input" MaxLength="15"></cc1:S_TextBox></TD>
												</TR>
											</TABLE>
										</asp:panel></TD>
								</TR>
								<tr>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><cc1:s_button CssClass="btn" id="btnsSalva" tabIndex="7" runat="server" Text="Salva"></cc1:s_button>&nbsp;
										<cc1:s_button CssClass="btn" id="btnsElimina" tabIndex="8" runat="server" Text="Elimina" CommandType="Delete"></cc1:s_button>&nbsp;
										<asp:button CssClass="btn" id="btnAnnulla" tabIndex="9" runat="server" Text="Annulla" CausesValidation="False"></asp:button></TD>
								</tr>
								<TR>
									<TD style="HEIGHT: 1%" vAlign="top" align="left" colspan="2">
										<hr noShade SIZE="2">
									</TD>
								</TR>
				</TR>
			</TABLE>
			<asp:validationsummary id="vlsEdit" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD></TR></TBODY></TABLE></form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
