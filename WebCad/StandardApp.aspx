<%@ Page language="c#" Codebehind="StandardApp.aspx.cs" AutoEventWireup="false" Inherits="WebCad.StandardApp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>StandardApp</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
		 function Valorizza(sender,sender2)
		 {
		   window.opener.ValorizzaEqstd(sender,sender2);
		 }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		Standard trovati: <%=elementiTrovati%>
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="MyDataGrid1" runat="server" Width="100%" GridLines="Vertical" AllowPaging="True"
				CssClass="DataGrid" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderWidth="1px"
				BorderStyle="Solid" BorderColor="Gray">
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
					<asp:BoundColumn DataField="Descrizione" HeaderText="Standard Apparecchiature"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="Black" BackColor="Silver" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></form>
	</body>
</HTML>
