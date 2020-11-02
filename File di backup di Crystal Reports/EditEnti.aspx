<%@ Page language="c#" Codebehind="EditEnti.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditEnti" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="MessagePanel1" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>EditUtenti</TITLE>
		<META content="False" name="vs_showGrid">
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../Js/CommonScript.js"></SCRIPT>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottommargin="0" leftmargin="5" topmargin="0"
		rightmargin="0" ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><UC1:PAGETITLE id="PageTitle1" runat="server"></UC1:PAGETITLE></TD>
				</TR>
				<TR>
					<TD valign="top" align="center" height="95%">
						<TABLE id="tblFormInput" cellspacing="1" cellpadding="1" align="center">
							<TR>
								<TD style="WIDTH: 5%; HEIGHT: 4.68%" valign="top" align="left"></TD>
								<TD style="HEIGHT: 4.68%" valign="top" align="left"><ASP:LABEL id="lblOperazione" runat="server" cssclass="TitleOperazione" width="536px"></ASP:LABEL><MESSPANEL:MESSAGEPANEL id="PanelMess" runat="server" width="136px" erroriconurl="~/Images/ico_critical.gif"
										messageiconurl="~/Images/ico_info.gif"></MESSPANEL:MESSAGEPANEL></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 0.96%" valign="top" align="left"></TD>
								<TD style="HEIGHT: 0.96%" valign="top" align="left"><HR noshade size="1">
								</TD>
							</TR>
							<TR>
								<TD valign="top" align="center"></TD>
								<TD valign="top" align="left"><ASP:PANEL id="PanelEdit" runat="server">
										<TABLE id="tblSearch100" cellspacing="0" cellpadding="2" border="1">
											<TBODY>
												<TR>
													<TD align="left" width="20%">Ente
														<asp:RequiredFieldValidator id="rfvEnte" runat="server" ControlToValidate="txtsDescrizione" ErrorMessage="Inserire l' Ente">*</asp:RequiredFieldValidator></TD>
													<TD width="30%"><CC1:S_TEXTBOX id="txtsDescrizione" tabindex="1" runat="server" dbdirection="Input" dbparametername="pDescrizione"
															dbsize="255"></CC1:S_TEXTBOX></TD>
													<TD colspan="2">&nbsp;</TD>
												</TR>
												<TR>
													<TD align="left" width="20%">Indirizzo</TD>
													<TD width="30%"><CC1:S_TEXTBOX id="txtsIndirizzo" tabindex="2" runat="server" dbparametername="pIndirizzo" dbsize="255"
															dbindex="3" maxlength="150" width="90%" dbdirection="Input"></CC1:S_TEXTBOX></TD>
													<TD align="left" width="20%">CAP</TD>
													<TD width="30%"><CC1:S_TEXTBOX id="txtsCap" tabindex="2" runat="server" dbparametername="pCap" dbsize="0" maxlength="15"
															width="90%" dbdirection="Input"></CC1:S_TEXTBOX></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 21px" align="left" width="20%">Provincia</TD>
													<TD style="HEIGHT: 21px" width="30%"><CC1:S_COMBOBOX id="cmbsProvincia" tabindex="3" runat="server" width="90%" maxlength="2" dbparametername="pProvincia"
															dbdirection="Input" autopostback="True" dbsize="10" dbindex="1" dbdatatype="Integer"></CC1:S_COMBOBOX></TD>
													<TD style="HEIGHT: 21px" align="left">Comune</TD>
													<TD style="HEIGHT: 21px"><CC1:S_COMBOBOX id="cmbsComune" tabindex="4" runat="server" width="90%" dbparametername="pComune "
															dbsize="10" maxlength="100" dbindex="2" dbdatatype="Integer"></CC1:S_COMBOBOX></TD>
												</TR>
							</TR>
							<TR>
								<TD style="HEIGHT: 26px" align="left">Ragione Sociale</TD>
								<TD style="HEIGHT: 26px"><CC1:S_TEXTBOX id="txtsRagioneSociale" tabindex="5" runat="server" width="90%" dbparametername="pRagioneSociale"
										dbsize="15" maxlength="15" dbindex="4"></CC1:S_TEXTBOX></TD>
								<TD style="HEIGHT: 26px" align="left">Partita IVA</TD>
								<TD style="HEIGHT: 26px"><CC1:S_TEXTBOX id="txtsPartitaIva" tabindex="6" runat="server" width="90%" dbdirection="Input"
										dbparametername="pPiva" maxlength="20" dbsize="20" dbindex="5"></CC1:S_TEXTBOX></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 23px" align="left">Telefono</TD>
								<TD style="HEIGHT: 23px"><CC1:S_TEXTBOX id="txtsTelefono" tabindex="7" runat="server" dbdirection="Input" dbparametername="pTelefono"
										dbsize="20" maxlength="20" width="90%" dbindex="6"></CC1:S_TEXTBOX></TD>
								<TD style="HEIGHT: 23px" align="left">Email</TD>
								<TD style="HEIGHT: 23px"><CC1:S_TEXTBOX id="txtsEmail" tabindex="8" runat="server" dbdirection="Input" dbparametername="pEmail"
										maxlength="100" width="90%" dbsize="20" dbindex="7"></CC1:S_TEXTBOX></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 24px" align="left">Referente</TD>
								<TD style="HEIGHT: 24px"><CC1:S_TEXTBOX id="txtsReferente" tabindex="9" runat="server" dbdirection="Input" dbparametername="pReferente"
										maxlength="100" width="90%" dbsize="100" dbindex="8"></CC1:S_TEXTBOX></TD>
								<TD style="HEIGHT: 24px" align="left">Telefono Referente</TD>
								<TD style="HEIGHT: 24px"><CC1:S_TEXTBOX id="txtsTelefonoRef" tabindex="10" runat="server" dbdirection="Input" dbparametername="pTelefonoReferente"
										dbsize="20" maxlength="20" width="90%" dbindex="9"></CC1:S_TEXTBOX></TD>
							</TR>
							<TR>
								<TD align="left">Data Inizio Contratto:</TD>
								<TD><UC1:CALENDARPICKER id="CalendarPicker1" runat="server"></UC1:CALENDARPICKER></TD>
								<TD align="left">Data Fine Contratto:</TD>
								<TD><UC1:CALENDARPICKER id="CalendarPicker2" runat="server"></UC1:CALENDARPICKER></TD>
							</TR>
						</TABLE>
						</ASP:PANEL></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 4.53%" valign="top" align="left"></TD>
					<TD style="HEIGHT: 4.53%" valign="top" align="left"><CC1:S_BUTTON id="btnsSalva" tabindex="11" runat="server" cssclass="btn" text="Salva"></CC1:S_BUTTON>&nbsp;
						<CC1:S_BUTTON id="btnsElimina" tabindex="12" runat="server" cssclass="btn" text="Elimina" commandtype="Delete"
							causesvalidation="False"></CC1:S_BUTTON>&nbsp;
						<ASP:BUTTON id="btnAnnulla" tabindex="13" runat="server" cssclass="btn" text="Annulla" causesvalidation="False"></ASP:BUTTON></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1%" valign="top" align="left"></TD>
					<TD style="HEIGHT: 1%" valign="top" align="left">
						<HR noshade size="1">
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 5%" valign="top" align="left"></TD>
					<TD style="HEIGHT: 5%" valign="top" align="left"><ASP:LABEL id="lblFirstAndLast" runat="server"></ASP:LABEL>&nbsp;</TD>
				</TR>
			</TABLE>
			<ASP:VALIDATIONSUMMARY id="vlsEdit" runat="server" showmessagebox="True" displaymode="List" showsummary="False"></ASP:VALIDATIONSUMMARY></TD></TR></TBODY></TABLE></FORM>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
