<%@ Page language="c#" Codebehind="TipologiaDitta.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.TipologiaDitta" %>
<%@ Register TagPrefix="uc2" TagName="RicercaAnagrafica" Src="RicercaAnagrafica.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TipologiaDitta</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc2:RicercaAnagrafica id="RicercaAnagrafica1" runat="server"></uc2:RicercaAnagrafica>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
