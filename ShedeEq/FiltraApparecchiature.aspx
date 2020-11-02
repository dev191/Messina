<%@ Register TagPrefix="uc1" TagName="UserStanze" Src="../WebControls/UserStanze.ascx" %>
<%@ Page language="c#" Codebehind="FiltraApparecchiature.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ShedeEq.FiltraApparecchiature" smartNavigation="False" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
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
			function SelCheckbox()
			{
				for (i=0;i<document.all.length;i++)	
				{
					if (document.all(i).type == 'checkbox')	
					{
						if (document.getElementById("ChkSelTutti").checked==true)
						{
							nome=document.all(i).id;	
							if (nome.substring(0,11)=='MyDataGrid1')
							{	
								if(document.all(i).disabled==false)
								{
									document.all(i).checked=true;}
								}
							}			
						else
						{
							nome=document.all(i).id;	
							if (nome.substring(0,11)=='MyDataGrid1')
							{	
								if(document.all(i).disabled==false)
								{
									document.all(i).checked=false;
								}
							 }
						 }								
					 }
				}
			}
		</SCRIPT>
	</HEAD>
	<BODY ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="center"><UC1:PAGETITLE id="PageTitle1" runat="server"></UC1:PAGETITLE></TD>
				</TR>
				<TR>
					<TD valign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" titlestyle-cssclass="TitleSearch" collapsed="False"
							titletext="Ricerca" expandtext="Espandi" expandimageurl="../Images/down.gif" collapsetext="Espandi/Riduci" cssclass="DataPanel75"
							collapseimageurl="../Images/up.gif" allowtitleexpandcollapse="True">
							<TABLE id="tblSearch100" cellSpacing="1" cellPadding="1" border="0">
								<TR>
									<TD vAlign="top" align="center" colSpan="4">
										<P>
											<UC1:RICERCAMODULO id="RicercaModulo1" runat="server"></UC1:RICERCAMODULO></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%">Piano:</TD>
									<TD style="HEIGHT: 28px">
										<CC1:S_COMBOBOX id="cmbsPiano" runat="server" width="200px"></CC1:S_COMBOBOX></TD>
									<TD colSpan="2">
										<uc1:UserStanze id="UserStanze1" runat="server"></uc1:UserStanze></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 2px"><SPAN>Servizio: </SPAN>
									</TD>
									<TD style="HEIGHT: 2px" colSpan="3">
										<CC1:S_COMBOBOX id="cmbsServizio" runat="server" width="392px" autopostback="True"></CC1:S_COMBOBOX></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 28px"><SPAN>Std. Apparecchiatura:</SPAN>
									</TD>
									<TD style="HEIGHT: 28px" colSpan="3">
										<CC1:S_COMBOBOX id="cmbsApparecchiatura" runat="server" width="392px"></CC1:S_COMBOBOX></TD>
								</TR>
								<TR>
									<TD colSpan="4">
										<UC1:CODICEAPPARECCHIATURE id="CodiceApparecchiature1" runat="server"></UC1:CODICEAPPARECCHIATURE></TD>
								</TR>
								<TR>
									<TD colSpan="4">&nbsp;
										<P></P>
										<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
											<TR>
												<TD align="left">
													<CC1:S_BUTTON id="S_btMostra" runat="server" cssclass="btn" width="130px" text="Ricerca" tooltip="Avvia la ricerca"></CC1:S_BUTTON>&nbsp;</TD>
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
					<TD valign="top"><UC1:GRIDTITLE id="GridTitle1" runat="server"></UC1:GRIDTITLE><ASP:DATAGRID id="MyDataGrid1" runat="server" cssclass="DataGrid" gridlines="Vertical" allowpaging="True"
							autogeneratecolumns="False" borderwidth="1px" bordercolor="Gray">
							<ALTERNATINGITEMSTYLE cssclass="DataGridAlternatingItemStyle"></ALTERNATINGITEMSTYLE>
							<ITEMSTYLE cssclass="DataGridItemStyle"></ITEMSTYLE>
							<HEADERSTYLE cssclass="DataGridHeaderStyle"></HEADERSTYLE>
							<COLUMNS>
								<ASP:TEMPLATECOLUMN>
									<HEADERSTYLE horizontalalign="Center" width="3%" verticalalign="Middle"></HEADERSTYLE>
									<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
									<HEADERTEMPLATE>
										<INPUT id="ChkSelTutti" type="checkbox" onclick="SelCheckbox()">
									</HEADERTEMPLATE>
									<ITEMTEMPLATE>
										<ASP:CHECKBOX id="ChkSel" runat="server"></ASP:CHECKBOX>
									</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
								<ASP:BOUNDCOLUMN visible="true" datafield="id_eq" headertext="ideq"></ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN datafield="bl_id" headertext="Cod.Edificio"></ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN datafield="ID" headertext="Cod. Apparecchiatura"></ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN datafield="DESCRIZIONE" headertext="Std. Apparecchiatura"></ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN datafield="Servizio" headertext="Servizio"></ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN visible="False" datafield="date_dismiss" headertext="Dismessa"></ASP:BOUNDCOLUMN>
							</COLUMNS>
							<PAGERSTYLE horizontalalign="Left" cssclass="DataGridPagerStyle" mode="NumericPages"></PAGERSTYLE>
						</ASP:DATAGRID></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="TblBtn">
							<TR>
								<TD><ASP:BUTTON id="btnConfermaSelezione" runat="server" cssclass="btn" width="130px" text="Conferma Selezione"
										enabled="False"></ASP:BUTTON></TD>
								<TD><ASP:BUTTON id="btnSelezionaTutto" runat="server" cssclass="btn" width="130px" text="Seleziona Tutto"
										enabled="False"></ASP:BUTTON></TD>
								<TD><ASP:BUTTON id="btnDeselezionaTutto" runat="server" cssclass="btn" width="130px" text="Deseleziona Tutto"
										enabled="False"></ASP:BUTTON></TD>
								<TD><ASP:BUTTON id="btnGeneraReportHtml" runat="server" cssclass="btn" width="130px" text="Genera Report Html"
										enabled="False"></ASP:BUTTON></TD>
								<TD><ASP:BUTTON id="btnGeneraReportPdf" runat="server" cssclass="btn" width="130px" text="Genera Report Pdf"
										enabled="False"></ASP:BUTTON></TD>
								<TD><ASP:BUTTON id="btnReset" runat="server" text="Reset" cssclass="btn" width="130px"></ASP:BUTTON></TD>
							</TR>
							<TR>
								<TD colspan="6">
									<ASP:LABEL id="lblElementiSelezionati" runat="server"></ASP:LABEL>
								</TD>
							</TR>
							<TR>
								<TD colspan="6">
									<ASP:LABEL id="LblRangeException" runat="server" backcolor="White" forecolor="#C00000" font-size="Larger"></ASP:LABEL>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
