using System;
using System.Data;
using System.Data.OracleClient; 
using System.Web.UI.WebControls;

namespace TheSite.AslMobile.Class
{
	public enum TipoManutenzioneType
	{
		ManutenzionesuRichiesta=1,
		ManutenzioneProgrammata=2,
		ManutenzioneStraordinaria=3
	}
	public enum StateType
	{
		RichiestaInAttesaDiEmissione=1,
		AssegnatoOrdineLavoro=2,
		AccorpataInAltraRichiesta=3,
		AttivitaCompletata=4,
		EmessaComeStraordinaria=5,
		EmessaInLavorazione=6,
		RichiestaRifiutata=7,
		EmessaMaSospesa=8,
		AutorizzatoDalCliente=9,
		Approvata=10,
		EmessaMaSospesaPerInaccessibilita=11,
		EmessaMaSospesaPerApprovviggionamento=12,
		EmessaMaSospesaPerInterventoSpecialistico=13,
		EmessaMaSospesaDalCommittente=14,
		RichiestaSospesa=15,
		Archiviata=16
	}

	/// <summary>
	/// Descrizione di riepilogo per ClassFunction.
	/// </summary>
	public class ClassFunction: Abstract
	{
		public ClassFunction()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
		public DataSet GetIdBL(string bl_id)
		{
			string sql = "select bl.id as id from bl where bl.bl_id='" + bl_id + "'";
			OracleParameterCollection Coll= new OracleParameterCollection();
		
			OracleParameter s_p_sql = new OracleParameter();
			s_p_sql.ParameterName = "p_sql";
			s_p_sql.OracleType = OracleType.VarChar;
			s_p_sql.Direction = ParameterDirection.Input;
			s_p_sql.Size =2000;
			s_p_sql.Value = sql;
			Coll.Add(s_p_sql);



			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);

			DataSet _MyDs= base.GetData(Coll,"PACK_COMMON.SP_DYNAMIC_SELECT");
			return _MyDs;		
		}

	}
}
