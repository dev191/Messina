<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="Addetti" Src="../WebControls/Addetti.ascx" %>
<%@ Page language="c#" Codebehind="CompletamentoMP.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.CompletamentoMP" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ApprovaRdl</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function ControllaCaratteri(){
				if (event.keyCode < 48	|| event.keyCode > 57){
					event.keyCode = 0;					
				}	
			}
			
			function Valorizza(val)
			{		
				document.getElementById("txtHidden").value=val;										
			}
						
			function SelCheckbox(){
				for (i=0;i<document.all.length;i++)	{
					if (document.all(i).type == 'checkbox')	{
						if (document.getElementById("ChkSelTutti").checked==true){
							nome=document.all(i).id;	
							if (nome.substring(0,15)=='DataGridRicerca'){	
								if(document.all(i).disabled==false){
									document.all(i).checked=true;}
								}
							}			
						else
						{
							nome=document.all(i).id;	
							if (nome.substring(0,15)=='DataGridRicerca')
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
			
		function ControllaData()
			{						
				
				if(document.getElementById("txtHidden").value=='0')
				{
				
					var Data1 = document.getElementById("<%=cmbsAnnoDa.ClientID%>").value + document.getElementById("<%=cmbsMeseDa.ClientID%>").value;	
					var Data2 = document.getElementById("<%=cmbsAnnoA.ClientID%>").value + document.getElementById("<%=cmbsMeseA.ClientID%>").value;										
					if (Data1>Data2)
					{
						alert("Periodo di ricerca incongruende.");
						document.getElementById("<%=cmbsAnnoDa.ClientID%>").focus();
						return false;
					}
					
					var wo_id = document.getElementById("<%=txtsRichiesta.ClientID%>").value
					
					if (!IsNumber(wo_id))
					{
						alert("L'ordine di lavoro deve essere numerico.");
						document.getElementById("<%=txtsRichiesta.ClientID%>").focus();
						return false;
					}
				
				}
				
				if(document.getElementById("txtHidden").value=='1')				
				{
					var data = document.getElementById("<%=CalendarPicker1.Datazione.ClientID%>");
					
					if (data.value=="")					
					{	
						alert("La data di completamento è obbligatoria.");
						return false;
					}
				}
			   // var ctrl=document.getElementById('<%=btnsCompletaOdl.ClientID%>')  
				//if(ctrl!=null)	
				//	ctrl.disabled=true;  
					
				return true;
										
			}
			
		function IsNumber(data)
		{
			var numeri="0123456789";
			var appoggio="";
			var contatore=0;
			for (var i=0; i<data.length; i++){
				appoggio=data.substring(i,i+1);
				if ((numeri.indexOf(appoggio))!=-1){
					contatore++;
				}
			}
			if (contatore==data.length){
				return true;
			}else{
				return false;
			}
		}				
		
		function refreshgriglia()
				{
					document.Form1.hidRicerca.value='1';					
					__doPostBack('btnsRicerca','');
				}	
			
		</script>
</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout" (??)>
		<form id="Form1" method="post" runat="server" onsubmit="return ControllaData(chiudi);">
			<TABLE id="TableMaincellSpacing=" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px"
				cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" height="95%">
							<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
								<TBODY>
									<TR>
										<TD style="HEIGHT: 25.11%" vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" TitleStyle-CssClass="TitleSearch" CssClass="DataPanel75"
												TitleText="Ricerca" AllowTitleExpandCollapse="True" Collapsed="False" ExpandText="Espandi" CollapseText="Riduci" CollapseImageUrl="../Images/up.gif"
												ExpandImageUrl="../Images/down.gif">
            <TABLE id=tblSearch100 cellSpacing=1 cellPadding=2 border=0>
              <TR>
                <TD align=left colSpan=4></TD></TR>
              <TR>
                <TD style="HEIGHT: 22px" align=left width="13%">Ordine di 
                  Lavoro</TD>
                <TD style="HEIGHT: 22px" width="30%" colSpan=3>
<cc1:s_textbox id=txtsRichiesta runat="server" width="184px" DBIndex="7" DBParameterName="p_Wr_Id" DBDirection="Input" DBSize="255"></cc1:s_textbox></TD></TR>
              <TR>
                <TD style="HEIGHT: 30px" align=left>Scadenza Da</TD>
                <TD style="HEIGHT: 30px">
<cc1:S_ComboBox id=cmbsMeseDa runat="server" DBIndex="1" DBParameterName="p_MeseDa" DBDirection="Input" DBSize="2" DBDataType="Integer">
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
															</cc1:S_ComboBox>
<cc1:S_ComboBox id=cmbsAnnoDa runat="server" DBIndex="2" DBParameterName="p_AnnoDa" DBDirection="Input" DBSize="4" DBDataType="Integer"></cc1:S_ComboBox></TD>
                <TD style="HEIGHT: 30px" align=left>Scadenza A</TD>
                <TD style="HEIGHT: 30px">
<cc1:S_ComboBox id=cmbsMeseA runat="server" DBIndex="3" DBParameterName="p_MeseA" DBDirection="Input" DBSize="2" DBDataType="Integer">
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
															</cc1:S_ComboBox>
<cc1:S_ComboBox id=cmbsAnnoA runat="server" DBIndex="4" DBParameterName="p_AnnoA" DBDirection="Input" DBSize="4" DBDataType="Integer"></cc1:S_ComboBox></TD></TR>
              <TR>
                <TD style="HEIGHT: 23px" align=left colSpan=4>
<uc1:RicercaModulo id=RicercaModulo1 runat="server"></uc1:RicercaModulo></TD></TR>
              <TR>
                <TD align=left>Servizio</TD>
                <TD colSpan=3>
<cc1:S_ComboBox id=cmbsServizio runat="server" DBIndex="6" DBParameterName="p_Servizio" DBDirection="Input" DBSize="5" DBDataType="Integer" Width="384px"></cc1:S_ComboBox></TD></TR>
              <TR>
                <TD style="HEIGHT: 19px" align=left>Ditta</TD>
                <TD style="HEIGHT: 19px" colSpan=3>
<cc1:S_ComboBox id=cmbsDitta runat="server" DBIndex="5" DBParameterName="p_Ditta" DBDirection="Input" DBSize="5" DBDataType="Integer" Width="384px" AutoPostBack="True"></cc1:S_ComboBox></TD></TR>
              <TR>
                <TD>Addetti </TD>
                <TD align=left colSpan=3>
<uc1:Addetti id=Addetti1 runat="server"></uc1:Addetti></TD></TR>
              <TR>
                <TD align=left colSpan=3>
<cc1:s_button id=btnsRicerca tabIndex=2 runat="server" CssClass="btn" Text="Ricerca"></cc1:s_button>&nbsp; 
<asp:Button id=cmdReset CssClass="btn" Text="Reset" Runat="server"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp; 
                  <INPUT type=hidden name=hidRicerca></TD>
                <TD align=right><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD></TR></TABLE><INPUT id=txtHidden 
            type=hidden value=0></COLLAPSE:DATAPANEL></TD>
									</TR>
									<tr>
										<TD style="HEIGHT: 3%" align="center"></TD>
									</tr>
									<TR>
										<TD style="HEIGHT: 72%" vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AllowPaging="True" BorderColor="Gray"
												BorderWidth="1px" GridLines="Vertical" AutoGenerateColumns="False">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
													<asp:TemplateColumn HeaderStyle-HorizontalAlign=Center HeaderText="&lt;input id='ChkSelTutti' type='Checkbox' onclick='SelCheckbox()'&gt;">
														<HeaderStyle Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:CheckBox ID="ChkSel" Runat="server"></asp:CheckBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Ordine di Lavoro">
														<HeaderStyle Width="20px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton CommandName="Dettaglio" Text='<%# DataBinder.Eval(Container.DataItem,"ID") %>' CommandArgument= '<%# "Completamento_MP_WRlist.aspx?wo_id=" + DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton1"/>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="Localita" HeaderText="Localit&#224;">
														<HeaderStyle Width="15%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Edificio" HeaderText="Edificio">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Indirizzo" HeaderText="Indirizzo">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Denominazione" HeaderText="Den. Edificio"></asp:BoundColumn>
													<asp:BoundColumn DataField="Servizio" HeaderText="Servizio"></asp:BoundColumn>
													<asp:BoundColumn DataField="MC" HeaderText="MC"></asp:BoundColumn>
													<asp:BoundColumn DataField="DataPianificata" HeaderText="Data Pianificata"></asp:BoundColumn>
													<asp:BoundColumn DataField="Addetto" HeaderText="Addetto"></asp:BoundColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
									<tr>
										<td><COLLAPSE:DATAPANEL id="DatapanelCompleta" runat="server" TitleStyle-CssClass="TitleSearch" CssClass="DataPanel75"
												TitleText="Completamento/Modifica ODL" AllowTitleExpandCollapse="True" ExpandText="Espandi" CollapseText="Riduci"
												CollapseImageUrl="../Images/up.gif" ExpandImageUrl="../Images/down.gif"
												Visible="False">
            <TABLE height="100%" align=center border=1>
              <TR>
                <TD style="WIDTH: 378px">
                  <TABLE>
                    <TR>
                      <TD align=center colSpan=3>COMPLETAMENTO </TD></TR>
                    <TR>
                      <TD style="COLOR: red; HEIGHT: 21px">Modifica Addetto</TD>
                      <TD style="HEIGHT: 21px">
<cc1:S_ComboBox id=cmbsAddettoCompl runat="server" Width="216px"></cc1:S_ComboBox></TD></TR>
                    <TR><%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
                      <TD style="HEIGHT: 28px">Data Completamento</TD>
                      <TD style="HEIGHT: 28px">
<uc1:CalendarPicker id=CalendarPicker1 runat="server"></uc1:CalendarPicker></TD></TR>
                    <TR>
                      <TD align=center colSpan=2>
<cc1:S_Button id=btnsCompletaOdl runat="server" CssClass="btn" Width="130px" Text="COMPLETA ODL"></cc1:S_Button></TD></TR></TABLE></TD>
                <TD>
                  <TABLE>
                    <TR>
                      <TD align=center colSpan=3>GESTIONE ADDETTI </TD></TR>
                    <TR>
                      <TD 
                        style="WIDTH: 110px; COLOR: red; HEIGHT: 13px">Modifica 
                        Addetto</TD>
                      <TD style="HEIGHT: 13px">&nbsp; 
<cc1:S_ComboBox id=cmbsAddettoMod runat="server" Width="224px"></cc1:S_ComboBox></TD></TR>
                    <TR>
                      <TD style="HEIGHT: 28px" colSpan=2>&nbsp;</TD></TR>
                    <TR>
                      <TD align=center colSpan=2>
<cc1:S_Button id=btnsModificaODL runat="server" CssClass="btn" Width="98px" Text="MODIFICA ODL"></cc1:S_Button></TD></TR></TABLE></TD></TR>
              <TR>
                <TD align=center colSpan=2>
                  <TABLE>
                    <TR>
                    <TR>
                      <TD align=center>
<cc1:S_Button id=btnSChiudi runat="server" CssClass="btn" Width="98px" Text="Chiudi"></cc1:S_Button></TD></TR></TABLE></TD></TR></TABLE>
											</COLLAPSE:DATAPANEL></td>
									</tr>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE></TD></TR></TBODY></TABLE></TD></TR></form></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM><script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
