<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Page language="c#" Codebehind="PianoFerie.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.PianoFerie" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Piano Ferie</title>
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
									<TD align="center"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" ExpandImageUrl="../Images/down.gif"
											CollapseImageUrl="../Images/up.gif" CollapseText="Riduci" ExpandText="Espandi" Collapsed="False" AllowTitleExpandCollapse="True"
											TitleText="Ricerca" CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch">
											<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
												<TR>
													<TD align="left" width="20%">Nome</TD>
													<TD width="20%">
														<cc1:S_TextBox id="txtsNome" runat="server" MaxLength="50" DBIndex="0" DBParameterName="p_nome"
															DBDirection="Input" width="100%" DBSize="50"></cc1:S_TextBox></TD>
													<TD style="WIDTH: 122px" align="left" width="122">Cognome</TD>
													<TD width="40%">
														<cc1:S_TextBox id="txtsCognome" runat="server" MaxLength="50" DBIndex="1" DBParameterName="p_cognome"
															DBDirection="Input" width="95%" DBSize="50"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD align="left">Inizio Ferie</TD>
													<TD>
														<uc1:CalendarPicker id="InizioFerie" runat="server" DBParameterName="p_dataInizio"></uc1:CalendarPicker></TD>
													<TD style="WIDTH: 122px" align="left">Fine Ferie</TD>
													<TD>
														<uc1:CalendarPicker id="FineFerie" runat="server" DBParameterName="p_dataFine"></uc1:CalendarPicker>
														<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Intervallo di Date non Valido!"
															Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 17px" align="left">Tipo Permesso</TD>
													<TD style="HEIGHT: 17px">
														<cc1:S_ComboBox id="TipoPermesso" runat="server" DBIndex="4" DBParameterName="p_idMotivo" DBDataType="Integer"
															DataTextField="descrizione" DataValueField="id" Width="184px"></cc1:S_ComboBox></TD>
													<TD style="HEIGHT: 17px"></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 383px" align="left" colSpan="3">&nbsp;
														<cc1:S_Button id="btnsRicerca" runat="server" cssClass="btn" Text="Ricerca"></cc1:S_Button>
														<cc1:S_Button id="btreset" runat="server" CssClass="btn" Text="Reset"></cc1:S_Button></TD>
													<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A>
													</TD>
												</TR>
											</TABLE>
										</COLLAPSE:DATAPANEL></TD>
								</TR>
								<tr>
									<TD align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" BorderColor="Gray" BorderWidth="1px"
											GridLines="Vertical" AutoGenerateColumns="False" AllowCustomPaging="True" AllowPaging="True">
											<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
											<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="nome" HeaderText="Nome">
													<HeaderStyle Width="25%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="cognome" HeaderText="Cognome">
													<HeaderStyle Width="25%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="DATE_START" HeaderText="Inizio">
													<HeaderStyle Width="25%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="DATE_END" HeaderText="Fine">
													<HeaderStyle Width="25%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="MOTIVO" HeaderText="Motivo">
													<HeaderStyle Width="25%"></HeaderStyle>
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
