using System;
using System.Data;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using System.Configuration;
using ApplicationDataLayer.DBType;
namespace TheSite.GIC.Classi
{
	/// <summary>
	/// Fa il parsing della Vista e Inserisce i campi corrispondenti 
	/// nella tabella IL_Glossario
	/// </summary>
	public class ParsingViste
	{
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
		public ParsingViste()
		{
		}
	
		public int MakeParsing_old(string NomeVista,int IdVista)
		{
			DataTable dt = GetDatiVista(NomeVista);
			int LunghezzaVista = Convert.ToInt32(dt.Rows[0][1].ToString());
			string CorpoVista = dt.Rows[0][0].ToString();
			int tmp = CorpoVista.ToUpper().IndexOf("FROM");
			string PrimaF = CorpoVista.ToUpper().Substring(0,tmp);
			string SenzaSelec= PrimaF.Replace("SELECT","");
			string[] PrimaDelForm  = SenzaSelec.Split(',');
			System.Data.DataTable DatiGl = new DataTable("DatiGl");
			MakeTableDatiGl(DatiGl);
			DataRow row;
			string separatore = " AS ";
			for(int i=0;i<PrimaDelForm.Length;i++)
			{
				int LungezzaIthem = PrimaDelForm[i].Length;
				int indiceSeparatore = PrimaDelForm[i].IndexOf(separatore);
				string PrimaDiAs = PrimaDelForm[i].Substring(0,indiceSeparatore);
				string DopoAs = PrimaDelForm[i].Substring(indiceSeparatore + separatore.Length,LungezzaIthem - (indiceSeparatore + separatore.Length));
				string[] OrigineTabellaGrezza =  PrimaDiAs.Split('.');
				string TabellaGrezza = OrigineTabellaGrezza[0].Replace("/n","");
				string OrigineGrezza = OrigineTabellaGrezza[1].Replace("/n","");
				string AliasGrezzo =  DopoAs.Replace("/n","");
				TabellaGrezza = TabellaGrezza.Replace("/t","");
				OrigineGrezza = OrigineTabellaGrezza[1].Replace("/t","");
				AliasGrezzo =  DopoAs.Replace("/t","");
				string Tabella = TabellaGrezza.Trim();
				string Origine = OrigineGrezza.Trim();
				string Alis = AliasGrezzo.Trim();
				row = DatiGl.NewRow();
				row["TABELLA"] = Tabella;
				row["ORIGINE"] = Origine;
				row["ALIAS"] = Alis;
				row["ID_VISTA"] = IdVista;
				row["TIPODATO"]= GetTipoDato(Tabella,Origine);
				DatiGl.Rows.Add(row);
			}

			for( int i=0;i< DatiGl.Rows.Count; i++)
			{
				InsertGlossario(DatiGl.Rows[i]);
			}
			return 0;
		}
		
		public int MakeParsing(string NomeVista,int IdVista)
		{
			DataTable dt = GetSchemaVista(NomeVista);
			string Colonna;
			string TipoOracle;
			string tipo;
			for(int i=0;i<dt.Rows.Count;i++)
			{
				Colonna = dt.Rows[i][0].ToString();
				TipoOracle=dt.Rows[i][1].ToString();
				switch(TipoOracle)
				{
					case  "VARCHAR2" : 
						tipo= "T";
						break;
					case "CHAR" :
						tipo="T";
						break;
					case "DATE":
						tipo = "D";
						break;
					case "FLOAT":
						tipo = "N";
						break;
					case "LONG":
						tipo = "N";
						break;
					case "NUMBER" :
						tipo = "N";
						break;
					default :
						tipo="T";
						break;
				}

				InsertGlossario(Colonna,tipo,NomeVista,IdVista);				
			}
			return 0;
		}

		private int InsertGlossario(string Colonna, string tipo,string NomeVista,int IdVista)
		{

			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			S_ControlsCollection param=new S_ControlsCollection();

			S_Object pOrigine = new S_Object();
			pOrigine.ParameterName = "pOrigine";
			pOrigine.Direction = ParameterDirection.Input;
			pOrigine.DbType = CustomDBType.VarChar;
			pOrigine.Size = 32;
			pOrigine.Index=0;
			pOrigine.Value = Colonna;
			param.Add(pOrigine);

			S_Object pTabella = new S_Object();
			pTabella.ParameterName = "pTabella";
			pTabella.Direction=ParameterDirection.Input;
			pTabella.DbType = CustomDBType.VarChar;
			pTabella.Size = 32;
			pTabella.Index=1;
			pTabella.Value = NomeVista;
			param.Add(pTabella);

			S_Object pTipoDato = new S_Object();
			pTipoDato.ParameterName = "pTipoDato";
			pTipoDato.Direction=ParameterDirection.Input;
			pTipoDato.DbType = CustomDBType.VarChar;
			pTipoDato.Size = 32;
			pTipoDato.Index=2;
			pTipoDato.Value = tipo;
			param.Add(pTipoDato);

			S_Object pAlias = new S_Object();
			pAlias.ParameterName = "pAlias";
			pAlias.Direction=ParameterDirection.Input;
			pAlias.DbType = CustomDBType.VarChar;
			pAlias.Size = 32;
			pAlias.Index=3;
			pAlias.Value = Colonna;
			param.Add(pAlias);

			S_Object pIdVista = new S_Object();
			pIdVista.ParameterName = "pIdVista";
			pIdVista.Direction=ParameterDirection.Input;
			pIdVista.DbType = CustomDBType.VarChar;
			pIdVista.Size = 32;
			pIdVista.Index=4;
			pIdVista.Value = IdVista.ToString();
			param.Add(pIdVista);

			S_Object pOut = new S_Object();
			pOut.ParameterName = "pOut";
			pOut.Direction=ParameterDirection.Output;
			pOut.DbType = CustomDBType.Integer;
			pOut.Size = 32;
			pOut.Index=5;
			param.Add(pOut);

			int ret = _OraDl.GetRowsAffected(param,"IL_PACK_INTERROGAZIONI.InsertGlossario");
			return ret;
		}

		private int InsertGlossario(DataRow dr)
		{

			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			S_ControlsCollection param=new S_ControlsCollection();

			S_Object pOrigine = new S_Object();
			pOrigine.ParameterName = "pOrigine";
			pOrigine.Direction = ParameterDirection.Input;
			pOrigine.DbType = CustomDBType.VarChar;
			pOrigine.Size = 32;
			pOrigine.Index=0;
			pOrigine.Value = dr["ORIGINE"].ToString();
			param.Add(pOrigine);

			S_Object pTabella = new S_Object();
			pTabella.ParameterName = "pTabella";
			pTabella.Direction=ParameterDirection.Input;
			pTabella.DbType = CustomDBType.VarChar;
			pTabella.Size = 32;
			pTabella.Index=1;
			pTabella.Value = dr["TABELLA"].ToString();
			param.Add(pTabella);

			S_Object pTipoDato = new S_Object();
			pTipoDato.ParameterName = "pTipoDato";
			pTipoDato.Direction=ParameterDirection.Input;
			pTipoDato.DbType = CustomDBType.VarChar;
			pTipoDato.Size = 32;
			pTipoDato.Index=2;
			pTipoDato.Value = dr["TIPODATO"].ToString();
			param.Add(pTipoDato);

			S_Object pAlias = new S_Object();
			pAlias.ParameterName = "pAlias";
			pAlias.Direction=ParameterDirection.Input;
			pAlias.DbType = CustomDBType.VarChar;
			pAlias.Size = 32;
			pAlias.Index=3;
			pAlias.Value = dr["ALIAS"].ToString();
			param.Add(pAlias);

			S_Object pIdVista = new S_Object();
			pIdVista.ParameterName = "pIdVista";
			pIdVista.Direction=ParameterDirection.Input;
			pIdVista.DbType = CustomDBType.VarChar;
			pIdVista.Size = 32;
			pIdVista.Index=4;
			pIdVista.Value = dr["ID_VISTA"].ToString();
			param.Add(pIdVista);

			S_Object pOut = new S_Object();
			pOut.ParameterName = "pOut";
			pOut.Direction=ParameterDirection.Output;
			pOut.DbType = CustomDBType.Integer;
			pOut.Size = 32;
			pOut.Index=5;
			param.Add(pOut);

			int ret = _OraDl.GetRowsAffected(param,"IL_PACK_INTERROGAZIONI.InsertGlossario");
			return ret;
		}

		public int InsertSchemaUtenti(string Username,int IdSchema)
		{

			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			S_ControlsCollection param=new S_ControlsCollection();			
			
			
			S_Object PidSchema = new S_Object();
			PidSchema.ParameterName = "pIdSchema";
			PidSchema.Direction=ParameterDirection.Input;
			PidSchema.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			PidSchema.Size = 32;
			PidSchema.Index=0;
			PidSchema.Value = IdSchema;
			param.Add(PidSchema);

			S_Object pUsername = new S_Object();
			pUsername.ParameterName = "pUtente";
			pUsername.Direction=ParameterDirection.Input;
			pUsername.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			pUsername.Size = 50;
			pUsername.Index=1;
			pUsername.Value = Username;
			param.Add(pUsername);

			S_Object pOut = new S_Object();
			pOut.ParameterName = "pId";
			pOut.Direction=ParameterDirection.Output;
			pOut.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			pOut.Size = 32;
			pOut.Index=2;
			param.Add(pOut);

			int ret = _OraDl.GetRowsAffected(param,"IL_PACK_INTERROGAZIONI.IL_SpInsertSchemaUtenti");
			return ret;
		}
		
		public void DeleteSchemaUtenti(S_ControlsCollection CollezioneControlli)
		{
			ApplicationDataLayer.OracleDataLayer _OraDl;
			_OraDl = new OracleDataLayer(s_ConnStr);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "p_IdOut";
			s_Cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			s_Cursor.Value=DBNull.Value;
			s_Cursor.Size=32;			
			CollezioneControlli.Add(s_Cursor);
			int ret = _OraDl.GetRowsAffected(CollezioneControlli,"IL_PACK_INTERROGAZIONI.IL_SpDelSchemaUt");
		}


		private string GetTipoDato(string Tabella, string Origine)
		{
			string UserId = ConfigurationSettings.AppSettings["UserId"];
			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			S_ControlsCollection param=new S_ControlsCollection();

			S_Object Ppropprietario = new S_Object();
			Ppropprietario.ParameterName = "pOwner";
			Ppropprietario.Direction = ParameterDirection.Input;
			Ppropprietario.DbType = CustomDBType.VarChar;
			Ppropprietario.Size = 32;
			Ppropprietario.Index=0;
			Ppropprietario.Value = UserId;
			param.Add(Ppropprietario);

			S_Object pCampo = new S_Object();
			pCampo.ParameterName = "pCampo";
			pCampo.Direction=ParameterDirection.Input;
			pCampo.DbType = CustomDBType.VarChar;
			pCampo.Size = 32;
			pCampo.Index=1;
			pCampo.Value = Origine;
			param.Add(pCampo);

			S_Object pTabella = new S_Object();
			pTabella.ParameterName = "pTabella";
			pTabella.Direction=ParameterDirection.Input;
			pTabella.DbType = CustomDBType.VarChar;
			pTabella.Size = 32;
			pTabella.Index=2;
			pTabella.Value = Tabella;
			param.Add(pTabella);

			S_Object io_cursor = new S_Object();
			io_cursor.ParameterName = "io_cursor";
			io_cursor.Direction=ParameterDirection.Output;
			io_cursor.DbType = CustomDBType.Cursor;
			io_cursor.Index=3;
			param.Add(io_cursor);
			DataSet ds = _OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.GetTipoDato");
			string TipoOracle = Convert.ToString(ds.Tables[0].Rows[0][0]);
			string ret;
			switch(TipoOracle)
			{
				case  "VARCHAR2" : 
					ret= "T";
				break;
				case "CHAR" :
					ret="T";
				break;
				case "DATE":
					ret = "D";
				break;
				case "FLOAT":
					ret = "N";
				break;
				case "LONG":
					ret = "N";
				break;
				case "NUMBER" :
					ret = "N";
				break;
				default :
					ret="T";
				break;
			}
			return ret;
		}
		private int MakeTableDatiGl(DataTable table)
		{
			// Create a new DataTable.
			
			// Declare variables for DataColumn and DataRow objects.
			DataColumn column;
	

 
			// Create new DataColumn, set DataType, 
			// ColumnName and add to DataTable.    
			column = new DataColumn();
			column.DataType = System.Type.GetType("System.String");
			column.ColumnName = "ORIGINE";
			column.AutoIncrement = false;
			column.Caption = "TABELLA";
			column.ReadOnly = false;
			column.Unique = false;
			// Add the Column to the DataColumnCollection.
			table.Columns.Add(column);
 
			// Create second column.
			column = new DataColumn();
			column.DataType = System.Type.GetType("System.String");
			column.ColumnName = "TABELLA";
			column.AutoIncrement = false;
			column.Caption = "TABELLA";
			column.ReadOnly = false;
			column.Unique = false;
			// Add the column to the table.
			table.Columns.Add(column);
 
			column = new DataColumn();
			column.DataType = System.Type.GetType("System.String");
			column.ColumnName = "ALIAS";
			column.AutoIncrement = false;
			column.Caption = "ALIAS";
			column.ReadOnly = false;
			column.Unique = false;
			// Add the column to the table.
			table.Columns.Add(column);

			column = new DataColumn();
			column.DataType = System.Type.GetType("System.Int32");
			column.ColumnName = "ID_VISTA";
			column.AutoIncrement = false;
			column.Caption = "ID_VISTA";
			column.ReadOnly = false;
			column.Unique = false;
			// Add the column to the table.
			table.Columns.Add(column);


			column = new DataColumn();
			column.DataType = System.Type.GetType("System.String");
			column.ColumnName = "TIPODATO";
			column.AutoIncrement = false;
			column.Caption = "TIPODATO";
			column.ReadOnly = false;
			column.Unique = false;
			// Add the column to the table.
			table.Columns.Add(column);
			return 0;
			
		}
        
		public DataSet GetDataUtenti(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "IL_PACK_INTERROGAZIONI.SP_GETUTENTI_VISTE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}

		private DataTable GetDatiVista(string NomeVista)
		{
			string UserId = ConfigurationSettings.AppSettings["UserId"];
			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			S_ControlsCollection param=new S_ControlsCollection();

			S_Object Ppropprietario = new S_Object();
			Ppropprietario.ParameterName = "Ppropprietario";
			Ppropprietario.Direction = ParameterDirection.Input;
			Ppropprietario.DbType = CustomDBType.VarChar;
			Ppropprietario.Size = 32;
			Ppropprietario.Index=0;
			Ppropprietario.Value = UserId;
			param.Add(Ppropprietario);

			S_Object PNomeVista = new S_Object();
			PNomeVista.ParameterName = "PNomeVista";
			PNomeVista.Direction=ParameterDirection.Input;
			PNomeVista.DbType = CustomDBType.VarChar;
			PNomeVista.Size = 32;
			PNomeVista.Index=1;
			PNomeVista.Value = NomeVista;
			param.Add(PNomeVista);

			S_Object io_cursor = new S_Object();
			io_cursor.ParameterName = "io_cursor";
			io_cursor.Direction=ParameterDirection.Output;
			io_cursor.DbType = CustomDBType.Cursor;
			io_cursor.Index=2;
			param.Add(io_cursor);
			DataSet ds = _OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.GetBodyViste");
			return ds.Tables[0];
		}
		
		private DataTable GetSchemaVista(string NomeVista)
		{
			string UserId = ConfigurationSettings.AppSettings["UserId"];
			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			S_ControlsCollection param=new S_ControlsCollection();

			S_Object Ppropprietario = new S_Object();
			Ppropprietario.ParameterName = "pOwner";
			Ppropprietario.Direction = ParameterDirection.Input;
			Ppropprietario.DbType = CustomDBType.VarChar;
			Ppropprietario.Size = 32;
			Ppropprietario.Index=0;
			Ppropprietario.Value = UserId;
			param.Add(Ppropprietario);

			S_Object PNomeVista = new S_Object();
			PNomeVista.ParameterName = "pTabella";
			PNomeVista.Direction=ParameterDirection.Input;
			PNomeVista.DbType = CustomDBType.VarChar;
			PNomeVista.Size = 32;
			PNomeVista.Index=1;
			PNomeVista.Value = NomeVista.Trim();
			param.Add(PNomeVista);

			S_Object io_cursor = new S_Object();
			io_cursor.ParameterName = "io_cursor";
			io_cursor.Direction=ParameterDirection.Output;
			io_cursor.DbType = CustomDBType.Cursor;
			io_cursor.Index=2;
			param.Add(io_cursor);
			DataSet ds = _OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.GetSchema");
			return ds.Tables[0];
		}
	}

}
