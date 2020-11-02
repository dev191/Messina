<%@ Page language="c#" Codebehind="TopFrame.aspx.cs" AutoEventWireup="false" Inherits="WebCad.TopFrame" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>TopFrame</TITLE>
		<META name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<META name="CODE_LANGUAGE" content="C#">
		<META name="vs_defaultClientScript" content="JavaScript">
		<META name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
			//crtl=document.getElementById('<%=tbxBlClinetId%>').style; 
			//crtl.display="none";
			//crtl=document.getElementById('<%=tbxFlClinetId%>').style; 
			//crtl.display="none";
			function ViewHtml()
			{
				d=window.open();    
				d.document.open('text/plain').write(document.documentElement.outerHTML);
			}
			function SetPianoStanza(idEdificio,codiceEdificio,idPiano,desctrizionePiano){
				document.getElementById('lblPiano').innerText=desctrizionePiano;
				document.getElementById('lblEdificio').innerText=codiceEdificio;
				document.getElementById('<%=tbxBlClinetId%>').value=idEdificio;
				document.getElementById('<%=tbxFlClinetId%>').value=idPiano;
				return;
			}
			
			function SetPlanimetria(planimetria){
				document.getElementById('lblPlan').innerText=planimetria;
			}
			function getNomePiano(){
				return document.getElementById('lblPiano').innerText;
			}
			function getIdPiano()
			{
				return document.getElementById('<%=tbxFlClinetId%>').value;
			}
			function getIdEdificio()
			{
				return document.getElementById('<%=tbxBlClinetId%>').value;
			}
			function getNomeEdificio(){
				return document.getElementById('lblEdificio').innerText;
			}
			function DisableButton(id,enabled){
				document.getElementById(id).disabled=enabled
			}
		</SCRIPT>
		<SCRIPT language="vbscript">
		'	MsgBox window.parent.frames(2).name
		'next
		sub SetPlanimetria(planimetria)
			document.getElementById("lblPlan").innerText=planimetria
		end sub
		Function GetPlanimetria()
			GetPlanimetria=document.getElementById("lblPlan").innerText
		end function
		sub DisableButton(id)
			MsgBox id
			document.getElementById(id).disabled=true
		end sub
		sub EnableButton(id)
		MsgBox id
			document.getElementById(id).disabled=false
		end sub
		function SetPianoStanzaT(idEdificio,codiceEdificio,idPiano,desctrizionePiano)
				document.getElementById("lblPiano").innerText=desctrizionePiano
				document.getElementById("lblEdificio").innerText=codiceEdificio
				document.getElementById("<%=tbxBlClinetId%>").value=idEdificio
				document.getElementById("<%=tbxFlClinetId%>").value=idPiano
		end function
		sub setServizio(srv)
			document.getElementById("lblServizio").innerText=srv
		end sub
		sub setIdServizio(idServwzio)
			document.getElementById("TxtIdServizio").value = idServwzio
		end sub
		</SCRIPT>
		<SCRIPT language="javascript">
		function clearServizio()
		{
			document.getElementById("lblServizio").innerText="";
		}
		function ImpostaSrvSwfCreazRdl()
		{
		var FromCreazioneRdl = document.getElementById('TxtFromCreazioneRdl').value;
		var ServizioId = document.getElementById('TxtIdServizio').value ;
		var planimetria = document.getElementById("lblPlan").innerText;
			window.parent.ImpostaSrvDwf(ServizioId,planimetria,FromCreazioneRdl);	
		}
		</SCRIPT>
	</HEAD>
	<BODY ms_positioning="GridLayout" topmargin="0" rightmargin="0" bottommargin="0" leftmargin="0"
		onunload="javascript:ImpostaSrvSwfCreazRdl();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE width="100%">
				<TR>
					<TD>
						<TABLE id="Table1" cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
							<TR>
								<TD width="20%">Edificio:&nbsp;
									<ASP:LABEL id="lblEdificio" runat="server" font-bold="True"></ASP:LABEL>
									<ASP:TEXTBOX id="id_bl" runat="server">0</ASP:TEXTBOX>
								</TD>
								<TD width="20%">Piano:&nbsp;
									<ASP:LABEL id="lblPiano" runat="server" font-bold="True"></ASP:LABEL>
									<ASP:TEXTBOX id="id_fl" runat="server">0</ASP:TEXTBOX>
								</TD>
								<TD width="35%">Planimetria:&nbsp;
									<ASP:LABEL id="lblPlan" runat="server" font-bold="True">&nbsp;</ASP:LABEL>
								</TD>
								<TD width="25%">Servizio:&nbsp;
									<ASP:LABEL id="lblServizio" runat="server" font-bold="True"></ASP:LABEL>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellspacing="1" cellpadding="1" width="100%" align="left" border="0">
							<TR>
								<TD width="20%">
									<INPUT class="btn" type="button" id="btnEvidenziaStanze" name="EvidenziaStanze" value="Evidenzia Stanze"
										onclick="window.parent.frames(2).EvidenziaStanze()" style="WIDTH: 150px">
								</TD>
								<TD width="20%"><INPUT class="btn" type="button" value="Refresh" onclick="window.parent.frames(2).Refresh()"
										style="WIDTH: 150px">
								</TD>
								<TD width="20%"><INPUT type="button" id="btnEvidenziaReparti" name="EvidenziaReparti" value="Evidenzia Reparti"
										class="btn" style="WIDTH: 150px">
								</TD>
								<TD width="20%"><INPUT type="button" name="btnEvidenziaDstUso" value="Evidenzia Destinazioni D'Uso" class="btn"
										style="WIDTH: 150px">
								</TD>
								<TD width="20%">&nbsp;</TD>
							</TR>
						</TABLE>
						<TABLE>
								<TR>
									<TD>
										<INPUT type="hidden" id="TxtFromCreazioneRdl" runat="server">
									</TD>
									<TD>
										<INPUT type="hidden" id="TxtIdServizio" runat="server">
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE>
		</FORM>
		<SCRIPT language="javascript">
			crtl=document.getElementById('<%=tbxBlClinetId%>').style; 
			crtl.display="none";
			crtl=document.getElementById('<%=tbxFlClinetId%>').style; 
			crtl.display="none"
			DisableButton('btnEvidenziaStanze',true)
			DisableButton('btnEvidenziaReparti',true)
			DisableButton('btnEvidenziaDstUso',true)
		</SCRIPT>
		<SCRIPT language="vbscript">
			'DisableButton "btnAttivaDisattivaHlnk"
		</SCRIPT>
	</BODY>
</HTML>
