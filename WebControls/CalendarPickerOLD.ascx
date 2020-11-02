<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CalendarPickerOLD.ascx.cs" Inherits="TheSite.WebControls.CalendarPickerOLD" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<cc1:s_textbox id="S_TxtDatecalendar" runat="server" Width="120px"></cc1:s_textbox><INPUT id="btCalendar" title="Visualizza il Calendario" style="WIDTH: 24px; HEIGHT: 24px"
	type="button" value="..." name="btCalendar" runat="server" class=btn>
<div id="Popupdata" runat="server" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; DISPLAY: none; BORDER-LEFT: #000000 1px solid; WIDTH: 409px; BORDER-BOTTOM: #000000 1px solid; POSITION: absolute; HEIGHT: 256px">
	<iframe id="docdata" runat="server" style="WIDTH: 100%; HEIGHT: 256px" name="docdata" src=""
		frameBorder="no" width="100%" scrolling="auto"></iframe>
</div>
