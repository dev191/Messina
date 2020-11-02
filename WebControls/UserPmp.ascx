<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="UserPmp.ascx.cs" Inherits="TheSite.WebControls.UserPmp" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table>
	<tr>
		<td valign="middle">
			<cc1:s_textbox id="txtmatricola" Width="96px" runat="server" AutoPostBack="True"></cc1:s_textbox>
		</td>
		<td>
			<INPUT id=btnsRicercamatricola title="Fare Click per effettuare la Ricerca delle Apparecchiature" style="WIDTH: 64px; HEIGHT: 24px" onclick="ShowFrameMatricole('<%=idTextRicMat%>','idric',event,'<%=idModuloMat%>');"type=button value=Ricerca class=btn>
		</td>
		<td valign="middle" colspan="2">
			<cc1:S_TextBox id="txtdescrizione" Width="344px" runat="server"></cc1:S_TextBox>&nbsp;
		</td>
	</tr>
	<tr>
		<td colspan="2" valign="middle">
			<div id="Popupmatricole" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; DISPLAY: none; BORDER-LEFT: #000000 1px solid; WIDTH: 409px; BORDER-BOTTOM: #000000 1px solid; POSITION: absolute; HEIGHT: 138px"><IFRAME id="docmatricole" style="WIDTH: 100%; HEIGHT: 138px" name="docmatricole" src=""
					frameBorder="no" width="100%" scrolling="auto"></IFRAME>
			</div>
		</td>
	</tr>
</table>
<INPUT type="hidden" id="txtid" name="txtid" runat="server" value="0"> 

