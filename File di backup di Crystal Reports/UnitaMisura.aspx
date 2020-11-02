<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Page language="c#" Codebehind="UnitaMisura.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.UnitaMisura" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Eqstd</title>
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
									<TD align="top">
										<COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" ExpandImageUrl="../Images/down.gif"
											CollapseImageUrl="../Images/up.gif" CollapseText="Riduci" ExpandText="Espandi" Collapsed="False"
											AllowTitleExpandCollapse="True" TitleText="Ricerca" CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch">
											<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
												<TR>
													<TD align="left" width="20%">Descrizione Unità di Misura</TD>
													<TD colSpan="3">
														<cc1:S_TextBox id="txtDescMisura" tabIndex="2" runat="server" DBSize="50" width="70%" DBDirection="Input"
															DBParameterName="p_descrizione" DBIndex="1"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD align="left" width="20%">Codice Unità di Misura</TD>
													<TD colSpan="3">
														<cc1:S_TextBox id="txtCodMisura" tabIndex="1" runat="server" DBSize="16" width="50px" DBDirection="Input"
															DBParameterName="p_codice_misura" DBIndex="0"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD align="left" colSpan="3">
														<cc1:S_Button id="btnsRicerca" tabIndex="3" runat="server" CssClass="btn" Text="Ricerca"></cc1:S_Button>&nbsp;&nbsp;&nbsp;
														<cc1:S_Button id="btnReset" tabIndex="4" runat="server" CssClass="btn" Text="Reset"></cc1:S_Button></TD>
													<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A>
													</TD>
												</TR>
											</TABLE>
										</COLLAPSE:DATAPANEL></TD>
								</TR>
								<tr>
									<TD align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" BorderColor="Gray" BorderWidth="1px"
											GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True">
											<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
											<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn>
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<ItemTemplate>
														<asp:ImageButton id="imgVisualizza" Runat=server CommandName="Dettaglio" ImageUrl="~/images/Search16x16_bianca.jpg" CommandArgument='<%# "EditMisura.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"idmisura") + "&FunId=" + FunId + "&TipoOper=read"%>'>
														</asp:ImageButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<ItemTemplate>
														<asp:ImageButton id="imgModifica" Runat=server CommandName="Dettaglio" ImageUrl="~/images/edit.gif" CommandArgument='<%# "EditMisura.aspx?ItemID="+ DataBinder.Eval(Container.DataItem,"idmisura") + "&FunId=" + FunId + "&TipoOper=write"%>'>
														</asp:ImageButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="ucodice" HeaderText="Codice Unità di Misura">
													<HeaderStyle Width="20%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="udescrizione" HeaderText="Descrizione Unità di Misura">
													<HeaderStyle Width="40%"></HeaderStyle>
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
