using System;
using System.Web;
using System.Web.UI;
using System.Data;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;
using System.Web.Security;

namespace WebCad.Classi
{
	/// <summary>
	/// SiteModule
	/// </summary>
	public class SiteModule
	{	
		#region Dichiarazioni

		private int i_ModuleId = 0;
		private string s_ModuleSrc = null;
		private string s_ModuleTitle = null;
		private bool b_IsEditable = false;
		private bool b_IsPrintable = false;
		private bool b_IsDeletable = false;
		private string s_Link = null;
		private string s_HelpLink = null;
		private string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];						

		#endregion

		public SiteModule()	
		{
		
		}

		public SiteModule(int ModuleId)
		{
			i_ModuleId = ModuleId;
			if (i_ModuleId > 0)
				this.GetSetting();
		}

		public SiteModule(string MenuSRC)
		{
			s_ModuleSrc = MenuSRC.Trim();
			if (s_ModuleSrc.Trim() != "")
				this.GetSettingPage();

		}
				
		public void GetSettingPage()
		{			

			DataSet _Ds;

			System.Web.HttpContext context = System.Web.HttpContext.Current;
			if (context.Request.Cookies[FormsAuthentication.FormsCookieName]==null)
			{
				//			        context.Response.Redirect("../Default.aspx");
				//					return;
    
				// Invalidate roles token
				context.Response.Cookies[FormsAuthentication.FormsCookieName].Value = null;
				context.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = new System.DateTime(1999, 10, 12);
				context.Response.Cookies[FormsAuthentication.FormsCookieName].Path = "/";
    
				// Redirect user back to the Portal Home Page
				context.Response.Redirect(context.Request.ApplicationPath + "/Default.aspx");
				context.Response.End(); 
				Console.WriteLine("Entrato"); 
			}

			S_ControlsCollection _SCollection = new S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_lnk = new S_Object();
			s_lnk.ParameterName = "p_path";
			s_lnk.DbType = CustomDBType.VarChar;
			s_lnk.Direction = ParameterDirection.Input;
			s_lnk.Size = 255;
			s_lnk.Index = 0;
			s_lnk.Value=s_ModuleSrc;

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Size = 50;
			s_UserName.Index = 1;
			string s_User = string.Empty;

			if (context.User != null)
				s_User = context.User.Identity.Name;
			else
			{
				System.Web.Security.FormsAuthenticationTicket ticket = System.Web.Security.FormsAuthentication.Decrypt(context.Request.Cookies[FormsAuthentication.FormsCookieName].Value);

				s_User = ticket.Name;
			}
			s_UserName.Value = s_User;

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 2;

			_SCollection.Add(s_lnk);
			_SCollection.Add(s_UserName);
			_SCollection.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SITO.SP_GETSETTINGS_PAGE";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();

			if (_Ds.Tables[0].Rows.Count == 1 )
			{
				this.s_ModuleTitle = _Ds.Tables[0].Rows[0]["DESCRIZIONE"].ToString();
				decimal i_Modifica = (decimal) _Ds.Tables[0].Rows[0]["ISMODIFICA"];
				this.i_ModuleId=int.Parse(_Ds.Tables[0].Rows[0]["FUNZIONE_ID"].ToString());

				if (i_Modifica < 0)
					this.b_IsEditable = true;
				else
					this.b_IsEditable = false;

				decimal i_Stampa = (decimal) _Ds.Tables[0].Rows[0]["ISSTAMPA"];
				if (i_Stampa < 0)
					this.b_IsPrintable = true;
				else
					this.b_IsPrintable = false;

				decimal i_Cancella = (decimal) _Ds.Tables[0].Rows[0]["ISCANCELLAZIONE"];
				if (i_Cancella < 0)
					this.b_IsDeletable = true;
				else
					this.b_IsDeletable = false;

				if (_Ds.Tables[0].Rows[0]["LINK"] != DBNull.Value)
					this.s_Link = _Ds.Tables[0].Rows[0]["LINK"].ToString();
				if (_Ds.Tables[0].Rows[0]["LINK_HELP"] != DBNull.Value)
				this.s_HelpLink =System.Configuration.ConfigurationSettings.AppSettings["LinkHelp"]+ _Ds.Tables[0].Rows[0]["LINK_HELP"].ToString();
					//	this.s_HelpLink = _Ds.Tables[0].Rows[0]["LINK_HELP"].ToString();
			}
			
		}

		public void GetSetting()
		{
			

			if (this.ModuleId != 0)
			{
				DataSet _Ds;

				System.Web.HttpContext context = System.Web.HttpContext.Current;
				if (context.Request.Cookies[FormsAuthentication.FormsCookieName]==null)
				{
					//			        context.Response.Redirect("../Default.aspx");
					//					return;
      
					// Invalidate roles token
					context.Response.Cookies[FormsAuthentication.FormsCookieName].Value = null;
					context.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = new System.DateTime(1999, 10, 12);
					context.Response.Cookies[FormsAuthentication.FormsCookieName].Path = "/";
        
					// Redirect user back to the Portal Home Page
					context.Response.Redirect(context.Request.ApplicationPath + "/Default.aspx");
					context.Response.End(); 
					Console.WriteLine("Entrato"); 
				}

				S_ControlsCollection _SCollection = new S_ControlsCollection();
				
				S_Controls.Collections.S_Object s_FunzioneId = new S_Object();
				s_FunzioneId.ParameterName = "p_Funzione_Id";
				s_FunzioneId.DbType = CustomDBType.Integer;
				s_FunzioneId.Direction = ParameterDirection.Input;
				s_FunzioneId.Index = 0;
				s_FunzioneId.Value = this.ModuleId;

				S_Controls.Collections.S_Object s_UserName = new S_Object();
				s_UserName.ParameterName = "p_UserName";
				s_UserName.DbType = CustomDBType.VarChar;
				s_UserName.Direction = ParameterDirection.Input;
				s_UserName.Size = 50;
				s_UserName.Index = 1;
				string s_User = string.Empty;

				if (context.User != null)
					s_User = context.User.Identity.Name;
				else
				{
					System.Web.Security.FormsAuthenticationTicket ticket = System.Web.Security.FormsAuthentication.Decrypt(context.Request.Cookies[FormsAuthentication.FormsCookieName].Value);

					s_User = ticket.Name;
				}
				s_UserName.Value = s_User;

				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 2;

				_SCollection.Add(s_FunzioneId);
				_SCollection.Add(s_UserName);
				_SCollection.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_SITO.SP_GETSETTINGS";	
				_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();
	
				if (_Ds.Tables[0].Rows.Count == 1 )
				{
					this.s_ModuleTitle = _Ds.Tables[0].Rows[0]["DESCRIZIONE"].ToString();
					decimal i_Modifica = (decimal) _Ds.Tables[0].Rows[0]["ISMODIFICA"];
					
					if (i_Modifica < 0)
						this.b_IsEditable = true;
					else
						this.b_IsEditable = false;

					decimal i_Stampa = (decimal) _Ds.Tables[0].Rows[0]["ISSTAMPA"];
					if (i_Stampa < 0)
						this.b_IsPrintable = true;
					else
						this.b_IsPrintable = false;

					decimal i_Cancella = (decimal) _Ds.Tables[0].Rows[0]["ISCANCELLAZIONE"];
					if (i_Cancella < 0)
						this.b_IsDeletable = true;
					else
						this.b_IsDeletable = false;

					if (_Ds.Tables[0].Rows[0]["LINK"] != DBNull.Value)
						this.s_Link = _Ds.Tables[0].Rows[0]["LINK"].ToString();
					if (_Ds.Tables[0].Rows[0]["LINK_HELP"] != DBNull.Value)
						this.s_HelpLink =System.Configuration.ConfigurationSettings.AppSettings["LinkHelp"]+ _Ds.Tables[0].Rows[0]["LINK_HELP"].ToString();
						//this.s_HelpLink = _Ds.Tables[0].Rows[0]["LINK_HELP"].ToString();
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int ModuleId
		{
			get {return i_ModuleId;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string ModuleSrc
		{
			get {return s_ModuleSrc;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string ModuleTitle
		{
			get {return s_ModuleTitle;}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsEditable
		{
			get {return b_IsEditable;}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsPrintable
		{
			get {return b_IsPrintable;}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsDeletable
		{
			get {return b_IsDeletable;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Link
		{
			get {return s_Link;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string HelpLink
		{
			get {return s_HelpLink;}
		}
	}
}
