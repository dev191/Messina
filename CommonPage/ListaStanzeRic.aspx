<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Page language="c#" Codebehind="ListaStanzeRic.aspx.cs" AutoEventWireup="false" Inherits="TheSite.CommonPage.ListaStanzeRic" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ListaStanze</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Chiudi()
		{
			var oVDiv=parent.document.getElementById("PopupAppst").style;
			oVDiv.display = 'none';
		}
			function Popolast(sender,codice)
		{
			parent.document.getElementById(idUsercontrol1 + "_" + "s_txtDescStanza").innerText=sender;
			parent.document.getElementById(idUsercontrol1 + "_" + "TxtIdStanza").innerText=codice;
			Chiudi();       
		}
		</script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" width="100%"
				border="0">
				<TR>
					<TD class="TDCommon"><asp:hyperlink id="HyperLink1" runat="server" Width="56px" Height="16px" NavigateUrl="javascript:Chiudi()">
							<img border="0" src="../Images/chiudi.gif" /></asp:hyperlink></TD>
				</TR>
				<TR>
					<TD width="100%"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="MyDataGrid1" AllowCustomPaging="True" runat="server" Width="100%" PageSize="5"
							GridLines="Vertical" AllowPaging="True" CssClass="DataGrid" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="Gray">
<FooterStyle ForeColor="#003399" BackColor="#99CCCC">
</FooterStyle>

<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle">
</AlternatingItemStyle>

<ItemStyle CssClass="DataGridItemStyle">
</ItemStyle>

<HeaderStyle CssClass="DataGridHeaderStyle">
</HeaderStyle>

<Columns>
<asp:TemplateColumn>
<HeaderStyle Width="30px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>

<ItemTemplate>
										<a href="" runat="server" id="hrefset"><img border="0" id="imgsele" src="../Images/edit.gif"></a>
									
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="Stanza" HeaderText="Descrizione Stanza"></asp:BoundColumn>
<asp:BoundColumn DataField="Piano" HeaderText="Piano"></asp:BoundColumn>
<asp:BoundColumn Visible="False" HeaderText="Edificio"></asp:BoundColumn>
<asp:BoundColumn Visible="False"></asp:BoundColumn>
</Columns>

<PagerStyle HorizontalAlign="Left" ForeColor="Black" BackColor="Silver" Mode="NumericPages">
</PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD class="TDCommon"><asp:hyperlink id="HyperLinkChiudi2" runat="server" Width="56px" Height="16px" NavigateUrl="javascript:Chiudi()">
							<img border="0" src="../Images/chiudi.gif" /></asp:hyperlink></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
