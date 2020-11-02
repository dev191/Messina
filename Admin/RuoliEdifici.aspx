<%@ Page language="c#" Codebehind="RuoliEdifici.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Admin.RuoliEdifici" %>
<%@ Register TagPrefix="MessagePanel1" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
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
								<TD style="HEIGHT: 4.68%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" CssClass="TitleOperazione"></asp:label><MESSPANEL:MESSAGEPANEL id="PanelMess" runat="server" Width="136px" ErrorIconUrl="~/Images/ico_critical.gif"
										MessageIconUrl="~/Images/ico_info.gif"></MESSPANEL:MESSAGEPANEL></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 0.96%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 0.96%" vAlign="top" align="left"><hr noShade SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 119px" vAlign="top" align="center"></TD>
								<TD style="HEIGHT: 119px" vAlign="top" align="left"><asp:panel id="PanelEdit" runat="server">
            <TABLE>
              <TR>
                <TD style="WIDTH: 318px" align=left>Ruolo: 
<asp:Label id=LblRuolo runat="server" Width="256px" Font-Bold="True"></asp:Label></TD>
                <TD align=center>&nbsp; 
<asp:Label id=LblTitolo runat="server" Font-Bold="True" BorderColor="White" BackColor="White" ForeColor="Red">Ricerca Edificio</asp:Label></TD></TR></TABLE>
            <TABLE id=tblSearch100 cellSpacing=1 cellPadding=2 border=0>
              <TR>
                <TD style="WIDTH: 78px; HEIGHT: 23px" vAlign=middle 
                  align=right>Codice</TD>
                <TD style="WIDTH: 235px; HEIGHT: 23px" width=235 height=23>
<cc1:s_textbox id=txtsCodice tabIndex=2 runat="server" DBDirection="Input" DBParameterName="p_Bl_Id" DBIndex="0" width="200px" DBSize="255"></cc1:s_textbox></TD>
                <TD style="WIDTH: 231px; HEIGHT: 23px" vAlign=middle 
                  align=right>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Descrizione</TD>
                <TD style="HEIGHT: 23px" width="30%" height=23>
<cc1:s_textbox id=txtsCampus tabIndex=2 runat="server" DBDirection="Input" DBParameterName="p_Campus" DBIndex="1" width="208px" DBSize="255"></cc1:s_textbox></TD></TR>
              <TR>
                <TD style="WIDTH: 78px; HEIGHT: 18px" vAlign=middle 
                  align=right>Provincia</TD>
                <TD style="WIDTH: 235px; HEIGHT: 18px">
<cc1:S_ComboBox id=cmbsProvincia runat="server" Width="200px" DBDirection="Input" DBParameterName="p_PROVINCIA" DBIndex="2" DBDataType="Integer" AutoPostBack="True"></cc1:S_ComboBox></TD>
                <TD style="WIDTH: 231px; HEIGHT: 18px" vAlign=middle 
                  align=right>Comune</TD>
                <TD style="HEIGHT: 18px">
<cc1:S_ComboBox id=cmbsComune runat="server" Width="208px" DBDirection="Input" DBParameterName="p_COMUNE" DBIndex="3" DBDataType="Integer"></cc1:S_ComboBox></TD></TR>
              <TR>
                <TD style="WIDTH: 78px" align=right>Servizio</TD>
                <TD>
<cc1:S_ComboBox id=cmbsServizi runat="server" Width="200px" DBDirection="Input" DBParameterName="p_Servizio" DBIndex="4" DBDataType="Integer"></cc1:S_ComboBox></TD>
                <TD style="WIDTH: 231px" align=right>
<asp:Button id=BtnFiltra runat="server" CssClass="btn" Width="152px" Text="Ricerca"></asp:Button>&nbsp; 
                  Ditta</TD>
                <TD>
<cc1:S_ComboBox id=cmbsDitta runat="server" Width="207px" DBDirection="Input" DBParameterName="p_DITTA" DBIndex="5" DBDataType="Integer"></cc1:S_ComboBox></TD></TR></TABLE>
									</asp:panel></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 2.77%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 2.77%" vAlign="top" align="left"><TABLE class="tblFormInputDettaglio" id="tblSearch100Dettaglio" cellSpacing="1" cellPadding="1"
										width="100%" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 14px" align="center" width="40%">Edifici Filtrati&nbsp; (
												<asp:label id="LblEdifici" runat="server" Width="13px" Font-Bold="True" BackColor="White" BorderColor="White">0</asp:label>)</TD>
											<TD style="HEIGHT: 14px" align="center"></TD>
											<TD style="HEIGHT: 14px" align="center">Edifici Associati (
												<asp:label id="LblEdificiAssociati" runat="server" Width="13px" Font-Bold="True" BackColor="White"
													BorderColor="White">0</asp:label>)</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 296px" align="center">
												<div id="lista" style="OVERFLOW: scroll; WIDTH: 274px; HEIGHT: 267px"><asp:checkboxlist id="ListBoxLeftF" runat="server" Width="256px" Height="8px"></asp:checkboxlist></div>
											</TD>
											<TD style="HEIGHT: 296px">
												<P align="center"><asp:button id="btnAssociaF" tabIndex="8" runat="server" Width="110px" Text="Aggiungi >>" CausesValidation="False" CssClass="btn"></asp:button></P>
												<P align="center"><asp:button id="btnEliminaF" tabIndex="9" runat="server" Width="110px" Text="<< Elimina" CausesValidation="False" CssClass="btn"></asp:button></P>
											</TD>
											<TD style="HEIGHT: 296px" align="center"><asp:listbox id="ListBoxRightF" tabIndex="10" runat="server" Width="272px" Height="274px" Rows="8"
													SelectionMode="Multiple"></asp:listbox></TD>
										</TR>
										<TR>
											<TD><asp:checkbox id="ChkSelezionaLeft" runat="server" AutoPostBack="True" Text="Seleziona Tutti"
													Visible="False"></asp:checkbox></TD>
											<TD></TD>
											<TD width="40%">&nbsp;&nbsp;
												<asp:checkbox id="ChkSelezionaTuttiRigth" runat="server" AutoPostBack="True" Text="Seleziona Tutti"
													Visible="False"></asp:checkbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 4.53%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 4.53%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="11" runat="server" Text="Salva" CssClass="btn"></cc1:s_button>&nbsp;&nbsp;&nbsp;
									<asp:button id="btnAnnulla" tabIndex="13" runat="server" Text="Annulla" CausesValidation="False" CssClass="btn"></asp:button>&nbsp;&nbsp;&nbsp;
									<asp:button id="btnAssociaServizi" tabIndex="13" runat="server" Text="Associazione Edifici  Servizi"
										CausesValidation="False" CssClass="btn"></asp:button></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 1%" vAlign="top" align="left">
									<hr noShade SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblFirstAndLast" runat="server"></asp:label>&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
