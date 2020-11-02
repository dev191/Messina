<%@ Page language="c#" Codebehind="ServiziEdifici.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.ServiziEdifici" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ServiziEdifici</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" height="100%" border="0"
				class="tblSearch100Dettaglio">
				<TR height="1%">
					<TD width="20%" align="center" colSpan="2">
						<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 10%" vAlign="top"><iewc:treeview id="TreeCtrl" runat="server" Width="250"></iewc:treeview></TD>
					<TD style="WIDTH: 90%" vAlign="top"><iframe class="fram" id="doc" name="doc" frameBorder="no" width="100%" height="100%" scrolling="auto"
							runat="server"></iframe>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
