<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Page language="c#" Codebehind="Default.aspx.cs" Inherits="TheSite.AslMobile._Default" AutoEventWireup="false" %>
<HEAD>
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="http://schemas.microsoft.com/Mobile/Page" name="vs_targetSchema">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
	<mobile:form id="Form1" runat="server">
		<mobile:Panel id="Panel1" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific1" runat="server">
				<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
					<ContentTemplate>
						<TABLE id="Table2" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="1" cellPadding="1" width="100%" border="0">
							<CAPTION>
								<FONT size="4">WFP
									<mobile:Label id="lblUtente" runat="server"></mobile:Label></FONT></CAPTION>
							<TR>
								<TD colSpan="2">
									<mobile:Image id="Image1" runat="server" ImageUrl="images/logo2.jpg"></mobile:Image></TD>
							</TR>
							<TR>
								<TD colSpan="2"><B>Manutenzione su Richiesta</B>
									<HR>
								</TD>
							</TR>
							<TR>
								<TD>
									<mobile:Image id="Image2" runat="server" ImageUrl="images/Nota1.gif"></mobile:Image></TD>
								<TD>
									<mobile:Link id="lkRichiesta" runat="server" Font-Size="Large" NavigateUrl="Richiesta.aspx">Creazione Richieta di Lavoro</mobile:Link></TD>
							</TR>
							<TR>
								<TD>
									<mobile:Image id="Image3" runat="server" ImageUrl="images/Nota2.gif"></mobile:Image></TD>
								<TD>
									<mobile:Link id="Link2" runat="server" Font-Size="Large" NavigateUrl="Rcompleta.aspx">Gestione Completamento</mobile:Link></TD>
							</TR>
							<TR>
								<TD colSpan="2"><B>Manutenzione Preventiva</B>
									<HR>
								</TD>
							</TR>
							<TR>
								<TD>
									<mobile:Image id="Image5" runat="server" ImageUrl="images/Nota3.gif"></mobile:Image></TD>
								<TD>
									<mobile:Link id="Link1" runat="server" Font-Size="Large" NavigateUrl="CompletamentoMP.aspx">Completamento MP</mobile:Link></TD>
							</TR>
							<TR>
								<TD colSpan="2"><B>Gestione</B>
									<HR>
								</TD>
							</TR>
							<TR>
								<TD>
									<mobile:Image id="Image4" runat="server" ImageUrl="images/uscita.gif"></mobile:Image></TD>
								<TD>
									<mobile:Link id="Link3" runat="server" Font-Size="Large" NavigateUrl="LogOut.aspx">Disconnetti</mobile:Link></TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:form>
</body>
