<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Page language="c#" Codebehind="Buildings.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.Buildings" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>Ditte</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
	function SoloNumeri()
	{	
		if (event.keyCode < 48	|| event.keyCode > 57){
			event.keyCode = 0;
		}	
	}	
		</SCRIPT>
</HEAD>
	<BODY onbeforeunload="parent.left.valorizza()" ms_positioning="GridLayout">
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
            <TABLE id=tblSearch100 cellSpacing=0 cellPadding=2 border=0>
              <TR>
                <TD style="HEIGHT: 24px" align=right width="20%">Codice 
                  Edificio </TD>
                <TD style="WIDTH: 219px; HEIGHT: 24px" width=219>
<CC1:S_TEXTBOX id=txtsBL_ID tabIndex=1 runat="server" dbparametername="p_BL_ID" dbdirection="Input" dbsize="8" dbindex="0" maxlength="6" width="208px"></CC1:S_TEXTBOX></TD>
                <TD style="HEIGHT: 24px" align=right width="20%">Nome</TD>
                <TD style="HEIGHT: 24px" width="30%">
<CC1:S_TEXTBOX id=txtsName tabIndex=2 runat="server" dbparametername="p_NAME" dbdirection="Input" dbsize="50" dbindex="1" maxlength="50" width="208px"></CC1:S_TEXTBOX></TD></TR>
              <TR>
                <TD style="HEIGHT: 24px" align=right>Indirizzo</TD>
                <TD style="WIDTH: 219px; HEIGHT: 24px">
<CC1:S_TEXTBOX id=txtsIndirizzo tabIndex=3 runat="server" dbparametername="p_INDIRIZZO" dbsize="50" dbindex="2" maxlength="50" width="208px"></CC1:S_TEXTBOX></TD>
                <TD style="HEIGHT: 24px" align=right>Ditta Referente</TD>
                <TD style="HEIGHT: 24px">
<CC1:S_TEXTBOX id=txtsReferente tabIndex=4 runat="server" dbparametername="p_REFERENTE" dbsize="50" dbindex="3" width="208px"></CC1:S_TEXTBOX></TD></TR>
              <TR>
                <TD style="HEIGHT: 23px" align=right>Comune</TD>
                <TD style="WIDTH: 219px; HEIGHT: 23px">
<CC1:S_TEXTBOX id=txtsComune tabIndex=5 runat="server" dbparametername="p_COMUNE" dbsize="50" dbindex="4" width="208px"></CC1:S_TEXTBOX></TD>
                <TD style="HEIGHT: 23px" align=right>Progetto</TD>
                <TD style="HEIGHT: 23px">
<CC1:S_COMBOBOX id=CmbProgetto tabIndex=8 runat="server" dbparametername="p_progetto" dbdirection="Input" dbsize="1" dbindex="5" width="208px" dbdatatype="Integer"></CC1:S_COMBOBOX></TD></TR>
              <TR>
                <TD style="HEIGHT: 23px" align=right></TD>
                <TD style="WIDTH: 219px; HEIGHT: 23px"></TD>
                <TD style="HEIGHT: 23px" align=right></TD>
                <TD style="HEIGHT: 23px">
<asp:Button id=Button1 runat="server" Text="Calcola tutte le superfici"></asp:Button></TD></TR>
              <TR></TR>
              <TR>
                <TD colSpan=2>
<CC1:S_BUTTON id=btnsRicerca tabIndex=6 runat="server" cssclass="btn" width="125px" text="Ricerca"></CC1:S_BUTTON>&nbsp; 
<ASP:BUTTON id=btnEsporta runat="server" cssclass="btn" width="125px" text="Esporta Dati In Excel"></ASP:BUTTON>&nbsp; 
<CC1:S_BUTTON id=BtnReset tabIndex=4 runat="server" cssclass="btn" width="60px" text="Reset"></CC1:S_BUTTON></TD>
                <TD></TD>
                <TD align=right><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD></TR>
              <TR></TR></TABLE>
									</COLLAPSE:DATAPANEL></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 3%" align="center">
									<asp:Label id="lbMessage" runat="server"></asp:Label></TD>
							<TR>
								<TD style="HEIGHT: 72%" valign="top" align="center"><UC1:GRIDTITLE id="GridTitle1" runat="server"></UC1:GRIDTITLE><ASP:DATAGRID id="DataGridRicerca" runat="server" cssclass="DataGrid" allowpaging="True" bordercolor="Gray"
										borderwidth="1px" gridlines="Vertical" autogeneratecolumns="False">
										<ALTERNATINGITEMSTYLE cssclass="DataGridAlternatingItemStyle"></ALTERNATINGITEMSTYLE>
										<ITEMSTYLE cssclass="DataGridItemStyle"></ITEMSTYLE>
										<HEADERSTYLE cssclass="DataGridHeaderStyle"></HEADERSTYLE>
										<COLUMNS>
											<ASP:BOUNDCOLUMN visible="False" datafield="ID" headertext="ID"></ASP:BOUNDCOLUMN>
											<ASP:TEMPLATECOLUMN>
												<HEADERSTYLE width="3%"></HEADERSTYLE>
												<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
												<ITEMTEMPLATE>
													<asp:ImageButton id="ImgBtnDettaglio" CommandArgument='<%# "EditBuilding.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&amp;FunId=" + FunId + "&amp;TipoOper=read" %>' CommandName="Dettaglio" Runat="server" ImageUrl="../images/Search16x16_bianca.jpg">
													</asp:ImageButton>
												</ITEMTEMPLATE>
											</ASP:TEMPLATECOLUMN>
											<ASP:TEMPLATECOLUMN>
												<HEADERSTYLE width="3%"></HEADERSTYLE>
												<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
												<ITEMTEMPLATE>
													<asp:ImageButton id="ImgBtnEdit" CommandArgument='<%# "EditBuilding.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&amp;FunId=" + FunId + "&amp;TipoOper=write" %>' CommandName="Dettaglio" Runat="server" ImageUrl="../images/edit.gif">
													</asp:ImageButton>
												</ITEMTEMPLATE>
											</ASP:TEMPLATECOLUMN>
											<ASP:BOUNDCOLUMN datafield="bl_id" headertext="Codice">
												<HEADERSTYLE width="10%"></HEADERSTYLE>
											</ASP:BOUNDCOLUMN>
											<ASP:BOUNDCOLUMN datafield="name" headertext="Nome">
												<HEADERSTYLE width="27%"></HEADERSTYLE>
											</ASP:BOUNDCOLUMN>
											<ASP:BOUNDCOLUMN datafield="Indirizzo" headertext="Indirizzo">
												<HEADERSTYLE width="23%"></HEADERSTYLE>
											</ASP:BOUNDCOLUMN>
											<ASP:BOUNDCOLUMN datafield="Referente" headertext="Ditta Referente">
												<HEADERSTYLE width="15%"></HEADERSTYLE>
											</ASP:BOUNDCOLUMN>
											<ASP:BOUNDCOLUMN datafield="prcom" headertext="Comune">
												<HEADERSTYLE width="15%"></HEADERSTYLE>
											</ASP:BOUNDCOLUMN>
											<ASP:BOUNDCOLUMN datafield="progetto" headertext="Progetto">
												<HEADERSTYLE width="15%"></HEADERSTYLE>
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
		<SCRIPT language="javascript">parent.left.calcola();</SCRIPT>
	</BODY>
</HTML>
