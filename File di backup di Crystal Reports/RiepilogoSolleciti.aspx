<%@ Page language="c#" Codebehind="RiepilogoSolleciti.aspx.cs" AutoEventWireup="false" Inherits="TheSite.CommonPage.RiepilogoSolleciti" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>NavigazioneApparechiature</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
			function Chiudi()
			{
				var oVDiv=parent.document.getElementById("PopupVisSoll").style;
				oVDiv.display = 'none';
			}
		</SCRIPT>
	</HEAD>
	<BODY ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" height="100%"
				cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD class="TDCommon" style="HEIGHT: 9px"><ASP:HYPERLINK id="HyperLink1" runat="server" width="56px" height="16px" navigateurl="javascript:Chiudi()"><IMG border="0" src="../Images/chiudi.gif" /></ASP:HYPERLINK></TD>
					</TR>
					<TR valign="top">
						<TD valign="top"><ASP:DATAGRID id="MyDataGrid1" runat="server" width="100%" pagesize="5" cssclass="DataGrid" gridlines="Vertical"
								allowpaging="True" autogeneratecolumns="False" datakeyfield="id" cellpadding="4" backcolor="White" borderwidth="1px"
								borderstyle="None" bordercolor="Gray">
								<FOOTERSTYLE forecolor="#003399" backcolor="#99CCCC"></FOOTERSTYLE>
								<ALTERNATINGITEMSTYLE cssclass="DataGridAlternatingItemStyle"></ALTERNATINGITEMSTYLE>
								<ITEMSTYLE cssclass="DataGridItemStyle"></ITEMSTYLE>
								<HEADERSTYLE cssclass="DataGridHeaderStyle"></HEADERSTYLE>
								<COLUMNS>
									<ASP:BOUNDCOLUMN visible="False" datafield="id" headertext="ID">
										<HEADERSTYLE width="0px"></HEADERSTYLE>
									</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="richiedente" headertext="Richiedente">
										<HEADERSTYLE width="30%"></HEADERSTYLE>
										<ITEMSTYLE font-size="9px"></ITEMSTYLE>
									</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="descrizione" headertext="Motivazione">
										<HEADERSTYLE width="45%"></HEADERSTYLE>
										<ITEMSTYLE font-size="9px"></ITEMSTYLE>
									</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="data_sollecito" headertext="Data/Ora">
										<HEADERSTYLE width="25%"></HEADERSTYLE>
										<ITEMSTYLE font-size="9px"></ITEMSTYLE>
									</ASP:BOUNDCOLUMN>
								</COLUMNS>
								<PAGERSTYLE horizontalalign="Left" cssclass="DataGridPagerStyle" mode="NumericPages"></PAGERSTYLE>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="TDCommon"><ASP:HYPERLINK id="HyperLinkChiudi2" runat="server" width="56px" height="16px" navigateurl="javascript:Chiudi()"><IMG border="0" src="../Images/chiudi.gif" /></ASP:HYPERLINK></TD>
					</TR>
				</TBODY>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
