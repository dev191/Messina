<%@ Control Language="c#" AutoEventWireup="false" Codebehind="VisualizzaReperibilita.ascx.cs" Inherits="TheSite.WebControls.VisualizzaReperibilita" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<INPUT id="btsCodice" title="Visualizza la reperibilità degli addetti" style="WIDTH: 153px; HEIGHT: 22px"
	type="button" value="Visualizza Reperibilità" runat="server" class=btn><BR>
<asp:TextBox id="txtBL_ID" runat="server" Width="0px"></asp:TextBox>
<div id="PopupRep" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; DISPLAY: none; BORDER-LEFT: #000000 1px solid; WIDTH: 100%; BORDER-BOTTOM: #000000 1px solid; POSITION: absolute; HEIGHT: 200%"><IFRAME id="docRep" name="docRep" src="" frameBorder="no" height="300" width="100%"></IFRAME>
</div>
