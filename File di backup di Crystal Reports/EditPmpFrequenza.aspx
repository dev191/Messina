<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Page language="c#" Codebehind="EditPmpFrequenza.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditPmpFrequenza" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
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
	<body MS_POSITIONING="GridLayout" onload="fissaPeriodica('cmbsTipoCadenza')" onbeforeunload="parent.left.valorizza()"  >
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
	
		function fissaPeriodica(pippo)
	{   
		 var periodico, fisso;
		var prova = document.getElementById(pippo);
		var valSelezionato = prova.options[prova.selectedIndex].value;
		
		if (valSelezionato ==  1)
		{
			 periodico=document.getElementById("Periodico").style; 
			 periodico.display = 'none';
			 fisso=document.getElementById("Fisso").style; 
			 fisso.display = 'block';
		 }else
		 {
		 	 periodico=document.getElementById("Periodico").style; 
			 periodico.display = 'block';
			 fisso=document.getElementById("Fisso").style; 
			 fisso.display = 'none';
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
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" Width="552px" CssClass="TitleOperazione"></asp:label><cc2:messagepanel id="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"></cc2:messagepanel></TD>
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
													<TD align="left">Frequenza
														<asp:RequiredFieldValidator id="rfvfrequenza" runat="server" ErrorMessage="Inserire la frequenza" ControlToValidate="txtsfrequenza">*</asp:RequiredFieldValidator></TD>
													<TD>
														<cc1:S_TextBox id="txtsfrequenza" tabIndex="1" runat="server" DBDirection="Input" DBSize="40" DBParameterName="p_frequenza"
															DBIndex="0"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD align="left">Descrizione
														<asp:RequiredFieldValidator id="rvffrequenza_des" runat="server" ErrorMessage="Inserire la descrizione" ControlToValidate="txtsfrequenza_des">*</asp:RequiredFieldValidator></TD>
													<TD>
														<cc1:S_TextBox id="txtsfrequenza_des" tabIndex="2" runat="server" DBDirection="Input" DBSize="50"
															DBParameterName="p_frequenza_des" DBIndex="1" width="90%"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 15px" align="left">Tipo Cadenza</TD>
													<TD style="HEIGHT: 15px">
														<cc1:S_ComboBox id="cmbsTipoCadenza" runat="server" DBDirection="Input" DBSize="2" DBParameterName="P_mese_std"
															DBIndex="2" DBDataType="Integer">
															<asp:ListItem Value="0">Periodico</asp:ListItem>
															<asp:ListItem Value="1">Fisso</asp:ListItem>
														</cc1:S_ComboBox></TD>
												</TR>
												<TR>
												</TR>
											</TABLE>
											<TABLE id="Periodico">
												<TR>
													<TD style="HEIGHT: 14px" align="left">Giorni</TD>
													<TD style="HEIGHT: 14px">
														<cc1:S_ComboBox id="cmbsGiorni" runat="server" DBDirection="Input" DBSize="6" DBParameterName="p_n_giorni"
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
														</cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 13px" align="left">Mesi</TD>
													<TD style="HEIGHT: 13px">
														<cc1:S_ComboBox id="cmbsMesi" runat="server" DBDirection="Input" DBParameterName="p_n_mesi" DBIndex="4"
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
														</cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD align="left">Anni&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
													<TD>
														<cc1:S_ComboBox id="cmbsAnni" runat="server" DBDirection="Input" DBSize="10" DBParameterName="p_n_anni"
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
														</cc1:S_ComboBox></TD>
												</TR>
											</TABLE>
											<TABLE id="Fisso" style="DISPLAY: none">
												<TR>
													<TD align="left">Mesi&nbsp; &nbsp; &nbsp;</TD>
													<TD>
														<cc1:S_ComboBox id="S_combobox1" runat="server" DBDirection="Input" DBParameterName="p_n_mesi2"
															DBIndex="4" DBDataType="Integer">
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
														</cc1:S_ComboBox></TD>
												</TR>
											</TABLE>
											<TABLE>
												<TR>
													<TD align="left">Calcola&nbsp;</TD>
													<TD>
														<cc1:S_ComboBox id="cmbsCalcola" runat="server" DBDirection="Input" DBSize="2" DBParameterName="p_calcola"
															DBIndex="6" DBDataType="Integer">
															<asp:ListItem Value="1">Calcola</asp:ListItem>
															<asp:ListItem Value="0">Non Calcola</asp:ListItem>
														</cc1:S_ComboBox></TD>
												</TR>
											</TABLE>
										</asp:panel></TD>
								</TR>
								<tr>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="7" runat="server" Text="Salva" CssClass="btn"></cc1:s_button>&nbsp;
										<cc1:s_button id="btnsElimina" tabIndex="8" runat="server" Text="Elimina" CausesValidation="False"
											CommandType="Delete" CssClass="btn"></cc1:s_button>&nbsp;
										<asp:button id="btnAnnulla" tabIndex="9" runat="server" Text="Annulla" CausesValidation="False"
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
			<asp:validationsummary id="vlsEdit" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD></TR></TBODY></TABLE></form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
