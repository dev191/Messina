<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RichiedentiSollecito" Src="../WebControls/RichiedentiSollecito.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserStanze" Src="../WebControls/UserStanze.ascx" %>
<%@ Page language="c#" Codebehind="CreazioneTemp.aspx.cs" AutoEventWireup="false" Inherits="TheSite.CreazioneTemp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Creazione Rdl</title>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<tr>
						<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" title="Inserimento Richieste" runat="server"></uc1:pagetitle></TD>
					</tr>
					<tr>
						<td>
							<hr noShade SIZE="1">
							<div>&nbsp;<asp:label id="lblProgetto" runat="server">Progetto: </asp:label><asp:dropdownlist id="CmbProgetto" runat="server" Width="216px"></asp:dropdownlist></div>
						</td>
					</tr>
					<tr>
						<TD vAlign="top" align="center" height="98%">
							<TABLE id="tblSearch95" cellSpacing="1" cellPadding="1" border="0">
								<tr>
									<td><asp:panel id="PanelRichiedente" runat="server">
											<TABLE id="TableRichiedente" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" border="0">
												<TR>
													<TD>
														<uc1:RichiedentiSollecito id="RichiedentiSollecito1" runat="server"></uc1:RichiedentiSollecito>
														<asp:requiredfieldvalidator id="rfvRichiedenteNome" runat="server" ErrorMessage="Indicare il Nome del Richiedente">*</asp:requiredfieldvalidator>
														<asp:requiredfieldvalidator id="rfvRichiedenteCognome" runat="server" ErrorMessage="Indicare il Cognome del Richiedente">*</asp:requiredfieldvalidator></TD>
												</TR>
											</TABLE>
										</asp:panel></td>
								</tr>
								<TR>
									<TD>
										<TABLE id="TableRicercaModulo" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" border="0">
											<TR>
												<TD><uc1:ricercamodulo id="RicercaModulo1" runat="server"></uc1:ricercamodulo><asp:requiredfieldvalidator id="rfvEdificio" runat="server" ErrorMessage="Selezionare un Edificio">*</asp:requiredfieldvalidator></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD>Descrizione Intervento Richiesto:</TD>
								</TR>
								<TR>
									<TD>
										<TABLE class="tblSearch100Dettaglio" style="WIDTH: 100%" cellSpacing="0" cellPadding="0"
											border="0">
											<TR>
												<TD width="10%">Telefono</TD>
												<TD align="left" width="20%"><cc1:s_textbox id="txtsTelefonoRichiedente" runat="server" MaxLength="50" DBIndex="3" DBSize="20"
														DBParameterName="p_Phone"></cc1:s_textbox></TD>
												<TD class="Comm" width="10%"><span class="blueoverline">Nota/Ambiente</span></TD>
												<TD align="left" width="40%"><cc1:s_textbox id="txtsNota" runat="server" Width="100%" MaxLength="2000" DBIndex="4" DBSize="2000"
														DBParameterName="p_Nota_Ric" Rows="2" TextMode="MultiLine"></cc1:s_textbox></TD>
											</TR>
											<tr>
												<TD class="Comm" width="10%"><span class="blueoverline">Piano</span><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Selezionare un piano"
														ControlToValidate="cmbsPiano">*</asp:requiredfieldvalidator></TD>
												<TD align="left" width="20%"><cc1:s_combobox id="cmbsPiano" runat="server" Width="200px" DBIndex="17" DBSize="10" DBParameterName="p_id_piani"
														DBDataType="Integer" DBDirection="Input"></cc1:s_combobox></TD>
												<TD width="10%" colSpan="2">
													<uc1:userstanze id="UserStanze1" runat="server"></uc1:userstanze></TD>
											</tr>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD>
										<asp:linkbutton id="lkbNonEmesse" runat="server" CssClass="LabelInfo" CausesValidation="False">Richieste non Emesse</asp:linkbutton>
									</TD>
								</TR>
								<TR>
									<TD>
										<asp:panel id="pnlShowInfo" style="DISPLAY: none; Z-INDEX: 100; COLOR: #ffffff; POSITION: absolute; BACKGROUND-COLOR: gainsboro"
											runat="server" Width="100%">
											<TABLE height="100%" width="100%">
												<TR>
													<TD class="TitleSearch" vAlign="top" align="right">
														<asp:linkbutton id="lnkChiudi" runat="server" CausesValidation="False" CssClass="LabelChiudi">Chiudi</asp:linkbutton></TD>
												</TR>
												<TR>
													<TD>
														<asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AllowPaging="True" GridLines="Vertical"
															AutoGenerateColumns="False" BorderWidth="1px" BorderColor="Gray" PageSize="1">
															<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
															<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
															<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
															<Columns>
																<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
																<asp:TemplateColumn>
																	<HeaderStyle Width="3%"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:ImageButton CausesValidation=False id="lnkNonEmesse" Runat=server CommandName="NonEmesse" ImageUrl="~/images/edit.gif" CommandArgument='<%# "EditCreazione.aspx?wr_id=" + DataBinder.Eval(Container.DataItem,"ID")%>'>
																		</asp:ImageButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="ID" HeaderText="N. RDL"></asp:BoundColumn>
																<asp:BoundColumn DataField="bl" HeaderText="EDIFICIO"></asp:BoundColumn>
																<asp:BoundColumn DataField="Data" HeaderText="DATA RICHIESTA" DataFormatString="{0:g}"></asp:BoundColumn>
																<asp:BoundColumn DataField="status" HeaderText="STATO"></asp:BoundColumn>
																<asp:BoundColumn DataField="Descrizione" HeaderText="DESCRIZIONE"></asp:BoundColumn>
																<asp:BoundColumn DataField="Richiedente" HeaderText="RICHIEDENTE"></asp:BoundColumn>
															</Columns>
															<PagerStyle Mode="NumericPages"></PagerStyle>
														</asp:datagrid></TD>
												</TR>
											</TABLE>
										</asp:panel>
										<iframe id="DivShim" style="DISPLAY: none; POSITION: absolute" src="javascript:false;" frameBorder="0"
											scrolling="no" tabIndex="0"></iframe>
									</TD>
								</TR>
								<TR>
									<TD><asp:linkbutton id="LinkApprovate" runat="server" CssClass="LabelInfo" CausesValidation="False">Richieste Approvate</asp:linkbutton></TD>
								</TR>
								<TR>
									<TD>
										<asp:panel id="PanelEmesse" style="DISPLAY: none; Z-INDEX: 100; COLOR: #ffffff; POSITION: absolute; BACKGROUND-COLOR: gainsboro"
											runat="server" Width="100%">
											<TABLE height="100%" width="100%">
												<TR>
													<TD class="TitleSearch" vAlign="top" align="right">
														<asp:linkbutton id="LinkChiudi2" runat="server" CausesValidation="False" CssClass="LabelChiudi">Chiudi</asp:linkbutton></TD>
												</TR>
												<TR>
													<TD>
														<asp:datagrid id="DatagridEmesse" runat="server" CssClass="DataGrid" AllowPaging="True" GridLines="Vertical"
															AutoGenerateColumns="False" BorderWidth="1px" BorderColor="Gray" PageSize="1">
															<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
															<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
															<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
															<Columns>
																<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
																<asp:TemplateColumn>
																	<HeaderStyle Width="3%"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:ImageButton CausesValidation=False id="lnlEmesse" Runat=server CommandName="Emesse" ImageUrl="~/images/edit.gif" CommandArgument='<%# "EditCreazione.aspx?wr_id=" + DataBinder.Eval(Container.DataItem,"ID") + "&c=true"%>'>
																		</asp:ImageButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="ID" HeaderText="N. RDL"></asp:BoundColumn>
																<asp:BoundColumn DataField="bl" HeaderText="EDIFICIO"></asp:BoundColumn>
																<asp:BoundColumn DataField="Data" HeaderText="DATA RICHIESTA" DataFormatString="{0:g}"></asp:BoundColumn>
																<asp:BoundColumn DataField="status" HeaderText="STATO"></asp:BoundColumn>
																<asp:BoundColumn DataField="Descrizione" HeaderText="DESCRIZIONE"></asp:BoundColumn>
																<asp:BoundColumn DataField="Richiedente" HeaderText="RICHIEDENTE"></asp:BoundColumn>
															</Columns>
															<PagerStyle Mode="NumericPages"></PagerStyle>
														</asp:datagrid></TD>
												</TR>
											</TABLE>
										</asp:panel><iframe id="DivEmesse" style="DISPLAY: none; POSITION: absolute" src="javascript:false;"
											frameBorder="0" scrolling="no"> </iframe>
									</TD>
								</TR>
								<TR>
									<TD>
										<asp:button id="btsCodice" runat="server" Width="153" Height="22" text="Visualizza Reperibilità"></asp:button><BR>
										<asp:textbox id="txtBL_ID" runat="server" Width="0px"></asp:textbox>
										<div id="PopupRep" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; DISPLAY: none; BORDER-LEFT: #000000 1px solid; WIDTH: 100%; BORDER-BOTTOM: #000000 1px solid; POSITION: absolute; HEIGHT: 200%"><IFRAME id="docRep" name="docRep" src="" frameBorder="no" width="100%"></IFRAME>
										</div>
									</TD>
								</TR>
								<TR>
									<TD>
										<asp:panel id="PanelServizio" runat="server">
											<TABLE id="Table2" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" border="0">
												<TR>
													<TD class="Comm" style="HEIGHT: 16px" width="15%"><SPAN class="blueoverline">Servizio</SPAN></TD>
													<TD style="HEIGHT: 16px" colSpan="5">
														<cc1:S_ComboBox id="cmbsServizio" runat="server" Width="350px" DBParameterName="p_Servizio_Id" DBSize="4"
															DBIndex="10" DBDataType="Integer" AutoPostBack="True"></cc1:S_ComboBox>
														<asp:requiredfieldvalidator id="RequiredfieldvalidatorServ" runat="server" ErrorMessage="Selezionare un servizio"
															ControlToValidate="cmbsServizio" InitialValue="0">*</asp:requiredfieldvalidator></TD>
												</TR>
												<TR>
													<TD width="15%"><SPAN>Std. Apparecchiatura</SPAN></TD>
													<TD colSpan="5">
														<cc1:S_ComboBox id="cmbsApparecchiatura" runat="server" Width="350px" DBParameterName="p_Eqstd_Id"
															DBSize="4" DBIndex="11" AutoPostBack="True"></cc1:S_ComboBox></TD>
												</TR>
											</TABLE>
										</asp:panel>
									</TD>
								</TR>
								<TR>
									<TD>
										<TABLE id="TableRicercaApparecchiatura" style="WIDTH: 100%" cellSpacing="1" cellPadding="1"
											border="0">
											<TR>
												<TD><uc1:codiceapparecchiature id="CodiceApparecchiature1" runat="server"></uc1:codiceapparecchiature></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD>
										<asp:panel id="PanelProblema" runat="server">
											<TABLE id="TableProblema" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" border="0">
												<TR>
													<TD width="15%">Urgenza</TD>
													<TD>
														<cc1:S_ComboBox id="cmbsUrgenza" runat="server" Width="400px" DBParameterName="p_Priority" DBSize="4"
															DBIndex="12" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD width="15%">Descrizione Problema/Note</TD>
													<TD>
														<cc1:S_TextBox id="txtsProblema" runat="server" Width="100%" DBParameterName="p_Description" DBSize="4000"
															DBIndex="13" TextMode="MultiLine" Rows="4" Height="34px"></cc1:S_TextBox></TD>
												</TR>
											</TABLE>
										</asp:panel>
									</TD>
								</TR>
								<TR>
									<TD class="SGA"><div><span class="blueoverline">Tipo di intervento:&nbsp;</span><CC1:S_COMBOBOX id="cmbsTipoIntrevento" runat="server" width="224px" dbdatatype="Integer"></CC1:S_COMBOBOX></div>
									</TD>
								</TR>
								<TR>
									<TD class="Comm"><STRONG class="blueoverline">A Seguito di:</STRONG></TD>
								</TR>
								<TR>
									<TD>
										<div id="aseguito1">
											<ul>
												<li>
													<TABLE class="BordiCellaR" id="Table70" style="WIDTH: 600px; HEIGHT: 40px" cellSpacing="0"
														cellPadding="0" width="448" border="0">
														<TR>
															<TD style="WIDTH: 160px" class="SGA"><asp:checkbox id="ChkConduzione" runat="server" Text="Conduzione" CssClass="blueoverline"></asp:checkbox></TD>
															<TD class="SGA"><SPAN class="blueoverline">In data:</SPAN></TD>
															<TD><UC1:CALENDARPICKER id="CPConduzioneData" runat="server"></UC1:CALENDARPICKER></TD>
															<TD><SPAN class="SGA"><SPAN class="blueoverline">Ora:</SPAN></SPAN>
																<CC1:S_COMBOBOX id="OraConduzione" runat="server" dbdatatype="Integer">
																	<asp:ListItem Value="00">00</asp:ListItem>
																	<asp:ListItem Value="01">01</asp:ListItem>
																	<asp:ListItem Value="02">02</asp:ListItem>
																	<asp:ListItem Value="03">03</asp:ListItem>
																	<asp:ListItem Value="04">04</asp:ListItem>
																	<asp:ListItem Value="05">05</asp:ListItem>
																	<asp:ListItem Value="06">06</asp:ListItem>
																	<asp:ListItem Value="07">07</asp:ListItem>
																	<asp:ListItem Value="08">08</asp:ListItem>
																	<asp:ListItem Value="09">09</asp:ListItem>
																	<asp:ListItem Value="10">10</asp:ListItem>
																	<asp:ListItem Value="11">11</asp:ListItem>
																	<asp:ListItem Value="12">12</asp:ListItem>
																	<asp:ListItem Value="13">13</asp:ListItem>
																	<asp:ListItem Value="14">14</asp:ListItem>
																	<asp:ListItem Value="15">15</asp:ListItem>
																	<asp:ListItem Value="16">16</asp:ListItem>
																	<asp:ListItem Value="17">17</asp:ListItem>
																	<asp:ListItem Value="18">18</asp:ListItem>
																	<asp:ListItem Value="19">19</asp:ListItem>
																	<asp:ListItem Value="20">20</asp:ListItem>
																	<asp:ListItem Value="21">21</asp:ListItem>
																	<asp:ListItem Value="22">22</asp:ListItem>
																	<asp:ListItem Value="23">23</asp:ListItem>
																</CC1:S_COMBOBOX>:
																<CC1:S_COMBOBOX id="MinutiConduzione" runat="server" width="40px" dbdatatype="Integer">
																	<asp:ListItem Value="00">00</asp:ListItem>
																	<asp:ListItem Value="15">15</asp:ListItem>
																	<asp:ListItem Value="30">30</asp:ListItem>
																	<asp:ListItem Value="45">45</asp:ListItem>
																</CC1:S_COMBOBOX>
															</TD>
														</TR>
													</TABLE>
												</li>
											</ul>
										</div>
										<div id="aseguito2">
											<ul>
												<li>
													<TABLE class="BordiCellaR" style="WIDTH: 600px; HEIGHT: 40px" cellSpacing="0" cellPadding="0"
														width="448" border="0">
														<TR>
															<TD style="WIDTH: 160px"><CC1:S_COMBOBOX id="CmbASeguito" runat="server" width="224px" dbdatatype="Integer"></CC1:S_COMBOBOX></TD>
															<TD class="Comm"><span class="blueoverline">DIE</span></TD>
															<TD>
																<cc1:s_textbox id="TxtASeguito1" runat="server" DBParameterName="p_Aseguito1" MaxLength="11"></cc1:s_textbox></TD>
															<TD id="data" class="Comm"><span class="blueoverline">Del</span>
															</TD>
															<TD id="lbl"><UC1:CALENDARPICKER id="CPAseguito" runat="server"></UC1:CALENDARPICKER></TD>
														</TR>
													</TABLE>
												</li>
											</ul>
										</div>
										<div id="aseguito3">
											<ul>
												<li>
													<TABLE style="WIDTH: 600px; HEIGHT: 40px" cellSpacing="0" cellPadding="0" width="448" border="0">
														<TR>
															<TD class="sga" style="WIDTH: 160px">
																<asp:checkbox id="ChkSopralluogo" runat="server" Text="Richiesta di sopralluogo e valutazione tecnico economica"
																	CssClass="blueoverline"></asp:checkbox></SPAN></TD>
															<TD class="SGA"><SPAN class="blueoverline">N°</SPAN>
																<cc1:s_textbox id="TxtSopralluogo" runat="server" MaxLength="11" DBParameterName="p_Aseguito1"></cc1:s_textbox></TD>
															<TD class="SGA"><SPAN class="blueoverline">Del</SPAN></TD>
															<TD>
																<UC1:CALENDARPICKER id="CPSopralluogoDie" runat="server"></UC1:CALENDARPICKER></TD>
														</TR>
													</TABLE>
													<TABLE class="BordiCellaR" id="Table15" style="WIDTH: 600px; HEIGHT: 40px" cellSpacing="0"
														cellPadding="0" width="448" border="0">
														<TR>
															<TD style="WIDTH: 160px" class="SGA"><span class="blueoverline"> Sopralluogo effettuato 
																	in data</span></TD>
															<TD><UC1:CALENDARPICKER id="CPSopralluogoData" runat="server"></UC1:CALENDARPICKER></TD>
															<TD class="SGA"><span class="blueoverline">Da</span><cc1:s_textbox id="TxtASeguito4" runat="server" DBParameterName="p_Aseguito4" MaxLength="61"></cc1:s_textbox></TD>
														</TR>
													</TABLE>
												</li>
											</ul>
										</div>
									</TD>
								</TR>
								<TR>
									<TD class="SGA"><div id="aseguito4"><span class="blueoverline">Causa presunta 
												guasto/anomalia</span><cc1:s_textbox id="TxtCausa" runat="server" Width="100%" DBParameterName="p_causa" DBSize="408"
												DBIndex="13" MaxLength="408" TextMode="MultiLine" Rows="4" Height="34px"></cc1:s_textbox></div>
									</TD>
								</TR>
								<TR>
									<TD class="SGA">
										<div id="aseguito5"><span class="blueoverline">Effetto del guasto</span>
											<cc1:s_textbox id="TxtGuasto" runat="server" Width="100%" DBParameterName="p_guastp" DBSize="408"
												DBIndex="13" MaxLength="408" TextMode="MultiLine" Rows="4" Height="34px"></cc1:s_textbox>
										</div>
									</TD>
								</TR>
								<TR>
									<TD><div>Data Richiesta:&nbsp;
											<UC1:CALENDARPICKER id="CalendarPicker1" runat="server"></UC1:CALENDARPICKER>&nbsp;Ora:
											<asp:textbox id="txtsorain" runat="server" Width="30px">00</asp:textbox>:
											<asp:textbox id="txtsorainmin" runat="server" Width="30px">00</asp:textbox></div>
									</TD>
								</TR>
								<TR>
									<TD><div><cc1:s_button id="btnsSalva" tabIndex="2" runat="server" Text="Salva"></cc1:s_button>&nbsp;<asp:button id="cmdReset" CausesValidation="False" Text="Reset" Runat="server"></asp:button>
											<cc1:s_button id="btnsChiudi" runat="server" Text="Chiudi" CausesValidation="False"></cc1:s_button>
											<a class=GuidaLink href="<%= HelpLink %>" target=_blank  >Guida</a></div>
									</TD>
								</TR>
								<TR>
									<TD><div>
											<asp:label id="lblFirstAndLast" runat="server"></asp:label>&nbsp;
											<MESSPANEL:MESSAGEPANEL id="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"></MESSPANEL:MESSAGEPANEL>
										</div>
									</TD>
								</TR>
								<TR>
									<TD>
										<div><asp:validationsummary id="vlsEdit" runat="server" ShowSummary="False" DisplayMode="List" ShowMessageBox="True"></asp:validationsummary>
										</div>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
