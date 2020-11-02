<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="VisualizzaReperibilita" Src="../WebControls/VisualizzaReperibilita.ascx" %>
<%@ Page language="c#" Codebehind="EditRepAddetti.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditRepAddetti" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditRepAddetti</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<script language="JavaScript">
		function Valorizza(val)
			{
				document.getElementById("txtHidden").value=val;
			}
			
		function SoloNumeri()
		{	
			if (event.keyCode < 48	|| event.keyCode > 57){
				event.keyCode = 0;
			}	
		}
		function Formatta(txt)
		{
			testo=document.getElementById(txt);
			if(testo.value.length==0)
				testo.value="00";
			if(testo.value.length==1)
				testo.value="0"+testo.value;		
		}
		function Controlla()
		{
			var ora=parseInt(document.getElementById("<%=txtsorain.ClientID%>").value);
			var minuti=parseInt(document.getElementById("<%=txtsorainmin.ClientID%>").value);
			var ore=(document.getElementById("<%=txtsorain.ClientID%>").value)+(document.getElementById("<%=txtsorainmin.ClientID%>").value)
			
						
			if(document.getElementById("txtHidden").value=="1")
			{
			
				if(ora<0 || ora>23)
				{ 

					alert("Attenzione l'ora deve essere compresa tra 00 e 23");		
					document.getElementById("<%=txtsorain.ClientID%>").focus()
					return false;
				}	
				if(minuti<0 || minuti>59)
				{
					alert("Attenzione i minuti deve essere compresa tra 00 e 59");		
					document.getElementById("<%=txtsorainmin.ClientID%>").focus();
					return false;
				}
				
				var ora1=parseInt(document.getElementById("<%=txtsoraout.ClientID%>").value);
				var minuti1=parseInt(document.getElementById("<%=txtsoraoutmin.ClientID%>").value);
				var ore1=(document.getElementById("<%=txtsoraout.ClientID%>").value) + document.getElementById("<%=txtsoraoutmin.ClientID%>").value;
							
				if(ora1<0 || ora1>23)
				{ 

					alert("Attenzione l'ora deve essere compresa tra 00 e 23");		
					document.getElementById("<%=txtsoraout.ClientID%>").focus()
					return false;
				}	
				if(minuti1<0 || minuti1>59)
				{
					alert("Attenzione i minuti deve essere compresa tra 00 e 59");		
					document.getElementById("<%=txtsoraoutmin.ClientID%>").focus();
					return false;
				}
				if(ore>ore1)
				{
					alert("Attenzione l'ora fine turno non può essere minore di quella di inizio");		
					document.getElementById("<%=txtsoraoutmin.ClientID%>").focus();
					return false;
				}
				return true;
			}
			else
			{
			    return true;
			}
		}
		</script>
		<form id="Form1" onsubmit="return Controlla();" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR vAlign="top" align="center" height="95%">
					<TD>
						<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<TBODY>
								<TR>
									<INPUT id="txtHidden" type="hidden">
									<TD style="WIDTH: 5%; HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" Width="584px" CssClass="TitleOperazione"></asp:label><cc2:messagepanel id="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"></cc2:messagepanel></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 1%" vAlign="top" align="left">
										<hr noShade SIZE="1">
									</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center"></TD>
									<TD vAlign="top" align="left" width="100%"><asp:panel id="PanelEdit" runat="server" Width="100%">
											<TABLE id="tblSearch100" cellSpacing="1" cellPadding="2" width="100%" border="0">
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 32px" align="left">Addetto
														<asp:RangeValidator id="RVraddetto" runat="server" ErrorMessage="Selezionare Addetto" MinimumValue="1"
															MaximumValue="999999999999999999" ControlToValidate="cmbsadd">*</asp:RangeValidator></TD>
													<TD style="HEIGHT: 32px">
														<cc1:S_ComboBox id="cmbsadd" tabIndex="4" runat="server" Width="60%" DBDirection="Input" DBSize="10"
															DBParameterName="p_addetto_id" DBIndex="0" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 15px" align="left">Giorno
														<asp:RangeValidator id="RVrgiorno" runat="server" ErrorMessage="Selezionare il Giorno" MinimumValue="1"
															MaximumValue="999999999999999999" ControlToValidate="cmbsgiorno">*</asp:RangeValidator></TD>
													<TD style="HEIGHT: 15px">
														<cc1:S_ComboBox id="cmbsgiorno" tabIndex="5" runat="server" Width="60%" DBDirection="Input" DBSize="10"
															DBParameterName="p_giorno_id" DBIndex="1" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 24px" align="left">Data Inizio Turno</TD>
													<TD style="HEIGHT: 24px">
														<asp:TextBox id="txtsorain" runat="server" Width="30px"></asp:TextBox>
														<DIV style="DISPLAY: inline; WIDTH: 24px; HEIGHT: 15px" ms_positioning="FlowLayout">&nbsp;&nbsp;:</DIV>
														<asp:TextBox id="txtsorainmin" runat="server" Width="30px"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 18px" align="left">Data Fine Turno</TD>
													<TD>
														<asp:TextBox id="txtsoraout" runat="server" Width="30px"></asp:TextBox>
														<DIV style="DISPLAY: inline; WIDTH: 24px; HEIGHT: 15px" ms_positioning="FlowLayout">&nbsp;&nbsp;:</DIV>
														<asp:TextBox id="txtsoraoutmin" runat="server" Width="30px"></asp:TextBox></TD>
												</TR>
											</TABLE>
										</asp:panel></TD>
								</TR>
								<tr>
									<TD style="HEIGHT: 3.46%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 3.46%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="7" runat="server" Text="Salva" CssClass="btn"></cc1:s_button>&nbsp;&nbsp;&nbsp;
										<asp:button id="btnAnnulla" tabIndex="9" runat="server" Text="Annulla" CausesValidation="False"
											CssClass="btn"></asp:button>
										<uc1:VisualizzaReperibilita id="VisualizzaReperibilita1" runat="server"></uc1:VisualizzaReperibilita></TD>
								</tr>
								<TR>
									<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 1%" vAlign="top" align="left">
										<hr noShade SIZE="1">
									</TD>
								</TR>
				</TR>
				<TR>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblFirstAndLast" runat="server"></asp:label>&nbsp;
					</TD>
				</TR>
			</TABLE>
			<asp:validationsummary id="vlsEdit" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD></TR></TBODY></TABLE></form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
