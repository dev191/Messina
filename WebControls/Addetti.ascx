<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Addetti.ascx.cs" Inherits="TheSite.WebControls.Addetti" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript">
	function TextAddetto(cognome,nome,id)
	{
		 var ctrl=document.getElementById('<%=idtxtAddetto%>');
		 ctrl.value = cognome.replace("`","'") + ' ' + nome.replace("`","'");
		 AddettiSetVisible(false, '<%=NomePannello%>')
		 
		 var ctrl1=document.getElementById('<%=IdTxtIdAddetto%>')
		 ctrl1.value=id;
	}
 
  function AddettiSetVisible(state, Pannello)
  {
   var DivRef = document.getElementById(Pannello);
   var IfrRef = document.getElementById('AddettiShim');
   if(state)
   {
    DivRef.style.display = "block";
    IfrRef.style.width = DivRef.offsetWidth;
    IfrRef.style.height = DivRef.offsetHeight;
    IfrRef.style.top = DivRef.style.top;
    IfrRef.style.left = DivRef.style.left;
    IfrRef.style.zIndex = DivRef.style.zIndex - 1;
    IfrRef.style.display = "block";
   }
   else
   {
    DivRef.style.display = "none";
    IfrRef.style.display = "none";
   }
  }
</script>
<asp:TextBox ID="hidBL_ID" Runat=server Visible=False></asp:TextBox>
<asp:TextBox ID="hidDITTA_ID" Runat=server Visible=False>
</asp:TextBox><asp:textbox id="txtAddetto" Runat="server" MaxLength="50" Width=80%></asp:textbox>
<asp:textbox id="TxtIdAddetto" Runat="server" Width=0 Height=0></asp:textbox><asp:button  CssClass="btn" id="cmdAddetto" runat="server" Text="..." Width="24" Height="24" CausesValidation=False></asp:button>
<br><asp:panel id="AddettiShowInfo" style="DISPLAY: none; Z-INDEX: 100; COLOR: #ffffff; POSITION: absolute; BACKGROUND-COLOR: gainsboro"
		runat="server" Width="100%">
		<TABLE height="100%" width="100%">
			<TR>
				<TD class="TitleSearch" vAlign="top" align="right">
					<asp:linkbutton id="lnkChiudi" runat="server" CssClass="LabelChiudi" CausesValidation="False">Chiudi</asp:linkbutton></TD>
			</TR>
			<TR>
				<TD>
					<asp:datagrid id="DataGridAddetto" runat="server" CssClass="DataGrid" AllowPaging="True" GridLines="Vertical"
						AutoGenerateColumns="False" BorderWidth="1px" BorderColor="Gray">
						<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
						<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
						<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
						<Columns>
							<asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>							
							<asp:TemplateColumn HeaderText="COGNOME">
								<ItemTemplate>
									<a href="#" onclick="TextAddetto('<%# Apici(DataBinder.Eval(Container, "DataItem.COGNOME")) %>','<%# Apici(DataBinder.Eval(Container, "DataItem.NOME")) %>','<%# DataBinder.Eval(Container, "DataItem.ID")%>')">
										<%# DataBinder.Eval(Container, "DataItem.Cognome") %>
									</a>
								</ItemTemplate>
							</asp:TemplateColumn>						
							<asp:TemplateColumn HeaderText="NOME">
								<ItemTemplate>
									<a href="#" onclick="TextAddetto('<%# Apici(DataBinder.Eval(Container, "DataItem.COGNOME")) %>','<%# Apici(DataBinder.Eval(Container, "DataItem.NOME")) %>','<%# DataBinder.Eval(Container, "DataItem.ID")%>')">
										<%# DataBinder.Eval(Container, "DataItem.Nome") %>
									</a>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="DITTA">
								<ItemTemplate>
									<a href="#" onclick="TextAddetto('<%# Apici(DataBinder.Eval(Container, "DataItem.COGNOME")) %>','<%# Apici(DataBinder.Eval(Container, "DataItem.NOME")) %>','<%# DataBinder.Eval(Container, "DataItem.ID")%>')">
										<%# DataBinder.Eval(Container, "DataItem.Ditta") %>
									</a>
								</ItemTemplate>
							</asp:TemplateColumn>
						</Columns>
						<PagerStyle Mode="NumericPages"></PagerStyle>
					</asp:datagrid></TD>
			</TR>
		</TABLE>
	</asp:panel><iframe id="AddettiShim" style="DISPLAY: none; POSITION: absolute" src="javascript:false;"
		frameBorder="0" scrolling="no"> </iframe>

