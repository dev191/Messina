<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BottomMenu" Src="../../WebControls/BottomMenu.ascx" %>
<%@ Page language="c#" Codebehind="OttimizzaPiano.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.Schedula.OttimizzaPiano" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>OttimizzaPiano</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0"
				height="100%">
				<TBODY>
					<TR valign="top">
						<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR valign="top">
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="1" cellPadding="1" align="center" width="98%">
								<TBODY>
									<TR valign="top">
										<TD vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" ExpandImageUrl="../../Images/down.gif" CollapseImageUrl="../../Images/up.gif"
												CollapseText="Riduci" ExpandText="Espandi" Collapsed="False" AllowTitleExpandCollapse="True" TitleText="Ricerca" CssClass="DataPanel75"
												TitleStyle-CssClass="TitleSearch">
												<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
													<TR vAlign="top">
														<TD style="HEIGHT: 14px" align="left">Anno:
														</TD>
														<TD style="HEIGHT: 14px">
															<CC1:S_COMBOBOX id="cmbsAnno" runat="server" Width="288px" DBSize="5" DBDirection="Input" DBIndex="5"
																DBDataType="Integer" AutoPostBack="True">
																<ASP:LISTITEM Value="1990">1990</ASP:LISTITEM>
																<ASP:LISTITEM Value="1991">1991</ASP:LISTITEM>
																<ASP:LISTITEM Value="1992">1992</ASP:LISTITEM>
																<ASP:LISTITEM Value="1993">1993</ASP:LISTITEM>
																<ASP:LISTITEM Value="1994">1994</ASP:LISTITEM>
																<ASP:LISTITEM Value="1995">1995</ASP:LISTITEM>
																<ASP:LISTITEM Value="1996">1996</ASP:LISTITEM>
																<ASP:LISTITEM Value="1997">1997</ASP:LISTITEM>
																<ASP:LISTITEM Value="1998">1998</ASP:LISTITEM>
																<ASP:LISTITEM Value="1999">1999</ASP:LISTITEM>
																<ASP:LISTITEM Value="2000">2000</ASP:LISTITEM>
																<ASP:LISTITEM Value="2001">2001</ASP:LISTITEM>
																<ASP:LISTITEM Value="2002">2002</ASP:LISTITEM>
																<ASP:LISTITEM Value="2003">2003</ASP:LISTITEM>
																<ASP:LISTITEM Value="2004">2004</ASP:LISTITEM>
																<ASP:LISTITEM Value="2005">2005</ASP:LISTITEM>
																<ASP:LISTITEM Value="2006">2006</ASP:LISTITEM>
																<ASP:LISTITEM Value="2007">2007</ASP:LISTITEM>
																<ASP:LISTITEM Value="2008">2008</ASP:LISTITEM>
																<ASP:LISTITEM Value="2009">2009</ASP:LISTITEM>
																<ASP:LISTITEM Value="2010">2010</ASP:LISTITEM>
																<ASP:LISTITEM Value="2011">2011</ASP:LISTITEM>
																<ASP:LISTITEM Value="2012">2012</ASP:LISTITEM>
																<ASP:LISTITEM Value="2013">2013</ASP:LISTITEM>
																<ASP:LISTITEM Value="2014">2014</ASP:LISTITEM>
																<ASP:LISTITEM Value="2015">2015</ASP:LISTITEM>
															</CC1:S_COMBOBOX></TD>
														<TD style="HEIGHT: 14px" align="left">Edificio:
														</TD>
														<TD style="HEIGHT: 14px">
															<CC1:S_COMBOBOX id="cmbsEdificio" runat="server" Width="288px" DBSize="5" DBDirection="Input" DBIndex="5"
																DBDataType="Integer" AutoPostBack="True" DBParameterName="p_Ditta"></CC1:S_COMBOBOX></TD>
													</TR>
													<TR vAlign="top">
														<TD align="left">Comune:
														</TD>
														<TD>
															<CC1:S_COMBOBOX id="cmbsComune" runat="server" Width="288px" DBSize="5" DBDirection="Input" DBIndex="5"
																DBDataType="Integer" AutoPostBack="True" DBParameterName="p_Ditta"></CC1:S_COMBOBOX></TD>
														<TD align="left">Servizio:&nbsp;</TD>
														<TD>
															<CC1:S_COMBOBOX id="cmbsServizio" runat="server" Width="288px" DBSize="5" DBDirection="Input" DBIndex="5"
																DBDataType="Integer" AutoPostBack="False" DBParameterName="p_Ditta"></CC1:S_COMBOBOX></TD>
													</TR>
													<TR vAlign="top">
														<TD></TD>
														<TD align="left" colSpan="3"></TD>
													</TR>
													<TR vAlign="top">
														<TD align="left" colSpan="3">
															<CC1:S_BUTTON id="btnsRicerca" tabIndex="2" runat="server" CssClass="btn" Text="Ricerca"></CC1:S_BUTTON>&nbsp;
															<asp:Button id="cmdReset" CssClass="btn" Text="Reset" Runat="server"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
														<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
													</TR>
												</TABLE>
											</COLLAPSE:DATAPANEL>
										</TD>
									</TR>
									<TR valign="top">
										<TD vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle>
											<asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AllowPaging="True" BorderColor="Gray"
												BorderWidth="1px" GridLines="Vertical" AutoGenerateColumns="False" AllowCustomPaging="True">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="INDICE" HeaderText="INDICE"></asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="20px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:ImageButton id="lnkDett" Runat=server CommandName="Dettaglio" ImageUrl="../../images/edit.gif" CommandArgument='<%# "OttimizzaPianoEQ.aspx?ID_BL=" + DataBinder.Eval(Container.DataItem,"BL_ID") + "&anno=" + cmbsAnno.SelectedValue + "&servizio=" + DataBinder.Eval(Container.DataItem,"IDSERVIZIO") +"&p=ottimizza"%>'>
															</asp:ImageButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="campus" HeaderText="EDIFICIO">
														<ItemStyle Font-Size="9px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="SERVIZIO" HeaderText="SERVIZIO">
														<ItemStyle Font-Size="9px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="TEMPO_STIMATO" HeaderText="TEMPO STIMATO"></asp:BoundColumn>
													<asp:BoundColumn DataField="TOT_ATTIVITA" HeaderText="TOT ATTIVITA'"></asp:BoundColumn>
													<asp:BoundColumn DataField="TOT_APP" HeaderText="NUM APPARECCHIATURE"></asp:BoundColumn>
													<asp:BoundColumn DataField="GEN" HeaderText="GEN">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="FEB" HeaderText="FEB">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="MAR" HeaderText="MAR">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="APR" HeaderText="APR">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="MAG" HeaderText="MAG">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="GIU" HeaderText="GIU">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="LUG" HeaderText="LUG">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="AGO" HeaderText="AGO">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="SETT" HeaderText="SET">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="OTT" HeaderText="OTT">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="NOV" HeaderText="NOV">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="DIC" HeaderText="DIC">
														<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Left" ForeColor="Black" BackColor="#D9E3FD" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
					<tr valign="bottom">
						<td><uc1:BottomMenu id="BottomMenu1" runat="server"></uc1:BottomMenu></td>
					</tr>
				</TBODY>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
