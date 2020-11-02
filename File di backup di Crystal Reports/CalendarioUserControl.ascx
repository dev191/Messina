<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CalendarioUserControl.ascx.cs" Inherits="TheSite.AslMobile.CalendarioUserControl" TargetSchema="http://schemas.microsoft.com/Mobile/WebUserControl" %>
<mobile:Panel id="Panel1" runat="server">
	<mobile:DeviceSpecific id="DeviceSpecific1" runat="server">
		<Choice Filter="isHTML32" Xmlns="http://schemas.microsoft.com/mobile/html32template">
			<ContentTemplate>
				<mobile:Calendar id="Calendar1"  OnSelectionChanged="Calendar_SelectionChangedDataStart" runat="server"></mobile:Calendar>
			</ContentTemplate>
		</Choice>
	</mobile:DeviceSpecific>
</mobile:Panel>
