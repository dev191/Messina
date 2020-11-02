<%@ Page language="c#" Codebehind="LoginMobile.aspx.cs" Inherits="TheSite.MobileWebForm1" AutoEventWireup="false" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<HEAD>
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="http://schemas.microsoft.com/Mobile/Page" name="vs_targetSchema">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
	<mobile:form id="frmLogin" title="Modulo di Login" Method="Get" runat="server">
		<mobile:Panel id="Panel1" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific1" runat="server">
				<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
					<ContentTemplate>
						<TABLE id="Table2" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="1" cellPadding="1" width="100%" border="0">
							<CAPTION>
								<FONT size="4">USLCT/FONT>
							</CAPTION>
							<TR>
								<TD>User ID:</TD>
								<TD>
									<mobile:TextBox id="txtUserID" runat="server"></mobile:TextBox></TD>
							</TR>
							<TR>
								<TD>Password:</TD>
								<TD>
									<mobile:TextBox id="txtPassword" runat="server" Wrapping="Wrap" Password="True"></mobile:TextBox></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<mobile:Command id="btnLogin" onclick="OnLogin" runat="server">Login</mobile:Command></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<mobile:Label id="lblInvalidLogin" runat="server" ForeColor="Red" Visible="False">*-Invalid Credentials
								</mobile:Label></TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:form>
</body>
