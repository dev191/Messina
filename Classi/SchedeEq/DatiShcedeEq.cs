using System;
using System.Data;
using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DataBaseConnection;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;
using TheSite.SchemiXSD;
namespace TheSite.Classi.SchedeEq
{
	/// <summary>
	/// Descrizione di riepilogo per DatiShcedeEq.
	/// </summary>
	public class DatiShcedeEq : AbstractBase
	{
		private int _EqId;
		private string _MoltepliciEqId;
	    private	enum Manutenzione {Richiesta =1, Programmata,Straordinaria};
		public DatiShcedeEq(int CEqId)
		{
			_EqId = CEqId;
		}
		public DatiShcedeEq(string CMoltepliciEqId)
		{
			_MoltepliciEqId = CMoltepliciEqId;
		}
		public DatiShcedeEq()
		{
		}
		public override DataSet GetData()
		{
			return null;
		}
		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			return 0;
		}
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			return null;
		}

		public override DataSet GetSingleData(int itemId)
		{
			return null;
		}
		public NewDataSet GetDsTipizzato()
		{
			NewDataSet ds = new NewDataSet();
			int[] id = ArrayEqId(_MoltepliciEqId);
			for(int j = 0; j<id.Length; j++)
			{
				ds = TblGenerale(ds,id[j]);
				ds =TblDatiTecnici(ds,id[j]);
				ds = TblTblPmpPassi(ds,id[j]);
				ds = TblAllegati(ds,id[j]);
				ds = TblMan(ds,id[j],(int)Manutenzione.Richiesta);
				ds = TblMan(ds,id[j],(int)Manutenzione.Programmata);
				ds = TblMan(ds,id[j],(int)Manutenzione.Straordinaria);
			}
			return ds;
		}

		private  NewDataSet TblMan(NewDataSet ds, int idEq,int TipoManutenzione)
		{
			int CntParametri = 0;
			S_ControlsCollection ColParametri = new S_ControlsCollection();
			S_Object PEqId = new S_Object();
			PEqId.ParameterName = "PEqId";
			PEqId.DbType = CustomDBType.Integer;
			PEqId.Direction = ParameterDirection.Input;
			PEqId.Index = CntParametri++;
			PEqId.Value = idEq;
			ColParametri.Add(PEqId);

			S_Object PTipoManutenzione = new S_Object();
			PTipoManutenzione.ParameterName = "PTipoManutenzione";
			PTipoManutenzione.DbType = CustomDBType.Integer;
			PTipoManutenzione.Direction = ParameterDirection.Input;
			PTipoManutenzione.Index = CntParametri++;
			PTipoManutenzione.Value = TipoManutenzione;
			ColParametri.Add(PTipoManutenzione);

			S_Object Pio_cursor = new S_Object();
			Pio_cursor.ParameterName = "io_cursor";
			Pio_cursor.DbType = CustomDBType.Cursor;
			Pio_cursor.Direction = ParameterDirection.Output;
			Pio_cursor.Index = CntParametri++;
			ColParametri.Add(Pio_cursor);
			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			DataSet GenericDs = _OraDl.GetRows(ColParametri,"PACK_SCHEDE_EQ.getInterventiEQMan").Copy();
			if(GenericDs.Tables[0].Rows.Count > 0)
			{
				switch(TipoManutenzione)
				{
					case 1: //manutenzione su richiesta
						for(int i=0; i< GenericDs.Tables[0].Rows.Count;i++)
						{
							ds.Tables["TblManRic"].ImportRow(GenericDs.Tables[0].Rows[i]);
						}
						break;
					case 2: //manutenzione programmata
						for(int i=0; i< GenericDs.Tables[0].Rows.Count;i++)
						{
							ds.Tables["TblManProg"].ImportRow(GenericDs.Tables[0].Rows[i]);
						}
						break;
					case 3: //manutenzione straordinaria
						for(int i=0; i< GenericDs.Tables[0].Rows.Count;i++)
						{
							ds.Tables["TblManStra"].ImportRow(GenericDs.Tables[0].Rows[i]);
						}
						break;
					default:
						// non fai niente
						break;
				}
			}
			return ds;

		}

		private NewDataSet TblGenerale(NewDataSet ds, int idEq)
		{
			int CntParametri = 0;
			S_ControlsCollection ColParametri = new S_ControlsCollection();
			S_Object PEqId = new S_Object();
			PEqId.ParameterName = "PEqId";
			PEqId.DbType = CustomDBType.Integer;
			PEqId.Direction = ParameterDirection.Input;
			PEqId.Index = CntParametri++;
			PEqId.Value = idEq;
			ColParametri.Add(PEqId);

			S_Object Pio_cursor = new S_Object();
			Pio_cursor.ParameterName = "io_cursor";
			Pio_cursor.DbType = CustomDBType.Cursor;
			Pio_cursor.Direction = ParameterDirection.Output;
			Pio_cursor.Index = CntParametri++;
			ColParametri.Add(Pio_cursor);

			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);	
			DataSet GenericDs = _OraDl.GetRows(ColParametri,"PACK_SCHEDE_EQ.getDatiRpt").Copy();
			if(GenericDs.Tables[0].Rows.Count > 0)
			{
				for(int i=0; i< GenericDs.Tables[0].Rows.Count;i++)
				{
					ds.Tables["TblGenerale"].ImportRow(GenericDs.Tables[0].Rows[i]);
				}
			}
			return ds;
		}
		private NewDataSet TblDatiTecnici(NewDataSet ds, int idEq)
		{
			int CntParametri = 0;
			S_ControlsCollection ColParametri = new S_ControlsCollection();
			S_Object PEqId = new S_Object();
			PEqId.ParameterName = "PEqId";
			PEqId.DbType = CustomDBType.Integer;
			PEqId.Direction = ParameterDirection.Input;
			PEqId.Index = CntParametri++;
			PEqId.Value = idEq;
			ColParametri.Add(PEqId);

			S_Object Pio_cursor = new S_Object();
			Pio_cursor.ParameterName = "io_cursor";
			Pio_cursor.DbType = CustomDBType.Cursor;
			Pio_cursor.Direction = ParameterDirection.Output;
			Pio_cursor.Index = CntParametri++;
			ColParametri.Add(Pio_cursor);

			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);	
			DataSet GenericDs = _OraDl.GetRows(ColParametri,"PACK_SCHEDE_EQ.getDatiTecnici").Copy();
			if(GenericDs.Tables[0].Rows.Count > 0)
			{
				for(int i=0; i< GenericDs.Tables[0].Rows.Count;i++)
				{
					ds.Tables["TblDatiTecnici"].ImportRow(GenericDs.Tables[0].Rows[i]);
				}
				int numeroRecord = GenericDs.Tables[0].Rows.Count;
				if(numeroRecord % 2 == 0)
				{
					for(int i=0;i<numeroRecord/2;i++)
					{
						DataRow dr = ds.Tables["TblDatiTecniciEstesa"].NewRow();
					
						dr[0] = GenericDs.Tables[0].Rows[2*i][3];
						dr[1] = GenericDs.Tables[0].Rows[2*i][4];
						dr[2] = GenericDs.Tables[0].Rows[2*i+1][3];
						dr[3] = GenericDs.Tables[0].Rows[2*i+1][4];
						dr[4]= GenericDs.Tables[0].Rows[2*i][1];
						ds.Tables["TblDatiTecniciEstesa"].Rows.Add(dr);
					}
				}
				if(numeroRecord %2 == 1)
				{
					for(int i=0;i<(numeroRecord-1)/2;i++)
					{
						 
						DataRow dr = ds.Tables["TblDatiTecniciEstesa"].NewRow();
						dr[0] =  GenericDs.Tables[0].Rows[2*i][3];
						dr[1] =  GenericDs.Tables[0].Rows[2*i][4];
						dr[2] =  GenericDs.Tables[0].Rows[2*i+1][3];
						dr[3] =  GenericDs.Tables[0].Rows[2*i+1][4];
						dr[4]= GenericDs.Tables[0].Rows[2*i][1];
						ds.Tables["TblDatiTecniciEstesa"].Rows.Add(dr);
					}
					DataRow drUltima = ds.Tables["TblDatiTecniciEstesa"].NewRow();
					drUltima[0] =  GenericDs.Tables[0].Rows[numeroRecord-1][3];
					drUltima[1] = GenericDs.Tables[0].Rows[numeroRecord-1][4];
					drUltima[2] = "";
					drUltima[3] = "";
					drUltima[4]= GenericDs.Tables[0].Rows[numeroRecord-1][1];
					ds.Tables["TblDatiTecniciEstesa"].Rows.Add(drUltima);
				}


			}
			return ds;
		}
		private NewDataSet TblTblPmpPassi(NewDataSet ds, int idEq)
		{
			int CntParametri = 0;
			S_ControlsCollection ColParametri = new S_ControlsCollection();
			S_Object PEqId = new S_Object();
			PEqId.ParameterName = "PEqId";
			PEqId.DbType = CustomDBType.Integer;
			PEqId.Direction = ParameterDirection.Input;
			PEqId.Index = CntParametri++;
			PEqId.Value = idEq;
			ColParametri.Add(PEqId);

			S_Object Pio_cursor = new S_Object();
			Pio_cursor.ParameterName = "io_cursor";
			Pio_cursor.DbType = CustomDBType.Cursor;
			Pio_cursor.Direction = ParameterDirection.Output;
			Pio_cursor.Index = CntParametri++;
			ColParametri.Add(Pio_cursor);

			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);	
			DataSet GenericDs = _OraDl.GetRows(ColParametri,"PACK_SCHEDE_EQ.getPmpPassi").Copy();
			if(GenericDs.Tables[0].Rows.Count > 0)
			{
				for(int i=0; i< GenericDs.Tables[0].Rows.Count;i++)
				{
					ds.Tables["TblPmpPassi"].ImportRow(GenericDs.Tables[0].Rows[i]);
				}
			}
			return ds;
		}
		private NewDataSet TblAllegati(NewDataSet ds, int idEq)
		{
			int CntParametri = 0;
			S_ControlsCollection ColParametri = new S_ControlsCollection();
			S_Object PEqId = new S_Object();
			PEqId.ParameterName = "PEqId";
			PEqId.DbType = CustomDBType.Integer;
			PEqId.Direction = ParameterDirection.Input;
			PEqId.Index = CntParametri++;
			PEqId.Value = idEq;
			ColParametri.Add(PEqId);

			S_Object Pio_cursor = new S_Object();
			Pio_cursor.ParameterName = "io_cursor";
			Pio_cursor.DbType = CustomDBType.Cursor;
			Pio_cursor.Direction = ParameterDirection.Output;
			Pio_cursor.Index = CntParametri++;
			ColParametri.Add(Pio_cursor);

			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);	
			DataSet GenericDs = _OraDl.GetRows(ColParametri,"PACK_SCHEDE_EQ.geteqallegati").Copy();
			if(GenericDs.Tables[0].Rows.Count > 0)
			{
				for(int i=0; i< GenericDs.Tables[0].Rows.Count;i++)
				{
					ds.Tables["TblAllegati"].ImportRow(GenericDs.Tables[0].Rows[i]);
				}
				int numeroRecord = GenericDs.Tables[0].Rows.Count;
				if(numeroRecord % 2 == 0)
				{
					for(int i=0;i<numeroRecord/2;i++)
					{
						DataRow dr = ds.Tables["TblAllegatiEstesa"].NewRow();
					
						dr[0] = GenericDs.Tables[0].Rows[2*i][1];
						dr[1] = GenericDs.Tables[0].Rows[2*i][2];
						dr[2] = GenericDs.Tables[0].Rows[2*i+1][1];
						dr[3] = GenericDs.Tables[0].Rows[2*i+1][2];
						dr[4]= GenericDs.Tables[0].Rows[2*i][3];
						ds.Tables["TblAllegatiEstesa"].Rows.Add(dr);
					}
				}
				if(numeroRecord %2 == 1)
				{
					for(int i=0;i<(numeroRecord-1)/2;i++)
					{
						 
						DataRow dr = ds.Tables["TblAllegatiEstesa"].NewRow();
						dr[0] =  GenericDs.Tables[0].Rows[2*i][1];
						dr[1] =  GenericDs.Tables[0].Rows[2*i][2];
						dr[2] =  GenericDs.Tables[0].Rows[2*i+1][1];
						dr[3] =  GenericDs.Tables[0].Rows[2*i+1][2];
						dr[4]= GenericDs.Tables[0].Rows[2*i][3];
						ds.Tables["TblAllegatiEstesa"].Rows.Add(dr);
					}
					DataRow drUltima = ds.Tables["TblAllegatiEstesa"].NewRow();
					drUltima[0] =  GenericDs.Tables[0].Rows[numeroRecord-1][1];
					drUltima[1] = GenericDs.Tables[0].Rows[numeroRecord-1][2];
					drUltima[2] = "";
					drUltima[3] = "";
					drUltima[4]= GenericDs.Tables[0].Rows[numeroRecord-1][3];
					ds.Tables["TblAllegatiEstesa"].Rows.Add(drUltima);
				}
			}
			return ds;
		}
		private int[]  ArrayEqId( string StringaEqId)
		{
			string[] tmp = StringaEqId.Split(',');
			int[] ArIdEq = new int[tmp.Length]; 
			for(int i=0; i< ArIdEq.Length; i++)
			{
				ArIdEq[i]= Convert.ToInt32(tmp[i]);
			}
			return ArIdEq;
		}

		public int EqId
		{
			get
			{
				return _EqId;
			}
			set
			{
				_EqId = value;
			}
		}
		
		public string MoltepliciEqId
		{
			get
			{
				return _MoltepliciEqId;
			}
			set
			{
				_MoltepliciEqId = value;
			}
		}
		

		
	}
}
