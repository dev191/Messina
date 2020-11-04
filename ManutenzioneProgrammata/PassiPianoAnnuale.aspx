<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Page language="c#" Codebehind="PassiPianoAnnuale.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.PassiPianoAnnuale" %>
<%@ Register TagPrefix="uc1" TagName="UserMeseGiorno" Src="../WebControls/UserMeseGiorno.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Piano Annuale</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function ImpostaGiorni(val,cmbgiorni)
			{
				var Elementi = document.getElementById(cmbgiorni).options.length - 1;
				while (Elementi > -1)
				{
					document.getElementById(cmbgiorni).remove(Elementi);	
					Elementi--;
				}
				
				var maxgiorni=0	
				
				switch (val)
				{		
				case "4":	//Aprile		
				case "6":	//Giugno		
				case "9":	//Settembre		
				case "11":	//Novembre		
					maxgiorni=30;
					break;
				case "2":		
					maxgiorni=28; //Febbraio	
					break;
				default:		
					maxgiorni=31;
					break;
				}

				var i;
				var ind=0;	
				for(i=1;i<=maxgiorni;i++)
				{	
					ind ++;
					Opt = document.createElement("Option");
					Opt.text = i;
					Opt.value = i;
					Opt.id = ind;		
					document.getElementById(cmbgiorni).add(Opt,ind);
				}
			}					
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="5" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" title="Piano Annuale" runat="server"></uc1:pagetitle></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
								<TBODY>
									<TR>
										<TD vAlign="top" align="left"><asp:label id="lblpmp" CssClass="TitleOperazione" Runat="server"></asp:label><asp:textbox id="txtAnno" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtEQ" runat="server" Visible="False"></asp:textbox>
											<asp:textbox id="txtId_bl" runat="server" Visible="False"></asp:textbox>
											<asp:textbox id="txtbl_id" runat="server" Visible="False"></asp:textbox></TD>
									</TR>
									<tr vAlign="top">
										<TD align="center"></TD>
									</tr>
									<TR vAlign="top">
										<TD vAlign="top" align="center"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="DataGridRicerca" runat="server" CssClass="DataGrid" PageSize="10" BorderColor="Gray"
												BorderWidth="1px" AutoGenerateColumns="False" GridLines="Vertical" AllowPaging="True">
												<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
												<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="false" DataField="ID_PMP" HeaderText="ID_PMP"></asp:BoundColumn>
													<asp:BoundColumn DataField="PMP" HeaderText="PROCEDURA">
														<ItemStyle VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="DESCRIZIONE" HeaderText="DESCRIZIONE">
														<ItemStyle VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn HeaderText="DATA" >
														<ItemTemplate>
															<uc1:UserMeseGiorno id="UserMeseGiorno1" runat="server" ></uc1:UserMeseGiorno>
															
														</ItemTemplate>
													</asp:TemplateColumn>
							
													<asp:BoundColumn HeaderText="ISTRUZIONI">
														<ItemStyle VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="false" DataField="ID_PMS" HeaderText="ID_PMS"></asp:BoundColumn>
													<asp:TemplateColumn HeaderText="ADDETTO">
														<ItemTemplate>
															<asp:DropDownList ID="cmdAddetto" Runat="server"></asp:DropDownList>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></TD>
									</TR>
									<tr>
										<td>
											<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="0">
												<TR>
													<TD>
														<cc1:S_Button id="btSalva" runat="server" CommandType="New" Text="Salva" CssClass="btn"></cc1:S_Button></TD>
													<TD><input id="cmdChiudi" onclick="javascript:window.close()" type="button" value="Chiudi"
															class="btn"></TD>
												</TR>
											</TABLE>
										</td>
									</tr>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
	</body>
</HTML>
