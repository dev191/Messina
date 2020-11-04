<%@ Register TagPrefix="uc1" TagName="CostiManodopera" Src="../WebControls/CostiManodopera.ascx" %>
<%@ Page language="c#" Codebehind="AnalisiCostiOperativiDiGestioneDettaglio.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorrettiva.AnalisiCostiOperativiDiGestioneDettaglio" uiCulture="it"%>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="materiali" Src="../WebControls/materiali.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>AnalisiMaterialiImpiegati</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD><UC1:PAGETITLE id="PgTitleCostiGestioneDettaglio" runat="server"></UC1:PAGETITLE></TD>
					</TR>
					<tr>
						<td>
							<TABLE id="tblSearch100" cellSpacing="1" cellPadding="1" width="100%">
								<tr>
									<td><strong>OdL°&nbsp;</strong>
										<asp:Label id="LblOdL" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<strong>RdL</strong>
										<asp:Label id="LblRdL" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<strong>Urgenza</strong>
										<asp:Label id="LblUrgenza" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<strong>Richiedente</strong>
										<asp:Label id="LblRichiedente" runat="server"></asp:Label>; Tel:
										<asp:Label id="LblTelefono" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td colspan="2"><strong>Data e ora Richiesta:</strong>
										<asp:Label id="LblDataRichiesta" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td colspan="2"><strong>Fabbricato: </strong>
										<asp:Label id="LblFabbricato" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td colspan="2"><strong>Servizi: </strong>
										<asp:Label id="LblServizi" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td colspan="2"><strong>Descrizione Intervento:</strong>
										<asp:Label id="LblDescIntervento" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td colspan="2" style="HEIGHT: 10px"><strong>Data e ora Pianificata: </strong>
										<asp:Label id="LblDataPianificata" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td colspan="2"><strong>Data e ora Inizio:</strong>
										<asp:Label id="LblDataInizio" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td colspan="2"><strong>Data e ora Fine: </strong>
										<asp:Label id="LblDataFine" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td colspan="2"><strong>Stato Richiesta:</strong>
										<asp:Label id="LblStatoRic" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td colspan="2"><strong>Addetto:</strong>
										<asp:Label id="LblAddetto" runat="server"></asp:Label></td>
								</tr>
								<tr runat="server" id="TrMs">
									<td colspan="2" style="HEIGHT: 54px">
										<table width="100%">
											<tr>
												<td colspan="2"><strong>Tipo Intervento:</strong>
													<asp:Label id="LblTipoIntervento" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td colspan="2"><strong>Spesa Presunta: </strong>
													<asp:Label id="LblSpesaPresunta" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td colspan="2"><strong>Ordine di lavoro Committente: </strong>
													<asp:Label id="LblOdLCommit" runat="server"></asp:Label></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td colspan="2"><strong>Annotazioni Materiali Utilizzato: </strong>
										<asp:Label id="LblAnnMatUtil" runat="server"></asp:Label></td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD width="100%"><CC2:DATAPANEL id="DataPanelRicerca1" runat="server" allowtitleexpandcollapse="True" collapseimageurl="../Images/up.gif"
								cssclass="DataPanel75" collapsetext="Nascondi Costi Manodopera impiegata" expandimageurl="../Images/down.gif"
								expandtext="Visualizza Costi Manodopera impiegata" titletext="Costi Manodopera Impiegata " collapsed="False"
								titlestyle-cssclass="TitleSearch">
								<UC1:COSTIMANODOPERA id="cstAddetti" runat="server"></UC1:COSTIMANODOPERA>
							</CC2:DATAPANEL>
						</TD>
					</TR>
					<tr>
						<td style="HEIGHT: 13px">&nbsp;</td>
					</tr>
					<TR>
						<TD width="100%">
							<CC2:DATAPANEL id="DataPanelRicerca" runat="server" allowtitleexpandcollapse="True" collapseimageurl="../Images/up.gif"
								cssclass="DataPanel75" collapsetext="Nascondi Materiali Impiegati" expandimageurl="../Images/down.gif"
								expandtext="Visualizza Materiali Impiegati" titletext="Costi Materiali Impiegati " collapsed="False"
								titlestyle-cssclass="TitleSearch">
								<UC1:MATERIALI id="mtImpegnati" runat="server" width="100%"></UC1:MATERIALI>
							</CC2:DATAPANEL></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 25px" width="100%">TOTALE&nbsp;COSTI OPERATIVI DI GESTIONE&nbsp;
							<asp:Literal id="LblTotale" runat="server"></asp:Literal></TD>
					</TR>
					<TR>
						<TD>
							<ASP:BUTTON id="btnChiudi" runat="server" text="Chiudi" cssclass="btn" Visible="false"></ASP:BUTTON></TD>
					</TR>
					<tr>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td>
							<asp:Button id="BntIndietro" runat="server" Text="Indietro"></asp:Button>
						</td>
					</tr>
				</TBODY>
			</TABLE>
		</FORM>
		<script language="javascript">
		parent.left.calcola();
		function Totale()
		{
			var appo=(document.getElementById('mtImpegnati_lblTot').innerText);
			var appo1 =appo.replace(',','.');
			var tot= parseFloat(appo1);
			
			var appo2=(document.getElementById('cstAddetti_lblTot1').innerText);
			var appo3 =appo.replace(',','.');
			var tot1= parseFloat(appo2);
					
			var totale=tot+tot1;
			//alert(totale);
			document.getElementById('LblTotale').innerText=tot+tot1;			
		}
		Totale();
		</script>
	</body>
</HTML>
