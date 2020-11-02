<%@ Page language="c#" Codebehind="CadViewer.aspx.cs" AutoEventWireup="false" Inherits="WebCad.CAD.CadViewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>CadViewer</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript">
			function ViewHtml()
			{
				d=window.open();    
				d.document.open('text/plain').write(document.documentElement.outerHTML);				
				//window.open("javascript:'<xmp>' + opener.window.document.documentElement.outerHTML + '</xmp>'"));
				//javascript:void(window.open("javascript:'<xmp>' + opener.window.document.documentElement.outerHTML + '</xmp>'"));
			}
			function ST(rm)
			{	
				parent.frames["rbottom2"].SelezionaRm(rm);	
			}
			function CO(reparto)
			{
				parent.frames["rbottom2"].SelezionaReparto(reparto);
			}
			function LV(fl)
			{
				parent.frames["rbottom2"].SelezionaPiano(fl);
			}
			function AP(eq)
			{
				//alert(eq);
				parent.frames["rbottom2"].SelezionaEq(eq);
			}
			
		</SCRIPT>
		<SCRIPT language="vbscript">
		
			Sub ImpostaLayerIniziale ' Imposta i layer iniziali da visualizzare
				'call Form1.ADViewer.Viewer.WaitForPageLoaded()
				for each Layer in Form1.ADViewer.Viewer.Layers
					NomeLayer = Layer.name
					InizioLayer = left(NomeLayer,5)
				if instr(1,InizioLayer,"z-RM_",1)>0 then
					Layer.visible = false
					''MsgBox NomeLayer
				elseif instr(1,InizioLayer,"z-RP_",1)>0 then
					Layer.visible = false
					'MsgBox NomeLayer
				elseif instr(1,InizioLayer,"z-DU_",1)>0 then
					Layer.visible = false
					'MsgBox NomeLayer
				elseif instr(1,InizioLayer,"z-CT_",1)>0 then
					Layer.visible = false
					'MsgBox NomeLayer
				end if
				next
			End sub
			Sub ZoomOfObject(z1x,z1y,z2x,z2y) ' Fa lo zoom delle coordinate
				dim Sinistra,Basso,Destra,Alto
				dim MaxSinistra,MaxBasso,MaxDestra,MaxAlto
				'dim SinistraCorrente,BassoCorrente,DestraCorrente,AltoCorrente
				'dim SinistraMedio,BassoMedio,DestraMedio,AltoMedio
				'Dim PassoSinistra,PassoBasso,PassoDestra,PassoAlto,NumeroPassi
				MaxSinistra = document.getElementById("txtZ1x").value
				MaxBasso = document.getElementById("txtZ1y").value
				MaxDestra = document.getElementById("txtZ2x").value
				MaxAlto = document.getElementById("txtZ2y").value
				SinistraCorrente = Form1.ADViewer.Viewer.View.Left
				BassoCorrente = Form1.ADViewer.Viewer.View.Bottom
				DestraCorrente = Form1.ADViewer.Viewer.View.Right
				AltoCorrente = Form1.ADViewer.Viewer.View.Top
				Sinistra = z1x/76
				Basso = z1y/77.5
				Destra = z2x/76
				Alto = z2y/77.5
				'SinistraMedio = (Sinistra + MaxSinistra)/2
				'BassoMedio = (Basso + MaxBasso)/2
				'DestraMedio = (Destra + MaxDestra)/2
				'AltoMedio = (Alto + MaxAlto)/2
				if SinistraCorrente = Sinistra and BassoCorrente = Basso and DestraCorrente = Destra and AltoCorrente = Alto then
					call Form1.ADViewer.Viewer.SetView(MaxSinistra,MaxBasso,MaxDestra,MaxAlto)
				else
					'call Form1.ADViewer.Viewer.SetView(MaxSinistra,MaxBasso,MaxDestra,MaxAlto)
					'NumeroPassi = 20
					'PassoSinistra = (Sinistra-MaxSinistra)/NumeroPassi
					'PassoBasso = (Basso-MaxBasso)/NumeroPassi
					'PassoDestra = (Destra -MaxDestra)/NumeroPassi
					'PassoAlto = (Alto-MaxAlto)/NumeroPassi
					'for i=i to NumeroPassi -1 step 1
						call Form1.ADViewer.Viewer.SetView(Sinistra, Basso, Destra,Alto)
					'next
					'call Form1.ADViewer.Viewer.SetView(Sinistra,Basso,Destra,Alto)
				end if
			end sub
			sub ImpostaCordinateIniziali
				dim OrgZ1x, OrgZ1y, OrgZ2x, OrgZ2y
				OrgZ1x = Form1.ADViewer.Viewer.View.Left
				OrgZ1y = Form1.ADViewer.Viewer.View.Bottom
				OrgZ2x = Form1.ADViewer.Viewer.View.Right
				OrgZ2y = Form1.ADViewer.Viewer.View.Top
				document.getElementById("txtZ1x").value = OrgZ1x
				document.getElementById("txtZ1y").value = OrgZ1y
				document.getElementById("txtZ2x").value = OrgZ2x
				document.getElementById("txtZ2y").value = OrgZ2y
			end sub
			Sub EnableHyperLink'Abilita-Disabilita gli Hperlink
				Form1.ADViewer.Viewer.HyperlinkTooltipsVisible = true
			End Sub
			Sub openFileView(FileNome, esiste) 'Carica un nuovo disegno
				
				if esiste = "true" then
					'Form1.ADViewer.Viewer.ExecuteCommand("EXIT")
					FileNameFull = document.getElementById("txtUrlDwf").value + FileNome
				
				
					
					PathFile = FileNameFull
					Form1.ADViewer.SourcePath  = PathFile
					
					'MsgBox FileNameFull
					'Form1.ADViewer.Viewer.ExecuteCommand("OPEN")
					'Form1.ADViewer.ExecuteCommand("RELOAD")
					'call Form1.ADViewer.Viewer.WaitForPageLoaded()
					'ImpostaLayerIniziale()
				else
					MsgBox "Il file selezionato non è presente nel server"
				end if
			End Sub
		Sub Navigation ' Fa il rendering del nuovo disegno dwf
			'Form1.ADViewer.Viewer.WaitForPageLoaded()
 			Form1.ADViewer.Viewer.ExecuteCommand("NAVIGATION")
		End Sub
		Sub Refresh
			if Form1.ADViewer.SourcePath <> "" then
			Form1.ADViewer.ExecuteCommand("RELOAD")
			forceRedraw()
			end if
			'Form1.ADViewer.Viewer.ExecuteCommand("EXIT")
		End Sub 
		Sub forceRedraw
			Form1.ADViewer.Viewer.SetView Form1.ADViewer.Viewer.View.Left, Form1.ADViewer.Viewer.View.Bottom, Form1.ADViewer.Viewer.View.Right, Form1.ADViewer.Viewer.View.Top
		End Sub
		sub EvidenziaStanze
			dim SStanze, AStanze,stringaStanze
			document.getElementById("txtZRm").value = window.parent.frames(3).StringaLayeRm
			SStanze= document.getElementById("txtZRm").value
			AStanze = Split(SStanze,";")
			'MsgBox SStanze
			
			dim Nstanze
			Nstanze = UBound(AStanze)
			'MsgBox Nstanze
			for i=0 to Nstanze step 1
				'MsgBox i & " := " & AStanze(i)
				Form1.ADViewer.Viewer.Layers(AStanze(i)).visible = not(Form1.ADViewer.Viewer.Layers(AStanze(i)).visible)
			next
		end sub
		'di federico, serve ad evidenziare una sola stanza
		sub EvidenziaStanza(id)
			Form1.ADViewer.Viewer.Layers(id).visible = not(Form1.ADViewer.Viewer.Layers(id).visible)
		end sub
		
		sub manipolalayerDwf
			'MsgBox "Totale Layer Disegno:= " & Form1.ADViewer.Viewer.Layers.count
			dim i
			i=0
			dim layerRmZ
			layerRmZ ="('"
			for each Layer in Form1.ADViewer.Viewer.Layers
					NomeLayer = Layer.name
					InizioLayer = left(NomeLayer,5)
				if instr(1,InizioLayer,"z-RM_",1)>0 then
					i=i+1
					layerRmZ = layerRmZ & NomeLayer & "','"
				end if
				next
				layerRmZ = layerRmZ & ")"
				'MsgBox "Totale Layer Rm_Z:= " & i
				'MsgBox layerRmZ
				document.getElementById("txtZRmDisegno").value = layerRmZ
		end sub
		sub VisualizzaCordinate
		'MsgBox Form1.ADViewer.Viewer.View.Bottom
			document.getElementById("Bottom").value = Form1.ADViewer.Viewer.View.Bottom
			document.getElementById("Left").value = Form1.ADViewer.Viewer.View.Left
			document.getElementById("Right").value = Form1.ADViewer.Viewer.View.Right
			document.getElementById("Top").value = Form1.ADViewer.Viewer.View.Top
			document.getElementById("idName").value = Form1.ADViewer.Viewer.View.Name
		end sub
		sub AbilitaVisualizzaRm
		document.getElementById("Right")
		end sub
		Sub HLnk
		MsgBox Form1.ADViewer.Viewer.LinksEnabled 
		End Sub
		function ST(rm)	
				parent.frames(3).SelezionaRm(rm)
		end function
		</SCRIPT>
	</HEAD>
	<BODY topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0" bgcolor="#ffffff">
		<FORM id="Form1" method="post" runat="server">
			<TABLE width="100%" id="Table1">
				<TR>
					<TD colspan="5">
						<OBJECT id="ADViewer" style="WIDTH: 100%; HEIGHT: 430px" codebase="http://www.autodesk.com/global/dwfviewer/installer/DwfViewerSetup_ita.exe"
							border="1" classid="clsid:a662da7e-ccb7-4743-b71a-d817f6d575df" viewastext>
							<PARAM name="_cx" value="25109">
							<PARAM name="_cy" value="11377">
							<PARAM name="BackColor" value="13395456">
							<PARAM name="EmbedDoc" value="0">
							<PARAM name="Src" value="">
							<PARAM name="ViewerParams" value="">
						</OBJECT>
						<SCRIPT for="ADViewer" event="OnEndLoadItem(bstrItemName,vData,vResult)" language="vbscript">
							
							ImpostaLayerIniziale()
							Form1.ADViewer.Viewer.UserInterfaceEnabled = true
							Form1.ADViewer.Viewer.SingleClickHyperlink = false
							Form1.ADViewer.Viewer.HyperlinkTooltipsVisible = true
							ImpostaCordinateIniziali()
						</SCRIPT>
						<SCRIPT for="ADViewer" event="OnExecuteURL(pIAdPageLink,nIndex,pHandled)" language="vbscript">
							pHandled.state = true
							dim stringaCom, stringaArg
							stringaCom = Replace(piAdPageLink.Link(nIndex),"javascript:","")
							if Mid(stringaCom,1,2)="AP" then
								stringaArg = Replace(Replace(stringaCom,"AP('",""),"');","")
								AP(stringaArg)							
							elseif Mid(stringaCom,1,2)="ST" then	
								stringaArg = Replace(Replace(stringaCom,"ST('",""),"');","")														
								ST(stringaArg)
							end if
						</SCRIPT>
					</TD>
				</TR>
				<TR>
					<TD><INPUT type="checkbox" id="accoda" checked>Accoda</TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR style="VISIBILITY: hidden">
					<TD><INPUT type="text" id="txtUrlDwf" size="15" name="txtUrlDwf" runat="server"></TD>
					<TD><INPUT type="text" id="txtZRm" size="15" name="txtZRm"></TD>
					<TD><INPUT type="text" id="txtZRmDisegno" size="15" name="txtZRmDisegno"></TD>
					<TD><INPUT type="button" id="cntLayerDisegno" value="Controola LAyer" onclick="manipolalayerDwf()"
							name="cntLayerDisegno"></TD>
					<TD><INPUT type="button" id="idVediCordinate" value="Reset Planimetria" onclick="ResetPlanimetria()"
							name="idVediCordinate"></TD>
				<TR style="VISIBILITY: hidden">
					<TD><INPUT type="text" id="Bottom" size="15" name="Bottom"></TD>
					<TD><INPUT type="text" id="Left" size="15" name="Left"></TD>
					<TD><INPUT type="text" id="Right" size="15" name="Right"></TD>
					<TD><INPUT type="text" id="Top" size="15" name="Top"></TD>
					<TD><INPUT type="text" id="idName" size="15" name="idName"></TD>
				</TR>
				<TR style="VISIBILITY: hidden">
					<TD><INPUT type="text" id="txtZ1x" name="txtZ1x"></TD>
					<TD><INPUT type="text" id="txtZ1y" name="txtZ1y"></TD>
					<TD><INPUT type="text" id="txtZ2x" name="txtZ2x"></TD>
					<TD><INPUT type="text" id="txtZ2y" name="txtZ2y"></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT language="vbscript">
			<%=EseguiScriptApriPlanimetria%>
		</SCRIPT>
	</BODY>
</HTML>
