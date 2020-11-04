<%@ Register TagPrefix="uc1" TagName="UserPmp" Src="../WebControls/UserPmp.ascx" %>
<%@ Page language="c#" Codebehind="ProcedurePassi.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.ProcedurePassi" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprovaRdl</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<script language="javascript">
		
			function Pulisci(des,cod,codnum)
			{
				document.getElementById(des).value="";
				document.getElementById(cod).value="";						
				document.getElementById(codnum).value="0";										
			}
			
			function SvuotaCombo(cmb)
			{
				var Elementi = document.getElementById(cmb).options.length - 1;
				while (Elementi > -1)
				{
					document.getElementById(cmb).remove(Elementi);	
					Elementi--;
				}
			}		
		
		</script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" title="Procedure e Passi" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
								<TBODY>
									<TR>
										<TD vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" TitleStyle-CssClass="TitleSearch" CssClass="DataPanel75"
												ExpandImageUrl="../Images/down.gif" CollapseImageUrl="../Images/up.gif" CollapseText="Riduci" ExpandText="Espandi" Collapsed="False"
												AllowTitleExpandCollapse="True" TitleText="Ricerca">
												<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" border="0">
													<TBODY>
														<TR>
															<TD style="WIDTH: 171px" align="left" width="171">Servizio:</TD>
															<TD style="WIDTH: 190px" width="190"><cc1:s_combobox id="cmbsServizio" runat="server" AutoPostBack="True" Width="528px" DBDirection="Input"
																	DBDataType="Integer" DBParameterName="p_ID_Servizio" DBSize="10"></cc1:s_combobox></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 171px; HEIGHT: 16px" align="left">Standard Apparecchiatura:</TD>
															<TD style="WIDTH: 190px; HEIGHT: 16px"><cc1:s_combobox id="cmdsStdApparecchiatura" runat="server" Width="528px" DBDirection="Input" DBDataType="Integer"
																	DBParameterName="p_eqstd_id" DBSize="10" DBIndex="1" AutoPostBack="True"></cc1:s_combobox></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 171px" align="left" colSpan="1">Attività:
															</TD>
															<TD style="WIDTH: 118px" align="left" colSpan="3"><uc1:userpmp id="UserPmp1" runat="server"></uc1:userpmp></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 171px" align="left">Specializzazione Addetto:</TD></TD>
										<TD style="WIDTH: 190px"><cc1:s_combobox id="cmbsSpecializzazione" runat="server" Width="528px" DBDirection="Input" DBDataType="Integer"
												DBParameterName="p_eqstd_id" DBSize="10" DBIndex="1"></cc1:s_combobox></TD>
									</TR>
									<TR>
										<TD align="left" colSpan="4"></TD>
									</TR>
									<TR>
										<TD align="left" colSpan="3"><cc1:s_button id="btnsRicerca" tabIndex="2" runat="server" Text="Ricerca" CssClass="btn"></cc1:s_button>&nbsp;
											<asp:Button id="cmdReset" Text="Reset" Runat="server" CssClass="btn"></asp:Button></TD>
										<TD align="right"><A class=GuidaLink 
                  href="<%= HelpLink %>" target=_blank 
                  >Guida</A></TD>
									</TR>
								</TBODY>
							</TABLE>
							</COLLAPSE:DATAPANEL></TD>
					</TR>
					<tr vAlign="top">
						<TD align="center"></TD>
					</tr>
					<TR vAlign="top">
						<TD vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" BorderColor="Gray" GridLines="Vertical"
								AutoGenerateColumns="False" BorderWidth="1px" AllowPaging="True" AllowCustomPaging="True">
								<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
								<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="3%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
										<ItemTemplate>
											<asp:HyperLink id=Hyperlink1 runat="server" NavigateUrl='<%# "DettProcedurePassi.aspx?pmp=" + DataBinder.Eval(Container.DataItem,"ID") + "&amp;pmp_id=" + DataBinder.Eval(Container.DataItem,"Attivita")+ "&descserv=" + DataBinder.Eval(Container.DataItem,"servizio")+ "&std=" + DataBinder.Eval(Container.DataItem,"description")%>' ImageUrl="~/images/edit.gif">
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="Servizio" HeaderText="Servizio"></asp:BoundColumn>
									<asp:BoundColumn DataField="Std. Apparecchiatura" HeaderText="Std. Apparecchiatura"></asp:BoundColumn>
									<asp:BoundColumn DataField="Attivita" HeaderText="Attivit&#224;"></asp:BoundColumn>
									<asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
									<asp:BoundColumn DataField="Frequenza" HeaderText="Frequenza"></asp:BoundColumn>
									<asp:BoundColumn DataField="Specializzazione Addetto" HeaderText="Specializzazione Addetto"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</TBODY>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
