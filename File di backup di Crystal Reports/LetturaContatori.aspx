<%@ Page language="c#" Codebehind="LetturaContatori.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.LetturaContatori" %>
<%@ Register TagPrefix="uc1" TagName="UserStanze" Src="../WebControls/UserStanze.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>NavigazioneApparechiature</TITLE>
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
		
			function SelCheckbox()
			{
				for (i=0;i<document.all.length;i++)	
				{
					if (document.all(i).type == 'checkbox')	
					{
						if (document.getElementById("ChkSelTutti").checked==true)
						{
							nome=document.all(i).id;	
							if (nome.substring(0,11)=='MyDataGrid1')
							{	
								if(document.all(i).disabled==false)
								{
									document.all(i).checked=true;}
								}
							}			
						else
						{
							nome=document.all(i).id;	
							if (nome.substring(0,11)=='MyDataGrid1')
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
							cssclass="DataPanel75" collapsetext="Espandi/Riduci" expandimageurl="../Images/down.gif" expandtext="Espandi" titletext="Ricerca"
							collapsed="False" titlestyle-cssclass="TitleSearch">
							<TABLE id="tblSearch100" cellSpacing="1" cellPadding="1" border="0">
								<TR>
									<TD vAlign="top" align="center" colSpan="4">
										<P>
											<UC1:RICERCAMODULO id="RicercaModulo1" runat="server"></UC1:RICERCAMODULO></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%">Data Lettura Da:</TD>
									<TD style="HEIGHT: 28px">
										<uc1:CalendarPicker id="CalendarPicker1" runat="server"></uc1:CalendarPicker></TD>
									<TD>Data Lettura A:</TD>
									<TD>
										<uc1:CalendarPicker id="CalendarPicker2" runat="server"></uc1:CalendarPicker></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 15%">Piano:</TD>
									<TD style="HEIGHT: 28px">
										<CC1:S_COMBOBOX id="cmbsPiano" runat="server" width="200px"></CC1:S_COMBOBOX></TD>
									<TD colSpan="2">
										<uc1:UserStanze id="UserStanze1" runat="server"></uc1:UserStanze></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 2px"><SPAN>Servizio: </SPAN>
									</TD>
									<TD style="HEIGHT: 2px" colSpan="3">
										<CC1:S_COMBOBOX id="cmbsServizio" runat="server" width="392px" autopostback="True"></CC1:S_COMBOBOX></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 28px"><SPAN>Std. Apparecchiatura:</SPAN>
									</TD>
									<TD style="HEIGHT: 28px" colSpan="3">
										<CC1:S_COMBOBOX id="cmbsApparecchiatura" runat="server" width="392px"></CC1:S_COMBOBOX></TD>
								</TR>
								<TR>
									<TD colSpan="4">
										<UC1:CODICEAPPARECCHIATURE id="CodiceApparecchiature1" runat="server"></UC1:CODICEAPPARECCHIATURE></TD>
								</TR>
								<TR>
									<TD colSpan="4">&nbsp;
										<P></P>
										<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
											<TR>
												<TD align="left">
													<CC1:S_BUTTON id="S_btMostra" runat="server" cssclass="btn" width="130px" text="Ricerca" tooltip="Avvia la ricerca"></CC1:S_BUTTON>&nbsp;
													<ASP:BUTTON id="btnReset" runat="server" cssclass="btn" width="130px" text="Reset"></ASP:BUTTON></TD>
												<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</COLLAPSE:DATAPANEL></TD>
				</TR>
				<TR vAlign="top">
					<TD vAlign="top"><UC1:GRIDTITLE id="GridTitle1" runat="server"></UC1:GRIDTITLE><asp:datagrid id="DataGridLettura" runat="server" BorderColor="Gray" BorderStyle="None" BorderWidth="1px"
							BackColor="White" CellPadding="4" AutoGenerateColumns="False" AllowPaging="True" GridLines="Vertical" Width="100%" CssClass="DataGrid">
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton id=Imagebutton1 CommandName="Dettaglio" Runat="server" ImageUrl="../Images/edit.gif" CommandArgument='<%# "EditLetturaContatori.aspx?id_lettura=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId + "&TipoOper=write"%>'>
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<HeaderStyle Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton id=Imagebutton2 ImageUrl="../Images/elimina.gif" Runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID")%>' CommandName="Delete">
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="bl_id" HeaderText="Cod.Edificio"></asp:BoundColumn>
								<asp:BoundColumn DataField="eq_id" HeaderText="Cod. Apparecchiatura"></asp:BoundColumn>
								<asp:BoundColumn DataField="DESCRIZIONE" HeaderText="Std. Apparecchiatura"></asp:BoundColumn>
								<asp:BoundColumn DataField="Servizio" HeaderText="Servizio"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="id_eq" HeaderText="ideq"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="date_dismiss" HeaderText="Dismessa"></asp:BoundColumn>
								<asp:BoundColumn DataField="PianoStanza" HeaderText="Piano/Stanza"></asp:BoundColumn>
								<asp:BoundColumn DataField="NominativoAddetto" HeaderText="Addetto"></asp:BoundColumn>
								<asp:BoundColumn DataField="lettura" HeaderText="Energia/Valore Lettura"></asp:BoundColumn>
								<asp:BoundColumn DataField="datalettura" HeaderText="Data Lettura" DataFormatString="{0:d}"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="TblBtn">
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
