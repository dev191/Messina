<%@ Page language="c#" Codebehind="EditFunzioni.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Admin.EditFunzioni" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditFunzioni</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" title="Gestione Funzioni" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" height="95%">
						<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" align="center">
							<TR>
								<TD style="WIDTH: 5%; HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" CssClass="TitleOperazione"></asp:label>
									<MessPanel:MESSAGEPANEL id="PanelMess" runat="server" ErrorIconUrl="~/Images/ico_critical.gif" MessageIconUrl="~/Images/ico_info.gif"></MessPanel:MESSAGEPANEL></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 1%" vAlign="top" align="left">
									<hr noShade SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center"></TD>
								<TD vAlign="top" align="left"><asp:panel id="PanelEdit" runat="server">
										<TABLE id="tblSearch75" cellSpacing="1" cellPadding="2" border="0">
											<TR>
												<TD align="center" colSpan="4"></TD>
											</TR>
											<TR>
												<TD align="right" width="20%">Codice</TD>
												<TD width="30%">
													<cc1:s_textbox id="txtsCodice" runat="server" DBSize="10" width="75%" DBDirection="Input" DBParameterName="p_Codice"
														DBIndex="1" MaxLength="10"></cc1:s_textbox></TD>
												<TD align="right" width="20%"></TD>
												<TD width="30%"></TD>
											</TR>
											<TR>
												<TD align="right">
													<asp:RequiredFieldValidator id="rfvDescrizione" runat="server" ErrorMessage="Inserire la descrizione Funzione"
														ControlToValidate="txtsDescrizione">*</asp:RequiredFieldValidator>Descrizione</TD>
												<TD colSpan="3">
													<cc1:s_textbox id="txtsDescrizione" tabIndex="1" runat="server" DBSize="255" width="95%" DBParameterName="p_Descrizione"
														DBIndex="0" MaxLength="255"></cc1:s_textbox></TD>
											</TR>
											<TR>
												<TD align="right">Link File</TD>
												<TD colSpan="3">
													<cc1:s_textbox id="txtsLink" tabIndex="2" runat="server" DBSize="255" width="95%" DBDirection="InputOutput"
														DBParameterName="p_Link" DBIndex="2" MaxLength="255"></cc1:s_textbox></TD>
											</TR>
											<TR>
												<TD align="right">Link File Help&nbsp;</TD>
												<TD colSpan="3">
													<cc1:s_textbox id="txtsLinkHelp" tabIndex="3" runat="server" DBSize="255" width="95%" DBParameterName="p_Link_Help"
														DBIndex="3" MaxLength="255"></cc1:s_textbox></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="4">&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
										</TABLE>
									</asp:panel></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left">
									<cc1:s_button id="btnsSalva" runat="server" Text="Salva" tabIndex="4" CssClass="btn"></cc1:s_button>&nbsp;
									<cc1:s_button id="btnsElimina" runat="server" Text="Elimina" CommandType="Delete" CausesValidation="False"
										tabIndex="5" CssClass="btn"></cc1:s_button>&nbsp;
									<asp:button id="btnAnnulla" runat="server" Text="Annulla" CausesValidation="False" tabIndex="6"
										CssClass="btn"></asp:button></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 1%" vAlign="top" align="left">
									<hr noShade SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblFirstAndLast" runat="server"></asp:label>&nbsp;
								</TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="vlsEdit" runat="server" ShowMessageBox="True" DisplayMode="List" ShowSummary="False"></asp:validationsummary>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
