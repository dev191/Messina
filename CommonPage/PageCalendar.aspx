<%@ Page language="c#" Codebehind="PageCalendar.aspx.cs" AutoEventWireup="false" Inherits="TheSite.CommonPage.PageCalendar" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PageCalendar</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="JavaScript">
var var_ie = false;
var var_browser = navigator.userAgent;
if( var_browser.indexOf("MSIE") > -1 ){
	var_ie = true;
}
function Chiudi()
{
	var oVDiv=parent.document.getElementById('<%=namediv%>').style;
	oVDiv.display = 'none';
}
function GetPrevYear(){
	if( document.form_cal.text_year.value > 1900 ){
		document.form_cal.text_year.value =  document.form_cal.text_year.value - 1;
	}
	else{
		document.form_cal.text_year.value =  9999;
	}
}

function GetNextYear(){
	var year = parseInt( document.form_cal.text_year.value ) + 1; 
	if(  year < 9999 ){
		document.form_cal.text_year.value = year;
	}
	else{
		document.form_cal.text_year.value = 1900;
	}
}

function GetPrevMonth(){
	var month = document.form_cal.select_month.options[document.form_cal.select_month.selectedIndex].value;
	if( month == 1){ month = 13;}
	document.form_cal.select_month.value = month - 1;
}

function GetNextMonth(){
	var month = parseInt( document.form_cal.select_month.options[document.form_cal.select_month.selectedIndex].value );
	if( month == 12){ month = 0;}
	document.form_cal.select_month.value = month + 1;
}

function GetDate(){
	//this.dateField   = opener.dateField;
	this.dateField =document.Form1.controlparent;
    //this.day     =  dateField.value;
	this.day = parent.document.getElementById(dateField.value  + "_" + "S_TxtDatecalendar").value;
	
	indice=document.Form1.Select1.selectedIndex ;
	datacompleta=document.Form1.Select1.options[indice].text;
	indice2=document.Form1.Select2.selectedIndex ;
	datacompleta=datacompleta + "    " +  document.Form1.Select2.options[indice2].value;
	document.Form1.Text1.value=datacompleta;
	
	var year =  document.form_cal.text_year.value ; 

	var month_index = parseInt( document.form_cal.select_month.selectedIndex );
	var month = 1;
	if( month_index > 0){
		month = parseInt( document.form_cal.select_month.options[month_index].value );
	}

	var daysOfMonth = 31;
	if(month==4||month==6||month==9||month==11){
  		daysOfMonth = 30;
	}
 	else{
			if( month == 2 ){
				daysOfMonth = 28;
				if( ( year % 4 == 0 && year % 100 != 0 ) || ( year % 400 == 0) ) {
					daysOfMonth = 29;
				}
			}
	}

	var date = new Date( year, month-1, 1);
	var dayOfFirst = date.getDay();
	var i;


	var var_day = 1;
	var dd;
	for( i = 0; i <= 41; i++) {
		if( ( i < dayOfFirst )  ||  ( var_day > daysOfMonth ) ){ 
			document.form_buttons.elements[i].value = "    "; 
			if( var_ie ){
				document.form_buttons.elements[i].style.visibility = "hidden";
			}
		}
		else{
			if( var_day.toString().length < 2 ){
				dd = " " + var_day + " ";
			}
			else{
				dd = var_day;
			}
			
			if( var_ie ){
				document.form_buttons.elements[i].style.visibility = "";
			}
			document.form_buttons.elements[i].value = dd;
			
			var today = new Date();
			if( var_ie ){
				if( dd == today.getDate() ){
					document.form_buttons.elements[i].style.color = "red"
					document.form_buttons.elements[i].style.fontSize = "8pt"				
				}
				else{
					document.form_buttons.elements[i].style.color = "black"
					document.form_buttons.elements[i].style.fontSize = "8pt"			
				}
			}

			var_day = var_day + 1;
		}				
	}
}

function SetDate( day )
{
	var month_index = parseInt( document.form_cal.select_month.selectedIndex );
	var month;
	if( month_index == 0){
		month = 1;
	}
	else{
		month = parseInt( document.form_cal.select_month.options[month_index].value );
	}

	if( month.toString().length < 2 ){
		month = "0" + month + "";
	}
	
	var dd = parseInt( day, 10 );
	if( dd < 10 ){
		dd = "0" + dd + "";
	}
	var year =  document.form_cal.text_year.value ; 

	if( year < 1900 || year > 9999) {
		alert( "Please enter a year between 1900 and 9999!");
	}
	else{
		//dateField.value = dd + "/" + month + "/" + year;
		parent.document.getElementById(dateField.value  + "_" + "S_TxtDatecalendar").value= dd + "/" + month + "/" + year;
		Chiudi();
	}
}

		</script>
	</HEAD>
	<BODY onLoad="GetDate()" bgcolor="#ffffff">
		<FORM name="form_cal" action="" ID="Form1">
			<input type="hidden" value='<%=Request.QueryString["idmodulocal"]%>'  id="controlparent"  name="controlparent">
			<table width="100%" border="0" align="center" bgcolor="#c0c0c0" summary="" ID="Table1">
				<tr>
					<td align="left" height="10"><asp:hyperlink id="HyperLink1" runat="server" Width="56px" Height="16px" NavigateUrl="javascript:Chiudi()"><img border="0" src="../Images/chiudi.gif" /></asp:hyperlink> </td>
				</tr>
				<tr>
					<td width="50%" height="42" align="center">
						<input type="text" name="DataCompleta" size="20" maxlength="10" border="0" style="BORDER-RIGHT: #c0c0c0; BORDER-TOP: #c0c0c0; FONT-SIZE: 14pt; BACKGROUND: #c0c0c0; BORDER-LEFT: #c0c0c0; COLOR: navy; BORDER-BOTTOM: #c0c0c0; FONT-FAMILY: Arial"
							ID="Text1">
					</td>
					<td height="42">
						<SELECT name="select_month" onChange="GetDate()" style="FONT-WEIGHT: bold" ID="Select1">
							<%if(d1.Month==1){%>
							<Option value="1">
								<%}else{%>
							<option value="1">
								<%}%>
								Gennaio
							</option>
							<%if(d1.Month==2){%>
							<Option value="2">
								<%}else{%>
							<Option value="2">
								<%}%>
								Febbraio</Option>
							<%if(d1.Month==3){%>
							<Option value="3">
								<%}else{%>
							<Option value="3">
								<%}%>
								Marzo</Option>
							<%if(d1.Month==4){%>
							<Option value="4">
								<%}else{%>
							<Option value="4">
								<%}%>
								Aprile</Option>
							<%if(d1.Month==5){%>
							<Option value="5">
								<%}else{%>
							<Option value="5">
								<%}%>
								Maggio</Option>
							<%if(d1.Month==6){%>
							<Option value="6">
								<%}else{%>
							<Option value="6">
								<%}%>
								Giugno</Option>
							<%if(d1.Month==7){%>
							<Option value="7">
								<%}else{%>
							<Option value="7">
								<%}%>
								Luglio</Option>
							<%if(d1.Month==8){%>
							<Option value="8">
								<%}else{%>
							<Option value="8">
								<%}%>
								Agosto</Option>
							<%if(d1.Month==9){%>
							<Option value="9">
								<%}else{%>
							<Option value="9">
								<%}%>
								Settembre</Option>
							<%if(d1.Month==10){%>
							<Option value="10">
								<%}else{%>
							<Option value="10">
								<%}%>
								Ottobre</Option>
							<%if(d1.Month==11){%>
							<Option value="11">
								<%}else{%>
							<Option value="11">
								<%}%>
								Novembre</Option>
							<%if(d1.Month==12){%>
							<Option Selected value="12">
								<%}else{%>
							<Option value="12">
								<%}%>
								Dicembre</Option>
						</SELECT>
					</td>
					<td height="42">
						<select name="text_year" style="FONT-WEIGHT: bold" ID="Select2" onChange="GetDate();">
							<% for (int i = 1900; i <= 2099 ; i++){
							if (d1.Year==i){ %>
							<option Selected value="<%= i%>">
								<% }else{ %>
							<option value="<%= i%>">
								<% } %>
								<%= i%>
							</option>
							<% }%>
						</select>
					</td>
				</tr>
			</table>
		</FORM>
		<table width="100%" border="1" align="center" cellpadding="0" cellspacing="0" bordercolorlight="#000000"
			bordercolordark="#ffffff" summary="" ID="Table2">
			<FORM name="form_buttons">
				<TBODY>
					<tr>
						<td bgcolor="#c0c0c0" bordercolor="#000000" bordercolorlight="#000000" bordercolordark="#ffffff"
							align="center"><font face="Arial" size="2"><b>Dom</b></font></td>
						<td bgcolor="#c0c0c0" bordercolor="#000000" bordercolorlight="#000000" bordercolordark="#ffffff"
							align="center"><font face="Arial" size="2"><b>Lun</b></font></td>
						<td bgcolor="#c0c0c0" bordercolor="#000000" bordercolorlight="#000000" bordercolordark="#ffffff"
							align="center"><font face="Arial" size="2"><b>Mar</b></font></td>
						<td bgcolor="#c0c0c0" bordercolor="#000000" bordercolorlight="#000000" bordercolordark="#ffffff"
							align="center"><font face="Arial" size="2"><b>Mer</b></font></td>
						<td bgcolor="#c0c0c0" bordercolor="#000000" bordercolorlight="#000000" bordercolordark="#ffffff"
							align="center"><font face="Arial" size="2"><b>Gio</b></font></td>
						<td bgcolor="#c0c0c0" bordercolor="#000000" bordercolorlight="#000000" bordercolordark="#ffffff"
							align="center"><font face="Arial" size="2"><b>Ven</b></font></td>
						<td bgcolor="#c0c0c0" bordercolor="#000000" bordercolorlight="#000000" bordercolordark="#ffffff"
							align="center"><font face="Arial" size="2"><b>Sab</b></font></td>
					</tr>
					<tr>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but1" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but2" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but3" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but4" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but5" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but6" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but7" onClick="SetDate(this.value)"></td>
					</tr>
					<tr>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but8" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but9" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but10" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but11" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but12" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but13" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but14" onClick="SetDate(this.value)"></td>
					</tr>
					<tr>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but15" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but16" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but17" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but18" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but19" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but20" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but21" onClick="SetDate(this.value)"></td>
					</tr>
					<tr>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but22" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but23" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but24" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but25" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but26" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but27" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but28" onClick="SetDate(this.value)"></td>
					</tr>
					<tr>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but29" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but30" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but31" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but32" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but33" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but34" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but35" onClick="SetDate(this.value)"></td>
					</tr>
					<tr>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but36" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but37" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but38" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but39" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but40" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but41" onClick="SetDate(this.value)"></td>
						<td align="center" height="20"><input style="WIDTH: 100%; HEIGHT: 100%" type="button" name="but42" onClick="SetDate(this.value)"></td>
					</tr>
			</FORM>
			</TBODY>
		</table>
	</BODY>
</HTML>
