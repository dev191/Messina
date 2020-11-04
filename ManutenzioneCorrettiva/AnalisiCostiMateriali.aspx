<%@ Page language="c#" Codebehind="AnalisiCostiMateriali.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneCorrettiva.AnalisiCostiMateriali" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>GestioneMateriali</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
		
		
		function OpenPopUp()
		 {
		 //string parametri=wr_id+"&RDL="+rdl+"&idMat="+idMater
		//		+"&DataDA="+datai+"&DataA="+dataf+"&Stato="+cmbsStato.SelectedValue;
			var datai=document.getElementById('<%=CalendarPicker1.Datazione.ClientID%>').value
			var dataf=document.getElementById('<%=CalendarPicker2.Datazione.ClientID%>').value; 
			var rdl= document.getElementById('<%=txtRdl.ClientID%>').value; 
			var ctrl=document.getElementById('<%=cmbsMateriale.ClientID%>');
			var appo= ctrl.options[ctrl.selectedIndex].value;
			var valueArray= appo.split(";");
			var idMat=valueArray[0];
			var ctrl1=document.getElementById('<%=cmbsStato.ClientID%>');
			var Stato= ctrl1.options[ctrl1.selectedIndex].value;	
		    var param="VisualizzaGestioneMaterialiPdf.aspx?RDL=" + rdl +"&DataDA=" +datai+ "&DataA="+dataf+"&idMat="+idMat+"&Stato="+Stato; 
           
           window.open(param,"lin","width=800px, height=800px, toolbar=no,location=no,status=yes,menubar=no,scrollbars=yes,resizable=yes");
			
		 }
   function apriAnagMat(funid)
   {
      var param1="../Gestione/ListaMateriali.aspx?FunId=649"; 
      window.open(param1,"lin","width=800px, height=800px, toolbar=no,location=no,status=yes,menubar=no,scrollbars=yes,resizable=yes");
	}
	function cmbSelezione(cmbMateriali,txtPrezzoUnitario,txtQuantita,txtPrezzoTotale)
	{
		var valueCmb;
		var valueArray;
		valueCmb =	document.getElementById(cmbMateriali).value;
		valueArray = valueCmb.split(";");
		document.getElementById(txtQuantita).value = '';
		document.getElementById(txtPrezzoTotale).value = '';
		document.getElementById(txtPrezzoUnitario).value = valueArray[1];
		if(document.getElementById(txtQuantita).value.length == 0)
		{   
			document.getElementById(txtPrezzoTotale).value = 0;
		}
	}
	function calcolaPrezzoTotale(txtPrezzoUnitario,txtQuantita,txtPrezzoTotale)
	{
		var quantita;
		var prezzoUnitario;
		var quantitaTotale;
		var fPrezzoUnitario;
		var PrezzoTotaleApprossimato;
		var prezzoTotale;
		var arrayPrezzoUnitario,arrayPrezzoTotale;

		quantita = document.getElementById(txtQuantita).value;
		prezzoUnitario = document.getElementById(txtPrezzoUnitario).value;
		fPrezzoUnitario = NumVirgolaToPunto(prezzoUnitario);
		
		prezzoTotale = parseFloat(quantita) * parseFloat(fPrezzoUnitario);
	
		PrezzoTotaleApprossimato = formatta(prezzoTotale);
		document.getElementById(txtPrezzoTotale).value = NumPuntoToVirgola(PrezzoTotaleApprossimato);
		if(document.getElementById(txtQuantita).value.length == 0)
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

function validateRange()
	{
	    var datai=document.getElementById('<%=CalendarPicker1.Datazione.ClientID%>').value; 
	    var datasplit1=datai.split("/");
	    var dinizio=datasplit1[2] + datasplit1[1] + datasplit1[0];
		var dataf=document.getElementById('<%=CalendarPicker2.Datazione.ClientID%>').value; 
		var datasplit2=dataf.split("/");
        var dfine=datasplit2[2] + datasplit2[1] + datasplit2[0];
       if (dinizio>dfine && dinizio!="NaN")
	    {
	      alert("Data Inizio  non può essere maggiore della Data Fine !");
	      return false;
	    }else
	    {
	      return true;
	    }
	}
	
	
	function apri_ricerca_materiali(gruppo,descmat, prezzo,id)
	{	
		var	var1=document.getElementById(descmat).value;			
		var W = window.open('../CommonPage/RicercaMateriali.aspx?utente=ALE&IdMat='+id+'&desc=' + var1 + '&IdTxt='+descmat+'&IdPrezzo='+prezzo+'&aa=richiesta_lavoro','vericacodice','width=600,height=400;status=yes')								
	}
	
	
		</SCRIPT>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" ms_positioning="GridLayout">
		<FORM id="Form1" name="materiali" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="center"><UC1:PAGETITLE id="PageTitle1" runat="server"></UC1:PAGETITLE></TD>
				</TR>
				<TR>
					<TD><COLLAPSE:DATAPANEL id="PanelRicerca" runat="server" titlestyle-cssclass="TitleSearch" cssclass="DataPanel75"
							titletext="Ricerca" allowtitleexpandcollapse="True" collapsed="False" expandtext="Espandi" collapsetext="Riduci"
							collapseimageurl="../Images/up.gif" expandimageurl="../Images/down.gif">
							<TABLE id="tblSearch100" cellSpacing="0" cellPadding="2" border="0">
								<TR>
									<TD>RDL</TD>
									<TD>
										<CC1:S_TEXTBOX id="txtRdl" runat="server" dbparametername="p_wrid" dbdirection="Input" width="216px"
											dbdatatype="Integer"></CC1:S_TEXTBOX></TD>
									<TD style="WIDTH: 102px">Materiale</TD>
									<TD>
										<CC1:S_COMBOBOX id="cmbsMateriale" runat="server" dbparametername="p_id_materiale" dbdirection="Input"
											width="200px" dbdatatype="Integer" dbindex="1"></CC1:S_COMBOBOX></TD>
								</TR>
								<TR>
									<TD>Data Aggiornamento Dal</TD>
									<TD>
										<UC1:CALENDARPICKER id="CalendarPicker1" runat="server"></UC1:CALENDARPICKER></TD>
									<TD style="WIDTH: 102px">Data Aggiornamento Al</TD>
									<TD>
										<UC1:CALENDARPICKER id="CalendarPicker2" runat="server"></UC1:CALENDARPICKER></TD>
								</TR>
								<TR>
									<TD>Stato</TD>
									<TD>
										<CC1:S_COMBOBOX id="cmbsStato" runat="server" dbparametername="p_id_stato" dbdirection="Input" width="200px"
											dbdatatype="Integer" dbindex="4">
											<ASP:LISTITEM value="-1">Nessuno stato</ASP:LISTITEM>
											<ASP:LISTITEM value="1">Entrata</ASP:LISTITEM>
											<ASP:LISTITEM value="2">Uscita</ASP:LISTITEM>
										</CC1:S_COMBOBOX></TD>
									<TD style="WIDTH: 102px"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD>
										<CC1:S_BUTTON id="btnsRicerca" runat="server" cssclass="btn" text="Ricerca"></CC1:S_BUTTON>&nbsp;
										<CC1:S_BUTTON id="BtnReset" runat="server" cssclass="btn" text="Reset" causesvalidation="False"></CC1:S_BUTTON></TD>
									<TD>
										<CC1:S_BUTTON id="ExpPdf" runat="server" cssclass="btn" text="EsportaPdf" causesvalidation="False"></CC1:S_BUTTON><INPUT id="wr_id" type="hidden" runat="server"></TD>
									<TD style="WIDTH: 102px" align="right">
										<CC1:S_BUTTON id="s_cmdanagmat" runat="server" cssclass="btn" text="Anagrafica Materiali"></CC1:S_BUTTON></TD>
									<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
            target=_blank>Guida</A></TD>
								</TR>
							</TABLE>
						</COLLAPSE:DATAPANEL></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="tblGridTitle" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD width="20%"><ASP:LINKBUTTON id="lkbNuovo" runat="server" cssclass="NuovoLink" causesvalidation="False">Nuovo</ASP:LINKBUTTON></TD>
								<TD width="60%"></TD>
								<TD align="right" width="20%">Record:
									<ASP:LABEL id="lblRecord" runat="server">0</ASP:LABEL>&nbsp;&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						<ASP:DATAGRID id="DataGridRicerca" runat="server" cssclass="DataGrid" autogeneratecolumns="False"
							gridlines="Vertical" borderwidth="1px" bordercolor="Gray" datakeyfield="id">
							<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
							<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Wrap="False" Height="20px"></ItemStyle>
									<ItemTemplate>
										<ASP:IMAGEBUTTON id="imbEdit" runat="server" height="20px" imageurl="../Images/edit.gif" commandname="Edit"
											causesvalidation="False"></ASP:IMAGEBUTTON>
										<ASP:IMAGEBUTTON id="imbDelete" runat="server" height="20px" imageurl="../Images/elimina.gif" commandname="Delete"
											causesvalidation="False"></ASP:IMAGEBUTTON>
									</ItemTemplate>
									<FooterStyle Wrap="False" Height="20px" Width="5%"></FooterStyle>
									<FooterTemplate>
										<ASP:IMAGEBUTTON id="imbInsert" runat="server" height="20px" imageurl="../Images/salva.gif" commandname="Insert"></ASP:IMAGEBUTTON>
										<ASP:IMAGEBUTTON id="imgCancel" runat="server" height="20px" imageurl="../Images/annulla.gif" commandname="Cancel"
											causesvalidation="False"></ASP:IMAGEBUTTON>
									</FooterTemplate>
									<EditItemTemplate>
										<ASP:IMAGEBUTTON id="imbUpdate" runat="server" height="20px" imageurl="../Images/salva.gif" commandname="Update"></ASP:IMAGEBUTTON>
										<ASP:IMAGEBUTTON id="imbCancel" runat="server" height="20px" imageurl="../Images/annulla.gif" commandname="Cancel"
											causesvalidation="False"></ASP:IMAGEBUTTON>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="wr_id" ReadOnly="True" HeaderText="RDL"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Materiale">
									<HeaderStyle HorizontalAlign="Center" Width="18%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" Height="20px"></ItemStyle>
									<ItemTemplate>
										<ASP:LABEL id=lblDescrizione runat="server" text='<%# DataBinder.Eval(Container.DataItem, "descrizione") %>' Height="20px">
										</ASP:LABEL>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Left" Width="18%"></FooterStyle>
									<FooterTemplate>
										<ASP:DROPDOWNLIST id=cmbMaterialiInsert runat="server" Height="20px" datasource="<%#GetMateriali()%>" datatextfield="descrizione" datavaluefield="id" Visible="False">
										</ASP:DROPDOWNLIST>
										<asp:TextBox id="TxtDescMat" runat="server" Height="20px" Width="71px"></asp:TextBox><INPUT class=btn id=cmbsCercaMateriale onclick="apri_ricerca_materiali('ADMIN','<%= dascmat%>','<%= prezzo%>','<%= id%>');" type=button value="Cerca Materiale">
										<asp:TextBox id="IdMateriale" runat="server" Height="0px" Width="0px"></asp:TextBox>
									</FooterTemplate>
									<EditItemTemplate>
										<ASP:DROPDOWNLIST id=cmbMaterialiEdit runat="server" Height="20px" datasource="<%#GetMateriali()%>" selectedindex='<%# GetIndex(DataBinder.Eval(Container.DataItem, "descrizione").ToString()) %>' datatextfield="descrizione" datavaluefield="id" Enabled="False" Visible="False">
										</ASP:DROPDOWNLIST>
										<ASP:LABEL id=lblDescrizioneEd runat="server" text='<%# DataBinder.Eval(Container.DataItem, "descrizione") %>' Height="20px">
										</ASP:LABEL>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Quantit&#224;">
									<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<ASP:LABEL id="lblquantita" style="TEXT-ALIGN: right" runat="server" text='<%# FormattaDecimali(DataBinder.Eval(Container.DataItem, "quantita"),0) %>' width="100%">
										</ASP:LABEL>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Right" Width="13%"></FooterStyle>
									<FooterTemplate>
										<ASP:TEXTBOX id="txtquantitaInset" style="TEXT-ALIGN: right" runat="server" text="0" width="100%"
											visible="True" enabled="true"></ASP:TEXTBOX>
										<ASP:REQUIREDFIELDVALIDATOR id="RequiredFieldValidator1" runat="server" errormessage="Inserire una quantità maggiore di 0"
											initialvalue="0" controltovalidate="txtquantitaInset" display="Dynamic">*</ASP:REQUIREDFIELDVALIDATOR>
									</FooterTemplate>
									<EditItemTemplate>
										<ASP:TEXTBOX id="txtquantitaEdit" style="TEXT-ALIGN: right" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "quantita") %>' visible="True" enabled="true">
										</ASP:TEXTBOX>
										<ASP:REQUIREDFIELDVALIDATOR id="RFVquantita" runat="server" errormessage="Inserire una quantità maggiore di 0"
											initialvalue="0" controltovalidate="txtquantitaEdit" display="Dynamic">*</ASP:REQUIREDFIELDVALIDATOR>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Prezzo Unitario (€)">
									<HeaderStyle HorizontalAlign="Center" Width="18%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" Width="18%"></ItemStyle>
									<ItemTemplate>
										<ASP:LABEL id=lblprezzo style="TEXT-ALIGN: right" runat="server" text='<%# FormattaDecimali(DataBinder.Eval(Container.DataItem, "prezzo_unitario"),2) %>'>
										</ASP:LABEL>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Right" Width="18%"></FooterStyle>
									<FooterTemplate>
										<ASP:TEXTBOX id="txtprezzoInsert" style="TEXT-ALIGN: right" runat="server" width="100%" borderwidth="0"
											visible="True" readonly="True"></ASP:TEXTBOX>
									</FooterTemplate>
									<EditItemTemplate>
										<ASP:TEXTBOX id=txtprezzoEdit style="TEXT-ALIGN: right" runat="server" width="100%" text='<%# DataBinder.Eval(Container.DataItem, "prezzo_unitario") %>' ReadOnly="True" visible="True" BorderWidth="0">
										</ASP:TEXTBOX>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Totale (€)">
									<HeaderStyle HorizontalAlign="Center" Width="12%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" Width="12%"></ItemStyle>
									<ItemTemplate>
										<ASP:LABEL id="lbltotale" style="TEXT-ALIGN: right" runat="server" text='<%# FormattaDecimali(DataBinder.Eval(Container.DataItem, "totale"),2) %>' width="100%">
										</ASP:LABEL>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Right"></FooterStyle>
									<FooterTemplate>
										<ASP:TEXTBOX id="txttotaleInsert" style="TEXT-ALIGN: right" runat="server" readonly="True" visible="True"
											width="100%" enabled="true">0</ASP:TEXTBOX>
									</FooterTemplate>
									<EditItemTemplate>
										<ASP:TEXTBOX id="txttotaleEdit" style="TEXT-ALIGN: right" runat="server" text='<%# DataBinder.Eval(Container.DataItem, "totale") %>' visible="True" ReadOnly="True" enabled="true">
										</ASP:TEXTBOX>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="dataaggiornamento" ReadOnly="True" HeaderText="Data Aggiornamento" DataFormatString="{0:d}"></asp:BoundColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="wr_id" DataNavigateUrlFormatString="javascript:var w =window.open('../ManutenzioneCorrettiva/VisualizzaRdl.aspx?ItemId={0}&amp;FunId={0}&amp;chiamante=Materiali','_blank','width=800,height=600,location=no,scrollbars=yes')"
									DataTextField="wr_id" HeaderText="Rdl"></asp:HyperLinkColumn>
							</Columns>
						</ASP:DATAGRID></TD>
				</TR>
			</TABLE>
			<ASP:VALIDATIONSUMMARY id="ValidationSummary1" style="Z-INDEX: 102; LEFT: 32px; POSITION: absolute; TOP: 400px"
				runat="server" showmessagebox="True" showsummary="False"></ASP:VALIDATIONSUMMARY></FORM>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
