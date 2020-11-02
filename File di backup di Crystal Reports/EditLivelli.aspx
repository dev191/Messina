<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Page language="c#" Codebehind="EditLivelli.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditLivelli" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditLivelli</title>
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
											<TABLE id="tblSearch75" cellSpacing="1" cellPadding="2" border="0">
												<TR>
													<TD style="HEIGHT: 24px" align="left">Codice
														<asp:RequiredFieldValidator id="rfvCodice" runat="server" ErrorMessage="Inserire il codice" ControlToValidate="txtsCodice">*</asp:RequiredFieldValidator></TD>
													<TD style="HEIGHT: 24px">
														<cc1:S_TextBox id="txtsCodice" tabIndex="1" runat="server" Width="346px" MaxLength="15" DBDirection="Input"
															DBSize="15" DBParameterName="p_CodiceLivello" DBIndex="0"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 23px" align="left">Descrizione</TD>
													<TD style="HEIGHT: 23px">
														<cc1:S_TextBox id="txtsDescrizione" tabIndex="2" runat="server" Width="90%" DBDirection="Input"
															DBSize="50" DBParameterName="p_DescrizioneLivello" DBIndex="1" DBDataType="VarChar"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD align="left">Prezzo unitario</TD>
													<TD>
														<asp:TextBox id="txtsPrezzo" runat="server" MaxLength="5"></asp:TextBox>,
														<asp:TextBox id="txtsPrezzoDecimali" runat="server" MaxLength="2"></asp:TextBox>
														<asp:RangeValidator id="RVPrezzo2" runat="server" ErrorMessage="Il campo decimale puo indicare valori compresi fra 0  e 99"
															ControlToValidate="txtsPrezzoDecimali" MaximumValue="99" MinimumValue="0">*</asp:RangeValidator>
														<asp:CompareValidator id="CVPrezzo1" runat="server" ErrorMessage="Il campo può contenere solo valori numerici"
															ControlToValidate="txtsPrezzo" Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
														<asp:CompareValidator id="CVPrezzo2" runat="server" ErrorMessage="Il campo può contenere solo valori numerici"
															ControlToValidate="txtsPrezzoDecimali" Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator></TD>
												</TR>
											</TABLE>
										</asp:panel></TD>
								</TR>
								<tr>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="10" runat="server" Text="Salva" CssClass="btn"></cc1:s_button>&nbsp;
										<cc1:s_button id="btnsElimina" tabIndex="11" runat="server" Text="Elimina" CommandType="Delete"
											CausesValidation="False" CssClass="btn"></cc1:s_button>&nbsp;
										<asp:button id="btnAnnulla" tabIndex="12" runat="server" Text="Annulla" CausesValidation="False"
											CssClass="btn"></asp:button></TD>
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
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
