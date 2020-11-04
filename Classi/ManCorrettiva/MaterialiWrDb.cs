using System;
using System.Data;
using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DataBaseConnection;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;
using TheSite.SchemiXSD;
namespace TheSite.Classi.ManCorrettiva
{
	/// <summary>
	/// Summary description for MaterialiWrDb.
	/// </summary>
	public class MaterialiWrDb  : AbstractBase
	{
		private int _Wr_id, _Materiali_Id,_Stato;
		private string _DataIniziale,_DataFinale;
		public MaterialiWrDb( int Wr_Id, int Materiali_Id, int Stato,string DataIniziale,string DataFinale)
		{
			_Wr_id = Wr_Id;
			_Materiali_Id = Materiali_Id;
			_Stato = Stato;
			_DataIniziale = DataIniziale;
			_DataFinale = DataFinale;
		}
		public MaterialiWrDb()
		{
		}
		public	int Wr_Id
		{
			get{ return _Wr_id;}
			set{_Wr_id = value;}
		}
		public int Materiali_Id
		{
			get{ return _Materiali_Id;}
			set{ _Materiali_Id = value;}
		}
		public int Stato
		{
			get{return _Stato;}
			set{_Stato=value;}
		}
		public string DataIniziale
		{
			get{return _DataIniziale;}
			set{_DataIniziale = value;}
		}
		public string DataFinale
		{
			get{return _DataFinale;}
			set{_DataFinale = value;}
		}
		public override DataSet GetData()
		{
			return null;
		}
		public override DataSet GetSingleData(int itemId)
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
		public GestioneMateriali GetTipizzato()
		{
			GestioneMateriali ds = new GestioneMateriali();
			ds = TblGestioneMateriali(ds);
			return ds;
		}
		private GestioneMateriali TblGestioneMateriali(GestioneMateriali ds)
		{
			///Istanzio un nuovo oggetto Collection per aggiungere i parametri
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
					
			//Id_WR
			S_Controls.Collections.S_Object s_p_wrid = new S_Controls.Collections.S_Object();
			s_p_wrid.ParameterName = "p_wrid";
			s_p_wrid.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_wrid.Direction = ParameterDirection.Input;
			s_p_wrid.Size =50;
			s_p_wrid.Index = _SCollection.Count;
			s_p_wrid.Value = Convert.ToInt32(_Wr_id);
			_SCollection.Add(s_p_wrid);

			//id_materiale
			S_Controls.Collections.S_Object s_p_id_materiale = new S_Controls.Collections.S_Object();
			s_p_id_materiale.ParameterName = "p_id_materiale";
			s_p_id_materiale.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_id_materiale.Direction = ParameterDirection.Input;
			s_p_id_materiale.Size =50;
			s_p_id_materiale.Index = _SCollection.Count;
			s_p_id_materiale.Value = Convert.ToInt32(_Materiali_Id);
			_SCollection.Add(s_p_id_materiale);

			//data aggiornamento Dal
			S_Controls.Collections.S_Object s_p_dataaggiornamentoDal = new S_Controls.Collections.S_Object();
			s_p_dataaggiornamentoDal.ParameterName = "p_dataaggiornamentoDal";
			s_p_dataaggiornamentoDal.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_dataaggiornamentoDal.Direction = ParameterDirection.Input;
			s_p_dataaggiornamentoDal.Size =50;
			s_p_dataaggiornamentoDal.Index = _SCollection.Count;
			s_p_dataaggiornamentoDal.Value = _DataIniziale.ToString();
			_SCollection.Add(s_p_dataaggiornamentoDal);

			//data aggiornamento Al
			S_Controls.Collections.S_Object s_p_dataaggiornamentoAl = new S_Controls.Collections.S_Object();
			s_p_dataaggiornamentoAl.ParameterName = "p_dataaggiornamentoAl";
			s_p_dataaggiornamentoAl.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_dataaggiornamentoAl.Direction = ParameterDirection.Input;
			s_p_dataaggiornamentoAl.Size =50;
			s_p_dataaggiornamentoAl.Index = _SCollection.Count;
			s_p_dataaggiornamentoAl.Value = _DataFinale.ToString();
			_SCollection.Add(s_p_dataaggiornamentoAl);

			//Id stato
			S_Controls.Collections.S_Object s_p_stato = new S_Controls.Collections.S_Object();
			s_p_stato.ParameterName = "p_stato";
			s_p_stato.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_stato.Direction = ParameterDirection.Input;
			s_p_stato.Size =50;
			s_p_stato.Index = _SCollection.Count;
			s_p_stato.Value = Convert.ToInt32(_Stato);
			_SCollection.Add(s_p_stato);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "io_cursor";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = _SCollection.Count;
			_SCollection.Add(s_Cursor);


			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			DataSet GenericDs = _OraDl.GetRows(_SCollection,"Pack_WrMateriali.getMateriali").Copy();

			if(GenericDs.Tables[0].Rows.Count > 0)
			{
				for(int i=0; i< GenericDs.Tables[0].Rows.Count;i++)
				{
					ds.Tables["TblGestioneMateriali"].ImportRow(GenericDs.Tables[0].Rows[i]);
				}
			}
			return ds;
			
		}
	}


}
