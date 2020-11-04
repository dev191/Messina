<%@ Page language="c#" Codebehind="Aggiona_WO.aspx.cs" AutoEventWireup="false" Inherits="TheSite.ManutenzioneProgrammata.Aggiona_WO" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Aggiornamento Ordini di lavoro</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TBODY>
					<TR>
						<TD align="left">
							<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></TD>
					</TR>
					<TR>
						<TD>
							<asp:Repeater id="RepeaterMaster" runat="server">
								<HeaderTemplate>
									<table id="tablellaMaster" width="100%">
								</HeaderTemplate>
								<ItemTemplate>
									<tr>
										<td>
											<b>Aggiornamento ordine di lavoro N.<%# DataBinder.Eval(Container.DataItem,"Key") %></b>
											<asp:Repeater id="RepeaterDettail" runat="server">
												<HeaderTemplate>
													<table  id="tablelladettail" border="1" width="100%" cellSpacing="0" cellPadding="0" style="TABLE-LAYOUT: auto; BORDER-COLLAPSE: collapse" >
														<tr bgcolor=Gray style="FONT-WEIGHT: bold; COLOR: white">
															<td width=15%>
																Richiesta di lavoro associata
															</td>
															<td width=15%>
																Data Richiesta
															</td>
															<td width=15%>
																Data Pianificata
															</td>
															<td width=25%>
																Attività
															</td>															
															<td width=15%>
																Vecchio Addetto
															</td>
															<td width=15%>
																Nuovo Addetto
															</td>
															<td width=15%>
																Stato
															</td>
														</tr>
												</HeaderTemplate>
												<ItemTemplate>
													<tr>
														<td><%# DataBinder.Eval(Container.DataItem,"wr_id") %>
														</td>
														<td><%# DataBinder.Eval(Container.DataItem,"Data_Richiesta", "{0:d}") %>
														</td>
														<td><%# DataBinder.Eval(Container.DataItem,"Data_Pianificata", "{0:d}") %>
														</td>
														<td><%# DataBinder.Eval(Container.DataItem,"Attivita") %>
														</td>														
														<td><%# DataBinder.Eval(Container.DataItem,"VecchioAddetto") %>
														</td>
														<td><%# DataBinder.Eval(Container.DataItem,"NuovoAddetto") %>
														</td>
														<td><%# DataBinder.Eval(Container.DataItem,"Stato") %>
														</td>
													</tr>
												</ItemTemplate>
												<AlternatingItemTemplate>
													<tr>
														<td bgcolor="whitesmoke"><%# DataBinder.Eval(Container.DataItem,"wr_id") %>
														</td>
														<td bgcolor="whitesmoke"><%# DataBinder.Eval(Container.DataItem,"Data_Richiesta", "{0:d}") %>
														</td>
														<td bgcolor="whitesmoke"><%# DataBinder.Eval(Container.DataItem,"Data_Pianificata", "{0:d}") %>
														</td>
														<td bgcolor="whitesmoke"><%# DataBinder.Eval(Container.DataItem,"Attivita") %>
														</td>														
														<td bgcolor="whitesmoke"><%# DataBinder.Eval(Container.DataItem,"VecchioAddetto") %>
														</td>
														<td bgcolor="whitesmoke"><%# DataBinder.Eval(Container.DataItem,"NuovoAddetto") %>
														</td>
														<td bgcolor="whitesmoke"><%# DataBinder.Eval(Container.DataItem,"Stato") %>
														</td>
													</tr>
												</AlternatingItemTemplate>
												<FooterTemplate>
			</TABLE>
			</FooterTemplate> </asp:Repeater> </td> </tr> </ItemTemplate>
			<FooterTemplate>
			</TABLE>
			</FooterTemplate>
			</asp:Repeater></TD></TR></TBODY></TABLE>
		</form>
	</body>
</HTML>
