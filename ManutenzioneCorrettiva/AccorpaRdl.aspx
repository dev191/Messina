<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Page language="c#" Codebehind="AccorpaRdl.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorretiva.AccorpaRdl" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Addetti" Src="../WebControls/Addetti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>AccorpaRdl</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
		var NS4 = (navigator.appName == "Netscape" && parseInt(navigator.appVersion) < 5);
		var NSX = (navigator.appName == "Netscape");
		var IE4 = (document.all) ? true : false;
		
			
			
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
			function validaContenuto()
			{
			  var crt=document.getElementById('<%=txtRdl.ClientID%>') 
			  if(crt.value=="")
			  {
			   alert("E' necessario indicare una richiesta accorpante valida!");
			   crt.focus();
			   return false;
			  }
			}
			
			 function seleziona(sender)
			{
			  var crt=document.getElementById('<%=txtRdl.ClientID%>').value =sender;
			}
		</SCRIPT>
</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" style="WIDTH: 400px; HEIGHT: 88px" cellSpacing="1" cellPadding="1" width="400"
							border="0">
							<TR>
								<TD>Selezionare la Rdl&nbsp;Accorpante:</TD>
								<TD><cc1:s_textbox id="txtRdl" runat="server" Width="76px"></cc1:s_textbox></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD><asp:linkbutton id="VisualAccorpate" runat="server">Visualizza Accorpate </asp:linkbutton></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD><asp:linkbutton id="RicAccorpante" runat="server">Filtro Ricerca Accorpante </asp:linkbutton></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD><asp:linkbutton id="RicAccorpate" runat="server">Filtro Ricerca Accorpate </asp:linkbutton></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><cc1:s_label id="lblDescription" runat="server"></cc1:s_label></TD>
				</TR>
				<TR>
					<TD><cc2:datapanel id="DataPanel1" runat="server" AllowTitleExpandCollapse="True" CollapseImageUrl="../Images/up.gif"
							CssClass="DataPanel75" CollapseText="Riduci" ExpandImageUrl="../Images/down.gif"
							ExpandText="Espandi" TitleText="Ricerca" Collapsed="False" TitleStyle-CssClass="TitleSearch">
      <TABLE id=tblSearch100 cellSpacing=1 cellPadding=1 width="100%" 
        border=0>
        <TR>
          <TD align=left colSpan=4>
<uc1:ricercamodulo id=RicercaModulo1 runat="server"></uc1:ricercamodulo></TD></TR>
        <TR>
          <TD align=left width="13%">Richiesta di Lavoro:</TD>
          <TD width="30%">
<cc1:s_textbox id=txtsRichiesta runat="server" DBParameterName="p_Wr_Id" DBDirection="Input" width="100px" DBSize="255" MaxLength="10" DBDataType="Integer" DBIndex="2"></cc1:s_textbox></TD>
          <TD align=left width="15%">Addetto:</TD>
          <TD width="30%">
<uc1:addetti id=Addetti1 runat="server"></uc1:addetti></TD></TR>
        <TR>
          <TD align=left>Data Da:</TD>
          <TD>
<uc1:calendarpicker id=CalendarPicker1 runat="server"></uc1:calendarpicker></TD>
          <TD align=left>Data A:</TD>
          <TD>
<uc1:calendarpicker id=CalendarPicker2 runat="server"></uc1:calendarpicker>
<asp:comparevalidator id=CompareValidator1 runat="server" Type="Date" Operator="GreaterThanEqual" ErrorMessage="Data non valida!"></asp:comparevalidator></TD></TR>
        <TR>
          <TD align=left>Ordine di Lavoro:</TD>
          <TD>
<cc1:s_textbox id=txtsOrdine runat="server" DBParameterName="p_Wr_Id" DBDirection="Input" width="100px" DBSize="255" MaxLength="10"></cc1:s_textbox></TD>
          <TD align=left></TD>
          <TD></TD></TR>
        <TR>
          <TD align=left>Servizio:</TD>
          <TD>
<cc1:s_combobox id=cmbsServizio runat="server" Width="99%"></cc1:s_combobox></TD>
          <TD align=left>
<cc1:S_Label id=lblStato runat="server">Stato Richiesta:</cc1:S_Label></TD>
          <TD>
<cc1:s_combobox id=cmbsStatus runat="server" Width="99%"></cc1:s_combobox></TD></TR>
        <TR>
          <TD align=left>Richiedente:</TD>
          <TD>
<uc1:richiedenti id=Richiedenti1 runat="server"></uc1:richiedenti></TD>
          <TD align=left>Urgenza:</TD>
          <TD>
<cc1:s_combobox id=cmbsUrgenza runat="server" Width="99%"></cc1:s_combobox></TD></TR>
        <TR>
          <TD align=left>Descrizione:</TD>
          <TD>
<cc1:s_textbox id=txtDescrizione runat="server" DBParameterName="p_Wr_Id" DBDirection="Input" width="99%" DBSize="255" MaxLength="255"></cc1:s_textbox></TD>
          <TD align=left>Gruppo:</TD>
          <TD>
<cc1:s_combobox id=cmbsGruppo runat="server" Width="99%"></cc1:s_combobox></TD></TR>
        <TR>
          <TD style="HEIGHT: 16px" align=left colSpan=4></TD></TR>
        <TR>
          <TD align=left colSpan=3>
<cc1:s_button id=btnsRicerca tabIndex=2 runat="server" Text="Ricerca"></cc1:s_button>&nbsp;&nbsp; 
<cc1:S_Button id=btReset runat="server" Text="Reset"></cc1:S_Button></TD>
          <TD align=right><A class=GuidaLink href="<%= HelpLink %>" 
            target=_blank>Guida</A></TD></TR></TABLE><INPUT id=HiddenVisible 
      style="WIDTH: 56px; HEIGHT: 18px" type=hidden size=4 runat="server">
						</cc2:datapanel></TD>
				</TR>
				<TR>
					<TD><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" Width="100%" CssClass="DataGrid" BorderColor="Gray"
							BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False" AllowPaging="True" GridLines="Vertical">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Sel.">
									<ItemTemplate>
										<asp:CheckBox Runat="server" ID="ckaccorpate"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Ord. di Lavoro">
									<ItemTemplate>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Edificio" HeaderText="Edificio"></asp:BoundColumn>
								<asp:BoundColumn DataField="WR" HeaderText="Ric. di Lavoro"></asp:BoundColumn>
								<asp:BoundColumn DataField="Servizio" HeaderText="Servizio"></asp:BoundColumn>
								<asp:BoundColumn DataField="Data" HeaderText="Data Emissione" DataFormatString="{0:d}"></asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Priority" HeaderText="Priorit&#224;"></asp:BoundColumn>
								<asp:BoundColumn DataField="Ditta" HeaderText="Ditta"></asp:BoundColumn>
								<asp:BoundColumn DataField="Richiedente" HeaderText="Richiedente"></asp:BoundColumn>
								<asp:BoundColumn DataField="Gruppo" HeaderText="Gruppo"></asp:BoundColumn>
								<asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
						<TABLE id="TableAccorpa" cellSpacing="1" cellPadding="1" width="300" border="0" runat="server">
							<TR>
								<TD>
									<cc1:S_Button id="btAccorpa" runat="server" Text="Accorpa"></cc1:S_Button></TD>
								<TD>Accorpa in:
									<cc1:S_Label id="lblPadreAccorpante" runat="server"></cc1:S_Label></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
