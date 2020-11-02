<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="WebCad._Default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<HTML>
	<HEAD>
		<TITLE>Cad Viewer</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript">
		
		function ImpostaSrvDwf(IdServizio,planimetria,FromCreaRdl)
		{	
			if(FromCreaRdl != "")
			{
				opener.valorizzaServFromkCad(IdServizio,planimetria);
			}
		}
		</SCRIPT>
	</HEAD>
	<FRAMESET cols="213,78%" frameborder="0" border="1" framespacing="4">
		<frame name="leftcad" src="LeftFrame2.aspx<%=UrlParams%>" scrolling="auto" noresize style="BORDER-RIGHT: #ffff99 2px solid" >
		<FRAMESET rows="8%,69%,23%">
			<frame name=rtop 
				src="TopFrame.aspx<%=UrlParams%>" scrolling="no" noresize style="BORDER-BOTTOM: #ffff99 2px solid">
			<frame name=rbottom 
				src="CAD/CadViewer.aspx<%=UrlParams%>" scrolling="no">
			<frame name=rbottom2 
				src="bottomFrame.aspx<%=UrlParams%>" style="BORDER-TOP: #7777ff 2px solid">
			<NOFRAMES>
				<PRE id="p2">
================================================================
ISTRUZIONI PER IL COMPLETAMENTO DELLA PAGINA CON FRAME CON GERARCHIA NIDIFICATA
1. Aggiungere l'URL della pagina src="" per il frame "left".
2. Aggiungere l'URL della pagina src="" per il frame "rtop".
3. Aggiungere l'URL della pagina src="" per il frame "rbottom".
4. Aggiungere un elemento BASE target="rtop" al tag HEAD della 
	pagina "left", in modo da impostare "rtop" come frame predefinito   
	per la visualizzazione delle pagine a cui fanno riferimento i collegamenti. 
5. Aggiungere un elemento BASE target="rbottom" al tag HEAD della 
	pagina "rtop", in modo da impostare "rbottom" come frame predefinito   
	per la visualizzazione delle pagine a cui fanno riferimento i collegamenti. 
================================================================
</PRE>
				<P id="p1">
					Questa pagina HTML con frame visualizza più pagine Web. Per visualizzarla, è 
					necessario un browser che supporti HTML versione 4.0 o successiva.
				</P>
			</NOFRAMES>
		</FRAMESET>
	</FRAMESET>
</HTML>
