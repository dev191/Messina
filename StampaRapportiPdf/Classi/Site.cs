using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

namespace StampaRapportiPdf.Classi
{	
	
	public enum NumberType
	{
		Intero,
		Decimale
	}

	public enum ExecuteType
	{
		Insert ,
		Update ,
		Delete 		
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

	public enum TipoManutenzioneType
	{
		ManutenzionesuRichiesta=1,
		ManutenzioneProgrammata=2,
		ManutenzioneStraordinaria=3
	}

	public class GestoreDropDownList
	{
		/// <summary>
		/// Restituisce in Item vuoto
		/// </summary>
		/// <param name="Text"></param>
		/// <param name="Value"></param>
		/// <returns></returns>
		
		public static ListItem ItemMessaggio(string Text, string Value)
		{
			ListItem _Li = new ListItem(Text, Value);
			return _Li;
		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="DataTableOrigine"></param>
		/// <param name="DataTextField"></param>
		/// <param name="DataValueFiled"></param>
		/// <param name="BlankText"></param>
		/// <param name="BlankValue"></param>
		/// <returns></returns>
		public static DataTable ItemBlankDataSource (DataTable DataTableOrigine, string DataTextField, string DataValueFiled,
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="DataViewOrigine"></param>
		/// <param name="DataTextField"></param>
		/// <param name="DataValueFiled"></param>
		/// <param name="BlankText"></param>
		/// <param name="BlankValue"></param>
		/// <returns></returns>
		public static DataTable ItemBlankDataSource (DataView DataViewOrigine, string DataTextField, string DataValueFiled,
			string BlankText, string BlankValue)
		{
			DataTable _MyDt = DataViewOrigine.Table.Clone();
			_MyDt.Columns[DataValueFiled].AllowDBNull = true;

			DataRow _DrBlank = _MyDt.NewRow();
			if (BlankValue != String.Empty)
				_DrBlank[DataValueFiled] = BlankValue;

			_DrBlank[DataTextField] = BlankText;

			_MyDt.Rows.Add(_DrBlank);

			int i = 0;
			while ( i <=  DataViewOrigine.Count - 1)
			{
				DataRow _DrNew = _MyDt.NewRow();
				_DrNew[DataValueFiled] = DataViewOrigine[i][DataValueFiled];
				_DrNew[DataTextField] = DataViewOrigine[i][DataTextField];

				_MyDt.Rows.Add(_DrNew);

				i ++;
			}

			return _MyDt;
		}

		
	}

	
	
}
