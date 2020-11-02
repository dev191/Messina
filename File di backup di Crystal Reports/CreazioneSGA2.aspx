<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RichiedentiSollecito" Src="../WebControls/RichiedentiSollecito.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserStanze" Src="../WebControls/UserStanze.ascx" %>
<%@ Page language="c#" Codebehind="CreazioneSGA2.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorrettiva.CreazioneSGA2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Creazione SGA2</title>
	</HEAD>
	<BODY bottomMargin="0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Css/MainSheet.css">
		<script language="javascript">
	 

		function setProg()
		{
			if(document.getElementById('CmbProgetto')==null)
				return;
			var ct=document.getElementById('CmbProgetto').value;
			
			document.getElementById("<%=RicercaModulo1.idProg.ClientID%>").value=ct;
		}
		
			function setcmbsTipoMan()
		{			
			document.getElementById('cmbsTipoManutenzione').selectedIndex=1;
			
			/*document.getElementById('cmbsTipoManutenzione').value='Manutenzione Canone';*/
		}
		
		
		function clearRoom()
		{
			document.getElementById("<%=UserStanze1.s_TxtIdStanza.ClientID%>").value="";
			document.getElementById("<%=UserStanze1.s_TxtDescStanza.ClientID%>").value="";	
		}   
	
  
	
		function iterator(senser)
		{
			var count = document.forms[0].elements.length;
			for (i=0; i<count; i++) 
			{	
				var element = document.forms[0].elements[i]; 
				if(element.type == 'select-one')
				{
					element.disabled=true;
				}
			}	
		}
		
	function ClearApparechiature()
	{
		var ctrltxtapp=document.getElementById('<%=CodiceApparecchiature1.s_CodiceApparecchiatura.ClientID%>');
		if(ctrltxtapp!=null && ctrltxtapp!='undefined')
		{
		  ctrltxtapp.value="";
		  document.getElementById('<%=CodiceApparecchiature1.CodiceHidden.ClientID%>').value="";
		}
	}

	function ControllaBL(nome)
	{
		if (document.getElementById(nome).value == "")				
		{
			alert('Inserire il Codice Edificio');
			return false;
		}
		return true;
	}
	
  function DivSetVisible(state)
  {
	 var DivRef = document.getElementById('pnlShowInfo');
	 var IfrRef = document.getElementById('DivShim');
	 if(state)
	 {
		DivRef.style.display = "block";
		IfrRef.style.width = DivRef.offsetWidth;
		IfrRef.style.height = DivRef.offsetHeight;
		IfrRef.style.top = DivRef.style.top;
		IfrRef.style.left = DivRef.style.left;
		IfrRef.style.zIndex = DivRef.style.zIndex - 1;
		IfrRef.style.display = "block";
	}
	else
	{
		DivRef.style.display = "none";
		IfrRef.style.display = "none";
	}
  }
  
   function EmesseSetVisible(state)
  {
   var DivRef = document.getElementById('PanelEmesse');
   var IfrRef = document.getElementById('DivEmesse');
   if(state)
   {
    DivRef.style.display = "block";
    IfrRef.style.width = DivRef.offsetWidth;
    IfrRef.style.height = DivRef.offsetHeight;
    IfrRef.style.top = DivRef.style.top;
    IfrRef.style.left = DivRef.style.left;
    IfrRef.style.zIndex = DivRef.style.zIndex - 1;
    IfrRef.style.display = "block";
   }
   else
   {
    DivRef.style.display = "none";
    IfrRef.style.display = "none";
   }
   
   
  }
  function visibletextmail(sender,controlid)
  {
       document.getElementById(controlid).disabled=!document.getElementById(sender).checked;       
  }
  	function SoloNumeri()
		{	
			if (event.keyCode < 48	|| event.keyCode > 57)
			{
				event.keyCode = 0;
			}	
		}
		
 		function ControllaOra(orain)
		{
		
			var ora=document.getElementById(orain).value;
			
				if (isNaN(ora))
						document.getElementById(orain).value="00"
				if(ora<0 || ora>23)
				{ 

					alert("Attenzione l'ora deve essere compresa tra 00 e 23");		
					document.getElementById(orain).focus()
					return false;
				}	
				else
				{
					var val = document.getElementById(orain).value;
					if(val.length==1)
						document.getElementById(orain).value="0" + val;
					return true;
				}
		}
		function ControllaMin(min)
		{
			var minuti=parseInt(document.getElementById(min).value);
				if (minuti=="")
						document.getElementById(min).value="00"
				
				
				if(minuti<0 || minuti>59)
				{
					alert("Attenzione i minuti devono essere compresi tra 00 e 59");		
					document.getElementById(min).focus();
					return false;
				}
				else
				{
				var val = document.getElementById(min).value;
					if(val.length==1)
						document.getElementById(min).value="0" + val;
					return true;
				}
			
		}
	function formatNum(obj)

{
	val=document.getElementById(obj).value;
	if(val=="")
		document.getElementById(obj).value="00";
	//if(val.length==1)	
	//	document.getElementById(obj).value=val+"0";
}


function $get(ct)
{
 return document.getElementById(ct);
}



		</script>
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; HEIGHT: 200px; TOP: 0px; LEFT: 0px"
				id="TableMain" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" title="Inserimento Richieste" runat="server"></uc1:pagetitle></TD>
				</tr>
				<tr>
					<td>
						<div>&nbsp;<asp:label id="lblProgetto" runat="server">Progetto: </asp:label><asp:dropdownlist id="CmbProgetto" runat="server" Width="216px"></asp:dropdownlist></div>
					</td>
				</tr>
				<TR>
					<TD>
						<table class="tblSearch100Dettaglio">
							<tr>
								<td>
							<TR>
								<TD>Dati Richiedente:</TD>
							</TR>
							<TR>
								<TD>
									<TABLE style="WIDTH: 100%" id="Table1" class="tblSearch100Dettaglio" border="0" cellSpacing="0"
										cellPadding="0">
										<TBODY>
											<TR>
												<TD>Nome</TD>
												<TD><cc1:s_textbox id="txtRichNome" Width="150px" DBParameterName="p_NomeRich" Runat="server" MaxLength="32"
														DBIndex="1" DBSize="32" Enabled="False"></cc1:s_textbox></TD>
												<TD>Cognome</TD>
												<TD><cc1:s_textbox id="txtRichCognome" Width="150px" DBParameterName="p_CognomeRich" Runat="server"
														MaxLength="32" DBIndex="2" DBSize="32" Enabled="False"></cc1:s_textbox></TD>
												<TD>Gruppo
												</TD>
												<TD style="WIDTH: 171px"><cc1:s_combobox id="cmbsGruppo" runat="server" Width="196px" DBParameterName="p_Gruppo" DBIndex="3"
														Enabled="False" DBDataType="Integer" AutoPostBack="False"></cc1:s_combobox></TD>
												<TD colSpan="2"></TD>
												<!--<TD>
											<img src="../images/elimina.gif" style="CURSOR:hand" title="Pulisci Campi" border="0"
												onclick="PulisciCampi()">
										</TD>--></TR>
											<TR>
												<TD>Telefono</TD>
												<TD><cc1:s_textbox id="txtstelefono" Width="150px" DBParameterName="p_phone_em" Runat="server" MaxLength="50"
														DBIndex="2" DBSize="50" Enabled="False"></cc1:s_textbox></TD>
												<TD>Email
												</TD>
												<TD><cc1:s_textbox id="txtsemail" Width="250px" DBParameterName="p_email_em" Runat="server" MaxLength="50"
														DBIndex="2" DBSize="50" Enabled="False"></cc1:s_textbox></TD>
								</TD>
								<TD>Stanza</TD>
								<TD colSpan="2"><cc1:s_textbox id="txtstanza" Width="150px" DBParameterName="p_stanza" Runat="server" MaxLength="50"
										DBIndex="1" DBSize="50" Enabled="False"></cc1:s_textbox></TD>
							</TR>
							<TR>
								<TD style="DISPLAY: none" id="tdcontatti" colSpan="7"><asp:linkbutton id="lnkVisContatti" runat="server" Width="272px" CausesValidation="False">Visualizza Contatti</asp:linkbutton></TD>
							</TR>
						</table> <!--fine tabella-->
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE style="WIDTH: 100%" id="TableRicercaModulo" border="0" cellSpacing="1" cellPadding="1">
							<TR>
								<TD><uc1:ricercamodulo id="RicercaModulo1" runat="server"></uc1:ricercamodulo><asp:requiredfieldvalidator id="rfvEdificio" runat="server" ErrorMessage="Selezionare un Edificio">*</asp:requiredfieldvalidator></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>Descrizione Intervento Richiesto:</TD>
				</TR>
				<TR>
					<TD>
						<TABLE style="WIDTH: 100%" class="tblSearch100Dettaglio" border="0" cellSpacing="0" cellPadding="0">
							<tr>
								<TD class="Comm" width="10%"><span class="blueoverline">Piano</span><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Selezionare un piano"
										ControlToValidate="cmbsPiano">*</asp:requiredfieldvalidator></TD>
								<TD width="20%" align="left"><asp:dropdownlist id="cmbsPiano" runat="server" Width="200px"></asp:dropdownlist></TD>
								<TD width="10%" colSpan="2"><uc1:userstanze id="UserStanze1" runat="server" Visible="False"></uc1:userstanze></TD>
							</tr>
							<TR>
								<TD class="Comm" width="10%"><span class="blueoverline">Nota/Ambiente</span></TD>
								<TD width="40%" align="left"><asp:textbox id="txtsNota" runat="server" Width="100%" MaxLength="2000" TextMode="MultiLine"
										Rows="2"></asp:textbox></TD>
								<TD width="10%"><!--Telefono--></TD>
								<TD width="20%" align="left"><asp:textbox id="txtsTelefonoRichiedente" runat="server" MaxLength="50" Visible="False"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<!--<TR>
									<TD><asp:linkbutton id="lkbNonEmesse" runat="server" CssClass="LabelInfo" CausesValidation="False" Visible="False">Richieste non Emesse</asp:linkbutton></TD>
								</TR>-->
				<!--<TR>
									<TD><asp:linkbutton id="LinkApprovate" runat="server" CssClass="LabelInfo" CausesValidation="False"
											Visible="False">Richieste Approvate</asp:linkbutton></TD>
								</TR>-->
				<!--<TR>
									<TD><asp:button id="btsCodice" runat="server" Width="153" Height="22" text="Visualizza Reperibilità"></asp:button><BR>
										<asp:textbox id="txtBL_ID" runat="server" Width="0px"></asp:textbox>
										<div id="PopupRep" style="BORDER-BOTTOM: #000000 1px solid; POSITION: absolute; BORDER-LEFT: #000000 1px solid; WIDTH: 100%; DISPLAY: none; HEIGHT: 200%; BORDER-TOP: #000000 1px solid; BORDER-RIGHT: #000000 1px solid"><IFRAME id="docRep" name="docRep" src="" frameBorder="no" width="100%"></IFRAME>
										</div>
									</TD>
								</TR>-->
				<TR>
					<TD>
						<div id="PanelServizio">
							<TABLE style="WIDTH: 100%" id="Table2" border="0" cellSpacing="1" cellPadding="1">
								<TR>
									<TD style="HEIGHT: 16px" class="Comm" width="15%"><SPAN class="blueoverline">Servizio</SPAN></TD>
									<TD style="HEIGHT: 16px" colSpan="5"><asp:dropdownlist id="cmbsServizio" runat="server" Width="350px" AutoPostBack="True"></asp:dropdownlist><asp:requiredfieldvalidator id="RequiredfieldvalidatorServ" runat="server" ErrorMessage="Selezionare un servizio"
											ControlToValidate="cmbsServizio" InitialValue="0">*</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD width="15%"><!--<SPAN>Std. Apparecchiatura</SPAN>--></TD>
									<TD colSpan="5"><asp:dropdownlist id="cmbsApparecchiatura" runat="server" Width="350px" AutoPostBack="True" Visible="False"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</div>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE style="WIDTH: 100%" id="TableRicercaApparecchiatura" border="0" cellSpacing="1"
							cellPadding="1">
							<TR>
								<TD><uc1:codiceapparecchiature id="CodiceApparecchiature1" runat="server"></uc1:codiceapparecchiature></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<div id="PanelProblema">
							<TABLE style="WIDTH: 100%" id="TableProblema" border="0" cellSpacing="1" cellPadding="1">
								<TR>
									<TD width="15%"><!--Priorità--></TD>
									<TD><asp:dropdownlist id="cmbsUrgenza" runat="server" Width="400px" Visible="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD width="15%">Descrizione Problema/Note</TD>
									<TD><asp:textbox id="txtsProblema" runat="server" Width="100%" TextMode="MultiLine" Rows="8" Height="70px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</div>
					</TD>
				</TR>
				<TR style="DISPLAY: none">
					<TD class="SGA">
						<!--<B class="blueoverline">Tipo Manutenzione:&nbsp;&nbsp; </B>--><asp:dropdownlist id="cmbsTipoManutenzione" runat="server" Visible="False" width="196px"></asp:dropdownlist></TD>
				</TR>
				<TR style="DISPLAY: none">
					<!--<TD class="SGA">
										<div><span class="blueoverline">Tipo di intervento:&nbsp;</span><asp:dropdownlist id="cmbsTipoIntrevento" runat="server" width="224px" Visible="False"></asp:dropdownlist></div>
									</TD>--></TR>
				<TR style="DISPLAY: none">
					<TD class="SGA">
						<div id="aseguito4"><span class="blueoverline">Causa presunta guasto/anomalia</span><asp:textbox id="TxtCausa" runat="server" Width="100%" MaxLength="408" Visible="False" TextMode="MultiLine"
								Rows="4" Height="34px"></asp:textbox></div>
					</TD>
				</TR>
				<TR style="DISPLAY: none">
					<TD class="SGA">
						<div id="aseguito5"><span class="blueoverline">Effetto del guasto</span>
							<asp:textbox id="TxtGuasto" runat="server" Width="100%" MaxLength="408" Visible="False" TextMode="MultiLine"
								Rows="4" Height="34px"></asp:textbox></div>
					</TD>
				</TR>
				<tr>
					<td>
						<table style="WIDTH: 344px; HEIGHT: 26px" border="0" cellSpacing="0" cellPadding="0">
							<TR>
								<!--<TD style="WIDTH: 37px">Email:</TD>-->
								<TD style="WIDTH: 72px" width="72"><asp:checkbox id="chksSendMail" runat="server" Visible="False" Text="[Si/No]"></asp:checkbox>
								<!--<TD width="15%">Destinatari:</TD>-->
								<TD><asp:textbox id="txtsMittente" runat="server" Width="200px" Visible="False" ToolTip="Gli indirizzi mail devono essere separati da ;"></asp:textbox></TD>
							</TR>
						</table>
					</td>
				</tr>
				<TR>
					<TD>
						<TABLE style="WIDTH: 408px; HEIGHT: 24px" border="0" cellSpacing="0" cellPadding="0" width="408">
							<TR>
								<TD>Richiesta:&nbsp;</TD>
								<TD><UC1:CALENDARPICKER id="CalendarPicker1" runat="server"></UC1:CALENDARPICKER></TD>
								<TD>Ora:</TD>
								<TD><asp:textbox id="txtsorain" runat="server" Width="30px">00</asp:textbox>:
									<asp:textbox id="txtsorainmin" runat="server" Width="30px">00</asp:textbox>&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<div><cc1:s_button id="btnsSalva" tabIndex="2" runat="server" Text="Salva"></cc1:s_button>&nbsp;<asp:button id="cmdReset" Runat="server" CausesValidation="False" Text="Reset"></asp:button>
							<cc1:s_button id="btnsChiudi" runat="server" CausesValidation="False" Text="Chiudi"></cc1:s_button><a 
      class=GuidaLink href="<%= HelpLink %>" target=_blank 
      >Guida</a></div>
					</TD>
				</TR>
				<TR>
					<TD>
						<div><asp:label id="lblFirstAndLast" runat="server"></asp:label>&nbsp;
							<MESSPANEL:MESSAGEPANEL id="PanelMess" runat="server" ErrorIconUrl="~/Images/ico_critical.gif" MessageIconUrl="~/Images/ico_info.gif"></MESSPANEL:MESSAGEPANEL></div>
					</TD>
				</TR>
				<TR>
					<TD>
						<div><asp:validationsummary id="vlsEdit" runat="server" ShowSummary="False" DisplayMode="List" ShowMessageBox="True"></asp:validationsummary></div>
					</TD>
				</TR>
				</TD></TR>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
	</BODY>
</HTML>
