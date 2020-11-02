<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="ServiceDettail.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.ServiceDettail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ServiceDettail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		 var finestra;
		 var finestra1;
		 var finestra3;
		 function chiudi()
		 {
		  if (finestra!=null)
		      finestra.close();
		      
		  if (finestra1!=null)
		      finestra1.close();
		  
		  if (finestra3!=null)
		      finestra3.close();
		 }
		 function opendoc(sender)
		 {
			var url;		
			url = "VisualDWF.aspx?" + sender;
			finestra=window.open(url,'','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width=800,height=600,align=center');
		 }
		  function opendoc1(sender)
		 {
			var url;		
			url = "DocImageGalery.aspx?" + sender;
			finestra1=window.open(url,'','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width=800,height=600,align=center');
		 }
		   function opendoceq(sender)
		 {
			var url;		
			url = "SchedaApparecchiatura.aspx?" + sender;
			finestra3=window.open(url,'','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width=800,height=600,align=center');
		 }
		 
		 function OpenPopUp(bl_id)
		 {
			var param="ServiceDettail.aspx?bl_id=" + bl_id; 
			window.open(param,"lin","width=800px, height=800px, toolbar=no,location=no,status=yes,menubar=no,scrollbars=yes,resizable=yes");
			
		 }
		</script>  
	</HEAD>
	<body MS_POSITIONING="GridLayout" onbeforeunload="chiudi();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellPadding="1" width="100%" border="0">
				<TBODY>
					<TR>
						<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
					</tr>
					<tr>
						<td><INPUT class="btn"  id="BtnPopUp" type="button" value="Visualizza in altra finestra" runat=server></td>
					</TR>
					<TR>
						<TD>
						<cc2:datapanel id="DataPanelDatiGenerali" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
								TitleText="Dati Generali " ExpandText="Espandi" ExpandImageUrl="../Images/down.gif"
								CollapseText="Riduci" CssClass="DataPanel75" CollapseImageUrl="../Images/up.gif"
								AllowTitleExpandCollapse="True">
								<asp:repeater id="RepeaterDatigerali" runat="server" EnableViewState=False>
									<HeaderTemplate>
										<table width="100%" border="0" cellpadding="0" cellspacing="0">
									</HeaderTemplate>
									<ItemTemplate>
										<tr>
											<td align="left"><b>Fabbricato: </b>
											</td>
											<td align="Left"><%# DataBinder.Eval(Container, "DataItem.bl_id") %>
												-
												<%# DataBinder.Eval(Container, "DataItem.DENOMINAZIONE") %>
											</td>
											<td align="left"><b>Indirizzo: </b>
											</td>
											<td align="Left"><%# DataBinder.Eval(Container, "DataItem.INDIRIZZO") %></td>
										</tr>
										<tr>
											<td align="left"><b>Comune: </b>
											</td>
											<td align="Left"><%# DataBinder.Eval(Container, "DataItem.COMUNE") %></td>
											<td align="left"><b>Ditta: </b>
											</td>
											<td align="left"><%# DataBinder.Eval(Container, "DataItem.REFERENTE") %></td>
										</tr>
									</ItemTemplate>
								
									<FooterTemplate>
			</TABLE>
			</FooterTemplate> </asp:repeater></cc2:datapanel>
			<br>
							<cc2:datapanel id="DataPanelPrestazioniEnergetiche" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
								TitleText="Prestazioni Energetiche " ExpandText="Espandi" ExpandImageUrl="../Images/down.gif"
								CollapseText="Riduci" CssClass="DataPanel75" CollapseImageUrl="../Images/up.gif"
								AllowTitleExpandCollapse="True">
								<asp:repeater id="RepeaterPrestazioni" runat="server" EnableViewState=False>
									<HeaderTemplate>
										<table width="100%" border="0" cellpadding="0" cellspacing="0">
									</HeaderTemplate>
									<ItemTemplate>
										<tr>
											<td align="left"><b>Tipo Prestazione: </b>
											</td>
											<td align="Left"><%# DataBinder.Eval(Container, "DataItem.desctipo") %>
											
											</td>
											<td align="left"><b>Descrizione: </b>
											</td>
											<td align="Left"><%# DataBinder.Eval(Container, "DataItem.Descrizione") %></td>
										</tr>
										</ItemTemplate>
								
									<FooterTemplate>
			</TABLE>
			</FooterTemplate> </asp:repeater></cc2:datapanel>
			<br>
			<hr>
			<b>Documentazione e Immagini allegate:</b>
			<hr>
			<!--<cc2:DataPanel id="Paneldiagnosienergetica" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
				TitleText="Diagnosi Energetica " ExpandText="Espandi" ExpandImageUrl="../Images/down.gif"
				CollapseText="Riduci" CssClass="DataPanel75" CollapseImageUrl="../Images/up.gif"
				AllowTitleExpandCollapse="True">
				<asp:Repeater id="RepeaterDiagnosiEnergetica" runat="server">
				<HeaderTemplate>
				  <table width="100%" border="0" cellpadding="0" cellspacing="0">
				  <tr >
						<td align=left class="tdtop" ><b>Servizio</nobr></FONT></b></td>
						<td align=left class="tdcenter" ><b>Nome File</b></td>
						<td align=left class="tdcenter"><b>Tipo</b></td>
						<td align=left class="tdbottom" ><b>Descrizione</b></td>
					</tr>
				</HeaderTemplate>
				<ItemTemplate>
				<tr >
					<td align=left><%# TitleService(DataBinder.Eval(Container, "DataItem.var_afm_dwgs_servizio").ToString()) %></td>							
					<td align=left>
					<a href="javascript:opendoc('var_afm_dwgs_dwg_name=<%# DataBinder.Eval(Container, "DataItem.var_afm_dwgs_dwg_name") %>');">
					<%# DataBinder.Eval(Container, "DataItem.var_afm_dwgs_dwg_name") %></a>
					</td>
					<td align=left><%# DataBinder.Eval(Container, "DataItem.var_afm_dwgs_tipo") %></td>
					<td align=left><%# DataBinder.Eval(Container, "DataItem.var_afm_dwgs_title") %></td>
				</tr>
				</ItemTemplate>
				<FooterTemplate>
				</TABLE>
				</FooterTemplate> 
				</asp:Repeater>
			</cc2:DataPanel>-->
			<br>
			<cc2:DataPanel id="panelricognizione" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
				TitleText="Ricognizione Fotografica " ExpandText="Espandi" ExpandImageUrl="../Images/down.gif"
				CollapseText="Riduci" CssClass="DataPanel75" CollapseImageUrl="../Images/up.gif"
				AllowTitleExpandCollapse="True">
				<asp:Repeater id="Repeaterricfotografica" runat="server" EnableViewState=False>
				<HeaderTemplate>
				  <table width="100%" border="0" cellpadding="0" cellspacing="0">
				  <tr >
						<td align=left class="tdtop" ><b>Servizio</nobr></FONT></b></td>
						<td align=left class="tdcenter" ><b>Nome File</b></td>
						<td align=left class="tdcenter"><b>Tipo</b></td>
						<td align=left class="tdbottom" ><b>Descrizione</b></td>
					</tr>
				</HeaderTemplate>
				<ItemTemplate>
				<tr>
					<td align=left><%# DataBinder.Eval(Container, "DataItem.var_servizio") %></td>
					<td align=center>
					<a href="javascript:opendoc1('bl_id=<%# bl_id.ToString() + "&doc_id_servizio="+ DataBinder.Eval(Container, "DataItem.var_id_servizio") + "&categoria=" + DataBinder.Eval(Container, "DataItem.var_categoria")
					+ "&idtip=" + DataBinder.Eval(Container, "DataItem.var_tipologiaid")%>');" title="Visualizza Documento">
					 <img src="../Images/ico_info.gif"  border="0"></a>
					</td>
					<td align=left>Cartella Fotografica <%# DataBinder.Eval(Container, "DataItem.var_tipologia") %></td>
					<td align=left><%# DataBinder.Eval(Container, "DataItem.var_descrizione") %></td>
				</tr>
				</ItemTemplate>
				<FooterTemplate>
				</TABLE>
				</FooterTemplate> 
				</asp:Repeater>
			</cc2:DataPanel>
			<br>
			<cc2:DataPanel id="PanelElaboratiTecnici" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
				TitleText="Elaborati Tecnici " ExpandText="Espandi" ExpandImageUrl="../Images/down.gif"
				CollapseText="Riduci" CssClass="DataPanel75" CollapseImageUrl="../Images/up.gif"
				AllowTitleExpandCollapse="True">
				<asp:Repeater id="RepeaterElaboratiTecnici" runat="server" EnableViewState=False >
				<HeaderTemplate>
				  <table width="100%" border="0" cellpadding="0" cellspacing="0">
				  <tr >
						<td align=left class="tdtop" ><b>Servizio</nobr></FONT></b></td>
						<td align=left class="tdcenter" ><b>Nome File</b></td>
						<td align=left class="tdcenter"><b>Tipo</b></td>
						<td align=left class="tdbottom" ><b>Descrizione</b></td>
					</tr>
				</HeaderTemplate>
				<ItemTemplate>
				<tr>
					<td align=left width="50px"><%# DataBinder.Eval(Container, "DataItem.var_afm_dwgs_servizio")%></td>
					<td align=left>
					 <asp:PlaceHolder ID="placercontrols" Runat="server"></asp:PlaceHolder>   
					</td>
					<td align=left><%# DataBinder.Eval(Container, "DataItem.var_afm_dwgs_tipo")%></td>
					<td align=left> <%# DataBinder.Eval(Container, "DataItem.var_afm_dwgs_title")%></td>
				</tr>
				</ItemTemplate>
				<FooterTemplate>
				</TABLE>
				</FooterTemplate> 
				</asp:Repeater>
			</cc2:DataPanel>
			<br>
			<cc2:DataPanel id="PanelCerificazioni" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
				TitleText="Certificazioni " ExpandText="Espandi" ExpandImageUrl="../Images/down.gif"
				CollapseText="Riduci" CssClass="DataPanel75" CollapseImageUrl="../Images/up.gif"
				AllowTitleExpandCollapse="True">
				<asp:Repeater id="RepeaterCertificazioni" runat="server" EnableViewState=False>
				<HeaderTemplate>
				  <table width="100%" border="0" cellpadding="0" cellspacing="0">
				  <tr >
						<td align=left class="tdtop" ><b>Servizio</nobr></FONT></b></td>
						<td align=left class="tdcenter" ><b>Nome File</b></td>
						<td align=left class="tdcenter"><b>Tipo</b></td>
						<td align=left class="tdbottom" ><b>Descrizione</b></td>
					</tr>
				</HeaderTemplate>
				<ItemTemplate>
				</ItemTemplate>
				<FooterTemplate>
				</TABLE>
				</FooterTemplate> 
				</asp:Repeater>
			</cc2:DataPanel>
			<br>
			<cc2:DataPanel id="PanelResult" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
				TitleText="Apparecchiature " ExpandText="Espandi" ExpandImageUrl="../Images/down.gif"
				CollapseText="Riduci" CssClass="DataPanel75" CollapseImageUrl="../Images/up.gif"
				AllowTitleExpandCollapse="True">
				<iframe height=1500px width=100%  src="../AnagrafeImpianti/ListaApparecchiatureServ.aspx?bl_id=<% = bl_id.ToString()%>&servizio_id=<% = servizio_id.ToString()%>" ></iframe>
				<!--<asp:Repeater id="RepeaterApparecchiature" runat="server" EnableViewState=False>
				<HeaderTemplate>
				  <table width="100%" border="1" cellpadding="0" cellspacing="0">
				  <tr >
						<td align=left class="tdtop" width="28%"><b>Codice Apparecchiatura</nobr></FONT></b></td>
						<td align=left class="tdcenter" width="40%"><b>Descrizione Apparecchiatura</b></td>
						<td align=left class="tdcenter" width="23%"><b>Specializzazione Impianto</b></td>
						<td align=left class="tdcenter" width="6%"><b>Stanza</b></td>
						<td align=left class="tdbottom" width="5%"><b>Q.tà</b></td>
					</tr>
				</HeaderTemplate>
				<ItemTemplate>
				<tr>
					<td align=left>
						<a href="javascript:opendoceq('eq_id=<%# DataBinder.Eval(Container, "DataItem.var_eq_eq_id")%>');" title="Visualizza ">
						<%# DataBinder.Eval(Container, "DataItem.var_eq_eq_id")%></a>
					</td>
					<td align=left><%# DataBinder.Eval(Container, "DataItem.description") %></td>
					<td align=left><%# DataBinder.Eval(Container, "DataItem.category") %></td>
					
					<td align=left title='<%# DataBinder.Eval(Container, "DataItem.roomdesc") %>'>&nbsp;<%# DataBinder.Eval(Container, "DataItem.room") %> </td>
					<td align=left><%# DataBinder.Eval(Container, "DataItem.quantita") %></td>
				</tr>
				</ItemTemplate>
				<FooterTemplate>
				</TABLE>
				</FooterTemplate> 
				</asp:Repeater>-->
			</cc2:DataPanel>
			<br>
			</TD></TR></TBODY></TABLE></form>
	</body>
</HTML>
