<%@ Page language="c#" Codebehind="NavigazioneApparecchiature.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.NavigazioneApparecchiature" %>
<%@ Register TagPrefix="uc1" TagName="UserStanze" Src="../WebControls/UserStanze.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
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
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center">
						<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left">
						<COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" AllowTitleExpandCollapse="True" CollapseImageUrl="../Images/up.gif"
							CssClass="DataPanel75" CollapseText="Espandi/Riduci" ExpandImageUrl="../Images/down.gif" ExpandText="Espandi"
							TitleText="Ricerca" Collapsed="False" TitleStyle-CssClass="TitleSearch">
							<TABLE id="tblSearch100" cellSpacing="1" cellPadding="1" border="0">
								<TR>
									<TD vAlign="top" align="center" colSpan="4">
										<P>
											<uc1:RicercaModulo id="RicercaModulo1" runat="server"></uc1:RicercaModulo></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%">Piano:</TD>
									<TD style="HEIGHT: 28px">
										<cc1:s_combobox id="cmbsPiano" runat="server" Width="200px"></cc1:s_combobox></TD>
									<TD colSpan="2">
										<uc1:UserStanze id="UserStanze1" runat="server"></uc1:UserStanze></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 6px"><SPAN>Servizio: </SPAN>
									</TD>
									<TD style="HEIGHT: 6px" colSpan="3">
										<cc1:S_ComboBox id="cmbsServizio" runat="server" Width="392px" AutoPostBack="True"></cc1:S_ComboBox></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 28px"><SPAN>Std. Apparecchiatura:</SPAN>
									</TD>
									<TD style="HEIGHT: 28px" colSpan="3">
										<cc1:S_ComboBox id="cmbsApparecchiatura" runat="server" Width="392px"></cc1:S_ComboBox></TD>
								</TR>
								<TR>
									<TD colSpan="4">
										<uc1:CodiceApparecchiature id="CodiceApparecchiature1" runat="server"></uc1:CodiceApparecchiature></TD>
								</TR>
								<TR>
									<TD colSpan="4">&nbsp;
										<P></P>
										<TABLE id="Table1" style="HEIGHT: 19px" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD style="WIDTH: 242px" align="right">
													<cc1:S_Button id="S_btMostra" runat="server" CssClass="btn" Width="134px" ToolTip="Avvia la ricerca"
														Text="Mostra Dettagli"></cc1:S_Button>&nbsp;</TD>
												<TD>&nbsp;
													<cc1:S_Button id="btReset" runat="server" CssClass="btn" Width="134px" Text="Reset"></cc1:S_Button></TD>
												<TD align="right"><A class="GuidaLink" href="<%= HelpLink %>" 
                  target="_blank">Guida</A></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</COLLAPSE:DATAPANEL>
					</TD>
				</TR>
				<TR vAlign="top">
					<TD vAlign="top">
						<uc1:GridTitle id="GridTitle1" runat="server"></uc1:GridTitle>
						<asp:DataGrid id="MyDataGrid1" runat="server" Width="100%" BorderColor="Gray" BorderStyle="None"
							BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False" CssClass="DataGrid"
							AllowPaging="True" GridLines="Vertical">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton ImageUrl="../Images/edit.gif" Runat="server" OnCommand="imageButton_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID") %>' ID="Imagebutton1">
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton ImageUrl="../Images/ChiaveInglese.gif" Runat="server" OnCommand="Richieste_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id_eq")+ "," + DataBinder.Eval(Container.DataItem,"id") %>' ID="Imagebutton2">
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<ASP:TEMPLATECOLUMN>
									<HEADERSTYLE width="30px"></HEADERSTYLE>
									<ITEMSTYLE horizontalalign="Center"></ITEMSTYLE>
									<ITEMTEMPLATE>
										<asp:ImageButton ImageUrl="../Images/attach.png" Runat="server" OnCommand="Documenti_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id_eq")+ "," + DataBinder.Eval(Container.DataItem,"id") %>' ID="Imagebutton3">
										</asp:ImageButton>
									</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
								<asp:BoundColumn DataField="bl_id" HeaderText="Cod.Edificio"></asp:BoundColumn>
								<asp:BoundColumn DataField="ID" HeaderText="Cod. Apparecchiatura"></asp:BoundColumn>
								<asp:BoundColumn DataField="DESCRIZIONE" HeaderText="Std. Apparecchiatura"></asp:BoundColumn>
								<asp:BoundColumn DataField="Servizio" HeaderText="Servizio"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="id_eq" HeaderText="ideq"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="date_dismiss" HeaderText="Dismessa"></asp:BoundColumn>
								<asp:BoundColumn DataField="PianoStanza" HeaderText="Piano/Stanza"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
					</TD>
				</TR>
			</TABLE>
		</form>
		</TD></TR></TBODY></TABLE><script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
