<%@ Page language="c#" Codebehind="EditFondi.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditFondi" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
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
													<TD style="WIDTH: 178px; HEIGHT: 25px" align="left">Codice Fondo</TD>
													<TD style="HEIGHT: 25px">
														<cc1:S_TextBox id="TxtCodFondo" tabIndex="1" runat="server" Width="319px" DBIndex="7" DBParameterName="p_descrizione"
															DBDirection="Input" DBSize="50" MaxLength="255"></cc1:S_TextBox>
														<asp:RequiredFieldValidator id="Rq1" runat="server" ControlToValidate="TxtCodFondo" Display="Dynamic" ErrorMessage="Il Codice Fondo è Obbligatorio">*</asp:RequiredFieldValidator></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 178px; HEIGHT: 30px" align="left">Data validità&nbsp;del Fondo:</TD>
													<TD>
														<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
															<TR>
																<TD>Dal 1°:</TD>
																<TD>
																	<asp:DropDownList id="DrMeseini" runat="server">
																		<asp:ListItem Value="0">--Seleziona un mese --</asp:ListItem>
																		<asp:ListItem Value="2">Gennaio</asp:ListItem>
																		<asp:ListItem Value="3">Febbraio</asp:ListItem>
																		<asp:ListItem Value="4">Marzo</asp:ListItem>
																		<asp:ListItem Value="5">Aprile</asp:ListItem>
																		<asp:ListItem Value="6">maggio</asp:ListItem>
																		<asp:ListItem Value="7">Giugno</asp:ListItem>
																		<asp:ListItem Value="8">Luglio</asp:ListItem>
																		<asp:ListItem Value="9">Agosto</asp:ListItem>
																		<asp:ListItem Value="10">Settembre</asp:ListItem>
																		<asp:ListItem Value="11">Novembre</asp:ListItem>
																		<asp:ListItem Value="12">Dicembre</asp:ListItem>
																		
																	</asp:DropDownList></TD>
																<TD>Anno Inizio:</TD>
																<TD>
																	<asp:DropDownList id="DrAnnoIni" runat="server"></asp:DropDownList></TD>
															</TR>
															<TR>
																<TD>Al 1°:</TD>
																<TD>
																	<asp:DropDownList id="secondomese" runat="server">
																		<asp:ListItem Value="0">--Seleziona un mese --</asp:ListItem>
																		<asp:ListItem Value="2">Gennaio</asp:ListItem>
																		<asp:ListItem Value="3">Febbraio</asp:ListItem>
																		<asp:ListItem Value="4">Marzo</asp:ListItem>
																		<asp:ListItem Value="5">Aprile</asp:ListItem>
																		<asp:ListItem Value="6">maggio</asp:ListItem>
																		<asp:ListItem Value="7">Giugno</asp:ListItem>
																		<asp:ListItem Value="8">Luglio</asp:ListItem>
																		<asp:ListItem Value="9">Agosto</asp:ListItem>
																		<asp:ListItem Value="10">Settembre</asp:ListItem>
																		<asp:ListItem Value="11">Novembre</asp:ListItem>
																		<asp:ListItem Value="12">Dicembre</asp:ListItem></asp:DropDownList></TD>
																<TD>Anno Fine:</TD>
																<TD>
																	<asp:DropDownList id="DrAnnofine" runat="server"></asp:DropDownList></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 178px; HEIGHT: 30px" align="left">Fondo Predefinito:</TD>
													<TD>
														<asp:CheckBox id="CkDefault" runat="server" Text="Imposta il Fondo come Predefinito"></asp:CheckBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 178px; HEIGHT: 30px" align="left">Periodicità del fondo:</TD>
													<TD style="HEIGHT: 30px">
														<asp:DropDownList id="cmbPeriodo" runat="server" Width="320px">
															<asp:ListItem Value="1">Mensile</asp:ListItem>
															<asp:ListItem Value="2">Bimestrale</asp:ListItem>
															<asp:ListItem Value="3">Trimestrale</asp:ListItem>
															<asp:ListItem Value="4">Quadrimestrale</asp:ListItem>
															<asp:ListItem Value="6">Semestrale</asp:ListItem>
															<asp:ListItem Value="12">Annuale</asp:ListItem>
														</asp:DropDownList></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 178px; HEIGHT: 23px" align="left">Tipo Intervento:</TD>
													<TD style="HEIGHT: 23px">
														<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
															<TR>
																<TD style="WIDTH: 237px">
																	<asp:ListBox id="ListTipoManutenzioneAdd" runat="server" Width="240px" SelectionMode="Multiple"
																		Height="73px"></asp:ListBox>
																	<asp:RequiredFieldValidator id="Rq4" runat="server" ControlToValidate="ListTipoManutenzioneAdd" Display="Dynamic"
																		ErrorMessage="Selezionare almeno un tipo intervento" InitialValue="0">*</asp:RequiredFieldValidator></TD>
																<TD style="WIDTH: 16px">
																	<P>
																		<asp:Button id="BtAdd" runat="server" Text="<-" CausesValidation="False"></asp:Button></P>
																	<P>
																		<asp:Button id="BtRemove" runat="server" Text="->" CausesValidation="False"></asp:Button></P>
																</TD>
																<TD>
																	<asp:ListBox id="ListTipoManutenzione" runat="server" Width="240px" SelectionMode="Multiple"
																		Height="73px"></asp:ListBox></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 178px; HEIGHT: 23px" align="left">Importo Netto:</TD>
													<TD style="HEIGHT: 23px">
														<cc1:S_TextBox id="txtsimporto_netto_intero" style="TEXT-ALIGN: right" tabIndex="1" runat="server"
															Width="112px" DBIndex="3" DBParameterName="p_netto_intero" DBDirection="Input" DBSize="50"
															MaxLength="8">0</cc1:S_TextBox>,
														<cc1:S_TextBox id="txtsimporto_netto_decimale" style="TEXT-ALIGN: right" tabIndex="1" runat="server"
															Width="32px" DBIndex="4" DBParameterName="p_netto_decimale" DBDirection="Input" DBSize="50"
															MaxLength="2">00</cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 178px; HEIGHT: 23px" align="left">Importo Lordo:</TD>
													<TD style="HEIGHT: 23px">
														<cc1:S_TextBox id="txtsimporto_lordo_intero" style="TEXT-ALIGN: right" tabIndex="1" runat="server"
															Width="112px" DBIndex="5" DBParameterName="p_lordo_intero" DBDirection="Input" DBSize="50"
															MaxLength="8">0</cc1:S_TextBox>,
														<cc1:S_TextBox id="txtsimporto_lordo_decimale" style="TEXT-ALIGN: right" tabIndex="1" runat="server"
															Width="32px" DBIndex="6" DBParameterName="p_lordo_decimale" DBDirection="Input" DBSize="50"
															MaxLength="2">00</cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 178px; HEIGHT: 23px" align="left">Descrizione Fondo:</TD>
													<TD style="HEIGHT: 23px">
														<cc1:S_TextBox id="txtsdescrizione" tabIndex="1" runat="server" Width="319px" DBIndex="7" DBParameterName="p_descrizione"
															DBDirection="Input" DBSize="50" MaxLength="255"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 178px; HEIGHT: 23px" align="left">Note</TD>
													<TD style="HEIGHT: 23px">
														<cc1:S_TextBox id="txtsNote" tabIndex="3" runat="server" Width="346px" DBIndex="8" DBParameterName="p_note"
															DBDirection="Input" DBSize="500" MaxLength="500" Height="56px" TextMode="MultiLine"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 178px; HEIGHT: 23px" align="left">Piano:</TD>
													<TD style="HEIGHT: 23px">
														<asp:DropDownList id="DrPiano" runat="server" Width="344px"></asp:DropDownList></TD>
												</TR>
											</TABLE>
										</asp:panel><asp:validationsummary id="ValidationSummary1" runat="server" Width="720px"></asp:validationsummary></TD>
								</TR>
								<tr>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="10" runat="server" CssClass="btn" Text="Salva"></cc1:s_button>&nbsp;
										<cc1:s_button id="btnsElimina" tabIndex="11" runat="server" CssClass="btn" Text="Elimina" CausesValidation="False"
											CommandType="Delete"></cc1:s_button>&nbsp;
										<asp:button id="btnAnnulla" tabIndex="12" runat="server" CssClass="btn" Text="Annulla" CausesValidation="False"></asp:button></TD>
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
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
