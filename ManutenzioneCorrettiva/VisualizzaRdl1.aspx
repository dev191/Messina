<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="VisualizzaRdl1.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorretiva.VisualizzaRdl1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>VisualizzaRdl</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" onbeforeunload="parent.left.valorizza()" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; TOP: 0px; LEFT: 0px"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="center" colSpan="2"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<tr>
					<td>
						<table width="90%" align="center">
							<TR>
								<TD style="HEIGHT: 1%" vAlign="top" align="left" colSpan="2">
									<hr noShade SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<TABLE id="tblSearch100" cellSpacing="1" cellPadding="1" border="0">
										<TR>
											<TD align="center" colSpan="8"></TD>
										</TR>
										<TR>
											<TD class="Title" width="10%" colSpan="3">OPERATORE:</TD>
											<TD colspan="5"><asp:label id="lblOperatore" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="Title" colSpan="3">DATA:</TD>
											<td><asp:label id="lblData" runat="server"></asp:label></td>
											<TD class="Title" colSpan="3">ORA:</TD>
											<td><asp:label id="lblOra" runat="server"></asp:label></td>
										</TR>
										<tr>
											<TD class="Title" colSpan="3">Numero Sga:</TD>
											<td><asp:label id="LblSga" runat="server"></asp:label></td>
											<TD class="Title" colSpan="3">Data Invio:</TD>
											<td><asp:label id="LblInvioSga" runat="server"></asp:label></td>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2">&nbsp;</TD>
							</TR>
							<TR>
								<td colSpan="2">
									<DIV style="BORDER-BOTTOM: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-RIGHT: black 1px solid">
										<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
											<TBODY>
												<tr>
													<TD class="TitleSearch" vAlign="middle" colSpan="4">DATI RICHIEDENTE</TD>
												</tr>
												<TR>
													<TD width="25%">RICHIEDENTE:</TD>
													<TD width="25%"><asp:label id="lblRichiedente" runat="server"></asp:label></TD>
													<TD width="25%">GRUPPO:</TD>
													<TD><asp:label id="lblGruppo" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD width="25%">TELEFONO RICHIEDENTE:</TD>
													<TD width="25%"><asp:label id="lblteleric" runat="server"></asp:label></TD>
													<TD width="25%">EMAIL:</TD>
													<TD><asp:label id="lblemailric" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD>STANZA/REPARTO:</TD>
													<TD colSpan="3"><asp:label id="lblstanzaric" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 14px">NOTA:</TD>
													<TD colSpan="3" style="HEIGHT: 14px"><asp:label id="lblNota" runat="server"></asp:label></TD>
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
										<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
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
													<TD>STANZA:</TD>
													<TD><asp:label id="lblstanzaed" runat="server"></asp:label></TD>
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
										<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
											<tr>
												<TD class="TitleSearch" vAlign="middle" colSpan="4">DATI RICHIESTA</TD>
											</tr>
											<TR>
												<TD width="25%" style="HEIGHT: 14px">DESCRIZIONE PROBLEMA/NOTE:</TD>
												<TD colSpan="3" style="HEIGHT: 14px"><asp:label id="lblDescrizione" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD width="25%">PRIORITA':</TD>
												<TD colSpan="3"><asp:label id="lblUrgenza" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD width="25%">SERVIZIO:</TD>
												<TD colSpan="3"><asp:label id="lblServizio" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD width="25%"><SPAN>STD. APPARECCHIATURA:</SPAN></TD>
												<TD colSpan="3"><asp:label id="lblEqStd" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD width="25%">APPARECCHIATURA:</TD>
												<TD colSpan="3"><asp:label id="lblEqId" runat="server"></asp:label></TD>
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
												<TD width="25%">TIPO MANUTENZIONE:</TD>
												<TD colSpan="3">
													<asp:label id="lblTipoIntervento" runat="server"></asp:label><INPUT id="HidTipInter" style="WIDTH: 8px; HEIGHT: 18px" type="hidden" size="1" name="HidTipInter"
														runat="server"></TD>
											</TR>
										</TABLE>
									</DIV>
								</td>
							</TR>
							<TR>
								<td colSpan="2">
									<DIV style="BORDER-BOTTOM: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-RIGHT: black 1px solid">
										<TABLE style="DISPLAY: none" cellSpacing="1" cellPadding="1" width="100%" border="0">
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
												</asp:panel>
											</TR>
											<TR id="aseguito2">
												<TD style="WIDTH: 210px">A seguito di</TD>
												<TD style="WIDTH: 127px"><asp:label id="CmbASeguito" runat="server"></asp:label>
												</TD>
												<TD style="WIDTH: 121px">DIE</TD>
												<TD style="WIDTH: 84px">
													<asp:label id="TxtASeguito1" runat="server"></asp:label>
												</TD>
												<TD id="data" style="WIDTH: 117px">Del</TD>
												<TD id="lbl">
													<asp:label id="CPAseguito" runat="server"></asp:label></TD>
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
												</asp:panel>
											</TR>
											<TR id="aseguito4">
												<TD style="WIDTH: 210px">Sopralluogo effettuato in data</TD>
												<TD style="WIDTH: 127px">
													<asp:label id="CPSopralluogoData" runat="server"></asp:label></TD>
												<TD style="WIDTH: 121px">Da
													<asp:label id="TxtASeguito4" runat="server"></asp:label>
												</TD>
											</TR>
										</TABLE>
									</DIV>
								</td>
							</TR>
							<TR>
								<TD style="HEIGHT: 1%" vAlign="top" align="left" width="10%">
									<cc1:s_button id="btnsNuova" tabIndex="2" runat="server" Text="Crea Altra Richiesta"></cc1:s_button></TD>
								<td style="HEIGHT: 22px"><cc1:s_button id="cmdApprova" runat="server" Text="Approva ed Emetti"></cc1:s_button>
									<cc1:s_button id="btnModificaRDL" runat="server" Text="Modifica RDL"></cc1:s_button>
									<asp:Button id="BtSalvaSGA" runat="server" Text="Salva/Invia SGA" Width="120px"></asp:Button>
									<asp:TextBox id="txtWrHidden" runat="server" Visible="False"></asp:TextBox>
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
