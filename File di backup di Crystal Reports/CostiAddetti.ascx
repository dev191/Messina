<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CostiAddetti.ascx.cs" Inherits="TheSite.WebControls.CostiAddetti" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
<TABLE class="tblSearch100Dettaglio" id="tblModulo" style="HEIGHT: 70px" cellspacing="1"
	cellpadding="1" width="100%" border="0">
	<TR>
		<TD colspan="4"><B>Costi Addetti</B></TD>
	</TR>
	<TR>
		<TD align="left"><ASP:LINKBUTTON id="lkbNuovo" runat="server">Nuovo</ASP:LINKBUTTON></TD>
		<TD></TD>
		<TD align="left">RecordPP:
			<ASP:LABEL id="lblRecord" runat="server">0</ASP:LABEL></TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 2.98%" valign="top" align="left">&nbsp;</TD>
		<TD valign="top" align="left">&nbsp;
			<ASP:DATAGRID id="DataGridEsegui" datakeyfield="wr_id" bordercolor="Gray" borderwidth="1px" gridlines="Vertical"
				autogeneratecolumns="False" cssclass="DataGrid" runat="server">
				<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
				<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
				<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="wr_id" HeaderText="wr_id">
						<HeaderStyle Width="1%"></HeaderStyle>
					</asp:BoundColumn>
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
						<HeaderStyle Width="2%"></HeaderStyle>
						<ItemStyle Wrap="False"></ItemStyle>
						<EditItemTemplate>
							<ASP:IMAGEBUTTON id="imbUpdate" runat="server" commandname="Update" imageurl="../Images/salva.gif"
								borderstyle="None"></ASP:IMAGEBUTTON>
							<ASP:IMAGEBUTTON id="imbCancel" runat="server" commandname="Cancel" imageurl="../Images/annulla.gif"
								borderstyle="None"></ASP:IMAGEBUTTON>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="2%"></HeaderStyle>
						<FooterStyle Wrap="False"></FooterStyle>
						<FooterTemplate>
							<ASP:IMAGEBUTTON id="Imagebutton1" runat="server" borderstyle="None" imageurl="../Images/salva.gif"
								commandname="Insert"></ASP:IMAGEBUTTON>
							<ASP:IMAGEBUTTON id="Imagebutton2" runat="server" borderstyle="None" imageurl="../Images/annulla.gif"
								commandname="Cancel"></ASP:IMAGEBUTTON>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Addetto">
						<HeaderStyle Width="30px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
						<ItemTemplate>
							<asp:Label id="lblAddetto" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "nominativo") %>'>
							</asp:Label>
						</ItemTemplate>
						<FooterTemplate>
							<cc1:S_ComboBox id="cmbaddettoNew" runat="server" Width="264px" DataValueField="tutto" DataTextField="nominativo" DataSource="<%# GetAddetti() %>" BParameterName="@p_pianostanza" DBDataType="Integer" DBDirection="Input" DBIndex="1">
							</cc1:S_ComboBox>
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Descrizione">
						<HeaderStyle Width="20px"></HeaderStyle>
						<ItemTemplate>
							<asp:Label id="lbldescrizione" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Descrizione_Intervento") %>'>
							</asp:Label>
						</ItemTemplate>
						<FooterTemplate>
							<CC1:S_TEXTBOX id="txtdescrizioneNew" tabindex="3" runat="server" width="60px" dbdirection="Input"
								maxlength="8" dbsize="8" dbparametername="@Stanza"></CC1:S_TEXTBOX>
						</FooterTemplate>
						<EditItemTemplate>
							<CC1:S_TEXTBOX id="txtdescrizione" tabIndex="3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Descrizione_Intervento") %>' Width="60px" DBDirection="Input" MaxLength="8" DBSize="8" DBParameterName="@Stanza">
							</CC1:S_TEXTBOX>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Livello">
						<HeaderStyle Width="50%"></HeaderStyle>
						<ItemTemplate>
							<asp:Label id="lbllivello" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "codicelivello") %>'>
							</asp:Label>
						</ItemTemplate>
						<FooterTemplate>
							<CC1:S_LABEL id="lbllivelloNew" runat="server"></CC1:S_LABEL>
						</FooterTemplate>
						<EditItemTemplate>
							<asp:Label id="lbllivello1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "codicelivello") %>'>
							</asp:Label>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Prezzo Unitario">
						<ItemTemplate>
							<asp:Label id=lblPrezzoUnitario runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "prezzo_unitario") %>'>
							</asp:Label>
						</ItemTemplate>
						<FooterTemplate>
							<CC1:S_LABEL id="lblPrezzoUnitatioNew" runat="server"></CC1:S_LABEL>
						</FooterTemplate>
						<EditItemTemplate>
							<asp:Label id=lblPrezzoUnitatio1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "prezzo_unitario") %>'>
							</asp:Label>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Ore Lavorate">
						<ItemTemplate>
							<asp:Label id="lblOreLavorate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ore") %>'>
							</asp:Label>
						</ItemTemplate>
						<FooterTemplate>
							<CC1:S_TEXTBOX id="txtOreLavorateNew" tabIndex="3" runat="server" Width="60px" Text='<%# DataBinder.Eval(Container.DataItem, "Descrizione_Intervento") %>' DBDirection="Input" DBParameterName="@Stanza" DBSize="8" MaxLength="8">
							</CC1:S_TEXTBOX>
						</FooterTemplate>
						<EditItemTemplate>
							<CC1:S_TEXTBOX id="txtOrelavorate" tabIndex="3" runat="server" Width="60px" Text='<%# DataBinder.Eval(Container.DataItem, "Descrizione_Intervento") %>' DBDirection="Input" DBParameterName="@Stanza" DBSize="8" MaxLength="8">
							</CC1:S_TEXTBOX>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Totale">
						<ItemTemplate>
							<asp:Label id=lblTotale runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "totale") %>'>
							</asp:Label>
						</ItemTemplate>
						<FooterTemplate>
							<CC1:S_TEXTBOX id="txtTotaleNew" tabIndex="3" runat="server" width="60px" dbdirection="Input" maxlength="8"
								dbsize="8" dbparametername="@Stanza"></CC1:S_TEXTBOX>
						</FooterTemplate>
						<EditItemTemplate>
							<asp:Label id=lblTotaleNew runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "totale") %>'>
							</asp:Label>
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</ASP:DATAGRID></TD>
	</TR>
</TABLE>
</ASP:PANEL></TD></TR>
<SCRIPT language="javascript">
function addetto(cmbaddettoNew,lbllivelloNew,lblPrezzoUnitatioNew)
{
	var ctrl=document.getElementById(cmbaddettoNew);
	var ctrl1=document.getElementById(lbllivelloNew);
	var ctrl2=document.getElementById(lblPrezzoUnitatioNew);
	var	selezione = ctrl.options[ctrl.selectedIndex].value;
	var arr_sel = new Array();
	arr_sel = selezione.split(";");
	ctrl.options[ctrl.selectedIndex].value=arr_sel[0];
	ctrl1.innerText=arr_sel[2];	
	alert(ctrl1.innerText);
	ctrl2.innerText=arr_sel[3];
}
</SCRIPT>
