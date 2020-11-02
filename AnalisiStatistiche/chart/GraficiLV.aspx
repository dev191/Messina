<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc2" TagName="CalendarPicker" Src="../../WebControls/CalendarPicker.ascx" %>
<%@ Page language="c#" Codebehind="GraficiLV.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnalisiStatistiche.chart.GraficiLV" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Grafici Manutenzione Su Richiesta</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../images/cal/popcalendar.js"></SCRIPT>
		<LINK href="../../images/cal/popcalendar.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
				function superClear()
			{
				document.getElementById("ifrReport").src="about:blank"
			} 
		</SCRIPT>
	</HEAD>
	<BODY>
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="TableMain" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD title="Data Di Richiesta" align="center" style="HEIGHT: 7px"><UC1:PAGETITLE id="PageTitleReport" runat="server"></UC1:PAGETITLE></TD>
					</TR>
					<TR>
						<TD valign="top" align="center">
							<TABLE id="tblForm" cellspacing="0" cellpadding="0" width="100%" align="center">
								<TBODY>
									<TR>
										<TD valign="top" align="left"><CC2:DATAPANEL id="DataPanelRicerca" runat="server" allowtitleexpandcollapse="True" collapseimageurl="../../Images/up.gif"
												cssclass="DataPanel75" collapsetext="Riduci" expandimageurl="../../Images/down.gif" expandtext="Espandi" titletext="Ricerca "
												collapsed="False" titlestyle-cssclass="TitleSearch">
												<TABLE id="TabellaRicercaMaster" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD>
															<TABLE id="tblSearch100" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD style="HEIGHT: 15px" align="left" width="10%">
																		<ASP:LABEL id="lblTipologiaLavori" runat="server">Tipologia Intervento:</ASP:LABEL></TD>
																	<TD style="HEIGHT: 15px" align="left" width="40%">
																		<ASP:DROPDOWNLIST id="cmbTipologiaInitervento" runat="server" width="130px">
																			<ASP:LISTITEM value="1" selected="True">Sotto Soglia</ASP:LISTITEM>
																			<ASP:LISTITEM value="3">Sopra Soglia</ASP:LISTITEM>
																			<ASP:LISTITEM value="4">Entrambe le Tipologie</ASP:LISTITEM>
																		</ASP:DROPDOWNLIST></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="tblSearch102" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD align="right" width="10%">&nbsp;</TD>
																	<TD align="left" width="20%"></TD>
																	<TD align="center" width="7%">&nbsp;</TD>
																	<TD align="left" width="26%"></TD>
																	<TD align="center" width="7%">&nbsp;</TD>
																	<TD align="left" width="20%"></TD>
																</TR>
																<TR>
																	<TD align="right" width="10%">&nbsp;</TD>
																	<TD align="left" width="20%"></TD>
																	<TD align="center" width="7%">&nbsp;</TD>
																	<TD align="left" width="26%"></TD>
																	<TD align="center" width="7%">&nbsp;</TD>
																	<TD align="left" width="20%"></TD>
																</TR>
																<TR>
																	<TD align="right" width="10%"><IMG src="../../Images/chart.png">
																	</TD>
																	<TD align="left" width="20%">
																		<CC1:S_OPTIONBUTTON id="S_optBtnRdlDispersioneRA" tabIndex="4" runat="server" groupname="Grkind" text="Dispersione Rdl tra Richiesta e Approvazione"
																			checked="True"></CC1:S_OPTIONBUTTON></TD>
																	<TD align="center" width="7%"><IMG src="../../Images/chart.png">
																	</TD>
																	<TD align="left" width="26%">
																		<CC1:S_OPTIONBUTTON id="S_optBtnRdlDispersioneAC" tabIndex="6" runat="server" groupname="Grkind" text="Dispersione Rdl tra Approvazione e Chiusura"></CC1:S_OPTIONBUTTON></TD>
																	<TD align="center" width="7%"><IMG src="../../Images/chart.png">
																	</TD>
																	<TD align="left" width="20%">
																		<CC1:S_OPTIONBUTTON id="S_optBtnRdlDispersioneRC" tabIndex="7" runat="server" groupname="Grkind" text="Dispersione Rdl tra Richiesta e Chiusura"></CC1:S_OPTIONBUTTON></TD>
																</TR>
																<TR>
																	<TD align="center" colSpan="6">
																		<TABLE id="tblSubmit" cellSpacing="1" cellPadding="1" width="20%" align="center" border="0">
																			<TR>
																				<TD noWrap align="left">
																					<CC1:S_BUTTON id="S_BtnSubmit" tabIndex="9" runat="server" cssclass="btn" text="Genera il Report"></CC1:S_BUTTON></TD>
																				<TD noWrap align="left"><INPUT class="btn" onclick="superClear();" tabIndex="10" type="reset" value="Reset">
																				</TD>
																				<TD noWrap align="right">&nbsp; <A class=GuidaLink 
                              href="../<%= HelpLink %>" 
                          target=_blank>Guida</A></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</CC2:DATAPANEL></TD>
									</TR>
									<TR>
										<TD>
											<TABLE id="DysplayGrafico" height="1200" cellspacing="0" cellpadding="0" width="100%" align="left"
												border="0">
												<TBODY>
													<TR>
														<TD><IFRAME class="fram" id="ifrReport" title="Display Report" tabindex="0" name="ifrReport"
																src="about:blank" frameborder="no" width="100%" scrolling="auto" height="100%"></IFRAME>
															<SCRIPT language="javascript">
																document.getElementById("ifrReport").src='<%=urlRpt%>'
															</SCRIPT>
														</TD>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
