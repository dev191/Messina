<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="Ditte.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.Ditte" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
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
										<TABLE id="tblSearch100" cellSpacing="0" cellPadding="2" border="0">
											<TR>
												<TD align="left" width="20%">Ditta</TD>
												<TD width="30%">
													<CC1:S_TEXTBOX id="txtsDescrizione" runat="server" dbsize="50" width="208px" dbdirection="Input"
														dbparametername="p_DESCRIZIONE"></CC1:S_TEXTBOX></TD>
												<TD align="left" width="20%">Indirizzo</TD>
												<TD width="30%">
													<CC1:S_TEXTBOX id="txtsIndirizzo" tabIndex="2" runat="server" dbsize="50" width="208px" dbparametername="p_INDIRIZZO"
														dbindex="2"></CC1:S_TEXTBOX></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 24px" align="left">Referente</TD>
												<TD style="HEIGHT: 24px">
													<CC1:S_TEXTBOX id="txtsReferente" tabIndex="1" runat="server" dbsize="50" width="208px" dbparametername="p_Referente"
														dbindex="1"></CC1:S_TEXTBOX></TD>
												<TD style="HEIGHT: 24px" align="left">Comune</TD>
												<TD style="HEIGHT: 24px">
													<CC1:S_TEXTBOX id="txtsComune" tabIndex="2" runat="server" dbsize="50" width="208px" dbparametername="p_COMUNE"
														dbindex="2"></CC1:S_TEXTBOX></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 23px" align="left">Email</TD>
												<TD style="HEIGHT: 23px">
													<CC1:S_TEXTBOX id="txtsEmail" tabIndex="3" runat="server" dbsize="255" width="208px" dbdirection="Input"
														dbparametername="p_EMAIL" dbindex="3"></CC1:S_TEXTBOX></TD>
												<TD style="HEIGHT: 23px" align="left">Telefono</TD>
												<TD style="HEIGHT: 23px">
													<CC1:S_TEXTBOX id="txtsTelefono" tabIndex="3" runat="server" dbsize="10" width="208px" dbdirection="Input"
														dbparametername="p_TELEFONO" dbindex="4"></CC1:S_TEXTBOX></TD>
											</TR>
											<TR>
												<TD align="left" colSpan="3">
													<CC1:S_BUTTON id="btnsRicerca" runat="server" cssclass="btn" text="Ricerca"></CC1:S_BUTTON>&nbsp;
													<cc1:S_Button id="BtnReset" tabIndex="4" runat="server" Text="Reset" CssClass="btn"></cc1:S_Button></TD>
												<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
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
											<ASP:BOUNDCOLUMN visible="False" datafield="id" headertext="ID"></ASP:BOUNDCOLUMN>
											<ASP:TEMPLATECOLUMN>
												<HEADERSTYLE width="3%"></HEADERSTYLE>
												<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
												<ITEMTEMPLATE>
													<asp:ImageButton id="Imagebutton3" Runat="server" CommandName="Dettaglio" ImageUrl="../images/Search16x16_bianca.jpg" CommandArgument='<%# "EditDitte.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId + "&TipoOper=read"%>'>
													</asp:ImageButton>
												</ITEMTEMPLATE>
											</ASP:TEMPLATECOLUMN>
											<ASP:TEMPLATECOLUMN>
												<HEADERSTYLE width="3%"></HEADERSTYLE>
												<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
												<ITEMTEMPLATE>
													<asp:ImageButton id="Imagebutton2" Runat="server" CommandName="Dettaglio" ImageUrl="../images/edit.gif" CommandArgument='<%# "EditDitte.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId + "&TipoOper=write"%>'>
													</asp:ImageButton>
												</ITEMTEMPLATE>
											</ASP:TEMPLATECOLUMN>
											<ASP:BOUNDCOLUMN datafield="descrizione" headertext="Ditta">
												<HEADERSTYLE width="25%"></HEADERSTYLE>
											</ASP:BOUNDCOLUMN>
											<ASP:BOUNDCOLUMN datafield="tipoditta" headertext="Tipo">
												<HEADERSTYLE width="12%"></HEADERSTYLE>
											</ASP:BOUNDCOLUMN>
											<ASP:BOUNDCOLUMN datafield="prcom" headertext="Comune">
												<HEADERSTYLE width="15%"></HEADERSTYLE>
											</ASP:BOUNDCOLUMN>
											<ASP:BOUNDCOLUMN datafield="Indirizzo" headertext="Indirizzo">
												<HEADERSTYLE width="20%"></HEADERSTYLE>
											</ASP:BOUNDCOLUMN>
											<ASP:BOUNDCOLUMN datafield="Email" headertext="Email">
												<HEADERSTYLE width="10%"></HEADERSTYLE>
											</ASP:BOUNDCOLUMN>
											<ASP:BOUNDCOLUMN datafield="Referente" headertext="Referente">
												<HEADERSTYLE width="18%"></HEADERSTYLE>
											</ASP:BOUNDCOLUMN>
										</COLUMNS>
										<PAGERSTYLE mode="NumericPages"></PAGERSTYLE>
									</ASP:DATAGRID></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
