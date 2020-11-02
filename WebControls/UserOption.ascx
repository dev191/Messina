<%@ Control Language="c#" AutoEventWireup="false" Codebehind="UserOption.ascx.cs" Inherits="TheSite.WebControls.UserOption" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table border="1">
	<tr>
		<td>
			<asp:RadioButtonList id="RadioButtonList1" runat="server">
<asp:ListItem Value="4">
					&lt;b&gt;Chiusa&lt;/b&gt;</asp:ListItem>
<asp:ListItem Value="15">
					&lt;b&gt;Sospesa&lt;/b&gt;</asp:ListItem>
			</asp:RadioButtonList>
		</td>
		<td>
			<asp:TextBox id="TxtSospesa" runat="server" Width="200px"></asp:TextBox>
		</td>
	</tr>
</table>
