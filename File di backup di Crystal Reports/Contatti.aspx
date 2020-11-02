<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Page language="c#" Codebehind="Contatti.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.Contatti" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>EditRuoli</title>
<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../Css/MainSheet.css" type=text/css rel=stylesheet >
<script language=javascript>	
		function SoloNumeri()
		{	
			if (event.keyCode < 48	|| event.keyCode > 57){
				event.keyCode = 0;
			}	
		}
		function nonpaste()
		{
			return false;
		}	
		
		</script>
</HEAD>
<body onbeforeunload="parent.left.valorizza()" bottomMargin=0 leftMargin=5 topMargin=0 rightMargin=0 
MS_POSITIONING="GridLayout">
<form id=Form1 method=post runat="server">
<TABLE id=TableMain 
style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%" 
cellSpacing=0 cellPadding=0 width="100%" align=center border=0>
  <TR>
    <TD style="HEIGHT: 50px" align=center><uc1:pagetitle id=PageTitle1 title="Gestione Contatti" runat="server"></uc1:pagetitle></TD></TR>
  <TR>
    <TD vAlign=top align=center height="95%">
      <TABLE id=tblFormInput cellSpacing=1 cellPadding=1 align=center 
      >
        <TR>
          <TD style="WIDTH: 5%; HEIGHT: 5%" vAlign=top align=left 
          ></TD>
          <TD style="HEIGHT: 5%" vAlign=top align=left><asp:label id=lblOperazione runat="server" CssClass="TitleOperazione"></asp:label>&nbsp;<MESSPANEL:MESSAGEPANEL 
            id=PanelMess runat="server" 
            ErrorIconUrl="~/Images/ico_critical.gif" 
            MessageIconUrl="~/Images/ico_info.gif"></MESSPANEL:MESSAGEPANEL></TD></TR>
        <TR>
          <TD style="HEIGHT: 5%" vAlign=top align=left></TD>
          <TD style="HEIGHT: 5%" vAlign=top align=left 
            ><asp:panel id=PanelEdit 
            runat="server">
            <TABLE id=tblSearch75 cellSpacing=1 cellPadding=2 border=0>
              <TR>
                <TD align=left>Nome</TD>
                <TD>
<cc1:S_TextBox id=txtsNome tabIndex=1 runat="server" DBDirection="Input" DBSize="128" DBParameterName="p_nome" DBIndex="1" width="90%" Enabled="False"></cc1:S_TextBox></TD></TR>
              <TR>
                <TD align=left>Cognome</TD>
                <TD>
<cc1:S_TextBox id=txtsCognome tabIndex=2 runat="server" DBDirection="Input" DBSize="255" DBParameterName="p_cognome" DBIndex="2" Enabled="False" DBDataType="VarChar"></cc1:S_TextBox></TD></TR>
              <TR>
                <TD align=left>Gruppo</TD>
                <TD>
<cc1:S_ComboBox id=cmbsGruppo runat="server" DBParameterName="p_idGruppo" DBIndex="3" Enabled="False" DBDataType="Integer" AutoPostBack="False" Width="196px"></cc1:S_ComboBox></TD></TR></TABLE></asp:panel></TD></TR>
        <TR>
          <TD style="HEIGHT: 5%" vAlign=top align=left></TD>
          <TD style="HEIGHT: 5%" vAlign=top align=left 
        ></TD></TR>
        <TR>
          <TD style="HEIGHT: 5%" vAlign=top align=left></TD>
          <TD style="HEIGHT: 5%" vAlign=top align=left 
            >&nbsp;&nbsp;&nbsp; </TD></TR>
        <TR>
          <TD style="HEIGHT: 5%" vAlign=top align=left></TD>
          <TD style="HEIGHT: 5%" vAlign=top align=left>
            <TABLE id=tblGridTitle cellSpacing=1 cellPadding=1 border=0 
            >
              <TR>
                <TD width="20%"><asp:linkbutton id=lkbNuovo runat="server" CssClass="NuovoLink">Nuovo</asp:linkbutton></TD>
                <TD width="60%"></TD>
                <TD align=center width="20%">Record: <asp:label id=lblRecord runat="server">0</asp:label></TD></TR></TABLE><ASP:DATAGRID id=DataGridEsegui runat="server" CssClass="DataGrid" OnDeleteCommand="jskDataGrid_Delete" OnEditCommand="jskDataGrid_Edit" OnCancelCommand="jskDataGrid_Cancel" OnUpdateCommand="jskDataGrid_Update" AutoGenerateColumns="False" DataKeyField="ID" BorderColor="Gray" ShowFooter="false">
										<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<FooterTemplate>
													<asp:ImageButton Title="Salva" id="Imagebutton1" runat="server" CommandName="Update" ImageUrl="../Images/salva.gif"></asp:ImageButton>
													<asp:ImageButton Title="Annulla" id="Imagebutton2" runat="server" CommandName="Cancel" ImageUrl="../Images/annulla.gif"></asp:ImageButton>
												</FooterTemplate>
												<ItemTemplate>
													<asp:ImageButton Title="Modifica" id="imbEdit" runat="server" ImageUrl="../Images/edit.gif" CommandName="Edit"></asp:ImageButton>
													<asp:ImageButton Title="Elimina" id="imbDelete" runat="server" ImageUrl="../Images/elimina.gif" CommandName="Delete" 
 CausesValidation="False"></asp:ImageButton>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:ImageButton Title="Salva" id="imbUpdate" runat="server" CommandName="Update" ImageUrl="../Images/salva.gif"></asp:ImageButton>
													<asp:ImageButton Title="Annulla" id="imbCancel" runat="server" CommandName="Cancel" ImageUrl="../Images/annulla.gif"></asp:ImageButton>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID">
												<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Descrizione">
												<FooterTemplate>
													<cc1:S_TextBox id="txts_DescrizioneNew" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem, "DESCRIZIONE") %>' Height="100%">
													</cc1:S_TextBox>
												</FooterTemplate>
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "DESCRIZIONE") %>
												</ItemTemplate>
												<EditItemTemplate>
													<cc1:S_TextBox id=txts_DescrizioneEdit runat="server" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem, "DESCRIZIONE") %>' Height="100%">
													</cc1:S_TextBox>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Tipologia">
												<FooterTemplate>
													<asp:DropDownList ID="cmbsTipologia_New" DataTextField="descrizione" DataValueField="id" DataSource="<%# loadTipoContatti()%>" Runat="server">
													</asp:DropDownList>
												</FooterTemplate>
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "TIPOLOGIA") %>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:DropDownList ID="cmbsTipologia_Edit" DataTextField="descrizione" DataValueField="id" DataSource="<%# loadTipoContatti()%>" Runat="server" SelectedValue ='<%# GetTipoContattiID(Container.DataItem)%>'>
													</asp:DropDownList>
												</EditItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</ASP:DATAGRID></TD></TR>
        <TR>
          <TD style="HEIGHT: 5%" vAlign=top align=left></TD>
          <TD style="HEIGHT: 5%" vAlign=top align=left><asp:label id=lblMessaggi runat="server" CssClass="LabelErrore"></asp:label></TD></TR>
        <TR>
          <TD style="HEIGHT: 5%" vAlign=top align=left></TD>
          <TD style="HEIGHT: 5%" vAlign=top align=left><asp:button id=btnsAnnulla tabIndex=25 runat="server" CssClass="btn" CausesValidation="False" Text="Indietro"></asp:button></TD></TR>
        <TR>
          <TD style="HEIGHT: 1%" vAlign=top align=left></TD>
          <TD style="HEIGHT: 1%" vAlign=top align=left>
            <hr noShade SIZE=1>
          </TD></TR></TABLE></TD></TR></TABLE></FORM>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
