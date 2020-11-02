<%@ Page language="c#" Codebehind="DisplayRapportino.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.Schedula.DisplayRapportino" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DisplayRapportino</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<tr>
					<td align="left">
						<CR:CrystalReportViewer id="CRView" runat="server" Width="350px" Height="50px"></CR:CrystalReportViewer>
					</td>
				</tr>
			</TABLE>
			<asp:TextBox id="txtTipo" style="Z-INDEX: 103; LEFT: 168px; POSITION: absolute; TOP: 80px" runat="server"
				Visible="False"></asp:TextBox>
			<asp:TextBox id="txtHid" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 80px" runat="server"
				Visible="False"></asp:TextBox>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
