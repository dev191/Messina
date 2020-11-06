<%@ Page Language="c#" CodeBehind="CompletaRdl.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorrettiva.CompletaRdl" %>

<%@ Register TagPrefix="uc1" TagName="AggiungiSollecito" Src="../WebControls/AggiungiSollecito.ascx" %>
<%@ Register TagPrefix="uc1" TagName="VisualizzaSolleciti" Src="../WebControls/VisualizzaSolleciti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Completamento Richiesta</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../images/cal/popcalendar.js"></script>
    <script language="javascript" src="jscompleta.js"></script>
</head>
<body onbeforeunload="closewin();" ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
        <table id="Table1" style="z-index: 101; position: absolute; top: 8px; left: 8px" cellspacing="1"
            cellpadding="1" width="100%" border="0">
            <tr>
                <td align="center">
                    <uc1:PageTitle ID="PageTitle1" runat="server"></uc1:PageTitle>
                </td>
            </tr>
            <tr>
                <td>
                    <table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td>
                                    <cc2:DataPanel ID="PanelGeneral" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
                                        TitleText="Dati della Richiesta" ExpandText="Espandi" ExpandImageUrl="../Images/down.gif" CollapseText="Riduci"
                                        CollapseImageUrl="../Images/up.gif" AllowTitleExpandCollapse="True" CssClass="DataPanel75">
                                        <table id="tblSearch100" border="0" cellspacing="0" cellpadding="0" width="100%">
                                            <tr>
                                                <td style="height: 12px" width="20%"><b>RDL N°</b></td>
                                                <td style="width: 169px; height: 12px">
                                                    <asp:Label ID="LblRdl" runat="server" Width="174px"></asp:Label></td>
                                                <td style="height: 12px"><b>
                                                    <input style="width: 16px; height: 18px" id="hidBl_id" size="1" type="hidden" runat="server"><input style="width: 16px; height: 18px" id="HPageBack" size="1" type="hidden" name="HPageBack"
                                                        runat="server"><input style="width: 16px; height: 18px" id="HSga" size="1" type="hidden" name="HSga" runat="server"><input style="width: 16px; height: 18px" id="HPrj" size="1" type="hidden" name="HPrj" runat="server"></b></td>
                                                <td style="height: 12px"></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 12px"><b>Nominativo Richiedente:</b></td>
                                                <td style="width: 169px; height: 12px">
                                                    <asp:Label ID="lblRichiedente" runat="server" Width="174px"></asp:Label></td>
                                                <td style="height: 12px"><b>Operatore:</b></td>
                                                <td style="height: 12px">
                                                    <asp:Label ID="lblOperatore" runat="server" Width="128px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Telefono Richiedente:</b></td>
                                                <td>
                                                    <asp:Label ID="lbltelefonoric" runat="server" Width="174px"></asp:Label></td>
                                                <td style="height: 29px"><b>Data Richiesta:</b></td>
                                                <td style="height: 29px">
                                                    <asp:Label ID="lblDataRichiesta" runat="server" Width="128px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Gruppo Richiedente:</b></td>
                                                <td style="width: 169px">
                                                    <asp:Label ID="lblGruppo" runat="server" Width="174px"></asp:Label></td>
                                                <td><b>Orario Richiesta:</b></td>
                                                <td>
                                                    <asp:Label ID="lblOraRichiesta" runat="server" Width="128px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Email Richiedente:</b></td>
                                                <td style="width: 169px">
                                                    <asp:Label ID="lblemailric" runat="server" Width="174px"></asp:Label></td>
                                                <td><b>Stanza Richiedente:</b></td>
                                                <td>
                                                    <asp:Label ID="lblstanzaric" runat="server" Width="128px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Fabbricato:</b></td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblfabbricato" runat="server" Width="472px"></asp:Label>
                                                    <asp:TextBox ID="txtHidBl" runat="server" Width="0px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 16px"><b>Piano:</b></td>
                                                <td style="width: 169px; height: 16px">
                                                    <asp:Label ID="lblPiano" runat="server" Width="174px"></asp:Label></td>
                                                <td style="height: 16px"><b>Stanza/Reparto:</b></td>
                                                <td style="height: 16px">
                                                    <asp:Label ID="lblStanza" runat="server" Width="174px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Telefono:</b></td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblTelefono" runat="server" Width="174px"></asp:Label></td>
                                                <tr>
                                                    <td><b>Note:</b></td>
                                                    <td colspan="3">
                                                        <asp:Label ID="lblNote" runat="server" Width="472px"></asp:Label>
                                                        <asp:Label ID="presidio" runat="server" Width="0px" Height="0px"></asp:Label></td>
                                                </tr>
                                            <tr>
                                                <td style="height: 24px"><b>Servizio:</b></td>
                                                <td style="height: 24px" colspan="3">
                                                    <cc1:S_ComboBox ID="cmbsServizio" runat="server" Width="480px" AutoPostBack="True"></cc1:S_ComboBox></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 19px"><b>Standard Apparecchiatura:</b></td>
                                                <td style="height: 19px" colspan="3">
                                                    <cc1:S_ComboBox ID="cmdsStdApparecchiatura" runat="server" Width="480px" DBDataType="Integer" AutoPostBack="True"
                                                        DBIndex="1" DBDirection="Input" DBParameterName="p_eqstd_id" DBSize="10">
                                                    </cc1:S_ComboBox></td>
                                            </tr>
                                            <tr>
                                                <td><b>Apparecchiatura:</b></td>
                                                <td colspan="3">
                                                    <cc1:S_ComboBox ID="cmbEQ" runat="server" Width="480px" DBDataType="Integer" DBIndex="1" DBDirection="Input"
                                                        DBParameterName="p_id_eq" DBSize="10">
                                                    </cc1:S_ComboBox></td>
                                            </tr>
                                            <tr>
                                                <td class="SGA"><b class="blueoverline">Descrizione Problema/Note:</b></td>
                                                <td colspan="3">
                                                    <cc1:S_TextBox ID="txtsDescrizione" runat="server" Width="480px" TextMode="MultiLine" Height="34px"></cc1:S_TextBox></td>
                                            </tr>
                                            <tr>
                                                <!--<TD class="SGA"><B class="blueoverline">Causa Presunta Guasto/Anomalia:</B></TD>-->
                                                <td colspan="3">
                                                    <cc1:S_TextBox ID="txtCausa" runat="server" Width="480px" TextMode="MultiLine" Height="34px" MaxLength="408"
                                                        Visible="False"></cc1:S_TextBox></td>
                                            </tr>
                                            <tr>
                                                <!--<TD class="SGA"><B class="blueoverline">Effetto del guasto/anomalie sulle prestazioni 
															dell'implianto/infrastuttura:</B></TD>-->
                                                <td colspan="3">
                                                    <cc1:S_TextBox ID="txtEffettoGuasto" runat="server" Width="480px" TextMode="MultiLine" Height="34px"
                                                        MaxLength="408" Visible="False"></cc1:S_TextBox>
                                                    <uc1:VisualizzaSolleciti ID="VisualizzaSolleciti1" runat="server"></uc1:VisualizzaSolleciti>
                                                </td>
                                            </tr>
                                        </table>
                                    </cc2:DataPanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <cc2:DataPanel ID="Datapanel1" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
                                        TitleText="Report Lavoro SGA" ExpandText="Espandi" ExpandImageUrl="../Images/down.gif" CollapseText="Riduci"
                                        CollapseImageUrl="../Images/up.gif" AllowTitleExpandCollapse="True" CssClass="DataPanel75">
                                        <table id="Table3" border="0" cellspacing="1" cellpadding="1" width="100%">
                                            <tr>
                                                <td style="width: 11.3%" class="sga"><b class="blueoverline">Soluzione Proposta:</b></td>
                                                <td colspan="3">
                                                    <cc1:S_TextBox ID="txtSoluzioneProposta" runat="server" Width="480px" TextMode="MultiLine" Height="34px"
                                                        MaxLength="408"></cc1:S_TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 139px; height: 38px" class="sga" valign="middle" align="left"><b class="blueoverline">Tipo 
															Manutenzione:</b></td>
                                                <td style="height: 38px" colspan="3">
                                                    <table style="width: 528px; height: 100%" id="Table18" border="0" cellspacing="0" cellpadding="0"
                                                        width="528">
                                                        <tr>
                                                            <td style="height: 27px">
                                                                <cc1:S_ComboBox ID="cmbsTipoManutenzione" runat="server" Width="196px"></cc1:S_ComboBox></td>
                                                            <td style="height: 27px" class="sga" valign="middle"><b class="blueoverline">Tipo 
																		Intervento:</b></td>
                                                            <td style="height: 27px">
                                                                <cc1:S_ComboBox ID="cmbsTipoIntrevento" runat="server" Width="200px" DBDirection="Input" DBDataType="VarChar"></cc1:S_ComboBox></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trprev1">
                                                <td style="width: 139px"><b>Importo Presunto:</b></td>
                                                <td>
                                                    <table style="width: 528px; height: 100%">
                                                        <tr>
                                                            <td>
                                                                <cc1:S_TextBox Style="text-align: right" ID="txtImp1" runat="server" Width="48px" MaxLength="8">0</cc1:S_TextBox>,
																	<cc1:S_TextBox ID="txtImp1_1" runat="server" Width="27px" MaxLength="2">00</cc1:S_TextBox></td>
                                                            <td><b>Oltre Iva:</b></td>
                                                            <td>
                                                                <cc1:S_TextBox Style="text-align: right" ID="txtPercentuale1" runat="server" Width="24px" MaxLength="2"></cc1:S_TextBox><b>%</b></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <tr id="trprev2">
                                                    <td style="width: 139px" class="sga"><b class="blueoverline">Importo Forfettario:</b></td>
                                                    <td>,
														<table style="width: 528px; height: 100%" id="Table19">
                                                            <tr>
                                                                <td>
                                                                    <cc1:S_TextBox Style="text-align: right" ID="txtImp2" runat="server" Width="48px" MaxLength="8">0</cc1:S_TextBox>,
																	<cc1:S_TextBox ID="txtImp2_1" runat="server" Width="27px" MaxLength="2">00</cc1:S_TextBox></td>
                                                                <td><b>Oltre Iva:</b></td>
                                                                <td><b>
                                                                    <cc1:S_TextBox Style="text-align: right" ID="txtPercentuale2" runat="server" Width="24px" MaxLength="2"></cc1:S_TextBox>%</b></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            <tr id="trprev3">
                                                <td style="width: 139px" class="sga"><b class="blueoverline">Modalita di Pagameno:</b></td>
                                                <td colspan="3">
                                                    <cc1:S_TextBox ID="txtModalitaPagamento" runat="server" Width="480px" TextMode="MultiLine" Height="34px"
                                                        MaxLength="112"></cc1:S_TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 139px" class="sga"><b class="blueoverline">Note:</b></td>
                                                <td colspan="3">
                                                    <cc1:S_TextBox ID="txtNoteSga" runat="server" Width="480px" TextMode="MultiLine" Height="34px"
                                                        MaxLength="408"></cc1:S_TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 139px"><strong>SGA:</strong></td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblSGA" runat="server" Font-Bold="True"></asp:Label>&nbsp;
														<asp:Label ID="LblDataInvioSga" runat="server" Font-Bold="True"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 139px"></td>
                                                <td>
                                                    <asp:Button ID="BtSalvaSGA" runat="server" Text="Salva/Invia SGA" Width="120px"></asp:Button>&nbsp;&nbsp;
                                                </td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </cc2:DataPanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <cc2:DataPanel ID="Datapanel2" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
                                        TitleText="Documentazione in allegato" ExpandText="Espandi" ExpandImageUrl="../Images/down.gif"
                                        CollapseText="Riduci" CollapseImageUrl="../Images/up.gif" AllowTitleExpandCollapse="True" CssClass="DataPanel75">
                                        <input id="UploadFile" style="width: 392px; height: 18px" type="file" size="46" runat="server">&nbsp;
                                        <asp:Button ID="BtUpload" runat="server" Text="Invia il File..."></asp:Button><asp:Repeater ID="rpdc" runat="server">
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
                                                    <td>
                                                        <asp:Label runat="server" ID="lbln" Visible="true"></asp:Label></td>
                                                    <td>
                                                        <asp:ImageButton ID="delete" ImageUrl="../Images/elimina.gif" runat="server" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id_file") + "," + DataBinder.Eval(Container.DataItem, "Nome_Doc") %>'></asp:ImageButton></td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </TABLE>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </cc2:DataPanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <cc2:DataPanel ID="Datapanel3" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
                                        TitleText="Emissione Ordine" ExpandText="Espandi" ExpandImageUrl="../Images/down.gif" CollapseText="Riduci"
                                        CollapseImageUrl="../Images/up.gif" AllowTitleExpandCollapse="True" CssClass="DataPanel75">
                                        <table id="Table4" cellspacing="1" cellpadding="1" width="100%" border="0">
                                            <tr>
                                                <td><strong>Ordine:</strong></td>
                                                <td>
                                                    <asp:Label ID="LblOrdine" runat="server" Font-Bold="True"></asp:Label></td>
                                                <td style="width: 141px"></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td class="die"><strong class="blueoverline">Ditta Esecutrice:</strong></td>
                                                <td>
                                                    <cc1:S_ComboBox ID="cmbsDitta" runat="server" Width="196px" AutoPostBack="True"></cc1:S_ComboBox></td>
                                                <td class="die" align="right" style="width: 141px"><strong class="blueoverline">Addetto: 
											&nbsp;</strong></td>
                                                <td>
                                                    <cc1:S_ComboBox ID="cmbsAddetto" runat="server" Width="273px"></cc1:S_ComboBox></td>
                                            </tr>
                                            <tr>
                                                <td class="die"><strong class="blueoverline">Priorità:</strong></td>
                                                <td colspan="3">
                                                    <cc1:S_ComboBox ID="cmbsUrgenza" runat="server" Width="400px"></cc1:S_ComboBox></td>
                                            </tr>
                                            <tr>
                                                <td><strong>Data Prevista Inizio Lavori:</strong></td>
                                                <td>
                                                    <uc1:CalendarPicker ID="CalendarPicker6" runat="server"></uc1:CalendarPicker>
                                                </td>
                                                <td colspan="2"><strong>Ora </strong>
                                                    <cc1:S_ComboBox ID="cmbOra1" runat="server" DBDataType="Integer">
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
                                                    </cc1:S_ComboBox>:
										<cc1:S_ComboBox ID="cmbMin2" runat="server" Width="40px" DBDataType="Integer">
                                            <asp:ListItem Value="00">00</asp:ListItem>
                                            <asp:ListItem Value="15">15</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="45">45</asp:ListItem>
                                        </cc1:S_ComboBox></td>
                                            </tr>
                                            <tr>
                                                <td><strong>Data Prevista Fine Lavori:</strong></td>
                                                <td>
                                                    <uc1:CalendarPicker ID="CalendarPicker2" runat="server"></uc1:CalendarPicker>
                                                </td>
                                                <td colspan="2"><strong>Ora </strong>
                                                    <cc1:S_ComboBox ID="cmborafinelav" runat="server" DBDataType="Integer">
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
                                                    </cc1:S_ComboBox>:
										<cc1:S_ComboBox ID="cmbminfinelav" runat="server" Width="40px" DBDataType="Integer">
                                            <asp:ListItem Value="00">00</asp:ListItem>
                                            <asp:ListItem Value="15">15</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="45">45</asp:ListItem>
                                        </cc1:S_ComboBox></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4"></td>
                                            </tr>
                                            <tr>
                                                <td><strong>Preventivo N°:</strong></td>
                                                <td>
                                                    <asp:TextBox ID="TxtNumPreventivo" runat="server" MaxLength="20"></asp:TextBox></td>
                                                <td align="right" style="width: 141px"><strong>Importo Preventivo: &nbsp;</strong></td>
                                                <td>
                                                    <cc1:S_TextBox ID="txtImpPrev1" Style="text-align: right" runat="server" Width="48px" MaxLength="8">0</cc1:S_TextBox>,
										<cc1:S_TextBox ID="txtImpPrev2" runat="server" Width="27px" MaxLength="2">00</cc1:S_TextBox></td>
                                            </tr>
                                            <tr>
                                                <td><strong>File Preventivo:</strong></td>
                                                <td colspan="3">
                                                    <input id="FilePreventivo" style="width: 392px; height: 18px" type="file" size="46" name="File1"
                                                        runat="server">&nbsp;
										<asp:Button ID="BtInviaPreventivo" runat="server" Text="Invia il File..."></asp:Button></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td colspan="3">
                                                    <asp:HyperLink ID="LkPrev" runat="server"></asp:HyperLink>&nbsp;
										<asp:ImageButton ID="btImgDelete" runat="server" ImageUrl="../Images/elimina.gif"></asp:ImageButton></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Label ID="LblMessaggio" runat="server" Width="560px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4">
                                                    <asp:Button ID="btRifiuta" runat="server" Text="Rifiuta" Width="135px"></asp:Button>&nbsp;
										<asp:Button ID="btSospendi" runat="server" Text="Sospendi" Width="135px"></asp:Button>&nbsp;
										<asp:Button ID="btApprova" runat="server" Text="Approva/Emetti" Width="135px" Style="z-index: 0"></asp:Button>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </cc2:DataPanel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <cc2:DataPanel ID="Datapanel5" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="false"
                        TitleText="Consuntivo Economico" ExpandText="Espandi" ExpandImageUrl="../Images/down.gif" CollapseText="Riduci"
                        CollapseImageUrl="../Images/up.gif" AllowTitleExpandCollapse="True" CssClass="DataPanel75">
                        <table border="0" cellspacing="1" cellpadding="1" width="100%">
                            <tr>
                                <td style="width: 144px" colspan="6">
                                    <table style="width: 616px; height: 33px" id="Table12" border="0" cellspacing="0" cellpadding="0"
                                        width="616">
                                        <tr>
                                            <td>
                                                <cc1:S_OptionButton ID="OptAMisura" TabIndex="4" runat="server" GroupName="Grkind" Text="A Misura" Checked="True"></cc1:S_OptionButton></td>
                                            <td style="width: 106px">
                                                <cc1:S_OptionButton ID="OptAForfait" TabIndex="4" runat="server" GroupName="Grkind" Text="A Forfait"></cc1:S_OptionButton></td>
                                            <td class="die"><strong class="blueoverline">Note:</strong></td>
                                            <td>
                                                <cc1:S_TextBox ID="TxtAForfait" runat="server" Height="22px" MaxLength="250" Width="283px" TextMode="MultiLine"></cc1:S_TextBox></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 144px" colspan="6">
                                    <table style="width: 488px; height: 88px" id="Table9" class="btbal" border="0" cellspacing="0"
                                        cellpadding="0" width="488">
                                        <tr>
                                            <td style="width: 60px"></td>
                                            <td style="width: 138px"><strong>Costo Materiali</strong></td>
                                            <td style="width: 143px"><strong><strong><strong>Costo Personale</strong></strong></strong></td>
                                            <td><strong>Sub Totali</strong></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60px"><strong>Manuale</strong></td>
                                            <td style="width: 138px" class="BbR">
                                                <cc1:S_TextBox Style="text-align: right" ID="txtCostiMateriali1" runat="server" Width="48px" MaxLength="8">0</cc1:S_TextBox>,
												<cc1:S_TextBox ID="txtCostiMateriali2" runat="server" Width="27px" MaxLength="2">00</cc1:S_TextBox></td>
                                            <td style="width: 143px" class="BbR">
                                                <cc1:S_TextBox Style="text-align: right" ID="txtCostiPersonale1" runat="server" Width="48px" MaxLength="8">0</cc1:S_TextBox>,
												<cc1:S_TextBox ID="txtCostiPersonale2" runat="server" Width="27px" MaxLength="2">00</cc1:S_TextBox></td>
                                            <td class="BbR">
                                                <cc1:S_TextBox Style="text-align: right" ID="txtCostiTotale1" runat="server" Width="48px" MaxLength="8">0</cc1:S_TextBox>,
												<cc1:S_TextBox ID="txtCostiTotale2" runat="server" Width="27px" MaxLength="2">00</cc1:S_TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60px"><strong>A Misura</strong></td>
                                            <td style="width: 138px" class="BbR">
                                                <asp:Label ID="lblCostoMateriali" runat="server"></asp:Label>€<input id="btOpenMat" title="Apre i Costi Materiali" onclick="OpenMateriali(<%=wr_id.ToString()%>);" value="..." type="button" name="btOpenMat"></td>
                                            <td style="width: 143px" class="BbR">
                                                <asp:Label ID="lblCostiPersonale" runat="server"></asp:Label>€<input id="btnPersonale" title="Apre i Costi Addetti" onclick="OpenPopUpAddetti(<%=wr_id.ToString()%>);" value="..." type="button" name="Button1"></td>
                                            <td class="BbR">
                                                <asp:Label ID="LblTotale" runat="server"></asp:Label>€</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60px"><strong>Totale</strong></td>
                                            <td style="width: 138px">
                                                <asp:Label ID="LblTotMateriali" runat="server"></asp:Label>€</td>
                                            <td style="width: 143px">
                                                <asp:Label ID="LblTotPersonale" runat="server"></asp:Label>€</td>
                                            <td>
                                                <asp:Label ID="LblTotGenerale" runat="server"></asp:Label>€</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 144px" colspan="6">
                                    <table style="width: 800px; height: 40px" id="Table10" border="0" cellspacing="0" cellpadding="0"
                                        width="800">
                                        <tr>
                                            <td><strong>Importo a Consuntivo:</strong></td>
                                            <td>&nbsp;
												<cc1:S_TextBox Style="text-align: right" ID="ImpCons1" runat="server" Width="48px" MaxLength="8">0</cc1:S_TextBox>,
												<cc1:S_TextBox ID="ImpCons2" runat="server" Width="27px" MaxLength="2">00</cc1:S_TextBox></td>
                                        </tr>
                                        <tr>
                                            <td><strong>File Consuntivo PDF:</strong></td>
                                            <td>&nbsp;<input style="width: 280px; height: 18px" id="FileConsuntivo" size="27" type="file" name="File1"
                                                runat="server">
                                                <asp:Button ID="BtInviaCons" runat="server" Text="Invia il File..." Width="88px"></asp:Button></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 144px"><strong></strong></td>
                                            <td colspan="5">&nbsp;
												<asp:HyperLink ID="LkCons" runat="server"></asp:HyperLink>&nbsp;
												<asp:ImageButton ID="btImgDeleteCons" runat="server" ImageUrl="../Images/elimina.gif"></asp:ImageButton></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 144px" colspan="6">
                                    <table id="Table11" border="0" cellspacing="0" cellpadding="0" width="300">
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="CmbFondo" runat="server" Visible="False" Width="250px"></asp:DropDownList></td>

                                            <td>
                                                <!---->
                                                <asp:DropDownList ID="cmbPeriodox" runat="server" Visible="False" Width="320px">
                                                    <asp:ListItem Value="1">Mensile</asp:ListItem>
                                                    <asp:ListItem Value="2">Bimestrale</asp:ListItem>
                                                    <asp:ListItem Value="3">Trimestrale</asp:ListItem>
                                                    <asp:ListItem Value="4">Quadrimestrale</asp:ListItem>
                                                    <asp:ListItem Value="6">Semestrale</asp:ListItem>
                                                    <asp:ListItem Value="12">Annuale</asp:ListItem>
                                                </asp:DropDownList>
                                                <!---->
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>


                        </table>
                    </cc2:DataPanel>
                </td>
            </tr>

            <tr>
                <td>
                    <cc2:DataPanel ID="Datapanel4" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
                        TitleText="Completamento Ordine" ExpandText="Espandi" ExpandImageUrl="../Images/down.gif" CollapseText="Riduci"
                        CollapseImageUrl="../Images/up.gif" AllowTitleExpandCollapse="True" CssClass="DataPanel75">
                        <table border="0" cellspacing="1" cellpadding="1" width="100%">
                            <tr>
                                <td colspan="3"><strong>Stato Richiesta:</strong>
                                    <cc1:S_ComboBox ID="cmbsstatolavoro" runat="server" Width="255px"></cc1:S_ComboBox></td>
                                <tr id="trsosp">
                                    <td colspan="3"><strong>Sospesa per:</strong>
                                        <cc1:S_TextBox ID="txtsAnnotazioni" runat="server" Width="480px" TextMode="MultiLine" Height="34px"
                                            MaxLength="2000"></cc1:S_TextBox></td>
                                </tr>
                            <tr>
                                <td colspan="3"><strong>Buono Lavoro Esterno:</strong>
                                    <asp:TextBox ID="txtBuonoLavoroEster" runat="server" MaxLength="32"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 144px" colspan="4">
                                    <table style="height: 68px" id="Table13" border="0" cellspacing="0" cellpadding="0" width="900">
                                        <tr>
                                            <td class="die"><strong class="blueoverline">Data Inizio Lavori:</strong></td>
                                            <td class="die"><strong class="blueoverline" title="data di completamente dell’intervento a tampone per la risoluzione del guasto">Data 
													Provvisoria Fine Lavori:</strong></td>
                                            <td class="die"><strong class="blueoverline">Data Fine Lavori:</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table id="Table5" border="0" cellspacing="1" cellpadding="1" width="100%">
                                                    <tr>
                                                        <td>
                                                            <uc1:CalendarPicker ID="CalendarPicker7" runat="server"></uc1:CalendarPicker>
                                                        </td>
                                                        <td><strong><span class="die"><span class="blueoverline">Ora</span></span>
                                                            <cc1:S_ComboBox ID="OraIni" runat="server" DBDataType="Integer">
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
                                                            </cc1:S_ComboBox></strong>:
															<cc1:S_ComboBox ID="MinitiIni" runat="server" Width="40px" DBDataType="Integer">
                                                                <asp:ListItem Value="00">00</asp:ListItem>
                                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                                <asp:ListItem Value="30">30</asp:ListItem>
                                                                <asp:ListItem Value="45">45</asp:ListItem>
                                                            </cc1:S_ComboBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table id="Table14" border="0" cellspacing="1" cellpadding="1" width="100%">
                                                    <tr>
                                                        <td style="width: 163px">
                                                            <uc1:CalendarPicker ID="CalendarPicker10" runat="server"></uc1:CalendarPicker>
                                                        </td>
                                                        <td><strong><span class="die"><span class="blueoverline">Ora</span></span>
                                                            <cc1:S_ComboBox ID="S_COMBOBOX2" runat="server" DBDataType="Integer">
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
                                                            </cc1:S_ComboBox></strong>:
															<cc1:S_ComboBox ID="S_COMBOBOX1" runat="server" Width="40px" DBDataType="Integer">
                                                                <asp:ListItem Value="00">00</asp:ListItem>
                                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                                <asp:ListItem Value="30">30</asp:ListItem>
                                                                <asp:ListItem Value="45">45</asp:ListItem>
                                                            </cc1:S_ComboBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table id="Table6" border="0" cellspacing="1" cellpadding="1" width="100%">
                                                    <tr>
                                                        <td style="width: 137px">
                                                            <uc1:CalendarPicker ID="CalendarPicker8" runat="server"></uc1:CalendarPicker>
                                                        </td>
                                                        <td><strong><span class="die"><span class="blueoverline">Ora</span></span>
                                                            <cc1:S_ComboBox ID="OraFine" runat="server" DBDataType="Integer">
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
                                                            </cc1:S_ComboBox></strong>:
															<cc1:S_ComboBox ID="MinutiFine" runat="server" Width="40px" DBDataType="Integer">
                                                                <asp:ListItem Value="00">00</asp:ListItem>
                                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                                <asp:ListItem Value="30">30</asp:ListItem>
                                                                <asp:ListItem Value="45">45</asp:ListItem>
                                                            </cc1:S_ComboBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <!--<TD style="WIDTH: 144px">
									<P><STRONG>Stato Intervento:</STRONG></P>
								</TD>-->
                                <td style="width: 329px">
                                    <asp:DropDownList ID="cmbStatoIntervento" runat="server" Width="255px" Visible="False">
                                        <asp:ListItem Value="1">Risolutivo</asp:ListItem>
                                        <asp:ListItem Value="2">Tampone</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td colspan="2">
                                    <asp:CheckBox ID="CkDisser" runat="server" Visible="False" Text="Creato Disservizio"></asp:CheckBox></td>
                            </tr>
                            <tr>
                                <!--<TD class="die" style="WIDTH: 144px"><STRONG class="blueoverline">Descritto nel 
										registro delle operzioni N°</STRONG></TD>-->
                                <td style="width: 329px" colspan="3">
                                    <table id="Table16" border="0" cellspacing="0" cellpadding="0" width="300">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtOperazioneN" runat="server" MaxLength="9" Visible="False"></asp:TextBox></td>
                                            <!--<TD><STRONG class="blueoverline">Mese:</STRONG></TD>-->
                                            <td>
                                                <cc1:S_ComboBox ID="CmbMese" runat="server" Width="196px" Visible="False">
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
                                                </cc1:S_ComboBox></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <!--<TD class="die" style="WIDTH: 144px"><STRONG class="blueoverline">Si dichiara che:</STRONG></TD>-->
                                <td style="width: 329px" class="die" colspan="3">
                                    <table style="width: 544px; height: 42px" id="Table15" border="0" cellspacing="0" cellpadding="0"
                                        width="544">
                                        <tr>
                                            <td class="die">
                                                <asp:CheckBox ID="Ck1" runat="server" Visible="False" Text="Gli apparati sono perfettamente funzionanti"
                                                    CssClass="blueoverline"></asp:CheckBox></td>
                                            <td class="die">
                                                <asp:CheckBox ID="Ck2" runat="server" Visible="False" Text="L'installazione è conforme alle norme vigenti"
                                                    CssClass="blueoverline"></asp:CheckBox></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 144px" class="die" colspan="3"><strong class="blueoverline">Descrizione 
										Intervento\Istruzioni:</strong>
                                    <cc1:S_TextBox ID="cmbDescrizioneIntervento" runat="server" Width="480px" TextMode="MultiLine"
                                        Height="34px" MaxLength="256"></cc1:S_TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 144px" class="die" colspan="3"><strong class="blueoverline">Note:</strong>
                                    <cc1:S_TextBox ID="txtNoteCompletamento" runat="server" Width="480px" TextMode="MultiLine" Height="34px"
                                        MaxLength="215"></cc1:S_TextBox></td>
                            </tr>
                            <tr id="trsod">
                                <td style="width: 144px" colspan="3"><strong>Livello Soddisfazione:</strong>
                                    <asp:RadioButtonList ID="RdListLivello" runat="server" Width="500px" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="4" Selected="True">Non dichiarato</asp:ListItem>
                                        <asp:ListItem Value="1">Non Soddisfatto</asp:ListItem>
                                        <asp:ListItem Value="2">Soddisfatto</asp:ListItem>
                                        <asp:ListItem Value="3">Pienamente Soddisfatto</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Button ID="BtSalva" runat="server" Text="Salva" Width="135px"></asp:Button>&nbsp;
									<asp:Button ID="BtDIE" runat="server" Text="Salva/Invia DIE" Width="135px"></asp:Button>&nbsp;
									<asp:Button ID="btFoglio" runat="server" Text="Foglio Prestazioni" Width="135px"></asp:Button>&nbsp;
									<asp:Button ID="btFoglioPdf" runat="server" Text="Foglio Prestazioni PDF" Width="135px"></asp:Button></td>
                            </tr>
                        </table>
                    </cc2:DataPanel>
                </td>
            </tr>
            <tr>
                <td align="center">&nbsp;<asp:Button ID="btChiudi" runat="server" Text="Chiudi" Width="135px"></asp:Button><uc1:AggiungiSollecito ID="AggiungiSollecito1" runat="server"></uc1:AggiungiSollecito>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
