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
using TheSite.SchemiXSD;
//using TheSite.Classi.ManCorrettiva;


namespace TheSite.Classi.CostiGesioneCumulativi
{
	/// <summary>
	/// Descrizione di riepilogo per CostiOperativiCumulativo.
	/// </summary>
	public class CostiOperativiCumulativo : AbstractBase
	{
		string userName = "";
		public CostiOperativiCumulativo(string userName)
		{
			this.userName=userName;
		}

		/// <summary>
		/// Imposto tutte le variabili per la generazione del report
		/// Eseguo il Binding sul Repeater
		/// </summary>
		public dsRapportino ImpostaRpt(string [] arOdl)
		{
			try
			{
				RichiestaIntervento  _RichiestaIntervento= new RichiestaIntervento(userName);

				dsRapportino _ds = new dsRapportino();



				foreach (string wrId in arOdl)
				{
					bool ciSonoCosti = false;
					DataRow MainDr = _ds.Tables["MainTable"].NewRow();
					MainDr["WR_ID"]=Convert.ToInt32(wrId);

					DataSet _dsAppoggio1 = _RichiestaIntervento.GetSingleData(getWo(int.Parse(wrId)));
					//Aggiunge al dataset l riga con i dettagli dell'intervento
					DataRow drc =_dsAppoggio1.Tables[0].Rows[0];
					MainDr["WO_ID"]=Convert.ToInt32(drc["VAR_WO_WO_ID"]);

					_ds.Tables["rapportoTecnicoIntervento"].ImportRow(drc);


					ClManCorrettiva ioDati = new ClManCorrettiva();
					DataTable Dt = ioDati.GetListaManodopera(Convert.ToInt32(wrId)).Tables[0].Copy();
					Dt.TableName="ListaManodopera";

					//					DataColumn dcWrId = new DataColumn("WR_ID");
					//					Dt.Columns.Add(dcWrId);

					if(Dt.Rows.Count==0)
					{
			
						//per inserire una riga

						DataRow o_Dr = _ds.Tables["ListaManodopera"].NewRow();
						o_Dr["ID"]="-1";				
						o_Dr["IdAddetto"]=0;
						o_Dr["IdAddettoWR"]=0;
						o_Dr["CognomeNome"] =DBNull.Value;
						o_Dr["Livello"] ="<b>TOTALE</b>";
						o_Dr["PrezzoUnitario"] =DBNull.Value;
						o_Dr["OreLavorate"]=DBNull.Value;
						o_Dr["Totale"]=0;
						o_Dr["DescrizioneIntervento"]=DBNull.Value;
						o_Dr["WR_ID"]=Convert.ToInt32(wrId);
						_ds.Tables["ListaManodopera"].Rows.Add(o_Dr);
						MainDr["HA_MANODOPERA"]="-1";
					} 
					else 
					{
						if (!Dt.Columns.Contains("WR_ID"))
						{
							DataColumn myDataColumn; 
							myDataColumn =	new DataColumn();
							myDataColumn.DataType = System.Type.GetType("System.Int32");
							myDataColumn.ColumnName = "WR_ID";
						
							// Add the Column to the DataColumnCollection.
							Dt.Columns.Add(myDataColumn);
						}
						ciSonoCosti=true;
						MainDr["HA_MANODOPERA"]="1";
						foreach (DataRow dr in Dt.Rows)
						{

							dr["WR_ID"]=Convert.ToInt32(wrId);
							
							_ds.Tables["ListaManodopera"].ImportRow(dr);
						}

					}


					DataTable Dt2 = ioDati.GetListaMateriali(Convert.ToInt32(wrId)).Tables[0].Copy();
					Dt2.TableName="ListaMateriali";

					//					DataColumn dcWrId2 = new DataColumn("WR_ID");
					//					Dt2.Columns.Add(dcWrId2);

					if(Dt2.Rows.Count==0)
					{
						//per inserire una riga

						DataRow o_Dr = _ds.Tables["ListaMateriali"].NewRow();
						o_Dr["ID"]="-1";				
						o_Dr["MATERIALE"]=DBNull.Value;
						o_Dr["PREZZO_UNITARIO"]=DBNull.Value;
						o_Dr["UNITAMISURA"] ="";
						o_Dr["QUANTITA"] =0;
						o_Dr["PREZZOTOTALE"] =0;
						o_Dr["ID_MATERIALI"]=-1;
						o_Dr["WR_ID"]=Convert.ToInt32(wrId);
						_ds.Tables["ListaMateriali"].Rows.Add(o_Dr);
						MainDr["HA_MATERIALI"]="-1";

					}
					else 
					{
						if (!Dt2.Columns.Contains("WR_ID"))
						{
							DataColumn myDataColumn; 
							myDataColumn =	new DataColumn();
							myDataColumn.DataType = System.Type.GetType("System.Int32");
							myDataColumn.ColumnName = "WR_ID";
							// Add the Column to the DataColumnCollection.
							Dt2.Columns.Add(myDataColumn);
						}

						ciSonoCosti=true;
						MainDr["HA_MATERIALI"]="1";
						foreach (DataRow dr in Dt2.Rows)
						{
							dr["WR_ID"]=Convert.ToInt32(wrId);
							_ds.Tables["ListaMateriali"].ImportRow(dr);
						}
					}

					_ds.Tables["MainTable"].Rows.Add(MainDr);
					
					float totaleManodoperaF=0;
					float totaleMaterialeF=0;
					if (ciSonoCosti) 
					{

						foreach (DataRow dr in _ds.Tables["ListaManodopera"].Rows)
						{
							if (Convert.ToInt32(dr["WR_ID"])==Convert.ToInt32(wrId))
								totaleManodoperaF += float.Parse(Convert.ToString(dr["TOTALE"]));
						}
						foreach (DataRow dr in _ds.Tables["ListaMateriali"].Rows)
						{
							if (Convert.ToInt32(dr["WR_ID"])==Convert.ToInt32(wrId))
								totaleMaterialeF += float.Parse(Convert.ToString(dr["PREZZOTOTALE"]));
						}

						DataRow o_Dr = _ds.Tables["TOTALI"].NewRow();
						o_Dr["TotaleManodopera"] =totaleManodoperaF;
						o_Dr["TotaleMateriali"]=totaleMaterialeF;
						o_Dr["WR_ID"]=Convert.ToInt32(wrId);
						_ds.Tables["TOTALI"].Rows.Add(o_Dr);

					} 
					else 
					{
						DataRow o_Dr = _ds.Tables["TOTALI"].NewRow();
						o_Dr["TotaleManodopera"] =-1;
						o_Dr["TotaleMateriali"]=-1;
						o_Dr["WR_ID"]=Convert.ToInt32(wrId);
						_ds.Tables["TOTALI"].Rows.Add(o_Dr);
					}
				}
				return _ds;
			}
			catch (Exception exc)
			{
				return null;
			}
		}

		private int getWo(int wrId)
		{
			DataSet _Ds;
			int result = -1;
			
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_wrId = new S_Object();
			s_wrId.ParameterName = "p_wr";
			s_wrId.DbType = CustomDBType.Integer;
			s_wrId.Direction = ParameterDirection.Input;
			s_wrId.Value=wrId;
			s_wrId.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_wrId);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "pack_CostiGestioneCumulativi.SP_GET_WOID_FROM_WRID2";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();
			
			foreach (DataRow Dr in _Ds.Tables[0].Rows)
			{
				result=Convert.ToInt32(Dr["WO_ID"]);						
			}
			
			_Ds.Dispose();
			return result;
		}

		#region Metodi Pubblici

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
			return null;
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public override DataSet GetSingleData(int wr_id)
		{
			return null;
			
		}
		#endregion


		#region Metodi Privati
		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			

			return 0;
			
		}

		#endregion
	}
}
