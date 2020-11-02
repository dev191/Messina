<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Page language="c#" Codebehind="ListaPmp.aspx.cs" AutoEventWireup="false" Inherits="TheSite.CommonPage.ListaPmp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListaMatricole</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		var NS4 = (navigator.appName == "Netscape" && parseInt(navigator.appVersion) < 5);
		var NSX = (navigator.appName == "Netscape");
		var IE4 = (document.all) ? true : false;

		function Chiudi()
		{
			var oVDiv=parent.document.getElementById("Popupmatricole").style;
			oVDiv.display = 'none';
		}
		function seleziona(codice,descrizione,codnum)
		{
		 parent.document.getElementById(idmodulo + "_" + "txtmatricola").value=codice;
		 parent.document.getElementById(idmodulo + "_" + "txtdescrizione").value=descrizione;
		 parent.document.getElementById(idmodulo + "_" + "txtid").value=codnum;		 
		 Chiudi();
		 parent.__doPostBack(idmodulo + '$txtmatricola','');        
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="TDCommon"><asp:hyperlink id="HyperLink1" runat="server" NavigateUrl="javascript:Chiudi()" Height="16px" Width="56px"><img border="0" src="../Images/chiudi.gif" /></asp:hyperlink></TD>
				</TR>
				<TR>
					<TD>
						<uc1:GridTitle id="GridTitle1" runat="server"></uc1:GridTitle>
						<asp:DataGrid id="DataGrid1" runat="server" Width="100%" BorderColor="Gray" BorderStyle="None"
							BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False" CssClass="DataGrid"
							AllowPaging="True" GridLines="Vertical">
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Seleziona">
									<ItemTemplate>
										<a href="javascript:seleziona('<%# DataBinder.Eval(Container, "DataItem.Id") %>','<%# DataBinder.Eval(Container, "DataItem.descrizione") %>','<%# DataBinder.Eval(Container, "DataItem.idnumerico") %>');"><img border="0" src="../Images/edit.gif"></a>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="idnumerico" HeaderText="idnumerico" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="ID" HeaderText="Codice"></asp:BoundColumn>
								<asp:BoundColumn DataField="descrizione" HeaderText="Descrizione"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></TD>
				</TR>
				<TR>
					<TD class="TDCommon"><asp:hyperlink id="Hyperlink2" runat="server" NavigateUrl="javascript:Chiudi()" Height="16px" Width="56px"><img border="0" src="../Images/chiudi.gif" /></asp:hyperlink></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
