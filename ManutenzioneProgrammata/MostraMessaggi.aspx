<%@ Page language="c#" Codebehind="MostraMessaggi.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.MostraMessaggi" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>MostraMessaggi</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<FORM id="Form1" method="post" runat="server">
			<TABLE width="100%">
				<TR>
					<TD>
						<ASP:LABEL id="lblErroreINIT" runat="server" width="320px">Con i seguenti filtri di selezione:</ASP:LABEL>
					</TD>
				</TR>
				<TR>
					<TD>
					&nbsp; &nbsp;	&nbsp;<ASP:LABEL id="lblAnno" runat="server">Label</ASP:LABEL></TD>
				</TR>
				<TR>
					<TD>
					&nbsp; &nbsp;	&nbsp;<ASP:LABEL id="lblMEse" runat="server">Label</ASP:LABEL></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px">
						&nbsp; &nbsp;	&nbsp;<ASP:LABEL id="lblEdificio" runat="server">Label</ASP:LABEL></TD>
				</TR>
				<TR>
					<TD>
						&nbsp; &nbsp;	&nbsp;<ASP:LABEL id="lblServizio" runat="server">Label</ASP:LABEL></TD>
				</TR>
				<TR>
					<TD>
						&nbsp; &nbsp;	&nbsp;<ASP:LABEL id="lblClasseelemento" runat="server">Label</ASP:LABEL></TD>
				</TR>
				<TR>
					<TD>
						<ASP:LABEL id="lblFINEerr" runat="server">il sitema  non ha generato risultati, cambia i filtri  di selezione e riprova</ASP:LABEL></TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
