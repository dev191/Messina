<%@ Page language="c#" Codebehind="DettPianoAnnuale.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.DettPianoAnnuale" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Piano Annuale</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="<%=DirectoryUp%>../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		var finestra;	
		function ChiudiFiglia()
		{
			if (finestra!=null)
			{
				finestra.close();				
			}
		}
		function Dettaglio(ID,EQ_ID,anno)
		{					
			var url;
			url = "PassiPianoAnnuale.aspx?ID="+ID+"&EQ_ID="+EQ_ID+"&anno="+anno;
			finestra = window.open(url,'dett','menubar=no,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width=800,height=600,align=center');						
		}			
		function UpdateDettaglio(ID,EQ_ID,anno,id_bl,bl_id)
		{					
			var url;
			url = "../PassiPianoAnnuale.aspx?ID="+ID+"&EQ_ID="+EQ_ID+"&anno="+anno + "&p=ottimizza&id_bl=" + id_bl + "&bl_id=" + bl_id;
			finestra = window.open(url,'dett','menubar=no,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width=800,height=600,align=center');						
		}	
		</script>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" title="Piano Annuale" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
								<TBODY>
									<TR>
										<TD vAlign="top" align="left"><asp:label id="lblpmp" CssClass="TitleOperazione" Runat="server"></asp:label><asp:textbox id="txtAnno" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtID_BL" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtServizio" runat="server" Visible="False"></asp:textbox></TD>
									</TR>
									<tr vAlign="top">
										<TD align="center"></TD>
									</tr>
									<TR vAlign="top">
										<TD vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" BorderColor="Gray" BorderWidth="1px"
												AutoGenerateColumns="False" GridLines="Vertical" AllowPaging="True" PageSize="60">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<a runat="server" id="LNK"><img src="<%=DirectoryUp%>../Images/edit.gif" border="0"></a>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="EQ_ID" HeaderText="APPARECCHIATURA"></asp:BoundColumn>
													<asp:BoundColumn DataField="ADDETTI" HeaderText="ADDETTO"></asp:BoundColumn>
													<asp:BoundColumn DataField="FREQUENZE" HeaderText="RAGGR. FREQUENZE"></asp:BoundColumn>
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
													<asp:BoundColumn DataField="SET" HeaderText="SET">
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
													<asp:BoundColumn Visible="False" DataField="BL_ID" HeaderText="BL_ID"></asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Left" CssClass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
									<tr>
										<td><!--<input type="button" id="cmdBack" value="Indietro" onclick="javascript:history.back()">--><asp:button id="cmdIndietro" runat="server" Text="Indietro" CssClass="btn"></asp:button></td>
									</tr>
									<TR vAlign="top">
										<TD vAlign="top" align="left"><asp:linkbutton id="lkbInfo" runat="server" CssClass="LabelInfo" CausesValidation="False">Legenda</asp:linkbutton><asp:panel id="pnlShowInfo" runat="server" CssClass="ShowInfoPanel350" Visible="False">
												<TABLE height="100%" width="100%">
													<TBODY>
														<TR>
															<TD class="TitleSearch" vAlign="top" align="right" colSpan="2" height="15"><asp:linkbutton id="lnkChiudi" runat="server" CssClass="LabelChiudi" CausesValidation="False">Chiudi</asp:linkbutton></TD>
														</TR>
														<TR>
															<TD vAlign="top"><asp:repeater id="rptFrequenze" runat="server">
																	<HeaderTemplate>
																		<TABLE class="BordiTabella" id="tblFrequenze" cellSpacing="0" cellPadding="2">
																			<tr class="tabblu">
																				<td colspan="2">Frequenze</td>
																			</tr>
																			<TR>
																				<TD class="BordiCellaTop"><FONT face="Arial" size="2">Frequenza</FONT></TD>
																				<TD class="BordiCellaRTop" bgColor="#ffffff"><FONT face="Arial" size="2">Descrizione</FONT></TD>
																			</TR>
																	</HeaderTemplate>
																	<ItemTemplate>
																		<tr>
																			<TD class="BordiCella" align="center"><FONT face="Arial" size="2">
																					<%# DataBinder.Eval(Container.DataItem, "Freq") %>
																				</FONT>
																			</TD>
																			<TD class="BordiCellaR" bgColor="#ffffff"><FONT face="Arial" size="2">
																					<%# DataBinder.Eval(Container.DataItem, "Des") %>
																				</FONT>
																			</TD>
																		</tr>
																	</ItemTemplate>
																	<FooterTemplate>
												</TABLE>
											</FooterTemplate> </asp:repeater></TD>
										<TD vAlign="top">
											<TABLE class="BordiTabella" id="tblInterventi" cellSpacing="0" cellPadding="2">
												<TR class="tabblu">
													<TD colSpan="2">Calendario</TD>
												<TR>
													<TD class="BordiCellaTop"><FONT face="Arial" size="2">Num. Interventi</FONT></TD>
													<TD class="BordiCellaRTop" bgColor="#ffffff"><FONT face="Arial" size="2">Colore</FONT></TD>
												</TR>
												<TR>
													<TD class="BordiCella" align="center"><FONT face="Arial" size="2">Uno</FONT></TD>
													<TD class="BordiCellaR" bgColor="#808080">&nbsp;</TD>
												</TR>
												<TR>
													<TD class="BordiCella" align="center" bgColor="#00ff00"><FONT face="Arial" size="2">Due</FONT></TD>
													<TD class="BordiCellaR" bgColor="#00ff00">&nbsp;</TD>
												</TR>
												<TR>
													<TD class="BordiCella" align="center"><FONT face="Arial" size="2">Tre</FONT></TD>
													<TD class="BordiCellaR" bgColor="#008000">&nbsp;</TD>
												</TR>
												<TR>
													<TD class="BordiCella" align="center"><FONT face="Arial" size="2">Quattro</FONT></TD>
													<TD class="BordiCellaR" bgColor="#0000ff">&nbsp;</TD>
												</TR>
												<TR>
													<TD class="BordiCella" align="center"><FONT face="Arial" size="2">Cinque</FONT></TD>
													<TD class="BordiCellaR" bgColor="#000080">&nbsp;</TD>
												</TR>
												<TR>
													<TD class="BordiCella" align="center"><FONT face="Arial" size="2">Sei</FONT></TD>
													<TD class="BordiCellaR" bgColor="#c00000">&nbsp;</TD>
												</TR>
												<TR>
													<TD class="BordiCella" align="center"><FONT face="Arial" size="2">Sette +</FONT></TD>
													<TD bgColor="#800000">&nbsp;</TD>
												</TR>
												<TR>
													<TD class="BordiCella" align="center"><FONT face="Arial" size="2">Altro</FONT></TD>
													<TD class="BordiCellaR" bgColor="#ffffff">&nbsp;</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							</asp:panel></TD>
					</TR>
				</TBODY>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
