<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Page language="c#" Codebehind="EditAddetti.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditAddetti" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditAddetti</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<script language="javascript">
	
	function Verifica(oggetto,max)
	{
	/*if (event.keyCode >=48	&& event.keyCode <= 57)
	{
		event.keyCode = 0;
	}*/
		if (oggetto.length>=max)
		{
				event.keyCode = 0;
		}
	}
	
		</script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; HEIGHT: 100%; TOP: 0px; LEFT: 0px"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR vAlign="top" align="center" height="95%">
					<TD>
						<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<TBODY>
								<TR>
									<TD style="WIDTH: 5%; HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" CssClass="TitleOperazione" Width="584px"></asp:label><cc2:messagepanel id="PanelMess" runat="server" ErrorIconUrl="~/Images/ico_critical.gif" MessageIconUrl="~/Images/ico_info.gif"></cc2:messagepanel></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 1%" vAlign="top" align="left">
										<hr noShade SIZE="1">
									</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center"></TD>
									<TD vAlign="top" align="left" width="100%"><asp:panel id="PanelEdit" runat="server" Width="100%">
											<TABLE id="tblSearch100" border="0" cellSpacing="1" cellPadding="2" width="100%">
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 24px" align="left">Cognome
														<asp:RequiredFieldValidator id="rfvcognome" runat="server" ErrorMessage="Inserire il cognome" ControlToValidate="txtscognome">*</asp:RequiredFieldValidator></TD>
													<TD>
														<cc1:S_TextBox id="txtscognome" tabIndex="1" runat="server" DBDirection="Input" DBSize="50" DBParameterName="p_cognome"
															DBIndex="0"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 23px" align="left">Nome&nbsp;
														<asp:RequiredFieldValidator id="rfvnome" runat="server" ErrorMessage="Inserire il nome " ControlToValidate="txtsnome">*</asp:RequiredFieldValidator></TD>
													<TD>
														<cc1:S_TextBox id="txtsnome" tabIndex="2" runat="server" DBDirection="Input" DBSize="50" DBParameterName="p_nome"
															DBIndex="1"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 28px" align="left">Data nascita</TD>
													<TD>
														<uc1:CalendarPicker id="CalendarPicker1" runat="server"></uc1:CalendarPicker></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 18px" align="left">Provincia di nascita</TD>
													<TD style="HEIGHT: 18px">
														<cc1:S_ComboBox id="cmbsprov_nasc" tabIndex="4" runat="server" DBDirection="Input" DBSize="10" DBParameterName="p_prov_nasc_id"
															DBIndex="3" AutoPostBack="True" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 21px" align="left">Comune di nascita</TD>
													<TD>
														<cc1:S_ComboBox id="cmbscom_nasc" tabIndex="5" runat="server" Width="90%" DBDirection="Input" DBSize="10"
															DBParameterName="p_com_nasc_id" DBIndex="4" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 17px" align="left">Provincia&nbsp; di residenza</TD>
													<TD>
														<cc1:S_ComboBox id="cmbsprov_res" tabIndex="6" runat="server" DBDirection="Input" DBSize="10" DBParameterName="p_prov_res_id"
															DBIndex="5" AutoPostBack="True" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 16px" align="left">Comune di residenza</TD>
													<TD style="HEIGHT: 16px">
														<cc1:S_ComboBox id="cmbscom_res" tabIndex="7" runat="server" Width="90%" DBDirection="Input" DBSize="10"
															DBParameterName="p_com_res_id" DBIndex="6" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px" align="left">Indirizzo</TD>
													<TD>
														<cc1:S_TextBox id="txtsindirizzo" tabIndex="8" runat="server" Width="90%" DBDirection="Input" DBSize="255"
															DBParameterName="p_indirizzo" DBIndex="7" DBDataType="VarChar"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 24px" align="left">Telefono</TD>
													<TD>
														<cc1:S_TextBox id="txtstelefono" tabIndex="9" runat="server" DBDirection="Input" DBSize="30" DBParameterName="p_telefono"
															DBIndex="8" DBDataType="VarChar"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 24px" align="left">Cellulare</TD>
													<TD>
														<cc1:S_TextBox id="txtscellulare" tabIndex="10" runat="server" DBDirection="Input" DBSize="30"
															DBParameterName="p_cellulare" DBIndex="9" DBDataType="VarChar"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 24px" align="left">Livello</TD>
													<TD>
														<cc1:S_ComboBox id="cmbsLivello" tabIndex="11" runat="server" DBDirection="Input" DBSize="10" DBParameterName="p_livello"
															DBIndex="13" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 6px" align="left">Ditta
														<asp:RangeValidator id="RVcmbsditta" runat="server" ErrorMessage="Selezionare la ditta" ControlToValidate="cmbsditta_id"
															MaximumValue="99999999999999999999999999" MinimumValue="0">*</asp:RangeValidator></TD>
													<TD style="HEIGHT: 6px">
														<cc1:S_ComboBox id="cmbsditta_id" tabIndex="11" runat="server" DBDirection="Input" DBSize="10" DBParameterName="p_ditta_id"
															DBIndex="10" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px" align="left">Priorità</TD>
													<TD>
														<cc1:S_ComboBox id="cmbspriorita" tabIndex="12" runat="server" DBDirection="Input" DBSize="10" DBParameterName="p_priorita"
															DBIndex="11" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 24px" align="left">Zona</TD>
													<TD>
														<cc1:S_TextBox id="txtszona" tabIndex="13" runat="server" Width="90%" DBDirection="Input" DBSize="30"
															DBParameterName="p_zona" DBIndex="12" DBDataType="VarChar"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 24px" align="left">Progetto</TD>
													<TD>
														<CC1:S_COMBOBOX id="CmbProgetto" tabIndex="8" runat="server" dbindex="14" dbparametername="p_progetto"
															dbsize="1" dbdirection="Input" dbdatatype="Integer" width="208px"></CC1:S_COMBOBOX></TD>
												</TR>
											</TABLE>
										</asp:panel></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 2.77%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 2.77%" vAlign="top" align="left"><TABLE class="tblFormInputDettaglio" id="tblSearch100Dettaglio" cellSpacing="1" cellPadding="1"
											width="100%" align="center" border="0">
											<TR>
												<TD style="HEIGHT: 14px" align="center" width="40%">Specializzazioni</TD>
												<TD style="HEIGHT: 14px" align="center"></TD>
												<TD style="HEIGHT: 14px" align="center">Specializzazioni Associate</TD>
											</TR>
											<TR>
												<TD align="center"><asp:listbox id="ListBoxLeft" tabIndex="7" runat="server" Width="280px" Rows="8"></asp:listbox></TD>
												<TD>
													<P align="center"><asp:button id="btnAssocia" tabIndex="14" runat="server" Width="110px" Text="Aggiungi >>" CausesValidation="False"
															CssClass="btn"></asp:button></P>
													<P align="center"><asp:button id="btnElimina" tabIndex="15" runat="server" Width="110px" Text="<< Elimina" CausesValidation="False"
															CssClass="btn"></asp:button></P>
												</TD>
												<TD align="center"><asp:listbox id="ListBoxRight" tabIndex="10" runat="server" Width="272px" Rows="8"></asp:listbox></TD>
											</TR>
											<TR>
												<TD></TD>
												<TD></TD>
												<TD width="40%"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<tr>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="16" runat="server" Text="Salva" CssClass="btn"></cc1:s_button>&nbsp;
										<cc1:s_button id="btnsElimina" tabIndex="17" runat="server" Text="Elimina" CausesValidation="False"
											CommandType="Delete" CssClass="btn"></cc1:s_button>&nbsp;
										<asp:button id="btnAnnulla" tabIndex="18" runat="server" Text="Annulla" CausesValidation="False"
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
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
