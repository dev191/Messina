<%@ Page language="c#" Codebehind="KPI_vod_report.aspx.cs" AutoEventWireup="false" Inherits="TheSite.SoddisfazioneCliente.KPI_vod_report" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Report KPI Vodafone</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function checkMesi()
			{
			var meseFine  = document.getElementById('DropMeseFine').value;
			var meseInizio = document.getElementById('DropMeseIni').value;
			if (meseFine < meseInizio)
			{
			alert('Attenzione il mese fine selezionato è precedente al mese inizio');
			}
				 
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="tbl1" class="tblSearch100Dettaglio" style="WIDTH: 100%" cellSpacing="1" cellPadding="1"
							border="0">
							<TR>
								<TD style="HEIGHT: 19px"><asp:label id="lblAnno" runat="server">Mese Inizio:</asp:label></TD>
								<TD style="HEIGHT: 19px">
									<asp:dropdownlist id="DropMeseIni" runat="server" Width="128px">
										<asp:ListItem Value="1">Gennaio</asp:ListItem>
										<asp:ListItem Value="2">Febbraio</asp:ListItem>
										<asp:ListItem Value="3">Marzo</asp:ListItem>
										<asp:ListItem Value="4">Aprile</asp:ListItem>
										<asp:ListItem Value="5">Maggio</asp:ListItem>
										<asp:ListItem Value="6">Giugno</asp:ListItem>
										<asp:ListItem Value="7">Luglio</asp:ListItem>
										<asp:ListItem Value="8">Agosto</asp:ListItem>
										<asp:ListItem Value="9">Settembre</asp:ListItem>
										<asp:ListItem Value="10">Ottobre</asp:ListItem>
										<asp:ListItem Value="11">Novembre</asp:ListItem>
										<asp:ListItem Value="12">Dicembre</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 19px">Mese Fine:</TD>
								<TD style="HEIGHT: 19px">
									<asp:dropdownlist id="DropMeseFine" runat="server" Width="128px">
										<asp:ListItem Value="1">Gennaio</asp:ListItem>
										<asp:ListItem Value="2">Febbraio</asp:ListItem>
										<asp:ListItem Value="3">Marzo</asp:ListItem>
										<asp:ListItem Value="4">Aprile</asp:ListItem>
										<asp:ListItem Value="5">Maggio</asp:ListItem>
										<asp:ListItem Value="6">Giugno</asp:ListItem>
										<asp:ListItem Value="7">Luglio</asp:ListItem>
										<asp:ListItem Value="8">Agosto</asp:ListItem>
										<asp:ListItem Value="9">Settembre</asp:ListItem>
										<asp:ListItem Value="10">Ottobre</asp:ListItem>
										<asp:ListItem Value="11">Novembre</asp:ListItem>
										<asp:ListItem Value="12">Dicembre</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR id="trvi">
								<TD><asp:label id="Label1" runat="server">Anno:</asp:label></TD>
								<TD><asp:dropdownlist id="DropAnno" runat="server" Width="128px"></asp:dropdownlist></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD colSpan="3">&nbsp;
									<asp:button id="BtGenera" runat="server" Width="112px" Text="Genera Report"></asp:button>&nbsp;<asp:button id="BtSalva" runat="server" Width="144px" Text="Genera/Salva Report"></asp:button>&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
