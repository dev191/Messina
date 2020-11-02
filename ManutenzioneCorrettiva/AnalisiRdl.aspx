<%@ Register TagPrefix="uc1" TagName="DataPicker" Src="../WebControls/DataPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Page language="c#" Codebehind="AnalisiRdl.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorretiva.AnalisiRdl" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>AnalisiRdl</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<script language="javascript">
	
			function Verifica(oggetto)
			{
				if (event.keyCode < 48	|| event.keyCode > 57)
					{
						event.keyCode = 0;
					}
			}	
			function nonpaste()
			{
				return false;
			}
		</script>
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
										<TD style="HEIGHT: 25.11%" vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" TitleStyle-CssClass="TitleSearch" CssClass="DataPanel75"
												TitleText="Ricerca" AllowTitleExpandCollapse="True" Collapsed="False" ExpandText="Espandi" CollapseText="Espandi/Riduci" CollapseImageUrl="../Images/up.gif"
												ExpandImageUrl="../Images/down.gif">
            <TABLE id=tblSearch100 cellSpacing=1 cellPadding=2 border=0>
              <TR>
                <TD align=left colSpan=4>
<uc1:RicercaModulo id=RicercaModulo1 runat="server"></uc1:RicercaModulo></TD></TR>
              <TR>
                <TD style="HEIGHT: 22px" align=left>Data Da:</TD>
                <TD style="HEIGHT: 22px">
<uc1:CalendarPicker id=CalendarPicker1 runat="server"></uc1:CalendarPicker></TD>
                <TD style="WIDTH: 125px; HEIGHT: 22px" align=left>Data A:</TD>
                <TD style="HEIGHT: 22px">
<uc1:CalendarPicker id=CalendarPicker2 runat="server"></uc1:CalendarPicker>
<asp:CompareValidator id=CompareValidator1 runat="server" Type="Date" Operator="GreaterThanEqual" ErrorMessage="Data non valida!"></asp:CompareValidator></TD></TR>
              <TR>
                <TD align=left>Ordine di Lavoro:</TD>
                <TD>
<cc1:s_textbox id=txtswo_id runat="server" DBDataType="Integer" DBIndex="2" DBParameterName="p_wo_id" DBDirection="Input" width="70%" DBSize="10"></cc1:s_textbox></TD></TR>
              <TR>
                <TD align=left>Richiesta&nbsp;di Lavoro:</TD>
                <TD>
<cc1:s_textbox id=txtswr_id runat="server" DBDataType="Integer" DBIndex="3" DBParameterName="p_wr_id" DBDirection="Input" width="70%" DBSize="10"></cc1:s_textbox></TD>
                <TD style="WIDTH: 125px" align=left>Stato:</TD>
                <TD>
<cc1:S_ComboBox id=cmbsid_status runat="server" DBDataType="Integer" DBIndex="4" DBParameterName="p_stato_id" DBDirection="Input" DBSize="10" Width="280px"></cc1:S_ComboBox></TD></TR>
              <TR>
                <TD align=left colSpan=4></TD></TR>
              <TR>
                <TD style="WIDTH: 447px" align=left colSpan=3>
<cc1:s_button id=btnsRicerca tabIndex=2 runat="server" Width="134px" Text="Ricerca"></cc1:s_button>&nbsp; 
<cc1:s_button id=btReset tabIndex=2 runat="server" Text="Reset" CausesValidation="False"></cc1:s_button>&nbsp; 
<cc1:s_button id=btnExcel tabIndex=2 runat="server" Text="Esporta"></cc1:s_button></TD>
                <TD align=right><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD></TR></TABLE>
											</COLLAPSE:DATAPANEL></TD>
									</TR>
									<tr>
										<TD style="HEIGHT: 3%" align="center"></TD>
									</tr>
									<TR>
										<TD style="HEIGHT: 72%" vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AutoGenerateColumns="False"
												GridLines="Vertical" BorderWidth="1px" BorderColor="Gray" AllowPaging="True">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="wr_id" HeaderText="ID"></asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:ImageButton id="lnkDett" Runat=server CommandName="Dettaglio" ImageUrl="~/images/edit.gif" CommandArgument='<%# "AnalisiRdlStorico.aspx?wr_id=" + DataBinder.Eval(Container.DataItem,"WR_ID") + "&FunId=" + FunId%>'>
															</asp:ImageButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="wr_id" HeaderText="Richiesta di RdL">
														<HeaderStyle Width="3%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Edificio" HeaderText="Edificio">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="OrdineLavoro" HeaderText="Ordine di Lavoro">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="StatoRichiesta" HeaderText="Stato Richiesta">
														<HeaderStyle Width="20%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="DataEmissione" HeaderText="Data Emissione" DataFormatString="{0:d}">
														<HeaderStyle Width="12%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Priorita" HeaderText="Priorit&#224;">
														<HeaderStyle Width="15%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Servizio" HeaderText="Servizio"></asp:BoundColumn>
													<asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
													<asp:BoundColumn DataField="tipomanutenzione" HeaderText="Tipo Manutenzione"></asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
