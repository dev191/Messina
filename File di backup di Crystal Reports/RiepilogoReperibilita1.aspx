<%@ Page language="c#" Codebehind="RiepilogoReperibilita1.aspx.cs" AutoEventWireup="false" Inherits="TheSite.CommonPage.RiepilogoReperibilita1" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Reperibiltà Addetti</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Css/MainSheet.css">
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
			<TABLE style="Z-INDEX: 101; POSITION: absolute; TOP: 8px; LEFT: 8px" id="TableMain" border="0"
				cellSpacing="0" cellPadding="0" width="100%" align="center" height="100%">
				<TBODY>
					<tr>
						<td style="HEIGHT: 9px" class="TDCommon"><asp:hyperlink id="HyperLink1" runat="server" Width="56px" Height="16px" NavigateUrl="javascript:Chiudi()"
								Visible="False"><img border="0" src="../Images/chiudi.gif" /></asp:hyperlink>
							<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></td>
					</tr>
					
					</tr>
					<TR vAlign="top">
						<TD vAlign="top"><asp:datagrid id="MyDataGrid1" runat="server" Width="100%" PageSize="5" CssClass="DataGrid" GridLines="Vertical"
								AllowPaging="True" AutoGenerateColumns="False" DataKeyField="id" CellPadding="4" BackColor="White" BorderWidth="1px"
								BorderStyle="None" BorderColor="Gray">
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
									<asp:BoundColumn Visible="False" DataField="zona" HeaderText="Zona">
										<HeaderStyle Width="10em"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="priorita" HeaderText="Priorit&#224;">
										<HeaderStyle Width="7em"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Lun">
										<HeaderStyle Width="5em"></HeaderStyle>
										<ItemStyle Width="11em"></ItemStyle>
										<ItemTemplate>
											<asp:repeater id=RepeaterLunedi runat="server" DataSource='<%# fasce(int.Parse(DataBinder.Eval(Container.DataItem, "id").ToString()),1) %>'>
												<HEADERTEMPLATE>
													<table width="100%" cellspacing="0">
												</HEADERTEMPLATE>
												<ALTERNATINGITEMTEMPLATE>
													<tr>
														<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightblue; TEXT-ALIGN: center">
															<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
														</td>
													</tr>
												</ALTERNATINGITEMTEMPLATE>
												<ITEMTEMPLATE>
													<tr>
														<td style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; FONT-SIZE: 9px; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid; BACKGROUND-COLOR: lightgreen; TEXT-ALIGN: center">
															<%# DataBinder.Eval(Container.DataItem, "Giorno") %>
														</td>
													</tr>
												</ITEMTEMPLATE>
												<FOOTERTEMPLATE>
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
			<PagerStyle HorizontalAlign="Left" CssClass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></TD></TR>
			<tr>
				<td class="TDCommon"><asp:hyperlink id="HyperLinkChiudi2" runat="server" Width="56px" Height="16px" NavigateUrl="javascript:Chiudi()"
						Visible="False"><img border="0" src="../Images/chiudi.gif" /></asp:hyperlink></td>
			</tr>
			</TBODY></TABLE></form>
	</body>
</HTML>
