<%@ Page language="c#" Codebehind="EditMenu.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Admin.EditMenu" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>EditMenu</TITLE>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="center" height="50"><uc1:pagetitle id="PageTitle1" title="Gestione Menu" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" height="95%">
						<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" align="center">
							<TR>
								<TD style="WIDTH: 5%; HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" CssClass="TitleOperazione"></asp:label><MESSPANEL:MESSAGEPANEL id="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"></MESSPANEL:MESSAGEPANEL></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left"></TD>
								<TD vAlign="top" align="left">
									<hr noShade SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center"></TD>
								<TD vAlign="top" align="left"><asp:panel id="PanelEdit" runat="server">
										<TABLE id="tblSearch75" cellSpacing="1" cellPadding="2" border="0">
											<TR>
												<TD align="right" width="20%"></TD>
												<TD width="30%"></TD>
												<TD align="right" width="20%"></TD>
												<TD width="30%"></TD>
											</TR>
											<TR>
												<TD align="right">
													<asp:RequiredFieldValidator id="rfvDescrizione" runat="server" ErrorMessage="Inserire la descrizione Funzione"
														ControlToValidate="txtsDescrizione">*</asp:RequiredFieldValidator>Descrizione</TD>
												<TD colSpan="3">
													<cc1:s_textbox id="txtsDescrizione" runat="server" MaxLength="255" DBSize="255" width="95%" DBParameterName="p_Descrizione"
														DBIndex="0"></cc1:s_textbox></TD>
											</TR>
											<TR>
												<TD align="right">
													<asp:CompareValidator id="cmvFunzione" runat="server" ErrorMessage="Selezionare la Funzione" ControlToValidate="cmbsFunzione"
														ValueToCompare="0" Operator="GreaterThan" Type="Integer">*</asp:CompareValidator>Funzione</TD>
												<TD colSpan="3">
													<cc1:S_ComboBox id="cmbsFunzione" tabIndex="1" runat="server" DBParameterName="p_Funzione_Id" DBIndex="1"
														DBDataType="Integer" Width="95%"></cc1:S_ComboBox></TD>
											</TR>
											<TR>
												<TD align="right">Menu Padre</TD>
												<TD colSpan="3">
													<cc1:S_ComboBox id="cmbsMenuPadre" tabIndex="2" runat="server" DBParameterName="p_Menu_Padre_Id"
														DBIndex="8" DBDataType="Integer" Width="95%"></cc1:S_ComboBox></TD>
											</TR>
											<TR>
												<TD align="right">CssClass</TD>
												<TD>
													<cc1:s_textbox id="txtsCssClass" tabIndex="3" runat="server" MaxLength="128" DBSize="128" width="95%"
														DBParameterName="p_CssClass" DBIndex="2"></cc1:s_textbox></TD>
												<TD align="right">ToolTip</TD>
												<TD>
													<cc1:s_textbox id="txtsToolTip" tabIndex="4" runat="server" MaxLength="255" DBSize="255" width="95%"
														DBParameterName="p_ToolTip" DBIndex="3"></cc1:s_textbox></TD>
											</TR>
											<TR>
												<TD align="right">Image</TD>
												<TD>
													<cc1:s_textbox id="txtsImage" tabIndex="5" runat="server" MaxLength="255" DBSize="255" width="95%"
														DBParameterName="p_Image" DBIndex="4"></cc1:s_textbox></TD>
												<TD align="right">Target</TD>
												<TD>
													<cc1:s_textbox id="txtsTarget" tabIndex="6" runat="server" MaxLength="255" DBSize="255" width="95%"
														DBParameterName="p_Target" DBIndex="7"></cc1:s_textbox></TD>
											</TR>
											<TR>
												<TD align="right">
													<asp:RegularExpressionValidator id="rgeViewOrder" runat="server" ErrorMessage="L'ordine di visualizzazione deve essere un numero"
														ControlToValidate="txtsViewOrder" ValidationExpression="[0-9]*">*</asp:RegularExpressionValidator>Ordine&nbsp;Visualizz.
												</TD>
												<TD>
													<cc1:s_textbox id="txtsViewOrder" tabIndex="7" runat="server" MaxLength="100000" DBSize="0" width="100px"
														DBParameterName="p_ViewOrder" DBIndex="5" DBDataType="Integer"></cc1:s_textbox>
													<asp:LinkButton id="lkbInfo" runat="server" CssClass="LabelInfo" CausesValidation="False">info</asp:LinkButton>
													<asp:Panel id="pnlShowInfo" runat="server" CssClass="ShowInfoPanel" Visible="False">
														<TABLE height="100%" width="100%">
															<TR>
																<TD class="TitleSearch" vAlign="top" align="right" height="15">
																	<asp:LinkButton id="lnkChiudi" runat="server" CssClass="LabelChiudi" CausesValidation="False">Chiudi</asp:LinkButton></TD>
															</TR>
															<TR>
																<TD vAlign="top">
																	<asp:DataList id="dtlInfo" runat="server" Width="100%">
																		<HeaderTemplate>
																			<b>Ordini di stesso livello</b>
																		</HeaderTemplate>
																		<ItemTemplate>
																			<%# DataBinder.Eval(Container.DataItem, "VIEWORDER") %>
																			-
																			<%# DataBinder.Eval(Container.DataItem, "DESCRIZIONE") %>
																		</ItemTemplate>
																	</asp:DataList></TD>
															</TR>
														</TABLE>
													</asp:Panel></TD>
												<TD align="right">Valido</TD>
												<TD>
													<cc1:S_CheckBox id="ckbsValido" tabIndex="8" runat="server" DBParameterName="p_Enable" DBIndex="6"
														DBDataType="Integer"></cc1:S_CheckBox></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="4">&nbsp;&nbsp;&nbsp;
												</TD>
											</TR>
										</TABLE>
									</asp:panel></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left" style="HEIGHT: 23px"></TD>
								<TD vAlign="top" align="left" style="HEIGHT: 23px"><cc1:s_button id="btnsSalva" tabIndex="9" runat="server" Text="Salva" CssClass="btn"></cc1:s_button>&nbsp;
									<cc1:s_button id="btnsElimina" tabIndex="10" runat="server" Text="Elimina" CausesValidation="False"
										CommandType="Delete" CssClass="btn"></cc1:s_button>&nbsp;
									<asp:button id="btnAnnulla" tabIndex="11" runat="server" Text="Annulla" CausesValidation="False"
										CssClass="btn"></asp:button></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left"></TD>
								<TD vAlign="top" align="left">
									<hr noShade SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left"></TD>
								<TD vAlign="top" align="left"><asp:label id="lblFirstAndLast" runat="server"></asp:label>&nbsp;
								</TD>
							</TR>
						</TABLE>
						<asp:validationsummary id="vlsEdit" runat="server" ShowSummary="False" DisplayMode="List" ShowMessageBox="True"></asp:validationsummary></TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
