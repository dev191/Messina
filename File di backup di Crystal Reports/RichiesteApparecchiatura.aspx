<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Addetti" Src="../WebControls/Addetti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Page language="c#" Codebehind="RichiesteApparecchiatura.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.RichiesteApparecchiatura" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
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
		
		</SCRIPT>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" onkeypress="if (valutaenter(event) == false) { return false; }" bottommargin="0"
		leftmargin="5" topmargin="0" rightmargin="0" ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellspacing="0"
				cellpadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><UC1:PAGETITLE id="PageTitle1" title="Sfoglia RdL e Odl" runat="server"></UC1:PAGETITLE></TD>
					</TR>
					<TR>
						<TD>
							<TABLE>
								<TR>
									<TD>&nbsp;&nbsp;<B>Codice Componente:</B></TD>
									<TD><CC1:S_LABEL id="S_lblcodicecomponente" runat="server"></CC1:S_LABEL></TD>
									<TD>&nbsp;&nbsp;<B>Standard:</B></TD>
									<TD><CC1:S_LABEL id="S_lblstdapparecchiature" runat="server"></CC1:S_LABEL></TD>
								<TR>
									<TD>&nbsp;&nbsp;<B>Codice Edificio:</B></TD>
									<TD><CC1:S_LABEL id="S_lblcodiceedificio" runat="server"></CC1:S_LABEL></TD>
									<TD>&nbsp;&nbsp;<B>Edificio:</B></TD>
									<TD><CC1:S_LABEL id="S_lbledificio" runat="server"></CC1:S_LABEL></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD valign="top" align="center" height="95%">
							<TABLE id="tblForm" cellspacing="1" cellpadding="1" align="center">
								<TBODY>
									<TR>
										<TD style="HEIGHT: 25%" valign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" titlestyle-cssclass="TitleSearch" cssclass="DataPanel75"
												titletext="Ricerca" allowtitleexpandcollapse="True" collapsed="False" expandtext="Espandi" collapsetext="Riduci" collapseimageurl="../Images/up.gif"
												expandimageurl="../Images/down.gif">
												<TABLE id="tblSearch100" cellspacing="1" cellpadding="2" border="0">
													<TR>
														<TD style="HEIGHT: 25px" align="left" width="13%">Richiesta di Lavoro:</TD>
														<TD style="WIDTH: 259px; HEIGHT: 25px" width="259">
															<CC1:S_TEXTBOX id="txtsRichiesta" runat="server" dbparametername="p_Wr_Id" dbdirection="Input"
																width="100px" dbsize="255" maxlength="10" dbdatatype="Integer" dbindex="2"></CC1:S_TEXTBOX></TD>
														<TD style="HEIGHT: 25px" align="left" width="15%">Addetto:</TD>
														<TD style="HEIGHT: 25px" width="30%">
															<UC1:ADDETTI id="Addetti1" runat="server"></UC1:ADDETTI></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 29px" align="left">Da:</TD>
														<TD style="WIDTH: 259px; HEIGHT: 29px">
															<UC1:CALENDARPICKER id="CalendarPicker1" runat="server"></UC1:CALENDARPICKER></TD>
														<TD style="HEIGHT: 29px" align="left">A:</TD>
														<TD style="HEIGHT: 29px">
															<UC1:CALENDARPICKER id="CalendarPicker2" runat="server"></UC1:CALENDARPICKER>
															<ASP:COMPAREVALIDATOR id="CompareValidator1" runat="server" type="Date" operator="GreaterThanEqual" errormessage="Data non valida!"></ASP:COMPAREVALIDATOR></TD>
													</TR>
													<TR>
														<TD align="left">Ordine di Lavoro:</TD>
														<TD style="WIDTH: 259px">
															<CC1:S_TEXTBOX id="txtsOrdine" runat="server" dbparametername="p_Wr_Id" dbdirection="Input" width="100px"
																dbsize="255" maxlength="10"></CC1:S_TEXTBOX></TD>
														<TD align="left">Stato Richiesta:</TD>
														<TD>
															<CC1:S_COMBOBOX id="cmbsStatus" runat="server" width="99%"></CC1:S_COMBOBOX></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 16px" align="left" colspan="4"></TD>
													</TR>
													<TR>
														<TD align="left" colspan="3">
															<CC1:S_BUTTON id="btnsRicerca" runat="server" cssclass="btn" text="Ricerca"></CC1:S_BUTTON>&nbsp;<INPUT class="btn" type="reset" value="Reset">&nbsp;&nbsp;
															<CC1:S_BUTTON id="cmdExcel" tabindex="2" runat="server" cssclass="btn" text="Esporta"></CC1:S_BUTTON>
															<ASP:BUTTON id="cmdReset" cssclass="btn" text="Indietro" runat="server"></ASP:BUTTON></TD>
														<TD align="right"><A CLASS="GuidaLink" HREF="<%= HelpLink %>" 
                  TARGET="_blank">Guida</A></TD>
													</TR>
												</TABLE>
											</COLLAPSE:DATAPANEL></TD>
									</TR>
									<TR>
										<TD valign="top" align="center" width="100%">
									<TR>
										<TD><IEWC:TABSTRIP id="TabStrip1" runat="server" width="100%" autopostback="True" tabdefaultstyle="background-color:darkgray;font-family:verdana;font-weight:bold;font-size:8pt;color:#ffffff;width:79;height:21;text-align:center;border-style:outset;border-width:1;"
												tabhoverstyle="background-color:#777777;border-style:inset;border-width:1;" tabselectedstyle="background-color:#ffffff;color:#000000;border-style:inset;">
												<IEWC:TAB text="Tutte le Manutenzioni"></IEWC:TAB>
												<IEWC:TAB text="Manutenzione su Richiesta"></IEWC:TAB>
												<IEWC:TAB text="Manutenzione Programmata"></IEWC:TAB>
												<IEWC:TAB text="Manutenzione Straordinaria"></IEWC:TAB>
											</IEWC:TABSTRIP></TD>
									</TR>
						</TD>
					</TR>
					<TR>
						<TD valign="top" align="center" width="100%"><UC1:GRIDTITLE id="GridTitle1" runat="server"></UC1:GRIDTITLE><ASP:DATAGRID id="DataGridRicerca" runat="server" cssclass="DataGrid" allowpaging="True" bordercolor="Gray"
								borderwidth="1px" gridlines="Vertical" autogeneratecolumns="False">
								<ALTERNATINGITEMSTYLE cssclass="DataGridAlternatingItemStyle"></ALTERNATINGITEMSTYLE>
								<ITEMSTYLE cssclass="DataGridItemStyle"></ITEMSTYLE>
								<HEADERSTYLE cssclass="DataGridHeaderStyle"></HEADERSTYLE>
								<COLUMNS>
									<ASP:BOUNDCOLUMN datafield="WR_ID" headertext="RdL"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="DATA_WR" headertext="Data Creazione" dataformatstring="{0:d}"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="WO_ID" headertext="OdL"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="PIANIFICATA" headertext="Data Pianificata" dataformatstring="{0:d}"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="COMPLETATA" headertext="Data Fine Lavori" dataformatstring="{0:d}"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="STATO" headertext="Stato Richiesta"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="DESCRIZIONE" headertext="Descrizione"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="ADDETTO" headertext="Addetto"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="Manutenzione" headertext="Manutenzione"></ASP:BOUNDCOLUMN>
								</COLUMNS>
								<PAGERSTYLE horizontalalign="Left" cssclass="DataGridPagerStyle" mode="NumericPages"></PAGERSTYLE>
							</ASP:DATAGRID></TD>
					</TR>
				</TBODY>
			</TABLE>
			</TD></TR></TBODY></TABLE></FORM>
		</TD></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
