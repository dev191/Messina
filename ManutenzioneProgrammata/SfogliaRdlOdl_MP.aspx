<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="SfogliaRdlOdl_MP.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.SfogliaRdlOdl_MP" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SfogliaRdlOdl_MP</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD><asp:datagrid id="DataGrid1" runat="server" GridLines="Vertical" AllowPaging="False" AutoGenerateColumns="False"
										CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="Gray"
										Width="100%" CssClass="DataGrid">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="wo_id" HeaderText="Ordine di Lavoro"></asp:BoundColumn>
											<asp:BoundColumn DataField="desccomune" HeaderText="Comune"></asp:BoundColumn>
											<asp:BoundColumn DataField="IDEdificio" HeaderText="Edificio"></asp:BoundColumn>
											<asp:BoundColumn DataField="IndEdificio" HeaderText="Indirizzo"></asp:BoundColumn>
											<asp:BoundColumn DataField="DATA_CREAZ" HeaderText="Data Emissione Odl" DataFormatString="{0:d}"></asp:BoundColumn>
											<asp:BoundColumn DataField="DatPian" HeaderText="Data Pianificata" DataFormatString="{0:d}"></asp:BoundColumn>
											<asp:BoundColumn DataField="Addetto" HeaderText="Addetto"></asp:BoundColumn>
											<asp:BoundColumn DataField="SERVIZIO" HeaderText="Servizio"></asp:BoundColumn>
											<asp:BoundColumn DataField="ditta" HeaderText="Ditta"></asp:BoundColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
							<TR>
								<TD align="center">
									<table border="0" width="85%">
										<tr>
											<td width="85%">
												<uc1:GridTitle id="GridTitle1" runat="server"></uc1:GridTitle>
												<asp:datagrid id="DataGrid2" runat="server" GridLines="Vertical" AllowPaging="True" AutoGenerateColumns="False"
													CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="Gray"
													Width="100%" CssClass="DataGrid">
													<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
													<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
													<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
													<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="wr_id" HeaderText="Richiesta di Lavoro"></asp:BoundColumn>
														<asp:BoundColumn DataField="Apparecchiatura" HeaderText="Apparecchiatura"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Codice Procedura">
															<ItemTemplate>
																<a href='DettProcedurePassi.aspx?pmp=<%#  DataBinder.Eval(Container.DataItem,"ID") + "&pmp_id=" + DataBinder.Eval(Container.DataItem,"CodPMP")%>'>
																	<%# DataBinder.Eval(Container.DataItem,"CodPMP")%>
																</a>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Stato Richiesta">
															<ItemTemplate>
																<asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem,"wo_id") %>' OnCommand="lk_Command" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"StatoRdl") %>' ID="Linkbutton2" />
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="WRDescr" HeaderText="Descrizione"></asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
												</asp:datagrid>
											</td>
										</tr>
									</table>
									<asp:Button Runat="server" Text="Indietro" ID="btIndietro" CssClass="btn"></asp:Button>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
