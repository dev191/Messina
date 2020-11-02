<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="Fondi.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.Fondi" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Fondi</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
	function Pulisci()
	{
		document.getElementById("cmbsAnno").selectedvalue=""
		document.getElementById("cmbsTipoIntervento").selectedvalue=""			
	}
	
		</script>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" height="95%">
						<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
							<TR>
								<TD style="HEIGHT: 25%" vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" ExpandImageUrl="../Images/down.gif" CollapseImageUrl="../Images/up.gif"
										CollapseText="Riduci" ExpandText="Espandi" Collapsed="False" AllowTitleExpandCollapse="True" TitleText="Ricerca" CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch">
										<TABLE id="tblSearch100" cellSpacing="0" cellPadding="2" border="0">
											<TR>
												<TD style="WIDTH: 119px; HEIGHT: 8px" align="left" width="119" colSpan="1">Anno</TD>
												<TD style="WIDTH: 399px; HEIGHT: 8px" width="399" colSpan="1">
													<cc1:S_ComboBox id="cmbsAnno" runat="server" DBParameterName="p_anno" DBDirection="Input" DBIndex="1"
														Width="200px" DBDataType="Integer"></cc1:S_ComboBox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 119px; HEIGHT: 24px" align="left" colSpan="1">Tipo Intervento</TD>
												<TD style="WIDTH: 399px; HEIGHT: 24px" colSpan="1">
													<cc1:S_ComboBox id="cmbsTipoIntervento" runat="server" DBParameterName="p_TipoIntervento" DBDirection="Input"
														DBIndex="2" Width="200px" DBDataType="Integer"></cc1:S_ComboBox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 522px" align="left" colSpan="2">
													<cc1:s_button id="btnsRicerca" runat="server" CssClass="btn" Text="Ricerca"></cc1:s_button>&nbsp;
													<cc1:S_Button id="BtnReset" tabIndex="4" runat="server" CssClass="btn" Text="Reset"></cc1:S_Button></TD>
												<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
											</TR>
										</TABLE>
									</COLLAPSE:DATAPANEL></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 3%" align="center"></TD>
							<TR>
								<TD style="HEIGHT: 72%" vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" BorderColor="Gray" BorderWidth="1px"
										GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True">
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="id" HeaderText="ID"></asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Imagebutton3" Runat=server CommandName="Dettaglio" ImageUrl="~/images/Search16x16_bianca.jpg" CommandArgument='<%# "EditFondi.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId + "&TipoOper=read"%>'>
													</asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Imagebutton2" Runat=server CommandName="Dettaglio" ImageUrl="~/images/edit.gif" CommandArgument='<%# "EditFondi.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId + "&TipoOper=write"%>'>
													</asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Anno" HeaderText="Anno"></asp:BoundColumn>
											<asp:BoundColumn DataField="descrizione_breve" HeaderText="Tipo Intervento"></asp:BoundColumn>
											<asp:BoundColumn DataField="importo_netto" HeaderText="Importo Netto" DataFormatString="{0:N2}"></asp:BoundColumn>
											<asp:BoundColumn DataField="importo_lordo" HeaderText="Importo Lordo" DataFormatString="{0:N2}"></asp:BoundColumn>
											<asp:BoundColumn DataField="descrizione" HeaderText="Descrizione Fondo"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="descrizionestesa" HeaderText="DescrizioneEstesa"></asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
