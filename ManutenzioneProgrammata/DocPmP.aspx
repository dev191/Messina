<%@ Page language="c#" Codebehind="DocPmP.aspx.cs" AutoEventWireup="false" Inherits="TheSite.DocPmP" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DocPmP</title>
<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../Css/MainSheet.css" type=text/css rel=stylesheet >
<script language=javascript>
			function setvis()
			{
				var v=	document.getElementById('DrTipoDocumenti').value;
				if(v=="1" || v=="2")
				{
				  document.getElementById('lblMese').style.display="none";
				  document.getElementById('DropMese').style.display="none";
				}
				else
				{
				  document.getElementById('lblMese').style.display="block";
				  document.getElementById('DropMese').style.display="block";
				}
			}
		</script>
</HEAD>
<body onload=setvis() MS_POSITIONING="GridLayout">
<form id=Form1 method=post runat="server">
<TABLE id=Table1 style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" 
cellSpacing=1 cellPadding=1 width="100%" border=0>
  <TR>
    <TD align=center><uc1:pagetitle id=PageTitle1 runat="server"></uc1:pagetitle></TD></TR>
  <TR>
    <TD>
      <TABLE id=Table2 cellSpacing=0 cellPadding=0 width="100%" border=0 
      >
        <TR>
          <TD>Edificio:</TD>
          <TD><asp:dropdownlist id=DrEdifici runat="server" Width="280px"></asp:dropdownlist></TD>
          <TD>Tipo Documento:</TD>
          <TD><asp:dropdownlist id=DrTipoDocumenti runat="server" Width="280px">
										<asp:ListItem Value="1">Piano Annuale Proposto</asp:ListItem>
										<asp:ListItem Value="2">Piano Annuale Accettato</asp:ListItem>
										<asp:ListItem Value="3">Programma Mensile Proposto</asp:ListItem>
										<asp:ListItem Value="4">Programma Mensile Eseguito</asp:ListItem>
										<asp:ListItem Value="5">Programma Mensile Accettato</asp:ListItem>
									</asp:dropdownlist></TD></TR>
        <TR id=trvi>
          <TD><asp:label id=lblAnno runat="server">Anno:</asp:label></TD>
          <TD><asp:dropdownlist id=DropAnno runat="server" Width="128px"></asp:dropdownlist></TD>
          <TD><asp:label id=lblMese runat="server">Mese:</asp:label></TD>
          <TD><asp:dropdownlist id=DropMese runat="server" Width="176px">
										<asp:ListItem Value="1">Gennaio</asp:ListItem>
										<asp:ListItem Value="2">Febbraio</asp:ListItem>
										<asp:ListItem Value="3">Marzo</asp:ListItem>
										<asp:ListItem Value="4">Aprile</asp:ListItem>
										<asp:ListItem Value="5">Maggio</asp:ListItem>
										<asp:ListItem Value="6">Giugno</asp:ListItem>
										<asp:ListItem Value="7">Luglio</asp:ListItem>
										<asp:ListItem Value="8">Agosto</asp:ListItem>
										<asp:ListItem Value="9">Settembre</asp:ListItem>
										<asp:ListItem Value="10">Ottobre</asp:ListItem>
										<asp:ListItem Value="11">Novembre</asp:ListItem>
										<asp:ListItem Value="12">Dicembre</asp:ListItem>
									</asp:dropdownlist></TD></TR>
        <TR>
          <TD>Notazioni:</TD>
          <TD colSpan=3><asp:textbox id=TxtAnnotazioni runat="server" Width="528px" TextMode="MultiLine"></asp:textbox></TD></TR>
        <TR>
          <TD>Invio Documento:</TD>
          <TD colSpan=3><INPUT id=UploadFile 
            title="Seleziona il documento da inviare." 
            style="WIDTH: 676px; HEIGHT: 22px" type=file size=93 name=UploadFile 
             runat="server">&nbsp; <asp:button id=BtInvia runat="server" Width="112px" Text="Salva Piano"></asp:button></TD></TR></TABLE></TD></TR>
  <TR>
    <TD><asp:label id=lblMessage runat="server" ForeColor="Red"></asp:label></TD></TR>
  <TR>
    <TD></TD></TR>
  <TR>
    <TD></TD></TR></TABLE></FORM>
	</body>
</HTML>
