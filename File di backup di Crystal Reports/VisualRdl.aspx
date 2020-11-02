<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Page language="c#" Codebehind="VisualRdl.aspx.cs" Inherits="TheSite.AslMobile.VisualRdl" AutoEventWireup="false" %>
<HEAD>
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="http://schemas.microsoft.com/Mobile/Page" name="vs_targetSchema">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
	<mobile:form id="Form1" title="Visualizza" runat="server">
		<mobile:Panel id="Panel1" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific1" runat="server">
				<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
					<ContentTemplate>
						<TABLE id="Table11" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" bgColor="#3399cc" colSpan="2"><EM>RICHIESTA</EM></TD>
							</TR>
							<TR>
								<TD>RDL</TD>
								<TD>
									<mobile:Label id="lblRDL" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>OPERATORE:</TD>
								<TD>
									<mobile:Label id="lblOperatore" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>DATA:</TD>
								<TD>
									<mobile:Label id="lblData" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>ORA:</TD>
								<TD>
									<mobile:Label id="lblOra" runat="server"></mobile:Label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table12" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" bgColor="#3399cc" colSpan="2"><EM>DATI RICHIEDENTI</EM></TD>
							</TR>
							<TR>
								<TD>RICHIEDENTE:</TD>
								<TD>
									<mobile:Label id="lblRichedente" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>GRUPPO:</TD>
								<TD>
									<mobile:Label id="lblGruppo" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>TELEFONO:</TD>
								<TD>
									<mobile:Label id="lblTelefono" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>NOTA:</TD>
								<TD>
									<mobile:Label id="lblNota" runat="server"></mobile:Label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table13" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" bgColor="#3399cc" colSpan="2"><EM>DATI UBICAZIONE</EM></TD>
							</TR>
							<TR>
								<TD>COD EDIFICIO:</TD>
								<TD>
									<mobile:Label id="lblCodEdificio" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>DENOMINAZIONE:</TD>
								<TD>
									<mobile:Label id="lblDenominazione" runat="server"></mobile:Label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table14" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center" bgColor="#3399cc" colSpan="2"><EM>DATI RICHIESTA</EM></TD>
							</TR>
							<TR>
								<TD>DESCRIZIONE:</TD>
								<TD>
									<mobile:Label id="lblDescrizione" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>URGENZA:</TD>
								<TD>
									<mobile:Label id="lblUrgenza" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>SERVIZIO:</TD>
								<TD>
									<mobile:Label id="lblServizio" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>STD. APP:</TD>
								<TD>
									<mobile:Label id="lblStdApparacchiatura" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>APPARECCHIATURA:</TD>
								<TD>
									<mobile:Label id="lblApparacchiatura" runat="server"></mobile:Label></TD>
							</TR>
						</TABLE>
						<mobile:Link id="Link1" runat="server" Font-Size="Large" NavigateUrl="Default.aspx">Home Page</mobile:Link>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:form>
</body>
