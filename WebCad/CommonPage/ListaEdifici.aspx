<%@ Page language="c#" Codebehind="ListaEdifici.aspx.cs" AutoEventWireup="false" Inherits="WebCad.CommonPage.ListaEdifici" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Lista Edifici</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		var NS4 = (navigator.appName == "Netscape" && parseInt(navigator.appVersion) < 5);
		var NSX = (navigator.appName == "Netscape");
		var IE4 = (document.all) ? true : false;

		function Chiudi()
		{
			var oVDiv=parent.document.getElementById("Popup").style;
			oVDiv.display = 'none';
		}
		function Popola1(j)
			{
				/*var ctrlLis= parent.document.getElementById("S_ListEdifici");
				var opt= new Option(campus,bl_id);
				var lenoption=ctrlLis.options.length;
                ctrlLis.options[lenoption]=opt; */ 
                var bl_id=a[j];
                var campus=b[j];
                
                var ctrlLis= parent.document.getElementById("S_ListEdifici");
               
                var i;
				for (i = 0; i < ctrlLis.options.length; i++) {
				    
					if(ctrlLis.options[i].value==bl_id){
					 alert("Edificio già selezionato!");
					 return;
					}
				}
				
				campus="(" + bl_id + ") " + campus;
				
				var opt= new Option(campus,bl_id);
				var lenoption=ctrlLis.options.length;
				
                ctrlLis.options[lenoption]=opt;
                
                var ctrlhidden= parent.document.getElementById("edifici");
                if(ctrlhidden.value=="") 
                  ctrlhidden.value=bl_id;
                else  
                 ctrlhidden.value+= "," + bl_id;
                
                var ctrldeschidden= parent.document.getElementById("edificidescription");
                if(ctrldeschidden.value=="") 
                  ctrldeschidden.value=campus;
                else  
                 ctrldeschidden.value+= "$" + campus;        
			}	
			
			
			function Popola2(j)
			{    
				parent.document.getElementById(idmodulo + "_" + "txtsCodEdificio").value=a[j];
				parent.document.getElementById(idmodulo + "_" + "lblDenominazione").innerText=b[j];
                parent.document.getElementById(idmodulo + "_" + "txtRicerca").value=c[j];   
                parent.document.getElementById(idmodulo + "_" + "lblEmail").innerText=d[j];
                parent.document.getElementById(idmodulo + "_" + "lblComune").innerText=e[j];
                parent.document.getElementById(idmodulo + "_" + "lblIndirizzo").innerText=f[j];
				parent.document.getElementById(idmodulo + "_" + "lblDitta").innerText=g[j];
                parent.document.getElementById(idmodulo + "_" + "lblTelefono").innerText=h[j];
				parent.document.getElementById(idmodulo + "_" + "lblCdC").innerText=i[j];
				parent.document.getElementById(idmodulo + "_" + "hiddenidbl").innerText=l[j];
				Chiudi();
				//if (typeof(parent.__doPostBack) == 'function')
				//{
				   parent.__doPostBack(idmodulo + '$txtsCodEdificio',''); 
				//}       
			}	
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td class="TDCommon"><asp:hyperlink id="HyperLink1" runat="server" Width="56px" Height="16px" NavigateUrl="javascript:Chiudi()"><img border="0" src="../Images/chiudi.gif" /></asp:hyperlink>evvvvvvvvvvvvvvvvvvvvvvvvvvvvaaaaaaaaaaaaaaaaaaaiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1</td>
				</tr>
				<tr>
					<td width="100%"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="MyDataGrid1" runat="server" Width="100%" GridLines="Vertical" AllowPaging="True"
							CssClass="DataGrid" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="Gray">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<a href="" runat="server" id="hrefset"><img border="0" id="imgsele" src="../Images/gnome-fs-home.gif"></a>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="bl_id" HeaderText="Cod. Edificio"></asp:BoundColumn>
								<asp:BoundColumn DataField="denominazione" HeaderText="Nome Edificio"></asp:BoundColumn>
								<asp:BoundColumn DataField="campus" HeaderText="Chiave di Ricerca"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="email"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="comune"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="indirizzo"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="referente"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="telefono_referente"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="centrodicosto"></asp:BoundColumn>
								<asp:BoundColumn DataField="id" HeaderText="Id. Edificio" Visible="False"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="Black" BackColor="Silver" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td class="TDCommon"><asp:hyperlink id="HyperLinkChiudi2" runat="server" Width="56px" Height="16px" NavigateUrl="javascript:Chiudi()"><img border="0" src="../Images/chiudi.gif" /></asp:hyperlink></td>
				</tr>
			</table>
			&nbsp;
		</form>
	</body>
</HTML>
