<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RichiedentiSollecito" Src="../WebControls/RichiedentiSollecito.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Page language="c#" Codebehind="ReportGiudizioCliente.aspx.cs" AutoEventWireup="false" Inherits="TheSite.SoddisfazioneCliente.ReportGiudizioCliente" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Giudizio</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
 
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

		</script>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px"
				cellSpacing="0" cellPadding="0" align="center" border="0">
				<TBODY>
					<TR>
						<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="100%">
							<TABLE id="tblForm" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" align="center"
								border="0">
								<tbody>
									<TR>
										<TD vAlign="top" width="100%"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" ExpandImageUrl="../Images/down.gif" CollapseImageUrl="../Images/up.gif"
												CollapseText="Riduci" ExpandText="Espandi" Collapsed="False" AllowTitleExpandCollapse="True" TitleText="Ricerca" CssClass="DataPanel75"
												TitleStyle-CssClass="TitleSearch">
												<TABLE style="WIDTH: 100%">
													<TBODY>
														<TR>
															<TD style="WIDTH: 100%" colSpan="4">
																<TABLE id="TableRicercaModulo" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" border="0">
																	<TR>
																		<TD><uc1:ricercamodulo id="RicercaModulo1" runat="server"></uc1:ricercamodulo></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<td colSpan="4">
																<TABLE class="tblSearch100Dettaglio" style="WIDTH: 100%" cellSpacing="1" cellPadding="1"
																	border="0">
																	<tr>
																		<TD width="10%">Data Da</TD>
																		<TD align="left" width="40%">
																			<uc1:CalendarPicker id="CPDataDa" runat="server"></uc1:CalendarPicker></TD>
																		<TD width="10%">Data A
																		</TD>
																		<TD align="left" width="40%">
																			<uc1:CalendarPicker id="CPDataA" runat="server"></uc1:CalendarPicker></TD>
																	</tr>
																</TABLE>
															</td>
														</TR>
														<TR>
															<td colSpan="4">
																<TABLE id="TableRicercaApparecchiatura" style="WIDTH: 100%" cellSpacing="1" cellPadding="1"
																	border="0">
																	<TBODY>
																		<TR>
																			<TD><uc1:codiceapparecchiature id="CodiceApparecchiature1" runat="server"></uc1:codiceapparecchiature></TD>
																		</TR>
																	</TBODY>
																</TABLE>
															</td>
														</TR>
														<TR>
															<TD align="center" colSpan="4"><asp:panel id="PanelServizio" runat="server">
																	<TABLE class="tblSearch100Dettaglio" id="Table2" style="WIDTH: 100%" cellSpacing="1" cellPadding="1"
																		border="0">
																		<TR>
																			<TD style="HEIGHT: 13px" width="10%">Servizio</TD>
																			<TD style="HEIGHT: 13px" align="left" width="40%">
																				<cc1:S_ComboBox id="cmbsServizio" runat="server" DBParameterName="p_Servizio_Id" DBDataType="Integer"
																					AutoPostBack="True" DBIndex="10" DBSize="4" Width="280px"></cc1:S_ComboBox></TD>
																			<TD style="HEIGHT: 16px">Report Giudizio Cliente</TD>
																			<TD style="HEIGHT: 16px" align="left" width="40%">
																				<cc1:S_ComboBox id="cmbsGiudizio" runat="server" DBParameterName="p_Giudizio_Id" DBDataType="Integer"
																					AutoPostBack="False" DBIndex="10" DBSize="4" Width="280px"></cc1:S_ComboBox></TD>
																		</TR>
																		<TR>
																			<TD style="HEIGHT: 13px" width="10%">Tipo Giudizio</TD>
																			<TD style="HEIGHT: 13px" align="left" width="40%" colSpan="3">
																				<cc1:S_ComboBox id="cmbsTipoGiudizio" runat="server" DBParameterName="p_Servizio_Id" DBDataType="Integer"
																					DBIndex="10" DBSize="4" Width="152px">
																					<asp:ListItem Value="T" Selected="True">Entrambi</asp:ListItem>
																					<asp:ListItem Value="F">A Freddo</asp:ListItem>
																					<asp:ListItem Value="C">A Caldo</asp:ListItem>
																				</cc1:S_ComboBox></TD>
																		</TR>
																	</TABLE>
																</asp:panel></TD>
														</TR>
														<tr>
															<td colSpan="4">&nbsp;</td>
														</tr>
														<TR>
															<TD align="left" colSpan="3"><cc1:s_button id="btnsRicerca" tabIndex="4" runat="server" CssClass="btn" Text="Ricerca"></cc1:s_button>&nbsp;&nbsp;
																<cc1:s_button id="cmdExcel" tabIndex="2" runat="server" CssClass="btn" Text="Esporta"></cc1:s_button>
																<cc1:s_button id="btnReset" tabIndex="5" runat="server" CssClass="btn" Text="Reset"></cc1:s_button>&nbsp;</TD>
															<td align="right"><A class=GuidaLink 
                  href="<%= HelpLink %>" target=_blank 
                  >Guida</A>
															</td>
														</TR>
									</TR>
								</tbody>
							</TABLE>
						</TD>
					</TR>
					</COLLAPSE:DATAPANEL></TD></TR>
					<TR>
						<TD align="center"><uc1:gridtitle id="GridTitle1" runat="server" Visible="False"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AllowPaging="True" GridLines="Vertical"
								AutoGenerateColumns="False" BorderWidth="1px" BorderColor="Gray">
								<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
								<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="tipologia_giudizio" HeaderText="Tipo Giudizio"></asp:BoundColumn>
									<asp:BoundColumn DataField="bl_id" HeaderText="Edificio">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="servizio" HeaderText="Servizio"></asp:BoundColumn>
									<asp:BoundColumn DataField="soddisfazione" HeaderText="Giudizio Cliente"></asp:BoundColumn>
									<asp:BoundColumn DataField="totale" HeaderText="Numero Giudizi"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</TBODY>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
