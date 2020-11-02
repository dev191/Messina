<%@ Page language="c#" Codebehind="CostoMateriali.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorrettiva.CostoMateriali" %>
<%@ Register TagPrefix="uc1" TagName="materiali" Src="../WebControls/materiali.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CostoMateriali</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">

function ImpostaTotale()
{
	parent.opener.ImpostaTotMateriali(document.getElementById('mtImpegnati1_lblTot').innerText );
}
		</SCRIPT>
	</HEAD>
	<body onbeforeunload="ImpostaTotale();">
		<form id="Form1" method="post" runat="server">
			<table id="tblSearch100" width="100%">
				<tr>
					<td>
						<UC1:MATERIALI id="mtImpegnati1" runat="server" width="100%"></UC1:MATERIALI>
					</td>
				</tr>
				<TR>
					<TD align="center">
						<INPUT id="btnclose" onclick="javascript:window.close();" type="button" value="Chiudi"
							name="btnclose"></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
