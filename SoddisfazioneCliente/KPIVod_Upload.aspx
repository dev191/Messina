<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="KPIVod_Upload.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.KPIVod_Upload" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>KPI Vodafone</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function checkFileExtension(elem) {
				var filePath = elem.value;

				if(filePath.indexOf('.') == -1)
					return false;
		        
				var validExtensions = new Array();
				var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();
		    
				validExtensions[0] = 'xls';
		    
				for(var i = 0; i < validExtensions.length; i++) {
					if(ext == validExtensions[i])
						return true;
				}

				alert("L'estenzione del file ' + ext.toUpperCase() + ' selezionato non è valida!");
				return false;
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD>
						<TABLE class=tblSearch100Dettaglio style="WIDTH: 100%" 
                  cellSpacing=1 cellPadding=1 border=0>
							<TR>
								<TD></TD>
								<TD colSpan="3">Invia i KPI al Server per elaborare SLA. Questa operazione potrebbe 
									richiedere qualche minuto per l'elaborazione.</TD>
							</TR>
							<TR>
								<TD>Invio Documento:</TD>
								<TD colSpan="3"><INPUT id="UploadFile" title="Seleziona il documento da inviare." style="WIDTH: 400px; HEIGHT: 22px"
										type="file" size="47" name="UploadFile" runat="server">&nbsp;
									<asp:button id="BtInvia" runat="server" Width="112px" Text="Salva/Invia KPI"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMessage" runat="server" ForeColor="Navy"></asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><A class="GuidaLink" href="../<%= HelpLink %>" 
                  target="_blank">Guida</A></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
