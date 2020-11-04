<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="ListaDestinazioneUso.aspx.cs" AutoEventWireup="false" Inherits="TheSite.CommonPage.ListaDestinazioneUso" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListaDestinazioniUso</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		var NS4 = (navigator.appName == "Netscape" && parseInt(navigator.appVersion) < 5);
		var NSX = (navigator.appName == "Netscape");
		var IE4 = (document.all) ? true : false;

		function Chiudi()
		{
			window.close();
		}
		function seleziona(sender)
		{
		var appo=('<%=NomeTxtDesc %>');
		 opener.document.materiali.appo.value=sender;
		 Chiudi();
		}
		
		
		function PopolaDest(desc,id)
			{ 
				var appo=('<%=NomeTxtDesc %>');/*s_txtDestinazione*/
				var appo1=('<%=NomeTxtIdMat %>');
				opener.document.getElementById('<%=NomeTxtDesc %>').value=desc;
				if (appo1 != '') 
				  opener.document.getElementById('<%=NomeTxtIdMat %>').value=id;         
				Chiudi();
			}	
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="TDCommon"><asp:hyperlink id="HyperLink1" runat="server" Width="56px" Height="16px" NavigateUrl="javascript:Chiudi()"><img border="0" src="../Images/chiudi.gif" /></asp:hyperlink></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="DataGrid1" runat="server" Width="100%" PageSize="5" DataKeyField="id" GridLines="Vertical"
							AllowPaging="True" CssClass="DataGrid" AutoGenerateColumns="False" CellPadding="4" BackColor="White"
							BorderWidth="1px" BorderStyle="None" BorderColor="Gray">
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Seleziona">
									<HeaderStyle Width="10px"></HeaderStyle>
									<ItemTemplate>
										<a href="" runat="server" id="hrefset"><img border="0" src="../Images/edit.gif"></a>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="id"></asp:BoundColumn>
								<asp:BoundColumn DataField="descrizione" HeaderText="Destinazione"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="Black" BackColor="#D9E3FD" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD class="TDCommon"><asp:hyperlink id="Hyperlink2" runat="server" Width="56px" Height="16px" NavigateUrl="javascript:Chiudi()"><img border="0" src="../Images/chiudi.gif" /></asp:hyperlink></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
