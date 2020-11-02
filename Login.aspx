<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Login" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Login</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<STYLE type="text/css">BODY { MARGIN: 0px }
	INPUT { BORDER-RIGHT: #464a50 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #464a50 1px solid; PADDING-LEFT: 2px; FONT-WEIGHT: normal; FONT-SIZE: 11px; PADDING-BOTTOM: 2px; BORDER-LEFT: #464a50 1px solid; COLOR: #0a305c; PADDING-TOP: 2px; BORDER-BOTTOM: #464a50 1px solid; FONT-FAMILY: Tahoma }
		</STYLE>
		<LINK href="Styles/MenuStyle.css" type="text/css" rel="stylesheet">
		<LINK href="Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">		 
		 if (typeof(parent.left) != "undefined")
		 {
		   top.document.location.href='Default.aspx'
		  }
		</SCRIPT>
	</HEAD>
	<BODY ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE height="100%" cellspacing="0" cellpadding="0" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 0.24%">&nbsp;</TD>
				</TR>
				<TR>
					<TD valign="middle">
						<DIV align="center">
							<TABLE style="BORDER-RIGHT: slategray 1px outset; BORDER-TOP: slategray 1px outset; BORDER-LEFT: slategray 1px outset; WIDTH: 430px; BORDER-BOTTOM: slategray 1px outset; HEIGHT: 300px"
								cellspacing="1" cellpadding="2" align="center" bgcolor="#9bbec2" border="0">
								<TR>
									<TD style="HEIGHT: 35px" valign="middle" colspan="2" class="TitleSearch" align="center">
										<B>
											<%= TheSite.Classi.Helper.GetApplicationName()%>
										</B>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 130px; HEIGHT: 95px" valign="middle"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 18px" valign="middle" align="right">
										<SPAN class="TestoNormale" style="COLOR: white">USER</SPAN></TD>
									<TD style="HEIGHT: 18px">
										<CC1:S_TEXTBOX id="txtsUserName" runat="server" dbdirection="Input" dbsize="50" dbparametername="p_UserName"
											width="130px"></CC1:S_TEXTBOX>
										<ASP:REQUIREDFIELDVALIDATOR id="rfvUserName" runat="server" cssclass="LabelErrore" controltovalidate="txtsUserName"
											errormessage="Inserire l'utenza" forecolor="#0e737b"></ASP:REQUIREDFIELDVALIDATOR></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 13px" valign="middle" align="right">
									<SPAN class="TestoNormale" style="COLOR: white">PASSWORD</SPAN></TD>
									<TD style="HEIGHT: 13px"><CC1:S_TEXTBOX id="txtsPasword" runat="server" dbdirection="Input" dbsize="50" dbparametername="p_Password"
											width="130px" dbindex="1" textmode="Password"></CC1:S_TEXTBOX><ASP:REQUIREDFIELDVALIDATOR id="rfvPassword" runat="server" cssclass="LabelErrore" controltovalidate="txtsPasword"
											errormessage="Inserire la password" forecolor="#0e737b"></ASP:REQUIREDFIELDVALIDATOR></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 43px" colspan="2" align="center"><ASP:BUTTON id="BttConferma" runat="server" text="Conferma" cssclass="btn"></ASP:BUTTON></TD>
								</TR>
								<TR>									
									<TD colspan="2">Inserisci la username e la password relativa al sistema informativo per la gestione dei servizi di: <b><%= TheSite.Classi.Helper.GetApplicationName()%></b></TD>
								</TR>
								<TR>
									<TD colspan="2" align="center">
										<P align="center">
											<MESSPANEL:MESSAGEPANEL id="PanelMess" runat="server" messageiconurl="~/Images/ico_info.gif" erroriconurl="~/Images/ico_critical.gif"
												horizontalalign="Center" wrap="False"></MESSPANEL:MESSAGEPANEL></P>
									</TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
