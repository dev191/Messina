//using System;
//using TheSite.SchemiXSD;
//using System.Data;
//using ApplicationDataLayer;
//using ApplicationDataLayer.Collections;
//using ApplicationDataLayer.DataBaseConnection;
//using ApplicationDataLayer.DBType;
//using S_Controls;
//using S_Controls.Collections;
//
//namespace TheSite.Classi.ManProgrammata
//{
//	/// <summary>
//	/// Summary description for RptMptData.
//	/// </summary>
//	public class RptMpData : AbstractBase
//	{
//		public RptMpData()
//		{
//		}
//		protected override int ExecuteUpdate(S_Controls.Collections.S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
//		{
//			return 0;
//		}
//		public override System.Data.DataSet GetData()
//		{
//			return null;
//		} 
//		public override System.Data.DataSet GetData(S_Controls.Collections.S_ControlsCollection CollezioneControlli)
//		{	
//			return null;
//		}
//		public override System.Data.DataSet GetSingleData(int itemId)
//		{
//			return null;
//		}
//		public  DsRptMpLocali GetDataTipizzato(string SOdl)
//		{
//			DsRptMpLocali ds =  new DsRptMpLocali();
//			int[] id = ArrayId(SOdl);
//			for(int j = 0; j<id.Length; j++)
//			{
//				ds = tblMain(ds,id[j]);
//				ds = tblPassi(ds,id[j]);
//				ds = TblDetRdl(ds,id[j]);
//			}
//			//ds = tblPassiTot(ds,SOdl);
//			ds = TblLeggendaPassi(ds);
//			ds = TblLeggendaStatus(ds);
//			return ds;
//		}
//	private DsRptMpLocali TblLeggendaPassi(DsRptMpLocali ds)
//		{
//			S_ControlsCollection ColParametri = new S_ControlsCollection();
//			S_Object PCursor = new S_Object();
//			PCursor.ParameterName = "PCursor";
//			PCursor.DbType = CustomDBType.Cursor;
//			PCursor.Direction = ParameterDirection.Output;
//			PCursor.Index = 1;
//			ColParametri.Add(PCursor);
//			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
//			DataSet GenericDs = _OraDl.GetRows(ColParametri,"PACK_RTP_PROG.GetLeggendaPassi").Copy();
//			if(GenericDs.Tables[0].Rows.Count > 0)
//			{
//				for(int i=0; i< GenericDs.Tables[0].Rows.Count;i++)
//				{
//					ds.Tables["TblLeggendaPassi"].ImportRow(GenericDs.Tables[0].Rows[i]);
//				}
//			}
//			return ds;
//		}
//		private DsRptMpLocali TblLeggendaStatus(DsRptMpLocali ds)
//		{
//			S_ControlsCollection ColParametri = new S_ControlsCollection();
//			S_Object PCursor = new S_Object();
//			PCursor.ParameterName = "PCursor";
//			PCursor.DbType = CustomDBType.Cursor;
//			PCursor.Direction = ParameterDirection.Output;
//			PCursor.Index = 1;
//			ColParametri.Add(PCursor);
//			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
//			DataSet GenericDs = _OraDl.GetRows(ColParametri,"PACK_RTP_PROG.GetLeggendaStatus").Copy();
//			if(GenericDs.Tables[0].Rows.Count > 0)
//			{
//				for(int i=0; i< GenericDs.Tables[0].Rows.Count;i++)
//				{
//					ds.Tables["tblLeggendaStatus"].ImportRow(GenericDs.Tables[0].Rows[i]);
//				}
//			}
//			return ds;
//		}
//		private DsRptMpLocali TblDetRdl(DsRptMpLocali ds, int idWo)
//		{
//		int[] IdPmp = ArrayPmp(idWo);
//			for(int k =0; k<IdPmp.Length;k++)
//			{
//				int CntParametri = 0;
//				S_ControlsCollection ColParametri = new S_ControlsCollection();
//				S_Object POdl = new S_Object();
//				POdl.ParameterName = "POdl";
//				POdl.DbType = CustomDBType.Integer;
//				POdl.Direction = ParameterDirection.Input;
//				POdl.Index = CntParametri++;
//				POdl.Value = idWo;
//				ColParametri.Add(POdl);
//
//			
//				S_Object PIdPmp = new S_Object();
//				PIdPmp.ParameterName = "PIdPmp";
//				PIdPmp.DbType = CustomDBType.Integer;
//				PIdPmp.Direction = ParameterDirection.Input;
//				PIdPmp.Index = CntParametri++;
//				PIdPmp.Value = IdPmp[k];;
//				ColParametri.Add(PIdPmp);
//
//				S_Object PCursor = new S_Object();
//				PCursor.ParameterName = "PCursor";
//				PCursor.DbType = CustomDBType.Cursor;
//				PCursor.Direction = ParameterDirection.Output;
//				PCursor.Index = CntParametri++;
//				ColParametri.Add(PCursor);
//				OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
//				DataSet GenericDs = _OraDl.GetRows(ColParametri,"PACK_RTP_PROG.GetDettaglioRdl").Copy();
//				if(GenericDs.Tables[0].Rows.Count > 0)
//				{
//					int numeroRecord = GenericDs.Tables[0].Rows.Count;
//					if(numeroRecord % 2 == 0)
//					{
//						for(int i=0;i<numeroRecord/2;i++)
//						{
//							DataRow dr = ds.Tables["TblDetRdlEstesa"].NewRow();
//							dr["WO_ID"] = GenericDs.Tables[0].Rows[2*i]["wo_id"]; // WO_ID
//							dr["ID_PMP"] = GenericDs.Tables[0].Rows[2*i]["id_pmp"]; // ID_PMP
//							dr["DESC_EQSTD"] = GenericDs.Tables[0].Rows[2*i]["desc_eqstd"]; // DESC Eqstd
//							dr["WR_ID0"] = GenericDs.Tables[0].Rows[2*i]["wr_id"]; // wr_id0 pari
//							dr["FL_ID0"] = GenericDs.Tables[0].Rows[2*i]["fl_id"]; //fl_id0 pari
//							dr["EQ_ID0"] = GenericDs.Tables[0].Rows[2*i]["eq_id"]; //eq_id pari
//							dr["RM_ID0"] = GenericDs.Tables[0].Rows[2*i]["rm_id"]; //rm_id pari
//							dr["STATUS0"] = GenericDs.Tables[0].Rows[2*i]["status"]; //status pari
//							dr["WR_ID1"] = GenericDs.Tables[0].Rows[2*i+1]["wr_id"];  // wr_id1 dispari
//							dr["FL_ID1"] = GenericDs.Tables[0].Rows[2*i+1]["fl_id"];  //fl_id1 dispari
//							dr["EQ_ID1"] = GenericDs.Tables[0].Rows[2*i+1]["eq_id"];  //eq_id1dispari
//							dr["RM_ID1"] = GenericDs.Tables[0].Rows[2*i+1]["rm_id"]; //rm_id1 dispari
//							dr["STATUS1"] = GenericDs.Tables[0].Rows[2*i+1]["status"]; //status1 dispari
//							ds.Tables["TblDetRdlEstesa"].Rows.Add(dr);
//						}
//					}
//					if(numeroRecord %2 == 1)
//					{
//						for(int i=0;i<(numeroRecord-1)/2;i++)
//						{
//						 
//							DataRow dr = ds.Tables["TblDetRdlEstesa"].NewRow();
//							dr["WO_ID"] = GenericDs.Tables[0].Rows[2*i]["wo_id"]; // WO_ID
//							dr["ID_PMP"] = GenericDs.Tables[0].Rows[2*i]["id_pmp"]; // ID_PMP
//							dr["DESC_EQSTD"] = GenericDs.Tables[0].Rows[2*i]["desc_eqstd"]; // DESC Eqstd
//
//							dr["WR_ID0"] = GenericDs.Tables[0].Rows[2*i]["wr_id"]; // wr_id0 pari
//							dr["FL_ID0"] = GenericDs.Tables[0].Rows[2*i]["fl_id"]; //fl_id0 pari
//							dr["EQ_ID0"] = GenericDs.Tables[0].Rows[2*i]["eq_id"]; //eq_id pari
//							dr["RM_ID0"] = GenericDs.Tables[0].Rows[2*i]["rm_id"]; //rm_id pari
//							dr["STATUS0"] = GenericDs.Tables[0].Rows[2*i]["status"]; //status pari
//							dr["WR_ID1"] = GenericDs.Tables[0].Rows[2*i+1]["wr_id"];  // wr_id1 dispari
//							dr["FL_ID1"] = GenericDs.Tables[0].Rows[2*i+1]["fl_id"];  //fl_id1 dispari
//							dr["EQ_ID1"] = GenericDs.Tables[0].Rows[2*i+1]["eq_id"];  //eq_id1dispari
//							dr["RM_ID1"] = GenericDs.Tables[0].Rows[2*i+1]["rm_id"]; //rm_id1 dispari
//							dr["STATUS1"] = GenericDs.Tables[0].Rows[2*i+1]["status"]; //status1 dispari
//							ds.Tables["TblDetRdlEstesa"].Rows.Add(dr);
//						}
//						DataRow drUltima = ds.Tables["TblDetRdlEstesa"].NewRow();
//						drUltima["WO_ID"] = GenericDs.Tables[0].Rows[numeroRecord-1]["wo_id"];
//						drUltima["ID_PMP"] = GenericDs.Tables[0].Rows[numeroRecord-1]["id_pmp"];
//						drUltima["DESC_EQSTD"] = GenericDs.Tables[0].Rows[numeroRecord-1]["desc_eqstd"];
//
//						drUltima["WR_ID0"] =  GenericDs.Tables[0].Rows[numeroRecord-1]["wr_id"];
//						drUltima["FL_ID0"] = GenericDs.Tables[0].Rows[numeroRecord-1]["fl_id"];
//						drUltima["EQ_ID0"] =  GenericDs.Tables[0].Rows[numeroRecord-1]["eq_id"];
//						drUltima["RM_ID0"] = GenericDs.Tables[0].Rows[numeroRecord-1]["rm_id"];
//						drUltima["STATUS0"] = GenericDs.Tables[0].Rows[numeroRecord-1]["status"];
//
//						drUltima["WR_ID1"] =  "";
//						drUltima["FL_ID1"] = "";
//						drUltima["EQ_ID1"] =  "";
//						drUltima["RM_ID1"] = "";
//						drUltima["STATUS1"] = "";
//						ds.Tables["TblDetRdlEstesa"].Rows.Add(drUltima);
//					}
//				}
//			}
//		return ds;
//	}
//		private  DsRptMpLocali tblMain(DsRptMpLocali ds, int idWo)
//		{
//			int CntParametri = 0;
//			S_ControlsCollection ColParametri = new S_ControlsCollection();
//			S_Object POdl = new S_Object();
//			POdl.ParameterName = "POdl";
//			POdl.DbType = CustomDBType.Integer;
//			POdl.Direction = ParameterDirection.Input;
//			POdl.Index = CntParametri++;
//			POdl.Value = idWo;
//			ColParametri.Add(POdl);
//
//			S_Object PCursor = new S_Object();
//			PCursor.ParameterName = "PCursor";
//			PCursor.DbType = CustomDBType.Cursor;
//			PCursor.Direction = ParameterDirection.Output;
//			PCursor.Index = CntParametri++;
//			ColParametri.Add(PCursor);
//			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
//			DataSet GenericDs = _OraDl.GetRows(ColParametri,"PACK_RTP_PROG.GetDatiInt").Copy();
//			if(GenericDs.Tables[0].Rows.Count > 0)
//			{
//				for(int i=0; i< GenericDs.Tables[0].Rows.Count;i++)
//				{
//					ds.Tables["tblMain"].ImportRow(GenericDs.Tables[0].Rows[i]);
//				}
//			}
//			return ds;
//		}
//
//		private  DsRptMpLocali tblPassi(DsRptMpLocali ds, int idWo)
//		{
//			int CntParametri = 0;
//			S_ControlsCollection ColParametri = new S_ControlsCollection();
//			S_Object POdl = new S_Object();
//			POdl.ParameterName = "POdl";
//			POdl.DbType = CustomDBType.Integer;
//			POdl.Direction = ParameterDirection.Input;
//			POdl.Index = CntParametri++;
//			POdl.Value = idWo;
//			ColParametri.Add(POdl);
//
//			S_Object PCursor = new S_Object();
//			PCursor.ParameterName = "PCursor";
//			PCursor.DbType = CustomDBType.Cursor;
//			PCursor.Direction = ParameterDirection.Output;
//			PCursor.Index = CntParametri++;
//			ColParametri.Add(PCursor);
//			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
//			DataSet GenericDs = _OraDl.GetRows(ColParametri,"PACK_RTP_PROG.GetPassi").Copy();
//			if(GenericDs.Tables[0].Rows.Count > 0)
//			{
//				for(int i=0; i< GenericDs.Tables[0].Rows.Count;i++)
//				{
//					ds.Tables["tblPassi"].ImportRow(GenericDs.Tables[0].Rows[i]);
//				}
//			}
//			return ds;
//		}
//		private int[]  ArrayId( string StringaEqId)
//		{
//			string[] tmp = StringaEqId.Split(',');
//			int[] ArId = new int[tmp.Length]; 
//			for(int i=0; i< ArId.Length; i++)
//			{
//				ArId[i]= Convert.ToInt32(tmp[i]);
//			}
//			return ArId;
//		}
//		private int[] ArrayPmp(int idWo)
//		{
//			string Sret = string.Empty;
//			int CntParametri = 0;
//			S_ControlsCollection ColParametri = new S_ControlsCollection();
//			S_Object POdl = new S_Object();
//			POdl.ParameterName = "POdl";
//			POdl.DbType = CustomDBType.Integer;
//			POdl.Direction = ParameterDirection.Input;
//			POdl.Index = CntParametri++;
//			POdl.Value = idWo;
//			ColParametri.Add(POdl);
//
//			S_Object PCursor = new S_Object();
//			PCursor.ParameterName = "PCursor";
//			PCursor.DbType = CustomDBType.Cursor;
//			PCursor.Direction = ParameterDirection.Output;
//			PCursor.Index = CntParametri++;
//			ColParametri.Add(PCursor);
//			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
//			DataSet GenericDs = _OraDl.GetRows(ColParametri,"PACK_RTP_PROG.getIdPmp").Copy();
//			if(GenericDs.Tables[0].Rows.Count > 0)
//			{
//					
//				for(int i=0; i< GenericDs.Tables[0].Rows.Count;i++)
//				{
//					Sret =   GenericDs.Tables[0].Rows[i][0].ToString() +  "," + Sret ;
//				}
//				Sret =  Sret.Remove(Sret.Length-1,1);
//			}
//			return ArrayId( Sret) ;
//		}
//
//		
//	}
//}
