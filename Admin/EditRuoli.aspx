<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Page language="c#" Codebehind="EditRuoli.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Admin.EditRuoli" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>EditRuoli</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottommargin="0" leftmargin="5" topmargin="0" rightmargin="0" ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><UC1:PAGETITLE id="PageTitle1" title="Gestione Ruoli" runat="server"></UC1:PAGETITLE></TD>
				</TR>
				<TR>
					<TD valign="top" align="center" height="95%">
						<TABLE id="tblFormInput" cellspacing="1" cellpadding="1" align="center">
							<TR>
								<TD style="WIDTH: 5%; HEIGHT: 5%" valign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" valign="top" align="left"><ASP:LABEL id="lblOperazione" runat="server" cssclass="TitleOperazione"></ASP:LABEL>&nbsp;<MESSPANEL:MESSAGEPANEL id="PanelMess" runat="server" messageiconurl="~/Images/ico_info.gif" erroriconurl="~/Images/ico_critical.gif"></MESSPANEL:MESSAGEPANEL></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1%" valign="top" align="left"></TD>
								<TD style="HEIGHT: 1%" valign="top" align="left">
									<HR noshade size="1">
								</TD>
							</TR>
							<TR>
								<TD valign="top" align="center"></TD>
								<TD valign="top" align="left"><ASP:PANEL id="PanelEdit" runat="server">
										<TABLE id="tblSearch75" cellSpacing="1" cellPadding="2" border="0">
											<TR>
												<TD align="center" colSpan="4"></TD>
											</TR>
											<TR>
												<TD align="right" width="20%">
													<ASP:REQUIREDFIELDVALIDATOR id="rfvDescrizione" runat="server" controltovalidate="txtsDescrizione" errormessage="Inserire la descrizione Ruolo">*</ASP:REQUIREDFIELDVALIDATOR>Ruolo</TD>
												<TD width="30%">
													<CC1:S_TEXTBOX id="txtsDescrizione" runat="server" maxlength="128" dbparametername="p_Descrizione"
														dbdirection="Input" width="95%" dbsize="50"></CC1:S_TEXTBOX></TD>
												<TD align="right" width="20%"></TD>
												<TD width="30%"></TD>
											</TR>
											<TR>
												<TD align="right">Note</TD>
												<TD colSpan="3">
													<CC1:S_TEXTBOX id="txtsNote" tabIndex="1" runat="server" maxlength="255" dbparametername="p_Note"
														width="95%" dbsize="50" dbindex="1"></CC1:S_TEXTBOX></TD>
											</TR>
											<TR>
												<TD align="right">Ditta</TD>
												<TD colSpan="3">
													<CC1:S_COMBOBOX id="cmbsDitta" tabIndex="2" runat="server" dbparametername="p_Ditta_Id" width="75%"
														dbindex="2" dbdatatype="Integer"></CC1:S_COMBOBOX></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="4">&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
										</TABLE>
									</ASP:PANEL></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 4.33%" valign="top" align="left"></TD>
								<TD style="HEIGHT: 4.33%" valign="top" align="left"><CC1:S_BUTTON id="btnsSalva" tabindex="3" runat="server" cssclass="btn" text="Salva"></CC1:S_BUTTON>&nbsp;
									<CC1:S_BUTTON id="btnsElimina" tabindex="4" runat="server" cssclass="btn" text="Elimina" causesvalidation="False"
										commandtype="Delete"></CC1:S_BUTTON>&nbsp;
									<ASP:BUTTON id="btnAnnulla" tabindex="5" runat="server" cssclass="btn" text="Annulla" causesvalidation="False"></ASP:BUTTON>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<CC1:S_COMBOBOX id="cmbCopiaruolo" tabIndex="2" runat="server" dbparametername="p_Ditta_Id" dbindex="2"
										dbdatatype="Integer"></CC1:S_COMBOBOX>
									<CC1:S_BUTTON id="btnCopiaRuolo" tabIndex="3" runat="server" cssclass="btn" text="Copia da Ruolo"></CC1:S_BUTTON></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" valign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" valign="top" align="left">
									<TABLE id="tblGridTitle" cellspacing="1" cellpadding="1" border="0">
										<TR>
											<TD width="20%"><ASP:LINKBUTTON id="lkbNuovo" runat="server" cssclass="NuovoLink">Nuovo</ASP:LINKBUTTON></TD>
											<TD width="60%"></TD>
											<TD align="center" width="20%">Record:
												<ASP:LABEL id="lblRecord" runat="server">0</ASP:LABEL></TD>
										</TR>
									</TABLE>
									<ASP:DATAGRID id="DataGridEsegui" runat="server" cssclass="DataGrid" autogeneratecolumns="False"
										gridlines="Vertical" borderwidth="1px" bordercolor="Gray" datakeyfield="ID">
										<ALTERNATINGITEMSTYLE cssclass="DataGridAlternatingItemStyle"></ALTERNATINGITEMSTYLE>
										<ITEMSTYLE cssclass="DataGridItemStyle"></ITEMSTYLE>
										<HEADERSTYLE cssclass="DataGridHeaderStyle"></HEADERSTYLE>
										<COLUMNS>
											<ASP:BOUNDCOLUMN visible="False" datafield="ID" headertext="ID"></ASP:BOUNDCOLUMN>
											<ASP:TEMPLATECOLUMN>
												<ITEMSTYLE wrap="False"></ITEMSTYLE>
												<ITEMTEMPLATE>
													<ASP:IMAGEBUTTON id="imbEdit" runat="server" imageurl="../Images/edit.gif" commandname="Edit"></ASP:IMAGEBUTTON>
													<ASP:IMAGEBUTTON id="imbDelete" runat="server" imageurl="../Images/elimina.gif" commandname="Delete"></ASP:IMAGEBUTTON>
												</ITEMTEMPLATE>
											</ASP:TEMPLATECOLUMN>
											<ASP:TEMPLATECOLUMN>
												<ITEMSTYLE wrap="False"></ITEMSTYLE>
												<EDITITEMTEMPLATE>
													<ASP:IMAGEBUTTON id="imbUpdate" runat="server" commandname="Update" imageurl="../Images/salva.gif"></ASP:IMAGEBUTTON>
													<ASP:IMAGEBUTTON id="imbCancel" runat="server" commandname="Cancel" imageurl="../Images/annulla.gif"></ASP:IMAGEBUTTON>
												</EDITITEMTEMPLATE>
											</ASP:TEMPLATECOLUMN>
											<ASP:TEMPLATECOLUMN>
												<FOOTERSTYLE wrap="False"></FOOTERSTYLE>
												<FOOTERTEMPLATE>
													<ASP:IMAGEBUTTON id="Imagebutton1" runat="server" commandname="Insert" imageurl="../Images/salva.gif"></ASP:IMAGEBUTTON>
													<ASP:IMAGEBUTTON id="Imagebutton2" runat="server" commandname="Cancel" imageurl="../Images/annulla.gif"></ASP:IMAGEBUTTON>
												</FOOTERTEMPLATE>
											</ASP:TEMPLATECOLUMN>
											<ASP:TEMPLATECOLUMN headertext="Funzione">
												<HEADERSTYLE width="52%"></HEADERSTYLE>
												<ITEMSTYLE horizontalalign="Left"></ITEMSTYLE>
												<ITEMTEMPLATE>
													<asp:Label id="lblDescrizione" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DESCRIZIONE") %>'>
													</asp:Label>
												</ITEMTEMPLATE>
												<FOOTERTEMPLATE>
													<cc1:S_ComboBox id="ddlFunzioneNew" runat="server" DBDirection="Input" DBIndex="1" DBDataType="Integer" BParameterName="p_Funzione_Id" DataSource="<%#GetFunzioni()%>" DataTextField="DESCRIZIONE" DataValueField="ID">
													</cc1:S_ComboBox>
												</FOOTERTEMPLATE>
												<EDITITEMTEMPLATE>
													<cc1:S_ComboBox id="ddlFunzione" runat="server" DBDirection="Input" DBIndex="1" DBDataType="Integer" BParameterName="p_Funzione_Id" SelectedValue='<%# GetIndex(DataBinder.Eval(Container.DataItem, "FUNZIONE_ID").ToString()) %>' DataSource="<%#GetFunzioni()%>" DataTextField="DESCRIZIONE" DataValueField="ID">
													</cc1:S_ComboBox>
												</EDITITEMTEMPLATE>
											</ASP:TEMPLATECOLUMN>
											<ASP:TEMPLATECOLUMN headertext="Lettura">
												<HEADERSTYLE horizontalalign="Center" width="12%"></HEADERSTYLE>
												<ITEMSTYLE horizontalalign="Center"></ITEMSTYLE>
												<ITEMTEMPLATE>
													<asp:CheckBox id="ckbLettura" Runat="server" Enabled="False" Visible="True" Checked='<%# Convert.ToBoolean((decimal)DataBinder.Eval(Container.DataItem, "LETTURA")) %>'>
													</asp:CheckBox>
												</ITEMTEMPLATE>
												<FOOTERSTYLE horizontalalign="Center"></FOOTERSTYLE>
												<FOOTERTEMPLATE>
													<CC1:S_CHECKBOX id="ckbLetturaNew" runat="server" enabled="true" visible="True" checked='false'
														dbdirection="Input" bparametername="p_Lettura" dbindex="3" dbdatatype="Integer"></CC1:S_CHECKBOX>
												</FOOTERTEMPLATE>
												<EDITITEMTEMPLATE>
													<cc1:S_CheckBox id="ckbLetturaEdit" Runat="server" Enabled="true" Visible="True" Checked='<%# Convert.ToBoolean((decimal)DataBinder.Eval(Container.DataItem, "LETTURA")) %>' DBDirection="Input" BParameterName="p_Lettura" DBIndex="3" DBDataType="Integer">
													</cc1:S_CheckBox>
												</EDITITEMTEMPLATE>
											</ASP:TEMPLATECOLUMN>
											<ASP:TEMPLATECOLUMN headertext="Inserimento">
												<HEADERSTYLE horizontalalign="Center" width="12%"></HEADERSTYLE>
												<ITEMSTYLE horizontalalign="Center"></ITEMSTYLE>
												<ITEMTEMPLATE>
													<asp:CheckBox id="ckbInserimento" Runat="server" Enabled="False" Visible="True" Checked='<%# Convert.ToBoolean((decimal)DataBinder.Eval(Container.DataItem, "INSERIMENTO")) %>'>
													</asp:CheckBox>
												</ITEMTEMPLATE>
												<FOOTERSTYLE horizontalalign="Center"></FOOTERSTYLE>
												<FOOTERTEMPLATE>
													<CC1:S_CHECKBOX id="ckbInserimentoNew" runat="server" enabled="true" visible="True" checked='false'
														dbdirection="Input" bparametername="p_Lettura" dbindex="3" dbdatatype="Integer"></CC1:S_CHECKBOX>
												</FOOTERTEMPLATE>
												<EDITITEMTEMPLATE>
													<cc1:S_CheckBox id="ckbInserimentoEdit" Runat="server" Enabled="true" Visible="True" Checked='<%# Convert.ToBoolean((decimal)DataBinder.Eval(Container.DataItem, "INSERIMENTO")) %>' DBDirection="Input" BParameterName="p_Inserimento" DBIndex="4" DBDataType="Integer">
													</cc1:S_CheckBox>
												</EDITITEMTEMPLATE>
											</ASP:TEMPLATECOLUMN>
											<ASP:TEMPLATECOLUMN headertext="Modifica">
												<HEADERSTYLE horizontalalign="Center" width="12%"></HEADERSTYLE>
												<ITEMSTYLE horizontalalign="Center"></ITEMSTYLE>
												<ITEMTEMPLATE>
													<asp:CheckBox id="ckbModifica" Runat="server" Enabled="False" Visible="True" Checked='<%# Convert.ToBoolean((decimal)DataBinder.Eval(Container.DataItem, "MODIFICA")) %>'>
													</asp:CheckBox>
												</ITEMTEMPLATE>
												<FOOTERSTYLE horizontalalign="Center"></FOOTERSTYLE>
												<FOOTERTEMPLATE>
													<CC1:S_CHECKBOX id="ckbModificaNew" runat="server" enabled="true" visible="True" checked='false'
														dbdirection="Input" bparametername="p_Lettura" dbindex="3" dbdatatype="Integer"></CC1:S_CHECKBOX>
												</FOOTERTEMPLATE>
												<EDITITEMTEMPLATE>
													<cc1:S_CheckBox id="ckbModificaEdit" Runat="server" Enabled="true" Visible="True" Checked='<%# Convert.ToBoolean((decimal)DataBinder.Eval(Container.DataItem, "MODIFICA")) %>' DBDirection="Input" BParameterName="p_Modifica" DBIndex="5" DBDataType="Integer">
													</cc1:S_CheckBox>
												</EDITITEMTEMPLATE>
											</ASP:TEMPLATECOLUMN>
											<ASP:TEMPLATECOLUMN headertext="Cancellazione">
												<HEADERSTYLE horizontalalign="Center" width="12%"></HEADERSTYLE>
												<ITEMSTYLE horizontalalign="Center"></ITEMSTYLE>
												<ITEMTEMPLATE>
													<asp:CheckBox id="ckbCancellazione" Runat="server" Enabled="False" Visible="True" Checked='<%# Convert.ToBoolean((decimal)DataBinder.Eval(Container.DataItem, "CANCELLAZIONE")) %>'>
													</asp:CheckBox>
												</ITEMTEMPLATE>
												<FOOTERSTYLE horizontalalign="Center"></FOOTERSTYLE>
												<FOOTERTEMPLATE>
													<CC1:S_CHECKBOX id="ckbCancellazioneNew" runat="server" enabled="true" visible="True" checked='false'
														dbdirection="Input" bparametername="p_Lettura" dbindex="3" dbdatatype="Integer"></CC1:S_CHECKBOX>
												</FOOTERTEMPLATE>
												<EDITITEMTEMPLATE>
													<cc1:S_CheckBox id="ckbCancellazioneEdit" Runat="server" Enabled="true" Visible="True" Checked='<%# Convert.ToBoolean((decimal)DataBinder.Eval(Container.DataItem, "CANCELLAZIONE")) %>' DBDirection="Input" BParameterName="p_Cancellazione" DBIndex="6" DBDataType="Integer">
													</cc1:S_CheckBox>
												</EDITITEMTEMPLATE>
											</ASP:TEMPLATECOLUMN>
										</COLUMNS>
									</ASP:DATAGRID></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" valign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" valign="top" align="left"><ASP:LABEL id="lblMessage" runat="server"></ASP:LABEL></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" valign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" valign="top" align="left"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1%" valign="top" align="left"></TD>
								<TD style="HEIGHT: 1%" valign="top" align="left">
									<HR noshade size="1">
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" valign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" valign="top" align="left"><ASP:LABEL id="lblFirstAndLast" runat="server"></ASP:LABEL>&nbsp;
								</TD>
							</TR>
						</TABLE>
						<ASP:VALIDATIONSUMMARY id="vlsEdit" runat="server" showmessagebox="True" displaymode="List" showsummary="False"></ASP:VALIDATIONSUMMARY></TD>
				</TR>
			</TABLE>
		</FORM>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
