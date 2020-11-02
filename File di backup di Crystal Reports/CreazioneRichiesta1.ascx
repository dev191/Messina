<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CreazioneRichiesta1.ascx.cs" Inherits="TheSite.AslMobile.CreazioneRichiesta1" TargetSchema="http://schemas.microsoft.com/Mobile/WebUserControl" %>
<TABLE id="Table1" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 100%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
	cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD align="center" bgColor="#3399cc" colSpan="2">
			<B>Creazione Richiesta di Lavoro</B>
		</TD>
	</TR>
	<TR>
		<TD bgColor="white">Rdl. N°</TD>
		<TD bgColor="white">
			<mobile:Label id="LblRdl" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD bgColor="whitesmoke">Trasmissione</TD>
		<TD bgColor="whitesmoke">
			<mobile:Label id="lblTrasmissione" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD bgColor="white">Richiedente</TD>
		<TD bgColor="white">
			<mobile:Label id="lblRichiedente" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD>Operatore</TD>
		<TD>
			<mobile:Label id="lblOperatore" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD bgColor="white">Tel.&nbsp;Richiedente</TD>
		<TD bgColor="white">
			<mobile:Label id="lblTelefono" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD>Data&nbsp;Richiesta</TD>
		<TD>
			<mobile:Label id="lblDataRichiesta" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD bgColor="white">Ora Richiesta</TD>
		<TD bgColor="white">
			<mobile:Label id="lblOraRichiesta" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD>Gruppo</TD>
		<TD>
			<mobile:Label id="lblGruppo" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD bgColor="white">Fabricato</TD>
		<TD bgColor="white">
			<mobile:Label id="lblFabriccato" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD>Note</TD>
		<TD>
			<mobile:Label id="lblNote" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD bgColor="white">Servizio</TD>
		<TD bgColor="white">
			<mobile:Label id="lblServizio" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD>Std.App.</TD>
		<TD>
			<mobile:Label id="lblStandApp" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD bgColor="white">App.</TD>
		<TD bgColor="white">
			<mobile:Label id="lblApp" runat="server">Label</mobile:Label>
		</TD>
	</TR>
	<TR>
		<TD>Desc Intervento</TD>
		<TD>
			<mobile:Label id="lblDescrizione" runat="server">Label</mobile:Label>
		</TD>
	</TR>
</TABLE>
