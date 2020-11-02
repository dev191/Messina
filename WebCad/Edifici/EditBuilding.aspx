<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Page language="c#" Codebehind="EditBuilding.aspx.cs" AutoEventWireup="false" Inherits="WebCad.Edifici.EditBuilding" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>EditBuilding</TITLE>
		<META content="False" name="vs_showGrid">
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../Js/CommonScript.js"></SCRIPT>
		<SCRIPT language="javascript">
		
		
		function SoloNumeriVirgola()
		{	
			if (!((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 44))
			{		
				event.keyCode = 0;		
			}
		}
	
			/*function SelezionaListBox()
			{
				
				var lst= document.getElementById("<%%>");=ListBoxRightP.ClientID
				if (lst.options.length>0)
				{
					if (lst.selectedIndex = -1)
					{
						lst.options[0].selected= true
					}	
				}	
					
				
			}*/
	
			function Messaggio() 
			{
				Abilita(3); 
				alert('Impossibile Eliminare il piano in quanto legato ad una apparecchiatura!'); 
			}
			function MessaggioPiani() 
			{
				Abilita(3); 
				alert('Impossibile Eliminare il piano in quanto associato ad una stanza!!'); 
			}
			
	
			function Abilita(val)
			{

				var pan4 = document.getElementById("<%=PanelEditPiani.ClientID%>");
				var pan5 = document.getElementById("<%=PanelEditStanze.ClientID%>");
				
				switch (val)
				{
					case 3: //Piani
						pan4.style.display='block';
						pan5.style.display='none';
						break;
					case 4: //Stanze
						pan4.style.display='none';
						pan5.style.display='block';
						break;
				}
			}
	
	function apri_ricerca_reparto(gruppo,descmat,id)
	{
		var	var1=document.getElementById(descmat).value;
		var W = window.open('../CommonPage/ListaReparto.aspx?utente=ALE&IdMat='+id+'&desc=' + var1 + '&IdTxt='+descmat+'&aa=richiesta_lavoro','vericacodice','width=600,height=400;status=yes')								
	}	
	
	function apri_ricerca_uso(gruppo,descmat,id)
	{
		var	var1=document.getElementById(descmat).value;
		var W = window.open('../CommonPage/ListaDestinazioneUso.aspx?utente=ALE&IdMat='+id+'&desc=' + var1 + '&IdTxt='+descmat+'&aa=richiesta_lavoro','vericacodice','width=600,height=400;status=yes')								
	}		
	
	function ControllaDati (categoria, reparto, destinazione)
	{
		var cat= document.getElementById(categoria).selectedIndex;
		var rep =document.getElementById(reparto).value;
		var dest=document.getElementById(destinazione).value;
		var messaggio="";
		
		if (cat == '0' )
			messaggio=" - Selezionare una Categoria \n";
		if (rep =="")
			messaggio+=" - Selezionare un Reparto \n";
		if (dest =="")
			messaggio+=" - Selezionare una Destinazione \n";
			
		if(dest  == ""  ||  rep  == "" ||  cat ==  '0')
		{
			alert (messaggio);
			return false;
		}
		else
			return true;
	}
		</SCRIPT>
	</HEAD>
	<body onload="Abilita(<%=TabId%>);">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD>&nbsp;</TD>
						<TD align="center"><UC1:PAGETITLE id="Pagetitle2" runat="server"></UC1:PAGETITLE></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 18px; vAlign: 'top'" align="left">&nbsp;
						</TD>
						<TD style="HEIGHT: 18px; vAlign: 'top'" align="left">
							<H4>Dettaglio delle stanze edificio:&nbsp;<%=edificio%>&nbsp;Piano:&nbsp;<%=piano%></H4>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">&nbsp;
						</TD>
						<TD vAlign="top" align="left"><ASP:PANEL id="PanelEditPiani" runat="server" width="100%">
								<TABLE class="tblFormInputDettaglio" id="TablePiani" cellSpacing="1" cellPadding="1" width="100%"
									align="center" border="0">
									<TR>
										<TD style="HEIGHT: 2.98%" vAlign="top" align="left">&nbsp;</TD>
										<TD style="HEIGHT: 2.98%" vAlign="top" align="left">&nbsp;
											<ASP:DATAGRID id="DataGridPiani" runat="server" cssclass="DataGrid" datakeyfield="ID" bordercolor="Gray"
												borderwidth="1px" gridlines="Vertical" autogeneratecolumns="False">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID">
														<HeaderStyle Width="1%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="2%"></HeaderStyle>
														<FooterStyle Wrap="False"></FooterStyle>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Piano">
														<HeaderStyle Width="30px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
														<ItemTemplate>
															<asp:Label id=Label3 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Descrizione") %>'>
															</asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Mq Lordi">
														<ItemTemplate>
															<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MQLORDI") %>' ID="Label2">
															</asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Mq Netti">
														<ItemTemplate>
															<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MQNETTI") %>' ID="Label4">
															</asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Mq Mura">
														<ItemTemplate>
															<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MQMURA") %>' ID="Label5">
															</asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
											</ASP:DATAGRID></TD>
									</TR>
								</TABLE>
							</ASP:PANEL><ASP:PANEL id="PanelEditStanze" runat="server" width="100%">
								<TABLE class="tblFormInputDettaglio" id="Table4" cellSpacing="1" cellPadding="1" width="100%"
									align="center" border="0">
									<TR>
										<TD style="WIDTH: 46px" align="left"></TD>
										<TD style="WIDTH: 585px" align="center"><INPUT id="HiddenPianiStanze" type="hidden" size="1" name="HiddenPianiStanze" runat="server"></TD>
										<TD align="left">Record:
											<ASP:LABEL id="lblRecord" runat="server">0</ASP:LABEL></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 585px; HEIGHT: 2.98%" vAlign="top" align="left" colSpan="3">&nbsp;
											<ASP:DATAGRID id="DataGridEsegui" runat="server" cssclass="DataGrid" datakeyfield="ID" bordercolor="Gray"
												borderwidth="1px" gridlines="Vertical" autogeneratecolumns="False" Width="95%">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID">
														<HeaderStyle Width="1%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn HeaderText="Piano">
														<HeaderStyle Width="30px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
														<ItemTemplate>
															<asp:Label id=lblDescrizionePiano runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DescrizionePiano") %>'>
															</asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Stanza">
														<ItemTemplate>
															<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Descrizione") %>'>
															</asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Descrizione Stanza">
														<ItemTemplate>
															<asp:Label id=lbldescrizione runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "descstanza") %>' Width="183px">
															</asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Mq">
														<ItemTemplate>
															<asp:Label id=LblMq runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MQ") %>' Width="71px">
															</asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Categoria">
														<ItemTemplate>
															<asp:Label id=lblDescCat runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "categoria") %>' Width="176px">
															</asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Reparto">
														<ItemTemplate>
															<asp:Label id=lblDescRep runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "reparto") %>' Width="176px">
															</asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Destinazione">
														<ItemTemplate>
															<asp:Label id=LblUso runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "destuso") %>' Width="176px">
															</asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
											</ASP:DATAGRID></TD>
									</TR>
								</TABLE>
							</ASP:PANEL></TD>
					</TR>
				</TBODY>
			</TABLE>
		</FORM>
	</body>
</HTML>
