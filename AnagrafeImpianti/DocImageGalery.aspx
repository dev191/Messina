<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Page language="c#" Codebehind="DocImageGalery.aspx.cs" AutoEventWireup="false" Inherits="TheSite.AnagrafeImpianti.DocImageGalery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Gallery</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body  MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TBODY>
					<TR>
						<TD align="center">
							<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:DataList id="DataListImage" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
								<ItemTemplate>
									<table border="0">
										<tr>
											<td>
												<a href="" runat="server" id="imagefull"><img id="imgdoc" runat="server" src="" align="middle" border="0">
												</a>
											</td>
										</tr>
									</table>
								</ItemTemplate>
							</asp:DataList>
						</TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
