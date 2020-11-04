using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Data;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;

namespace TheSite.Classi.ManProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per InvioDocPmP.
	/// </summary>
	public class InvioDocPmP
	{
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
		public InvioDocPmP()
		{
		}

		public int GetIdProgetto(string Bl_id)
		{
			S_Controls.Collections.S_ControlsCollection control = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_bl_id = new S_Object();
			s_bl_id.ParameterName = "p_bl_id";
			s_bl_id.DbType = CustomDBType.VarChar;
			s_bl_id.Size=10;
			s_bl_id.Value=Bl_id;
			s_bl_id.Index = control.Count;
			control.Add(s_bl_id);

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = control.Count;
			control.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(control, "PACK_PIANI_APPROVATI.SP_GETIDPROGETTO");

			return i_Result;
		}

		public int IsValidStatus(int p_bl_id, int p_mese,int p_anno,int p_stato, string username)
		{
			S_Controls.Collections.S_ControlsCollection control = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_bl_id";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Value=p_bl_id;						
			control.Add(p);
			
			p = new S_Object();
			p.ParameterName = "p_mese";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Value=p_mese;						
			control.Add(p);

			p = new S_Object();
			p.ParameterName = "p_anno";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Value=p_anno;						
			control.Add(p);

			p = new S_Object();
			p.ParameterName = "p_stato";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Value=p_stato;						
			control.Add(p);

			p = new S_Object();
			p.ParameterName = "p_UserName";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Size=20;
			p.Value=username;						
			control.Add(p);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "p_IdOut";
			s_Cursor.DbType = CustomDBType.Integer;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = control.Count;
			control.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_PIANI_APPROVATI.SP_ISVALIDI";	
			int i_Result = _OraDl.GetRowsAffected(control,s_StrSql);

			return i_Result;
		}


		public DataSet GetEdifici(string username)
		{
			DataSet _Ds;
			S_Controls.Collections.S_ControlsCollection control = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_username";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Size=20;
			p.Value=username;						
			control.Add(p);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = control.Count;
			control.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_PIANI_APPROVATI.sp_getedifici";	
			_Ds = _OraDl.GetRows(control, s_StrSql).Copy();			

			return _Ds;
		}

		public DataSet GetDestinatari(int bl_id,bool Eseguito)
		{
			
			S_ControlsCollection _SColl = new S_ControlsCollection();
		
			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_id_bl";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Value = bl_id;
			_SColl.Add(p);

			p = new S_Object();
			p.ParameterName = "IO_CURSOR";
			p.DbType = CustomDBType.Cursor;
			p.Direction = ParameterDirection.Output;
			p.Index = _SColl.Count;
			_SColl.Add(p);

			string s_StrSql = "";
			if (Eseguito)
				s_StrSql ="PACK_PIANI_APPROVATI.SP_GETDESTINATARIESEGUITO";
			else
				s_StrSql ="PACK_PIANI_APPROVATI.SP_GETDESTINATARIPROPOSTO";

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr); 
			DataSet _Ds =  _OraDl.GetRows(_SColl, s_StrSql);

			return _Ds;
			
		}

		public int SaveAnni(S_ControlsCollection CollezioneControlli)
		{ 
			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_PIANI_APPROVATI.SP_EXECUTE_PianiAnnuali");

		  return i_Result;
		}
		public int SaveMesi(S_ControlsCollection CollezioneControlli)
		{
			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_PIANI_APPROVATI.SP_EXECUTE_PianiMensili");

			return i_Result;
		}
		public string GetMailByUser()
		{
			S_ControlsCollection CollezioneControlli =new S_ControlsCollection();
			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_UserName";
			s_IdOut.DbType = CustomDBType.VarChar;
			s_IdOut.Direction = ParameterDirection.Input;
			s_IdOut.Index = CollezioneControlli.Count;
			s_IdOut.Value =System.Web.HttpContext.Current.User.Identity.Name;    
			CollezioneControlli.Add(s_IdOut);

			s_IdOut = new S_Object();
			s_IdOut.ParameterName = "IO_CURSOR";
			s_IdOut.DbType = CustomDBType.Cursor;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			
			DataSet _Ds =  _OraDl.GetRows(CollezioneControlli, "PACK_PIANI_APPROVATI.SP_GETMAILBYUSER");
			if(_Ds.Tables[0].Rows.Count>0)
				return _Ds.Tables[0].Rows[0][0].ToString();
			else
				return "";
		}
	}
}
