<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="RicercaModulo.ascx.cs" Inherits="TheSite.WebControls.RicercaModulo" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<!---<LINK href="../Css/IACPSheet.css" type="text/css" rel="stylesheet">-->
<script language="javascript">
var prj=<%=varprj%>;
function setprj(e)
{
	prj=e.value;
}
</script>
<TABLE runat="server" id="tblModulo" cellSpacing="1" cellPadding="1" width="100%" border="0"
	class="tblSearch100Dettaglio">
	<TR>
		<TD style="WIDTH: 15%"><B>Cod. Edificio</B></TD>
		<TD noWrap><cc1:s_textbox id="txtsCodEdificio" Width="63px" runat="server"></cc1:s_textbox><INPUT id="btsCodice" style="WIDTH: 32px; HEIGHT: 22px" type="button" value="..." title="Ricerca il Codice dell'Edificio" onclick="ShowFrame('<%=idTextCod%>','idcod',event,'<%=idModulo%>','<%=multisele%>');"class=btn>&nbsp;
			<asp:Label id="lblBlId" runat="server" Visible="False"></asp:Label>
			<input type="hidden" id="hiddenidbl" runat="server" style="WIDTH: 16px; HEIGHT: 25px" size="1">
		</TD>
		<TD align="center"><INPUT id="btnsRicerca" title="Fare Click per effettuare la Ricerca Edificio" type="button"
				value="Ricerca Edificio"  onclick="ShowFrame('<%=idTextRic%>','idric',event,'<%=idModulo%>','<%=multisele%>');"class=btn></TD>
		<TD>
			<cc1:S_TextBox id="txtRicerca" runat="server" Width="420px"></cc1:S_TextBox>
			<INPUT type="hidden" runat="server" id="idProg" style="WIDTH: 5px; HEIGHT: 22px" size="1">
		</TD>
	</TR>
	<TR>
		<TD style="WIDTH: 15%">
			<asp:Label id="lblProgetto" runat="server" Font-Bold="True">Progetto:</asp:Label></TD>
		<TD noWrap>
			<asp:DropDownList id="CmbProgetto" runat="server"></asp:DropDownList></TD>
		<TD align="center"></TD>
		<TD></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 15%" colSpan="4">
			<asp:Panel id="PanelDettagli" runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD>Denominazione</TD>
						<TD>
							<asp:Label id="lblDenominazione" runat="server" CssClass="LabelReadOnly"></asp:Label></TD>
						<TD>Indirizzo</TD>
						<TD>
							<asp:Label id="lblIndirizzo" runat="server" CssClass="LabelReadOnly"></asp:Label></TD>
					</TR>
					<TR>
						<TD>Comune</TD>
						<TD>
							<asp:Label id="lblComune" runat="server" CssClass="LabelReadOnly"></asp:Label></TD>
						<TD>Telefono</TD>
						<TD>
							<asp:Label id="lblTelefono" runat="server" CssClass="LabelReadOnly"></asp:Label></TD>
					</TR>
					<TR>
						<TD>Ditta</TD>
						<TD>
							<asp:Label id="lblDitta" runat="server" CssClass="LabelReadOnly"></asp:Label></TD>
						<TD>Centro di Costo</TD>
						<TD>
							<asp:Label id="lblCdC" runat="server" CssClass="LabelReadOnly"></asp:Label></TD>
					</TR>
					<TR>
						<TD><INPUT id="lblEmail" style="WIDTH: 16px; HEIGHT: 25px" type="hidden" size="1" name="Hidden1"
								runat="server">
							<asp:Label id="presidio" runat="server" Width="0px" Height="0px"></asp:Label></TD>
						<TD>Presidio:</TD>
						<TD colSpan="2">
							<asp:Label id="LbLPresidio" runat="server" Width="0px" Height="0px"></asp:Label></TD>
					</TR>
				</TABLE>
			</asp:Panel></TD>
	</TR>
</TABLE>
<div id="Popup" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; DISPLAY: none; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; POSITION: absolute"><iframe id="doc" style="HEIGHT: 450px" name="doc" src="" frameBorder="no" width="100%" scrolling="auto">
	</iframe>
</div>
