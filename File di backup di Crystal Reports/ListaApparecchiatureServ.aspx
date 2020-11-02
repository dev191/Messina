<%@ Page language="c#" Codebehind="ListaApparecchiatureServ.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.ListaApparecchiatureServ" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
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
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" align="left">
				<TR>
					<TD>
						<P>
							<asp:datagrid id="DtgListaApparecchiature" runat="server" BorderColor="Gray" BorderStyle="None"
								BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False" AllowPaging="True"
								GridLines="Vertical" Width="100%" CssClass="DataGrid" PageSize="25">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
								<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="var_eq_eq_id" HeaderText="Codice Apparecchiatura"></asp:BoundColumn>
									<asp:HyperLinkColumn Text="var_eq_eq_id" DataNavigateUrlField="var_eq_eq_id" DataNavigateUrlFormatString="javascript:var w =window.open('../AnagrafeImpianti/SchedaApparecchiatura.aspx?eq_id={0}','_blank','width=800,height=600,location=no,scrollbars=yes')"
										DataTextField="var_eq_eq_id" HeaderText="Cod. Apparecchiatura"></asp:HyperLinkColumn>
									<asp:BoundColumn DataField="description" HeaderText="Desc. Apparecchiatura"></asp:BoundColumn>
									<asp:BoundColumn DataField="category" HeaderText="Spec. Impianto"></asp:BoundColumn>
									<asp:BoundColumn DataField="room" HeaderText="Stanza"></asp:BoundColumn>
									<asp:BoundColumn DataField="quantita" HeaderText="Q.t&#224;"></asp:BoundColumn>
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
