<%@ Control Language="c#" AutoEventWireup="false" Codebehind="PageTitle.ascx.cs" Inherits="WebCad.WebControls.PageTitle" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table1" height="50" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD width="5%"></TD>
		<TD align="left"><span class="MainTitle" id="spanMainTitle" runat="server"></span><br>
			<span class="Title" id="spanTitle" runat="server"></span>
		</TD>
		<TD vAlign="top" align="right" width="25%">
			<asp:PlaceHolder id="PlaceHolder1" runat="server">
			<asp:label id="lblOperatore" runat="server" CssClass="LabelOperatore"></asp:label>&nbsp; 
			| <A class="LabelLogout" id="logoutlinnk" href="../Logoff.aspx" runat="server">Logout</A>&nbsp;|&nbsp;<asp:HyperLink id="lblHome" runat="server" CssClass="LabelOperatore"></asp:HyperLink></asp:PlaceHolder></TD>
	</TR>
</TABLE>
  