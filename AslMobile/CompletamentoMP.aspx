<%@ Page language="c#" Codebehind="CompletamentoMP.aspx.cs" Inherits="TheSite.AslMobile.CompletamentoMP" AutoEventWireup="false" %>
<%@ Register TagPrefix="uc1" TagName="Completamento" Src="./CompletamentoUserControl.ascx" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<HEAD>
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="http://schemas.microsoft.com/Mobile/Page" name="vs_targetSchema">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
	<P>
		<mobile:form id="Form1" runat="server">
			<mobile:Panel id="pnlRicerca" runat="server">
				<mobile:DeviceSpecific id="DeviceSpecific1" runat="server">
					<Choice Filter="isHTML32" Xmlns="Mobile HTML3.2 Template">
						<ContentTemplate>
							<TABLE id="Table1" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
								cellSpacing="0" cellPadding="0" align="center" border="0">
								<TR>
									<TD>Ordine di Lavoro</TD>
									<TD colSpan="2">
										<mobile:TextBox id="txtOrdineLavoro" runat="server" Size="16"></mobile:TextBox>
									</TD>
								</TR>
								<TR>
									<TD>Scadenza </TD>
									<TD colSpan="2">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD>da</TD>
												<TD>
													<asp:DropDownList id="cmbsMeseDa" runat="server">
														<asp:ListItem Value="01">Gennaio</asp:ListItem>
														<asp:ListItem Value="02">Febbraio</asp:ListItem>
														<asp:ListItem Value="03">Marzo</asp:ListItem>
														<asp:ListItem Value="04">Aprile</asp:ListItem>
														<asp:ListItem Value="05">Maggio</asp:ListItem>
														<asp:ListItem Value="06">Giugno</asp:ListItem>
														<asp:ListItem Value="07">Luglio</asp:ListItem>
														<asp:ListItem Value="08">Agosto</asp:ListItem>
														<asp:ListItem Value="09">Settembre</asp:ListItem>
														<asp:ListItem Value="10">Ottobre</asp:ListItem>
														<asp:ListItem Value="11">Novembre</asp:ListItem>
														<asp:ListItem Value="12">Dicembre</asp:ListItem>
													</asp:DropDownList>
												</TD>
												<TD>
													<asp:DropDownList id="cmbsAnnoDa" runat="server"></asp:DropDownList>
												</TD>
											</TR>
											<TR>
												<TD>a</TD>
												<TD>
													<asp:DropDownList id="cmbsMeseA" runat="server">
														<asp:ListItem Value="01">Gennaio</asp:ListItem>
														<asp:ListItem Value="02">Febbraio</asp:ListItem>
														<asp:ListItem Value="03">Marzo</asp:ListItem>
														<asp:ListItem Value="04">Aprile</asp:ListItem>
														<asp:ListItem Value="05">Maggio</asp:ListItem>
														<asp:ListItem Value="06">Giugno</asp:ListItem>
														<asp:ListItem Value="07">Luglio</asp:ListItem>
														<asp:ListItem Value="08">Agosto</asp:ListItem>
														<asp:ListItem Value="09">Settembre</asp:ListItem>
														<asp:ListItem Value="10">Ottobre</asp:ListItem>
														<asp:ListItem Value="11">Novembre</asp:ListItem>
														<asp:ListItem Value="12">Dicembre</asp:ListItem>
													</asp:DropDownList>
												</TD>
												<TD>
													<asp:DropDownList id="cmbsAnnoA" runat="server"></asp:DropDownList>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD>Cod.Edificio</TD>
									<TD>
										<mobile:TextBox id="txtCodEdificio" runat="server" Size="12"></mobile:TextBox>
									</TD>
									<TD>
										<mobile:Command id="cmdRicercaEdifici" onclick="OnRicercaEdifici" runat="server">...</mobile:Command>
									</TD>
								</TR>
								<TR>
									<TD>Servizio</TD>
									<TD colSpan="2">
										<asp:DropDownList id="cmbsServizio" runat="server"></asp:DropDownList>
									</TD>
								</TR>
								<TR>
									<TD>Ditta</TD>
									<TD colSpan="2">
										<asp:DropDownList id="cmbsDitta" runat="server"></asp:DropDownList>
									</TD>
								</TR>
								<TR>
									<TD>Addetti</TD>
									<TD>
										<mobile:TextBox id="txtAddetto" runat="server" Size="12"></mobile:TextBox>
									</TD>
									<TD>
										<mobile:Command id="cmdRicercaAddetti" onclick="OnRicercaAddetti" runat="server">...</mobile:Command>
									</TD>
								</TR>
								<TR>
									<TD>
										<mobile:Link id="Link3" NavigateUrl="Default.aspx" runat="server" Font-Size="Large">Home Page</mobile:Link>
									</TD>
									<TD colSpan="2">
										<mobile:Command id="cmdRicerca" onclick="OnRicerca" runat="server">Ricerca</mobile:Command>
									</TD>
								</TR>
							</TABLE>
						</ContentTemplate>
					</Choice>
				</mobile:DeviceSpecific>
			</mobile:Panel>
		</mobile:form>
		<mobile:form id="Form2" runat="server">
			<mobile:Panel id="pnlSelezione" runat="server">
				<mobile:DeviceSpecific id="DeviceSpecific2" runat="server">
					<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
						<ContentTemplate>
							<TABLE id="Table5" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
								cellSpacing="0" cellPadding="0" align="center" border="0">
								<TR>
									<TD>
										<asp:datagrid id="DataGridEdifici" runat="server" PageSize="4" Width="100%" GridLines="Vertical"
											AllowPaging="True" CssClass="DataGrid" AutoGenerateColumns="False" CellPadding="4" BackColor="White"
											BorderWidth="1px" BorderStyle="None" BorderColor="Gray">
											<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
											<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
											<HeaderStyle Font-Size="11px" BackColor="Gainsboro"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="Cod. Edificio">
													<ItemTemplate>
														<asp:LinkButton Runat="server" ID="linkEdi" OnCommand="imageButton_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"bl_id") %>' Font-Size="Large">
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
										<asp:DataGrid id="DataGridAddetti" runat="server" PageSize="5" Width="100%" GridLines="Vertical"
											AllowPaging="True" CssClass="DataGrid" AutoGenerateColumns="False" CellPadding="4" BackColor="White"
											BorderWidth="1px" BorderStyle="None" BorderColor="Gray">
											<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
											<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
											<HeaderStyle Font-Size="11px" BackColor="Gainsboro"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="COGNOME">
													<ItemTemplate>
														<asp:LinkButton Runat="server" CausesValidation="False" OnCommand="Addetto_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"COGNOME") %>' ID="Linkbutton1" NAME="Linkbutton1" Font-Size="Large">
															<%# DataBinder.Eval(Container.DataItem,"COGNOME") %>
														</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="NOME">
													<ItemTemplate>
														<asp:LinkButton Runat="server" CausesValidation="False" OnCommand="Addetto_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"COGNOME") %>' ID="Linkbutton2" NAME="Linkbutton1" Font-Size="Large">
															<%# DataBinder.Eval(Container.DataItem,"NOME") %>
														</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="DITTA">
													<ItemTemplate>
														<asp:LinkButton Runat="server" CausesValidation="False" OnCommand="Addetto_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"COGNOME") %>' ID="Linkbutton3" NAME="Linkbutton1" Font-Size="Large">
															<%# DataBinder.Eval(Container.DataItem,"DITTA") %>
														</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid>
										<asp:LinkButton Runat="server" ID="indie" OnClick="OnAnnulla" Font-Size="Large">Indietro</asp:LinkButton>
									</TD>
								</TR>
							</TABLE>
						</ContentTemplate>
					</Choice>
				</mobile:DeviceSpecific>
			</mobile:Panel>
		</mobile:form>
		<mobile:form id="Form3" runat="server">
			<mobile:Panel id="pnlRisultati" runat="server">
				<mobile:DeviceSpecific id="DeviceSpecific3" runat="server">
					<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
						<ContentTemplate>
							<TABLE id="Table" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
								cellSpacing="0" cellPadding="0" align="center" border="0">
								<TR>
									<TD>
										<asp:DataGrid id="DatagridRisultati" runat="server" PageSize="5" Width="100%" GridLines="Vertical"
											AllowPaging="True" CssClass="DataGrid" AutoGenerateColumns="False" CellPadding="4" BackColor="White"
											BorderWidth="1px" BorderStyle="None" BorderColor="Gray">
											<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
											<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
											<HeaderStyle Font-Size="11px" BackColor="Gainsboro"></HeaderStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Seleziona">
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<ItemTemplate>
														<asp:CheckBox ID="ChkSel" Runat="server"></asp:CheckBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Ord. Lavoro">
													<ItemTemplate>
														<asp:LinkButton Runat="server" CausesValidation="False" OnCommand="Risultati_Click" CommandArgument='<%#"Completamento_MP_WRlist.aspx?wo_id=" + DataBinder.Eval(Container.DataItem,"ID")%>' ID="Linkbutton4" NAME="Linkbutton1" Font-Size="Large">
															<%# DataBinder.Eval(Container.DataItem,"ID") %>
														</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="Edificio" HeaderText="Edificio">
													<HeaderStyle Width="5%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="DataPianificata" HeaderText="Data Pianificata" DataFormatString="{0:d}"></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
								<TR>
									<TD>
										<uc1:Completamento id="Completamento1" runat="server"></uc1:Completamento></TD>
								</TR>
								<TR>
									<TD>
										<mobile:Link id="Link4" runat="server" Font-Size="Large" NavigateUrl="#Form1">Indietro</mobile:Link></TD>
								</TR>
							</TABLE>
						</ContentTemplate>
					</Choice>
				</mobile:DeviceSpecific>
			</mobile:Panel>
		</mobile:form>
	</P>
	<P>
		<mobile:Form id="Form5" runat="server">
			<mobile:Panel id="Panel2" runat="server">
				<mobile:DeviceSpecific id="DeviceSpecific5" runat="server">
					<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
						<ContentTemplate>
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" border="0">
								<TR>
									<TD>
										<asp:Repeater id="RepeaterMaster" runat="server">
											<HeaderTemplate>
												<TABLE cellSpacing="1" cellPadding="1" border="0">
											</HeaderTemplate>
											<ItemTemplate>
												<TR>
													<TD bgcolor=#00ccff nowrap><b>Inserimento ordine di lavoro N.<%# DataBinder.Eval(Container.DataItem,"Key") %></b></TD>
												</TR>
												<TR>
													<TD nowrap>
														<asp:Repeater id="RepeaterDettail" runat="server">											
															<HeaderTemplate>
																<table cellSpacing="1" cellPadding="1" border="0">
																	<tr>
																		<td nowrap bgcolor=DarkGray>Richiesta di lavoro associata</td>
																		<td nowrap bgcolor=DarkGray>Data Richiesta</td>
																		<td nowrap bgcolor=DarkGray>Data Pianificata</td>
																		<td nowrap bgcolor=DarkGray>Attività</td>
																		<td nowrap bgcolor=DarkGray>Descrizione</td>
																		<td nowrap bgcolor=DarkGray>Stato</td>
																	</tr>
															</HeaderTemplate>
															<ItemTemplate>
																<tr>
																	<td nowrap width="100%" bgcolor=PowderBlue><%# DataBinder.Eval(Container.DataItem,"wr_id") %>
																	</td>
																	<td nowrap width="100%" bgcolor=PowderBlue><%# DataBinder.Eval(Container.DataItem,"Data_Richiesta", "{0:d}") %>
																	</td>
																	<td nowrap width="100%" bgcolor=PowderBlue><%# DataBinder.Eval(Container.DataItem,"Data_Pianificata", "{0:d}") %>
																	</td>
																	<td nowrap width="100%" bgcolor=PowderBlue><%# DataBinder.Eval(Container.DataItem,"Attivita") %>
																	</td>
																	<td nowrap width="100%" bgcolor=PowderBlue><%# DataBinder.Eval(Container.DataItem,"Descrizione") %>
																	</td>
																	<td nowrap width="100%" bgcolor=PowderBlue><%# DataBinder.Eval(Container.DataItem,"Stato") %>
																	</td>
																</tr>
															</ItemTemplate>
															<AlternatingItemTemplate>
																<tr>
																	<td bgcolor=LightSteelBlue nowrap><%# DataBinder.Eval(Container.DataItem,"wr_id") %></td>
																	<td bgcolor=LightSteelBlue nowrap><%# DataBinder.Eval(Container.DataItem,"Data_Richiesta", "{0:d}") %></td>
																	<td bgcolor=LightSteelBlue nowrap><%# DataBinder.Eval(Container.DataItem,"Data_Pianificata", "{0:d}") %></td>
																	<td bgcolor=LightSteelBlue nowrap><%# DataBinder.Eval(Container.DataItem,"Attivita") %></td>
																	<td bgcolor=LightSteelBlue nowrap><%# DataBinder.Eval(Container.DataItem,"Descrizione") %></td>
																	<td bgcolor=LightSteelBlue nowrap><%# DataBinder.Eval(Container.DataItem,"Stato") %></td>
																</tr>
															</AlternatingItemTemplate>
															<FooterTemplate>
																</TABLE>
															</FooterTemplate> 
														</asp:Repeater> 													
													</TD>
												</TR>
											</ItemTemplate>
											<FooterTemplate>
												</TABLE>
											</FooterTemplate>
										</asp:Repeater>
									</TD>
								</TR>
								<TR>
									<TD><mobile:Link id="Link5" runat="server" Font-Size="Large" NavigateUrl="#Form1">Indietro</mobile:Link></TD>
								</TR>
							</TABLE>
						</ContentTemplate>
					</Choice>
				</mobile:DeviceSpecific>
			</mobile:Panel>
		</mobile:Form>
	</P>
</body>
