<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="EditPmpFrequenza.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditPmpFrequenza" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditPmpFrequenza</title>
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
	if (event.keyCode < 48	|| event.keyCode > 57)
	{
		event.keyCode = 0;
	}
	
	
		if (oggetto.length>=max)
		{
				event.keyCode = 0;
		}
	}
	function SetVisible()
	{
		var ct=document.getElementById('cmbsTipoCadenza');
		if(ct.value=="0")//periodico
		{
			document.getElementById('r1').style.display="block";
			document.getElementById('r2').style.display="block";
			document.getElementById('r3').style.display="block";
			document.getElementById('r4').style.display="none";  
		}
		else
		{
			document.getElementById('r1').style.display="none";
			document.getElementById('r2').style.display="none";
			document.getElementById('r3').style.display="none";
			document.getElementById('r4').style.display="block"; 
		}
	}
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
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" CssClass="TitleOperazione" Width="552px"></asp:label><cc2:messagepanel id="PanelMess" runat="server" ErrorIconUrl="~/Images/ico_critical.gif" MessageIconUrl="~/Images/ico_info.gif"></cc2:messagepanel></TD>
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
												<TBODY>
													<TR>
														<TD align="left">Frequenza
															<asp:requiredfieldvalidator id="rfvfrequenza" runat="server" ErrorMessage="Inserire la frequenza" ControlToValidate="txtsfrequenza">*</asp:requiredfieldvalidator></TD>
														<TD><cc1:s_textbox id="txtsfrequenza" tabIndex="1" runat="server" DBDirection="Input" DBSize="40" DBParameterName="p_frequenza"
																DBIndex="0"></cc1:s_textbox></TD>
													</TR>
													<TR>
														<TD align="left">Descrizione
															<asp:requiredfieldvalidator id="rvffrequenza_des" runat="server" ErrorMessage="Inserire la descrizione" ControlToValidate="txtsfrequenza_des">*</asp:requiredfieldvalidator></TD>
														<TD><cc1:s_textbox id="txtsfrequenza_des" tabIndex="2" runat="server" DBDirection="Input" DBSize="50"
																DBParameterName="p_frequenza_des" DBIndex="1" width="90%"></cc1:s_textbox></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 15px" align="left">Tipo Cadenza</TD>
														<TD style="HEIGHT: 15px"><cc1:s_combobox id="cmbsTipoCadenza" runat="server" DBDirection="Input" DBSize="2" DBParameterName="P_mese_std"
																DBIndex="2" DBDataType="Integer">
																<asp:ListItem Value="0">Periodico</asp:ListItem>
																<asp:ListItem Value="1">Fisso</asp:ListItem>
															</cc1:s_combobox></TD>
													</TR>
													<TR runat="server" id="r1">
														<TD style="HEIGHT: 14px" align="left">Giorni</TD>
														<TD style="HEIGHT: 14px"><cc1:s_combobox id="cmbsGiorni" runat="server" DBDirection="Input" DBSize="6" DBParameterName="p_n_giorni"
																DBIndex="3" DBDataType="Integer">
																<asp:ListItem Value="0">0</asp:ListItem>
																<asp:ListItem Value="1">1</asp:ListItem>
																<asp:ListItem Value="2">2</asp:ListItem>
																<asp:ListItem Value="3">3</asp:ListItem>
																<asp:ListItem Value="4">4</asp:ListItem>
																<asp:ListItem Value="5">5</asp:ListItem>
																<asp:ListItem Value="6">6</asp:ListItem>
																<asp:ListItem Value="7">7</asp:ListItem>
																<asp:ListItem Value="8">8</asp:ListItem>
																<asp:ListItem Value="9">9</asp:ListItem>
																<asp:ListItem Value="10">10</asp:ListItem>
																<asp:ListItem Value="11">11</asp:ListItem>
																<asp:ListItem Value="12">12</asp:ListItem>
																<asp:ListItem Value="13">13</asp:ListItem>
																<asp:ListItem Value="14">14</asp:ListItem>
																<asp:ListItem Value="15">15</asp:ListItem>
																<asp:ListItem Value="16">16</asp:ListItem>
																<asp:ListItem Value="17">17</asp:ListItem>
																<asp:ListItem Value="18">18</asp:ListItem>
																<asp:ListItem Value="19">19</asp:ListItem>
																<asp:ListItem Value="20">20</asp:ListItem>
																<asp:ListItem Value="21">21</asp:ListItem>
																<asp:ListItem Value="22">22</asp:ListItem>
																<asp:ListItem Value="23">23</asp:ListItem>
																<asp:ListItem Value="24">24</asp:ListItem>
																<asp:ListItem Value="25">25</asp:ListItem>
																<asp:ListItem Value="26">26</asp:ListItem>
																<asp:ListItem Value="27">27</asp:ListItem>
																<asp:ListItem Value="28">28</asp:ListItem>
																<asp:ListItem Value="29">29</asp:ListItem>
																<asp:ListItem Value="30">30</asp:ListItem>
																<asp:ListItem Value="31">31</asp:ListItem>
															</cc1:s_combobox></TD>
													</TR>
													<TR runat="server" id="r2">
														<TD align="left">Mesi</TD>
														<TD><cc1:s_combobox id="cmbsMesi" runat="server" DBDirection="Input" DBParameterName="p_n_mesi" DBIndex="4"
																DBDataType="Integer">
																<asp:ListItem Value="0">0</asp:ListItem>
																<asp:ListItem Value="1">1</asp:ListItem>
																<asp:ListItem Value="2">2</asp:ListItem>
																<asp:ListItem Value="3">3</asp:ListItem>
																<asp:ListItem Value="4">4</asp:ListItem>
																<asp:ListItem Value="5">5</asp:ListItem>
																<asp:ListItem Value="6">6</asp:ListItem>
																<asp:ListItem Value="7">7</asp:ListItem>
																<asp:ListItem Value="8">8</asp:ListItem>
																<asp:ListItem Value="9">9</asp:ListItem>
																<asp:ListItem Value="10">10</asp:ListItem>
																<asp:ListItem Value="11">11</asp:ListItem>
																<asp:ListItem Value="12">12</asp:ListItem>
															</cc1:s_combobox></TD>
													</TR>
													<TR runat="server" id="r3">
														<TD align="left">Anni</TD>
														<TD><cc1:s_combobox id="cmbsAnni" runat="server" DBDirection="Input" DBSize="10" DBParameterName="p_n_anni"
																DBIndex="5" DBDataType="Integer">
																<asp:ListItem Value="0">0</asp:ListItem>
																<asp:ListItem Value="1">1</asp:ListItem>
																<asp:ListItem Value="2">2</asp:ListItem>
																<asp:ListItem Value="3">3</asp:ListItem>
																<asp:ListItem Value="4">4</asp:ListItem>
																<asp:ListItem Value="5">5</asp:ListItem>
																<asp:ListItem Value="6">6</asp:ListItem>
																<asp:ListItem Value="7">7</asp:ListItem>
																<asp:ListItem Value="8">8</asp:ListItem>
																<asp:ListItem Value="9">9</asp:ListItem>
																<asp:ListItem Value="10">10</asp:ListItem>
															</cc1:s_combobox></TD>
													</TR>
													<TR>
														<TD colSpan="2" runat="server" id="r4"><asp:repeater id="rpserv" Runat="server">
																<HeaderTemplate>
																	<table>
																</HeaderTemplate>
																<ItemTemplate>
																	<tr>
																		<td>Servizio:</td>
																		<td><%# DataBinder.Eval(Container.DataItem,"descrizione")%>
																			<input type="hidden" id="idser" runat="server" value='<%# DataBinder.Eval(Container.DataItem,"id")%>'>
																		</td>
																		<td>Mese:</td>
																		<td><asp:DropDownList Runat="server" ID="drmese">
																				<asp:ListItem Value="0">-- Nessun Mese --</asp:ListItem>
																				<asp:ListItem Value="1">Gennaio</asp:ListItem>
																				<asp:ListItem Value="2">Febbraio</asp:ListItem>
																				<asp:ListItem Value="3">Marzo</asp:ListItem>
																				<asp:ListItem Value="4">Aprile</asp:ListItem>
																				<asp:ListItem Value="5">Maggio</asp:ListItem>
																				<asp:ListItem Value="6">Giugno</asp:ListItem>
																				<asp:ListItem Value="7">Luglio</asp:ListItem>
																				<asp:ListItem Value="8">Agosto</asp:ListItem>
																				<asp:ListItem Value="9">Settembre</asp:ListItem>
																				<asp:ListItem Value="10">Ottobre</asp:ListItem>
																				<asp:ListItem Value="11">Novembre</asp:ListItem>
																				<asp:ListItem Value="12">Dicembre</asp:ListItem>
																			</asp:DropDownList>
																		</td>
																	</tr>
																</ItemTemplate>
																<FooterTemplate>
											</TABLE>
										</FooterTemplate> </asp:repeater></TD>
								</TR>
								<TR>
									<TD align="left">Calcola</TD>
									<TD><cc1:s_combobox id="cmbsCalcola" runat="server" DBDirection="Input" DBSize="2" DBParameterName="p_calcola"
											DBIndex="6" DBDataType="Integer">
											<asp:ListItem Value="1">Calcola</asp:ListItem>
											<asp:ListItem Value="0">Non Calcola</asp:ListItem>
										</cc1:s_combobox></TD>
								</TR>
							</TBODY>
						</TABLE>
						</asp:panel></TD>
				</TR>
				<tr>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="7" runat="server" CssClass="btn" Text="Salva"></cc1:s_button>&nbsp;
						<cc1:s_button id="btnsElimina" tabIndex="8" runat="server" CssClass="btn" Text="Elimina" CommandType="Delete"
							CausesValidation="False"></cc1:s_button>&nbsp;
						<asp:button id="btnAnnulla" tabIndex="9" runat="server" CssClass="btn" Text="Annulla" CausesValidation="False"></asp:button></TD>
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
