<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Calendar.ascx.cs" Inherits="TheSite.calendar.Calendar" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table cellSpacing="0" cellPadding="0" border="0">
	<tr>
		<td><asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
		</td>
		<td><input type="button" id="btOpenCal" title="Apri Calendario" value="..." onclick="displayCalendar(<%=txtDate.ClientID%>,'dd/mm/yyyy',this,true)">
		</td>
	</tr>
</table>
