<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="DatiTecnici.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.DatiTecnici" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DatiTecnici</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="PanelNuovoDatoTecnico" style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 240px"
				runat="server"></asp:panel>
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="tblSearch100Dettaglio" id="Table3" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD style="HEIGHT: 31px" align="center" colSpan="2"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 22px" width="16%">Tipo di Apparecchiatura:</TD>
								<TD style="HEIGHT: 22px"><cc1:s_combobox id="cmbsApparecchiatura" runat="server" Height="24px" AutoPostBack="True" Width="384px"></cc1:s_combobox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Richiesto!" Display="Dynamic"
										ControlToValidate="cmbsApparecchiatura"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD width="16%">Descrizione della Tiologia:</TD>
								<TD><asp:textbox id="txtDescrizioneTipologia" runat="server" Width="384px"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Richiesto!" Display="Dynamic"
										ControlToValidate="txtDescrizioneTipologia"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 160px">&nbsp;
									<asp:button id="btNuovo" Width="136px" Text="Nuova Tipologia" Runat="server" CssClass="btn"></asp:button></TD>
								<TD><asp:button id="btsalvaTipologia" Width="136px" Text="Salva" Runat="server" CssClass="btn"></asp:button>&nbsp;
									<asp:button id="btRitorna" Width="200px" Text="Ritorna alla Descrizione Tecnica " Runat="server"
										CausesValidation="False" CssClass="btn"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<HR width="100%" SIZE="1">
					</TD>
				</TR>
				<TR>
					<TD><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGrid1" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyField="id">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<ItemStyle ForeColor="DimGray" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="Black" BackColor="Silver"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Modifica" ButtonType="PushButton" CommandName="Select" ItemStyle-Width="100px"
									ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px"
									HeaderText="Aggiorna la Descrizione" />
								<asp:BoundColumn Visible="False" DataField="ID" HeaderText="id"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="EQSTD_ID" HeaderText="EQSTD_ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="DESCRIZIONE" HeaderText="Descrizione"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
