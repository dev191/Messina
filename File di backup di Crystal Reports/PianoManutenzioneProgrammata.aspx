<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Page language="c#" Codebehind="PianoManutenzioneProgrammata.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.PianoManutenzioneProgrammata" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>PianoManutenzioneProgrammata</TITLE>
		<META name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<META name="CODE_LANGUAGE" content="C#">
		<META name="vs_defaultClientScript" content="JavaScript">
		<META name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<FORM id="Form1" method="post" runat="server">
			<TABLE width="100%">
				<TR>
					<TD>
						<UC1:PAGETITLE id="PageTitle1" runat="server"></UC1:PAGETITLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE width="100%">
							<TR>
								<TD>
									<CC2:DATAPANEL id="DataPanelRicerca" runat="server" titlestyle-cssclass="TitleSearch" collapsed="False"
										titletext="" expandtext="" expandimageurl="../Images/down.gif" collapsetext="Riduci" cssclass="DataPanel75"
										collapseimageurl="../Images/up.gif" allowtitleexpandcollapse="false">
										<TABLE width="100%">
											<TR>
												<TD align="left">
													<ASP:LABEL id="lblAnno" runat="server">Anno:</ASP:LABEL></TD>
												<TD align="left" colSpan="3">
													<ASP:TEXTBOX id="txtAnno" runat="server" width="40px"></ASP:TEXTBOX>
													<ASP:REQUIREDFIELDVALIDATOR id="RequiredFieldValidator1" runat="server" errormessage="L'anno è obbligatorio"
														controltovalidate="txtAnno">*</ASP:REQUIREDFIELDVALIDATOR>&nbsp;
													<ASP:REGULAREXPRESSIONVALIDATOR id="RegularExpressionValidator1" runat="server" errormessage="Inserire un Anno valido, esempio 2008"
														controltovalidate="txtAnno" validationexpression="\d\d\d\d">*</ASP:REGULAREXPRESSIONVALIDATOR>
													<ASP:LABEL id="lblmese" runat="server"> Mese:</ASP:LABEL>&nbsp;
													<ASP:DROPDOWNLIST id="drpMese" runat="server" width="72px">
														<ASP:LISTITEM value="1">Gennaio</ASP:LISTITEM>
														<ASP:LISTITEM value="2">Febbraio</ASP:LISTITEM>
														<ASP:LISTITEM value="3">Marzo</ASP:LISTITEM>
														<ASP:LISTITEM value="4">Aprile</ASP:LISTITEM>
														<ASP:LISTITEM value="5">Maggio</ASP:LISTITEM>
														<ASP:LISTITEM value="6">Giugno</ASP:LISTITEM>
														<ASP:LISTITEM value="7">Luglio</ASP:LISTITEM>
														<ASP:LISTITEM value="8">Agosto</ASP:LISTITEM>
														<ASP:LISTITEM value="9">Settembre</ASP:LISTITEM>
														<ASP:LISTITEM value="10">Ottobre</ASP:LISTITEM>
														<ASP:LISTITEM value="11">Novembre</ASP:LISTITEM>
														<ASP:LISTITEM value="12">Dicembre</ASP:LISTITEM>
														<ASP:LISTITEM></ASP:LISTITEM>
													</ASP:DROPDOWNLIST></TD>
											</TR>
											<TR>
												<TD>
													<ASP:LABEL id="lblEdificio" runat="server">Edificio: </ASP:LABEL></TD>
												<TD colSpan="3">
													<ASP:DROPDOWNLIST id="drpEdificio" runat="server"></ASP:DROPDOWNLIST></TD>
											</TR>
											<TR>
												<TD>
													<ASP:LABEL id="lnlCategoriaTecnologica" runat="server">Categoria Tenologica: </ASP:LABEL></TD>
												<TD colSpan="3">
													<ASP:DROPDOWNLIST id="drpCategoriaTecnologica" runat="server"></ASP:DROPDOWNLIST></TD>
											</TR>
											<TR>
												<TD>
													<ASP:LABEL id="lblClasseElemento" runat="server">Classe Elemento: </ASP:LABEL></TD>
												<TD colSpan="3">
													<ASP:DROPDOWNLIST id="drpClasseElemento" runat="server"></ASP:DROPDOWNLIST></TD>
											</TR>
											<TR>
												<TD colSpan="4">
													<ASP:BUTTON id="btnGenera" runat="server" cssclass="btn" text="Genera"></ASP:BUTTON></TD>
											</TR>
										</TABLE>
										<ASP:VALIDATIONSUMMARY id="ValidationSummary1" runat="server"></ASP:VALIDATIONSUMMARY>
									</CC2:DATAPANEL>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
