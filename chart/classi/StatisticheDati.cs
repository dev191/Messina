// Decompiled with JetBrains decompiler
// Type: chart.classi.StatisticheDati
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Collections;

namespace chart.classi
{
  public class StatisticheDati
  {
    private ArrayList _Rarr = new ArrayList();

    public void Add(float num) => this._Rarr.Add((object) num);

    public float Media => this.RoMedio();

    public float Varianza => this.RoVarianza();

    private float RoMedio()
    {
      float num = 0.0f;
      for (int index = 0; index < this._Rarr.Count; ++index)
        num += Convert.ToSingle(this._Rarr[index].ToString());
      return num / Convert.ToSingle(this._Rarr.Count);
    }

    public float RoVarianza()
    {
      float num1 = 0.0f;
      float num2 = this.RoMedio();
      for (int index = 0; index < this._Rarr.Count; ++index)
        num1 += Convert.ToSingle(Math.Pow((double) num2 - (double) Convert.ToSingle(this._Rarr[index].ToString()), 2.0));
      return Convert.ToSingle(Math.Sqrt(1.0 / ((double) this._Rarr.Count - 1.0) * (double) num1));
    }
  }
}
