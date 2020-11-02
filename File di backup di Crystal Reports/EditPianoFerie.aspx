<%@ Page language="c#" Codebehind="EditPianoFerie.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditPianoFerie" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditRuoli</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
		<script language="javascript">	
		
		function Formatta(txt)
		{
			testo=document.getElementById(txt);
			if(testo.value.length==0)
				testo.value="00";
			if(testo.value.length==1)
				testo.value="0"+testo.value;		
		}
		
		
		function SoloNumeri()
		{	
			if (event.keyCode < 48	|| event.keyCode > 57){
				event.keyCode = 0;
			}	
		}
		function nonpaste()
		{
			return false;
		}	
		
		function Controlla(OraStart, MinStart, OraEnd, MinEnd)
		{
			var ora=parseInt(document.getElementById(OraStart).value);
			var minuti=parseInt(document.getElementById(MinStart).value);
			var ore=(document.getElementById(OraStart).value)+(document.getElementById(MinStart).value)
			
				if(ora<0 || ora>23)
				{ 

					alert("Attenzione l'ora deve essere compresa tra 01 e 23");		
					document.getElementById(OraStart).focus()
					return false;
				}	
				if(minuti<0 || minuti>59)
				{
					alert("Attenzione i minuti deve essere compresa tra 01 e 59");		
					document.getElementById(MinStart).focus();
					return false;
				}
				
				var ora1=parseInt(document.getElementById(OraEnd).value);
				var minuti1=parseInt(document.getElementById(MinEnd).value);
				var ore1=(document.getElementById(OraEnd).value) + document.getElementById(MinEnd).value;
							
				if(ora1<0 || ora1>23)
				{ 

					alert("Attenzione l'ora deve essere compresa tra 01 e 23");		
					document.getElementById(OraEnd).focus()
					return false;
				}	
				if(minuti1<0 || minuti1>59)
				{
					alert("Attenzione i minuti deve essere compresa tra 01 e 59");		
					document.getElementById(MinEnd).focus();
					return false;
				}
				if(ore>ore1)
				{
					alert("Attenzione l'ora fine turno non può essere minore di quella di inizio");		
					document.getElementById(OraEnd).focus();
					return false;
				}
				
				return true;
			
		}	
		</script>
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 100%"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" title="Gestione Ferie" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" height="95%">
						<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" align="center">
							<TR>
								<TD style="WIDTH: 5%; HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" CssClass="TitleOperazione"></asp:label>&nbsp;<MESSPANEL:MESSAGEPANEL id="PanelMess" runat="server" ErrorIconUrl="~/Images/ico_critical.gif" MessageIconUrl="~/Images/ico_info.gif"></MESSPANEL:MESSAGEPANEL></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:panel id="PanelEdit" runat="server">
										<TABLE id="tblSearch75" cellSpacing="1" cellPadding="2" border="0">
											<TR>
												<TD align="left">Nome</TD>
												<TD>
													<cc1:S_TextBox id="txtsNome" tabIndex="1" runat="server" DBDirection="Input" DBSize="128" DBParameterName="p_nome"
														DBIndex="1" width="90%" Enabled="False"></cc1:S_TextBox></TD>
											</TR>
											<TR>
												<TD align="left">Cognome</TD>
												<TD>
													<cc1:S_TextBox id="txtsCognome" tabIndex="2" runat="server" DBDirection="Input" DBSize="255" DBParameterName="p_cognome"
														DBIndex="0" Enabled="False" DBDataType="VarChar"></cc1:S_TextBox></TD>
											</TR>
											<TR>
												<TD align="left"></TD>
												<TD></TD>
											</TR>
										</TABLE>
									</asp:panel></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left">&nbsp;&nbsp;&nbsp;
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left">
									<TABLE id="tblGridTitle" cellSpacing="1" cellPadding="1" border="0">
										<TR>
											<TD width="20%"><asp:linkbutton id="lkbNuovo" runat="server" CssClass="NuovoLink">Nuovo</asp:linkbutton></TD>
											<TD width="60%"></TD>
											<TD align="center" width="20%">Record:
												<asp:label id="lblRecord" runat="server">0</asp:label></TD>
										</TR>
									</TABLE>
									<ASP:DATAGRID id="DataGridEsegui" runat="server" CssClass="DataGrid" OnDeleteCommand="jskDataGrid_Delete"
										OnEditCommand="jskDataGrid_Edit" OnCancelCommand="jskDataGrid_Cancel" OnUpdateCommand="jskDataGrid_Update"
										AutoGenerateColumns="False" DataKeyField="ID" BorderColor="Gray" ShowFooter="false">
										<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<ItemTemplate>
													<asp:ImageButton Title="Modifica" id="imbEdit" runat="server" ImageUrl="../Images/edit.gif" CommandName="Edit"></asp:ImageButton>
													<asp:ImageButton Title="Elimina" id="imbDelete" runat="server" ImageUrl="../Images/elimina.gif" CommandName="Delete"
														CausesValidation="False"></asp:ImageButton>
												</ItemTemplate>
												<FooterTemplate>
													<asp:ImageButton Title="Salva" id="Imagebutton1" runat="server" CommandName="Update" ImageUrl="../Images/salva.gif"></asp:ImageButton>
													<asp:ImageButton Title="Annulla" id="Imagebutton2" runat="server" CommandName="Cancel" ImageUrl="../Images/annulla.gif"></asp:ImageButton>
												</FooterTemplate>
												<EditItemTemplate>
													<asp:ImageButton Title="Salva" id="imbUpdate" runat="server" CommandName="Update" ImageUrl="../Images/salva.gif"></asp:ImageButton>
													<asp:ImageButton Title="Annulla" id="imbCancel" runat="server" CommandName="Cancel" ImageUrl="../Images/annulla.gif"></asp:ImageButton>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID">
												<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Data Inizio">
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "DATE_START") %>
												</ItemTemplate>
												<FooterTemplate>
													<uc1:CalendarPicker id="Calendar_DataStartNew" runat="server"></uc1:CalendarPicker>&nbsp;Ore
													<asp:TextBox id="TxtOraStartN" runat="server" Width="25px">00</asp:TextBox>:&nbsp;
													<asp:TextBox id="TxtMinStartN" runat="server" Width="25px">00</asp:TextBox>
												</FooterTemplate>
												<EditItemTemplate>
													<uc1:CalendarPicker id=Calendar_DataStartEdit runat="server" CalendarDate='<%# DataBinder.Eval(Container.DataItem, "DATE_START") %>'>
													</uc1:CalendarPicker>&nbsp;Ore
													<asp:TextBox id=TxtMinStartE runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DATE_START")).Hour.ToString().PadLeft(2,Convert.ToChar(0))%>' Width="25px">
													</asp:TextBox>:
													<asp:TextBox id=TxtOraStartE runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DATE_START")).Minute.ToString().PadLeft(2,Convert.ToChar(0))%>' Width="25px">
													</asp:TextBox>&nbsp;
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Data Fine">
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "DATE_END") %>
												</ItemTemplate>
												<FooterTemplate>
													<uc1:CalendarPicker id="Calendar_DataEndNew" runat="server"></uc1:CalendarPicker>&nbsp;Ore:
													<asp:TextBox id="TxtOraEndN" runat="server" Width="25px">00</asp:TextBox>:
													<asp:TextBox id="TxtMinEndN" runat="server" Width="25px">00</asp:TextBox>
												</FooterTemplate>
												<EditItemTemplate>
													<uc1:CalendarPicker id=Calendar_DataEndEdit runat="server" CalendarDate='<%# DataBinder.Eval(Container.DataItem, "DATE_END") %>'>
													</uc1:CalendarPicker>&nbsp;Ore :
													<asp:TextBox id=TxtMinEndE runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DATE_END")).Minute.ToString().PadLeft(2,Convert.ToChar(0))%>' Width="25px">
													</asp:TextBox>:
													<asp:TextBox id=TxtOraEndE runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DATE_END")).Hour.ToString().PadLeft(2,Convert.ToChar(0))%>' Width="25px">
													</asp:TextBox>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Motivo Assenza">
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "MOTIVO") %>
												</ItemTemplate>
												<FooterTemplate>
													<asp:DropDownList ID="cmbsMotivo_New" DataTextField="descrizione" DataValueField="id" DataSource="<%# loadMotivoAssenza()%>" Runat="server">
													</asp:DropDownList>
												</FooterTemplate>
												<EditItemTemplate>
													<asp:DropDownList ID="cmbsMotivo_Edit" DataTextField="descrizione" DataValueField="id" DataSource="<%# loadMotivoAssenza()%>" Runat="server" SelectedValue ='<%# GetPianoFerieID(Container.DataItem)%>'/>
												</EditItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</ASP:DATAGRID></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblMessaggi" runat="server" CssClass="LabelErrore"></asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:button CssClass="btn" id="btnsAnnulla" tabIndex="25" runat="server" CausesValidation="False"
										Text="Indietro"></asp:button></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 1%" vAlign="top" align="left">
									<hr noShade SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
								<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblFirstAndLast" runat="server"></asp:label>&nbsp;
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body><script language="javascript">parent.left.calcola();</script>
</HTML>
