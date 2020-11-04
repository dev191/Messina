<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="HelpApplication.Default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Default</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<frameset cols="18%,82%" border="0" frameSpacing="0" frameBorder="0">
		<frame name="left" scrolling="auto" noresize src='<%=LeftPage%>'>
		<FRAME name="rbottom" src='<%=DefaultPage%>'>
		<noframes>
			<pre id="p2">
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
</pre>
			<p id="p1">
				Questa pagina HTML con frame visualizza più pagine Web. Per visualizzarla, è 
				necessario un browser che supporti HTML versione 4.0 o successiva.
			</p>
		</noframes>
	</frameset>
</HTML>
