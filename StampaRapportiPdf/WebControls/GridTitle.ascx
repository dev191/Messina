<%@ Control Language="c#" AutoEventWireup="false" Codebehind="GridTitle.ascx.cs" Inherits="StampaRapportiPdf.WebControls.GridTitle" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<TABLE id="tblGridTitle" cellspacing="1" cellpadding="1" border="0">
	<TR>
		<TD width="20%">
			<CC1:S_HYPERLINK id="hplsNuovo" runat="server" cssclass="NuovoLink">Nuovo</CC1:S_HYPERLINK></TD>
		<TD width="60%" align="center">
			<CC1:S_LABEL id="lblTitleDescription" runat="server"></CC1:S_LABEL></TD>
		<TD width="20%" align="center">
			<CC1:S_LABEL id="lblDescrRecord" runat="server">Record:</CC1:S_LABEL>
			<ASP:LABEL id="lblRecord" runat="server">0</ASP:LABEL></TD>
	</TR>
</TABLE>
