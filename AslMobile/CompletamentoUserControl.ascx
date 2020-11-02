<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CompletamentoUserControl.ascx.cs" Inherits="TheSite.AslMobile.CompletamentoUserControl" TargetSchema="http://schemas.microsoft.com/Mobile/WebUserControl" %>
<P>
	<mobile:panel id="Panel1" runat="server">
		<mobile:DeviceSpecific id="DeviceSpecific1" runat="server">
			<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
				<ContentTemplate>
					<TABLE id="Table2" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
						cellSpacing="0" cellPadding="0" width="130" align="center" border="0">
						<TR>
							<TD align="center" bgColor="#3399cc" colSpan="3">GESTIONE ADDETTI</TD>
						</TR>
						<TR>
							<TD>Modifica Addetto</TD>
							<TD colSpan="2">
								<asp:DropDownList id="cmbsAddetti0" runat="server"></asp:DropDownList></TD>
						</TR>
						<TR>
							<TD></TD>
							<TD>
								<mobile:Command id="cmdModificaODL" onclick="ModificaODL_Click" runat="server">Modifica ODL</mobile:Command></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD align="center" bgColor="#3399cc" colSpan="3">COMPLETAMENTO</TD>
						</TR>
						<TR>
							<TD>Modifica Addetto</TD>
							<TD colSpan="2">
								<asp:DropDownList id="cmbsAddetti1" runat="server"></asp:DropDownList></TD>
						</TR>
						<TR>
							<TD>Data Comp.</TD>
							<TD>
								<asp:TextBox id="txtData" runat="server">Selezionare Data</asp:TextBox></TD>
							<TD>
								<mobile:Command id="cmdData" onclick="Calendar_Click" runat="server">...</mobile:Command></TD>
						</TR>
						<TR>
							<TD></TD>
							<TD>
								<mobile:Command id="cmdCompletaODL" onclick="CompletaODL_Click" runat="server">Completa ODL</mobile:Command></TD>
						</TR>
						<TR>
							<TD colSpan="3">
								<mobile:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtData" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.]((?:19|20)\d\d)$"
									ErrorMessage="La Data di completameto è obbligatoria"></mobile:RegularExpressionValidator></TD>
						</TR>
					</TABLE>
				</ContentTemplate>
			</Choice>
		</mobile:DeviceSpecific>
	</mobile:panel>
	<mobile:panel id="Panel2" runat="server">
		<mobile:DeviceSpecific id="DeviceSpecific2" runat="server">
			<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
				<ContentTemplate>
					<mobile:Calendar id="Calendar1" runat="server" OnSelectionChanged="Calendar_SelectionChangedDataStart"></mobile:Calendar>
				</ContentTemplate>
			</Choice>
		</mobile:DeviceSpecific>
	</mobile:panel>
</P>
