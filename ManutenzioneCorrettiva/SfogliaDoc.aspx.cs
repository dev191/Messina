using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using MyCollection;
using System.IO;
using ICSharpCode;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;

namespace TheSite.ManutenzioneCorrettiva
{
	/// <summary>
	/// Descrizione di riepilogo per SfogliDoc.
	/// </summary>
	public class SfogliDoc : System.Web.UI.Page
	{
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_ComboBox cmbsTipoDoc;
		protected S_Controls.S_Button btnsRicerca;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected S_Controls.S_TextBox TxtWr_id;
		protected S_Controls.S_TextBox TxtCodice;
		protected S_Controls.S_TextBox TxtNomeDoc;
		protected S_Controls.S_TextBox txtUtente;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.GridTitle GridTitle1;	
		Classi.ManCorrettiva.Traccia_doc Traccia_doc = new TheSite.Classi.ManCorrettiva.Traccia_doc();						
		public static string HelpLink = string.Empty;
		public Classi.SiteModule _SiteModule;
		public static int FunId = 0;
		protected WebControls.PageTitle PageTitle1;
		CompletaRdl  _fp=null;
		MyCollection.clMyCollection _myColl = new MyCollection.clMyCollection();
		public MyCollection.clMyCollection _Contenitore
		{
			get {return _myColl;}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			string _mypage="./ManutenzioneCorrettiva/SfogliaDoc.aspx";			
			_SiteModule = new TheSite.Classi.SiteModule(_mypage);
			FunId = _SiteModule.ModuleId;

			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = "SFOGLIA TRACCIA DOCUMENTI";
			GridTitle1.hplsNuovo.Visible =false; 
		
			if(Context.Handler is TheSite.ManutenzioneCorrettiva.CompletaRdl)
			{
				_fp = (TheSite.ManutenzioneCorrettiva.CompletaRdl)Context.Handler;
				if (_fp!=null) 
				{						
					_myColl=_fp._Contenitore;
					_myColl.SetValues(this.Page.Controls);						
					Ricerca();
				}
			}
		}

		public DataSet Destinatari(int id_bl, int id_servizio, string tipo_doc)
		{
			return Traccia_doc.GetDestinatari(id_bl,id_servizio, tipo_doc);
			
		}

		#region Codice generato da Progettazione Web Form
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: questa chiamata è richiesta da Progettazione Web Form ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
			this.DataGridRicerca.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemCreated);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			DataGridRicerca.CurrentPageIndex=0;
			Ricerca();
		}
		private void Ricerca()
		{	
			
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
			int indice=_SCollection.Count;

			S_Controls.Collections.S_Object s_p_NOME_DOC = new S_Controls.Collections.S_Object();
			s_p_NOME_DOC.ParameterName = "p_NOME_DOC";
			s_p_NOME_DOC.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_NOME_DOC.Direction = ParameterDirection.Input;
			s_p_NOME_DOC.Index = indice;
			s_p_NOME_DOC.Size=50;
			s_p_NOME_DOC.Value =this.TxtNomeDoc.Text;		
			_SCollection.Add(s_p_NOME_DOC);

			S_Controls.Collections.S_Object s_p_DATA_INVIO = new S_Controls.Collections.S_Object();
			s_p_DATA_INVIO.ParameterName = "p_DATA_INVIO";
			s_p_DATA_INVIO.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DATA_INVIO.Direction = ParameterDirection.Input;
			s_p_DATA_INVIO.Index = indice;
			s_p_DATA_INVIO.Size= 10;
			s_p_DATA_INVIO.Value = (CalendarPicker1.Datazione.Text =="")? "":CalendarPicker1.Datazione.Text;  			
			_SCollection.Add(s_p_DATA_INVIO);

			S_Controls.Collections.S_Object s_p_USERS = new S_Controls.Collections.S_Object();
			s_p_USERS.ParameterName = "p_USERS";
			s_p_USERS.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_USERS.Direction = ParameterDirection.Input;
			s_p_USERS.Index =indice;
			s_p_USERS.Size=50;
			s_p_USERS.Value =this.txtUtente.Text;		
			_SCollection.Add(s_p_USERS);

			S_Controls.Collections.S_Object s_p_TIPO_DOC = new S_Controls.Collections.S_Object();
			s_p_TIPO_DOC.ParameterName = "p_TIPO_DOC";
			s_p_TIPO_DOC.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_TIPO_DOC.Direction = ParameterDirection.Input;
			s_p_TIPO_DOC.Index = indice;
			if(cmbsTipoDoc.SelectedValue.ToUpper() =="TUTTI")
			{
				s_p_TIPO_DOC.Value =DBNull.Value;
			}
			else
			{
				s_p_TIPO_DOC.Value =cmbsTipoDoc.SelectedValue;
			}
		
			_SCollection.Add(s_p_TIPO_DOC);

			S_Controls.Collections.S_Object s_p_CODICE = new S_Controls.Collections.S_Object();
			s_p_CODICE.ParameterName = "p_CODICE";
			s_p_CODICE.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_CODICE.Direction = ParameterDirection.Input;
			s_p_CODICE.Index =indice;
			s_p_CODICE.Size=50;
			s_p_CODICE.Value =this.TxtCodice.Text;		
			_SCollection.Add(s_p_CODICE);

			S_Controls.Collections.S_Object s_p_ID_WR = new S_Controls.Collections.S_Object();
			s_p_ID_WR.ParameterName = "p_ID_WR";
			s_p_ID_WR.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_ID_WR.Direction = ParameterDirection.Input;
			s_p_ID_WR.Index = indice;
			s_p_ID_WR.Size=50;
			s_p_ID_WR.Value = (this.TxtWr_id.Text=="")?0:Int32.Parse(this.TxtWr_id.Text);		
			_SCollection.Add(s_p_ID_WR);

			S_Controls.Collections.S_Object s_p_ID_BL = new S_Controls.Collections.S_Object();
			s_p_ID_BL.ParameterName = "p_ID_BL";
			s_p_ID_BL.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_ID_BL.Direction = ParameterDirection.Input;
			s_p_ID_BL.Size =50;
			s_p_ID_BL.Index = indice;
			s_p_ID_BL.Value = (this.RicercaModulo1._txthidbl.Value=="")?0:Int32.Parse(this.RicercaModulo1._txthidbl.Value);
			_SCollection.Add(s_p_ID_BL);
		    

			S_Controls.Collections.S_Object p_prog = new S_Controls.Collections.S_Object();
			p_prog.ParameterName = "p_progetto";
			p_prog.DbType =CustomDBType.Integer;
			p_prog.Direction = ParameterDirection.Input;
			p_prog.Index = indice;
			p_prog.Size= 10;
			string Progetto="";
			if(Request["VarApp"]!=null)
				Progetto = Request["VarApp"];
			if (Progetto=="")
				p_prog.Value=0;
			else
				p_prog.Value = int.Parse(Progetto);  			
			_SCollection.Add(p_prog);

			S_Controls.Collections.S_Object p_user = new S_Controls.Collections.S_Object();
			p_user.ParameterName = "p_username";
			p_user.DbType =CustomDBType.VarChar;
			p_user.Direction = ParameterDirection.Input;
			p_user.Index = indice;
			p_user.Size= 30;
			p_user.Value=HttpContext.Current.User.Identity.Name;
			_SCollection.Add(p_user);

			Double _totalPages = 1;		
	
			int _totalRecords = Traccia_doc.GetCount(_SCollection);
			this.GridTitle1.NumeroRecords=_totalRecords.ToString();
			if ((_totalRecords % DataGridRicerca.PageSize) == 0)
				_totalPages = _totalRecords / DataGridRicerca.PageSize;
			else
				_totalPages = (_totalRecords / DataGridRicerca.PageSize)+1;
			
			this.DataGridRicerca.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);
			
		
			if (int.Parse(this.GridTitle1.NumeroRecords) ==0) 
			{
				DataGridRicerca.CurrentPageIndex=0;
				GridTitle1.DescriptionTitle="Nessun dato trovato."; 
			}
			else
			{
				GridTitle1.DescriptionTitle=""; 
			}


			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = indice;
			s_p_pageindex.Value=DataGridRicerca.CurrentPageIndex+1;			
			_SCollection.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = indice;
			s_p_pagesize.Value= DataGridRicerca.PageSize;			
			_SCollection.Add(s_p_pagesize);

			DataSet _MyDs = Traccia_doc.GetSfoglia(_SCollection).Copy();		

		
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			
			this.DataGridRicerca.DataBind();	
			

		}

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			string varapp="";
			if(Request["VarApp"]!=null)
				varapp="&VarApp=" + Request["VarApp"];
			Response.Redirect("SfogliaDoc.aspx?Fun=" + ViewState["FunId"] + varapp);
		
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			Ricerca();
		}

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Download")
			{
				string[] param;
				string [] bl;
				string file=""; 
			    string[] filename;
				string filedownload ="";
				if (e.Item.Cells[7].Text=="SGA" || e.Item.Cells[7].Text=="DIE")
				{
					param=e.CommandArgument.ToString().Split(',');
					bl=param[1].Split(' ');
					file= Server.MapPath("../Doc_DB")+"\\"+ bl[1]+ "\\" + param[0] + "\\" + param[1];
					filename=Path.GetFileName(file).Split(' ');
					filedownload =Server.MapPath("../Doc_DB")+"\\"+filename[1] + "\\" + param[0] + "\\" + filename[0] + " " + filename[1] + " " + filename[2]  +".rtf";
					Response.Clear();
					Response.ContentType = "application/rtf";
					
					if(File.Exists(filedownload)) 
						File.Delete(filedownload); 

					File.Copy(file,filedownload);
				}
				else
				{
					filedownload= Server.MapPath("../Doc_DB")+"\\"+ e.Item.Cells[3].Text.Trim()  + "\\" +e.Item.Cells[6].Text.Trim();
					filedownload=filedownload.Replace(".xls",".zip");
					Response.Clear();
					Response.ContentType = "application/zip";
				}
			
				
				Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileName(filedownload));
                Response.WriteFile(filedownload);
				Response.End();
			}

			if (e.CommandName=="Invio")
			{			
				string[] param;
				string [] bl;
				string file=""; 
				string[] filename;
				string filedownload ="";
				if (e.Item.Cells[7].Text=="SGA" || e.Item.Cells[7].Text=="DIE")
				{
					param=e.CommandArgument.ToString().Split(',');
					bl=param[1].Split(' ');
					file= Server.MapPath("../Doc_DB")+"\\"+ bl[1]+ "\\" + param[0] + "\\" + param[1];
					filename=Path.GetFileName(file).Split(' ');
					filedownload =Server.MapPath("../Doc_DB")+"\\"+filename[1] + "\\" + param[0] + "\\" + filename[0] + " " + filename[1] + " " + filename[2]  +".rtf";
					
					if(File.Exists(filedownload)) 
						File.Delete(filedownload); 
			
					File.Copy(file,filedownload);
					
				}
				else
				{
					param=e.CommandArgument.ToString().Split(',');
					filedownload= Server.MapPath("../Doc_DB")+"\\"+ e.Item.Cells[3].Text.Trim()  + "\\" +e.Item.Cells[6].Text.Trim();
				}
				
			

				TheSite.Classi.MailSend mail=new TheSite.Classi.MailSend();
				DocType TipoDc;
				if(e.Item.Cells[7].Text=="SGA")
					TipoDc=DocType.SGA;
				else if(e.Item.Cells[7].Text=="DIE") 
					TipoDc=DocType.DIE;
				else 
					TipoDc=DocType.XLS;

				string FileZip ="";

				if(TipoDc==DocType.XLS)
				{
					FileZip = filedownload;
				}
				else
				{
					FileZip = Path.GetDirectoryName(filedownload) + @"\" + Path.GetFileNameWithoutExtension(filedownload) + ".zip";
		
					if (File.Exists(FileZip))
						File.Delete(FileZip);

					ZipOutputStream s = new ZipOutputStream(File.Create(FileZip)); 
					s.SetLevel(5); // 0 - store only to 9 - means best compression 
					FileStream fs = File.OpenRead(filedownload); 
					byte[] buffer = new byte[fs.Length]; 
					fs.Read(buffer, 0, buffer.Length); 
					ZipEntry entry = new ZipEntry(Path.GetFileName(filedownload)); 
					s.PutNextEntry(entry); 
					s.Write(buffer, 0, buffer.Length); 
					s.Finish(); 
					s.Close(); 
					fs.Close();
				}
				if (e.Item.Cells[7].Text=="SGA" || e.Item.Cells[7].Text=="DIE")
					mail.SendMail(FileZip,int.Parse(param[0]),TipoDc);
				else
					mail.SendMailXls(FileZip,TipoDc,Convert.ToInt32(e.Item.Cells[10].Text));

			}
		}

		private void DataGridRicerca_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				ImageButton _myButton = (ImageButton)e.Item.FindControl("btSend");
				_myButton.Attributes.Add("onclick", "return confirm('Reinvio del documento selezionato?');");

				((ImageButton)e.Item.FindControl("btScarica")).ImageUrl ="../images/w.gif";				
			}
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				string[] filename;
				if (e.Item.Cells[7].Text=="SGA" || e.Item.Cells[7].Text=="DIE")
				{
					filename=e.Item.Cells[6].Text.Split(' ');
					e.Item.Cells[6].Text=filename[0] + " " + filename[1]  + " " + filename[2] + ".rtf";
				}
				if(e.Item.Cells[7].Text =="XLS")
					((ImageButton)e.Item.FindControl("btScarica")).ImageUrl ="../images/Excel.gif";				
			}
		}

	}
}
