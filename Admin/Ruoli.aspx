<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="cc2" Namespace="arTreeMenu" Assembly="arTreeMenu" %>
<%@ Page language="c#" Codebehind="Ruoli.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Admin.Ruoli" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Ruoli</title>
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
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" height="95%">
						<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
							<TR>
								<TD style="HEIGHT: 25%" vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" TitleStyle-CssClass="TitleSearch" CssClass="DataPanel75"
										TitleText="Ricerca" AllowTitleExpandCollapse="True" Collapsed="False" ExpandText="Espandi" CollapseText="Riduci" CollapseImageUrl="../Images/up.gif"
										ExpandImageUrl="../Images/down.gif">
										<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
											<TR>
												<TD align="right" width="20%">Descrizione</TD>
												<TD width="30%">
													<cc1:s_textbox id="txtsDescrizione" runat="server" DBSize="128" width="75%" DBDirection="Input"
														DBParameterName="p_Descrizione"></cc1:s_textbox></TD>
												<TD align="right" width="20%">Note</TD>
												<TD width="30%">
													<cc1:s_textbox id="txtsNote" tabIndex="1" runat="server" DBSize="255" width="75%" DBParameterName="p_Note"
														DBIndex="1"></cc1:s_textbox></TD>
											</TR>
											<TR>
												<TD align="right">Ditta</TD>
												<TD>
													<cc1:S_ComboBox id="cmbsDitta" runat="server" DBParameterName="p_Ditta_Id" DBIndex="2" Width="75%"
														DBDataType="Integer"></cc1:S_ComboBox></TD>
												<TD style="HEIGHT: 2px" align="right"></TD>
												<TD style="HEIGHT: 2px"></TD>
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
													<asp:HyperLink ImageUrl="~/images/edit.gif" NavigateUrl='<%# "EditRuoli.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId %>' runat="server" ID="Hyperlink1"/>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:HyperLink ImageUrl="~/images/view.gif" NavigateUrl='<%# "RuoliEdifici.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId + "&descr="+ DataBinder.Eval(Container.DataItem,"Descrizione") %>' runat="server" ID="Hyperlink2"/>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="DESCRIZIONE" HeaderText="Ruolo">
												<HeaderStyle Width="35%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DESCRIZIONEDITTA" HeaderText="Ditta">
												<HeaderStyle Width="27%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NOTE" HeaderText="Note">
												<HeaderStyle Width="45%"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
