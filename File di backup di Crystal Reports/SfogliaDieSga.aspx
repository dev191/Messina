<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Addetti" Src="../WebControls/Addetti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Page language="c#" Codebehind="SfogliaDieSga.aspx.cs" AutoEventWireup="false" Inherits="TheSite.SfogliaDieSga" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Sfoglia Rdl SGA DIE</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center">
						<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></TD>
				</TR>
				<TR>
					<TD>
						<COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" ExpandImageUrl="../Images/down.gif" CollapseImageUrl="../Images/up.gif"
							CollapseText="Riduci" ExpandText="Espandi" Collapsed="False" AllowTitleExpandCollapse="True" TitleText="Ricerca"
							CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch">
							<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
								<TR>
									<TD align="left" colSpan="4">
										<uc1:RicercaModulo id="RicercaModulo1" runat="server"></uc1:RicercaModulo></TD>
								</TR>
								<TR>
									<TD align="left" width="13%">Richiesta di Lavoro:</TD>
									<TD width="30%">
										<cc1:s_textbox id="txtsRichiesta" runat="server" DBParameterName="p_Wr_Id" DBDirection="Input"
											width="100px" DBSize="255" MaxLength="10" DBDataType="Integer" DBIndex="2"></cc1:s_textbox></TD>
									<TD align="left" width="15%">Addetto:</TD>
									<TD width="30%">
										<uc1:Addetti id="Addetti1" runat="server"></uc1:Addetti></TD>
								</TR>
								<TR>
									<TD align="left">Ordine di Lavoro:</TD>
									<TD>
										<cc1:s_textbox id="txtsOrdine" runat="server" DBParameterName="p_Wr_Id" DBDirection="Input" width="100px"
											DBSize="255" MaxLength="10"></cc1:s_textbox></TD>
									<TD align="left">Stato Richiesta:</TD>
									<TD>
										<cc1:S_ComboBox id="cmbsStatus" runat="server" Width="99%"></cc1:S_ComboBox></TD>
								</TR>
								<TR>
									<TD align="left">Servizio:</TD>
									<TD>
										<cc1:S_ComboBox id="cmbsServizio" runat="server" Width="99%"></cc1:S_ComboBox></TD>
									<TD align="left">Gruppo:</TD>
									<TD>
										<cc1:S_ComboBox id="cmbsGruppo" runat="server" Width="99%"></cc1:S_ComboBox></TD>
								</TR>
								<TR>
									<TD align="left">Richiedente:</TD>
									<TD>
										<uc1:Richiedenti id="Richiedenti1" runat="server"></uc1:Richiedenti></TD>
									<TD align="left">Tipo di Documenti:</TD>
									<TD>
										<cc1:S_ComboBox id="cmbsTipoDocumenti" runat="server" Width="99%">
											<asp:ListItem Value="0">- Tutti documenti -</asp:ListItem>
											<asp:ListItem Value="1">Documenti SGA</asp:ListItem>
											<asp:ListItem Value="2">Documenti DIE</asp:ListItem>
										</cc1:S_ComboBox></TD>
								</TR>
								<TR>
									<TD align="left" colSpan="1">Descrizione:</TD>
									<TD colSpan="3">
										<cc1:s_textbox id="txtDescrizione" runat="server" DBParameterName="p_Wr_Id" DBDirection="Input"
											width="99%" DBSize="255" MaxLength="255"></cc1:s_textbox></TD>
								</TR>
								<TR>
									<TD align="left">Tipo Manutenzione:</TD>
									<TD>
										<cc1:S_ComboBox id="cmbsTipoManutenzione" runat="server" Width="99%"></cc1:S_ComboBox></TD>
									<TD id="tabletipointervento" style="DISPLAY: none">Tipo Intervento:</TD>
									<TD id="tabletipointervento2" style="DISPLAY: none">
										<cc1:S_ComboBox id="cmbsTipoIntervento" runat="server" Width="99%"></cc1:S_ComboBox></TD>
								</TR>
								<TR id="trdate" style="DISPLAY: none">
									<TD align="left">Data Prevista Inizio Lavori:</TD>
									<TD>
										<uc1:CalendarPicker id="CalendarPicker3" runat="server"></uc1:CalendarPicker></TD>
									<TD align="left">Data Prevista Fine Lavori:</TD>
									<TD>
										<uc1:CalendarPicker id="CalendarPicker4" runat="server"></uc1:CalendarPicker></TD>
								</TR>
								<TR style="DISPLAY: none">
									<TD align="left">Data Inizio Lavori:</TD>
									<TD></TD>
									<TD align="left">Data Fine Lavori:</TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 16px" align="left" colSpan="4"></TD>
								</TR>
								<TR>
									<TD align="left" colSpan="3">
										<cc1:s_button id="btnsRicerca" runat="server" Text="Ricerca"></cc1:s_button>&nbsp;
										<asp:Button id="cmdReset" Text="Reset" Runat="server"></asp:Button>&nbsp;
										<cc1:s_button id="cmdExcel" tabIndex="2" runat="server" Text="Esporta"></cc1:s_button>
										<asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD>
									<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
            target=_blank>Guida</A></TD>
								</TR>
							</TABLE>
						</COLLAPSE:DATAPANEL></TD>
				</TR>
				<TR>
					<TD>
						<uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AutoGenerateColumns="False"
							GridLines="Vertical" BorderWidth="1px" BorderColor="Gray" AllowPaging="True" ShowFooter="True">
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="WR_ID" HeaderText="ID"></asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="3%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton id="lnkDett" Runat=server CommandName="Dettaglio" ImageUrl="../images/edit.gif" CommandArgument='<%# "EditSfoglia.aspx?wr_id=" + DataBinder.Eval(Container.DataItem,"WR_ID")%>'>
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="3%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton id="Imagebutton2" Runat=server CommandName="Modifica" ImageUrl="../images/Search16x16_bianca.JPG" CommandArgument='<%# "CreazioneSGA.aspx?ItemId=" + DataBinder.Eval(Container.DataItem,"WR_ID")%>'>
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="WO_ID" HeaderText="OdL"></asp:BoundColumn>
								<asp:BoundColumn DataField="WR_ID" HeaderText="Rdl"></asp:BoundColumn>
								<asp:BoundColumn DataField="INDIRIZZO" HeaderText="Impianto"></asp:BoundColumn>
								<asp:BoundColumn DataField="addetto" HeaderText="Addetto"></asp:BoundColumn>
								<asp:BoundColumn DataField="stato" HeaderText="Stato"></asp:BoundColumn>
								<asp:BoundColumn DataField="tipointerventoater" HeaderText="Tipo Intervento"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" CssClass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
