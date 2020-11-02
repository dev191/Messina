<%@ Page language="c#" Codebehind="SfogliaPiani.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.SfogliaPiani" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Addetti" Src="../WebControls/Addetti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Sfoglia Rdl SGA DIE</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" ExpandImageUrl="../Images/down.gif" CollapseImageUrl="../Images/up.gif"
							CollapseText="Riduci" ExpandText="Espandi" Collapsed="False" AllowTitleExpandCollapse="True" TitleText="Ricerca"
							CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch">
							<TABLE id="tblSearch100" style="WIDTH: 100%; HEIGHT: 184px" cellSpacing="1" cellPadding="2"
								border="0">
								<TR>
									<TD align="left" colSpan="4">
										<uc1:RicercaModulo id="RicercaModulo1" runat="server"></uc1:RicercaModulo></TD>
								</TR>
								<TR>
									<TD align="left" width="13%">Nome Documento:</TD>
									<TD width="30%">
										<asp:TextBox id="txtDescrizione" runat="server" width="272px" MaxLength="255"></asp:TextBox></TD>
									<TD align="left" width="15%">Stato:</TD>
									<TD width="30%">
										<asp:dropdownlist id="cmbStato" runat="server" Width="200px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD align="left">Data Invio:</TD>
									<TD>
										<uc1:CalendarPicker id="CalendarPicker1" runat="server"></uc1:CalendarPicker></TD>
									<TD align="left">Data Inserimento:</TD>
									<TD>
										<uc1:CalendarPicker id="CalendarPicker2" runat="server"></uc1:CalendarPicker></TD>
								</TR>
								<TR>
									<TD align="left">Tipo di Documenti:</TD>
									<TD>
										<asp:dropdownlist id="cmbsTipoDocumenti" runat="server" Width="99%">
											<asp:ListItem Value="1">Piani annuali</asp:ListItem>
											<asp:ListItem Value="2">Piani mensili</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD align="left">Anno:</TD>
									<TD>
										<asp:dropdownlist id="DropAnno" runat="server" Width="128px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 16px" align="left" colSpan="4"></TD>
								</TR>
								<TR>
									<TD align="left" colSpan="3">
										<cc1:s_button id="btnsRicerca" runat="server" Text="Ricerca"></cc1:s_button>&nbsp;
										<asp:Button id="cmdReset" Text="Reset" Runat="server"></asp:Button>&nbsp;
										<asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD>
									<TD align="right"><A class=GuidaLink href="../<%= HelpLink %>" 
            target=_blank>Guida</A></TD>
								</TR>
							</TABLE>
						</COLLAPSE:DATAPANEL></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 72%" vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" PageSize="20" AutoGenerateColumns="False"
							GridLines="Vertical" BorderWidth="1px" BorderColor="Gray" AllowPaging="True">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="id" HeaderText="ID"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Download">
									<HeaderStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton id="btScarica" Runat="server" CommandName="Download" ImageUrl="../images/Excel.gif" CommandArgument='<%#  DataBinder.Eval(Container.DataItem,"nome_doc") + "," + DataBinder.Eval(Container.DataItem,"COD")%>'>
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Cod" HeaderText="Edificio"></asp:BoundColumn>
								<asp:BoundColumn DataField="NOME_DOC" HeaderText="Nome Documento">
									<HeaderStyle Width="50px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="descrizionestato" HeaderText="Stato"></asp:BoundColumn>
								<asp:BoundColumn DataField="DATA_INVIO" HeaderText="Data Invio" DataFormatString="{0:d}"></asp:BoundColumn>
								<asp:BoundColumn DataField="DATA_INSERIMENTo" HeaderText="Data Inserimento" DataFormatString="{0:d}"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" CssClass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
