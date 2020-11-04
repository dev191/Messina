using System;



namespace TheSite.Classi.AnalisiStatistiche
{
	/// <summary>
	/// Descrizione di riepilogo per wrapDb.
	/// </summary>
	public class wrapDb : Classi.AbstractBase
	{
		private string _s_storedProcedureName;
		public wrapDb()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}

		public override int Add(S_Controls.Collections.S_ControlsCollection CollezioneControlli)
		{
			return base.Add (CollezioneControlli);
		}
		public override bool Equals(object obj)
		{
			return base.Equals (obj);
		}
		 public override System.Data.DataSet GetData()
		{
					return null;
		}
		public override System.Data.DataSet GetData(S_Controls.Collections.S_ControlsCollection CollezioneControlli)
		{
			
//			try
//			{
				
				//				
				System.Data.DataSet _DSet;
				ApplicationDataLayer.OracleDataLayer _OraDl = new ApplicationDataLayer.OracleDataLayer(s_ConnStr);	
			//	_DSet =  _OraDl.GetRows(CollezioneControlli, "PACK_ANALISI_STATISTICHE.GET_RDL_MESE_COMPLETATA").Copy();
			    _DSet =  _OraDl.GetRows(CollezioneControlli, _s_storedProcedureName).Copy();
				return _DSet;	
//			}
//			catch( System.Data.OracleClient.OracleException e) 
//			{
////				throw new Exception("ciao sono andrea e ti mando:" +  _DSet.Tables[0].Rows.Count.ToString());
//			
//				}
//			catch(Exception ex)
//			{
//				throw ex;
//			}
		}
		public override int Delete(S_Controls.Collections.S_ControlsCollection CollezioneControlli, int itemId)
		{
			return base.Delete (CollezioneControlli, itemId);
		}

		protected override int ExecuteUpdate(S_Controls.Collections.S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			return 0;
		}
		public override string GetFirstAndLastUser(System.Data.DataRow Data)
		{
			return base.GetFirstAndLastUser (Data);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}
		public override System.Data.DataSet GetSingleData(int itemId)
		{
			return null;
		}
		public override string ToString()
		{
			return base.ToString ();
		}
		public override int Update(S_Controls.Collections.S_ControlsCollection CollezioneControlli, int itemId)
		{
			return base.Update (CollezioneControlli, itemId);
		}

		/// <summary>
		/// Imposta il nome della stored procedure
		/// </summary>
		public string s_storedProcedureName
		{
			get
			{
				return null;
			}
			set
			{
				_s_storedProcedureName = value;
			}
		}
		



	}
}
