// Decompiled with JetBrains decompiler
// Type: chart.classi.TrasfCoord
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Drawing;

namespace chart.classi
{
  public class TrasfCoord
  {
    private PointF _P = new PointF();
    private float _Ro;
    private float _Tetha;
    private float _Raggio;
    private float _DeltaX;
    private float _DeltaY;
    private float _DelataRo;
    private StatisticheDati Stat = new StatisticheDati();

    public RectangleF PRect => this.PointQuadrato();

    public float Ro
    {
      set
      {
        this._Ro = value;
        this.Stat.Add(this._Ro);
      }
    }

    public float Tetha
    {
      set => this._Tetha = value;
    }

    public float Raggio
    {
      set => this._Raggio = value;
    }

    public float DeltaX
    {
      set => this._DeltaX = value;
    }

    public float DeltaY
    {
      set => this._DeltaY = value;
    }

    public float DeltaRo
    {
      set => this._DelataRo = value;
    }

    public PointF PCenter => new PointF(this._DeltaX + this._Raggio, this._DeltaY + this._Raggio);

    public float RoMedio => this.Stat.Media;

    public float VarRo => this.Stat.Varianza;

    public PointF PCartesiano
    {
      get
      {
        this._P.X = this.CordinataX(this._Ro, this._Tetha, this._Raggio, this._DeltaX);
        this._P.Y = this.CordinataY(this._Ro, this._Tetha, this._Raggio, this._DeltaY);
        return this._P;
      }
    }

    private RectangleF PointQuadrato()
    {
      this._P.X = this.CordinataX(this._Ro + this._DelataRo, this._Tetha, this._Raggio, this._DeltaX);
      this._P.Y = this.CordinataY(this._Ro + this._DelataRo, this._Tetha, this._Raggio, this._DeltaY);
      float num = 4f;
      return new RectangleF(this._P.X - num / 2f, this._P.Y - num / 2f, num, num);
    }

    private float CordinataX(float r, float alfa, float rMax, float dX) => r * Convert.ToSingle(Math.Cos((double) alfa)) + rMax + dX;

    private float CordinataY(float r, float alfa, float rMax, float dY) => -r * Convert.ToSingle(Math.Sin((double) alfa)) + rMax + dY;
  }
}
