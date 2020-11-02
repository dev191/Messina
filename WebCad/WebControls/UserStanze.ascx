<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="UserStanze.ascx.cs" Inherits="WebCad.WebControls.UserStanze" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="456" border="0" style="WIDTH: 100%">
	<TR>
		<TD style="WIDTH: 24.8%"><SPAN><SPAN> Stanza:&nbsp;&nbsp;&nbsp;</SPAN></SPAN>&nbsp;
		</TD>
		<TD style="WIDTH: 359px">
			<cc1:S_TextBox id="s_txtDescStanza" runat="server" Width="244px"></cc1:S_TextBox>&nbsp;
			<INPUT id="bt_codapparecchiatura" style="WIDTH: 32px; HEIGHT: 25px" type="button" value="..."
				onclick="ShowFramest('1',event);" class="btn">
			<asp:TextBox id="TxtIdStanza" Width="0px" runat="server" Height="0px"></asp:TextBox>&nbsp;
		</TD>
	</TR>
</TABLE>
<div id="PopupAppst" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; DISPLAY: none; BORDER-LEFT: #000000 1px solid; WIDTH: 480px; BORDER-BOTTOM: #000000 1px solid; POSITION: absolute; HEIGHT: 274px"><iframe id="docstanza" style="WIDTH: 105.64%; HEIGHT: 272px" name="docstanza" src="" frameBorder="no"
		width="100%" scrolling="auto"> </iframe>
</div>
