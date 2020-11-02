// Decompiled with JetBrains decompiler
// Type: chart.demo
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using chart.classi;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Web.UI;
using TheSite.Classi.AnalisiStatistiche;
using TheSite.SchemiXSD;

namespace chart
{
  public class demo : Page
  {
    protected TrasfCoord PuntoTrasformato = new TrasfCoord();
    protected int width;
    protected int height;
    protected int Npx;
    protected int Nhh;
    protected int Rdisco;
    protected int ScalaLinare;
    protected int ScalaLogaritmica;
    protected int i_Tipologia;
    protected int Anno;
    protected float Fwidth;
    protected float Fheight;
    protected float zoom;
    protected float esponente;
    protected string S_optBtnRdlDispersioneRA;
    protected string S_optBtnRdlDispersioneAC;
    protected string S_optBtnRdlDispersioneRC;

    private void Page_Load(object sender, EventArgs e)
    {
      this.ScalaLinare = Convert.ToInt32(this.Request["ScalaLinare"]);
      this.ScalaLogaritmica = Convert.ToInt32(this.Request["ScalaLogaritmica"]);
      this.esponente = Convert.ToSingle(this.Request["esponente"]);
      this.Rdisco = Convert.ToInt32(this.Request["Rdisco"]);
      this.zoom = Convert.ToSingle(this.Request["zoom"]);
      this.Nhh = Convert.ToInt32(this.Request["Nhh"]);
      this.Npx = Convert.ToInt32(this.Request["Npx"]);
      this.i_Tipologia = Convert.ToInt32(this.Request["i_Tipologia"]);
      this.Anno = Convert.ToInt32(this.Request["Anno"]);
      this.S_optBtnRdlDispersioneAC = Convert.ToString(this.Request["S_optBtnRdlDispersioneAC"]);
      this.S_optBtnRdlDispersioneRA = Convert.ToString(this.Request["S_optBtnRdlDispersioneRA"]);
      this.S_optBtnRdlDispersioneRC = Convert.ToString(this.Request["S_optBtnRdlDispersioneRC"]);
      if (this.ScalaLinare == 1)
      {
        this.Fwidth = Convert.ToSingle(this.zoom * (float) (2 * this.Nhh) * (float) this.Npx + (float) (2 * this.Rdisco));
        this.width = Convert.ToInt32(this.zoom * (float) (2 * this.Nhh) * (float) this.Npx + (float) (2 * this.Rdisco));
      }
      else if (this.ScalaLogaritmica == 1)
      {
        this.Fwidth = Convert.ToSingle(Math.Log((double) this.zoom * (double) this.Nhh * (double) this.Npx) * Math.Exp((double) this.esponente) + (double) this.Rdisco) * 2f;
        this.width = Convert.ToInt32(this.Fwidth);
      }
      this.writeBar();
    }

    private void writeBar()
    {
      this.height = this.width;
      this.Fheight = this.Fwidth;
      int num = this.width + Convert.ToInt32((float) ((double) this.Npx * (double) this.zoom * 20.0)) + 20;
      Bitmap bitmap = new Bitmap(num, num);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.Clear(ColorTranslator.FromHtml("white"));
      if (this.ScalaLinare == 1)
      {
        this.PuntoTrasformato.DeltaX = (float) ((double) this.Npx * (double) this.zoom * 10.0);
        this.PuntoTrasformato.DeltaY = (float) ((double) this.Npx * (double) this.zoom * 10.0);
      }
      else if (this.ScalaLogaritmica == 1)
      {
        this.PuntoTrasformato.DeltaX = 0.0f;
        this.PuntoTrasformato.DeltaY = 0.0f;
      }
      this.PuntoTrasformato.DeltaRo = Convert.ToSingle(this.Rdisco);
      this.PuntoTrasformato.Raggio = this.Fwidth / 2f;
      LayerGrafico layerGrafico = new LayerGrafico(graphics, this.Rdisco, this.PuntoTrasformato.PCenter);
      layerGrafico.DisegnaPie(new Size(this.width, this.width), this.Anno, this.PuntoTrasformato.PCenter, Color.Black, Color.White);
      layerGrafico.DisegnaPie(new Size(2 * this.Rdisco, 2 * this.Rdisco), this.Anno, this.PuntoTrasformato.PCenter, Color.FromArgb(100, 0, 200, 0), Color.FromArgb(100, 0, 200, 0));
      layerGrafico.DisegnaMesi();
      this.DisegnaDati(graphics);
      this.DisegnaStatistiche(graphics);
      layerGrafico.DisplayMisure((float) this.Nhh, this.PuntoTrasformato.PCenter, (float) this.Npx * this.zoom, this.ScalaLinare, this.ScalaLogaritmica, this.esponente);
      graphics.Dispose();
      this.Response.Clear();
      bitmap.Save(this.Response.OutputStream, ImageFormat.Jpeg);
      bitmap.Dispose();
      this.Response.End();
    }

    private DsAnalisiStatistiche DsDati(DsAnalisiStatistiche ds, int tipologia)
    {
      int num = this.Session["VarApp"] == null ? 0 : Convert.ToInt32(this.Session["VarApp"]);
      try
      {
        wrapDb wrapDb = new wrapDb();
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("S_ANNO");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Size(3);
        ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
        ((ParameterObject) sObject1).set_Value((object) this.Anno);
        CollezioneControlli.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("S_TIPOLOGIA");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Size(3);
        ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
        ((ParameterObject) sObject2).set_Value((object) tipologia);
        CollezioneControlli.Add(sObject2);
        S_Object sObject3 = new S_Object();
        ((ParameterObject) sObject3).set_ParameterName("S_PROGETTO");
        ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
        ((ParameterObject) sObject3).set_Value((object) num);
        CollezioneControlli.Add(sObject3);
        S_Object sObject4 = new S_Object();
        ((ParameterObject) sObject4).set_ParameterName("IO_CORSUR");
        ((ParameterObject) sObject4).set_DbType((CustomDBType) 8);
        ((ParameterObject) sObject4).set_Direction(ParameterDirection.Output);
        ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
        CollezioneControlli.Add(sObject4);
        wrapDb.s_storedProcedureName = this.GetNomeStrPrd();
        DataSet dataSet = wrapDb.GetData(CollezioneControlli).Copy();
        int index;
        for (index = 0; index <= dataSet.Tables[0].Rows.Count - 1; ++index)
          ds.Tables["ChartRadar"].ImportRow(dataSet.Tables[0].Rows[index]);
        if (index == 0)
          throw new Exception("* Non ci sono Rdl nell'intervallo temporale che hai selezionato, cambia intervallo e riprova.");
        return ds;
      }
      catch (Exception ex)
      {
        this.Server.Transfer("../../Error.aspx?msgErr=" + ex.Message);
        return (DsAnalisiStatistiche) null;
      }
    }

    private DataSet DsStat()
    {
      wrapDb wrapDb = new wrapDb();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      S_Object sObject2 = new S_Object();
      S_Object sObject3 = new S_Object();
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("S_ANNO");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(10);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.Anno);
      CollezioneControlli.Add(sObject1);
      ((ParameterObject) sObject2).set_ParameterName("S_TIPOLOGIA");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) this.i_Tipologia);
      CollezioneControlli.Add(sObject2);
      ((ParameterObject) sObject3).set_ParameterName("S_TIPO_INTERVALLO");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) this.GetTipoIntervallo());
      CollezioneControlli.Add(sObject3);
      ((ParameterObject) sObject4).set_ParameterName("IO_CORSUR");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject4).set_Index(3);
      CollezioneControlli.Add(sObject4);
      wrapDb.s_storedProcedureName = "PACK_ANALISI_STATISTICHE.MEDIA_DISPERSIONE_RDL";
      DataSet dataSet = new DataSet();
      return wrapDb.GetData(CollezioneControlli).Copy();
    }

    private string GetNomeStrPrd()
    {
      string str = "PACK_ANALISI_STATISTICHE.";
      if (this.S_optBtnRdlDispersioneRA.ToUpper(new CultureInfo("it", false)) == "true".ToUpper(new CultureInfo("it", false)))
        str += "GET_DATI_DISPERSIONE_RA";
      if (this.S_optBtnRdlDispersioneAC.ToUpper(new CultureInfo("it", false)) == "true".ToUpper(new CultureInfo("it", false)))
        str += "GET_DATI_DISPERSIONE_AC";
      if (this.S_optBtnRdlDispersioneRC.ToUpper(new CultureInfo("it", false)) == "true".ToUpper(new CultureInfo("it", false)))
        str += "GET_DATI_DISPERSIONE_RC";
      return str;
    }

    private int GetTipoIntervallo()
    {
      if (this.S_optBtnRdlDispersioneRA.ToUpper(new CultureInfo("it", false)) == "TRUE")
        return 0;
      if (this.S_optBtnRdlDispersioneAC.ToUpper(new CultureInfo("it", false)) == "TRUE")
        return 1;
      if (this.S_optBtnRdlDispersioneRC.ToUpper(new CultureInfo("it", false)) == "TRUE")
        return 2;
      throw new Exception("Valore del tipo dell'inervallo non impostato");
    }

    private void DisegnaDati(Graphics gr)
    {
      DsAnalisiStatistiche ds = new DsAnalisiStatistiche();
      DsAnalisiStatistiche analisiStatistiche = this.i_Tipologia != 4 ? this.DsDati(ds, this.i_Tipologia) : this.DsDati(this.DsDati(ds, 1), 3);
      TrAngoliDate trAngoliDate = new TrAngoliDate();
      foreach (DataRow row in (InternalDataCollectionBase) analisiStatistiche.Tables["ChartRadar"].Rows)
      {
        if (!(row["GG"].ToString() == ""))
        {
          if (this.ScalaLinare == 1)
            this.PuntoTrasformato.Ro = Convert.ToSingle(row["DELTA"].ToString()) * (float) this.Npx * this.zoom;
          else if (this.ScalaLogaritmica == 1)
            this.PuntoTrasformato.Ro = Convert.ToSingle(Math.Log(Convert.ToDouble(row["DELTA"].ToString()) * (double) this.Npx * (double) this.zoom) * Math.Exp((double) this.esponente));
        }
        this.PuntoTrasformato.Tetha = trAngoliDate.TrasformaAngoliInRadianti(Convert.ToSingle(row["GG"].ToString()), (float) trAngoliDate.GiorniDellAnno(this.Anno));
        SolidBrush solidBrush = new SolidBrush(this.PtColor(Convert.ToInt32(row["PRIORITY"].ToString()), !(row["PENALE"].ToString() != "") ? 0 : Convert.ToInt32(row["PENALE"].ToString()), Convert.ToInt32(row["DELTA"].ToString())));
        gr.FillEllipse((Brush) solidBrush, this.PuntoTrasformato.PRect);
      }
    }

    private Color PtColor(int Prioriy, int Data_sal, int DeltaRdl)
    {
      Color color = Color.Black;
      if (this.GetTipoIntervallo() == 0)
      {
        switch (Prioriy)
        {
          case 1:
            color = DeltaRdl > 24 ? Color.Red : Color.Blue;
            break;
          case 2:
            color = DeltaRdl > 24 ? Color.Red : Color.Blue;
            break;
          case 3:
            color = DeltaRdl > 24 ? Color.Red : Color.Blue;
            break;
          case 4:
            color = Color.Blue;
            break;
          case 5:
            color = Color.Blue;
            break;
          case 6:
            color = Color.Blue;
            break;
        }
      }
      else if (this.GetTipoIntervallo() == 1)
      {
        switch (Prioriy)
        {
          case 1:
            color = DeltaRdl > Data_sal ? Color.Red : Color.Blue;
            break;
          case 2:
            color = DeltaRdl > Data_sal ? Color.Red : Color.Blue;
            break;
          case 3:
            color = DeltaRdl > Data_sal ? Color.Red : Color.Blue;
            break;
          case 4:
            color = Color.Blue;
            break;
          case 5:
            color = Color.Blue;
            break;
          case 6:
            color = Color.Blue;
            break;
        }
      }
      else
      {
        switch (Prioriy)
        {
          case 1:
            color = DeltaRdl > 48 ? Color.Red : Color.Blue;
            break;
          case 2:
            color = DeltaRdl > 48 ? Color.Red : Color.Blue;
            break;
          case 3:
            color = DeltaRdl > 72 ? Color.Red : Color.Blue;
            break;
          case 4:
            color = Color.Blue;
            break;
          case 5:
            color = Color.Blue;
            break;
          case 6:
            color = Color.Blue;
            break;
        }
      }
      return color;
    }

    private void DisegnaStatistiche(Graphics gr)
    {
      DataSet dataSet1 = new DataSet();
      DataSet dataSet2 = this.DsStat().Copy();
      float num = 0.0f;
      foreach (DataRow row in (InternalDataCollectionBase) dataSet2.Tables[0].Rows)
      {
        if (!(row["MEDIA"].ToString() == ""))
        {
          if (this.ScalaLinare == 1)
            num = Convert.ToSingle(row["MEDIA"].ToString()) * (float) this.Npx * this.zoom;
          else if (this.ScalaLogaritmica == 1)
            num = Convert.ToSingle(Math.Log((double) num) * Math.Exp((double) this.esponente));
        }
      }
      SizeF sizeF = new SizeF((float) this.width, (float) this.width);
      RectangleF rect = new RectangleF(new PointF()
      {
        X = this.PuntoTrasformato.PCenter.X - num - (float) this.Rdisco,
        Y = this.PuntoTrasformato.PCenter.Y - num - (float) this.Rdisco
      }, new SizeF((float) (2.0 * ((double) num + (double) this.Rdisco)), (float) (2.0 * ((double) num + (double) this.Rdisco))));
      gr.DrawEllipse(Pens.Red, rect);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    private enum TipoM
    {
      Richiesta = 1,
      Programmata = 2,
      Straordinaria = 3,
      Entrambe = 4,
    }
  }
}
