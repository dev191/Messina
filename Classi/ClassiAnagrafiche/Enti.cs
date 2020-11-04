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

namespace TheSite.Classi.ClassiAnagrafiche
{
	/// <summary>
	/// Descrizione di riepilogo per Enti.
	/// </summary>
	public class Enti : AbstractBase
	{

		#region Dichiarazioni

		private string s_Name = string.Empty;

		#endregion

		public Enti()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
		//public Enti(int Id)	: this(Id, string.Empty) {}

//		public Enti(int Id, string Name) 
//		{
//			this.Id = Id;
//			this.Name = Name;
//		}


	#region Metodi Pubblici

		public override DataSet GetData()
		{			
			DataSet _Ds;
					
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "io_cursor";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 0;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ENTI.BindDescrizioni";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;				
		}
		
		
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ENTI.GETENTI";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}

		public override DataSet GetSingleData(int itemId)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "pIdEnti";
			s_Id.DbType = CustomDBType.Integer;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = 0;
			s_Id.Value = itemId;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "io_cursor";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SColl.Add(s_Id);
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ENTI.GetEntiById";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;		
		}

			
		public DataSet GetProvince()
		{
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
								
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ENTI.BindProvincie";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}

		public DataSet GetComuni(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;
			
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "io_cursor";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ENTI.BindComuni";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}


	#endregion

		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			int i_MaxParametri = CollezioneControlli.Count + 1;			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			int i_Result =0;
			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			switch(Operazione.ToString().ToUpper())
			{
				case "UPDATE":
					s_IdIn.ParameterName = "pId";
					s_IdIn.DbType = CustomDBType.Integer;
					s_IdIn.Direction = ParameterDirection.Input;
					s_IdIn.Index = i_MaxParametri;
					s_IdIn.Value = itemId;
					CollezioneControlli.Add(s_IdIn);

					s_CurrentUser.ParameterName = "pcurrentuser";
					s_CurrentUser.DbType = CustomDBType.VarChar;
					s_CurrentUser.Direction = ParameterDirection.Input;
					s_CurrentUser.Index = i_MaxParametri;
					s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;
					i_MaxParametri ++;
					CollezioneControlli.Add(s_CurrentUser);

					
					s_IdOut.ParameterName = "pOut";
					s_IdOut.DbType = CustomDBType.Integer;
					s_IdOut.Direction = ParameterDirection.Output;
					s_IdOut.Index = i_MaxParametri;
					CollezioneControlli.Add(s_IdOut);
					i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "pack_enti.UpdateEnti");
					break;
				case "DELETE":

					s_IdIn.ParameterName = "pId";
					s_IdIn.DbType = CustomDBType.Integer;
					s_IdIn.Direction = ParameterDirection.Input;
					s_IdIn.Index = i_MaxParametri;
					s_IdIn.Value = itemId;
					CollezioneControlli.Add(s_IdIn);

					s_IdOut.ParameterName = "pOut";
					s_IdOut.DbType = CustomDBType.Integer;
					s_IdOut.Direction = ParameterDirection.Output;
					s_IdOut.Index = i_MaxParametri;
					CollezioneControlli.Add(s_IdOut);
					i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "pack_enti.DeleteEnti");
					break;
				case "INSERT":

					s_CurrentUser.ParameterName = "pcurrentuser";
					s_CurrentUser.DbType = CustomDBType.VarChar;
					s_CurrentUser.Direction = ParameterDirection.Input;
					s_CurrentUser.Index = i_MaxParametri;
					s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;
					i_MaxParametri ++;
					CollezioneControlli.Add(s_CurrentUser);


					s_IdOut.ParameterName = "pOut";
					s_IdOut.DbType = CustomDBType.Integer;
					s_IdOut.Direction = ParameterDirection.Output;
					s_IdOut.Index = i_MaxParametri;
					CollezioneControlli.Add(s_IdOut);
					i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "pack_enti.InsertEnti");
					break;
			}
			return i_Result;
		}

		#endregion
	}
}
