<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="Fornitori.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.Fornitori" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Fornitori</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" height="95%">
						<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
							<TR>
								<TD style="HEIGHT: 25%" vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" ExpandImageUrl="../Images/down.gif" CollapseImageUrl="../Images/up.gif"
										CollapseText="Riduci" ExpandText="Espandi" Collapsed="False" AllowTitleExpandCollapse="True" TitleText="Ricerca" CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch">
										<TABLE id="tblSearch100" cellSpacing="0" cellPadding="2" border="0">
											<TR>
												<TD align="left" width="20%">Fornitore</TD>
												<TD width="30%">
													<cc1:s_textbox id="txtsFornitore" runat="server" DBParameterName="p_vn_id" DBDirection="Input"
														width="208px" DBSize="30"></cc1:s_textbox></TD>
												<TD align="left" width="20%">Indirizzo</TD>
												<TD width="30%">
													<cc1:s_textbox id="txtsIndirizzo" tabIndex="2" runat="server" DBParameterName="p_address1" DBDirection="Input"
														width="208px" DBSize="50" DBIndex="1"></cc1:s_textbox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 24px" align="left">Comune</TD>
												<TD style="HEIGHT: 24px">
													<cc1:s_textbox id="txtsComune" tabIndex="2" runat="server" DBParameterName="p_city" DBDirection="Input"
														width="208px" DBSize="255" DBIndex="2"></cc1:s_textbox></TD>
												<TD style="HEIGHT: 24px" align="left">Telefono</TD>
												<TD style="HEIGHT: 24px">
													<cc1:s_textbox id="txtsTelefono" tabIndex="3" runat="server" DBParameterName="p_phone" DBDirection="Input"
														width="208px" DBSize="20" DBIndex="3"></cc1:s_textbox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 23px" align="left">Email</TD>
												<TD style="HEIGHT: 23px">
													<cc1:s_textbox id="txtsEmail" tabIndex="3" runat="server" DBParameterName="p_email" DBDirection="Input"
														width="208px" DBSize="50" DBIndex="4"></cc1:s_textbox></TD>
												<TD style="HEIGHT: 23px" align="left"></TD>
												<TD style="HEIGHT: 23px"></TD>
											</TR>
											<TR>
												<TD align="left" colSpan="3">
													<cc1:s_button id="btnsRicerca" runat="server" CssClass="btn" Text="Ricerca"></cc1:s_button>&nbsp;
													<cc1:S_Button id="BtnReset" tabIndex="4" runat="server" CssClass="btn" Text="Reset"></cc1:S_Button></TD>
												<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
											</TR>
										</TABLE>
									</COLLAPSE:DATAPANEL></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 3%" align="center"></TD>
							<TR>
								<TD style="HEIGHT: 72%" vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" BorderColor="Gray" BorderWidth="1px"
										GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True">
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="id" HeaderText="ID"></asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Imagebutton3" Runat=server CommandName="Dettaglio" ImageUrl="~/images/Search16x16_bianca.jpg" CommandArgument='<%# "EditFornitori.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId + "&TipoOper=read"%>'>
													</asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Imagebutton2" Runat=server CommandName="Dettaglio" ImageUrl="~/images/edit.gif" CommandArgument='<%# "EditFornitori.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId + "&TipoOper=write"%>'>
													</asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="fornitore" HeaderText="Fornitore">
												<HeaderStyle Width="25%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="indirizzo" HeaderText="Indirizzo">
												<HeaderStyle Width="22%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="prcom" HeaderText="Comune">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="telefono" HeaderText="Telefono">
												<HeaderStyle Width="13%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Email" HeaderText="Email">
												<HeaderStyle Width="15%"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
