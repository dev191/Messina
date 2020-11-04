<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Page language="c#" Codebehind="EditServizi.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditServizi" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Edit Servizi</title>
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
			<TABLE id="TableMain" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; HEIGHT: 100%; TOP: 0px; LEFT: 0px"
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
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" CssClass="TitleOperazione" Width="544px"></asp:label><cc2:messagepanel id="PanelMess" runat="server" ErrorIconUrl="~/Images/ico_critical.gif" MessageIconUrl="~/Images/ico_info.gif"></cc2:messagepanel></TD>
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
											<TABLE id="tblSearch75" border="0" cellSpacing="1" cellPadding="2">
												<TR>
													<TD style="HEIGHT: 20px" align="left">Settore
														<asp:RequiredFieldValidator id="rfvSettore" runat="server" InitialValue="-1" ErrorMessage="Scegliere settore"
															ControlToValidate="cmbsSettore">*</asp:RequiredFieldValidator></TD>
													<TD style="HEIGHT: 20px">
														<cc1:S_ComboBox id="cmbsSettore" runat="server" DBDataType="Integer" DBDirection="Input" DBParameterName="p_SETTORE"
															DBIndex="3"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 24px" align="left">Codice
														<asp:RequiredFieldValidator id="rfvCodice" runat="server" ErrorMessage="Inserire il codice" ControlToValidate="txtsCodice">*</asp:RequiredFieldValidator></TD>
													<TD style="HEIGHT: 24px">
														<cc1:S_TextBox id="txtsCodice" tabIndex="1" runat="server" Width="346px" DBDirection="Input" DBParameterName="p_CODICE"
															DBIndex="2" MaxLength="5" DBSize="5"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 23px" align="left">Descrizione</TD>
													<TD style="HEIGHT: 23px">
														<cc1:S_TextBox id="txtsDescrizione" tabIndex="2" runat="server" Width="346px" DBDataType="VarChar"
															DBDirection="Input" DBParameterName="p_DESCRIZIONE" DBIndex="0" MaxLength="255" DBSize="255"></cc1:S_TextBox>
														<asp:RequiredFieldValidator id="rfvPercentuale" runat="server" ErrorMessage="Inserire la descrizione" ControlToValidate="txtsDescrizione">*</asp:RequiredFieldValidator></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 23px" align="left">Note:</TD>
													<TD style="HEIGHT: 23px">
														<cc1:S_TextBox id="txtsNote" tabIndex="2" runat="server" Width="346px" DBDataType="VarChar" DBDirection="Input"
															DBParameterName="p_NOTE" DBIndex="1" MaxLength="500" DBSize="500" TextMode="MultiLine"></cc1:S_TextBox></TD>
												</TR>
											</TABLE>
										</asp:panel></TD>
								</TR>
								<tr>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="10" runat="server" CssClass="btn" Text="Salva"></cc1:s_button>&nbsp;
										<cc1:s_button id="btnsElimina" tabIndex="11" runat="server" CssClass="btn" Text="Elimina" CommandType="Delete"
											CausesValidation="False"></cc1:s_button>&nbsp;
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
			<asp:validationsummary id="vlsEdit" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD></TR></TBODY></TABLE></form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
