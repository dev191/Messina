<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SelezioneQuery.ascx.cs" Inherits="GIC.Report.UserControl.SelezioneQuery" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<SCRIPT language="javascript">
	function ConfermaEliminazione(nome){
		if (confirm("eliminare l'item " + nome +"? ")){
			return true;
		} else {
			return false;
		}
	}
	
	function ApriAssUtenti(id,schema)
	{		
		url="AssociaUtenti.aspx?id="+id+"&schema="+schema;
		window.open(url,"popupVis","scrollbars=yes,resizable=yes,menubar=no,toolbar=no,location=no,status=yes,width=600,height=400");			
	}
</SCRIPT>
<DIV style="WIDTH: 300px">
	<TABLE id="Table1" width="300">
		<TR>
			<TD class="TableInt">Ricerca della Query</TD>
		</TR>
		<TR>
			<TD style="HEIGHT: 68px">
				<TABLE id="TableQuery" cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
					<TR>
						<TD class="TableInt" style="WIDTH: 92px">Titolo</TD>
						<TD class="TableInt"><CC1:S_TEXTBOX id="TextBox1" runat="server" width="168px" dbparametername="pDenominazione"></CC1:S_TEXTBOX></TD>
					</TR>
					<TR>
						<TD class="TableInt" style="WIDTH: 92px">Descrizione</TD>
						<TD class="TableInt"><CC1:S_TEXTBOX id="TextBox2" runat="server" width="168px" dbparametername="pDescrizione"></CC1:S_TEXTBOX></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
		<TR>
			<TD><ASP:BUTTON id="TxtSuchen" runat="server" text="Cerca" cssclass="btn"></ASP:BUTTON><ASP:BUTTON id="BtnNeu" runat="server" text="Nuova" cssclass="btn"></ASP:BUTTON>&nbsp;
				<ASP:BUTTON id="BtnIndietro" runat="server" text="Indietro" cssclass="btn"></ASP:BUTTON></TD>
		</TR>
	</TABLE>
	<ASP:LABEL id="LabelMessage" runat="server"></ASP:LABEL><BR>
	<asp:datagrid id=DataGridQuery runat="server" alternatingitemstyle-cssclass="DataGridAlternatingItemStyle" itemstyle-cssclass="DataGridItemStyle" headerstyle-cssclass="DataGridHeaderStyle" DataSource="<%# dataSetReport1.Query %>" datakeyfield="IdQuery" AutoGenerateColumns="False">
		<COLUMNS>
			<ASP:TEMPLATECOLUMN>
				<HEADERSTYLE width="2%"></HEADERSTYLE>
				<ITEMSTYLE horizontalalign="Center"></ITEMSTYLE>
				<ITEMTEMPLATE>
					<ASP:IMAGEBUTTON id="ImageUpdate" runat="server" imageurl="../../imgFunz/edit.gif" alternatetext="Associa lo schema agli utenti" commandname="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"IdQuery")+ "," + DataBinder.Eval(Container.DataItem,"denominazione") %>'>
					</ASP:IMAGEBUTTON>
				</ITEMTEMPLATE>
			</ASP:TEMPLATECOLUMN>
			<ASP:TEMPLATECOLUMN>
				<HEADERSTYLE width="2%"></HEADERSTYLE>
				<ITEMSTYLE horizontalalign="Center"></ITEMSTYLE>
				<ITEMTEMPLATE>
					<ASP:IMAGEBUTTON style="" id="ImageDelete" runat="server" commandname="Delete" alternatetext="Elimina l'elemento corrente"
						imageurl="../../imgFunz/cancel.gif"></ASP:IMAGEBUTTON>
				</ITEMTEMPLATE>
			</ASP:TEMPLATECOLUMN>
			<ASP:TEMPLATECOLUMN headertext="Nome">
				<ITEMTEMPLATE>
					<ASP:LinkButton id="lblDenominazione" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,  "denominazione")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,  "IdQuery")%>' OnClick="lbt_Click">
					</ASP:LinkButton>
				</ITEMTEMPLATE>
			</ASP:TEMPLATECOLUMN>
			<ASP:TEMPLATECOLUMN headertext="Descrizione">
				<ITEMTEMPLATE>
					<ASP:Label Runat="server" Text='<%#Convert.ToString(DataBinder.Eval(Container.DataItem, "descrizione")).Length>30?Convert.ToString(DataBinder.Eval(Container.DataItem, "descrizione")).Substring(0,27)+"...":DataBinder.Eval(Container.DataItem, "descrizione")%>' ID="Label1">
					</ASP:Label>
				</ITEMTEMPLATE>
			</ASP:TEMPLATECOLUMN>
			<ASP:TEMPLATECOLUMN headertext="username">
				<ITEMTEMPLATE>
					<ASP:Label Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "username")%>' ID="LabelUsername">
					</ASP:Label>
				</ITEMTEMPLATE>
			</ASP:TEMPLATECOLUMN>
		</COLUMNS>
	</asp:datagrid></DIV>
