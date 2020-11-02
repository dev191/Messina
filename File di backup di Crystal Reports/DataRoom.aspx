<%@ Register TagPrefix="uc1" TagName="CodiceStdApparecchiatura" Src="../WebControls/CodiceStdApparecchiatura.ascx" %>
<%@ Page language="c#" Codebehind="DataRoom.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.DataRoom" %>
<%@ Register TagPrefix="uc1" TagName="UserStanze" Src="../WebControls/UserStanze.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
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
							<TABLE id="tblSearch100" cellspacing="1" cellpadding="1" border="0">
								<TR>
									<TD valign="top" align="center" colspan="2">
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
									<TD colspan="2"><SPAN>
											<UC1:USERSTANZE id="UserStanze1" runat="server"></UC1:USERSTANZE></SPAN></TD>
								</TR>
								<TR>
									<TD><SPAN>Servizio:</SPAN></TD>
									<TD>
										<CC1:S_COMBOBOX id="cmbsServizio" runat="server" width="392px"></CC1:S_COMBOBOX></TD>
								</TR>
								<TR>
									<TD><SPAN>Std. Apparecchiatura:</SPAN></TD>
									<TD>
										<CC1:S_COMBOBOX id="cmbsApparecchiatura" runat="server" width="392px"></CC1:S_COMBOBOX></TD>
								</TR>
								<TR>
									<TD valign="top" align="center" colspan="2">
										<UC1:CODICEAPPARECCHIATURE id="CodiceApparecchiature1" runat="server"></UC1:CODICEAPPARECCHIATURE></TD>
								</TR>
								<TR>
									<TD colspan="2">&nbsp;
										<UC1:CODICESTDAPPARECCHIATURA id="CodiceStdApparecchiatura1" runat="server" visible="False"></UC1:CODICESTDAPPARECCHIATURA>
										<P></P>
										<TABLE id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
											<TR>
												<TD style="WIDTH: 219px" align="right">
													<CC1:S_BUTTON id="S_btMostra" runat="server" cssclass="btn" width="134px" text="Mostra Dettagli"
														tooltip="Avvia la ricerca"></CC1:S_BUTTON>&nbsp;</TD>
												<TD>&nbsp;
													<CC1:S_BUTTON id="btReset" runat="server" cssclass="btn" width="134px" text="Reset"></CC1:S_BUTTON></TD>
												<TD align="right"><A CLASS="GuidaLink" HREF="<%= HelpLink %>" 
                  TARGET="_blank">Guida</A></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</COLLAPSE:DATAPANEL></TD>
				</TR>
				<TR valign="top">
					<TD valign="top"><UC1:GRIDTITLE id="GridTitle1" runat="server"></UC1:GRIDTITLE><ASP:DATAGRID id="MyDataGrid1" runat="server" cssclass="DataGrid" width="100%" gridlines="Vertical"
							allowpaging="True" autogeneratecolumns="False" cellpadding="4" backcolor="White" borderwidth="1px" borderstyle="None" bordercolor="Gray">
							<FOOTERSTYLE forecolor="#003399" backcolor="#99CCCC"></FOOTERSTYLE>
							<ALTERNATINGITEMSTYLE cssclass="DataGridAlternatingItemStyle"></ALTERNATINGITEMSTYLE>
							<ITEMSTYLE cssclass="DataGridItemStyle"></ITEMSTYLE>
							<HEADERSTYLE cssclass="DataGridHeaderStyle"></HEADERSTYLE>
							<COLUMNS>
								<ASP:TEMPLATECOLUMN>
									<HEADERSTYLE width="30px"></HEADERSTYLE>
									<ITEMSTYLE horizontalalign="Center"></ITEMSTYLE>
									<ITEMTEMPLATE>
										<asp:ImageButton id="Imagebutton1" title="Elenco Apparecchiature per Stanza" OnCommand="imagebutton1_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id_rm")+"&amp;bl_id=" + DataBinder.Eval(Container.DataItem,"id_bl")+"&amp;piani=" + DataBinder.Eval(Container.DataItem,"idpiani")+ "&amp;TitoloStanza=" +DataBinder.Eval(Container.DataItem,"Stanza")  %>' Runat="server" ImageUrl="../Images/Stanza.gif">
										</ASP:IMAGEBUTTON>
									</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
								<ASP:TEMPLATECOLUMN>
									<HEADERSTYLE width="30px"></HEADERSTYLE>
									<ITEMTEMPLATE>
										<asp:ImageButton id="Imagebutton2" title="Elenco Apparecchiature per Piano" OnCommand="imagebutton2_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"idpiani")+"&amp;bl_id=" + DataBinder.Eval(Container.DataItem,"id_bl") + "&amp;TitoloPiano=" +DataBinder.Eval(Container.DataItem,"piano") %>' Runat="server" ImageUrl="../Images/Piano.gif">
										</ASP:IMAGEBUTTON>
									</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
								<ASP:BOUNDCOLUMN datafield="bl_id" headertext="Cod.Edificio"></ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN datafield="piano" headertext="Piano"></ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN datafield="stanza" headertext="Stanza"></ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN visible="False" datafield="id_bl"></ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN visible="False" datafield="id_rm"></ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN visible="False" datafield="idpiani"></ASP:BOUNDCOLUMN>
							</COLUMNS>
							<PAGERSTYLE horizontalalign="Left" forecolor="Black" backcolor="Silver" mode="NumericPages"></PAGERSTYLE>
						</ASP:DATAGRID></TD>
				</TR>
			</TABLE>
		</FORM>
		</TD></TR></TBODY></TABLE>
	</BODY>
</HTML>
