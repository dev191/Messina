<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Page language="c#" Codebehind="ListaRDL.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ListaRDL" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Lista RDL</title>
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
                var wr_id=a[j];
                
                
                var ctrlLis= parent.document.getElementById("S_ListRDL");                
                var i;
				for (i = 0; i < ctrlLis.options.length; i++) 
				{
				    
					if(ctrlLis.options[i].value==wr_id)
					{
					 alert("RDL già selezionata!");
					 return;
					}
				}
												
				var opt= new Option(wr_id,wr_id);
				var lenoption=ctrlLis.options.length;
				
                ctrlLis.options[lenoption]=opt;
                var ctrlhidden= parent.document.getElementById("rdl");
                /*if(ctrlhidden.value=="") 
                  ctrlhidden.value=wr_id;*/ 
                 
                /*else*/  
                 ctrlhidden.value+=  wr_id + "," ;
                /*var ctrlhidden= parent.document.getElementById("edifici");
                if(ctrlhidden.value=="") 
                  ctrlhidden.value=bl_id;
                else  
                 ctrlhidden.value+= "," + bl_id;
                
                var ctrldeschidden= parent.document.getElementById("edificidescription");
                if(ctrldeschidden.value=="") 
                  ctrldeschidden.value=campus;
                else  
                 ctrldeschidden.value+= "$" + campus;        
                 */
				
			   
			}	
			
			
			function Popola2(j)
			{    
				parent.document.getElementById(idmodulo + "_" + "txtsRDL").value=a[j];
                
				parent.document.getElementById(idmodulo + "_" + "hiddenidbl").innerText=b[j];
				Chiudi();
				//if (typeof(parent.__doPostBack) == 'function')
				//{
				   parent.__doPostBack(idmodulo + '$txtsRDL',''); 
				//}       
			}	
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td class="TDCommon"><asp:hyperlink id="HyperLink1" runat="server" Width="56px" Height="16px" NavigateUrl="javascript:Chiudi()"><img border="0" src="../Images/chiudi.gif" />
						</asp:hyperlink></td>
				</tr>
				<tr>
					<td width="100%"><uc1:gridtitle id="GridTitle1" runat="server"></uc1:gridtitle><asp:datagrid id="MyDataGrid1" runat="server" Width="100%" GridLines="Vertical" AllowCustomPaging="True"
							AllowPaging="True" CssClass="DataGrid" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="Gray">
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="30px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<A id="hrefset" href="" runat="server"><IMG id="imgsele" src="../Images/gnome-fs-home.gif" border="0"></A>
										<A id="hrefset1" href="" runat="server"><IMG id="Imgbloc" src="../Images/lucc.gif" border="0"></A>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="wr_id" HeaderText="RDL"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="totrdl"></asp:BoundColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="wr_id" DataNavigateUrlFormatString="javascript:var w =window.open('../ManutenzioneCorrettiva/VisualizzaRdl.aspx?ItemId={0}&amp;FunId={0}&amp;chiamante=Materiali','_blank','width=800,height=600,location=no,scrollbars=yes')"
									DataTextField="wr_id" HeaderText="Rdl"></asp:HyperLinkColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" cssclass="DataGridPagerStyle" Mode="NumericPages"></PagerStyle>
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
