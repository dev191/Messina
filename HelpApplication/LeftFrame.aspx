<%@ Page language="c#" Codebehind="LeftFrame.aspx.cs" AutoEventWireup="false" Inherits="HelpApplication.LeftFrame" %>
<%@ Register TagPrefix="cc1" Namespace="arTreeMenu" Assembly="arTreeMenu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LeftFrame</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">
		html,body{
			background-color:  #93B9EC;
		}
		.mainsection {
			border-right: slategray 1px solid;
			padding-right: 1px;
			border-top: slategray 1px solid;
			margin-top: 0px;
			display: block;
			padding-left: 1px;
			font-size: 11px;
			font-weight: bold;
			margin-bottom: 0px;
			padding-bottom: 1px;
			margin-left: 0px;
			border-left: slategray 1px solid;
			color: #FFFF66;
			padding-top: 1px;
			border-bottom: slategray 1px solid;
			background-repeat: repeat-x;
			font-family: Verdana, Arial;
			background-color: lightslategray;
			filter:progid:DXImageTransform.Microsoft.Gradient
			(GradientType=0, StartColorStr='#005ebb', EndColorStr='#005ebb');

			text-decoration: none;
		 } 
		.mainsection:hover { 
			COLOR: #FFFF66; 
			background-color: #4d73a6;
			TEXT-DECORATION: none 
		} 
		.subsection { 
			BORDER-RIGHT: gainsboro 1px solid; 
			PADDING-RIGHT: 1px; 
			BORDER-TOP: gainsboro 1px solid; 
			MARGIN-TOP: 0px; 
			DISPLAY: block; 
			PADDING-LEFT: 1px; 
			FONT-SIZE: 11px;
			font-weight: bold;
			MARGIN-BOTTOM: 0px; 
			PADDING-BOTTOM: 1px; 
			MARGIN-LEFT: 0px; 
			BORDER-LEFT: gainsboro 1px solid; 
			COLOR: #FFFF66; 
			PADDING-TOP: 1px; 
			BORDER-BOTTOM: gainsboro 1px solid; 
			BACKGROUND-REPEAT: repeat-x; 
			FONT-FAMILY: Verdana, Arial; 
			BACKGROUND-COLOR: #237BAF; 
			TEXT-DECORATION: none 
		} 
		.subsection:hover { 
			COLOR: #FFFF66; 
			background-color: #4d73a6;
			TEXT-DECORATION: none 
		} 
		
		.subsection2 { PADDING-RIGHT: 1px; MARGIN-TOP: 1px; DISPLAY: block; PADDING-LEFT: 5px; FONT-WEIGHT: bold; FONT-SIZE: 10px; BACKGROUND-IMAGE: url(images/bot3.jpg); PADDING-BOTTOM: 3px; COLOR: #d7e4f3; PADDING-TOP: 2px; FONT-FAMILY: Tahoma; TEXT-DECORATION: none } 
		.subsection2 A:hover { COLOR: #ffffff } 
		INPUT { BORDER-RIGHT: #39669d 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #39669d 1px solid; PADDING-LEFT: 2px; FONT-WEIGHT: normal; FONT-SIZE: 11px; PADDING-BOTTOM: 1px; BORDER-LEFT: #39669d 1px solid; COLOR: #39669d; LINE-HEIGHT: 6px; PADDING-TOP: 4px; BORDER-BOTTOM: #39669d 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: #eff3f7 } 
		.Stile1 { FONT-WEIGHT: normal; FONT-SIZE: 12px; COLOR: #5b7eab; FONT-FAMILY: Arial, Helvetica, sans-serif } 
		.Spacer { BACKGROUND-COLOR: transparent } 
		</style>
			<SCRIPT language="javascript">		
				  		
		function valorizza()	{}	
						
		function calcola()	{}	
		</SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout"
		bgcolor="gainsboro">
		<form id="Form1" method="post" runat="server">
			<table width="100%" height="100%" border="0" align="center" cellpadding="1" cellspacing="0">
				<tr>
					<td height="1">&nbsp;</td>
				</tr>
				<tr height="90%">
					<td id="tdMenu" align="left" height="442" style="HEIGHT: 442px">
						<P>
							<cc1:treemenu id="TreeMenu1" runat="server" Width="150px" BorderWidth="0px"></cc1:treemenu></P>
					</td>
					</TD>
				</tr>
				<tr>
					<td height="1" valign="bottom">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
