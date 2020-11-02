<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Page language="c#" Codebehind="PmpS.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.PmpS" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditRuoli</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">	
		function SoloNumeri()
		{	
			if (event.keyCode < 48	|| event.keyCode > 57){
				event.keyCode = 0;
			}	
		}
		function nonpaste()
		{
			return false;
		}	
		
		</script>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" title="Passi per Procedura di Manutenzione Programmata" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" height="95%">
						<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" align="center">
							<TR>
								<TD style="WIDTH: 5%; HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" CssClass="TitleOperazione"></asp:label>&nbsp;<MESSPANEL:MESSAGEPANEL id="PanelMess" runat="server" ErrorIconUrl="~/Images/ico_critical.gif" MessageIconUrl="~/Images/ico_info.gif"></MESSPANEL:MESSAGEPANEL></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:datagrid id="DataGridDettaglio" runat="server" CssClass="DataGrid" PageSize="1" AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="des" HeaderText="Procedura di Manutenzione">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="servizio" HeaderText="Servizio">
												<HeaderStyle Width="14%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Standard" HeaderText="Standard Apparecchiatura">
												<HeaderStyle Width="26%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="specializ" HeaderText="Specializzazione">
												<HeaderStyle Width="18%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="fqdes" HeaderText="Frequenza">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="tempotot" HeaderText="Tempo Totale"></asp:BoundColumn>
										</Columns>
										<PagerStyle Visible="False"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left">&nbsp;&nbsp;&nbsp;
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left">
									<TABLE id="tblGridTitle" cellSpacing="1" cellPadding="1" border="0">
										<TR>
											<TD width="20%"><asp:linkbutton id="lkbNuovo" runat="server" CssClass="NuovoLink">Nuovo</asp:linkbutton></TD>
											<TD width="60%"></TD>
											<TD align="center" width="20%">Record:
												<asp:label id="lblRecord" runat="server">0</asp:label></TD>
										</TR>
									</TABLE>
									<asp:datagrid id="DataGridEsegui" runat="server" CssClass="DataGrid" AutoGenerateColumns="False"
										DataKeyField="PASSO" BorderColor="Gray" BorderWidth="1px" GridLines="Vertical">
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="imbEdit" runat="server" ImageUrl="../Images/edit.gif" CommandName="Edit"></asp:ImageButton>
													<asp:ImageButton id="imbDelete" runat="server" ImageUrl="../Images/elimina.gif" CommandName="Delete"
														CausesValidation="False"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
												<EditItemTemplate>
													<asp:ImageButton id="imbUpdate" runat="server" CommandName="Update" ImageUrl="../Images/salva.gif"></asp:ImageButton>
													<asp:ImageButton id="imbCancel" runat="server" CommandName="Cancel" ImageUrl="../Images/annulla.gif"></asp:ImageButton>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="1%"></HeaderStyle>
												<FooterStyle Wrap="False"></FooterStyle>
												<FooterTemplate>
													<asp:ImageButton id="Imagebutton1" runat="server" CommandName="Insert" ImageUrl="../Images/salva.gif"></asp:ImageButton>
													<asp:ImageButton id="Imagebutton2" runat="server" CommandName="Cancel" ImageUrl="../Images/annulla.gif"></asp:ImageButton>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Imagebutton3" runat="server" CommandName="Su" ImageUrl="../Images/up.gif"></asp:ImageButton>
													<asp:ImageButton id="Imagebutton4" runat="server" CommandName="Giu" ImageUrl="../Images/down.gif"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="PASSO" HeaderText="Passo"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Istruzioni">
												<HeaderStyle Width="87%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
												<ItemTemplate>
													<asp:Label id=lblIstruzioni runat="server" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem, "ISTRUZIONE") %>'>
													</asp:Label>
												</ItemTemplate>
												<FooterTemplate>
													<cc1:S_TextBox id="txts_IstruzioniNew" runat="server" Width="100%" Height="100%" TextMode="MultiLine"></cc1:S_TextBox>
												</FooterTemplate>
												<EditItemTemplate>
													<cc1:S_TextBox id=txts_IstruzioniEdit runat="server" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem, "ISTRUZIONE") %>' Height="100%" TextMode="MultiLine">
													</cc1:S_TextBox>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Tempo">
												<HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:Label id=lblTempo runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TEMPO") %>'>
													</asp:Label>
												</ItemTemplate>
												<FooterStyle HorizontalAlign="Center"></FooterStyle>
												<FooterTemplate>
													<cc1:S_TextBox id="txts_TempoNew" runat="server"></cc1:S_TextBox>
												</FooterTemplate>
												<EditItemTemplate>
													<cc1:S_TextBox id=txts_TempoEdit runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TEMPO") %>'>
													</cc1:S_TextBox>
												</EditItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="Label1" runat="server" Width="696px">Usare le freccie a lato delle istruzioni per cambiarne l'ordine di esecuzione.</asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblMessaggi" runat="server" CssClass="LabelErrore"></asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"><cc1:s_button id="btnsSalvaTutto" runat="server" Text="Salva Tutto" Enabled="False" CssClass="btn"></cc1:s_button><asp:button id="btnsAnnulla" tabIndex="25" runat="server" Text="Annulla" CausesValidation="False"
										CssClass="btn"></asp:button></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 1%" vAlign="top" align="left">
									<hr noShade SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblFirstAndLast" runat="server"></asp:label>&nbsp;
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
