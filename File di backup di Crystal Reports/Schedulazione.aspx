<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="Schedulazione.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.Schedulazione" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Schedula</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" title="Schedula" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" height="95%">
						<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" align="center">
							<TR>
								<TD style="WIDTH: 5%; HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
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
										<TABLE id="tblSearch90" cellSpacing="1" cellPadding="1" border="0">
											<TR>
												<TD class="TitleOperazione" align="left"><BR>
													<A href="Schedula/Associazione_EQ_PMS.aspx">Associazione delle apparecchiature alle 
														Procedure di Manutenzione Programmata</A>
												</TD>
											</TR>
											<TR>
												<TD class="TitleOperazione" align="left"><BR>
													<A href="Impostazioni.aspx">Impostazioni Iniziali</A>
												</TD>
											</TR>
											<TR>
												<TD class="TitleOperazione" align="left"><BR>
													<A href="CreaPianoMP.aspx">Elabora il Piano della Manutenzione Programmata</A>
												</TD>
											</TR>
											<TR>
												<TD class="TitleOperazione" style="HEIGHT: 23px" align="left"><BR>
													<A href="Schedula/OttimizzaPiano.aspx">Ottimizza il Piano della Manutenzione 
														Programmata</A>
												</TD>
											</TR>
											<TR>
												<TD class="TitleOperazione" align="left"><BR>
													<A href="Schedula/CreaOttimizzaRDL_MP.aspx">Emetti Richieste di Lavoro</A>
												</TD>
											</TR>
											<TR>
												<TD class="TitleOperazione" align="left"><BR>
													<A href="Schedula/CreazioneODL_MP.aspx">Emetti Ordini di Lavoro</A>
												</TD>
											</TR>
											<TR>
												<TD class="TitleOperazione" align="left"><BR>
													<A href="Schedula/Rapportino.aspx">Stampa Rapportino Tecnico di Intervento</A>
												</TD>
											</TR>
										</TABLE>
									</asp:panel></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 1%" vAlign="top" align="right"><A class=GuidaLink href="<%= HelpLink %>" 
            target=_blank>Guida</A>
									<hr noShade SIZE="1">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
