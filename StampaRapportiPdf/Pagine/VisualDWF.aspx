<%@ Page language="c#" Codebehind="VisualDWF.aspx.cs" AutoEventWireup="false" Inherits="StampaRapportiPdf.Pagine.VisualDWF" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>VisualDWF</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="tblMain">
				<TBODY>
					<TR>
						<TD>
							<TABLE>
								<TBODY>
									<TR>
										<TD>
											<ASP:LINKBUTTON id="lnkBtnDownload" runat="server">Vai alla pagina di download</ASP:LINKBUTTON>
										</TD>
										<TD width="50">
										</TD>
										<TD>
											<ASP:LINKBUTTON id="lnkBtnRicerca" runat="server">Vai alla pagina di ricerca e stampa</ASP:LINKBUTTON>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>
							<TABLE width="924" height="668">
								<TBODY>
									<TR>
										<TD align="center">
											<ASP:LITERAL id="ltlVisualizza" runat="server"></ASP:LITERAL>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
