<%@ Page language="c#" Codebehind="CompletaRdl1.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorrettiva.CompletaRdl1" %>
<%@ Register TagPrefix="uc1" TagName="AggiungiSollecito" Src="../WebControls/AggiungiSollecito.ascx" %>
<%@ Register TagPrefix="uc1" TagName="VisualizzaSolleciti" Src="../WebControls/VisualizzaSolleciti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Completamento Richiesta</title>
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY onbeforeunload="closewin();">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="../images/cal/popcalendar.js"></SCRIPT>
		<SCRIPT language="javascript" src="jscompleta.js"></SCRIPT>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; TOP: 8px; LEFT: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TBODY>
					<TR>
						<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD>
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TBODY>
									<TR>
										<TD><cc2:datapanel id="PanelGeneral" runat="server" titlestyle-cssclass="TitleSearch" collapsed="False"
												titletext="Dati della Richiesta" expandtext="Espandi" expandimageurl="../Images/down.gif" collapsetext="Riduci"
												collapseimageurl="../Images/up.gif" allowtitleexpandcollapse="True" cssclass="DataPanel75">
												<TABLE id="tblSearch100" border="0" cellSpacing="0" cellPadding="0" width="100%">
													<TR>
														<TD style="HEIGHT: 12px" width="20%"><B>RDL N°</B></TD>
														<TD style="WIDTH: 169px; HEIGHT: 12px">
															<ASP:LABEL id="LblRdl" runat="server" width="174px"></ASP:LABEL></TD>
														<TD style="HEIGHT: 12px"><B><INPUT style="WIDTH: 16px; HEIGHT: 18px" id="hidBl_id" size="1" type="hidden" name="hidBl_id"
																	runat="server"><INPUT style="WIDTH: 16px; HEIGHT: 18px" id="HPageBack" size="1" type="hidden" name="HPageBack"
																	runat="server"><INPUT style="WIDTH: 16px; HEIGHT: 18px" id="HSga" size="1" type="hidden" name="HSga" runat="server"><INPUT style="WIDTH: 16px; HEIGHT: 18px" id="HPrj" size="1" type="hidden" name="HPrj" runat="server"></B></TD>
														<TD style="HEIGHT: 12px"></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 12px"><B>Nominativo Richiedente:</B></TD>
														<TD style="WIDTH: 169px; HEIGHT: 12px">
															<ASP:LABEL id="lblRichiedente" runat="server" width="174px"></ASP:LABEL></TD>
														<TD style="HEIGHT: 12px"><B>Operatore:</B></TD>
														<TD style="HEIGHT: 12px">
															<ASP:LABEL id="lblOperatore" runat="server" width="128px"></ASP:LABEL></TD>
													</TR>
													<TR>
														<TD><B>Telefono Richiedente:</B></TD>
														<TD>
															<ASP:LABEL id="lbltelefonoric" runat="server" width="174px"></ASP:LABEL></TD>
														<TD style="HEIGHT: 29px"><B>Data Richiesta:</B></TD>
														<TD style="HEIGHT: 29px">
															<ASP:LABEL id="lblDataRichiesta" runat="server" width="128px"></ASP:LABEL></TD>
													</TR>
													<TR>
														<TD><B>Gruppo Richiedente:</B></TD>
														<TD style="WIDTH: 169px">
															<ASP:LABEL id="lblGruppo" runat="server" width="174px"></ASP:LABEL></TD>
														<TD><B>Orario Richiesta:</B></TD>
														<TD>
															<ASP:LABEL id="lblOraRichiesta" runat="server" width="128px"></ASP:LABEL></TD>
													</TR>
													<TR>
														<TD><B>Email Richiedente:</B></TD>
														<TD style="WIDTH: 169px">
															<ASP:LABEL id="lblemailric" runat="server" width="174px"></ASP:LABEL></TD>
														<TD><B>Stanza:</B></TD>
														<TD>
															<ASP:LABEL id="lblstanzaric" runat="server" width="128px"></ASP:LABEL></TD>
													</TR>
													<TR>
														<TD><B>Fabbricato:</B></TD>
														<TD colSpan="3">
															<ASP:LABEL id="lblfabbricato" runat="server" width="472px"></ASP:LABEL>
															<ASP:TEXTBOX id="txtHidBl" runat="server" width="0px"></ASP:TEXTBOX></TD>
													</TR>
													<TR>
														<TD><B>Piano:</B></TD>
														<TD style="WIDTH: 169px">
															<ASP:LABEL id="lblPiano" runat="server" width="174px"></ASP:LABEL></TD>
														<TD><B>Stanza/Reparto:</B></TD>
														<TD>
															<ASP:LABEL id="lblStanza" runat="server" width="174px"></ASP:LABEL></TD>
													</TR>
													<TR>
														<TD><B>Telefono:</B></TD>
														<TD colSpan="3">
															<ASP:LABEL id="lblTelefono" runat="server" width="174px"></ASP:LABEL></TD>
													<TR>
														<TD><B>Note:</B></TD>
														<TD colSpan="3">
															<ASP:LABEL id="lblNote" runat="server" width="472px"></ASP:LABEL>
															<ASP:LABEL id="presidio" runat="server" width="0px" Height="0px"></ASP:LABEL></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 24px"><B>Servizio:</B></TD>
														<TD style="HEIGHT: 24px" colSpan="3">
															<CC1:S_COMBOBOX id="cmbsServizio" runat="server" width="480px"></CC1:S_COMBOBOX></TD>
													</TR>
													<TR> <!--<TD style="HEIGHT: 19px"><B>Standard Apparecchiatura:</B></TD>-->
														<TD style="HEIGHT: 19px" colSpan="3">
															<CC1:S_COMBOBOX id="cmdsStdApparecchiatura" runat="server" width="480px" dbdatatype="Integer" AutoPostBack="True"
																dbindex="1" dbdirection="Input" dbparametername="p_eqstd_id" dbsize="10" Visible="False"></CC1:S_COMBOBOX></TD>
													</TR>
													<TR> <!--<TD><B>Apparecchiatura:</B></TD>-->
														<TD colSpan="3">
															<CC1:S_COMBOBOX id="cmbEQ" runat="server" width="480px" dbdatatype="Integer" dbindex="1" dbdirection="Input"
																dbparametername="p_id_eq" dbsize="10" Visible="False"></CC1:S_COMBOBOX></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 39px" class="SGA"><B class="blueoverline">Descrizione Problema/Note:</B></TD>
														<TD style="HEIGHT: 39px" colSpan="3">
															<CC1:S_TEXTBOX id="txtsDescrizione" runat="server" width="480px" textmode="MultiLine" height="34px"></CC1:S_TEXTBOX></TD>
													</TR>
													<TR> <!--<TD class="SGA"><B class="blueoverline">Causa Presunta Guasto/Anomalia:</B></TD>-->
														<TD colSpan="3">
															<CC1:S_TEXTBOX id="txtCausa" runat="server" width="480px" Visible="False" textmode="MultiLine"
																height="34px"></CC1:S_TEXTBOX></TD>
													</TR>
													<TR> <!--<TD class="SGA"><B class="blueoverline">Effetto del Guasto</B></TD>-->
														<TD colSpan="3">
															<CC1:S_TEXTBOX id="txtEffettoGuasto" runat="server" width="480px" Visible="False" textmode="MultiLine"
																height="34px"></CC1:S_TEXTBOX>
															<uc1:VisualizzaSolleciti id="VisualizzaSolleciti1" runat="server"></uc1:VisualizzaSolleciti></TD>
													</TR>
												</TABLE>
											</cc2:datapanel></TD>
									</TR>
									<TR>
										<TD><cc2:datapanel id="Datapanel1" runat="server" titlestyle-cssclass="TitleSearch" collapsed="False"
												titletext="Definizione Lavoro" expandtext="Espandi" expandimageurl="../Images/down.gif" collapsetext="Riduci"
												collapseimageurl="../Images/up.gif" allowtitleexpandcollapse="True" cssclass="DataPanel75">
												<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%">
													<TR>
														<TD style="WIDTH: 11.3%" class="sga"><B class="blueoverline">Soluzione Proposta:</B></TD>
														<TD colSpan="3">
															<CC1:S_TEXTBOX id="txtSoluzioneProposta" runat="server" width="480px" textmode="MultiLine" height="34px"
																MaxLength="408"></CC1:S_TEXTBOX></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 139px; HEIGHT: 38px" class="sga" vAlign="middle" align="left"><B class="blueoverline">Tipo 
																Manutenzione:</B></TD>
														<TD style="HEIGHT: 38px" colSpan="3">
															<TABLE style="WIDTH: 528px; HEIGHT: 100%" id="Table18" border="0" cellSpacing="0" cellPadding="0"
																width="528">
																<TR>
																	<TD style="HEIGHT: 27px">
																		<CC1:S_COMBOBOX id="cmbsTipoManutenzione" runat="server" width="196px"></CC1:S_COMBOBOX></TD> <!--<TD class="sga" style="HEIGHT: 27px" vAlign="middle"><B class="blueoverline">Tipo 
																		Intervento:</B></TD>-->
																	<TD style="HEIGHT: 27px">
																		<CC1:S_COMBOBOX id="cmbsTipoIntrevento" runat="server" width="200px" Visible="False" DBDirection="Input"
																			DBDataType="VarChar"></CC1:S_COMBOBOX></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR id="trprev1">
														<TD style="WIDTH: 139px"><B>Importo Presunto:</B></TD>
														<TD>
															<TABLE style="WIDTH: 528px; HEIGHT: 100%">
																<TR>
																	<TD>
																		<CC1:S_TEXTBOX style="TEXT-ALIGN: right" id="txtImp1" runat="server" width="48px" Visible="true"
																			maxlength="8">0</CC1:S_TEXTBOX>,
																		<CC1:S_TEXTBOX id="txtImp1_1" runat="server" width="27px" Visible="true" maxlength="2">00</CC1:S_TEXTBOX></TD>
																	<TD><B>Oltre Iva:</B></TD>
																	<TD>
																		<CC1:S_TEXTBOX style="TEXT-ALIGN: right" id="txtPercentuale1" runat="server" width="24px" Visible="true"
																			maxlength="2"></CC1:S_TEXTBOX><B>%</B></TD>
																</TR>
															</TABLE>
														</TD>
													<TR id="trprev2">
														<TD style="WIDTH: 139px" class="sga"><B class="blueoverline">Importo Forfettario:</B></TD>
														<TD>
															<TABLE style="WIDTH: 528px; HEIGHT: 100%" id="Table19">
																<TR>
																	<TD>
																		<CC1:S_TEXTBOX style="TEXT-ALIGN: right" id="txtImp2" runat="server" width="48px" Visible="true"
																			maxlength="8">0</CC1:S_TEXTBOX>,
																		<CC1:S_TEXTBOX id="txtImp2_1" runat="server" width="27px" Visible="true" maxlength="2">00</CC1:S_TEXTBOX></TD>
																	<TD><B>Oltre Iva:</B></TD>
																	<TD><B>
																			<CC1:S_TEXTBOX style="TEXT-ALIGN: right" id="txtPercentuale2" runat="server" width="24px" Visible="true"
																				maxlength="2"></CC1:S_TEXTBOX>%</B></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR id="trprev3">
														<TD style="WIDTH: 139px" class="sga"><B class="blueoverline">Modalita di Pagameno:</B></TD>
														<TD colSpan="3">
															<CC1:S_TEXTBOX id="txtModalitaPagamento" runat="server" width="480px" textmode="MultiLine" height="34px"
																MaxLength="112"></CC1:S_TEXTBOX></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 139px" class="sga"><B class="blueoverline">Note:</B></TD>
														<TD colSpan="3">
															<CC1:S_TEXTBOX id="txtNoteSga" runat="server" width="480px" Visible="true" textmode="MultiLine"
																height="34px" MaxLength="408"></CC1:S_TEXTBOX></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 139px"><STRONG>SGA:</STRONG></TD>
														<TD colSpan="3">
															<asp:label id="lblSGA" runat="server" Font-Bold="True"></asp:label>&nbsp;
															<asp:label id="LblDataInvioSga" runat="server" Font-Bold="True"></asp:label></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 139px"></TD>
														<TD>
															<asp:button id="BtSalvaSGA" runat="server" Text="Salva/Invia SGA" Width="120px"></asp:button>&nbsp;&nbsp;
														</TD>
														<TD></TD>
														<TD></TD>
													</TR>
												</TABLE>
											</cc2:datapanel></TD>
									</TR>
									<TR>
										<TD><cc2:datapanel id="Datapanel2" runat="server" titlestyle-cssclass="TitleSearch" collapsed="False"
												titletext="Documentazione in allegato" expandtext="Espandi" expandimageurl="../Images/down.gif"
												collapsetext="Riduci" collapseimageurl="../Images/up.gif" allowtitleexpandcollapse="True" cssclass="DataPanel75"><INPUT id="UploadFile" style="WIDTH: 392px; HEIGHT: 18px" type="file" size="46" runat="server"
													NAME="UploadFile">&nbsp; <asp:button id="BtUpload" runat="server" Text="Invia il File..."></asp:button><asp:repeater id="rpdc" Runat="server">
													<HeaderTemplate>
														<table border="0">
															<tr>
																<td>Nome Documento</td>
																<td>Download del Documento</td>
																<td>Elimina</td>
															</tr>
													</HeaderTemplate>
													<ItemTemplate>
														<tr>
															<td><%# DataBinder.Eval(Container.DataItem, "Nome_Doc") %></td>
															<td><asp:Label Runat="server" ID="lbln"></asp:Label></td>
															<td><asp:ImageButton ID="delete"  ImageUrl="../Images/elimina.gif" Runat="server" CommandName="Delete"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id_file") + "," + DataBinder.Eval(Container.DataItem, "Nome_Doc") %>'></asp:ImageButton></td>
														</tr>
													</ItemTemplate>
													<FooterTemplate>
							</TABLE>
							</FooterTemplate> </asp:repeater></cc2:datapanel></TD>
					</TR>
					<TR>
						<TD><cc2:datapanel id="Datapanel3" runat="server" titlestyle-cssclass="TitleSearch" collapsed="False"
								titletext="Emissione Ordine" expandtext="Espandi" expandimageurl="../Images/down.gif" collapsetext="Riduci"
								collapseimageurl="../Images/up.gif" allowtitleexpandcollapse="True" cssclass="DataPanel75">
								<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TBODY>
										<TR>
											<TD style="WIDTH: 244px; HEIGHT: 15px"><STRONG>Ordine:</STRONG></TD>
											<TD style="WIDTH: 195px; HEIGHT: 15px"><asp:label id="LblOrdine" runat="server" Font-Bold="True"></asp:label></TD>
											<TD style="WIDTH: 136px; HEIGHT: 15px"></TD>
											<TD style="HEIGHT: 15px"></TD>
										</TR>
										<TR>
											<TD class="die" style="WIDTH: 244px"><STRONG class="blueoverline">Ditta Esecutrice:</STRONG></TD>
											<TD colSpan="3"><CC1:S_COMBOBOX id="cmbsDitta" runat="server" width="196px" autopostback="True"></CC1:S_COMBOBOX></TD>
										</TR>
										<tr>
											<TD class="die" style="WIDTH: 244px"><STRONG class="blueoverline">Addetto: &nbsp;</STRONG></TD>
											<TD colSpan="3"><CC1:S_COMBOBOX id="cmbsAddetto" runat="server" width="273px"></CC1:S_COMBOBOX></TD>
										</tr>
										<TR>
											<TD class="die" style="WIDTH: 244px"><STRONG class="blueoverline">Priorità:</STRONG></TD>
											<TD colSpan="3"><CC1:S_COMBOBOX id="cmbsUrgenza" runat="server" width="272px"></CC1:S_COMBOBOX></TD>
										</TR>
										<TR>
											<TD><STRONG>Data Prevista Inizio Lavori:</STRONG></TD>
											<TD><uc1:calendarpicker id="CalendarPicker6" runat="server"></uc1:calendarpicker>
											&nbsp;
											<TD><STRONG>Ora </STRONG>
												<CC1:S_COMBOBOX id="cmbOra1" runat="server" dbdatatype="Integer">
													<asp:ListItem Value="00">00</asp:ListItem>
													<asp:ListItem Value="01">01</asp:ListItem>
													<asp:ListItem Value="02">02</asp:ListItem>
													<asp:ListItem Value="03">03</asp:ListItem>
													<asp:ListItem Value="04">04</asp:ListItem>
													<asp:ListItem Value="05">05</asp:ListItem>
													<asp:ListItem Value="06">06</asp:ListItem>
													<asp:ListItem Value="07">07</asp:ListItem>
													<asp:ListItem Value="08">08</asp:ListItem>
													<asp:ListItem Value="09">09</asp:ListItem>
													<asp:ListItem Value="10">10</asp:ListItem>
													<asp:ListItem Value="11">11</asp:ListItem>
													<asp:ListItem Value="12">12</asp:ListItem>
													<asp:ListItem Value="13">13</asp:ListItem>
													<asp:ListItem Value="14">14</asp:ListItem>
													<asp:ListItem Value="15">15</asp:ListItem>
													<asp:ListItem Value="16">16</asp:ListItem>
													<asp:ListItem Value="17">17</asp:ListItem>
													<asp:ListItem Value="18">18</asp:ListItem>
													<asp:ListItem Value="19">19</asp:ListItem>
													<asp:ListItem Value="20">20</asp:ListItem>
													<asp:ListItem Value="21">21</asp:ListItem>
													<asp:ListItem Value="22">22</asp:ListItem>
													<asp:ListItem Value="23">23</asp:ListItem>
												</CC1:S_COMBOBOX>:
												<CC1:S_COMBOBOX id="cmbMin2" runat="server" dbdatatype="Integer">
													<asp:ListItem Value="00">00</asp:ListItem>
													<asp:ListItem Value="15">15</asp:ListItem>
													<asp:ListItem Value="30">30</asp:ListItem>
													<asp:ListItem Value="45">45</asp:ListItem>
												</CC1:S_COMBOBOX></TD>
											<td align="left">&nbsp;</td>
										<TR>
											<TD><STRONG>Data Prevista Fine Lavori:</STRONG></TD>
											<TD><uc1:calendarpicker id="CalendarPicker2" runat="server"></uc1:calendarpicker>&nbsp;
											</TD>
											<td><STRONG>Ora </STRONG>
												<CC1:S_COMBOBOX id="cmborafinelav" runat="server" dbdatatype="Integer">
													<asp:ListItem Value="00">00</asp:ListItem>
													<asp:ListItem Value="01">01</asp:ListItem>
													<asp:ListItem Value="02">02</asp:ListItem>
													<asp:ListItem Value="03">03</asp:ListItem>
													<asp:ListItem Value="04">04</asp:ListItem>
													<asp:ListItem Value="05">05</asp:ListItem>
													<asp:ListItem Value="06">06</asp:ListItem>
													<asp:ListItem Value="07">07</asp:ListItem>
													<asp:ListItem Value="08">08</asp:ListItem>
													<asp:ListItem Value="09">09</asp:ListItem>
													<asp:ListItem Value="10">10</asp:ListItem>
													<asp:ListItem Value="11">11</asp:ListItem>
													<asp:ListItem Value="12">12</asp:ListItem>
													<asp:ListItem Value="13">13</asp:ListItem>
													<asp:ListItem Value="14">14</asp:ListItem>
													<asp:ListItem Value="15">15</asp:ListItem>
													<asp:ListItem Value="16">16</asp:ListItem>
													<asp:ListItem Value="17">17</asp:ListItem>
													<asp:ListItem Value="18">18</asp:ListItem>
													<asp:ListItem Value="19">19</asp:ListItem>
													<asp:ListItem Value="20">20</asp:ListItem>
													<asp:ListItem Value="21">21</asp:ListItem>
													<asp:ListItem Value="22">22</asp:ListItem>
													<asp:ListItem Value="23">23</asp:ListItem>
												</CC1:S_COMBOBOX>:
												<CC1:S_COMBOBOX id="cmbminfinelav" runat="server" dbdatatype="Integer">
													<asp:ListItem Value="00">00</asp:ListItem>
													<asp:ListItem Value="15">15</asp:ListItem>
													<asp:ListItem Value="30">30</asp:ListItem>
													<asp:ListItem Value="45">45</asp:ListItem>
												</CC1:S_COMBOBOX></td>
											<td align="left">&nbsp;</td>
										</TR>
										<TR>
											<TD colSpan="4"></TD>
										</TR>
										<TR>
											<TD><STRONG>Preventivo N°:</STRONG></TD>
											<TD><asp:textbox id="TxtNumPreventivo" runat="server" MaxLength="8"></asp:textbox></TD>
											<TD align="right" style="WIDTH: 136px"><STRONG>Importo Preventivo: &nbsp;</STRONG></TD>
											&nbsp;
											<TD style="WIDTH: 195px"><CC1:S_TEXTBOX id="txtImpPrev1" style="TEXT-ALIGN: right" runat="server" width="48px" maxlength="8">0</CC1:S_TEXTBOX><CC1:S_TEXTBOX id="txtImpPrev2" runat="server" width="27px" maxlength="2">00</CC1:S_TEXTBOX></TD>
										</TR>
										<TR>
											<TD><STRONG>File Preventivo:</STRONG></TD>
											<TD colSpan="3"><INPUT id="FilePreventivo" style="WIDTH: 392px; HEIGHT: 18px" type="file" size="46" name="File1"
													runat="server">&nbsp;
												<asp:button id="BtInviaPreventivo" runat="server" Visible="False" Text="Invia il File..." Enabled="false"></asp:button></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 244px"></TD>
											<TD colSpan="3"><asp:hyperlink id="LkPrev" runat="server"></asp:hyperlink>&nbsp;
												<asp:imagebutton id="btImgDelete" runat="server" ImageUrl="../Images/elimina.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD colSpan="4"><ASP:LABEL id="LblMessaggio" runat="server" width="560px"></ASP:LABEL></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="4"><asp:button id="btRifiuta" runat="server" Text="Rifiuta" Width="135px"></asp:button>&nbsp;
												<asp:button id="btSospendi" runat="server" Text="Sospendi" Width="135px"></asp:button>&nbsp;
												<asp:button id="btApprova" runat="server" Text="Approva/Emetti" Width="135px"></asp:button>&nbsp;
											</TD>
										</TR>
									</TBODY>
								</TABLE></TD>
					</TR>
				</TBODY>
			</TABLE>
			</cc2:datapanel></TD></TR>
			<TR>
				<TD>
					<cc2:datapanel id="Datapanel5" runat="server" titlestyle-cssclass="TitleSearch" collapsed="false"
						titletext="Consuntivo Economico" expandtext="Espandi" expandimageurl="../Images/down.gif" collapsetext="Riduci"
						collapseimageurl="../Images/up.gif" allowtitleexpandcollapse="True" cssclass="DataPanel75">
						<TABLE border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD style="WIDTH: 144px" colSpan="6">
									<TABLE style="WIDTH: 616px; HEIGHT: 33px" id="Table12" border="0" cellSpacing="0" cellPadding="0"
										width="616">
										<TR>
											<TD>
												<CC1:S_OPTIONBUTTON id="OptAMisura" tabIndex="4" runat="server" Visible="true" groupname="Grkind" text="A Misura"
													Checked="True"></CC1:S_OPTIONBUTTON></TD>
											<TD style="WIDTH: 106px">
												<CC1:S_OPTIONBUTTON id="OptAForfait" tabIndex="4" runat="server" Visible="true" groupname="Grkind" text="A Forfait"></CC1:S_OPTIONBUTTON></TD>
											<TD class="die"><STRONG class="blueoverline">Note:</STRONG></TD>
											<TD>
												<CC1:S_TEXTBOX id="TxtAForfait" runat="server" Height="22px" Visible="true" MaxLength="250" Width="283px"
													TextMode="MultiLine"></CC1:S_TEXTBOX></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px" colSpan="6">
									<TABLE style="WIDTH: 488px; HEIGHT: 88px" id="Table9" class="btbal" border="0" cellSpacing="0"
										cellPadding="0" width="488">
										<TR>
											<TD style="WIDTH: 60px"></TD>
											<TD style="WIDTH: 138px"><STRONG>Costo Materiali</STRONG></TD>
											<TD style="WIDTH: 143px"><STRONG><STRONG><STRONG>Costo Personale</STRONG></STRONG></STRONG></TD>
											<TD><STRONG>Sub Totali</STRONG></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 60px"><STRONG>Manuale</STRONG></TD>
											<TD style="WIDTH: 138px" class="BbR">
												<CC1:S_TEXTBOX style="TEXT-ALIGN: right" id="txtCostiMateriali1" runat="server" width="48px" Visible="true"
													maxlength="8">0</CC1:S_TEXTBOX>,
												<CC1:S_TEXTBOX id="txtCostiMateriali2" runat="server" width="27px" Visible="true" maxlength="2">00</CC1:S_TEXTBOX></TD>
											<TD style="WIDTH: 143px" class="BbR">
												<CC1:S_TEXTBOX style="TEXT-ALIGN: right" id="txtCostiPersonale1" runat="server" width="48px" Visible="true"
													maxlength="8">0</CC1:S_TEXTBOX>,
												<CC1:S_TEXTBOX id="txtCostiPersonale2" runat="server" width="27px" Visible="true" maxlength="2">00</CC1:S_TEXTBOX></TD>
											<TD class="BbR">
												<CC1:S_TEXTBOX style="TEXT-ALIGN: right" id="txtCostiTotale1" runat="server" width="48px" Visible="true"
													maxlength="8">0</CC1:S_TEXTBOX>,
												<CC1:S_TEXTBOX id="txtCostiTotale2" runat="server" width="27px" Visible="true" maxlength="2">00</CC1:S_TEXTBOX></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 60px"><STRONG>A Misura</STRONG></TD>
											<TD style="WIDTH: 138px" class="BbR">
												<ASP:LABEL id="lblCostoMateriali" runat="server" Visible="true"></ASP:LABEL>€<INPUT id=btOpenMat title="Apre i Costi Materiali" onclick="OpenMateriali(<%=wr_id.ToString()%>);" value=... type=button name=btOpenMat></TD>
											<TD style="WIDTH: 143px" class="BbR">
												<ASP:LABEL id="lblCostiPersonale" runat="server" Visible="true"></ASP:LABEL>€<INPUT id=btnPersonale title="Apre i Costi Addetti" onclick="OpenPopUpAddetti(<%=wr_id.ToString()%>);" value=... type=button name=Button1></TD>
											<TD class="BbR">
												<ASP:LABEL id="LblTotale" runat="server"></ASP:LABEL>€</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 60px"><STRONG>Totale</STRONG></TD>
											<TD style="WIDTH: 138px">
												<ASP:LABEL id="LblTotMateriali" runat="server"></ASP:LABEL>€</TD>
											<TD style="WIDTH: 143px">
												<ASP:LABEL id="LblTotPersonale" runat="server"></ASP:LABEL>€</TD>
											<TD>
												<ASP:LABEL id="LblTotGenerale" runat="server"></ASP:LABEL>€</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px" colSpan="6">
									<TABLE style="WIDTH: 800px; HEIGHT: 40px" id="Table10" border="0" cellSpacing="0" cellPadding="0"
										width="800">
										<TR>
											<TD style="WIDTH: 150px"><STRONG>Importo a Consuntivo:</STRONG></TD>
											<TD style="WIDTH: 91px">&nbsp;
												<CC1:S_TEXTBOX style="TEXT-ALIGN: right" id="ImpCons1" runat="server" width="48px" Visible="true"
													maxlength="8">0</CC1:S_TEXTBOX>,
												<CC1:S_TEXTBOX id="ImpCons2" runat="server" width="27px" Visible="true" maxlength="2">00</CC1:S_TEXTBOX></TD>
											<TD style="WIDTH: 139px"><STRONG>File Consuntivo PDF:</STRONG></TD>
											<TD>&nbsp;<INPUT style="WIDTH: 280px; HEIGHT: 18px" id="FileConsuntivo" size="27" type="file" name="File1"
													runat="server">
												<asp:button id="BtInviaCons" runat="server" Visible="true" Text="Invia il File..." Width="88px"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 144px"><STRONG></STRONG></TD>
								<TD colSpan="5">&nbsp;
									<asp:hyperlink id="LkCons" runat="server"></asp:hyperlink>&nbsp;
									<asp:imagebutton id="btImgDeleteCons" runat="server" ImageUrl="../Images/elimina.gif"></asp:imagebutton></TD>
							</TR> <!--<TR>
							<TD style="WIDTH: 144px" colSpan="6">
								<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="300" border="0">
									<TR>
										<TD><STRONG>Fondo:</STRONG></TD>
										<TD><asp:dropdownlist id="CmbFondo" runat="server" Visible="False" AutoPostBack="True" Width="250px"></asp:dropdownlist></TD>
										<TD><STRONG>Periodo:</STRONG></TD>
										<TD><asp:dropdownlist id="cmbPeriodo" runat="server" Visible="False" Width="320px">
												<asp:ListItem Value="1">Mensile</asp:ListItem>
												<asp:ListItem Value="2">Bimestrale</asp:ListItem>
												<asp:ListItem Value="3">Trimestrale</asp:ListItem>
												<asp:ListItem Value="4">Quadrimestrale</asp:ListItem>
												<asp:ListItem Value="6">Semestrale</asp:ListItem>
												<asp:ListItem Value="12">Annuale</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>--></TABLE>
					</cc2:datapanel></TD>
			</TR>
			<TR>
				<TD>
					<cc2:datapanel id="Datapanel4" runat="server" titlestyle-cssclass="TitleSearch" collapsed="False"
						titletext="Completamento Ordine" expandtext="Espandi" expandimageurl="../Images/down.gif" collapsetext="Riduci"
						collapseimageurl="../Images/up.gif" allowtitleexpandcollapse="True" cssclass="DataPanel75">
						<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="HEIGHT: 23px"><STRONG>Stato Richiesta:</STRONG>
									<CC1:S_COMBOBOX id="cmbsstatolavoro" runat="server" width="255px"></CC1:S_COMBOBOX></TD>
							</TR>
							<TR id="trsosp">
								<TD><STRONG>Sospesa per:</STRONG>
									<CC1:S_TEXTBOX id="txtsAnnotazioni" runat="server" width="480px" height="34px" textmode="MultiLine"
										MaxLength="2000"></CC1:S_TEXTBOX></TD>
							</TR>
							<TR>
								<TD><STRONG>Buono Lavoro Esterno:</STRONG>
									<asp:textbox id="txtBuonoLavoroEster" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<td>
									<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD colspan="2" style="WIDTH: 535px; HEIGHT: 16px"><STRONG class="blueoverline">Data 
													Inizio Lavori:</STRONG></TD>
											<TD style="WIDTH: 210px; HEIGHT: 16px"><STRONG class="blueoverline" title="data di completamente dell’intervento a tampone per la risoluzione del guasto">Data 
													Provvisoria Fine Lavori:</STRONG></TD>
										</TR>
										<TR>
											<TD><uc1:calendarpicker id="CalendarPicker7" runat="server"></uc1:calendarpicker></TD>
											<TD style="WIDTH: 306px"><STRONG><SPAN class="die"><SPAN class="blueoverline">Ora</SPAN></SPAN>
													<CC1:S_COMBOBOX id="OraIni" runat="server" dbdatatype="Integer">
														<asp:ListItem Value="00">00</asp:ListItem>
														<asp:ListItem Value="01">01</asp:ListItem>
														<asp:ListItem Value="02">02</asp:ListItem>
														<asp:ListItem Value="03">03</asp:ListItem>
														<asp:ListItem Value="04">04</asp:ListItem>
														<asp:ListItem Value="05">05</asp:ListItem>
														<asp:ListItem Value="06">06</asp:ListItem>
														<asp:ListItem Value="07">07</asp:ListItem>
														<asp:ListItem Value="08">08</asp:ListItem>
														<asp:ListItem Value="09">09</asp:ListItem>
														<asp:ListItem Value="10">10</asp:ListItem>
														<asp:ListItem Value="11">11</asp:ListItem>
														<asp:ListItem Value="12">12</asp:ListItem>
														<asp:ListItem Value="13">13</asp:ListItem>
														<asp:ListItem Value="14">14</asp:ListItem>
														<asp:ListItem Value="15">15</asp:ListItem>
														<asp:ListItem Value="16">16</asp:ListItem>
														<asp:ListItem Value="17">17</asp:ListItem>
														<asp:ListItem Value="18">18</asp:ListItem>
														<asp:ListItem Value="19">19</asp:ListItem>
														<asp:ListItem Value="20">20</asp:ListItem>
														<asp:ListItem Value="21">21</asp:ListItem>
														<asp:ListItem Value="22">22</asp:ListItem>
														<asp:ListItem Value="23">23</asp:ListItem>
													</CC1:S_COMBOBOX></STRONG>:
												<CC1:S_COMBOBOX id="MinitiIni" runat="server" width="40px" dbdatatype="Integer">
													<asp:ListItem Value="00">00</asp:ListItem>
													<asp:ListItem Value="15">15</asp:ListItem>
													<asp:ListItem Value="30">30</asp:ListItem>
													<asp:ListItem Value="45">45</asp:ListItem>
												</CC1:S_COMBOBOX></TD>
											<TD><uc1:calendarpicker id="CalendarPicker10" runat="server"></uc1:calendarpicker></TD>
											<TD><STRONG><SPAN class="die"><SPAN class="blueoverline">Ora</SPAN></SPAN>
													<CC1:S_COMBOBOX id="S_COMBOBOX2" runat="server" dbdatatype="Integer">
														<asp:ListItem Value="00">00</asp:ListItem>
														<asp:ListItem Value="01">01</asp:ListItem>
														<asp:ListItem Value="02">02</asp:ListItem>
														<asp:ListItem Value="03">03</asp:ListItem>
														<asp:ListItem Value="04">04</asp:ListItem>
														<asp:ListItem Value="05">05</asp:ListItem>
														<asp:ListItem Value="06">06</asp:ListItem>
														<asp:ListItem Value="07">07</asp:ListItem>
														<asp:ListItem Value="08">08</asp:ListItem>
														<asp:ListItem Value="09">09</asp:ListItem>
														<asp:ListItem Value="10">10</asp:ListItem>
														<asp:ListItem Value="11">11</asp:ListItem>
														<asp:ListItem Value="12">12</asp:ListItem>
														<asp:ListItem Value="13">13</asp:ListItem>
														<asp:ListItem Value="14">14</asp:ListItem>
														<asp:ListItem Value="15">15</asp:ListItem>
														<asp:ListItem Value="16">16</asp:ListItem>
														<asp:ListItem Value="17">17</asp:ListItem>
														<asp:ListItem Value="18">18</asp:ListItem>
														<asp:ListItem Value="19">19</asp:ListItem>
														<asp:ListItem Value="20">20</asp:ListItem>
														<asp:ListItem Value="21">21</asp:ListItem>
														<asp:ListItem Value="22">22</asp:ListItem>
														<asp:ListItem Value="23">23</asp:ListItem>
													</CC1:S_COMBOBOX></STRONG>:
												<CC1:S_COMBOBOX id="S_COMBOBOX1" runat="server" width="40px" dbdatatype="Integer">
													<asp:ListItem Value="00">00</asp:ListItem>
													<asp:ListItem Value="15">15</asp:ListItem>
													<asp:ListItem Value="30">30</asp:ListItem>
													<asp:ListItem Value="45">45</asp:ListItem>
												</CC1:S_COMBOBOX></TD>
										</TR>
										<tr>
											<TD><STRONG class="blueoverline">Data Fine Lavori:</STRONG></TD>
										</tr>
										<tr>
											<td><uc1:calendarpicker id="CalendarPicker8" runat="server"></uc1:calendarpicker></td>
											<td style="WIDTH: 306px"><STRONG><SPAN class="die"><SPAN class="blueoverline">Ora</SPAN></SPAN>
													<CC1:S_COMBOBOX id="OraFine" runat="server" dbdatatype="Integer">
														<asp:ListItem Value="00">00</asp:ListItem>
														<asp:ListItem Value="01">01</asp:ListItem>
														<asp:ListItem Value="02">02</asp:ListItem>
														<asp:ListItem Value="03">03</asp:ListItem>
														<asp:ListItem Value="04">04</asp:ListItem>
														<asp:ListItem Value="05">05</asp:ListItem>
														<asp:ListItem Value="06">06</asp:ListItem>
														<asp:ListItem Value="07">07</asp:ListItem>
														<asp:ListItem Value="08">08</asp:ListItem>
														<asp:ListItem Value="09">09</asp:ListItem>
														<asp:ListItem Value="10">10</asp:ListItem>
														<asp:ListItem Value="11">11</asp:ListItem>
														<asp:ListItem Value="12">12</asp:ListItem>
														<asp:ListItem Value="13">13</asp:ListItem>
														<asp:ListItem Value="14">14</asp:ListItem>
														<asp:ListItem Value="15">15</asp:ListItem>
														<asp:ListItem Value="16">16</asp:ListItem>
														<asp:ListItem Value="17">17</asp:ListItem>
														<asp:ListItem Value="18">18</asp:ListItem>
														<asp:ListItem Value="19">19</asp:ListItem>
														<asp:ListItem Value="20">20</asp:ListItem>
														<asp:ListItem Value="21">21</asp:ListItem>
														<asp:ListItem Value="22">22</asp:ListItem>
														<asp:ListItem Value="23">23</asp:ListItem>
													</CC1:S_COMBOBOX>:
													<CC1:S_COMBOBOX id="MinutiFine" runat="server" width="40px" dbdatatype="Integer">
														<asp:ListItem Value="00">00</asp:ListItem>
														<asp:ListItem Value="15">15</asp:ListItem>
														<asp:ListItem Value="30">30</asp:ListItem>
														<asp:ListItem Value="45">45</asp:ListItem>
													</CC1:S_COMBOBOX></SPAN></SPAN></STRONG></td>
										</tr>
									</TABLE>
								</td>
							</TR>
							<TR>
								<TD>
									<P><STRONG>Stato Intervento:</STRONG>
										<asp:dropdownlist id="cmbStatoIntervento" runat="server" width="255px">
											<asp:ListItem Value="1">Risolutivo</asp:ListItem>
											<asp:ListItem Value="2">Tampone</asp:ListItem>
										</asp:dropdownlist><asp:checkbox id="CkDisser" runat="server" Text="Creato Disservizio"></asp:checkbox></P>
								</TD>
							</TR>
							<TR>
								<!--<TD class="die" style="WIDTH: 144px"><STRONG class="blueoverline">Descritto nel 
										registro delle operzioni N°</STRONG></TD>-->
								<TD style="WIDTH: 329px" colSpan="3">
									<TABLE id="Table16" cellSpacing="0" cellPadding="0" width="300" border="0">
										<TR>
											<TD><asp:textbox id="txtOperazioneN" runat="server" Visible="False" MaxLength="9"></asp:textbox></TD>
											<!--<TD><STRONG class="blueoverline">Mese:</STRONG></TD>-->
											<TD><CC1:S_COMBOBOX id="CmbMese" runat="server" width="196px" Visible="False">
													<asp:ListItem Value="0">- Nessun Mese Selezionato -</asp:ListItem>
													<asp:ListItem Value="1">Gennaio</asp:ListItem>
													<asp:ListItem Value="2">Febbraio</asp:ListItem>
													<asp:ListItem Value="3">Marzo</asp:ListItem>
													<asp:ListItem Value="4">Aprile</asp:ListItem>
													<asp:ListItem Value="5">Maggio</asp:ListItem>
													<asp:ListItem Value="6">Giugno</asp:ListItem>
													<asp:ListItem Value="7">Luglio</asp:ListItem>
													<asp:ListItem Value="8">Agosto</asp:ListItem>
													<asp:ListItem Value="9">Settembre</asp:ListItem>
													<asp:ListItem Value="10">Ottobre</asp:ListItem>
													<asp:ListItem Value="11">Novembre</asp:ListItem>
													<asp:ListItem Value="12">Dicembre</asp:ListItem>
												</CC1:S_COMBOBOX></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<!--<TD class="die" style="WIDTH: 144px"><STRONG class="blueoverline">Si dichiara che:</STRONG></TD>
								<TD class="die" style="WIDTH: 329px" colSpan="3">--></TR>
						</TABLE>
						<table>
							<TR>
								<TD class="die" style="WIDTH: 144px"><STRONG class="blueoverline">Descrizione 
										Intervento\Istruzioni:</STRONG></TD>
								<TD style="WIDTH: 200px"><CC1:S_TEXTBOX id="cmbDescrizioneIntervento" runat="server" width="480px" height="34px" textmode="MultiLine"
										MaxLength="4000"></CC1:S_TEXTBOX></TD>
							</TR>
							<TR>
								<TD class="die" style="WIDTH: 144px"><STRONG class="blueoverline">Note:</STRONG></TD>
								<TD style="WIDTH: 200px"><CC1:S_TEXTBOX id="txtNoteCompletamento" runat="server" width="480px" height="34px" textmode="MultiLine"
										MaxLength="215"></CC1:S_TEXTBOX></TD>
							</TR>
							<TR id="trsod">
								<TD style="WIDTH: 144px"><STRONG>Livello Soddisfazione:</STRONG></TD>
								<TD style="WIDTH: 329px" colSpan="3"><ASP:RADIOBUTTONLIST id="RdListLivello" runat="server" Width="500px" repeatdirection="Horizontal">
										<asp:ListItem Value="4" Selected="True">Non dichiarato</asp:ListItem>
										<asp:ListItem Value="1">Non Soddisfatto</asp:ListItem>
										<asp:ListItem Value="2">Soddisfatto</asp:ListItem>
										<asp:ListItem Value="3">Pienamente Soddisfatto</asp:ListItem>
									</ASP:RADIOBUTTONLIST></TD>
							</TR>
							<TR>
								<td colspan="3"><asp:button id="BtSalva" runat="server" Text="Salva" Width="135px"></asp:button>
									<asp:button id="btFoglioPdf" runat="server" Text="Foglio Prestazioni PDF" Width="135px"></asp:button>
									<asp:button id="btFoglio" runat="server" Text="Foglio Prestazioni" Width="135px"></asp:button>
									<asp:button id="BtDIE" runat="server" Text="Salva/Invia DIE" Width="135px"></asp:button>
								</td>
							</TR>
						</table>
				</TD>
			</TR>
			</cc2:datapanel></TD></TR>
			<TR>
				<TD align="center">&nbsp;<asp:button id="btChiudi" runat="server" Text="Chiudi" Width="135px"></asp:button><uc1:aggiungisollecito id="AggiungiSollecito1" runat="server"></uc1:aggiungisollecito></TD>
			</TR>
			</TBODY></TABLE>&nbsp;
		</form>
	</BODY>
</HTML>
