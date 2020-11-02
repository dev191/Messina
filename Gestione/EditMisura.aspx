<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Page language="c#" Codebehind="EditMisura.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditMisura" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>EditMateriale</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<script language="javascript">
	
	
	
		</script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR vAlign="top" align="center" height="95%">
					<TD>
						<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" align="center">
							<TBODY>
								<TR>
									<TD style="WIDTH: 5%; HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" Width="512px" CssClass="TitleOperazione"></asp:label><cc2:messagepanel id="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"></cc2:messagepanel></TD>
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
            <TABLE id=tblSearch75 cellSpacing=1 cellPadding=2 border=0>
              <TR>
                <TD style="WIDTH: 178px; HEIGHT: 24px" align=left>Descrizione 
                  Unità di Misura&nbsp; 
<asp:RequiredFieldValidator id=rfvDescMisura runat="server" ControlToValidate="txtDescMisura" ErrorMessage="Inserire la Descrizione!">*</asp:RequiredFieldValidator></TD>
                <TD style="HEIGHT: 23px">
<cc1:S_TextBox id=txtDescMisura tabIndex=1 runat="server" Width="90%" MaxLength="100" DBIndex="1" DBParameterName="p_descrizione" DBSize="100" DBDirection="Input" DBDataType="VarChar"></cc1:S_TextBox></TD></TR>
              <TR>
                <TD style="WIDTH: 178px; HEIGHT: 24px" align=left>Codice Unità 
                  di Misura&nbsp; 
<asp:RequiredFieldValidator id=rfvCodMisura runat="server" ControlToValidate="txtCodMisura" ErrorMessage="Inserire il Codice!">*</asp:RequiredFieldValidator></TD>
                <TD style="HEIGHT: 24px">
<cc1:S_TextBox id=txtCodMisura tabIndex=0 runat="server" MaxLength="10" DBIndex="0" DBParameterName="p_codice" DBSize="16" DBDirection="Input"></cc1:S_TextBox></TD></TR></TABLE>
										</asp:panel></TD>
								</TR>
								<tr>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="10" runat="server" CssClass="btn" Text="Salva"></cc1:s_button>&nbsp;
										<cc1:s_button id="btnsElimina" tabIndex="11" runat="server" CssClass="btn" Text="Elimina" CausesValidation="False"
											CommandType="Delete"></cc1:s_button>&nbsp;
										<asp:button id="btnAnnulla" tabIndex="12" runat="server" CssClass="btn" Text="Annulla" CausesValidation="False"></asp:button></TD>
								</tr>
								<TR>
									<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 1%" vAlign="top" align="left">
										<hr noShade SIZE="1">
									</TD>
								</TR>
				</TR>
				<TR>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblFirstAndLast" runat="server"></asp:label>&nbsp;
					</TD>
				</TR>
			</TABLE>
			<asp:validationsummary id="vlsEdit" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD></TR></TBODY></TABLE></form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
