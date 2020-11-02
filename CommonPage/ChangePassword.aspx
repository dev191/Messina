<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="ChangePassword.aspx.cs" AutoEventWireup="false" Inherits="TheSite.CommonPage.ChangePassword" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ChangePassword</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		 function nascondi()
		 {
		  var ctrl=document.getElementById('<%=PanelMess.ClientID%>'); 
		  if(ctrl!=null)
		  {
		    ctrl.style.visibility = "hidden";
			ctrl.style.display = "none";
		  }
		 }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle>
			<table height="100%" cellSpacing="0" cellPadding="0" align="center" border="0">
				<tr>
					<td style="HEIGHT: 0.24%">&nbsp;</td>
				</tr>
				<tr>
					<td vAlign="middle">
						<div align="center"><asp:requiredfieldvalidator id="rfvconferma" runat="server" CssClass="LabelErrore" ControlToValidate="txtsConfermaPasword"
								ErrorMessage="Inserire la password corrente" Display="None"></asp:requiredfieldvalidator>
							<asp:requiredfieldvalidator id="rfvnuovapawd" runat="server" ErrorMessage="Inserire la conferma della nuova password"
								ControlToValidate="txtsNewPasword" CssClass="LabelErrore" Display="None"></asp:requiredfieldvalidator>
							<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="La nuova password deve essere uguale a quella di conferma."
								ControlToValidate="txtsConfermaPasword" Display="None" ControlToCompare="txtsNewPasword"></asp:CompareValidator>
							<table style="BORDER-RIGHT: slategray 1px outset; BORDER-TOP: slategray 1px outset; BORDER-LEFT: slategray 1px outset; WIDTH: 346px; BORDER-BOTTOM: slategray 1px outset; HEIGHT: 311px"
								cellSpacing="1" cellPadding="2" align="center" bgColor="gainsboro" border="0">
								<TR>
									<TD style="HEIGHT: 35px" vAlign="middle" colspan="2" class="TitleSearch" align="center">
										<b>Usa questo modulo per cambiare la tua Password. </b>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 130px; HEIGHT: 24px" vAlign="middle"></TD>
									<TD style="HEIGHT: 24px"></TD>
								</TR>
								<tr>
									<td style="HEIGHT: 1px" vAlign="middle" align="right"><span class="TestoNormale">PASSWORD 
											CORRENTE:</span></td>
									<td style="HEIGHT: 1px"><cc1:s_textbox id="txtsPasword" runat="server" DBDirection="Input" DBSize="0" Width="170px" TextMode="Password"></cc1:s_textbox></td>
								</tr>
								<tr>
									<td style="HEIGHT: 13px" vAlign="middle" align="right"><span class="TestoNormale">NUOVA 
											PASSWORD:</span></td>
									<td style="HEIGHT: 13px"><cc1:s_textbox id="txtsNewPasword" runat="server" DBDirection="Input" DBSize="0" Width="170px"
											DBIndex="1" TextMode="Password"></cc1:s_textbox></td>
								</tr>
								<TR>
									<TD style="HEIGHT: 13px" vAlign="middle" align="right">CONFERMA PASSWORD:</TD>
									<TD style="HEIGHT: 13px">
										<cc1:s_textbox id="txtsConfermaPasword" runat="server" Width="170px" DBSize="0" DBDirection="Input"
											TextMode="Password" DBIndex="1"></cc1:s_textbox></TD>
								</TR>
								<tr>
									<td style="HEIGHT: 43px" colSpan="2" align="center"><asp:button id="BttConferma" runat="server" Text="Cambia Password" CssClass="btn"></asp:button></td>
								</tr>
								<TR>
									<TD colSpan="2" align="center">
										<P align="center">
											<cc2:MessagePanel id="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"
												HorizontalAlign="Center" Wrap="False"></cc2:MessagePanel>
											<asp:ValidationSummary id="ValidationSummary1" runat="server" Width="301px"></asp:ValidationSummary></P>
									</TD>
								</TR>
							</table>
							<asp:requiredfieldvalidator id="rfvPassword" runat="server" CssClass="LabelErrore" ControlToValidate="txtsPasword"
								ErrorMessage="Inserire la nuova password" Display="None"></asp:requiredfieldvalidator><A 
      class=GuidaLink href="<%= HelpLink %>" target=_blank>Guida</A>
						</div>
					</td>
				</tr>
				<TR>
					<TD vAlign="middle" align="right"><A class=GuidaLink href="<%= HelpLink %>" 
      target=_blank></A></TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="right"></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
