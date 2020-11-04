<%@ Page language="c#" Codebehind="RapportoTecnicoIntervento.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorretiva.RapportoTecnicoIntervento" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Rapporto Tecnico di Intervento</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style>TABLE { FONT-SIZE: 8px; FONT-FAMILY: Arial }
		</style>
		<script language="javascript">
		 function stampa()
		 {		  
		  document.getElementById("btnstampa").style.visibility = "hidden";
		  document.getElementById("btnchiudi").style.visibility = "hidden";
		  window.print();		 
		  document.getElementById("btnstampa").style.visibility = "visible";
		  document.getElementById("btnchiudi").style.visibility = "visible"; 
		 }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="95%" border="0">
				<TR>
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server" Visible="False"></uc1:pagetitle></TD>
				</TR>
				<tr borderColor="#ffffff">
					<td align="left" width="100%" colSpan="4"><FONT face="Arial" size="3"><strong></strong></FONT></td>
				</tr>
				<tr>
					<td>
						<IMG src="<%=image%>" >
					</td>
				</tr>
				<TR>
					<TD width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" align=left width="88%" border="0">
							<TR>
							</TR>
						</TABLE>
						<asp:repeater id="repeater1" Runat="server">
							<ItemTemplate>
								<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="82%" border="0">
									<TR>
										<TD width="100%">
											<table id="Table10" cellPadding="3" width="90%" border="1" frame="border">
												<tr borderColor="#ffffff">
													<TD colSpan="2"><Font face="Arial" size="1"><nobr>BUONO LAVORO N°:</nobr></Font><b><Font face="Arial" size="-1"><%=WO_Id %>
															</Font></b>
													</TD>
													<TD>
														<cc1:s_label id="S_Lblditta" runat="server"></cc1:s_label></TD>
													<td align="left" colSpan="2"><b><Font face="Arial" size="1"><nobr>OGGETTO DELLA RICHIESTA N.</nobr></Font>
															<Font face="Arial" size="-1">
																<%#EvalField(DataBinder.Eval(Container.DataItem, "var_wr_wr_id"),0)%>
															</Font></b>
													</td>
													<td align="left" colSpan="2"><b><Font face="Arial" size="1"><nobr>DATA DELLA RICHIESTA </nobr></Font>
															<Font face="Arial" size="-1">
																<%#EvalField(DataBinder.Eval(Container.DataItem, "var_wr_date_requested"),0)%>
															</Font></b>
													</td>
												</tr>
												<tr borderColor="#ffffff">
													<td><Font face="Arial" size="1"><nobr>RICHIEDENTE</nobr>:</Font></td>
													<td><strong><Font face="Arial" size="-1">
																<%#EvalField(DataBinder.Eval(Container.DataItem, "var_wr_requestor"),35)%>
																(
																<%#DataBinder.Eval(Container.DataItem, "var_wr_gruppo")%>
																) </Font></strong>
													</td>
												</tr>
												<tr borderColor="#ffffff">
													<td><Font face="Arial" size="1"><nobr>SERVIZIO</nobr>:</Font></td>
													<td><strong><Font face="Arial" size="-1">
																<%#EvalField(DataBinder.Eval(Container.DataItem, "var_wr_prob_type"),35)%>
															</Font></strong>
													</td>
													<td><Font face="Arial" size="1"><nobr>TELEFONO</nobr>:</Font></td>
													<td width="60"><strong><Font face="Arial" size="-1">
																<%#EvalField(DataBinder.Eval(Container.DataItem, "var_em_phone"),35)%>
															</Font></strong>
													</td>
												</tr>
												<tr borderColor="#ffffff">
													<td width="30"><Font face="Arial" size="1"><nobr>OPERATORE</nobr>:</Font></td>
													<td width="90"><strong><Font face="Arial" size="-1">
																<%#EvalField(DataBinder.Eval(Container.DataItem, "var_wr_operatore"),35)%>
															</Font></strong>
													</td>
													<td width="30"><nobr></nobr></td>
													<td width="60">&nbsp;</td>
												</tr>
												<tr borderColor="#ffffff">
													<td width="30"><Font face="Arial" size="1"><nobr>NOTA</nobr>:</Font></td>
													<td align="left" width="100%" colspan="3"><strong><Font face="Arial" size="-1">
																<%#EvalField(DataBinder.Eval(Container.DataItem, "var_wr_nota_ric"),93)%>
															</Font></strong>
													</td>
												</tr>
												<tr bordercolor="#ffffff">
													<td align="left" width="100%" colspan="4">&nbsp;www</td>
												</tr>
											</table>
											<table frame="border" border="1" width="90%" cellpadding="3" ID="Table4">
												<tr bordercolor="#ffffff">
													<td align="left"><Font face="Arial" size="1"><b><nobr>DESCRIZIONE INTERVENTO</nobr></b></Font></td>
													<td align="left">
														<Font face="Arial" size="1"><nobr>URGENZA</nobr>: </Font><strong><Font face="Arial" size="-1">
																<%#EvalField(DataBinder.Eval(Container.DataItem, "desc_priority"),0)%>
															</Font></strong>
													</td>
												</tr>
												<tr bordercolor="#ffffff">
													<td align="left" width="100%" colspan="4">
														<table>
															<tr>
																<td width="30">
																	<Font face="Arial" size="1"><nobr>INTERVENTO</nobr>: </Font>
																</td>
																<td>
																	<strong><Font face="Arial" size="-1">
																			<%#EvalField(DataBinder.Eval(Container.DataItem, "var_wr_description"),155)%>
																		</Font></strong>
																</td>
															</tr>
														</table>
														<br>
													</td>
												</tr>
											</table>
											<table border="1" width="90%" cellpadding="3" ID="Table3">
												<tr bordercolor="#ffffff">
													<td>
														<Font face="Arial" size="1"><b><nobr>DENOMINAZIONE CLIENTE </nobr></b></Font><strong>
															<Font face="Arial" size="-1"><%=descprog%></Font></strong>
													</td>
													<td align="left">
														<Font face="Arial" size="1"><nobr>LOCALITÀ</nobr>: </Font><strong><Font face="Arial" size="-1">
																<%#EvalField(DataBinder.Eval(Container.DataItem, "var_bl_city_id"),0)%>
															</Font></strong>
													</td>
												</tr>
												<tr bordercolor="#ffffff">
													<td>
														<Font face="Arial" size="1"><nobr>NOME EDIFICIO</nobr>: </Font><strong><Font face="Arial" size="-1">
																<%#EvalField(DataBinder.Eval(Container.DataItem, "var_wr_bl_id"),0)%>
															</Font></strong>
													</td>
												</tr>
												<tr bordercolor="#ffffff">
													<td>
														<Font face="Arial" size="1"><nobr>INDIRIZZO</nobr>: </Font><strong><Font face="Arial" size="-1">
																<%#EvalField(DataBinder.Eval(Container.DataItem, "var_bl_address1"),0)%>
															</Font></strong>
													</td>
											</table>
											<table frame="border" border="1" width="90%"  cellpadding="3" ID="Table5">
												<tr bordercolor="#ffffff">
													<td align="left"><b><nobr><Font face="Arial" size="1">ADDETTO ALL'INTERVENTO:</Font> <Font face="Arial" size="-1">
																	<%#EvalField(DataBinder.Eval(Container.DataItem, "var_wrcf_ditta"),0)%>
																</Font></nobr></b>
													</td>
													<td align="left"><b><nobr><Font face="Arial" size="1">DATA E ORA PIANIFICATA:</Font> <Font face="Arial" size="-1">
																	<%#EvalField(DataBinder.Eval(Container.DataItem, "var_wr_date_assigned"),0)%>
																</Font></nobr></b>
													</td>
												</tr>
												<tr bordercolor="#ffffff" style='<%#EvalBool(DataBinder.Eval(Container.DataItem, "var_wrcf_comments"),true)%>'>
													<td align="left" colspan="2"><b><Font face="Arial" size="1">ANNOTAZIONI / MATERIALE 
																UTILIZZATO :
																<br>
															</Font></nobr></b> <strong><Font face="Arial" size="-1">
																<%#DataBinder.Eval(Container.DataItem, "var_wrcf_comments")%>
															</Font></strong></b>
													</td>
												</tr>
												<tr bordercolor="#ffffff" style='<%#EvalBool(DataBinder.Eval(Container.DataItem, "var_wrcf_comments"),false)%>'>
													<td align="left" width="100%" colspan="2">___________________________________________________________________________________________________________________________________</td>
												</tr>
												<tr bordercolor="#ffffff" style='<%#EvalBool(DataBinder.Eval(Container.DataItem, "var_wrcf_comments"),false)%>'>
													<td align="left" width="100%" colspan="2">___________________________________________________________________________________________________________________________________</td>
												</tr>
												<tr bordercolor="#ffffff" style='<%#EvalBool(DataBinder.Eval(Container.DataItem, "var_wrcf_comments"),false)%>'>
													<td align="left" width="100%" colspan="2">___________________________________________________________________________________________________________________________________</td>
												</tr>
												<tr bordercolor="#ffffff" style='<%#EvalBool(DataBinder.Eval(Container.DataItem, "var_wrcf_comments"),false)%>'>
													<td align="left" width="100%" colspan="2">___________________________________________________________________________________________________________________________________</td>
												</tr>
												<tr bordercolor="#ffffff" style='<%#EvalBool(DataBinder.Eval(Container.DataItem, "var_wrcf_comments"),false)%>'>
													<td align="left" width="100%" colspan="2">___________________________________________________________________________________________________________________________________</td>
												</tr>
												<tr bordercolor="#ffffff">
													<td align="right" width="100%" colspan="2">FIRMA_________________________________________________</td>
												</tr>
											</table>
											<table frame="border" border="1" width="80%" align="center" cellpadding="3" ID="Table6">
												<tr bordercolor="#ffffff">
													<td align="left" width="100%"><Font face="Arial" size="1">FIRMA MAGAZZINIERE</Font> 
														_______________________________________________</td>
												</tr>
											</table>
											<table border="1" width="90%" ID="Table9">
												<TR id="trsoddisfazione" runat="server">
													<TD bordercolor="#ffffff"><Font face="Arial" size="1"><B>Livello Soddisfazione:</B></Font></TD>
													<TD bordercolor="#ffffff"><INPUT type="checkbox" value="Inadeguato"  <%# Chk( DataBinder.Eval(Container.DataItem,"soddisfazione").ToString(),"1")%> ><Font face="Arial" size="1">Non soddisfatto</Font></TD>
													<TD bordercolor="#ffffff"><INPUT type="checkbox" value="Parzialmente Adeguato"  <%# Chk( DataBinder.Eval(Container.DataItem,"soddisfazione").ToString(),"2")%> ><Font face="Arial" size="1">Soddisfatto</Font></TD>
													<TD bordercolor="#ffffff"><INPUT type="checkbox" value="Adeguato" <%# Chk( DataBinder.Eval(Container.DataItem,"soddisfazione").ToString(),"3")%> ><Font face="Arial" size="1">Pienamento Soddisfatto</Font></TD>
													<TD bordercolor="#ffffff"><INPUT type="checkbox" value="Eccellente" <%# Chk( DataBinder.Eval(Container.DataItem,"soddisfazione").ToString(),"4")%>><Font face="Arial" size="1">Non Dichiarato</Font></TD>
												</TR>
											</table>
											<table frame="border" border="1" width="90%" align="left" cellpadding="3" ID="Table7">
												<tr>
													<td bordercolor="#ffffff" width="20%" align="left"><nobr><Font face="Arial" size="1">DATA 
																INIZIO LAVORO:</Font> </nobr>
													</td>
													<td bordercolor="#ffffff" width="20%" align="left"><strong> <Font face="Arial" size="-1">
																<%#GetStringData(DataBinder.Eval(Container.DataItem, "date_start"),"Data")%>
															</Font></strong>
													</td>
													<td bordercolor="#ffffff" align="left"><Font face="Arial" size="1">ALLE ORE</Font> <strong>
															<Font face="Arial" size="-1">
																<%#EvalField(GetStringData(DataBinder.Eval(Container.DataItem, "date_start"),"Ora"),7)%>
															</Font></strong>
													</td>
													<td bordercolor="#ffffff" width="15%" align="left"><strong>&nbsp;</strong></td>
													<td width="30%" align="center" rowspan="4"><Font face="Arial" size="1">Si dichiara che 
															i lavori sono stati eseguiti ed i materiali installati<br>
															<br>
															Firma Cliente<br>
														</Font>_______________
													</td>
												</tr>
												<tr>
													<td bordercolor="#ffffff" align="left"><nobr><Font face="Arial" size="1">DATA FINE LAVORO:</Font></nobr>
													</td>
													<td bordercolor="#ffffff" align="left"><strong> <Font face="Arial" size="-1">
																<%#GetStringData(DataBinder.Eval(Container.DataItem, "date_end"),"Data")%>
															</Font></strong>
													</td>
													<td bordercolor="#ffffff" align="left"><strong><Font face="Arial" size="1">ALLE ORE</Font>
															<Font face="Arial" size="-1">
																<%#EvalField(GetStringData(DataBinder.Eval(Container.DataItem, "date_end"),"Ora"),7)%>
															</Font></strong>
													</td>
													<td bordercolor="#ffffff" align="left">&nbsp;</td>
												</tr>
												<!--	<tr>
													<td bordercolor="#ffffff" align="left"><nobr><Font face="Arial" size="1">TRASFERIMENTO:</Font>
														</nobr>
													</td>
													<td bordercolor="#ffffff" width="20%" align="left"><strong>_____/_____/_____</strong></td>
													<td bordercolor="#ffffff" align="left"><Font face="Arial" size="1">DALLE ORE</Font> 
														_______</td>
													<td bordercolor="#ffffff" align="left">
														<Font face="Arial" size="1">ALLE ORE</Font> _______</td>
												</tr>
												<tr>
													<td bordercolor="#ffffff" align="left">&nbsp;</td>
													<td bordercolor="#ffffff" width="20%" align="left"><strong>_____/_____/_____</strong></td>
													<td bordercolor="#ffffff" align="left"><Font face="Arial" size="1">DALLE ORE</Font> 
														_______</td>
													<td bordercolor="#ffffff" align="left">
														<Font face="Arial" size="1">ALLE ORE</Font> _______</td>
												</tr>-->
											</table>
										</TD>
									</TR>
								</TABLE>
								<table align="center">
									<tr>
										<td>
											<INPUT class="btn" style="WIDTH: 168px" id="btnstampa" onclick="stampa()" type="button"
												value="Stampa">
										</td>
										<td>
											<INPUT class="btn" style="WIDTH: 168px" id="btnchiudi" onclick="javascript:window.close()"
												type="button" value="Chiudi">
										</td>
									</tr>
								</table>
							</ItemTemplate>
						</asp:repeater></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
