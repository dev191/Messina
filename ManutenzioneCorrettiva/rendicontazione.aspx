<%@ Page language="c#" Codebehind="rendicontazione.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorrettiva.rendicontazione" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Rendicontazione Trimestrale</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" class="DataPanel75" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD style="HEIGHT: 30px">Edificio:</TD>
								<TD style="HEIGHT: 30px"><asp:dropdownlist id="DrEdifici" runat="server" Width="280px"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 30px">Trimestre:</TD>
								<TD style="HEIGHT: 30px"><asp:dropdownlist id="DrTrimestre" runat="server" Width="176px">
										<asp:ListItem Value="1">1&#176; Trimestre</asp:ListItem>
										<asp:ListItem Value="2">2&#176; Trimestre</asp:ListItem>
										<asp:ListItem Value="3">3&#176; Trimestre</asp:ListItem>
										<asp:ListItem Value="4">4&#176; Trimestre</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR id="trvi">
								<TD style="HEIGHT: 32px"><asp:label id="lblAnno" runat="server">Anno:</asp:label></TD>
								<TD style="HEIGHT: 32px"><asp:dropdownlist id="DropAnno" runat="server" Width="128px"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 32px"></TD>
								<TD style="HEIGHT: 32px"></TD>
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
