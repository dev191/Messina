<%@ Control Language="c#" AutoEventWireup="false" Codebehind="VisualizzaSolleciti.ascx.cs" Inherits="TheSite.WebControls.VisualizzaSolleciti" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<INPUT id="btsCodice" title="Visualizza i solleciti della RDL" style="WIDTH: 136px; HEIGHT: 22px"
	type="button" value="Visualizza Solleciti" runat="server">
<ASP:TEXTBOX id="txtWR_ID" runat="server" width="0px"></ASP:TEXTBOX>
<DIV id="PopupVisSoll" style="BORDER-RIGHT: #000000 1px solid; 
	BORDER-TOP: #000000 1px solid; DISPLAY: none; 
	BORDER-LEFT: #000000 1px solid; WIDTH: 650px; 
	BORDER-BOTTOM: #000000 1px solid; POSITION: absolute; HEIGHT: 200px">
	<IFRAME id="docVisSoll" name="docVisSoll" src="" frameborder="no" width="650" height="200"
		style="WIDTH: 696px; HEIGHT: 216px"></IFRAME>
</DIV>
