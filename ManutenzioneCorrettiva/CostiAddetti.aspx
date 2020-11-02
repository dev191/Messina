<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Page language="c#" Codebehind="CostiAddetti.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorrettiva.CostiAddetti" %>
<%@ Register TagPrefix="uc1" TagName="CostiManodopera" Src="../WebControls/CostiManodopera.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CostoMateriali</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">

		function ImpostaTotale() 
		{ 
			parent.opener.ImpostaTotAddetti(document.getElementById('CostiManodopera1_lblTot1').innerText);
		 } 
		</SCRIPT>
	</HEAD>
	<BODY onbeforeunload="ImpostaTotale();">
		<form id="Form1" method="post" runat="server">
			<table id="tblSearch100" width="100%">
				<tr>
					<td><uc1:costimanodopera id="CostiManodopera1" runat="server"></uc1:costimanodopera></td>
				</tr>
				<TR>
					<TD align="center">
						<INPUT id="btnclose" onclick="javascript:window.close();" type="button" value="Chiudi"
							name="btnclose"></TD>
				</TR>
			</table>
		</form>
		<P></P>
	</BODY>
</HTML>
