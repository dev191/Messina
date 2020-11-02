<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../../WebControls/GridTitle.ascx" %>
<%@ Page language="c#" Codebehind="SelectSchema.aspx.cs" AutoEventWireup="false" Inherits="TheSite.GIC.Report.SelectSchema" %>
<%@ Register TagPrefix="uc1" TagName="GridTitleServer" Src="../../WebControls/GridTitleServer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>SelectSchema</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style/StyleSheetReport.css" type="text/css" rel="stylesheet">
		<LINK href="../../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<FORM id="Form1" method="post" runat="server">
			<TABLE width="100%">
				<TBODY>
					<TR>
						<TD><UC1:PAGETITLE id="PageTitle1" runat="server"></UC1:PAGETITLE></TD>
					</TR>
					<TR>
						<TD>
							<UC1:GRIDTITLESERVER id="GridTitleServer1" runat="server"></UC1:GRIDTITLESERVER></TD>
					</TR>
					<TR>
						<TD><ASP:DATAGRID id="DatagridVista" runat="server" alternatingitemstyle-cssclass="DataGridAlternatingItemStyle"
								itemstyle-cssclass="DataGridItemStyle" headerstyle-cssclass="DataGridHeaderStyle" autogeneratecolumns="False">
								<COLUMNS>
									<ASP:TEMPLATECOLUMN>
										<HEADERSTYLE width="1%"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
										<ITEMTEMPLATE>
											<ASP:IMAGEBUTTON id="imgBtnVisualizza" runat="server" imageurl="../image/forward.png" oncommand="imgBtnVisualizza_Click" commandargument='<%# DataBinder.Eval(Container.DataItem,"id_vista") + "-" +DataBinder.Eval(Container.DataItem,"vista") %>'>
											</ASP:IMAGEBUTTON>
										</ITEMTEMPLATE>
									</ASP:TEMPLATECOLUMN>
									<ASP:TEMPLATECOLUMN>
										<HEADERSTYLE width="1%"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
										<ITEMTEMPLATE>
											<ASP:IMAGEBUTTON id="imgBtnDettaglioGlossario" runat="server" imageurl="../image/eye.gif" oncommand="imgBtnDettaglioGlossario_Click" commandargument='<%# DataBinder.Eval(Container.DataItem,"id_vista") + "-" +DataBinder.Eval(Container.DataItem,"vista") %>'>
											</ASP:IMAGEBUTTON>
										</ITEMTEMPLATE>
									</ASP:TEMPLATECOLUMN>
									<ASP:TEMPLATECOLUMN>
										<HEADERSTYLE width="1%"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
										<ITEMTEMPLATE>
											<ASP:IMAGEBUTTON id="ImgBtnElimina" runat="server" imageurl="../image/elimina.gif" oncommand="imgBtnElimina_Click" commandargument='<%# DataBinder.Eval(Container.DataItem,"id_vista") + "-" + DataBinder.Eval(Container.DataItem,"vista") + "-" + DataBinder.Eval(Container.DataItem,"descrizione")%>' >
											</ASP:IMAGEBUTTON>
										</ITEMTEMPLATE>
									</ASP:TEMPLATECOLUMN>
									<ASP:BOUNDCOLUMN datafield="id_vista" headertext="Id Vista" visible="False"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="aquisizione" headertext="acquisizione" visible="false"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="vista" headertext="Nome Vista"></ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN datafield="descrizione" headertext="Descrizione"></ASP:BOUNDCOLUMN>
									<ASP:TEMPLATECOLUMN>
										<HEADERSTYLE width="120px"></HEADERSTYLE>
										<ITEMSTYLE horizontalalign="Center" verticalalign="Middle"></ITEMSTYLE>
										<ITEMTEMPLATE>
											<ASP:BUTTON id="btnAquisisci" runat="server" causesvalidation="False" width="120px" oncommand="btnAquisisci_Click" commandargument='<%# DataBinder.Eval(Container.DataItem,"id_vista") + "-" +DataBinder.Eval(Container.DataItem,"vista") %>'>
											</ASP:BUTTON>
										</ITEMTEMPLATE>
									</ASP:TEMPLATECOLUMN>
								</COLUMNS>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD>&nbsp; <INPUT id="txtNomeVista" type="hidden" runat="server"><INPUT id="txtIdVista" type="hidden" value="-1" runat="server">
						</TD>
					</TR>
					<TR>
						<TD><ASP:PANEL id="pnlShowInfo" runat="server" width="100%" visible="false" cssclass="ShowInfoPanel350">
								<TABLE width="100%">
									<TR>
										<TD align="left">
											<ASP:LABEL id="lblDettaglioVista" runat="server"></ASP:LABEL></TD>
										<TD align="right">
											<ASP:LINKBUTTON id="lnkChiudi" runat="server" cssclass="LabelChiudi" causesvalidation="False">Chiudi &nbsp;</ASP:LINKBUTTON></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 26px" colSpan="2">
											<UC1:GRIDTITLE id="Gridtitle2" runat="server"></UC1:GRIDTITLE></TD>
									</TR>
									<TR>
										<TD colSpan="2">
											<ASP:DATAGRID id="DatagridGlossario" runat="server" autogeneratecolumns="False" headerstyle-cssclass="DataGridHeaderStyle"
												itemstyle-cssclass="DataGridItemStyle" alternatingitemstyle-cssclass="DataGridAlternatingItemStyle"
												width="100%">
												<COLUMNS>
													<ASP:BOUNDCOLUMN datafield="id_vista" headertext="Id Vista" visible="False"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="idglossario" headertext="Id Glossario" visible="False"></ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="origine" headertext="Campo">
														<HEADERSTYLE width="25%"></HEADERSTYLE>
													</ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="tabella" headertext="Tabella">
														<HEADERSTYLE width="20%"></HEADERSTYLE>
													</ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="alias" headertext="Alias Campo">
														<HEADERSTYLE width="25%"></HEADERSTYLE>
													</ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="descrizione_estesa" headertext="Descrizione Campo">
														<HEADERSTYLE width="20%"></HEADERSTYLE>
													</ASP:BOUNDCOLUMN>
													<ASP:BOUNDCOLUMN datafield="tipodato" headertext="Tipo Dato">
														<HEADERSTYLE width="10%"></HEADERSTYLE>
													</ASP:BOUNDCOLUMN>
												</COLUMNS>
											</ASP:DATAGRID></TD>
									</TR>
								</TABLE>
							</ASP:PANEL></TD>
					</TR>
				</TBODY>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
