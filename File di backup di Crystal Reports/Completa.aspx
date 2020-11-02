<%@ Register TagPrefix="uc1" TagName="CreazioneRichiesta1" Src="CreazioneRichiesta1.ascx" %>
<%@ Page language="c#" Codebehind="Completa.aspx.cs" Inherits="TheSite.AslMobile.Completa" AutoEventWireup="false" %>
<%@ Register TagPrefix="uc2" TagName="CreazioneRichiesta2" Src="CreazioneRichiesta2.ascx" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<HEAD>
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="http://schemas.microsoft.com/Mobile/Page" name="vs_targetSchema">
</HEAD>
<body Xmlns:mobile="http://schemas.microsoft.com/Mobile/WebForm">
	<mobile:form id="Form1" title="Dati Creazione Richiesta" Paginate="True" runat="server">
		<mobile:Panel id="Panel3" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific3" runat="server">
				<Choice Filter="isHTML32" Xmlns="Mobile HTML3.2 Template">
					<ContentTemplate>
						<uc1:CreazioneRichiesta1 id="CreazioneRichiesta1" runat="server"></uc1:CreazioneRichiesta1>
						<TABLE id="tablef1" border="0">
							<TR>
								<TD>
									<mobile:Link id="Link1" runat="server" NavigateUrl="#Form3" Font-Size="Large">Indietro</mobile:Link>
								</TD>
								<TD>
									<mobile:Link id="Link5" runat="server" NavigateUrl="#Form2" Font-Size="Large">Avanti</mobile:Link>
								</TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:form>
	<mobile:form id="Form2" title="Dati Emissione ordine" Paginate="True" runat="server">
		<mobile:Panel id="Panel1" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific1" runat="server">
				<Choice Filter="isHTML32" Xmlns="Mobile HTML3.2 Template">
					<ContentTemplate>
						<uc2:CreazioneRichiesta2 id="CreazioneRichiesta2" runat="server"></uc2:CreazioneRichiesta2>
						<TABLE id="table5" border="0">
							<TR>
								<TD>
									<mobile:Link id="Link4" runat="server" NavigateUrl="#Form1" Font-Size="Large">Indietro</mobile:Link>
								</TD>
								<TD>
									<mobile:Link id="Link6" runat="server" NavigateUrl="#Form3" Font-Size="Large">Avanti</mobile:Link>
								</TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:form>
	<mobile:form id="Form3" runat="server">
		<mobile:Panel id="Panel4" runat="server">
			<mobile:DeviceSpecific id="DeviceSpecific4" runat="server">
				<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
					<ContentTemplate>
						<TABLE id="TableStatoLavoro" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center" bgColor="#3399cc" colSpan="2"><B>Completamento Ordine di Lavoro</B></TD>
							</TR>
							<TR>
								<TD>Stato Ric.</TD>
								<TD>
									<asp:DropDownList id="cmbsstatolavoro" runat="server"></asp:DropDownList></TD>
							</TR>
						</TABLE>
						<TABLE id="TableSospesaLavoro" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
							<TR>
								<TD>Sospesa per</TD>
								<TD>
									<asp:TextBox id="txtSospesa" runat="server" Columns="15" TextMode="MultiLine"></asp:TextBox></TD>
							</TR>
						</TABLE>
						<TABLE id="TableDate" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
							cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD>Data/Ora Inizio:</TD>
								<TD>
									<mobile:Label id="lblDataStart" runat="server"></mobile:Label></TD>
								<TD>
									<mobile:Command id="cmdDataStart" runat="server" CommandArgument="S" OnItemCommand="cmd_OnItemCommand">...</mobile:Command></TD>
							</TR>
							<TR>
								<TD colSpan="3">
									<TABLE id="TableOraStart" cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
										<TR>
											<TD>Ora</TD>
											<TD>
												<asp:DropDownList id="txtOraStart" runat="server">
													<asp:ListItem Selected="True"></asp:ListItem>
													<asp:ListItem Value="00">00</asp:ListItem>
													<asp:ListItem Value="01">01</asp:ListItem>
													<asp:ListItem Value="02">02</asp:ListItem>
													<asp:ListItem Value="03">03</asp:ListItem>
													<asp:ListItem Value="04">04</asp:ListItem>
													<asp:ListItem Value="05">05</asp:ListItem>
													<asp:ListItem Value="06">06</asp:ListItem>
													<asp:ListItem Value="07">07</asp:ListItem>
													<asp:ListItem Value="08">08</asp:ListItem>
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
												</asp:DropDownList></TD>
										</TR>
										<TR>
											<TD>Minuti</TD>
											<TD>
												<asp:DropDownList id="txtMinutiStart" runat="server">
													<asp:ListItem Value="00">00</asp:ListItem>
													<asp:ListItem Value="10">10</asp:ListItem>
													<asp:ListItem Value="20">20</asp:ListItem>
													<asp:ListItem Value="30">30</asp:ListItem>
													<asp:ListItem Value="40">40</asp:ListItem>
													<asp:ListItem Value="50">50</asp:ListItem>
													<asp:ListItem Selected="True"></asp:ListItem>
												</asp:DropDownList></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>Data/Ora Fine:</TD>
								<TD>
									<mobile:Label id="lblDataEnd" runat="server"></mobile:Label></TD>
								<TD>
									<mobile:Command id="cmdDataEnd" runat="server" CommandArgument="E" OnItemCommand="cmd_OnItemCommand">...</mobile:Command></TD>
							</TR>
							<TR>
								<TD colSpan="3">
									<TABLE id="TableOraEnd" cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
										<TR>
											<TD>Ora</TD>
											<TD>
												<asp:DropDownList id="txtOraEnd" runat="server">
													<asp:ListItem Value="00">00</asp:ListItem>
													<asp:ListItem Value="01">01</asp:ListItem>
													<asp:ListItem Value="02">02</asp:ListItem>
													<asp:ListItem Value="03">03</asp:ListItem>
													<asp:ListItem Value="04">04</asp:ListItem>
													<asp:ListItem Value="05">05</asp:ListItem>
													<asp:ListItem Value="06">06</asp:ListItem>
													<asp:ListItem Value="07">07</asp:ListItem>
													<asp:ListItem Value="08">08</asp:ListItem>
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
													<asp:ListItem Selected="True"></asp:ListItem>
												</asp:DropDownList></TD>
										</TR>
										<TR>
											<TD>Minuti</TD>
											<TD>
												<asp:DropDownList id="txtMinutiEnd" runat="server">
													<asp:ListItem Value="00">00</asp:ListItem>
													<asp:ListItem Value="10">10</asp:ListItem>
													<asp:ListItem Value="20">20</asp:ListItem>
													<asp:ListItem Value="30">30</asp:ListItem>
													<asp:ListItem Value="40">40</asp:ListItem>
													<asp:ListItem Value="50">50</asp:ListItem>
													<asp:ListItem Selected="True"></asp:ListItem>
												</asp:DropDownList></TD>
										</TR>
									</TABLE>
									<INPUT id="Hiddetempointervento" type="hidden" size="1" runat="server"></TD>
							</TR>
							<TR>
								<TD>Ann.Materiale</TD>
								<TD colSpan="2">
									<asp:TextBox id="txtAnnotazioni" runat="server" Columns="15" TextMode="MultiLine"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="3">
									<TABLE id="tableSalva" width="100%" border="0" runat="server">
										<TR>
											<TD>
												<mobile:Link id="Link3" runat="server" NavigateUrl="#Form1" Font-Size="Large">Dettagli</mobile:Link></TD>
											<TD>
												<mobile:Command id="cmdSalva" onclick="OnSalva" runat="server">Invia</mobile:Command></TD>
										</TR>
										<TR>
											<TD>
												<mobile:Link id="Link2" runat="server" NavigateUrl="Default.aspx" Font-Size="Large">Home Page</mobile:Link></TD>
											<TD>
												<mobile:Link id="Link7" runat="server" NavigateUrl="Rcompleta.aspx" Font-Size="Large">Nuova Ricerca</mobile:Link></TD>
										</TR>
									</TABLE>
									<TABLE id="tableconferma" width="100%" border="0" runat="server">
										<TR>
											<TD colSpan="2"><FONT color="red">Data non conforme al capitolato. Continuare?</FONT></TD>
										</TR>
										<TR>
											<TD>
												<mobile:Command id="CommandAnnlla" runat="server" CommandArgument="annulla" OnItemCommand="cmdC_OnItemCommand">Annulla</mobile:Command></TD>
											<TD>
												<mobile:Command id="CommandConferma" runat="server" CommandArgument="salva" OnItemCommand="cmdC_OnItemCommand">Conferma</mobile:Command></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colSpan="3">
									<asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ErrorMessage="Specificare l'ora di inizio lavori."
										ControlToValidate="txtOraStart" Display="Dynamic"></asp:RequiredFieldValidator>
									<asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ErrorMessage="Specificare i minuti di inizio lavori."
										ControlToValidate="txtMinutiStart" Display="Dynamic"></asp:RequiredFieldValidator>
									<asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ErrorMessage="Specificare l'ora di fine lavori."
										ControlToValidate="txtOraEnd" Display="Dynamic"></asp:RequiredFieldValidator>
									<asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server" ErrorMessage="Specificare i minuti di fine lavori."
										ControlToValidate="txtMinutiEnd" Display="Dynamic"></asp:RequiredFieldValidator>
									<mobile:Label id="lblError" runat="server" ForeColor="Red"></mobile:Label></TD>
							</TR>
						</TABLE>
					</ContentTemplate>
				</Choice>
			</mobile:DeviceSpecific>
		</mobile:Panel>
	</mobile:form>
	<mobile:form id="Form4" runat="server">
		<mobile:Label id="lbltipodata" runat="server"></mobile:Label>
		<mobile:Calendar id="Calendar1" runat="server" OnSelectionChanged="Calendar_SelectionChangedDataStart"></mobile:Calendar>
		<mobile:Link id="Link8" runat="server" Font-Size="Large" NavigateUrl="#Form3">Indietro</mobile:Link>
	</mobile:form>
</body>
