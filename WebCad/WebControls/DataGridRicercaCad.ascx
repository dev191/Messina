<%@ Control Language="c#" AutoEventWireup="false" Codebehind="DataGridRicercaCad.ascx.cs" Inherits="WebCad.WebControls.DataGridRicercaCad" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language="javascript">
	function fnClear(){
		window.location="<%=nomeScript%>?clear=true;";
	}
</script>
<DIV id="divdatagrid" style="BACKGROUND-COLOR: #ffffff" runat="server">
	<B>Elementi trovati:
		<ASP:LABEL id="LabelElementiTrovati" runat="server"></ASP:LABEL></B><BR>
	<ASP:PLACEHOLDER id="PlaceHolder1" runat="server"></ASP:PLACEHOLDER><BR>
	<TABLE id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
		<TR>
			<TD width="33%">&nbsp;<INPUT type="button" value="Pulisci" id="clear" onclick="fnClear();"></TD>
			<TD width="33%">&nbsp;</TD>
			<TD width="33%" align="right">
				record per pagina:
				<ASP:DROPDOWNLIST id="DropDownList1" runat="server" autopostback="True">
					<ASP:LISTITEM value="10">10</ASP:LISTITEM>
					<ASP:LISTITEM value="20">20</ASP:LISTITEM>
					<ASP:LISTITEM value="30">30</ASP:LISTITEM>
					<ASP:LISTITEM value="40">40</ASP:LISTITEM>
					<ASP:LISTITEM value="50">50</ASP:LISTITEM>
					<ASP:LISTITEM value="100">100</ASP:LISTITEM>
					<ASP:LISTITEM value="200">200</ASP:LISTITEM>
				</ASP:DROPDOWNLIST>
			</TD>
		</TR>
	</TABLE>
	<ASP:LABEL id="LabelResp" runat="server"></ASP:LABEL></DIV>
