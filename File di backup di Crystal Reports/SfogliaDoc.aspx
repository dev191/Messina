<%@ Page language="c#" Codebehind="SfogliaDoc.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorrettiva.SfogliDoc" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
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
	<body bottomMargin="0" onbeforeunload="parent.left.valorizza()" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="0"
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
												<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
													<TR>
														<TD align="left" colSpan="4">
															<uc1:RicercaModulo id="RicercaModulo1" runat="server"></uc1:RicercaModulo></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 22px" align="left" width="13%">Numero Richiesta</TD>
														<TD style="HEIGHT: 22px" width="30%">
															<cc1:s_textbox id="TxtWr_id" runat="server" DBSize="255" width="100px" DBDirection="Input" DBParameterName="p_Wr_Id"></cc1:s_textbox></TD>
														<TD style="HEIGHT: 26px" align="left" width="15%">Codice</TD>
														<TD style="HEIGHT: 26px" width="30%">
															<cc1:s_textbox id="TxtCodice" runat="server" DBSize="255" width="192px" DBDirection="Input"></cc1:s_textbox></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 22px" align="left" width="13%">Nome Documento</TD>
														<TD style="HEIGHT: 22px" width="30%">
															<cc1:s_textbox id="TxtNomeDoc" runat="server" DBSize="255" width="264px" DBDirection="Input" DBParameterName="p_NOME_DOC"></cc1:s_textbox></TD>
														<TD style="HEIGHT: 26px" align="left" width="15%">Tipo Documento</TD>
														<TD style="HEIGHT: 26px" width="30%">
															<CC1:S_COMBOBOX id="cmbsTipoDoc" runat="server" width="196px">
																<asp:ListItem Value="TUTTI" Selected="True">Tutti</asp:ListItem>
																<asp:ListItem Value="SGA">SGA</asp:ListItem>
																<asp:ListItem Value="DIE">DIE</asp:ListItem>
																<asp:ListItem Value="XLS">RPC</asp:ListItem>
															</CC1:S_COMBOBOX></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 22px" align="left">Data Invio:</TD>
														<TD style="HEIGHT: 22px">
															<uc1:CalendarPicker id="CalendarPicker1" runat="server"></uc1:CalendarPicker></TD>
														<TD style="HEIGHT: 22px" align="left">Utente</TD>
														<TD style="HEIGHT: 22px">
															<cc1:s_textbox id="txtUtente" runat="server" DBSize="255" width="192px" DBDirection="Input"></cc1:s_textbox></TD>
													</TR>
													<TR>
														<TD align="left" colSpan="4"></TD>
													</TR>
													<TR>
														<TD align="left" colSpan="3">
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
												<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="id_traccia_doc" HeaderText="ID"></asp:BoundColumn>
													<asp:TemplateColumn HeaderText="Download">
														<HeaderStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:ImageButton id="btScarica" Runat="server" CommandArgument='<%#  DataBinder.Eval(Container.DataItem,"id_wr") + "," + DataBinder.Eval(Container.DataItem,"nome_doc")%>' ImageUrl="../images/w.gif" CommandName="Download">
															</asp:ImageButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="ReInvia">
														<HeaderStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:ImageButton id=btSend Runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id_wr")  + "," + DataBinder.Eval(Container.DataItem,"nome_doc")%>' ImageUrl="../images/mail.gif" CommandName="Invio">
															</asp:ImageButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="codice_bl" HeaderText="Cod. Edificio">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:HyperLinkColumn DataNavigateUrlField="id_wr" DataNavigateUrlFormatString="CompletaRdl.aspx?wr_id={0}&amp;FunId={0}&amp;chiamante=SfogliaDoc"
														DataTextField="id_wr" HeaderText="N. RdL"></asp:HyperLinkColumn>
													<asp:BoundColumn DataField="codice" HeaderText="Codice"></asp:BoundColumn>
													<asp:BoundColumn DataField="nome_doc" HeaderText="Nome Documento"></asp:BoundColumn>
													<asp:BoundColumn DataField="tipo_doc" HeaderText="Tipo Doc.">
														<HeaderStyle Width="50px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="data_invio" HeaderText="Data Invio"></asp:BoundColumn>
													<asp:BoundColumn DataField="users" HeaderText="Utente"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="id"></asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<a href='<%# "DettDestinatariInvio.aspx?Wr_id=" + DataBinder.Eval(Container.DataItem,"id_wr")+ "&Tipo_doc=" + DataBinder.Eval(Container.DataItem,"tipo_doc")+ "&bl_id=" + DataBinder.Eval(Container.DataItem,"id")%>' target=_blank runat="server" id="imagefull">
																<img id="imgdoc" runat="server" src="../Images/Dt.JPG" align="middle" border="0">
															</a>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Left" CssClass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
