<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Addetti" Src="../WebControls/Addetti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Page language="c#" Codebehind="SfogliaRdlOdlPaging.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.SfogliaRdlOdlPaging" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SfogliaOdlRdl</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
		var NS4 = (navigator.appName == "Netscape" && parseInt(navigator.appVersion) < 5);
		var NSX = (navigator.appName == "Netscape");
		var IE4 = (document.all) ? true : false;
		
			if(self.location==top.location){
			location.href="Default.aspx";
			}
			
			function valutanumeri(evt)
			{
				var e = evt? evt : window.event; 
				if(!e) return; 
				var key = 0; 
				
				if(IE4==true)
				{
					if (e.keyCode < 48	|| e.keyCode > 57){
						e.keyCode = 0;
						return false;
					}	
		        }
		        
				if (e.keycode) { key = e.keycode; } // for moz/fb, if keycode==0 use 'which' 
				if (typeof(e.which)!= 'undefined') { 
					key = e.which;
					if (key < 48	|| key > 57){
						return false;
					} 
					
				} 
			}
			function nonpaste()
			{
				return false;
			}
		</SCRIPT>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD><cc2:datapanel id="DataPanel1" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
							TitleText="Ricerca" ExpandText="Espandi" ExpandImageUrl="../Images/down.gif" CollapseText="Riduci"
							CssClass="DataPanel75" CollapseImageUrl="../Images/up.gif" AllowTitleExpandCollapse="True">
							<TABLE id="tblSearch100" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD colSpan="4">
										<uc1:ricercamodulo id="RicercaModulo1" runat="server"></uc1:ricercamodulo></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%; HEIGHT: 16px">Scadenza Da:</TD>
									<TD style="WIDTH: 305px; HEIGHT: 16px">
										<cc1:s_combobox id="cmbsMeseDa" runat="server" DBSize="2" DBDirection="Input" DBParameterName="p_MeseDa"
											DBIndex="1" DBDataType="Integer">
											<asp:ListItem Value="01">Gennaio</asp:ListItem>
											<asp:ListItem Value="02">Febbraio</asp:ListItem>
											<asp:ListItem Value="03">Marzo</asp:ListItem>
											<asp:ListItem Value="04">Aprile</asp:ListItem>
											<asp:ListItem Value="05">Maggio</asp:ListItem>
											<asp:ListItem Value="06">Giugno</asp:ListItem>
											<asp:ListItem Value="07">Luglio</asp:ListItem>
											<asp:ListItem Value="08">Agosto</asp:ListItem>
											<asp:ListItem Value="09">Settembre</asp:ListItem>
											<asp:ListItem Value="10">Ottobre</asp:ListItem>
											<asp:ListItem Value="11">Novembre</asp:ListItem>
											<asp:ListItem Value="12">Dicembre</asp:ListItem>
										</cc1:s_combobox>
										<cc1:s_combobox id="cmbsAnnoDa" runat="server" DBSize="4" DBDirection="Input" DBParameterName="p_AnnoDa"
											DBIndex="2" DBDataType="Integer"></cc1:s_combobox></TD>
									<TD style="WIDTH: 75px; HEIGHT: 16px">Scadenza A:</TD>
									<TD style="HEIGHT: 16px">
										<cc1:s_combobox id="cmbsMeseA" runat="server" DBSize="2" DBDirection="Input" DBParameterName="p_MeseA"
											DBIndex="3" DBDataType="Integer">
											<asp:ListItem Value="01">Gennaio</asp:ListItem>
											<asp:ListItem Value="02">Febbraio</asp:ListItem>
											<asp:ListItem Value="03">Marzo</asp:ListItem>
											<asp:ListItem Value="04">Aprile</asp:ListItem>
											<asp:ListItem Value="05">Maggio</asp:ListItem>
											<asp:ListItem Value="06">Giugno</asp:ListItem>
											<asp:ListItem Value="07">Luglio</asp:ListItem>
											<asp:ListItem Value="08">Agosto</asp:ListItem>
											<asp:ListItem Value="09">Settembre</asp:ListItem>
											<asp:ListItem Value="10">Ottobre</asp:ListItem>
											<asp:ListItem Value="11">Novembre</asp:ListItem>
											<asp:ListItem Value="12">Dicembre</asp:ListItem>
										</cc1:s_combobox>
										<cc1:s_combobox id="cmbsAnnoA" runat="server" DBSize="4" DBDirection="Input" DBParameterName="p_AnnoA"
											DBIndex="4" DBDataType="Integer"></cc1:s_combobox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%">Ordine di lavoro:</TD>
									<TD style="WIDTH: 305px">
										<cc1:s_textbox id="txtOrdineLavoro" runat="server" Width="260px"></cc1:s_textbox></TD>
									<TD style="WIDTH: 75px"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%">Richiesta di lavoro:</TD>
									<TD style="WIDTH: 305px">
										<cc1:s_textbox id="txtRichiestaLavoro" runat="server" Width="260px"></cc1:s_textbox></TD>
									<TD style="WIDTH: 75px">Stato Rdl:</TD>
									<TD>
										<cc1:s_combobox id="cmbsstatolavoro" runat="server" DBSize="5" DBDirection="Input" DBParameterName="p_Ditta"
											DBIndex="5" DBDataType="Integer" Width="224px"></cc1:s_combobox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%">Descrizione:</TD>
									<TD style="WIDTH: 305px">
										<cc1:s_textbox id="txtDescrizione" runat="server" Width="260px"></cc1:s_textbox></TD>
									<TD style="WIDTH: 75px"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%">Ditta:</TD>
									<TD style="WIDTH: 305px">
										<cc1:s_combobox id="cmbsDitta" runat="server" DBSize="5" DBDirection="Input" DBParameterName="p_Ditta"
											DBIndex="5" DBDataType="Integer" Width="320px" AutoPostBack="True"></cc1:s_combobox></TD>
									<TD style="WIDTH: 75px">Addetto:</TD>
									<TD>
										<uc1:addetti id="Addetti1" runat="server"></uc1:addetti></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%">Servizio:</TD>
									<TD style="WIDTH: 305px">
										<cc1:s_combobox id="cmbsServizio" runat="server" DBSize="5" DBDirection="Input" DBParameterName="p_Servizio"
											DBIndex="6" DBDataType="Integer" Width="320px" AutoPostBack="True"></cc1:s_combobox></TD>
									<TD style="WIDTH: 75px"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%">Standard Apparecchiature:</TD>
									<TD style="WIDTH: 305px; HEIGHT: 17px">
										<cc1:s_combobox id="cmbsStdApparecchiature" runat="server" DBSize="5" DBDirection="Input" DBParameterName="p_Servizio"
											DBIndex="6" DBDataType="Integer" Width="320px"></cc1:s_combobox></TD>
									<TD style="WIDTH: 75px; HEIGHT: 17px"></TD>
									<TD style="HEIGHT: 17px"></TD>
								</TR>
								<TR>
									<TD colSpan="4">
										<uc1:CodiceApparecchiature id="CodiceApparecchiature1" runat="server"></uc1:CodiceApparecchiature></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%" colSpan="4">
										<TABLE id="Table2" style="WIDTH: 392px; HEIGHT: 39px" cellSpacing="1" cellPadding="1" width="392"
											border="0">
											<TR>
												<TD style="WIDTH: 104px">
													<cc1:S_Button id="btRicerca" runat="server" CssClass="btn" Width="96px" Text="Ricerca"></cc1:S_Button></TD>
												<TD>
													<cc1:S_Button id="btUltimo" runat="server" CssClass="btn" Width="96px" Text="Ultimo Mese"></cc1:S_Button></TD>
												<TD>
													<cc1:S_Button id="btReset" runat="server" CssClass="btn" Width="96px" Text="Reset"></cc1:S_Button>&nbsp;<A 
                  class=GuidaLink href="<%= HelpLink %>" 
                target=_blank>Guida</A></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</cc2:datapanel></TD>
				</TR>
				<TR>
					<TD><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGrid1" runat="server" CssClass="DataGrid" Width="100%" BorderColor="Gray"
							BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False" AllowPaging="True" GridLines="Vertical">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="OdL">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id=LinkButton1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"wo_id") %>' OnCommand="LinkButton1_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"wo_id") %>'>
										</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Comune" HeaderText="Comune">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NomeEdificio" HeaderText="Cod.Edificio">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IndEdificio" HeaderText="Indirizzo">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NOMEEDIFICIO" HeaderText="Den.Edificio">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Servizio" HeaderText="Servizio">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="macro" HeaderText="MC">
									<HeaderStyle Width="3%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATPIAN" HeaderText="Data Pian." DataFormatString="{0:d}">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATA_C" HeaderText="Data Compl." DataFormatString="{0:d}">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NOMEDITTA" HeaderText="Ditta">
									<HeaderStyle Width="7%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PMPADDETTO" HeaderText="Addetto">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Stato OdL">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="Linkbutton2" runat="server" Text="Completa" OnCommand="LinkButton2_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"wo_id") %>'>
										</asp:LinkButton>
										<asp:Label id="lblComp" Runat="server">Completato</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" Visible="False" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
						<div id="PagingLink" runat="server">
							<div class="pageLinks">
								<b>Pagina&nbsp;<asp:Label id="CurrentPage" CssClass="pageLinks" runat="server" />
									di
									<asp:Label id="TotalPages" CssClass="pageLinks" runat="server" /></b>
							</div>
							<div>
								<asp:LinkButton runat="server" CssClass="pageLinks" id="FirstPage" Text="[Prima Pagina]" OnCommand="NavigationLink_Click"
									CommandName="First" />&nbsp;
								<asp:LinkButton runat="server" CssClass="pageLinks" id="PreviousPage" Text="[Pagina Precedente]"
									OnCommand="NavigationLink_Click" CommandName="Prev" />&nbsp;
								<asp:LinkButton runat="server" CssClass="pageLinks" id="NextPage" Text="[Pagina Successiva]" OnCommand="NavigationLink_Click"
									CommandName="Next" />&nbsp;
								<asp:LinkButton runat="server" CssClass="pageLinks" id="LastPage" Text="[Ultima Pagina]" OnCommand="NavigationLink_Click"
									CommandName="Last" />
							</div>
						</div>
						<p>&nbsp;</p>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
