<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CodiceStdApparecchiatura.ascx.cs" Inherits="TheSite.WebControls.CodiceStdApparecchiatura" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript">

</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD style="WIDTH: 15%"><SPAN>Cod. Std Apparecchiatura:</SPAN>
		</TD>
		<TD>
			<cc1:S_TextBox id="S_txtcodStdapparecchiatura" runat="server" Width="344px"></cc1:S_TextBox>&nbsp;
			<INPUT id="bt_codapparecchiatura" style="WIDTH: 32px; HEIGHT: 25px" type="button" value="..."
				onclick="ShowFrame2('1',event);" class="btn"> <INPUT id="hidCodStd" type="hidden" runat="server" NAME="hidCodStd">
		</TD>
	</TR>
</TABLE>
<div id="PopupApp" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; DISPLAY: none; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; POSITION: absolute"><iframe id="docStdapp" style="HEIGHT: 192px" name="docapp" src="" frameBorder="no" width="100%"
		scrolling="auto"> </iframe>
</div>
