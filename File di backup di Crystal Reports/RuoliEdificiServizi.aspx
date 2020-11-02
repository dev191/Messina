<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page language="c#" Codebehind="RuoliEdificiServizi.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Admin.RuoliEdificiServizi" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="MessagePanel1" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>EditUtenti</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../Js/CommonScript.js"></SCRIPT>
</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" height="95%">
						<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" align="center">
							<TR>
								<TD style="WIDTH: 5%; HEIGHT: 4.68%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 4.68%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" CssClass="TitleOperazione"></asp:label><MESSPANEL:MESSAGEPANEL id="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"
										Width="136px"></MESSPANEL:MESSAGEPANEL></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 0.56%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 0.56%" vAlign="top" align="left"><hr noShade SIZE="1">
									<asp:label id="LblRuolo" runat="server" Width="286px" Font-Bold="True"></asp:label>&nbsp;&nbsp;
									<asp:checkbox id="ChkSelezionaLeft" runat="server" Width="464px" Font-Bold="True" AutoPostBack="True"
										Text="Seleziona Tutti i Servizi" Visible="False"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 190px" vAlign="top" align="center"></TD>
								<TD style="HEIGHT: 190px" vAlign="top" align="left"><asp:panel id="PanelEdit" runat="server" Height="493px">
            <TABLE id=tblSearch100 style="WIDTH: 100%; HEIGHT: 446px" 
            cellSpacing=1 cellPadding=2 border=1>
              <TR>
                <TD style="WIDTH: 55px; HEIGHT: 11px">Codice</TD>
                <TD style="WIDTH: 222px; HEIGHT: 11px" width=222 height=11>
<cc1:s_textbox id=txtsCodice tabIndex=2 runat="server" DBDirection="Input" DBParameterName="p_Bl_Id" DBIndex="0" width="208px" DBSize="255"></cc1:s_textbox></TD>
                <TD height=200 rowSpan=11>
                  <TABLE style="WIDTH: 500px; HEIGHT: 435px">
                    <TR>
                      <TD>Edifici&nbsp;Selezionati&nbsp; ( 
<asp:label id=LblEdifici runat="server" Width="13px" Font-Bold="True" BorderColor="White" BackColor="White">0</asp:label>) 
<iewc:treeview id=TreeCtrl runat="server" Width="500px"></iewc:treeview></TD></TR></TABLE></TD></TR>
              <TR>
                <TD style="WIDTH: 55px; HEIGHT: 11px">Descrizione</TD>
                <TD style="WIDTH: 222px; HEIGHT: 11px">
<cc1:s_textbox id=txtsCampus tabIndex=2 runat="server" DBDirection="Input" DBParameterName="p_Campus" DBIndex="1" width="208px" DBSize="255"></cc1:s_textbox></TD></TR>
              <TR>
                <TD style="WIDTH: 55px; HEIGHT: 14px">Provincia</TD>
                <TD style="WIDTH: 222px; HEIGHT: 14px">
<cc1:s_combobox id=cmbsProvincia runat="server" Width="208px" AutoPostBack="True" DBDirection="Input" DBParameterName="p_PROVINCIA" DBIndex="2" DBDataType="Integer"></cc1:s_combobox></TD></TR>
              <TR>
                <TD style="WIDTH: 55px; HEIGHT: 13px">Comune</TD>
                <TD style="WIDTH: 222px; HEIGHT: 13px">
<cc1:s_combobox id=cmbsComune runat="server" Width="208px" DBDirection="Input" DBParameterName="p_COMUNE" DBIndex="3" DBDataType="Integer"></cc1:s_combobox></TD></TR>
              <TR>
                <TD style="WIDTH: 55px; HEIGHT: 12px">Servizio</TD>
                <TD style="WIDTH: 222px; HEIGHT: 12px">
<cc1:s_combobox id=cmbsServizi runat="server" Width="208px" DBDirection="Input" DBParameterName="p_Servizio" DBIndex="4" DBDataType="Integer"></cc1:s_combobox></TD></TR>
              <TR>
                <TD style="WIDTH: 55px; HEIGHT: 2px">Ditta</TD>
                <TD style="WIDTH: 222px; HEIGHT: 2px">
<cc1:s_combobox id=cmbsDitta runat="server" Width="208" DBDirection="Input" DBParameterName="p_DITTA" DBIndex="5" DBDataType="Integer"></cc1:s_combobox></TD></TR>
              <TR>
                <TD style="HEIGHT: 12px" align=center colSpan=2>
<asp:RadioButtonList id=OptFiltro runat="server" Width="270px" Height="6px" RepeatDirection="Horizontal">
														<asp:ListItem Value="0" Selected="True">Tutti</asp:ListItem>
														<asp:ListItem Value="1">Associato</asp:ListItem>
														<asp:ListItem Value="2">Da Associare</asp:ListItem>
													</asp:RadioButtonList></TD>
              <TR>
                <TD style="WIDTH: 296px; HEIGHT: 7px" colSpan=2>
<asp:button id=BtnFiltra runat="server" CssClass="btn" Width="272px" Text="Ricerca"></asp:button>&nbsp; 
                </TD></TR>
              <TR>
                <TD style="WIDTH: 296px; HEIGHT: 14px" colSpan=2>
<cc1:s_button id=btnsSalva tabIndex=11 runat="server" CssClass="btn" Width="272px" Text="Salva"></cc1:s_button></TD></TR>
              <TR>
                <TD style="WIDTH: 296px" colSpan=2>
<asp:button id=btnAnnulla tabIndex=13 runat="server" CssClass="btn" Width="272px" Text="Annulla" CausesValidation="False"></asp:button>&nbsp;&nbsp;&nbsp; 
                </TD></TR></TABLE>
									</asp:panel></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
