<%@ Register TagPrefix="MessagePanel1" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Page language="c#" Codebehind="EditDitte.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditDitte" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditUtenti</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../Js/CommonScript.js"></SCRIPT>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" height="95%">
						<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" align="center">
							<TR>
								<TD style="WIDTH: 5%; HEIGHT: 4.68%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 4.68%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" CssClass="TitleOperazione" Width="536px"></asp:label>
									<MESSPANEL:MESSAGEPANEL id="PanelMess" runat="server" Width="136px" ErrorIconUrl="~/Images/ico_critical.gif"
										MessageIconUrl="~/Images/ico_info.gif"></MESSPANEL:MESSAGEPANEL></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 0.96%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 0.96%" vAlign="top" align="left"><hr noShade SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center"></TD>
								<TD vAlign="top" align="left"><asp:panel id="PanelEdit" runat="server">
										<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
											<TR>
												<TD align="center" colSpan="4"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 108px; HEIGHT: 23px" vAlign="middle" align="right">
													<asp:RequiredFieldValidator id="rfvUserName" runat="server" ControlToValidate="txtsDescrizione" ErrorMessage="Inserire la Ditta">*</asp:RequiredFieldValidator>Ditta</TD>
												<TD style="WIDTH: 235px; HEIGHT: 23px" width="235" height="23">
													<cc1:S_TextBox id="txtsDescrizione" runat="server" Width="200px" DBDirection="Input" DBSize="255"
														DBParameterName="p_DESCRIZIONE" DBIndex="0"></cc1:S_TextBox></TD>
												<TD style="WIDTH: 204px; HEIGHT: 23px" vAlign="middle" align="right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Indirizzo&nbsp;</TD>
												<TD style="HEIGHT: 23px" width="30%" height="23">
													<cc1:s_textbox id="txtsIndirizzo" tabIndex="2" runat="server" DBDirection="Input" DBSize="255"
														DBParameterName="p_INDIRIZZO" DBIndex="1" width="208px"></cc1:s_textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 108px; HEIGHT: 36px" vAlign="middle" align="right">Provincia</TD>
												<TD style="WIDTH: 235px; HEIGHT: 36px">
													<cc1:S_ComboBox id="cmbsProvincia" runat="server" Width="200px" DBDirection="Input" DBParameterName="p_PROVINCIA"
														DBIndex="7" DBDataType="Integer" AutoPostBack="True"></cc1:S_ComboBox></TD>
												<TD style="WIDTH: 204px; HEIGHT: 36px" vAlign="middle" align="right">Comune</TD>
												<TD style="HEIGHT: 36px">
													<cc1:S_ComboBox id="cmbsComune" runat="server" Width="208px" DBDirection="Input" DBParameterName="p_COMUNE"
														DBIndex="8" DBDataType="Integer"></cc1:S_ComboBox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 108px; HEIGHT: 14px" vAlign="middle" align="right">Tipo</TD>
												<TD style="WIDTH: 235px; HEIGHT: 14px">
													<cc1:S_ComboBox id="cmbsTipo" runat="server" Width="200px" DBDirection="Input" DBParameterName="p_TIPOLOGIADITTA"
														DBIndex="3" DBDataType="Integer" AutoPostBack="True"></cc1:S_ComboBox></TD>
												<TD style="WIDTH: 204px; HEIGHT: 14px" vAlign="middle" align="right">&nbsp;&nbsp;Telefono</TD>
												<TD style="HEIGHT: 14px">
													<cc1:S_TextBox id="txtsTelefono" runat="server" Width="200px" DBSize="20" DBParameterName="p_TELEFONO"
														DBIndex="5"></cc1:S_TextBox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 108px; HEIGHT: 14px" vAlign="middle" borderColor="red" align="right"
													colSpan="1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" Width="3px" ControlToValidate="TxtsCAP"
														ErrorMessage="Cap Non Valido" ValidationExpression="\d{5}" Height="8px">*</asp:RegularExpressionValidator>&nbsp;CAP</TD>
												<TD style="WIDTH: 235px; HEIGHT: 14px" borderColor="red" align="left" rowSpan="1">
													<cc1:S_TextBox id="TxtsCAP" runat="server" Width="134px" DBDirection="Input" DBSize="10" DBParameterName="p_CAP"
														DBIndex="2"></cc1:S_TextBox></TD>
												<TD style="WIDTH: 204px; HEIGHT: 14px" borderColor="red" align="right" rowSpan="1"></TD>
												<TD style="HEIGHT: 14px" borderColor="red" align="center" rowSpan="1"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 108px; HEIGHT: 7px" vAlign="middle" align="right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Referente</TD>
												<TD style="WIDTH: 235px; HEIGHT: 7px">
													<cc1:S_TextBox id="txtsReferente" runat="server" Width="215px" DBDirection="Input" DBSize="100"
														DBParameterName="p_REFERENTE" DBIndex="6"></cc1:S_TextBox></TD>
												<TD style="WIDTH: 204px; HEIGHT: 7px" vAlign="middle" align="right">&nbsp;&nbsp;
													<asp:RegularExpressionValidator id="REVtxtsemail" runat="server" Width="3px" ControlToValidate="txtsEmail" ErrorMessage="Formato Email non  Valido"
														ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Height="8px">*</asp:RegularExpressionValidator>&nbsp;&nbsp;EMail</TD>
												<TD style="HEIGHT: 7px">
													<cc1:S_TextBox id="txtsEmail" runat="server" Width="200px" DBDirection="Input" DBSize="255" DBParameterName="p_EMAIL"
														DBIndex="4"></cc1:S_TextBox></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="4"></TD>
											</TR>
										</TABLE>
									</asp:panel></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 2.77%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 2.77%" vAlign="top" align="left"><TABLE class="tblFormInputDettaglio" id="tblSearch100Dettaglio" cellSpacing="1" cellPadding="1"
										width="100%" align="center" border="0">
										<TR>
											<TD align="center" width="40%">Servizi</TD>
											<TD align="center"></TD>
											<TD align="center">Servizi Associati</TD>
										</TR>
										<TR>
											<TD align="center"><asp:listbox id="ListBoxLeft" tabIndex="7" runat="server" Width="280px" Enabled="False" Rows="8"></asp:listbox></TD>
											<TD>
												<P align="center"><asp:button id="btnAssocia" tabIndex="8" runat="server" Width="110px" Enabled="False" Text="Aggiungi >>"
														CausesValidation="False" CssClass="btn"></asp:button></P>
												<P align="center"><asp:button id="btnElimina" tabIndex="9" runat="server" Width="110px" Enabled="False" Text="<< Elimina"
														CausesValidation="False" CssClass="btn"></asp:button></P>
											</TD>
											<TD align="center"><asp:listbox id="ListBoxRight" tabIndex="10" runat="server" Width="272px" Enabled="False" Rows="8"></asp:listbox></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD width="40%"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 2.77%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 2.77%" vAlign="top" align="left"><TABLE class="tblFormInputDettaglio" id="tblSearch100Dettaglio" cellSpacing="1" cellPadding="1"
										width="100%" align="center" border="0">
										<TR>
											<TD align="center" width="40%">Ditte SubAppaltatrici</TD>
											<TD align="center"></TD>
											<TD align="center">Ditte SubAppaltatrici Associate</TD>
										</TR>
										<TR>
											<TD align="center"><asp:listbox id="ListBoxLeftF" tabIndex="7" runat="server" Width="272px" Enabled="False" Rows="8"></asp:listbox></TD>
											<TD>
												<P align="center"><asp:button id="btnAssociaF" tabIndex="8" runat="server" Width="110px" Enabled="False" Text="Aggiungi >>"
														CausesValidation="False" CssClass="btn"></asp:button></P>
												<P align="center"><asp:button id="btnEliminaF" tabIndex="9" runat="server" Width="110px" Enabled="False" Text="<< Elimina"
														CausesValidation="False" CssClass="btn"></asp:button></P>
											</TD>
											<TD align="center"><asp:listbox id="ListBoxRightF" tabIndex="10" runat="server" Width="272px" Enabled="False" Rows="8"></asp:listbox></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD width="40%"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 4.53%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 4.53%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="11" runat="server" Text="Salva" CssClass="btn"></cc1:s_button>&nbsp;
									<cc1:s_button id="btnsElimina" tabIndex="12" runat="server" Text="Elimina" CausesValidation="False"
										CommandType="Delete" CssClass="btn"></cc1:s_button>&nbsp;
									<asp:button id="btnAnnulla" tabIndex="13" runat="server" Text="Annulla" CausesValidation="False"
										CssClass="btn"></asp:button></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 1%" vAlign="top" align="left">
									<hr noShade SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblFirstAndLast" runat="server"></asp:label>&nbsp;</TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="vlsEdit" runat="server" ShowMessageBox="True" DisplayMode="List" ShowSummary="False"></asp:validationsummary></TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
