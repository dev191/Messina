<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="Fondi.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.Fondi" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
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
								<TD style="HEIGHT: 25%" vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" TitleStyle-CssClass="TitleSearch" CssClass="DataPanel75"
										TitleText="Ricerca" AllowTitleExpandCollapse="True" Collapsed="False" ExpandText="Espandi" CollapseText="Riduci" CollapseImageUrl="../Images/up.gif"
										ExpandImageUrl="../Images/down.gif">
										<TABLE id="tblSearch100" cellSpacing="0" cellPadding="2" border="0">
											<TR>
												<TD style="WIDTH: 119px; HEIGHT: 8px" align="left" width="119" colSpan="1">Codice</TD>
												<TD style="WIDTH: 125px; HEIGHT: 8px" width="125" colSpan="1">
													<asp:TextBox id="txtCodiceFondo" runat="server"></asp:TextBox></TD>
												<TD style="WIDTH: 66px; HEIGHT: 8px" width="66"></TD>
												<TD style="WIDTH: 399px; HEIGHT: 8px" width="399"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 119px; HEIGHT: 24px" align="left" colSpan="1">Data Validità:</TD>
												<TD style="WIDTH: 125px; HEIGHT: 24px" colSpan="3">
													<TABLE id="Table3" style="WIDTH: 560px; HEIGHT: 59px" cellSpacing="1" cellPadding="1" width="560"
														border="0">
														<TR>
															<TD>Mese Inizio:</TD>
															<TD>
																<asp:DropDownList id="DrMeseini" runat="server"></asp:DropDownList></TD>
															<TD>Anno Inizio:</TD>
															<TD>
																<asp:DropDownList id="DrAnnoIni" runat="server"></asp:DropDownList></TD>
														</TR>
														<TR>
															<TD>Mese Fine:</TD>
															<TD>
																<asp:DropDownList id="DrMesefine" runat="server"></asp:DropDownList></TD>
															<TD>Anno Fine:</TD>
															<TD>
																<asp:DropDownList id="DrAnnofine" runat="server"></asp:DropDownList></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 214px" align="left" colSpan="2">
													<cc1:s_button id="btnsRicerca" runat="server" CssClass="btn" Text="Ricerca"></cc1:s_button>&nbsp;
													<cc1:S_Button id="BtnReset" tabIndex="4" runat="server" CssClass="btn" Text="Reset"></cc1:S_Button></TD>
												<TD style="WIDTH: 66px" align="right"></TD>
												<TD align="right"></TD>
												<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
											</TR>
										</TABLE>
									</COLLAPSE:DATAPANEL></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 3%" align="center"></TD>
							<TR>
								<TD style="HEIGHT: 72%" vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AllowPaging="True" AutoGenerateColumns="False"
										GridLines="Vertical" BorderWidth="1px" BorderColor="Gray">
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
											<asp:BoundColumn DataField="codicefondo" HeaderText="Codice Fondo"></asp:BoundColumn>
											<asp:BoundColumn DataField="meseini" HeaderText="Mese Inizio" DataFormatString="{0:d}"></asp:BoundColumn>
											<asp:BoundColumn DataField="annoini" HeaderText="Anno inizio" DataFormatString="{0:d}"></asp:BoundColumn>
											<asp:BoundColumn DataField="mesefine" HeaderText="Mese fine"></asp:BoundColumn>
											<asp:BoundColumn DataField="annofine" HeaderText="Anno Fine"></asp:BoundColumn>
											<asp:BoundColumn DataField="importo_netto" HeaderText="Importo Netto" DataFormatString="{0:N2}"></asp:BoundColumn>
											<asp:BoundColumn DataField="importo_lordo" HeaderText="Importo Lordo" DataFormatString="{0:N2}"></asp:BoundColumn>
											<asp:BoundColumn DataField="descrizione" HeaderText="Descrizione Fondo"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Periodo" HeaderText="Periodicit&#224;"></asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
