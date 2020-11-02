<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserRdlInailLabel" Src="../WebControls/UserRdlInailLabel.ascx" %>
<%@ Page language="c#" Codebehind="VisualizzaRdlEliminare.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorrettiva.VisualizzaRdlEliminare" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Edit Sfoglia</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<uc1:UserRdlInailLabel id="UserRdlInailLabel" runat="server"></uc1:UserRdlInailLabel></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
