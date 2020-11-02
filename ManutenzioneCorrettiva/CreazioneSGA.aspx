<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RichiedentiSollecito" Src="../WebControls/RichiedentiSollecito.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserStanze" Src="../WebControls/UserStanze.ascx" %>
<%@ Page language="c#" Codebehind="CreazioneSGA.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorrettiva.CreazioneSGA" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Creazione SGA</title>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
	 

		function setProg()
		{
			if(document.getElementById('CmbProgetto')==null)
				return;
			var ct=document.getElementById('CmbProgetto').value;
			document.getElementById("<%=RichiedentiSollecito1.idProg.ClientID%>").value=ct;
			document.getElementById("<%=RicercaModulo1.idProg.ClientID%>").value=ct;
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
	</HEAD>
	<body bottomMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<tr>
						<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" title="Inserimento Richieste" runat="server"></uc1:pagetitle></TD>
					</tr>
					<tr>
						<td>
							<hr noShade SIZE="1">
							<div>&nbsp;<asp:label id="lblProgetto" runat="server">Progetto: </asp:label><asp:dropdownlist id="CmbProgetto" runat="server" Width="216px"></asp:dropdownlist></div>
						</td>
					</tr>
					<tr>
						<TD vAlign="top" align="left" height="100%">
							<TABLE id="tblBlSearch" cellSpacing="1" cellPadding="1" border="0">
								<tr>
									<td>
										<div id="PanelRichiedente">
											<TABLE id="TableRichiedente" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" border="0">
												<TR>
													<TD><uc1:richiedentisollecito id="RichiedentiSollecito1" runat="server"></uc1:richiedentisollecito><asp:requiredfieldvalidator id="rfvRichiedenteNome" runat="server" ErrorMessage="Indicare il Nome del Richiedente">*</asp:requiredfieldvalidator><asp:requiredfieldvalidator id="rfvRichiedenteCognome" runat="server" ErrorMessage="Indicare il Cognome del Richiedente">*</asp:requiredfieldvalidator></TD>
												</TR>
											</TABLE>
										</div>
									</td>
								</tr>
								<TR>
									<TD>
										<TABLE id="TableRicercaModulo" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" border="0">
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
										<TABLE class="tblSearch100Dettaglio" style="WIDTH: 100%" cellSpacing="0" cellPadding="0"
											border="0">
											<TR>
												<TD width="10%">Telefono</TD>
												<TD align="left" width="20%"><asp:textbox id="txtsTelefonoRichiedente" runat="server" MaxLength="50"></asp:textbox></TD>
												<TD class="Comm" width="10%"><span class="blueoverline">Nota/Ambiente</span></TD>
												<TD align="left" width="40%"><asp:textbox id="txtsNota" runat="server" Width="100%" MaxLength="2000" Rows="2" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<tr>
												<TD class="Comm" width="10%"><span class="blueoverline">Piano</span><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Selezionare un piano"
														ControlToValidate="cmbsPiano">*</asp:requiredfieldvalidator></TD>
												<TD align="left" width="20%"><asp:dropdownlist id="cmbsPiano" runat="server" Width="200px"></asp:dropdownlist></TD>
												<TD width="10%" colSpan="2"><uc1:userstanze id="UserStanze1" runat="server"></uc1:userstanze></TD>
											</tr>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD><asp:linkbutton id="lkbNonEmesse" runat="server" CssClass="LabelInfo" CausesValidation="False">Richieste non Emesse</asp:linkbutton></TD>
								</TR>
								<TR>
									<TD>
										<div id="pnlShowInfo" style="DISPLAY: none; Z-INDEX: 100; COLOR: #ffffff; POSITION: absolute; BACKGROUND-COLOR: gainsboro"
											runat="server">
											<TABLE height="100%" width="100%">
												<TR>
													<TD class="TitleSearch" vAlign="top" align="right"><asp:linkbutton id="lnkChiudi" runat="server" CssClass="LabelChiudi" CausesValidation="False">Chiudi</asp:linkbutton></TD>
												</TR>
												<TR>
													<TD><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AllowPaging="True" GridLines="Vertical"
															AutoGenerateColumns="False" BorderWidth="1px" BorderColor="Gray" PageSize="5">
															<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
															<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
															<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
															<Columns>
																<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
																<asp:TemplateColumn>
																	<HeaderStyle Width="3%"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:ImageButton CausesValidation=False id="lnkNonEmesse" Runat=server CommandName="NonEmesse" ImageUrl="~/images/edit.gif" CommandArgument='<%# "CompletaRdl.aspx?wr_id=" + DataBinder.Eval(Container.DataItem,"ID")%>'>
																		</asp:ImageButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="ID" HeaderText="N. RDL"></asp:BoundColumn>
																<asp:BoundColumn DataField="bl" HeaderText="EDIFICIO"></asp:BoundColumn>
																<asp:BoundColumn DataField="Data" HeaderText="DATA RICHIESTA" DataFormatString="{0:g}"></asp:BoundColumn>
																<asp:BoundColumn DataField="status" HeaderText="STATO"></asp:BoundColumn>
																<asp:BoundColumn DataField="Descrizione" HeaderText="DESCRIZIONE"></asp:BoundColumn>
																<asp:BoundColumn DataField="Richiedente" HeaderText="RICHIEDENTE"></asp:BoundColumn>
															</Columns>
															<PagerStyle Mode="NumericPages"></PagerStyle>
														</asp:datagrid></TD>
												</TR>
											</TABLE>
										</div>
										<iframe id="DivShim" style="DISPLAY: none; POSITION: absolute" tabIndex="0" src="javascript:false;"
											frameBorder="0" scrolling="no"></iframe>
									</TD>
								</TR>
								<TR>
									<TD><asp:linkbutton id="LinkApprovate" runat="server" CssClass="LabelInfo" CausesValidation="False">Richieste Approvate</asp:linkbutton></TD>
								</TR>
								<TR>
									<TD>
										<div id="PanelEmesse" style="DISPLAY: none; Z-INDEX: 100; COLOR: #ffffff; POSITION: absolute; BACKGROUND-COLOR: gainsboro"
											runat="server">
											<TABLE height="100%" width="100%">
												<TR>
													<TD class="TitleSearch" vAlign="top" align="right"><asp:linkbutton id="LinkChiudi2" runat="server" CssClass="LabelChiudi" CausesValidation="False">Chiudi</asp:linkbutton></TD>
												</TR>
												<TR>
													<TD><asp:datagrid id="DatagridEmesse" runat="server" CssClass="DataGrid" AllowPaging="True" GridLines="Vertical"
															AutoGenerateColumns="False" BorderWidth="1px" BorderColor="Gray" PageSize="5">
															<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
															<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
															<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
															<Columns>
																<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
																<asp:TemplateColumn>
																	<HeaderStyle Width="3%"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:ImageButton CausesValidation=False id="lnlEmesse" Runat=server CommandName="Emesse" ImageUrl="~/images/edit.gif" CommandArgument='<%# "CompletaRdl.aspx?wr_id=" + DataBinder.Eval(Container.DataItem,"ID") + "&c=true"%>'>
																		</asp:ImageButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="ID" HeaderText="N. RDL"></asp:BoundColumn>
																<asp:BoundColumn DataField="bl" HeaderText="EDIFICIO"></asp:BoundColumn>
																<asp:BoundColumn DataField="Data" HeaderText="DATA RICHIESTA" DataFormatString="{0:g}"></asp:BoundColumn>
																<asp:BoundColumn DataField="status" HeaderText="STATO"></asp:BoundColumn>
																<asp:BoundColumn DataField="Descrizione" HeaderText="DESCRIZIONE"></asp:BoundColumn>
																<asp:BoundColumn DataField="Richiedente" HeaderText="RICHIEDENTE"></asp:BoundColumn>
															</Columns>
															<PagerStyle Mode="NumericPages"></PagerStyle>
														</asp:datagrid></TD>
												</TR>
											</TABLE>
										</div>
										<iframe id="DivEmesse" style="DISPLAY: none; POSITION: absolute" src="javascript:false;"
											frameBorder="0" scrolling="no"></iframe>
									</TD>
								</TR>
								<TR>
									<TD><asp:button id="btsCodice" runat="server" Width="153" Height="22" text="Visualizza Reperibilità"></asp:button><BR>
										<asp:textbox id="txtBL_ID" runat="server" Width="0px"></asp:textbox>
										<div id="PopupRep" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; DISPLAY: none; BORDER-LEFT: #000000 1px solid; WIDTH: 100%; BORDER-BOTTOM: #000000 1px solid; POSITION: absolute; HEIGHT: 200%"><IFRAME id="docRep" name="docRep" src="" frameBorder="no" width="100%"></IFRAME>
										</div>
									</TD>
								</TR>
								<TR>
									<TD>
										<div id="PanelServizio">
											<TABLE id="Table2" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" border="0">
												<TR>
													<TD class="Comm" style="HEIGHT: 16px" width="15%"><SPAN class="blueoverline">Servizio</SPAN></TD>
													<TD style="HEIGHT: 16px" colSpan="5"><asp:dropdownlist id="cmbsServizio" runat="server" Width="350px" AutoPostBack="True"></asp:dropdownlist><asp:requiredfieldvalidator id="RequiredfieldvalidatorServ" runat="server" ErrorMessage="Selezionare un servizio"
															ControlToValidate="cmbsServizio" InitialValue="0">*</asp:requiredfieldvalidator></TD>
												</TR>
												<TR>
													<TD width="15%"><SPAN>Std. Apparecchiatura</SPAN></TD>
													<TD colSpan="5"><asp:dropdownlist id="cmbsApparecchiatura" runat="server" Width="350px" AutoPostBack="True"></asp:dropdownlist></TD>
												</TR>
											</TABLE>
										</div>
									</TD>
								</TR>
								<TR>
									<TD>
										<TABLE id="TableRicercaApparecchiatura" style="WIDTH: 100%" cellSpacing="1" cellPadding="1"
											border="0">
											<TR>
												<TD><uc1:codiceapparecchiature id="CodiceApparecchiature1" runat="server"></uc1:codiceapparecchiature></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD>
										<div id="PanelProblema">
											<TABLE id="TableProblema" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" border="0">
												<TR>
													<TD width="15%">Priorità</TD>
													<TD><asp:dropdownlist id="cmbsUrgenza" runat="server" Width="400px"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD width="15%">Descrizione Problema/Note</TD>
													<TD><asp:textbox id="txtsProblema" runat="server" Width="100%" Rows="4" TextMode="MultiLine" Height="34px"></asp:textbox></TD>
												</TR>
											</TABLE>
										</div>
									</TD>
								</TR>
								<TR>
									<TD class="SGA"><B class="blueoverline">Tipo Manutenzione:&nbsp;&nbsp; </B>
										<asp:dropdownlist id="cmbsTipoManutenzione" runat="server" width="196px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="SGA">
										<div><span class="blueoverline">Tipo di intervento:&nbsp;</span><asp:dropdownlist id="cmbsTipoIntrevento" runat="server" width="224px"></asp:dropdownlist></div>
									</TD>
								</TR>
								<TR style="DISPLAY: none">
									<TD class="SGA">
										<div id="aseguito4"><span class="blueoverline">Causa presunta guasto/anomalia</span><asp:textbox id="TxtCausa" runat="server" Width="100%" MaxLength="408" Rows="4" TextMode="MultiLine"
												Height="34px" Visible="False"></asp:textbox></div>
									</TD>
								</TR>
								<TR style="DISPLAY: none">
									<TD class="SGA">
										<div id="aseguito5"><span class="blueoverline">Effetto del guasto</span>
											<asp:textbox id="TxtGuasto" runat="server" Width="100%" MaxLength="408" Rows="4" TextMode="MultiLine"
												Height="34px" Visible="False"></asp:textbox></div>
									</TD>
								</TR>
								<tr>
									<td>
										<table style="WIDTH: 344px; HEIGHT: 26px" cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD style="WIDTH: 37px">Email:</TD>
												<TD style="WIDTH: 72px" width="72"><asp:checkbox id="chksSendMail" runat="server" Text="[Si/No]"></asp:checkbox>
												<TD width="15%">Destinatari:</TD>
												<TD><asp:textbox id="txtsMittente" runat="server" Width="100%" ToolTip="Gli indirizzi mail devono essere separati da ;"></asp:textbox></TD>
											</TR>
										</table>
									</td>
								</tr>
								<TR>
									<TD>
										<TABLE style="WIDTH: 408px; HEIGHT: 24px" cellSpacing="0" cellPadding="0" width="408" border="0">
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
										<div><cc1:s_button id="btnsSalva" tabIndex="2" runat="server" Text="Salva"></cc1:s_button>&nbsp;<asp:button id="cmdReset" CausesValidation="False" Text="Reset" Runat="server"></asp:button>
											<cc1:s_button id="btnsChiudi" runat="server" CausesValidation="False" Text="Chiudi"></cc1:s_button><a 
            class=GuidaLink href="<%= HelpLink %>" target=_blank 
            >Guida</a></div>
									</TD>
								</TR>
								<TR>
									<TD>
										<div><asp:label id="lblFirstAndLast" runat="server"></asp:label>&nbsp;
											<MESSPANEL:MESSAGEPANEL id="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"></MESSPANEL:MESSAGEPANEL></div>
									</TD>
								</TR>
								<TR>
									<TD>
										<div><asp:validationsummary id="vlsEdit" runat="server" ShowSummary="False" DisplayMode="List" ShowMessageBox="True"></asp:validationsummary></div>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
