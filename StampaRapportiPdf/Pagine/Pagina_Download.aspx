<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Page language="c#" Codebehind="Pagina_Download.aspx.cs" AutoEventWireup="false" Inherits="StampaRapportiPdf.Pagine.Pagina_Download" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Pagina_Download</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="tblMain" width="100%">
				<TBODY>
					<TR>
						<TD align="center" colspan="2"><UC1:PAGETITLE id="pgtlDownoloadStampe" runat="server"></UC1:PAGETITLE></TD>
					</TR>
					<TR>
						<TD colspan="2"></TD>
					</TR>
					<TR>
						<TD valign="top" align="center" colspan="2"><UC1:GRIDTITLE id="GridTitleDownLoad" runat="server"></UC1:GRIDTITLE><ASP:DATAGRID id="DataGridRicerca" runat="server" cssclass="DataGrid" autogeneratecolumns="False"
								allowpaging="True" gridlines="Vertical" borderwidth="1px" bordercolor="Gray">
								<ALTERNATINGITEMSTYLE cssclass="DataGridAlternatingItemStyle"></ALTERNATINGITEMSTYLE>
								<ITEMSTYLE cssclass="DataGridItemStyle"></ITEMSTYLE>
								<HEADERSTYLE cssclass="DataGridHeaderStyle"></HEADERSTYLE>
								<COLUMNS>
									<ASP:TEMPLATECOLUMN>
										<HEADERSTYLE width="1%"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
										<ITEMTEMPLATE>
											<ASP:IMAGEBUTTON id="imgBtnVisualizza" runat="server" imageurl="../images/eye.gif" OnCommand="imgBtnVisualizza_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"nome_file")  %>'>
											</ASP:IMAGEBUTTON>
										</ITEMTEMPLATE>
									</ASP:TEMPLATECOLUMN>
									<ASP:TEMPLATECOLUMN>
										<HEADERSTYLE width="1%"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
										<ITEMTEMPLATE>
											<ASP:IMAGEBUTTON id="imgBtnDownLoad" runat="server" imageurl="../images/salva.gif" oncommand="imgBtnDownLoad_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"nome_file") %>'>
											</ASP:IMAGEBUTTON>
										</ITEMTEMPLATE>
									</ASP:TEMPLATECOLUMN>
									<ASP:TEMPLATECOLUMN>
										<HEADERSTYLE width="1%"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
										<ITEMTEMPLATE>
											<ASP:IMAGEBUTTON id="imgBtnElimina" runat="server" imageurl="../images/elimina.gif" OnCommand="imgBtnElimina_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") + "," + DataBinder.Eval(Container.DataItem,"nome_file") %>'>
											</ASP:IMAGEBUTTON>
										</ITEMTEMPLATE>
									</ASP:TEMPLATECOLUMN>
									<ASP:TEMPLATECOLUMN>
										<HEADERSTYLE width="3%"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
										<ITEMTEMPLATE>
											<ASP:IMAGEBUTTON id="lnkDett" runat="server" OnCommand="lnkDett_Click" imageurl="../images/Search16x16_bianca.JPG" commandargument= '<%# DataBinder.Eval(Container.DataItem,"id") %>'>
											</ASP:IMAGEBUTTON>
										</ITEMTEMPLATE>
									</ASP:TEMPLATECOLUMN>
									<ASP:BOUNDCOLUMN visible="False" datafield="id" headertext="id"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="data_created" headertext="Data di stampa report">
										<HEADERSTYLE horizontalalign="center"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Left" wrap="False"></ITEMSTYLE>
									</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="tipologia_report" headertext="Tipologia report">
										<HEADERSTYLE horizontalalign="center" wrap="False"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Left" wrap="False"></ITEMSTYLE>
									</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="DATA_ASS_IN_OUT" headertext="Data di assegn.ne iniziale-finale">
										<HEADERSTYLE horizontalalign="center"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Left" wrap="False"></ITEMSTYLE>
									</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="comune" headertext="Comune">
										<HEADERSTYLE horizontalalign="center" wrap="False"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Left" wrap="False"></ITEMSTYLE>
									</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="edificio" headertext="Edificio">
										<HEADERSTYLE horizontalalign="center" wrap="False"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Left" wrap="False"></ITEMSTYLE>
									</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="intervallo_odl_selezionati" headertext="Intervallo Odl">
										<HEADERSTYLE horizontalalign="center" wrap="False"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Left" wrap="False"></ITEMSTYLE>
									</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="ditta" headertext="Ditta">
										<HEADERSTYLE horizontalalign="center" wrap="False"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Left" wrap="False"></ITEMSTYLE>
									</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="categoria" headertext="Categoria">
										<HEADERSTYLE horizontalalign="center" wrap="False"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Left" wrap="False"></ITEMSTYLE>
									</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="addetto" headertext="Addetto">
										<HEADERSTYLE horizontalalign="center" wrap="False"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Left" wrap="False"></ITEMSTYLE>
									</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="COMPLETATE" headertext="Completate">
										<HEADERSTYLE horizontalalign="center" wrap="False"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Left" wrap="False"></ITEMSTYLE>
									</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="DIMENSIONEFILE_PDF_ZIP" headertext="Dim. file Pdf/Zip(byte)">
										<HEADERSTYLE horizontalalign="center" wrap="False"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Right" wrap="False"></ITEMSTYLE>
									</ASP:BOUNDCOLUMN>
								</COLUMNS>
								<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD align="left" width="15%"><CC1:S_BUTTON id="S_btnRicerca" runat="server" text="Pagina Ricerca e  Stampa" width="160px" cssclass="btn"></CC1:S_BUTTON></TD>
						<TD align="left"><CC1:S_BUTTON id="S_btnEliminaTiitiFile" runat="server" text="Elimina Tutti I File" width="160px"
								cssclass="btn"></CC1:S_BUTTON>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<A 
      class=GuidaLink href="../<%= HelpLink %>" 
  target=_blank>Guida</A></TD>
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
														<ASP:LABEL id="lblIntestazione" runat="server" forecolor="#000099" font-size="Larger">Scheda di dettaglio rapportino interventi MAnutenzione Programmata</ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="lblC11" runat="server">Data di creazione</ASP:LABEL></TD>
													<TD align="right">&nbsp;
														<ASP:LABEL id="lblDataDiCreazione" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL18" runat="server">Tipologia Report</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblTipologiaReport" runat="server"></ASP:LABEL>&nbsp;</TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL19" runat="server">Edificio</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblEdificio" runat="server"></ASP:LABEL>&nbsp;</TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL20" runat="server">Comune</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblComune" runat="server"></ASP:LABEL>&nbsp;</TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL21" runat="server">Intervallo Odl</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblIntervalloOdl" runat="server"></ASP:LABEL>&nbsp;</TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL22" runat="server">Ditta</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblDitta" runat="server"></ASP:LABEL>&nbsp;</TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL23" runat="server">Categoria</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblCategoria" runat="server"></ASP:LABEL>&nbsp;</TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL24" runat="server">Addetto</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblAddetto" runat="server"></ASP:LABEL>&nbsp;</TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL25" runat="server">Solo non completate</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblSoloNonCompletate" runat="server"></ASP:LABEL>&nbsp;</TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL26" runat="server">Solo completate</ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblSoloCompletate" runat="server"></ASP:LABEL>&nbsp;</TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="Label1" runat="server">Solo completate con filtro </ASP:LABEL></TD>
													<TD>
														<ASP:LABEL id="lblSoloCompletateConFiltro" runat="server"></ASP:LABEL>&nbsp;</TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL27" runat="server">Dimensione file Pdf(byte)</ASP:LABEL></TD>
													<TD align="right">&nbsp;
														<ASP:LABEL id="lblDimensioneFilePdf" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL28" runat="server">Dimensione file Zip(byte)</ASP:LABEL></TD>
													<TD align="right">&nbsp;
														<ASP:LABEL id="lblDimensioneFileZip" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL29" runat="server">Data assegnazione iniziale</ASP:LABEL></TD>
													<TD align="right">&nbsp;
														<ASP:LABEL id="lblDataAssegnazioneIniziale" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL30" runat="server">Data assegnazione finale</ASP:LABEL></TD>
													<TD align="right">&nbsp;
														<ASP:LABEL id="lblDataAssegnazioneFinale" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL31" runat="server">Data completamento iniziale</ASP:LABEL></TD>
													<TD align="right">&nbsp;
														<ASP:LABEL id="lblDataCompletamentoIniziale" runat="server"></ASP:LABEL></TD>
												</TR>
												<TR>
													<TD>
														<ASP:LABEL id="LABEL32" runat="server">Data completamento finale</ASP:LABEL></TD>
													<TD align="right">&nbsp;
														<ASP:LABEL id="lblDataCompletamentoFinale" runat="server"></ASP:LABEL></TD>
												</TR>
											</TABLE>
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
