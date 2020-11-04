<%@ Page language="c#" Codebehind="ReportGiudizioCliente.aspx.cs" AutoEventWireup="false" Inherits="TheSite.SoddisfazioneCliente.ReportGiudizioCliente" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="RichiedentiSollecito" Src="../WebControls/RichiedentiSollecito.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Giudizio</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
 
			function EmesseSetVisible(state)
			{
			var DivRef = document.getElementById('PanelEmesse');
			var IfrRef = document.getElementById('DivEmesse');
			if(state)
			{
				DivRef.style.display = "block";
				IfrRef.style.width = DivRef.offsetWidth;
				IfrRef.style.height = DivRef.offsetHeight;
				IfrRef.style.top = DivRef.style.top;
				IfrRef.style.left = DivRef.style.left;
				IfrRef.style.zIndex = DivRef.style.zIndex - 1;
				IfrRef.style.display = "block";
			}
			else
			{
				DivRef.style.display = "none";
				IfrRef.style.display = "none";
			}
			   
			   
			}

		</SCRIPT>
	</HEAD>
	<BODY bottommargin="0" onbeforeunload="parent.left.valorizza()" leftmargin="5" topmargin="0"
		rightmargin="0" ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px"
				cellspacing="0" cellpadding="0" align="center" border="0">
				<TBODY>
					<TR>
						<TD align="center"><UC1:PAGETITLE id="PageTitle1" runat="server"></UC1:PAGETITLE></TD>
					</TR>
					<TR>
						<TD valign="top" align="center" width="100%">
							<TABLE id="tblForm" style="WIDTH: 100%" cellspacing="1" cellpadding="1" align="center"
								border="0">
								<TBODY>
									<TR>
										<TD valign="top" width="100%"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" titlestyle-cssclass="TitleSearch" cssclass="DataPanel75"
												titletext="Ricerca" allowtitleexpandcollapse="True" collapsed="False" expandtext="Espandi" collapsetext="Riduci" collapseimageurl="../Images/up.gif"
												expandimageurl="../Images/down.gif">
												<TABLE style="WIDTH: 100%">
													<TBODY>
														<TR>
															<TD style="WIDTH: 100%" colspan="4">
																<TABLE id="TableRicercaModulo" style="WIDTH: 100%" cellspacing="1" cellpadding="1" border="0">
																	<TR>
																		<TD><UC1:RICERCAMODULO id="RicercaModulo1" runat="server"></UC1:RICERCAMODULO></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD colspan="4">
																<TABLE class="tblSearch100Dettaglio" style="WIDTH: 100%" cellspacing="1" cellpadding="1"
																	border="0">
																	<TR>
																		<TD width="10%">Data Da</TD>
																		<TD align="left" width="40%"><UC1:CALENDARPICKER id="CPDataDa" runat="server"></UC1:CALENDARPICKER></TD>
																		<TD width="10%">Data A
																		</TD>
																		<TD align="left" width="40%"><UC1:CALENDARPICKER id="CPDataA" runat="server"></UC1:CALENDARPICKER></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD colspan="4">
																<TABLE id="TableRicercaApparecchiatura" style="WIDTH: 100%" cellspacing="1" cellpadding="1"
																	border="0">
																	<TBODY>
																		<TR>
																			<TD><UC1:CODICEAPPARECCHIATURE id="CodiceApparecchiature1" runat="server"></UC1:CODICEAPPARECCHIATURE></TD>
																		</TR>
																	</TBODY>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD align="center" colspan="4"><ASP:PANEL id="PanelServizio" runat="server">
																	<TABLE class="tblSearch100Dettaglio" id="Table2" style="WIDTH: 100%" cellSpacing="1" cellPadding="1"
																		border="0">
																		<TR>
																			<TD style="HEIGHT: 13px" width="10%">Servizio</TD>
																			<TD style="HEIGHT: 13px" align="left" width="40%">
																				<CC1:S_COMBOBOX id="cmbsServizio" runat="server" dbparametername="p_Servizio_Id" dbdatatype="Integer"
																					autopostback="True" dbindex="10" dbsize="4" width="280px"></CC1:S_COMBOBOX></TD>
																			<TD style="HEIGHT: 16px">Report Giudizio Cliente</TD>
																			<TD style="HEIGHT: 16px" align="left" width="40%">
																				<CC1:S_COMBOBOX id="cmbsGiudizio" runat="server" dbparametername="p_Giudizio_Id" dbdatatype="Integer"
																					autopostback="False" dbindex="10" dbsize="4" width="280px"></CC1:S_COMBOBOX></TD>
																		</TR>
																		<TR>
																			<TD style="HEIGHT: 13px" width="10%">Tipo Giudizio</TD>
																			<TD style="HEIGHT: 13px" align="left" width="40%" colSpan="3">
																				<CC1:S_COMBOBOX id="cmbsTipoGiudizio" runat="server" dbparametername="p_Servizio_Id" dbdatatype="Integer"
																					dbindex="10" dbsize="4" width="152px">
																					<ASP:LISTITEM value="T" selected="True">Entrambi</ASP:LISTITEM>
																					<ASP:LISTITEM value="F">A Freddo</ASP:LISTITEM>
																					<ASP:LISTITEM value="C">A Caldo</ASP:LISTITEM>
																				</CC1:S_COMBOBOX></TD>
																		</TR>
																	</TABLE>
																</ASP:PANEL></TD>
														</TR>
														<TR>
															<TD colspan="4">&nbsp;</TD>
														</TR>
														<TR>
															<TD align="left" colspan="3"><CC1:S_BUTTON id="btnsRicerca" tabindex="4" runat="server" cssclass="btn" text="Ricerca"></CC1:S_BUTTON>&nbsp;&nbsp;
																<CC1:S_BUTTON id="cmdExcel" tabindex="2" runat="server" cssclass="btn" text="Esporta"></CC1:S_BUTTON><CC1:S_BUTTON id="btnReset" tabindex="5" runat="server" cssclass="btn" text="Reset"></CC1:S_BUTTON>&nbsp;</TD>
															<TD align="right"><A class=GuidaLink 
                  href="<%= HelpLink %>" target=_blank 
                  >Guida</A>
															</TD>
														</TR>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
					</COLLAPSE:DATAPANEL></TD></TR>
					<TR>
						<TD align="center"><UC1:GRIDTITLE id="GridTitle1" runat="server" visible="False"></UC1:GRIDTITLE><ASP:DATAGRID id="DataGridRicerca" runat="server" cssclass="DataGrid" bordercolor="Gray" borderwidth="1px"
								autogeneratecolumns="False" gridlines="Vertical" allowpaging="True">
								<ALTERNATINGITEMSTYLE cssclass="DataGridAlternatingItemStyle"></ALTERNATINGITEMSTYLE>
								<ITEMSTYLE cssclass="DataGridItemStyle"></ITEMSTYLE>
								<HEADERSTYLE cssclass="DataGridHeaderStyle"></HEADERSTYLE>
								<COLUMNS>
									<ASP:BOUNDCOLUMN datafield="tipologia_giudizio" headertext="Tipo Giudizio"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="bl_id" headertext="Edificio">
										<HEADERSTYLE width="15%"></HEADERSTYLE>
									</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="servizio" headertext="Servizio"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="soddisfazione" headertext="Giudizio Cliente"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="totale" headertext="Numero Giudizi"></ASP:BOUNDCOLUMN>
								</COLUMNS>
								<PAGERSTYLE mode="NumericPages"></PAGERSTYLE>
							</ASP:DATAGRID></TD>
					</TR>
				</TBODY>
			</TABLE>
			</TD></TR></TBODY></TABLE></FORM>
		<SCRIPT language="javascript">parent.left.calcola();</SCRIPT>
	</BODY>
</HTML>
