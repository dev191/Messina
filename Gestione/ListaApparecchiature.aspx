<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RicercaModulo" Src="../WebControls/RicercaModulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserStanze" Src="../WebControls/UserStanze.ascx" %>
<%@ Page language="c#" Codebehind="ListaApparecchiature.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.ListaApparecchiature" %>
<%@ Register TagPrefix="uc1" TagName="CodiceStdApparecchiatura" Src="../WebControls/CodiceStdApparecchiatura.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CodiceApparecchiature" Src="../WebControls/CodiceApparecchiature.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="cc1" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="GridTitleServer" Src="../WebControls/GridTitleServer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
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
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; TOP: 8px; LEFT: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="tblSearch100" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD><cc1:datapanel id="DataPanel1" runat="server" TitleStyle-CssClass="TitleSearch" Collapsed="False"
										TitleText="Anagrafe Apparecchiature" ExpandText="Espandi" ExpandImageUrl="../Images/down.gif"
										CollapseText="Riduci" CssClass="DataPanel75" CollapseImageUrl="../Images/up.gif" AllowTitleExpandCollapse="True">
										<TABLE id="tblSearch100" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD><uc1:ricercamodulo id="RicercaModulo1" runat="server"></uc1:ricercamodulo></TD>
											</TR>
											<TR>
											</TR>
										</TABLE>
										<TABLE width="100%" border="0">
											<TR>
												<TD style="WIDTH: 72px; HEIGHT: 6px">Piano:</TD>
												<TD style="HEIGHT: 6px"><cc2:s_combobox id="cmbsPiano" runat="server" Width="200px"></cc2:s_combobox></TD>
												<TD style="HEIGHT: 6px" colSpan="2">
													<uc1:UserStanze id="UserStanze1" runat="server"></uc1:UserStanze></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 72px">Servizio:</TD>
												<TD colSpan="3"><cc2:s_combobox id="cmbsServizio" runat="server" Width="312px" AutoPostBack="True"></cc2:s_combobox><asp:requiredfieldvalidator id="RQServizio" runat="server" ControlToValidate="cmbsServizio" Display="Dynamic"
														ErrorMessage="Selezionare un servizio"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 72px">Std. Apparecchiatura:</TD>
												<TD colSpan="3"><cc2:s_combobox id="cmbsApparecchiatura" runat="server" Width="350px" DBParameterName="p_Eqstd_Id"
														DBSize="4" DBIndex="11"></cc2:s_combobox></TD>
											</TR>
											<TR>
												<TD colSpan="4"><uc1:codiceapparecchiature id="CodiceApparecchiature1" runat="server"></uc1:codiceapparecchiature></TD>
											</TR>
											<TR>
												<TD colSpan="4"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 72px"><cc2:s_button id="btRicerca" runat="server" CssClass="btn" Width="80px" Text="Ricerca"></cc2:s_button></TD>
												<TD style="WIDTH: 330px"><cc2:s_button id="brreset" runat="server" CssClass="btn" Width="80px" Text="Reset" CausesValidation="False"></cc2:s_button></TD>
												<TD style="WIDTH: 20px"></TD>
												<td align="right"><A class=GuidaLink 
                  href="<%= HelpLink %>" 
            target=_blank>Guida</A></td>
											</TR>
										</TABLE></TD>
							</TR>
						</TABLE>
						<P>&nbsp;</P>
						</cc1:datapanel></TD>
				</TR>
				<TR>
					<TD><uc1:gridtitleserver id="GridTitleServer1" runat="server" DESIGNTIMEDRAGDROP="302"></uc1:gridtitleserver><asp:datagrid id="DataGrid1" runat="server" CssClass="DataGrid" Width="100%" BorderColor="Gray"
							BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False" GridLines="Vertical">
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="20px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton ImageUrl="../Images/edit.gif" Runat=server OnCommand="imageButton_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id")+ "," + DataBinder.Eval(Container.DataItem,"date_dismiss")%>' ID="Imagebutton1">
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="20px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton ImageUrl="../Images/elimina.gif" Runat="server" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id")%>' ID="Imagebutton2">
										</asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="bl_id" HeaderText="Cod.Edificio"></asp:BoundColumn>
								<asp:BoundColumn DataField="eq_id" HeaderText="Cod.Apparecchiature"></asp:BoundColumn>
								<asp:BoundColumn DataField="condition" HeaderText="Stato"></asp:BoundColumn>
								<asp:BoundColumn DataField="description" HeaderText="Descrizione"></asp:BoundColumn>
								<asp:BoundColumn DataField="category" HeaderText="Servizio"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="date_dismiss" HeaderText="datadismissione"></asp:BoundColumn>
								<asp:BoundColumn DataField="piano" HeaderText="Piano"></asp:BoundColumn>
								<asp:BoundColumn DataField="stanza" HeaderText="Stanza"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<INPUT id="hiddenblid" type="hidden" runat="server"> </TD></TR></TABLE></form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
