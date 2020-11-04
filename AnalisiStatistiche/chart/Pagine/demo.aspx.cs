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
using System.Globalization;
using TheSite.Classi.AnalisiStatistiche;
using S_Controls.Collections;
using ApplicationDataLayer.DBType;
using TheSite.SchemiXSD;

namespace chart
{
	/// <summary>
	/// Descrizione di riepilogo per WebForm1.
	/// </summary>
	public class demo : System.Web.UI.Page
	{
		protected TrasfCoord PuntoTrasformato = new TrasfCoord();
		protected int width,height,Npx,Nhh,Rdisco,ScalaLinare,ScalaLogaritmica,i_Tipologia,Anno;
		protected float Fwidth,Fheight,zoom,esponente;
		protected string S_optBtnRdlDispersioneRA,S_optBtnRdlDispersioneAC,S_optBtnRdlDispersioneRC;
		private enum TipoM {Richiesta=1 ,Programmata,Straordinaria,Entrambe};
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			ScalaLinare			     = Convert.ToInt32(Request["ScalaLinare"]);
			ScalaLogaritmica	     = Convert.ToInt32(Request["ScalaLogaritmica"]);
			esponente			     = Convert.ToSingle(Request["esponente"]);
			Rdisco				     = Convert.ToInt32(Request["Rdisco"]);
			zoom				     = Convert.ToSingle(Request["zoom"]);
			Nhh					     = Convert.ToInt32(Request["Nhh"]);
			Npx					     = Convert.ToInt32(Request["Npx"]);
			i_Tipologia              = Convert.ToInt32(Request["i_Tipologia"]);
			Anno                     = Convert.ToInt32(Request["Anno"]);
			S_optBtnRdlDispersioneAC = Convert.ToString(Request["S_optBtnRdlDispersioneAC"]);
			S_optBtnRdlDispersioneRA = Convert.ToString(Request["S_optBtnRdlDispersioneRA"]);
			S_optBtnRdlDispersioneRC = Convert.ToString(Request["S_optBtnRdlDispersioneRC"]);
			

			if(ScalaLinare == 1)
			{
				Fwidth = Convert.ToSingle(zoom *(2* Nhh) * Npx +2*Rdisco);
				width  =Convert.ToInt32( zoom * (2*Nhh) * Npx + 2*Rdisco) ;
			}
			else if (ScalaLogaritmica ==1)
			{
				float FMezzoLato = Convert.ToSingle(Math.Log( zoom * Nhh * Npx)*Math.Exp(esponente) + Rdisco );
				Fwidth = FMezzoLato *2F;
				width  = Convert.ToInt32(Fwidth) ;
			}
			else
			{
			}

			
			writeBar();
		}

		private void writeBar()
		{
			// dimensioni dell'immagine
			
			height = width;
			Fheight = Fwidth;

			// creo una nuova immagine
			int latoImmagine = width+ Convert.ToInt32(Npx*zoom *20)+20;
			Bitmap bitmap = new Bitmap(latoImmagine,latoImmagine);
			// oggetto graphics, necessario per manipolare il file

			Graphics g = Graphics.FromImage(bitmap);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			
			

			// disegno il voto
			g.Clear(ColorTranslator.FromHtml("white"));

			//imposta i parametri da inviare all'oggetto che trasforma le cordinate 
			// da polaria cartesiane.
//			float angoloRadianti;
			// costante di traformazione per la conversione in radianti 
			// dei giorni dell'anno
//			double Conv = 2*Math.PI/365;
			// traslazione del grafico rispetto all'origine standard
			if(ScalaLinare == 1)
			{
				PuntoTrasformato.DeltaX = Npx*zoom * 10;
				PuntoTrasformato.DeltaY = Npx*zoom * 10;
			}
			else if(ScalaLogaritmica ==1)
			{
				PuntoTrasformato.DeltaX =0F;
				PuntoTrasformato.DeltaY =0F;
			}
			// tralazione dei dati lungo i raggi congiungenti l'origene
			PuntoTrasformato.DeltaRo=Convert.ToSingle(Rdisco);
			// Raggio della torta
			PuntoTrasformato.Raggio = Fwidth/2.0F;
			chart.classi.LayerGrafico basedisegno = new chart.classi.LayerGrafico(g,Rdisco,PuntoTrasformato.PCenter);
			basedisegno.DisegnaPie(new Size(width,width),Anno,PuntoTrasformato.PCenter,Color.Black,Color.White);
			basedisegno.DisegnaPie(new Size(2*Rdisco,2*Rdisco),Anno,PuntoTrasformato.PCenter,Color.FromArgb(100,0,200,0),Color.FromArgb(100,0,200,0));
			basedisegno.DisegnaMesi();
			DisegnaDati(g);
			DisegnaStatistiche(g);
			basedisegno.DisplayMisure(Nhh,PuntoTrasformato.PCenter,Npx*zoom,ScalaLinare,ScalaLogaritmica,esponente);
			g.Dispose();
			// cambio di content type
			Response.Clear();
			bitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
			bitmap.Dispose();
			Response.End();
		}
		private DsAnalisiStatistiche DsDati(DsAnalisiStatistiche ds,int tipologia)
		{
			int progetto;
			if (Session["VarApp"] != null)
				 progetto = Convert.ToInt32(Session["VarApp"]);
			else
				progetto = 0;
			try
			{
				TheSite.Classi.AnalisiStatistiche.wrapDb _IODB = new TheSite.Classi.AnalisiStatistiche.wrapDb();
				S_Controls.Collections.S_ControlsCollection _Scollection = new S_Controls.Collections.S_ControlsCollection();

				S_Controls.Collections.S_Object s_anno  = new S_Controls.Collections.S_Object();

				s_anno.ParameterName = "S_ANNO";
				s_anno.DbType = CustomDBType.Integer;
				s_anno.Direction = ParameterDirection.Input;
				s_anno.Size =3;
				s_anno.Index = _Scollection.Count +1;
				s_anno.Value = Anno;
				_Scollection.Add(s_anno);;

				S_Controls.Collections.S_Object i_tip  = new S_Controls.Collections.S_Object();
				i_tip.ParameterName = "S_TIPOLOGIA";
				i_tip.DbType = CustomDBType.Integer;
				i_tip.Direction = ParameterDirection.Input;
				i_tip.Size =3;
				i_tip.Index =_Scollection.Count +1;
				i_tip.Value = tipologia;
				_Scollection.Add(i_tip);

				// nuovo parametro per il progetto

				S_Controls.Collections.S_Object i_progetto  = new S_Controls.Collections.S_Object();
				i_progetto.ParameterName = "S_PROGETTO";
				i_progetto.DbType = CustomDBType.Integer;
				i_progetto.Direction = ParameterDirection.Input;
				i_progetto.Index = _Scollection .Count +1;
				i_progetto.Value = progetto;
				_Scollection.Add(i_progetto);

				S_Controls.Collections.S_Object s_Cursor =  new S_Controls.Collections.S_Object();
				s_Cursor.ParameterName = "IO_CORSUR";
				s_Cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = _Scollection .Count +1;
				_Scollection.Add(s_Cursor);

				_IODB.s_storedProcedureName=GetNomeStrPrd();
				DataSet _MyDataset = _IODB.GetData(_Scollection).Copy();
				int i = 0;
				for(i=0; i<= _MyDataset.Tables[0].Rows.Count-1;i++)
				{ 
					ds.Tables["ChartRadar"].ImportRow(_MyDataset.Tables[0].Rows[i]);
				}
				if(i==0)
				{
					throw new Exception("* Non ci sono Rdl nell'intervallo temporale che hai selezionato, cambia intervallo e riprova.");
				}
				return ds;
			}
			catch(Exception ex)
			{
				Server.Transfer("../../Error.aspx?msgErr=" + ex.Message);
				return null;
			}
		}

		private DataSet DsStat()
		{
				wrapDb IOstat = new wrapDb();
				S_ControlsCollection ColParStat =new S_ControlsCollection();
				S_Object ParAnno           = new S_Object();
				S_Object ParTipologia      = new S_Object();
				S_Object ParTipoIntervallo = new S_Object();
				S_Object ParCursore        = new S_Object();

				ParAnno.ParameterName = "S_ANNO";
				ParAnno.DbType = CustomDBType.Integer;
				ParAnno.Direction = ParameterDirection.Input;
				ParAnno.Size = 10;
				ParAnno.Index = 0;
				ParAnno.Value = Anno;
				ColParStat.Add(ParAnno);

				ParTipologia.ParameterName = "S_TIPOLOGIA";
				ParTipologia.DbType = CustomDBType.Integer;
				ParTipologia.Direction = ParameterDirection.Input;
				ParTipologia.Size = 10;
				ParTipologia.Index = 1;
				ParTipologia.Value = i_Tipologia;
				ColParStat.Add(ParTipologia);

				ParTipoIntervallo.ParameterName = "S_TIPO_INTERVALLO";
				ParTipoIntervallo.DbType = CustomDBType.Integer;
				ParTipoIntervallo.Direction = ParameterDirection.Input;
				ParTipoIntervallo.Size = 10;
				ParTipoIntervallo.Index = 2;
				ParTipoIntervallo.Value = GetTipoIntervallo();
				ColParStat.Add(ParTipoIntervallo);

				ParCursore.ParameterName = "IO_CORSUR";
				ParCursore.DbType = CustomDBType.Cursor;
				ParCursore.Direction = ParameterDirection.Output;
				ParCursore.Index = 3;
				ColParStat.Add(ParCursore);

				IOstat.s_storedProcedureName = "PACK_ANALISI_STATISTICHE.MEDIA_DISPERSIONE_RDL";
				DataSet _MyDataset = new DataSet();
				_MyDataset = IOstat.GetData(ColParStat).Copy();
				
				return _MyDataset;
		}
		private string GetNomeStrPrd()
		{
			string Nome="PACK_ANALISI_STATISTICHE.";
			if(S_optBtnRdlDispersioneRA.ToUpper(new CultureInfo("it",false )) == "true".ToUpper(new CultureInfo("it",false )))
			{
				Nome +="GET_DATI_DISPERSIONE_RA";
			}
			if(S_optBtnRdlDispersioneAC.ToUpper(new CultureInfo("it",false )) == "true".ToUpper(new CultureInfo("it",false )))
			{
				Nome +="GET_DATI_DISPERSIONE_AC";
			}
			if(S_optBtnRdlDispersioneRC.ToUpper(new CultureInfo("it",false )) == "true".ToUpper(new CultureInfo("it",false )))
			{
				Nome +="GET_DATI_DISPERSIONE_RC";
			}
			return Nome;
		}
		private int GetTipoIntervallo()
		{
			int TipoIntervallo;
			if(S_optBtnRdlDispersioneRA.ToUpper(new CultureInfo("it",false )) == "TRUE")
			{
				TipoIntervallo = 0;
			}
			else if(S_optBtnRdlDispersioneAC.ToUpper(new CultureInfo("it",false )) == "TRUE")
			{
				TipoIntervallo = 1;
			}
			else if(S_optBtnRdlDispersioneRC.ToUpper(new CultureInfo("it",false )) == "TRUE")
			{
				TipoIntervallo = 2;
			}
			else 
			{
				throw new Exception("Valore del tipo dell'inervallo non impostato");
				//return -1;
			}
			return TipoIntervallo;
		}
			
		private void DisegnaDati( Graphics gr)
		{
			/* Calcolo e disegno della media nel grafico*/
			//DataSet RdlDati = new DataSet();
			DsAnalisiStatistiche RdlDati = new DsAnalisiStatistiche();
			if(i_Tipologia == (int)TipoM.Entrambe)
			{
				RdlDati = DsDati(RdlDati,(int)TipoM.Richiesta);
				RdlDati = DsDati(RdlDati,(int)TipoM.Straordinaria);
			}
			else
			{
				RdlDati = DsDati(RdlDati,i_Tipologia);
			}
			

			TrAngoliDate Ang = new TrAngoliDate();
			foreach (DataRow R in RdlDati.Tables["ChartRadar"].Rows)
			{
				if (!(R["GG"].ToString()=="")) 
				{
					if(ScalaLinare ==1)
					{
						PuntoTrasformato.Ro= Convert.ToSingle(R["DELTA"].ToString()) * Npx * zoom ;
					}
					else if (ScalaLogaritmica ==1)
					{
						PuntoTrasformato.Ro= Convert.ToSingle( Math.Log( Convert.ToDouble(R["DELTA"].ToString())* Npx * zoom) * Math.Exp(esponente));
					}
				}
				else
				{
				}
			
				PuntoTrasformato.Tetha = Ang.TrasformaAngoliInRadianti(Convert.ToSingle(R["GG"].ToString()),Ang.GiorniDellAnno(Anno));
				
//				gr.FillEllipse(System.Drawing.Brushes.Brown, PuntoTrasformato.PRect);
				int Priority = Convert.ToInt32(R["PRIORITY"].ToString());
				int Penale =0;
				if(R["PENALE"].ToString() != "")
				{
					 Penale = Convert.ToInt32(R["PENALE"].ToString());
				}
				else
				{
					Penale = 0;
				}
				int Delta = Convert.ToInt32(R["DELTA"].ToString());


				SolidBrush PtBrush = new SolidBrush(PtColor(Priority,Penale,Delta));
				gr.FillEllipse(PtBrush, PuntoTrasformato.PRect);
			
			}
		}
		private Color PtColor(int Prioriy, int Data_sal,int DeltaRdl)
		{
			
			Color TmpColore = Color.Black;
			if(GetTipoIntervallo()== 0)
			{
				switch(Prioriy)
				{
					case 1:
					{
						if(DeltaRdl <=  24)
						{
							TmpColore = Color.Blue;
						}
						else
						{
							TmpColore = Color.Red;
						}
					
						break;
					}
					case 2:
					{
						if(DeltaRdl <= 24)
						{
							TmpColore = Color.Blue;
						}
						else
						{
							TmpColore = Color.Red;
						}
						break;
					}
					case 3:
					{
						if(DeltaRdl <= 24)
						{
							TmpColore = Color.Blue;
						}
						else
						{
							TmpColore = Color.Red;
						}
						break;
					}
					case 4:
					{
						TmpColore = Color.Blue;
						break;
					}
					case 5:
					{
						TmpColore = Color.Blue;
						break;

					}
					case 6:
					{
						TmpColore = Color.Blue;
						break;

					}
					default:
						break;
				}
			}
			else if(GetTipoIntervallo() == 1)
			{
				switch(Prioriy)
				{
					case 1:
					{
						if(DeltaRdl <=  Data_sal)
						{
							TmpColore = Color.Blue;
						}
						else
						{
							TmpColore = Color.Red;
						}
					
						break;
					}
					case 2:
					{
						if(DeltaRdl <= Data_sal)
						{
							TmpColore = Color.Blue;
						}
						else
						{
							TmpColore = Color.Red;
						}
						break;
					}
					case 3:
					{
						if(DeltaRdl <= Data_sal)
						{
							TmpColore = Color.Blue;
						}
						else
						{
							TmpColore = Color.Red;
						}
						break;
					}
					case 4:
					{
						TmpColore = Color.Blue;
						break;
					}
					case 5:
					{
						TmpColore = Color.Blue;
						break;

					}
					case 6:
					{
						TmpColore = Color.Blue;
						break;

					}
					default:
					break;
				}
			}
			else 
			{
			switch(Prioriy)
				{
					case 1:
					{
						if(DeltaRdl <=  48)
						{
							TmpColore = Color.Blue;
						}
						else
						{
							TmpColore = Color.Red;
						}
					
						break;
					}
					case 2:
					{
						if(DeltaRdl <= 48)
						{
							TmpColore = Color.Blue;
						}
						else
						{
							TmpColore = Color.Red;
						}
						break;
					}
					case 3:
					{
						if(DeltaRdl <= 72)
						{
							TmpColore = Color.Blue;
						}
						else
						{
							TmpColore = Color.Red;
						}
						break;
					}
					case 4:
					{
						TmpColore = Color.Blue;
						break;
					}
					case 5:
					{
						TmpColore = Color.Blue;
						break;

					}
					case 6:
					{
						TmpColore = Color.Blue;
						break;

					}
					default:
						break;
				}
			}
			return TmpColore;
		}
		private void DisegnaStatistiche(Graphics gr)
		{
			DataSet RdlDati = new DataSet();
			RdlDati = DsStat().Copy();
//			float Media =0F,Varianza = 0F,Max=0F,Min=0F;
			float Media =0F;
			foreach (DataRow R in RdlDati.Tables[0].Rows)
			{
				if (!(R["MEDIA"].ToString()=="")) 
				{

					if(ScalaLinare ==1)
					{
						Media = Convert.ToSingle(R["MEDIA"].ToString()) * Npx * zoom;
					}
					else if (ScalaLogaritmica ==1)
					{
						Media= Convert.ToSingle(Math.Log(Media) * Math.Exp(esponente));
					}
				}
				else
				{
					// nell'anno considerato non ci sono Dati(Rdl)
				}
			}
			
			SizeF SzPie   = new SizeF(width,width);
			SizeF SzMedia = new SizeF(2F*(Media+Rdisco),2F*(Media+Rdisco));
//			SizeF Sz24 = new SizeF(2F * (Max+Rdisco),2F * (Max +Rdisco));
//			SizeF SzMin = new SizeF(2F * (Min +Rdisco),2F * (Min +Rdisco));
//			
//			PointF PPie = new PointF();
//			PPie.X = PuntoTrasformato.PCenter.X - width/2;
//			PPie.Y = PuntoTrasformato.PCenter.Y - width/2;
//			RectangleF RctPie = new RectangleF(PPie,SzPie);

			PointF Pmed = new PointF();
			Pmed.X = PuntoTrasformato.PCenter.X - Media - Rdisco;
			Pmed.Y = PuntoTrasformato.PCenter.Y - Media- Rdisco;
			RectangleF RctMedia= new RectangleF(Pmed,SzMedia);

//			PointF Pmax = new PointF();
//			Pmax.X = PuntoTrasformato.PCenter.X - Max - Rdisco;
//			Pmax.Y = PuntoTrasformato.PCenter.Y - Max- Rdisco;
//			RectangleF RctMax= new RectangleF(Pmax,SzMax);
//
//			PointF Pmin = new PointF();
//			Pmin.X = PuntoTrasformato.PCenter.X - Min - Rdisco;
//			Pmin.Y = PuntoTrasformato.PCenter.Y - Min- Rdisco;
//			RectangleF RctMin= new RectangleF(Pmin,SzMin);


			gr.DrawEllipse(Pens.Red,RctMedia);
//			gr.DrawEllipse(Pens.Red,RctMax);
//			gr.DrawEllipse(Pens.Red,RctMin);
//			
//			GraphicsPath path1 = new GraphicsPath();
//			GraphicsPath path2 = new GraphicsPath();
//			GraphicsPath path3 = new GraphicsPath();
//			
//			path1.AddEllipse(RctMax);
//			//			path1.AddEllipse(recMmenoS);
//			
//			path2.AddEllipse(RctMin);
//
//			path3.AddEllipse(RctPie);
//			//
//			Region rgn1 = new Region(path1);
//			Region rgn2 = new Region(path2);
//			Region rgn3 = new Region(path3);
//			rgn1.Xor(path2);
//			rgn1.Intersect(path3);
//					  SolidBrush lgBrush = new SolidBrush(Color.FromArgb(25,0,0,255));
//			//			g.FillRegion(new SolidBrush(Color.FromArgb(50,0,0,200)),rgn1);
//						gr.FillRegion(lgBrush,rgn1);
		}
		#region Codice generato da Progettazione Web Form
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: questa chiamata è richiesta da Progettazione Web Form ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}


}
