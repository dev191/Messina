<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserStanze" Src="../WebControls/UserStanze.ascx" %>
<%@ Page language="c#" Codebehind="EditGiudizio.aspx.cs" AutoEventWireup="false" Inherits="TheSite.SoddisfazioneCliente.EditGiudizio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditGiudizio</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		var NS4 = (navigator.appName == "Netscape" && parseInt(navigator.appVersion) < 5);
		var NSX = (navigator.appName == "Netscape");
		var IE4 = (document.all) ? true : false;
		  function clearRoom()
	{
		document.getElementById("<%=UserStanze1.s_TxtIdStanza.ClientID%>").value="";
		document.getElementById("<%=UserStanze1.s_TxtDescStanza.ClientID%>").value="";	
	}   

			function valutanumeri(evt)
			{
				var e = evt? evt : window.event; 
				if(!e) return; 
				var key = 0; 
				
				if(IE4==true)
				{
					if (e.keyCode < 48	|| e.keyCode > 57){
						e.keyCode = 0;
						return false;
					}	
		        }
		        
				if (e.keycode) { key = e.keycode; } // for moz/fb, if keycode==0 use 'which' 
				if (typeof(e.which)!= 'undefined') { 
					key = e.which;
					if (key < 48	|| key > 57){
						return false;
					} 
					
				} 
			}
			function nonpaste()
			{
				return false;
			}
		
		  function seledificio()
		  {
		    var ctrl=document.getElementById('hiddenblid');
		    if (ctrl!=null)
		    {
		       if (ctrl.value=="")
		       {
					alert("Selezionare un Edificio!");
					return false;
			   }else
			     {return true;}
		    }
		  }
		</script>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" height="300">
							<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" align="center" style="WIDTH: 90%; HEIGHT: 300px">
								<TBODY>
									<TR>
										<TD style="WIDTH: 5%; HEIGHT: 4.86%" vAlign="top" align="left"></TD>
										<TD style="HEIGHT: 4.86%" vAlign="top" align="left">
											<asp:label id="lblOperazione" runat="server" CssClass="TitleOperazione" Width="536px"></asp:label>
											<cc2:messagepanel id="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"></cc2:messagepanel>
											<asp:textbox id="blid_scelto" Visible="False" Runat="server"></asp:textbox></TD>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 0.96%" vAlign="top" align="left"></TD>
						<TD style="HEIGHT: 0.96%" vAlign="top" align="left"><hr noShade SIZE="1">
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" style="HEIGHT: 300px"></TD>
						<TD vAlign="top" align="left" style="HEIGHT: 300px">
							<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
								<%if (Request["ItemId"]=="0"){;%>
								<TBODY>
									<TR>
										<TD style="WIDTH: 100%; HEIGHT: 42px" colSpan="4">
											<TABLE id="TableRicercaModulo" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" border="0">
												<TR>
													<TD><uc1:ricercamodulo id="RicercaModulo1" runat="server"></uc1:ricercamodulo></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<%}%>
									<%else {%>
									<TR>
										<TD style="WIDTH: 15.92%; HEIGHT: 2px" align="left"><B>Codice Edificio</B></TD>
										<TD style="FONT-WEIGHT: bold; HEIGHT: 2px">&nbsp;
											<cc1:s_label id="lblCodEdificio" tabIndex="0" runat="server" DBIndex="0" DBParameterName="p_CodEdificio"
												DBSize="16" DBDirection="Input"></cc1:s_label>&nbsp;&nbsp;&nbsp;</TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 43px" colSpan="2">
											<TABLE width="100%" border="0">
												<TR>
													<TD style="FONT-WEIGHT: bold" width="15%">Denominazione</TD>
													<TD width="35%">&nbsp;
														<asp:label id="lblDenominazione" runat="server" Font-Bold="true"></asp:label></TD>
													<TD style="FONT-WEIGHT: bold" width="15%">Indirizzo</TD>
													<TD align="left" width="35%">&nbsp;
														<asp:label id="lblIndirizzo" runat="server" Font-Bold="true"></asp:label></TD>
												</TR>
												<TR>
													<TD style="FONT-WEIGHT: bold" width="15%">Comune</TD>
													<TD width="35%">&nbsp;
														<asp:label id="lblComune" runat="server" Font-Bold="true"></asp:label></TD>
													<TD style="FONT-WEIGHT: bold" width="15%">Telefono</TD>
													<TD align="left" width="35%">&nbsp;
														<asp:label id="lblTelefono" runat="server" Font-Bold="true"></asp:label></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<%}%>
									<TR width="100%">
										<TD width="100%" colSpan="4" style="HEIGHT: 31px">
											<TABLE class="tblSearch100Dettaglio" style="WIDTH: 100%" cellSpacing="1" cellPadding="1"
												border="0">
												<TR>
													<TD width="15%">Piano</TD>
													<TD align="left" width="40%">
														<cc1:s_combobox id="cmbsPiano" runat="server" Width="200px" DBIndex="1" DBParameterName="p_id_piani"
															DBDirection="Input" DBDataType="Integer"></cc1:s_combobox></TD>
													<TD width="15%" colSpan="2">
														<uc1:UserStanze id="UserStanze1" runat="server"></uc1:UserStanze>
													</TD>
												</TR>
											</TABLE>
										</TD>
									<TR width="100%">
										<TD align="center" colSpan="4" style="HEIGHT: 34px">
											<TABLE class="tblSearch100Dettaglio" id="Table2" style="WIDTH: 100%" cellSpacing="1" cellPadding="1"
												border="0">
												<TR>
													<TD width="15%">Servizio</TD>
													<TD style="HEIGHT: 13px" align="left" width="40%">
														<cc1:S_ComboBox id="cmbsServizio" runat="server" DBIndex="3" DBParameterName="p_Servizio_Id" DBDataType="Integer"
															AutoPostBack="True"></cc1:S_ComboBox></TD>
													<TD width="15%">Giudizio Cliente</TD>
													<TD style="HEIGHT: 16px" align="left" width="30%">
														<cc1:S_ComboBox id="cmbsGiudizio" runat="server" DBIndex="4" DBParameterName="p_Giudizio_Id" DBDataType="Integer"
															AutoPostBack="False"></cc1:S_ComboBox>&nbsp;
														<asp:requiredfieldvalidator id="rfvGiudizio" runat="server" Width="3px" InitialValue="0" ControlToValidate="cmbsGiudizio"
															ErrorMessage="Selezionare giudizio!">*</asp:requiredfieldvalidator></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR width="100%">
										<TD align="center" colSpan="4" style="HEIGHT: 35px">
											<TABLE class="tblSearch100Dettaglio" id="Table23" style="WIDTH: 100%" cellSpacing="1" cellPadding="1"
												border="0">
												<TR>
													<TD align="left" width="15%">Data Ispezione</TD>
													<TD width="40%">
														<uc1:CalendarPicker id="dataIspezione" runat="server"></uc1:CalendarPicker></TD>
													<TD width="15%">Numero</TD>
													<TD style="HEIGHT: 16px" align="left" width="30%">
														<cc1:S_TextBox id="txtNumero" runat="server" DBIndex="5" DBParameterName="p_numero" DBDataType="Integer"
															MaxLength="7" Text="1"></cc1:S_TextBox>
														<asp:regularexpressionvalidator id="regtxtNumero" Runat="server" ControlToValidate="txtNumero" ErrorMessage="Controlare dati inseriti nel campo Numero!"
															ValidationExpression="^[0-9]*$">*</asp:regularexpressionvalidator></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR width="100%">
										<TD align="center" colSpan="4" style="HEIGHT: 126px">
											<TABLE class="tblSearch100Dettaglio" id="Table22" style="WIDTH: 100%; HEIGHT: 100%" cellSpacing="1"
												cellPadding="1" border="0">
												<TR>
													<TD align="left" width="15%">Attività Ispezione</TD>
													<TD>
														<cc1:s_textbox id="txtAttivitaIsp" tabIndex="1" runat="server" Width="100%" DBIndex="6" DBParameterName="p_attivita"
															DBSize="500" DBDirection="Input" DBDataType="VarChar" Rows="3" TextMode="MultiLine"></cc1:s_textbox></TD>
												</TR>
												<TR>
													<TD align="left" width="15%">Annotazioni</TD>
													<TD>
														<cc1:s_textbox id="txtAnnotazioni" tabIndex="1" runat="server" Width="100%" DBIndex="7" DBParameterName="p_annotazioni"
															DBSize="4000" DBDirection="Input" DBDataType="VarChar" Rows="3" TextMode="MultiLine"></cc1:s_textbox></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 0.48%" vAlign="top" align="left"></TD>
						<TD style="HEIGHT: 0.48%" vAlign="top" align="left">
							<cc1:s_button id="btnsSalva" tabIndex="10" runat="server" CssClass="btn" Text="Salva"></cc1:s_button>&nbsp;
							<cc1:s_button id="btnsElimina" tabIndex="11" runat="server" CssClass="btn" Text="Elimina" CausesValidation="False"
								CommandType="Delete"></cc1:s_button>&nbsp;
							<asp:button id="btnAnnulla" tabIndex="12" runat="server" CssClass="btn" Text="Annulla" CausesValidation="False"></asp:button>&nbsp;&nbsp;
							<INPUT id="hiddenblid" type="hidden" name="hiddenblid" runat="server">
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 0%" vAlign="top" align="left"></TD>
						<TD style="HEIGHT: 0%" vAlign="top" align="left">
							<hr noShade SIZE="1">
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 0%" vAlign="top" align="left"></TD>
						<TD style="HEIGHT: 0%" vAlign="top" align="left"><asp:label id="lblFirstAndLast" runat="server" Visible="false"></asp:label>&nbsp;</TD>
					</TR>
					<tr>
						<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
						<td><asp:validationsummary id="vlsEdit" tabIndex="20" runat="server" Width="968px" ShowMessageBox="True" Height="10px"></asp:validationsummary>
						</td>
					</tr>
				</TBODY>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
