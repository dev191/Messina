<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Addetti" Src="../WebControls/Addetti.ascx" %>
<%@ Page language="c#" Codebehind="SfogliaRdl.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorrettiva.SfogliaRdl" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SfogliaRdl</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		var NS4 = (navigator.appName == "Netscape" && parseInt(navigator.appVersion) < 5);
		var NSX = (navigator.appName == "Netscape");
		var IE4 = (document.all) ? true : false;
			
		
	function Visualizza(Stato)
	{
	   	   
	    var crtl;
		switch (Stato)
		{
			case "3": //Straordinaria
			    crtl=document.getElementById("tabletipointervento").style; 
				crtl.display="block";
				crtl=document.getElementById("tabletipointervento2").style; 
				crtl.display="block";
			    crtl=document.getElementById("trdate").style; 
				crtl.display="block";				
				break;
			case "1": //Ordinaria	
			    crtl=document.getElementById("tabletipointervento").style; 
				crtl.display="none";
				crtl=document.getElementById("tabletipointervento2").style; 
				crtl.display="none";
			    crtl=document.getElementById("trdate").style; 
				crtl.display="none";				
				break;
			default:
			    crtl=document.getElementById("tabletipointervento").style; 
				crtl.display="none";
				crtl=document.getElementById("tabletipointervento2").style; 
				crtl.display="none";
			    crtl=document.getElementById("trdate").style; 
				crtl.display="none";								
				break;
		}		
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
			
		  //Impedisce di scatenare qualsiasi l'evento sulla pagina alla pressione del tasto invio
	   function valutaenter(evt)
			{
				var e = evt? evt : window.event; 
				if(!e) return; 
				var key = 0; 
				
				if(IE4==true)
				{
					if (e.keyCode ==13){
						e.keyCode = 0;
						return false;
					}	
		        }
		        
				if (e.keycode) { key = e.keycode; } // for moz/fb, if keycode==0 use 'which' 
				if (typeof(e.which)!= 'undefined') { 
					key = e.which;
					if (key ==13){
						return false;
					} 
					
				} 
			}
 var finestra;		
 
 function openpdf(sender,path,namefile)
 {
   var url;		
   namefile=namefile.replace("`","'");   
   url = "Visualpdf.aspx?wr_id=" + sender + "&path=" + path + "&name=" +namefile;
   finestra=window.open(url,'','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width=800,height=600,align=center');	
 }	
 
 function chiudi()
 {
   if (finestra!=null)
		      finestra.close();
 }
		</script>
	</HEAD>
	<body onkeypress="if (valutaenter(event) == false) { return false; }" bottomMargin="0"
		onbeforeunload="chiudi();parent.left.valorizza()" leftMargin="5" topMargin="0" rightMargin="0"
		MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" title="Sfoglia RdL e Odl" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" height="95%">
							<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
								<TBODY>
									<TR>
										<TD style="HEIGHT: 25%" vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" ExpandImageUrl="../Images/down.gif" CollapseImageUrl="../Images/up.gif"
												CollapseText="Riduci" ExpandText="Espandi" Collapsed="False" AllowTitleExpandCollapse="True" TitleText="Ricerca" CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch">
												<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
													<TR>
														<TD align="left" colSpan="4">
															<uc1:RicercaModulo id="RicercaModulo1" runat="server"></uc1:RicercaModulo></TD>
													</TR>
													<TR>
														<TD align="left" width="13%">Richiesta di Lavoro:</TD>
														<TD width="30%">
															<cc1:s_textbox id="txtsRichiesta" runat="server" DBIndex="2" DBDataType="Integer" MaxLength="10"
																DBSize="255" width="100px" DBDirection="Input" DBParameterName="p_Wr_Id"></cc1:s_textbox></TD>
														<TD align="left" width="15%">Addetto:</TD>
														<TD width="30%">
															<uc1:Addetti id="Addetti1" runat="server"></uc1:Addetti></TD>
													</TR>
													<TR>
														<TD align="left">Data Da:</TD>
														<TD>
															<uc1:CalendarPicker id="CalendarPicker1" runat="server"></uc1:CalendarPicker></TD>
														<TD align="left">Data A:</TD>
														<TD>
															<uc1:CalendarPicker id="CalendarPicker2" runat="server"></uc1:CalendarPicker>
															<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Data non valida!" Operator="GreaterThanEqual"
																Type="Date" Display="Dynamic"></asp:CompareValidator></TD>
													</TR>
													<TR>
														<TD align="left">Ordine di Lavoro:</TD>
														<TD>
															<cc1:s_textbox id="txtsOrdine" runat="server" MaxLength="10" DBSize="255" width="100px" DBDirection="Input"
																DBParameterName="p_Wr_Id"></cc1:s_textbox></TD>
														<TD align="left">Stato Richiesta:</TD>
														<TD>
															<cc1:S_ComboBox id="cmbsStatus" runat="server" Width="99%"></cc1:S_ComboBox></TD>
													</TR>
													<TR>
														<TD align="left">Servizio:</TD>
														<TD>
															<cc1:S_ComboBox id="cmbsServizio" runat="server" Width="99%"></cc1:S_ComboBox></TD>
														<TD align="left">Gruppo:</TD>
														<TD>
															<cc1:S_ComboBox id="cmbsGruppo" runat="server" Width="99%"></cc1:S_ComboBox></TD>
													</TR>
													<TR>
														<TD align="left">Richiedente:</TD>
														<TD>
															<uc1:Richiedenti id="Richiedenti1" runat="server"></uc1:Richiedenti></TD>
														<TD align="left">Urgenza:</TD>
														<TD>
															<cc1:S_ComboBox id="cmbsUrgenza" runat="server" Width="99%"></cc1:S_ComboBox></TD>
													</TR>
													<TR>
														<TD align="left" colSpan="1">Descrizione:</TD>
														<TD colSpan="3">
															<cc1:s_textbox id="txtDescrizione" runat="server" MaxLength="255" DBSize="255" width="99%" DBDirection="Input"
																DBParameterName="p_Wr_Id"></cc1:s_textbox></TD>
													</TR>
													<TR>
														<TD align="left">Tipo Manutenzione:</TD>
														<TD>
															<cc1:S_ComboBox id="cmbsTipoManutenzione" runat="server" Width="99%"></cc1:S_ComboBox></TD>
														<TD>Validazione:</TD>
														<TD>
															<cc1:S_ComboBox id="cmbsvalidazione" runat="server" DBIndex="8" DBDataType="Integer" DBDirection="Input"
																DBParameterName="p_validazione" Width="75%">
																<asp:ListItem Value="0">Tutte le Richieste</asp:ListItem>
																<asp:ListItem Value="1">Richieste non ancora validate</asp:ListItem>
																<asp:ListItem Value="2">Richieste validate DL</asp:ListItem>
																<asp:ListItem Value="3">Approvate DL</asp:ListItem>
																<asp:ListItem Value="4">Rifiutate DL</asp:ListItem>
															</cc1:S_ComboBox></TD>
														<TD id="tabletipointervento" style="DISPLAY: none">Tipo Intervento:</TD>
														<TD id="tabletipointervento2" style="DISPLAY: none">
															<cc1:S_ComboBox id="cmbsTipoIntervento" runat="server" Width="99%"></cc1:S_ComboBox></TD>
													</TR>
													<TR id="trdate" style="DISPLAY: none">
														<TD align="left">Data Privista Inizio:</TD>
														<TD>
															<uc1:CalendarPicker id="CalendarPicker3" runat="server"></uc1:CalendarPicker></TD>
														<TD align="left">Data Prevista Fine:</TD>
														<TD>
															<uc1:CalendarPicker id="CalendarPicker4" runat="server"></uc1:CalendarPicker></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 16px" align="left" colSpan="4"></TD>
													</TR>
													<TR>
														<TD align="left" colSpan="3">
															<cc1:s_button id="btnsRicerca" runat="server" Text="Ricerca"></cc1:s_button>&nbsp;
															<asp:Button id="cmdReset" Text="Reset" Runat="server"></asp:Button>&nbsp;
															<cc1:s_button id="cmdExcel" tabIndex="2" runat="server" Text="Esporta"></cc1:s_button>
															<asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD>
														<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
													</TR>
												</TABLE>
											</COLLAPSE:DATAPANEL></TD>
									</TR>
									<tr>
										<TD align="center"></TD>
									</tr>
									<TR id="trstraordinaria">
										<TD vAlign="top" align="center" width="100%"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AutoGenerateColumns="False"
												GridLines="Vertical" BorderWidth="1px" BorderColor="Gray" AllowPaging="True" ShowFooter="True">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="WR_ID" HeaderText="ID"></asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:ImageButton id="lnkDett" Runat="server" CommandName="Dettaglio" ImageUrl="../images/edit.gif" CommandArgument='<%# "EditSfoglia.aspx?wr_id=" + DataBinder.Eval(Container.DataItem,"WR_ID")%>'>
															</asp:ImageButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:ImageButton id="Imagebutton2" Runat="server" CommandName="Modifica" ImageUrl="../images/Search16x16_bianca.JPG" CommandArgument='<%# "ModificaRdl.aspx?ItemId=" + DataBinder.Eval(Container.DataItem,"WR_ID")%>'>
															</asp:ImageButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Prev.">
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<a href="" runat="server" id="linkpreve"></a>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn Visible="False" HeaderText="Cons.">
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<a href="" runat="server" id="linkconsu"></a>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="WR_ID" HeaderText="Rdl"></asp:BoundColumn>
													<asp:BoundColumn DataField="ordineater" HeaderText="Odl UNIBA"></asp:BoundColumn>
													<asp:BoundColumn DataField="INDIRIZZO" HeaderText="Impianto"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="WO_ID" HeaderText="OdL"></asp:BoundColumn>
													<asp:BoundColumn DataField="addetto" HeaderText="Addetto"></asp:BoundColumn>
													<asp:BoundColumn DataField="stato" HeaderText="Stato"></asp:BoundColumn>
													<asp:BoundColumn DataField="tipointerventoater" HeaderText="Tipo Intervento"></asp:BoundColumn>
													<asp:BoundColumn DataField="importostimato" HeaderText="Importo Stimato" DataFormatString="{0:C}">
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="importoconsuntivo" HeaderText="Importo Consuntivo" DataFormatString="{0:C}">
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn Visible="False">
														<HeaderStyle Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:ImageButton Visible="false" id="imgCostiStra" Runat="server" CommandName="Modifica" ImageUrl="../Images/kcalc.jpg" CommandArgument='<%# "../CostiOperativi/CostiOperativi.aspx?ItemId=" + DataBinder.Eval(Container.DataItem,"WR_ID") + "&TipoManId =" + DataBinder.Eval(Container.DataItem,"tipomanutenzione_id")%>'>
															</asp:ImageButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="id_stato" HeaderText="idstato"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="tipomanutenzione_id" HeaderText="idstato"></asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
									<TR id="trrichiesta">
										<TD vAlign="top" align="center" width="100%"><uc1:gridtitle id="Gridtitle2" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca2" runat="server" CssClass="DataGrid" AutoGenerateColumns="False"
												GridLines="Vertical" BorderWidth="1px" BorderColor="Gray" AllowPaging="True">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="false" DataField="WR_ID" HeaderText="ID"></asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:ImageButton id="Imagebutton1" Runat="server" CommandName="Dettaglio" ImageUrl="~/images/edit.gif" CommandArgument='<%# "EditSfoglia.aspx?wr_id=" + DataBinder.Eval(Container.DataItem,"WR_ID") %>'>
															</asp:ImageButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:ImageButton id="Imagebutton3" Runat="server" CommandName="Modifica" ImageUrl="../images/Search16x16_bianca.JPG" CommandArgument='<%# "ModificaRdl.aspx?ItemId=" + DataBinder.Eval(Container.DataItem,"WR_ID")%>'>
															</asp:ImageButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="INDIRIZZO" HeaderText="Indirizzo"></asp:BoundColumn>
													<asp:BoundColumn DataField="WO_ID" HeaderText="OdL"></asp:BoundColumn>
													<asp:BoundColumn DataField="DATA_WO" HeaderText="Data Emissione" DataFormatString="{0:d}"></asp:BoundColumn>
													<asp:BoundColumn DataField="DITTA" HeaderText="Ditta"></asp:BoundColumn>
													<asp:BoundColumn DataField="WR_ID" HeaderText="RdL"></asp:BoundColumn>
													<asp:BoundColumn DataField="DATA_WR" HeaderText="Data Creazione" DataFormatString="{0:d}"></asp:BoundColumn>
													<asp:BoundColumn DataField="STATO" HeaderText="Stato Richiesta"></asp:BoundColumn>
													<asp:BoundColumn DataField="PRIORITY" HeaderText="Priorit&#224;"></asp:BoundColumn>
													<asp:BoundColumn DataField="PIANIFICATA" HeaderText="Data Pianificata" DataFormatString="{0:d}"></asp:BoundColumn>
													<asp:BoundColumn DataField="COMPLETATA" HeaderText="Data Fine Lavori" DataFormatString="{0:d}"></asp:BoundColumn>
													<asp:BoundColumn DataField="DESCRIZIONE" HeaderText="Descrizione"></asp:BoundColumn>
													<asp:TemplateColumn Visible="FALSE">
														<HeaderStyle Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:ImageButton Visible="false" id="imgCostiRich" Runat="server" CommandName="Modifica" ImageUrl="../Images/kcalc.jpg" CommandArgument='<%# "../CostiOperativi/CostiOperativi.aspx?ItemId=" + DataBinder.Eval(Container.DataItem,"WR_ID") + "&TipoManId =" + DataBinder.Eval(Container.DataItem,"tipomanutenzione_id")%>'>
															</asp:ImageButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="false" DataField="id_stato" HeaderText="idstato"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="tipomanutenzione_id" HeaderText="idstato"></asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM><script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
