using System;
using System.Data;
using System.Data.OracleClient;
using ApplicationDataLayer;
 
namespace TheSite.AslMobile.Class
{
	/// <summary>
	/// Descrizione di riepilogo per ClassEdifici.
	/// </summary>
	public class ClassEdifici: Abstract
	{
		string UserName=string.Empty; 
		public ClassEdifici()
		{
		}
		public ClassEdifici(string username)
		{
			UserName=username;
		}
		public DataSet GetListaEdifici(string codedi)
		{
			OracleParameterCollection Coll= new OracleParameterCollection();

			OracleParameter  p_Bl_Id=new OracleParameter();
			p_Bl_Id.ParameterName="p_Bl_Id";
			p_Bl_Id.Size=50;
			p_Bl_Id.Direction=ParameterDirection.Input;
			p_Bl_Id.OracleType=OracleType.VarChar;
			p_Bl_Id.Value =codedi;
			Coll.Add(p_Bl_Id);		
			
			OracleParameter  p_id_comune=new OracleParameter();
			p_id_comune.ParameterName="p_id_comune";
			p_id_comune.Direction=ParameterDirection.Input;
			p_id_comune.OracleType=OracleType.Int32;
			p_id_comune.Value =0;
			Coll.Add(p_id_comune);	

			// 19-07-2005 Armando: aggiunto parametro frazione //
			OracleParameter  p_id_frazione=new OracleParameter();
			p_id_frazione.ParameterName="p_id_frazione";
			p_id_frazione.Direction=ParameterDirection.Input;
			p_id_frazione.OracleType=OracleType.Int32;
			p_id_frazione.Value =0;
			Coll.Add(p_id_frazione);	
			// Armando fine //


			OracleParameter  p_Username=new OracleParameter();
			p_Username.ParameterName="p_Username";
			p_Username.Size=50;
			p_Username.Direction=ParameterDirection.Input;
			p_Username.OracleType=OracleType.VarChar;
			p_Username.Value =this.UserName;
			Coll.Add(p_Username);
	
			OracleParameter  p_campus=new OracleParameter();
			p_campus.ParameterName="p_campus";
			p_campus.Size=128;
			p_campus.Direction=ParameterDirection.Input;
			p_campus.OracleType=OracleType.VarChar;
			p_campus.Value ="";
			Coll.Add(p_campus);

			//Creazione del Parametro Del Cursore
			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);

			DataSet _MyDs= base.GetData(Coll,"PACK_EDIFICI.SP_GETEDIFICILISTA");

            return _MyDs;
		}
		
		
	}
}
