<%@ Register TagPrefix="cc1" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="VisualDWF.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.VisualDWF" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Documenti Grafici</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></TD>
				</TR>
				<TR>
					<TD>
						<cc1:datapanel id="DataPanel1" runat="server" AllowTitleExpandCollapse="True" CollapseImageUrl="../Images/up.gif"
							CssClass="DataPanel75" CollapseText="Riduci" ExpandImageUrl="../Images/down.gif"
							ExpandText="Espandi" TitleText="Dati Generali " Collapsed="False" TitleStyle-CssClass="TitleSearch">
							<asp:Repeater id="Repeater1" runat="server">
								<HeaderTemplate>
								</HeaderTemplate>
								<ItemTemplate>
									<table width="100%" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td><b>Edificio:</b></td>
											<td>
												<%# DataBinder.Eval(Container, "DataItem.var_afm_dwgs_bl_id") %>
												-
												<%# DataBinder.Eval(Container, "DataItem.var_bl_name") %>
											</td>
											<td><b>Servizio: </b>
											</td>
											<td>
												<%# DataBinder.Eval(Container, "DataItem.var_afm_dwgs_servizio") %>
											</td>
										</tr>
										<tr>
											<td><b>Categoria: </b>
											</td>
											<td>
												<%# DataBinder.Eval(Container, "DataItem.var_afm_dwgs_categorie") %>
											</td>
											<td><b>Tipologia: </b>
											</td>
											<td>
												<%# DataBinder.Eval(Container, "DataItem.var_afm_dwgs_tipologie") %>
											</td>
										</tr>
										<tr>
											<td><b>Nome File: </b>
											</td>
											<td>
												<%# DataBinder.Eval(Container, "DataItem.var_nomedwf") %>
											</td>
											<td><b>Descrizione: </b>
											</td>
											<td>
												<%# DataBinder.Eval(Container, "DataItem.var_afm_dwgs_title") %>
											</td>
											<asp:Literal Runat="server" ID="lite"></asp:Literal>
										</tr>
									</table>
								</ItemTemplate>
								<FooterTemplate>
									<br>
									<%if(Context.Handler is TheSite.AnagrafeImpianti.NavigazioneDocumenti || Context.Handler is TheSite.AnagrafeImpianti.NavigazioneCertificati){%>				
										<table><tr><td><input type="button" id="btnh" value="Indietro" onclick="javascript:history.back();"></td></tr></table>
									<%}else{%>
										<table><tr><td><input type="button" id="btnclose" value="Chiudi" onclick="javascript:window.close();"></td></tr></table>
									<%}%>	
								</FooterTemplate>
							</asp:Repeater>
						</cc1:datapanel>
					</TD>
				</TR>
				<TR height="100%">
					<TD style="HEIGHT: 100%">
						<P><asp:literal id="Literal1" Runat="server"></asp:literal></P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
