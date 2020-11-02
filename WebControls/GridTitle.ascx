<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="GridTitle.ascx.cs" Inherits="TheSite.WebControls.GridTitle" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="tblGridTitle" cellSpacing="1" cellPadding="1" border="0">
	<TR>
		<TD width="20%">
			<cc1:S_HyperLink id="hplsNuovo" runat="server" CssClass="NuovoLink">Nuovo</cc1:S_HyperLink></TD>
		<TD width="60%" align="center">
			<cc1:S_Label id="lblTitleDescription" runat="server"></cc1:S_Label></TD>
		<TD width="20%" align="center">
			<cc1:S_Label id="lblDescrRecord" runat="server">Record:</cc1:S_Label>
			<asp:Label id="lblRecord" runat="server">0</asp:Label></TD>
	</TR>
</TABLE>
