<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Addetti" Src="../WebControls/Addetti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Page language="c#" Codebehind="AnalisiCostiOperativiDiGestioneCumulativo.aspx.cs" AutoEventWireup="false" Inherits="TheSite.CostiGesioneCumulativi.AnalisiCostiOperativiDiGestioneCumulativo" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE html public "-//w3c//dtd html 4.0 transitional//en" >
<HTML>
	<HEAD>
		<TITLE>SfogliaRdl</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
		var NS4 = (navigator.appName == "Netscape" && parseInt(navigator.appVersion) < 5);
		var NSX = (navigator.appName == "Netscape");
		var IE4 = (document.all) ? true : false;
			
		function SelCheckbox(){
				for (i=0;i<document.all.length;i++)	{
					if (document.all(i).type == 'checkbox')	{
						if (document.getElementById("ChkSelTutti").checked==true){
							nome=document.all(i).id;	
							if (nome.substring(0,15)=='DataGridRicerca'){	
								if(document.all(i).disabled==false){
									document.all(i).checked=true;}
								}
							}			
						else
						{
							nome=document.all(i).id;	
							if (nome.substring(0,15)=='DataGridRicerca')
							{	
								if(document.all(i).disabled==false)
								{
									document.all(i).checked=false;
								}
							}
						}								
					}
				}
			}
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
		</SCRIPT>
	</HEAD>
	<BODY onkeypress="if (valutaenter(event) == false) { return false; }" bottomMargin="0"
		onbeforeunload="chiudi();" leftMargin="5" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="0"
				cellPadding="0" width="90%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><UC1:PAGETITLE id="PageTitle1" title="Sfoglia RdL e Odl" runat="server"></UC1:PAGETITLE></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" height="95%">
							<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center" width="95%">
								<TBODY>
									<TR>
										<TD style="HEIGHT: 25%" vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" titlestyle-cssclass="TitleSearch" cssclass="DataPanel75"
												titletext="Ricerca" allowtitleexpandcollapse="True" collapsed="False" expandtext="Espandi" collapsetext="Riduci" collapseimageurl="../Images/uparrows_trans.gif"
												expandimageurl="../Images/downarrows_trans.gif" Width="95%" Height="359">
												<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
													<TR>
														<TD align="left" colSpan="4">
															<UC1:RICERCAMODULO id="RicercaModulo1" runat="server"></UC1:RICERCAMODULO></TD>
													</TR>
													<TR>
														<TD align="left" width="13%">Richiesta di Lavoro:</TD>
														<TD width="30%">
															<CC1:S_TEXTBOX id="txtsRichiesta" runat="server" dbindex="2" dbdatatype="Integer" maxlength="10"
																dbsize="255" width="100px" dbdirection="Input" dbparametername="p_Wr_Id"></CC1:S_TEXTBOX></TD>
														<TD align="left" width="15%">Addetto:</TD>
														<TD width="30%">
															<UC1:ADDETTI id="Addetti1" runat="server"></UC1:ADDETTI></TD>
													</TR>
													<TR>
														<TD align="left">Data Da:</TD>
														<TD>
															<UC1:CALENDARPICKER id="CalendarPicker1" runat="server"></UC1:CALENDARPICKER></TD>
														<TD align="left">Data A:</TD>
														<TD>
															<UC1:CALENDARPICKER id="CalendarPicker2" runat="server"></UC1:CALENDARPICKER>
															<ASP:COMPAREVALIDATOR id="CompareValidator1" runat="server" errormessage="Data non valida!" operator="GreaterThanEqual"
																type="Date" display="Dynamic"></ASP:COMPAREVALIDATOR></TD>
													</TR>
													<TR>
														<TD align="left">Ordine di Lavoro:</TD>
														<TD>
															<CC1:S_TEXTBOX id="txtsOrdine" runat="server" maxlength="10" dbsize="255" width="100px" dbdirection="Input"
																dbparametername="p_Wr_Id"></CC1:S_TEXTBOX></TD>
														<TD align="left">Stato Richiesta:</TD>
														<TD>
															<CC1:S_COMBOBOX id="cmbsStatus" runat="server" width="99%"></CC1:S_COMBOBOX></TD>
													</TR>
													<TR>
														<TD align="left">Servizio:</TD>
														<TD>
															<CC1:S_COMBOBOX id="cmbsServizio" runat="server" width="99%"></CC1:S_COMBOBOX></TD>
														<TD align="left">Gruppo:</TD>
														<TD>
															<CC1:S_COMBOBOX id="cmbsGruppo" runat="server" width="99%"></CC1:S_COMBOBOX></TD>
													</TR>
													<TR>
														<TD align="left">Richiedente:</TD>
														<TD>
															<UC1:RICHIEDENTI id="Richiedenti1" runat="server"></UC1:RICHIEDENTI></TD>
														<TD align="left">Urgenza:</TD>
														<TD>
															<CC1:S_COMBOBOX id="cmbsUrgenza" runat="server" width="99%"></CC1:S_COMBOBOX></TD>
													</TR>
													<TR>
														<TD align="left" colSpan="1">Descrizione:</TD>
														<TD colSpan="3">
															<CC1:S_TEXTBOX id="txtDescrizione" runat="server" maxlength="255" dbsize="255" width="690px" dbdirection="Input"
																dbparametername="p_Wr_Id"></CC1:S_TEXTBOX></TD>
													</TR>
													<TR>
														<TD align="left">Tipo Manutenzione:</TD>
														<TD>
															<CC1:S_COMBOBOX id="cmbsTipoManutenzione" runat="server" width="99%"></CC1:S_COMBOBOX></TD>
														<TD id="tabletipointervento" style="DISPLAY: none">Tipo Intervento:</TD>
														<TD id="tabletipointervento2" style="DISPLAY: none">
															<CC1:S_COMBOBOX id="cmbsTipoIntervento" runat="server" width="99%"></CC1:S_COMBOBOX></TD>
													</TR>
													<TR id="trdate" style="DISPLAY: none">
														<TD align="left">Data Privista Inizio:</TD>
														<TD>
															<UC1:CALENDARPICKER id="CalendarPicker3" runat="server"></UC1:CALENDARPICKER></TD>
														<TD align="left">Data Prevista Fine:</TD>
														<TD>
															<UC1:CALENDARPICKER id="CalendarPicker4" runat="server"></UC1:CALENDARPICKER></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 16px" align="left" colSpan="4"></TD>
													</TR>
													<TR>
														<TD align="left" colSpan="3">
															<CC1:S_BUTTON id="btnsRicerca" runat="server" text="Ricerca"></CC1:S_BUTTON>&nbsp;
															<ASP:BUTTON id="cmdReset" runat="server" text="Reset"></ASP:BUTTON>&nbsp;
															<ASP:VALIDATIONSUMMARY id="ValidationSummary1" runat="server"></ASP:VALIDATIONSUMMARY></TD>
														<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
													</TR>
												</TABLE>
											</COLLAPSE:DATAPANEL></TD>
									</TR>
									<TR>
										<TD align="center"></TD>
									</TR>
									<TR id="trstraordinaria">
										<TD vAlign="top" align="center" width="100%"><UC1:GRIDTITLE id="GridTitle1" runat="server"></UC1:GRIDTITLE>
											<ASP:DATAGRID id="DataGridRicerca" runat="server" cssclass="DataGrid" showfooter="True" allowpaging="True"
												bordercolor="Gray" borderwidth="1px" gridlines="Vertical" autogeneratecolumns="False" Width="100%"
												AllowCustomPaging="True">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="WR_ID" HeaderText="ID"></asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle HorizontalAlign="Center" Width="3%" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<HeaderTemplate>
															<INPUT type="checkbox" id="ChkSelTutti" onclick="SelCheckbox()">
														</HeaderTemplate>
														<ItemTemplate>
															<ASP:CHECKBOX id="ChkSel" runat="server"></ASP:CHECKBOX>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn Visible="False">
														<HeaderStyle Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<ASP:IMAGEBUTTON id="Imagebutton2" runat="server" commandname="Modifica" imageurl="../images/Search16x16_bianca.JPG" commandargument='<%# "CreazioneSGA.aspx?ItemId=" + DataBinder.Eval(Container.DataItem,"WR_ID")%>'>
															</ASP:IMAGEBUTTON>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="WR_ID" HeaderText="Rdl"></asp:BoundColumn>
													<asp:BoundColumn DataField="ordineater" HeaderText="Odl F.S.L."></asp:BoundColumn>
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
													<asp:BoundColumn Visible="False" DataField="id_stato" HeaderText="idstato"></asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Left" CssClass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
											</ASP:DATAGRID></TD>
									</TR>
									<TR id="trrichiesta">
										<TD vAlign="top" align="center" width="100%"><UC1:GRIDTITLE id="Gridtitle2" runat="server"></UC1:GRIDTITLE><ASP:DATAGRID id="DataGridRicerca2" runat="server" cssclass="DataGrid" allowpaging="True" bordercolor="Gray"
												borderwidth="1px" gridlines="Vertical" autogeneratecolumns="False" Width="100%" AllowCustomPaging="True">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="WR_ID" HeaderText="ID"></asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle HorizontalAlign="Center" Width="3%" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<HeaderTemplate>
															<INPUT type="checkbox" id="ChkSelTutti" onclick="SelCheckbox()">
														</HeaderTemplate>
														<ItemTemplate>
															<ASP:CHECKBOX id="ChkSel2" runat="server"></ASP:CHECKBOX>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn Visible="False">
														<HeaderStyle Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<ASP:IMAGEBUTTON id="Imagebutton3" runat="server" commandname="Modifica" imageurl="../images/Search16x16_bianca.JPG" commandargument='<%# "CreazioneSGA.aspx?ItemId=" + DataBinder.Eval(Container.DataItem,"WR_ID")%>'>
															</ASP:IMAGEBUTTON>
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
													<asp:BoundColumn Visible="False" DataField="id_stato" HeaderText="idstato"></asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Left" CssClass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
											</ASP:DATAGRID>
											<P>
												<TABLE id="tableComandi" cellSpacing="1" cellPadding="1" width="900" border="0" runat="server">
													<TBODY>
														<TR>
															<TD style="HEIGHT: 25px" width="20%"><CC1:S_BUTTON id="S_btnConfermaSel" runat="server" cssclass="btn" width="120px" text="Conferma Selezione"></CC1:S_BUTTON></TD>
															<TD style="HEIGHT: 25px" width="20%"><CC1:S_BUTTON id="S_btnStampa" runat="server" cssclass="btn" width="120px" text="Crea File  Pdf"
																	enabled="False"></CC1:S_BUTTON></TD>
															<TD style="HEIGHT: 25px" width="20%">
																<CC1:S_BUTTON id="S_btnSelezionaTutto" runat="server" cssclass="btn" width="120px" text="Seleziona Tutto"></CC1:S_BUTTON></TD>
															<TD style="HEIGHT: 25px" width="20%">
																<CC1:S_BUTTON id="S_btnDeselezioneTutto" runat="server" cssclass="btn" width="120px" text="Deseleziona Tutto"></CC1:S_BUTTON></TD>
															<TD style="HEIGHT: 25px" width="20%">
																<CC1:S_BUTTON id="S_btnReset" runat="server" cssclass="btn" width="120px" text="Reset"></CC1:S_BUTTON></TD>
														</TR>
													</TBODY>
												</TABLE>
												<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="90%" border="0" runat="server">
													<TBODY>
														<TR>
															<TD><ASP:LABEL id="lblElementiSelezionati" runat="server"></ASP:LABEL></TD>
														</TR>
														<TR>
															<TD><ASP:LABEL id="lblMessaggio" runat="server"></ASP:LABEL></TD>
														</TR>
													</TBODY>
												</TABLE>
											</P>
											<P><CC1:S_BUTTON id="S_btnDownLoad" runat="server" cssclass="btn" width="120px" text="Pagina Download"></CC1:S_BUTTON></P>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</FORM>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM></TR></TBODY>
		<P></P>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
		<script language="javascript">
			Visualizza("<%=comboTipoManutenzioneCliendiId%>");
		</script>
	</BODY>
</HTML>
