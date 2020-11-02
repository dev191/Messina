<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc2" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Page language="c#" Codebehind="ListaDoc_Dwf.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.ListaDoc_Dwf" %>
<%@ Register TagPrefix="uc1" TagName="GridTitleServer" Src="../WebControls/GridTitleServer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DescrizioneDoc_Dwf</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="center">
						<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="tblSearch100" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD>
									<cc1:DataPanel id="DataPanel1" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
										TitleText="Anagrafe Documenti" ExpandText="Espandi" ExpandImageUrl="../Images/down.gif" CollapseText="Riduci"
										CssClass="DataPanel75" CollapseImageUrl="../Images/up.gif" AllowTitleExpandCollapse="True">
										<TABLE id="tblSearch100" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD>
													<uc1:RicercaModulo id="RicercaModulo1" runat="server"></uc1:RicercaModulo></TD>
											</TR>
										</TABLE>
										<TABLE width="100%" border="0">
											<TR>
												<TD style="WIDTH: 87px">
													<cc2:S_Button id="btRicerca" runat="server" CssClass="btn" Width="88px" Text="Ricerca"></cc2:S_Button></TD>
												<TD>
													<cc2:S_Button id="btReset" runat="server" CssClass="btn" Width="88px" Text="Reset"></cc2:S_Button></TD>
												<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
											</TR>
										</TABLE>
									</cc1:DataPanel>
								</TD>
							</TR>
							<TR>
								<TD>
									<uc1:GridTitleServer id="GridTitleServer1" runat="server"></uc1:GridTitleServer>
									<asp:DataGrid id="DataGrid1" runat="server" CssClass="DataGrid" Width="100%" BorderColor="Gray"
										BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False"
										AllowPaging="True" GridLines="Vertical">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton ImageUrl="../Images/edit.gif" Runat=server OnCommand="imageButton_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") + "," + DataBinder.Eval(Container.DataItem,"NOMEDWF") %>' ID="Imagebutton1">
													</asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton ImageUrl="../Images/elimina.gif" Runat="server" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id")%>' ID="Imagebutton2">
													</asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="codice_edificio" HeaderText="Cod.Edificio"></asp:BoundColumn>
											<asp:BoundColumn DataField="NOMEDWF" HeaderText="Nome File"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Descrizione">
												<ItemTemplate>
													<span title='<%# valutatooltip(DataBinder.Eval(Container, "DataItem.descrizione")) %>'>
														<%# valutastringa(DataBinder.Eval(Container, "DataItem.descrizione")) %>
													</span>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="dimensione_file" HeaderText="Dimensione"></asp:BoundColumn>
											<asp:BoundColumn DataField="categoriadescription" HeaderText="Categoria"></asp:BoundColumn>
											<asp:BoundColumn DataField="tipologiadescription" HeaderText="Tipologia"></asp:BoundColumn>
											<asp:BoundColumn DataField="servizio" HeaderText="Servizio"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
									</asp:DataGrid>
								</TD>
							</TR>
						</TABLE>
						<INPUT id="hiddenblid" type="hidden" name="hiddenblid" runat="server">
						<cc2:S_Label id="lblError" runat="server" ForeColor="Red"></cc2:S_Label>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
