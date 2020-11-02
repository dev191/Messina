<%@ Page language="c#" Codebehind="IndicePrestazione.aspx.cs" AutoEventWireup="false" Inherits="TheSite.SoddisfazioneCliente.IndicePrestazione" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="RichiedentiSollecito" Src="../WebControls/RichiedentiSollecito.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Giudizio</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
 
			function EmesseSetVisible(state)
			{
			var DivRef = document.getElementById('PanelEmesse');
			var IfrRef = document.getElementById('DivEmesse');
			if(state)
			{
				DivRef.style.display = "block";
				IfrRef.style.width = DivRef.offsetWidth;
				IfrRef.style.height = DivRef.offsetHeight;
				IfrRef.style.top = DivRef.style.top;
				IfrRef.style.left = DivRef.style.left;
				IfrRef.style.zIndex = DivRef.style.zIndex - 1;
				IfrRef.style.display = "block";
			}
			else
			{
				DivRef.style.display = "none";
				IfrRef.style.display = "none";
			}
			   
			   
			}

		</SCRIPT>
	</HEAD>
	<BODY bottomMargin="0" onbeforeunload="parent.left.valorizza()" leftMargin="5" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px"
				cellSpacing="0" cellPadding="0" align="center" border="0">
				<TBODY>
					<TR>
						<TD align="center"><UC1:PAGETITLE id="PageTitle1" runat="server"></UC1:PAGETITLE></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="100%">
							<TABLE id="tblForm" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" align="center"
								border="0">
								<TBODY>
									<TR>
										<TD vAlign="top" width="100%"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" expandimageurl="../Images/down.gif" collapseimageurl="../Images/up.gif"
												collapsetext="Riduci" expandtext="Espandi" collapsed="False" allowtitleexpandcollapse="True" titletext="Ricerca" cssclass="DataPanel75"
												titlestyle-cssclass="TitleSearch">
												<TABLE style="WIDTH: 100%">
													<TBODY>
														<TR>
															<TD style="WIDTH: 100%" colSpan="4">
																<TABLE id="TableRicercaModulo" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" border="0">
																	<TR>
																		<TD><UC1:RICERCAMODULO id="RicercaModulo1" runat="server" Visible="False"></UC1:RICERCAMODULO></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD colSpan="4">
																<TABLE class="tblSearch100Dettaglio" style="WIDTH: 100%" cellSpacing="1" cellPadding="1"
																	border="0">
																	<TR>
																		<TD width="10%">Anno</TD>
																		<TD align="left" width="40%"><asp:dropdownlist id="cmbsAnno" runat="server" Width="200px"></asp:dropdownlist></TD>
																		<TD width="10%">Quadrimestre
																		</TD>
																		<TD align="left" width="40%"><asp:dropdownlist id="cmbQuadrimestre" runat="server" Width="200px">
																				<asp:ListItem Value="1">1&#176; Quadrimestre</asp:ListItem>
																				<asp:ListItem Value="2">2&#176; Quadrimestre</asp:ListItem>
																				<asp:ListItem Value="3">3&#176; Quadrimestre</asp:ListItem>
																				<asp:ListItem Value="0" Selected="True">-Intero Anno -</asp:ListItem>
																			</asp:dropdownlist></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD align="center" colSpan="4"><ASP:PANEL id="PanelServizio" runat="server">
																	<TABLE class="tblSearch100Dettaglio" id="Table2" style="WIDTH: 100%" cellSpacing="1" cellPadding="1"
																		border="0">
																		<TR>
																			<TD style="HEIGHT: 13px" width="10%">Indice Prestazione</TD>
																			<TD style="HEIGHT: 13px" align="left" width="40%">
																				<CC1:S_COMBOBOX id="cmbsIndice" runat="server" width="280px" dbsize="4" dbindex="10" autopostback="False"
																					dbdatatype="VarChar" DBDirection="ReturnValue">
																					<asp:ListItem Value="0">- Tutti gli Indice -</asp:ListItem>
																					<asp:ListItem Value="1">Indice 1</asp:ListItem>
																					<asp:ListItem Value="2">Indice tra 1 e 0,80</asp:ListItem>
																					<asp:ListItem Value="3">Indice tra 0,80 e 0,60</asp:ListItem>
																					<asp:ListItem Value="4">Indice inferiore 0,60</asp:ListItem>
																				</CC1:S_COMBOBOX></TD>
																			<TD style="HEIGHT: 16px"></TD>
																			<TD style="HEIGHT: 16px" align="left" width="40%">
																				<CC1:S_COMBOBOX id="cmbsPriorita" runat="server" Visible="False" width="280px" dbsize="4" dbindex="10"
																					autopostback="True" dbdatatype="Integer">
																					<asp:ListItem Value="0">- Nessun elemento selezionato -</asp:ListItem>
																				</CC1:S_COMBOBOX></TD>
																		</TR>
																	</TABLE>
																</ASP:PANEL></TD>
														</TR>
														<TR>
															<TD colSpan="4">&nbsp;</TD>
														</TR>
														<TR>
															<TD align="left" colSpan="3"><CC1:S_BUTTON id="btnsRicerca" tabIndex="4" runat="server" cssclass="btn" text="Ricerca"></CC1:S_BUTTON>&nbsp;&nbsp;
																<CC1:S_BUTTON id="cmdExcel" tabIndex="2" runat="server" cssclass="btn" text="Esporta"></CC1:S_BUTTON><CC1:S_BUTTON id="btnReset" tabIndex="5" runat="server" cssclass="btn" text="Reset"></CC1:S_BUTTON>&nbsp;</TD>
															<TD align="right"><A class=GuidaLink 
                  href="<%= HelpLink %>" target=_blank 
                  >Guida</A>
															</TD>
														</TR>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
					</COLLAPSE:DATAPANEL></TD></TR>
					<TR>
						<TD align="center"><UC1:GRIDTITLE id="GridTitle1" runat="server" visible="False"></UC1:GRIDTITLE><ASP:DATAGRID id="DataGridRicerca" runat="server" cssclass="DataGrid" allowpaging="True" gridlines="Vertical"
								autogeneratecolumns="False" borderwidth="1px" bordercolor="Gray" PageSize="25">
								<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
								<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="Anno" HeaderText="Anno" ItemStyle-HorizontalAlign ="Center">
										<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Quadrimestre" HeaderText="Quadrimestre" ItemStyle-HorizontalAlign ="Center">
										<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn ItemStyle-HorizontalAlign ="Center" HeaderStyle-Width="20%" DataField="ATT_NON_CONFORMI" HeaderText="N&#176; Attivit&#224; non conformi" ></asp:BoundColumn>
									<asp:BoundColumn DataField="ATT_TOTALI" ItemStyle-HorizontalAlign ="Center" HeaderText="N&#176; Attivit&#224; Totali" >
										<ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn ItemStyle-HorizontalAlign ="Center" DataField="IP" HeaderText="Indice Prestazionale">
										<ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
				</TBODY>
			</TABLE>
			</TD></TR></TBODY></TABLE></FORM>
		<SCRIPT language="javascript">parent.left.calcola();</SCRIPT>
	</BODY>
</HTML>
