<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Page language="c#" Codebehind="AnalisiCostiOperativiDiGestione.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorrettiva.AnalisiCostiOperativiDiGestione" %>
<%@ Register TagPrefix="uc1" TagName="Addetti" Src="../WebControls/Addetti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
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
	<BODY onkeypress="if (valutaenter(event) == false) { return false; }" bottommargin="0"
		onbeforeunload="chiudi();parent.left.valorizza()" leftmargin="5" topmargin="0" rightmargin="0" ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellspacing="0"
				cellpadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><UC1:PAGETITLE id="PageTitle1" title="Sfoglia RdL e Odl" runat="server"></UC1:PAGETITLE></TD>
					</TR>
					<TR>
						<TD valign="top" align="center" height="95%">
							<TABLE id="tblForm" cellspacing="1" cellpadding="1" align="center">
								<TBODY>
									<TR>
										<TD style="HEIGHT: 25%" valign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" titlestyle-cssclass="TitleSearch" cssclass="DataPanel75"
												titletext="Ricerca" allowtitleexpandcollapse="True" collapsed="False" expandtext="Espandi" collapsetext="Riduci" collapseimageurl="../Images/up.gif"
												expandimageurl="../Images/down.gif">
            <TABLE id=tblSearch100 cellSpacing=1 cellPadding=2 border=0>
              <TR>
                <TD align=left colSpan=4>
<UC1:RICERCAMODULO id=RicercaModulo1 runat="server"></UC1:RICERCAMODULO></TD></TR>
              <TR>
                <TD align=left width="13%">Richiesta di Lavoro:</TD>
                <TD width="30%">
<CC1:S_TEXTBOX id=txtsRichiesta runat="server" dbparametername="p_Wr_Id" dbdirection="Input" width="100px" dbsize="255" maxlength="10" dbdatatype="Integer" dbindex="2"></CC1:S_TEXTBOX></TD>
                <TD align=left width="15%">Addetto:</TD>
                <TD width="30%">
<UC1:ADDETTI id=Addetti1 runat="server"></UC1:ADDETTI></TD></TR>
              <TR>
                <TD align=left>Data Da:</TD>
                <TD>
<UC1:CALENDARPICKER id=CalendarPicker1 runat="server"></UC1:CALENDARPICKER></TD>
                <TD align=left>Data A:</TD>
                <TD>
<UC1:CALENDARPICKER id=CalendarPicker2 runat="server"></UC1:CALENDARPICKER>
<ASP:COMPAREVALIDATOR id=CompareValidator1 runat="server" display="Dynamic" type="Date" operator="GreaterThanEqual" errormessage="Data non valida!"></ASP:COMPAREVALIDATOR></TD></TR>
              <TR>
                <TD align=left>Ordine di Lavoro:</TD>
                <TD>
<CC1:S_TEXTBOX id=txtsOrdine runat="server" dbparametername="p_Wr_Id" dbdirection="Input" width="100px" dbsize="255" maxlength="10"></CC1:S_TEXTBOX></TD>
                <TD align=left>Stato Richiesta:</TD>
                <TD>
<CC1:S_COMBOBOX id=cmbsStatus runat="server" width="99%"></CC1:S_COMBOBOX></TD></TR>
              <TR>
                <TD align=left>Servizio:</TD>
                <TD>
<CC1:S_COMBOBOX id=cmbsServizio runat="server" width="99%"></CC1:S_COMBOBOX></TD>
                <TD align=left>Gruppo:</TD>
                <TD>
<CC1:S_COMBOBOX id=cmbsGruppo runat="server" width="99%"></CC1:S_COMBOBOX></TD></TR>
              <TR>
                <TD align=left>Richiedente:</TD>
                <TD>
<UC1:RICHIEDENTI id=Richiedenti1 runat="server"></UC1:RICHIEDENTI></TD>
                <TD align=left>Urgenza:</TD>
                <TD>
<CC1:S_COMBOBOX id=cmbsUrgenza runat="server" width="99%"></CC1:S_COMBOBOX></TD></TR>
              <TR>
                <TD align=left colSpan=1>Descrizione:</TD>
                <TD colSpan=3>
<CC1:S_TEXTBOX id=txtDescrizione runat="server" dbparametername="p_Wr_Id" dbdirection="Input" width="99%" dbsize="255" maxlength="255"></CC1:S_TEXTBOX></TD></TR>
              <TR>
                <TD align=left>Tipo Manutenzione:</TD>
                <TD>
<CC1:S_COMBOBOX id=cmbsTipoManutenzione runat="server" width="99%"></CC1:S_COMBOBOX></TD>
                <TD id=tabletipointervento style="DISPLAY: none">Tipo 
                  Intervento:</TD>
                <TD id=tabletipointervento2 style="DISPLAY: none">
<CC1:S_COMBOBOX id=cmbsTipoIntervento runat="server" width="99%"></CC1:S_COMBOBOX></TD></TR>
              <TR id=trdate style="DISPLAY: none">
                <TD align=left>Data Privista Inizio:</TD>
                <TD>
<UC1:CALENDARPICKER id=CalendarPicker3 runat="server"></UC1:CALENDARPICKER></TD>
                <TD align=left>Data Prevista Fine:</TD>
                <TD>
<UC1:CALENDARPICKER id=CalendarPicker4 runat="server"></UC1:CALENDARPICKER></TD></TR>
              <TR>
                <TD style="HEIGHT: 16px" align=left colSpan=4></TD></TR>
              <TR>
                <TD align=left colSpan=3>
<CC1:S_BUTTON id=btnsRicerca runat="server" text="Ricerca"></CC1:S_BUTTON>&nbsp; 
<ASP:BUTTON id=cmdReset runat="server" text="Reset"></ASP:BUTTON>&nbsp; 
<CC1:S_BUTTON id=cmdExcel tabIndex=2 runat="server" text="Esporta"></CC1:S_BUTTON>
<ASP:VALIDATIONSUMMARY id=ValidationSummary1 runat="server"></ASP:VALIDATIONSUMMARY></TD>
                <TD align=right><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD></TR></TABLE>
											</COLLAPSE:DATAPANEL></TD>
									</TR>
									<TR>
										<TD align="center"></TD>
									</TR>
									<TR id="trstraordinaria">
										<TD valign="top" align="center" width="100%">
											<UC1:GRIDTITLE id="GridTitle1" runat="server"></UC1:GRIDTITLE>
											<ASP:DATAGRID id="DataGridRicerca" runat="server" cssclass="DataGrid" showfooter="True" allowpaging="True"
												bordercolor="Gray" borderwidth="1px" gridlines="Vertical" autogeneratecolumns="False" AllowCustomPaging="True">
												<ALTERNATINGITEMSTYLE cssclass="DataGridAlternatingItemStyle"></ALTERNATINGITEMSTYLE>
												<ITEMSTYLE cssclass="DataGridItemStyle"></ITEMSTYLE>
												<HEADERSTYLE cssclass="DataGridHeaderStyle"></HEADERSTYLE>
												<COLUMNS>
													<ASP:BOUNDCOLUMN visible="False" datafield="WR_ID" headertext="ID"></ASP:BOUNDCOLUMN>
													<ASP:TEMPLATECOLUMN>
														<HEADERSTYLE width="3%"></HEADERSTYLE>
														<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
														<ITEMTEMPLATE>
															<ASP:IMAGEBUTTON id="lnkDett" runat="server" commandname="Dettaglio" imageurl="../images/edit.gif" commandargument='<%# "AnalisiCostiOperativiDiGestioneDettaglio.aspx?wr_id=" + DataBinder.Eval(Container.DataItem,"WR_ID")%>'>
															</ASP:IMAGEBUTTON>
														</ITEMTEMPLATE>
													</ASP:TEMPLATECOLUMN>
													<ASP:TEMPLATECOLUMN visible="False">
														<HEADERSTYLE width="3%"></HEADERSTYLE>
														<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
														<ITEMTEMPLATE>
															<ASP:IMAGEBUTTON id="Imagebutton2" runat="server" commandname="Modifica" imageurl="../images/Search16x16_bianca.JPG" commandargument='<%# "CreazioneSGA.aspx?ItemId=" + DataBinder.Eval(Container.DataItem,"WR_ID")%>'>
															</ASP:IMAGEBUTTON>
														</ITEMTEMPLATE>
													</ASP:TEMPLATECOLUMN>
													<ASP:TEMPLATECOLUMN headertext="Prev.">
														<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
														<ITEMTEMPLATE>
															<A href="" runat="server" id="linkpreve"></A>
														</ITEMTEMPLATE>
													</ASP:TEMPLATECOLUMN>
													<ASP:TEMPLATECOLUMN headertext="Cons.">
														<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
														<ITEMTEMPLATE>
															<A href="" runat="server" id="linkconsu"></A>
														</ITEMTEMPLATE>
													</ASP:TEMPLATECOLUMN>
													<ASP:BOUNDCOLUMN datafield="WR_ID" headertext="Rdl"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="ordineater" headertext="Odl"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="INDIRIZZO" headertext="Impianto"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN visible="False" datafield="WO_ID" headertext="OdL"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="addetto" headertext="Addetto"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="stato" headertext="Stato"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="tipointerventoater" headertext="Tipo Intervento"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="importostimato" headertext="Importo Stimato" dataformatstring="{0:C}">
														<ITEMSTYLE horizontalalign="Right"></ITEMSTYLE>
													</ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="importoconsuntivo" headertext="Importo Consuntivo" dataformatstring="{0:C}">
														<ITEMSTYLE horizontalalign="Right"></ITEMSTYLE>
													</ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN visible="False" datafield="id_stato" headertext="idstato"></ASP:BOUNDCOLUMN>
												</COLUMNS>
												<PAGERSTYLE horizontalalign="Left" cssclass="DataGridPagerStyle" mode="NumericPages"></PAGERSTYLE>
											</ASP:DATAGRID></TD>
									</TR>
									<TR id="trrichiesta">
										<TD valign="top" align="center" width="100%"><UC1:GRIDTITLE id="Gridtitle2" runat="server"></UC1:GRIDTITLE><ASP:DATAGRID id="DataGridRicerca2" runat="server" cssclass="DataGrid" allowpaging="True" bordercolor="Gray"
												borderwidth="1px" gridlines="Vertical" autogeneratecolumns="False" AllowCustomPaging="True">
												<ALTERNATINGITEMSTYLE cssclass="DataGridAlternatingItemStyle"></ALTERNATINGITEMSTYLE>
												<ITEMSTYLE cssclass="DataGridItemStyle"></ITEMSTYLE>
												<HEADERSTYLE cssclass="DataGridHeaderStyle"></HEADERSTYLE>
												<COLUMNS>
													<ASP:BOUNDCOLUMN visible="False" datafield="WR_ID" headertext="ID"></ASP:BOUNDCOLUMN>
													<ASP:TEMPLATECOLUMN>
														<HEADERSTYLE width="3%"></HEADERSTYLE>
														<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
														<ITEMTEMPLATE>
															<ASP:IMAGEBUTTON id="Imagebutton1" runat="server" commandname="Dettaglio" imageurl="../images/edit.gif" commandargument='<%# "AnalisiCostiOperativiDiGestioneDettaglio.aspx?wr_id=" + DataBinder.Eval(Container.DataItem,"WR_ID") %>'>
															</ASP:IMAGEBUTTON>
														</ITEMTEMPLATE>
													</ASP:TEMPLATECOLUMN>
													<ASP:TEMPLATECOLUMN visible="False">
														<HEADERSTYLE width="3%"></HEADERSTYLE>
														<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
														<ITEMTEMPLATE>
															<ASP:IMAGEBUTTON id="Imagebutton3" runat="server" commandname="Modifica" imageurl="../images/Search16x16_bianca.JPG" commandargument='<%# "CreazioneSGA.aspx?ItemId=" + DataBinder.Eval(Container.DataItem,"WR_ID")%>'>
															</ASP:IMAGEBUTTON>
														</ITEMTEMPLATE>
													</ASP:TEMPLATECOLUMN>
													<ASP:BOUNDCOLUMN datafield="INDIRIZZO" headertext="Indirizzo"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="WO_ID" headertext="OdL"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="DATA_WO" headertext="Data Emissione" dataformatstring="{0:d}"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="DITTA" headertext="Ditta"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="WR_ID" headertext="RdL"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="DATA_WR" headertext="Data Creazione" dataformatstring="{0:d}"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="STATO" headertext="Stato Richiesta"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="PRIORITY" headertext="Priorit&#224;"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="PIANIFICATA" headertext="Data Pianificata" dataformatstring="{0:d}"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="COMPLETATA" headertext="Data Fine Lavori" dataformatstring="{0:d}"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="DESCRIZIONE" headertext="Descrizione"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN visible="False" datafield="id_stato" headertext="idstato"></ASP:BOUNDCOLUMN>
												</COLUMNS>
												<PAGERSTYLE horizontalalign="Left" forecolor="Black" backcolor="#d9e3fd" mode="NumericPages"></PAGERSTYLE>
											</ASP:DATAGRID></TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</FORM></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM><script language="javascript">parent.left.calcola();</script>
	</BODY>
</HTML>
