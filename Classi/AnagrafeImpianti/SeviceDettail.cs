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

namespace TheSite.Classi.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per SeviceDettail.
	/// Classe usata dalla Form ServiceDettail.aspx
	/// </summary>
	public class SeviceDettail  : AbstractBase
	{
		private string username=string.Empty;

		public SeviceDettail(string Username)
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

		/// <summary>
		/// DataSet con i record selezionati in base alla collection
		/// </summary>
		/// <param name="CollezioneCOntrolli"></param>
		/// <param name="NomeProcedura"></param>
		/// <returns></returns>
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			return null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public override DataSet GetSingleData(int itemId)

		{	
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_Bl_Id = new S_Object();
			s_Bl_Id.ParameterName = "p_Bl_Id";
			s_Bl_Id.DbType = CustomDBType.Integer;
			s_Bl_Id.Direction = ParameterDirection.Input;
			s_Bl_Id.Index = 0;
			s_Bl_Id.Value =	itemId;
			CollezioneControlli.Add(s_Bl_Id);

			return ExecuteStore(CollezioneControlli,"SP_GETDETTAILEDIFICIO");
		}

		public DataSet GetDiagnosiEnergetica(int itemId)
		{
			
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_Bl_Id = new S_Object();
			s_Bl_Id.ParameterName = "p_Bl_Id";
			s_Bl_Id.DbType = CustomDBType.Integer;
			s_Bl_Id.Direction = ParameterDirection.Input;
			s_Bl_Id.Index = 0;
			s_Bl_Id.Value =	itemId;
			CollezioneControlli.Add(s_Bl_Id);

			return ExecuteStore(CollezioneControlli,"SP_GETDIAGNOSIENERGETICA");	
		}

		public DataSet GetRicognizioneFotografica(int itemId)
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_Bl_Id = new S_Object();
			s_Bl_Id.ParameterName = "p_Bl_Id";
			s_Bl_Id.DbType = CustomDBType.Integer;
			s_Bl_Id.Direction = ParameterDirection.Input;
			s_Bl_Id.Index = 0;
			s_Bl_Id.Value =	itemId;
			CollezioneControlli.Add(s_Bl_Id);

			return ExecuteStore(CollezioneControlli,"SP_GETRICOGNIZIONEFOTOGRAFICA");
		}
		
		// MDG 14-03-2007 Aggiungo il parametro relativo al servizio 
		public DataSet GetElaboratiTecnici(int itemId, int id_sevizio)
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_Bl_Id = new S_Object();
			s_Bl_Id.ParameterName = "p_Bl_Id";
			s_Bl_Id.DbType = CustomDBType.Integer;
			s_Bl_Id.Direction = ParameterDirection.Input;
			s_Bl_Id.Index = 0;
			s_Bl_Id.Value =	itemId;
			CollezioneControlli.Add(s_Bl_Id);

			S_Controls.Collections.S_Object s_id_servizio = new S_Object();
			s_id_servizio.ParameterName = "p_id_servizio";
			s_id_servizio.DbType = CustomDBType.Integer;
			s_id_servizio.Direction = ParameterDirection.Input;
			s_id_servizio.Index =1;
			s_id_servizio.Value =	id_sevizio;
			CollezioneControlli.Add(s_id_servizio);

			return ExecuteStore(CollezioneControlli,"SP_GETELABORATITECNICI");	
		}

		public DataSet GetCertificazioni(int itemId)
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_Bl_Id = new S_Object();
			s_Bl_Id.ParameterName = "p_Bl_Id";
			s_Bl_Id.DbType = CustomDBType.Integer;
			s_Bl_Id.Direction = ParameterDirection.Input;
			s_Bl_Id.Index = 0;
			s_Bl_Id.Value =	itemId;
			CollezioneControlli.Add(s_Bl_Id);

			return ExecuteStore(CollezioneControlli,"SP_GETCERTIFICAZIONI");	
		}
		public DataSet GetApparecchiature(int itemId,int servizio_id)
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_Bl_Id = new S_Object();
			s_Bl_Id.ParameterName = "p_Bl_Id";
			s_Bl_Id.DbType = CustomDBType.Integer;
			s_Bl_Id.Direction = ParameterDirection.Input;
			s_Bl_Id.Index = 0;
			s_Bl_Id.Value =	itemId;
			CollezioneControlli.Add(s_Bl_Id);

			S_Controls.Collections.S_Object s_p_id_servizio = new S_Object();
			s_p_id_servizio.ParameterName = "p_id_servizio";
			s_p_id_servizio.DbType = CustomDBType.Integer;
			s_p_id_servizio.Direction = ParameterDirection.Input;
			s_p_id_servizio.Index = 1;
			s_p_id_servizio.Value =	servizio_id;
			CollezioneControlli.Add(s_p_id_servizio);

			return ExecuteStore(CollezioneControlli,"SP_GETAPPARECCHIATURA");	
		}

		private DataSet ExecuteStore(S_ControlsCollection CollezioneControlli, string NameStoreProcedure)
		{
			S_Controls.Collections.S_Object s_User = new S_Controls.Collections.S_Object();
			s_User.ParameterName = "p_Username";
			s_User.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_User.Direction = ParameterDirection.Input;
			s_User.Size=50; 
			s_User.Index = CollezioneControlli.Count +1;
			s_User.Value = this.username;
			CollezioneControlli.Add(s_User);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count +1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_EDIFICI." + NameStoreProcedure;
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

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
