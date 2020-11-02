<%@ Register TagPrefix="uc1" TagName="WebUserControlTreeView" Src="WebControls/WebUserControlTreeView.ascx" %>
<%@ Page language="c#" Codebehind="LeftFrame2.aspx.cs" AutoEventWireup="false" Inherits="WebCad.LeftFrame2" %>
<%@ Register TagPrefix="uc1" TagName="myDropDownList" Src="WebControls/myDropDownList.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>LeftFrame</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Css/MainSheet.css" type="text/css" rel="stylesheet">
		<STYLE type="text/css">.mainsectionCad { BORDER-RIGHT: slategray 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: slategray 1px solid; MARGIN-TOP: 0px; DISPLAY: block; PADDING-LEFT: 1px; FONT-WEIGHT: bold; FONT-SIZE: 11px; MARGIN-BOTTOM: 0px; PADDING-BOTTOM: 1px; MARGIN-LEFT: 0px; BORDER-LEFT: slategray 1px solid; COLOR: #20095b; PADDING-TOP: 1px; BORDER-BOTTOM: slategray 1px solid; BACKGROUND-REPEAT: repeat-x; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: #f0c090; TEXT-DECORATION: none }
	.mainsectionCad:hover { COLOR: #ffffff; BACKGROUND-COLOR: #454db8; TEXT-DECORATION: none }
	.subsectionCad { BORDER-RIGHT: gainsboro 1px solid; PADDING-RIGHT: 1px; BORDER-TOP: gainsboro 1px solid; MARGIN-TOP: 0px; DISPLAY: block; PADDING-LEFT: 1px; FONT-WEIGHT: bold; FONT-SIZE: 11px; MARGIN-BOTTOM: 0px; PADDING-BOTTOM: 1px; MARGIN-LEFT: 0px; BORDER-LEFT: gainsboro 1px solid; COLOR: #20095b; PADDING-TOP: 1px; BORDER-BOTTOM: gainsboro 1px solid; BACKGROUND-REPEAT: repeat-x; FONT-FAMILY: Verdana, Arial; BACKGROUND-COLOR: #f0c090; TEXT-DECORATION: none }
	.subsectionCad:hover { COLOR: #ffffff; BACKGROUND-COLOR: #454db8; TEXT-DECORATION: none }
	.subsectionCad2 { PADDING-RIGHT: 1px; MARGIN-TOP: 1px; DISPLAY: block; PADDING-LEFT: 5px; FONT-WEIGHT: bold; FONT-SIZE: 10px; BACKGROUND-IMAGE: url(images/bot3.jpg); PADDING-BOTTOM: 3px; COLOR: #d7e4f3; PADDING-TOP: 2px; FONT-FAMILY: Tahoma; TEXT-DECORATION: none }
	.subsectionCad2 A:hover { COLOR: #ffffff }
	</STYLE>
		<SCRIPT language="javascript">
		///Sezione dediacata ai layer///////
		
		var blId=0;
		var flId=0;
		
		function trimm(stringa){
			var parole=stringa.split('');
			var k=parole.length;
			var blank=0;	
			var msg='';
			for (i=0; i<k; i++) {
				if (parole[i] != ' ') {  		 		
				blank = 0;		    
				msg+=parole[i];
				} else {
					blank++;
				}
				if ((blank == 1) && (i!=0)) {
				msg+=parole[i]; 
				}   	
			} 		
			if (msg.substring((msg.length-1 ),msg.length) == ' ')
			{
				stringa = msg.substring(0,(msg.length - 1)) 	
			}
			else
			{ 
				stringa=msg;
			}
			
			return stringa;
		}
			
		function VisualizzaBl(){
			crtl=document.getElementById('bl').style; 
			crtl.display="block";
			crtl=document.getElementById('app').style; 
			crtl.display="none"				
		}
		
		function VisualizzaApp(){
			if (checkPlanimetria()){
				crtl=document.getElementById('bl').style; 
				crtl.display="none";
				crtl=document.getElementById('app').style; 
				crtl.display="block"	
			}		
		}
		
		<%=scriptDaEseguire%>
		
		function checkPlanimetria()
		{
			if(document.getElementById('hiddenPlanimetria')!=null){			
				if(document.getElementById('hiddenPlanimetria').value==''){
					alert('Per visualizzare la Navigazione Spazi e Apparati occorre \n prima visualizzare una planimetria');
					return false;	
				}
				return true;
			}
		}
		
		function checkParametriRicercaEq()
		{
			if(document.getElementById("<%=CategorieDropDownList.getClientID()%>").value=="" &&
			document.getElementById("<%=repartiDropDownList.getClientID()%>").value=="" &&
			document.getElementById("<%=destUsoDropDownList.getClientID()%>").value==""){	
				if(trimm(document.getElementById("filtroApp").value)=="" && 
				trimm(document.getElementById("hiddenStanze").value)=="" && 
				trimm(document.getElementById("hiddenEqstd").value)==""){
					//alert("pippo:"+trimm(document.getElementById("filtroApp").value));					
					return false;
				}
			}			
				return true;	
		}
		
		function setPlanimetria(planimetria)
		{			
			document.getElementById('hiddenPlanimetria').value=planimetria;
		}
		
		function Eq(sender,sender2,sender3,sender4)
		{
			var ctr= document.getElementById('frameLink');
		  	ctr.src="ListLink.aspx?bl=" + sender +"&corpo=" + sender2 + "&stanza=" + sender3 + "&eq=" + sender4;
		}
		function Stanza(sender,sender2,sender3)
		{
			var ctr= document.getElementById('frameLink');
		  	ctr.src="ListLink.aspx?bl=" + sender +"&corpo=" + sender2 + "&stanza=" + sender3;
		}
		function Corpo(sender,sender2)
		{
			var ctr= document.getElementById('frameLink');
		  	ctr.src="ListLink.aspx?bl=" + sender +"&corpo=" + sender2;
		}
		function Bl(sender)
		{
			var ctr= document.getElementById('frameLink');
		  	ctr.src="ListLink.aspx?bl=" + sender;
		}
			
		 var finestra;
		 var finestra2;

		 function ChechSelection()
		 {	
			alert("Devi selezionare un piano di un edificio!!")
		 }
		 
		 
		 function OpenStanze()
		 {	
			if (document.getElementById('<%=idPian.ClientID%>').value==0){
				alert("Devi selezionare un piano di un edificio!!")
				return;
			}
			var controlList='<%=ListBoxStanze.ClientID%>';
			finestra=window.open("Stanze.aspx?idbl=" + 
				document.getElementById('<%=idEdif.ClientID%>').value + 
				"&idpiano=" + document.getElementById('<%=idPian.ClientID%>').value + 
				"&ctrid=" + controlList +
				"&descrizione=" + document.getElementById("filtroRm").value,
				"stanze","resizable=yes,menubar=no,toolbar=no,location=no,status=yes,width=600,height=400");
		 }
		 
		 function OpenEqstd()
		 {
			if (document.getElementById('<%=idPian.ClientID%>').value==0){
				alert("Devi selezionare un piano di un edificio!!")
				return;
			}
			var controlList='<%=ListBoxEQSTD.ClientID%>';
			var url = "StandardApp.aspx?idbl=" + document.getElementById('<%=idEdif.ClientID%>').value + 
					"&idpiano=" + document.getElementById('<%=idPian.ClientID%>').value + 
					"&IdServizio=" + document.getElementById('<%=idServ.ClientID%>').value +
					"&ctrid=" + controlList +
					"&descrizione=" + document.getElementById("filtroStd").value;
			finestra2=window.open(url,"eqstd","resizable=yes,menubar=no,toolbar=no,location=no,status=yes,width=600,height=400");
		 }
		 
		 function OpenEq()
		 {
			if (document.getElementById('<%=idPian.ClientID%>').value==0){
				alert("Devi selezionare un piano di un edificio!!");
				return;
			}
			
			if (!checkParametriRicercaEq()){
				alert("Devi valorizzare almeno un criterio di ricerca!!");
				return;
			}
			var controlList='<%=listBoxEQClId%>';
			finestra2=window.open("apparecchiature.aspx?idbl=" + 
			document.getElementById('<%=idEdif.ClientID%>').value + 
			"&idpiano=" + document.getElementById('<%=idPian.ClientID%>').value + 
			"&IdServizio=" + document.getElementById('<%=idServ.ClientID%>').value +
			"&ctrid=" + controlList +
			"&descrizione=" + document.getElementById("filtroApp").value +
			"&idReparto=" + document.getElementById("<%=repartiDropDownList.getClientID()%>").value +
			"&idCategoria=" + document.getElementById("<%=CategorieDropDownList.getClientID()%>").value +
			"&idDestUso=" + document.getElementById("<%=destUsoDropDownList.getClientID()%>").value +
			"&stanzeSel=" + document.getElementById("hiddenStanze").value +
			"&stdSel=" + document.getElementById("hiddenEqstd").value,
			"STD","resizable=yes,menubar=no,toolbar=no,location=no,status=yes,width=600,height=400");
		 }
		 
		 
		 function ValorizzaStanze(sender,sender2)
		 {
		   var ctrlLis= document.getElementById('<%=ListBoxStanze.ClientID%>');
		  	var i;
			for (i = 0; i < ctrlLis.options.length; i++) 
			{
				
				if(ctrlLis.options[i].value==sender)
				{
					alert("Stanza già inserito!");
					finestra.focus();
					return;
				}
				if(ctrlLis.options[i].value=="")
				  ctrlLis.options[i]=null;
			}
			var opt= new Option(sender2,sender);
			var lenoption=ctrlLis.options.length;
            ctrlLis.options[lenoption]=opt;
            var hiddenctrl=document.getElementById('<%=hiddenStanze.ClientID%>');
            ReloadHidden(hiddenctrl,ctrlLis);
            var hiddenctrl2=document.getElementById('<%=stanzeDescription.ClientID%>');
            ReloadHidden2(hiddenctrl2,ctrlLis);
           
		 }
		 
		 function ValorizzaEqstd(sender,sender2)
		 {
		   var ctrlLis= document.getElementById('<%=ListBoxEQSTD.ClientID%>');
		  	var i;
			for (i = 0; i < ctrlLis.options.length; i++) 
			{
				
				if(ctrlLis.options[i].value==sender)
				{
					alert("Standard Apparechiatura già inserito!");
					finestra2.focus();
					return;
				}
				if(ctrlLis.options[i].value=="")
				  ctrlLis.options[i]=null;
			}
			var opt= new Option(sender2,sender);
			var lenoption=ctrlLis.options.length;
            ctrlLis.options[lenoption]=opt;
            var hiddenctrl=document.getElementById('<%=hiddenEqstd.ClientID%>');
            ReloadHidden(hiddenctrl,ctrlLis);
             var hiddenctrl2=document.getElementById('<%=eqStdDescription.ClientID%>');
            ReloadHidden2(hiddenctrl2,ctrlLis);
		 }
		 
		 function ValorizzaEq(sender,sender2)
		 {
		   var ctrlLis= document.getElementById('<%=listBoxEQClId%>');
		  	var i;
			for (i = 0; i < ctrlLis.options.length; i++) 
			{
				
				if(ctrlLis.options[i].value==sender)
				{
					alert("Apparechiatura già inserita!");
					finestra2.focus();
					return;
				}
				if(ctrlLis.options[i].value=="")
				  ctrlLis.options[i]=null;
			}
			var opt= new Option(sender2,sender);
			var lenoption=ctrlLis.options.length;
            ctrlLis.options[lenoption]=opt;
            
            var hiddenctrl=document.getElementById('<%=hiddenEq.ClientID%>');
            ReloadHidden(hiddenctrl,ctrlLis);
            var hiddenctrl2=document.getElementById('<%=eqDescription.ClientID%>');
            ReloadHidden2(hiddenctrl2,ctrlLis);
		 }
		 
		function deleteitem(sender,e)
		{
			if (sender.selectedIndex!=-1) 
			{ 
				if ((event.keyCode==46) && (window.confirm('Eliminare l\'elemento selezionato?')))
				{
					if (sender.options.length!=0) 
						sender.options[sender.selectedIndex]=null;
				}
				if (sender.options.length==0) {
					//alert("pippo");
					/*if(sender ==document.getElementById('<%=ListBoxEQSTD.ClientID%>'))
						document.getElementById('<%=ListBoxEQSTD.ClientID%>').options[0]=new Option("","- Tutti gli Standard Apparechiatura -");
					else if(sender ==document.getElementById('<%=listBoxEQ.ClientID%>'))
						document.getElementById('<%=listBoxEQClId%>').options[0]=new Option("","- Tutte le Apparechiature -");
					else*/
						//sender.options[0]=new Option("","- Tutte le Stanze -");
				}
			} 
			var hiddenctrl=null;
			if(sender ==document.getElementById('<%=ListBoxEQSTD.ClientID%>'))
			   hiddenctrl=document.getElementById('<%=hiddenEqstd.ClientID%>');
			else if(sender ==document.getElementById('<%=listBoxEQ.ClientID%>'))
			   hiddenctrl=document.getElementById('<%=hiddenEq.ClientID%>');
			else
			   hiddenctrl=document.getElementById('<%=hiddenStanze.ClientID%>');
			   
			ReloadHidden(hiddenctrl,sender);
			
			hiddenctrl=null;
			if(sender ==document.getElementById('<%=ListBoxEQSTD.ClientID%>'))
			   hiddenctrl=document.getElementById('<%=eqStdDescription.ClientID%>');
			else if(sender ==document.getElementById('<%=listBoxEQ.ClientID%>'))
			   hiddenctrl=document.getElementById('<%=eqDescription.ClientID%>');
			else
			   hiddenctrl=document.getElementById('<%=stanzeDescription.ClientID%>');
			   
			ReloadHidden(hiddenctrl,sender);
		}
				
		function ReloadHidden(sender,ctrlLis)
		{
			var hidden=sender;
            hidden.value="";
            for(i=0;i<=ctrlLis.options.length-1;i++)
            {
             if(hidden.value=="")
				hidden.value=ctrlLis.options[i].value;
			 else
			   hidden.value+="," + ctrlLis.options[i].value;
            }
		}	
		
		function ReloadHidden2(sender,ctrlLis)
		{
			var hidden=sender;
            hidden.value="";
            for(i=0;i<=ctrlLis.options.length-1;i++)
            {
             if(hidden.value=="")
				hidden.value=ctrlLis.options[i].text;
			 else
			   hidden.value+="," + ctrlLis.options[i].text;
            }
		}
			
		 function chiudi()
		 {
		  if (finestra!=null)
		      finestra.close();
		      
		  if (finestra2!=null)
		      finestra2.close();
		  
		 }
		 	function OnDivScroll(sender)
			{
				var lstCollegeNames = sender;
				if (lstCollegeNames.options.length > 8)
				{
					lstCollegeNames.size=lstCollegeNames.options.length;
				}
				else
				{
					lstCollegeNames.size=8;
				}
			}
			

			function OnSelectFocus(sender,sender2)
			{
				
				if (sender2.scrollLeft != 0)
				{
					sender2.scrollLeft = 0;
				}
				var lstCollegeNames = sender;
				if( lstCollegeNames.options.length > 8)
				{
	 				lstCollegeNames.focus();
	 				lstCollegeNames.size=8;
				}
			}
			function InviaServizi()
			{
			 var selezionati=new Array();
			 var table= document.getElementById("CheckBoxServizi")
			 var cells = table.getElementsByTagName("td");
			 var ctlr;
			 var j=0;
			 for (var i = 0; i < cells.length; i++){
				ctrl = cells[i].firstChild;
				if (ctrl.type == 'checkbox')
					if(ctrl.checked==true)
					{
						ctrl = cells[i].lastChild;
						selezionati[j]=ctrl.innerText;
						j+=1;
					}
			 }
			  
			 if(selezionati.length>0)
					alert(selezionati.toString());
			
			}
			function Inviabj(sender)
			{
			    var ctrlLis=document.getElementById(sender);
			    var message="";
				for(i=0;i<=ctrlLis.options.length-1;i++)
				{
				  message += ctrlLis.options[i].text + " ";
				}
				//alert(message);
			}	
			
			
			function getIdEdificio(){
				window.parent.frames['rtop'].document.getElementById('id_bl').value;
			}
			function getIdPiano(){
				window.parent.frames['rtop'].document.getElementById('id_fl').value;
			}
			
			function SetPianoStanza(idEdificio,codiceEdificio,idPiano,desctrizionePiano){
				window.parent.frames['rtop'].SetPianoStanza(idEdificio,codiceEdificio,idPiano,desctrizionePiano);
				window.parent.frames['rtop'].clearServizio();
				blId=idEdificio;
				flId=idPiano;
				document.getElementById('<%=idEdif.ClientID%>').value=blId;
				document.getElementById('<%=idPian.ClientID%>').value=flId;
				setPlanimetria('');
				//alert("Hai selezionato il " + desctrizionePiano+ "\ndell'edificio " + codiceEdificio);
				window.parent.frames['rbottom2'].window.location="bottomFrame.aspx?idBl="+blId+"&idFl="+flId;	
				return;			
			}
			
			function setPlanimetria(planimetria){			
				document.getElementById("hiddenPlanimetria").value=planimetria;
			}
			function ViewHtml() 
			{
				d=window.open();    
				d.document.open('text/plain').write(document.documentElement.outerHTML);
			}
			
			function SendParameterToBottomFrame(tipoDatagrid){
				window.parent.frames['rbottom2'].document.getElementById("tipo").value=tipoDatagrid;
				window.parent.frames['rbottom2'].document.getElementById("stanze").value=document.getElementById("hiddenStanze").value;
				window.parent.frames['rbottom2'].document.getElementById("stdApp").value=document.getElementById("hiddenEqstd").value;
				window.parent.frames['rbottom2'].document.getElementById("App").value=document.getElementById("hiddenEq").value;
				window.parent.frames['rbottom2'].document.getElementById("categoria").value=document.getElementById("<%=CategorieDropDownList.getClientID()%>").value;
				window.parent.frames['rbottom2'].document.getElementById("reparto").value=document.getElementById("<%=repartiDropDownList.getClientID()%>").value;
				window.parent.frames['rbottom2'].document.getElementById("destUso").value=document.getElementById("<%=destUsoDropDownList.getClientID()%>").value;	
				window.parent.frames['rbottom2'].document.getElementById("FormDati").submit();		
			}
			 
		</SCRIPT>
		<SCRIPT language="vbscript">
			dim blId
			dim flId
			sub setPlanimetria(planimetria)	
				document.getElementById("hiddenPlanimetria").value=planimetria
			end sub
			sub setServizio(servizio)	
				document.getElementById("idServ").value=servizio
			end sub
			
			
			function SetPianoStanza(idEdificio,codiceEdificio,idPiano,desctrizionePiano, IDNodo)
				parent.frames(1).SetPianoStanzaT idEdificio,codiceEdificio,idPiano,desctrizionePiano
				window.parent.frames(1).setServizio("")
				window.parent.frames(1). setIdServizio("")
				blId=idEdificio
				flId=idPiano
				document.getElementById("<%=idEdif.ClientID%>").value=blId
				document.getElementById("<%=idPian.ClientID%>").value=flId
				
				'msgbox "-"&document.getElementById("hiddenPlanimetria").value&"-"
				if document.getElementById("hiddenPlanimetria").value <> "" then
					parent.frames(1).SetPlanimetria ""
					
					parent.frames(2).window.location = "CAD/CadViewer.aspx"
				end if
				
				setPlanimetria ""
				
				'msgBox("Hai selezionato il " + desctrizionePiano+ "\ndell'edificio " + codiceEdificio)
				parent.frames(3).window.location="bottomFrame.aspx?idBl="&blId&"&idFl="&flId
				
				'document.getElementById("<%=WebUserControlTreeView1.GetClientId()%>").nodes(1)'.DefaultStyle.Add "background","#ff0000"
			end function
		</SCRIPT>
</HEAD>
	<BODY onbeforeunload="chiudi();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE width="100%" border="0">
				<TR>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD><A class="subsectionCad" href="javascript:VisualizzaBl();">Navigazione</A></TD>
				</TR>
				<TR>
					<TD><A class="subsectionCad" href="javascript:VisualizzaApp();">Gestione Spazi Apparati</A></TD>
				</TR>
				<!--<TR>
					<TD style="VISIBILITY: hidden"><A class="subsectionCad" href="" target="_blank">Help</A></TD>
				</TR>-->
			</TABLE>
			<DIV id="bl" style="BACKGROUND-COLOR: #ffffcc">
				<ASP:TEXTBOX id="txtFiltraBlTree" runat="server" WIDTH="100px"></ASP:TEXTBOX>
				&nbsp;
				<ASP:BUTTON id="btnVisualizzaBlTree" runat="server" text="Filtra Bl" cssclass="btn"></ASP:BUTTON>
				<P><UC1:WEBUSERCONTROLTREEVIEW id="WebUserControlTreeView1" runat="server"></UC1:WEBUSERCONTROLTREEVIEW>
					<ASP:TEXTBOX id="idEdif" runat="server"></ASP:TEXTBOX>
					<ASP:TEXTBOX id="idPian" runat="server"></ASP:TEXTBOX>
					<ASP:TEXTBOX id="idServ" runat="server"></ASP:TEXTBOX></P>
			</DIV>
			<DIV id="app"><UC1:MYDROPDOWNLIST id="CategorieDropDownList" runat="server"></UC1:MYDROPDOWNLIST><UC1:MYDROPDOWNLIST id="repartiDropDownList" runat="server"></UC1:MYDROPDOWNLIST><UC1:MYDROPDOWNLIST id="destUsoDropDownList" runat="server"></UC1:MYDROPDOWNLIST>
				<P>
					<!--selezione stanza-->
					<INPUT class="btn" id="btStanze" style="WIDTH: 18%; HEIGHT: 24px" onclick="OpenStanze();"
						type="button" value="Rm"> <INPUT id="filtroRm" type="text" style="WIDTH: 80%"><BR>
					<INPUT id="hiddenStanze" type="hidden" runat="server"> <INPUT id="stanzeDescription" type="hidden" name="Hidden1" runat="server">
					<SELECT id="ListBoxStanze" style="WIDTH: 100%; HEIGHT: 80px" size="4" name="ListBoxStanze"
						runat="server">
						<OPTION value="">- Tutte le stanze -</OPTION>
					</SELECT><BR>
					<!--selezione std app--><INPUT class="btn" id="btEqstd" style="WIDTH: 18%; HEIGHT: 24px" onclick="OpenEqstd();"
						type="button" value="Std"> <INPUT id="filtroStd" type="text" style="WIDTH: 80%"><BR>
					<INPUT id="hiddenEqstd" type="hidden" runat="server"> <INPUT id="eqStdDescription" type="hidden" runat="server">
					<SELECT id="ListBoxEQSTD" style="WIDTH: 100%; HEIGHT: 80px" size="4" name="ListBoxEQSTD"
						runat="server">
						<OPTION value="">- Tutti gli Standard Apparechiatura -</OPTION>
					</SELECT><BR>
					<!--selezione app-->
					<INPUT class="btn" id="btEq" style="WIDTH: 18%; HEIGHT: 24px" onclick="OpenEq();" type="button"
						value="App"> <INPUT id="filtroApp" type="text" style="WIDTH: 80%"><BR>
					<INPUT id="hiddenEq" type="hidden" runat="server"> <INPUT id="eqDescription" type="hidden" name="eqDescription" runat="server">
					<SELECT id="listBoxEQ" style="WIDTH: 100%; HEIGHT: 80px" size="4" name="listBoxEQ" runat="server">
						<OPTION value="">- Tutte le Apparecchiature -</OPTION>
					</SELECT>
					<!-- comapo plan selezionata-->
					<INPUT id="hiddenPlanimetria" type="hidden" name="Hidden1" runat="server">
					<TABLE id="tblGoBottomFrame" width="100%">
						<TR>
							<TD>
								<INPUT class="btn" id="btnVisualizzaSp" style="WIDTH: 100%" onclick="SendParameterToBottomFrame(2)"
									type="button" value="Visualizza Rm">
							</TD>
							<TD>
								&nbsp;
							</TD>
							<TD>
								<INPUT class="btn" id="btnVisualizzaEq2" style="WIDTH: 100%" onclick="SendParameterToBottomFrame(3)"
									type="button" value="Visualizza App">
							</TD>
						</TR>
					</TABLE>
				</P>
			</DIV>
			<!--<div id="divelinkPost" style="OVERFLOW: scroll; WIDTH: 100%; HEIGHT: 178px"><iframe id="frameLink" name="frameLink" src="ListLink.aspx" width="98%"></iframe>
			</div>--></FORM>
		<SCRIPT language="javascript">
			crtl=document.getElementById('<%=idEdif.ClientID%>').style; 
			crtl.display="none";
			crtl=document.getElementById('<%=idPian.ClientID%>').style; 
			crtl.display="none";
			crtl=document.getElementById('<%=idServ.ClientID%>').style; 
			crtl.display="none";
			<%if (contesto=="edificio"){%>
			crtl=document.getElementById('bl').style; 
			crtl.display="block";
			crtl=document.getElementById('app').style; 
			crtl.display="none";
			<%}%>
			<%if (contesto=="navigazione"){%>
			crtl=document.getElementById('bl').style; 
			crtl.display="none";
			crtl=document.getElementById('app').style; 
			crtl.display="block";
			<%}%>
		
	
		</SCRIPT>
	</BODY>
</HTML>
