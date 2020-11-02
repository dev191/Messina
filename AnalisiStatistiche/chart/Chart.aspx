<%@ Page language="c#" Codebehind="Chart.aspx.cs" AutoEventWireup="false" Inherits="chart.Chart" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Chart</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">


		function enableLiniare()
		{
			document.getElementById("<%=TxtEsponente.ClientID%>").disabled= true;
			document.getElementById("<%=drpzoom.ClientID%>").disabled= false;
		}
		function enableLogaritmica()
		{
			document.getElementById("<%=TxtEsponente.ClientID%>").disabled= false;
			document.getElementById("<%=drpzoom.ClientID%>").disabled= true;
		}
		
		</SCRIPT>
	</HEAD>
	<BODY>
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="mainTable" border="2">
				<TBODY>
					<TR>
						<TD>
							<TABLE id="SopraChart" cellspacing="0" cellpadding="0" align="left" border="0">
								<TBODY>
									<TR>
										<TD>Anno:
										</TD>
										<TD><ASP:TEXTBOX id="TxtAnno" runat="server" width="100px"></ASP:TEXTBOX><ASP:RANGEVALIDATOR id="RangeValidator2" runat="server" errormessage="Il Campo Anno deve essere un numero intero positivo compreso tra 1900 e 2005"
												forecolor="Brown" controltovalidate="TxtAnno" minimumvalue="1900" maximumvalue="9999" type="Integer">*</ASP:RANGEVALIDATOR></TD>
										<TD>max(hh):
										</TD>
										<TD><ASP:TEXTBOX id="TxtNore" runat="server" width="100px">72</ASP:TEXTBOX><ASP:RANGEVALIDATOR id="RangeValidator1" runat="server" errormessage="Il campo Max(hh)deve  appartenere  ad un inetrvallo nomerico intero  tra 2 e 920. "
												forecolor="Brown" controltovalidate="TxtNore" minimumvalue="2" maximumvalue="920" type="Integer">*</ASP:RANGEVALIDATOR></TD>
									</TR>
									<TR>
										<TD>Scala Lineare
										</TD>
										<TD><ASP:RADIOBUTTON id="RbtLineare" runat="server" groupname="Scala" checked="True"></ASP:RADIOBUTTON></TD>
										<TD>Zoom
										</TD>
										<TD colspan="3"><ASP:DROPDOWNLIST id="drpzoom" runat="server" width="100px"></ASP:DROPDOWNLIST></TD>
									</TR>
									<TR>
										<TD>Scala Logaritmica
										</TD>
										<TD><ASP:RADIOBUTTON id="RbtLogaritmica" runat="server" groupname="Scala"></ASP:RADIOBUTTON></TD>
										<TD>Esponente di Dilatazione:
										</TD>
										<TD colspan="2"><ASP:TEXTBOX id="TxtEsponente" runat="server" width="100px">3</ASP:TEXTBOX><ASP:RANGEVALIDATOR id="RangeValidator3" runat="server" errormessage="Il campo Esponenete di dilatazione puo' contenere un intervallo numerico reale da 1 a 5 "
												forecolor="Brown" controltovalidate="TxtEsponente" minimumvalue="1" maximumvalue="5" type="Double">*</ASP:RANGEVALIDATOR></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>Dimensione della Legenda:
										</TD>
										<TD><ASP:TEXTBOX id="txtRaggioLabel" runat="server" width="100px">100</ASP:TEXTBOX>
											<ASP:RANGEVALIDATOR id="RangeValidatorRaggioLabel" runat="server" errormessage="La dimezione della legenda deve essere un numero intero compreso tra 1 e 400"
												type="Integer" minimumvalue="1" maximumvalue="4000" controltovalidate="txtRaggioLabel">*</ASP:RANGEVALIDATOR></TD>
										<TD></TD>
										<TD align="left" colspan="3"><ASP:BUTTON id="sbtSubmit" runat="server" width="100px" text="Aggiorna " cssclass="btn"></ASP:BUTTON></TD>
									</TR>
									<TR>
										<TD colspan="6"><ASP:VALIDATIONSUMMARY id="ValidationSummary1" runat="server" forecolor="CornflowerBlue" height="40px"></ASP:VALIDATIONSUMMARY></TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>
							<TABLE id="TableChart">
								<TBODY>
									<TR>
										<TD><IFRAME class=fram id=ifrChart 
            title="Display chart" tabIndex=0 name=ifrChart align=middle 
            src="about:blank" frameBorder=no width="<%=latoFrame%>" scrolling=no 
            height="<%=latoFrame%>"></IFRAME>
											<SCRIPT language="javascript">
												document.getElementById("ifrChart").src='<%=urlChart%>';
											</SCRIPT>
										</TD>
									</TR>
									<TR>
										<TD>
											<IFRAME class="fram" id="TabellaDati" title="Dysplay Dati" name="ifrDati" align="middle"
												frameborder="no"></IFRAME>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<SCRIPT language="javascript">
	
			</SCRIPT>
		</FORM>
	</BODY>
</HTML>
