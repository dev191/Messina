<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="KPI_Download.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.KPI_Download" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Download KPI</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function setvis()
			{
			    if(document.getElementById('DropTipoDoc').value=="1")
			    {
					document.getElementById('r1').style.display ="block";
					document.getElementById('r2').style.display ="block";
				}else {
				    document.getElementById('r1').style.display ="none";
					document.getElementById('r2').style.display ="none";
					
				}
				 
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="setvis();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="tblSearch100Dettaglio" class="tblSearch100Dettaglio" style="WIDTH: 100%" 
                  cellSpacing=1 cellPadding=1 border=0>
							<TR id="r1">
								<TD style="HEIGHT: 19px">Edificio:</TD>
								<TD style="HEIGHT: 19px"><asp:dropdownlist id="DrEdifici" runat="server" Width="280px"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 19px">Nome Documento:</TD>
								<TD style="HEIGHT: 19px"><asp:textbox id="txtNomeDoc" runat="server" Width="176px" MaxLength="50"></asp:textbox></TD>
							</TR>
							<TR id="r2">
								<TD><asp:label id="lblAnno" runat="server">Anno:</asp:label></TD>
								<TD><asp:dropdownlist id="DropAnno" runat="server" Width="128px"></asp:dropdownlist></TD>
								<TD><asp:label id="lblMese" runat="server">Mese:</asp:label></TD>
								<TD><asp:dropdownlist id="DropMese" runat="server" Width="176px">
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
							<TR>
								<TD>Tipo Doc:</TD>
								<TD>
									<asp:dropdownlist id="DropTipoDoc" runat="server" Width="200px">
										<asp:ListItem Value="1">KPI Vodafone</asp:ListItem>
										<asp:ListItem Value="3">KPI SLA Salvati</asp:ListItem>
										<asp:ListItem Value="2">KPI Inviati al Server</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><cc1:s_button id="btnsRicerca" runat="server" Text="Ricerca"></cc1:s_button>&nbsp;
						<asp:button id="cmdReset" Text="Reset" Runat="server"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><A class=GuidaLink href="../<%= HelpLink %>" target=_blank >Guida</A></TD>
				</TR>
				<TR>
					<TD><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" AllowPaging="True" GridLines="Vertical" AutoGenerateColumns="False"
							BorderWidth="1px" BorderColor="Gray" CssClass="DataGrid">
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Download">
									<HeaderStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton id="btScarica" Runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"nomefile")%>' ImageUrl="../images/excel.gif" CommandName="Download">
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="nomefile" HeaderText="Documento"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
