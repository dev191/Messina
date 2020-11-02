<%@ Page language="c#" Codebehind="ReportDettaglioFondo.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorretiva.ReportDettaglioFondo" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Dettaglio di Stampa</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style>
		TABLE { FONT-SIZE: 14px; FONT-FAMILY: Arial }
		.MainTitle { FONT-WEIGHT: bold; FONT-SIZE: 15px; COLOR: darkblue; FONT-FAMILY: Verdana, Arial }
		</style>
		<script language="javascript">
		    function Stampa()
			{
			document.getElementById('btnStampaDett').style.visibility = 'hidden';
			document.getElementById('btnChiudiDett').style.visibility = 'hidden';
			window.print();
			document.getElementById('btnStampaDett').style.visibility = 'visible';
			document.getElementById('btnChiudiDett').style.visibility = 'visible';
			}
   
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="800" align="center" border="0">
				<TR>
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD width="800">
						<TABLE id="Table11" style="WIDTH: 800px; HEIGHT: 34px" cellSpacing="0" cellPadding="0"
							width="800" border="0">
							<TR>
								<TD class="MainTitle">
									<b>Stampa Dettaglio Fondo</b>
								</TD>
							</TR>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<TR>
								<TD>
									<b>Anno:</b><font color="#ff0000">&nbsp;<%=anno%></font>
								</TD>
							</TR>
							<TR>
								<TD>
									<b>Tipo Intervento:</b><font color="#ff0000">&nbsp;<%=TipoInterventoDesc%></font>
								</TD>
							</TR>
						</TABLE>
						<br>
						<TABLE id="Table2" style="WIDTH: 800px; HEIGHT: 34px" cellSpacing="0" cellPadding="0" width="800"
							border="1">
							<TR>
								<td align="left"><b>Importo Netto:</b>&nbsp;<%=Formatta(ImportoNetto)%></td>
							</TR>
							<tr>	
								<td align="left"><b>Importo Lordo:</b>&nbsp;<%=Formatta(ImportoLordo)%></td>
							</tr>
							<tr>	
								<td align="left"><b>Descrizione Fondo:</b>&nbsp;<%=Descrizione%></td>
							</tr>
							<tr>	
								<td align="left"><b>Note:</b>&nbsp;<%=Note%></td>								
							</TR>
							
						</TABLE>
						<table align="center" id="TblMessaggio" runat="server">
							<tr>
								<td class="MainTitle">Nessuna Richiesta esistente con i filtri impostati</td>
							</tr>
						</table>
						<br>
						<table align="center">
							<tr>
								<td><input type="button" id="btnStampaDett" value="Stampa" onclick="Stampa();"></td>
								<td><input type="button" id="btnChiudiDett" value="Chiudi" onclick="javascript:window.close();"></td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
