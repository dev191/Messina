<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="VisualizzaSolleciti" Src="VisualizzaSolleciti.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="UserRdlInail.ascx.cs" Inherits="TheSite.WebControls.UserRdlInail" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="uc1" TagName="AggiungiSollecito" Src="AggiungiSollecito.ascx" %>
<SCRIPT language="javascript" src="../images/cal/popcalendar.js"></SCRIPT>
<SCRIPT language="javascript">

var NS4 = (navigator.appName == "Netscape" && parseInt(navigator.appVersion) < 5);
		var NSX = (navigator.appName == "Netscape");
		var IE4 = (document.all) ? true : false;
		
			
			
function valutanumeri(evt)
{
	var e = evt? evt : window.event; 
	if(!e) return; 
	var key = 0; 
	
	if(IE4==true)
	{
		if (e.keyCode < 48	|| e.keyCode > 57){
			e.keyCode = 0;
			return false;
		}	
	}
	
	if (e.keycode) { key = e.keycode; } // for moz/fb, if keycode==0 use 'which' 
	if (typeof(e.which)!= 'undefined') { 
		key = e.which;
		if (key < 48	|| key > 57){
			return false;
		} 
		
	} 
}
		

 function imposta_dec(obj)
{
	val=document.getElementById(obj).value;
	if(val=="")
		document.getElementById(obj).value="00";
	if(val.length==1)	
		document.getElementById(obj).value=val+"0";
}

function imposta_int(obj)
{
	if(document.getElementById(obj).value=="")
		document.getElementById(obj).value="0";		
}


	function AddHour(var_s,caselladitesto)
	{
		var hh = 0.0;
		var txt = document.getElementById(caselladitesto)
		
		if( txt.value < 0 || txt.value > 24 ) {
			txt.value = 0;
		}

		hh =  txt.value/1 + var_s;

		if( hh == "NaN"){
			hh = 0;
		}

		if( hh >= 24 )
		{
			hh = 0;
		}
		
		if( hh < 0 )
		{
			hh = 23;
		}
		
		var str = ( ( hh < "10" )? "0" : "") + hh;
		if( str == "NaN" ) {
			str = "00";
		}

		txt.value = str;
	}

	function AddMinute(var_s,caselladitesto)
	{
		var mm = 0.0;
		var txt = document.getElementById(caselladitesto)
		
		if( txt.value < 0 || txt.value >= 60 ) {
			txt.var_mm.value = 0;
		}

		mm =  txt.value/1 + var_s*15;

		if( mm == "NaN" )
		{
			mm = 0;
		}

		if( mm >= 60 )
		{
			mm = 0;
		}
		
		if( mm < 0 )
		{
			mm =45;
		}
		
		var str = ( ( mm < "10" )? "0" : "") + mm;
		if( str == "NaN" ) {
			str = "00";
		}

		txt.value = str;
	}
	function SetWorkType(Stato)
	{
	   //trconsuntivo1.ClientID
	   
	    var crtl;
		switch (Stato)
		{
			case "4": //Attività completata
			    var combTipoMan=document.getElementById('<%=cmbsTipoManutenzione.ClientID%>');
			     
					crtl=document.getElementById('<%=trsoddisfazione.ClientID%>').style;
					crtl.display="block";
					crtl=document.getElementById('<%=trannotazione.ClientID%>').style;
					crtl.display="block";
				if(combTipoMan.options[combTipoMan.selectedIndex].value=="3")
			    {	
					
					crtl=document.getElementById('<%=trannocontab.ClientID%>').style; 
					crtl.display="block";
					crtl=document.getElementById('<%=trconsuntivo1.ClientID%>').style; 
					crtl.display="block";
					crtl=document.getElementById('<%=trconsuntivo2.ClientID%>').style; 
					crtl.display="block";
					crtl=document.getElementById('<%=trconsuntivo3.ClientID%>').style; 
					crtl.display="block";
				}
				crtl=document.getElementById('<%=trnote.ClientID%>').style; 
				crtl.display="none";				
				break;
			case "11": //Emessa ma sospesa per Inaccessibilità				
			case "12": //Emessa ma sospesa per approvviggiovamento				
			case "14": //Emessa ma sospesa dal committente			
			case "8": //Emessa ma sospesa 
			case "13": //Emessa ma in sospeso per intervento specialistico
			   
			    crtl=document.getElementById('<%=trnote.ClientID%>').style; 
				crtl.display="block";
				crtl=document.getElementById('<%=trconsuntivo1.ClientID%>').style; 
				crtl.display="none";
				crtl=document.getElementById('<%=trconsuntivo2.ClientID%>').style; 
				crtl.display="none";
				crtl=document.getElementById('<%=trconsuntivo3.ClientID%>').style; 
				crtl.display="none";
				crtl=document.getElementById('<%=trannocontab.ClientID%>').style; 
				crtl.display="none";
				crtl=document.getElementById('<%=trsoddisfazione.ClientID%>').style
				crtl.display="none";
				crtl=document.getElementById('<%=trannotazione.ClientID%>').style;
				crtl.display="none";
				break;
			default:
			 
			    crtl=document.getElementById('<%=trnote.ClientID%>').style; 
				crtl.display="none";
				document.getElementById('<%=txtsSospesa.ClientID%>').value = "";
				crtl=document.getElementById('<%=trconsuntivo1.ClientID%>').style; 
				crtl.display="none";
				crtl=document.getElementById('<%=trconsuntivo2.ClientID%>').style; 
				crtl.display="none";
				crtl=document.getElementById('<%=trconsuntivo3.ClientID%>').style; 
				crtl.display="none";
				crtl=document.getElementById('<%=trannocontab.ClientID%>').style; 
				crtl.display="none";
				crtl=document.getElementById('<%=trsoddisfazione.ClientID%>').style
				crtl.display="none";
				crtl=document.getElementById('<%=trannotazione.ClientID%>').style;
				crtl.display="none";
				
				//document.getElementById('<%=txtSpesa3.ClientID%>').value = "";
				//document.getElementById('<%=txtSpesa4.ClientID%>').value = "";
				break;
		}		
	}
	function SetPreventivo(Stato)
	{
	   //trconsuntivo1.ClientID
	   
	    var crtl;
		switch (Stato)
		{
			case "3": //Straordinaria
			    crtl=document.getElementById('<%=tipointervento0.ClientID%>').style; 
				crtl.display="block";
			    crtl=document.getElementById('<%=tipointervento1.ClientID%>').style; 
				crtl.display="block";
				crtl=document.getElementById('<%=tipointervento2.ClientID%>').style; 
				crtl.display="block";		
				break;
			case "1": //Ordinaria	
			    crtl=document.getElementById('<%=tipointervento0.ClientID%>').style; 
				crtl.display="none";			
				crtl=document.getElementById('<%=tipointervento1.ClientID%>').style; 
				crtl.display="none";
				crtl=document.getElementById('<%=tipointervento2.ClientID%>').style; 
				crtl.display="none";
				break;
			default:
			    crtl=document.getElementById('<%=tipointervento0.ClientID%>').style; 
				crtl.display="none";
			 	crtl=document.getElementById('<%=tipointervento1.ClientID%>').style; 
				crtl.display="none";
				crtl=document.getElementById('<%=tipointervento2.ClientID%>').style; 
				crtl.display="none";
				break;
		}		
	}
	function ApriPopUp(url)
	{	
		var windowW = 1024;  
		var windowH = 768;	
		W = window.open(url,'Rapporto','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width='+windowW+',height='+windowH+',align=center');			
	}
	
	function validateDate()
	{
	
	   if(ControllaData()==false)
	      return false;
	

	   //importo preventivo
		var ctrlnumeroIC1=document.getElementById('<%=txtSpesa3.ClientID%>');
		if (ctrlnumeroIC1.value=="") 
		{
			alert("Inserire l'importo del consuntivo!");
			return false;
		}
		
	    //se è stata selezionata la combo degli stati ad attività completata non
	   //deve fare il controllo sulle date
	   
	    var ctrlstato=document.getElementById('<%=cmbsstatolavoro.ClientID%>');
		if(ctrlstato!=null)
		{
			if ((ctrlstato.selectedIndex!=-1)) 
			{
				if(ctrlstato.value!="4")
				   return true;
			}
		}
		
	    if(validateRange()==false)
	      return false;

	   //return false; blocca il postback
	  //Validazione delle Date
	  //Combo delle Urgenze
	  var cmbo=document.getElementById('<%=cmbsUrgenza.ClientID%>'); 
	  var selur =cmbo.options[cmbo.selectedIndex].value.split(",");
	  
	    //recupero la data inizio Lavori
	    var datai=document.getElementById('<%=CalendarPicker2.Datazione.ClientID%>').value; 
	    var orarioi=document.getElementById('<%=cmbsOraInizio.ClientID%>').value;
	    var orarioi2=document.getElementById('<%=cmbsMinutiInizio.ClientID%>').value;
	    if (datai=="")
	    {
	      alert("Inserire la Data inizio lavori!" ) ;	
		  return false;
	    }
	  /*  if (orarioi=="00")
	    {
	      alert("Inserire la l'orario di inizio dei lavori!" ) ;	
		  return false;
	    }*/
	    
	    var ds=datai.split("/");
	    var dinizio=new Date(ds[2],ds[1]-1,ds[0],orarioi,orarioi2);
	    //var dinizio=ds[2]+ds[1]+ds[0]+orarioi+orarioi2;
	  if (selur[1]!="")
	  {
	    //se esiste l'orario di intervento controllo che la data richiesta
	    //recupero la data pianificata /richiesta
	    var datap=document.getElementById('<%=lblDataRichiesta.ClientID%>').innerText; 
	    var orariop=document.getElementById('<%=lblOraRichiesta.ClientID%>').innerText;
	    var d1=datap.split("/");
	    var o1=orariop.split(".");
	    
	    //var dpianificata=new Date(d1[2],d1[1],d1[0],o1[0],o1[1]);
	    var dpianificata=new Date(d1[2],d1[1]-1,d1[0],o1[0],o1[1]);
			if ((dinizio - dpianificata)/(1000 * 60 * 60) > selur[1])
			{
				var ask = window.confirm("Data non conforme al capitolato. Continuare?" );
				return ask;
			}	
			else
			{
				if (dpianificata>dinizio)
				{
					alert("La Data Inizio Lavori  è minore della Data richiesta Lavoro!" ) ;	
					return false;					
				}	
				else
				{						
					return true;
				}			
			}	
			return true;	
	  }//end if di selur[1]
	  
	     
	    
	}
	function validateRange()
	{
	  
		
		//recupero la data inizio Lavori
	    var datai=document.getElementById('<%=CalendarPicker2.Datazione.ClientID%>').value; 
	    var orarioi1=document.getElementById('<%=cmbsOraInizio.ClientID%>').value;
	    var orarioi2=document.getElementById('<%=cmbsMinutiInizio.ClientID%>').value;
	    if (datai=="")
	    {
	      alert("Inserire la Data inizio lavori!" ) ;	
		  return false;
	    }
	   /* if (orarioi1=="00")
	    {
	      alert("Inserire la l'orario di inizio dei lavori!" ) ;	
		  return false;
	    }*/
	    
	    var datasplit1=datai.split("/");
	    //var dinizio=new Date(datasplit1[2],datasplit1[1]-1,datasplit1[0],orarioi1,orarioi2,00);
	     var dinizio=datasplit1[2] + datasplit1[1] + datasplit1[0] + orarioi1 + orarioi2;
		//recupero la data fine Lavori
		 var dataf=document.getElementById('<%=CalendarPicker3.Datazione.ClientID%>').value; 
		 var orariof1=document.getElementById('<%=cmbsOraFine.ClientID%>').value;
		 var orarioif2=document.getElementById('<%=cmbsMinutiFine.ClientID%>').value;
		if (dataf=="")
		{
			alert("Inserire la Data Fine Lavori!" ) ;	
			return false;
		}
		/*if (orariof1=="00")
		{
			alert("Inserire la l'orario di Fine dei Lavori!" ) ;	
			return false;
		}  */
		
		var datasplit2=dataf.split("/");
	    //var dfine=new Date(datasplit2[2],datasplit2[1],datasplit2[0],orariof1,orarioif2,00);
        var dfine=datasplit2[2] + datasplit2[1] + datasplit2[0] + orariof1 + orarioif2;
          
	    if (dinizio>dfine)
	    {
	      alert("Data Inizio Lavori non può essere maggiore della Data Fine Lavori!");
	      return false;
	    }else
	    {
	      return true;
	    }
	}
	
	function Ripristina(sender,name)
	{
	 sender.disabled=false;
	 sender.value= name;
	}
	function ControllaData()
	{
	
	    if(controllaimporto()==false)
	       return false;
	       
		if(ControllaCombo()==false)
	      return false;
	      
		var oremagg= document.getElementById('<%=cmbsOre.ClientID%>').value
		var minutimagg=document.getElementById('<%=cmbsMinuti.ClientID%>').value	
		var datamagg = document.getElementById('<%=CalendarPicker1.Datazione.ClientID%>').value
		
		var datamin = document.getElementById('<%=lblDataRichiesta.ClientID%>').innerText
		var oramin=document.getElementById('<%=lblOraRichiesta.ClientID%>').innerText
				
		var orario=oramin.split(".");
		
		var ore = orario[0];
		var minuti= orario[1]; 
			
		if (ore.length==1)
		{
			ore= "0" + ore;
		}
		
		if (minuti.length==1)
		{
			minuti= "0" + minuti;
		}
		
		oramin = ore + minuti;
			 
					
		if (datamagg=="")
		{
			alert("La data di Pianificazione è obbligatoria");
			document.getElementById('<%=CalendarPicker1.Datazione.ClientID%>').focus();
			return false;
		}
		
		var Data1 = datamagg.substr(6,4) + datamagg.substr(3,2) + datamagg.substr(0,2);	
		Data1 = Data1 + oremagg + minutimagg
		
		var Data2 = datamin.substr(6,4) + datamin.substr(3,2) + datamin.substr(0,2);	
		//Data2 = Data2 + oramin.substr(0,2) + oramin.substr(3,2)
		Data2 = Data2 + oramin;
						
				
		if (Data2>Data1)
		{
			alert("La data Pianificata non è corretta. Inserire una data successiva a quella della Richiesta.");
			document.getElementById('<%=CalendarPicker1.Datazione.ClientID%>').focus();
			return false;
		}
				
		return true;						
	}	

	function ControllaCombo()
	{
		var ctrlditta=document.getElementById('<%=cmbsDitta.ClientID%>');
		if ((ctrlditta.selectedIndex==-1))// || (ctrlditta.selectedIndex==0)) 
		{
			alert("Selezionare una Ditta!");
			return false;
		}
		var ctrladdetto=document.getElementById('<%=cmbsAddetto.ClientID%>');
		if ((ctrladdetto.selectedIndex==-1) || (ctrladdetto.selectedIndex==0)) 
		{
			alert("Selezionare un Addetto!");
			return false;
		}
		
		var ctrlservizio=document.getElementById('<%=cmbsServizio.ClientID%>');
		if ((ctrlservizio.selectedIndex==-1) || (ctrlservizio.selectedIndex==0)) 
		{
			alert("Selezionare il Servizio!");
			return false;
		}
		var ctrTipoInter=document.getElementById('<%=cmbsTipoManutenzione.ClientID%>');
		if (ctrTipoInter.options[ctrTipoInter.selectedIndex].value=="3") 
		{
			//Numero preventivo
			var ctrlnumeroP=document.getElementById('<%=txtNumeroPreventivo.ClientID%>');
			/*if(ctrlnumeroP!=null)
				if (ctrlnumeroP.value=="") 
				{
					alert("Inserire il numero del preventivo!");
					ctrlnumeroP.focus();
					return false;
				}*/
				
		//importo preventivo
			var ctrlnumeroIP1=document.getElementById('<%=txtSpesa1.ClientID%>');
			if(ctrlnumeroIP1!=null)
				if (ctrlnumeroIP1.value=="") 
				{
				    ctrlnumeroIP1.focus();
					alert("Inserire l'importo del preventivo!");
					return false;
				}
		}
		
		
		var ctrlstato=document.getElementById('<%=cmbsstatolavoro.ClientID%>');
		if(ctrlstato!=null)
		{
			if ((ctrlstato.selectedIndex==-1) || (ctrlstato.selectedIndex==0)) 
			{
				alert("Selezionare lo Stato di Richiesta di Lavoro!");
				return false;
			}
		}
	}
 var finestra;		
 
 function openpdf(sender,path,namefile)
 {
   var url;		
   namefile=namefile.replace("`","'");
   url = "Visualpdf.aspx?wr_id=" + sender + "&path=" + path + "&name=" +namefile;
   finestra=window.open(url,'','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width=800,height=600,align=center');	
 }	
 
 function chiudi()
 {
   if (finestra!=null)
		      finestra.close();
 }

 function controllaimporto()
 {
   /*var ctrlTipoMan=document.getElementById('<%=cmbsTipoManutenzione.ClientID%>');
   if(ctrlTipoMan.options[ctrlTipoMan.selectedIndex].value!="3")
      return;
   
   
   var ctrlspesa=document.getElementById('<%=txtspesaPresunta1.ClientID%>').value;
   ctrlspesa=ctrlspesa.replace(".","")
   ctrlspesa=ctrlspesa + "." + document.getElementById('<%=txtspesaPresunta2.ClientID%>').value;
   ctrlspesa=parseFloat(ctrlspesa);
   if(document.getElementById('<%=txtSpesa1.ClientID%>')==null)
   return;
   
		var ctrlpreventivo1=document.getElementById('<%=txtSpesa1.ClientID%>').value;
		var ctrlpreventivo2=document.getElementById('<%=txtSpesa2.ClientID%>').value;
		var ctrlpreventivo=parseFloat(ctrlpreventivo1 + "." + ctrlpreventivo2);
		if(ctrlpreventivo >ctrlspesa)
		{
			alert("L'importo del preventivo non può essere maggiore della spesa presunta!");
			return false;
		 }
	
	*/
	return true;
	       
 }
 
 function ControllaDateSpesaPresunta()
{
 var ctrlTipoMan=document.getElementById('<%=cmbsTipoManutenzione.ClientID%>');
   if(ctrlTipoMan.options[ctrlTipoMan.selectedIndex].value!="3")
      return;
      
 var ctrDataIni=document.getElementById('<%=CalendarPicker4.Datazione.ClientID%>').value;
 var ctrDataEnd=document.getElementById('<%=CalendarPicker5.Datazione.ClientID%>').value;	  
	if (ctrDataIni=="")
	{
		alert("Inserire la Data prevista inizio lavori!" ) ;	
		return false;
	} 
	if (ctrDataEnd=="")
	{
		alert("Inserire la Data prevista fine lavori!" ) ;	
		return false;
	} 
  var ds=ctrDataIni.split("/");
  var dinizio=new Date(ds[2],ds[1]-1,ds[0],00,00);
  var de=ctrDataEnd.split("/");
  var dfine=new Date(de[2],de[1]-1,de[0],00,00);

  if(dinizio>dfine)
  {
    alert("La data prevista di inizio lavori non può essere maggiore della data di fine!" ) ;	
	return false;
  }
  
  
  var ctrlOrdineAter=document.getElementById('<%=txtOrdineLavoro.ClientID%>');
  /*if(ctrlOrdineAter.value=="")
  {
    alert("L'ordine di lavoro è obbligatorio!" ) ;	
    ctrlOrdineAter.focus();
	return false;
  }*/
  
    var ctrlspesa=document.getElementById('<%=txtspesaPresunta1.ClientID%>');
  if(ctrlspesa.value=="")
  {
    alert("Inserire la spesa presunta!" ) ;	
    ctrlspesa.focus();
	return false;
  }
  return true;
}
</SCRIPT>
<TABLE id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
	<TR>
		<TD><ASP:LABEL id="lblOperazione" runat="server" cssclass="TitleOperazione"></ASP:LABEL><CC2:MESSAGEPANEL id="PanelMess" runat="server" width="136px" erroriconurl="~/Images/ico_critical.gif"
				messageiconurl="~/Images/ico_info.gif"></CC2:MESSAGEPANEL></TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 513px"><CC2:DATAPANEL id="PanelGeneral" runat="server" cssclass="DataPanel75" titlestyle-cssclass="TitleSearch"
				collapsed="False" titletext="Creazione Richiesta di Lavoro" expandtext="Espandi" expandimageurl="../Images/down.gif"
				collapsetext="Riduci" collapseimageurl="../Images/up.gif" allowtitleexpandcollapse="True">
				<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" width="100%" border="0">
					<TR>
						<TD style="HEIGHT: 12px" width="20%"><B>RDL N°</B></TD>
						<TD style="WIDTH: 169px; HEIGHT: 12px">
							<ASP:LABEL id="LblRdl" runat="server" width="174px"></ASP:LABEL></TD>
						<TD style="HEIGHT: 12px"><B>Trasmissione:</B></TD>
						<TD style="HEIGHT: 12px">
							<CC1:S_COMBOBOX id="cmbsTrasmissione" runat="server" width="192px"></CC1:S_COMBOBOX></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 12px"><B>Nominativo Richiedente:</B></TD>
						<TD style="WIDTH: 169px; HEIGHT: 12px">
							<ASP:LABEL id="lblRichiedente" runat="server" width="174px"></ASP:LABEL></TD>
						<TD style="HEIGHT: 12px"><B>Operatore:</B></TD>
						<TD style="HEIGHT: 12px">
							<ASP:LABEL id="lblOperatore" runat="server" width="128px"></ASP:LABEL></TD>
					</TR>
					<TR>
						<TD><B>Telefono Richiedente:</B></TD>
						<TD>
							<ASP:LABEL id="lbltelefonoric" runat="server" width="174px"></ASP:LABEL></TD>
						<TD style="HEIGHT: 29px"><B>Data Richiesta:</B></TD>
						<TD style="HEIGHT: 29px">
							<ASP:LABEL id="lblDataRichiesta" runat="server" width="128px"></ASP:LABEL></TD>
					</TR>
					<TR>
						<TD><B>Gruppo Richiedente:</B></TD>
						<TD style="WIDTH: 169px">
							<ASP:LABEL id="lblGruppo" runat="server" width="174px"></ASP:LABEL></TD>
						<TD><B>Orario Richiesta:</B></TD>
						<TD>
							<ASP:LABEL id="lblOraRichiesta" runat="server" width="128px"></ASP:LABEL></TD>
					</TR>
					<TR>
						<TD><B>Email Richiedente:</B></TD>
						<TD style="WIDTH: 169px">
							<ASP:LABEL id="lblemailric" runat="server" width="174px"></ASP:LABEL></TD>
						<TD><B>Stanza Richiedente:</B></TD>
						<TD>
							<ASP:LABEL id="lblstanzaric" runat="server" width="128px"></ASP:LABEL></TD>
					</TR>
					<TR>
						<TD><B>Fabbricato:</B></TD>
						<TD colSpan="3">
							<ASP:LABEL id="lblfabbricato" runat="server" width="472px"></ASP:LABEL>
							<ASP:TEXTBOX id="txtHidBl" runat="server" width="0px" visible="False"></ASP:TEXTBOX></TD>
					</TR>
					<TR>
						<TD><B>Piano:</B></TD>
						<TD style="WIDTH: 169px">
							<ASP:LABEL id="lblPiano" runat="server" width="174px"></ASP:LABEL></TD>
						<TD><B>Stanza:</B></TD>
						<TD>
							<ASP:LABEL id="lblStanza" runat="server" width="174px"></ASP:LABEL></TD>
					</TR>
					<TR>
						<TD><B>Telefono:</B></TD>
						<TD colSpan="3">
							<ASP:LABEL id="lblTelefono" runat="server" width="174px"></ASP:LABEL></TD>
					<TR>
						<TD><B>Note:</B></TD>
						<TD colSpan="3">
							<ASP:LABEL id="lblNote" runat="server" width="472px"></ASP:LABEL></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 24px"><B>Servizio:</B></TD>
						<TD style="HEIGHT: 24px" colSpan="3">
							<CC1:S_COMBOBOX id="cmbsServizio" runat="server" width="480px" autopostback="True"></CC1:S_COMBOBOX></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 17px"><B>Standard Apparecchiatura:</B></TD>
						<TD style="HEIGHT: 17px" colSpan="3">
							<CC1:S_COMBOBOX id="cmdsStdApparecchiatura" runat="server" width="480px" autopostback="True" dbindex="1"
								dbdirection="Input" dbdatatype="Integer" dbparametername="p_eqstd_id" dbsize="10"></CC1:S_COMBOBOX></TD>
					</TR>
					<TR>
						<TD><B>Apparecchiatura:</B></TD>
						<TD colSpan="3">
							<CC1:S_COMBOBOX id="cmbEQ" runat="server" width="480px" dbindex="1" dbdirection="Input" dbdatatype="Integer"
								dbparametername="p_id_eq" dbsize="10"></CC1:S_COMBOBOX></TD>
					</TR>
					<TR>
						<TD><B>Descrizione Intervento:</B></TD>
						<TD colSpan="3">
							<CC1:S_TEXTBOX id="txtsDescrizione" runat="server" width="480px" textmode="MultiLine" height="120px"></CC1:S_TEXTBOX></TD>
					</TR>
				</TABLE>
				<UC1:VISUALIZZASOLLECITI id="VisualizzaSolleciti1" runat="server"></UC1:VISUALIZZASOLLECITI>
			</CC2:DATAPANEL></TD>
	</TR>
	<TR>
		<TD><CC2:DATAPANEL id="PanelDCSIT" runat="server" cssclass="DataPanel75" titlestyle-cssclass="TitleSearch"
				collapsed="False" titletext="Validazione da parte del COLLABORATORE" expandtext="Espandi" expandimageurl="../Images/down.gif"
				collapsetext="Riduci" collapseimageurl="../Images/up.gif" allowtitleexpandcollapse="True" visible="False">
				<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD colSpan="4">&nbsp;
							<CC1:S_BUTTON id="btsApprovaDCSIT" runat="server" width="128px" text="Approva"></CC1:S_BUTTON>&nbsp;
							<CC1:S_BUTTON id="btsRifiutaDCSIT" runat="server" width="128px" text="Rifiuta" causesvalidation="False"></CC1:S_BUTTON></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 170px; HEIGHT: 12px"><B>Data di validazione:</B></TD>
						<TD>
							<CC1:S_LABEL id="lbldatavalidDCSIT" runat="server"></CC1:S_LABEL></TD>
						<TD style="WIDTH: 143px; HEIGHT: 17px"><B>Ora validazione:</B></TD>
						<TD>
							<CC1:S_LABEL id="lblOraValidDCSIT" runat="server"></CC1:S_LABEL></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 172px; HEIGHT: 17px"><B>Utente:</B></TD>
						<TD>
							<CC1:S_LABEL id="lblUtenteDCSIT" runat="server"></CC1:S_LABEL></TD>
						<TD style="WIDTH: 143px; HEIGHT: 17px"><B>Stato:</B></TD>
						<TD>
							<CC1:S_LABEL id="lblStatoDCSIT" runat="server"></CC1:S_LABEL></TD>
					</TR>
				</TABLE>
			</CC2:DATAPANEL></TD>
	</TR>
	<TR>
		<TD><CC2:DATAPANEL id="PanelDL" runat="server" cssclass="DataPanel75" titlestyle-cssclass="TitleSearch"
				collapsed="False" titletext="Validazione da parte del Responsabile della Manutenzione" expandtext="Espandi"
				expandimageurl="../Images/down.gif" collapsetext="Riduci" collapseimageurl="../Images/up.gif"
				allowtitleexpandcollapse="True">
				<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD colSpan="4">&nbsp;
							<CC1:S_BUTTON id="btsApprovaDL" runat="server" width="128px" text="Approva"></CC1:S_BUTTON>&nbsp;
							<CC1:S_BUTTON id="btsRifiutaDL" runat="server" width="128px" text="Rifiuta" causesvalidation="False"></CC1:S_BUTTON></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 170px; HEIGHT: 12px"><B>Data di validazione:</B></TD>
						<TD>
							<CC1:S_LABEL id="lblDataValidDL" runat="server"></CC1:S_LABEL></TD>
						<TD style="WIDTH: 143px; HEIGHT: 17px"><B>Ora validazione:</B></TD>
						<TD>
							<CC1:S_LABEL id="lblOraValidDL" runat="server"></CC1:S_LABEL></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 170px; HEIGHT: 12px"><STRONG>Tipo Manutenzione:</STRONG></TD>
						<TD>
							<CC1:S_COMBOBOX id="cmbsTipoManutenzione" runat="server" width="196px"></CC1:S_COMBOBOX></TD>
						<TD colSpan="2"><STRONG>Lavoro da quantificare successivamente&nbsp;:</STRONG>
							<CC1:S_CHECKBOX id="checkQuantifica" runat="server" dbdirection="Input" dbdatatype="Integer" font-bold="True"></CC1:S_CHECKBOX></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 172px; HEIGHT: 17px"><STRONG>Utente:</STRONG></TD>
						<TD>
							<CC1:S_LABEL id="lblUtenteDL" runat="server"></CC1:S_LABEL></TD>
						<TD style="WIDTH: 143px; HEIGHT: 17px"><B>Stato:</B></TD>
						<TD>
							<CC1:S_LABEL id="lblStatoDL" runat="server"></CC1:S_LABEL></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR id="preventivo1" runat="server">
						<TD><B>Preventivo n°<EM>(max 8 caratteri):</EM></B></TD>
						<TD style="WIDTH: 169px">
							<CC1:S_TEXTBOX id="txtNumeroPreventivo" runat="server" width="196px" dbsize="8" maxlength="8"></CC1:S_TEXTBOX></TD>
						<TD><B>Importo Preventivo:</B></TD>
						<TD>
							<CC1:S_TEXTBOX id="txtSpesa1" style="TEXT-ALIGN: right" runat="server" width="107px" maxlength="8">0</CC1:S_TEXTBOX>,
							<CC1:S_TEXTBOX id="txtSpesa2" runat="server" width="27px" maxlength="2">00</CC1:S_TEXTBOX></TD>
					</TR>
					<TR id="preventivo2" runat="server">
						<TD><B>Importa Preventivo(PDF):</B></TD>
						<TD style="WIDTH: 169px" colSpan="3"><INPUT id="UploadFilePreventivo" style="WIDTH: 352px; HEIGHT: 22px" type="file" size="39"
								name="UploadFilePreventivo" runat="server"></TD>
					</TR>
					<TR id="preventivo3" runat="server">
						<TD colSpan="4"><!--<B>Preventivo n°<EM>(max 8 caratteri):</EM></B>
							<cc1:S_Label id="lblPreventivo" runat="server"></cc1:S_Label>&nbsp;<B>Importo 
								Preventivo:</B>
							<cc1:S_Label id="lblPreventivoImporto" runat="server"></cc1:S_Label>&nbsp;<B>File 
								Preventivo:&nbsp;</B>-->
							<CC1:S_HYPERLINK id="LinkPreventivo" runat="server"></CC1:S_HYPERLINK></TD>
					</TR>
					<TR id="tipointervento0" runat="server">
						<TD style="WIDTH: 172px; HEIGHT: 17px"><STRONG>Ordine di lavoro UNIBA:</STRONG></TD>
						<TD>
							<CC1:S_TEXTBOX id="txtOrdineLavoro" runat="server"></CC1:S_TEXTBOX></TD>
						<TD style="WIDTH: 143px; HEIGHT: 17px"></TD>
						<TD colSpan="3"></TD>
					</TR>
					<TR id="tipointervento1" runat="server">
						<TD style="WIDTH: 172px; HEIGHT: 17px"><STRONG>Tipo Intervento:</STRONG></TD>
						<TD>
							<CC1:S_COMBOBOX id="cmbsTipoIntrevento" runat="server" width="224px" dbdatatype="Integer"></CC1:S_COMBOBOX></TD>
						<TD style="DISPLAY: none; WIDTH: 143px; HEIGHT: 17px"><STRONG>Spesa Presunta:</STRONG></TD>
						<TD style="DISPLAY: none" colSpan="3">
							<CC1:S_TEXTBOX id="txtspesaPresunta1" style="TEXT-ALIGN: right" runat="server" width="154px" maxlength="8">00</CC1:S_TEXTBOX>,
							<CC1:S_TEXTBOX id="txtspesaPresunta2" runat="server" width="32px" maxlength="2">00</CC1:S_TEXTBOX></TD>
					</TR>
					<TR id="tipointervento2" runat="server">
						<TD style="WIDTH: 172px; HEIGHT: 17px"><STRONG>Data prevista Inizio:</STRONG></TD>
						<TD>
							<UC1:CALENDARPICKER id="CalendarPicker4" runat="server"></UC1:CALENDARPICKER></TD>
						<TD style="WIDTH: 143px; HEIGHT: 17px"><STRONG>Data Fine:</STRONG></TD>
						<TD colSpan="3">
							<UC1:CALENDARPICKER id="CalendarPicker5" runat="server"></UC1:CALENDARPICKER></TD>
					</TR>
				</TABLE>
			</CC2:DATAPANEL></TD>
	</TR>
	<TR>
		<TD><CC2:DATAPANEL id="PanelCofatec" runat="server" cssclass="DataPanel75" titlestyle-cssclass="TitleSearch"
				collapsed="False" titletext="Emissione Ordine di Lavoro" expandtext="Espandi" expandimageurl="../Images/down.gif"
				collapsetext="Riduci" collapseimageurl="../Images/up.gif" allowtitleexpandcollapse="True">
				<TABLE id="Tableordine" cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
					<TR>
						<TD style="HEIGHT: 29px" width="20%"><B>Ordine di lavoro:</B>
						</TD>
						<TD>
							<CC1:S_LABEL id="S_Lblordinelavoro" runat="server"></CC1:S_LABEL></TD>
					</TR>
				</TABLE>
				<TABLE id="Table5" cellSpacing="1" cellPadding="2" width="100%" border="0">
					<TR>
						<TD style="HEIGHT: 29px" width="20%"><B>Ditta Esecutrice:</B></TD>
						<TD style="WIDTH: 169px; HEIGHT: 29px">
							<CC1:S_COMBOBOX id="cmbsDitta" runat="server" width="196px" autopostback="True"></CC1:S_COMBOBOX></TD>
						<TD style="HEIGHT: 29px"><B>Addetto:</B></TD>
						<TD style="HEIGHT: 29px">
							<CC1:S_COMBOBOX id="cmbsAddetto" runat="server" width="184px"></CC1:S_COMBOBOX></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 16px"><B><B>Urgenza:</B></B></TD>
						<TD style="WIDTH: 169px; HEIGHT: 16px">
							<CC1:S_COMBOBOX id="cmbsUrgenza" runat="server" width="196px"></CC1:S_COMBOBOX></TD>
						<TD style="HEIGHT: 16px"><B></B></TD>
						<TD style="HEIGHT: 16px"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 32px"><B>Data Pianificata:</B></TD>
						<TD style="WIDTH: 169px; HEIGHT: 32px">
							<UC1:CALENDARPICKER id="CalendarPicker1" runat="server"></UC1:CALENDARPICKER></TD>
						<TD style="HEIGHT: 32px"><B>Orario Pianificato:</B></TD>
						<TD style="HEIGHT: 32px">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD noWrap height="15" rowSpan="2"></TD>
									<TD noWrap>
										<CC1:S_COMBOBOX id="cmbsOre" runat="server" dbdatatype="Integer">
											<ASP:LISTITEM value="00">00</ASP:LISTITEM>
											<ASP:LISTITEM value="01">01</ASP:LISTITEM>
											<ASP:LISTITEM value="02">02</ASP:LISTITEM>
											<ASP:LISTITEM value="03">03</ASP:LISTITEM>
											<ASP:LISTITEM value="04">04</ASP:LISTITEM>
											<ASP:LISTITEM value="05">05</ASP:LISTITEM>
											<ASP:LISTITEM value="06">06</ASP:LISTITEM>
											<ASP:LISTITEM value="07">07</ASP:LISTITEM>
											<ASP:LISTITEM value="08">08</ASP:LISTITEM>
											<ASP:LISTITEM value="09">09</ASP:LISTITEM>
											<ASP:LISTITEM value="10">10</ASP:LISTITEM>
											<ASP:LISTITEM value="11">11</ASP:LISTITEM>
											<ASP:LISTITEM value="12">12</ASP:LISTITEM>
											<ASP:LISTITEM value="13">13</ASP:LISTITEM>
											<ASP:LISTITEM value="14">14</ASP:LISTITEM>
											<ASP:LISTITEM value="15">15</ASP:LISTITEM>
											<ASP:LISTITEM value="16">16</ASP:LISTITEM>
											<ASP:LISTITEM value="17">17</ASP:LISTITEM>
											<ASP:LISTITEM value="18">18</ASP:LISTITEM>
											<ASP:LISTITEM value="19">19</ASP:LISTITEM>
											<ASP:LISTITEM value="20">20</ASP:LISTITEM>
											<ASP:LISTITEM value="21">21</ASP:LISTITEM>
											<ASP:LISTITEM value="22">22</ASP:LISTITEM>
											<ASP:LISTITEM value="23">23</ASP:LISTITEM>
										</CC1:S_COMBOBOX></TD>
									<TD noWrap height="15" rowSpan="2"><FONT face="Arial" size="-1"><B>:</B></FONT>
									</TD>
									<TD noWrap height="15" rowSpan="2">
										<CC1:S_COMBOBOX id="cmbsMinuti" runat="server" width="64px" dbdatatype="Integer">
											<ASP:LISTITEM value="00">00</ASP:LISTITEM>
											<ASP:LISTITEM value="15">15</ASP:LISTITEM>
											<ASP:LISTITEM value="30">30</ASP:LISTITEM>
											<ASP:LISTITEM value="45">45</ASP:LISTITEM>
										</CC1:S_COMBOBOX></TD>
									<TD noWrap></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="4">
							<ASP:LABEL id="LblMessaggio" runat="server" width="560px"></ASP:LABEL></TD>
					</TR>
				</TABLE>
				<TABLE id="TableEmetti" align="center" runat="server">
					<TR>
						<TD>
							<ASP:BUTTON id="btnRifiuta" runat="server" text="Rifiuta" causesvalidation="False"></ASP:BUTTON></TD>
						<TD>
							<ASP:BUTTON id="btnSospendi" runat="server" text="Sospendi" causesvalidation="False"></ASP:BUTTON></TD>
						<TD>
							<ASP:BUTTON id="btnApprova" runat="server" text="Approva ed Emetti"></ASP:BUTTON></TD>
						<TD>
							<ASP:BUTTON id="btnHelp" runat="server" text="Aiuto" causesvalidation="False"></ASP:BUTTON></TD>
					</TR>
				</TABLE>
			</CC2:DATAPANEL></TD>
	</TR>
	<TR>
		<TD><CC2:DATAPANEL id="PanelCompleta" runat="server" cssclass="DataPanel75" titlestyle-cssclass="TitleSearch"
				collapsed="False" titletext="Completamento Ordine di Lavoro" expandtext="Espandi" expandimageurl="../Images/down.gif"
				collapsetext="Riduci" collapseimageurl="../Images/up.gif" allowtitleexpandcollapse="True">
				<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="20%"><B>Stato Richiesta di Lavoro:</B></TD>
						<TD>
							<CC1:S_COMBOBOX id="cmbsstatolavoro" runat="server" width="255px"></CC1:S_COMBOBOX></TD>
					</TR>
					<TR id="trnote" runat="server">
						<TD width="20%"><B>Sospesa per:</B></TD>
						<TD>
							<CC1:S_TEXTBOX id="txtsSospesa" runat="server" width="408px" textmode="MultiLine" height="70px"></CC1:S_TEXTBOX></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD width="20%"><B>Data inizio:</B></TD>
									<TD style="WIDTH: 227px">
										<UC1:CALENDARPICKER id="CalendarPicker2" runat="server"></UC1:CALENDARPICKER></TD>
									<TD><B>Ora Inizio:</B></TD>
									<TD>
										<TABLE id="Tablecompletamento" cellSpacing="0" cellPadding="0" border="0" runat="server">
											<TR>
												<TD noWrap height="15" rowSpan="2"></TD>
												<TD noWrap>
													<CC1:S_COMBOBOX id="cmbsOraInizio" runat="server" dbdatatype="Integer">
														<ASP:LISTITEM value="00">00</ASP:LISTITEM>
														<ASP:LISTITEM value="01">01</ASP:LISTITEM>
														<ASP:LISTITEM value="02">02</ASP:LISTITEM>
														<ASP:LISTITEM value="03">03</ASP:LISTITEM>
														<ASP:LISTITEM value="04">04</ASP:LISTITEM>
														<ASP:LISTITEM value="05">05</ASP:LISTITEM>
														<ASP:LISTITEM value="06">06</ASP:LISTITEM>
														<ASP:LISTITEM value="07">07</ASP:LISTITEM>
														<ASP:LISTITEM value="08">08</ASP:LISTITEM>
														<ASP:LISTITEM value="09">09</ASP:LISTITEM>
														<ASP:LISTITEM value="10">10</ASP:LISTITEM>
														<ASP:LISTITEM value="11">11</ASP:LISTITEM>
														<ASP:LISTITEM value="12">12</ASP:LISTITEM>
														<ASP:LISTITEM value="13">13</ASP:LISTITEM>
														<ASP:LISTITEM value="14">14</ASP:LISTITEM>
														<ASP:LISTITEM value="15">15</ASP:LISTITEM>
														<ASP:LISTITEM value="16">16</ASP:LISTITEM>
														<ASP:LISTITEM value="17">17</ASP:LISTITEM>
														<ASP:LISTITEM value="18">18</ASP:LISTITEM>
														<ASP:LISTITEM value="19">19</ASP:LISTITEM>
														<ASP:LISTITEM value="20">20</ASP:LISTITEM>
														<ASP:LISTITEM value="21">21</ASP:LISTITEM>
														<ASP:LISTITEM value="22">22</ASP:LISTITEM>
														<ASP:LISTITEM value="23">23</ASP:LISTITEM>
													</CC1:S_COMBOBOX></TD>
												<TD noWrap height="15" rowSpan="2"><FONT face="Arial" size="-1"><B>:</B></FONT>
												</TD>
												<TD noWrap height="15" rowSpan="2">
													<CC1:S_COMBOBOX id="cmbsMinutiInizio" runat="server" width="64px" dbdatatype="Integer">
														<ASP:LISTITEM value="00">00</ASP:LISTITEM>
														<ASP:LISTITEM value="15">15</ASP:LISTITEM>
														<ASP:LISTITEM value="30">30</ASP:LISTITEM>
														<ASP:LISTITEM value="45">45</ASP:LISTITEM>
													</CC1:S_COMBOBOX></TD>
												<TD noWrap></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD width="20%"><B>Data Fine:</B></TD>
									<TD style="WIDTH: 227px">
										<UC1:CALENDARPICKER id="CalendarPicker3" runat="server"></UC1:CALENDARPICKER></TD>
									<TD><B>Ora Fine:</B></TD>
									<TD>
										<TABLE id="Table8" cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD noWrap height="15" rowSpan="2"></TD>
												<TD noWrap>
													<CC1:S_COMBOBOX id="cmbsOraFine" runat="server" dbdatatype="Integer">
														<ASP:LISTITEM value="00">00</ASP:LISTITEM>
														<ASP:LISTITEM value="01">01</ASP:LISTITEM>
														<ASP:LISTITEM value="02">02</ASP:LISTITEM>
														<ASP:LISTITEM value="03">03</ASP:LISTITEM>
														<ASP:LISTITEM value="04">04</ASP:LISTITEM>
														<ASP:LISTITEM value="05">05</ASP:LISTITEM>
														<ASP:LISTITEM value="06">06</ASP:LISTITEM>
														<ASP:LISTITEM value="07">07</ASP:LISTITEM>
														<ASP:LISTITEM value="08">08</ASP:LISTITEM>
														<ASP:LISTITEM value="09">09</ASP:LISTITEM>
														<ASP:LISTITEM value="10">10</ASP:LISTITEM>
														<ASP:LISTITEM value="11">11</ASP:LISTITEM>
														<ASP:LISTITEM value="12">12</ASP:LISTITEM>
														<ASP:LISTITEM value="13">13</ASP:LISTITEM>
														<ASP:LISTITEM value="14">14</ASP:LISTITEM>
														<ASP:LISTITEM value="15">15</ASP:LISTITEM>
														<ASP:LISTITEM value="16">16</ASP:LISTITEM>
														<ASP:LISTITEM value="17">17</ASP:LISTITEM>
														<ASP:LISTITEM value="18">18</ASP:LISTITEM>
														<ASP:LISTITEM value="19">19</ASP:LISTITEM>
														<ASP:LISTITEM value="20">20</ASP:LISTITEM>
														<ASP:LISTITEM value="21">21</ASP:LISTITEM>
														<ASP:LISTITEM value="22">22</ASP:LISTITEM>
														<ASP:LISTITEM value="23">23</ASP:LISTITEM>
													</CC1:S_COMBOBOX></TD>
												<TD noWrap height="15" rowSpan="2"><FONT face="Arial" size="-1"><B>:</B></FONT>
												</TD>
												<TD noWrap height="15" rowSpan="2">
													<CC1:S_COMBOBOX id="cmbsMinutiFine" runat="server" width="64px" dbdatatype="Integer">
														<ASP:LISTITEM value="00">00</ASP:LISTITEM>
														<ASP:LISTITEM value="15">15</ASP:LISTITEM>
														<ASP:LISTITEM value="30">30</ASP:LISTITEM>
														<ASP:LISTITEM value="45">45</ASP:LISTITEM>
													</CC1:S_COMBOBOX></TD>
												<TD noWrap></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="trannotazione" runat="server">
						<TD style="WIDTH: 171px"><B></B></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 171px"><B>Annotazioni Materiale Utilizzato:</B></TD>
						<TD>
							<CC1:S_TEXTBOX id="txtsAnnotazioni" runat="server" width="408px" textmode="MultiLine" height="70px"></CC1:S_TEXTBOX></TD>
					</TR>
					<TR>
					<TR id="trconsuntivo1" style="VISIBILITY: hidden" runat="server">
						<TD><B>Importo a Consuntivo:</B></TD>
						<TD>
							<CC1:S_TEXTBOX id="txtSpesa3" style="TEXT-ALIGN: right" runat="server" width="154px" maxlength="8">0</CC1:S_TEXTBOX>,
							<CC1:S_TEXTBOX id="txtSpesa4" runat="server" width="32px" maxlength="2">00</CC1:S_TEXTBOX></TD>
					</TR>
					<TR id="trconsuntivo2" style="VISIBILITY: hidden" runat="server">
						<TD><B>Contabilizzazione:</B></TD>
						<TD>
							<CC1:S_COMBOBOX id="cmbContabilizzazione" runat="server" width="255px"></CC1:S_COMBOBOX></TD>
					</TR>
					<TR id="trannocontab" style="VISIBILITY: hidden" runat="server">
						<TD><B>Anno Contabilizzazione:</B></TD>
						<TD>
							<CC1:S_COMBOBOX id="cmbsAnnoContab" runat="server" width="255px"></CC1:S_COMBOBOX></TD>
					</TR>
					<TR id="trconsuntivo3" style="VISIBILITY: hidden" runat="server">
						<TD colSpan="2"><B>
								<ASP:LABEL id="lblconsuntivo" runat="server">Importa Consuntivo(PDF): </ASP:LABEL></B><INPUT id="UploadFileCosto" style="WIDTH: 352px; HEIGHT: 22px" type="file" size="55" name="UploadFileCosto"
								runat="server">
							<CC1:S_HYPERLINK id="LinkConsuntivo" runat="server" visible="False"></CC1:S_HYPERLINK></TD>
						<TD></TD>
					</TR>
					<TR id="trsoddisfazione" runat="server">
						<TD style="WIDTH: 171px"><B>Livello Soddisfazione:</B></TD>
						<TD>
							<ASP:RADIOBUTTONLIST id="RadioButtonList1" runat="server" repeatdirection="Horizontal">
								<asp:ListItem Value="4" Selected="True">Non dichiarato</asp:ListItem>
								<asp:ListItem Value="1">Non Soddisfatto</asp:ListItem>
								<asp:ListItem Value="2">Soddisfatto</asp:ListItem>
								<asp:ListItem Value="3">Pienamente Soddisfatto</asp:ListItem>
							</ASP:RADIOBUTTONLIST></TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
						<TD></TD>
					</TR>
				</TABLE>
				<TABLE id="TableCompleta" style="HEIGHT: 29px" cellSpacing="0" cellPadding="0" width="516"
					align="center" border="0" runat="server">
					<TR>
						<TD>
							<CC1:S_BUTTON id="btnCompleta" runat="server" width="180px" text="Invia"></CC1:S_BUTTON></TD>
						<TD>&nbsp;
							<CC1:S_BUTTON id="btnfoglioprestazioni" runat="server" width="180px" text="Foglio Prestazioni"
								causesvalidation="False"></CC1:S_BUTTON></TD>
						<TD>
							<CC1:S_BUTTON id="btnfoglioprestazioniPdf" runat="server" width="180px" text="Foglio Prestazioni in Pdf"
								causesvalidation="False"></CC1:S_BUTTON></TD>
					</TR>
				</TABLE>
			</CC2:DATAPANEL></TD>
	</TR>
	<TR>
		<TD align="center"><CC1:S_BUTTON id="BtnCostiOpera" runat="server" width="180px" visible="False" text="Costi Operativi Di Gestione"
				causesvalidation="False"></CC1:S_BUTTON><CC1:S_BUTTON id="btnChiudicompleta" runat="server" width="180px" text="Chiudi" causesvalidation="False"></CC1:S_BUTTON><UC1:AGGIUNGISOLLECITO id="AggiungiSollecito1" runat="server"></UC1:AGGIUNGISOLLECITO></TD>
	</TR>
</TABLE>
