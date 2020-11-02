<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="UserStanze" Src="../WebControls/UserStanze.ascx" %>
<%@ Page language="c#" Codebehind="DataRoom.aspx.cs" AutoEventWireup="false" Inherits="WebCad.Edifici.DataRoom" %>
<%@ Register TagPrefix="uc1" TagName="CodiceStdApparecchiatura" Src="../WebControls/CodiceStdApparecchiatura.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NavigazioneApparechiature</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">

	function ClearStdApparechiature()
	{
		var ctrlstd=document.getElementById('<%=CodiceStdApparecchiatura1.s_CodiceStdApparecchiatura.ClientID%>');
		if(ctrlstd!=null && ctrlstd!='undefined')
		{
		  ctrlstd.value="";
		  document.getElementById('<%=CodiceStdApparecchiatura1.CodiceHidden.ClientID%>').value="";
		}
	}
	
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
							TitleText="Ricerca" ExpandText="Espandi" ExpandImageUrl="../Images/downarrows_trans.gif" CollapseText="Espandi/Riduci" CssClass="DataPanel75"
							CollapseImageUrl="../Images/uparrows_trans.gif" AllowTitleExpandCollapse="True">
							<TABLE id="tblSearch100" cellSpacing="1" cellPadding="1" border="0">
								<TR>
									<TD vAlign="top" align="center" colSpan="2">
										<uc1:RicercaModulo id="RicercaModulo1" runat="server"></uc1:RicercaModulo></TD>
								</TR>
								<TR>
									<TD><SPAN><SPAN>Piano: </SPAN></SPAN>
									</TD>
									<TD>
										<cc1:S_ComboBox id="cmbsPiano" runat="server" Width="392px" DBDirection="Input" DBIndex="1" DBSize="10"
											DBDataType="Integer"></cc1:S_ComboBox></TD>
								</TR>
								<TR>
									<TD colSpan="2"><SPAN>
											<uc1:UserStanze id="UserStanze1" runat="server"></uc1:UserStanze></SPAN></TD>
								</TR>
								<TR>
									<TD><SPAN>Servizio:</SPAN></TD>
									<TD>
										<cc1:S_ComboBox id="cmbsServizio" runat="server" Width="392px"></cc1:S_ComboBox></TD>
								</TR>
								<TR>
									<TD><SPAN>Std. Apparecchiatura:</SPAN></TD>
									<TD>
										<cc1:S_ComboBox id="cmbsApparecchiatura" runat="server" Width="392px"></cc1:S_ComboBox></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center" colSpan="2">
										<uc1:CodiceApparecchiature id="CodiceApparecchiature1" runat="server"></uc1:CodiceApparecchiature></TD>
								</TR>
								<TR>
									<TD colSpan="2">&nbsp;
										<uc1:CodiceStdApparecchiatura id="CodiceStdApparecchiatura1" runat="server" Visible="False"></uc1:CodiceStdApparecchiatura>
										<P></P>
										<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD style="WIDTH: 219px" align="right">
													<cc1:S_Button id="S_btMostra" runat="server" CssClass="btn" Width="134px" ToolTip="Avvia la ricerca"
														Text="Mostra Dettagli"></cc1:S_Button>&nbsp;</TD>
												<TD>&nbsp;
													<cc1:S_Button id="btReset" runat="server" CssClass="btn" Width="134px" Text="Reset"></cc1:S_Button></TD>
												<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</COLLAPSE:DATAPANEL></TD>
				</TR>
				<TR vAlign="top">
					<TD vAlign="top"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="MyDataGrid1" runat="server" CssClass="DataGrid" Width="100%" GridLines="Vertical"
							AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="Gray">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton id=Imagebutton1 title="Elenco Apparecchiature per Stanza" OnCommand="imagebutton1_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id_rm")+"&amp;bl_id=" + DataBinder.Eval(Container.DataItem,"id_bl")+"&amp;piani=" + DataBinder.Eval(Container.DataItem,"idpiani")+ "&amp;TitoloStanza=" +DataBinder.Eval(Container.DataItem,"Stanza")  %>' Runat="server" ImageUrl="../Images/Stanza.gif">
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="30px"></HeaderStyle>
									<ItemTemplate>
										<asp:ImageButton id=Imagebutton2 title="Elenco Apparecchiature per Piano" OnCommand="imagebutton2_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"idpiani")+"&amp;bl_id=" + DataBinder.Eval(Container.DataItem,"id_bl") + "&amp;TitoloPiano=" +DataBinder.Eval(Container.DataItem,"piano") %>' Runat="server" ImageUrl="../Images/Piano.gif">
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="bl_id" HeaderText="Cod.Edificio"></asp:BoundColumn>
								<asp:BoundColumn DataField="piano" HeaderText="Piano"></asp:BoundColumn>
								<asp:BoundColumn DataField="stanza" HeaderText="Stanza"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="id_bl"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="id_rm"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="idpiani"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="Black" BackColor="Silver" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
