<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Matricole.ascx.cs" Inherits="TheSite.WebControls.Matricole" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<cc1:S_TextBox id="txtmatricola" runat="server" Width="136px"></cc1:S_TextBox>&nbsp;<INPUT id="btnsRicercamatricola" title="Fare Click per effettuare la Ricerca sulle Matricole" type="button"
				value="Ricerca"  onclick="ShowFrameMatricole('<%=idTextRicMat%>','idric',event,'<%=idModuloMat%>');" class=btn>
<div id="Popupmatricole" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; DISPLAY: none; BORDER-LEFT: #000000 1px solid; WIDTH: 409px; BORDER-BOTTOM: #000000 1px solid; POSITION: absolute; HEIGHT: 138px">
	<iframe id="docmatricole" style="WIDTH: 100%; HEIGHT: 138px" name="docmatricole" src=""
		frameBorder="no" width="100%" scrolling="auto"></iframe>
</div>
