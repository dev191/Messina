<%@ Control Language="c#" AutoEventWireup="false" Codebehind="VisSelCampi.ascx.cs" Inherits="GIC.Report.UserControl.VisSelCampi" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<SCRIPT language="javascript">

	iVuota = new Image();
	iVuota.src="../Image/ico-vuota.gif";
	
	iOrdAsc = new Image();
	iOrdDesc = new Image();
	iFiltro = new Image();
	iAgrreg = new Image();
	iHihhen = new Image();
	
	iOrdAsc.src="../Image/ico-crescente.gif";
	iOrdDesc.src="../Image/ico-decrescente.gif";
	iFiltro.src="../Image/ico-filtro.gif";
	iAgrreg.src="../Image/ico-fx.gif";
	iHihhen.src="../Image/ico-selezione.gif";
	

	function OpenWindow(idQuery, idCampo, sender, tablerow){
		window.open("ModificaCampo.aspx?IdQuery=" + idQuery +"&sender=<%=SelezClientId%>&idcampo=" + idCampo ,"popup","resizable=yes,menubar=no,toolbar=no,location=no,status=yes,width=630,height=400");		
	}
	
	function OpenVisualizzazione(){
		window.open("Visualizza.aspx?IdQuery=<%=IdQuery%>" ,"popupVis","scrollbars=yes,resizable=yes,menubar=no,toolbar=no,location=no,status=yes,width=600,height=400");		
	}
	
	function OpenEsportazione(){
		window.open("Esporta.aspx?IdQuery=<%=IdQuery%>" ,"popupVis","scrollbars=yes,resizable=yes,menubar=no,toolbar=no,location=no,status=yes,width=600,height=400");		
	}
	
	function GetTableCampi(){
		return document.getElementById('<%=SelectedItems.ClientID%>');
	}
	
	
	function CheckSelC(){
		righe=document.getElementById('<%=SelezClientId%>').tBodies[0];
		if (righe.rows.length<2) {
			alert ("Occorre selezionare almeno un campo");
			return false;
		}
		return true;
	}
	
	function Inverti(obj1,obj2){
		righe=document.getElementById('<%=SelezClientId%>').tBodies[0];
		if(obj1!=null && obj2!=null){
		k=obj1.rowIndex;		
		l=obj2.rowIndex;

		if (righe.rows[k]!=null && righe.rows[l]!=null){	
				righe.moveRow(k,l);		
			}	
		}
		
	}
	
	function Inverti2(obj1,obj2){
		righe=document.getElementById('<%=TuttiClientId%>').tBodies[0];
		if(obj1!=null && obj2!=null){
		k=obj1.rowIndex;		
		l=obj2.rowIndex;

		if (righe.rows[k]!=null && righe.rows[l]!=null){	
				righe.moveRow(k,l);		
			}	
		}
		
	}
	
	function InversioneCampi(cella, verso){
		indice=cella.parentElement.parentElement.rowIndex;
		obj=document.getElementById('<%=SelezClientId%>').tBodies[0];
		for (j=1;j<obj.rows.length;j++){
			if(obj.rows[j].rowIndex==indice){
				if(verso=="su"){
					if(j>1)
						Inverti(obj.rows[indice],obj.rows[indice-1])
				}
				if(verso=="giu"){
					if (j<obj.rows.length)
						Inverti(obj.rows[indice],obj.rows[indice+1])
				}	
			}		
		}
		ResetHiddenText();				
	}
	
	function RiordinaTabella(){
		var boolend=false;
		table1=document.getElementById('<%=TuttiClientId%>').tBodies[0];
		var conta = table1.rows.length;
		var j=0;
		while(!boolend && j<conta){
			var inv;
			inv=false;
			for(i=2; i<conta; i++){				
				
				if(table1.rows[i-1].desc>table1.rows[i].desc){
					Inverti2(table1.rows[i-1],table1.rows[i])
					inv=true;
				}
			}
			j++;
			if(!inv)
				boolend=true;
		}
	}
	
	function compareValues(v1, v2) {

		var f1, f2;

		// If the values are numeric, convert them to floats.

		f1 = parseFloat(v1);
		f2 = parseFloat(v2);
		if (!isNaN(f1) && !isNaN(f2)) {
			v1 = f1;
			v2 = f2;
		}

		// Compare the two values.
		if (v1 == v2)
			return 0;
		if (v1 > v2)
			return 1
		return -1;
	}
	
	function SelectItem(obj, versus){
		table1=document.getElementById('<%=TuttiClientId%>').tBodies[0];
		table2=document.getElementById('<%=SelezClientId%>').tBodies[0];
		
		var fqui = table1.rows[0].cells[0].ondblclick;
		var fli = table2.rows[0].cells[0].ondblclick;
		if (versus=="li" && !obj.rowIndex==0){
			obj.cells[0].ondblclick=fli;
			SetRiga('block', obj);
			SetHiddenValue(obj)
			table2.appendChild(obj);			
		}
		if (versus=="qui" && !obj.rowIndex==0){
			obj.cells[0].ondblclick=fqui;
			SetRiga('none', obj);
			table1.appendChild(obj);
			RiordinaTabella();
			document.getElementById("<%=SelectedItems.ClientID%>").value=Remove(document.getElementById("<%=SelectedItems.ClientID%>"),obj.idItem);
		}
	}
	
	function SetHiddenValue(obj){
		if(document.getElementById("<%=SelectedItems.ClientID%>").value!=""){
			document.getElementById("<%=SelectedItems.ClientID%>").value+="?";
		}
		document.getElementById("<%=SelectedItems.ClientID%>").value+=obj.idItem;
		document.getElementById("<%=SelectedItems.ClientID%>").value+="#";
		document.getElementById("<%=SelectedItems.ClientID%>").value+=obj.desc;
		document.getElementById("<%=SelectedItems.ClientID%>").value+="#";
		document.getElementById("<%=SelectedItems.ClientID%>").value+=obj.ord;
		document.getElementById("<%=SelectedItems.ClientID%>").value+="#";
		document.getElementById("<%=SelectedItems.ClientID%>").value+=obj.filtro;
		document.getElementById("<%=SelectedItems.ClientID%>").value+="#";
		document.getElementById("<%=SelectedItems.ClientID%>").value+=obj.nascosto;	
		document.getElementById("<%=SelectedItems.ClientID%>").value+="#";
		document.getElementById("<%=SelectedItems.ClientID%>").value+=obj.aggr;
		document.getElementById("<%=SelectedItems.ClientID%>").value+="#";
		document.getElementById("<%=SelectedItems.ClientID%>").value+=obj.rowIndex;
		document.getElementById("<%=SelectedItems.ClientID%>").value+="#";
		document.getElementById("<%=SelectedItems.ClientID%>").value+=obj.tipol;
		document.getElementById("<%=SelectedItems.ClientID%>").value+="#";
		document.getElementById("<%=SelectedItems.ClientID%>").value+=obj.tipod;		
		} 
		
	function ResetHiddenText(){
		document.getElementById("<%=SelectedItems.ClientID%>").value="";
		obj=document.getElementById('<%=SelezClientId%>').tBodies[0];
		for (j=1;j<obj.rows.length;j++){
			if(obj.rows[j].rowIndex>0)
				SetHiddenValue(obj.rows[j]);			
		}
	
		
	}
	
	function GetModifiedText(text,val){
	
		stringa=document.getElementById("<%=SelectedItems.ClientID%>").value;

		var result;
		result="";
		var splitted = new Array();
		var j;
		splitted = stringa.split("?");
		for (i in splitted) {
			if(splitted[i].substring(0,splitted[i].indexOf('#'))==val){
				if (result==""){  
					result+=text;
				} else {
					result+="?"+text;
				} 
			} else {
				if (result==""){  
					result+=splitted[i];
				} else {
					result+="?"+splitted[i];
				}
			}			
		}
		document.getElementById("<%=SelectedItems.ClientID%>").value = result;
		
		//modifico le immaginine
		
		obj=document.getElementById('<%=SelezClientId%>').tBodies[0];
		valori = text.split('#');
		idCampo=valori[0];
		ord=valori[2];
		fil=valori[3];
		hid=valori[4];
		agg=valori[5];
		for (j=1;j<obj.rows.length;j++){
			if(obj.rows[j].rowIndex>0 && obj.rows[j].idItem==val)
			{
				obj2=obj.rows[j]
				if (ord=="NESSUNO")
					obj2.cells[1].firstChild.outerHTML=iVuota.outerHTML;
				if (ord=="ASC")
					obj2.cells[1].firstChild.outerHTML=iOrdAsc.outerHTML;
				if (ord=="DESC")
					obj2.cells[1].firstChild.outerHTML=iOrdDesc.outerHTML;
					
				if (fil=="")
					obj2.cells[2].firstChild.outerHTML=iVuota.outerHTML;
				else
					obj2.cells[2].firstChild.outerHTML=iFiltro.outerHTML;
					
				if (hid=="True")
					obj2.cells[4].firstChild.outerHTML=iHihhen.outerHTML;
				else
					obj2.cells[4].firstChild.outerHTML=iVuota.outerHTML;
					
				if (agg=="NESSUNO")
					obj2.cells[3].firstChild.outerHTML=iVuota.outerHTML;
				else
					obj2.cells[3].firstChild.outerHTML=iAgrreg.outerHTML;									
			}				
		}		
	}
	
	function HiddenComm(obj){
		for (j=1;j<obj.rows.length;j++){
			if(obj.rows[j].rowIndex>0)
				SetRiga('none',obj.rows[j]);			
		}
	}
	
	function Remove(controllo,val){
		stringa=controllo.value;
		controllo.value="";
		var result;
		result="";
		var splitted = new Array();
		var j;
		splitted = stringa.split("?");
		for (i in splitted) {
			if(splitted[i].substring(0,splitted[i].indexOf('#'))==val){
				j=i;
			} else {
				if (result==""){  
					result+=splitted[i];
				} else {
					result+="?"+splitted[i];
				}
			}
			
		}
		return result;
	}
	
	function SetRiga(styl, obj)
	{
		if (obj!=null){
			obj.cells[1].style.display=styl;
			obj.cells[2].style.display=styl;
			obj.cells[3].style.display=styl;
			obj.cells[4].style.display=styl;
			obj.cells[5].style.display=styl;
			obj.cells[6].style.display=styl;
			obj.cells[7].style.display=styl;
		}
	}
</SCRIPT>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="520" border="0">
	<TR>
		<TD class="TableInt" style="WIDTH: 112px">Titolo</TD>
		<TD class="TableInt"><ASP:TEXTBOX id="TextTitolo" width="368px" runat="server"></ASP:TEXTBOX></TD>
	</TR>
	<TR>
		<TD class="TableInt" style="WIDTH: 112px">Descrizione</TD>
		<TD class="TableInt"><STRONG><ASP:TEXTBOX id="TextDescrizione" width="368px" runat="server" height="56px"></ASP:TEXTBOX></STRONG></TD>
	</TR>
	<TR>
		<TD class="TableInt" style="WIDTH: 112px">Propretario</TD>
		<TD class="TableInt"><ASP:TEXTBOX Enabled="False" id="TxtOwner" width="368px" runat="server"></ASP:TEXTBOX></TD>
	</TR>
</TABLE>
<BR>
<TABLE id="TableReportField" style="WIDTH: 720px; HEIGHT: 100px">
	<TR>
		<TD class="TableHeaderCampi" style="WIDTH: 250px; HEIGHT: 20px">Campi disponibili</TD>
		<TD class="TableHeaderCampi" style="WIDTH: 20px; HEIGHT: 20px">&nbsp;</TD>
		<TD class="TableHeaderCampi" style="WIDTH: 470px; HEIGHT: 20px">Campi selezionati</TD>
	</TR>
	<TR>
		<TD style="WIDTH: 250px; POSITION: relative; HEIGHT: 20px" vAlign="top">
			<DIV class="TableContCampi"><ASP:TABLE id="TableTuttiCampi" runat="server" enableviewstate="False"></ASP:TABLE></DIV>
		</TD>
		<TD style="WIDTH: 20px">&nbsp;</TD>
		<TD style="WIDTH: 470px; POSITION: relative; HEIGHT: 20px" vAlign="top">
			<DIV class="TableContCampi"><ASP:TABLE id="TableCampiSel" runat="server" enableviewstate="False" cssclass="TableContCampi"></ASP:TABLE></DIV>
		</TD>
	</TR>
	<TR>
		<TD style="WIDTH: 250px; POSITION: relative; HEIGHT: 20px" vAlign="top"></TD>
		<TD style="WIDTH: 20px"></TD>
		<TD style="WIDTH: 470px; POSITION: relative; HEIGHT: 20px" vAlign="top">
			<ASP:BUTTON id="BtnSalva" runat="server" cssclass="btn" text="Salva"></ASP:BUTTON>
			<ASP:BUTTON id="BtnAnnulla" runat="server" cssclass="btn" text="Annulla"></ASP:BUTTON>
			<ASP:BUTTON id="ButtonVisualizza" runat="server" cssclass="btn" text="Visualizza"></ASP:BUTTON>
			<ASP:BUTTON id="BtnExcel" runat="server" cssclass="btn" text="Esporta Excel"></ASP:BUTTON>
			<ASP:BUTTON id="BtnCopia" runat="server" cssclass="btn" text="Copia"></ASP:BUTTON>
		</TD>
	</TR>
</TABLE>
<INPUT id="SelectedItems" type="hidden" runat="server">
<INPUT id="txtHTitolo" type="hidden" runat="server" NAME="txtHTitolo">
<SCRIPT language="javascript">HiddenComm(document.getElementById('<%=TuttiClientId%>').tBodies[0]);</SCRIPT>
