<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="ReportDettaglio.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorretiva.ReportDettaglio" %>
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
									<b>Stampa Dettaglio Contabilizazione</b>
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
								<td align="center"><b>Impianto</b></td>
								<td align="center"><b>Cod. RdL</b></td>
								<td align="center"><b>Cod. OdL</b></td>
								<td align="center"><b>Cod. OdL </b></td>
								<%if(Request.QueryString["servizio"].ToString()=="true"){%>
									<td align="center"><b>Servizio</b></td>
								<%}%>
								<%if(Request.QueryString["descrizione"].ToString()=="true"){%>	
								<td align="center"><b>Descrizione Problema</b></td>
								<%}%>
								<td align="center"><b>Presunto</b></td>
								<td align="center"><b>Contabilizzato</b></td>
								<td align="center"><b>Scostamento</b></td>								
							</TR>
							<asp:repeater id="repeater1" Runat="server">
								<ItemTemplate>
									<tr>
										<td>&nbsp;<%#DataBinder.Eval(Container.DataItem, "centrale_termica")%>
										</td>										
										<td align="right" nowrap>&nbsp;<%#DataBinder.Eval(Container.DataItem, "wr_id")%></td>
										<td align="right" nowrap>&nbsp;<%#DataBinder.Eval(Container.DataItem, "wo_id")%></td>
										<td align="right" nowrap>&nbsp;<%#DataBinder.Eval(Container.DataItem, "ordinativo")%></td>
										<%if(Request.QueryString["servizio"].ToString()=="true"){%>
										<td align="right" nowrap>&nbsp;<%#DataBinder.Eval(Container.DataItem, "Servizio")%></td>
										<%}%>
										<%if(Request.QueryString["descrizione"].ToString()=="true"){%>	
										<td align="right" nowrap>&nbsp;<%#DataBinder.Eval(Container.DataItem, "DescrProblema")%></td>
										<%}%>
										<td align="right" nowrap>&nbsp;<%#Formatta(DataBinder.Eval(Container.DataItem, "Presunto").ToString())%></td>
										<td align="right" nowrap>&nbsp;<%#Formatta(DataBinder.Eval(Container.DataItem, "Contabilizzato").ToString())%></td>
										<td align="right" nowrap>&nbsp;<%#Formatta(DataBinder.Eval(Container.DataItem, "Scostamento").ToString())%></td>
									</tr>
								</ItemTemplate>
							</asp:repeater>
							<asp:repeater id="repeater2" Runat="server">
								<ItemTemplate>
									<tr>
										<td align="right" id="tdTotale" colspan="<%=colspan%>"><b>TOTALI</b>
										</td>
										<td align="right" nowrap><b>&nbsp;<%#Formatta(DataBinder.Eval(Container.DataItem, "TotPresunto").ToString())%></b></td>
										<td align="right" nowrap><b>&nbsp;<%#Formatta(DataBinder.Eval(Container.DataItem, "TotContabilizzato").ToString())%></b></td>
										<td align="right" nowrap><b>&nbsp;<%#Formatta(DataBinder.Eval(Container.DataItem, "TotScostamento").ToString())%></b></td>
									</tr>
								</ItemTemplate>
							</asp:repeater>
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
