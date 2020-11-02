<%@ Control Language="c#" AutoEventWireup="false" Codebehind="RicercaAnagrafica.ascx.cs" Inherits="TheSite.Gestione.RicercaAnagrafica1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
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
									<TD style="HEIGHT: 27px" align="left" width="20%">Descrizione</TD>
									<TD style="HEIGHT: 27px" width="30%">
										<cc1:s_textbox id="txtsDescrizione" runat="server" DBParameterName="p_DESCRIZIONE" DBDirection="Input"
											width="208px" DBSize="255"></cc1:s_textbox></TD>
									<TD style="HEIGHT: 27px" align="left" width="20%">Note</TD>
									<TD style="HEIGHT: 27px" width="30%">
										<cc1:s_textbox id="txtsNote" tabIndex="2" runat="server" DBParameterName="p_note" DBDirection="Input"
											width="208px" DBSize="500" DBIndex="2"></cc1:s_textbox></TD>
								</TR>
								<TR>
									<TD align="left" width="20%"><%=Codice%></TD>
									<TD width="30%">
										<cc1:S_TextBox id="txtsCodice" runat="server" DBParameterName="p_codice" DBDirection="Input" DBSize="5"
											DBIndex="2"></cc1:S_TextBox></TD>
									<TD align="right" width="20%"></TD>
									<TD width="30%"></TD>
								</TR>
								<TR>
									<TD align="left" colSpan="3">
										<cc1:s_button id="btnsRicerca" runat="server" CssClass="btn" Text="Ricerca"></cc1:s_button>&nbsp;
										<CC1:S_BUTTON id="btnReset" tabIndex="4" runat="server" cssclass="btn" text="Reset"></CC1:S_BUTTON></TD>
									<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A>
									</TD>
								</TR>
							</TABLE>
						</COLLAPSE:DATAPANEL></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 3%" align="center"></TD>
				<TR>
					<TD style="HEIGHT: 72%" vAlign="top" align="center">
						<uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AutoGenerateColumns="False"
							GridLines="Vertical" BorderWidth="1px" BorderColor="Gray">
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="1%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton id=Imagebutton1 OnCommand="imageButton_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID") %>' Runat="server" ImageUrl="~/images/Search16x16_bianca.jpg">
										</asp:ImageButton>
										<!--<asp:ImageButton id="Imagebutton3" OnCommand="imageButton_Click" CommandArgument='<%# "EditAnagrafica.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&amp;FunId=" + FunId + "&amp;TipoOper=read&amp;Pagina="+s_pagdir%>' Runat="server" ImageUrl="~/images/Search16x16_bianca.jpg">
										</asp:ImageButton>-->
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="1%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton id=Imagebutton2 OnCommand="imageButton_Click1" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID")%>' Runat="server" ImageUrl="~/images/edit.gif" CommandName="Delete">
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="descrizione" HeaderText="Descrizione">
									<HeaderStyle Width="35%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="codice" HeaderText="Codice">
									<HeaderStyle Width="25%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="note" HeaderText="Note">
									<HeaderStyle Width="40%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
