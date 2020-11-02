<%@ Page language="c#" Codebehind="ListLink.aspx.cs" AutoEventWireup="false" Inherits="WebCad.ListLink" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListLink</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="Css/MainSheet.css">
		<script language="javascript">
		 function ApriEq(sender)
		 {
		  var finestra=window.open(sender,"Eq");
		  finestra.focus();
		 }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Repeater id="RepeaterLink" runat="server">
				<HeaderTemplate>
					<table border="0" id="tableLink" width="100%">
						<caption>
							Dettaglio
						</caption>
						<tr>
							<td>&nbsp;</td>
						</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<tr>
						<td><a href="#" runat="server" id="link"></a>
						<hr>
						</td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					</table>
				</FooterTemplate>
			</asp:Repeater>
		</form>
	</body>
</HTML>
