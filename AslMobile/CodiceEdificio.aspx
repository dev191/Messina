<%@ Page language="c#" Codebehind="CodiceEdificio.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AslMobile.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 240px" cellSpacing="1"
				cellPadding="1" width="300" border="1">
				<TR>
					<TD>Codice:</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Ricerca:</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<asp:datagrid id="MyDataGrid1" runat="server" BorderColor="Gray" BorderStyle="None" BorderWidth="1px"
							BackColor="White" CellPadding="4" AutoGenerateColumns="False" CssClass="DataGrid" AllowPaging="True"
							GridLines="Vertical" Width="100%">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<a href="" runat="server" id="hrefset"><img border="0" id="imgsele" src="Images/gnome-fs-home.gif"></a>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="bl_id" HeaderText="Cod. Edificio"></asp:BoundColumn>
								<asp:BoundColumn DataField="denominazione" HeaderText="Nome Edificio"></asp:BoundColumn>
								<asp:BoundColumn DataField="id" HeaderText="Id. Edificio" Visible="False"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<TABLE id="Table1" style="BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; FONT-SIZE: 11px; BORDER-LEFT: #666666 1px solid; WIDTH: 75%; COLOR: #000077; BORDER-BOTTOM: darkgray 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: whitesmoke"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 128px">Richiedente</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 128px">Gruppo</TD>
					<TD>
						<asp:DropDownList id="DropDownList1" runat="server"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 128px">Telefono</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 128px">Nota</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 128px">Servizio</TD>
					<TD>
						<asp:DropDownList id="DropDownList2" runat="server"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 128px"><SPAN>Std. Apparecchiatura</SPAN></TD>
					<TD>
						<asp:DropDownList id="DropDownList3" runat="server"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 128px">Urgenza</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 128px">Desc Problema Note</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 128px">Data</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 128px">Ora</TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
