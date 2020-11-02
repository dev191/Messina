using System;
using System.Drawing;
using System.Collections;

namespace chart.classi
{
	/// <summary>
	/// Descrizione di riepilogo per ClasseMatematica.
	/// </summary>
	public class TrAngoliDate
	{
		private ArrayList _Rarr = new ArrayList();
		public  TrAngoliDate()
		{
		}

		public float TraformaAngoliInGradi(float Angolo, float AngoloGiro)
		{
			return Convert.ToSingle(360* Angolo/AngoloGiro);
		}
		public float TrasformaAngoliInRadianti(float Angolo, float AngoloGiro)
		{
			return Convert.ToSingle( 2.0*Math.PI * Angolo / AngoloGiro);
		}

	
		public float AngoloMeseGradi( int mese, int anno)
		{
			float AngoloG;
			AngoloG=TraformaAngoliInGradi(GiorniDelMese( anno,mese),GiorniDellAnno(anno));
			return AngoloG;

		}

		public float AngoloMeseRadianti( int mese, int anno)
		{
			float AngoloR;
			AngoloR=TrasformaAngoliInRadianti(GiorniDelMese( anno,mese),GiorniDellAnno(anno));
			return AngoloR;
		}


		public int GiorniDelMese(int anno,int mese)
		{
			int gg ;
			System.TimeSpan diff1;
			DateTime dateInit ;
			DateTime  dateOut;
			int[] giorniMese = new int[12];
			for (int i=0; i<11 ;i++)
			{
				dateInit = new DateTime(anno,i+1,1);
				dateOut = new DateTime(anno,i+2,1);
				diff1 = dateOut.Subtract(dateInit);
				giorniMese[i]= diff1.Days; 
			}
			dateInit = new DateTime(anno,12,1);
			dateOut= new DateTime(anno+1,1,1);
			diff1 = dateOut.Subtract(dateInit);
			giorniMese[11]= diff1.Days; 
			gg = giorniMese[mese];
			return gg;

		}
		public int GiorniDellAnno(int anno)
		{
			int gg;
			System.TimeSpan diff1;
			DateTime dateInit ;
			DateTime  dateOut;
			dateInit = new DateTime(anno,1,1);
			dateOut = new DateTime(anno+1,1,1);
			diff1 = dateOut.Subtract(dateInit);
			gg = diff1.Days;
			return gg;
		}
		public float TrRadGrad(float Rad)
		{
			return Convert.ToSingle(Rad/Math.PI * 180.0);
		}
		public float TrGradRad(float Grad)
		{
			return Convert.ToSingle(Grad/180.0 *Math.PI);
		}

		public string strMese(int mese)
		{
			string tmp;
			switch(mese)
			{
				case 0:	
				{				
					tmp= "Gennaio";
					break;
				}
				case 1:	
				{
					tmp= "Febbraio";
					break;
				}
				case 2:
				{
					tmp= "Marzo";
					break;
				}
				case 3:
				{
					tmp= "Aprile";	
					break;
				}
				case 4:
				{
					tmp= "Maggio";
					break;
				}
				case 5:
				{
					tmp= "Giugno";
					break;
				}	
				case 6:
				{
					tmp= "Luglio";
					break;
				}
				case 7:
				{
					tmp= "Agosto";
					break;
				}
				case 8:
				{
					tmp= "Settembre";
					break;
				}
				case 9:
				{
					tmp= "Ottobre";
					break;
				}
				case 10:
				{
					tmp= "Novembre";
					break;
				}	
				case 11:
				{
					tmp= "Dicembre";
					break;
				}
				default:
				{
					tmp= "";
					break;
				}
			}
			return tmp;
		}
	}
}
