<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CostiManodopera.ascx.cs" Inherits="TheSite.WebControls.CostiManodopera" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<SCRIPT language="javascript"> 

	function cmbSelezione(cmbNomeCognome,txtPrezzoUnitario,txtLivello,txtOreLavorate,txtTotale)
	{
		var valueCmb;
		var valueArray;
		valueCmb =	document.getElementById(cmbNomeCognome).value;
		valueArray = valueCmb.split(";");
		document.getElementById(txtOreLavorate).value = '';
		document.getElementById(txtTotale).value = '';
		document.getElementById(txtPrezzoUnitario).value = valueArray[2];
		document.getElementById(txtLivello).value = valueArray[1];
		if(document.getElementById(txtOreLavorate).value.length == 0)
		{   
			document.getElementById(txtTotale).value = 0;
		}
	}

	function calcolaPrezzoTotale(txtPrezzoUnitario,txtOreLavorate,txtPrezzoTotale)
	{
		var quantita;
		var prezzoUnitario;
		var quantitaTotale;
		var fPrezzoUnitario;
		var PrezzoTotaleApprossimato;
		var prezzoTotale;
		var arrayPrezzoUnitario,arrayPrezzoTotale;

		quantita = document.getElementById(txtOreLavorate).value;
		prezzoUnitario = document.getElementById(txtPrezzoUnitario).value;
		fPrezzoUnitario = NumVirgolaToPunto(prezzoUnitario);
		prezzoTotale = parseFloat(quantita) * parseFloat(fPrezzoUnitario);
		PrezzoTotaleApprossimato = formatta(prezzoTotale);
		document.getElementById(txtPrezzoTotale).value = NumPuntoToVirgola(PrezzoTotaleApprossimato);
		if(document.getElementById(txtOreLavorate).value.length == 0)
		{   
			document.getElementById(txtPrezzoTotale).value = 0;
		}
	
	}

function NumVirgolaToPunto(numV)
{
	var ar,numP,numS,inde,i;
	numS = numV.toString();
	i = parseInt(numS.indexOf(","));	
	if(i> 0)
	{
		ar = numS.split(",");
		numP = ar[0] + "." + ar[1];
		return numP;
	}
	else
	{
		return numS;
	}
}

function NumPuntoToVirgola(numP)
{
	var ar,numV,numS,i;
	numS = numP.toString();
	i = parseInt(numS.indexOf("."));
	if(i > 0)
	{
		ar = numS.split(".");
		numV = ar[0] + "," + ar[1];
		return numV;
	}
	else
	{
		return numS;
	}
}
function formatta(fl){	
	var ris;
	var tmp;
	fl=fl.toString();	
	i = parseInt(fl.indexOf("."));		
	if(i>0)
	{			
		lung = parseInt(fl.substring(i+1).length);			
		if(lung>2)
		{
			terza = fl.substring(i+3,i+4);
			ris = parseFloat(fl.substring(0,i+3));					
			if (terza>4)
			{
				ris = ris + parseFloat(0.01);
				ris=ris.toString();
				j=parseInt(ris.indexOf("."));
				tmp = parseFloat(ris.substring(0,j+3));				
				return tmp;
			}
			else
			{
				return ris;
			}
					
		}	
		ris = parseFloat(fl.substring(0,i+3));
		return ris;		
	}
	
	return fl;	
}
function ControllaCaratteri(){
	if (event.keyCode < 48	|| event.keyCode > 57){
		event.keyCode = 0;
	}	
}
</SCRIPT>
<TABLE id="TableMain" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
	<TR>
		<TD vAlign="top" align="center" height="95%">
			<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" align="center">
				<TR>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
					<TD style="HEIGHT: 5%" vAlign="top" align="left">
						<TABLE id="tblGridTitle" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD width="20%"><ASP:LINKBUTTON id="lkbNuovo" cssclass="NuovoLink" runat="server">Nuovo</ASP:LINKBUTTON></TD>
								<TD width="60%"></TD>
								<TD align="right" width="20%">Record:
									<ASP:LABEL id="lblRecord" runat="server">0</ASP:LABEL>&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						<ASP:DATAGRID id="DataGridEsegui" cssclass="DataGrid" runat="server" autogeneratecolumns="False"
							gridlines="vertical" borderwidth="1px" bordercolor="Gray" datakeyfield="ID">
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
								<asp:TemplateColumn Visible="False" HeaderText="IdAddetto">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Wrap="False" Height="20px"></ItemStyle>
									<ItemTemplate>
										<ASP:LABEL ID="lblIdAddetto" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "IdAddetto") %>'>
										</ASP:LABEL>
									</ItemTemplate>
									<FooterTemplate>
										<ASP:LABEL ID="lblIdAddettoInsert" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "IdAddetto") %>'>
										</ASP:LABEL>
									</FooterTemplate>
									<EditItemTemplate>
										<ASP:LABEL ID="lblIdAddettoEdit" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "IdAddetto") %>'>
										</ASP:LABEL>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False" HeaderText="IdAddettoWR">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Wrap="False" Height="20px"></ItemStyle>
									<ItemTemplate>
										<ASP:LABEL ID="lblIdAddettoWR" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "IdAddettoWR") %>'>
										</ASP:LABEL>
									</ItemTemplate>
									<FooterTemplate>
										<ASP:LABEL ID="lblIdAddettoWRInsert" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "IdAddettoWR") %>'>
										</ASP:LABEL>
									</FooterTemplate>
									<EditItemTemplate>
										<ASP:LABEL ID="lblIdAddettoWREdit" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "IdAddettoWR") %>'>
										</ASP:LABEL>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Wrap="False" Height="20px"></ItemStyle>
									<ItemTemplate>
										<ASP:IMAGEBUTTON id="imbEdit" runat="server" commandname="Edit" imageurl="../Images/edit.gif" height="20px"></ASP:IMAGEBUTTON>
										<ASP:IMAGEBUTTON id=imbDelete runat="server" commandname="Delete" imageurl="../Images/elimina.gif" height="20px" Visible='<%# GetStato(DataBinder.Eval(Container.DataItem, "IdAddetto").ToString(),DataBinder.Eval(Container.DataItem, "IdAddettoWR").ToString())%>'>
										</ASP:IMAGEBUTTON>
									</ItemTemplate>
									<FooterStyle Wrap="False" Height="20px" Width="5%"></FooterStyle>
									<FooterTemplate>
										<ASP:IMAGEBUTTON id="imbInsert" runat="server" commandname="Insert" imageurl="../Images/salva.gif"
											height="20px"></ASP:IMAGEBUTTON>
										<ASP:IMAGEBUTTON id="imgCancel" runat="server" commandname="Cancel" imageurl="../Images/annulla.gif"
											height="20px"></ASP:IMAGEBUTTON>
									</FooterTemplate>
									<EditItemTemplate>
										<ASP:IMAGEBUTTON id="imbUpdate" runat="server" commandname="Update" imageurl="../Images/salva.gif"
											height="20px"></ASP:IMAGEBUTTON>
										<ASP:IMAGEBUTTON id="imbCancel" runat="server" commandname="Cancel" imageurl="../Images/annulla.gif"
											height="20px"></ASP:IMAGEBUTTON>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Addetto">
									<HeaderStyle HorizontalAlign="Center" Width="18%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" Height="20px"></ItemStyle>
									<ItemTemplate>
										<ASP:LABEL id=lblAddetto runat="server" text='<%# DataBinder.Eval(Container.DataItem, "CognomeNome") %>' width="100%" height="20px">
										</ASP:LABEL>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Left" Width="18%"></FooterStyle>
									<FooterTemplate>
										<ASP:DROPDOWNLIST id=cmbAddettoInsert runat="server" width="100%" datasource="<%#GetManodopera()%>" datatextfield="CognomeNome" datavaluefield="cmbvalore">
										</ASP:DROPDOWNLIST>
									</FooterTemplate>
									<EditItemTemplate>
										<ASP:DROPDOWNLIST id=cmbAddettoEdit runat="server" width="100%" datasource="<%#GetManodopera()%>" selectedindex='<%# GetIndex(DataBinder.Eval(Container.DataItem, "CognomeNome").ToString()) %>' datatextfield="CognomeNome" Enabled='<%# GetStato(DataBinder.Eval(Container.DataItem, "IdAddetto").ToString(),DataBinder.Eval(Container.DataItem, "IdAddettoWR").ToString())%>' datavaluefield="cmbvalore">
										</ASP:DROPDOWNLIST>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Livello">
									<HeaderStyle HorizontalAlign="Center" Width="14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<ASP:LABEL id="lblLivello" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "Livello") %>' width="100%">
										</ASP:LABEL>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Left" Width="14%"></FooterStyle>
									<FooterTemplate>
										<ASP:TEXTBOX id="txtLivelloInsert" runat="server" width="100%" ReadOnly="True" BorderWidth="0"></ASP:TEXTBOX>
									</FooterTemplate>
									<EditItemTemplate>
										<ASP:TEXTBOX id="txtLivelloEdit" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "Livello") %>' width="100%" ReadOnly=True BorderWidth=0>
										</ASP:TEXTBOX>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Prezzo Unitario (€)">
									<HeaderStyle HorizontalAlign="Center" Width="18%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<ASP:LABEL id=lblPrezzoUnitario style="TEXT-ALIGN: right" runat="server" width="100%" text='<%# FormattaDecimali(DataBinder.Eval(Container.DataItem, "PrezzoUnitario"),2) %>'>
										</ASP:LABEL>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Right" Width="18%"></FooterStyle>
									<FooterTemplate>
										<ASP:TEXTBOX id="txtPrezzoUnitarioInsert" style="TEXT-ALIGN: right" runat="server" width="100%"
											ReadOnly="True" BorderWidth="0"></ASP:TEXTBOX>
									</FooterTemplate>
									<EditItemTemplate>
										<ASP:TEXTBOX id=txtPrezzoUnitarioEdit style="TEXT-ALIGN: right" runat="server" width="100%" text='<%# FormattaDecimali(DataBinder.Eval(Container.DataItem, "PrezzoUnitario"),2) %>' ReadOnly="True" BorderWidth="0">
										</ASP:TEXTBOX>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Ore Lavorate">
									<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<ASP:LABEL id=lblOreLavorate style="TEXT-ALIGN: right" runat="server" width="100%" text='<%# FormattaDecimali(DataBinder.Eval(Container.DataItem, "OreLavorate"),0) %>'>
										</ASP:LABEL>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Right" Width="13%"></FooterStyle>
									<FooterTemplate>
										<ASP:TEXTBOX id="txtOreLavorateInsert" style="TEXT-ALIGN: right" runat="server" width="100%">0</ASP:TEXTBOX>
									</FooterTemplate>
									<EditItemTemplate>
										<ASP:TEXTBOX id=txtOreLavorateEdit style="TEXT-ALIGN: right" runat="server" width="95%" text='<%# DataBinder.Eval(Container.DataItem, "OreLavorate") %>' enabled="true" readonly="False">
										</ASP:TEXTBOX>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Totale (€)">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<ASP:LABEL id=lblTotale style="TEXT-ALIGN: right" runat="server" width="100%" text='<%# FormattaDecimali(DataBinder.Eval(Container.DataItem, "Totale"),2) %>'>
										</ASP:LABEL>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Right" Width="10%"></FooterStyle>
									<FooterTemplate>
										<ASP:TEXTBOX id="TexTotaleInsert" style="TEXT-ALIGN: right" runat="server" width="95%" enabled="true"
											readonly="True">0</ASP:TEXTBOX>
									</FooterTemplate>
									<EditItemTemplate>
										<ASP:TEXTBOX id=TexTotaleEdit style="TEXT-ALIGN: right" runat="server" width="95%" text='<%# DataBinder.Eval(Container.DataItem, "Totale") %>' enabled="true" readonly="True">
										</ASP:TEXTBOX>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Descrizione Intervento">
									<HeaderStyle HorizontalAlign="Center" Width="22%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
									<ItemTemplate>
										<ASP:LABEL id=lblDescIntervento runat="server" width="100%" text='<%# DataBinder.Eval(Container.DataItem, "DescrizioneIntervento") %>'>
										</ASP:LABEL>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Right" Width="22%"></FooterStyle>
									<FooterTemplate>
										<ASP:TEXTBOX id="txtDescInterventoInsert" runat="server" width="100%" enabled="true"></ASP:TEXTBOX>
									</FooterTemplate>
									<EditItemTemplate>
										<ASP:TEXTBOX id=txtDescInterventoEdit runat="server" width="95%" text='<%# DataBinder.Eval(Container.DataItem, "DescrizioneIntervento") %>' enabled="true">
										</ASP:TEXTBOX>
									</EditItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</ASP:DATAGRID></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
<asp:Label id="lblTot1" runat="server" Width="0px" Height="0px"></asp:Label>
