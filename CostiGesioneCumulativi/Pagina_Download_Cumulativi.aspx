<%@ Page language="c#" Codebehind="Pagina_Download_Cumulativi.aspx.cs" AutoEventWireup="false" Inherits="TheSite.CostiGesioneCumulativi.Pagina_Download_Cumulativi" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Pagina_Download</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="tblMain" width="100%">
				<TBODY>
					<TR>
						<TD align="center" colSpan="2"><UC1:PAGETITLE id="pgtlDownoloadStampe" runat="server"></UC1:PAGETITLE></TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="2"><UC1:GRIDTITLE id="GridTitleDownLoad" runat="server"></UC1:GRIDTITLE><ASP:DATAGRID id="DataGridRicerca" runat="server" bordercolor="Gray" borderwidth="1px" gridlines="Vertical"
								allowpaging="True" autogeneratecolumns="False" cssclass="DataGrid">
								<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
								<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<HeaderStyle Width="1%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
										<ItemTemplate>
											<ASP:IMAGEBUTTON id=imgBtnVisualizza runat="server" OnCommand="imgBtnVisualizza_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"nome_file")  %>' imageurl="../images/eye.gif">
											</ASP:IMAGEBUTTON>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="1%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
										<ItemTemplate>
											<ASP:IMAGEBUTTON id="imgBtnDownLoad" runat="server" imageurl="../images/salva.gif" oncommand="imgBtnDownLoad_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"nome_file") %>'>
											</ASP:IMAGEBUTTON>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="1%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
										<ItemTemplate>
											<ASP:IMAGEBUTTON id="imgBtnElimina" runat="server" imageurl="../images/elimina.gif" OnCommand="imgBtnElimina_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"rpt_id") + "," + DataBinder.Eval(Container.DataItem,"nome_file") %>'>
											</ASP:IMAGEBUTTON>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="3%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
										<ItemTemplate>
											<ASP:IMAGEBUTTON id="lnkDett" runat="server" OnCommand="lnkDett_Click" imageurl="../images/Search16x16_bianca.JPG" commandargument= '<%# DataBinder.Eval(Container.DataItem,"rpt_id") %>'>
											</ASP:IMAGEBUTTON>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="rpt_id" HeaderText="id"></asp:BoundColumn>
									<asp:BoundColumn DataField="data_created" HeaderText="Data di stampa report">
										<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="codice_edificio" HeaderText="Edificio">
										<HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="stringardl" HeaderText="Intervallo RDL">
										<HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="addetto_id" HeaderText="Addetto">
										<HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STATO_RICHIESTA" HeaderText="Stato richiesta">
										<HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DIMENSIONEFILE_PDF_ZIP" HeaderText="Dim. file Pdf/Zip(byte)">
										<HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" CssClass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD align="left" width="15%"><CC1:S_BUTTON id="S_btnRicerca" runat="server" cssclass="btn" width="160px" text="Pagina Ricerca e  Stampa"></CC1:S_BUTTON></TD>
						<TD align="left"><CC1:S_BUTTON id="S_btnEliminaTiitiFile" runat="server" cssclass="btn" width="160px" text="Elimina Tutti I File"></CC1:S_BUTTON>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<A class=GuidaLink href="<%= HelpLink %>" target=_blank 
      >Guida</A></TD>
					</TR>
				</TBODY>
			</TABLE>
			<TABLE>
				<TBODY>
					<TR>
						<TD><ASP:LABEL id="lblId" runat="server"></ASP:LABEL></TD>
					</TR>
				</TBODY>
			</TABLE>
			<TABLE>
				<TBODY>
					<TR>
						<TD><ASP:PANEL id="pnlShowInfo" runat="server" cssclass="ShowInfoPanel350" visible="False">
								<TABLE height="100%" width="100%">
									<TR>
										<TD class="TitleSearch" vAlign="top" align="right" colSpan="2" height="15">
											<ASP:LINKBUTTON id="lnkChiudi" runat="server" cssclass="LabelChiudi" causesvalidation="False">Chiudi</ASP:LINKBUTTON></TD>
									</TR>
									<TR>
										<TD vAlign="top">
											<TABLE class="BordiTabella" id="tblFrequenze" cellSpacing="0" cellPadding="2" border="1">
												<TR>
													<TD colSpan="2">
														<ASP:LABEL id="lblIntestazione" runat="server" font-size="Larger" forecolor="#000099">Scheda di dettaglio rapportino interventi MAnutenzione Programmata</ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="lblC11" runat="server">Data di creazione</ASP:LABEL></TD>
													<TD align="right">
														<ASP:LABEL id="lblDataDiCreazione" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL18" runat="server">Richiesta di lavoro</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblRichiestaLavoro" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL19" runat="server">Edificio</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblEdificio" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL20" runat="server">Comune</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblComune" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL21" runat="server">Intervallo Rdl</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblIntervalloRdl" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL22" runat="server">Ditta</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblDitta" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL23" runat="server">Ordine di Lavoro</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblOdl" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL3" runat="server">Richiedenti</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblRichiedenti" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL4" runat="server">Gruppo</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblGruppo" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL5" runat="server">Servizio</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblServizio" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL24" runat="server">Addetto</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblAddetto" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL25" runat="server">Urgenza</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblUrgenza" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL6" runat="server">Tipo manutenzione</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblTipoManutenzione" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL26" runat="server">Stato Richiesta</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblStatoRichiesta" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="Label1" runat="server">Data Da</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblDataDa" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL2" runat="server">Data A</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblDataA" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<asp:Label id="Label7" runat="server">Data prevista inizio</asp:Label></TD>
													<TD>
														<asp:Label id="lblDataPrevistaInizio" runat="server"></asp:Label></TD>
												</TR>
												<TR>
													<TD>
														<asp:Label id="Label8" runat="server">Data prevista fine</asp:Label></TD>
													<TD>
														<asp:Label id="lblDataPrevistaFine" runat="server"></asp:Label></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL27" runat="server">Dimensione file Pdf(byte)</ASP:LABEL></TD>
													<TD align="right">
														<ASP:LABEL id="lblDimensioneFilePdf" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL28" runat="server">Dimensione file Zip(byte)</ASP:LABEL></TD>
													<TD align="right">
														<ASP:LABEL id="lblDimensioneFileZip" runat="server"></ASP:LABEL></TD>
												</TR> <!--<TR>
													<TD>
														<ASP:LABEL id="LABEL29" runat="server">Data assegnazione iniziale</ASP:LABEL></TD>
													<TD align="right">
														<ASP:LABEL id="lblDataAssegnazioneIniziale" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL30" runat="server">Data assegnazione finale</ASP:LABEL></TD>
													<TD align="right">
														<ASP:LABEL id="lblDataAssegnazioneFinale" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL31" runat="server">Data completamento iniziale</ASP:LABEL></TD>
													<TD align="right">
														<ASP:LABEL id="lblDataCompletamentoIniziale" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL32" runat="server">Data completamento finale</ASP:LABEL></TD>
													<TD align="right">
														<ASP:LABEL id="lblDataCompletamentoFinale" runat="server"></ASP:LABEL></TD>
												</TR>--></TABLE>
										</TD>
									</TR>
								</TABLE>
							</ASP:PANEL></TD>
					</TR>
				</TBODY>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
