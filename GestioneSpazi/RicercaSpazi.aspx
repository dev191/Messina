<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Page language="c#" Codebehind="RicercaSpazi.aspx.cs" AutoEventWireup="false" Inherits="TheSite.GestioneSpazi.RicercaSpazi"  TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="UserStanze" Src="../WebControls/UserStanze.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RicercaSpazi</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
	 function SelCheckbox(chk){
       
	   var chk_Edif=document.getElementById('<%=chkEdificio.ClientID%>');
	   var chk_Piano=document.getElementById('<%=chkPiano.ClientID%>');
	   var chk_Stanze=document.getElementById('<%=chkStanze.ClientID%>');
	   var chk_Categoria=document.getElementById('<%=chkCategoria.ClientID%>');
	   var chk_Destinazione=document.getElementById('<%=chkDestinazione.ClientID%>');
	   var chk_Reparto=document.getElementById('<%=chkReparto.ClientID%>');
	   var chkattiva=document.getElementById('<%=chk_attiva.ClientID%>');
	   if (chkattiva.checked==true)
	   {
	     chk_Edif.checked=true;
	     chk_Piano.checked=true;
	     chk_Stanze.checked=true;
	     chk_Categoria.checked=true;
	     chk_Destinazione.checked=true;
	     chk_Reparto.checked=true;
	   }
	   else
	   {
	     chk_Edif.checked=false;
	     chk_Piano.checked=false;
	     chk_Stanze.checked=false;
	     chk_Categoria.checked=false;
	     chk_Destinazione.checked=false;
	     chk_Reparto.checked=false;
	   }
	   
	}	
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
				    var arr1 = new Array();
				    var str1= document.getElementById("edificidescription").value;
				    arr =str.split(",");
				    arr1 =str1.split("$");
				   
				    for (i = 0; i <= arr.length-1; i++)
					{
						if(arr[i] == eledelete)
						{
						 arr.splice(i,1);
						}
				    }
				    for (i = 0; i <= arr1.length-1; i++)
					{
					   var idp=arr1[i].indexOf("(");
					   var ida =arr1[i].indexOf(")");
						if(arr1[i].substring(idp + 1,ida) == eledelete)
						{
						 arr1.splice(i,1);
						}
				    }
				    
					document.getElementById("edifici").value=arr.join(",");
					document.getElementById("edificidescription").value=arr1.join("$");
					sender.options[sender.selectedIndex]=null 
				}
			 }
        } 
	 }
	/* function errorlist(sender)
	 {
	 var ctrl=document.getElementById(sender);
	 
	  if (ctrl.options.length==0) {
	    alert("Selezionare almeno un Edificio!");
        return false;
	  }else
	  {
	   return true;
	  }
	  
	 }*/
	 
	 function apri_ricerca_reparto(gruppo,descmat,id)
	{
		var	var1=document.getElementById(descmat).value;
		var W = window.open('../CommonPage/ListaReparto.aspx?utente=ALE&chiamante=Spazi&IdMat='+id+'&desc=' + var1 + '&IdTxt='+descmat+'&aa=richiesta_lavoro','vericacodice','width=600,height=400;status=yes')								
	}	
	function apri_ricerca_uso(gruppo,descmat,id)
	{
		var	var1=document.getElementById(descmat).value;
		var W = window.open('../CommonPage/ListaDestinazioneUso.aspx?utente=ALE&chiamante=Spazi&IdMat='+id+'&desc=' + var1 + '&IdTxt='+descmat+'&aa=richiesta_lavoro','vericacodice','width=600,height=400;status=yes')								
	}	
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center"><cc2:datapanel id="DataPanel1" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
							TitleText="Ricerca " ExpandText="Espandi " ExpandImageUrl="../Images/downarrows_trans.gif" CollapseText="Espandi/Riduci"
							CssClass="DataPanel75" CollapseImageUrl="../Images/uparrows_trans.gif" AllowTitleExpandCollapse="True">
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
														<uc1:RicercaModulo id="RicercaModulo1" runat="server"></uc1:RicercaModulo>&nbsp;<INPUT id="chkEdificio" type="checkbox" name="chkEdificio" runat="server">Spuntare 
														per visualizzare il campo nella lista</P>
												</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 14.88%"><SPAN>Piano:</SPAN></TD>
												<TD style="HEIGHT: 28px">
													<cc1:S_ComboBox id="cmbsPiano" runat="server" Width="392px"></cc1:S_ComboBox><INPUT id="chkPiano" type="checkbox" name="chkPiano" runat="server">Spuntare 
													per visualizzare il campo nella lista</TD>
											</TR>
											<TR>
												<TD colSpan="2">
													<TABLE width="100%" border="0">
														<TR>
															<TD>
																<uc1:UserStanze id="UserStanze1" runat="server"></uc1:UserStanze></TD>
															<TD><INPUT id="chkStanze" type="checkbox" name="chkStanze" runat="server">Spuntare 
																per visualizzare il campo nella lista</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 131px; HEIGHT: 26px"><SPAN>Categoria:</SPAN></TD>
												<TD style="HEIGHT: 26px">
													<cc1:S_ComboBox id="cmbsCategoria" runat="server" Width="392px"></cc1:S_ComboBox><INPUT id="chkCategoria" type="checkbox" name="chkCategoria" runat="server">Spuntare 
													per visualizzare il campo nella lista</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 131px; HEIGHT: 20px">Destinazione d'uso:</TD>
												<TD style="HEIGHT: 20px">
													<cc1:S_TextBox id="s_txtDestinazione" runat="server" Width="344px"></cc1:S_TextBox>&nbsp;<INPUT class=btn id=bt_destinazione style="WIDTH: 32px; HEIGHT: 25px" onclick="apri_ricerca_uso('ADMIN','<%= descUso1 %>','<%= Usoid1 %>');" type=button value=... name=bt_destinazione><INPUT id="chkDestinazione" type="checkbox" name="chkDestinazione" runat="server">Spuntare 
													per visualizzare il campo nella lista</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 131px; HEIGHT: 27px">Reparto:</TD>
												<TD style="HEIGHT: 27px">
													<cc1:S_TextBox id="s_txtReparto" runat="server" Width="344px"></cc1:S_TextBox>&nbsp;<INPUT class=btn id=bt_reparto style="WIDTH: 32px; HEIGHT: 25px" onclick="apri_ricerca_reparto('ADMIN','<%= descRep%>','<%= id%>');" type=button value=... name=bt_reparto><INPUT id="chkReparto" type="checkbox" name="chkReparto" runat="server">Spuntare 
													per visualizzare il campo nella lista</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 131px; HEIGHT: 27px">Mq2:</TD>
												<TD style="HEIGHT: 27px">
													<cc1:S_ComboBox id="cmbsConfronto" runat="server" Width="40px">
														<ASP:LISTITEM Selected="True" Value="=">=</ASP:LISTITEM>
														<ASP:LISTITEM Value=">">&gt;</ASP:LISTITEM>
														<ASP:LISTITEM Value="<">&lt;</ASP:LISTITEM>
													</cc1:S_ComboBox>
													<cc1:S_TextBox id="s_txtMq" runat="server" Width="112px"></cc1:S_TextBox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 4px" align="center" colSpan="2">&nbsp; Edifici Selezionati
												</TD>
											</TR>
											<TR>
												<TD align="center" colSpan="2">
													<cc1:S_ListBox id="S_ListEdifici" runat="server" Width="100%" DBDirection="Input" DBSize="100"></cc1:S_ListBox>&nbsp;
													<INPUT id="edifici" type="hidden" name="edifici" runat="server"> <INPUT id="edificidescription" type="hidden" name="edificidescription" runat="server">
												</TD>
											</TR>
											<TR>
												<TD align="left" colSpan="2">
													<TABLE id="Table1" style="WIDTH: 100%; HEIGHT: 19px" cellSpacing="0" cellPadding="0" width="448"
														border="0">
														<TR>
															<TD align="right">
																<cc1:S_Button id="S_btMostra" runat="server" CssClass="btn" Width="134px" ToolTip="Avvia la ricerca"
																	Text="Mostra Dettagli"></cc1:S_Button>&nbsp;</TD>
															<TD style="WIDTH: 159px">&nbsp;
																<cc1:S_Button id="btReset" runat="server" CssClass="btn" Width="134px" ToolTip="Rimposta i criteri di ricerca"
																	Text="Reset"></cc1:S_Button></TD>
															<TD align="left">&nbsp; <INPUT id="chk_attiva" onclick="SelCheckbox(this);" type="checkbox" name="chk_attiva" runat="server">
																Seleziona tutti</TD>
															<TD align="right"><A class=GuidaLink 
                        href="<%= HelpLink %>" 
                    target=_blank>Guida</A></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</cc2:datapanel></TD>
				</TR>
				<TR>
					<TD><asp:panel id="Panel1" runat="server" Height="7px">
							<uc1:GridTitle id="GridTitle1" runat="server"></uc1:GridTitle>
							<asp:DataGrid id="DtgRicercaSpazi" runat="server" CssClass="DataGrid" Width="100%" AllowCustomPaging="True"
								ShowFooter="True" BorderColor="Gray" BorderStyle="None" BorderWidth="1px" BackColor="White"
								CellPadding="4" AutoGenerateColumns="False" AllowPaging="True" GridLines="Vertical" PageSize="20">
								<FooterStyle ForeColor="#003399" BackColor="White"></FooterStyle>
								<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
								<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="EDIFICIO" HeaderText="Cod.Edificio"></asp:BoundColumn>
									<asp:BoundColumn DataField="PIANO" HeaderText="Piano"></asp:BoundColumn>
									<asp:BoundColumn DataField="STANZA" HeaderText="Stanza"></asp:BoundColumn>
									<asp:BoundColumn DataField="CATEGORIA" HeaderText="Categoria"></asp:BoundColumn>
									<asp:BoundColumn DataField="DESTINAZIONE" HeaderText="Destinazione"></asp:BoundColumn>
									<asp:BoundColumn DataField="REPARTO" HeaderText="Reparto"></asp:BoundColumn>
									<asp:BoundColumn DataField="VALORE_INT" HeaderText="Mq" DataFormatString="{0:#,##0.00}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" CssClass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
						</asp:panel></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
