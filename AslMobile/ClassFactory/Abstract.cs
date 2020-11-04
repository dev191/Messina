using System;
using System.Data;
using System.Data.OracleClient;  

namespace TheSite.AslMobile
{
	public enum ExecuteType
	{
		Insert ,
		Update ,
		Delete 		
	}

	/// <summary>
	/// Descrizione di riepilogo per Abstract.
	/// </summary>
	public abstract class Abstract 
	{
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
		/// <summary>
		/// Costruttore della classe che utilizza la stringa di connessione presente nel file web.config
		/// vece del file ConnectionString
		/// </summary>
		public Abstract()
		{
		}
        /// <summary>
        /// Costuttore della classe che accetta una nuova stringa di connessione non presa dal  Web.config
        /// </summary>
        /// <param name="ConnectionString"></param>
		public Abstract(string ConnectionString)
		{
	        s_ConnStr=ConnectionString;
		}
		/// <summary>
		/// Ritorna un DataSet Passando una collezione di parametri e il nome del Pack + il nome della Store Procedure
		/// </summary>
		/// <param name="CollectionParameter">Collezione dei Parametri (deve essere anche compreso il Parametro del Cursore).</param>
		/// <param name="StorProcedureName">Nome del Pack + Nome della Store Procedure</param>
		/// <returns></returns>
		public virtual DataSet GetData(OracleParameterCollection CollectionParameter, string StorProcedureName) 
		{ 
			OracleConnection  cn =new OracleConnection(s_ConnStr); 
			OracleCommand myCmd = new OracleCommand(StorProcedureName, cn);
			myCmd.CommandType = CommandType.StoredProcedure;
			OracleDataAdapter da = new OracleDataAdapter(myCmd);

			foreach (OracleParameter po in CollectionParameter) 
			{ 
				OracleParameter Param = new OracleParameter(po.ParameterName, po.OracleType, po.Size);
				Param.Direction = po.Direction;
				Param.Value = po.Value;
				myCmd.Parameters.Add(Param);
			} 
			DataSet ds = new DataSet(); 
			using (cn)
			{
				da.Fill(ds);
			}
			return ds; 
		}
		/// <summary>
		/// Ritorna un DataSet passandogli il Nome del Pack + il Nome della Store Procedure
		/// </summary>
		/// <param name="StorProcedureName"> Nome Pack + Nome Store Procedure</param>
		/// <param name="CursorName">Nome del Cursore nella Store Procedure</param>
		/// <returns></returns>
		public virtual DataSet GetData(string StorProcedureName,string CursorName) 
		{ 
			OracleConnection  cn =new OracleConnection(s_ConnStr); 
			OracleCommand myCmd = new OracleCommand(StorProcedureName, cn);
			myCmd.CommandType = CommandType.StoredProcedure;
			OracleDataAdapter da = new OracleDataAdapter(myCmd);
			OracleParameter Param = new OracleParameter(CursorName, OracleType.Cursor);
			Param.Direction = ParameterDirection.Output;
			myCmd.Parameters.Add(Param);
			DataSet ds = new DataSet(); 
			using (cn)
			{
				da.Fill(ds);
			}
			return ds; 
		}
		/// <summary>
		/// Ritorna un DataSet Passando il Nome del Parametro e il corrispettivo valore nel parametro id.
		/// </summary>
		/// <param name="ParameterName">Nome del Parametro nella Store Precedure</param>
		/// <param name="id">Valore del Parametro</param>
		/// <param name="CollectionParameter">Collezzione di altri Parametri</param>
		/// <param name="StorProcedureName">Nome Pack + Nome Store Procedure</param>
		/// <returns></returns>
		public virtual DataSet GetSingleData(string ParameterName, int id, OracleParameterCollection CollectionParameter, string StorProcedureName) 
		{ 
			//Creazione del Parametro id
			OracleParameter  PaId=new OracleParameter();
			PaId.ParameterName=ParameterName;
			PaId.OracleType=OracleType.Int32;
			PaId.Direction=ParameterDirection.Input;
			PaId.Value =id;
			CollectionParameter.Add(PaId);

			return GetData(CollectionParameter, StorProcedureName); 
		}
		/// <summary>
		/// Ritorna un DataSet Passando il Nome del Parametro e il corrispettivo valore nel parametro id.
		/// </summary>
		/// <param name="ParameterName">Nome del Parametro nella Store Precedure</param>
		/// <param name="id">Valore del Parametro</param>
		/// <param name="StorProcedureName">Nome Pack + Nome Store Procedure</param>
		/// <param name="CursorName">Nome del Cursore nella Store Procedure</param>
		/// <returns></returns>
		public virtual DataSet GetSingleData(string ParameterName, int id, string StorProcedureName, string CursorName) 
		{ 
			
            OracleParameterCollection Coll=new OracleParameterCollection();
			//Creazione del Parametro id
			OracleParameter  PaId=new OracleParameter();
			PaId.ParameterName=ParameterName;
			PaId.OracleType=OracleType.Int32;
			PaId.Direction=ParameterDirection.Input;
			PaId.Value =id;
			Coll.Add(PaId);

			//Creazione del Parametro Cursore
			OracleParameter Param = new OracleParameter(CursorName, OracleType.Cursor);
			Param.Direction = ParameterDirection.Output;
			Coll.Add(PaId);

            return GetData(Coll, StorProcedureName); 
			
		}

		/// <summary>
		/// Aggiunge un record e restituisce l'id
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public virtual int Add(OracleParameterCollection CollezioneControlli,string StorProcedureName)
		{
			return this.ExecuteUpdate(CollezioneControlli, ExecuteType.Insert,"", 0,StorProcedureName);
		}

		/// <summary>
		/// Modifica un record e restituisce l'id
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public virtual int Update(OracleParameterCollection CollezioneControlli, string ParameterName , int itemId,string StorProcedureName)
		{
			return this.ExecuteUpdate(CollezioneControlli, ExecuteType.Update,ParameterName, itemId, StorProcedureName);
		}

		/// <summary>
		/// Elimina un record e restituisce -1 se ok
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public virtual int Delete(OracleParameterCollection CollezioneControlli, string ParameterName, int itemId , string StorProcedureName)
		{
			return this.ExecuteUpdate(CollezioneControlli, ExecuteType.Delete,ParameterName, itemId,StorProcedureName);
		}

		protected virtual int ExecuteUpdate(OracleParameterCollection Coll, ExecuteType Operazione, string ParameterName, int itemId ,string StorProcedureName)
		{
			OracleConnection  cn =new OracleConnection(s_ConnStr); 
			OracleCommand cmd = new OracleCommand(StorProcedureName, cn);
			cmd.CommandType = CommandType.StoredProcedure;
			if(ParameterName!="")//Creazione del Parametro in caso di modifica o delete
			{
				//Creazione del Parametro id
				OracleParameter  PaId=new OracleParameter();
				PaId.ParameterName=ParameterName;
				PaId.OracleType=OracleType.Int32;
				PaId.Direction=ParameterDirection.Input;
				PaId.Value =itemId;
				Coll.Add(PaId);
			}
			foreach (OracleParameter po in Coll) 
			{ 
				OracleParameter Param = new OracleParameter(po.ParameterName, po.OracleType, po.Size);
				Param.Direction = po.Direction;
				Param.Value = po.Value;
				cmd.Parameters.Add(Param);
			} 
			try
			{
				using (cn)
				{
					cn.Open();
					cmd.ExecuteNonQuery();  			
					int RowsAffected = (int) cmd.Parameters[cmd.Parameters.Count-1].Value;
					cn.Close();				
					return RowsAffected;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
			 if (cn.State==ConnectionState.Open) cn.Close();  
			}
		}	

		public virtual DataTable ItemBlankDataSource (DataTable DataTableOrigine, string DataTextField, string DataValueFiled,
			string BlankText, string BlankValue)
		{
			DataTable _MyDt = DataTableOrigine.Clone();
			_MyDt.Columns[DataValueFiled].AllowDBNull = true;

			DataRow _DrBlank = _MyDt.NewRow();
			if (BlankValue != String.Empty)
				_DrBlank[DataValueFiled] = BlankValue;

			_DrBlank[DataTextField] = BlankText;

			_MyDt.Rows.Add(_DrBlank);

			foreach (DataRow _Dr in DataTableOrigine.Rows)
			{
				DataRow _DrNew= _MyDt.NewRow();
				_DrNew[DataValueFiled] = _Dr[DataValueFiled];
				_DrNew[DataTextField] = _Dr[DataTextField];

				_MyDt.Rows.Add(_DrNew);
			}

			return _MyDt;
		}

	}
}
