<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Page language="c#" Codebehind="AnalisiRdlStorico.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorretiva.AnalisiRdlStorico" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>AnalisiRdlStorico</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
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
										<TD style="HEIGHT: 72%" vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" BorderColor="Gray" BorderWidth="1px"
												GridLines="Vertical" AutoGenerateColumns="False">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="id" HeaderText="ID"></asp:BoundColumn>
													<asp:BoundColumn DataField="date_requested" HeaderText="Data Richiesta"></asp:BoundColumn>
													<asp:BoundColumn DataField="status_desc" HeaderText="Stato"></asp:BoundColumn>
													<asp:BoundColumn DataField="time_stat_chg" HeaderText="Data Modifica"></asp:BoundColumn>
													<asp:BoundColumn DataField="username" HeaderText="Operatore"></asp:BoundColumn>
													<asp:BoundColumn DataField="descrizione" HeaderText="Servizio"></asp:BoundColumn>
													<asp:BoundColumn DataField="requestor" HeaderText="Richiedente"></asp:BoundColumn>
													<asp:BoundColumn DataField="wo_id" HeaderText="N&#176; Odl"></asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Left" CssClass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
												<input value="Chiudi" type="button" name="btnsChiudi" id="btnsChiudi" onclick="javascript:history.back();">
												<asp:button id="btnsExcel" runat="server" Text="Esporta"></asp:button></TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM><script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
