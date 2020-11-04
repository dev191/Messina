<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="UserStanze" Src="../WebControls/UserStanze.ascx" %>
<%@ Page language="c#" Codebehind="DataRoom.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.DataRoom" %>
<%@ Register TagPrefix="uc1" TagName="UserStanzeRic" Src="../WebControls/UserStanzeRic.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CodiceStdApparecchiatura" Src="../WebControls/CodiceStdApparecchiatura.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>NavigazioneApparechiature</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">

	function ClearStdApparechiature()
	{
		var ctrlstd=document.getElementById('<%=CodiceStdApparecchiatura1.s_CodiceStdApparecchiatura.ClientID%>');
		if(ctrlstd!=null && ctrlstd!='undefined')
		{
		  ctrlstd.value="";
		  document.getElementById('<%=CodiceStdApparecchiatura1.CodiceHidden.ClientID%>').value="";
		}
	}
	 function selezionedata(sender)
	 {
	   var ctrTextCodice=document.getElementById('<%=RicercaModulo1.TxtCodice.ClientID%>');
	   if(ctrTextCodice.value=="")
	   {
	     alert("Il Codice Edificio è obbligatorio");
	     return false;
	   }
	 
	    var ctrl=document.getElementById(sender);
		
	 }
		</SCRIPT>
	</HEAD>
	<BODY ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellspacing="0"
				cellpadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><UC1:PAGETITLE id="PageTitle1" runat="server"></UC1:PAGETITLE></TD>
				</TR>
				<TR>
					<TD valign="top" align="left">
						<COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" titlestyle-cssclass="TitleSearch" collapsed="False"
							titletext="Ricerca" expandtext="Espandi" expandimageurl="../Images/downarrows_trans.gif" collapsetext="Espandi/Riduci"
							cssclass="DataPanel75" collapseimageurl="../Images/uparrows_trans.gif" allowtitleexpandcollapse="True">
							<TABLE id="tblSearch100" cellSpacing="1" cellPadding="1" border="0">
								<TR>
									<TD vAlign="top" align="center" colSpan="2">
										<UC1:RICERCAMODULO id="RicercaModulo1" runat="server"></UC1:RICERCAMODULO></TD>
								</TR>
								<TR>
									<TD><SPAN><SPAN>Piano: </SPAN></SPAN>
									</TD>
									<TD>
										<CC1:S_COMBOBOX id="cmbsPiano" runat="server" dbdatatype="Integer" dbsize="10" dbindex="1" dbdirection="Input"
											width="392px"></CC1:S_COMBOBOX></TD>
								</TR>
								<TR>
									<TD colSpan="2"><SPAN>
											<uc1:UserStanzeRic id="UserStanze1" runat="server"></uc1:UserStanzeRic></SPAN></TD>
								</TR>
								<TR>
									<TD><SPAN>Servizio:</SPAN></TD>
									<TD>
										<CC1:S_COMBOBOX id="cmbsServizio" runat="server" width="392px" AutoPostBack="True"></CC1:S_COMBOBOX></TD>
								</TR>
								<TR>
									<TD><SPAN>Std. Apparecchiatura:</SPAN></TD>
									<TD>
										<CC1:S_COMBOBOX id="cmbsApparecchiatura" runat="server" width="392px"></CC1:S_COMBOBOX></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center" colSpan="2">
										<UC1:CODICEAPPARECCHIATURE id="CodiceApparecchiature1" runat="server"></UC1:CODICEAPPARECCHIATURE></TD>
								</TR>
								<TR>
									<TD colSpan="2">&nbsp;
										<UC1:CODICESTDAPPARECCHIATURA id="CodiceStdApparecchiatura1" runat="server" visible="False"></UC1:CODICESTDAPPARECCHIATURA>
										<P></P>
										<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD style="WIDTH: 219px" align="right">
													<CC1:S_BUTTON id="S_btMostra" runat="server" cssclass="btn" width="134px" text="Mostra Dettagli"
														tooltip="Avvia la ricerca"></CC1:S_BUTTON>&nbsp;</TD>
												<TD>&nbsp;
													<CC1:S_BUTTON id="btReset" runat="server" cssclass="btn" width="134px" text="Reset" CausesValidation="False"></CC1:S_BUTTON></TD>
												<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</COLLAPSE:DATAPANEL></TD>
				</TR>
				<TR valign="top">
					<TD valign="top"><UC1:GRIDTITLE id="GridTitle1" runat="server"></UC1:GRIDTITLE><ASP:DATAGRID id="MyDataGrid1" runat="server" cssclass="DataGrid" width="100%" gridlines="Vertical"
							allowpaging="True" autogeneratecolumns="False" cellpadding="4" backcolor="White" borderwidth="1px" borderstyle="None" bordercolor="Gray" AllowCustomPaging="True">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton id="Imagebutton1" title="Elenco Apparecchiature per Stanza" OnCommand="imagebutton1_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id_rm")+"&amp;bl_id=" + DataBinder.Eval(Container.DataItem,"id_bl")+"&amp;piani=" + DataBinder.Eval(Container.DataItem,"idpiani")+ "&amp;TitoloStanza=" +DataBinder.Eval(Container.DataItem,"Stanza")  %>' Runat="server" ImageUrl="../Images/Stanza.gif">
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="30px"></HeaderStyle>
									<ItemTemplate>
										<asp:ImageButton id="Imagebutton2" title="Elenco Apparecchiature per Piano" OnCommand="imagebutton2_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"idpiani")+"&amp;bl_id=" + DataBinder.Eval(Container.DataItem,"id_bl") + "&amp;TitoloPiano=" +DataBinder.Eval(Container.DataItem,"piano") %>' Runat="server" ImageUrl="../Images/Piano.gif">
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="bl_id" HeaderText="Cod.Edificio"></asp:BoundColumn>
								<asp:BoundColumn DataField="piano" HeaderText="Piano"></asp:BoundColumn>
								<asp:BoundColumn DataField="stanza" HeaderText="Stanza"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="id_bl"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="id_rm"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="idpiani"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="Black" BackColor="Silver" Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
			</TABLE>
		</FORM>
		</TD></TR></TBODY></TABLE>
	</BODY>
</HTML>
