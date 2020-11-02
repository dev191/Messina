// Decompiled with JetBrains decompiler
// Type: chart.classi.LayerGrafico
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace chart.classi
{
  public class LayerGrafico
  {
    private Graphics g;
    private int raggio;
    private int diametro;
    private PointF Center = new PointF();
    private Point NCenter = new Point();

    public LayerGrafico(Graphics _g, int _raggioLeggenda, PointF _Center)
    {
      this.raggio = _raggioLeggenda;
      this.diametro = 2 * this.raggio;
      this.g = _g;
      this.Center.X = _Center.X;
      this.Center.Y = _Center.Y;
      this.NCenter.X = Convert.ToInt32(_Center.X - (float) this.raggio);
      this.NCenter.Y = Convert.ToInt32(_Center.Y - (float) this.raggio);
    }

    public void MostraLayerBase()
    {
    }

    public void DisegnaPie(Size SizePie, int anno)
    {
      Pen pen = new Pen(Color.Black, 1f);
      Rectangle rect = new Rectangle(this.NCenter, SizePie);
      TrAngoliDate trAngoliDate = new TrAngoliDate();
      float num1 = 0.0f;
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 150));
      for (int mese = 0; mese < 12; ++mese)
      {
        float num2 = trAngoliDate.AngoloMeseGradi(mese, anno);
        this.g.DrawPie(pen, rect, -num1, -num2);
        this.g.FillPie((Brush) solidBrush, rect, -num1, -num2);
        num1 = num2 + num1;
      }
      pen.Dispose();
      solidBrush.Dispose();
    }

    public void DisegnaPie(Size SizePie, int anno, PointF CenterPie)
    {
      Pen pen = new Pen(Color.Black, 1f);
      Rectangle rect = new Rectangle(new Point()
      {
        X = Convert.ToInt32(CenterPie.X - (float) Convert.ToInt32(SizePie.Width / 2)),
        Y = Convert.ToInt32(CenterPie.Y - (float) Convert.ToInt32(SizePie.Height / 2))
      }, SizePie);
      TrAngoliDate trAngoliDate = new TrAngoliDate();
      float num1 = 0.0f;
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 150));
      for (int mese = 0; mese < 12; ++mese)
      {
        float num2 = trAngoliDate.AngoloMeseGradi(mese, anno);
        this.g.DrawPie(pen, rect, -num1, -num2);
        this.g.FillPie((Brush) solidBrush, rect, -num1, -num2);
        num1 = num2 + num1;
      }
      pen.Dispose();
      solidBrush.Dispose();
    }

    public void DisegnaPie(
      Size SizePie,
      int anno,
      PointF CenterPie,
      Color DrawColol,
      Color FillColor)
    {
      Pen pen = new Pen(DrawColol, 1f);
      Rectangle rect = new Rectangle(new Point()
      {
        X = Convert.ToInt32(CenterPie.X - (float) Convert.ToInt32(SizePie.Width / 2)),
        Y = Convert.ToInt32(CenterPie.Y - (float) Convert.ToInt32(SizePie.Height / 2))
      }, SizePie);
      TrAngoliDate trAngoliDate = new TrAngoliDate();
      float num1 = 0.0f;
      SolidBrush solidBrush = new SolidBrush(FillColor);
      for (int mese = 0; mese < 12; ++mese)
      {
        float num2 = trAngoliDate.AngoloMeseGradi(mese, anno);
        this.g.DrawPie(pen, rect, -num1, -num2);
        this.g.FillPie((Brush) solidBrush, rect, -num1, -num2);
        num1 = num2 + num1;
      }
      pen.Dispose();
      solidBrush.Dispose();
    }

    public void DisegnaMesi()
    {
      GraphicsPath path = new GraphicsPath();
      TrAngoliDate trAngoliDate = new TrAngoliDate();
      StringFormat genericDefault = StringFormat.GenericDefault;
      float num1 = 0.0f;
      for (int mese = 0; mese < 12; ++mese)
      {
        float num2 = trAngoliDate.AngoloMeseRadianti(mese, 2005);
        float num3 = trAngoliDate.AngoloMeseGradi(mese, 2005);
        float single1 = Convert.ToSingle(0.75 * (double) this.raggio * Math.Cos((double) num2 / 2.0));
        float single2 = Convert.ToSingle(0.5 * (double) this.raggio * Math.Sin((double) num2 / 2.0));
        RectangleF rectangleF = new RectangleF((PointF) this.NCenter, new SizeF(single1, single2));
        string s = trAngoliDate.strMese(mese);
        FontFamily family = new FontFamily("Arial");
        int style = 2;
        int num4 = Convert.ToInt32(single2) + 1;
        path.AddString(s, family, style, (float) num4, this.Center, genericDefault);
        Matrix matrix1 = new Matrix();
        matrix1.Translate((float) (this.raggio / 4), -single2);
        Matrix matrix2 = new Matrix();
        matrix2.RotateAt((float) (-(double) num3 / 2.0), new PointF(this.Center.X + (float) (this.raggio / 4), this.Center.Y));
        matrix1.Multiply(matrix2, MatrixOrder.Append);
        path.Transform(matrix1);
        Matrix matrix3 = new Matrix();
        matrix3.RotateAt(-num1, this.Center);
        path.Transform(matrix3);
        this.g.FillPath(Brushes.BlueViolet, path);
        matrix1.Reset();
        matrix2.Reset();
        matrix3.Reset();
        path.Reset();
        num1 = num3 + num1;
      }
    }

    public void DisplayMisure(
      float OraMax,
      PointF Origine,
      float unaOra,
      int ScalaLinare,
      int ScalaLogaritmica,
      float esponente)
    {
      float num1 = 12f;
      int num2 = Convert.ToInt32(Math.Floor(Convert.ToDouble(OraMax / num1))) + 1;
      float DistanzaOrigine = 0.0f;
      PointF location = new PointF();
      for (int index = 0; index < num2; ++index)
      {
        location.X = Origine.X;
        location.Y = Origine.Y;
        float single = Convert.ToSingle((float) index * num1 * unaOra);
        if (ScalaLinare == 1)
          DistanzaOrigine = single + (float) this.raggio;
        else if (ScalaLogaritmica == 1)
          DistanzaOrigine = Convert.ToSingle(Math.Log((double) single) * Math.Exp((double) esponente)) + (float) this.raggio;
        location.X -= DistanzaOrigine;
        location.Y -= DistanzaOrigine;
        SizeF size = new SizeF(2f * DistanzaOrigine, 2f * DistanzaOrigine);
        if (ScalaLinare == 1)
          this.DisegnaUnitaNumeriche(Origine, DistanzaOrigine, (float) index * num1, unaOra);
        this.g.DrawEllipse(Pens.Blue, new RectangleF(location, size));
      }
    }

    private void DisegnaUnitaNumeriche(
      PointF Center,
      float DistanzaOrigine,
      float Valore,
      float FactorScala)
    {
      GraphicsPath path = new GraphicsPath();
      TrAngoliDate trAngoliDate = new TrAngoliDate();
      StringFormat genericDefault = StringFormat.GenericDefault;
      float num1 = 5f * FactorScala;
      float num2 = 0.0f;
      for (int mese = 0; mese < 12; ++mese)
      {
        float num3 = trAngoliDate.AngoloMeseRadianti(mese, 2005);
        float num4 = trAngoliDate.AngoloMeseGradi(mese, 2005);
        float single1 = Convert.ToSingle((double) num1 * Math.Cos((double) num3 / 2.0));
        float single2 = Convert.ToSingle(2.0 * (double) num1 * Math.Sin((double) num3 / 2.0));
        SizeF size = new SizeF(single1, single2);
        RectangleF rectangleF = new RectangleF(Center, size);
        string s = Convert.ToString(Valore) + " (hh)";
        FontFamily family = new FontFamily("Arial");
        int style = 2;
        int num5 = Convert.ToInt32(single2) + 1;
        path.AddString(s, family, style, (float) num5, Center, genericDefault);
        Matrix matrix1 = new Matrix();
        matrix1.Translate(DistanzaOrigine, -single2);
        Matrix matrix2 = new Matrix();
        matrix2.RotateAt(0.0f, new PointF(Center.X + DistanzaOrigine, Center.Y));
        matrix1.Multiply(matrix2, MatrixOrder.Append);
        path.Transform(matrix1);
        Matrix matrix3 = new Matrix();
        matrix3.RotateAt(-num2, Center);
        path.Transform(matrix3);
        this.g.FillPath(Brushes.Black, path);
        matrix1.Reset();
        matrix2.Reset();
        matrix3.Reset();
        path.Reset();
        num2 = num4 + num2;
      }
    }
  }
}
