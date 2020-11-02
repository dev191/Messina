<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CodiceApparecchiature.ascx.cs" Inherits="TheSite.WebControls.CodiceApparecchiature" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<script language="javascript">
		/*	function checkApparecchiatura()
			{
				var app = document.getElementById(idthis + "_S_txtcodapparecchiatura").value;
				if( (app == "") 	||	
					(app.length<3) 	||
					(app.indexOf("_") <0 )
				)
				{
					alert("Inserire almeno un _ e due caratteri, es. _BR");
					return false;
				}
				else{return true;}		
			}	
			if (!checkApparecchiatura()) return;
			*/	
</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD style="WIDTH: 15%"><SPAN>Cod. Apparecchiatura:</SPAN>
		</TD>
		<TD>
			<cc1:S_TextBox id="S_txtcodapparecchiatura" runat="server" Width="344px"></cc1:S_TextBox>&nbsp;
			<INPUT id="bt_codapparecchiatura" style="WIDTH: 32px; HEIGHT: 25px" type="button" value="..."
				onclick="ShowFrame2('1',event);" class="btn"> <INPUT id="hidCodEq" type="hidden" runat="server">
			<asp:TextBox id="RichiestaLettura" Width="0px" runat="server" Height="0px"></asp:TextBox>
			<cc1:S_TextBox id="TxtIdApp" Width="0px" runat="server" Height="0px"></cc1:S_TextBox>
		</TD>
	</TR>
</TABLE>
<div id="PopupApp" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; DISPLAY: none; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; POSITION: absolute"><iframe id="docapp" style="WIDTH: 100%; HEIGHT: 280px" name="docapp" src="" frameBorder="no"
		width="100%" scrolling="auto"> </iframe>
</div>
