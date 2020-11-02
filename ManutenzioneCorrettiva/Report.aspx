<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="Report.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorretiva.Report" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Report</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
	
	function ApriReport(anno,tipointervento,TipoInterventoDesc)
	{
		var excel=document.getElementById("CheckExcel").checked;
		var descrizione=document.getElementById("CheckDescrizione").checked;
		var servizio=document.getElementById("CheckServizio").checked;
		
		var url = "ReportDettaglio.aspx?anno="+anno+"&tipointervento="+tipointervento+"&TipoInterventoDesc="+TipoInterventoDesc+"&excel="+excel+"&descrizione="+descrizione+"&servizio="+servizio;
		var windowW = 1024;  
		var windowH = 768;	
		W = window.open(url,'ReportContab','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width='+windowW+',height='+windowH+',align=center');					
	}
	function ApriReportPresunto(anno,tipointervento,TipoInterventoDesc)
	{
		var excel=document.getElementById("CheckExcel").checked;
		var descrizione=document.getElementById("CheckDescrizione").checked;
		var servizio=document.getElementById("CheckServizio").checked;
		
		var url = "ReportDettaglioPresunto.aspx?anno="+anno+"&tipointervento="+tipointervento+"&TipoInterventoDesc="+TipoInterventoDesc+"&excel="+excel+"&descrizione="+descrizione+"&servizio="+servizio;
		var windowW = 1024;  
		var windowH = 768;	
		W = window.open(url,'ReportPresunto','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width='+windowW+',height='+windowH+',align=center');					
	}
	function ApriReportSaldo(anno,tipointervento,TipoInterventoDesc,Saldo)
	{
		var excel=document.getElementById("CheckExcel").checked;
		var descrizione=document.getElementById("CheckDescrizione").checked;
		var servizio=document.getElementById("CheckServizio").checked;
		
		var url = "ReportDettaglioSaldo.aspx?anno="+anno+"&tipointervento="+tipointervento+"&TipoInterventoDesc="+TipoInterventoDesc+"&excel="+excel+"&Saldo="+Saldo+"&descrizione="+descrizione+"&servizio="+servizio;;
		var windowW = 1024;  
		var windowH = 768;	
		W = window.open(url,'ReportPresunto','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width='+windowW+',height='+windowH+',align=center');					
	}
	function ApriReportFondo(id)
	{
		var excel=document.getElementById("CheckExcel").checked;
		var url = "ReportDettaglioFondo.aspx?id="+id+"&excel="+excel;
		var windowW = 1024;  
		var windowH = 768;	
		W = window.open(url,'ReportFondo','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width='+windowW+',height='+windowH+',align=center');					
	}
	
	
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center">
						<uc1:PageTitle id="PageTitle1"  title="Report MS" runat="server"></uc1:PageTitle></TD>
				</TR>
				<TR>
					<TD>
						<cc2:datapanel id="DataPanel3" CssClass="DataPanel75" runat="server" AllowTitleExpandCollapse="True"
							CollapseImageUrl="../Images/up.gif" CollapseText="Riduci" ExpandImageUrl="../Images/down.gif"
							ExpandText="Espandi" TitleText="Report" Collapsed="False" TitleStyle-CssClass="TitleSearch">
							<TABLE id="Table2" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<TR>
									<TD style="WIDTH: 163px"><B>Anno:</B></TD>
									<TD colSpan="4">
										<cc1:S_ComboBox id="cmbsAnno" runat="server" Width="217px"></cc1:S_ComboBox>
										<asp:Button id="BtnRicerca" runat="server" Width="89px" Text="Ricerca"></asp:Button></TD>
									<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
            target=_blank>Guida</A></TD>
								</TR>
							</TABLE>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
			<table>
				<tr>
					<td id="tdfondi" runat="server" align="center"></td>
				</tr>
			</table>
			<table align="center" runat="server" id="TblExcel">
				<tr style="CURSOR:hand">
					<td title="Spuntando la casella è possibile visualizzare il risultato del dettaglio in Excel">
						<asp:CheckBox id="CheckExcel" runat="server"></asp:CheckBox>
						<b>Visualizza dettaglio In Excel</b>
					</td>
				</tr>
				<tr style="CURSOR:hand">
					<td title="Spuntando la casella è possibile visualizzare nel dettaglio la Descrizione del problema">
						<asp:CheckBox id="CheckDescrizione" runat="server"></asp:CheckBox>
						<b>Visualizza Descrizione Problema</b>
					</td>
				</tr>
				<tr style="CURSOR:hand">
					<td title="Spuntando la casella è possibile visualizzare nel dettaglio il Servizio">
						<asp:CheckBox id="CheckServizio" runat="server"></asp:CheckBox>
						<b>Visualizza Servizio</b>
					</td>
				</tr>
			</table>
			</cc2:datapanel>
		</form>
	</body>
</HTML>
