<%@ Page language="c#" Codebehind="RiepilogoReperibilita.aspx.cs" AutoEventWireup="false" Inherits="TheSite.CommonPage.RiepilogoReperibilita" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NavigazioneApparechiature</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function Chiudi()
			{
				var oVDiv=parent.document.getElementById("PopupRep").style;
				oVDiv.display = 'none';
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" height="100%"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<tr>
						<td class="TDCommon" style="HEIGHT: 9px"><asp:hyperlink id="HyperLink1" runat="server" NavigateUrl="javascript:Chiudi()" Height="16px" Width="56px"><img border="0" src="../Images/chiudi.gif" /></asp:hyperlink></td>
					</tr>
					<TR vAlign="top">
						<TD vAlign="top">
							<asp:datagrid id="MyDataGrid1" runat="server" Width="100%" BorderColor="Gray" BorderStyle="None"
								BorderWidth="1px" BackColor="White" CellPadding="4" DataKeyField="id" AutoGenerateColumns="False"
								AllowPaging="True" GridLines="Vertical" CssClass="DataGrid" PageSize="5">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<AlternatingItemStyle CssClass="DataGridAlternatingItemStyleDark"></AlternatingItemStyle>
								<ItemStyle CssClass="DataGridItemStyleDark"></ItemStyle>
								<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="id" HeaderText="ID">
										<HeaderStyle Width="0px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="nominativo" HeaderText="Addetto">
										<HeaderStyle Width="15%"></HeaderStyle>
										<ItemStyle Font-Size="9px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="telefono" HeaderText="Telefono">
										<HeaderStyle Width="12em"></HeaderStyle>
										<ItemStyle Font-Size="9px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cellulare" HeaderText="Cellulare">
										<HeaderStyle Width="12em"></HeaderStyle>
										<ItemStyle Font-Size="9px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="zona" HeaderText="Zona">
										<HeaderStyle Width="10em"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="priorita" HeaderText="Priorit&#224;">
										<HeaderStyle Width="7em"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Lun">
										<HeaderStyle Width="5em"></HeaderStyle>
										<ItemStyle Width="11em"></ItemStyle>
										<ItemTemplate>
											<asp:repeater id=RepeaterLunedi runat="server" DataSource='<%# fasce(int.Parse(DataBinder.Eval(Container.DataItem, "id").ToString()),1) %>'>
												<HeaderTemplate>
													<table width="100%" cellspacing="0">
												</HeaderTemplate>
												<AlternatingItemTemplate>
													<tr>
														<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightblue; TEXT-ALIGN: center">
															<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
														</td>
													</tr>
												</AlternatingItemTemplate>
												<ItemTemplate>
													<tr>
														<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightgreen; TEXT-ALIGN: center">
															<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
														</td>
													</tr>
												</ItemTemplate>
												<FooterTemplate>
			</TABLE>
			</FooterTemplate> </asp:repeater> </ItemTemplate> </asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Mar">
				<HeaderStyle Width="5em"></HeaderStyle>
				<ItemStyle Width="11em"></ItemStyle>
				<ItemTemplate>
					<asp:repeater id="RepeaterMartedi" runat="server" DataSource='<%# fasce(int.Parse(DataBinder.Eval(Container.DataItem, "id").ToString()),2) %>'>
						<HeaderTemplate>
							<table width="100%" cellspacing="0">
						</HeaderTemplate>
						<AlternatingItemTemplate>
							<tr>
								<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightblue; TEXT-ALIGN: center">
									<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
								</td>
							</tr>
						</AlternatingItemTemplate>
						<ItemTemplate>
							<tr>
								<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightgreen; TEXT-ALIGN: center">
									<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
								</td>
							</tr>
						</ItemTemplate>
						<FooterTemplate>
							</table>
						</FooterTemplate>
					</asp:repeater>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Mer">
				<HeaderStyle Width="5em"></HeaderStyle>
				<ItemStyle Width="11em"></ItemStyle>
				<ItemTemplate>
					<asp:repeater id="RepeaterMercoledi" runat="server" DataSource='<%# fasce(int.Parse(DataBinder.Eval(Container.DataItem, "id").ToString()),3) %>'>
						<HeaderTemplate>
							<table width="100%" cellspacing="0">
						</HeaderTemplate>
						<AlternatingItemTemplate>
							<tr>
								<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightblue; TEXT-ALIGN: center">
									<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
								</td>
							</tr>
						</AlternatingItemTemplate>
						<ItemTemplate>
							<tr>
								<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightgreen; TEXT-ALIGN: center">
									<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
								</td>
							</tr>
						</ItemTemplate>
						<FooterTemplate>
							</table>
						</FooterTemplate>
					</asp:repeater>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Gio">
				<HeaderStyle Width="5em"></HeaderStyle>
				<ItemStyle Width="11em"></ItemStyle>
				<ItemTemplate>
					<asp:repeater id="Repeater3" runat="server" DataSource='<%# fasce(int.Parse(DataBinder.Eval(Container.DataItem, "id").ToString()),4) %>'>
						<HeaderTemplate>
							<table width="100%" cellspacing="0">
						</HeaderTemplate>
						<AlternatingItemTemplate>
							<tr>
								<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightblue; TEXT-ALIGN: center">
									<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
								</td>
							</tr>
						</AlternatingItemTemplate>
						<ItemTemplate>
							<tr>
								<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightgreen; TEXT-ALIGN: center">
									<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
								</td>
							</tr>
						</ItemTemplate>
						<FooterTemplate>
							</table>
						</FooterTemplate>
					</asp:repeater>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Ven">
				<HeaderStyle Width="5em"></HeaderStyle>
				<ItemStyle Width="11em"></ItemStyle>
				<ItemTemplate>
					<asp:repeater id="Repeater4" runat="server" DataSource='<%# fasce(int.Parse(DataBinder.Eval(Container.DataItem, "id").ToString()),5) %>'>
						<HeaderTemplate>
							<table width="100%" cellspacing="0">
						</HeaderTemplate>
						<AlternatingItemTemplate>
							<tr>
								<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightblue; TEXT-ALIGN: center">
									<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
								</td>
							</tr>
						</AlternatingItemTemplate>
						<ItemTemplate>
							<tr>
								<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightgreen; TEXT-ALIGN: center">
									<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
								</td>
							</tr>
						</ItemTemplate>
						<FooterTemplate>
							</table>
						</FooterTemplate>
					</asp:repeater>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Sab">
				<HeaderStyle Width="5em"></HeaderStyle>
				<ItemStyle Width="11em"></ItemStyle>
				<ItemTemplate>
					<asp:repeater id="Repeater5" runat="server" DataSource='<%# fasce(int.Parse(DataBinder.Eval(Container.DataItem, "id").ToString()),6) %>'>
						<HeaderTemplate>
							<table width="100%" cellspacing="0">
						</HeaderTemplate>
						<AlternatingItemTemplate>
							<tr>
								<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightblue; TEXT-ALIGN: center">
									<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
								</td>
							</tr>
						</AlternatingItemTemplate>
						<ItemTemplate>
							<tr>
								<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightgreen; TEXT-ALIGN: center">
									<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
								</td>
							</tr>
						</ItemTemplate>
						<FooterTemplate>
							</table>
						</FooterTemplate>
					</asp:repeater>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Dom">
				<HeaderStyle Width="5em"></HeaderStyle>
				<ItemStyle Width="11em"></ItemStyle>
				<ItemTemplate>
					<asp:repeater id="Repeater6" runat="server" DataSource='<%# fasce(int.Parse(DataBinder.Eval(Container.DataItem, "id").ToString()),7) %>'>
						<HeaderTemplate>
							<table width="100%" cellspacing="0">
						</HeaderTemplate>
						<AlternatingItemTemplate>
							<tr>
								<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightblue; TEXT-ALIGN: center">
									<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
								</td>
							</tr>
						</AlternatingItemTemplate>
						<ItemTemplate>
							<tr>
								<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightgreen; TEXT-ALIGN: center">
									<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
								</td>
							</tr>
						</ItemTemplate>
						<FooterTemplate>
							</table>
						</FooterTemplate>
					</asp:repeater>
				</ItemTemplate>
			</asp:TemplateColumn>
			</Columns>
			<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></TD></TR>
			<tr>
				<td class="TDCommon"><asp:hyperlink id="HyperLinkChiudi2" runat="server" NavigateUrl="javascript:Chiudi()" Height="16px"
						Width="56px"><img border="0" src="../Images/chiudi.gif" /></asp:hyperlink></td>
			</tr>
			</TBODY></TABLE>
		</form>
	</body>
</HTML>
