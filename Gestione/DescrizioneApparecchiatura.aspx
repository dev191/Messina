<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Page language="c#" Codebehind="DescrizioneApparecchiatura.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.DescrizioneApparecchiatura" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="UserStanze" Src="../WebControls/UserStanze.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DescrizioneApparecchiatura</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">


		function clearRoom()
	{
		document.getElementById("<%=UserStanze1.s_TxtIdStanza.ClientID%>").value="";
		document.getElementById("<%=UserStanze1.s_TxtDescStanza.ClientID%>").value="";	
	}   
					
			var NS4 = (navigator.appName == "Netscape" && parseInt(navigator.appVersion) < 5);
			var NSX = (navigator.appName == "Netscape");
			var IE4 = (document.all) ? true : false;
			var finestra;
			
		function AbilitaCmbsUM()
		{//cmbsUDM
			ctrl=document.getElementById('<%=Contatore.ClientID%>');
			Cmb=document.getElementById('<%=cmbsUDM.ClientID%>');
			 if(ctrl.checked==true)
				Cmb.disabled=false;
    		 else
    		    Cmb.disabled=true;
    		  
		}

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
			
		
	
		 function chiudi()
		 {
		  if (finestra!=null)
		      finestra.close();
		 }
		 function opendoc(sender)
		 {
			var url;		
			url = "../AnagrafeImpianti/ListaDatiApparecchiatura.aspx?" + sender;
			finestra=window.open(url,'LIST','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width=800,height=600,align=center');
		 }
	function ControllaData()
	{
	
		
		var datamagg = document.getElementById("CalendarPicker1_S_TxtDatecalendar").value
		
		if (datamagg=="")
		{
			alert("La data di Inizio Validità è Obbligatoria!");
			document.getElementById("CalendarPicker1_S_TxtDatecalendar").focus();
			return false;
		}
		var datamagg2 = document.getElementById("CalendarPicker2_S_TxtDatecalendar").value
		
		if (datamagg2=="")
		{
			alert("La data di Fine Validità è Obbligatoria!");
			document.getElementById("CalendarPicker2_S_TxtDatecalendar").focus();
			return false;
		}
		
		var Data1 = datamagg.substr(6,4) + datamagg.substr(3,2) + datamagg.substr(0,2);	
		
		var Data2 = datamagg2.substr(6,4) + datamagg2.substr(3,2) + datamagg2.substr(0,2);	
		
							
		if (Data1>Data2)
		{
			alert("La data di Inizio Validità non può essere maggiore della data di Fine Validità.");
			document.getElementById("CalendarPicker1_S_TxtDatecalendar").focus();
			return false;
		}
		return true;						
	}	
	function Abilita(val)
	{
		var pan1 = document.getElementById("<%=PanelEditAnag.ClientID%>");
		var pan2 = document.getElementById("<%=PanelEditDocumenti.ClientID%>")
		switch (val)
		{
			case 0: //Anagrafica Apparecchiatura
				pan1.style.display='block';
				pan2.style.display='none';
				break;
			case 1: //Documenti Allegati
				pan1.style.display='none';
				pan2.style.display='block';
				break;
		}
	}
function openallegati(namefile)
 {
   var url;		
   
   url = "../ManutenzioneCorrettiva/Visualpdf.aspx?name=" +namefile + "&mittente=Apparecchiatura" ; 
   
   finestra=window.open(url,'','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width=800,height=600,align=center');	
 }
 
 function Nascondi()
 {
 	var ctrl=document.getElementById('Radio1');
 	var td = document.getElementById('txtApparechiatura');
 	//alert(ctrl.checked);
 			 if(ctrl.checked)
 			 {
 				 td.disabled=false;
 			 }
 			 else
			 {
					 td.disabled=true;
			 }
	 }
		
		function tipoInserimento()
	{
		var ctrl=document.getElementById('Radio1');
	 	var td = document.getElementById('txtApparechiatura');
	 	if ((ctrl.checked==true) && (td.value==""))
	 	{
	 		alert("Inserire il codice apparecchiatura manualmente");
	 		return false;
	 	}
	 	else
	 	{ 	return true;}
	 	
 	}
	
		</script>
	</HEAD>
	<body onbeforeunload="chiudi();parent.left.valorizza()" MS_POSITIONING="GridLayout" onload="Abilita(<%=TabId%>);">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TBODY>
					<TR>
						<TD align="center"></TD>
						<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD align="center"></TD>
						<TD align="center">
							<HR width="100%" SIZE="1">
						</TD>
					</TR>
					<TR>
						<TD style="vAlign: 'top'" align="left">&nbsp;
						</TD>
						<TD style="vAlign: 'top'" align="left">
							<HR noShade SIZE="1">
							<iewc:tabstrip id="TabStrip1" runat="server" TabSelectedStyle="background-color:#ffffff;color:#000000;border-style:inset;"
								TabHoverStyle="background-color:#777777;border-style:inset;border-width:1;" TabDefaultStyle="background-color:darkgray;font-family:verdana;font-weight:bold;font-size:8pt;color:#ffffff;width:79;height:21;text-align:center;border-style:outset;border-width:1;"
								Width="80%">
								<iewc:Tab Text="Dati Apparecchiatura"></iewc:Tab>
								<iewc:Tab Text="Documenti Allegati"></iewc:Tab>
							</iewc:tabstrip>
						</TD>
					</TR>
					<TR>
						<TD width="5%"></TD>
						<TD>
							<asp:panel id="PanelEditAnag" runat="server" Width="100%">
								<TABLE id="tblSearch100" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD align="center" width="40%" colSpan="3"><B>Dati&nbsp;Apparecchiatura</B></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 15px">Codice Edificio:
											<cc1:s_label id="S_Lblcodedificio" runat="server"></cc1:s_label>
											<cc1:s_label id="lblCodApparecchiatura" runat="server"></cc1:s_label></TD>
									</TR>
									<TR>
										<TD>
											<TABLE id="TableSearch100" cellSpacing="1" cellPadding="1" width="100%" border="1">
											<TR>
											<TD style="WIDTH: 168px">Codice Apparechiatura:</TD>
											<TD><asp:TextBox ID="txtApparechiatura" Runat="server" Width="168px" MaxLength="50"></asp:TextBox>
												<INPUT type="radio" name="Opt" id="Radio1" runat="server" onclick="JAVASCRIPT:Nascondi();"
													VALUE="Mano" checked>Inserimento manuale <INPUT type="radio" name="Opt" id="opt1" runat="server" onclick="JAVASCRIPT:Nascondi();"
													VALUE="Auto">Inserimento automatico
											</TD>
										</TR>											
												<TR>
													<TD style="WIDTH: 168px">Servizio:</TD>
													<TD>
														<cc1:s_label id="lblServizioDescription" runat="server"></cc1:s_label></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 168px">Standard Apparecchiature:</TD>
													<TD>
														<cc1:s_combobox id="cmbsApparecchiatura" runat="server" Width="392px"></cc1:s_combobox>
														<asp:requiredfieldvalidator id="RQApparecchiatura" runat="server" ControlToValidate="cmbsApparecchiatura" Display="Dynamic"
															ErrorMessage="Selezionare l'apparecchiatura">*</asp:requiredfieldvalidator></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 168px">Data di Inizio Validità:</TD>
													<TD>
														<TABLE id="Table2" style="WIDTH: 544px; HEIGHT: 49px" cellSpacing="1" cellPadding="1" width="544"
															border="0">
															<TR>
																<TD>
																	<uc1:calendarpicker id="CalendarPicker1" runat="server"></uc1:calendarpicker></TD>
																<TD>Data di Fine Validità:</TD>
																<TD>
																	<uc1:calendarpicker id="CalendarPicker2" runat="server"></uc1:calendarpicker></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 168px">QTA:</TD>
													<TD width="100%">
														<table width="100%" border="0">
														<tr>														
															<td  align="right">Unità di Misura: </td>
															<td>
															<cc1:s_combobox id="cmbsUnita" runat="server" ></cc1:s_combobox>															
															<cc1:s_textbox id="S_TxtqtaMatInt" runat="server" Width="65px" Maxlength="8"></cc1:s_textbox>							
															, <cc1:s_textbox id="S_TxtqtaMatDec" runat="server" Width="50px" Maxlength="5"></cc1:s_textbox>
															</td>
															<td>
															<asp:regularexpressionvalidator id="RegularExpressionValidator2" ControlToValidate="S_TxtqtaMatInt" ErrorMessage="*Il campo è numerico!"
															ValidationExpression="^[0-9]*$" Runat="server"></asp:regularexpressionvalidator>
															<asp:regularexpressionvalidator id="RegularExpressionValidator3" ControlToValidate="S_TxtqtaMatDec" ErrorMessage="*Il campo è numerico!"
															ValidationExpression="^[0-9]*$" Runat="server">*</asp:regularexpressionvalidator>
															</td>
																<td style="VISIBILITY: hidden">
															<cc1:s_textbox id="S_Txtqta" runat="server" Width="30px"></cc1:s_textbox>
														<asp:regularexpressionvalidator id="RegularExpressionValidator1" ControlToValidate="S_Txtqta" ErrorMessage="Il campo QTA è numerico!"
															ValidationExpression="^[0-9]*$" Runat="server">*</asp:regularexpressionvalidator>
															</td>
														</tr>
														</table>
														
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 168px; HEIGHT: 22px">Condizione:</TD>
													<TD style="HEIGHT: 22px">
														<cc1:s_combobox id="cmbsCondizione" runat="server" Width="392px"></cc1:s_combobox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 168px; HEIGHT: 22px">Piano:</TD>
													<TD style="HEIGHT: 22px">
														<cc1:s_combobox id="cmbsPiano" runat="server" Width="392px" AutoPostBack="True"></cc1:s_combobox>
														<asp:requiredfieldvalidator id="RQCondizione" runat="server" ControlToValidate="cmbsPiano" Display="Dynamic"
															ErrorMessage="Selezionare il Piano">*</asp:requiredfieldvalidator></TD>
												</TR>
												<TR>
													<TD colspan=2><uc1:UserStanze id="UserStanze1" runat="server"></uc1:UserStanze></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 168px; HEIGHT: 22px">Macro Componente:</TD>
													<TD style="HEIGHT: 22px">
														<cc1:s_combobox id="cmbsMacro" runat="server" Width="392px"></cc1:s_combobox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 168px; HEIGHT: 15px">Fornitore:</TD>
													<TD style="HEIGHT: 15px">
														<cc1:s_combobox id="cmbsvenditore" runat="server" Width="392px"></cc1:s_combobox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 168px">Modello:</TD>
													<TD>
														<cc1:s_textbox id="S_Txtmodello" runat="server" Width="392px"></cc1:s_textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 168px">Tipo:</TD>
													<TD>
														<cc1:s_textbox id="S_Txttipo" runat="server" Width="392px"></cc1:s_textbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 168px">Dismesso:</TD>
													<TD>
														<cc1:s_checkbox id="ChekDismesso" runat="server"></cc1:s_checkbox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 168px">Immagine Allegata:</TD>
													<TD><INPUT id="Uploader" style="WIDTH: 392px; HEIGHT: 18px" type="file" size="46" name="File1"
															runat="server"></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 168px">Riferimento Planimetria:</TD>
													<TD>
														<cc1:s_textbox id="S_TxtRif" runat="server" Width="80px"></cc1:s_textbox>
														
													</TD>
													
												</TR>
											<TR style="VISIBILITY: hidden">							
												<td  style="PADDING-RIGHT: 1px" >Apparecchiatura <br>soggetta a <br>lettura: </td>
												<td style="PADDING-RIGHT: 15px"><asp:CheckBox id="Contatore" runat="server"></asp:CheckBox></td>
											</tr>
											<tr  style="VISIBILITY: hidden">
												<td style=" PADDING-RIGHT: 1px">Unità di misura: </td>
												<td><cc1:s_combobox id="cmbsUDM" runat="server"></cc1:s_combobox></td>
											</tr>
											<tr  style="VISIBILITY: hidden">
												<td style=" PADDING-RIGHT: 1px">Ente Erogante: </td>
												<td><cc1:s_combobox id="cmbEnteErogante" runat="server"></cc1:s_combobox></td>
											</tr>
												<tr>
													<TD colspan=2>
														<asp:validationsummary id="ValidationSummary1" runat="server" Width="488px" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary>
														<cc1:s_label id="S_Lblerror" runat="server" Width="488px" ForeColor="Red"></cc1:s_label></TD>
												</TR>
												
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</asp:panel>
							<asp:panel id="PanelEditDocumenti" runat="server" Width="100%">
								<TABLE class="tblFormInputDettaglio" id="Table4" cellSpacing="1" cellPadding="1" width="100%"
									align="center" border="0">
									<TR>
										<TD align="center" width="40%" colSpan="3"><B>Associazioni&nbsp;Documenti
												<MESSPANEL:MESSAGEPANEL id="PanelMess" runat="server" Width="136px" ErrorIconUrl="~/Images/ico_critical.gif"
													MessageIconUrl="~/Images/ico_info.gif"></MESSPANEL:MESSAGEPANEL></B></TD>
									</TR>
									<TR>
										<TD align="left">
											<asp:linkbutton id="lkbNuovo" runat="server">Nuovo</asp:linkbutton></TD>
										<TD style="WIDTH: 321px" align="center"><INPUT id="HiddenEq" type="hidden" size="1" name="HiddenPianiStanze" runat="server"></TD>
										<TD align="left">Record:
											<asp:label id="lblRecord" runat="server">0</asp:label></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="3"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 2.98%" vAlign="top" align="left">&nbsp;</TD>
										<TD style="HEIGHT: 2.98%" vAlign="top" align="left">&nbsp;
											<asp:datagrid id="DataGridEsegui" runat="server" CssClass="DataGrid" DataKeyField="ID" BorderColor="Gray"
												BorderWidth="1px" GridLines="Vertical" AutoGenerateColumns="False">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
													<asp:TemplateColumn>
														<ItemStyle Wrap="False"></ItemStyle>
														<ItemTemplate>
															<asp:ImageButton id="imbEdit" runat="server" CommandName="Edit" ImageUrl="../Images/edit.gif" BorderStyle="None"></asp:ImageButton>
															<asp:ImageButton id="imbDelete" runat="server" CommandName="Delete" ImageUrl="../Images/elimina.gif"
																BorderStyle="None"></asp:ImageButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn>
														<ItemStyle Wrap="False"></ItemStyle>
														<EditItemTemplate>
															<asp:ImageButton id="imbUpdate" runat="server" CommandName="Update" ImageUrl="../Images/salva.gif"
																BorderStyle="None"></asp:ImageButton>
															<asp:ImageButton id="imbCancel" runat="server" CommandName="Cancel" ImageUrl="../Images/annulla.gif"
																BorderStyle="None"></asp:ImageButton>
														</EditItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn>
														<FooterStyle Wrap="False"></FooterStyle>
														<FooterTemplate>
															<asp:ImageButton id="Imagebutton1" runat="server" CommandName="Insert" ImageUrl="../Images/salva.gif"
																BorderStyle="None"></asp:ImageButton>
															<asp:ImageButton id="Imagebutton2" runat="server" CommandName="Cancel" ImageUrl="../Images/annulla.gif"
																BorderStyle="None"></asp:ImageButton>
														</FooterTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Descrizione File">
														<HeaderStyle Width="50%"></HeaderStyle>
														<ItemTemplate>
															<asp:Label id=lblDescrizione runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Descrizione") %>'>
															</asp:Label>
														</ItemTemplate>
														<FooterTemplate>
															<CC1:S_TEXTBOX id="ddldescrizioneNew" tabIndex="3" runat="server" Width="264px" DBDirection="Input"
																MaxLength="400" DBSize="8"></CC1:S_TEXTBOX>
														</FooterTemplate>
														<EditItemTemplate>
															<CC1:S_TEXTBOX id=ddldescrizione tabIndex=3 runat="server" Width="264px" DBDirection="Input" Text='<%# DataBinder.Eval(Container.DataItem, "Descrizione") %>' MaxLength="400" DBSize="8" DBParameterName="@Descrizione">
															</CC1:S_TEXTBOX>
														</EditItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Allega File">
														<HeaderStyle Width="50%"></HeaderStyle>
														<ItemTemplate>
															<asp:HyperLink id="hlink" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NOMEFILE") %>' NavigateUrl=<%# "javascript:openallegati("+ "'" + DataBinder.Eval(Container.DataItem, "nomefile") + "'" + " );"%> >
																</asp:HyperLink> 
														</ItemTemplate>
														<FooterTemplate>
															<input id="Upload" type=file runat="server">
															
														</FooterTemplate>
													</asp:TemplateColumn>
												</Columns>
											</asp:datagrid></TD>
									</TR>
								</TABLE>
							</asp:panel>
							<TABLE id="Table3" style="WIDTH: 416px; HEIGHT: 42px" cellSpacing="1" cellPadding="1" width="416"
								border="0">
								<TR>
									<TD><cc1:s_button id="S_BtInvia" runat="server" Width="128px" CssClass="btn" Text="Salva"></cc1:s_button>&nbsp;
										<cc1:s_button id="S_btannulla" runat="server" Width="128px" CssClass="btn" Text="Indietro" CausesValidation="False"></cc1:s_button></TD>
									<TD><INPUT class="btn" id="S_BtDatiTecnici" style="WIDTH: 128px" type="button"
											value="Dati Tecnici" runat="server"></TD>
											<td><cc1:s_button id="BtnNuovo" runat="server" Width="128px" CssClass="btn" Text="Nuovo" CausesValidation="False"></cc1:s_button></td>
								</TR>
							</TABLE>
							<INPUT id="Hidden_idservizio" type="hidden" runat="server"><INPUT id="Hidden_codiceservizio" type="hidden" runat="server">
						</TD>
					</TR>
					<TR>
						<TD></TD>
						<TD width="95%" colSpan="1" rowSpan="1">
							<HR width="100%" SIZE="1">
							<cc1:s_label id="lblFirstAndLast" runat="server"></cc1:s_label></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD width="95%">
							<% if(Imagename!=string.Empty){%>
							<IMG src="../AnagrafeImpianti/PageImage.aspx?<%=Imagename%>&amp;p=y" align=right border=0 >
							<%}%>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
