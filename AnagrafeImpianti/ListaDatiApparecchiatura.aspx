<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitleServer" Src="../WebControls/GridTitleServer.ascx" %>
<%@ Page language="c#" Codebehind="ListaDatiApparecchiatura.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.Apparecchiatura" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Apparecchiatura</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 16px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD><asp:panel id="PanelGriglia" runat="server">
							<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD style="HEIGHT: 26px">
										<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></TD>
								</TR>
								<TR>
									<TD>
										<HR width="100%" SIZE="1">
										<asp:Label id="lblDescrizioneApparecchiatura" runat="server"></asp:Label>
										<HR width="100%" SIZE="1">
									</TD>
								</TR>
								<TR>
									<TD>
										<uc1:GridTitleServer id="GridTitleServer1" runat="server"></uc1:GridTitleServer>
										<asp:datagrid id="DataGrid1" runat="server" Width="100%" AutoGenerateColumns="False" BorderStyle="Double"
											BorderWidth="3px" BackColor="White" CellPadding="4" GridLines="Horizontal" DataKeyField="eq_datitecnici_id">
											<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
											<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
											<FooterStyle ForeColor="#333333" BackColor="White"></FooterStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="id" HeaderText=" "></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="eq_id" HeaderText=" "></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="eqstd_id" HeaderText=" "></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="eqstdapparecchiatura_id" HeaderText=" "></asp:BoundColumn>
												<asp:BoundColumn DataField="tipologia" HeaderText="Dati Tecnici"></asp:BoundColumn>
												<asp:BoundColumn DataField="descrizione" HeaderText="Descrizione"></asp:BoundColumn>
												<asp:ButtonColumn Text="Modifica" ButtonType="PushButton" CommandName="Select">
													<ItemStyle Width="20px"></ItemStyle>
												</asp:ButtonColumn>
												<asp:ButtonColumn Text="Delete" ButtonType="PushButton" CommandName="Delete">
													<ItemStyle Width="20px"></ItemStyle>
												</asp:ButtonColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</TABLE>
						</asp:panel></TD>
				</TR>
				<TR>
					<TD><asp:panel id="PanelDatoTecnico" runat="server" Visible="False">
							<TABLE class="tblSearch100Dettaglio" id="Table2" cellSpacing="0" cellPadding="0" width="100%"
								border="0">
								<TR>
									<TD class="FormLabel" align="center" width="15%" colSpan="2">Descrizione dei dati 
										Tecnici</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 24px" width="16%">Tipologia Tecnica:</TD>
									<TD style="HEIGHT: 24px">
										<cc1:S_ComboBox id="S_Cbtipologia" runat="server" Width="384px"></cc1:S_ComboBox>
										<asp:RequiredFieldValidator id="rfvProductName" runat="server" ErrorMessage="Selezionare una Tipologia Tecnica"
											Display="Dynamic" ControlToValidate="S_Cbtipologia">*</asp:RequiredFieldValidator></TD>
								</TR>
								<TR>
									<TD>Descrizione:</TD>
									<TD>
										<asp:TextBox id="txtDescrizione" runat="server" Width="384px"></asp:TextBox>
										<asp:RequiredFieldValidator id="rfvQtyUnit" runat="server" ErrorMessage="Inserire la descrizione" Display="Dynamic"
											ControlToValidate="txtDescrizione">*</asp:RequiredFieldValidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;</TD>
									<TD>
										<asp:Button id="btnSalva" Width="136px" Visible="true" CssClass="btn" Text="Salva" Runat="server"></asp:Button></TD>
								</TR>
							</TABLE>
							<HR width="100%" SIZE="1">
							<TABLE class="tblSearch100Dettaglio" id="Table4" cellSpacing="0" cellPadding="0" width="100%"
								border="0">
								<TR>
									<TD width="16%">
										<uc1:GridTitleServer id="GridTitleServer2" runat="server"></uc1:GridTitleServer></TD>
								</TR>
							</TABLE>
							<HR width="100%" SIZE="1">
						</asp:panel>
						<asp:ValidationSummary id="ValidationSummary1" runat="server" Width="168px" Height="43px" ShowMessageBox="True"
							ShowSummary="False"></asp:ValidationSummary></TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
