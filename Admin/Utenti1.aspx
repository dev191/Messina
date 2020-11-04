<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Page language="c#" Codebehind="Utenti1.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Admin.Utenti1" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Utenti</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Css/MainSheet.css">
	</HEAD>
	<body bottomMargin="0" leftMargin="5" rightMargin="0" onbeforeunload="parent.left.valorizza()"
		topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; POSITION: absolute; TOP: 0px; LEFT: 0px" id="TableMain" border="0"
				cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD height="95%" vAlign="top" align="center">
						<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
							<TR>
								<TD style="HEIGHT: 25%" vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" ExpandImageUrl="../Images/down.gif" CollapseImageUrl="../Images/up.gif"
										CollapseText="Riduci" ExpandText="Espandi" Collapsed="False" AllowTitleExpandCollapse="True" TitleText="Ricerca" CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch">
										<TABLE id="tblSearch100" border="0" cellSpacing="0" cellPadding="2">
											<TR>
												<TD width="20%" align="right">Utente</TD>
												<TD width="30%">
													<cc1:s_textbox id="txtsUserName" tabIndex="1" runat="server" dbdatatype="Varchar" dbindex="0" DBSize="50"
														width="75%" DBDirection="Input" DBParameterName="p_UserName"></cc1:s_textbox></TD>
												<TD width="20%" align="right">Progetto</TD>
												<TD width="30%">
													<CC1:S_COMBOBOX id="CmbProgetto" tabIndex="1" runat="server" dbdatatype="Integer" dbindex="1" dbparametername="p_progetto"
														dbdirection="Input" dbsize="3"></CC1:S_COMBOBOX></TD>
											</TR>
											<TR>
												<TD align="right">Cognome</TD>
												<TD>
													<cc1:s_textbox id="txtsCognome" tabIndex="2" runat="server" DBSize="50" width="75%" DBParameterName="p_Cognome"
														DBIndex="2"></cc1:s_textbox></TD>
												<TD align="right">Ruolo</TD>
												<TD>
													<CC1:S_COMBOBOX id="CmbRuolo" tabIndex="3" runat="server" dbdatatype="Integer" dbparametername="p_ruolo"
														dbdirection="Input" dbsize="3" DBIndex="3"></CC1:S_COMBOBOX></TD>
											</TR>
											<TR>
												<TD colSpan="3" align="left">
													<cc1:s_button id="btnsRicerca" runat="server" CssClass="btn" Text="Ricerca"></cc1:s_button>&nbsp;
													<INPUT class="btn" value="Reset" type="reset"></TD>
												<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
											</TR>
										</TABLE>
									</COLLAPSE:DATAPANEL></TD>
							</TR>
							<tr>
								<TD style="HEIGHT: 3%" align="center"></TD>
							</tr>
							<TR>
								<TD style="HEIGHT: 72%" vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" BorderColor="Gray" BorderWidth="1px"
										GridLines="Vertical" AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:HyperLink ImageUrl="~/images/edit.gif" NavigateUrl='<%# "EditUtenti.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId%>' runat="server" ID="Hyperlink1"/>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="USERNAME" HeaderText="Utente">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="COGNOME" HeaderText="Cognome">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="nome" HeaderText="Nome">
												<HeaderStyle Width="20px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Ruolo" HeaderText="Ruolo">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Progetto" HeaderText="Progetto">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
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
