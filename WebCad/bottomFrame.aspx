<%@ Register TagPrefix="uc1" TagName="DataGridRicercaCad" Src="WebControls/DataGridRicercaCad.ascx" %>
<%@ Page language="c#" Codebehind="bottomFrame.aspx.cs" AutoEventWireup="false" Inherits="WebCad.bottomFrame" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>bottomFrame</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
			//function reloadPage(){
			//	document.location="bottomFrame.aspx";
			//}			
			function SetDWG(nomeFile){
				window.parent.frames['leftcad'].setPlanimetria(nomeFile);
				window.parent.frames['rbottom'].document.location="CAD/CadViewer.aspx?nomeDWG="+nomeFile;
			
			}
			function LoadDettaglioDWG(nomeFile){
				document.location="bottomFrame.aspx";
			}
			function OpenPiano(idEdif, idPian)
			{
				finestra1=window.open("Edifici/EditBuilding.aspx?idEdif=" + idEdif + "&idPian=" + idPian +"&Edificio="+getNomeEdificio()+"&Piano="+getNomePiano(),
					"DettaglioPiano",
					"resizable=yes,scrollbars=yes,menubar=no,toolbar=no,location=no,status=yes,width=600,height=400");
			}
			function OpenDataRoom(IdRm,DescrizioneRm)
			{
				var IdEdificio,IdPiano,NomePiano;
				IdEdificio= window.parent.frames['rtop'].getIdEdificio();
				IdPiano= window.parent.frames['rtop'].getIdPiano();
				NomePiano= window.parent.frames['rtop'].getNomePiano();
				fnOpenDataRoom=window.open("../AnagrafeImpianti/NavigazioneAppDEMO.aspx?var_stanza="+
					IdRm+"&var_bl_id=" + IdEdificio + 
					"&var_piani=" + IdPiano +
					"&TitoloStanza=" + DescrizioneRm +"&TitoloPiano="+NomePiano+ "&FunId=0&FromWebCad=true",
					"DettaglioPiano",
					"resizable=yes,scrollbars=yes,menubar=no,toolbar=no,location=no,status=yes,width=600,height=400");
				
			}
			function OpenApparecchiatura(eq_id)
			{
				
				//fnOpenApparecchiatura=window.open("RedirectPages/RedirectDettaglioApparecchiatura.aspx?eq_id=" + eq_id,
				fnOpenApparecchiatura=window.open("../AnagrafeImpianti/SchedaApparecchiatura.aspx?eq_id=" + eq_id,
					"DettaglioApparecchiatura",
					"resizable=yes,scrollbars=yes,menubar=no,toolbar=no,location=no,status=yes,width=900,height=600");
			}
			
			function OpenSchedaEq(id_eq)
			{
		
				//fnOpenSchedaEq =window.open("RedirectPages/RedirectSchedaEq.aspx?id_eq=" + id_eq,
				fnOpenSchedaEq =window.open("../ShedeEq/VisualizzaSchedaHtml.aspx?FromWebCad=true" + "&id_eq=" + id_eq,
					"DettaglioApparecchiatura",
					"resizable=yes,scrollbars=yes,menubar=no,toolbar=no,location=no,status=yes,width=900,height=600");
				
			}
			function OpenDocumentiEq(id_eq,eq_id)
			{
				//fnOpenDocumentiEq=window.open("RedirectPages/RedirectEqDocumentiAllegati.aspx?id_eq=" + id_eq + "&eq_id=" + eq_id,
				fnOpenDocumentiEq=window.open("../AnagrafeImpianti/Eq_DocumentiAllegati.aspx?id_eq=" + id_eq + "&eq_id=" + eq_id + "&FromWebCad=true",
					"DettaglioApparecchiatura",
					"resizable=yes,scrollbars=yes,menubar=no,toolbar=no,location=no,status=yes,width=900,height=600");
				
			}
			function getNomePiano(){
				return window.parent.frames['rtop'].getNomePiano();
			}
			 
			function getNomeEdificio(){
				return window.parent.frames['rtop'].getNomeEdificio();
			}
			
			function openRicercaDataRoom(Edificio,Piano){
				fnOpenDocumentiEq=window.open("../AnagrafeImpianti/DataRoom.aspx?id_edificio_cad=" + Edificio + "&id_piano_cad=" + Piano + "&FromWebCad=true",
					"DataRoom",
					"resizable=yes,scrollbars=yes,menubar=no,toolbar=no,location=no,status=yes,width=900,height=600");
			}
			 
			//"NavigazioneAppDEMO.aspx?var_piani=1&var_bl_id=201&TitoloPiano&TitoloPiano=Piano Terra"
				
			function StringaLayerDWF(){
				var StringaLayerDWF = "<%=stringaLayerStanze%>"
				if (window.parent.frames['rtop'].document.getElementById('btnEvidenziaStanze')!=null){
					if (StringaLayerDWF==""){
						window.parent.frames['rtop'].DisableButton('btnEvidenziaStanze',true)
					} else {
						window.parent.frames['rtop'].DisableButton('btnEvidenziaStanze',false)
					}
				}
			}
			function SelezionaReparto(reparto)
			{	
				window.location = '../bottomFrame.aspx?reparto=' + reparto;
			}
			function SelezionaPiano(fl)
			{
				window.location = '../bottomFrame.aspx?fl_id=' + fl;
			}
			function SelezionaRm(rm)
			{
				window.location = '../bottomFrame.aspx?rm_id=' + rm +'&accoda=' + getAccodaVal2();
			}
			function SelezionaEq(eq)
			{
				window.location = '../bottomFrame.aspx?eq_id=' + eq +'&accoda=' + getAccodaVal2();
			}
			
			function ViewHtml()
			{
				d=window.open();    
				d.document.open('text/plain').write(document.documentElement.outerHTML);
			}
			
			function getAccodaVal(){
				if (window.parent.frames['rbottom'].document.getElementById('accoda')!=null){
					if (parent.frames['rbottom'].document.getElementById("accoda").checked)
						document.getElementById("accoda").value="1"
					else
						document.getElementById("accoda").value="0"
				}
			}
			
			function getAccodaVal2(){
				if (window.parent.frames['rbottom'].document.getElementById('accoda')!=null){
					if (parent.frames['rbottom'].document.getElementById("accoda").checked)
						return 1
					else
						return 0
				}
			}
			 
			 StringaLayerDWF();
		</SCRIPT>
		<SCRIPT language="vbscript">
			sub SetDwf(NomeSuDb, NomeFile, esiste, servizio,descServizio)
			
				window.parent.frames(2).openFileView NomeFile, esiste 
				if (esiste="true") then
					window.parent.frames(0).setPlanimetria(NomeSuDb)
					window.parent.frames(1).SetPlanimetria(NomeSuDb)
					window.parent.frames(1).setServizio(descServizio)
					window.parent.frames(1).setIdServizio(servizio)					
					window.parent.frames(0).setServizio(servizio)
					'window.parent.frames(1).EnableButton "btnAttivaDisattivaHlnk"				
					window.location= "bottomFrame.aspx?NomeFile=" & NomeSuDb
					
				end if
				'MsgBox "Fine Caricamento"
				'window.parent.frames(2).document.ADViewer.Viewer.WaitForPageLoaded()
				'window.parent.frames(2).forceRedraw()
				'window.parent.frames(2).ImpostaLayerIniziale() 
				'MsgBox "Fine Routine"
			End sub
			sub reloadPage()
				window.location="bottomFrame.aspx"
			end sub	
			sub ZoomOfObject(z1x,z1y,z2x,z2y)
				window.parent.frames(2).ZoomOfObject z1x,z1y,z2x,z2y
			end sub
			function StringaLayeRm()
				'MsgBox "<%=stringaLayerStanze%>"
				StringaLayeRm = "<%=stringaLayerStanze%>"
				
			end function
			function EvidenziaLayer(id)
				window.parent.frames(2).EvidenziaStanza(id)
			end function
			function SelezionaReparto(reparto)
				window.location = "../bottomFrame.aspx?reparto" & reparto
			end function
			function SelezionaPiano(fl)
				window.location = "../bottomFrame.aspx?fl_id=" & fl
			end function
			function SelezionaRm(rm)
				window.location = "../bottomFrame.aspx?rm_id=" & rm
			end function
			function SelezionaEq(eq)
				window.location = "../bottomFrame.aspx?eq_id=" & eq
			end function
			<%=vbScriptDaEseguire%>
		</SCRIPT>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE width="100%">
				<TR>
					<TD>
						<UC1:DATAGRIDRICERCACAD id="DataGridRicercaCad1" runat="server"></UC1:DATAGRIDRICERCACAD>
					</TD>
				</TR>
			</TABLE>
			<!--<A href="javascript:ViewHtml();">View Source</A>-->
			<input type="hidden" id="accoda" runat="server" NAME="accoda" value="0">
		</FORM>
		<FORM id="FormDati" method="post" action="bottomFrame.aspx">
			<input type="hidden" id="tipo" runat="server" NAME="tipo" value="0"> <input type="hidden" id="categoria" runat="server" NAME="categoria">
			<input type="hidden" id="reparto" runat="server" NAME="reparto"> <input type="hidden" id="destUso" runat="server" NAME="destUso">
			<input type="hidden" id="stanze" runat="server" NAME="stanze"> <input type="hidden" id="stdApp" runat="server" NAME="stdApp">
			<input type="hidden" id="App" runat="server" NAME="App">
		</FORM>
	</BODY>
	<script language="javascript">
		getAccodaVal();
	</script>
</HTML>
