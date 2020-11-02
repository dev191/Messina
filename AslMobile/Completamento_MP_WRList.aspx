<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Register TagPrefix="uc1" TagName="Calendario" Src="./calendarioUserControl.ascx" %>
<%@ Page language="c#" Codebehind="Completamento_MP_WRList.aspx.cs" Inherits="AslMobile.Completamento_MP_WRList" AutoEventWireup="false" %>
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
						<TABLE id="Table6" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="0" cellPadding="0" align="center" border="0">
							<TR>
								<TD>Ordine Lavoro</TD>
								<TD>
									<mobile:Label id="lblOrdineLavoro" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>Edificio</TD>
								<TD>
									<mobile:Label id="lblEdificio" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>Indirizzo</TD>
								<TD>
									<mobile:Label id="lblIndirizzo" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>Data ODL</TD>
								<TD>
									<mobile:Label id="lblODL" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>Data Pianificata</TD>
								<TD>
									<mobile:Label id="lblDataPianificata" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:DataGrid id="DataGridRicerca1" runat="server" AutoGenerateColumns="False" GridLines="Vertical"
										BorderWidth="1px" BorderColor="Gray" AllowPaging="True" CssClass="DataGrid" PageSize="5" BorderStyle="None"
										BackColor="White" CellPadding="4" width="100%">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle Font-Size="11px" BackColor="Gainsboro"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton Enabled="False" ImageUrl="images/verde.gif" Runat="server" ID="Imagebutton1"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID1"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="RDL">
												<ItemTemplate>
													<asp:LinkButton Runat="server" CausesValidation="False" OnCommand="RDL_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID") + ":" +DataBinder.Eval(Container.DataItem,"idstatus") + ":" + DataBinder.Eval(Container.DataItem,"MotivoSospensione")%>' ID="Linkbutton2" NAME="Linkbutton1" Font-Size="Large">
														<%# DataBinder.Eval(Container.DataItem,"Id") %>
													</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Codice Procedura">
												<ItemTemplate>
													<a href='DettProcedurePassi.aspx?pmp=<%#  DataBinder.Eval(Container.DataItem,"id_Pm") + "&pmp_id=" + DataBinder.Eval(Container.DataItem,"CodiceProcedura")%>'>
														<%# DataBinder.Eval(Container.DataItem,"CodiceProcedura")%>
													</a>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="Apparecchiatura" HeaderText="Apparecchiatura"></asp:BoundColumn>
											<asp:BoundColumn DataField="StatoRichiesta" HeaderText="Stato Richiesta"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="descrizione" HeaderText="Descrizione"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="MotivoSospensione" HeaderText="Motivo Sospensione"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="idstatus" HeaderText="idstatus"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
									</asp:DataGrid></TD>
							</TR>
							<TR>
								<TD>
									<mobile:Link id="Link1" runat="server" NavigateUrl="Default.aspx" Font-Size="Large">Home Page</mobile:Link></TD>
								<TD><mobile:Link id="Link2" runat="server" NavigateUrl="CompletamentoMP.aspx" Font-Size="Large">Indietro</mobile:Link></TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:form>
	<mobile:form id="Form2" runat="server">
		<mobile:Panel id="pnlDettagli" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific2" runat="server">
				<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
					<ContentTemplate>
						<TABLE id="Table1" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="0" cellPadding="0" align="center" border="0">
							<TR>
								<TD><B>Check</B></TD>
								<TD colSpan="2"><B>Modivo della sospensione</B></TD>
							</TR>
							<TR>
								<TD>
									<asp:RadioButtonList id="RadioButtonList1" runat="server" OnSelectedIndexChanged="Index_Changed" AutoPostBack="True">
										<asp:ListItem Value="4">Chiusa</asp:ListItem>
										<asp:ListItem Value="15">Sospesa</asp:ListItem>
									</asp:RadioButtonList></TD>
								<TD colSpan="2">
									<asp:TextBox id="TextBox2" runat="server"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD><B>Data</B></TD>
								<TD>
									<mobile:Label id="lblCalendario" runat="server"></mobile:Label></TD>
								<TD>
									<mobile:Command id="cmdCalendario" onclick="OnCalendario" runat="server">....</mobile:Command></TD>
							</TR>
							<TR>
								<TD>
									<mobile:Command id="cmdSave" onclick="OnSalva" runat="server">Salva</mobile:Command></TD>
								<TD colSpan="2">
									<mobile:Command id="cmdAnnulla" onclick="OnAnnulla" runat="server">Annulla</mobile:Command></TD>
							</TR>
							<TR>
								<TD colSpan="3">
									<uc1:Calendario id="Calendario1" runat="server"></uc1:Calendario></TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:form>
</body>
