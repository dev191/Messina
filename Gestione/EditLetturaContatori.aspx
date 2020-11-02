<%@ Register TagPrefix="uc1" TagName="Addetti" Src="../WebControls/Addetti.ascx" %>
<%@ Page language="c#" Codebehind="EditLetturaContatori.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditLetturaContatori" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Lettura Contatori</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
		
		function ClearApparechiature()
		{
			var ctrltxtapp=document.getElementById('<%=CodiceApparecchiature1.s_CodiceApparecchiatura.ClientID%>');
			if(ctrltxtapp!=null && ctrltxtapp!='undefined')
			{
				ctrltxtapp.value="";
				document.getElementById('<%=CodiceApparecchiature1.CodiceHidden.ClientID%>').value="";
			}
		
		}
			
				
		function SoloNumeri()
		{	
			if (event.keyCode < 48	|| event.keyCode > 57)
			{
				event.keyCode = 0;
			}	
		}
		
		function ControllaOra()
		{
			var ora=parseInt(document.getElementById("<%=txtsorain.ClientID%>").value);
				if (ora=="")
						document.getElementById("<%=txtsorain.ClientID%>").value="00"
				if(ora<0 || ora>23)
				{ 

					alert("Attenzione l'ora deve essere compresa tra 00 e 23");		
					document.getElementById("<%=txtsorain.ClientID%>").focus()
					return false;
				}	
				else
				return true;
		}
		function ControllaMin()
		{
			var minuti=parseInt(document.getElementById("<%=txtsorainmin.ClientID%>").value);
				if (minuti=="")
						document.getElementById("<%=txtsorainmin.ClientID%>").value="00"
				
				if(minuti<0 || minuti>59)
				{
					alert("Attenzione i minuti devono essere compresi tra 00 e 59");		
					document.getElementById("<%=txtsorainmin.ClientID%>").focus();
					return false;
				}
				else
				return true;
				
			
		}
		
		function formatNum(obj)

{
	val=document.getElementById(obj).value;
	if(val=="")
		document.getElementById(obj).value="00";
	//if(val.length==1)	
	//	document.getElementById(obj).value=val+"0";
}
		</SCRIPT>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="center"><UC1:PAGETITLE id="PageTitle1" runat="server"></UC1:PAGETITLE></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left"><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" allowtitleexpandcollapse="True" collapseimageurl="../Images/up.gif"
							cssclass="DataPanel75" collapsetext="Espandi/Riduci" expandimageurl="../Images/down.gif" expandtext="Espandi" titletext="Filtra Apparecchiatura"
							collapsed="False" titlestyle-cssclass="TitleSearch" DESIGNTIMEDRAGDROP="15">
							<TABLE id="tblSearch10" cellSpacing="1" cellPadding="1" border="0">
								<TR>
									<TD vAlign="top" align="center" colSpan="4">
										<P>
											<UC1:RICERCAMODULO id="RicercaModulo1" runat="server"></UC1:RICERCAMODULO></P>
									</TD>
								</TR>
								<TR style="DISPLAY: none">
									<TD style="WIDTH: 15%">Piano:</TD>
									<TD style="HEIGHT: 28px">
										<CC1:S_COMBOBOX id="cmbsPiano" runat="server" width="200px" autopostback="True"></CC1:S_COMBOBOX></TD>
									<TD>Stanza:</TD>
									<TD>
										<CC1:S_COMBOBOX id="cmbsStanza" runat="server" width="200px" dbdirection="Input"></CC1:S_COMBOBOX></TD>
								</TR>
								<TR>
									<TD><SPAN>Servizio: </SPAN>
									</TD>
									<TD>
										<CC1:S_COMBOBOX id="cmbsServizio" runat="server" width="392px" autopostback="True"></CC1:S_COMBOBOX></TD>
								</TR>
								<TR>
									<TD><SPAN>Std. Apparecchiatura:</SPAN>
									</TD>
									<TD>
										<CC1:S_COMBOBOX id="cmbsApparecchiatura" runat="server" width="392px"></CC1:S_COMBOBOX></TD>
								</TR>
							</TABLE>
						</COLLAPSE:DATAPANEL></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left"><COLLAPSE:DATAPANEL id="Datapanel1" runat="server" allowtitleexpandcollapse="True" collapseimageurl="../Images/up.gif"
							cssclass="DataPanel75" collapsetext="Espandi/Riduci" expandimageurl="../Images/down.gif" expandtext="Espandi" titletext="Salva Lettura"
							collapsed="False" titlestyle-cssclass="TitleSearch" DESIGNTIMEDRAGDROP="795">
							<TABLE id="tblSearch100" style="WIDTH: 100%; HEIGHT: 152px" cellSpacing="1" cellPadding="1"
								border="0">
								<TR>
									<TD colSpan="4">
										<UC1:CODICEAPPARECCHIATURE id="CodiceApparecchiature1" runat="server"></UC1:CODICEAPPARECCHIATURE></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 44px">Data Ora Lettura</TD>
									<TD style="HEIGHT: 44px">
										<uc1:CalendarPicker id="CalendarPicker1" runat="server"></uc1:CalendarPicker>
										<asp:RequiredFieldValidator id="RfvData" runat="server" ErrorMessage="Selezionare La DataLettura">*</asp:RequiredFieldValidator>
										<asp:TextBox id="txtsorain" runat="server" Width="30px">00</asp:TextBox>:
										<asp:TextBox id="txtsorainmin" runat="server" Width="30px">00</asp:TextBox></TD>
									<TD style="HEIGHT: 44px">Valore Lettura</TD>
									<TD style="HEIGHT: 44px">
										<cc1:S_TextBox id="TxtValoreLetturaInt" tabIndex="6" runat="server" DBDirection="Input" DBSize="20"
											DBParameterName="p_telefono" DBIndex="5" DBDataType="VarChar">0</cc1:S_TextBox>,
										<cc1:S_TextBox id="TxtValoreLetturaDec" tabIndex="6" runat="server" Width="32px" DBDirection="Input"
											DBSize="3" DBParameterName="p_telefono" DBIndex="5" DBDataType="VarChar" MaxLength="3">000</cc1:S_TextBox></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 27px">Addetto</TD>
									<TD style="HEIGHT: 27px">
										<uc1:Addetti id="Addetti1" runat="server"></uc1:Addetti>
										<asp:RequiredFieldValidator id="RFVAddetto" runat="server" ErrorMessage="Selezionare un addetto">*</asp:RequiredFieldValidator></TD>
									<TD style="HEIGHT: 27px">Energia</TD>
									<TD style="HEIGHT: 27px">
										<CC1:S_COMBOBOX id="CmbsEnergia" runat="server" width="200px" dbdirection="Input">
											<asp:ListItem Value="--Seleziona Energia--">--Seleziona Energia--</asp:ListItem>
											<asp:ListItem Value="Erogata">Erogata</asp:ListItem>
											<asp:ListItem Value="Utilizzata">Utilizzata</asp:ListItem>
										</CC1:S_COMBOBOX>
										<asp:RequiredFieldValidator id="RfvEnergia" runat="server" ErrorMessage="Selezionare un energia" InitialValue="-1"
											ControlToValidate="CmbsEnergia">*</asp:RequiredFieldValidator></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 55px">Nota</TD>
									<TD style="HEIGHT: 55px" colSpan="3">
										<cc1:S_TextBox id="TxtNota" tabIndex="6" runat="server" Width="456px" DBDirection="Input" DBSize="20"
											DBIndex="5" DBDataType="VarChar" Height="56px" TextMode="MultiLine"></cc1:S_TextBox></TD>
								</TR>
								<TR>
									<TD>
										<P>
											<CC1:S_BUTTON id="BtnSalva" runat="server" cssclass="btn" width="130px" text="Salva" tooltip="Salva Lettura"></CC1:S_BUTTON></P>
									</TD>
									<TD colSpan="3">
										<CC1:S_BUTTON id="BtnElimina" runat="server" cssclass="btn" width="130px" text="Elimina" CausesValidation="False"></CC1:S_BUTTON>
										<CC1:S_BUTTON id="BtnAnnulla" runat="server" cssclass="btn" width="130px" text="Annula" tooltip="Torna alla pagina di ricerca"
											CausesValidation="False"></CC1:S_BUTTON>
										<cc1:S_TextBox id="itemId" tabIndex="6" runat="server" Width="0px" DBDirection="Input" DBSize="20"
											DBParameterName="p_telefono" DBIndex="5" DBDataType="VarChar" Height="0px"></cc1:S_TextBox></TD>
								</TR>
							</TABLE>
						</COLLAPSE:DATAPANEL></TD>
				</TR>
			</TABLE>
			<asp:ValidationSummary id="ValidationSummary1" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 376px"
				runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></FORM>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
