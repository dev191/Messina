<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="VisualizzaRdl2.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorretiva.VisualizzaRdl2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>VisualizzaRdl</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Css/MainSheet.css">
	</HEAD>
	<body bottomMargin="0" leftMargin="5" rightMargin="0" onbeforeunload="parent.left.valorizza()"
		topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; TOP: 0px; LEFT: 0px" id="TableMain"
				border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
					<TD colSpan="2" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<tr>
					<td>
						<table width="90%" align="center">
							<TR>
								<TD style="HEIGHT: 1%" vAlign="top" colSpan="2" align="left">
									<hr SIZE="1" noShade>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<TABLE id="tblSearch100" border="0" cellSpacing="1" cellPadding="1">
										<TR>
											<TD colSpan="8" align="center"></TD>
										</TR>
										<TR>
											<TD class="Title" width="10%" colSpan="3">OPERATORE:</TD>
											<TD colSpan="5"><asp:label id="lblOperatore" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="Title" colSpan="3">DATA:</TD>
											<td><asp:label id="lblData" runat="server"></asp:label></td>
											<TD class="Title" colSpan="3">ORA:</TD>
											<td><asp:label id="lblOra" runat="server"></asp:label></td>
										</TR>
										<tr>
											<TD class="Title" colSpan="3"><!--Numero Sga:--></TD>
											<td><asp:label id="LblSga" runat="server" Visible="False"></asp:label></td>
											<TD class="Title" colSpan="3"><!--Data Invio:--></TD>
											<td><asp:label id="LblInvioSga" runat="server" Visible="False"></asp:label></td>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2" align="center">&nbsp;</TD>
							</TR>
							<TR>
								<td colSpan="2">
									<DIV style="BORDER-BOTTOM: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-RIGHT: black 1px solid">
										<TABLE border="0" cellSpacing="1" cellPadding="1" width="100%">
											<TBODY>
												<tr>
													<TD class="TitleSearch" vAlign="middle" colSpan="4">DATI RICHIEDENTE</TD>
												</tr>
												<TR>
													<TD width="25%">RICHIEDENTE:</TD>
													<TD width="25%"><asp:label id="lblRichiedente" runat="server"></asp:label></TD>
													<TD width="25%">GRUPPO RICHIEDENTE:</TD>
													<TD><asp:label id="lblGruppo" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD width="25%">TELEFONO RICHIEDENTE:</TD>
													<TD width="25%"><asp:label id="lblteleric" runat="server"></asp:label></TD>
													<TD width="25%">EMAIL RICHIEDENTE:</TD>
													<TD><asp:label id="lblemailric" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD>STANZA RICHIEDENTE:</TD>
													<TD colSpan="3"><asp:label id="lblstanzaric" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD></TD>
													<TD></TD>
													<TD></TD>
													<TD></TD>
												</TR>
											</TBODY>
										</TABLE>
									</DIV>
								</td>
							</TR>
							<TR>
								<td colSpan="2">
									<DIV style="BORDER-BOTTOM: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-RIGHT: black 1px solid">
										<TABLE border="0" cellSpacing="1" cellPadding="1" width="100%">
											<TBODY>
												<tr>
													<TD class="TitleSearch" vAlign="middle" colSpan="4">DATI UBICAZIONE:</TD>
												</tr>
												<TR>
													<TD width="25%">CODICE EDIFICIO:</TD>
													<TD width="25%"><asp:label id="lblCodiceEdificio" runat="server"></asp:label></TD>
													<TD width="25%">DENOMINAZIONE:</TD>
													<TD><asp:label id="lblDenominazione" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD>PIANO:</TD>
													<TD><asp:label id="lblpianoed" runat="server"></asp:label></TD>
													<TD><!--STANZA:--></TD>
													<TD><asp:label id="lblstanzaed" runat="server" Visible="False"></asp:label></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 14px">NOTA/AMBIENTE:</TD>
													<TD style="HEIGHT: 14px" colSpan="3"><asp:label id="lblNota" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD>INDIRIZZO:</TD>
													<TD colSpan="3"><asp:label id="lblIndirizzo" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD>COMUNE:</TD>
													<TD><asp:label id="lblComune" runat="server"></asp:label></TD>
													<TD>TELEFONO UBICAZIONE:</TD>
													<TD><asp:label id="lblTelefono" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD>DITTA:</TD>
													<TD><asp:label id="lblDitta" runat="server"></asp:label></TD>
													<TD>TELEFONO DITTA:</TD>
													<TD><asp:label id="lblTelefonoDitta" runat="server"></asp:label></TD>
												</TR>
											</TBODY>
										</TABLE>
									</DIV>
								</td>
							</TR>
							<TR>
								<td colSpan="2">
									<DIV style="BORDER-BOTTOM: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-RIGHT: black 1px solid">
										<TABLE border="0" cellSpacing="1" cellPadding="1" width="100%">
											<tr>
												<TD class="TitleSearch" vAlign="middle" colSpan="4">DATI RICHIESTA</TD>
											</tr>
											<TR>
												<TD style="HEIGHT: 14px" width="25%">DESCRIZIONE PROBLEMA/NOTE:</TD>
												<TD style="HEIGHT: 14px" colSpan="3"><asp:label id="lblDescrizione" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD width="25%"><!--PRIORITA':--></TD>
												<TD colSpan="3"><asp:label id="lblUrgenza" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD width="25%">SERVIZIO:</TD>
												<TD colSpan="3"><asp:label id="lblServizio" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD width="25%"><SPAN><!--STD. APPARECCHIATURA:--></SPAN></TD>
												<TD colSpan="3"><asp:label id="lblEqStd" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD width="25%"><!--APPARECCHIATURA:--></TD>
												<TD colSpan="3"><asp:label id="lblEqId" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<!--<TD width="25%">CAUSA PRESUNTA GUASTO:</TD>-->
												<TD colSpan="3"><asp:label id="LblAnomalia" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<!--<TD width="25%">EFFETTO DEL GUASTO:</TD>-->
												<TD colSpan="3"><asp:label id="LblEffetto" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD width="25%"><!--TIPO MANUTENZIONE:--></TD>
												<TD colSpan="3"><asp:label id="lblTipoIntervento" runat="server" Visible="False"></asp:label><INPUT style="WIDTH: 8px; HEIGHT: 18px" id="HidTipInter" size="1" type="hidden" name="HidTipInter"
														runat="server"></TD>
											</TR>
										</TABLE>
									</DIV>
								</td>
							</TR>
							<TR>
								<td colSpan="2">
									<DIV style="BORDER-BOTTOM: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-RIGHT: black 1px solid">
										<TABLE style="DISPLAY: none" border="0" cellSpacing="1" cellPadding="1" width="100%">
											<tr>
												<TD class="TitleSearch" vAlign="middle" colSpan="6">A SEGUITO DI</TD>
											</tr>
											<TR id="aseguito1">
												<TD style="WIDTH: 210px"><asp:checkbox id="ChkConduzione" runat="server" Text="Conduzione"></asp:checkbox></TD>
												<asp:panel id="Conduzione" runat="server">
													<TD style="WIDTH: 127px">In data:
													</TD>
													<TD style="WIDTH: 121px">
														<asp:label id="CPConduzioneData" runat="server"></asp:label></TD>
													<TD style="WIDTH: 84px">Ora:
													</TD>
													<TD style="WIDTH: 117px">
														<asp:label id="TxtOraAseguito" runat="server"></asp:label></TD>
												</asp:panel></TR>
											<TR id="aseguito2">
												<TD style="WIDTH: 210px">A seguito di</TD>
												<TD style="WIDTH: 127px"><asp:label id="CmbASeguito" runat="server"></asp:label></TD>
												<TD style="WIDTH: 121px">DIE</TD>
												<TD style="WIDTH: 84px"><asp:label id="TxtASeguito1" runat="server"></asp:label></TD>
												<TD style="WIDTH: 117px" id="data">Del</TD>
												<TD id="lbl"><asp:label id="CPAseguito" runat="server"></asp:label></TD>
											</TR>
											<TR id="aseguito3">
												<TD style="WIDTH: 210px"><asp:checkbox id="ChkSopralluogo" runat="server" Text="Richiesta di sopralluogo e valutazione tecnico economica"></asp:checkbox></TD>
												<asp:panel id="Sopralluogo" runat="server">
													<TD style="WIDTH: 127px">N°</TD>
													<TD style="WIDTH: 121px">
														<asp:label id="TxtSopralluogo" runat="server"></asp:label></TD>
													<TD style="WIDTH: 84px">Del
													</TD>
													<TD style="WIDTH: 117px">
														<asp:label id="CPSopralluogoDie" runat="server"></asp:label></TD>
												</asp:panel></TR>
											<TR id="aseguito4">
												<TD style="WIDTH: 210px">Sopralluogo effettuato in data</TD>
												<TD style="WIDTH: 127px"><asp:label id="CPSopralluogoData" runat="server"></asp:label></TD>
												<TD style="WIDTH: 121px">Da
													<asp:label id="TxtASeguito4" runat="server"></asp:label></TD>
											</TR>
										</TABLE>
									</DIV>
								</td>
							</TR>
							<TR>
								<TD style="HEIGHT: 1%" vAlign="top" width="10%" align="left"><cc1:s_button id="btnsNuova" tabIndex="2" runat="server" Text="Crea Altra Richiesta"></cc1:s_button></TD>
								<td style="HEIGHT: 22px"><cc1:s_button id="cmdApprova" runat="server" Visible="False" Text="Approva ed Emetti"></cc1:s_button><cc1:s_button id="btnModificaRDL" runat="server" Text="Modifica RDL"></cc1:s_button><asp:button id="BtSalvaSGA" runat="server" Visible="False" Text="Salva/Invia SGA" Width="120px"></asp:button><asp:textbox id="txtWrHidden" runat="server" Visible="False"></asp:textbox>
									<INPUT id="hidprog" style="WIDTH: 16px; HEIGHT: 18px" type="hidden" size="1" runat="server"
										NAME="hidBl_id"></td>
							</TR>
							<TR>
								<TD colspan="2" style="HEIGHT: 1%" vAlign="top" align="left">
									<hr noShade SIZE="1">
								</TD>
							</TR>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
