<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Page language="c#" Codebehind="SfogliaFatture.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Contabilita.SfogliaFatture" %>
<%@ Register TagPrefix="uc1" TagName="RicercaRDL" Src="../WebControls/RicercaRDL.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Servizi</title>
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
					
			function imposta_dec(obj)
				{
					val=document.getElementById(obj).value;
					if(val=="")
						document.getElementById(obj).value="00";
					else
					{
						var Imponibile = parseFloat(document.Form1.S_TxtImponibile.value);
						var Impo = parseFloat(document.Form1.S_TxtImponibile.value/100);
						var Iva= document.Form1.S_TxtPercentuale.value;
						var totiva=(Impo * Iva);
						document.Form1.S_TxtTot.value = parseFloat(Imponibile + totiva);
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
							var Imponibile = parseFloat(document.Form1.S_TxtImponibile.value);
							var Impo = parseFloat(document.Form1.S_TxtImponibile.value/100);
							var Iva= document.Form1.S_TxtPercentuale.value;
							var totiva=(Impo * Iva);
							document.Form1.S_TxtTot.value = parseFloat(Imponibile + totiva);
						}
					}	
					
			function abilita()
			{ 
					document.Form1.cmbDaMese.Enabled = true;
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" height="100%">
						<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
							<TBODY>
								<TR>
									<TD style="HEIGHT: 25%" vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" TitleStyle-CssClass="TitleSearch" CssClass="DataPanel75"
											TitleText="Ricerca" AllowTitleExpandCollapse="True" Collapsed="False" ExpandText="Espandi" CollapseText="Riduci" CollapseImageUrl="../Images/up.gif"
											ExpandImageUrl="../Images/down.gif">
											<TABLE id="tblSearch100" cellSpacing="0" cellPadding="2" border="0">
												<TR>
													<TD style="WIDTH: 140px" align="left" width="140">Data Fattura Da</TD>
													<TD align="left"><uc1:calendarpicker id="CalendarPicker1" runat="server"></uc1:calendarpicker></TD>
													<TD style="WIDTH: 140px" align="left" width="140">Data Fattura A</TD>
													<TD width="30%"><uc1:calendarpicker id="CalendarPicker5" runat="server"></uc1:calendarpicker></TD>
												</TR>
												<TR>
													<TD>Scadenza Pagamento Da</TD>
													<TD><uc1:calendarpicker id="CalendarPicker2" runat="server"></uc1:calendarpicker></TD>
													<TD>Scadenza Pagamento Da</TD>
													<TD><uc1:calendarpicker id="CalendarPicker6" runat="server"></uc1:calendarpicker></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 153px" align="left" width="153">Data Approvazione Da</TD>
													<TD width="30%"><uc1:calendarpicker id="CalendarPicker3" runat="server"></uc1:calendarpicker></TD>
													<TD style="WIDTH: 153px" align="left" width="153">Data Approvazione A</TD>
													<TD width="30%"><uc1:calendarpicker id="CalendarPicker7" runat="server"></uc1:calendarpicker></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 140px" align="left" width="140">Data Pagamento DA</TD>
													<TD width="30%"><uc1:calendarpicker id="CalendarPicker4" runat="server"></uc1:calendarpicker></TD>
													<TD style="WIDTH: 140px" align="left" width="140">Data Pagamento A</TD>
													<TD width="30%"><uc1:calendarpicker id="CalendarPicker8" runat="server"></uc1:calendarpicker></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 140px" align="left" width="140">Numero Fattura</TD>
													<TD width="30%"><cc1:s_textbox id="S_TxtNumFattura" tabIndex="2" runat="server" MaxLength="255" DBSize="255" DBDirection="Input"
															DBParameterName="p_descrizione" DBIndex="0" DBDataType="VarChar" Width="96px"></cc1:s_textbox></TD>
												<TR>
													<TD style="WIDTH: 140px" align="left" width="140">Imponibile maggiore di</TD>
													<TD style="FONT-WEIGHT: bold" width="30%">€
														<cc1:s_textbox id="S_TxtImponibile" tabIndex="1" runat="server" MaxLength="5" DBSize="5" DBDirection="Input"
															DBParameterName="p_CODICE" DBIndex="2" Width="40px">0</cc1:s_textbox><cc1:s_textbox id="S_TxtImponibileDec" tabIndex="1" runat="server" MaxLength="2" DBSize="5" DBDirection="Input"
															DBParameterName="p_CODICE" DBIndex="2" Width="27px" Visible="False">00</cc1:s_textbox></TD>
												</TR>
												<!-- DA QUI-->
												<TR>
													<TD style="WIDTH: 140px" align="left" width="140">Tipo Servizio</TD>
													<TD width="30%"><cc1:s_combobox id="cmbsServizio" runat="server" DBDirection="Input" DBParameterName="p_SETTORE"
															DBIndex="3" DBDataType="Integer"></cc1:s_combobox></TD>
												</TR>
												<TR>
													<td colSpan="3"></td>
												</TR>
											</TABLE>
											<!--<TR>
												<TD style="WIDTH: 140px"></TD>
												<TD> -->
											<TABLE id="TableOrdinaria" runat="server">
												<TR>
													<TD>Periodo Fatturazione:</TD>
													<TD><asp:dropdownlist id="cmbAnnoDa" runat="server">
															<asp:ListItem Value="0000">Selezionare anno</asp:ListItem>
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
														</asp:dropdownlist></TD>
													<TD><asp:dropdownlist id="cmbDaMese" runat="server">
															<asp:ListItem Value="00">Selezionare Mese</asp:ListItem>
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
														</asp:dropdownlist></TD>
												</TR>
											</TABLE>
											<!--</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 140px"></TD>
									<TD>-->
											<TABLE id="TableStrardinaria" runat="server">
												<TR>
													<TD><uc1:ricercardl id="RicercaRDL1" runat="server"></uc1:ricercardl></TD>
													<TD><cc1:s_listbox id="S_ListRDL" runat="server" Width="144px"></cc1:s_listbox></TD>
												</TR>
												<TR>
													<TD><INPUT id="rdl" type="hidden" name="rdl" runat="server">
													</TD>
												</TR>
											</TABLE>
											<table cellSpacing="0" cellPadding="2" width="100%" border="0">
												<tr>
													<td colSpan="3"><cc1:s_button id="btnsRicerca" runat="server" CssClass="btn" Text="Ricerca"></cc1:s_button>&nbsp;
														<asp:button id="BtnReset" runat="server" CssClass="btn" Text="Reset"></asp:button></td>
													<TD align="right"><A class=GuidaLink 
                  href="<%= HelpLink %>" target=_blank 
                  >Guida</A>
													</TD>
												</tr>
											</table></TD>
					</TD>
				</TR>
				</COLLAPSE:DATAPANEL></TD></TR>
				<TR>
					<TD style="HEIGHT: 3%" align="center"></TD>
				<TR>
					<TD style="HEIGHT: 95%" vAlign="top" align="center">
						<uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AllowPaging="True" AutoGenerateColumns="False"
							GridLines="Vertical" BorderWidth="1px" BorderColor="Gray">
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="FATTURA_ID" HeaderText="ID"></asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="3%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton id=Imagebutton3 CommandArgument='<%# "InserimentoFattura.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"FATTURA_ID") + "&amp;FunId=" + FunId + "&amp;TipoOper=read"%>' ImageUrl="~/images/Search16x16_bianca.jpg" CommandName="Dettaglio" Runat="server">
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="3%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton id=Imagebutton2 CommandArgument='<%# "InserimentoFattura.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"FATTURA_ID") + "&amp;FunId=" + FunId + "&amp;TipoOper=write"%>' ImageUrl="~/images/edit.gif" CommandName="Dettaglio" Runat="server">
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="DATA_FATTURA" HeaderText="Data Fattura" DataFormatString="{0:d}">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NUMERO_FATTURA" HeaderText="Numero Fattura">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATA_SCADENZA_PAGAMENTO" HeaderText="Scad. Pag." DataFormatString="{0:d}">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="descrizione" HeaderText="Servizio">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="periodo_inizio_fattura" HeaderText="Periodo">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="periodo_fine_fattura" HeaderText="fine periodo">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="RdL Fatturate">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IMPONIBILE" HeaderText="Imponibile €" DataFormatString="{0:##,###.00}">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DESCRIZIONE_FATTURA" HeaderText="Descrizione">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATA_APPROVAZIONE" HeaderText="Data App" DataFormatString="{0:d}">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATA_PAGAMENTO" HeaderText="Data Pag" DataFormatString="{0:d}">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="tipomanutenzione_id" HeaderText="IDSERVIZIO">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
	</body>
</HTML>
