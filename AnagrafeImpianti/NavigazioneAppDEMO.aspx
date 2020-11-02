<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Page language="c#" Codebehind="NavigazioneAppDEMO.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.NavigazioneAppDEMO" %>
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
			function valorizza(){
					if (parent.left != null){
					parent.left.valorizza();
				}
			}		
		</SCRIPT>
	</HEAD>
	<BODY onbeforeunload="valorizza()" ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellspacing="0"
				cellpadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center">
							<UC1:PAGETITLE id="PageTitle1" runat="server"></UC1:PAGETITLE></TD>
					</TR>
					<TR valign="top">
						<TD valign="top">
							<UC1:GRIDTITLE id="GridTitle1" runat="server"></UC1:GRIDTITLE>
							<ASP:DATAGRID id="MyDataGrid1" runat="server" width="100%" bordercolor="Gray" borderstyle="None"
								borderwidth="1px" backcolor="White" cellpadding="4" autogeneratecolumns="False" cssclass="DataGrid"
								allowpaging="True" gridlines="Vertical" pagesize="20">
								<FOOTERSTYLE forecolor="#003399" backcolor="#99CCCC"></FOOTERSTYLE>
								<ALTERNATINGITEMSTYLE cssclass="DataGridAlternatingItemStyle"></ALTERNATINGITEMSTYLE>
								<ITEMSTYLE cssclass="DataGridItemStyle"></ITEMSTYLE>
								<HEADERSTYLE cssclass="DataGridHeaderStyle"></HEADERSTYLE>
								<COLUMNS>
									<ASP:BOUNDCOLUMN datafield="bl_id" headertext="Cod.Edificio"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="eq_id" headertext="Cod. Apparecchiatura"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="std" headertext="Std. Apparecchiatura"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="descrizione" headertext="Servizio"></ASP:BOUNDCOLUMN>
								</COLUMNS>
								<PAGERSTYLE horizontalalign="Left" forecolor="Black" backcolor="Silver" mode="NumericPages"></PAGERSTYLE>
							</ASP:DATAGRID>
							<ASP:BUTTON id="BntIndietro" runat="server" text="Indietro"></ASP:BUTTON>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</FORM>
		<SCRIPT language="javascript">
		if (parent.left != null){
			parent.left.calcola();
		}
		</SCRIPT>
	</BODY>
</HTML>
