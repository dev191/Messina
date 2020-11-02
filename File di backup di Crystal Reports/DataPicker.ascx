<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="DataPicker.ascx.cs" Inherits="TheSite.WebControls.DataPicker" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<P><cc1:s_textbox id="txtDataPicker" runat="server" Width="128px"></cc1:s_textbox><INPUT id="btCalendar" title="Visualizza il Calendario" style="WIDTH: 32px; HEIGHT: 28px"
		onclick="ShowCalendar()" type="button" value="..." class=btn></P>
<div id="PopupDiv" style="DISPLAY: none; Z-INDEX: 100; WIDTH: 220px; COLOR: #ffffff; POSITION: absolute; HEIGHT: 201px; BACKGROUND-COLOR: #000000"
	runat="server"><asp:calendar id="Calendar1" runat="server" BorderStyle="Solid" ShowGridLines="True" BorderColor="#FFCC66"
		Font-Names="Verdana" Font-Size="8pt" Height="200px" ForeColor="#663399" DayNameFormat="FirstLetter" Width="220px"
		BorderWidth="1px" BackColor="#FFFFCC">
		<TodayDayStyle BorderWidth="1px" ForeColor="White" BorderStyle="Solid" BackColor="#FFCC66"></TodayDayStyle>
		<SelectorStyle BorderWidth="1px" BorderStyle="Solid" BorderColor="Red" BackColor="#FFCC66"></SelectorStyle>
		<DayStyle BackColor="Red"></DayStyle>
		<NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC"></NextPrevStyle>
		<DayHeaderStyle Height="1px" BorderWidth="1px" BorderStyle="Solid" BackColor="#FFCC66"></DayHeaderStyle>
		<SelectedDayStyle Font-Bold="True" BorderWidth="1px" BorderStyle="Solid" BackColor="#CCCCFF"></SelectedDayStyle>
		<TitleStyle Font-Size="9pt" Font-Bold="True" HorizontalAlign="Center" BorderWidth="1px" ForeColor="#FFFFCC"
			BorderStyle="Solid" BackColor="#990000"></TitleStyle>
		<WeekendDayStyle BorderWidth="1px" BorderStyle="Solid"></WeekendDayStyle>
		<OtherMonthDayStyle BorderWidth="1px" ForeColor="#CC9966" BorderStyle="Solid"></OtherMonthDayStyle>
	</asp:calendar></div>
<iframe id="DivShim" style="DISPLAY: none; POSITION: absolute" src="javascript:false;" frameBorder="0"
	scrolling="no" runat="server"></iframe>
<script language="javascript">
function ShowCalendar()
{
    var DivRef=document.getElementById("<%=namecontrol%>" +  "_PopupDiv"); 
    var IfrRef = document.getElementById("<%=namecontrol%>" + "_DivShim");
	if(DivRef.style.display == 'none'){
		DivRef.style.display = "block";
		IfrRef.style.width = DivRef.offsetWidth;
		IfrRef.style.height = DivRef.offsetHeight;
		IfrRef.style.top = DivRef.style.top;
		IfrRef.style.left = DivRef.style.left;
		IfrRef.style.zIndex = DivRef.style.zIndex - 1;
		IfrRef.style.display = "block";
    }
    else
    {
     DivRef.style.display = "none";
     IfrRef.style.display = "none";
    }

}
function ShowCalendar2(sender)
{
    var DivRef=document.getElementById("<%=namecontrol%>" +  "_PopupDiv"); 
    var IfrRef = document.getElementById("<%=namecontrol%>" + "_DivShim");
	if(sender == true){
		DivRef.style.display = "block";
		IfrRef.style.width = DivRef.offsetWidth;
		IfrRef.style.height = DivRef.offsetHeight;
		IfrRef.style.top = DivRef.style.top;
		IfrRef.style.left = DivRef.style.left;
		IfrRef.style.zIndex = DivRef.style.zIndex - 1;
		IfrRef.style.display = "block";
    }
    else
    {
     DivRef.style.display = "none";
     IfrRef.style.display = "none";
    }

}
</script>

