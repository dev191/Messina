<%@ Register TagPrefix="uc1" TagName="BottomMenu2" Src="../WebControls/BottomMenu2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="Addetti" Src="../WebControls/Addetti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserMeseGiorno" Src="../WebControls/UserMeseGiorno.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserMeseGiorno2" Src="../WebControls/UserMeseGiorno.ascx" %>
<%@ Page language="c#" Codebehind="Impostazioni.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.Impostazioni" %>
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
			
			function AbilitaData(chk,cmbmesi,cmbgiorni)
			{				
				document.getElementById(cmbmesi).disabled=!document.getElementById(chk).checked;
				document.getElementById(cmbgiorni).disabled=!document.getElementById(chk).checked;
			}
			
			function ControllaEdifici()
			{				
				if(document.getElementById("<%=txtTotSelezionati.ClientID%>").value=='0')
				{
					if(document.getElementById("txtHidden").value=="1")
					{
						alert("Nessun Edificio Selezionato.");				
						return false;
					}
				}
			}
			
			function Valorizza(val)
			{
				document.getElementById("txtHidden").value=val;
			}
			
			
	function ImpostaGiorni(val,cmbgiorni)
	{
		var Elementi = document.getElementById(cmbgiorni).options.length - 1;
		while (Elementi > -1)
		{
			document.getElementById(cmbgiorni).remove(Elementi);	
			Elementi--;
		}
		
		var maxgiorni=0	
		
		switch (val)
		{		
		case "4":	//Aprile		
		case "6":	//Giugno		
		case "9":	//Settembre		
		case "11":	//Novembre		
			maxgiorni=30;
			break;
		case "2":		
			maxgiorni=28; //Febbraio	
			break;
		default:		
			maxgiorni=31;
			break;
		}

		var i;
		var ind=0;	
		for(i=1;i<=maxgiorni;i++)
		{	
			ind ++;
			Opt = document.createElement("Option");
			Opt.text = i;
			Opt.value = i;
			Opt.id = ind;		
			document.getElementById(cmbgiorni).add(Opt,ind);
		}
	}						
		</script>
</HEAD>
	<body bottomMargin="0" onbeforeunload="parent.left.valorizza()" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" onsubmit="return ControllaEdifici()" method="post" runat="server">
			<TABLE id="TableMain" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="1" cellPadding="1" width="98%" align="center">
								<TBODY>
									<TR>
										<TD vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" ExpandImageUrl="../Images/down.gif" CollapseImageUrl="../Images/up.gif"
												CollapseText="Riduci" ExpandText="Espandi" Collapsed="False" AllowTitleExpandCollapse="True" TitleText="Ricerca" CssClass="DataPanel75"
												TitleStyle-CssClass="TitleSearch">
            <TABLE id=tblSearch100 cellSpacing=1 cellPadding=2 border=0>
              <TR>
                <TD align=left colSpan=4>
<uc1:RicercaModulo id=RicercaModulo1 runat="server"></uc1:RicercaModulo></TD></TR>
              <TR>
                <TD align=left>Servizio</TD>
                <TD align=left>
<cc1:S_ComboBox id=cmbsServizio runat="server" DBDataType="Integer" DBIndex="6" DBParameterName="p_Servizio" DBDirection="Input" DBSize="5"></cc1:S_ComboBox></TD>
                <TD align=left>Ditta</TD>
                <TD align=left>
<cc1:S_ComboBox id=cmbsDitta runat="server" DBDataType="Integer" DBIndex="5" DBParameterName="p_Ditta" DBDirection="Input" DBSize="5"></cc1:S_ComboBox></TD></TR>
              <TR>
                <TD align=left>Tipologia</TD>
                <TD align=left colSpan=3>
<cc1:S_ComboBox id=cmbsTutti runat="server" DBDataType="Integer" DBIndex="6" DBParameterName="p_Tipologia" DBDirection="Input" DBSize="5" AutoPostBack="False">
																<asp:ListItem Value="1">Da Inserire nel Piano di Manutenzione</asp:ListItem>
																<asp:ListItem Value="2">Inseriti nel Piano di Manutenzione</asp:ListItem>
															</cc1:S_ComboBox>
<asp:TextBox id=txtTotSelezionati runat="server" Width="0px" Height="0px">0</asp:TextBox><INPUT 
                  id=txtHidden style="WIDTH: 3px; HEIGHT: 18px" type=hidden 
                  size=1 value=0 name=txtHidden></TD></TR>
              <TR>
                <TD align=left colSpan=3>
<cc1:s_button id=btnsRicerca tabIndex=2 runat="server" CssClass="btn" Text="Ricerca"></cc1:s_button>&nbsp; 
<asp:Button id=cmdReset CssClass="btn" Text="Reset" Runat="server"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp; 
                </TD>
                <TD align=right><A class=GuidaLink href="<%//= HelpLink %>" 
                  target=_blank>Guida</A></TD></TR></TABLE>
											</COLLAPSE:DATAPANEL></TD>
									</TR>
									<TR>
										<TD vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" AutoGenerateColumns="False"
												GridLines="Vertical" BorderWidth="1px" BorderColor="Gray" AllowPaging="True" AllowCustomPaging="True">
												<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:TemplateColumn HeaderText="&lt;input id='ChkSelTutti' type='Checkbox' onclick='SelCheckbox()'&gt;">
														<HeaderStyle HorizontalAlign="Center" Width="3%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:CheckBox ID="ChkSel" Runat="server"></asp:CheckBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="Codice_Edificio" HeaderText="Edificio">
														<HeaderStyle Width="20%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="ID_BL" HeaderText="Id_BL">
														<HeaderStyle Width="5%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="Id_Ditta" HeaderText="Id_Ditta">
														<HeaderStyle Width="17%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Ditta" HeaderText="Ditta">
														<HeaderStyle Width="20%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="Id_Servizio" HeaderText="IdServizio"></asp:BoundColumn>
													<asp:BoundColumn DataField="Servizio" HeaderText="Servizio">
														<HeaderStyle Width="20%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn HeaderText="Addetto">
														<HeaderStyle Width="20%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:Label Id="LblAddetto" Runat="server"></asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="DATASTART" HeaderText="Data Inizio"></asp:BoundColumn>
													<asp:TemplateColumn HeaderText="Data Inizio">
														<HeaderStyle Width="20%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<uc1:UserMeseGiorno id="UserMeseGiorno1" runat="server"></uc1:UserMeseGiorno>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="Addetto" HeaderText="Addetto">
														<HeaderStyle Width="20%"></HeaderStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Left" CssClass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
									<asp:panel id="PanelAddetto" runat="server" Visible="False">
        <TR>
          <TD colSpan=2>
            <TABLE width="100%" border=1>
              <TR>
                <TD width="10%">Addetto</TD>
                <TD width="44%">
<cc1:s_combobox id=cmbsAddettoMod runat="server"></cc1:s_combobox></TD>
                <TD width="10%">
<asp:checkbox id=chkAbilitaData runat="server"></asp:checkbox></TD>
                <TD width="20%">
<uc1:usermesegiorno id=UserMeseGiorno2 runat="server"></uc1:usermesegiorno></TD>
                <TD width="6%">
<cc1:s_button id=btnsConfermaSelezioni runat="server" CssClass="btn" Text="Conferma Selezioni"></cc1:s_button></TD>
              <TR></TR></TABLE>
            <TABLE width="100%" align=center border=1>
              <TR>
                <TD style="WIDTH: 138px" width="10%">
<cc1:s_button id=btnsSalva runat="server" CssClass="btn" Width="120px" Text="SALVA"></cc1:s_button></TD>
                <TD width="20%">
<cc1:s_button id=btnsSelezionaTutti runat="server" CssClass="btn" Text="Seleziona Tutti"></cc1:s_button></TD>
                <TD width="50%">
<asp:label id=LblElementiSelezionati runat="server">0</asp:label></TD>
                <TD align=right width="20%">
<cc1:s_button id=btnsDeSelezionaTutti runat="server" CssClass="btn" Text="Deseleziona Tutti"></cc1:s_button></TD></TR></TABLE></TD></TR>
									</asp:panel></TBODY></TABLE>
						</TD>
					</TR>
					<tr>
						<td vAlign="bottom"><uc1:bottommenu2 id="BottomMenu1" runat="server"></uc1:bottommenu2></td>
					</tr>
				</TBODY>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
