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

namespace WebCad.Classi.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per ServiziEdifici.
	/// </summary>
	public class ServiziEdifici : AbstractBase
	{
		private string username;
		public ServiziEdifici(string Username)
		{
			username=Username;
		}
		/// <summary>
		/// DataSet con tutti i record
		/// </summary>
		/// <returns></returns>
		public override DataSet GetData()
		{					

			return new DataSet();		
		}
		public DataSet GetComune(int comune_id)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();
			S_Controls.Collections.S_Object s_p_comune_id = new S_Object();
			s_p_comune_id.ParameterName = "p_comune_id";
			s_p_comune_id.DbType = CustomDBType.Integer;
			s_p_comune_id.Direction = ParameterDirection.Input;
			s_p_comune_id.Index = CollezioneControlli.Count + 1;
			s_p_comune_id.Value =comune_id;
			CollezioneControlli.Add(s_p_comune_id);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_EDIFICI.GETCOMUNE";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		public DataSet GetComuneFrazione(int comune_id, int frazione_id)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();
			S_Controls.Collections.S_Object s_p_comune_id = new S_Object();
			s_p_comune_id.ParameterName = "p_comune_id";
			s_p_comune_id.DbType = CustomDBType.Integer;
			s_p_comune_id.Direction = ParameterDirection.Input;
			s_p_comune_id.Index = CollezioneControlli.Count + 1;
			s_p_comune_id.Value =comune_id;
			CollezioneControlli.Add(s_p_comune_id);

			S_Controls.Collections.S_Object s_p_frazione_id = new S_Object();
			s_p_frazione_id.ParameterName = "p_frazione_id";
			s_p_frazione_id.DbType = CustomDBType.Integer;
			s_p_frazione_id.Direction = ParameterDirection.Input;
			s_p_frazione_id.Index = CollezioneControlli.Count + 1;
			s_p_frazione_id.Value =frazione_id;
			CollezioneControlli.Add(s_p_frazione_id);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_EDIFICI.GETCOMUNEFRAZIONE";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		/// <summary>
		/// DataSet con i record selezionati in base alla collection
		/// </summary>
		/// <param name="CollezioneCOntrolli"></param>
		/// <param name="NomeProcedura"></param>
		/// <returns></returns>
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_User = new S_Controls.Collections.S_Object();
			s_User.ParameterName = "p_Username";
			s_User.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_User.Direction = ParameterDirection.Input;
			s_User.Size=50; 
			s_User.Index = CollezioneControlli.Count + 1;
			s_User.Value = this.username;
			CollezioneControlli.Add(s_User);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_EDIFICI.SP_GETEINFOEDIFICI";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}
		public  DataSet GetRicerca(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_RPT_GESTIONE_SPAZI.SP_GET_RICERCA";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public override DataSet GetSingleData(int itemId)

		{	
			DataSet _Ds;
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_Bl_Id = new S_Object();
			s_Bl_Id.ParameterName = "p_Bl_Id";
			s_Bl_Id.DbType = CustomDBType.Integer;
			s_Bl_Id.Direction = ParameterDirection.Input;
			s_Bl_Id.Index = 0;
			s_Bl_Id.Value =	itemId;
			CollezioneControlli.Add(s_Bl_Id);

			S_Controls.Collections.S_Object s_User = new S_Controls.Collections.S_Object();
			s_User.ParameterName = "p_Username";
			s_User.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_User.Direction = ParameterDirection.Input;
			s_User.Size=50; 
			s_User.Index = 1;
			s_User.Value = this.username;
			CollezioneControlli.Add(s_User);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 2;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_EDIFICI.SP_GETEINFOEDIFICIO";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}


		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			int i=0;
			return i;
		}		

		#endregion
	}
}
