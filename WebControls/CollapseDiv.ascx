<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CollapseDiv.ascx.cs" Inherits="TheSite.WebControls.CollapseDiv" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table width="100%">
	<tr>
		<td bgColor="#6633ff"><asp:imagebutton id="imgSu" runat="server" ImageAlign="Right" ImageUrl="../Images/immagini/uparrows_white.gif"></asp:imagebutton><asp:imagebutton id="imgGiu" runat="server" ImageAlign="Right" ImageUrl="../Images/immagini/downarrows_white.gif"></asp:imagebutton></td>
	</tr>
	<tr>
		<td height="50">
			<DIV id="divCollapse" style="DISPLAY: none; WIDTH: 100%; POSITION: absolute" runat="server">
				<asp:Button id="Button1" runat="server" Text="Button" CssClass="btn"></asp:Button></DIV>
		</td>
	</tr>
</table>
