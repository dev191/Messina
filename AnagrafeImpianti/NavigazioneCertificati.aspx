<%@ Register TagPrefix="cc2" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Page language="c#" Codebehind="NavigazioneCertificati.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.NavigazioneCertificati" %>
<%@ Register TagPrefix="uc1" TagName="Fascicolo" Src="../WebControls/Fascicolo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Matricole" Src="../WebControls/Matricole.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SelezioneCertificati</title>
		<meta content="True" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function expandcollapse(obj)
			{
				var selezione=obj.value;
				if(selezione == 3)//ispels
					{	
						tableispesel.style.visibility = "visible";
						tableispesel.style.display = "block";
						tablevvf.style.visibility = "hidden";
						tablevvf.style.display = "none";
					}
				else if(selezione == 2)//vvf
					{
						tableispesel.style.visibility = "hidden";
						tableispesel.style.display = "none";
						tablevvf.style.visibility = "visible";
						tablevvf.style.display = "block";
					}
				else 
				{
					tableispesel.style.visibility = "hidden";
					tableispesel.style.display = "none";
					tablevvf.style.visibility = "hidden";
					tablevvf.style.display = "none";
				}
			}
			
   function selezionedata(sender)
	 {
	   var crtlCombo=document.getElementById('<%=S_CbTipo.ClientID%>');
	   var ctrTextCodice=document.getElementById('<%=RicercaModulo1.TxtCodice.ClientID%>');
	   var ctrTextnomefile=document.getElementById('<%=S_Txtnomefile.ClientID%>');
	   var ctrTextdesc=document.getElementById('<%=S_Txtdescrizione.ClientID%>');
	   
	   if(crtlCombo.selectedIndex==0 && ctrTextCodice.value=="" && ctrTextnomefile.value==""
	   && ctrTextdesc.value=="")
	   {
	     alert("Inserire almento un criterio di ricerca in Cod.Edificio,Nome File,Descrizione File, Tipo.");
	     return false;
	   }
	 
	    var ctrl=document.getElementById(sender);
		/*if((tableispesel.style.visibility == "visible") || (tableispesel.style.display == "block"))
		{
			if ((ctrl.selectedIndex==-1) || (ctrl.selectedIndex==0)) 
			{
				alert("Selezionare l'anno!");
				return false;
			}
			else
			{
			return true;
			}
	   }*/
	 }
	 
	
		</script>
</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD><cc1:datapanel id="DataPanel1" runat="server" AllowTitleExpandCollapse="True" CollapseImageUrl="../Images/up.gif"
							CssClass="DataPanel75" CollapseText="Espandi/Riduci " ExpandImageUrl="../Images/down.gif" ExpandText="Espandi"
							TitleText="Ricerca" Collapsed="False" TitleStyle-CssClass="TitleSearch">
      <TABLE id=tblSearch100 cellSpacing=0 cellPadding=0 width="100%" 
        border=0>
        <TR>
          <TD align=center colSpan=2 rowSpan=1>
<uc1:RicercaModulo id=RicercaModulo1 runat="server"></uc1:RicercaModulo></TD></TR>
        <TR>
          <TD style="WIDTH: 325px">Nome File:</TD>
          <TD>
<cc2:S_TextBox id=S_Txtnomefile runat="server" Width="448px" DBDirection="Input" DBSize="50" DBParameterName="P_nomefile" DBIndex="2"></cc2:S_TextBox></TD></TR>
        <TR>
          <TD style="WIDTH: 325px">Descrizione File:</TD>
          <TD>
<cc2:S_TextBox id=S_Txtdescrizione runat="server" Width="448px" DBDirection="Input" DBSize="255" DBParameterName="P_desc_file" DBIndex="3"></cc2:S_TextBox></TD></TR>
        <TR>
          <TD style="WIDTH: 325px; HEIGHT: 27px">Tipo:</TD>
          <TD style="HEIGHT: 27px">
<cc2:S_ComboBox id=S_CbTipo runat="server" Width="248px" DBDirection="Input" DBSize="10" DBParameterName="P_tipo" DBIndex="4">
											<asp:ListItem Selected="True"></asp:ListItem>
											<asp:ListItem Value="6">ISPELS</asp:ListItem>
											<asp:ListItem Value="7">LEGGE 46/90</asp:ListItem>
											<asp:ListItem Value="8">VVF</asp:ListItem>
										</cc2:S_ComboBox></TD></TR>
        <TR>
          <TD style="WIDTH: 139px" colSpan=2>
            <TABLE id=tableispesel 
            style="DISPLAY: none; WIDTH: 400px; HEIGHT: 80px" cellSpacing=1 
            cellPadding=1 width=400 border=0 runat="server">
              <TR>
                <TD>Matricola ISPELS:</TD>
                <TD>
<uc1:Matricole id=Matricole1 runat="server"></uc1:Matricole></TD></TR>
              <TR>
                <TD>Data Prima Verifica:</TD>
                <TD>
<uc1:CalendarPicker id=CalendarPicker1 runat="server"></uc1:CalendarPicker></TD></TR>
              <TR>
                <TD>Anno Scadenza:</TD>
                <TD>
<cc2:S_ComboBox id=S_CbAnno runat="server" Width="128px" DBDirection="Input" DBSize="20" DBParameterName="P_text_year" DBIndex="7"></cc2:S_ComboBox></TD></TR></TABLE>
            <TABLE id=tablevvf style="DISPLAY: none; WIDTH: 400px; HEIGHT: 80px" 
            cellSpacing=1 cellPadding=1 width=400 border=0 runat="server">
              <TR>
                <TD>Numero Fascicolo:</TD>
                <TD>
<uc1:Fascicolo id=Fascicolo1 runat="server"></uc1:Fascicolo></TD></TR>
              <TR>
                <TD>Data Parere Favorevole:</TD>
                <TD>
<uc1:CalendarPicker id=CalendarPicker2 runat="server"></uc1:CalendarPicker></TD></TR>
              <TR>
                <TD>Verifica Collaudo:</TD>
                <TD>
<asp:CheckBox id=chscollaudo runat="server"></asp:CheckBox></TD></TR></TABLE></TD></TR>
        <TR>
          <TD style="WIDTH: 241px" colSpan=2>
            <TABLE id=Table2 style="WIDTH: 792px; HEIGHT: 35px" cellSpacing=0 
            cellPadding=0 width=792 border=0>
              <TR>
                <TD style="WIDTH: 280px" align=right>
<cc2:S_Button id=S_btRicerca runat="server" CssClass="btn" Width="130px" Text="Mostra Dettagli"></cc2:S_Button>&nbsp;</TD>
                <TD>&nbsp; 
<cc2:S_Button id=S_btReset runat="server" CssClass="btn" Width="130px" Text="Reset" CausesValidation="False"></cc2:S_Button></TD>
                <TD align=right><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD></TR></TABLE></TD></TR></TABLE>
						</cc1:datapanel></TD>
				</TR>
				<TR>
					<TD><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGrid1" runat="server" CssClass="DataGrid" Width="100%" BorderColor="Gray"
							BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False" AllowPaging="True" GridLines="Vertical" AllowCustomPaging="True">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton ImageUrl="../Images/edit.gif" Runat="server" OnCommand="imageButton_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"var_afm_dwgs_dwg_name") %>' ID="Imagebutton1">
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="bl_id" HeaderText="Cod.Edificio"></asp:BoundColumn>
								<asp:BoundColumn DataField="var_afm_dwgs_servizio" HeaderText="Servizio"></asp:BoundColumn>
								<asp:BoundColumn DataField="var_afm_dwgs_dwg_name" HeaderText="Nome File"></asp:BoundColumn>
								<asp:BoundColumn DataField="var_afm_dwgs_tipo" HeaderText="Tipo"></asp:BoundColumn>
								<asp:BoundColumn DataField="var_afm_dwgs_title" HeaderText="Descrizione"></asp:BoundColumn>
								<asp:BoundColumn DataField="var_afm_dwgs_n_fascicolo_vvf" HeaderText="Numero Fascicolo" DataFormatString="{0:d}"></asp:BoundColumn>
								<asp:BoundColumn DataField="var_afm_dwgs_data_p_fav" HeaderText="Data Parere Favorevole" DataFormatString="{0:d}"></asp:BoundColumn>
								<asp:BoundColumn DataField="var_afm_dwgs_collaudo" HeaderText="Collaudo">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="var_afm_dwgs_matricola_ispesl" HeaderText="Numero Matricola"></asp:BoundColumn>
								<asp:BoundColumn DataField="var_afm_dwgs_data_p_ver" HeaderText="Data Prima Verifica" DataFormatString="{0:d}"></asp:BoundColumn>
								<asp:BoundColumn DataField="var_afm_dwgs_anno_scadenza" HeaderText="Anno Scadenza"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
