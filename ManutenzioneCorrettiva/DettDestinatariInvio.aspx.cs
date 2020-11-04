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

namespace TheSite.ManutenzioneCorrettiva
{
	/// <summary>
	/// Summary description for DettDestinatariInvio.
	/// </summary>
	public class DettDestinatariInvio : System.Web.UI.Page
	{
	
		
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;	
		Classi.ManCorrettiva.Traccia_doc Traccia_doc = new TheSite.Classi.ManCorrettiva.Traccia_doc();						
		int wr_id;
		int bl_id;
		string Tipo_doc="";
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.GridTitle1.hplsNuovo.Visible=false;
	
			if(Request.QueryString["Wr_id"]!= "")
				wr_id= Convert.ToInt32(Request.QueryString["Wr_id"].ToString());
			if(Request.QueryString["tipo_doc"]!= "")
				Tipo_doc= Request.QueryString["tipo_doc"].ToString();
			if(Request.QueryString["bl_id"]!= "")
				bl_id= Convert.ToInt32(Request.QueryString["bl_id"].ToString());
			Ricerca();
			// Put user code to initialize the page here
		}
	private void Ricerca()
	{
		S_ControlsCollection _SCollection = new S_ControlsCollection();			
		

		S_Controls.Collections.S_Object s_p_NOME_DOC = new S_Controls.Collections.S_Object();
		s_p_NOME_DOC.ParameterName = "p_TIPO_DOC";
		s_p_NOME_DOC.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
		s_p_NOME_DOC.Direction = ParameterDirection.Input;
		s_p_NOME_DOC.Index =_SCollection.Count;
		s_p_NOME_DOC.Size=50;
		s_p_NOME_DOC.Value =Tipo_doc;		
		_SCollection.Add(s_p_NOME_DOC);

		S_Controls.Collections.S_Object s_p_ID_WR = new S_Controls.Collections.S_Object();
		s_p_ID_WR.ParameterName = "p_ID_WR";
		s_p_ID_WR.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
		s_p_ID_WR.Direction = ParameterDirection.Input;
		s_p_ID_WR.Index = _SCollection.Count;
		s_p_ID_WR.Size=50;
		s_p_ID_WR.Value = wr_id;		
		_SCollection.Add(s_p_ID_WR);

		S_Controls.Collections.S_Object s_p_ID_BL = new S_Controls.Collections.S_Object();
		s_p_ID_BL.ParameterName = "p_ID_BL";
		s_p_ID_BL.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
		s_p_ID_BL.Direction = ParameterDirection.Input;
		s_p_ID_BL.Index = _SCollection.Count;
		s_p_ID_BL.Size=50;
		s_p_ID_BL.Value = bl_id;		
		_SCollection.Add(s_p_ID_BL);

		DataSet _MyDs = Traccia_doc.GetDestinatariInvio(_SCollection).Copy();		

		this.GridTitle1.NumeroRecords=_MyDs.Tables[0].Rows.Count.ToString();
		this.DataGridRicerca.DataSource = _MyDs.Tables[0];
		this.DataGridRicerca.DataBind();
	}
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
