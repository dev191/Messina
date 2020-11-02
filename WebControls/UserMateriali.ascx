<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="UserMateriali.ascx.cs" Inherits="TheSite.WebControls.UserMateriali" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<SCRIPT language="javascript">
function SoloNumeri()
		{	
			if (event.keyCode < 48	|| event.keyCode > 57)
			{
				event.keyCode = 0;
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
		//alert(quantita);
			prezzoUnitario = document.getElementById(txtPrezzoUnitario).innerText;
			//alert(prezzoUnitario);
			fPrezzoUnitario = NumVirgolaToPunto(prezzoUnitario);
			//alert(fPrezzoUnitario);
			prezzoTotale = parseFloat(quantita) * parseFloat(fPrezzoUnitario);
			//alert(prezzoTotale);
			PrezzoTotaleApprossimato = formatta(prezzoTotale);
			//alert(PrezzoTotaleApprossimato);
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


</SCRIPT>
<table>
	<tr>
		<td><cc1:s_textbox id="txtMateriale" Width="136px" runat="server"></cc1:s_textbox><cc1:s_textbox id="lbldes" Width="0px" runat="server" Height="0px"></cc1:s_textbox><INPUT class=btn id=btnsRicerca title="Fare Click per effettuare la Ricerca sui Materiali" onclick="ShowFrameMateriale('<%=TextRicMat%>','idric',event,'<%=idModuloMat%>','<%=DescrizioneMateriali%>');"type=button value=...>
		</td>
		<td>
			<div id="PopupMateriale" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; DISPLAY: none; BORDER-LEFT: #000000 1px solid; WIDTH: 409px; BORDER-BOTTOM: #000000 1px solid; POSITION: absolute; HEIGHT: 200px"><IFRAME id="docMateriale" style="WIDTH: 104.61%; HEIGHT: 216px" name="docMateriale" src=""
					frameBorder="no" width="100%" scrolling="auto"></IFRAME>
			</div>
		</td>
	</tr>
	<tr>
		<td>Unità</td>
		<td><ASP:LABEL id="lblunita" runat="server"></ASP:LABEL></td>
	</tr>
	<tr>
		<td>Prezzo unitario</td>
		<td><ASP:LABEL id="lblprezzounitario" runat="server"></ASP:LABEL></td>
	</tr>
	<tr>
		<td>Quantità</td>
		<td><cc1:s_textbox id="txtquantita" Width="136px" runat="server"></cc1:s_textbox></td>
	</tr>
	<tr>
		<td>Totale</td>
		<td><cc1:s_textbox id="txttotale" Width="136px" runat="server"></cc1:s_textbox></td>
	</tr>
	<TR>
		<TD><ASP:IMAGEBUTTON id="imbUpdate" runat="server" height="20px" imageurl="../Images/salva.gif" commandname="Update"></ASP:IMAGEBUTTON><ASP:IMAGEBUTTON id="imbCancel" runat="server" height="20px" imageurl="../Images/annulla.gif" commandname="Cancel"></ASP:IMAGEBUTTON><cc1:s_textbox id="txtid" Width="0px" runat="server" Height="0px"></cc1:s_textbox><cc1:s_textbox id="txtwrid" Width="0px" runat="server" Height="0px"></cc1:s_textbox>
			<cc1:s_textbox id="txtwrdIn" Width="0px" runat="server" Height="0px"></cc1:s_textbox></TD>
	</TR>
</table>
