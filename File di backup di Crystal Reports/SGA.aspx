<%@ Page language="c#" Codebehind="SGA.aspx.cs" AutoEventWireup="false" Inherits="TheSite.SgaRtf.SGA" %>
<HTML>
	<HEAD>
	</HEAD>
	<body>
		<form runat="server" id="frm01" method="post">
			<table>
				<tr>
					<td>
						<asp:Label id="lblWrID" runat="server">WrId</asp:Label>
					</td>
					<td>
						<asp:TextBox id="txtWrId" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Button id="btnGenera" Text="Genera Doc" runat="server"></asp:Button>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
