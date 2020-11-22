<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="cr1" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Page language="c#" Codebehind="DisplayReport.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnalisiStatistiche.DysplayReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>DysplayReport</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript">
		/*function PrintWindow()
		{ 
			if (navigator.appName == "Microsoft Internet Explorer") 
			{ 
    			var PrintCommand = '<O B J E C T ID="PrintCommandObject" WIDTH=0 HEIGHT=0 ';
				PrintCommand += 'CLASSID="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2">';
    			document.body.insertAdjacentHTML('beforeEnd', PrintCommand); 
    			PrintCommandObject.ExecWB(6, -1); PrintCommandObject.outerHTML = ""; 
    		} 
			else 
			{ 
			window.print();
			} 
		} 
		
		var gAutoPrint = true; // Flag for whether or not to automatically call the print function
		function printSpecial() 
		{
			if (document.getElementById != null) 
			{
				var html = '\n\n'; 
				if (document.getElementsByTagName != null) 
				{ 
					var headTags = document.getElementsByTagName("head"); 
					if (headTags.length > 0) 
						html += headTags[0].innerHTML;
				} 
				html += '\n< / H E A D >\n< B O D Y>\n';
				var printReadyElem = document.getElementById("printReady"); 
				if (printReadyElem != null) 
				{ 
					html += printReadyElem.innerHTML; } 
				else 
				{ 
					alert("Could not find the printReady section in the HTML"); 
					return; 
				} 
				html += '\n</ B Y D O>\n</ T L M H>'; 
				var printWin = window.open("","printSpecial"); 
				printWin.document.open(); 
				printWin.document.write(html); 
				printWin.document.close(); 
				if (gAutoPrint) 
					printWin.print(); 
			}
			else 
			{ 
				alert("Sorry, the print ready feature is only available in modern browsers."); 
			} 
		}
		*/
		</SCRIPT>
	</HEAD>
	<BODY>
		<FORM id="FrmReport" method="post" runat="server">
			<TABLE id="tblMain" cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
				<!--TR>
					<TD>
						<INPUT type="button" value="Stampa" onclick="PrintWindow();"> <INPUT type="button" value="printSprcial" onclick="printSpecial();">
					</TD>
				</TR-->
				<TR>
					<TD>
						<CR1:CRYSTALREPORTVIEWER id="rptEngineOra" runat="server" borderstyle="None" width="350px" height="50px"
							enabledrilldown="False" hasdrillupbutton="False" hassearchbutton="False"></CR1:CRYSTALREPORTVIEWER>
					</TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
