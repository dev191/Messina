using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;

	namespace TheSite.GIC.App_Code.Consultazioni
{
	/// <summary>
	/// Summary description for interogazioni.
	/// </summary>
		public class interogazioni 
		{
			private const string SELECT = " SELECT DISTINCT ";
			private const string FROM = " FROM ";
			private const string WHERE = " WHERE ";
			private const string AND = " AND ";
			private const string OR = " OR ";
			private const string ORDERBY = " ORDER BY ";
			private const string GROUPBY = " GROUP BY ";
			private const string HAVING = " HAVING ";
			private const string LIKE = "LIKE";
			private const string BETWEEN = "BETWEEN";
			//private const string VISTA = " IL_QRY_TOTALE ";
			private const string ORIGINE = "Descrizione_estesa";
			//private const string ORIGINE = "Origine";
			private const string TABELLA = "Tabella";
			private const string FUNZIONE = "Funzione";
			private const string VISIBILE = "Visibile";
			private const string ORDINAMENTO = "Ordinamento";
			private const string OPERATORE = "Operatore";
			private const string VALORE1 = "Valore1";
			private const string VALORE2 = "Valore2";
			private const string DESCRIZIONEESTESA = "Descrizione_estesa";
			private const string ALIAS = "Alias";
			private const string TIPODATO = "TipoDato";
			private string _VISTA;
			private int _IdVista;
			private string QueryFiltraUtente=string.Empty;
	
			protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
	
			public interogazioni()
			{

			}
			public DataSet GetData(int IdQuery)
			{
				string SSql = String.Empty;
				SSql = GetQuery(IdQuery);
				OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				S_ControlsCollection param=new S_ControlsCollection();

				S_Object pSqlStatement;
				pSqlStatement= new S_Object();
				pSqlStatement.ParameterName="pSqlStatement";
				pSqlStatement.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				pSqlStatement.Direction=ParameterDirection.Input;
				pSqlStatement.Value=SSql;
				pSqlStatement.Size=1000;
				pSqlStatement.Index=0;
				param.Add (pSqlStatement);

				S_Object io_cursor = new S_Object();
				io_cursor.ParameterName = "io_cursor";
				io_cursor.Direction=ParameterDirection.Output;
				io_cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
				io_cursor.Index=1;
				param.Add(io_cursor);

				try
				{
					DataSet ds = _OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.IL_SpGetDatiDn");
					return ds;
				} 
				catch (Exception ex)
				{
					throw new ApplicationException(ex.Message +"<br>"+SSql);
				}
			
			}
			private DataTable GetCriteriQuery(int IdSchema)
			{
				OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				S_ControlsCollection param=new S_ControlsCollection();

				S_Object pIdSchema;
				pIdSchema= new S_Object();
				pIdSchema.ParameterName="pIdSchema";
				pIdSchema.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				pIdSchema.Direction=ParameterDirection.Input;
				pIdSchema.Value=IdSchema;  
				pIdSchema.Size=1000;
				pIdSchema.Index=0;
				param.Add (pIdSchema);

				S_Object io_cursor = new S_Object();
				io_cursor.ParameterName = "io_cursor";
				io_cursor.Direction=ParameterDirection.Output;
				io_cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
				io_cursor.Index=1;
				param.Add(io_cursor);

				DataSet ds = _OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.IL_SpCriteriQuery");

				return ds.Tables[0];

			}
			private DataTable GetCriteriSelect(int IdSchema)
			{
				OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				S_ControlsCollection param=new S_ControlsCollection();

				S_Object pIdSchema;
				pIdSchema= new S_Object();
				pIdSchema.ParameterName="pIdSchema";
				pIdSchema.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				pIdSchema.Direction=ParameterDirection.Input;
				pIdSchema.Value=IdSchema;  
				pIdSchema.Size=32;
				pIdSchema.Index=0;
				param.Add (pIdSchema);

				S_Object io_cursor = new S_Object();
				io_cursor.ParameterName = "io_cursor";
				io_cursor.Direction=ParameterDirection.Output;
				io_cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
				io_cursor.Index=1;
				param.Add(io_cursor);

				DataSet ds = _OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.IL_CSELECT");

				return ds.Tables[0];
			}

			public string GetQuery(int IdSchema)
			{
				string Query = string.Empty;
				string QuerySelect, QueryWhere, QueryGroupBy, QueryHaving, QueryOrderBy;
				QuerySelect = CreaSelect(IdSchema);
				QueryWhere = CreaWhere(IdSchema);
				QueryGroupBy = CreaGroupBy(IdSchema);
				QueryHaving = CreaHaving(IdSchema);
				QueryOrderBy=CreaOrderBy(IdSchema);
				Query = QuerySelect + QueryWhere + QueryGroupBy + QueryHaving + QueryOrderBy ;
				return Query;
		    }	
			private bool TestOrderBay(DataTable dt)
			{
				bool ret = false;
				foreach (DataRow dr in dt.Rows)
				{
					if(dr[ORDINAMENTO].ToString()!=String.Empty)
					{
						ret = true;
					}
				}
				return ret;
			}
			private bool TestHaving(DataTable dt)
			{
				bool ret = false;
				foreach (DataRow dr in dt.Rows)
				{
					if(dr[FUNZIONE].ToString()!=String.Empty)
					{
						if(dr[OPERATORE].ToString() != String.Empty)
						{
							ret = true;
						}
					}
				}
				return ret;
			}
			private bool TestGroupBy(DataTable dt)
			{
				bool ret = false;
				bool allret = true;
				foreach (DataRow dr in dt.Rows)
				{
					if(dr["Aggregazione"].ToString()!="NESSUNO")
					{
						ret = true;
					} 
					else 
					{
						allret=false;
					}
				}
				return ret && (!allret);
			}
			private bool Test(DataRow dr, string NomeCampo)
			{
				bool ret=false;

				if(NomeCampo != VISIBILE)
				{
					if(dr[NomeCampo].ToString() != string.Empty)
					{
						ret= true;
					}
					else
					{
						ret=false;
					}
			
				}
				else
				{
					if(dr[NomeCampo].ToString() == "1")
					{
						ret= true;
					}
					else
					{
						ret=false;
					}
				}
				return ret;
			}
			private bool TestTipoDato(DataRow dr)
			{
				bool ret = false;
				if(dr[TIPODATO].ToString() == "D")
				{
					ret= true;
				}
				return ret;
			}
			private string asliasFunzione(string FunzioneAggregazione,string CAmpo)
			{
				string ret=string.Empty;
				int maxL=25;
				switch(FunzioneAggregazione)
				{
					case "COUNT":
						if (String.Concat("Conteggio " , CAmpo).Length>maxL)
							ret = " AS " + "\"" + String.Concat("Conteggio " , CAmpo).Substring(0,maxL) +"\"";
						else
							ret = " AS " + "\"Conteggio " + CAmpo +"\"";
						break;
					case "SUM":
						if (String.Concat("Somma " , CAmpo).Length>maxL)
							ret = " AS " + "\"" + String.Concat("Somma " , CAmpo).Substring(0,maxL) +"\"";
						else
							ret = " AS " + "\"Somma " + CAmpo+"\"";
						break;
					default:
						ret = String.Empty;
						break;
				}
				return ret;
			}
			private string CreaSelect(int IdSchema)
			{
				string Query = string.Empty;
				DataTable dt;
				dt= GetCriteriSelect(IdSchema);
				int j = 0;
				for(int i=0; i<dt.Rows.Count ; i++)
				{
					DataRow dr;
					dr = dt.Rows[i];
					if(Test(dr,VISIBILE))
					{
						if(Test(dr,FUNZIONE))
						{
							if(j==0)
							{
								Query = Query + dr[FUNZIONE].ToString() + " ( " + dr[ALIAS].ToString() + " ) "  + asliasFunzione(dr[FUNZIONE].ToString(),dr[ALIAS].ToString());
							}
							else
							{
								Query = Query + " , " + dr[FUNZIONE].ToString() + " ( " + dr[ALIAS].ToString() + " ) " + asliasFunzione(dr[FUNZIONE].ToString(),dr[ALIAS].ToString());
							}
							j++;
						}
						else
						{
							if(j==0)
							{
								Query = Query + dr[ALIAS].ToString();
							}
							else
							{
								Query = Query + " , " + dr[ALIAS].ToString();
							}
							j++;	
						}
				
					}
				}
				
				string utente = System.Web.HttpContext.Current.User.Identity.Name;
				
				if(Query != string.Empty)
				{
					Query =  SELECT + Query + FROM + _VISTA; 
					QueryFiltraUtente = " t,ruoli_edifici_servizi r ";
					QueryFiltraUtente+= "Where r.id_bl=t.idbl and r.servizio_id=t.idservizio ";
					QueryFiltraUtente+= "and r.ruolo_id in (select t.ruolo_id from utente_ruoli t where t.utente_id=";
					QueryFiltraUtente+=  "(select utente_id from utenti where upper(username)=upper('" + utente + "')))"; 					
				}

				return Query + QueryFiltraUtente;
			}
			private string CreaWhere( int IdSchema)
			{
				string Query = string.Empty;
				DataTable dtGl;
				dtGl= GetIdClossario(IdSchema);
				int NumeroCriteriSingoli = dtGl.Rows.Count;
				if (NumeroCriteriSingoli >0)
				{
					int IdGlossario = Convert.ToInt32(dtGl.Rows[0]["idglossario"]);
					DataTable dt = GetCriteriWhere(IdSchema,IdGlossario);
					int NumCampiMultipli = dt.Rows.Count;
					DataRow dr;
					dr = dt.Rows[0];
					Query = Query + AND + "(";
					Query = Query + dr[ALIAS].ToString() + " " + dr[OPERATORE].ToString();
					if(dr[TIPODATO].ToString() == "D")
					{
						if ( dr[OPERATORE].ToString().ToUpper() == BETWEEN )
						{
							Query = Query + " to_date( \'" + dr[VALORE1].ToString() + "\',\'dd/mm/yyyy\')" ;
							Query = Query + AND + " to_date(\'" + dr[VALORE2].ToString() + "\',\'dd/mm/yyyy\')" ;
						}
						else
						{
							Query = Query +" to_date(\'"+ dr[VALORE1].ToString()+"\',\'dd/mm/yyyy\')" ;
						}
					}
					else
					{
						if ( dr[OPERATORE].ToString().ToUpper() == BETWEEN )
						{
							Query = Query + " \'" + dr[VALORE1].ToString() + "\' ";
							Query = Query + AND + " '" + dr[VALORE2].ToString() + "\' ";
						}
						else if(dr[OPERATORE].ToString().ToUpper() == LIKE )
						{
							Query = Query + " '%"+ dr[VALORE1].ToString()+"%'" ;
						}
						else
						{
							Query = Query + "\'"+ dr[VALORE1].ToString()+"\'" ;
						}
					}
					// LA Parte in OR
					for(int i =1 ; i< NumCampiMultipli ; i++)
					{
						dr = dt.Rows[i];
						Query = Query + OR;
						Query = Query + dr[ALIAS].ToString() + dr[OPERATORE].ToString();
						if(dr[TIPODATO].ToString() == "D")
						{
							if ( dr[OPERATORE].ToString().ToUpper() == BETWEEN )
							{
								Query = Query + " to_date( \'" + dr[VALORE1].ToString() + "\',\'dd/mm/yyyy\')" ;
								Query = Query + AND + " to_date(\'" + dr[VALORE2].ToString() + "\',\'dd/mm/yyyy\')" ;
							}
							else
							{
								Query = Query +" to_date(\'"+ dr[VALORE1].ToString()+"\',\'dd/mm/yyyy\')" ;
							}
						}
						else
						{
							if ( dr[OPERATORE].ToString().ToUpper() == BETWEEN )
							{
								Query = Query + " \'" + dr[VALORE1].ToString() + "\' ";
								Query = Query + AND + " '" + dr[VALORE2].ToString() + "\' ";
							}
							else if(dr[OPERATORE].ToString().ToUpper() == LIKE )
							{
								Query = Query + " '%"+ dr[VALORE1].ToString()+"%'" ;
							}
							else
							{
								Query = Query + "\'"+ dr[VALORE1].ToString()+"\'" ;
							}
						}
						
					}
					Query = Query + ")";
				}
				//La Parte in And
				for(int k = 1; k<dtGl.Rows.Count; k++)
				{
					int IdGlossario = Convert.ToInt32(dtGl.Rows[k]["idglossario"]);
					DataTable dt = GetCriteriWhere(IdSchema,IdGlossario);
					int NumCampiMultipli = dt.Rows.Count;
					DataRow dr;
					dr = dt.Rows[0];
					Query = Query + AND + "(";
					Query = Query + dr[ALIAS].ToString() + " " + dr[OPERATORE].ToString();
					if(dr[TIPODATO].ToString() == "D")
					{
						if ( dr[OPERATORE].ToString().ToUpper() == BETWEEN )
						{
							Query = Query + " to_date( \'" + dr[VALORE1].ToString() + "\',\'dd/mm/yyyy\')" ;
							Query = Query + AND + " to_date(\'" + dr[VALORE2].ToString() + "\',\'dd/mm/yyyy\')" ;
						}
						else
						{
							Query = Query +" to_date(\'"+ dr[VALORE1].ToString()+"\',\'dd/mm/yyyy\')" ;
						}
					}
					else
					{
						if ( dr[OPERATORE].ToString().ToUpper() == BETWEEN )
						{
							Query = Query + " \'" + dr[VALORE1].ToString() + "\' ";
							Query = Query + AND + " '" + dr[VALORE2].ToString() + "\' ";
						}
						else if(dr[OPERATORE].ToString().ToUpper() == LIKE )
						{
							Query = Query + " '%"+ dr[VALORE1].ToString()+"%'" ;
						}
						else
						{
							Query = Query + "\'"+ dr[VALORE1].ToString()+"\'" ;
						}
					}
					// LA Parte in OR
					for(int i =1 ; i< NumCampiMultipli; i++)
					{
						dr = dt.Rows[i];
						Query = Query + OR;
						Query = Query + dr[ALIAS].ToString() + dr[OPERATORE].ToString();
						if(dr[TIPODATO].ToString() == "D")
						{
							if ( dr[OPERATORE].ToString().ToUpper() == BETWEEN )
							{
								Query = Query + " to_date( \'" + dr[VALORE1].ToString() + "\',\'dd/mm/yyyy\')" ;
								Query = Query + AND + " to_date(\'" + dr[VALORE2].ToString() + "\',\'dd/mm/yyyy\')" ;
							}
							else
							{
								Query = Query +" to_date(\'"+ dr[VALORE1].ToString()+"\',\'dd/mm/yyyy\')" ;
							}
						}
						else
						{
							if ( dr[OPERATORE].ToString().ToUpper() == BETWEEN )
							{
								Query = Query + " \'" + dr[VALORE1].ToString() + "\' ";
								Query = Query + AND + " '" + dr[VALORE2].ToString() + "\' ";
							}
							else if(dr[OPERATORE].ToString().ToUpper() == LIKE )
							{
								Query = Query + " '%"+ dr[VALORE1].ToString()+"%'" ;
							}
							else
							{
								Query = Query + "\'"+ dr[VALORE1].ToString()+"\'" ;
							}
						}
						
					}
					Query = Query + ")";
				}
				return Query;

			}

			private string CreaHaving( int IdSchema)
			{
				string Query = string.Empty;
				DataTable dtGl;
				dtGl= IlGlossarioHaving(IdSchema);
				int NumeroCriteriSingoli = dtGl.Rows.Count;
				if (NumeroCriteriSingoli >0)
				{
					int IdGlossario = Convert.ToInt32(dtGl.Rows[0]["idglossario"]);
					DataTable dt = GetILCGroupBay(IdSchema,IdGlossario);
					int NumCampiMultipli = dt.Rows.Count;
					DataRow dr;
					dr = dt.Rows[0];
					Query = Query + HAVING + "(";
					Query = Query + dr[FUNZIONE].ToString() + " ( " + dr[ALIAS].ToString() + " ) " + dr[OPERATORE].ToString();
						if ( dr[OPERATORE].ToString().ToUpper() == BETWEEN )
						{
							Query = Query + " \'" + dr[VALORE1].ToString() + "\' ";
							Query = Query + AND + " '" + dr[VALORE2].ToString() + "\' ";
						}
						else
						{
							Query = Query + "\'"+ dr[VALORE1].ToString()+"\'" ;
						}
					// LA Parte in OR
					for(int i =1 ; i< NumCampiMultipli; i++)
					{
						dr = dt.Rows[i];
						Query = Query + OR;
						Query = Query + dr[FUNZIONE].ToString() + " ( " + dr[ALIAS].ToString() + " ) " + dr[OPERATORE].ToString();
						if ( dr[OPERATORE].ToString().ToUpper() == BETWEEN )
						{
							Query = Query + " \'" + dr[VALORE1].ToString() + "\' ";
							Query = Query + AND + " '" + dr[VALORE2].ToString() + "\' ";
						}
						else
						{
							Query = Query + "\'"+ dr[VALORE1].ToString()+"\'" ;
						}
						
					}
					Query = Query + ")";
				}
				//La Parte in And
				for(int k = 1; k<dtGl.Rows.Count; k++)
				{
					int IdGlossario = Convert.ToInt32(dtGl.Rows[k]["idglossario"]);
					DataTable dt = GetCriteriWhere(IdSchema,IdGlossario);
					int NumCampiMultipli = dt.Rows.Count;
					DataRow dr;
					dr = dt.Rows[0];
					Query = Query + AND + "(";
					Query = Query + dr[FUNZIONE].ToString() + " ( " + dr[ALIAS].ToString() + " ) "+ dr[OPERATORE].ToString();
						if ( dr[OPERATORE].ToString().ToUpper() == BETWEEN )
						{
							Query = Query + " \'" + dr[VALORE1].ToString() + "\' ";
							Query = Query + AND + " '" + dr[VALORE2].ToString() + "\' ";
						}
						else
						{
							Query = Query + "\'"+ dr[VALORE1].ToString()+"\'" ;
						}
					// LA Parte in OR
					for(int i =1 ; i< NumCampiMultipli; i++)
					{
						dr = dt.Rows[i];
						Query = Query + OR;
						Query = Query + dr[FUNZIONE].ToString() + " ( " + dr[ALIAS].ToString() + " ) " + dr[OPERATORE].ToString();

							if ( dr[OPERATORE].ToString().ToUpper() == BETWEEN )
							{
								Query = Query + " \'" + dr[VALORE1].ToString() + "\' ";
								Query = Query + AND + " '" + dr[VALORE2].ToString() + "\' ";
							}
							else
							{
								Query = Query + "\'"+ dr[VALORE1].ToString()+"\'" ;
							}
						
					}
					Query = Query + ")";
				}
				return Query;
			}
			private string CreaGroupBy(int IdSchema)
			{
				string GB = GROUPBY + " ";
				DataTable dt = GetCampiQuery(IdSchema);
				if (TestGroupBy(dt))
				{int j=0;
					for(int i=0; i<dt.Rows.Count ; i++)
					{
						
						DataRow dr;
						dr = dt.Rows[i];
						if (Convert.ToString(dr["Aggregazione"])=="NESSUNO")
						{
							if (j==0)
								GB+=Convert.ToString(dr["ALIAS"]);
							else
								GB+=","+Convert.ToString(dr["ALIAS"]);

							j++;

						}
						
					}

					return GB;

				}
				else
				{
					return string.Empty;
				}
			}
			
			private string CreaOrderBy(int IdSchema)
			{
				string Order = ORDERBY + " ";
				DataTable dt = GetCampiOrderBy(IdSchema);				
				int j=0;
				for(int i=0; i<dt.Rows.Count ; i++)
				{					
					DataRow dr;
					dr = dt.Rows[i];
					if (j==0)
						Order+=Convert.ToString(dr["ALIAS"]) + " " + Convert.ToString(dr["ORDINAMENTO"]);
					else
						Order+=","+Convert.ToString(dr["ALIAS"]) + " " + Convert.ToString(dr["ORDINAMENTO"]);
					j++;
				}	
				if (j>0)
					return Order;
				else
					return String.Empty;
			}

		private DataTable GetCriteriWhere(int IdSchema, int IdGlossario)
		{
			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			S_ControlsCollection param=new S_ControlsCollection();

			S_Object pIdSchema;
			pIdSchema= new S_Object();
			pIdSchema.ParameterName="pIdSchema";
			pIdSchema.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			pIdSchema.Direction=ParameterDirection.Input;
			pIdSchema.Value=IdSchema;  
			pIdSchema.Size=32;
			pIdSchema.Index=0;
			param.Add (pIdSchema);

			S_Object pIdGlossario = new S_Object();
			pIdGlossario.ParameterName = "pIdGlossario";
			pIdGlossario.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			pIdGlossario.Direction=ParameterDirection.Input;
			pIdGlossario.Value=IdGlossario;  
			pIdGlossario.Size=32;
			pIdGlossario.Index=1;
			param.Add (pIdGlossario);

			S_Object io_cursor = new S_Object();
			io_cursor.ParameterName = "io_cursor";
			io_cursor.Direction=ParameterDirection.Output;
			io_cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
			io_cursor.Index=1;
			param.Add(io_cursor);

			DataSet ds = _OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.IL_CWhere");
			return ds.Tables[0];
		}

			private DataTable GetILCGroupBay(int IdSchema, int IdGlossario)
			{
				OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				S_ControlsCollection param=new S_ControlsCollection();

				S_Object pIdSchema;
				pIdSchema= new S_Object();
				pIdSchema.ParameterName="pIdSchema";
				pIdSchema.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				pIdSchema.Direction=ParameterDirection.Input;
				pIdSchema.Value=IdSchema;  
				pIdSchema.Size=32;
				pIdSchema.Index=0;
				param.Add (pIdSchema);

				S_Object pIdGlossario = new S_Object();
				pIdGlossario.ParameterName = "pIdGlossario";
				pIdGlossario.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				pIdGlossario.Direction=ParameterDirection.Input;
				pIdGlossario.Value=IdGlossario;  
				pIdGlossario.Size=32;
				pIdGlossario.Index=1;
				param.Add (pIdGlossario);

				S_Object io_cursor = new S_Object();
				io_cursor.ParameterName = "io_cursor";
				io_cursor.Direction=ParameterDirection.Output;
				io_cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
				io_cursor.Index=1;
				param.Add(io_cursor);

				DataSet ds = _OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.IL_CGroupBay");
				return ds.Tables[0];
			}
			private DataTable IlGlossarioHaving(int IdSchema)
			{
				OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				S_ControlsCollection param=new S_ControlsCollection();

				S_Object pIdSchema;
				pIdSchema= new S_Object();
				pIdSchema.ParameterName="pIdSchema";
				pIdSchema.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				pIdSchema.Direction=ParameterDirection.Input;
				pIdSchema.Value=IdSchema;  
				pIdSchema.Size=32;
				pIdSchema.Index=0;
				param.Add (pIdSchema);

				S_Object io_cursor = new S_Object();
				io_cursor.ParameterName = "io_cursor";
				io_cursor.Direction=ParameterDirection.Output;
				io_cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
				io_cursor.Index=2;
				param.Add(io_cursor);

				DataSet ds = _OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.IL_GLOSSARIO_HAVING");
				return ds.Tables[0];
			}


		private DataTable GetIdClossario(int IdSchema)
		{
			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			S_ControlsCollection param=new S_ControlsCollection();

			S_Object pIdSchema;
			pIdSchema= new S_Object();
			pIdSchema.ParameterName="pIdSchema";
			pIdSchema.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			pIdSchema.Direction=ParameterDirection.Input;
			pIdSchema.Value=IdSchema;  
			pIdSchema.Size=32;
			pIdSchema.Index=0;
			param.Add (pIdSchema);

			S_Object io_cursor = new S_Object();
			io_cursor.ParameterName = "io_cursor";
			io_cursor.Direction=ParameterDirection.Output;
			io_cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
			io_cursor.Index=2;
			param.Add(io_cursor);

			DataSet ds = _OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.IL_GetGlossario");
			return ds.Tables[0];
		}



			private DataTable GetCampiQuery(int IdSchema)
			{
				int cntPar = 0;
				OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				S_ControlsCollection param = new S_ControlsCollection();

				S_Object pIdQuery=new S_Object();
				pIdQuery.ParameterName = "pIdQuery";
				pIdQuery.Direction = ParameterDirection.Input;
				pIdQuery.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
				pIdQuery.Value = IdSchema;
				pIdQuery.Size = 32;
				pIdQuery.Index=cntPar++;
				param.Add(pIdQuery);

				S_Object pSelect=new S_Object();
				pSelect.ParameterName = "pSelected";
				pSelect.Direction = ParameterDirection.Input;
				pSelect.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
				pSelect.Value = 1;
				pSelect.Size = 32;
				pSelect.Index=cntPar++;
				param.Add(pSelect);
			
				S_Object pSortExpression=new S_Object();
				pSortExpression.ParameterName = "pSortExpression";
				pSortExpression.Direction = ParameterDirection.Input;
				pSortExpression.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				pSortExpression.Size = 100;
				pSortExpression.Index=cntPar++;
				pSortExpression.Value = DBNull.Value;
				param.Add(pSortExpression);

				
				S_Object pIdVista=new S_Object();
				pIdVista.ParameterName = "pIdVista";
				pIdVista.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
				pIdVista.Direction = ParameterDirection.Input;
				pIdVista.Size = 32;
				pIdVista.Value =  _IdVista;
				pIdVista.Index=cntPar++;
				param.Add(pIdVista);

				S_Object io_cursor = new S_Object();
				io_cursor.ParameterName = "io_cursor";
				io_cursor.Direction=ParameterDirection.Output;
				io_cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
				io_cursor.Index=cntPar++;
				param.Add(io_cursor);


				string CurrentProcedure="IL_PACK_INTERROGAZIONI.IL_SpSelectGlossario";

				DataSet ds = _OraDl.ExecuteProcedure(param,CurrentProcedure);
				return ds.Tables[0];
			}
			
			private DataTable GetCampiOrderBy(int IdSchema)
			{
				OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				S_ControlsCollection param = new S_ControlsCollection();

				S_Object pIdQuery=new S_Object();
				pIdQuery.ParameterName = "pIdSchema";
				pIdQuery.Direction = ParameterDirection.Input;
				pIdQuery.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
				pIdQuery.Value = IdSchema;
				pIdQuery.Size = 32;
				pIdQuery.Index=0;
				param.Add(pIdQuery);

				S_Object io_cursor = new S_Object();
				io_cursor.ParameterName = "io_cursor";
				io_cursor.Direction=ParameterDirection.Output;
				io_cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
				io_cursor.Index=1;
				param.Add(io_cursor);


				string CurrentProcedure="IL_PACK_INTERROGAZIONI.IL_OrderBy";

				DataSet ds = _OraDl.ExecuteProcedure(param,CurrentProcedure);
				return ds.Tables[0];
			}

			public string VISTA 
			{
				get{ return _VISTA; }
				set{ _VISTA = value;}
			}
			public int IdVista
			{
				get{ return _IdVista;}
				set{ _IdVista =value;}
			}
	}
	

}
