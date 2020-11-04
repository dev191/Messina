<%@ Page language="c#" Codebehind="NavigazioneServizi.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.NavigazioneServizi" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NavigazioneDocumenti</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
	 function deleteitem(sender,e)
	 {
		if (sender.selectedIndex!=-1) 
		{ 
		    if ((event.keyCode==46) && (window.confirm('Eliminare dalla ricerca l\'edificio selezionato?')))
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
		</script>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center">
						<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<cc2:DataPanel id="DataPanel1" runat="server" AllowTitleExpandCollapse="True" CollapseImageUrl="../Images/up.gif"
							CssClass="DataPanel75" CollapseText="Espandi/Riduci" ExpandImageUrl="../Images/down.gif" ExpandText="Espandi "
							TitleText="Ricerca " Collapsed="False" TitleStyle-CssClass="TitleSearch">
							<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
								<TR>
									<TD vAlign="top" align="left">
										<cc1:S_Label id="lblComuneDescrizione" runat="server" Visible="False">Comune selezionato: </cc1:S_Label>
										<cc1:S_Label id="lblComune" runat="server"></cc1:S_Label>&nbsp;
										<cc1:S_Label id="lblFrazioneDescrizione" runat="server" Visible="False">Frazione: </cc1:S_Label>
										<cc1:S_Label id="lblFrazione" runat="server"></cc1:S_Label></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<uc1:RicercaModulo id="RicercaModulo1" runat="server"></uc1:RicercaModulo></TD>
								</TR>
								<TR vAlign="top">
									<TD align="center">
										<TABLE class="tblSearch100Dettaglio" id="tabl" style="HEIGHT: 95px" cellSpacing="0" cellPadding="0"
											width="100%" border="0">
											<TR>
												<TD style="WIDTH: 14.88%"><SPAN>Servizio: </SPAN>
												</TD>
												<TD style="HEIGHT: 28px">
													<cc1:S_ComboBox id="cmbsServizio" runat="server" AutoPostBack="True" Width="392px"></cc1:S_ComboBox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 131px; HEIGHT: 26px"><SPAN>Std. Apparecchiatura:</SPAN>
												</TD>
												<TD style="HEIGHT: 26px">
													<cc1:S_ComboBox id="cmbsApparecchiatura" runat="server" Width="392px"></cc1:S_ComboBox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 4px" align="center" colSpan="2">&nbsp; Edifici Selezionati
												</TD>
											</TR>
											<TR>
												<TD align="center" colSpan="2">
													<cc1:S_ListBox id="S_ListEdifici" runat="server" Width="100%" DBSize="100" DBDirection="Input"></cc1:S_ListBox>&nbsp;
													<INPUT id="edifici" type="hidden" name="edifici" runat="server"> <INPUT id="edificidescription" type="hidden" name="edificidescription" runat="server">
												</TD>
											</TR>
											<TR>
												<TD align="left" colSpan="2">
													<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD style="WIDTH: 239px" align="right">
																<cc1:S_Button id="S_btMostra" runat="server" CssClass="btn" Width="134px" Text="Mostra Dettagli"
																	ToolTip="Avvia la ricerca"></cc1:S_Button>&nbsp;</TD>
															<TD style="WIDTH: 398px">&nbsp;
																<cc1:S_Button id="btReset" runat="server" CssClass="btn" Width="134px" Text="Reset" ToolTip="Rimposta i criteri di ricerca"
																	CausesValidation="False"></cc1:S_Button>&nbsp;</TD>
															<TD align="right">&nbsp;<A class=GuidaLink 
                        href="<%= HelpLink %>" target=_blank>Guida</A>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</cc2:DataPanel>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Panel id="Panel1" runat="server" Height="480px">
							<TABLE class="tblSearch100Dettaglio" id="Tabletreview" height="100%" cellSpacing="1" cellPadding="1"
								width="100%" border="0">
								<TR height="100%">
									<TD style="WIDTH: 10%" vAlign="top">
										<iewc:treeview id="TreeCtrl" runat="server" Width="250" Height="100%" EnableViewState="False"></iewc:treeview></TD>
									<TD style="WIDTH: 90%" vAlign="top"><IFRAME class="fram" id="doctrevew" style="WIDTH: 100%; HEIGHT: 100%" name="doctrevew" frameBorder="no"
											width="100%" scrolling="auto" height="100%" runat="server"></IFRAME>
									</TD>
								</TR>
							</TABLE>
						</asp:Panel>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
