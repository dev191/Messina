<%@ Page language="c#" Codebehind="LogOut.aspx.cs" Inherits="TheSite.AslMobile.LogOut" AutoEventWireup="false" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<HEAD>
	<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
	<meta name="CODE_LANGUAGE" content="C#">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/Mobile/Page">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
	<mobile:Form id="Form1" runat="server" title="Logout WFP Mobile">
		<mobile:Panel id="Panel1" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific1" runat="server">
				<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
					<ContentTemplate>
						<TABLE id="Table2" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="1" cellPadding="1" width="100%" border="0">
							<CAPTION>
								<FONT size="4">WFP</FONT>
							</CAPTION>
							<TR>
								<TD>
									<mobile:Command id="Command2" onclick="OnDisconnetti" runat="server">Disconnetti</mobile:Command></TD>
							</TR>
							<TR>
								<TD>
									<mobile:Link id="Link1" runat="server" NavigateUrl="Default.aspx" Font-Size="Large">Home Page</mobile:Link></TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:Form>
</body>
