// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.DateAndTime
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Globalization;

namespace TheSite.Gestione
{
  public class DateAndTime
  {
    public static long DateDiff(DateInterval interval, DateTime dt1, DateTime dt2) => DateAndTime.DateDiff(interval, dt1, dt2, DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);

    private static int GetQuarter(int nMonth)
    {
      if (nMonth <= 3)
        return 1;
      if (nMonth <= 6)
        return 2;
      return nMonth <= 9 ? 3 : 4;
    }

    public static long DateDiff(
      DateInterval interval,
      DateTime dt1,
      DateTime dt2,
      DayOfWeek eFirstDayOfWeek)
    {
      if (interval == DateInterval.Year)
        return (long) (dt2.Year - dt1.Year);
      if (interval == DateInterval.Month)
        return (long) Math.Abs(12 * (dt1.Year - dt2.Year) + dt1.Month - dt2.Month);
      TimeSpan timeSpan = dt2 - dt1;
      if (interval == DateInterval.Day || interval == DateInterval.DayOfYear)
        return DateAndTime.Round(timeSpan.TotalDays);
      switch (interval)
      {
        case DateInterval.Hour:
          return DateAndTime.Round(timeSpan.TotalHours);
        case DateInterval.Minute:
          return DateAndTime.Round(timeSpan.TotalMinutes);
        case DateInterval.Quarter:
          double quarter = (double) DateAndTime.GetQuarter(dt1.Month);
          return DateAndTime.Round((double) DateAndTime.GetQuarter(dt2.Month) - quarter + (double) (4 * (dt2.Year - dt1.Year)));
        case DateInterval.Second:
          return DateAndTime.Round(timeSpan.TotalSeconds);
        case DateInterval.Weekday:
          return DateAndTime.Round(timeSpan.TotalDays / 7.0);
        case DateInterval.WeekOfYear:
          while (dt2.DayOfWeek != eFirstDayOfWeek)
            dt2 = dt2.AddDays(-1.0);
          while (dt1.DayOfWeek != eFirstDayOfWeek)
            dt1 = dt1.AddDays(-1.0);
          return DateAndTime.Round((dt2 - dt1).TotalDays / 7.0);
        default:
          return 0;
      }
    }

    private static long Round(double dVal) => dVal >= 0.0 ? (long) Math.Floor(dVal) : (long) Math.Ceiling(dVal);
  }
}
