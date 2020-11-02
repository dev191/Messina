<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="Funzioni.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Admin.Funzioni" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Funzioni</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" height="95%">
							<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
								<TBODY>
									<TR>
										<TD style="HEIGHT: 25%" vAlign="top" align="left">
											<Collapse:DataPanel id="PanelRicerca" runat="server" ExpandImageUrl="../Images/down.gif" CollapseImageUrl="../Images/up.gif"
												CollapseText="Riduci" ExpandText="Espandi" Collapsed="False" AllowTitleExpandCollapse="True" TitleText="Ricerca"
												CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch">
												<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
													<TR>
														<TD align="right" width="20%">Descrizione</TD>
														<TD width="30%">
															<cc1:s_textbox id="txtsDescrizione" runat="server" DBSize="255" width="75%" DBDirection="Input"
																DBParameterName="p_Descrizione"></cc1:s_textbox></TD>
														<TD align="right" width="20%">Codice</TD>
														<TD width="30%">
															<cc1:s_textbox id="txtsCodice" tabIndex="1" runat="server" DBSize="10" width="75%" DBParameterName="p_Codice"
																DBIndex="0"></cc1:s_textbox></TD>
													</TR>
													<TR>
														<TD align="right"></TD>
														<TD></TD>
														<TD align="right"></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD align="left" colSpan="3">
															<cc1:s_button id="btnsRicerca" tabIndex="2" runat="server" CssClass="btn" Text="Ricerca"></cc1:s_button>&nbsp;
															<INPUT class="btn" tabIndex="3" type="reset" value="Reset"></TD>
														<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
													</TR>
												</TABLE>
											</Collapse:DataPanel></TD>
									</TR>
									<tr>
										<TD style="HEIGHT: 3%" align="center"></TD>
									</tr>
									<TR>
										<TD style="HEIGHT: 72%" vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle>
											<asp:DataGrid id="DataGridRicerca" runat="server" CssClass="DataGrid" BorderColor="Gray" BorderWidth="1px"
												GridLines="Vertical" AutoGenerateColumns="False">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:HyperLink ImageUrl="~/images/edit.gif" NavigateUrl='<%# "EditFunzioni.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId%>' runat="server" ID="Hyperlink1"/>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="DESCRIZIONE" HeaderText="Funzione">
														<HeaderStyle Width="34%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CODICE" HeaderText="Codice">
														<HeaderStyle Width="8%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="LINK" HeaderText="Link File">
														<HeaderStyle Width="29%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="LINK_HELP" HeaderText="Link File Help">
														<HeaderStyle Width="29%"></HeaderStyle>
													</asp:BoundColumn>
												</Columns>
											</asp:DataGrid></TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
