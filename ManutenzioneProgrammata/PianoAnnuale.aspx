<%@ Page language="c#" Codebehind="PianoAnnuale.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.PianoAnnuale" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Piano Annuale</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
							<TR vAlign="top">
								<TD align="center" colSpan="1" rowSpan="1"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" CssClass="DataPanel75" TitleText="Ricerca" AllowTitleExpandCollapse="True"
										Collapsed="False" ExpandText="Espandi" CollapseText="Riduci" CollapseImageUrl="../Images/up.gif" ExpandImageUrl="../Images/down.gif" TitleStyle-CssClass="TitleSearch">
										<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
											<TR>
												<TD vAlign="top" align="center" colSpan="2">
													<uc1:RicercaModulo id="RicercaModulo1" runat="server"></uc1:RicercaModulo></TD>
											</TR>
											<asp:Panel id="PagePanel" Runat="server">
												<TR>
													<TD style="WIDTH: 15%"><SPAN>Anno di riferimento: </SPAN>
													</TD>
													<TD style="HEIGHT: 28px">
														<cc1:S_ComboBox id="cmbsAnno" runat="server" AutoPostBack="True" Width="230px"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 15%"><SPAN>Servizio: </SPAN>
													</TD>
													<TD style="HEIGHT: 28px">
														<cc1:S_ComboBox id="cmbsServizio" runat="server" AutoPostBack="True" Width="230px"></cc1:S_ComboBox></TD>
												</TR>
											</asp:Panel>
											<TR>
												<TD colSpan="2">&nbsp;
													<P></P>
													<TABLE id="Table1" style="HEIGHT: 19px" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD align="left" colSpan="3">
																<cc1:s_button id="btnsRicerca" tabIndex="2" runat="server" CssClass="btn" Text="Ricerca"></cc1:s_button>&nbsp;
																<asp:Button id="cmdReset" CssClass="btn" Runat="server" Text="Reset"></asp:Button></TD>
															<TD align="right"><A class=GuidaLink 
                        href="<%= HelpLink %>" 
                    target=_blank>Guida</A></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</COLLAPSE:DATAPANEL></TD>
							</TR>
							<TR vAlign="top">
								<TD vAlign="top" align="left"><asp:linkbutton id="lkbInfo" runat="server" CssClass="LabelInfo" CausesValidation="False">Legenda</asp:linkbutton><asp:panel id="pnlShowInfo" runat="server" CssClass="ShowInfoPanel350" Visible="False">
										<TABLE height="100%" width="100%">
											<TBODY>
												<TR>
													<TD class="TitleSearch" vAlign="top" align="right" colSpan="2" height="15"><asp:linkbutton id="lnkChiudi" runat="server" CssClass="LabelChiudi" CausesValidation="False">Chiudi</asp:linkbutton></TD>
												</TR>
												<TR>
													<TD vAlign="top"><asp:repeater id="rptFrequenze" runat="server">
															<HeaderTemplate>
																<TABLE class="BordiTabella" id="tblFrequenze" cellSpacing="0" cellPadding="2">
																	<tr class="tabblu">
																		<td colspan="2">Frequenze</td>
																	</tr>
																	<TR>
																		<TD class="BordiCellaTop"><FONT face="Arial" size="2">Frequenza</FONT></TD>
																		<TD class="BordiCellaRTop" bgColor="#ffffff"><FONT face="Arial" size="2">Descrizione</FONT></TD>
																	</TR>
															</HeaderTemplate>
															<ItemTemplate>
																<tr>
																	<TD class="BordiCella" align="center"><FONT face="Arial" size="2">
																			<%# DataBinder.Eval(Container.DataItem, "Freq") %>
																		</FONT>
																	</TD>
																	<TD class="BordiCellaR" bgColor="#ffffff"><FONT face="Arial" size="2">
																			<%# DataBinder.Eval(Container.DataItem, "Des") %>
																		</FONT>
																	</TD>
																</tr>
															</ItemTemplate>
															<FooterTemplate>
										</TABLE>
									</FooterTemplate> </asp:repeater></TD>
								<TD vAlign="top">
									<TABLE class="BordiTabella" id="tblInterventi" cellSpacing="0" cellPadding="2">
										<TR class="tabblu">
											<TD colSpan="2">Calendario</TD>
										<TR>
											<TD class="BordiCellaTop"><FONT face="Arial" size="2">Num. Interventi</FONT></TD>
											<TD class="BordiCellaRTop" bgColor="#ffffff"><FONT face="Arial" size="2">Colore</FONT></TD>
										</TR>
										<TR>
											<TD class="BordiCella" align="center"><FONT face="Arial" size="2">0-9</FONT></TD>
											<TD class="BordiCellaR" bgColor="#ffffff">&nbsp;</TD>
										</TR>
										<TR>
											<TD class="BordiCella" align="center"><FONT face="Arial" size="2">10-19</FONT></TD>
											<TD class="BordiCellaR" bgColor="#808080">&nbsp;</TD>
										</TR>
										<TR>
											<TD class="BordiCella" align="center" bgColor="#00ff00"><FONT face="Arial" size="2">20-29</FONT></TD>
											<TD class="BordiCellaR" bgColor="#00ff00">&nbsp;</TD>
										</TR>
										<TR>
											<TD class="BordiCella" align="center"><FONT face="Arial" size="2">30-39</FONT></TD>
											<TD class="BordiCellaR" bgColor="#008000">&nbsp;</TD>
										</TR>
										<TR>
											<TD class="BordiCella" align="center"><FONT face="Arial" size="2">40-49</FONT></TD>
											<TD class="BordiCellaR" bgColor="#0000ff">&nbsp;</TD>
										</TR>
										<TR>
											<TD class="BordiCella" align="center"><FONT face="Arial" size="2">50-59</FONT></TD>
											<TD class="BordiCellaR" bgColor="#000080">&nbsp;</TD>
										</TR>
										<TR>
											<TD class="BordiCella" align="center"><FONT face="Arial" size="2">60-69</FONT></TD>
											<TD class="BordiCellaR" bgColor="#c00000">&nbsp;</TD>
										</TR>
										<TR>
											<TD class="BordiCella" align="center"><FONT face="Arial" size="2">Altro</FONT></TD>
											<TD bgColor="#800000">&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						</asp:panel></TD>
				</TR>
				<tr>
					<TD vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" BorderColor="Gray" BorderWidth="1px"
							AutoGenerateColumns="False" GridLines="Vertical" AllowPaging="True">
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="3%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton id="lnkDett" Runat=server CommandName="Dettaglio" ImageUrl="~/images/edit.gif" CommandArgument='<%# "DettPianoAnnuale.aspx?FUNID=" + FunId +"&ID_BL=" + DataBinder.Eval(Container.DataItem,"ID") + "&anno=" + DataBinder.Eval(Container.DataItem,"ANNO") + "&servizio=" + DataBinder.Eval(Container.DataItem,"IDSERVIZIO")%>'>
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="EDIFICIO" HeaderText="EDIFICIO"></asp:BoundColumn>
								<asp:BoundColumn DataField="NOME" HeaderText="NOME EDIFICIO"></asp:BoundColumn>
								<asp:BoundColumn DataField="INDIRIZZO" HeaderText="INDIRIZZO"></asp:BoundColumn>
								<asp:BoundColumn DataField="SERVIZIO" HeaderText="SERVIZIO"></asp:BoundColumn>
								<asp:BoundColumn DataField="GEN" HeaderText="GEN">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FEB" HeaderText="FEB">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MAR" HeaderText="MAR">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="APR" HeaderText="APR">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MAG" HeaderText="MAG">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="GIU" HeaderText="GIU">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="LUG" HeaderText="LUG">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AGO" HeaderText="AGO">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SET" HeaderText="SET">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OTT" HeaderText="OTT">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NOV" HeaderText="NOV">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DIC" HeaderText="DIC">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</tr>
			</TABLE>
			</TD></TR></TBODY></TABLE>&nbsp;
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
