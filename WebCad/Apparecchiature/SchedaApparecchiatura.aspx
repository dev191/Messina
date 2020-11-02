<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Page language="c#" Codebehind="SchedaApparecchiatura.aspx.cs" AutoEventWireup="false" Inherits="WebCad.Apparecchiature.SchedaApparecchiatura" enableViewState="False" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SchedaApparecchiatura</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="1" rowSpan="1">
							<P><cc1:s_label id="S_lblTitoloPage" runat="server" Font-Size="14pt">Scheda Apparecchiatura</cc1:s_label>&nbsp;
							</P>
							<P></P>
							<asp:panel id="Panel1" runat="server" Width="100%">
      <TABLE id=tblSearch100Dettaglio cellSpacing=0 cellPadding=0 width="100%" 
      border=0>
        <TR>
          <TD>Codice Componente:</TD>
          <TD>
<cc1:S_Label id=S_lblcodicecomponente runat="server"></cc1:S_Label></TD>
          <TD rowSpan=11><IMG src="PageImage.aspx?<%=Imagename%>&amp;p=y" 
            align=right/></TD></TR>
        <TR>
          <TD>Standard Apparecchiatura:</TD>
          <TD>
<cc1:S_Label id=S_lblstdapparecchiature runat="server"></cc1:S_Label></TD></TR>
        <TR>
          <TD>Codice Edificio:</TD>
          <TD>
<cc1:S_Label id=S_lblcodiceedificio runat="server"></cc1:S_Label></TD></TR>
        <TR>
          <TD>Edificio:</TD>
          <TD>
<cc1:S_Label id=S_lbledificio runat="server"></cc1:S_Label></TD></TR>
        <TR>
          <TD>Piano:</TD>
          <TD>
<cc1:S_Label id=S_lblpiano runat="server"></cc1:S_Label></TD></TR>
        <TR>
          <TD>Stanza:</TD>
          <TD>
<cc1:S_Label id=S_lblstanza runat="server"></cc1:S_Label></TD></TR>
        <TR>
          <TD>Quantita:</TD>
          <TD>
<cc1:S_Label id=S_lblqta runat="server"></cc1:S_Label></TD></TR>
        <TR>
          <TD style="WIDTH: 15%">Locale Tecnico:</TD>
          <TD>
<cc1:S_Label id=S_lbltecnico runat="server"></cc1:S_Label></TD></TR>
        <TR>
          <TD>Marca:</TD>
          <TD>
<cc1:S_Label id=S_lblmarca runat="server"></cc1:S_Label></TD></TR>
        <TR>
          <TD>Modello:</TD>
          <TD>
<cc1:S_Label id=S_lblmodello runat="server"></cc1:S_Label></TD></TR>
        <TR>
          <TD>Tipo:</TD>
          <TD>
<cc1:S_Label id=S_lbltipo runat="server"></cc1:S_Label></TD></TR>
        <TR>
          <TD>Garanzia:</TD>
          <TD>
<cc1:S_Label id=S_lblgaranzia runat="server"></cc1:S_Label></TD></TR>
        <TR>
          <TD></TD>
          <TD></TD></TR></TABLE>
							</asp:panel><cc2:datapanel id="DataPanelCaratteristiche" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
								TitleText="Caratteristiche Tecniche " ExpandText="Espandi" ExpandImageUrl="../Images/downarrows_trans.gif"
								CollapseText="Espandi/Riduci" CssClass="DataPanel75" CollapseImageUrl="../Images/uparrows_trans.gif" AllowTitleExpandCollapse="True">
<asp:datalist id=DataList1 runat="server" Width="100%" BorderWidth="0px" GridLines="Both" RepeatDirection="Horizontal" RepeatColumns="2">
									<ItemTemplate>
										<span>
											<%# DataBinder.Eval(Container, "DataItem.tipologia") %>
											:&nbsp;</span> <span>
											<%# DataBinder.Eval(Container, "DataItem.descrizione") %>
											&nbsp;</span>
									</ItemTemplate>
									<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
								</asp:datalist>
							</cc2:datapanel></TD>
					</TR>
					<TR>
						<TD align="left">&nbsp;
							<cc2:datapanel id="DataPanelPassi" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
								TitleText="Manutenzione Generale Apparecchiatura " ExpandText="Espandi" ExpandImageUrl="../Images/downarrows_trans.gif"
								CollapseText="Espandi/Riduci" CssClass="DataPanel75" CollapseImageUrl="../Images/uparrows_trans.gif"
								AllowTitleExpandCollapse="True">
								<asp:datalist id="Datalist2" runat="server" Width="100%" RepeatDirection="Horizontal" GridLines="Both"
									BorderWidth="1px" DataKeyField="id">
									<HeaderTemplate>
										<table Width="100%" class="tblSearch100Dettaglio">
											<tr>
												<td>Servizio</td>
												<td>Attivit&#224;</td>
												<td>Descrizione</td>
												<td>Frequenza</td>
												<td>Tempo stimato</td>
												<td>Specializzazione Addetto</td>
											</tr>
									</HeaderTemplate>
									<ItemTemplate>
										<tr>
											<td>
												<a runat="server" ID="A1"><img src="../Images/uparrows_trans.gif" runat="server" border="0" id="imageexpand"></a>
												<asp:Label id="Label2" runat="server">
													<%# DataBinder.Eval(Container,"DataItem.pm_group") %>
												</asp:Label></td>
											<td><asp:Label id="Label1" runat="server"><%# DataBinder.Eval(Container,"DataItem.pmp_id") %></asp:Label>
											</td>
											<td><asp:Label id="Label3" runat="server"><%# DataBinder.Eval(Container,"DataItem.description") %></asp:Label></td>
											<td><asp:Label id="Label4" runat="server"><%# DataBinder.Eval(Container,"DataItem.frequenza") %></asp:Label></td>
											<td><asp:Label id="Label5" runat="server"><%# DataBinder.Eval(Container,"DataItem.units_hour") %></asp:Label></td>
											<td><asp:Label id="Label6" runat="server"><%# DataBinder.Eval(Container,"DataItem.tr_id") %></asp:Label></td>
										</tr>
										<br>
										<tr>
											<td colspan="6">
												<div style="display:none;" id="expand" runat="server">
													<asp:Repeater ID="repetarpassi" runat="server">
														<HeaderTemplate>
															<table border="0" width="100%">
														</HeaderTemplate>
														<ItemTemplate>
															<tr valign="middle">
																<td align="right">Passo:
																	<%# DataBinder.Eval(Container,"DataItem.passo")%>
																</td>
																<td align="left"><%# DataBinder.Eval(Container,"DataItem.descrizione")%></td>
															</tr>
														</ItemTemplate>
														<FooterTemplate>
			</TABLE>
			</FooterTemplate> </asp:Repeater> </div> </td> </tr> </ItemTemplate>
			<FooterTemplate>
			</TABLE>
			</FooterTemplate>
			</asp:datalist></cc2:datapanel></TD></TR></TBODY></TABLE>
			<!--if(Context.Handler is TheSite.AnagrafeImpianti.NavigazioneApparecchiature)
			<table>
				<tr>
					<td><input id="btnh" onclick="javascript:history.back();" type="button" value="Indietro"></td>
				</tr>
			</table>
			else-->
			<table>
				<tr>
					<td><input id="btnclose" onclick="javascript:window.close();" type="button" value="Chiudi"></td>
				</tr>
			</table>
			<!--}-->
		</form>
	</body>
</HTML>
