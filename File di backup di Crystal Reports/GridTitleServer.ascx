<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="GridTitleServer.ascx.cs" Inherits="TheSite.WebControls.GridTitleServer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="tblGridTitle" cellSpacing="1" cellPadding="1" border="0">
	<TR>
		<TD width="40%">
			<asp:LinkButton id="hplsNuovo" runat="server" CssClass="NuovoLink">Nuovo</asp:LinkButton></TD>
		<TD width="40%"></TD>
		<TD width="20%" align="center">
			<asp:Label id="lblRecord" runat="server">0</asp:Label></TD>
	</TR>
</TABLE>
