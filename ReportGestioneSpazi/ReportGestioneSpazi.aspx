<%@ Register TagPrefix="uc1" TagName="UserStanze" Src="../WebControls/UserStanze.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="ReportGestioneSpazi.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ReportGestioneSpazi.ReportGestioneSpazi" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ReportGestioneSpazi</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		
		
	function ApriPopUp(url)
	{	
		var windowW = 1024;  
		var windowH = 768;	
		W = window.open(url,'Rapporto','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width='+windowW+',height='+windowH+',align=center');			
	}
	
	 function deleteitem(sender,e)
	 {
		if (sender.selectedIndex!=-1) 
		{ 
		    if (((event.keyCode==46) || event.click) && (window.confirm('Eliminare dalla ricerca l\'edificio selezionato?')))
			 {
				if (sender.options.length!=0) 
				{ 
				    var eledelete=sender.options[sender.selectedIndex].value;
				    var str=document.getElementById("edifici").value;
				    var arr = new Array();
				    arr =str.split(",");
				    var arr2=new Array();
				    for (i = 0; i <= arr.length-1; i++)
					{
						if(arr[i] == eledelete)
						{
						 arr.splice(i,1); 
						}
				    }
				    
					document.getElementById("edifici").value=arr.join(",");
					sender.options[sender.selectedIndex]=null 
				}
			 }
        } 
	 }
	 
	 function deleteitem2(sender,e)
	 {
		if (sender.selectedIndex!=-1) 
		{ 
		    if (window.confirm('Eliminare dalla ricerca l\'edificio selezionato?'))
			 {
				if (sender.options.length!=0) 
				{ 
				    var eledelete=sender.options[sender.selectedIndex].value;
				    var str=document.getElementById("edifici").value;
				    var arr = new Array();
				    arr =str.split(",");
				    var arr2=new Array();
				    for (i = 0; i <= arr.length-1; i++)
					{
						if(arr[i] == eledelete)
						{
						 arr.splice(i,1); 
						}
				    }
				    
					document.getElementById("edifici").value=arr.join(",");
					sender.options[sender.selectedIndex]=null 
				}
			 }
        } 
	 }
	 
	 
	 function errorlist(sender)
	 {
	 var ctrl=document.getElementById(sender);
	 
	  if (ctrl.options.length==0) {
	    alert("Selezionare almeno un Edificio!");
        return false;
	  }else
	  {
	   return true;
	  }
	  
	 }
	 
	 function apri_ricerca_reparto(gruppo,descmat,id)
	{
		var	var1=document.getElementById(descmat).value;
		var W = window.open('../CommonPage/ListaReparto.aspx?utente=ALE&IdMat='+id+'&desc=' + var1 + '&IdTxt='+descmat+'&aa=richiesta_lavoro','vericacodice','width=600,height=400;status=yes')								
	}	
	function apri_ricerca_uso(gruppo,descmat,id)
	{
		var	var1=document.getElementById(descmat).value;
		var W = window.open('../CommonPage/ListaDestinazioneUso.aspx?utente=ALE&IdMat='+id+'&desc=' + var1 + '&IdTxt='+descmat+'&aa=richiesta_lavoro','vericacodice','width=600,height=400;status=yes')								
	}	
	
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:panel id="PanelPannelloRicerca" runat="server" Width="100%" Height="59px"> <!-- Pannello di ricerca -->
				<TABLE id="TableMain" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<TR>
						<TD style="HEIGHT: 50px" align="center">
							<uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<CC2:DATAPANEL id="DataPanel1" runat="server" CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch"
								Collapsed="False" TitleText="Filtri dei Dati" ExpandText="Espandi " ExpandImageUrl="../Images/down.gif"
								CollapseText="Espandi/Riduci" CollapseImageUrl="../Images/up.gif" AllowTitleExpandCollapse="True">
								<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
									<TR>
										<TD vAlign="top" align="left">&nbsp;
										</TD>
									</TR>
									<TR vAlign="top">
										<TD align="center">
											<TABLE class="tblSearch100Dettaglio" id="tabl" style="HEIGHT: 95px" cellSpacing="0" cellPadding="0"
												width="100%" border="0">
												<TR>
													<TD colSpan="2">
														<P>
															<uc1:RicercaModulo id="RicercaModulo1" runat="server"></uc1:RicercaModulo></P>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 18.34%"><SPAN>Piano:</SPAN></TD>
													<TD style="HEIGHT: 28px">
														<cc1:S_ComboBox id="cmbsPiano" runat="server" Width="392px"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 14.88%" colSpan="2">
														<uc1:UserStanze id="UserStanze1" runat="server"></uc1:UserStanze></TD>
													<TD style="HEIGHT: 28px"></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 158px; HEIGHT: 26px"><SPAN>Categoria:</SPAN></TD>
													<TD style="HEIGHT: 26px">
														<cc1:S_ComboBox id="cmbsCategoria" runat="server" Width="392px"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 158px; HEIGHT: 20px">Destinazione d'Uso:</TD>
													<TD style="HEIGHT: 20px">
														<cc1:S_TextBox id="s_txtDestinazione" runat="server" Width="344px"></cc1:S_TextBox>&nbsp;<INPUT class=btn id=bt_destinazione style="WIDTH: 32px; HEIGHT: 25px" onclick="apri_ricerca_uso('ADMIN','<%= descUso1 %>','<%= Usoid1 %>');" type=button value=... name=bt_destinazione></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 158px; HEIGHT: 27px">Reparto:</TD>
													<TD style="HEIGHT: 27px">
														<cc1:S_TextBox id="s_txtReparto" runat="server" Width="344px"></cc1:S_TextBox>&nbsp;<INPUT class=btn id=bt_reparto style="WIDTH: 32px; HEIGHT: 25px" onclick="apri_ricerca_reparto('ADMIN','<%= descRep%>','<%= id%>');" type=button value=... name=bt_reparto></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 158px; HEIGHT: 27px">mq stanza:</TD>
													<TD style="HEIGHT: 27px">
														<cc1:S_ComboBox id="cmbsConfronto" runat="server" Width="40px">
															<asp:ListItem Value="=" Selected="True">=</asp:ListItem>
															<asp:ListItem Value="&gt;=">&gt;</asp:ListItem>
															<asp:ListItem Value="&lt;=">&lt;</asp:ListItem>
														</cc1:S_ComboBox>
														<cc1:S_TextBox id="s_txtMq" runat="server" Width="112px"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 4px" align="center" colSpan="2">&nbsp; Edifici Selezionati <EM>(Fare 
															doppio click&nbsp;sugli elementi o selezionarli e premere 'Canc' per 
															cancellarli)</EM></TD>
												</TR>
												<TR>
													<TD align="center" colSpan="2">
														<cc1:S_ListBox id="S_ListEdifici" runat="server" Width="100%" DBDirection="Input" DBSize="100"></cc1:S_ListBox>&nbsp;
														<INPUT id="edifici" type="hidden" name="edifici" runat="server"> <INPUT id="edificidescription" type="hidden" name="edificidescription" runat="server">
													</TD>
												</TR>
												<TR>
													<TD align="left" colSpan="2">
														<TABLE id="Table1" style="WIDTH: 448px; HEIGHT: 19px" cellSpacing="0" cellPadding="0" width="448"
															border="0">
															<TR>
																<TD align="right">&nbsp;</TD>
																<TD>&nbsp; <A class=GuidaLink href="<%= HelpLink %>" 
                        target=_blank>Guida</A></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</CC2:DATAPANEL></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
				</TABLE> <!--Fine pannello di ricerca-->
				<TABLE id="tblSearch102" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD align="right" width="10%"><IMG src="../Images/Pie.png">&nbsp;</TD>
						<TD align="left" width="20%">
							<CC1:S_OPTIONBUTTON id="S_Misure" tabIndex="6" runat="server" checked="True" text="Grafico della Superficie Totale"
								groupname="Grkind"></CC1:S_OPTIONBUTTON></TD>
						<TD align="center" width="7%">&nbsp;<IMG src="../Images/Pie.png"></TD>
						<TD align="left" width="26%">
							<CC1:S_OPTIONBUTTON id="S_Categorie" tabIndex="5" runat="server" text="Grafico della Superficie Utile per Categoria"
								groupname="Grkind"></CC1:S_OPTIONBUTTON></TD>
					</TR>
					<TR>
						<TD align="right" width="10%"><IMG src="../Images/GraficiIstogramma.png">&nbsp;</TD>
						<TD align="left" width="20%">
							<CC1:S_OPTIONBUTTON id="S_Reparti" tabIndex="3" runat="server" text="Grafico della Superficie Utile per Reparto"
								groupname="Grkind"></CC1:S_OPTIONBUTTON></TD>
						<TD align="center" width="7%"><IMG src="../Images/GraficiIstogramma.png">&nbsp;</TD>
						<TD align="left" width="26%">
							<CC1:S_OPTIONBUTTON id="S_Destinazione" tabIndex="4" runat="server" text="Grafico della Superficie Utile per Destinazione d'Uso"
								groupname="Grkind"></CC1:S_OPTIONBUTTON></TD>
					</TR>
					<TR>
						<TD align="right" width="10%">&nbsp;</TD>
						<TD align="left" width="20%"></TD>
						<TD align="center" width="7%">&nbsp;</TD>
						<TD align="left" width="26%"></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="6">
							<TABLE id="tblSubmit" cellSpacing="1" cellPadding="1" width="20%" align="center" border="0">
								<TR>
									<TD noWrap align="left">
										<CC1:S_BUTTON id="S_BtnSubmit" tabIndex="9" runat="server" text="Genera il Report in Html" width="150px"
											cssclass="btn"></CC1:S_BUTTON></TD>
									<TD>
										<ASP:BUTTON id="btnReportPdf" runat="server" text="Genera il Report In Pdf" width="150px" cssclass="btn"></ASP:BUTTON></TD>
									<TD noWrap align="left"><INPUT class="btn" id="Reset1" style="WIDTH: 150px" tabIndex="10" type="reset" value="Reset"
											name="Reset1" runat="server">
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
