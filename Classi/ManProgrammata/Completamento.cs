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
	/// Descrizione di riepilogo per ProcAndSteps.
	/// </summary>
	public class Completamento : AbstractBase
	{
		public string UserName;

		public Completamento(string UserName)
		{
			this.UserName= UserName;
		}

		public Completamento(){}
		

		#region Metodi Pubblici

		/// <summary>
		/// DataSet con tutti i record
		/// </summary>
		/// <returns></returns>
		

		/// <summary>
		/// 
		/// </summary>		

		public override DataSet GetData()
		{
			return null;
		}
		public override DataSet GetSingleData(int itemId)
		{
			DataSet _Ds;

			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_WO_ID = new S_Object();

			s_WO_ID.ParameterName = "p_Wo_Id";
			s_WO_ID.DbType = CustomDBType.Integer;
			s_WO_ID.Direction = ParameterDirection.Input;
			s_WO_ID.Index = 0;
			s_WO_ID.Size=4;
			s_WO_ID.Value=itemId;
			CollezioneControlli.Add(s_WO_ID);	
		
			// Tipo Manutenzione
			S_Controls.Collections.S_Object s_TipoManutenzione = new S_Object();

			s_TipoManutenzione.ParameterName = "p_TipoManutenzione";
			s_TipoManutenzione.DbType = CustomDBType.Integer;
			s_TipoManutenzione.Direction = ParameterDirection.Input;
			s_TipoManutenzione.Index = 1;
			s_TipoManutenzione.Size=4;
			s_TipoManutenzione.Value=Classi.TipoManutenzioneType.ManutenzioneProgrammata;						
			CollezioneControlli.Add(s_TipoManutenzione);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 2;
			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_PROG.GetSingleWO";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = 8;
			s_UserName.Size=50;
			s_UserName.Value=System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 9;
			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_PROG.GetCompletamento";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}

		public DataSet GetDatiWO(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;
			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_PROG.GetDatiWO";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}
		public DataSet GetDatiWR(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
//
//			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
//			s_Cursor.ParameterName = "IO_CURSOR";
//			s_Cursor.DbType = CustomDBType.Cursor;
//			s_Cursor.Direction = ParameterDirection.Output;
//			s_Cursor.Index = 1;
//			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_PROG.GetDatiWR";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}

		

		#endregion

		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			return 0;
		}

		#endregion
	}
}

