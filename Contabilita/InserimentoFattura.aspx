<%@ Page language="c#" Codebehind="InserimentoFattura.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Contabilita.InserimentoFattura" %>
<%@ Register TagPrefix="uc1" TagName="RicercaRDL" Src="../WebControls/RicercaRDL.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Edit Servizi</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
	
			function visualizzadettservizio(obj)
			{
				var selezione=obj.value;
				if(selezione == 1)
					{	
					/* panel per ordinaria*/
					TableOrdinaria.style.display = "block";
					TableStrardinaria.style.display = "none";
						
					}
				else if(selezione == 3)
					{
						/* Usercontrol Per straordinaria*/
					TableStrardinaria.style.display = "block";						
					TableOrdinaria.style.display = "none";
											
					}
				else 
				{
					TableOrdinaria.style.display = "none";
					TableStrardinaria.style.display = "none";
					/* nessuno dei due*/
				}
			}
					
			var NS4 = (navigator.appName == "Netscape" && parseInt(navigator.appVersion) < 5);
			var NSX = (navigator.appName == "Netscape");
			var IE4 = (document.all) ? true : false;
		
					
			
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
					
			//Impedisce di scatenare qualsiasi l'evento sulla pagina alla pressione del tasto invio
		
			function valutaenter(evt)
			{
				var e = evt? evt : window.event; 
				if(!e) return; 
				var key = 0; 
				
				if(IE4==true)
				{
					if (e.keyCode ==13)
					{
						e.keyCode = 0;
						return false;
					}	
				}
				        
				if (e.keycode)
				{ 
					key = e.keycode; 
				} // for moz/fb, if keycode==0 use 'which' 
				if (typeof(e.which)!= 'undefined')
				 { 
					key = e.which;
					if (key ==13)
					{
						return false;
					} 
							
				} 
			}
					
function formatta(fl){ 
 var ris;
 var tmp;
 fl=fl.toString(); 
 i = 0;  
 
   terza = fl.substring(i+2,i+3);
   ris = parseFloat(fl.substring(0,i+2));     
   if (terza>4)
   {
    ris = ris + parseFloat(0.011);
    ris=ris.toString();
 //   j=parseInt(ris.indexOf("."));
    tmp = parseFloat(ris.substring(0,2));    
    return tmp;
   }
   else
   {
    return ris;
   }
     
   
  ris = parseFloat(fl.substring(0,i+3));
  return ris;  
  
}


			function imposta_dec(obj)
				{
					val=document.getElementById(obj).value;
					if(val=="")
						document.getElementById(obj).value="00";
					else
					{
						var Imponibile = parseFloat(document.Form1.S_TxtImponibile.value +"."+document.Form1.S_TxtImponibileDec.value );
						var Impo = parseFloat(Imponibile/100);
						//var Impo = parseFloat(document.Form1.S_TxtImponibile.value/100);
						var Iva= document.Form1.S_TxtPercentuale.value;
						var totiva=(Impo * Iva);
						document.Form1.S_TxtTot.value = parseFloat(Imponibile + totiva);
						var str =document.Form1.S_TxtTot.value;
						var indice = str.indexOf(".");
						if (indice ==-1)
						document.Form1.S_TxtTot.value= str;
						else
						{
						document.Form1.S_TxtTot.value = str.substring(0,indice);
						var appo=str.substring(indice + 1, indice+4)
						document.Form1.S_TxtTotDec.value =formatta(appo);
						}
					}
					
					if(val.length==1)	
						document.getElementById(obj).value=val+"0";
				}

			function imposta_int(obj)
					{
						if(document.getElementById(obj).value=="")
							document.getElementById(obj).value="0";		
							else
						{
							var Imponibile = parseFloat(document.Form1.S_TxtImponibile.value +"."+document.Form1.S_TxtImponibileDec.value );
							var Impo = parseFloat(document.Form1.S_TxtImponibile.value/100);
							var Iva= parseFloat(document.Form1.S_TxtPercentuale.value);
							var totiva=(Impo * Iva);
							var tot =formatta(Imponibile + totiva)
							//document.Form1.S_TxtTot.value = parseFloat(Imponibile + totiva);
						var str = String(tot);
						var indice = str.indexOf(".");
						if (indice ==-1)
						document.Form1.S_TxtTot.value= str;
						else
						{
						document.Form1.S_TxtTot.value = str.substring(0,indice);
						document.Form1.S_TxtTotDec.value = str.substring(indice + 1, str.length);
						}
						}
						
					}	
					
					
			
			

		function deleteitem(sender,e)
	 {
		if (sender.selectedIndex!=-1) 
		{ 
		    if ((event.keyCode==46) && (window.confirm('Eliminare dalla ricerca la RdL selezionata?')))
			 {
				if (sender.options.length!=0) 
				{ 
				    var eledelete=sender.options[sender.selectedIndex].value;
				    var str=document.getElementById("rdl").value;
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
				    
					document.getElementById("rdl").value=arr.join(",");
					sender.options[sender.selectedIndex]=null 
				}
			 }
        } 
	 }
			
			
			
			
			
			
			
			
			function controllodata()
			{ 
				if (document.Form1.cmbsServizio.value==1)
				{
						var da;
						var a;
						da=document.Form1.cmbAnnoDa.value + document.Form1.cmbDaMese.value;
						a=document.Form1.cmbAnnoA.value + document.Form1.cmbAMese.value;
						if (da > a)
						{
							alert('Periodo iniziale ERRATO');
							return false;
						}
					//	else
					//	{
							//alert ('BRAVAAAA');
					//		return true;
					//	}
				}
											
			}
		</script>
</HEAD>
	<body onkeypress="if (valutaenter(event) == false) { return false; }" bottomMargin="0"
		leftMargin="5" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD align="left"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR vAlign="top" align="center" height="100%">
						<TD>
							<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" align="center">
								<TBODY>
									<TR>
										<TD style="WIDTH: 5%; HEIGHT: 5%" vAlign="top" align="left"></TD>
										<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" Width="544px" CssClass="TitleOperazione"></asp:label><cc2:messagepanel id="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"></cc2:messagepanel></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
										<TD style="HEIGHT: 1%" vAlign="top" align="left">
											<hr noShade SIZE="1">
										</TD>
									</TR>
									<TR>
										<TD vAlign="top" align="center"></TD>
										<TD vAlign="top" align="left"><asp:panel id="PanelEdit" runat="server" Width="100%">
												<TABLE id="tblSearch75" cellSpacing="1" cellPadding="2" border="0" width="100%">
													<TBODY>
														<TR>
															<TD style="WIDTH: 119px; HEIGHT: 20px" align="left">Intestatario</TD>
															<TD style="HEIGHT: 20px"><cc1:s_textbox id="S_TxtIntestatario" tabIndex="1" runat="server" Width="224px" DBSize="5" MaxLength="50"
																	DBIndex="2" DBParameterName="p_CODICE" DBDirection="Input"></cc1:s_textbox></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 119px; HEIGHT: 20px" align="left">Destinatario&nbsp;
															</TD>
															<TD style="HEIGHT: 20px"><cc1:s_textbox id="S_TxtDestinatario" tabIndex="1" runat="server" Width="224px" DBSize="5" MaxLength="50"
																	DBIndex="2" DBParameterName="p_CODICE" DBDirection="Input"></cc1:s_textbox></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 119px; HEIGHT: 24px" align="left">n° fattura</TD>
															<TD style="HEIGHT: 24px"><cc1:s_textbox id="S_TxtNumFattura" tabIndex="1" runat="server" Width="224px" DBSize="5" MaxLength="50"
																	DBIndex="2" DBParameterName="p_CODICE" DBDirection="Input"></cc1:s_textbox>
																<asp:RequiredFieldValidator id="RFVNumFattura" runat="server" Display="Dynamic" ErrorMessage="Inserire il numero fattura"
																	ControlToValidate="S_TxtNumFattura">*</asp:RequiredFieldValidator></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 119px; HEIGHT: 24px" align="left">Data Fattura&nbsp;
															</TD>
															<TD style="HEIGHT: 24px"><uc1:calendarpicker id="CalendarPicker1" runat="server"></uc1:calendarpicker></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 119px; HEIGHT: 23px" align="left">Scadenza Pagamento</TD>
															<TD><uc1:calendarpicker id="CalendarPicker2" runat="server"></uc1:calendarpicker></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 119px; HEIGHT: 19px" align="left">Tipo Servizio</TD>
															<TD style="HEIGHT: 19px"><cc1:s_combobox id="cmbsServizio" runat="server" DBIndex="3" DBParameterName="p_SETTORE" DBDirection="Input"
																	DBDataType="Integer" onChange="visualizzadettservizio(this);"></cc1:s_combobox>
																<asp:RequiredFieldValidator id="RFVTipoServizio" runat="server" ControlToValidate="cmbsServizio" ErrorMessage="Selezionare un Servizio"
																	Display="Dynamic" InitialValue="-1">*</asp:RequiredFieldValidator></TD>
														</TR>
														<TR>
															<td style="WIDTH: 119px"></td>
															<TD>
																<TABLE id="TableOrdinaria" runat="server">
																	<tr>
																		<td>Periodo Da:
																			<asp:dropdownlist id="cmbAnnoDa" runat="server">
																				<asp:ListItem Value="2004">2004</asp:ListItem>
																				<asp:ListItem Value="2005">2005</asp:ListItem>
																				<asp:ListItem Value="2006">2006</asp:ListItem>
																				<asp:ListItem Value="2007">2007</asp:ListItem>
																				<asp:ListItem Value="2008">2008</asp:ListItem>
																				<asp:ListItem Value="2009">2009</asp:ListItem>
																				<asp:ListItem Value="2010">2010</asp:ListItem>
																				<asp:ListItem Value="2011">2011</asp:ListItem>
																				<asp:ListItem Value="2012">2012</asp:ListItem>
																				<asp:ListItem Value="2013">2013</asp:ListItem>
																				<asp:ListItem Value="2014">2014</asp:ListItem>
																				<asp:ListItem Value="2015">2015</asp:ListItem>
																			</asp:dropdownlist><asp:dropdownlist id="cmbDaMese" runat="server">
																				<asp:ListItem Value="01">Gennaio</asp:ListItem>
																				<asp:ListItem Value="02">Febbraio</asp:ListItem>
																				<asp:ListItem Value="03">Marzo</asp:ListItem>
																				<asp:ListItem Value="04">Aprile</asp:ListItem>
																				<asp:ListItem Value="05">Maggio</asp:ListItem>
																				<asp:ListItem Value="06">Giugno</asp:ListItem>
																				<asp:ListItem Value="07">Luglio</asp:ListItem>
																				<asp:ListItem Value="08">Agosto</asp:ListItem>
																				<asp:ListItem Value="09">Settembre</asp:ListItem>
																				<asp:ListItem Value="10">Ottobre</asp:ListItem>
																				<asp:ListItem Value="11">Novembre</asp:ListItem>
																				<asp:ListItem Value="12">Dicembre</asp:ListItem>
																			</asp:dropdownlist></td>
																		<td>Periodo A:&nbsp;
																			<asp:dropdownlist id="cmbAnnoA" runat="server">
																				<asp:ListItem Value="2004">2004</asp:ListItem>
																				<asp:ListItem Value="2005">2005</asp:ListItem>
																				<asp:ListItem Value="2006">2006</asp:ListItem>
																				<asp:ListItem Value="2007">2007</asp:ListItem>
																				<asp:ListItem Value="2008">2008</asp:ListItem>
																				<asp:ListItem Value="2009">2009</asp:ListItem>
																				<asp:ListItem Value="2010">2010</asp:ListItem>
																				<asp:ListItem Value="2011">2011</asp:ListItem>
																				<asp:ListItem Value="2012">2012</asp:ListItem>
																				<asp:ListItem Value="2013">2013</asp:ListItem>
																				<asp:ListItem Value="2014">2014</asp:ListItem>
																				<asp:ListItem Value="2015">2015</asp:ListItem>
																			</asp:dropdownlist><asp:dropdownlist id="cmbAMese" runat="server">
																				<asp:ListItem Value="01">Gennaio</asp:ListItem>
																				<asp:ListItem Value="02">Febbraio</asp:ListItem>
																				<asp:ListItem Value="03">Marzo</asp:ListItem>
																				<asp:ListItem Value="04">Aprile</asp:ListItem>
																				<asp:ListItem Value="05">Maggio</asp:ListItem>
																				<asp:ListItem Value="06">Giugno</asp:ListItem>
																				<asp:ListItem Value="07">Luglio</asp:ListItem>
																				<asp:ListItem Value="08">Agosto</asp:ListItem>
																				<asp:ListItem Value="09">Settembre</asp:ListItem>
																				<asp:ListItem Value="10">Ottobre</asp:ListItem>
																				<asp:ListItem Value="11">Novembre</asp:ListItem>
																				<asp:ListItem Value="12">Dicembre</asp:ListItem>
																			</asp:dropdownlist></td>
																	</tr>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<td style="WIDTH: 119px"></td>
															<TD width="100%">
																<TABLE id="TableStrardinaria" runat="server">
																	<TBODY>
																		<tr>
																			<td><uc1:ricercardl id="RicercaRDL1" runat="server"></uc1:ricercardl></td>
																			<td><cc1:s_listbox id="S_ListRDL" runat="server" Width="144px"></cc1:s_listbox></td>
																		</tr>
																		<tr>
																			<td><INPUT id="rdl" type="hidden" name="rdl" runat="server">
																			</td>
																		</tr>
																	</TBODY>
																</TABLE>
															</TD>
														</TR>
									</TR>
									<TR>
										<TD style="WIDTH: 119px; HEIGHT: 38px" align="left">Descrizione</TD>
										<TD style="HEIGHT: 38px"><cc1:s_textbox id="S_TxtDescrizione" tabIndex="1" runat="server" Width="376px" DBSize="5" MaxLength="5"
												DBIndex="2" DBParameterName="p_CODICE" DBDirection="Input" TextMode="MultiLine" Height="80px"></cc1:s_textbox></TD>
									</TR>
									<asp:panel id="CampiModifica" runat="server" visible="False">
              <TR>
                <TD style="WIDTH: 119px; HEIGHT: 23px" align=left>Data 
                  Approvazione</TD>
                <TD style="HEIGHT: 23px">
<uc1:CalendarPicker id=CalendarPicker3 runat="server"></uc1:CalendarPicker></TD></TR>
              <TR>
                <TD style="WIDTH: 119px; HEIGHT: 23px" align=left>Data 
                  Pagamento</TD>
                <TD style="HEIGHT: 23px">
<uc1:CalendarPicker id=CalendarPicker4 runat="server"></uc1:CalendarPicker></TD></TR>
									</asp:panel>
									<TR>
										<TD style="WIDTH: 119px; HEIGHT: 24px" align="left">Imponibile €</TD>
										<TD style="HEIGHT: 24px"><cc1:s_textbox id="S_TxtImponibile" tabIndex="1" runat="server" Width="96px" DBSize="5" MaxLength="8"
												DBIndex="2" DBParameterName="p_CODICE" DBDirection="Input">0</cc1:s_textbox>,
											<cc1:s_textbox id="S_TxtImponibileDec" tabIndex="1" runat="server" Width="27px" DBSize="5" MaxLength="2"
												DBIndex="2" DBParameterName="p_CODICE" DBDirection="Input">00</cc1:s_textbox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 115px; HEIGHT: 30px" align="left">Iva</TD>
										<TD style="HEIGHT: 30px"><cc1:s_textbox id="S_TxtPercentuale" tabIndex="1" runat="server" Width="24px" DBSize="5" MaxLength="2"
												DBIndex="2" DBParameterName="p_CODICE" DBDirection="Input">0</cc1:s_textbox>%</TD>
									</TR>
									<TR>
										<TD align="left">Totale Fattura €</TD>
										<TD><cc1:s_textbox id="S_TxtTot" tabIndex="1" runat="server" Width="96px" DBSize="5" MaxLength="8"
												DBIndex="2" DBParameterName="p_CODICE" DBDirection="Input">0</cc1:s_textbox>,
											<cc1:s_textbox id="S_TxtTotDec" tabIndex="1" runat="server" Width="27px" DBSize="5" MaxLength="2"
												DBIndex="2" DBParameterName="p_CODICE" DBDirection="Input">00</cc1:s_textbox></TD>
									</TR>
								</TBODY>
							</TABLE></asp:panel></TD>
					</TR>
					<tr>
						<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
						<TD style="HEIGHT: 5%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="10" runat="server" CssClass="btn" Text="Salva"></cc1:s_button>&nbsp;
							<cc1:s_button id="btnsElimina" tabIndex="11" runat="server" CssClass="btn" Text="Elimina" CausesValidation="False"
								CommandType="Delete"></cc1:s_button>&nbsp;
							<asp:button id="btnAnnulla" tabIndex="12" runat="server" CssClass="btn" Text="Annulla" CausesValidation="False"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<A class=GuidaLink href="<%= HelpLink %>" 
        target=_blank>Guida</A></TD>
					</tr>
					<TR>
						<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
						<TD style="HEIGHT: 1%" vAlign="top" align="left">
							<hr noShade SIZE="1">
						</TD>
					</TR></TR>
					<TR>
						<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
						<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblFirstAndLast" runat="server"></asp:label></TD>
					</TR>
				</TBODY>
			</TABLE>
			<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></TD></TR></TBODY></TABLE></form>
	</body>
</HTML>
