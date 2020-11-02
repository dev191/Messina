<%@ Page language="c#" Codebehind="Richiesta.aspx.cs" Inherits="TheSite.AslMobile.Richiesta" AutoEventWireup="false" %>
<%@ Register TagPrefix="uc1" TagName="CreazioneRichiesta1" Src="./CreazioneRichiesta1.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CreazioneRichiesta2" Src="./CreazioneRichiesta2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CreazioneRichiesta3" Src="./CreazioneRichiesta3.ascx" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<HEAD>
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="http://schemas.microsoft.com/Mobile/Page" name="vs_targetSchema">
	<LINK href="style/StyleMobile.css" type="text/css" rel="stylesheet"></LINK>
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
	<mobile:form id="Form1" title="Ricerca Edificio" runat="server">
		<mobile:Panel id="Panel2" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific1" runat="server">
				<Choice Filter="isHTML32" Xmlns="Mobile HTML3.2 Template">
					<ContentTemplate>
						<TABLE id="tablella" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 75%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="0" cellPadding="0" align="center">
							<CAPTION>
								<FONT size="4">WFP</FONT>
							</CAPTION>
							<TR>
								<TD></TD>
								<TD>Ricerca Edificio</TD>
							</TR>
							<TR>
								<TD>Codice:</TD>
								<TD>
									<mobile:TextBox id="txtCodice" runat="server"></mobile:TextBox>
								</TD>
							</TR>
							<TR>
								<TD></TD>
								<TD>
									<mobile:Command id="cmdRicerca" onclick="OnRicerca" runat="server">Ricerca</mobile:Command>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:datagrid id="MyDataGrid1" runat="server" BorderColor="Gray" BorderStyle="None" BorderWidth="1px"
										BackColor="White" CellPadding="4" AutoGenerateColumns="False" CssClass="DataGrid" AllowPaging="True"
										GridLines="Vertical" Width="100%">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle BackColor="gainsboro" Font-Size="11px"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="Cod. Edificio">
												<ItemTemplate>
													<asp:LinkButton Runat="server" OnCommand="imageButton_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"bl_id") %>' ID="linkbt" Font-Size="Large">
														<%# DataBinder.Eval(Container.DataItem,"bl_id")%>
													</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="denominazione" HeaderText="Nome Edificio"></asp:BoundColumn>
											<asp:BoundColumn DataField="id" HeaderText="Id. Edificio" Visible="False"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
									</asp:datagrid>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<mobile:Link id="Link1" runat="server" NavigateUrl="Default.aspx" Font-Size="Large">Home Page</mobile:Link>
								</TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:form>
	<mobile:form id="Form2" title="Richiedente" runat="server" Paginate="false">
		<mobile:Panel id="Panel3" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific3" runat="server">
				<Choice Filter="isHTML32" Xmlns="Mobile HTML3.2 Template">
					<ContentTemplate>
						<TABLE id="Table11" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 75%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="1" cellPadding="1" width="100%" border="0">
							<CAPTION>
								<FONT size="4">UNIBA</FONT>
							</CAPTION>
							<TR>
								<TD></TD>
								<TD>Ricerca Richiedente</TD>
							</TR>
							<TR>
								<TD>Cod. Edificio</TD>
								<TD>
									<mobile:Label id="lblCodEdiF2" runat="server">Label</mobile:Label>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Richiedente</TD>
								<TD>
									<mobile:TextBox id="txtRichiedente" runat="server"></mobile:TextBox>
								</TD>
							</TR>
							<TR>
								<TD></TD>
								<TD>
									<mobile:Command id="cmdRicercaRic" onclick="OnRicercaOperatore" runat="server" CausesValidation="False">Ricerca</mobile:Command>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:DataGrid id="MyDataGrid2" runat="server" BorderColor="Gray" BorderStyle="None" BorderWidth="1px"
										BackColor="White" CellPadding="4" AutoGenerateColumns="False" CssClass="DataGrid" AllowPaging="True"
										GridLines="Vertical" Width="100%">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle Font-Size="11px" BackColor="Gainsboro"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="Richiedente">
												<ItemTemplate>
													<asp:LinkButton Runat="server" CausesValidation="False" OnCommand="Operatore_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Richiedente") %>' Font-Size="Large">
														<%# DataBinder.Eval(Container.DataItem,"Richiedente") %>
													</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
									</asp:DataGrid>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<mobile:Command id="cmdOperatore" onclick="OnOperatore" runat="server" CausesValidation="True">Conferma</mobile:Command>
									<mobile:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtRichiedente" ErrorMessage="Inserire il richiedente"></mobile:RequiredFieldValidator>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:LinkButton id="LinkButton1" onclick="OnRichiesteNonEmesse" runat="server" CausesValidation="False"
										Font-Bold="True">Richieste non emesse</asp:LinkButton>
									<P></P>
									<asp:LinkButton id="LinkButton2" onclick="OnRichiesteEmesse" runat="server" CausesValidation="False"
										Font-Bold="True">Richieste approvate</asp:LinkButton>
								</TD>
							</TR>
							<TR>
								<TD>
									<mobile:Link id="Link3" runat="server" NavigateUrl="#Form1" Font-Size="Large">Indietro</mobile:Link>
								</TD>
								<TD>
									<mobile:Link id="Link2" runat="server" NavigateUrl="Default.aspx" Font-Size="Large">Home Page</mobile:Link>
								</TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:form>
	<mobile:form id="Form3" runat="server">
		<mobile:Panel id="Panel1" runat="server">
			<mobile:DeviceSpecific id="Devicespecific2" runat="server">
				<Choice Filter="isHTML32" Xmlns="Mobile HTML3.2 Template">
					<ContentTemplate>
						<TABLE id="Table1" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 75%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD></TD>
								<TD>Richiesta Lavoro</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Codice Edi.</TD>
								<TD>
									<mobile:Label id="lblcodedi" runat="server">Label</mobile:Label>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Richiedente</TD>
								<TD>
									<mobile:Label id="lblRichiedenteF3" runat="server">Label</mobile:Label>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Gruppo</TD>
								<TD>
									<asp:DropDownList id="cmbsGruppo" runat="server"></asp:DropDownList>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Telefono</TD>
								<TD>
									<mobile:TextBox id="txtsTelefonoRichiedente" runat="server"></mobile:TextBox>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Nota</TD>
								<TD>
									<mobile:TextBox id="txtsNota" runat="server"></mobile:TextBox>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Servizio</TD>
								<TD>
									<asp:DropDownList id="cmbsServizio" runat="server"></asp:DropDownList>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">
									<SPAN>Std. App.</SPAN>
								</TD>
								<TD>
									<asp:DropDownList id="cmbsApp" runat="server"></asp:DropDownList>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">
									<SPAN>App.</SPAN>
								</TD>
								<TD>
									<asp:DropDownList id="cmbsAppare" runat="server"></asp:DropDownList>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Urgenza</TD>
								<TD>
									<asp:DropDownList id="cmbsPriority" runat="server"></asp:DropDownList>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Desc Problema Note</TD>
								<TD>
									<asp:TextBox id="txtsProblema" runat="server" TextMode="MultiLine"></asp:TextBox>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Data</TD>
								<TD>
									<mobile:Label id="lblDataRichiesta" runat="server">Label</mobile:Label>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Ora</TD>
								<TD>
									<mobile:Label id="lblOraRichiesta" runat="server">Label</mobile:Label>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px"></TD>
								<TD>
									<mobile:Command id="BtSalva" onclick="OnSalva" runat="server">Salva</mobile:Command>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<mobile:RegularExpressionValidator id="RqTelefono" runat="server" ErrorMessage="Il Telefono deve essere numerico" ControlToValidate="txtsTelefonoRichiedente"
										ValidationExpression="[0-9]*"></mobile:RegularExpressionValidator>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">
									<mobile:Link id="Link5" runat="server" Font-Size="Large" NavigateUrl="#Form2">Indietro</mobile:Link>
								</TD>
								<TD>
									<mobile:Link id="Link4" runat="server" Font-Size="Large" NavigateUrl="Default.aspx">Home Page</mobile:Link>
								</TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:form>
	<mobile:form id="Form4" runat="server">
		<mobile:Panel id="Panel4" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific4" runat="server">
				<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
					<ContentTemplate>
						<TABLE id="Table2" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 75%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD>
									<asp:datagrid id="MyDatagrid3" runat="server" PageSize="5" BorderColor="Gray" BorderStyle="None"
										BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False" CssClass="DataGrid"
										AllowPaging="True" GridLines="Vertical" Width="100%">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle Font-Size="11px" BackColor="Gainsboro"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="N. RDL">
												<ItemTemplate>
													<asp:LinkButton Runat="server" OnCommand="consulta_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID") %>' ID="Linkbutton3" Font-Size="Large">
														<%# DataBinder.Eval(Container.DataItem,"ID")%>
													</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="bl" HeaderText="EDIFICIO"></asp:BoundColumn>
											<asp:BoundColumn DataField="Data" HeaderText="DATA RICHIESTA" DataFormatString="{0:d}"></asp:BoundColumn>
											<asp:BoundColumn DataField="status" HeaderText="STATO"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
							<TR>
								<TD>
									<mobile:Link id="Link6" runat="server" Font-Size="Large" NavigateUrl="#Form2">Indietro</mobile:Link></TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:form>
	<mobile:Form id="Form5" runat="server">
		<mobile:Panel id="Panel5" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific5" runat="server">
				<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
					<ContentTemplate>
						<TABLE id="Table3" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 75%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD>
									<uc1:CreazioneRichiesta1 id="CreazioneRichiesta1" runat="server"></uc1:CreazioneRichiesta1></TD>
							</TR>
							<TR>
								<TD>
									<uc1:CreazioneRichiesta2 id="CreazioneRichiesta2" runat="server"></uc1:CreazioneRichiesta2></TD>
							</TR>
							<TR>
								<TD>
									<uc1:CreazioneRichiesta3 id="CreazioneRichiesta3" runat="server"></uc1:CreazioneRichiesta3></TD>
							</TR>
							<TR>
								<TD>
									<mobile:Link id="Link7" runat="server" Font-Size="Large" NavigateUrl="#Form4">Avanti</mobile:Link></TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:Form>
</body>
