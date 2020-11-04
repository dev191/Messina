<%@ Page language="c#" Codebehind="DettProcedurePassi.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.DettProcedurePassi" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Procedure e Passi</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
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
										<TD vAlign="top" align="left"><asp:label id="lblpmp" CssClass="TitleOperazione" Runat="server"></asp:label></TD>
									</TR>
									<tr vAlign="top">
										<TD align="center"></TD>
									</tr>
									<TR vAlign="top">
										<TD vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" BorderColor="Gray" GridLines="Vertical"
												AutoGenerateColumns="False" BorderWidth="1px" EnableViewState="False">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
													<asp:BoundColumn DataField="PASSO" HeaderText="Codice Passo">
														<ItemStyle Height="20px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="ISTRUZIONE" HeaderText="ISTRUZIONI"></asp:BoundColumn>
												</Columns>
											</asp:datagrid></TD>
									</TR>
									<tr>
										<td><input type="button" id="cmdBack" value="Indietro" onclick="javascript:history.back()"
												class="btn"></td>
									</tr>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
