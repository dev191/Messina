<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="PmpIntervalli.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.PmpIntervalli" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>GestioneMateriali</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
		function  controllaPeriodo(m11,m12,m22,m21)
		{
			mese_1_1 = m11.value;
			mese_1_2 = m12.value;
			mese_2_1 = m21.value;
			mese_2_2 = m22.value;
						
			if (mese_1_1>mese_1_2)
			{
				alert("Il primo periodo è incongruente.");
				return false;
			}
			
				
			if (mese_2_1>mese_2_2)
			{
				alert("Il secondo periodo è incongruente.");
				return false;
			}
				
		}
		</SCRIPT>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" ms_positioning="GridLayout">
		<FORM id="Form1" name="materiali" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="center"><UC1:PAGETITLE id="PageTitle1" runat="server"></UC1:PAGETITLE></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="tblGridTitle" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD width="20%"><ASP:LINKBUTTON id="lkbNuovo" runat="server" cssclass="NuovoLink" causesvalidation="False">Nuovo</ASP:LINKBUTTON></TD>
								<TD width="60%"></TD>
								<TD align="right" width="20%">Record:
									<ASP:LABEL id="lblRecord" runat="server">0</ASP:LABEL>&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						<ASP:DATAGRID id="DataGridRicerca" runat="server" cssclass="DataGrid" datakeyfield="ID" bordercolor="Gray"
							borderwidth="1px" gridlines="Vertical" autogeneratecolumns="False">
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
									<ItemTemplate>
										<ASP:IMAGEBUTTON id="imbEdit" runat="server" commandname="Edit" imageurl="../Images/edit.gif" borderstyle="None"></ASP:IMAGEBUTTON>
										<ASP:IMAGEBUTTON id="imbDelete" runat="server" commandname="Delete" imageurl="../Images/elimina.gif"
											borderstyle="None"></ASP:IMAGEBUTTON>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="0%"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
									<EditItemTemplate>
										<ASP:IMAGEBUTTON id="imbCancel" runat="server" commandname="Cancel" imageurl="../Images/annulla.gif"
											borderstyle="None"></ASP:IMAGEBUTTON>
										<ASP:IMAGEBUTTON id="imbUpdate" runat="server" commandname="Update" imageurl="../Images/salva.gif"
											borderstyle="None"></ASP:IMAGEBUTTON>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="0%"></HeaderStyle>
									<FooterStyle Wrap="False"></FooterStyle>
									<FooterTemplate>
										<ASP:IMAGEBUTTON id="Imagebutton2" runat="server" commandname="Cancel" imageurl="../Images/annulla.gif"
											borderstyle="None"></ASP:IMAGEBUTTON>
										<ASP:IMAGEBUTTON id="Imagebutton1" runat="server" commandname="Insert" imageurl="../Images/salva.gif"
											borderstyle="None"></ASP:IMAGEBUTTON>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Servizio">
									<HeaderStyle Width="52%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<asp:Label id=lblDescrizioneServ runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DESCRIZIONE") %>'>
										</asp:Label>
									</ItemTemplate>
									<FooterTemplate>
										<cc1:S_ComboBox id=CmbServizioInsert runat="server" DataValueField="ID" DataTextField="DESCRIZIONE" DataSource="<%# GetServizi() %>">
										</cc1:S_ComboBox>
									</FooterTemplate>
									<EditItemTemplate>
										<cc1:S_ComboBox id=CmbServizioEdit runat="server" DataValueField="ID" DataTextField="DESCRIZIONE" DataSource="<%# GetServizi() %>" selectedindex='<%# GetIndexServ(DataBinder.Eval(Container.DataItem, "DESCRIZIONE").ToString()) %>'>
										</cc1:S_ComboBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Intervallo1_1">
									<ItemTemplate>
										<asp:Label id=lblDescrizioneInt1_1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "interval_1_1") %>'>
										</asp:Label>
									</ItemTemplate>
									<FooterTemplate>
										<cc1:S_ComboBox id=CmbInt1_1Insert runat="server" DataValueField="ID" DataTextField="DESCRIZIONE" DataSource="<%# GetMesi() %>" >
										</cc1:S_ComboBox>
									</FooterTemplate>
									<EditItemTemplate>
										<cc1:S_ComboBox id=CmbInt1_1Edit runat="server" DataValueField="ID" DataTextField="DESCRIZIONE" DataSource="<%# GetMesi() %>" selectedindex='<%# GetIndex(DataBinder.Eval(Container.DataItem, "interval_1_1").ToString()) %>'>
										</cc1:S_ComboBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Intervallo1_2">
									<ItemTemplate>
										<asp:Label id=lblDescrizioneInt1_2 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "interval_1_2") %>'>
										</asp:Label>
									</ItemTemplate>
									<FooterTemplate>
										<cc1:S_ComboBox id=CmbInt1_2Insert runat="server" DataValueField="ID" DataTextField="DESCRIZIONE" DataSource="<%# GetMesi() %>" >
										</cc1:S_ComboBox>
									</FooterTemplate>
									<EditItemTemplate>
										<cc1:S_ComboBox id=CmbInt1_2Edit runat="server" DataValueField="ID" DataTextField="DESCRIZIONE" DataSource="<%# GetMesi() %>" selectedindex='<%# GetIndex(DataBinder.Eval(Container.DataItem, "interval_1_2").ToString()) %>'>
										</cc1:S_ComboBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Intervallo2_1">
									<ItemTemplate>
										<asp:Label id=lblDescrizioneInt2_1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "interval_2_1") %>'>
										</asp:Label>
									</ItemTemplate>
									<FooterTemplate>
										<cc1:S_ComboBox id=CmbInt2_1Insert runat="server" DataValueField="ID" DataTextField="DESCRIZIONE" DataSource="<%# GetMesi() %>" >
										</cc1:S_ComboBox>
									</FooterTemplate>
									<EditItemTemplate>
										<cc1:S_ComboBox id=CmbInt2_1Edit runat="server" DataValueField="ID" DataTextField="DESCRIZIONE" DataSource="<%# GetMesi() %>" selectedindex='<%# GetIndex(DataBinder.Eval(Container.DataItem, "interval_2_1").ToString()) %>'>
										</cc1:S_ComboBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Intervallo2_2">
									<ItemTemplate>
										<asp:Label id=lblDescrizioneInt2_2 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "interval_2_2") %>'>
										</asp:Label>
									</ItemTemplate>
									<FooterTemplate>
										<cc1:S_ComboBox id=CmbInt2_2Insert runat="server" DataValueField="ID" DataTextField="DESCRIZIONE" DataSource="<%# GetMesi() %>" >
										</cc1:S_ComboBox>
									</FooterTemplate>
									<EditItemTemplate>
										<cc1:S_ComboBox id=CmbInt2_2Edit runat="server" DataValueField="ID" DataTextField="DESCRIZIONE" DataSource="<%# GetMesi() %>" selectedindex='<%# GetIndex(DataBinder.Eval(Container.DataItem, "interval_2_2").ToString()) %>'>
										</cc1:S_ComboBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</ASP:DATAGRID></TD>
				</TR>
			</TABLE>
		</FORM>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
