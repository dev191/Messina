<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="VisualizzaReperibilita" Src="../WebControls/VisualizzaReperibilita.ascx" %>
<%@ Page language="c#" Codebehind="RepAddetti.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.RepAddetti" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RepAddetti</title>
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
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
							<tbody>
								<TR>
									<TD align="top"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" TitleStyle-CssClass="TitleSearch" CssClass="DataPanel75"
											TitleText="Ricerca" AllowTitleExpandCollapse="True" Collapsed="False" ExpandText="Espandi" CollapseText="Riduci"
											CollapseImageUrl="../Images/up.gif" ExpandImageUrl="../Images/down.gif">
											<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
												<TR>
													<TD align="left" width="20%">Addetto</TD>
													<TD width="20%">
														<cc1:S_TextBox id="txtsadd" tabIndex="1" runat="server" DBSize="50" width="100%" DBDirection="Input"
															DBParameterName="p_add" DBIndex="0"></cc1:S_TextBox></TD>
													<TD align="left" width="20%">Giorno</TD>
													<TD width="40%">
														<cc1:S_ComboBox id="cmbsGiorno" runat="server" DBSize="10" DBDirection="Input" DBParameterName="p_giorno"
															DBIndex="1" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 20px" align="left">Ditta</TD>
													<TD style="HEIGHT: 20px">
														<cc1:S_TextBox id="txtsditta" runat="server" DBSize="50" DBDirection="Input" DBParameterName="p_ditta"
															DBIndex="2"></cc1:S_TextBox></TD>
													<TD style="HEIGHT: 20px" align="right"></TD>
													<TD style="HEIGHT: 20px"></TD>
												</TR>
												<TR>
													<TD align="left" colSpan="3">&nbsp;
														<cc1:S_Button id="btnsRicerca" tabIndex="4" runat="server" CssClass="btn" Text="Ricerca"></cc1:S_Button>
														<cc1:S_Button id="BtnReset" tabIndex="4" runat="server" CssClass="btn" Text="Reset"></cc1:S_Button></TD>
													<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A>
													</TD>
												</TR>
											</TABLE>
											<uc1:VisualizzaReperibilita id="VisualizzaReperibilita1" runat="server"></uc1:VisualizzaReperibilita>
										</COLLAPSE:DATAPANEL></TD>
								</TR>
								<tr>
									<TD align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AllowPaging="True" AutoGenerateColumns="False"
											GridLines="Vertical" BorderWidth="1px" BorderColor="Gray">
											<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
											<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<ItemTemplate>
														<asp:ImageButton id="Imagebutton3" Runat=server CommandName="Dettaglio" ImageUrl="../images/Search16x16_bianca.jpg" CommandArgument='<%# "EditRepAddetti.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId + "&TipoOper=read"%>'>
														</asp:ImageButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<ItemTemplate>
														<asp:ImageButton id="Imagebutton1" Runat=server CommandName="Delete" ImageUrl="../Images/elimina.gif" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID") %>'>
														</asp:ImageButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="cognom" HeaderText="Addetto">
													<HeaderStyle Width="30%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="ditta" HeaderText="Ditta">
													<HeaderStyle Width="30%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="giorno" HeaderText="Giorno">
													<HeaderStyle Width="20%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="orain" HeaderText="Inizio Turno">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="oraout" HeaderText="Fine Turno">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</tr>
							</tbody>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
