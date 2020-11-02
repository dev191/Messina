<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Page language="c#" Codebehind="Rcompleta.aspx.cs" Inherits="TheSite.AslMobile.Rcompleta" AutoEventWireup="false" %>
<HEAD>
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="http://schemas.microsoft.com/Mobile/Page" name="vs_targetSchema">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
	<mobile:form id="Form1" title="Gestione e Completamento" runat="server">
		<mobile:Panel id="pnlGestioneComp" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific3" runat="server">
				<Choice Filter="isHTML32" Xmlns="Mobile HTML3.2 Template">
					<ContentTemplate>
						<TABLE id="Table11" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 75%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							height="80%" cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
							<TR>
								<TD>Cod.Edi</TD>
								<TD>
									<mobile:TextBox id="txtCodiceEdificio" runat="server" Size="15"></mobile:TextBox>
								</TD>
								<TD>
									<mobile:Command id="RicercaEdifici" onclick="OnRicercaEdifici" runat="server">...</mobile:Command>
								</TD>
							</TR>
							<TR>
								<TD>Richiesta</TD>
								<TD colSpan="2">
									<mobile:TextBox id="txtRichiesta" runat="server" Size="15" Numeric="True"></mobile:TextBox>
								</TD>
							</TR>
							<TR>
								<TD>Ordine</TD>
								<TD colSpan="2">
									<mobile:TextBox id="txtOrdineLavoro" runat="server" Size="15"></mobile:TextBox>
								</TD>
							</TR>
							<TR>
								<TD>Data Creazione</TD>
								<TD>
									<asp:TextBox id="txtDataCreazione" runat="server" Columns="15" Enabled="False" ReadOnly="True"></asp:TextBox>
								</TD>
								<TD>
									<mobile:Command id="cmdDataS" onclick="OnDataSelect" runat="server">...</mobile:Command>
								</TD>
							</TR>
							<TR>
								<TD>Richiedente</TD>
								<TD>
									<mobile:TextBox id="txtRichiedente" runat="server" Size="15"></mobile:TextBox>
								</TD>
								<TD>
									<mobile:Command id="RicercaRichiedente" onclick="OnRicercaRichiedente" runat="server">...</mobile:Command>
								</TD>
							</TR>
							<TR>
								<TD>Gruppo</TD>
								<TD colSpan="2">
									<asp:DropDownList id="cmbsGruppo" runat="server"></asp:DropDownList>
								</TD>
							</TR>
							<TR>
								<TD>Descrizione</TD>
								<TD colSpan="2">
									<mobile:TextBox id="txtDescrizione" runat="server" Size="15"></mobile:TextBox>
								</TD>
							</TR>
							<TR>
								<TD>Servizio</TD>
								<TD colSpan="2">
									<asp:DropDownList id="cmbsServizio" runat="server" Width="100%"></asp:DropDownList>
								</TD>
							</TR>
							<TR>
								<TD>Urgenza</TD>
								<TD colSpan="2">
									<asp:DropDownList id="cmbsPriority" runat="server" Width="100%"></asp:DropDownList>
								</TD>
							</TR>
							<TR>
								<TD>
									<mobile:Command id="cmdRicerca" onclick="OnRicerca" runat="server">Ricerca</mobile:Command>
								</TD>
								<TD colSpan="2">
									<mobile:Link id="Link2" runat="server" NavigateUrl="Default.aspx" Font-Size="Large">Home Page</mobile:Link>
								</TD>
							</TR>
							<TR>
								<TD colSpan="3">
									<mobile:RegularExpressionValidator id="ValidatorOrdine" runat="server" ErrorMessage='Il campo "Ordine" deve essere un Numero'
										ControlToValidate="txtOrdineLavoro" ValidationExpression="\d{0,}"></mobile:RegularExpressionValidator>
									<mobile:RegularExpressionValidator id="ValidatorRichiesta" runat="server" ErrorMessage='Il campo "Richiesta" deve essere un Numero'
										ControlToValidate="txtRichiesta" ValidationExpression="\d{0,}"></mobile:RegularExpressionValidator>
								</TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:form>
	<mobile:form id="Form2" runat="server">
		<mobile:Panel id="Panel1" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific1" runat="server">
				<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
					<ContentTemplate>
						<TABLE style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 75%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="0" cellPadding="0" align="center">
							<TR>
								<TD>
									<mobile:Label id="lblDescrizione" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:datagrid id="DataGridEdifici" runat="server" Width="100%" Height="50%" PageSize="5" BorderColor="Gray"
										BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="2" AutoGenerateColumns="False"
										CssClass="DataGrid" AllowPaging="True" GridLines="Vertical">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle Font-Size="11px" BackColor="Gainsboro"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="Cod. Edificio">
												<ItemTemplate>
													<asp:LinkButton id="linkbt" Runat="server" OnCommand="imageButton_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"bl_id") %>' Font-Size="Large">
														<%# DataBinder.Eval(Container.DataItem,"bl_id") %>
													</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="denominazione" HeaderText="Nome Edificio"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="id" HeaderText="Id. Edificio"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
							<TR>
								<TD>
									<asp:DataGrid id="DataGridRichiedente" runat="server" Width="100%" BorderColor="Gray" BorderStyle="None"
										BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False" CssClass="DataGrid"
										AllowPaging="True" GridLines="Vertical">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle Font-Size="11px" BackColor="Gainsboro"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="Richiedente">
												<ItemTemplate>
													<asp:LinkButton Runat="server" CausesValidation="False" OnCommand="Operatore_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Richiedente") %>' ID="Linkbutton1" NAME="Linkbutton1" Font-Size="Large">
														<%# DataBinder.Eval(Container.DataItem,"Richiedente") %>
													</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
									</asp:DataGrid></TD>
							</TR>
							<TR>
								<TD>
									<asp:LinkButton id="LinkButton2" onclick="OnBack" runat="server" Font-Size="Large">Indietro</asp:LinkButton></TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:form>
	<mobile:Form id="Form4" runat="server">
		<mobile:Panel id="Panel2" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific4" runat="server">
				<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
					<ContentTemplate>
						<mobile:Calendar id="Calendar1" runat="server" OnSelectionChanged="Calendar_SelectionChangedDataStart"></mobile:Calendar>
						<mobile:Link id="Link3" runat="server" NavigateUrl="#Form1" Font-Size="Large">Indietro</mobile:Link>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:Form>
	<mobile:form id="Form3" runat="server">
		<mobile:Panel id="PnlRicerca" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific2" runat="server">
				<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
					<ContentTemplate>
						<TABLE style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 75%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="0" cellPadding="0" align="center">
							<TR>
								<TD>
									<mobile:Label id="lblDscrizioneRicerca" runat="server"></mobile:Label></TD>
							</TR>
							<TR>
								<TD>
									<asp:datagrid id="DataGridRicerca" runat="server" Height="50%" PageSize="5" BorderColor="Gray"
										BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="2" AutoGenerateColumns="False"
										CssClass="DataGrid" AllowPaging="True" GridLines="Vertical" Width="100%">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle Font-Size="11px" BackColor="Gainsboro"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="Cod.Edificio">
												<ItemTemplate>
													<asp:LinkButton ID="linkbtedi" Runat="server" OnCommand="imageButtonEdit_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"var_wr_wr_id") %>' Font-Size="Large">
														<%# DataBinder.Eval(Container.DataItem,"var_bl_id") %>
													</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="IndEdificio" HeaderText="Indirizzo"></asp:BoundColumn>
											<asp:BoundColumn DataField="var_wr_wr_id" HeaderText="RdL"></asp:BoundColumn>
											<asp:BoundColumn DataField="var_wr_wo_id" HeaderText="OdL"></asp:BoundColumn>
											<asp:BoundColumn DataField="descrizione" HeaderText="Servizio"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Descrizione">
												<ItemTemplate>
													<%# ValutaStringa(DataBinder.Eval(Container.DataItem,"var_wr_descrizione")) %>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
							<TR>
								<TD>
									<mobile:Link id="Link1" runat="server" NavigateUrl="#Form1" Font-Size="Large">Indietro</mobile:Link></TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:form>
</body>
