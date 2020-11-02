<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Page language="c#" Codebehind="GraficiGiudizio.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnalisiStatistiche.GraficiGiudizio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Grafici Manutenzione Su Richiesta</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
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
						<TD title="Data Di Richiesta" align="center"><UC1:PAGETITLE id="PageTitleReport" runat="server"></UC1:PAGETITLE></TD>
					</TR>
					<TR>
						<TD valign="top" align="center"><CC2:DATAPANEL id="DataPanelRicerca" runat="server" titlestyle-cssclass="TitleSearch" collapsed="False"
								titletext="Ricerca " expandtext="Espandi" expandimageurl="../Images/down.gif" collapsetext="Riduci" cssclass="DataPanel75"
								collapseimageurl="../Images/up.gif" allowtitleexpandcollapse="True">
								<TABLE id="tblForm" cellSpacing="0" cellPadding="0" width="100%" align="center">
									<TR>
										<TD vAlign="top" align="left">
											<TABLE id="TabellaRicercaMaster" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD align="left" width="10%">Da</TD>
													<TD align="left" width="40%">
														<UC1:CALENDARPICKER id="DataPkInit" runat="server"></UC1:CALENDARPICKER>
														<ASP:COMPAREVALIDATOR id="ValidatorDataInit" tabIndex="11" runat="server" type="Date" operator="LessThanEqual"
															errormessage="La data iniziale dell' intervallo temporale selezionato deve essere minore di quella finale.">*</ASP:COMPAREVALIDATOR></TD>
													<TD align="left" width="10%">A</TD>
													<TD align="left" width="40%">
														<UC1:CALENDARPICKER id="DataPkEnd" runat="server"></UC1:CALENDARPICKER>
														<ASP:COMPAREVALIDATOR id="ValidatorDataEnd" tabIndex="12" runat="server" type="Date" operator="GreaterThanEqual">*</ASP:COMPAREVALIDATOR>
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
													<TD>
														<ASP:LABEL id="lblServizio" runat="server">Servizio</ASP:LABEL></TD>
													<TD>
														<ASP:DROPDOWNLIST id="cmbServizio" runat="server" width="136px"></ASP:DROPDOWNLIST></TD>
													<TD></TD>
													<TD></TD>
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
														<CC1:S_OPTIONBUTTON id="S_optbtnGiudizio" tabIndex="7" runat="server" groupname="Grkind" text="Giudizio Per Servizio "
															checked="True"></CC1:S_OPTIONBUTTON></TD>
													<TD align="center" width="7%"><IMG src="../Images/GraficiIstogramma.png">
													</TD>
													<TD align="left" width="26%">
														<CC1:S_OPTIONBUTTON id="S_optbtnGiudizioTipologia" tabIndex="4" runat="server" groupname="Grkind" text="Giudizio Per Servizio per Tipologia Giudizio"></CC1:S_OPTIONBUTTON></TD>
													<TD align="center" width="7%"><IMG src="../Images/GraficiIstogramma.png">
													</TD>
													<TD align="left" width="20%">
														<CC1:S_OPTIONBUTTON id="S_optbtnGiudizioMesi" tabIndex="6" runat="server" groupname="Grkind" text="Giudizio Per Servizio Nei Mesi"></CC1:S_OPTIONBUTTON></TD>
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
													<TD align="center" colSpan="6">
														<TABLE id="tblSubmit" style="WIDTH: 480px; HEIGHT: 26px" cellSpacing="1" cellPadding="1"
															width="480" align="center" border="0">
															<TR>
																<TD noWrap align="left">
																	<CC1:S_BUTTON id="S_BtnSubmit" tabIndex="9" runat="server" cssclass="btn" width="150px" text="Genera il Report in Html"></CC1:S_BUTTON></TD>
																<TD>
																	<ASP:BUTTON id="btnReportPdf" runat="server" cssclass="btn" width="150px" text="Genera il Report in Pdf"></ASP:BUTTON></TD>
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
			</TD></TR></TBODY></TABLE></FORM>
	</BODY>
</HTML>
