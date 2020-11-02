<%@ Control Language="c#" AutoEventWireup="false" Codebehind="UserRdlInailLabel.ascx.cs" Inherits="TheSite.WebControls.UserRdlInailLabel" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="PageTitle.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="VisualizzaSolleciti" Src="VisualizzaSolleciti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AggiungiSollecito" Src="AggiungiSollecito.ascx" %>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD style="HEIGHT: 50px" align="center">
			<uc1:pagetitle id="PageTitle1" title="Sfoglia RdL e Odl" runat="server"></uc1:pagetitle>
		</TD>
	</TR>
	<TR>
		<TD><cc2:datapanel id="PanelGeneral" runat="server" CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch"
				Collapsed="False" TitleText="Sfoglia Richiesta di Lavoro" ExpandText="Espandi" ExpandImageUrl="../Images/downarrows_trans.gif"
				CollapseText="Riduci" CollapseImageUrl="../Images/uparrows_trans.gif" AllowTitleExpandCollapse="True">
				<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" width="100%" border="0">
					<TR>
						<TD style="HEIGHT: 12px" width="20%"><B>RDL N°</B></TD>
						<TD style="WIDTH: 169px; HEIGHT: 12px">
							<asp:Label id="LblRdl" runat="server" Width="174px"></asp:Label></TD>
						<TD style="HEIGHT: 12px"><B>Trasmissione:</B></TD>
						<TD style="HEIGHT: 12px">
							<asp:Label id="lblTrasmissione" Runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 12px"><B>Nominativo Richiedente:</B></TD>
						<TD style="WIDTH: 169px; HEIGHT: 12px">
							<asp:Label id="lblRichiedente" runat="server" Width="174px"></asp:Label></TD>
						<TD style="HEIGHT: 12px"><B>Operatore:</B></TD>
						<TD style="HEIGHT: 12px">
							<asp:Label id="lblOperatore" runat="server" Width="128px"></asp:Label></TD>
					</TR>
					<TR>
						<TD><B>Telefono Richiedente:</B></TD>
						<TD>
							<asp:Label id="lbltelefonoric" runat="server" Width="174px"></asp:Label></TD>
						<TD style="HEIGHT: 29px"><B>Data Richiesta:</B></TD>
						<TD style="HEIGHT: 29px">
							<asp:Label id="lblDataRichiesta" runat="server" Width="128px"></asp:Label></TD>
					</TR>
					<TR>
						<TD><B>Gruppo Richiedente:</B></TD>
						<TD style="WIDTH: 169px">
							<asp:Label id="lblGruppo" runat="server" Width="174px"></asp:Label></TD>
						<TD><B>Orario Richiesta:</B></TD>
						<TD>
							<asp:Label id="lblOraRichiesta" runat="server" Width="128px"></asp:Label></TD>
					</TR>
					<TR>
						<TD><B>Email Richiedente:</B></TD>
						<TD style="WIDTH: 169px">
							<asp:Label id="lblemailric" runat="server" Width="174px"></asp:Label></TD>
						<TD><B>Stanza Richiedente:</B></TD>
						<TD>
							<asp:Label id="lblstanzaric" runat="server" Width="128px"></asp:Label></TD>
					</TR>
					<TR>
						<TD><B>Fabbricato:</B></TD>
						<TD colSpan="3">
							<asp:Label id="lblfabbricato" runat="server" Width="472px"></asp:Label>
							<asp:TextBox id="txtHidBl" runat="server" Width="0px" Visible="false"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD><B>Piano:</B></TD>
						<TD style="WIDTH: 169px">
							<asp:Label id="lblPiano" runat="server" Width="174px"></asp:Label></TD>
						<TD><B>Stanza:</B></TD>
						<TD>
							<asp:Label id="lblStanza" runat="server" Width="174px"></asp:Label></TD>
					</TR>
					<TR>
						<TD><B>Telefono:</B></TD>
						<TD colSpan="3">
							<asp:Label id="lblTelefono" runat="server" Width="174px"></asp:Label></TD>
					<TR>
						<TD><B>Note:</B></TD>
						<TD colSpan="3">
							<asp:Label id="lblNote" runat="server" Width="472px"></asp:Label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 24px"><B>Servizio:</B></TD>
						<TD style="HEIGHT: 24px" colSpan="3">
							<asp:Label id="lblServizio" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 17px"><B>Standard Apparecchiatura:</B></TD>
						<TD style="HEIGHT: 17px" colSpan="3">
							<asp:Label id="lblStandardApp" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD><B>Apparecchiatura:</B></TD>
						<TD colSpan="3">
							<asp:Label id="lblApparecchiatura" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD><B>Descrizione Intervento:</B></TD>
						<TD colSpan="3">
							<asp:label id="lblDescrizione" Runat="server"></asp:label></TD>
					</TR>
				</TABLE>
				<uc1:VisualizzaSolleciti id="VisualizzaSolleciti1" runat="server"></uc1:VisualizzaSolleciti>
			</cc2:datapanel></TD>
	</TR>
	<TR>
		<TD><cc2:datapanel id="PanelDCSIT" runat="server" CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch"
				Collapsed="False" TitleText="Validazione da parte del COLLABORATORE" ExpandText="Espandi" ExpandImageUrl="../Images/downarrows_trans.gif"
				CollapseText="Riduci" CollapseImageUrl="../Images/uparrows_trans.gif" AllowTitleExpandCollapse="True">
				<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD style="WIDTH: 170px; HEIGHT: 12px"><B>Data di validazione:</B></TD>
						<TD>
							<cc1:S_Label id="lbldatavalidDCSIT" runat="server"></cc1:S_Label></TD>
						<TD style="WIDTH: 143px; HEIGHT: 17px"><B>Ora validazione:</B></TD>
						<TD>
							<cc1:S_Label id="lblOraValidDCSIT" runat="server"></cc1:S_Label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 172px; HEIGHT: 17px"><B>Utente:</B></TD>
						<TD>
							<cc1:S_Label id="lblUtenteDCSIT" runat="server"></cc1:S_Label></TD>
						<TD style="WIDTH: 143px; HEIGHT: 17px"><B>Stato:</B></TD>
						<TD>
							<cc1:S_Label id="lblStatoDCSIT" runat="server"></cc1:S_Label></TD>
					</TR>
				</TABLE>
			</cc2:datapanel></TD>
	</TR>
	<TR>
		<TD><cc2:datapanel id="PanelDL" runat="server" CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch"
				Collapsed="False" TitleText="Validazione da parte del Direttore dei Lavori" ExpandText="Espandi"
				ExpandImageUrl="../Images/downarrows_trans.gif" CollapseText="Riduci" CollapseImageUrl="../Images/uparrows_trans.gif"
				AllowTitleExpandCollapse="True">
				<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD style="WIDTH: 170px; HEIGHT: 12px"><B>Data di validazione:</B></TD>
						<TD>
							<cc1:S_Label id="lblDataValidDL" runat="server"></cc1:S_Label></TD>
						<TD style="WIDTH: 143px; HEIGHT: 17px"><B>Ora validazione:</B></TD>
						<TD>
							<cc1:S_Label id="lblOraValidDL" runat="server"></cc1:S_Label></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 170px; HEIGHT: 12px"><STRONG>Tipo Manutenzione:</STRONG></TD>
						<TD>
							<asp:Label id="lblTipoManutenzione" Runat="server"></asp:Label></TD>
						<TD colSpan="2"><STRONG>Lavoro da quantificare successivamente&nbsp;:</STRONG>
							<cc1:S_CheckBox id="checkQuantifica" runat="server" Font-Bold="True" DBDataType="Integer" DBDirection="Input"></cc1:S_CheckBox></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 172px; HEIGHT: 17px"><STRONG>Utente:</STRONG></TD>
						<TD>
							<cc1:S_Label id="lblUtenteDL" runat="server"></cc1:S_Label></TD>
						<TD style="WIDTH: 143px; HEIGHT: 17px"><B>Stato:</B></TD>
						<TD>
							<cc1:S_Label id="lblStatoDL" runat="server"></cc1:S_Label></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR id="tipointervento0" runat="server">
						<TD style="WIDTH: 172px; HEIGHT: 17px"><STRONG>Ordine di lavoro FSL:</STRONG></TD>
						<TD>
							<asp:Label id="lblOrdineLavoroFSL" Runat="server"></asp:Label></TD>
						<TD style="WIDTH: 143px; HEIGHT: 17px"></TD>
						<TD colSpan="3"></TD>
					</TR>
					<TR id="tipointervento1" runat="server">
						<TD style="WIDTH: 172px; HEIGHT: 17px"><STRONG>Tipo Intervento:</STRONG></TD>
						<TD>
							<asp:Label id="lblTipoIntervento" Runat="server"></asp:Label></TD>
						<TD style="WIDTH: 143px; HEIGHT: 17px"><STRONG>Spesa Presunta:</STRONG></TD>
						<TD colSpan="3">
							<asp:Label id="lblSpesaPresunta" Runat="server"></asp:Label></TD>
					</TR>
					<TR id="tipointervento2" runat="server">
						<TD style="WIDTH: 172px; HEIGHT: 17px"><STRONG>Data prevista Inizio:</STRONG></TD>
						<TD>
							<asp:Label id="lblDataPrevistaInizio" Runat="server"></asp:Label></TD>
						<TD style="WIDTH: 143px; HEIGHT: 17px"><STRONG>Data Fine:</STRONG></TD>
						<TD colSpan="3">
							<asp:Label id="lblDataPrevistaFine" Runat="server"></asp:Label></TD>
					</TR>
				</TABLE>
			</cc2:datapanel></TD>
	</TR>
	<TR>
		<TD><cc2:datapanel id="PanelCofatec" runat="server" CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch"
				Collapsed="False" TitleText="Emissione Ordine di Lavoro" ExpandText="Espandi" ExpandImageUrl="../Images/downarrows_trans.gif"
				CollapseText="Riduci" CollapseImageUrl="../Images/uparrows_trans.gif" AllowTitleExpandCollapse="True">
				<TABLE id="Tableordine" cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
					<TR>
						<TD style="HEIGHT: 29px" width="20%"><B>Ordine di lavoro:</B>
						</TD>
						<TD>
							<asp:Label id="lblOrdineLavoro" Runat="server"></asp:Label></TD>
					</TR>
				</TABLE>
				<TABLE id="Table5" cellSpacing="1" cellPadding="2" width="100%" border="0">
					<TR>
						<TD style="HEIGHT: 29px" width="20%"><B>Ditta Esecutrice:</B></TD>
						<TD style="WIDTH: 169px; HEIGHT: 29px">
							<asp:Label id="lblDitta" Runat="server"></asp:Label></TD>
						<TD style="HEIGHT: 29px"><B>Addetto:</B></TD>
						<TD style="HEIGHT: 29px">
							<asp:Label id="lblAddetto" Runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 16px"><B><B>Urgenza:</B></B></TD>
						<TD style="WIDTH: 169px; HEIGHT: 16px">
							<asp:Label id="lblUrgenza" runat="server"></asp:Label></TD>
						<TD style="HEIGHT: 16px"><B></B></TD>
						<TD style="HEIGHT: 16px"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 32px"><B>Data Pianificata:</B></TD>
						<TD style="WIDTH: 169px; HEIGHT: 32px">
							<asp:Label id="lblDataPianificata" Runat="server"></asp:Label></TD>
						<TD style="HEIGHT: 32px"><B>Orario Pianificato:</B></TD>
						<TD style="HEIGHT: 32px">
							<asp:Label id="lblOreMinuti" Runat="server"></asp:Label></TD>
					</TR>
					<TR id="preventivo1" runat="server">
						<TD><B>Preventivo n°: </B>
						</TD>
						<TD style="WIDTH: 169px">
							<asp:Label id="lblNumPreventivo" Runat="server"></asp:Label></TD>
						<TD><B>Importo Preventivo:</B></TD>
						<TD>
							<asp:Label id="lblImportoPreventivo" Runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD colSpan="4">
							<asp:Label id="LblMessaggio" runat="server" Width="560px"></asp:Label></TD>
					</TR>
				</TABLE>
			</cc2:datapanel></TD>
	</TR>
	<tr>
		<td><cc2:datapanel id="PanelCompleta" runat="server" CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch"
				Collapsed="False" TitleText="Completamento Ordine di Lavoro" ExpandText="Espandi" ExpandImageUrl="../Images/downarrows_trans.gif"
				CollapseText="Riduci" CollapseImageUrl="../Images/uparrows_trans.gif" AllowTitleExpandCollapse="True">
				<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="20%"><B>Stato Richiesta di Lavoro:</B></TD>
						<TD>
							<asp:Label id="lblStatoLavoro" Runat="server"></asp:Label></TD>
					</TR>
					<TR id="trnote" runat="server">
						<TD width="20%"><B>Sospesa per:</B></TD>
						<TD>
							<asp:Label id="lblSospesa" Runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD width="20%"><B>Data inizio:</B></TD>
									<TD style="WIDTH: 227px">
										<asp:Label id="lblDataInizio" Runat="server"></asp:Label></TD>
									<TD><B>Ora Inizio:</B></TD>
									<TD>
										<asp:Label id="lblOreMinutiInizio" Runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD width="20%"><B>Data Fine:</B></TD>
									<TD style="WIDTH: 227px">
										<asp:Label id="lblDataFine" Runat="server"></asp:Label></TD>
									<TD><B>Ora Fine:</B></TD>
									<TD>
										<asp:Label id="lblOreMinutiFine" Runat="server"></asp:Label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="trannotazione" runat="server">
						<TD style="WIDTH: 171px"><B></B></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 171px"><B>Annotazioni Materiale Utilizzato:</B></TD>
						<TD>
							<asp:Label id="lblAnnotazioni" Runat="server"></asp:Label></TD>
					</TR>
					<TR id="trconsuntivo1" runat="server">
						<TD style="WIDTH: 171px"><B>Importo a Consuntivo:</B></TD>
						<TD>
							<asp:Label id="lblImpCons" Runat="server"></asp:Label></TD>
					</TR>
					<TR id="trconsuntivo2" runat="server">
						<TD style="WIDTH: 171px"><B>Contabilizzazione:</B></TD>
						<TD>
							<asp:Label id="lblContabilizzazione" Runat="server"></asp:Label></TD>
					</TR>
					<TR id="trannocontab" runat="server">
						<TD style="WIDTH: 171px"><B>Anno Contabilizzazione:</B></TD>
						<TD>
							<asp:Label id="lblAnno" Runat="server"></asp:Label></TD>
					</TR>
					<TR id="trsoddisfazione" runat="server">
						<TD style="WIDTH: 171px"><B>Livello Soddisfazione:</B></TD>
						<TD>
							<asp:RadioButtonList id="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Enabled="false">
								<asp:ListItem Selected="True" Value="0">Non dichiarato</asp:ListItem>
								<asp:ListItem Value="1">Inadeguato</asp:ListItem>
								<asp:ListItem Value="2">Parzialmente Adeguato</asp:ListItem>
								<asp:ListItem Value="3">Adeguato</asp:ListItem>
								<asp:ListItem Value="4">Non dichiarato</asp:ListItem>
								<asp:ListItem Value="5">Eccellente</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
						<TD></TD>
					</TR>
				</TABLE>
			</cc2:datapanel></td>
	</tr>
	<tr>
		<td align="center"><cc1:s_button id="BtnElimina" runat="server" Width="140px" Visible="True" CausesValidation="False"
				Text="Elimina RdL selezionata"></cc1:s_button><cc1:s_button id="btnChiudicompleta" runat="server" Width="100px" CausesValidation="False" Text="Annulla"></cc1:s_button></td>
	</tr>
</TABLE>
