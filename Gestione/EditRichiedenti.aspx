<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="EditRichiedenti.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditRichiedenti" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
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
									<TD vAlign="top" align="left"><asp:panel id="PanelEdit" runat="server" Height="152px">
											<TABLE id="tblSearch75" cellSpacing="1" cellPadding="2" border="0">
												<TBODY>
													<TR>
														<TD align="left"><B>Nome</B>
															<asp:RequiredFieldValidator id="rvfnome" runat="server" ErrorMessage="Inserire il nome" ControlToValidate="txtsNome">*</asp:RequiredFieldValidator></TD>
														<TD>
															<cc1:S_TextBox id="txtsNome" tabIndex="1" runat="server" DBDirection="Input" DBSize="128" DBParameterName="p_nome"
																DBIndex="0" width="50%"></cc1:S_TextBox></TD>
													</TR>
													<TR>
														<TD align="left"><B>Cognome
																<asp:RequiredFieldValidator id="rfvcognome" runat="server" ErrorMessage="Inserire il cognome" ControlToValidate="txtsCognome">*</asp:RequiredFieldValidator></B></TD>
														<TD>
															<cc1:S_TextBox id="txtsCognome" tabIndex="2" runat="server" DBDirection="Input" DBSize="255" DBParameterName="p_cognome"
																DBIndex="1" width="50%" DBDataType="VarChar"></cc1:S_TextBox></TD>
													</TR>
													<TR>
														<TD align="left"><B>Gruppo</B>
															<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Inserire il gruppo d'appartenenza"
																ControlToValidate="cmbsGruppo">*</asp:RequiredFieldValidator></TD>
														<TD>
															<cc1:S_ComboBox id="cmbsGruppo" runat="server" Width="196px" DBParameterName="p_idGruppo" DBIndex="2"
																DBDataType="Integer" AutoPostBack="False"></cc1:S_ComboBox></TD>
													</TR>
													<TR>
														<TD align="left"><B>Telefono</B>
														</TD>
														<TD>
															<cc1:S_TextBox id="txtstelefono" runat="server" DBDirection="Input" DBSize="128" DBParameterName="p_phone"
																DBIndex="4" MaxLength="20"></cc1:S_TextBox></TD>
													</TR>
													<TR>
														<TD align="left"><B>Email</B>
															<asp:RegularExpressionValidator id="REVtxtsemail" runat="server" Width="3px" Height="8px" ErrorMessage="Formato Email non  Valido"
																ControlToValidate="txtsEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></TD>
														<TD>
															<cc1:S_TextBox id="txtsemail" runat="server" DBDirection="Input" DBSize="128" DBParameterName="p_email"
																DBIndex="5" MaxLength="50"></cc1:S_TextBox></TD>
													</TR>
													<TR>
														<TD align="left"><B>Stanza</B>
														</TD>
														<TD>
															<cc1:S_TextBox id="txtsstanza" runat="server" DBDirection="Input" DBSize="128" DBParameterName="p_stanza"
																DBIndex="6" MaxLength="15"></cc1:S_TextBox></TD>
													</TR>
										</asp:panel>
								<TR>
									<TD align="left"><B>progetto</B>
									</TD>
									<TD>
										<CC1:S_COMBOBOX id="CmbProgetto" tabIndex="8" runat="server" dbdatatype="Integer" dbparametername="p_progetto"
											dbdirection="Input" dbsize="1" dbindex="3"></CC1:S_COMBOBOX></TD>
								</TR>
							</TBODY>
						</TABLE>
					</TD>
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
