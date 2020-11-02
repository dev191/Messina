<%@ Page language="c#" Codebehind="EditPrestazioniEnergetiche.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.EditPrestazioniEnergetiche" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc2" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListaApparecchiature</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		  function seledificio()
		  {
		    var ctrl=document.getElementById("hiddenblid");
		    if (ctrl!=null)
		    {
		       if (ctrl.value=="")
		       {
					alert("Selezionare un Edificio!");
					return false;
			   }else
			     {return true;}
		    }
		  }
		  
		</script>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="tblSearch100" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD><cc1:datapanel id="DataPanel1" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
										TitleText="Prestazioni Energetiche" ExpandText="Espandi" ExpandImageUrl="../Images/down.gif"
										CollapseText="Riduci" CssClass="DataPanel75" CollapseImageUrl="../Images/up.gif" AllowTitleExpandCollapse="True">
										<TABLE id="tblSearch100" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD><uc1:ricercamodulo id="RicercaModulo1" runat="server"></uc1:ricercamodulo>
													<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Selezionare un edificio">*</asp:RequiredFieldValidator></TD>
											</TR>
											<TR>
											</TR>
										</TABLE>
										<TABLE width="100%" border="0">
											<TBODY>
												<TR>
													<TD style="WIDTH: 72px; HEIGHT: 6px">Tipo prestazione:</TD>
													<TD><cc2:s_combobox id="cmbsTipPres" runat="server" DBDataType="Integer" DBDirection="Input" DBParameterName="p_ID_PRESTAZIONI_TIPO"
															DBSize="10" DBIndex="1" Width="200px"></cc2:s_combobox>
														<asp:RequiredFieldValidator id="RFVTipoPrest" runat="server" ErrorMessage="Selezionare Un tipo prestazione"
															ControlToValidate="cmbsTipPres" InitialValue="0">*</asp:RequiredFieldValidator></TD>
													<TD style="HEIGHT: 6px" colSpan="2"></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 72px">Descrizione:</TD>
													<TD colSpan="3"><cc2:s_textbox id="s_txtDesc" runat="server" DBDirection="Input" DBParameterName="P_DESCRIZIONE"
															DBSize="255" DBIndex="3" Width="384px" MaxLength="255" TextMode="MultiLine"></cc2:s_textbox><cc2:s_textbox id="s_txtID" runat="server" DBDataType="Integer" DBDirection="Input" DBParameterName="p_ID_PRESTAZIONI_ENERGETICHE"
															DBSize="10" DBIndex="0" Width="0px" MaxLength="10">0</cc2:s_textbox>
														<asp:RequiredFieldValidator id="RFVDescrizione" runat="server" ErrorMessage="Inserire una descrizione" ControlToValidate="s_txtDesc">*</asp:RequiredFieldValidator></TD>
												</TR>
												<TR>
													<TD colSpan="4"></TD>
												</TR>
												<TR>
													<TD colSpan="4"></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 72px"><cc2:s_button id="btSalva" runat="server" CssClass="btn" Width="80px" Text="Salva"></cc2:s_button></TD>
													<TD style="WIDTH: 330px"><cc2:s_button id="btnElimina" runat="server" CssClass="btn" Width="80px" Text="Elimina" CausesValidation="False"></cc2:s_button>
														<cc2:s_button id="BtnAnnulla" runat="server" CssClass="btn" Width="80px" Text="Annulla" CausesValidation="False"></cc2:s_button></TD>
													<TD style="WIDTH: 20px"></TD>
													<td align="right"></td>
												</TR>
											</TBODY>
										</TABLE></TD>
							</TR>
						</TABLE>
						<P>&nbsp;</P>
					</TD>
					</cc1:datapanel></TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
			<INPUT id="hiddenblid" type="hidden" name="hiddenblid" runat="server">
			<asp:ValidationSummary id="ValidationSummary1" style="Z-INDEX: 102; LEFT: 288px; POSITION: absolute; TOP: 312px"
				runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></TD></TR></TABLE></form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
