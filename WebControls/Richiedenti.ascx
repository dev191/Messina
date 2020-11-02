<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Richiedenti.ascx.cs" Inherits="TheSite.WebControls.Richiedenti" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<script language="javascript">
	function TextRichiedente(nome)
	{
		 var ctrl=document.getElementById('<%=idtxtRichiedente%>');
		 ctrl.value = nome.replace("`","'");
		 RichiedentiSetVisible(false, '<%=NomePannello%>')		
	}
 
  function RichiedentiSetVisible(state, Pannello)
  {
   var DivRef = document.getElementById(Pannello);
   var IfrRef = document.getElementById('RichiedenteShim');
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
</asp:TextBox><cc1:s_textbox id="txtRichiedente" Runat="server" MaxLength="50" Width=80%></cc1:s_textbox><asp:button CssClass="btn" CausesValidation=False  id="cmdRichiedente" runat="server" Text="..." Width="24" Height="24"></asp:button>
<br><asp:panel id="RichiedenteShowInfo" style="DISPLAY: none; Z-INDEX: 100; COLOR: #ffffff; POSITION: absolute; BACKGROUND-COLOR: gainsboro"
		runat="server" Width="100%">
		<TABLE height="100%" width="100%">
			<TR>
				<TD class="TitleSearch" vAlign="top" align="right">
					<asp:linkbutton id="lnkChiudi" runat="server" CssClass="LabelChiudi" CausesValidation="False">Chiudi</asp:linkbutton></TD>
			</TR>
			<TR>
				<TD>
					<asp:datagrid id="DataGridRichiedente" runat="server" CssClass="DataGrid" AllowPaging="True" GridLines="Vertical"
						AutoGenerateColumns="False" BorderWidth="1px" BorderColor="Gray">
						<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
						<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
						<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
						<Columns>													
							<asp:TemplateColumn HeaderText="Richiedente">
								<ItemTemplate>
									<a href="#" onclick="TextRichiedente('<%# Apici(DataBinder.Eval(Container, "DataItem.Richiedente")) %>')">
										<%# DataBinder.Eval(Container, "DataItem.Richiedente") %>
									</a>
								</ItemTemplate>
							</asp:TemplateColumn>																	
						</Columns>
						<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
					</asp:datagrid></TD>
			</TR>
		</TABLE>
	</asp:panel><iframe id="RichiedenteShim" style="DISPLAY: none; POSITION: absolute" src="javascript:false;"
		frameBorder="0" scrolling="no"> </iframe>

