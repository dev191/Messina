<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RichiedentiSollecito" Src="../WebControls/RichiedentiSollecito.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Page language="c#" Codebehind="CreazioneRdl.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorretiva.CreazioneRdl" %>
<%@ Register TagPrefix="uc1" TagName="UserStanze" Src="../WebControls/UserStanze.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CreazioneRdl</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
 
 
  function clearRoom()
	{
		document.getElementById("<%=UserStanze1.s_TxtIdStanza.ClientID%>").value="";
		document.getElementById("<%=UserStanze1.s_TxtDescStanza.ClientID%>").value="";	
	}   
	
    function disableControl()
	{	
		var ctrl= document.forms[0]; 
		iterator(ctrl);		
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
  
 
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="5" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout"
		onbeforeunload="disableControl();parent.left.valorizza()">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; HEIGHT: 100%; TOP: 0px; LEFT: 0px"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" title="Inserimento Richieste" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" height="98%">
						<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" align="center">
							<TR>
								<TD style="WIDTH: 3%; HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 3%" vAlign="top" align="left"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 1%" vAlign="top" align="left">
									<hr noShade SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center"></TD>
								<TD vAlign="top" align="left">
									<TABLE id="tblSearch95" cellSpacing="1" cellPadding="1" border="0">
										<TR>
											<TD align="center" colSpan="4"><asp:panel id="PanelRichiedente" runat="server">
													<TABLE style="WIDTH: 100%" id="TableRichiedente" border="0" cellSpacing="1" cellPadding="1">
														<TR>
															<TD width="25%" colSpan="4">
																<uc1:RichiedentiSollecito id="RichiedentiSollecito1" runat="server"></uc1:RichiedentiSollecito>
																<asp:requiredfieldvalidator id="rfvRichiedenteNome" runat="server" ErrorMessage="Indicare il Nome del Richiedente">*</asp:requiredfieldvalidator>
																<asp:requiredfieldvalidator id="rfvRichiedenteCognome" runat="server" ErrorMessage="Indicare il Cognome del Richiedente">*</asp:requiredfieldvalidator></TD>
														</TR>
													</TABLE>
												</asp:panel></TD>
										</TR>
										<TR>
											<TD align="left" colSpan="4">
												<TABLE id="TableRicercaModulo" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" border="0">
													<TR>
														<TD><uc1:ricercamodulo id="RicercaModulo1" runat="server"></uc1:ricercamodulo><asp:requiredfieldvalidator id="rfvEdificio" runat="server" ErrorMessage="Selezionare un Edificio">*</asp:requiredfieldvalidator></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<td>
												<table>
													<tr>
														<td>
															Descrizione Intervento Richiesto:
														</td>
													</tr>
												</table>
												<TABLE style="WIDTH: 100%" cellSpacing="1" cellPadding="1" border="0" class="tblSearch100Dettaglio">
													<TR>
														<TD width="10%">Telefono</TD>
														<TD align="left" width="20%">
															<cc1:S_TextBox id="txtsTelefonoRichiedente" runat="server" MaxLength="50" DBIndex="3" DBSize="20"
																DBParameterName="p_Phone"></cc1:S_TextBox></TD>
														<TD width="10%">Nota</TD>
														<TD align="left" width="40%">
															<cc1:S_TextBox id="txtsNota" runat="server" MaxLength="2000" DBIndex="4" DBSize="2000" DBParameterName="p_Nota_Ric"
																Rows="2" TextMode="MultiLine" Width="100%"></cc1:S_TextBox></TD>
													</TR>
													<tr>
														<TD width="10%">Piano
															<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Selezionare un piano"
																ControlToValidate="cmbsPiano">*</asp:RequiredFieldValidator></TD>
														<TD align="left" width="20%">
															<cc1:s_combobox id="cmbsPiano" runat="server" Width="200px" DBIndex="17" DBSize="10" DBParameterName="p_id_piani"
																DBDataType="Integer" DBDirection="Input"></cc1:s_combobox></TD>
														<TD width="10%" colSpan="2">
															<uc1:UserStanze id="UserStanze1" runat="server"></uc1:UserStanze>
														</TD>
													</tr>
												</TABLE>
											</td>
										</TR>
										<TR>
											<TD align="left" colSpan="4"><asp:linkbutton id="lkbNonEmesse" runat="server" CausesValidation="False" CssClass="LabelInfo">Richieste non Emesse</asp:linkbutton></TD>
										</TR>
										<tr>
											<td><asp:panel id="pnlShowInfo" style="Z-INDEX: 100; POSITION: absolute; BACKGROUND-COLOR: gainsboro; DISPLAY: none; COLOR: #ffffff"
													runat="server" Width="100%">
													<TABLE width="100%" height="100%">
														<TR>
															<TD class="TitleSearch" vAlign="top" align="right">
																<asp:linkbutton id="lnkChiudi" runat="server" CssClass="LabelChiudi" CausesValidation="False">Chiudi</asp:linkbutton></TD>
														</TR>
														<TR>
															<TD>
																<asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" BorderColor="Gray" BorderWidth="1px"
																	AutoGenerateColumns="False" GridLines="Vertical" AllowPaging="True">
																	<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
																	<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
																	<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
																	<Columns>
																		<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
																		<asp:TemplateColumn>
																			<HeaderStyle Width="3%"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			<ItemTemplate>
																				<asp:ImageButton CausesValidation=False id="lnkNonEmesse" Runat=server CommandName="NonEmesse" ImageUrl="~/images/edit.gif" CommandArgument='<%# "EditCreazione.aspx?wr_id=" + DataBinder.Eval(Container.DataItem,"ID")%>'>
																				</asp:ImageButton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:BoundColumn DataField="ID" HeaderText="N. RDL"></asp:BoundColumn>
																		<asp:BoundColumn DataField="bl" HeaderText="EDIFICIO"></asp:BoundColumn>
																		<asp:BoundColumn DataField="Data" HeaderText="DATA RICHIESTA" DataFormatString="{0:d}"></asp:BoundColumn>
																		<asp:BoundColumn DataField="status" HeaderText="STATO"></asp:BoundColumn>
																		<asp:BoundColumn DataField="Descrizione" HeaderText="DESCRIZIONE"></asp:BoundColumn>
																		<asp:BoundColumn DataField="Richiedente" HeaderText="RICHIEDENTE"></asp:BoundColumn>
																	</Columns>
																	<PagerStyle Mode="NumericPages"></PagerStyle>
																</asp:datagrid></TD>
														</TR>
													</TABLE>
												</asp:panel><iframe id="DivShim" style="POSITION: absolute; DISPLAY: none" src="javascript:false;" frameBorder="0"
													scrolling="no"> </iframe>
											</td>
										</tr>
										<TR>
											<TD align="left" colSpan="4"><asp:linkbutton id="LinkApprovate" runat="server" CausesValidation="False" CssClass="LabelInfo">Richieste Approvate</asp:linkbutton></TD>
										</TR>
										<tr>
											<td><asp:panel id="PanelEmesse" style="Z-INDEX: 100; POSITION: absolute; BACKGROUND-COLOR: gainsboro; DISPLAY: none; COLOR: #ffffff"
													runat="server" Width="100%">
													<TABLE width="100%" height="100%">
														<TR>
															<TD class="TitleSearch" vAlign="top" align="right">
																<asp:linkbutton id="LinkChiudi2" runat="server" CssClass="LabelChiudi" CausesValidation="False">Chiudi</asp:linkbutton></TD>
														</TR>
														<TR>
															<TD>
																<asp:datagrid id="DatagridEmesse" runat="server" CssClass="DataGrid" BorderColor="Gray" BorderWidth="1px"
																	AutoGenerateColumns="False" GridLines="Vertical" AllowPaging="True">
																	<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
																	<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
																	<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
																	<Columns>
																		<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
																		<asp:TemplateColumn>
																			<HeaderStyle Width="3%"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			<ItemTemplate>
																				<asp:ImageButton CausesValidation=False id="lnlEmesse" Runat=server CommandName="Emesse" ImageUrl="~/images/edit.gif" CommandArgument='<%# "EditCreazione.aspx?wr_id=" + DataBinder.Eval(Container.DataItem,"ID") + "&c=true"%>'>
																				</asp:ImageButton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:BoundColumn DataField="ID" HeaderText="N. RDL"></asp:BoundColumn>
																		<asp:BoundColumn DataField="bl" HeaderText="EDIFICIO"></asp:BoundColumn>
																		<asp:BoundColumn DataField="Data" HeaderText="DATA RICHIESTA" DataFormatString="{0:d}"></asp:BoundColumn>
																		<asp:BoundColumn DataField="status" HeaderText="STATO"></asp:BoundColumn>
																		<asp:BoundColumn DataField="Descrizione" HeaderText="DESCRIZIONE"></asp:BoundColumn>
																		<asp:BoundColumn DataField="Richiedente" HeaderText="RICHIEDENTE"></asp:BoundColumn>
																	</Columns>
																	<PagerStyle Mode="NumericPages"></PagerStyle>
																</asp:datagrid></TD>
														</TR>
													</TABLE>
												</asp:panel><iframe id="DivEmesse" style="POSITION: absolute; DISPLAY: none" src="javascript:false;"
													frameBorder="0" scrolling="no"> </iframe>
											</td>
										</tr>
										<tr width="100%">
											<td align="left" width="100%">
												<asp:Button id="btsCodice" text="Visualizza Reperibilità" runat="server" Width="153" Height="22"></asp:Button><BR>
												<asp:textbox id="txtBL_ID" runat="server" Width="0px"></asp:textbox>
												<div id="PopupRep" style="BORDER-BOTTOM: #000000 1px solid; POSITION: absolute; BORDER-LEFT: #000000 1px solid; WIDTH: 100%; DISPLAY: none; HEIGHT: 200%; BORDER-TOP: #000000 1px solid; BORDER-RIGHT: #000000 1px solid"><IFRAME id="docRep" name="docRep" src="" frameBorder="no" width="100%"></IFRAME>
												</div>
											</td>
										</tr>
										<TR>
											<TD align="center" colSpan="4">
												<asp:panel id="PanelServizio" runat="server">
													<TABLE style="WIDTH: 100%" id="Table2" border="0" cellSpacing="1" cellPadding="1">
														<TR>
															<TD style="HEIGHT: 16px" width="15%">Servizio</TD>
															<TD style="HEIGHT: 16px" colSpan="5">
																<cc1:S_ComboBox id="cmbsServizio" runat="server" DBParameterName="p_Servizio_Id" DBSize="4" DBIndex="10"
																	Width="350px" DBDataType="Integer" AutoPostBack="True"></cc1:S_ComboBox></TD>
														</TR>
														<TR>
															<TD width="15%"><SPAN>Std. Apparecchiatura</SPAN></TD>
															<TD colSpan="5">
																<cc1:S_ComboBox id="cmbsApparecchiatura" runat="server" DBParameterName="p_Eqstd_Id" DBSize="4"
																	DBIndex="11" Width="350px" AutoPostBack="True"></cc1:S_ComboBox></TD>
														</TR>
													</TABLE>
												</asp:panel></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="4">
												<TABLE id="TableRicercaApparecchiatura" style="WIDTH: 100%" cellSpacing="1" cellPadding="1"
													border="0">
													<TBODY>
														<TR>
															<TD><uc1:codiceapparecchiature id="CodiceApparecchiature1" runat="server"></uc1:codiceapparecchiature></TD>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="4">
									<asp:panel id="PanelProblema" runat="server">
										<TABLE style="WIDTH: 100%" id="TableProblema" border="0" cellSpacing="1" cellPadding="1">
											<TR>
												<TD width="15%">Urgenza</TD>
												<TD colSpan="3">
													<cc1:S_ComboBox id="cmbsUrgenza" runat="server" DBParameterName="p_Priority" DBSize="4" DBIndex="12"
														Width="200px" DBDataType="Integer"></cc1:S_ComboBox></TD>
											</TR>
											<TR>
												<TD>Descrizione Problema<BR>
													Note</TD>
												<TD colSpan="3">
													<cc1:S_TextBox id="txtsProblema" runat="server" DBParameterName="p_Description" DBSize="4000" DBIndex="13"
														Width="100%" TextMode="MultiLine" Rows="4"></cc1:S_TextBox></TD>
											</TR>
											<TR>
												<TD>Email</TD>
												<TD width="30%">
													<asp:CheckBox id="chksSendMail" runat="server" Text="[Si/No]"></asp:CheckBox>
												<TD width="15%">Destinatari
												</TD>
												<TD>
													<asp:TextBox id="txtsMittente" runat="server" Width="100%" ToolTip="Gli indirizzi mail devono essere separati da ;">francesco.porreca@cofely-gdfsuez.com</asp:TextBox></TD>
											</TR>
											<TR>
												<TD>Data Richiesta
													<asp:RequiredFieldValidator id="rfvDataRichiesta" runat="server" ErrorMessage="Indicare la Data di Richiesta"
														ControlToValidate="txtsDataRichiesta">*</asp:RequiredFieldValidator></TD>
												<TD>
													<cc1:S_TextBox id="txtsDataRichiesta" runat="server" DBParameterName="p_Date_Requested" DBSize="10"
														DBIndex="14" MaxLength="10" ReadOnly="True"></cc1:S_TextBox></TD>
												<TD>Ora
													<asp:RequiredFieldValidator id="rfvOraRichiesta" runat="server" ErrorMessage="Indicare l'Ora di Richiesta" ControlToValidate="txtsOraRichiesta">*</asp:RequiredFieldValidator></TD>
												<TD>
													<cc1:S_TextBox id="txtsOraRichiesta" runat="server" DBParameterName="p_Time_Requested" DBSize="5"
														DBIndex="15" MaxLength="5" Width="50px" ReadOnly="True"></cc1:S_TextBox></TD>
											</TR>
										</TABLE>
									</asp:panel></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<!--messo io-->
				<TR>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
					<TD style="HEIGHT: 5%" vAlign="top" align="left" width="90%">
						<table border="0" width="100%">
							<tr>
								<td width="70%" align="left">
									<cc1:s_button id="btnsSalva" tabIndex="2" runat="server" Text="Salva"></cc1:s_button>
									&nbsp;<asp:button id="cmdReset" CausesValidation="False" Text="Reset" Runat="server"></asp:button>
								</td>
								<td width="25%" align="right">
									<A class=GuidaLink href="<%= HelpLink %>" target=_blank >Guida</A>
								</td>
								<td width="5%">&nbsp;</td>
							</tr>
						</table>
					</TD>
				<TR>
					<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
					<TD style="HEIGHT: 1%" vAlign="top" align="left">
						<hr noShade SIZE="1">
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblFirstAndLast" runat="server"></asp:label>&nbsp;
						<MESSPANEL:MESSAGEPANEL id="PanelMess" runat="server" ErrorIconUrl="~/Images/ico_critical.gif" MessageIconUrl="~/Images/ico_info.gif"></MESSPANEL:MESSAGEPANEL></TD>
				</TR>
			</TABLE>
			<asp:validationsummary id="vlsEdit" runat="server" ShowMessageBox="True" DisplayMode="List" ShowSummary="False"></asp:validationsummary></TD></TR></TBODY></TABLE>&nbsp;
		</form>
		<script language="javascript">parent.left.calcola();</script>
		<script language="javascript">
			parent.left.calcola();
		</script>
	</body>
</HTML>
