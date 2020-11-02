<%@ Page language="c#" Codebehind="apparecchiature.aspx.cs" AutoEventWireup="false" Inherits="WebCad.apparecchiature" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Apparecchiature</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript">
		 function Valorizza(sender,sender2)
		 {
		   opener.ValorizzaEq(sender,sender2);
		 }
		</SCRIPT>
	</HEAD>
	<BODY ms_positioning="GridLayout">
		Apparecchiature trovate: <%=elementiTrovati%>
		<FORM id="Form1" method="post" runat="server">
			<ASP:DATAGRID id="MyDataGrid1" runat="server" width="100%" gridlines="Vertical" allowpaging="True"
				cssclass="DataGrid" autogeneratecolumns="False" cellpadding="4" backcolor="White" borderwidth="1px"
				borderstyle="None" bordercolor="Gray">
				<FOOTERSTYLE forecolor="#003399" backcolor="#99CCCC"></FOOTERSTYLE>
				<ALTERNATINGITEMSTYLE cssclass="DataGridAlternatingItemStyle"></ALTERNATINGITEMSTYLE>
				<ITEMSTYLE cssclass="DataGridItemStyle"></ITEMSTYLE>
				<HEADERSTYLE cssclass="DataGridHeaderStyle"></HEADERSTYLE>
				<COLUMNS>
					<ASP:TEMPLATECOLUMN>
						<HEADERSTYLE width="30px"></HEADERSTYLE>
						<ITEMSTYLE horizontalalign="Center"></ITEMSTYLE>
						<ITEMTEMPLATE>
							<A href="#" runat="server" id="hrefset"><IMG border="0" id="imgsele" src="images/forward.png"></A>
						</ITEMTEMPLATE>
					</ASP:TEMPLATECOLUMN>
					<ASP:BOUNDCOLUMN datafield="Descrizione" headertext="Apparecchiature"></ASP:BOUNDCOLUMN>
				</COLUMNS>
				<PAGERSTYLE horizontalalign="Left" forecolor="Black" backcolor="Silver" mode="NumericPages"></PAGERSTYLE>
			</ASP:DATAGRID></FORM>
	</BODY>
</HTML>
