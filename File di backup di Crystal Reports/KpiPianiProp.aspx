<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Page language="c#" Codebehind="KpiPianiProp.aspx.cs" AutoEventWireup="false" Inherits="TheSite.SoddisfazioneCliente.KpiPianiProp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>KpiPianiProp</title>
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
									<td>&nbsp;Mese:
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
									<TD><CC1:S_BUTTON id="btnsRicerca" tabIndex="4" runat="server" cssclass="btn" text="Ricerca"></CC1:S_BUTTON><CC1:S_BUTTON id="btnReset" tabIndex="5" runat="server" cssclass="btn" text="Reset"></CC1:S_BUTTON></TD>
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
											<table id="fuoriSLA" width="100%" runat="server">
												<TBODY>
													<tr>
														<td><!-- prima tabella -->
															<FONT size="3">Intestazione descrittiva dei dati</FONT></td>
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
																		<td><%# DataBinder.Eval(Container.DataItem, "priorità") %></td>
																		<td><%# DataBinder.Eval(Container.DataItem, "wr_pres") %></td>
																		<td><%# DataBinder.Eval(Container.DataItem, "wr_no_pres") %></td>
																		<td><%# DataBinder.Eval(Container.DataItem, "wr_tot") %></td>
																		<td><%# DataBinder.Eval(Container.DataItem, "fuoriSLA") %></td>
																		<td><%# DataBinder.Eval(Container.DataItem, "bl_id") %></td>
																	</tr>
																</ItemTemplate>
																<FooterTemplate>
											</table>
											</FooterTemplate> </asp:repeater>
										</td> <!--   ************ invertire la td   -->
									</tr>
									<!--		</td>    		************    ???????    -->
									<!--		</tr>		 	************    ???????    -->
								</TBODY>
							</table>
							<TABLE> <!--fine prima tabella -->
							<!--   ------------------------------------------------------------------------    -->
							************ manca una
						</td>
						e
					</tr>
					<tr>
						<td>
							&nbsp;
						</td>
					</tr>
					<tr>
						<td>
							<!--   ------------------------------------------------------------------------    -->
							<table id="pianiMens" width="100%" runat="server">
								<TBODY>
									<tr>
										<td><!-- seconda tabella -->
											<FONT size="3">Intestazione descrittiva dei dati</FONT></td>
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
													</tr>
												</ItemTemplate>
												<FooterTemplate>
							</table>
							</FooterTemplate> </asp:repeater></td>
					</tr>
				<!--	</TD>			************    ???????    -->
				<!--    </TR>		        ************    ???????    -->
			</TABLE> <!-- fine seconda tabella -->
			<!--   ------------------------------------------------------------------------    --> 
			</TD>e </TR> 
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
					<table id="totAtt" width="100%" runat="server">
						<TBODY>
							<tr>
								<td><!-- terza tabella -->
									<FONT size="3">Slittamento attivita'</FONT></td>
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
												<td><b>Eseguite entro 100gg:</b></td>
												<td align="right">&nbsp;<%# DataBinder.Eval(Container.DataItem, "nei100gg") %></td>
											</tr>
											<tr>
												<td><b>Risultato KPI</b></td>
												<td></td>
											</tr>
										</ItemTemplate>
										<FooterTemplate>
					</table>
					</FooterTemplate> </asp:repeater></td>
			</tr>
			<!--		</TD></TR>      ************    ???????    --> </TBODY></TABLE><!-- fine terza tabella -->
			<!--   ------------------------------------------------------------------------    --> 
			</TD></TR></TBODY></TABLE> 
			<!-- Fine Tabella tbDati  --> </TD></TR> 
			<!--   fine tabella tbDati--------------------------------------------------------------------- --> 
			</TBODY></TABLE></form>
		</TR></TBODY></TABLE>
	</body>
</HTML>
