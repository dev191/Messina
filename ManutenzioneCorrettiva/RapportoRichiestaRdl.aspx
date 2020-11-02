<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Page language="c#" Codebehind="RapportoRichiestaRdl.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorretiva.RapportoRichiestaRdl" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RapportoRichiestaRdl</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		 function stampa(sender)
		 {
		  sender.style.visibility = 'hidden'
		  document.getElementById('<%=btApprova.ClientID%>').style.visibility = 'hidden'
		  document.getElementById('<%=btCrea.ClientID%>').style.visibility = 'hidden'
		  window.print()
		  sender.style.visibility = 'visible'
		  document.getElementById('<%=btApprova.ClientID%>').style.visibility = 'visible'
		  document.getElementById('<%=btCrea.ClientID%>').style.visibility = 'visible' 
		 }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101" cellSpacing="1" cellPadding="1" width="100%" align="center"
				border="0">
				<TR>
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD align="left">
						<TABLE cellSpacing="0" cellPadding="0" width="95%" align="left" border="0">
							<!-- Prima Riga-->
							<TR>
								<TD align="left" colSpan="2">
									<table align="left" border="0">
										<TR>
											<TD align="center"><cc1:s_label id="lblRdl" runat="server" ForeColor="Red"></cc1:s_label></TD>
										</TR>
										<tr>
											<td align="center"><b>AZIENDA TERRITORIALE PER L'EDILIZIA
													<br>
													RESIDENZIALE PUBBLICA DELLA PROVINCIA DI ROMA </b>
											</td>
										</tr>
										<tr>
											<td align="center">Servizio Manutenzione e Recupero - Sezione Impianti -
											</td>
										</tr>
										<tr>
											<td align="center">Via delle vigne nuove, 654 - 00139 ROMA - tel. 06/87148647 - FAX 
												06/87141678
											</td>
										</tr>
									</table>
								</TD>
							</TR>
							<TR align="center">
								<td style="BORDER-RIGHT: #000099 1px solid; BORDER-TOP: #000099 1px solid; BORDER-LEFT: #000099 1px solid; HEIGHT: 48px"
									align="left" colSpan="2">
									<table id="rapporto" cellSpacing="6" cellPadding="0" width="100%" border="0">
										<tr>
											<td style="BORDER-BOTTOM: #000099 1px solid"><b>Ord. N°<%=Ordine%>
												</b>
											</td>
											<td style="BORDER-BOTTOM: #000099 1px solid"><b>Scadenza</b></td>
											<td style="WIDTH: 268px; BORDER-BOTTOM: #000099 1px solid"><b>Richiesta Proroga al</b></td>
											<td style="BORDER-BOTTOM: #000099 1px solid"><b>Prorogato al</b></td>
										</tr>
										<!-- Seconda Riga-->
										<tr>
											<td style="BORDER-BOTTOM: #000099 1px solid"><b>Data Ini:</b>
												<%=DataIni%>
											</td>
											<td style="BORDER-BOTTOM: #000099 1px solid"><b>Data Fine:</b>
												<%=DataEnd%>
											</td>
											<td style="WIDTH: 268px; BORDER-BOTTOM: #000099 1px solid"><b>il D.L. </b>
											</td>
											<td style="BORDER-BOTTOM: #000099 1px solid"><b>Codice Impianto:</b>
												<%=Bl_id%>
												(<%=NomeEdificio%>
												)</td>
										</tr>
									</table>
								</td>
							</TR>
							<!-- Seconda Riga-->
							<TR>
								<td style="BORDER-RIGHT: #000099 1px solid; BORDER-LEFT: #000099 1px solid" colSpan="2">
									<table cellSpacing="6" cellPadding="0" width="100%" border="0">
										<tr>
											<td style="BORDER-BOTTOM: #000099 1px solid"><b>Comune:</b>
												<%=Comune%>
											</td>
											<td style="BORDER-BOTTOM: #000099 1px solid" colSpan="2"><b>Indirizzo:</b>
												<%=Indirizzo%>
											</td>
											<td style="BORDER-BOTTOM: #000099 1px solid"><b>Restituito:</b></td>
											<td style="BORDER-BOTTOM: #000099 1px solid"><b>Impresa:</b>&nbsp;Cofathec S.p.A</td>
										<tr>
										<tr>
											<td style="BORDER-BOTTOM: #000099 1px solid"><b>Pal:</b>
											</td>
											<td style="BORDER-BOTTOM: #000099 1px solid"><b>Sc:</b>
											</td>
											<td style="BORDER-BOTTOM: #000099 1px solid"><b>Int:</b></td>
											<td style="BORDER-BOTTOM: #000099 1px solid" colSpan="3"><b>Dir. Oper:</b></td>
										<tr>
										<tr>
											<td style="BORDER-BOTTOM: #000099 1px solid"><b>Inquilino:</b></td>
											<td style="BORDER-BOTTOM: #000099 1px solid" colSpan="2"><b>Tel.:</b>
											</td>
											<td style="BORDER-BOTTOM: #000099 1px solid"><b>Spesa Presunta:</b>
												<%=SpesaPresunta%>
											</td>
											<td style="BORDER-BOTTOM: #000099 1px solid" colSpan="2"><b>Il compilare:</b>
											</td>
										<tr>
										</tr>
									</table>
								</td>
							<tr>
								<td style="BORDER-RIGHT: #000099 1px solid; BORDER-LEFT: #000099 1px solid; BORDER-BOTTOM: #000099 1px solid"
									colSpan="2">
									<table cellSpacing="6" cellPadding="0" width="100%" border="0">
										<tr>
											<td><b>Richiesta Intervento per:</b></td>
										</tr>
										<tr>
											<td noWrap>
												<%=DescrizioneIntervento%>
											</td>
										</tr>
										<tr>
											<td style="BORDER-BOTTOM: #000099 1px solid">&nbsp;</td>
										</tr>
										<tr>
											<td style="BORDER-BOTTOM: #000099 1px solid">&nbsp;</td>
										</tr>
										<tr>
											<td style="BORDER-BOTTOM: #000099 1px solid">&nbsp;</td>
										</tr>
										<tr>
											<td style="BORDER-BOTTOM: #000099 1px solid">&nbsp;</td>
										</tr>
										<tr>
											<td style="BORDER-BOTTOM: #000099 1px solid">&nbsp;</td>
										</tr>
										<tr>
											<td style="BORDER-BOTTOM: #000099 1px solid">&nbsp;</td>
										</tr>
										<tr>
											<td style="BORDER-BOTTOM: #000099 1px solid">&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
				</TR>
			</TABLE>
			</TD></TR>
			<TR>
				<TD><cc1:s_button id="btApprova" runat="server" Width="168px" Text="Approva ed Emetti"></cc1:s_button>&nbsp;
					<cc1:s_button id="btCrea" runat="server" Width="168px" Text="Crea altra Richiesta"></cc1:s_button>&nbsp;<INPUT style="WIDTH: 168px" onclick="stampa(this)" type="button" value="Stampa">
					<asp:textbox id="txtWrHidden" runat="server" Width="48px" Visible="False"></asp:textbox></TD>
			</TR>
			</TABLE></form>
	</body>
</HTML>
