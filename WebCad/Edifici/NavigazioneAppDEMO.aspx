<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Page language="c#" Codebehind="NavigazioneAppDEMO.aspx.cs" AutoEventWireup="false" Inherits="WebCad.Edifici.NavigazioneAppDEMO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NavigazioneApparechiature</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center">
							<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></TD>
					</TR>
					<TR vAlign="top">
						<TD vAlign="top">
							<uc1:GridTitle id="GridTitle1" runat="server"></uc1:GridTitle>
							<asp:DataGrid id="MyDataGrid1" runat="server" Width="100%" BorderColor="Gray" BorderStyle="None"
								BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False" CssClass="DataGrid"
								AllowPaging="True" GridLines="Vertical" PageSize="20">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
								<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="bl_id" HeaderText="Cod.Edificio"></asp:BoundColumn>
									<asp:BoundColumn DataField="eq_id" HeaderText="Cod. Apparecchiatura"></asp:BoundColumn>
									<asp:BoundColumn DataField="std" HeaderText="Std. Apparecchiatura"></asp:BoundColumn>
									<asp:BoundColumn DataField="descrizione" HeaderText="Servizio"></asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" ForeColor="Black" BackColor="Silver" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
							<asp:Button id="BntIndietro" runat="server" Text="Indietro"></asp:Button>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
