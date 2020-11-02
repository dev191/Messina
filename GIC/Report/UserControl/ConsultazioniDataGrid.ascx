<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ConsultazioniDataGrid.ascx.cs" Inherits="GIC.Report.UserControl.ConsultazioniDataGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="../style/StyleSheetReport.css" type="text/css" rel="stylesheet">
<TABLE width="100%">
	<TR>
		<TD colspan="2" width="100%">
		</TD>
	</TR>
	<TR>
		<TD width="100%">
			<ASP:DATAGRID id="DataGridQuery" runat="server" autogeneratecolumns="True" headerstyle-cssclass="DataGridHeaderStyle"
				itemstyle-cssclass="DataGridItemStyle" alternatingitemstyle-cssclass="DataGridAlternatingItemStyle"
				width="100%" enableviewstate="False"></ASP:DATAGRID>
		</TD>
	</TR>
</TABLE>
