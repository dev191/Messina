<%@ Page language="c#" Codebehind="CreaPianoMp.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.CreaPianoMP" %>
<%@ Register TagPrefix="uc1" TagName="Addetti" Src="../WebControls/Addetti.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BottomMenu2" Src="../WebControls/BottomMenu2.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprovaRdl</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
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
			
		</script>
	</HEAD>
	<body bottomMargin="0" onbeforeunload="parent.left.valorizza()" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" onsubmit="return ControllaEdifici()" method="post" runat="server">
			<TABLE id="TableMain" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="1" cellPadding="1" width="98%" align="center">
								<TBODY>
									<TR>
										<TD vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" TitleStyle-CssClass="TitleSearch" CssClass="DataPanel75"
												TitleText="Ricerca" AllowTitleExpandCollapse="True" Collapsed="False" ExpandText="Espandi" CollapseText="Riduci" CollapseImageUrl="../Images/up.gif"
												ExpandImageUrl="../Images/down.gif">
												<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
													<TR>
														<TD align="left" colSpan="4">
															<uc1:RicercaModulo id="RicercaModulo1" runat="server"></uc1:RicercaModulo></TD>
													</TR>
													<TR>
														<TD align="left">Servizio</TD>
														<TD colSpan="3">
															<cc1:S_ComboBox id="cmbsServizio" runat="server" Width="384px" DBDataType="Integer" DBIndex="6"
																DBParameterName="p_Servizio" DBDirection="Input" DBSize="5"></cc1:S_ComboBox></TD>
													</TR>
													<TR>
														<TD align="left">Ditta</TD>
														<TD>
															<cc1:S_ComboBox id="cmbsDitta" runat="server" Width="384px" DBDataType="Integer" DBIndex="5" DBParameterName="p_Ditta"
																DBDirection="Input" DBSize="5" AutoPostBack="True"></cc1:S_ComboBox></TD>
														<TD align="left">Anno</TD>
														<TD>
															<cc1:S_ComboBox id="cmbsAnnoA" runat="server" Width="200px" DBDataType="Integer" DBIndex="5" DBParameterName="p_Ditta"
																DBDirection="Input" DBSize="5" AutoPostBack="False"></cc1:S_ComboBox></TD>
													</TR>
													<TR>
														<TD>Addetti</TD>
														<TD align="left" colSpan="3">
															<uc1:Addetti id="Addetti1" runat="server"></uc1:Addetti></TD>
													</TR>
													<TR>
														<TD align="left" colSpan="3">
															<cc1:s_button id="btnsRicerca" tabIndex="2" runat="server" CssClass="btn" Text="Ricerca"></cc1:s_button>&nbsp;
															<asp:Button id="cmdReset" CssClass="btn" Text="Reset" Runat="server"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
															<INPUT id="txtHidden" type="hidden" value="0">
															<asp:TextBox id="txtTotSelezionati" runat="server" Width="0px">0</asp:TextBox></TD>
														<TD align="right"><A class="GuidaLink" href="<%= HelpLink %>" 
                  target="_blank">Guida</A></TD>
													</TR>
												</TABLE>
											</COLLAPSE:DATAPANEL></TD>
									</TR>
									<TR>
										<TD vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AllowPaging="True" BorderColor="Gray"
												BorderWidth="1px" GridLines="Vertical" AutoGenerateColumns="False" AllowCustomPaging="True">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="id_bl" HeaderText="id_bl"></asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle HorizontalAlign="Center" Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<HeaderTemplate>
															<INPUT type="checkbox" id="ChkSelTutti" onclick="SelCheckbox()">
														</HeaderTemplate>
														<ItemTemplate>
															<asp:CheckBox id="ChkSel" Runat="server"></asp:CheckBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="id_ditta" HeaderText="IdDitta">
														<HeaderStyle Width="15%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="id_servizio" HeaderText="id_servizio">
														<HeaderStyle Width="20%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="id_addetto" HeaderText="id_addetto">
														<HeaderStyle Width="20%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="codice_edificio" HeaderText="Edificio"></asp:BoundColumn>
													<asp:BoundColumn DataField="Servizio" HeaderText="Servizio"></asp:BoundColumn>
													<asp:BoundColumn DataField="ditta" HeaderText="Ditta"></asp:BoundColumn>
													<asp:BoundColumn DataField="Addetto" HeaderText="Addetto"></asp:BoundColumn>
													<asp:BoundColumn DataField="Anno" HeaderText="Ultima Schedulazione"></asp:BoundColumn>
													<asp:BoundColumn DataField="dataini" HeaderText="Data Inizio"></asp:BoundColumn>
													<asp:BoundColumn DataField="date_start" HeaderText="Data Start"></asp:BoundColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
									<tr>
										<td><asp:panel id="PanelCrea" runat="server" Visible="False">
												<TABLE align="center">
													<TR>
														<TD><cc1:s_button id="btnsCrea" runat="server" CssClass="btn" Width="130px" Text="Crea Piano" Visible="true"></cc1:s_button></TD>
														<TD><cc1:s_button id="btnsSelezionaTutti" runat="server" CssClass="btn" Width="130px" Text="Seleziona Tutti"
																Visible="true"></cc1:s_button></TD>
														<TD><cc1:s_button id="btnsDeSelezionaTutti" runat="server" CssClass="btn" Width="130px" Text="Deseleziona Tutti"
																Visible="true"></cc1:s_button></TD>
														<TD><cc1:s_button id="btnsConfermaSelezioni" runat="server" CssClass="btn" Width="130px" Text="Conferma Selezioni"
																Visible="true"></cc1:s_button></TD>
														<TD>&nbsp;&nbsp;&nbsp;
															<asp:label id="LblElementiSelezionati" runat="server">0</asp:label></TD>
													</TR>
												</TABLE></td>
									</tr>
									</asp:panel></TBODY></TABLE>
						</TD>
					</TR>
					<tr>
						<td vAlign="bottom"><uc1:bottommenu2 id="BottomMenu1" runat="server"></uc1:bottommenu2></td>
					</tr>
				</TBODY>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
