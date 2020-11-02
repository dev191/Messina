using System;
using System.Drawing;
using chart.classi;


namespace chart.classi
{
	
	/// <summary>
	/// Descrizione di riepilogo per TrasfCoord.
	/// </summary>
	public class TrasfCoord
	{
		PointF _P= new PointF();
		float _Ro, _Tetha, _Raggio,_DeltaX,_DeltaY,_DelataRo;
		StatisticheDati Stat = new StatisticheDati();
		public TrasfCoord()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}

		public RectangleF PRect
		{
			get
			{
				return PointQuadrato();
			}
		}
		public float Ro
		{
			set
			{
				_Ro=value;
				Stat.Add(_Ro);
			}
	
		}
		public float Tetha
		{
			set
			{
				_Tetha = value;
			}
		}

		public float Raggio
		{
			set
			{
				_Raggio = value;
			}
		}
		public float DeltaX
		{
			set
			{
				_DeltaX = value;
			}
		}
		public float DeltaY
		{
			set
			{
				_DeltaY = value;
			}
		}
		public float DeltaRo
		{
			set
			{
				_DelataRo = value;
			}
		}
		public PointF PCenter
		{
			get
			{
				PointF Delta = new PointF(_DeltaX + _Raggio,_DeltaY+ _Raggio);
				return Delta;
				
			}
		}
		public float RoMedio
		{
			get
			{
				return Stat.Media;
			}
		}
		public float VarRo
		{
			get
			{
				return Stat.Varianza;
			}
		}
		public PointF PCartesiano
		{
			get
			{
				_P.X=CordinataX(_Ro,_Tetha,_Raggio,_DeltaX);
				_P.Y=CordinataY(_Ro,_Tetha,_Raggio,_DeltaY);
				return _P;
			}
		}
		private RectangleF PointQuadrato()
		{
				
			_P.X=CordinataX(_Ro + _DelataRo,_Tetha,_Raggio,_DeltaX);
			_P.Y=CordinataY(_Ro + _DelataRo,_Tetha,_Raggio,_DeltaY);
			float lato =4.0F;
			RectangleF tmp= new RectangleF( _P.X -lato/2.0F, _P.Y - lato/2.0F, lato,lato);
			return tmp;
		}

		private float CordinataX( float r, float alfa,float rMax, float dX)
		{
//			return raggio *   Math.Cos(angolo) + latoRettangolo/2.0 + deltaX;
			return  r * Convert.ToSingle(Math.Cos(alfa)) + rMax + dX;
		}
		private float CordinataY( float r, float alfa ,float rMax , float dY)
		{
//			return  -raggio *  Math.Sin(angolo) + latoRettangolo/2.0 + deltaY;
			return  - r * Convert.ToSingle(Math.Sin(alfa)) + rMax +dY;
		}
	}


}
