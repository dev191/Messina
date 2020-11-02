<%@ Register TagPrefix="cc1" Namespace="arTreeMenu" Assembly="arTreeMenu" %>
<%@ Page language="c#" Codebehind="LeftFrame.aspx.cs" AutoEventWireup="false" Inherits="TheSite.LeftFrame" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>LeftFrame</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<STYLE type="text/css">
		HTML { BACKGROUND-COLOR: #ffffff }
		BODY { BACKGROUND-COLOR: #e7e4f7 }
		.mainsection { BORDER-RIGHT: #434367 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: #434367 1px solid; MARGIN-TOP: 0px; DISPLAY: block; PADDING-LEFT: 1px; FONT-WEIGHT: bold; FONT-SIZE: 11px; MARGIN-BOTTOM: 0px; PADDING-BOTTOM: 1px; MARGIN-LEFT: 0px; BORDER-LEFT: #434367 1px solid; COLOR: #300f76; PADDING-TOP: 1px; BORDER-BOTTOM: #434367 1px solid; BACKGROUND-REPEAT: repeat-x; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: #f0f0f0; TEXT-DECORATION: none }
		.mainsection:hover { COLOR: #ffffff; BACKGROUND-COLOR: #a60a0b; TEXT-DECORATION: none }
		.subsection { BORDER-RIGHT: black 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: black 1px solid; MARGIN-TOP: 0px; DISPLAY: block; PADDING-LEFT: 1px; FONT-WEIGHT: bold; FONT-SIZE: 11px; MARGIN-BOTTOM: 0px; PADDING-BOTTOM: 1px; MARGIN-LEFT: 0px; BORDER-LEFT: black 1px solid; COLOR: black; PADDING-TOP: 1px; BORDER-BOTTOM: black 1px solid; BACKGROUND-REPEAT: repeat-x; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: white; TEXT-DECORATION: none }
		.subsection:hover { COLOR: #ffffff; BACKGROUND-COLOR: #0e737b; TEXT-DECORATION: none }
		.subsection2 { PADDING-RIGHT: 1px; MARGIN-TOP: 1px; DISPLAY: block; PADDING-LEFT: 5px; FONT-WEIGHT: bold; FONT-SIZE: 10px; BACKGROUND-IMAGE: url(images/bot3.jpg); PADDING-BOTTOM: 3px; COLOR: #d7e4f3; PADDING-TOP: 2px; FONT-FAMILY: Tahoma; TEXT-DECORATION: none }
		.subsection2 A:hover { COLOR: #ffffff }
		INPUT { BORDER-RIGHT: #39669d 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #39669d 1px solid; PADDING-LEFT: 2px; FONT-WEIGHT: normal; FONT-SIZE: 11px; PADDING-BOTTOM: 1px; BORDER-LEFT: #39669d 1px solid; COLOR: #39669d; LINE-HEIGHT: 6px; PADDING-TOP: 4px; BORDER-BOTTOM: #39669d 1px solid; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: #a60a0b }
		.Stile1 { FONT-WEIGHT: normal; FONT-SIZE: 12px; COLOR: #5b7eab; FONT-FAMILY: Arial, Helvetica, sans-serif }
		.Spacer { BACKGROUND-COLOR: transparent }
		</STYLE>
		<SCRIPT language="javascript">		
		//alert(parent.left); 
		 if (typeof(parent.left) != "undefined")
		 {
		   //top.document.location.href='Default.aspx'
		  }
		  
		  		
		function valorizza()
		{	
			//alert("BRA");
			ts = new Date();							
			//Aggiungere le caselle relative a anno mese e giorno
			document.getElementById("TxtOraServer").value=ts.getHours();
			document.getElementById("TxtMinutiServer").value=ts.getMinutes();
			document.getElementById("TxtSecondiServer").value=ts.getSeconds();
			document.getElementById("TxtMSecondiServer").value=ts.getMilliseconds();					
		}	
						
		function calcola()
		{	
	
			t = new Date();
			
			anno=t.getFullYear();
			mese=t.getMonth();
			giorno=t.getDay();
			ora =t.getHours();
			minuti=t.getMinutes();
			secondi=t.getSeconds();
			m_secondi=t.getMilliseconds();	
			
			//Aggiungere le caselle relative a anno mese e giorno
			document.getElementById("TxtOra2").value=ora;
			document.getElementById("TxtMinuti2").value=minuti;
			document.getElementById("TxtSecondi2").value=secondi;
			document.getElementById("TxtMSecondi2").value=m_secondi;
			
			ora_start = document.getElementById("TxtOraServer").value;
			minuti_start= document.getElementById("TxtMinutiServer").value;
			secondi_start= document.getElementById("TxtSecondiServer").value;
			msecondi_start=document.getElementById("TxtMSecondiServer").value;
			
			d1 = new Date(anno,mese,giorno,ora_start,minuti_start,secondi_start,msecondi_start);
			d2 = new Date(anno,mese,giorno,ora,minuti,secondi,m_secondi);
			
			tempo_di_esecuzione = (d2 - d1)/1000;
			
			 self.status=" - Tempo totale di esecuzione Totale: " + tempo_di_esecuzione.toString() + " secondi - "					
		//	alert(self.status);
		}	
		</SCRIPT>
	</HEAD>
	<BODY bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" ms_positioning="GridLayout"
		bgcolor="gainsboro">
		<FORM id="Form1" method="post" runat="server">
			<TABLE width="100%" height="100%" border="0" align="center" cellpadding="1" cellspacing="0">
				<TR>
					<TD height="1">&nbsp;</TD>
				</TR>
				<TR height="90%">
					<TD id="tdMenu" align="left" height="394" style="HEIGHT: 394px">
						<CC1:TREEMENU id="TreeMenu1" runat="server" width="150px" borderwidth="0px"></CC1:TREEMENU></TD>
					</TD>
				</TR>
				<TR>
					<TD height="1" valign="bottom">&nbsp;</TD>
				</TR>
			</TABLE>
			<!-- Calcolo Tempo Client -->
			<table style="DISPLAY:none">
				<tr>
					<td>
						<asp:Label id="Label5" runat="server">Ora:</asp:Label>
						<asp:TextBox id="TxtOraServer" runat="server"></asp:TextBox>
					</td>
					<td>
						<asp:Label id="Label6" runat="server">Minuti:</asp:Label>
						<asp:TextBox id="TxtMinutiServer" runat="server"></asp:TextBox>
					</td>
					<td>
						<asp:Label id="Label7" runat="server">Secondi:</asp:Label>
						<asp:TextBox id="TxtSecondiServer" runat="server"></asp:TextBox>
					</td>
					<td>
						<asp:Label id="Label8" runat="server">Millisecondi:</asp:Label>
						<asp:TextBox id="TxtMSecondiServer" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label1" runat="server">Ora:</asp:Label>
						<asp:TextBox id="TxtOra2" runat="server"></asp:TextBox>
					</td>
					<td>
						<asp:Label id="Label2" runat="server">Minuti:</asp:Label>
						<asp:TextBox id="TxtMinuti2" runat="server"></asp:TextBox>
					</td>
					<td>
						<asp:Label id="Label3" runat="server">Secondi:</asp:Label>
						<asp:TextBox id="TxtSecondi2" runat="server"></asp:TextBox>
					</td>
					<td>
						<asp:Label id="Label4" runat="server">Millisecondi:</asp:Label>
						<asp:TextBox id="TxtMSecondi2" runat="server"></asp:TextBox>
					</td>
				</tr>
			</table>
		</FORM>
	</BODY>
</HTML>
