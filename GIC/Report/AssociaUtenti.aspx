<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="AssociaUtenti.aspx.cs" AutoEventWireup="false" Inherits="TheSite.GIC.Report.AssociaUtenti" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Utenti</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function SelCheckbox(){				
				for (i=0;i<document.all.length;i++)	{
					if (document.all(i).type == 'checkbox')	{
						if (document.getElementById("ChkSelTutti").checked==true){
							nome=document.all(i).id;	
							if (nome.substring(0,15)=='DataGridRicerca'){	
								if(document.all(i).disabled==false){
									document.all(i).checked=true;}
								}
							}			
						else
						{
							nome=document.all(i).id;	
							if (nome.substring(0,15)=='DataGridRicerca')
							{	
								if(document.all(i).disabled==false)
								{
									document.all(i).checked=false;
								}
							}
						}								
					}
				}
			}
		</script>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="0"
				cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" height="95%">
						<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
							<TR>
								<TD style="HEIGHT: 25%" vAlign="top" align="left">
									<Collapse:DataPanel id="PanelRicerca" runat="server" ExpandImageUrl="../../Images/down.gif" CollapseImageUrl="../../Images/up.gif"
										CollapseText="Riduci" ExpandText="Espandi" Collapsed="False" AllowTitleExpandCollapse="True" TitleText="Ricerca"
										CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch">
										<TABLE id="tblSearch100" cellSpacing="0" cellPadding="2" border="0">
											<TR>
												<TD align="right" width="20%">Utente</TD>
												<TD width="30%">
													<cc1:s_textbox id="txtsUserName" runat="server" DBSize="50" DBDirection="Input" DBParameterName="p_UserName"
														width="75%"></cc1:s_textbox></TD>
												<TD align="right" width="20%">Progetto</TD>
												<TD width="30%">
													<CC1:S_COMBOBOX id="CmbProgetto" tabIndex="8" runat="server" Width="176px" dbdatatype="Integer"
														dbparametername="p_progetto" dbdirection="Input" dbsize="1" dbindex="5"></CC1:S_COMBOBOX></TD>
											</TR>
											<TR>
												<TD align="right">Cognome</TD>
												<TD>
													<cc1:s_textbox id="txtsCognome" tabIndex="1" runat="server" DBSize="50" DBParameterName="p_Cognome"
														width="75%" DBIndex="1"></cc1:s_textbox></TD>
												<TD align="right">Nome</TD>
												<TD>
													<cc1:s_textbox id="txtsNome" tabIndex="2" runat="server" DBSize="50" DBParameterName="p_Nome" width="75%"
														DBIndex="2"></cc1:s_textbox></TD>
											</TR>
											<TR>
												<TD align="right">Email</TD>
												<TD>
													<cc1:s_textbox id="txtsEmail" tabIndex="3" runat="server" DBSize="255" DBDirection="Input" DBParameterName="p_Email"
														width="75%" DBIndex="3"></cc1:s_textbox></TD>
												<TD align="right">Telefono</TD>
												<TD>
													<cc1:s_textbox id="txtsTelefono" tabIndex="3" runat="server" DBSize="10" DBDirection="Input" DBParameterName="p_Telefono"
														width="75%" DBIndex="4"></cc1:s_textbox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 25px" align="left" colSpan="3">
													<cc1:s_button id="btnsRicerca" runat="server" CssClass="btn" Text="Ricerca"></cc1:s_button>
													<cc1:s_button id="btnsIndietro" runat="server" CssClass="btn" Width="88px" Text="Indietro"></cc1:s_button>&nbsp;
													<cc1:s_button id="btnsSalva" runat="server" CssClass="btn" Width="120px" Text="Salva"></cc1:s_button></TD>
												<TD style="HEIGHT: 25px" align="right"><A class=GuidaLink 
                  href="<%= HelpLink %>" 
            target=_blank>Guida</A></TD>
											</TR>
										</TABLE>
									</Collapse:DataPanel>
								</TD>
							</TR>
							<tr>
								<TD style="HEIGHT: 3%" align="center"></TD>
							</tr>
							<TR>
								<TD style="HEIGHT: 72%" vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle>
									<asp:DataGrid id="DataGridRicerca" runat="server" CssClass="DataGrid" BorderColor="Gray" BorderWidth="1px"
										GridLines="Vertical" AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
										<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="&lt;input id='ChkSelTutti' type='Checkbox' onclick='SelCheckbox()'&gt;">
												<HeaderStyle HorizontalAlign="Center" Width="3%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:CheckBox ID="ChkSel" Runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
											<asp:BoundColumn DataField="USERNAME" HeaderText="Utente">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="COGNOME" HeaderText="Cognome">
												<HeaderStyle Width="25%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NOME" HeaderText="Nome">
												<HeaderStyle Width="25%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PROGETTO" HeaderText="Progetto">
												<HeaderStyle Width="25%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IDSCHEMA" HeaderText="SCHEMA" Visible="False">
												<HeaderStyle Width="25%"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:DataGrid></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 138px" width="10%" align="center"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
