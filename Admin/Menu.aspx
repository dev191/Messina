<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="Menu.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Admin.Menu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Menu</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
	function Ricarica(){
		parent.parent.left.location.href='../LeftFrame.aspx'
	}
		</script>
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
										<TD style="HEIGHT: 25%" vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" TitleStyle-CssClass="TitleSearch" CssClass="DataPanel75"
												TitleText="Ricerca" AllowTitleExpandCollapse="True" Collapsed="False" ExpandText="Espandi" CollapseText="Riduci" CollapseImageUrl="../Images/up.gif"
												ExpandImageUrl="../Images/down.gif">
												<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
													<TR>
														<TD style="HEIGHT: 13px" align="right" width="20%">Menu</TD>
														<TD style="HEIGHT: 13px" width="30%">
															<cc1:s_textbox id="txtsDescrizione" runat="server" DBParameterName="p_Descrizione" DBDirection="Input"
																width="75%" DBSize="255"></cc1:s_textbox></TD>
														<TD style="HEIGHT: 13px" align="right" width="20%">Menu Padre</TD>
														<TD style="HEIGHT: 13px" width="30%">
															<cc1:S_ComboBox id="cmbsMenuPadre" runat="server" DBParameterName="p_Menu_Padre_Id" DBDataType="Integer"
																Width="95%" DBIndex="2"></cc1:S_ComboBox></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 14px" align="right">Funzione</TD>
														<TD style="HEIGHT: 14px">
															<cc1:S_ComboBox id="cmbsFunzione" runat="server" DBParameterName="p_Funzione_Id" DBDataType="Integer"
																Width="95%" DBIndex="1"></cc1:S_ComboBox></TD>
														<TD style="HEIGHT: 14px" align="right">CssClass</TD>
														<TD style="HEIGHT: 14px">
															<cc1:s_textbox id="txtsCssClass" tabIndex="1" runat="server" DBParameterName="p_CssClass" width="75%"
																DBSize="128" DBIndex="3"></cc1:s_textbox></TD>
													</TR>
													<TR>
														<TD align="right"></TD>
														<TD></TD>
														<TD align="right"></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD align="left" colSpan="3">
															<cc1:s_button id="btnsRicerca" tabIndex="2" runat="server" CssClass="btn" Text="Ricerca"></cc1:s_button>&nbsp;<INPUT class="btn" tabIndex="3" type="reset" value="Reset">&nbsp;<INPUT class="btn" onclick="Ricarica()" tabIndex="3" type="reset" value="Aggiorna Menu"></TD>
														<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
													</TR>
												</TABLE>
											</COLLAPSE:DATAPANEL></TD>
									</TR>
									<tr>
										<TD style="HEIGHT: 3%" align="center"></TD>
									</tr>
									<TR>
										<TD style="HEIGHT: 72%" vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AutoGenerateColumns="False"
												GridLines="Vertical" BorderWidth="1px" BorderColor="Gray">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:HyperLink ImageUrl="~/images/edit.gif" NavigateUrl='<%# "EditMenu.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId%>' runat="server" ID="Hyperlink1"/>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="DESCRIZIONE" HeaderText="Menu">
														<HeaderStyle Width="25%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="DESCRIZIONEFUNZIONE" HeaderText="Funzione">
														<HeaderStyle Width="23%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="MENUPADRE" HeaderText="Menu Padre">
														<HeaderStyle Width="22%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CSSCLASS" HeaderText="CssClass">
														<HeaderStyle Width="12%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="TARGET" HeaderText="Target">
														<HeaderStyle Width="8%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="VIEWORDER" HeaderText="Ordine">
														<HeaderStyle Width="7%"></HeaderStyle>
													</asp:BoundColumn>
												</Columns>
											</asp:datagrid></TD>
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
