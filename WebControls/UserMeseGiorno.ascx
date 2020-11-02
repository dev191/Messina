<%@ Control Language="c#" AutoEventWireup="false" Codebehind="UserMeseGiorno.ascx.cs" Inherits="TheSite.WebControls.UserMeseGiorno" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<cc1:S_ComboBox id="cmbsMesi" runat="server">
	<asp:ListItem Value="1">Gennaio</asp:ListItem>
	<asp:ListItem Value="2">Febbraio</asp:ListItem>
	<asp:ListItem Value="3">Marzo</asp:ListItem>
	<asp:ListItem Value="4">Aprile</asp:ListItem>
	<asp:ListItem Value="5">Maggio</asp:ListItem>
	<asp:ListItem Value="6">Giugno</asp:ListItem>
	<asp:ListItem Value="7">Luglio</asp:ListItem>
	<asp:ListItem Value="8">Agosto</asp:ListItem>
	<asp:ListItem Value="9">Settembre</asp:ListItem>
	<asp:ListItem Value="10">Ottobre</asp:ListItem>
	<asp:ListItem Value="11">Novembre</asp:ListItem>
	<asp:ListItem Value="12">Dicembre</asp:ListItem>
</cc1:S_ComboBox>
<cc1:S_ComboBox id="cmbsGiorni" runat="server"></cc1:S_ComboBox>
