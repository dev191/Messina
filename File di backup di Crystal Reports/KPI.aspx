<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="KPI.aspx.cs" AutoEventWireup="false" Inherits="TheSite.SoddisfazioneCliente.KPI" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>KPI</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px"
				cellSpacing="0" cellPadding="0" align="center" border="0">
				<TBODY>
					<tr>
						<td align="center"><UC1:PAGETITLE id="PageTitle1" runat="server"></UC1:PAGETITLE></td>
					</tr>
					<tr>
						<td><uc1:ricercamodulo id="RicercaModulo1" runat="server"></uc1:ricercamodulo></td>
					</tr>
					<tr>
						<td>
							<table class="tblSearch100Dettaglio" style="WIDTH: 100%" cellSpacing="1" cellPadding="1"
								border="0">
								<tr>
									<td>Priorità:
										<asp:dropdownlist id="DrPriorita" runat="server" Width="176px">
											<asp:ListItem Value="0">- Nessuna Selezione -</asp:ListItem>
											<asp:ListItem Value="1">Emergenza</asp:ListItem>
											<asp:ListItem Value="2">Critici</asp:ListItem>
											<asp:ListItem Value="3">Urgente</asp:ListItem>
										</asp:dropdownlist>&nbsp;Mese:
										<asp:dropdownlist id="DrMese" runat="server" Width="176px">
											<asp:ListItem Value="01">Gennaio</asp:ListItem>
											<asp:ListItem Value="02">Febbraio</asp:ListItem>
											<asp:ListItem Value="03">Marzo</asp:ListItem>
											<asp:ListItem Value="04">Aprile</asp:ListItem>
											<asp:ListItem Value="05">Maggio</asp:ListItem>
											<asp:ListItem Value="06">Giugno</asp:ListItem>
											<asp:ListItem Value="07">Luglio</asp:ListItem>
											<asp:ListItem Value="08">Agosto</asp:ListItem>
											<asp:ListItem Value="09">Settembre</asp:ListItem>
											<asp:ListItem Value="10">Ottobre</asp:ListItem>
											<asp:ListItem Value="11">Novembre</asp:ListItem>
											<asp:ListItem Value="12">Dicembre</asp:ListItem>
										</asp:dropdownlist>&nbsp;Anno:
										<asp:dropdownlist id="DropAnno" runat="server" Width="176px"></asp:dropdownlist></td>
									<td></td>
									<td></td>
									<td></td>
									<TD></TD>
									<TD></TD>
								</tr>
								<TR>
									<TD><CC1:S_BUTTON id="btnsRicerca" tabIndex="4" runat="server" text="Ricerca" cssclass="btn"></CC1:S_BUTTON><CC1:S_BUTTON id="btnReset" tabIndex="5" runat="server" text="Reset" cssclass="btn"></CC1:S_BUTTON></TD>
									<TD></TD>
									<TD></TD>
									<TD></TD>
									<TD></TD>
									<TD></TD>
								</TR>
							</table>
						</td>
					</tr>
					<!--   inzio tabella dati -->
					<tr>
						<td>
							<!-- Inizio Tabella tbDati ---------------------------------------------------------------------  -->
							<table id="tbDati" width="100%">
								<TBODY>
									<tr>
										<td>
											<!--   ------------------------------------------------------------------------    -->
											<table id="tblFuoriSLA" width="100%" runat="server">
												<TBODY>
													<tr>
														<td><!-- prima tabella --><FONT size="3">Nr Attività presidio/no presidio</FONT></td>
													</tr>
													<tr>
														<td><asp:repeater id="Repeater1" runat="server">
																<HeaderTemplate>
																	<table border="1" cellpadding="1" cellspacing="0" bordercolor="Gainsboro">
																		<tr>
																			<td><b>Edificio</b></td>
																			<td><b>Priorità</b></td>
																			<td><b>N. Tot ODL con Presidio</b></td>
																			<td><b>N. Tot ODL senza Presidio</b></td>
																			<td><b>Totale ODL</b></td>
																			<td><b>N. Odl fuori SLA ODL</b></td>
																			<td><b>Risultato KPI</b></td>
																		</tr>
																</HeaderTemplate>
																<ItemTemplate>
																	<tr>
																		<td><%# DataBinder.Eval(Container.DataItem, "bl_id") %></td>
																		<td><%# DataBinder.Eval(Container.DataItem, "priorita") %></td>
																		<td><%# DataBinder.Eval(Container.DataItem, "wr_pres") %></td>
																		<td><%# DataBinder.Eval(Container.DataItem, "wr_no_pres") %></td>
																		<td><%# DataBinder.Eval(Container.DataItem, "wr_tot") %></td>
																		<td><%# DataBinder.Eval(Container.DataItem, "fuoriSLA") %></td>
																		<td><%# RisultatoKPI( DataBinder.Eval(Container.DataItem, "fuoriSLA"),DataBinder.Eval(Container.DataItem, "wr_tot")) %></td>
																	</tr>
																</ItemTemplate>
																<FooterTemplate>
																	<tr style="FONT-WEIGHT: bold">
																		<td colspan="2"><b>Priorità</b></td>
																		<td><b>N. Tot ODL con Presidio</b></td>
																		<td><b>N. Tot ODL senza Presidio</b></td>
																		<td><b>Totale ODL</b></td>
																		<td><b>N. Odl fuori SLA ODL</b></td>
																		<td><b>Risultato KPI</b></td>
																	</tr>
																	<tr style="FONT-WEIGHT: bold">
																		<td colspan="2"><%#TPriorita%></td>
																		<td><%#Twr_pres%></td>
																		<td><%#Twr_no_pres%></td>
																		<td><%#Twr_tot%></td>
																		<td><%#TfuoriSLA%></td>
																		<td><%#Trisultato %>%</td>
																	</tr>
																	<tr style="FONT-WEIGHT: bold">
																		<td colspan="2"><%#TPriorita1%></td>
																		<td><%#Twr_pres1%></td>
																		<td><%#Twr_no_pres1%></td>
																		<td><%#Twr_tot1%></td>
																		<td><%#TfuoriSLA1%></td>
																		<td><%#Trisultato1 %>%</td>
																	</tr>
																	<tr style="FONT-WEIGHT: bold">
																		<td colspan="2"><%#TPriorita2%></td>
																		<td><%#Twr_pres2%></td>
																		<td><%#Twr_no_pres2%></td>
																		<td><%#Twr_tot2%></td>
																		<td><%#TfuoriSLA2%></td>
																		<td><%#Trisultato2%>%</td>
																	</tr>
											</table>
											</FooterTemplate> </asp:repeater></td>
									</tr>
									<!--		</td>    		************    ???????    -->
									<!--		</tr>		 	************    ???????    --></TBODY></table>
							<TABLE> <!--fine prima tabella -->
							<!--   ------------------------------------------------------------------------    -->
							<!--	************ manca una   --></td>
					</tr>
					<tr>
						<td>&nbsp;
						</td>
					</tr>
					<tr>
						<td>
							<!--   ------------------------------------------------------------------------    -->
							<table id="tblPianiMens" width="100%" runat="server">
								<TBODY>
									<tr>
										<td><!-- seconda tabella --><FONT size="3">Piani Proposti/Eseguiti</FONT></td>
									</tr>
									<tr>
										<td><asp:repeater id="Repeater2" runat="server">
												<HeaderTemplate>
													<table border="1" cellpadding="1" cellspacing="0" bordercolor="Gainsboro">
														<tr>
															<td><b>N. PP Inviati</b></td>
															<td><b>N. PP Inviati oltre la data</b></td>
															<td><b>N. PE Inviati</b></td>
															<td><b>N. PE Inviati oltre la data </b>
															</td>
															<td><b>Risultato KPI</b></td>
														</tr>
												</HeaderTemplate>
												<ItemTemplate>
													<tr>
														<td><%# DataBinder.Eval(Container.DataItem, "totPropInv") %></td>
														<td><%# DataBinder.Eval(Container.DataItem, "proFuoriData") %></td>
														<td><%# DataBinder.Eval(Container.DataItem, "totEsegInviati") %></td>
														<td><%# DataBinder.Eval(Container.DataItem, "esegFuoriData") %></td>
														<td><%#Risultato(DataBinder.Eval(Container.DataItem, "totPropInv"),DataBinder.Eval(Container.DataItem, "proFuoriData"),DataBinder.Eval(Container.DataItem, "totEsegInviati"),DataBinder.Eval(Container.DataItem, "esegFuoriData") )%>%</td>
													</tr>
												</ItemTemplate>
												<FooterTemplate>
							</table>
							</FooterTemplate> </asp:repeater></td>
					</tr>
				<!--	</TD>			************    ???????    -->
				<!--    </TR>		        ************    ???????    --></TABLE> <!-- fine seconda tabella -->
			<!--   ------------------------------------------------------------------------    --> 
			</TD></TR> 
			<!--	************ manca una </TD>  e   </tr>  -->
			<tr>
				<!--    ************    MANCAVA LA CELLA
				&nbsp;
	        ************    MANCA LA CELLA         -->
				<TD></TD>
			</tr>
			<tr>
				<td>
					<!--   ------------------------------------------------------------------------    -->
					<table id="tblTotAtt" width="100%" runat="server">
						<TBODY>
							<tr>
								<td><!-- terza tabella --><FONT size="3">Slittamento attivita'</FONT></td>
							</tr>
							<tr>
								<td><asp:repeater id="Repeater3" runat="server">
										<HeaderTemplate>
											<table border="1" cellpadding="1" cellspacing="0" bordercolor="Gainsboro">
												<tr>
												</tr>
										</HeaderTemplate>
										<ItemTemplate>
											<tr>
												<td><b>Totale righe di attivita' PP:</b></td>
												<td align="right">&nbsp;<%# DataBinder.Eval(Container.DataItem, "totAtt") %></td>
											</tr>
											<tr>
												<td><b>Eseguite nei tempi previsti:</b></td>
												<td align="right">&nbsp;<%# DataBinder.Eval(Container.DataItem, "neiTempi") %></td>
											</tr>
											<tr>
												<td><b>Eseguite entro 10gg:</b></td>
												<td align="right">&nbsp;<%# DataBinder.Eval(Container.DataItem, "nei100gg") %></td>
											</tr>
											<tr>
												<td><b>Risultato KPI entro 10gg</b></td>
												<td><%#			RisSlittamentoEnto10(DataBinder.Eval(Container.DataItem, "totAtt") ,DataBinder.Eval(Container.DataItem, "neiTempi"),DataBinder.Eval(Container.DataItem, "nei100gg") )%>%</td>
											</tr>
											<tr>
												<td><b>Risultato KPI </b>
												</td>
												<td><%#RisSlittamento(DataBinder.Eval(Container.DataItem, "neiTempi") ,DataBinder.Eval(Container.DataItem, "totAtt") )%>%</td>
											</tr>
										</ItemTemplate>
										<FooterTemplate>
					</table>
					</FooterTemplate> </asp:repeater></td>
			</tr>
			<!--		</TD></TR>      ************    ???????    --> </TBODY></TABLE><!-- fine terza tabella -->
			<!--   ------------------------------------------------------------------------    -->
			<TABLE id="TabXLS" width="100%" runat="server">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 5px"><!-- seconda tabella --><FONT size="3">Consuntivazione 
								trimestrale</FONT></TD>
					</TR>
					<TR>
						<TD>
							<asp:repeater id="RepeaterXls" runat="server">
								<HeaderTemplate>
									<table border="1" cellpadding="1" cellspacing="0" bordercolor="Gainsboro">
										<tr>
											<td><b>Sede</b></td>
											<td><b>Codice</b></td>
											<td><b>Data Invio</b></td>											
										</tr>
								</HeaderTemplate>
								<ItemTemplate>
									<tr>
										<td><%# DataBinder.Eval(Container.DataItem, "codice_bl") %></td>
										<td><%# DataBinder.Eval(Container.DataItem, "codice") %></td>
										<td><%# DataBinder.Eval(Container.DataItem, "data_invio") %></td>
									</tr>
								</ItemTemplate>
								<FooterTemplate>
			</TABLE>
			</FooterTemplate> </asp:repeater></TD></TR><!--	</TD>			************    ???????    -->  <!--    </TR>		        ************    ???????    --> 
			</TBODY></TABLE></TD></TR>
			<TR>
				<TD>
					<TABLE id="TabREI" width="100%" runat="server">
						<TBODY>
							<TR>
								<TD><!-- terza tabella --><FONT size="3">Porte REI</FONT></TD>
							</TR>
							<TR>
								<TD><asp:repeater id="RepeaterREI" runat="server">
										<HeaderTemplate>
											<table border="1" cellpadding="1" cellspacing="0" bordercolor="Gainsboro">
												<tr>
												</tr>
										</HeaderTemplate>
										<ItemTemplate>
											<tr>
												<td><b>N. Totale ODL interventi su porte REI:</b></td>
												<td align="right">&nbsp;<%# DataBinder.Eval(Container.DataItem, "totrei") %></td>
											</tr>
											<tr>
												<td><b>N. ODL con tempo di intervento superiore allo SLA:</b></td>
												<td align="right">&nbsp;<%# DataBinder.Eval(Container.DataItem, "totreiintsla") %></td>
											</tr>
											<tr>
												<td><b>Risultato KPI:</b></td>
												<td align="right">&nbsp;<%#  RisRei(DataBinder.Eval(Container.DataItem, "totrei"),DataBinder.Eval(Container.DataItem, "totreiintsla"))  %>%</td>
											</tr>
											<tr>
												<td><b>N. Totale ODL interventi su porte REI:</b></td>
												<td align="right">&nbsp;<%# DataBinder.Eval(Container.DataItem, "totrei") %></td>
											</tr>
											<tr>
												<td><b>N. ODL con tempo di risoluzione superiore allo SLA:</b></td>
												<td align="right">&nbsp;<%# DataBinder.Eval(Container.DataItem, "totreirissla") %></td>
											</tr>
											<tr>
												<td><b>Risultato KPI:</b></td>
												<td align="right">&nbsp;<%#  RisRei(DataBinder.Eval(Container.DataItem, "totrei"),DataBinder.Eval(Container.DataItem, "totreirissla")) %>%</td>
											</tr>
										</ItemTemplate>
										<FooterTemplate>
					</TABLE>
					</FooterTemplate> </asp:repeater></TD>
			</TR> <!--		</TD></TR>      ************    ???????    --> 
			</TBODY></TABLE></TD></TR></TBODY></TABLE> 
			<!-- Fine Tabella tbDati  --> 
			</TD></TR> 
			<!--   fine tabella tbDati--------------------------------------------------------------------- --> 
			</TBODY></TABLE></form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
