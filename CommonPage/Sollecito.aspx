<%@ Page language="c#" Codebehind="Sollecito.aspx.cs" AutoEventWireup="false" Inherits="TheSite.CommonPage.Sollecito" %>
<%@ Register TagPrefix="uc1" TagName="RichiedentiSollecito" Src="../WebControls/RichiedentiSollecito.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="Richiedenti" Src="../WebControls/Richiedenti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ListaMatricole</title>
<META http-equiv=Content-Type content="text/html; charset=windows-1252">
<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../Css/MainSheet.css" type=text/css rel=stylesheet >
<script language=javascript>
		var NS4 = (navigator.appName == "Netscape" && parseInt(navigator.appVersion) < 5);
		var NSX = (navigator.appName == "Netscape");
		var IE4 = (document.all) ? true : false;

		function Chiudi()
		{
			var oVDiv=parent.document.getElementById("PopupAddSoll").style;
			oVDiv.display = 'none';
		}
	/*	function seleziona(sender)
		{
		 parent.document.getElementById(idmodulo + "_" + "txtfascicolo").value=sender;
		 Chiudi();
		}
	*/
	
			function ControllaRichiedente(nome, cognome)
			{
				if (document.getElementById(nome).value == "" || document.getElementById(cognome).value == "")				
				{
					alert('Inserire il dati del Richiedente');
					return false;
				}
				return true;
			}	
	
		</script>
</HEAD>
<body MS_POSITIONING="GridLayout">
<form id=Form1 method=post runat="server">
<TABLE id=Table1 style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" 
cellSpacing=0 cellPadding=0 width="100%" border=0>
  <TR>
    <TD class=TDCommon><asp:hyperlink id=HyperLink1 runat="server" NavigateUrl="javascript:Chiudi()" Height="16px" Width="56px"><img border="0" src="../Images/chiudi.gif" /></asp:hyperlink></TD></TR>
  <TR>
    <TD>
      <P>&nbsp;</P>
      <P>
      <TABLE id=tblSearch100 border=0>
        <tr>
          <td><asp:panel id=PanelEdit 
             runat="server" Height="56px" Width="100%">
            <TABLE width="100%">
              <TR>
                <TD colSpan=2>
<uc1:RichiedentiSollecito id=RichiedentiSollecito1 runat="server"></uc1:RichiedentiSollecito></TD>
              <TR>
                <TD align=left>Motivazione</TD>
                <TD>
<cc1:S_TextBox id=txtsMotivo runat="server" Width="270px" DBSize="4000" DBDirection="Input" DBParameterName="p_Motivo" DBIndex="3"></cc1:S_TextBox></TD></TR></TABLE></asp:panel></TD></TR>
        <TR>
          <TD align=left>&nbsp; <cc1:s_button id=btnsAggiungi tabIndex=4 runat="server" Text="Aggiungi"></cc1:s_button></TD></TR></TABLE></P></TD></TR>
  <TR>
    <TD class=TDCommon><asp:hyperlink id=Hyperlink2 runat="server" NavigateUrl="javascript:Chiudi()" Height="16px" Width="56px"><img border="0" src="../Images/chiudi.gif" /></asp:hyperlink></TD></TR></TABLE></FORM>
	</body>
</HTML>
