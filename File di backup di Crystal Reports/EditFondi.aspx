<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="EditFondi.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditFondi" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Aggiorna Fondi</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<script language="javascript">
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
		</script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR vAlign="top" align="center" height="95%">
					<TD>
						<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" align="center">
							<TBODY>
								<TR>
									<TD style="WIDTH: 5%; HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" Width="512px" CssClass="TitleOperazione"></asp:label><cc2:messagepanel id="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"></cc2:messagepanel></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 1%" vAlign="top" align="left">
										<hr noShade SIZE="1">
									</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center"></TD>
									<TD vAlign="top" align="left"><asp:panel id="PanelEdit" runat="server">
											<TABLE id="tblSearch75" style="WIDTH: 75.98%; HEIGHT: 158px" cellSpacing="1" cellPadding="2"
												border="0">
												<TR>
													<TD style="WIDTH: 178px; HEIGHT: 30px" align="left">Anno&nbsp;
													</TD>
													<TD style="HEIGHT: 30px">
														<cc1:S_ComboBox id="cmbsAnno" runat="server" Width="88px" DBDirection="Input" DBParameterName="p_anno"
															DBIndex="1" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 178px; HEIGHT: 23px" align="left">Tipo Intervento</TD>
													<TD style="HEIGHT: 23px">
														<cc1:S_ComboBox id="cmbsTipoIntervento" runat="server" Width="319px" DBDirection="Input" DBParameterName="p_TipoIntervento"
															DBIndex="2" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 178px; HEIGHT: 23px" align="left">Importo Netto</TD>
													<TD style="HEIGHT: 23px">
														<cc1:S_TextBox id="txtsimporto_netto_intero" style="TEXT-ALIGN: right" tabIndex="1" runat="server"
															Width="112px" DBDirection="Input" DBParameterName="p_netto_intero" DBIndex="3" MaxLength="8"
															DBSize="50">0</cc1:S_TextBox>,
														<cc1:S_TextBox id="txtsimporto_netto_decimale" style="TEXT-ALIGN: right" tabIndex="1" runat="server"
															Width="32px" DBDirection="Input" DBParameterName="p_netto_decimale" DBIndex="4" MaxLength="2"
															DBSize="50">00</cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 178px; HEIGHT: 23px" align="left">Importo Lordo</TD>
													<TD style="HEIGHT: 23px">
														<cc1:S_TextBox id="txtsimporto_lordo_intero" style="TEXT-ALIGN: right" tabIndex="1" runat="server"
															Width="112px" DBDirection="Input" DBParameterName="p_lordo_intero" DBIndex="5" MaxLength="8"
															DBSize="50">0</cc1:S_TextBox>,
														<cc1:S_TextBox id="txtsimporto_lordo_decimale" style="TEXT-ALIGN: right" tabIndex="1" runat="server"
															Width="32px" DBDirection="Input" DBParameterName="p_lordo_decimale" DBIndex="6" MaxLength="2"
															DBSize="50">00</cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 178px; HEIGHT: 23px" align="left">Descrizione Fondo</TD>
													<TD style="HEIGHT: 23px">
														<cc1:S_TextBox id="txtsdescrizione" tabIndex="1" runat="server" Width="319px" DBDirection="Input"
															DBParameterName="p_descrizione" DBIndex="7" MaxLength="255" DBSize="50"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 178px; HEIGHT: 23px" align="left">Note</TD>
													<TD style="HEIGHT: 23px">
														<cc1:S_TextBox id="txtsNote" tabIndex="3" runat="server" Width="346px" DBDirection="Input" DBParameterName="p_note"
															DBIndex="8" MaxLength="500" DBSize="500" TextMode="MultiLine" Height="137px"></cc1:S_TextBox></TD>
												</TR>
											</TABLE>
										</asp:panel></TD>
								</TR>
								<tr>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="10" runat="server" Text="Salva" CssClass="btn"></cc1:s_button>&nbsp;
										<cc1:s_button id="btnsElimina" tabIndex="11" runat="server" Text="Elimina" CausesValidation="False"
											CommandType="Delete" CssClass="btn"></cc1:s_button>&nbsp;
										<asp:button id="btnAnnulla" tabIndex="12" runat="server" Text="Annulla" CausesValidation="False"
											CssClass="btn"></asp:button></TD>
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
			</TD></TR></TBODY></TABLE></form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
