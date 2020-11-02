<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CreazioneRichiesta3.ascx.cs" Inherits="TheSite.AslMobile.CreazioneRichiesta3" TargetSchema="http://schemas.microsoft.com/Mobile/WebUserControl" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<TABLE id="Table2" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
	cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD align="center" bgColor="#3399cc" colSpan="2">
			<B>Completamento Ordine di 
      Lavoro</B>
		</TD>
	</TR>
	<TR>
		<TD bgColor="white">Stato Ric.</TD>
		<TD bgColor="white">
			<mobile:Label id="lblstato" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD>Sospesa per</TD>
		<TD>
			<mobile:Label id="lblsospesa" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD bgColor="white">Data/Ora inizio</TD>
		<TD bgColor="white">
			<mobile:Label id="lblDataInizio" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD>Data/Ora fine</TD>
		<TD>
			<mobile:Label id="lblDataFine" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD bgColor="white">Annotazioni</TD>
		<TD bgColor="white">
			<mobile:Label id="lblAnnotazioni" runat="server">Label</mobile:Label>
		</TD>
	</TR>
</TABLE>
