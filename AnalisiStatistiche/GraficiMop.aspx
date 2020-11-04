<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Page language="c#" Codebehind="GraficiMop.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnalisiStatistiche.GraficiMop" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Report Manutenzione Programmata</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="jscript">
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
						<TD title="Data Di Richiesta" align="center"><UC1:PAGETITLE id="PageTitleReport" runat="server"></UC1:PAGETITLE></TD>
					</TR>
					<TR>
						<TD valign="top" align="center">
							<TABLE id="tblForm" cellspacing="0" cellpadding="0" width="100%" align="center">
								<TBODY>
									<TR>
										<TD valign="top" align="left">
											<CC2:DATAPANEL id="DataPanelRicerca" runat="server" titlestyle-cssclass="TitleSearch" collapsed="False"
												titletext="Ricerca " expandtext="Espandi" expandimageurl="../Images/down.gif" collapsetext="Riduci"
												cssclass="DataPanel75" collapseimageurl="../Images/up.gif" allowtitleexpandcollapse="True">
												<TABLE id="TabellaRicercaMaster" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD>
															<TABLE id="tblSearch100" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD style="HEIGHT: 10px" align="left" width="10%">Da</TD>
																	<TD style="HEIGHT: 10px" align="left" width="40%">
																		<UC1:CALENDARPICKER id="DataPkInit" runat="server"></UC1:CALENDARPICKER>
																		<ASP:COMPAREVALIDATOR id="ValidatorDataInit" tabIndex="11" runat="server" operator="LessThanEqual" type="Date"
																			errormessage="La data iniziale dell' intervallo temporale selezionato deve essere minore di quella finale.">*</ASP:COMPAREVALIDATOR></TD>
																	<TD style="HEIGHT: 10px" align="left" width="10%">A</TD>
																	<TD style="HEIGHT: 10px" align="left" width="40%">
																		<UC1:CALENDARPICKER id="DataPkEnd" runat="server"></UC1:CALENDARPICKER>
																		<ASP:COMPAREVALIDATOR id="ValidatorDataEnd" tabIndex="12" runat="server" operator="GreaterThanEqual" type="Date">*</ASP:COMPAREVALIDATOR>
																		<SCRIPT language="javascript">
																			if(<%=status%> == 0)
																			{
																			document.getElementById("<%=DataPkInit.Datazione.ClientID%>").value="<%=VarDataInit%>";
																			document.getElementById("<%=DataPkEnd.Datazione.ClientID%>").value="<%=VarDataEnd%>";
																			};
																		</SCRIPT>
																	</TD>
																</TR>
																<TR>
																	<TD align="center" colSpan="4">
																		<TABLE id="tblRadiobtn" cellSpacing="1" cellPadding="1" width="20%" align="center" border="0">
																			<TR>
																				<TD noWrap align="left">
																					<CC1:S_OPTIONBUTTON id="S_OptBtnDataAssegnazione" tabIndex="1" runat="server" text="Data Di Assegnazione"
																						groupname="GrSelection" checked="True"></CC1:S_OPTIONBUTTON></TD>
																			</TR>
																			<TR>
																				<TD noWrap align="left">
																					<CC1:S_OPTIONBUTTON id="S_OptBtnDataChiusura" tabIndex="2" runat="server" text="Data Di Chiusura" groupname="GrSelection"></CC1:S_OPTIONBUTTON></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="tblSearch102" cellSpacing="1" cellPadding="1" width="100%" border="0">
																<TR>
																	<TD align="right" width="10%"><IMG src="../Images/Pie.png">
																	</TD>
																	<TD align="left" width="20%">
																		<CC1:S_OPTIONBUTTON id="S_OptBtnRdlMese" tabIndex="3" runat="server" text="Rdl Per Mese" groupname="Grkind"
																			checked="True"></CC1:S_OPTIONBUTTON></TD>
																	<TD align="center" width="7%"><IMG src="../Images/GraficiIstogramma.png">
																	</TD>
																	<TD align="left" width="26%">
																		<CC1:S_OPTIONBUTTON id="S_OptBtnRdlServizioMesi" tabIndex="5" runat="server" text="Rdl Per Servizio Nei Mesi"
																			groupname="Grkind"></CC1:S_OPTIONBUTTON></TD>
																	<TD align="center" width="7%"><IMG src="../Images/Pie.png">
																	</TD>
																	<TD align="left" width="20%">
																		<CC1:S_OPTIONBUTTON id="S_OptBtnRdlStato" tabIndex="7" runat="server" text="Rdl Per Stato" groupname="Grkind"></CC1:S_OPTIONBUTTON></TD>
																</TR>
																<TR>
																	<TD align="right" width="10%"><IMG src="../Images/Pie.png">
																	</TD>
																	<TD align="left" width="20%">
																		<CC1:S_OPTIONBUTTON id="S_OptBtnRdlDitta" tabIndex="4" runat="server" text="Rdl Per Ditta" groupname="Grkind"></CC1:S_OPTIONBUTTON></TD>
																	<TD align="center" width="7%"><IMG src="../Images/GraficiIstogramma.png">
																	</TD>
																	<TD align="left" width="26%">
																		<CC1:S_OPTIONBUTTON id="S_OptBtnRdlDittaMesi" tabIndex="6" runat="server" text="Rdl Per Ditta Nei Mesi"
																			groupname="Grkind"></CC1:S_OPTIONBUTTON></TD>
																	<TD align="center" width="7%"><IMG src="../Images/Pie.png">
																	</TD>
																	<TD align="left" width="20%">
																		<CC1:S_OPTIONBUTTON id="S_OptBtnRdlServizio" tabIndex="7" runat="server" text="Rdl Per Servizio" groupname="Grkind"></CC1:S_OPTIONBUTTON></TD>
																</TR>
																<TR>
																	<TD align="center" colSpan="6">
																		<TABLE id="tblSubmit" cellSpacing="1" cellPadding="1" width="20%" align="center" border="0">
																			<TR>
																				<TD noWrap align="left">
																					<CC1:S_BUTTON id="S_BtnSubmit" tabIndex="9" runat="server" cssclass="btn" text="Genera il Report in Html"
																						width="150px"></CC1:S_BUTTON></TD>
																				<TD>
																					<ASP:BUTTON id="btnReportPdf" runat="server" cssclass="btn" text="Genera il Report in Pdf" width="150px"></ASP:BUTTON></TD>
																				<TD noWrap align="left"><INPUT class="btn" style="WIDTH: 150px" onclick="superClear();" tabIndex="10" type="reset"
																						value="Reset">
																				</TD>
																				<TD noWrap align="right">&nbsp; <A class=GuidaLink 
                              href="<%= HelpLink %>" 
                          target=_blank>Guida</A></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
															<ASP:VALIDATIONSUMMARY id="ValidationSummary1" tabIndex="10" runat="server"></ASP:VALIDATIONSUMMARY></TD>
													</TR>
												</TABLE>
											</CC2:DATAPANEL>
										</TD>
									</TR>
									<TR>
										<TD>
											<TABLE id="DysplayGrafico" height="1200" cellspacing="0" cellpadding="0" align="left" border="0"
												width="100%">
												<TBODY>
													<TR>
														<TD>
															<IFRAME class="fram" id="ifrReport" name="ifrReport" frameborder="no" width="100%" scrolling="no"
																height="100%" title="Display Report" tabindex="0" src="about:blank"></IFRAME>
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
