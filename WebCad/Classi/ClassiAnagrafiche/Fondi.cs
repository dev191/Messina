using System;
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

namespace WebCad.Classi.ClassiAnagrafiche
{
	/// <summary>
	/// Descrizione di riepilogo per Ditte.
	/// </summary>
	
	public class Fondi : AbstractBase
	{
		#region Dichiarazioni

		private string s_Name = string.Empty;

		#endregion
		public Fondi()	{}

		public Fondi(int Id)	: this(Id, string.Empty) {}

		public Fondi(int Id, string Name) 
		{
			this.Id = Id;
			this.Name = Name;
		}

		#region Metodi Pubblici

			
			
		/// <summary>
		/// DataSet con tutti i record
		/// </summary>
		/// <returns></returns>
		public override DataSet GetData()
		{
			return null;				
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
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			
							
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MS.SP_GETFONDI";	
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

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_Fondo_Id";
			s_Id.DbType = CustomDBType.Integer;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = 0;
			s_Id.Value = itemId;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SColl.Add(s_Id);
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MS.SP_GETSINGLEFONDO";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;		
		}	

			
				
		/// <summary>
		/// 
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
			
		#endregion

		#region Proprietà Pubbliche


		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get {return s_Name;}
			set {s_Name = value;}
		}

		#endregion
	
		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			
			// ID
			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_ID";
			s_Id.DbType = CustomDBType.Integer;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = 0;
			s_Id.Value = itemId;			
			// TIPO OPERAZIONE
			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_Operazione";
			s_Operazione.DbType = CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index = 7;
			s_Operazione.Value = Operazione.ToString();
			// OUT
			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = 8;
				
			CollezioneControlli.Add(s_Id);				
			CollezioneControlli.Add(s_Operazione);
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MS.SP_EXECUTEFONDI");
				
			return i_Result;
		}

		#endregion
	}
}


