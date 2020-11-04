
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Page language="c#" Codebehind="Completamento_MP_WRList.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.Completamento_MP_WRList" %>
<%@ Register TagPrefix="uc1" TagName="UserOption" Src="../WebControls/UserOption.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Completamento MP WR_LIST</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function Disabilita(opt,txt)
			{	
				optchiusa= document.getElementById(opt + "_0");
				optsospesa=document.getElementById(opt + "_1");
				txtsospesa=document.getElementById(txt);
				
				if (optchiusa.checked==true)
				{				
					txtsospesa.disabled=true;
				}
				if (optsospesa.checked==true)
				{				
					txtsospesa.disabled=false;
				}				
			}
			
			
			function ControllaCaratteri(){
				if (event.keyCode < 48	|| event.keyCode > 57){
					event.keyCode = 0;
				}	
			}			
			
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
			
			
			
		function IsNumber(data)
		{
			var numeri="0123456789";
			var appoggio="";
			var contatore=0;
			for (var i=0; i<data.length; i++){
				appoggio=data.substring(i,i+1);
				if ((numeri.indexOf(appoggio))!=-1){
					contatore++;
				}
			}
			if (contatore==data.length){
				return true;
			}else{
				return false;
			}
		}					
		function ControllaData()
		{
			var datai=document.getElementById('CalendarPicker1_S_TxtDatecalendar').value; 
			if(datai=="")
			{
			 alert("Specificare la Data di Completamento/Sospensione.");
			 return false;
			}
			return true;
		}
		
		function refreshgriglia()
				{
					document.Form1.hidRicerca.value='1';					
					__doPostBack('hidRef','');
				}	
		
		</script>
	</HEAD>
	<body bottomMargin="0" onbeforeunload="chiudi();parent.left.valorizza()" leftMargin="5" topMargin="0" rightMargin="0"
		MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD>
							<TABLE id="tblSearch100" cellSpacing="1" cellPadding="1" width="100%">
								<TBODY>
									<TR>
										<TD>
											<table width="100%">
												<tr align="center">
													<td colSpan="7"><b>Dati Dell' Ordine di Lavoro (ODL)</b>
													</td>
												</tr>
												<tr>
													<td><asp:label id="Label1" runat="server" Font-Bold="True" ForeColor="Gray">Ordine di Lavoro</asp:label></td>
													<td><asp:label id="Label2" runat="server" Font-Bold="True" ForeColor="Gray">Località</asp:label></td>
													<td><asp:label id="Label3" runat="server" Font-Bold="True" ForeColor="Gray">Edificio</asp:label></td>
													<td><asp:label id="Label4" runat="server" Font-Bold="True" ForeColor="Gray">Indirizzo</asp:label></td>
													<td><asp:label id="Label5" runat="server" Font-Bold="True" ForeColor="Gray">Data Emissione ODL</asp:label></td>
													<td><asp:label id="Label6" runat="server" Font-Bold="True" ForeColor="Gray">Data Pianificata</asp:label></td>
													<td><asp:label id="Label7" runat="server" Font-Bold="True" ForeColor="Gray">Addetto</asp:label></td>
												</tr>
												<tr>
													<td><asp:label id="LblODL" runat="server"></asp:label>&nbsp;</td>
													<td><asp:label id="LblLocalita" runat="server"></asp:label>&nbsp;</td>
													<td><asp:label id="LblCodEdificio" runat="server"></asp:label>&nbsp;</td>
													<td><asp:label id="LblIndirizzo" runat="server"></asp:label>&nbsp;</td>
													<td><asp:label id="LblDataEmissione" runat="server"></asp:label>&nbsp;</td>
													<td><asp:label id="LblDataPianificata" runat="server"></asp:label>&nbsp;</td>
													<td><asp:label id="LblAddetto" runat="server"></asp:label>&nbsp;</td>
												</tr>
											</table>
										</TD>
									</TR>
									<tr>
										<TD style="HEIGHT: 3%" align="center"></TD>
									</tr>
									<TR>
										<TD style="HEIGHT: 72%" vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" AutoGenerateColumns="False" GridLines="Vertical"
												BorderWidth="1px" BorderColor="Gray" AllowPaging="True" CssClass="DataGrid">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID1"></asp:BoundColumn>
													<asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="&lt;input id='ChkSelTutti' type='Checkbox' onclick='SelCheckbox()'&gt;">
														<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:CheckBox ID="ChkSel" Runat="server"></asp:CheckBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:HyperLinkColumn DataTextField="Id" HeaderText="RDL"></asp:HyperLinkColumn>
													<asp:TemplateColumn HeaderText="Codice Procedura">
														<ItemTemplate>
															<a href='DettProcedurePassi.aspx?pmp=<%#  DataBinder.Eval(Container.DataItem,"id_Pm") + "&pmp_id=" + DataBinder.Eval(Container.DataItem,"CodiceProcedura")%>'>
																<%# DataBinder.Eval(Container.DataItem,"CodiceProcedura")%>
															</a>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="Apparecchiatura" HeaderText="Apparecchiatura"></asp:BoundColumn>
													<asp:BoundColumn DataField="StatoRichiesta" HeaderText="Stato Richiesta"></asp:BoundColumn>
													<asp:BoundColumn DataField="descrizione" HeaderText="Descrizione"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="MotivoSospensione" HeaderText="Motivo Sospensione"></asp:BoundColumn>
													<asp:TemplateColumn HeaderText="&#160;Check&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Motivo della sospensione">
														<HeaderStyle Width="40%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<uc1:UserOption id="UserOption1" runat="server"></uc1:UserOption>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="idstatus" HeaderText="idstatus"></asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
									<tr>
										<td><COLLAPSE:DATAPANEL id="DatapanelCompleta" runat="server" CssClass="DataPanel75" Visible="False" ExpandImageUrl="../Images/down.gif"
												CollapseImageUrl="../Images/up.gif" CollapseText="Riduci" ExpandText="Espandi" AllowTitleExpandCollapse="True"
												TitleText="Completamento/Modifica ODL" TitleStyle-CssClass="TitleSearch">
												<TABLE height="100%" align="center" border="0">
													<TR>
														<TD style="WIDTH: 378px">
															<TABLE width="100%" border="1">
																<TR align="center">
																	<TD style="COLOR: red; HEIGHT: 28px" colSpan="2">Data Completamento/Sospensione</TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 28px" align="center" colSpan="2">
																		<uc1:calendarpicker id="CalendarPicker1" runat="server" Visible="True"></uc1:calendarpicker></TD>
																</TR>
																<TR>
																	<TD align="right" width="50%">
																		<cc1:s_button id="btnsCompletaOdl" runat="server" CssClass="btn" Visible="True" Text="COMPLETA ODL"
																			Width="100%"></cc1:s_button></TD>
																	<TD align="left">
																		<asp:button id="BtnChiudi" runat="server" CssClass="btn" Text="CHIUDI" Width="100%"></asp:button></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</COLLAPSE:DATAPANEL></td>
									</tr>
								</TBODY>
							</TABLE>
							<INPUT id="hiddenreload" type="hidden" runat="server">
							<asp:Button id="hidRef" runat="server" Width="0px"></asp:Button><INPUT type="hidden" name="hidRicerca"></TD>
					</TR>
				</TBODY>
			</TABLE>
			</TD></TR></TBODY></TABLE></TD></TR></form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
