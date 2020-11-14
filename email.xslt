<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output indent="yes" omit-xml-declaration="yes" method="xml"/>
    <xsl:template match="data">
     
		<HTML><HEAD>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1"></META>
		<META content="MSHTML 6.00.2900.2627" name="GENERATOR"></META>
		<STYLE>
		</STYLE>
		</HEAD>
		<BODY bgColor="#ffffff">
		<DIV><FONT face="Arial" size="2">
		 Gentile <xsl:value-of select="name" />, 
         la informiamo che la richiesta di intervento per l'Edificio di <xsl:value-of select="codedi" /> è stata <xsl:value-of select="surname" /> da parte <xsl:value-of select="responsabile" />.
         <br/>
         Richesta numero: <b><xsl:value-of select="idrichiesta" /></b>.<br/>
         Descrizione del problema: <xsl:value-of select="descrizione" />
         <!--
         <br/>  
         Per ulteriori informazioni <a href="http://martino.cofasir.it">http://martino.cofasir.it</a>
         <br/>-->
         Distinti Saluti.
		</FONT></DIV></BODY></HTML>
    </xsl:template>
</xsl:stylesheet>
  