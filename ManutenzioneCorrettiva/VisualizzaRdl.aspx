<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="VisualizzaRdl.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorretiva.VisualizzaRdl" %>
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
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colspan="2" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<tr>
					<td>
						<table width="90%" align="center">
							<TR>
								<TD colspan="2" style="HEIGHT: 1%" vAlign="top" align="left">
									<hr noShade SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD colspan="2">
									<TABLE id="tblSearch100" cellSpacing="1" cellPadding="1" border="0">
										<TR>
											<TD align="center" colSpan="4"></TD>
										</TR>
										<TR>
											<TD width="10%" colSpan="3" class="Title">OPERATORE:</TD>
											<TD><asp:Label id="lblOperatore" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="Title" colSpan="3">DATA:</TD>
											<td><asp:Label id="lblData" runat="server"></asp:Label></td>
										</TR>
										<tr>
											<TD class="Title" colSpan="3">ORA:</TD>
											<td><asp:Label id="lblOra" runat="server"></asp:Label></td>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colspan="2" align="center">&nbsp;</TD>
							</TR>
							<TR>
								<td colspan="2">
									<DIV style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid">
										<TABLE width="100%" border="0" cellSpacing="1" cellPadding="1">
											<TBODY>
												<tr>
													<TD class="TitleSearch" vAlign="middle" colSpan="4">DATI RICHIEDENTE</TD>
												</tr>
												<TR>
													<TD width="25%">RICHIEDENTE:</TD>
													<TD width="25%">
														<asp:Label id="lblRichiedente" runat="server"></asp:Label></TD>
													<TD width="25%">GRUPPO:</TD>
													<TD>
														<asp:Label id="lblGruppo" runat="server"></asp:Label></TD>
												</TR>
												<TR>
													<TD width="25%">TELEFONO RICHIEDENTE:</TD>
													<TD width="25%">
														<asp:Label id="lblteleric" runat="server"></asp:Label></TD>
													<TD width="25%">EMAIL:</TD>
													<TD>
														<asp:Label id="lblemailric" runat="server"></asp:Label></TD>
												</TR>
												<TR>
													<TD>STANZA:</TD>
													<TD colSpan="3">
														<asp:Label id="lblstanzaric" runat="server"></asp:Label></TD>
												</TR>
												<TR>
													<TD>NOTA:</TD>
													<TD colSpan="3">
														<asp:Label id="lblNota" runat="server"></asp:Label></TD>
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
								<td colspan="2">
									<DIV style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid">
										<TABLE width="100%" border="0" cellSpacing="1" cellPadding="1">
											<TBODY>
												<tr>
													<TD class="TitleSearch" vAlign="middle" colSpan="4">DATI UBICAZIONE:</TD>
												</tr>
												<TR>
													<TD width="25%">CODICE EDIFICIO:</TD>
													<TD width="25%">
														<asp:Label id="lblCodiceEdificio" runat="server"></asp:Label></TD>
													<TD width="25%">DENOMINAZIONE:</TD>
													<TD>
														<asp:Label id="lblDenominazione" runat="server"></asp:Label></TD>
												</TR>
												<TR>
													<TD>PIANO:</TD>
													<TD>
														<asp:Label id="lblpianoed" runat="server"></asp:Label></TD>
													<TD>STANZA:</TD>
													<TD>
														<asp:Label id="lblstanzaed" runat="server"></asp:Label></TD>
												</TR>
												<TR>
													<TD>INDIRIZZO:</TD>
													<TD colSpan="3">
														<asp:Label id="lblIndirizzo" runat="server"></asp:Label></TD>
												</TR>
												<TR>
													<TD>COMUNE:</TD>
													<TD>
														<asp:Label id="lblComune" runat="server"></asp:Label></TD>
													<TD>TELEFONO UBICAZIONE:</TD>
													<TD>
														<asp:Label id="lblTelefono" runat="server"></asp:Label></TD>
												</TR>
												<TR>
													<TD>DITTA:</TD>
													<TD>
														<asp:Label id="lblDitta" runat="server"></asp:Label></TD>
													<TD>TELEFONO DITTA:</TD>
													<TD>
														<asp:Label id="lblTelefonoDitta" runat="server"></asp:Label></TD>
												</TR>
											</TBODY>
										</TABLE>
									</DIV>
								</td>
							</TR>
							<TR>
								<td colspan="2">
									<DIV style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid">
										<TABLE width="100%" border="0" cellSpacing="1" cellPadding="1">
											<tr>
												<TD class="TitleSearch" vAlign="middle" colSpan="4">DATI RICHIESTA</TD>
											</tr>
											<TR>
												<TD width="25%">DESCRIZIONE:</TD>
												<TD colSpan="3">
													<asp:Label id="lblDescrizione" runat="server"></asp:Label></TD>
											</TR>
											<TR>
												<TD width="25%">URGENZA:</TD>
												<TD colSpan="3">
													<asp:Label id="lblUrgenza" runat="server"></asp:Label></TD>
											</TR>
											<TR>
												<TD width="25%">SERVIZIO:</TD>
												<TD colSpan="3">
													<asp:Label id="lblServizio" runat="server"></asp:Label></TD>
											</TR>
											<TR>
												<TD width="25%"><SPAN>STD. APPARECCHIATURA:</SPAN></TD>
												<TD colSpan="3">
													<asp:Label id="lblEqStd" runat="server"></asp:Label></TD>
											</TR>
											<TR>
												<TD width="25%">APPARECCHIATURA:</TD>
												<TD colSpan="3">
													<asp:Label id="lblEqId" runat="server"></asp:Label></TD>
											</TR>
										</TABLE>
									</DIV>
								</td>
							</TR>
							<TR>
								<TD style="HEIGHT: 1%" vAlign="top" align="left" width="10%">
									<cc1:s_button id="btnsNuova" tabIndex="2" runat="server" Text="Crea Altra Richiesta"></cc1:s_button></TD>
								<td><cc1:s_button id="cmdApprova" runat="server" Text="Approva ed Emetti"></cc1:s_button>
									<cc1:s_button id="btnModificaRDL" runat="server" Text="Modifica RDL"></cc1:s_button>
									<asp:TextBox id="txtWrHidden" runat="server" Visible="False"></asp:TextBox></td>
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
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
