<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Page language="c#" Codebehind="Specializzazioni.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.Specializzazioni" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Specializzazioni</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px"
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
											<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
												<TR>
													<TD style="HEIGHT: 24px" align="left" width="20%">Descrizione</TD>
													<TD style="HEIGHT: 24px">
														<cc1:S_TextBox id="txtsDescrizione" runat="server" DBIndex="0" DBParameterName="p_descrizione"
															DBDirection="Input" width="100%" DBSize="128"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 20px" align="left" width="20%">Servizio</TD>
													<TD style="HEIGHT: 20px">
														<cc1:S_TextBox id="txtsServizio" runat="server" DBIndex="1" DBParameterName="p_Servizio" DBDirection="Input"
															width="100%" DBSize="255"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 383px" align="left" colSpan="3">&nbsp;
														<cc1:S_Button id="btnsRicerca" runat="server" CssClass="btn" Text="Ricerca"></cc1:S_Button>
														<cc1:S_Button id="BtnReset" tabIndex="4" runat="server" CssClass="btn" Text="Reset"></cc1:S_Button>
													</TD>
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
											GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True">
											<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
											<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn>
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<ItemTemplate>
														<asp:ImageButton id="Imagebutton3" Runat=server CommandName="Dettaglio" ImageUrl="~/images/Search16x16_bianca.jpg" CommandArgument='<%# "EditSpecializzazioni.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId + "&TipoOper=read"%>'>
														</asp:ImageButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<ItemTemplate>
														<asp:ImageButton id="Imagebutton1" Runat=server CommandName="Dettaglio" ImageUrl="~/images/edit.gif" CommandArgument='<%# "EditSpecializzazioni.aspx?ItemID="+ DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId + "&TipoOper=write"%>'>
														</asp:ImageButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="descrizione" HeaderText="Descrizione"></asp:BoundColumn>
												<asp:BoundColumn DataField="servizio" HeaderText="Servizio"></asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</asp:DataGrid>
									</TD>
								</tr>
							</tbody>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
