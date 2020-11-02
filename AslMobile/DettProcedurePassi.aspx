<%@ Page language="c#" Codebehind="DettProcedurePassi.aspx.cs" Inherits="TheSite.AslMobile.DettProcedurePassi" AutoEventWireup="false" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<HEAD>
	<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
	<meta name="CODE_LANGUAGE" content="C#">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/Mobile/Page">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
	<mobile:Form id="Form1" runat="server">
		<mobile:Panel id="Panel1" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific1" runat="server">
				<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
					<ContentTemplate>
						<TABLE id="Table6" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="0" cellPadding="0" align="center" border="0">
							<TR>
								<TD>
									<asp:DataGrid id="Datagrid2" runat="server" width="100%" CellPadding="4" BackColor="White" BorderStyle="None"
										PageSize="5" CssClass="DataGrid" AllowPaging="True" BorderColor="Gray" BorderWidth="1px" GridLines="Vertical"
										AutoGenerateColumns="False">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle Font-Size="11px" BackColor="Gainsboro"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
											<asp:BoundColumn DataField="PASSO" HeaderText="Codice Passo" ItemStyle-Height="20"></asp:BoundColumn>
											<asp:BoundColumn DataField="ISTRUZIONE" HeaderText="ISTRUZIONI"></asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:DataGrid></TD>
							</TR>
							<TR>
								<TD>
									<asp:HyperLink id="HyperLink1" runat="server" Font-Size="Larger" NavigateUrl="javascript:history.back()">Indietro</asp:HyperLink></TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:Form>
</body>
