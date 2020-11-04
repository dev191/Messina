<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="RicercaRDL.ascx.cs" Inherits="TheSite.WebControls.RicercaRDL" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!---<LINK href="../Css/IACPSheet.css" type="text/css" rel="stylesheet">-->
<script language="javascript">

</script>
<TABLE class="tblSearch100Dettaglio" id="tblModulo" style="HEIGHT: 70px" cellSpacing="1"
	cellPadding="1" width="100%" border="0">
	<tr>
		<td colSpan="4"><b>Selezionare le RdL da fatturare</b></td>
	</tr>
	<TR>
		<TD style="WIDTH: 1.11%"><B>Rdl</B></TD>
		<TD style="WIDTH: 136px" noWrap><cc1:s_textbox id="txtsRDL" Width="72px" runat="server" Height="25px"></cc1:s_textbox><INPUT id=btsCodice title="Fare Click per effettuare la Ricerca per codice RDL" style="WIDTH: 32px; HEIGHT: 22px" onclick="ShowFrame('<%=idTextCod%>','<%=idTextCod%>','idcod',event,'<%=idModulo%>','<%=multisele%>','<%=operazione%>','<%=TipoMan%>');"type=button value=...>
		</TD>
		<TD style="WIDTH: 517px">
			<table>
				<TR>
					<TD align="left">Da:</TD>
					<TD><uc1:calendarpicker id="CalendarPicker1" runat="server"></uc1:calendarpicker></TD>
					<TD align="left">A:</TD>
					<TD><uc1:calendarpicker id="CalendarPicker2" runat="server"></uc1:calendarpicker><asp:comparevalidator id="CompareValidator1" Width="48px" runat="server" Display="Dynamic" Type="Date"
							Operator="GreaterThanEqual" ErrorMessage="Data non valida!"></asp:comparevalidator></TD>
					<TD style="WIDTH: 66px" align="center"><INPUT id=btnsRicerca title="Fare Click per effettuare la Ricerca per data completamento RDL" style="WIDTH: 50px; HEIGHT: 24px" onclick="ShowFrame('<%=idTextRic%>','<%=idTextRicA%>','idric',event,'<%=idModulo%>','<%=multisele%>','<%=TipoMan%>');"type=button value=Ricerca></TD>
				</TR>
			</table>
		</TD>
	</TR>
	<TR>
		<TD style="WIDTH: 15%" colSpan="4"><asp:panel id="PanelDettagli" runat="server">
				<DIV id="Popup" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; DISPLAY: none; BORDER-LEFT: #000000 1px solid; WIDTH: 168px; BORDER-BOTTOM: #000000 1px solid; POSITION: absolute; HEIGHT: 424px"><IFRAME id="doc" style="WIDTH: 276.66%; HEIGHT: 450px" name="doc" src="" frameBorder="no"
						width="100%" scrolling="auto"> </IFRAME>
				</DIV>
			</asp:panel></TD>
	</TR>
	<input id="hiddenidRDL" style="WIDTH: 16px; HEIGHT: 25px" type="hidden" runat="server">
	<TABLE>
	</TABLE>
