<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Page language="c#" Codebehind="DettDestinatariInvio.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorrettiva.DettDestinatariInvio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>lista</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle>
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
				<TR>
					<TD>
						<P><asp:datagrid id="DataGridRicerca" runat="server" PageSize="25" CssClass="DataGrid" Width="100%"
								GridLines="Vertical" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" BackColor="White"
								BorderWidth="1px" BorderStyle="None" BorderColor="Gray">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
								<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="email" HeaderText="Destinatari"></asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" ForeColor="Black" BackColor="#D9E3FD" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
