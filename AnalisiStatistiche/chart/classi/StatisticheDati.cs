using System;
using System.Drawing;
using System.Collections;

namespace chart.classi
{
	/// <summary>
	/// Classe Manipolazione dati per manipolazioni statistiche.
	/// </summary>
	public class StatisticheDati
	{
		private ArrayList _Rarr = new ArrayList() ;

		public StatisticheDati()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}

		public void Add( float num)
		{
			_Rarr.Add( num );
		}

		public float Media
		{
			get 
			{
				return RoMedio();
			}
		}
		public float Varianza
		{
			get
			{
				return RoVarianza();
			}
		}
		private float RoMedio()
		{
			float Sum=0F,TMedia=0F;

			for (int i =0; i < _Rarr.Count; i++)
			{
			Sum = Sum + Convert.ToSingle(_Rarr[i].ToString());
			}
			TMedia = Sum / (Convert.ToSingle(_Rarr.Count));
			return TMedia;
		}
	

		public float RoVarianza()
		{

			float sumQ=0F, TVarianza=0F, TMedia;
			TMedia = RoMedio();
			for (int i =0; i < _Rarr.Count; i++)
			{
			sumQ = sumQ+ Convert.ToSingle(Math.Pow((TMedia - Convert.ToSingle(_Rarr[i].ToString())),2));
			}
			//Stima della varianza
			TVarianza = Convert.ToSingle( Math.Sqrt(1.0/(_Rarr.Count-1.0) * sumQ));
			return TVarianza;
		}

	}
}
