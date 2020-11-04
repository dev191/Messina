<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="CreazioneODL_MP.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.CreazioneODL_MP" %>
<%@ Register TagPrefix="uc1" TagName="Addetti" Src="../../WebControls/Addetti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BottomMenu" Src="../../WebControls/BottomMenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprovaRdl</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/MainSheet.css" type="text/css" rel="stylesheet">
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
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0"
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
										<TD vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" ExpandImageUrl="../../Images/down.gif" CollapseImageUrl="../../Images/up.gif"
												CollapseText="Riduci" ExpandText="Espandi" Collapsed="False" AllowTitleExpandCollapse="True" TitleText="Ricerca" CssClass="DataPanel75"
												TitleStyle-CssClass="TitleSearch">
												<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
													<TR>
														<TD style="WIDTH: 46px" align="left">Anno:
														</TD>
														<TD>
															<cc1:S_ComboBox id="cmbsAnno" runat="server" Width="288px" DBSize="5" DBDirection="Input" DBIndex="5"
																DBDataType="Integer" AutoPostBack="True">
																<asp:ListItem Value="1990">1990</asp:ListItem>
																<asp:ListItem Value="1991">1991</asp:ListItem>
																<asp:ListItem Value="1992">1992</asp:ListItem>
																<asp:ListItem Value="1993">1993</asp:ListItem>
																<asp:ListItem Value="1994">1994</asp:ListItem>
																<asp:ListItem Value="1995">1995</asp:ListItem>
																<asp:ListItem Value="1996">1996</asp:ListItem>
																<asp:ListItem Value="1997">1997</asp:ListItem>
																<asp:ListItem Value="1998">1998</asp:ListItem>
																<asp:ListItem Value="1999">1999</asp:ListItem>
																<asp:ListItem Value="2000">2000</asp:ListItem>
																<asp:ListItem Value="2001">2001</asp:ListItem>
																<asp:ListItem Value="2002">2002</asp:ListItem>
																<asp:ListItem Value="2003">2003</asp:ListItem>
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
															</cc1:S_ComboBox></TD>
														<TD>Mesi:</TD>
														<TD>Da:
															<cc1:S_ComboBox id="cmbMeseDa" runat="server"></cc1:S_ComboBox>&nbsp;A:
															<cc1:S_ComboBox id="cmbMeseA" runat="server"></cc1:S_ComboBox></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 46px; HEIGHT: 14px">Comune:</TD>
														<TD style="HEIGHT: 14px">
															<cc1:S_ComboBox id="cmbsComune" runat="server" Width="288px" DBSize="5" DBDirection="Input" DBIndex="5"
																DBDataType="Integer" AutoPostBack="True" DBParameterName="p_Ditta"></cc1:S_ComboBox></TD>
														<TD style="HEIGHT: 14px">Edificio:
														</TD>
														<TD style="HEIGHT: 14px">
															<cc1:S_ComboBox id="cmbsEdificio" runat="server" Width="288px" DBSize="5" DBDirection="Input" DBIndex="5"
																DBDataType="Integer" AutoPostBack="True" DBParameterName="p_Ditta"></cc1:S_ComboBox></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 46px" align="left">Servizio:</TD>
														<TD>
															<cc1:S_ComboBox id="cmbsServizio" runat="server" Width="288px" DBSize="5" DBDirection="Input" DBIndex="5"
																DBDataType="Integer" AutoPostBack="False" DBParameterName="p_Ditta"></cc1:S_ComboBox></TD>
														<TD align="left">Addetto:&nbsp;
														</TD>
														<TD>
															<cc1:S_ComboBox id="cmbsAddetti" runat="server" Width="288px" DBSize="5" DBDirection="Input" DBIndex="5"
																DBDataType="Integer" DBParameterName="p_Ditta"></cc1:S_ComboBox></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 46px"></TD>
														<TD align="left" colSpan="3"></TD>
													</TR>
													<TR>
														<TD align="left" colSpan="3">
															<cc1:s_button id="btnsRicerca" tabIndex="2" runat="server" CssClass="btn" Text="Ricerca"></cc1:s_button>&nbsp;
															<asp:Button id="cmdReset" CssClass="btn" Text="Reset" Runat="server"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
															<INPUT id="txtHidden" type="hidden" value="0">
															<asp:TextBox id="txtTotSelezionati" runat="server" Width="0px">0</asp:TextBox></TD>
														<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
													</TR>
												</TABLE>
											</COLLAPSE:DATAPANEL></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 72%" vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AllowPaging="True" BorderColor="Gray"
												BorderWidth="1px" GridLines="Vertical" AutoGenerateColumns="False" AllowCustomPaging="True">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="INDICE" HeaderText="INDICE"></asp:BoundColumn>
													<asp:TemplateColumn HeaderText="&lt;input id='ChkSelTutti' type='Checkbox' onclick='SelCheckbox()'&gt;">
														<HeaderStyle HorizontalAlign="Center" Width="3%" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:CheckBox ID="ChkSel" Runat="server"></asp:CheckBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="BL_ID" HeaderText="BL_ID">
														<ItemStyle Font-Size="9px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CAMPUS" HeaderText="EDIFICIO">
														<ItemStyle Font-Size="9px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="SERVIZIO" HeaderText="SERVIZIO">
														<ItemStyle Font-Size="9px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="IDSERVIZIO" HeaderText="IDSERVIZIO"></asp:BoundColumn>
													<asp:BoundColumn DataField="ADDETTO" HeaderText="ADDETTO"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="IDADDETTO" HeaderText="IDADDETTO"></asp:BoundColumn>
													<asp:BoundColumn DataField="WR_COUNT" HeaderText="RDL">
														<ItemStyle Font-Size="9px"></ItemStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Left" CssClass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
									<tr>
										<td><asp:panel id="PanelCrea" runat="server" Visible="False">
												<TABLE align="center">
													<TR>
														<TD>
															<cc1:s_button id="btnsCrea" runat="server" CssClass="btn" Width="130px" Text="Crea Ordine di Lavoro"
																Visible="true"></cc1:s_button></TD>
														<TD>
															<cc1:s_button id="btnsSelezionaTutti" runat="server" CssClass="btn" Width="130px" Text="Seleziona Tutti"
																Visible="true"></cc1:s_button></TD>
														<TD>
															<cc1:s_button id="btnsDeSelezionaTutti" runat="server" CssClass="btn" Width="130px" Text="Deseleziona Tutti"
																Visible="true"></cc1:s_button></TD>
														<TD>
															<cc1:s_button id="btnsConfermaSelezioni" runat="server" CssClass="btn" Width="130px" Text="Conferma Selezioni"
																Visible="true"></cc1:s_button></TD>
														<TD>&nbsp;&nbsp;&nbsp;
															<asp:label id="LblElementiSelezionati" runat="server">0</asp:label></TD>
													</TR>
												</TABLE>
											</asp:panel></td>
									</tr>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="bottom"><uc1:bottommenu id="BottomMenu1" runat="server"></uc1:bottommenu></TD>
					</TR>
				</TBODY>
			</TABLE>
			</TD></TR></TBODY></TABLE></TD></TR></form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
