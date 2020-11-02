using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using chart.classi;

namespace chart.classi
{
	/// <summary>
	/// Descrizione di riepilogo per LayerBae.
	/// </summary>
	public class LayerGrafico
	{
		private Graphics g;
		//		private Page curPage;
		//		private Bitmap curBitmap;
		private int raggio;
		private int diametro;
		PointF Center = new PointF();
		Point NCenter = new Point();

		public LayerGrafico(Graphics _g, int _raggioLeggenda,PointF _Center )
		{
			raggio = _raggioLeggenda;
			diametro  = 2* raggio;
			g=_g;
			//			curPage = cPage;
			//			curBitmap = new Bitmap(diametro+50,diametro+50);
			//			g = Graphics.FromImage(curBitmap);
			Center.X=  _Center.X;
			Center.Y = _Center.Y;

			NCenter.X = Convert.ToInt32(_Center.X - raggio);
			NCenter.Y =  Convert.ToInt32(_Center.Y - raggio);
			
		}

		
		// creo una nuova immagine
		
		// oggetto graphics, necessario per manipolare il file

		public void MostraLayerBase()
		{
			//			curPage.Response.ContentType="image/jpeg";
			//			g.SmoothingMode = SmoothingMode.AntiAlias;
			//			g.Clear(Color.White);
			//	DisegnaPie();
			//			DisegnaMesi();
			//			g.Dispose();
			//			curBitmap.Save(curPage.Response.OutputStream,ImageFormat.Jpeg);
			//			curBitmap.Dispose();
		}	
		
		public void DisegnaPie( Size SizePie,int anno)
		{
			Pen BlackPen = new Pen(Color.Black,1);
			
			
			//			int anno = 2005;
			//			Size SizePie = new Size(diametro,diametro);
			Rectangle RctPie = new Rectangle(NCenter,SizePie);
			TrAngoliDate AngoliMesi = new TrAngoliDate();
			float Alfa, Beta=0F;
			SolidBrush BrPiew = new SolidBrush(Color.FromArgb(100,0,0,150));

			for (int i = 0; i<12 ; i++)
			{
				Alfa=AngoliMesi.AngoloMeseGradi(i,anno);
				g.DrawPie(BlackPen,RctPie,-Beta,-Alfa);
				g.FillPie(BrPiew,RctPie,-Beta,-Alfa);
				Beta = Alfa + Beta;
			}
			BlackPen.Dispose();
			BrPiew.Dispose();
		}
		public void DisegnaPie( Size SizePie,int anno,PointF CenterPie)
		{
			Pen BlackPen = new Pen(Color.Black,1);
			Point Originepie = new Point();
			Originepie.X = Convert.ToInt32(CenterPie.X - Convert.ToInt32(SizePie.Width/2));
			Originepie.Y = Convert.ToInt32(CenterPie.Y - Convert.ToInt32(SizePie.Height/2));
			
			//			int anno = 2005;
			//			Size SizePie = new Size(diametro,diametro);
			Rectangle RctPie = new Rectangle(Originepie,SizePie);
			TrAngoliDate AngoliMesi = new TrAngoliDate();
			float Alfa, Beta=0F;
			SolidBrush BrPiew = new SolidBrush(Color.FromArgb(100,0,0,150));

			for (int i = 0; i<12 ; i++)
			{
				Alfa=AngoliMesi.AngoloMeseGradi(i,anno);
				g.DrawPie(BlackPen,RctPie,-Beta,-Alfa);
				g.FillPie(BrPiew,RctPie,-Beta,-Alfa);
				Beta = Alfa + Beta;
			}
			BlackPen.Dispose();
			BrPiew.Dispose();
		}
		public void DisegnaPie( Size SizePie,int anno,PointF CenterPie,Color DrawColol, Color FillColor)
		{
			Pen BlackPen = new Pen(DrawColol,1);
			Point Originepie = new Point();
			Originepie.X = Convert.ToInt32(CenterPie.X - Convert.ToInt32(SizePie.Width/2));
			Originepie.Y = Convert.ToInt32(CenterPie.Y - Convert.ToInt32(SizePie.Height/2));
			
			//			int anno = 2005;
			//			Size SizePie = new Size(diametro,diametro);
			Rectangle RctPie = new Rectangle(Originepie,SizePie);
			TrAngoliDate AngoliMesi = new TrAngoliDate();
			float Alfa, Beta=0F;
			SolidBrush BrPiew = new SolidBrush(FillColor);

			for (int i = 0; i<12 ; i++)
			{
				Alfa=AngoliMesi.AngoloMeseGradi(i,anno);
				g.DrawPie(BlackPen,RctPie,-Beta,-Alfa);
				g.FillPie(BrPiew,RctPie,-Beta,-Alfa);
				Beta = Alfa + Beta;
			}
			BlackPen.Dispose();
			BrPiew.Dispose();
		}
		public void DisegnaMesi()
		{
			// Create a GraphicsPath object.
			GraphicsPath myPath = new GraphicsPath();
			// Set up all the string parameters.
			TrAngoliDate AngRadMesi = new TrAngoliDate();
			StringFormat format = StringFormat.GenericDefault;
			float BetaG =0F;
			for (int i=0; i<12;i++)
			{
				float AlfaR = AngRadMesi.AngoloMeseRadianti(i,2005);
				float AlfaG = AngRadMesi.AngoloMeseGradi(i,2005);
				float baseR = Convert.ToSingle(3.0/4.0 * raggio * Math.Cos(AlfaR/2.0));
				float AltezzaR = Convert.ToSingle(1.0/2.0 * raggio * Math.Sin(AlfaR/2.0));
				SizeF SizeR = new SizeF( baseR,AltezzaR);
				RectangleF LblRect = new RectangleF(NCenter,SizeR);
				//myPath.AddRectangle(LblRect);
				string stringText = AngRadMesi.strMese(i);
				FontFamily family = new FontFamily("Arial");
				int fontStyle = (int)FontStyle.Italic;
				int emSize = Convert.ToInt32(AltezzaR) + 1;

				
				// Add the string to the path.
				myPath.AddString(stringText,family,fontStyle,emSize,Center,format);
				// Trasformazione Di  Traslazione sull'etichetta
				Matrix T = new Matrix();
				T.Translate(raggio/4, -AltezzaR);
				// Trasformazione Di  Rotazione Sull'etichetta
				Matrix R= new Matrix();
				R.RotateAt(-AlfaG/2.0F,new PointF(Center.X+raggio/4,Center.Y));
				T.Multiply(R,MatrixOrder.Append);
				myPath.Transform(T);
				Matrix RGlobale = new Matrix();
				RGlobale.RotateAt(-BetaG,Center);
				myPath.Transform(RGlobale);
				g.FillPath(Brushes.BlueViolet, myPath);
				T.Reset();
				R.Reset();
				RGlobale.Reset();
				myPath.Reset();
				BetaG = AlfaG+BetaG;
			}
	
		}
			
		public void DisplayMisure(float OraMax,PointF Origine,float unaOra,int ScalaLinare,int ScalaLogaritmica,float esponente)

		{
			float unit = 12.0F;
			double Dimax = Convert.ToDouble(OraMax/unit);
			double max = Math.Floor(Dimax);
			int Imax = Convert.ToInt32( max)+1;
			
			float MzLato=0F,Ore=0F;
			SizeF SzMisure;
			RectangleF RctMiure;
			PointF _Origine = new PointF();
			for(int i=0; i<Imax; i++)
			{
				_Origine.X = Origine.X;
				_Origine.Y = Origine.Y;
				Ore = Convert.ToSingle(i*unit*unaOra);
				if (ScalaLinare == 1)
				{
					MzLato = Ore+raggio;
				}
				else if (ScalaLogaritmica ==1)
				{
					MzLato = Convert.ToSingle(Math.Log(Ore)* Math.Exp(esponente))+raggio;
				}
				_Origine.X = _Origine.X - MzLato ;
				_Origine.Y = _Origine.Y - MzLato ;
		
				SzMisure = new SizeF(2*MzLato,2*MzLato);
				if (ScalaLinare == 1)
				{
					DisegnaUnitaNumeriche(Origine,MzLato,i*unit,unaOra);
				}
				RctMiure = new RectangleF(_Origine,SzMisure);
				g.DrawEllipse(Pens.Blue,RctMiure);
			}
		}
		private void DisegnaUnitaNumeriche(PointF Center, float DistanzaOrigine,float Valore,float FactorScala)
		{
			// Create a GraphicsPath object.
			GraphicsPath myPath = new GraphicsPath();
			TrAngoliDate AngRadMesi = new TrAngoliDate();
			// Set up all the string parameters.
			StringFormat format = StringFormat.GenericDefault;
			float OB=5F * FactorScala;
			float BetaG =0F;
			for (int i=0; i<12;i++)
			{
				float AlfaR = AngRadMesi.AngoloMeseRadianti(i,2005);
				float AlfaG = AngRadMesi.AngoloMeseGradi(i,2005);
				float baseR = Convert.ToSingle(OB * Math.Cos(AlfaR/2.0));
				float AltezzaR = Convert.ToSingle(2.0 * OB * Math.Sin(AlfaR/2.0));
				SizeF SizeR = new SizeF( baseR,AltezzaR);
				RectangleF LblRect = new RectangleF(Center,SizeR);
				//myPath.AddRectangle(LblRect);
				string stringText = Convert.ToString(Valore)+" (hh)";
				FontFamily family = new FontFamily("Arial");
				int fontStyle = (int)FontStyle.Italic;
				int emSize = Convert.ToInt32(AltezzaR) + 1;

				
				// Add the string to the path.
				myPath.AddString(stringText,family,fontStyle,emSize,Center,format);
				// Trasformazione Di  Traslazione sull'etichetta
				Matrix T = new Matrix();
				T.Translate(DistanzaOrigine, -AltezzaR);
				 //Trasformazione Di  Rotazione Sull'etichetta
				Matrix R= new Matrix();
//				R.RotateAt(-AlfaG/2.0F,new PointF(Center.X+DistanzaOrigine,Center.Y));
				R.RotateAt(0.0F,new PointF(Center.X+DistanzaOrigine,Center.Y));
				T.Multiply(R,MatrixOrder.Append);
				myPath.Transform(T);
				Matrix RGlobale = new Matrix();
				RGlobale.RotateAt(-BetaG,Center);
				myPath.Transform(RGlobale);
				g.FillPath(Brushes.Black, myPath);
				T.Reset();
				R.Reset();
				RGlobale.Reset();
				myPath.Reset();
				BetaG = AlfaG+BetaG;
			}
		}
	}
}