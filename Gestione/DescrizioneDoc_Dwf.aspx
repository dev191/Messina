<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Page language="c#" Codebehind="DescrizioneDoc_Dwf.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.DescrizioneDoc_Dwf" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DescrizioneDoc_Dwf</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
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
			function nonpaste()
			{
				return false;
			}
			function abilita(sender)
			{
			   document.getElementById('<%=txtNumeroPagina.ClientID%>').disabled=!sender.checked;
			}
		</script>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center"></TD>
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD align="left" width="5%"></TD>
					<TD align="left" width="95%">
						<HR width="100%" SIZE="1">
						&nbsp;</TD>
				</TR>
				<TR>
					<TD align="left" width="5%" colSpan="1" rowSpan="1"></TD>
					<TD align="left" width="95%" colSpan="1" rowSpan="1">
						<TABLE id="tblSearch100" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 128px">Codice Edificio:
								</TD>
								<TD><cc1:s_label id="S_Lblcodedificio" runat="server"></cc1:s_label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Codice Documento:</TD>
								<TD><cc1:s_label id="S_LblCodiceDoc" runat="server"></cc1:s_label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Nome del File:</TD>
								<TD><cc1:s_label id="S_LblFileName" runat="server"></cc1:s_label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px; HEIGHT: 6px">Piano:</TD>
								<TD style="HEIGHT: 6px"><cc1:s_combobox id="cmbsPiano" runat="server" DBDataType="Integer" DBDirection="Input" DBParameterName="p_piano_id"
										DBIndex="14" Width="344px"></cc1:s_combobox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Servizio:</TD>
								<TD><cc1:s_combobox id="cmbsServizio" runat="server" DBDataType="Integer" DBDirection="Input" DBParameterName="p_servizio_id"
										DBIndex="15" Width="344px"></cc1:s_combobox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="cmbsServizio"
										ErrorMessage="Selezionare il Servizio"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Categoria Generale:</TD>
								<TD><cc1:s_combobox id="cmbsCategoriaGenerale" runat="server" Width="344px" AutoPostBack="True"></cc1:s_combobox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px; HEIGHT: 14px">Categoria</TD>
								<TD style="HEIGHT: 14px"><cc1:s_combobox id="cmbsCategoria" runat="server" Width="344px" AutoPostBack="True"></cc1:s_combobox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Tipologia del Documento:</TD>
								<TD><cc1:s_combobox id="cmbsTipologiaDocumento" runat="server" Width="344px" AutoPostBack="True"></cc1:s_combobox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px; HEIGHT: 24px">Tipologia del File:</TD>
								<TD style="HEIGHT: 24px"><cc1:s_combobox id="cmbsTipoFile" runat="server" Width="344px"></cc1:s_combobox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="cmbsTipoFile"
										ErrorMessage="Selezionare la Tipologia File"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Descrizione:</TD>
								<TD><cc1:s_textbox id="txtsdescrizione" runat="server" DBDirection="Input" Width="90%"></cc1:s_textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px">Rinomina il File:</TD>
								<TD>
									<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="300" border="0">
										<TR>
											<TD><cc1:s_checkbox id="CheckRinomina" runat="server"></cc1:s_checkbox></TD>
											<TD>Numero di Pagina:</TD>
											<TD><cc1:s_textbox id="txtNumeroPagina" runat="server" Width="49px">1</cc1:s_textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px" colSpan="2">
									<TABLE id="TableVVf" cellSpacing="1" cellPadding="1" width="400" border="0" runat="server">
										<TR>
											<TD style="WIDTH: 145px">N° Fascicolo VVF:<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtNFascicoloVVF"
													ErrorMessage="Inserire il N° Fascicolo">*</asp:requiredfieldvalidator></TD>
											<TD><cc1:s_textbox id="txtNFascicoloVVF" runat="server" DBDirection="Input" DBParameterName="p_nfascicolo"
													DBIndex="2" Width="224px" MaxLength="20" DBSize="20"></cc1:s_textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 145px">Data Rilascio CPI:</TD>
											<TD><uc1:calendarpicker id="CalendarPicker1VVF" runat="server"></uc1:calendarpicker></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 145px">Data Scadenza CPI:</TD>
											<TD><uc1:calendarpicker id="CalendarPicker2VVF" runat="server"></uc1:calendarpicker></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 145px">Data Parere Favorevole:</TD>
											<TD><uc1:calendarpicker id="CalendarPicker3VVF" runat="server"></uc1:calendarpicker></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 145px">Collaudo:</TD>
											<TD><cc1:s_checkbox id="checkCollaudoVVF" runat="server"></cc1:s_checkbox></TD>
										</TR>
									</TABLE>
									<TABLE id="TableISPESL" cellSpacing="1" cellPadding="1" width="400" border="0" runat="server">
										<TR>
											<TD>Matricola ISPELS:<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" Display="None" ControlToValidate="txtISPESL"
													ErrorMessage="Inserire la Matricola ISPELS">*</asp:requiredfieldvalidator></TD>
											<TD><cc1:s_textbox id="txtISPESL" runat="server" DBDirection="Input" DBParameterName="p_matricola"
													DBIndex="7" Width="224px" MaxLength="20" DBSize="20"></cc1:s_textbox></TD>
										</TR>
										<TR>
											<TD>Data Prima Verifica:</TD>
											<TD><uc1:calendarpicker id="CalendarPicker4ISPESL" runat="server"></uc1:calendarpicker></TD>
										</TR>
										<TR>
											<TD>Anno Scadenza:</TD>
											<TD><cc1:s_combobox id="S_CbAnno" runat="server" DBDirection="Input" DBParameterName="p_anno" DBIndex="9"
													Width="128px" DBSize="4"></cc1:s_combobox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px; HEIGHT: 21px">File da inviare:
									<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" Display="None" ControlToValidate="Uploader"
										ErrorMessage="Selezionare il file da Inviare">*</asp:requiredfieldvalidator></TD>
								<TD style="HEIGHT: 21px"><INPUT id="Uploader" style="WIDTH: 344px; HEIGHT: 18px" type="file" size="28" runat="server"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px" colSpan="2"></TD>
							</TR>
						</TABLE>
						<TABLE id="Table3" style="WIDTH: 400px; HEIGHT: 27px" cellSpacing="1" cellPadding="1" width="400"
							border="0">
							<TR>
								<TD><cc1:s_button id="btNuovo" runat="server" Width="128px" CssClass="btn" Text="Nuovo File" CausesValidation="False"></cc1:s_button></TD>
								<TD><cc1:s_button id="btSalva" runat="server" Width="128px" CssClass="btn" Text="Salva"></cc1:s_button></TD>
								<TD><cc1:s_button id="btBack" runat="server" Width="128px" CssClass="btn" Text="Indietro" CausesValidation="False"></cc1:s_button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="left"></TD>
					<TD align="left">
						<HR width="100%" SIZE="1">
						<cc1:s_label id="S_Lblerror" runat="server" ForeColor="Red"></cc1:s_label><asp:validationsummary id="ValidationSummary1" runat="server" Width="648px"></asp:validationsummary><cc1:s_label id="lblFirstAndLast" runat="server"></cc1:s_label></TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
