<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Page language="c#" Codebehind="PmpFrequenza.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.PmpFrequenza" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PmpFrequenza</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; TOP: 0px; LEFT: 0px"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="center">
						<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
							<tbody>
								<TR>
									<TD Align="center">
										<Collapse:DataPanel id="PanelRicerca" runat="server" ExpandImageUrl="../Images/down.gif" CollapseImageUrl="../Images/up.gif"
											CollapseText="Riduci" ExpandText="Espandi" Collapsed="False" AllowTitleExpandCollapse="True" TitleText="Ricerca"
											CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch">
											<TABLE id="tblSearch100" border="0" cellSpacing="1" cellPadding="2">
												<TR>
													<TD width="20%" align="left">Frequenza</TD>
													<TD width="20%">
														<cc1:S_TextBox id="txtsFrequenza" runat="server" DBIndex="0" DBParameterName="p_frequenza" DBDirection="Input"
															width="100%" DBSize="40"></cc1:S_TextBox></TD>
													<TD width="20%" align="left">Descrizione</TD>
													<TD width="40%">
														<cc1:S_TextBox id="txtsFrequenza_des" runat="server" DBIndex="1" DBParameterName="p_frequenza_des"
															DBDirection="Input" width="90%" DBSize="50"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD align="left">Tipo Cadenza</TD>
													<TD>
														<cc1:s_combobox id="CmbCadenza" runat="server" DBIndex="3" DBParameterName="p_tipo" DBDirection="Input"
															DBDataType="Integer">
															<asp:ListItem Value="-1">--Nessun elemento selezionato --</asp:ListItem>
															<asp:ListItem Value="0">Periodico</asp:ListItem>
															<asp:ListItem Value="1">Fisso</asp:ListItem>
														</cc1:s_combobox></TD>
													<TD align="right"></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD colSpan="3" align="left">&nbsp;
														<cc1:S_Button id="btnsRicerca" runat="server" CssClass="btn" Text="Ricerca"></cc1:S_Button>
														<cc1:S_Button id="BtnReset" tabIndex="4" runat="server" CssClass="btn" Text="Reset"></cc1:S_Button>
														<cc1:S_Button id="btnEsportaXsl" tabIndex="5" runat="server" CssClass="btn" Text="Esporta xls"></cc1:S_Button></TD>
													<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A>
													</TD>
												</TR>
											</TABLE>
										</Collapse:DataPanel>
									</TD>
								</TR>
								<tr>
									<TD align="center">
										<uc1:GridTitle id="GridTitle1" runat="server"></uc1:GridTitle>
										<asp:DataGrid id="DataGridRicerca" runat="server" CssClass="DataGrid" BorderColor="Gray" BorderWidth="1px"
											GridLines="Vertical" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
											<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn>
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<ItemTemplate>
														<asp:ImageButton id="Imagebutton3" Runat=server CommandName="Dettaglio" ImageUrl="~/images/Search16x16_bianca.jpg" CommandArgument='<%# "EditPmpFrequenza.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId + "&TipoOper=read"%>'>
														</asp:ImageButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<ItemTemplate>
														<asp:ImageButton id="Imagebutton1" Runat=server CommandName="Dettaglio" ImageUrl="~/images/edit.gif" CommandArgument='<%#  "EditPmpFrequenza.aspx?ItemID="+ DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId + "&TipoOper=write"%>'>
														</asp:ImageButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="frequenza" HeaderText="Frequenza">
													<HeaderStyle Width="15%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="frequenza_des" HeaderText="Descrizione">
													<HeaderStyle Width="35%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="mese_std" HeaderText="Tipo Cadenza"></asp:BoundColumn>
												<asp:BoundColumn DataField="n_giorni" HeaderText="Giorni">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="n_mesi" HeaderText="Mesi">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="n_anni" HeaderText="Anni">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Servizio\Mese">
													<ItemTemplate>
														<div style="overflow:auto;WIDTH: 100%; HEIGHT: 100px;border: 1px solid black;">
															<table width="100%">
																<asp:Repeater ID="rp" Runat="server">
																	<ItemTemplate>
																		<tr>
																			<td align="center"><%# DataBinder.Eval(Container.DataItem,"Servizio")%></td>
																			<td align="center"><%# DataBinder.Eval(Container.DataItem,"Mese")%></td>
																		</tr>
																	</ItemTemplate>
																</asp:Repeater>
															</table>
														</div>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="calcola" HeaderText="Calcola"></asp:BoundColumn>
											</Columns>
										</asp:DataGrid>
									</TD>
								</tr>
							</tbody>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
