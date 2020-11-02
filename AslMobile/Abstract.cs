// Decompiled with JetBrains decompiler
// Type: TheSite.AslMobile.Abstract
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;

namespace TheSite.AslMobile
{
  public abstract class Abstract
  {
    protected string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];

    public Abstract()
    {
    }

    public Abstract(string ConnectionString) => this.s_ConnStr = ConnectionString;

    public virtual DataSet GetData(
      OracleParameterCollection CollectionParameter,
      string StorProcedureName)
    {
      OracleConnection connection = new OracleConnection(this.s_ConnStr);
      OracleCommand selectCommand = new OracleCommand(StorProcedureName, connection);
      selectCommand.CommandType = CommandType.StoredProcedure;
      OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(selectCommand);
      foreach (OracleParameter oracleParameter in CollectionParameter)
        selectCommand.Parameters.Add(new OracleParameter(oracleParameter.ParameterName, oracleParameter.OracleType, oracleParameter.Size)
        {
          Direction = oracleParameter.Direction,
          Value = oracleParameter.Value
        });
      DataSet dataSet = new DataSet();
      using (connection)
        oracleDataAdapter.Fill(dataSet);
      return dataSet;
    }

    public virtual DataSet GetData(string StorProcedureName, string CursorName)
    {
      OracleConnection connection = new OracleConnection(this.s_ConnStr);
      OracleCommand selectCommand = new OracleCommand(StorProcedureName, connection);
      selectCommand.CommandType = CommandType.StoredProcedure;
      OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(selectCommand);
      selectCommand.Parameters.Add(new OracleParameter(CursorName, OracleType.Cursor)
      {
        Direction = ParameterDirection.Output
      });
      DataSet dataSet = new DataSet();
      using (connection)
        oracleDataAdapter.Fill(dataSet);
      return dataSet;
    }

    public virtual DataSet GetSingleData(
      string ParameterName,
      int id,
      OracleParameterCollection CollectionParameter,
      string StorProcedureName)
    {
      CollectionParameter.Add(new OracleParameter()
      {
        ParameterName = ParameterName,
        OracleType = OracleType.Int32,
        Direction = ParameterDirection.Input,
        Value = (object) id
      });
      return this.GetData(CollectionParameter, StorProcedureName);
    }

    public virtual DataSet GetSingleData(
      string ParameterName,
      int id,
      string StorProcedureName,
      string CursorName)
    {
      OracleParameterCollection CollectionParameter = new OracleParameterCollection();
      OracleParameter oracleParameter = new OracleParameter();
      oracleParameter.ParameterName = ParameterName;
      oracleParameter.OracleType = OracleType.Int32;
      oracleParameter.Direction = ParameterDirection.Input;
      oracleParameter.Value = (object) id;
      CollectionParameter.Add(oracleParameter);
      new OracleParameter(CursorName, OracleType.Cursor).Direction = ParameterDirection.Output;
      CollectionParameter.Add(oracleParameter);
      return this.GetData(CollectionParameter, StorProcedureName);
    }

    public virtual int Add(OracleParameterCollection CollezioneControlli, string StorProcedureName) => this.ExecuteUpdate(CollezioneControlli, ExecuteType.Insert, "", 0, StorProcedureName);

    public virtual int Update(
      OracleParameterCollection CollezioneControlli,
      string ParameterName,
      int itemId,
      string StorProcedureName)
    {
      return this.ExecuteUpdate(CollezioneControlli, ExecuteType.Update, ParameterName, itemId, StorProcedureName);
    }

    public virtual int Delete(
      OracleParameterCollection CollezioneControlli,
      string ParameterName,
      int itemId,
      string StorProcedureName)
    {
      return this.ExecuteUpdate(CollezioneControlli, ExecuteType.Delete, ParameterName, itemId, StorProcedureName);
    }

    protected virtual int ExecuteUpdate(
      OracleParameterCollection Coll,
      ExecuteType Operazione,
      string ParameterName,
      int itemId,
      string StorProcedureName)
    {
      OracleConnection connection = new OracleConnection(this.s_ConnStr);
      OracleCommand oracleCommand = new OracleCommand(StorProcedureName, connection);
      oracleCommand.CommandType = CommandType.StoredProcedure;
      if (ParameterName != "")
        Coll.Add(new OracleParameter()
        {
          ParameterName = ParameterName,
          OracleType = OracleType.Int32,
          Direction = ParameterDirection.Input,
          Value = (object) itemId
        });
      foreach (OracleParameter oracleParameter in Coll)
        oracleCommand.Parameters.Add(new OracleParameter(oracleParameter.ParameterName, oracleParameter.OracleType, oracleParameter.Size)
        {
          Direction = oracleParameter.Direction,
          Value = oracleParameter.Value
        });
      try
      {
        using (connection)
        {
          connection.Open();
          oracleCommand.ExecuteNonQuery();
          int num = (int) oracleCommand.Parameters[oracleCommand.Parameters.Count - 1].Value;
          connection.Close();
          return num;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (connection.State == ConnectionState.Open)
          connection.Close();
      }
    }

    public virtual DataTable ItemBlankDataSource(
      DataTable DataTableOrigine,
      string DataTextField,
      string DataValueFiled,
      string BlankText,
      string BlankValue)
    {
      DataTable dataTable = DataTableOrigine.Clone();
      dataTable.Columns[DataValueFiled].AllowDBNull = true;
      DataRow row1 = dataTable.NewRow();
      if (BlankValue != string.Empty)
        row1[DataValueFiled] = (object) BlankValue;
      row1[DataTextField] = (object) BlankText;
      dataTable.Rows.Add(row1);
      foreach (DataRow row2 in (InternalDataCollectionBase) DataTableOrigine.Rows)
      {
        DataRow row3 = dataTable.NewRow();
        row3[DataValueFiled] = row2[DataValueFiled];
        row3[DataTextField] = row2[DataTextField];
        dataTable.Rows.Add(row3);
      }
      return dataTable;
    }
  }
}
