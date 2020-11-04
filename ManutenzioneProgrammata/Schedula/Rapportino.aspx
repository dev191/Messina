<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../../WebControls/CalendarPicker.ascx" %>
<%@ Page language="c#" Codebehind="Rapportino.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.Rapportino" %>
<%@ Register TagPrefix="uc1" TagName="Addetti" Src="../../WebControls/Addetti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BottomMenu" Src="../../WebControls/BottomMenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>ApprovaRdl</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
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
			
			function ControllaCaratteri(){
				if (event.keyCode < 48	|| event.keyCode > 57){
					event.keyCode = 0;
				}	
			}
			
			function Valorizza(val)
			{
				document.getElementById("txtHidden").value=val;
			}
			
			function ControllaEdifici()
			{				
				if(document.getElementById("<%=txtTotSelezionati.ClientID%>").value=='0')
				{
					if(document.getElementById("txtHidden").value=="1")
					{
						alert("Nessun Edificio Selezionato.");				
						return false;
					}
				}
			}
						
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
			
		</SCRIPT>
	</HEAD>
	<BODY bottomMargin="0" onbeforeunload="parent.left.valorizza()" leftMargin="5" topMargin="0"
		rightMargin="0" ms_positioning="GridLayout">
		<FORM id="Form1" onsubmit="return ControllaEdifici()" method="post" runat="server">
			<TABLE id="TableMain" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><UC1:PAGETITLE id="PageTitle1" runat="server"></UC1:PAGETITLE></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="1" cellPadding="1" width="98%" align="center">
								<TBODY>
									<TR>
										<TD vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" titlestyle-cssclass="TitleSearch" cssclass="DataPanel75"
												titletext="Ricerca" allowtitleexpandcollapse="True" collapsed="False" expandtext="Espandi" collapsetext="Riduci" collapseimageurl="../../Images/up.gif"
												expandimageurl="../../Images/down.gif">
												<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
													<TR>
														<TD align="left">Ordine di Lavoro:
														</TD>
														<TD colSpan="3">
															<CC1:S_TEXTBOX id="txtsOrdine" runat="server" dbdirection="Input" dbsize="255" dbparametername="p_Wr_Id"
																maxlength="10" width="100px"></CC1:S_TEXTBOX></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 14px" align="left">Anno:
														</TD>
														<TD style="HEIGHT: 14px">
															<CC1:S_COMBOBOX id="cmbsAnno" runat="server" dbdirection="Input" dbsize="5" width="288px" autopostback="True"
																dbdatatype="Integer" dbindex="5">
																<ASP:LISTITEM value="1990">1990</ASP:LISTITEM>
																<ASP:LISTITEM value="1991">1991</ASP:LISTITEM>
																<ASP:LISTITEM value="1992">1992</ASP:LISTITEM>
																<ASP:LISTITEM value="1993">1993</ASP:LISTITEM>
																<ASP:LISTITEM value="1994">1994</ASP:LISTITEM>
																<ASP:LISTITEM value="1995">1995</ASP:LISTITEM>
																<ASP:LISTITEM value="1996">1996</ASP:LISTITEM>
																<ASP:LISTITEM value="1997">1997</ASP:LISTITEM>
																<ASP:LISTITEM value="1998">1998</ASP:LISTITEM>
																<ASP:LISTITEM value="1999">1999</ASP:LISTITEM>
																<ASP:LISTITEM value="2000">2000</ASP:LISTITEM>
																<ASP:LISTITEM value="2001">2001</ASP:LISTITEM>
																<ASP:LISTITEM value="2002">2002</ASP:LISTITEM>
																<ASP:LISTITEM value="2003">2003</ASP:LISTITEM>
																<ASP:LISTITEM value="2004">2004</ASP:LISTITEM>
																<ASP:LISTITEM value="2005">2005</ASP:LISTITEM>
																<ASP:LISTITEM value="2006">2006</ASP:LISTITEM>
																<ASP:LISTITEM value="2007">2007</ASP:LISTITEM>
																<ASP:LISTITEM value="2008">2008</ASP:LISTITEM>
																<ASP:LISTITEM value="2009">2009</ASP:LISTITEM>
																<ASP:LISTITEM value="2010">2010</ASP:LISTITEM>
																<ASP:LISTITEM value="2011">2011</ASP:LISTITEM>
																<ASP:LISTITEM value="2012">2012</ASP:LISTITEM>
																<ASP:LISTITEM value="2013">2013</ASP:LISTITEM>
																<ASP:LISTITEM value="2014">2014</ASP:LISTITEM>
																<ASP:LISTITEM value="2015">2015</ASP:LISTITEM>
															</CC1:S_COMBOBOX></TD>
														<TD style="HEIGHT: 14px">Mesi:</TD>
														<TD style="HEIGHT: 14px">Da:
															<CC1:S_COMBOBOX id="cmbMeseDa" runat="server"></CC1:S_COMBOBOX>&nbsp;A:
															<CC1:S_COMBOBOX id="cmbMeseA" runat="server"></CC1:S_COMBOBOX></TD>
													</TR>
													<TR>
														<TD>Comune:</TD>
														<TD>
															<CC1:S_COMBOBOX id="cmbsComune" runat="server" dbdirection="Input" dbsize="5" dbparametername="p_Ditta"
																width="288px" autopostback="True" dbdatatype="Integer" dbindex="5"></CC1:S_COMBOBOX></TD>
														<TD>Edificio:
														</TD>
														<TD>
															<CC1:S_COMBOBOX id="cmbsEdificio" runat="server" dbdirection="Input" dbsize="5" dbparametername="p_Ditta"
																width="288px" autopostback="True" dbdatatype="Integer" dbindex="5"></CC1:S_COMBOBOX></TD>
													</TR>
													<TR>
														<TD align="left">Servizio:</TD>
														<TD>
															<CC1:S_COMBOBOX id="cmbsServizio" runat="server" dbdirection="Input" dbsize="5" dbparametername="p_Ditta"
																width="288px" autopostback="False" dbdatatype="Integer" dbindex="5"></CC1:S_COMBOBOX></TD>
														<TD align="left">Addetto:&nbsp;
														</TD>
														<TD>
															<CC1:S_COMBOBOX id="cmbsAddetti" runat="server" dbdirection="Input" dbsize="5" dbparametername="p_Ditta"
																width="288px" dbdatatype="Integer" dbindex="5"></CC1:S_COMBOBOX></TD>
													</TR>
													<TR>
														<TD></TD>
														<TD align="left" colSpan="3"></TD>
													</TR>
													<TR>
														<TD align="left" colSpan="3">
															<CC1:S_BUTTON id="btnsRicerca" tabIndex="2" runat="server" cssclass="btn" text="Ricerca"></CC1:S_BUTTON>&nbsp;
															<ASP:BUTTON id="cmdReset" runat="server" cssclass="btn" text="Reset"></ASP:BUTTON>&nbsp;&nbsp;&nbsp;&nbsp;
															<INPUT id="txtHidden" type="hidden" value="0">
															<ASP:TEXTBOX id="txtTotSelezionati" runat="server" width="0px">0</ASP:TEXTBOX></TD>
														<TD align="right"><A class="GuidaLink" href="../<%= HelpLink %>" 
                  target="_blank">Guida</A></TD>
													</TR>
												</TABLE>
											</COLLAPSE:DATAPANEL></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 72%" vAlign="top" align="center"><UC1:GRIDTITLE id="GridTitle1" runat="server"></UC1:GRIDTITLE><ASP:DATAGRID id="DataGridRicerca" runat="server" cssclass="DataGrid" AllowCustomPaging="True"
												autogeneratecolumns="False" gridlines="Vertical" borderwidth="1px" bordercolor="Gray" allowpaging="True">
												<ALTERNATINGITEMSTYLE cssclass="DataGridAlternatingItemStyle"></ALTERNATINGITEMSTYLE>
												<ITEMSTYLE cssclass="DataGridItemStyle"></ITEMSTYLE>
												<HEADERSTYLE cssclass="DataGridHeaderStyle"></HEADERSTYLE>
												<COLUMNS>
													<ASP:BOUNDCOLUMN visible="false" datafield="WO_ID" headertext="WO_ID"></ASP:BOUNDCOLUMN>
													<ASP:TEMPLATECOLUMN headertext="&lt;input id='ChkSelTutti' type='Checkbox' onclick='SelCheckbox()'&gt;">
														<HEADERSTYLE width="3%" horizontalalign="Center" verticalalign="Middle"></HEADERSTYLE>
														<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
														<ITEMTEMPLATE>
															<ASP:CHECKBOX id="ChkSel" runat="server"></ASP:CHECKBOX>
														</ITEMTEMPLATE>
													</ASP:TEMPLATECOLUMN>
													<ASP:BOUNDCOLUMN visible="True" datafield="WO_ID" headertext="WO_ID"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="BL_ID" headertext="BL_ID" visible="False">
														<ITEMSTYLE font-size="9px"></ITEMSTYLE>
													</ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="CAMPUS" headertext="EDIFICIO">
														<ITEMSTYLE font-size="9px"></ITEMSTYLE>
													</ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="SERVIZIO" headertext="SERVIZIO">
														<ITEMSTYLE font-size="9px"></ITEMSTYLE>
													</ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="IDSERVIZIO" headertext="IDSERVIZIO" visible="False"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="ADDETTO" headertext="ADDETTO"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="IDAddetto" headertext="IDADDETTO" visible="False"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="MESE" headertext="MESE"></ASP:BOUNDCOLUMN>
												</COLUMNS>
												<PAGERSTYLE horizontalalign="Left" cssclass="DataGridPagerStyle" mode="NumericPages"></PAGERSTYLE>
											</ASP:DATAGRID></TD>
									</TR>
									<TR>
										<TD><ASP:PANEL id="PanelCrea" runat="server" visible="True">
												<P>
													<ASP:RADIOBUTTON id="StampaCorta" runat="server" text="Stampa Corta" visible="True" checked="True"
														groupname="optionstampa"></ASP:RADIOBUTTON><BR>
													<ASP:RADIOBUTTON id="StampaLunga" runat="server" text="Stampa Lunga" visible="True" groupname="optionstampa"></ASP:RADIOBUTTON><BR>
													<ASP:RADIOBUTTON id="StampaDettaglioLocaliCorta" runat="server" text="Stampa dettaglio locali Corta"
														visible="True" groupname="optionstampa"></ASP:RADIOBUTTON><BR>
													<ASP:RADIOBUTTON id="StampaDetaglioLocali" runat="server" text="Stampa dettaglio locali Lunga" visible="True"
														groupname="optionstampa"></ASP:RADIOBUTTON><BR>
													<ASP:RADIOBUTTON id="StampaDetaglioLocaliLung2Pa" runat="server" text="Stampa dettaglio locali Lunga passi 2 c "
														visible="True" groupname="optionstampa"></ASP:RADIOBUTTON><BR>
												</P>
												<TABLE align="center">
													<TR>
														<TD>
															<CC1:S_BUTTON id="btnsStampa" runat="server" cssclass="btn" width="130px" text="Stampa Rapportino"
																visible="true"></CC1:S_BUTTON></TD>
														<TD>
															<CC1:S_BUTTON id="btnsSelezionaTutti" runat="server" cssclass="btn" width="130px" text="Seleziona Tutti"
																visible="true"></CC1:S_BUTTON></TD>
														<TD>
															<CC1:S_BUTTON id="btnsDeSelezionaTutti" runat="server" cssclass="btn" width="130px" text="Deseleziona Tutti"
																visible="true"></CC1:S_BUTTON></TD>
														<TD>
															<CC1:S_BUTTON id="btnsConfermaSelezioni" runat="server" cssclass="btn" width="130px" text="Conferma Selezioni"
																visible="true"></CC1:S_BUTTON></TD>
														<TD>&nbsp;&nbsp;&nbsp;
															<ASP:LABEL id="LblElementiSelezionati" runat="server">0</ASP:LABEL></TD>
													</TR>
												</TABLE>
											</ASP:PANEL></TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="bottom"><UC1:BOTTOMMENU id="BottomMenu1" runat="server"></UC1:BOTTOMMENU></TD>
					</TR>
				</TBODY>
			</TABLE>
			</TD></TR></TBODY></TABLE></TD></TR></FORM>
		<SCRIPT language="javascript">parent.left.calcola();</SCRIPT>
	</BODY>
</HTML>
