<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Page language="c#" Codebehind="EditFornitori.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditFornitori" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditFornitori</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<script language="javascript">
	
	
	
		</script>
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
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" CssClass="TitleOperazione" Width="544px"></asp:label><cc2:messagepanel id="PanelMess" runat="server" ErrorIconUrl="~/Images/ico_critical.gif" MessageIconUrl="~/Images/ico_info.gif"></cc2:messagepanel></TD>
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
													<TD style="HEIGHT: 24px" align="left">Fornitore&nbsp;
														<asp:RequiredFieldValidator id="rfvFornitore" runat="server" ControlToValidate="txtsFornitore" ErrorMessage="Inserire il cognome">*</asp:RequiredFieldValidator></TD>
													<TD style="HEIGHT: 24px">
														<cc1:S_TextBox id="txtsFornitore" tabIndex="1" runat="server" Width="346px" DBIndex="0" DBParameterName="p_vn_id"
															DBSize="30" DBDirection="Input" MaxLength="30"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 23px" align="left">Indirizzo</TD>
													<TD style="HEIGHT: 23px">
														<cc1:S_TextBox id="txtsindirizzo" tabIndex="2" runat="server" Width="90%" DBIndex="1" DBParameterName="p_indirizzo"
															DBSize="50" DBDirection="Input" DBDataType="VarChar"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 17px" align="left">Provincia&nbsp;&nbsp;</TD>
													<TD style="HEIGHT: 17px">
														<cc1:S_ComboBox id="cmbsprov_res" tabIndex="3" runat="server" DBIndex="2" DBParameterName="p_prov_res_id"
															DBSize="10" DBDirection="Input" DBDataType="Integer" AutoPostBack="True"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 34px" align="left">Comune&nbsp;</TD>
													<TD style="HEIGHT: 34px">
														<cc1:S_ComboBox id="cmbscom_res" tabIndex="4" runat="server" Width="90%" DBIndex="3" DBParameterName="p_com_res_id"
															DBSize="10" DBDirection="Input" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD align="left">CAP</TD>
													<TD>
														<cc1:S_TextBox id="txtscap" tabIndex="5" runat="server" DBIndex="4" DBParameterName="p_postal_code"
															DBSize="10" DBDirection="Input"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD align="left">Telefono</TD>
													<TD>
														<cc1:S_TextBox id="txtstelefono" tabIndex="6" runat="server" DBIndex="5" DBParameterName="p_telefono"
															DBSize="20" DBDirection="Input" DBDataType="VarChar"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD align="left">Fax</TD>
													<TD>
														<cc1:S_TextBox id="txtsfax" tabIndex="7" runat="server" DBIndex="6" DBParameterName="p_fax" DBSize="20"
															DBDirection="Input" DBDataType="VarChar"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 22px" align="left">E-mail
														<asp:RegularExpressionValidator id="REVtxtsemail" runat="server" ControlToValidate="txtsemail" ErrorMessage="Formato Email non  Valido"
															ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></TD>
													<TD style="HEIGHT: 22px">
														<cc1:S_TextBox id="txtsemail" tabIndex="8" runat="server" DBIndex="7" DBParameterName="p_email"
															DBSize="50" DBDirection="Input" DBDataType="VarChar"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD align="left">P.IVA</TD>
													<TD>
														<cc1:S_TextBox id="txtspiva" tabIndex="9" runat="server" DBIndex="8" DBParameterName="p_iva" DBSize="16"
															DBDirection="Input" DBDataType="VarChar"></cc1:S_TextBox></TD>
												</TR>
											</TABLE>
										</asp:panel></TD>
								</TR>
								<tr>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="10" runat="server" Text="Salva" CssClass="btn"></cc1:s_button>&nbsp;
										<cc1:s_button id="btnsElimina" tabIndex="11" runat="server" Text="Elimina" CommandType="Delete"
											CausesValidation="False" CssClass="btn"></cc1:s_button>&nbsp;
										<asp:button id="btnAnnulla" tabIndex="12" runat="server" Text="Annulla" CausesValidation="False"
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
			<asp:validationsummary id="vlsEdit" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD></TR></TBODY></TABLE></form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
