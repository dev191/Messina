<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Page language="c#" Codebehind="ApprovaRDL.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorrettiva.ApprovaRDL" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprovaRdl</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
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
		
		</script>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; POSITION: absolute; TOP: 0px; LEFT: 0px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" height="95%">
							<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
								<TBODY>
									<TR>
										<TD style="HEIGHT: 25.11%" vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" TitleStyle-CssClass="TitleSearch" CssClass="DataPanel75"
												TitleText="Ricerca" AllowTitleExpandCollapse="True" Collapsed="False" ExpandText="Espandi" CollapseText="Riduci" CollapseImageUrl="../Images/up.gif"
												ExpandImageUrl="../Images/down.gif">
												<TABLE id="tblSearch100" border="0" cellSpacing="1" cellPadding="2">
													<TR>
														<TD colSpan="4" align="left">
															<uc1:RicercaModulo id="RicercaModulo1" runat="server"></uc1:RicercaModulo></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 22px" width="13%" align="left">Richiesta</TD>
														<TD style="HEIGHT: 22px" width="30%">
															<cc1:s_textbox id="txtsRichiesta" runat="server" DBParameterName="p_Wr_Id" DBDirection="Input"
																width="100px" DBSize="255"></cc1:s_textbox></TD>
														<TD style="HEIGHT: 26px" width="15%" align="left">Operatore</TD>
														<TD style="HEIGHT: 26px" width="30%">
															<cc1:s_textbox id="txtsOperatore" tabIndex="1" runat="server" DBParameterName="p_Operatore" DBDirection="Input"
																width="75%" DBSize="10" DBIndex="8"></cc1:s_textbox></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 22px" align="left">Data Da:</TD>
														<TD style="HEIGHT: 22px">
															<uc1:CalendarPicker id="CalendarPicker1" runat="server"></uc1:CalendarPicker></TD>
														<TD style="HEIGHT: 22px" align="left">Data A:</TD>
														<TD style="HEIGHT: 22px">
															<uc1:CalendarPicker id="CalendarPicker2" runat="server"></uc1:CalendarPicker>
															<asp:CompareValidator id="CompareValidator1" runat="server" Type="Date" Operator="GreaterThanEqual" ErrorMessage="Data non valida!"></asp:CompareValidator></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 23px" align="left">Richiedente</TD>
														<TD style="HEIGHT: 23px">
															<uc1:Richiedenti id="Richiedenti1" runat="server"></uc1:Richiedenti></TD>
														<TD style="HEIGHT: 23px" align="left">Gruppo</TD>
														<TD style="HEIGHT: 23px">
															<cc1:S_ComboBox id="cmbsGruppo" runat="server" DBParameterName="p_Gruppo" DBDirection="Input" DBIndex="4"
																DBDataType="Integer" Width="75%"></cc1:S_ComboBox></TD>
													</TR>
													<TR>
														<TD align="left">Descrizione</TD>
														<TD>
															<cc1:s_textbox id="txtsDescrizione" runat="server" DBParameterName="p_Descrizione" DBDirection="Input"
																width="300px" DBSize="255" DBIndex="5"></cc1:s_textbox></TD>
														<TD align="left">Priorità</TD>
														<TD>
															<cc1:S_ComboBox id="cmbsUrgenza" runat="server" DBParameterName="p_Urgenza" DBDirection="Input"
																DBIndex="6" DBDataType="Integer" Width="75%"></cc1:S_ComboBox></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 19px" align="left">Servizio</TD>
														<TD style="HEIGHT: 19px">
															<cc1:S_ComboBox id="cmbsServizio" runat="server" DBParameterName="p_Servizio" DBDirection="Input"
																DBIndex="7" DBDataType="Integer" Width="300px"></cc1:S_ComboBox></TD>
														<TD>Validazione</TD>
														<TD>
															<cc1:S_ComboBox id="cmbsvalidazione" runat="server" DBParameterName="p_validazione" DBDirection="Input"
																DBIndex="8" DBDataType="Integer" Width="75%">
																<asp:ListItem Value="0">Tutte le Richieste</asp:ListItem>
																<asp:ListItem Value="1">Richieste non ancora validate</asp:ListItem>
																<asp:ListItem Value="3">Richieste validate DL</asp:ListItem>
															</cc1:S_ComboBox></TD>
													</TR>
													<TR>
														<TD colSpan="4" align="left"></TD>
													</TR>
													<TR>
														<TD colSpan="3" align="left">
															<cc1:s_button id="btnsRicerca" tabIndex="2" runat="server" Text="Ricerca"></cc1:s_button>&nbsp;&nbsp;
															<asp:Button id="cmdReset" Text="Reset" Runat="server"></asp:Button>&nbsp;
														</TD>
														<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
													</TR>
												</TABLE>
											</COLLAPSE:DATAPANEL></TD>
									</TR>
									<tr>
										<TD style="HEIGHT: 3%" align="center"></TD>
									</tr>
									<TR>
										<TD style="HEIGHT: 72%" vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AutoGenerateColumns="False"
												GridLines="Vertical" BorderWidth="1px" BorderColor="Gray" AllowPaging="True" AllowCustomPaging="True">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:ImageButton id="lnkDett" Runat=server CommandName="Dettaglio" ImageUrl="../images/edit.gif" CommandArgument='<%# "CompletaRdl.aspx?wr_id=" + DataBinder.Eval(Container.DataItem,"ID")%>'>
															</asp:ImageButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="bl_id" HeaderText="Cod. Edificio">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="indirizzo" HeaderText="Indirizzo">
														<HeaderStyle Width="15%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="id" HeaderText="N. RdL">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="datardl" HeaderText="Data RdL" DataFormatString="{0:d}">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="stato_descrizione_estesa" HeaderText="Stato"></asp:BoundColumn>
													<asp:BoundColumn DataField="servizio_descrizione" HeaderText="Servizio"></asp:BoundColumn>
													<asp:BoundColumn DataField="descrizione" HeaderText="Descrizione"></asp:BoundColumn>
													<asp:BoundColumn DataField="urgenza_descrizione" HeaderText="Urgenza"></asp:BoundColumn>
													<asp:BoundColumn DataField="operatore" HeaderText="Operatore"></asp:BoundColumn>
													<asp:BoundColumn DataField="richiedente" HeaderText="Richiedente"></asp:BoundColumn>
													<asp:BoundColumn DataField="gruppo" HeaderText="Gruppo"></asp:BoundColumn>
													<asp:BoundColumn DataField="DCSIT" HeaderText="Validazione"></asp:BoundColumn>
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
