<%@ Page language="c#" Codebehind="Stanze.aspx.cs" AutoEventWireup="false" Inherits="WebCad.Stanze" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Stanze</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		 function Valorizza(sender,sender2)
		 {
		   opener.ValorizzaStanze(sender,sender2);
		 }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		Stanze trovate: <%=elementiTrovati%>
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="MyDataGrid1" runat="server" Width="100%" GridLines="Vertical" AllowPaging="True"
				CssClass="DataGrid" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderWidth="1px"
				BorderStyle="None" BorderColor="Gray">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
				<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
				<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn>
						<HeaderStyle Width="30px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<a href="#" runat="server" id="hrefset"><img border="0" id="imgsele" src="images/forward.png"></a>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Descrizione" HeaderText="Stanze"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="Black" BackColor="Silver" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></form>
	</body>
</HTML>
