<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AggiungiSollecito.ascx.cs" Inherits="TheSite.WebControls.AggiungiSollecito" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<INPUT id="btsCodice" title="Aggiungi un sollecito alla RDL" style="WIDTH: 136px; HEIGHT: 22px"
	type="button" value="Aggiungi Sollecito" runat="server" >
<asp:textbox id="txtWR_ID" runat="server" Width="0px"></asp:textbox>
<div id="PopupAddSoll" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; DISPLAY: none; BORDER-LEFT: #000000 1px solid; WIDTH: 850px; BORDER-BOTTOM: #000000 1px solid; POSITION: absolute; HEIGHT: 150px">
	<IFRAME id="docAddSoll" name="docAddSoll" src="" frameBorder="no" style="WIDTH:850px; HEIGHT: 250px">
	</IFRAME>
</div>
