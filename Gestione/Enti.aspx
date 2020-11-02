<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="Enti.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.Enti" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Ditte</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellspacing="0"
				cellpadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><UC1:PAGETITLE id="PageTitle1" runat="server"></UC1:PAGETITLE></TD>
				</TR>
				<TR>
					<TD valign="top" align="center" height="95%">
						<TABLE id="tblForm" cellspacing="1" cellpadding="1" align="center">
							<TR>
								<TD style="HEIGHT: 25%" valign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" expandimageurl="../Images/down.gif" collapseimageurl="../Images/up.gif"
										collapsetext="Riduci" expandtext="Espandi" collapsed="False" allowtitleexpandcollapse="True" titletext="Ricerca" cssclass="DataPanel75" titlestyle-cssclass="TitleSearch">
										<TABLE id="tblSearch100" cellspacing="0" cellpadding="2" border="0">
											<TBODY>
												<TR>
													<TD align="left" width="20%">Ente</TD>
													<TD width="30%"><CC1:S_COMBOBOX id="cmbsDescrizione" tabindex="1" runat="server" dbparametername="pDescrizione"
															dbdirection="Input" dbsize="255"></CC1:S_COMBOBOX></TD>
													<TD colspan="2">&nbsp;</TD>
												</TR>
												<TR>
													<TD align="left" width="20%">Indirizzo</TD>
													<TD width="30%"><CC1:S_TEXTBOX id="txtsIndirizzo" tabindex="2" runat="server" dbparametername="pIndirizzo" dbindex="2"
															width="90%" dbsize="0" maxlength="150"></CC1:S_TEXTBOX></TD>
													<TD align="left" width="20%">CAP</TD>
													<TD width="30%"><CC1:S_TEXTBOX id="txtsCap" tabindex="2" runat="server" dbparametername="pCap" dbdirection="Input"
															width="90%" dbsize="0" maxlength="15"></CC1:S_TEXTBOX></TD>
												</TR>
												<TR>
													<TD align="left" width="20%">Provincia</TD>
													<TD width="30%"><CC1:S_TEXTBOX id="txtsProvincia" tabindex="3" runat="server" dbparametername="pProvincia" dbdirection="Input"
															width="90%" maxlength="2"></CC1:S_TEXTBOX></TD>
													<TD align="left">Comune</TD>
													<TD style="HEIGHT: 24px"><CC1:S_TEXTBOX id="txtsComune" tabindex="4" runat="server" dbparametername="pComune " width="90%"
															dbsize="0" maxlength="100"></CC1:S_TEXTBOX></TD>
												</TR>
							</TR>
							<TR>
								<TD style="HEIGHT: 24px" align="left">Ragione Sociale</TD>
								<TD style="HEIGHT: 24px"><CC1:S_TEXTBOX id="txtsRagioneSociale" tabindex="5" runat="server" dbparametername="pRagioneSociale"
										width="90%" dbsize="15" maxlength="15"></CC1:S_TEXTBOX></TD>
								<TD style="HEIGHT: 23px" align="left">Partita IVA</TD>
								<TD style="HEIGHT: 23px"><CC1:S_TEXTBOX id="txtsPartitaIva" tabindex="6" runat="server" dbparametername="pPiva" dbdirection="Input"
										width="90%" maxlength="20"></CC1:S_TEXTBOX></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 23px" align="left">Telefono</TD>
								<TD style="HEIGHT: 23px"><CC1:S_TEXTBOX id="txtsTelefono" tabindex="7" runat="server" dbparametername="pTelefono" dbdirection="Input"
										width="90%" dbsize="10" maxlength="20"></CC1:S_TEXTBOX></TD>
								<TD style="HEIGHT: 23px" align="left">Email</TD>
								<TD style="HEIGHT: 23px"><CC1:S_TEXTBOX id="txtsEmail" tabindex="8" runat="server" dbparametername="pEmail" dbdirection="Input"
										width="90%" maxlength="100"></CC1:S_TEXTBOX></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 24px" align="left">Referente</TD>
								<TD style="HEIGHT: 24px"><CC1:S_TEXTBOX id="txtsReferente" tabindex="9" runat="server" dbparametername="pReferente" dbdirection="Input"
										width="90%" maxlength="100"></CC1:S_TEXTBOX></TD>
								<TD style="HEIGHT: 24px" align="left">Telefono Referente</TD>
								<TD style="HEIGHT: 24px"><CC1:S_TEXTBOX id="txtsTelefonoRef" tabindex="10" runat="server" dbparametername="pTelefonoReferente"
										dbdirection="Input" width="90%" dbsize="0" maxlength="20"></CC1:S_TEXTBOX></TD>
							</TR>
							<TR>
								<TD align="left">Data Inizio Contratto:</TD>
								<TD><UC1:CALENDARPICKER id="CalendarPicker1" runat="server"></UC1:CALENDARPICKER></TD>
								<TD align="left">Data Fine Contratto:</TD>
								<TD><UC1:CALENDARPICKER id="CalendarPicker2" runat="server"></UC1:CALENDARPICKER></TD>
							</TR>
							<TR>
								<TD align="left" colspan="3">
									<CC1:S_BUTTON id="btnsRicerca" runat="server" cssclass="btn" text="Ricerca" width="100px"></CC1:S_BUTTON>&nbsp;
									<ASP:BUTTON id="btnReset" runat="server" width="100px" text="Reset" cssclass="btn"></ASP:BUTTON></TD>
								<TD align="right"><A class=GuidaLink 
                  href="<%= HelpLink %>" target=_blank 
                  >Guida</A></TD>
							</TR>
						</TABLE>
						</COLLAPSE:DATAPANEL></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 3%" align="center"></TD>
				<TR>
					<TD style="HEIGHT: 72%" valign="top" align="center"><UC1:GRIDTITLE id="GridTitle1" runat="server"></UC1:GRIDTITLE><ASP:DATAGRID id="DataGridRicerca" runat="server" cssclass="DataGrid" bordercolor="Gray" borderwidth="1px"
							gridlines="Vertical" autogeneratecolumns="False" allowpaging="True">
							<ALTERNATINGITEMSTYLE cssclass="DataGridAlternatingItemStyle"></ALTERNATINGITEMSTYLE>
							<ITEMSTYLE cssclass="DataGridItemStyle"></ITEMSTYLE>
							<HEADERSTYLE cssclass="DataGridHeaderStyle"></HEADERSTYLE>
							<COLUMNS>
								<ASP:BOUNDCOLUMN visible="False" datafield="Id" headertext="ID"></ASP:BOUNDCOLUMN>
								<ASP:TEMPLATECOLUMN>
									<HEADERSTYLE width="3%"></HEADERSTYLE>
									<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
									<ITEMTEMPLATE>
										<asp:ImageButton id="Imagebutton3" Runat="server" CommandName="Dettaglio" ImageUrl="../images/Search16x16_bianca.jpg" CommandArgument='<%# "EditEnti.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"Id") + "&FunId=" + FunId + "&TipoOper=read"%>'>
										</ASP:IMAGEBUTTON>
									</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
								<ASP:TEMPLATECOLUMN>
									<HEADERSTYLE width="3%"></HEADERSTYLE>
									<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
									<ITEMTEMPLATE>
										<asp:ImageButton id="Imagebutton2" Runat="server" CommandName="Dettaglio" ImageUrl="../images/edit.gif" CommandArgument='<%# "EditEnti.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"Id") + "&FunId=" + FunId + "&TipoOper=write"%>'>
										</ASP:IMAGEBUTTON>
									</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
								<ASP:BOUNDCOLUMN datafield="descrizione" headertext="Ente">
									<HEADERSTYLE width="25%"></HEADERSTYLE>
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN datafield="Provincia" headertext="Provincia">
									<HEADERSTYLE width="12%"></HEADERSTYLE>
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN datafield="Comune" headertext="Comune">
									<HEADERSTYLE width="15%"></HEADERSTYLE>
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN datafield="Indirizzo" headertext="Indirizzo">
									<HEADERSTYLE width="20%"></HEADERSTYLE>
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN datafield="RagioneSociale" headertext="RagioneSociale">
									<HEADERSTYLE width="10%"></HEADERSTYLE>
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN datafield="Telefono" headertext="Telefono">
									<HEADERSTYLE width="10%"></HEADERSTYLE>
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN datafield="Referente" headertext="Referente">
									<HEADERSTYLE width="18%"></HEADERSTYLE>
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN datafield="DataInizioContratto" headertext="DataInizioContratto">
									<HEADERSTYLE width="10%"></HEADERSTYLE>
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN datafield="DataFineContratto" headertext="DataFineContratto">
									<HEADERSTYLE width="10%"></HEADERSTYLE>
								</ASP:BOUNDCOLUMN>
							</COLUMNS>
							<PAGERSTYLE mode="NumericPages"></PAGERSTYLE>
						</ASP:DATAGRID></TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE></FORM>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
