<%@ Page language="c#" Codebehind="ModificaCampo.aspx.cs" AutoEventWireup="false" Inherits="GIC.Report.ModificaCampo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ModificaCampo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style/StyleSheetReport.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
		var idCampo=<%=IdCampo%>;
		var salvato;
		salvato=false;
		
		var campo;
		var tabella;
		var camptab;
		var modificato;
		var CampoValore;
		modificato=false;
		
		function OpenValCampo(sender){
			CampoValore=sender;
			window.open("ValoriCampo.aspx?Campo=" + campo +"&Tabella=" + tabella+"&valore=" + sender.value+"&tipo=" + GetTipoDato() ,"popupVis","resizable=yes,menubar=no,toolbar=no,location=no,status=yes,width=600,height=400");		
		}
		
		function ValorizzaVal(sender){
			var valLetto;
			if (GetTipoDato().substr(0,1)=="D"){
				if (sender.length >10)
					valLetto=sender.substr(0,10)
				else
					valLetto=sender;
			} else 
			{
				valLetto=sender;
			}
			var valOper=document.getElementById('operatore').value;
			
			if (valOper=="BETWEEN")
				CampoValore.value=valLetto;
			else			
				AddFiltroByPopup(valLetto);
		}
		
		function Check(val1, val2){
		
			if(document.getElementById('count').checked){
				return CheckValues(val1, val2);
			}
			
			if(document.getElementById('sum').checked){
				return CheckValues(val1, val2)
			}
			
			return true;
		
		}
		
		function CheckValues(val1, val2){
			var valOper=document.getElementById('operatore').value;
			if (valOper=="BETWEEN"){

				if (isNaN(val1) || isNaN(val2)){
					alert("È richiesto il conteggio o la somma, le condizioni devono essere su valori interi");
					return false;
				}	
				} else {
				
					if (isNaN(val1)){
					alert("È richiesto il conteggio o la somma, le condizioni devono essere su valori interi");
					return false;
				}			
			}			
			return true;		
		}
		
		function Valorizza()
		{
			var obj=opener.GetTableCampi();
			var pippo=document.getElementById('LstCampi');
			obj2=obj.value.split('?');
			for (i in obj2){
				var splitted = obj2[i].split('#');
				if(splitted[0]==idCampo){
					document.getElementById('hiddenField').value=obj2[i];
					pippo.options[pippo.options.length]=new Option(splitted[1], splitted[0]);
					document.getElementById('nomCamp').innerText=splitted[1];
					tabcamp=splitted[1].split('-');
					campo=tabcamp[1];
					tabella=tabcamp[0];
					camptab=splitted[1];
					var splitAllFiltri=splitted[3].split('$');
					var listBoxImp = document.getElementById('<%=ListBox1.ClientID%>');
					for (f in splitAllFiltri){
						var splitFiltri = splitAllFiltri[f].split('&');
						
						if (!(splitted[3]=="NESSUNO" || splitted[3]=="")){
							listBoxImp.options[listBoxImp.options.length] = new Option(splitted[1]+' '+splitFiltri[1]+' '+splitFiltri[2]+'  '+splitFiltri[3],splitFiltri[0]);
						}	
					}			
				}
			}			
			//document.getElementById('hiddenField').value=Selezione(obj.value,idCampo);
			SecondoValore();
			InitControl();
		 }
		 
		 function Salva(){
			opener.GetModifiedText(document.getElementById('hiddenField').value,idCampo);
			alert("I filtri impostati sono stati memorizzati");
			salvato=true;
			window.close();
		 }
		 
		 function Annulla(){
				if (modificato){
					if (confirm("Tutte le operazioni di modifica dei filtri saranno annullate. Procedere?")){
						window.close()
					}		 
				} else {
					window.close();
				}
		 }
		 
		  function Close(){
			if(!salvato && modificato)
				if (confirm("Salvare i filtri che sono stai impostati?")){
					opener.GetModifiedText(document.getElementById('hiddenField').value,idCampo);
				}
			//window.close()		 
		 }
		 
		 function eliminaFiltri(){
			var listBoxImp = document.getElementById('<%=ListBox1.ClientID%>');
			var len = listBoxImp.options.length;
			for (o=len-1; o>=0 ;o--){
				listBoxImp.options[o]=null;
			}
			
			var obj=document.getElementById('hiddenField').value;
			document.getElementById('hiddenField').value="";
			var splitted = obj.split('#');
			var result=1;
			return result;
		 }
		 
		 function eliminaFiltro(sender){
		//alert("ok: " + sender.selectedIndex);
		if (sender.options.length!=0) 
			{	

				var posfiltro = sender.selectedIndex;
				sender.options[sender.selectedIndex]=null; 	
				var nfil;
				nfil="";
				
				var obj=document.getElementById('hiddenField').value;
				document.getElementById('hiddenField').value="";
				var splitted = obj.split('#');
				var filtri=splitted[3];
				var splittedfiltri = filtri.split('$');
				if (filtri!=""){
					for (j in splittedfiltri){
						if(j!=posfiltro){
							if(nfil==""){
								nfil=splittedfiltri[j];
							} else {
								nfil+='$' + splittedfiltri[j];
							}
						}
					}	
				}
				var result=splitted[0]+"#"+splitted[1]+"#"+splitted[2]+"#"+nfil+"#"+splitted[4]+"#"+splitted[5]+"#"+splitted[6]+"#"+splitted[7]+"#"+splitted[8];
				document.getElementById('hiddenField').value=result;
							
			}
		 }
		 
		 function Selezione(controllo,val){
			var stringa=controllo;
			var result;
			result="";
			var splitted = new Array();
			var j;
			splitted = stringa.split("?");
			for (i in splitted) {
				if(splitted[i].substring(0,stringa.indexOf('#'))==val){
					return splitted[i]+"\n";
				} 
			}
		 }
		 
		 function InitControl(){
			var obj=document.getElementById('hiddenField').value;
			//alert(obj);
			var splitted = obj.split('#');
			var ordinamento=splitted[2];
			var listOrd=document.getElementById('ordinamento');
			
			if(ordinamento=="NESSUNO")
				listOrd.selectedIndex=0;
			
			if(ordinamento=="ASC")
				listOrd.selectedIndex=1;
			
			if(ordinamento=="DESC")
				listOrd.selectedIndex=2;
			
			
			var aggregazione=splitted[5];
			var sum=document.getElementById('sum');
			var count=document.getElementById('count');
			
			if (aggregazione=="SUM"){
				document.getElementById('nomCamp').innerText='SUM(' +camptab + ')';
				sum.checked = true;
			}
			if (aggregazione=="COUNT"){
				document.getElementById('nomCamp').innerText='COUNT(' +camptab  + ')';
				count.checked=true;
			}			
			if (aggregazione=="SUMCOUNT"){
				document.getElementById('nomCamp').innerText='SUM E COUNT(' +camptab  + ')';
				count.checked=true;
				sum.checked = true;
			}
			
			var Nascostov=splitted[4];
			var nascosto=document.getElementById('nascosto');
			if (Nascostov=="True"){
				nascosto.checked=true;
				SetOrdEnabled(true)
			}
			if (GetTipoDato().substr(0,1)!="N"){
				sum.disabled=true;
				
			}
		 }
		 
		 function AddFiltro(){
		 
			var listBoxImp = document.getElementById('<%=ListBox1.ClientID%>');
			var valNome=document.getElementById('LstCampi').options[document.getElementById('LstCampi').selectedIndex].text;
			var valOper=document.getElementById('operatore').value;
			var val1=document.getElementById('valore1').value;
			var val2=document.getElementById('valore2').value;
				
			
			if (val1 == ""){
				alert("Valori per le condizioni non definiti"); 
				document.getElementById('valore1').focus();
				return;
			}
			
			if (val1 == "" || (val2 == "" && valOper=="BETWEEN")){
				alert("Valori per le condizioni non definiti"); 
				if (val1 == ""){
					document.getElementById('valore1').focus();
					return;
				}
				else {
					document.getElementById('valore2').focus();
					return;
				}
				return;
			}
			
			if(!ControllaData())
				return;
			
			
			if (!Check(val1, val2))
				return;
				
			listBoxImp.options[listBoxImp.options.length] = new Option(valNome+' '+valOper+' '+val1+'  '+val2,valNome);
			
			//pure il campo nascosto
			
			var obj=document.getElementById('hiddenField').value;
			var splitted = obj.split('#');
			var filtri=splitted[3];
			if (filtri==""){
				filtri="0"+"&"+valOper+"&"+val1+"&"+val2
			} else {
				filtri+="$"+"0"+"&"+valOper+"&"+val1+"&"+val2
			}
			
			var result=splitted[0]+"#"+splitted[1]+"#"+splitted[2]+"#"+filtri+"#"+splitted[4]+"#"+splitted[5]+"#"+splitted[6]+"#"+splitted[7]+"#"+splitted[8];
			document.getElementById('hiddenField').value=result;
			modificato=true;
			
			document.getElementById('valore1').value="";
			document.getElementById('valore2').value="";

		 }
		 
		 function AddFiltroByPopup(valoreS){
		 
			var listBoxImp = document.getElementById('<%=ListBox1.ClientID%>');
			var valNome=document.getElementById('LstCampi').options[document.getElementById('LstCampi').selectedIndex].text;
			var valOper=document.getElementById('operatore').value;
			var val1=valoreS;
			var val2=document.getElementById('valore2').value;
				
			
			if (val1 == ""){
				alert("Valori per le condizioni non definiti"); 
				document.getElementById('valore1').focus();
				return;
			}
			
			if (val1 == "" || (val2 == "" && valOper=="BETWEEN")){
				alert("Valori per le condizioni non definiti"); 
				if (val1 == ""){
					document.getElementById('valore1').focus();
					return;
				}
				else {
					document.getElementById('valore2').focus();
					return;
				}
				return;
			}
			
			if(!ControllaData())
				return;
			
			
			if (!Check(val1, val2))
				return;
				
			listBoxImp.options[listBoxImp.options.length] = new Option(valNome+' '+valOper+' '+val1+'  '+val2,valNome);
			
			//pure il campo nascosto
			
			var obj=document.getElementById('hiddenField').value;
			var splitted = obj.split('#');
			var filtri=splitted[3];
			if (filtri==""){
				filtri="0"+"&"+valOper+"&"+val1+"&"+val2
			} else {
				filtri+="$"+"0"+"&"+valOper+"&"+val1+"&"+val2
			}
			
			var result=splitted[0]+"#"+splitted[1]+"#"+splitted[2]+"#"+filtri+"#"+splitted[4]+"#"+splitted[5]+"#"+splitted[6]+"#"+splitted[7]+"#"+splitted[8];
			document.getElementById('hiddenField').value=result;
			modificato=true;

		 }
		 
		 function CambiaOrdinamento(){
			
			var nascosto=document.getElementById('nascosto');
			var nascostos;
			nascosto.checked=false;

			nascostos="False";
			 
			var obj=document.getElementById('hiddenField').value;
			var splitted = obj.split('#');
			var ordinamento=splitted[2];
			neworder=document.getElementById('ordinamento').value;
			var result=splitted[0]+"#"+splitted[1]+"#"+neworder+"#"+splitted[3]+"#"+nascostos+"#"+splitted[5]+"#"+splitted[6]+"#"+splitted[7]+"#"+splitted[8];
			document.getElementById('hiddenField').value=result;
			modificato=true;

		 }
		 
		 function CambiaAggregazione(){
		 
			var obj=document.getElementById('hiddenField').value;
			var splitted = obj.split('#');
			var aggregazioneOld=splitted[5];
			var sum=document.getElementById('sum');
			var count=document.getElementById('count');
			var aggregazione;
			
			var FiltriEliminati = 0;
			
			if (sum.checked && count.checked){
				aggregazione=sum.value+""+count.value;
				document.getElementById('nomCamp').innerText='SUM E COUNT(' +camptab + ')';
				FiltriEliminati = eliminaFiltri();
			}
			if (sum.checked && !count.checked){
				aggregazione=sum.value;
				document.getElementById('nomCamp').innerText='SUM(' +camptab  + ')';
				FiltriEliminati = eliminaFiltri();
			}
			if (!sum.checked && count.checked){
				aggregazione=count.value;
				document.getElementById('nomCamp').innerText='COUNT(' +camptab + ')';
				FiltriEliminati = eliminaFiltri();
			}
			if (!sum.checked && !count.checked){
				aggregazione="NESSUNO";
				document.getElementById('nomCamp').innerText=camptab;
				FiltriEliminati = eliminaFiltri();
			}
			var Filtri;
			if (FiltriEliminati = 1)
				Filtri="";
			else
				Filtri=splitted[3];
			
			var result=splitted[0]+"#"+splitted[1]+"#"+splitted[2]+"#"+Filtri+"#"+splitted[4]+"#"+aggregazione+"#"+splitted[6]+"#"+splitted[7]+"#"+splitted[8];
			document.getElementById('hiddenField').value=result;
			modificato=true;

		 }
		 
		 function GetTipoDato(){
			var obj=document.getElementById('hiddenField').value;
			return obj.split('#')[8];			
		 }
		 
		 function CambiaNascosco(){		 
			var obj=document.getElementById('hiddenField').value;
			var splitted = obj.split('#');
			var NascostoOld=splitted[5];
			var nascosto=document.getElementById('nascosto');
			var nascosto;
			if (nascosto.checked){
				nascosto="True";
				SetOrdEnabled(true);
			} else {
				nascosto="False";
				SetOrdEnabled(false);
			}			
			var result=splitted[0]+"#"+splitted[1]+"#"+"NESSUNO"+"#"+splitted[3]+"#"+nascosto+"#"+splitted[5]+"#"+splitted[6]+"#"+splitted[7]+"#"+splitted[8];
			document.getElementById('hiddenField').value=result;
			modificato=true;
			
			document.getElementById('ordinamento').selectedIndex=0;

		 }
		 
		 function SetOrdEnabled(disabl){
			document.getElementById('ordinamento').disabled=disabl;
		 }
		 		 
		 function SecondoValore(){
			
			if (document.getElementById('2val').style.display=='none'){
				if(document.getElementById('operatore').value=="BETWEEN"){
					document.getElementById('2val').style.display='block';
				}
			}
			else{
				if(document.getElementById('operatore').value!="BETWEEN"){
					document.getElementById('2val').style.display='none';
					document.getElementById('valore2').value="";
				}
			}
			
			//controllo sul like
			if ((GetTipoDato().substr(0,1)=="D" || GetTipoDato().substr(0,1)=="N") && document.getElementById('operatore').value=="LIKE"){
				alert("Il campo non è di tipo testo e quindi non si può usare il Like");
				document.getElementById('operatore').selectedIndex=0;
			}
						
		 }
		 
		 function IsDate(DateToCheck){
			if(DateToCheck==""){return true;}
				var m_strDate = DateToCheck;
				if(m_strDate==""){
				return false;
			}
				var m_arrDate = m_strDate.split("/");
				var m_DAY = m_arrDate[0];
				var m_MONTH = m_arrDate[1];
				var m_YEAR = m_arrDate[2];
				if(m_YEAR.length > 4){return false;}
				m_strDate = m_MONTH + "/" + m_DAY + "/" + m_YEAR;
				var testDate=new Date(m_strDate);
				if(testDate.getMonth()+1==m_MONTH){
				return true;
			} 
			else{
				return false;
			}
		}//end function
		 
		 function ControllaData(){
			if (GetTipoDato().substr(0,1)=="D" && (!document.getElementById('count').checked)){	
				if(document.getElementById('operatore').value!="BETWEEN"){
					var vall = document.getElementById('valore1').value;		
					if(!IsDate(vall)){ 
						alert("Invalid Date") 
						return false;
					} else {
						return true;
					}
				} else {
					var vall = document.getElementById('valore1').value;	
					var val2 = document.getElementById('valore2').value;		
					if(!IsDate(vall) || !IsDate(val2) ){ 
						alert("Invalid Date") 
						return false;
					} else {
						return true;
					}
				}			
			}	else {
				return true;
			}	 
		 }
		 
		 function SoloNumeriVirgola()
		 {	
			var sum=document.getElementById('sum');
			var count=document.getElementById('count');
			if (count.checked) {
			
				if (!(event.keyCode >= 48 && event.keyCode <= 57))
				{		
					event.keyCode = 0;		
					return
				}
			}
			if (GetTipoDato().substr(0,1)=="N" || sum.checked) {			
				if (!((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 46))
				{		
					event.keyCode = 0;		
				}
			}
		}
		 
		</SCRIPT>
</HEAD>
	<body onload="Valorizza();" onunload="Close();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" width="590">
				<TR>
					<TD><span class="titolo">Imposta criterio</span><BR>
						<TABLE id="Table2" width="100%">
							<TR>
								<TD style="WIDTH: 161px" class="TableHeaderCampi2"><SELECT id="LstCampi" runat="server" style="DISPLAY:none"></SELECT><span id="nomCamp"></span></TD>
								<TD style="WIDTH: 71px"><SELECT id="operatore" onchange="SecondoValore();" runat="server">
										<OPTION selected>=</OPTION>
										<OPTION>&gt;</OPTION>
										<OPTION>&gt;=</OPTION>
										<OPTION>&lt;</OPTION>
										<OPTION>&lt;=</OPTION>
										<OPTION>&lt;&gt;</OPTION>
										<OPTION>BETWEEN</OPTION>
										<OPTION>LIKE</OPTION>
									</SELECT></TD>
								<TD style="WIDTH: 235px"><INPUT id="valore1" style="WIDTH: 184px; HEIGHT: 22px" onKeyPress="SoloNumeriVirgola();" type="text" size="25" runat="server"><INPUT type="button" class="btn" value="..." onclick="OpenValCampo(document.getElementById('valore1'))"></TD>
								<TD><INPUT onclick="AddFiltro();" type="button" value="Aggiungi"  class="btn"></TD>
							</TR>
							<TR id="2val">
								<TD style="WIDTH: 161px"></TD>
								<TD style="WIDTH: 71px">And</TD>
								<TD style="WIDTH: 235px"><INPUT id="valore2" style="WIDTH: 184px; HEIGHT: 22px" onKeyPress="SoloNumeriVirgola();" type="text" size="25" runat="server"><INPUT type="button"  class="btn" value="..." onclick="OpenValCampo(document.getElementById('valore2'))"></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:listbox id="ListBox1" runat="server" Width="600px"></asp:listbox><BR>
						<INPUT onclick="Salva()"  class="btn" type="button" value="Salva"><INPUT onclick="Annulla();"  class="btn" type="button" value="Annulla"><BR>
						<INPUT id="hiddenField" style="WIDTH: 616px; HEIGHT: 22px" type="hidden" size="97"></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table3" width="300">
							<TR>
								<TD  class="TableHeaderCampi2">Opzioni di Campo</TD>
							</TR>
							<TR>
								<TD>Nascosto <INPUT id="nascosto" onclick="CambiaNascosco()" type="checkbox" value="1" name="Checkbox1"></TD>
							</TR>
							<TR>
								<TD>Raggruppamento: <INPUT id="sum" onclick="CambiaAggregazione()" type="checkbox" value="SUM">Somma
									<INPUT id="count" onclick="CambiaAggregazione()" type="checkbox" value="COUNT">Conteggio</TD>
							</TR>
							<TR>
								<TD>Ordinamento:
									<SELECT id="ordinamento" onchange="CambiaOrdinamento();">
										<OPTION value="NESSUNO" selected>NESSUNO</OPTION>
										<OPTION value="ASC">ASC</OPTION>
										<OPTION value="DESC">DESC</OPTION>
									</SELECT></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
