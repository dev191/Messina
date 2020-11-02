<%@ Page language="c#" Codebehind="Eq_DocumentiAllegati.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.Eq_DocumentiAllegati" enableViewState="False"%>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Eq_DocumentiAllegati</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
					function openallegati(namefile)
					{
						var url;		
						   
						url = "../ManutenzioneCorrettiva/Visualpdf.aspx?name=" +namefile + "&mittente=Apparecchiatura" ; 
						   
						finestra=window.open(url,'','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width=800,height=600,align=center');	
					}	
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form2" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center">
							<P><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></P>
							<P align="left">
								<TABLE id="tblSearch100Dettaglio" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD style="FONT-WEIGHT: bold">Codice Componente:</TD>
										<TD>
											<cc1:S_Label id="S_lblcodicecomponente" runat="server"></cc1:S_Label></TD>
										<TD style="FONT-WEIGHT: bold">Standard Apparecchiatura:</TD>
										<TD>
											<cc1:S_Label id="S_lblstdapparecchiature" runat="server"></cc1:S_Label></TD>
									</TR>
									<TR>
										<TD style="FONT-WEIGHT: bold">Servizio</TD>
										<TD>
											<cc1:S_Label id="S_Lblservizio" runat="server"></cc1:S_Label></TD>
										<TD style="FONT-WEIGHT: bold">Codice Edificio:</TD>
										<TD>
											<cc1:S_Label id="S_lblcodiceedificio" runat="server"></cc1:S_Label></TD>
									</TR>
									<TR>
										<TD style="FONT-WEIGHT: bold">Edificio:</TD>
										<TD>
											<cc1:S_Label id="S_lbledificio" runat="server"></cc1:S_Label></TD>
										<TD style="FONT-WEIGHT: bold">Piano:</TD>
										<TD>
											<cc1:S_Label id="S_lblpiano" runat="server"></cc1:S_Label></TD>
									</TR>
									<TR>
										<TD style="FONT-WEIGHT: bold">Stanza:</TD>
										<TD>
											<cc1:S_Label id="S_lblstanza" runat="server"></cc1:S_Label></TD>
										<TD></TD>
										<TD></TD>
									</TR>
								</TABLE>
							</P>
						</TD>
					</TR>
					<TR vAlign="top">
						<TD vAlign="top"><asp:datagrid id="MyDataGrid1" runat="server" GridLines="Vertical" AllowPaging="False" CssClass="DataGrid"
								AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="Gray"
								Width="100%" DataKeyField="ID">
								<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
								<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="File Allegati">
										<HeaderStyle Width="50%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="Hyperlink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NOMEFILE") %>' NavigateUrl=<%# "javascript:openallegati("+ "'" + DataBinder.Eval(Container.DataItem, "nomefile") + "'" + " );"%> >
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" ForeColor="Black" BackColor="Silver" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><input id="btnh" onclick="javascript:history.back();" type="button" value="Indietro" <%=BtnHidden%>></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
