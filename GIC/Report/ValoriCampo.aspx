<%@ Page language="c#" Codebehind="ValoriCampo.aspx.cs" AutoEventWireup="false" Inherits="GIC.Report.ValoriCampo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Ricerca Valori Campo</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript">
		 function Valorizza(val)
		 {
		   opener.ValorizzaVal(val);
		   //window.close();
		 }
		 
		</SCRIPT>
	</HEAD>
	<BODY ms_positioning="GridLayout">
		Valori trovati:
		<%=elementiTrovati%>
		<FORM id="Form1" method="post" runat="server">
			<ASP:DATAGRID id="MyDataGrid1" runat="server" bordercolor="Gray" borderstyle="None" borderwidth="1px"
				backcolor="White" cellpadding="4" autogeneratecolumns="False" cssclass="DataGrid" allowpaging="True"
				gridlines="Vertical" width="100%">
				<FOOTERSTYLE forecolor="#003399" backcolor="#99CCCC"></FOOTERSTYLE>
				<ALTERNATINGITEMSTYLE cssclass="DataGridAlternatingItemStyle"></ALTERNATINGITEMSTYLE>
				<ITEMSTYLE cssclass="DataGridItemStyle"></ITEMSTYLE>
				<HEADERSTYLE cssclass="DataGridHeaderStyle"></HEADERSTYLE>
				<COLUMNS>
					<ASP:TEMPLATECOLUMN>
						<HEADERSTYLE width="30px"></HEADERSTYLE>
						<ITEMSTYLE horizontalalign="Center"></ITEMSTYLE>
						<ITEMTEMPLATE>
							<A href="#" runat="server" id="hrefset"><IMG border="0" id="imgsele" src="../image/forward.png"></A>
						</ITEMTEMPLATE>
					</ASP:TEMPLATECOLUMN>
					<ASP:BOUNDCOLUMN datafield="valore" headertext="Valori"></ASP:BOUNDCOLUMN>
				</COLUMNS>
				<PAGERSTYLE horizontalalign="Left" forecolor="Black" backcolor="Silver" mode="NumericPages"></PAGERSTYLE>
			</ASP:DATAGRID></FORM>
	</BODY>
</HTML>
