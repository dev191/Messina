<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Fascicolo.ascx.cs" Inherits="TheSite.WebControls.Fascicolo" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<cc1:S_TextBox id="txtfascicolo" runat="server" Width="136px"></cc1:S_TextBox>&nbsp;<INPUT id="btnsRicercafascicolo" title="Fare Click per effettuare la Ricerca sui Fascicoli" type="button"
				value="Ricerca"  onclick="ShowFrameFascicolo('<%=idTextRicFas%>','idric',event,'<%=idModuloFas%>');" class=btn>
<div id="Popupfascicolo" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; DISPLAY: none; BORDER-LEFT: #000000 1px solid; WIDTH: 409px; BORDER-BOTTOM: #000000 1px solid; POSITION: absolute; HEIGHT: 200px">
	<iframe id="docfascicolo" style="WIDTH: 100%; HEIGHT: 200px" name="docfascicolo" src=""
		frameBorder="no" width="100%" scrolling="auto"></iframe>
</div>
