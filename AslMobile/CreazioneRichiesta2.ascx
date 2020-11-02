<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CreazioneRichiesta2.ascx.cs" Inherits="TheSite.AslMobile.CreazioneRichiesta2" TargetSchema="http://schemas.microsoft.com/Mobile/WebUserControl" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<TABLE id="Table2" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
	cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD align="center" bgColor="#3399cc" colSpan="2">
			<B>Emissione Ordine di Lavoro</B>
		</TD>
	</TR>
	<TR>
		<TD bgColor="white">Ordine</TD>
		<TD bgColor="white">
			<mobile:Label id="S_Lblordinelavoro" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD>Ditta</TD>
		<TD>
			<mobile:Label id="lblditta" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD bgColor="white">Addetto</TD>
		<TD bgColor="white">
			<mobile:Label id="lbladdetto" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD>Tipo Intervento</TD>
		<TD>
			<mobile:Label id="lbltipointervento" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD bgColor="white">Urgenza</TD>
		<TD bgColor="white">
			<mobile:Label id="lblurgenza" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD>Data&nbsp;Pianificata</TD>
		<TD>
			<mobile:Label id="ldldatap" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD bgColor="white">Ora Pianificata</TD>
		<TD bgColor="white">
			<mobile:Label id="lblorap" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD colSpan="2">
			<mobile:Label id="LblMessaggio" runat="server">Label</mobile:Label>
		</TD>
	</TR>
</TABLE>
