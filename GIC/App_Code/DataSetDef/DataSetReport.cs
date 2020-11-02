// Decompiled with JetBrains decompiler
// Type: TheSite.GIC.App_Code.DataSetDef.DataSetReport
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace TheSite.GIC.App_Code.DataSetDef
{
  [DesignerCategory("code")]
  [DebuggerStepThrough]
  [ToolboxItem(true)]
  [Serializable]
  public class DataSetReport : DataSet
  {
    private DataSetReport.QueryDataTable tableQuery;
    private DataSetReport.CampiDataTable tableCampi;
    private DataSetReport.TuttiCampiDataTable tableTuttiCampi;

    public DataSetReport()
    {
      this.InitClass();
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      this.Tables.CollectionChanged += changeEventHandler;
      this.Relations.CollectionChanged += changeEventHandler;
    }

    protected DataSetReport(SerializationInfo info, StreamingContext context)
    {
      string s = (string) info.GetValue("XmlSchema", typeof (string));
      if (s != null)
      {
        DataSet dataSet = new DataSet();
        dataSet.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
        if (dataSet.Tables[nameof (Query)] != null)
          this.Tables.Add((DataTable) new DataSetReport.QueryDataTable(dataSet.Tables[nameof (Query)]));
        if (dataSet.Tables[nameof (Campi)] != null)
          this.Tables.Add((DataTable) new DataSetReport.CampiDataTable(dataSet.Tables[nameof (Campi)]));
        if (dataSet.Tables[nameof (TuttiCampi)] != null)
          this.Tables.Add((DataTable) new DataSetReport.TuttiCampiDataTable(dataSet.Tables[nameof (TuttiCampi)]));
        this.DataSetName = dataSet.DataSetName;
        this.Prefix = dataSet.Prefix;
        this.Namespace = dataSet.Namespace;
        this.Locale = dataSet.Locale;
        this.CaseSensitive = dataSet.CaseSensitive;
        this.EnforceConstraints = dataSet.EnforceConstraints;
        this.Merge(dataSet, false, MissingSchemaAction.Add);
        this.InitVars();
      }
      else
        this.InitClass();
      this.GetSerializationData(info, context);
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      this.Tables.CollectionChanged += changeEventHandler;
      this.Relations.CollectionChanged += changeEventHandler;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Browsable(false)]
    public DataSetReport.QueryDataTable Query => this.tableQuery;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Browsable(false)]
    public DataSetReport.CampiDataTable Campi => this.tableCampi;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public DataSetReport.TuttiCampiDataTable TuttiCampi => this.tableTuttiCampi;

    public override DataSet Clone()
    {
      DataSetReport dataSetReport = (DataSetReport) base.Clone();
      dataSetReport.InitVars();
      return (DataSet) dataSetReport;
    }

    protected override bool ShouldSerializeTables() => false;

    protected override bool ShouldSerializeRelations() => false;

    protected override void ReadXmlSerializable(XmlReader reader)
    {
      this.Reset();
      DataSet dataSet = new DataSet();
      int num = (int) dataSet.ReadXml(reader);
      if (dataSet.Tables["Query"] != null)
        this.Tables.Add((DataTable) new DataSetReport.QueryDataTable(dataSet.Tables["Query"]));
      if (dataSet.Tables["Campi"] != null)
        this.Tables.Add((DataTable) new DataSetReport.CampiDataTable(dataSet.Tables["Campi"]));
      if (dataSet.Tables["TuttiCampi"] != null)
        this.Tables.Add((DataTable) new DataSetReport.TuttiCampiDataTable(dataSet.Tables["TuttiCampi"]));
      this.DataSetName = dataSet.DataSetName;
      this.Prefix = dataSet.Prefix;
      this.Namespace = dataSet.Namespace;
      this.Locale = dataSet.Locale;
      this.CaseSensitive = dataSet.CaseSensitive;
      this.EnforceConstraints = dataSet.EnforceConstraints;
      this.Merge(dataSet, false, MissingSchemaAction.Add);
      this.InitVars();
    }

    protected override XmlSchema GetSchemaSerializable()
    {
      MemoryStream memoryStream = new MemoryStream();
      this.WriteXmlSchema((XmlWriter) new XmlTextWriter((Stream) memoryStream, (Encoding) null));
      memoryStream.Position = 0L;
      return XmlSchema.Read((XmlReader) new XmlTextReader((Stream) memoryStream), (ValidationEventHandler) null);
    }

    internal void InitVars()
    {
      this.tableQuery = (DataSetReport.QueryDataTable) this.Tables["Query"];
      if (this.tableQuery != null)
        this.tableQuery.InitVars();
      this.tableCampi = (DataSetReport.CampiDataTable) this.Tables["Campi"];
      if (this.tableCampi != null)
        this.tableCampi.InitVars();
      this.tableTuttiCampi = (DataSetReport.TuttiCampiDataTable) this.Tables["TuttiCampi"];
      if (this.tableTuttiCampi == null)
        return;
      this.tableTuttiCampi.InitVars();
    }

    private void InitClass()
    {
      this.DataSetName = nameof (DataSetReport);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/DataSetReport.xsd";
      this.Locale = new CultureInfo("en-US");
      this.CaseSensitive = false;
      this.EnforceConstraints = true;
      this.tableQuery = new DataSetReport.QueryDataTable();
      this.Tables.Add((DataTable) this.tableQuery);
      this.tableCampi = new DataSetReport.CampiDataTable();
      this.Tables.Add((DataTable) this.tableCampi);
      this.tableTuttiCampi = new DataSetReport.TuttiCampiDataTable();
      this.Tables.Add((DataTable) this.tableTuttiCampi);
    }

    private bool ShouldSerializeQuery() => false;

    private bool ShouldSerializeCampi() => false;

    private bool ShouldSerializeTuttiCampi() => false;

    private void SchemaChanged(object sender, CollectionChangeEventArgs e)
    {
      if (e.Action != CollectionChangeAction.Remove)
        return;
      this.InitVars();
    }

    public delegate void QueryRowChangeEventHandler(
      object sender,
      DataSetReport.QueryRowChangeEvent e);

    public delegate void CampiRowChangeEventHandler(
      object sender,
      DataSetReport.CampiRowChangeEvent e);

    public delegate void TuttiCampiRowChangeEventHandler(
      object sender,
      DataSetReport.TuttiCampiRowChangeEvent e);

    [DebuggerStepThrough]
    public class QueryDataTable : DataTable, IEnumerable
    {
      private DataColumn columnIdQuery;
      private DataColumn columnDenominazione;
      private DataColumn columnDescrizione;
      private DataColumn columnUsername;

      internal QueryDataTable()
        : base("Query")
        => this.InitClass();

      internal QueryDataTable(DataTable table)
        : base(table.TableName)
      {
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
        this.DisplayExpression = table.DisplayExpression;
      }

      [Browsable(false)]
      public int Count => this.Rows.Count;

      internal DataColumn IdQueryColumn => this.columnIdQuery;

      internal DataColumn DenominazioneColumn => this.columnDenominazione;

      internal DataColumn DescrizioneColumn => this.columnDescrizione;

      internal DataColumn UsernameColumn => this.columnUsername;

      public DataSetReport.QueryRow this[int index] => (DataSetReport.QueryRow) this.Rows[index];

      public event DataSetReport.QueryRowChangeEventHandler QueryRowChanged;

      public event DataSetReport.QueryRowChangeEventHandler QueryRowChanging;

      public event DataSetReport.QueryRowChangeEventHandler QueryRowDeleted;

      public event DataSetReport.QueryRowChangeEventHandler QueryRowDeleting;

      public void AddQueryRow(DataSetReport.QueryRow row) => this.Rows.Add((DataRow) row);

      public DataSetReport.QueryRow AddQueryRow(
        int IdQuery,
        string Denominazione,
        string Descrizione)
      {
        DataSetReport.QueryRow queryRow = (DataSetReport.QueryRow) this.NewRow();
        queryRow.ItemArray = new object[3]
        {
          (object) IdQuery,
          (object) Denominazione,
          (object) Descrizione
        };
        this.Rows.Add((DataRow) queryRow);
        return queryRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        DataSetReport.QueryDataTable queryDataTable = (DataSetReport.QueryDataTable) base.Clone();
        queryDataTable.InitVars();
        return (DataTable) queryDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new DataSetReport.QueryDataTable();

      internal void InitVars()
      {
        this.columnIdQuery = this.Columns["IdQuery"];
        this.columnDenominazione = this.Columns["Denominazione"];
        this.columnDescrizione = this.Columns["Descrizione"];
        this.columnUsername = this.Columns["Username"];
      }

      private void InitClass()
      {
        this.columnIdQuery = new DataColumn("IdQuery", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdQuery);
        this.columnDenominazione = new DataColumn("Denominazione", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDenominazione);
        this.columnDescrizione = new DataColumn("Descrizione", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDescrizione);
        this.columnUsername = new DataColumn("Username", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnUsername);
      }

      public DataSetReport.QueryRow NewQueryRow() => (DataSetReport.QueryRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new DataSetReport.QueryRow(builder);

      protected override Type GetRowType() => typeof (DataSetReport.QueryRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.QueryRowChanged == null)
          return;
        this.QueryRowChanged((object) this, new DataSetReport.QueryRowChangeEvent((DataSetReport.QueryRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.QueryRowChanging == null)
          return;
        this.QueryRowChanging((object) this, new DataSetReport.QueryRowChangeEvent((DataSetReport.QueryRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.QueryRowDeleted == null)
          return;
        this.QueryRowDeleted((object) this, new DataSetReport.QueryRowChangeEvent((DataSetReport.QueryRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.QueryRowDeleting == null)
          return;
        this.QueryRowDeleting((object) this, new DataSetReport.QueryRowChangeEvent((DataSetReport.QueryRow) e.Row, e.Action));
      }

      public void RemoveQueryRow(DataSetReport.QueryRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class QueryRow : DataRow
    {
      private DataSetReport.QueryDataTable tableQuery;

      internal QueryRow(DataRowBuilder rb)
        : base(rb)
        => this.tableQuery = (DataSetReport.QueryDataTable) this.Table;

      public int IdQuery
      {
        get
        {
          try
          {
            return (int) this[this.tableQuery.IdQueryColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery.IdQueryColumn] = (object) value;
      }

      public string Denominazione
      {
        get
        {
          try
          {
            return (string) this[this.tableQuery.DenominazioneColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery.DenominazioneColumn] = (object) value;
      }

      public string Username
      {
        get
        {
          try
          {
            return (string) this[this.tableQuery.UsernameColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery.UsernameColumn] = (object) value;
      }

      public string Descrizione
      {
        get
        {
          try
          {
            return (string) this[this.tableQuery.DescrizioneColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery.DescrizioneColumn] = (object) value;
      }

      public bool IsIdQueryNull() => this.IsNull(this.tableQuery.IdQueryColumn);

      public void SetIdQueryNull() => this[this.tableQuery.IdQueryColumn] = Convert.DBNull;

      public bool IsDenominazioneNull() => this.IsNull(this.tableQuery.DenominazioneColumn);

      public void SetDenominazioneNull() => this[this.tableQuery.DenominazioneColumn] = Convert.DBNull;

      public bool IsDescrizioneNull() => this.IsNull(this.tableQuery.DescrizioneColumn);

      public void SetDescrizioneNull() => this[this.tableQuery.DescrizioneColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class QueryRowChangeEvent : EventArgs
    {
      private DataSetReport.QueryRow eventRow;
      private DataRowAction eventAction;

      public QueryRowChangeEvent(DataSetReport.QueryRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public DataSetReport.QueryRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class CampiDataTable : DataTable, IEnumerable
    {
      private DataColumn columnAggregazione;
      private DataColumn columnFiltro;
      private DataColumn columnNascosto;
      private DataColumn columnOrdinamento;
      private DataColumn columnNomeCampo;
      private DataColumn columnNomeTabella;
      private DataColumn columnIdGlossario;
      private DataColumn columnTipologia;
      private DataColumn columnTipoDato;
      private DataColumn columnAlias;

      internal CampiDataTable()
        : base("Campi")
        => this.InitClass();

      internal CampiDataTable(DataTable table)
        : base(table.TableName)
      {
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
        this.DisplayExpression = table.DisplayExpression;
      }

      [Browsable(false)]
      public int Count => this.Rows.Count;

      internal DataColumn AggregazioneColumn => this.columnAggregazione;

      internal DataColumn FiltroColumn => this.columnFiltro;

      internal DataColumn NascostoColumn => this.columnNascosto;

      internal DataColumn OrdinamentoColumn => this.columnOrdinamento;

      internal DataColumn NomeCampoColumn => this.columnNomeCampo;

      internal DataColumn NomeTabellaColumn => this.columnNomeTabella;

      internal DataColumn IdGlossarioColumn => this.columnIdGlossario;

      internal DataColumn TipologiaColumn => this.columnTipologia;

      internal DataColumn TipoDatoColumn => this.columnTipoDato;

      internal DataColumn AliasColumn => this.columnAlias;

      public DataSetReport.CampiRow this[int index] => (DataSetReport.CampiRow) this.Rows[index];

      public event DataSetReport.CampiRowChangeEventHandler CampiRowChanged;

      public event DataSetReport.CampiRowChangeEventHandler CampiRowChanging;

      public event DataSetReport.CampiRowChangeEventHandler CampiRowDeleted;

      public event DataSetReport.CampiRowChangeEventHandler CampiRowDeleting;

      public void AddCampiRow(DataSetReport.CampiRow row) => this.Rows.Add((DataRow) row);

      public DataSetReport.CampiRow AddCampiRow(
        string Aggregazione,
        string Filtro,
        bool Nascosto,
        string Ordinamento,
        string NomeCampo,
        string NomeTabella,
        int IdGlossario,
        string Tipologia,
        string TipoDato,
        string Alias)
      {
        DataSetReport.CampiRow campiRow = (DataSetReport.CampiRow) this.NewRow();
        campiRow.ItemArray = new object[10]
        {
          (object) Aggregazione,
          (object) Filtro,
          (object) Nascosto,
          (object) Ordinamento,
          (object) NomeCampo,
          (object) NomeTabella,
          (object) IdGlossario,
          (object) Tipologia,
          (object) TipoDato,
          (object) Alias
        };
        this.Rows.Add((DataRow) campiRow);
        return campiRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        DataSetReport.CampiDataTable campiDataTable = (DataSetReport.CampiDataTable) base.Clone();
        campiDataTable.InitVars();
        return (DataTable) campiDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new DataSetReport.CampiDataTable();

      internal void InitVars()
      {
        this.columnAggregazione = this.Columns["Aggregazione"];
        this.columnFiltro = this.Columns["Filtro"];
        this.columnNascosto = this.Columns["Nascosto"];
        this.columnOrdinamento = this.Columns["Ordinamento"];
        this.columnNomeCampo = this.Columns["NomeCampo"];
        this.columnNomeTabella = this.Columns["NomeTabella"];
        this.columnIdGlossario = this.Columns["IdGlossario"];
        this.columnTipologia = this.Columns["Tipologia"];
        this.columnTipoDato = this.Columns["TipoDato"];
        this.columnAlias = this.Columns["Alias"];
      }

      private void InitClass()
      {
        this.columnAggregazione = new DataColumn("Aggregazione", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAggregazione);
        this.columnFiltro = new DataColumn("Filtro", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFiltro);
        this.columnNascosto = new DataColumn("Nascosto", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNascosto);
        this.columnOrdinamento = new DataColumn("Ordinamento", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnOrdinamento);
        this.columnNomeCampo = new DataColumn("NomeCampo", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNomeCampo);
        this.columnNomeTabella = new DataColumn("NomeTabella", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNomeTabella);
        this.columnIdGlossario = new DataColumn("IdGlossario", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdGlossario);
        this.columnTipologia = new DataColumn("Tipologia", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTipologia);
        this.columnTipoDato = new DataColumn("TipoDato", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTipoDato);
        this.columnAlias = new DataColumn("Alias", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAlias);
      }

      public DataSetReport.CampiRow NewCampiRow() => (DataSetReport.CampiRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new DataSetReport.CampiRow(builder);

      protected override Type GetRowType() => typeof (DataSetReport.CampiRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.CampiRowChanged == null)
          return;
        this.CampiRowChanged((object) this, new DataSetReport.CampiRowChangeEvent((DataSetReport.CampiRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.CampiRowChanging == null)
          return;
        this.CampiRowChanging((object) this, new DataSetReport.CampiRowChangeEvent((DataSetReport.CampiRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.CampiRowDeleted == null)
          return;
        this.CampiRowDeleted((object) this, new DataSetReport.CampiRowChangeEvent((DataSetReport.CampiRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.CampiRowDeleting == null)
          return;
        this.CampiRowDeleting((object) this, new DataSetReport.CampiRowChangeEvent((DataSetReport.CampiRow) e.Row, e.Action));
      }

      public void RemoveCampiRow(DataSetReport.CampiRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class CampiRow : DataRow
    {
      private DataSetReport.CampiDataTable tableCampi;

      internal CampiRow(DataRowBuilder rb)
        : base(rb)
        => this.tableCampi = (DataSetReport.CampiDataTable) this.Table;

      public string Aggregazione
      {
        get
        {
          try
          {
            return (string) this[this.tableCampi.AggregazioneColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableCampi.AggregazioneColumn] = (object) value;
      }

      public string Filtro
      {
        get
        {
          try
          {
            return (string) this[this.tableCampi.FiltroColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableCampi.FiltroColumn] = (object) value;
      }

      public bool Nascosto
      {
        get
        {
          try
          {
            return (bool) this[this.tableCampi.NascostoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableCampi.NascostoColumn] = (object) value;
      }

      public string Ordinamento
      {
        get
        {
          try
          {
            return (string) this[this.tableCampi.OrdinamentoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableCampi.OrdinamentoColumn] = (object) value;
      }

      public string NomeCampo
      {
        get
        {
          try
          {
            return (string) this[this.tableCampi.NomeCampoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableCampi.NomeCampoColumn] = (object) value;
      }

      public string NomeTabella
      {
        get
        {
          try
          {
            return (string) this[this.tableCampi.NomeTabellaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableCampi.NomeTabellaColumn] = (object) value;
      }

      public int IdGlossario
      {
        get
        {
          try
          {
            return (int) this[this.tableCampi.IdGlossarioColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableCampi.IdGlossarioColumn] = (object) value;
      }

      public string Tipologia
      {
        get
        {
          try
          {
            return (string) this[this.tableCampi.TipologiaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableCampi.TipologiaColumn] = (object) value;
      }

      public string TipoDato
      {
        get
        {
          try
          {
            return (string) this[this.tableCampi.TipoDatoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableCampi.TipoDatoColumn] = (object) value;
      }

      public string Alias
      {
        get
        {
          try
          {
            return (string) this[this.tableCampi.AliasColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableCampi.AliasColumn] = (object) value;
      }

      public bool IsAggregazioneNull() => this.IsNull(this.tableCampi.AggregazioneColumn);

      public void SetAggregazioneNull() => this[this.tableCampi.AggregazioneColumn] = Convert.DBNull;

      public bool IsFiltroNull() => this.IsNull(this.tableCampi.FiltroColumn);

      public void SetFiltroNull() => this[this.tableCampi.FiltroColumn] = Convert.DBNull;

      public bool IsNascostoNull() => this.IsNull(this.tableCampi.NascostoColumn);

      public void SetNascostoNull() => this[this.tableCampi.NascostoColumn] = Convert.DBNull;

      public bool IsOrdinamentoNull() => this.IsNull(this.tableCampi.OrdinamentoColumn);

      public void SetOrdinamentoNull() => this[this.tableCampi.OrdinamentoColumn] = Convert.DBNull;

      public bool IsNomeCampoNull() => this.IsNull(this.tableCampi.NomeCampoColumn);

      public void SetNomeCampoNull() => this[this.tableCampi.NomeCampoColumn] = Convert.DBNull;

      public bool IsNomeTabellaNull() => this.IsNull(this.tableCampi.NomeTabellaColumn);

      public void SetNomeTabellaNull() => this[this.tableCampi.NomeTabellaColumn] = Convert.DBNull;

      public bool IsIdGlossarioNull() => this.IsNull(this.tableCampi.IdGlossarioColumn);

      public void SetIdGlossarioNull() => this[this.tableCampi.IdGlossarioColumn] = Convert.DBNull;

      public bool IsTipologiaNull() => this.IsNull(this.tableCampi.TipologiaColumn);

      public void SetTipologiaNull() => this[this.tableCampi.TipologiaColumn] = Convert.DBNull;

      public bool IsTipoDatoNull() => this.IsNull(this.tableCampi.TipoDatoColumn);

      public void SetTipoDatoNull() => this[this.tableCampi.TipoDatoColumn] = Convert.DBNull;

      public bool IsAliasNull() => this.IsNull(this.tableCampi.AliasColumn);

      public void SetAliasNull() => this[this.tableCampi.AliasColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class CampiRowChangeEvent : EventArgs
    {
      private DataSetReport.CampiRow eventRow;
      private DataRowAction eventAction;

      public CampiRowChangeEvent(DataSetReport.CampiRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public DataSetReport.CampiRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class TuttiCampiDataTable : DataTable, IEnumerable
    {
      private DataColumn columnNomeTabella;
      private DataColumn columnNomeCampo;
      private DataColumn columnIdGlossario;
      private DataColumn columnTipologia;
      private DataColumn columnTipoDato;
      private DataColumn columnAlias;

      internal TuttiCampiDataTable()
        : base("TuttiCampi")
        => this.InitClass();

      internal TuttiCampiDataTable(DataTable table)
        : base(table.TableName)
      {
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
        this.DisplayExpression = table.DisplayExpression;
      }

      [Browsable(false)]
      public int Count => this.Rows.Count;

      internal DataColumn NomeTabellaColumn => this.columnNomeTabella;

      internal DataColumn NomeCampoColumn => this.columnNomeCampo;

      internal DataColumn IdGlossarioColumn => this.columnIdGlossario;

      internal DataColumn TipologiaColumn => this.columnTipologia;

      internal DataColumn TipoDatoColumn => this.columnTipoDato;

      internal DataColumn AliasColumn => this.columnAlias;

      public DataSetReport.TuttiCampiRow this[int index] => (DataSetReport.TuttiCampiRow) this.Rows[index];

      public event DataSetReport.TuttiCampiRowChangeEventHandler TuttiCampiRowChanged;

      public event DataSetReport.TuttiCampiRowChangeEventHandler TuttiCampiRowChanging;

      public event DataSetReport.TuttiCampiRowChangeEventHandler TuttiCampiRowDeleted;

      public event DataSetReport.TuttiCampiRowChangeEventHandler TuttiCampiRowDeleting;

      public void AddTuttiCampiRow(DataSetReport.TuttiCampiRow row) => this.Rows.Add((DataRow) row);

      public DataSetReport.TuttiCampiRow AddTuttiCampiRow(
        string NomeTabella,
        string NomeCampo,
        int IdGlossario,
        string Tipologia,
        string TipoDato,
        string Alias)
      {
        DataSetReport.TuttiCampiRow tuttiCampiRow = (DataSetReport.TuttiCampiRow) this.NewRow();
        tuttiCampiRow.ItemArray = new object[6]
        {
          (object) NomeTabella,
          (object) NomeCampo,
          (object) IdGlossario,
          (object) Tipologia,
          (object) TipoDato,
          (object) Alias
        };
        this.Rows.Add((DataRow) tuttiCampiRow);
        return tuttiCampiRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        DataSetReport.TuttiCampiDataTable tuttiCampiDataTable = (DataSetReport.TuttiCampiDataTable) base.Clone();
        tuttiCampiDataTable.InitVars();
        return (DataTable) tuttiCampiDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new DataSetReport.TuttiCampiDataTable();

      internal void InitVars()
      {
        this.columnNomeTabella = this.Columns["NomeTabella"];
        this.columnNomeCampo = this.Columns["NomeCampo"];
        this.columnIdGlossario = this.Columns["IdGlossario"];
        this.columnTipologia = this.Columns["Tipologia"];
        this.columnTipoDato = this.Columns["TipoDato"];
        this.columnAlias = this.Columns["Alias"];
      }

      private void InitClass()
      {
        this.columnNomeTabella = new DataColumn("NomeTabella", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNomeTabella);
        this.columnNomeCampo = new DataColumn("NomeCampo", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNomeCampo);
        this.columnIdGlossario = new DataColumn("IdGlossario", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdGlossario);
        this.columnTipologia = new DataColumn("Tipologia", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTipologia);
        this.columnTipoDato = new DataColumn("TipoDato", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTipoDato);
        this.columnAlias = new DataColumn("Alias", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAlias);
      }

      public DataSetReport.TuttiCampiRow NewTuttiCampiRow() => (DataSetReport.TuttiCampiRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new DataSetReport.TuttiCampiRow(builder);

      protected override Type GetRowType() => typeof (DataSetReport.TuttiCampiRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TuttiCampiRowChanged == null)
          return;
        this.TuttiCampiRowChanged((object) this, new DataSetReport.TuttiCampiRowChangeEvent((DataSetReport.TuttiCampiRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TuttiCampiRowChanging == null)
          return;
        this.TuttiCampiRowChanging((object) this, new DataSetReport.TuttiCampiRowChangeEvent((DataSetReport.TuttiCampiRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TuttiCampiRowDeleted == null)
          return;
        this.TuttiCampiRowDeleted((object) this, new DataSetReport.TuttiCampiRowChangeEvent((DataSetReport.TuttiCampiRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TuttiCampiRowDeleting == null)
          return;
        this.TuttiCampiRowDeleting((object) this, new DataSetReport.TuttiCampiRowChangeEvent((DataSetReport.TuttiCampiRow) e.Row, e.Action));
      }

      public void RemoveTuttiCampiRow(DataSetReport.TuttiCampiRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TuttiCampiRow : DataRow
    {
      private DataSetReport.TuttiCampiDataTable tableTuttiCampi;

      internal TuttiCampiRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTuttiCampi = (DataSetReport.TuttiCampiDataTable) this.Table;

      public string NomeTabella
      {
        get
        {
          try
          {
            return (string) this[this.tableTuttiCampi.NomeTabellaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTuttiCampi.NomeTabellaColumn] = (object) value;
      }

      public string NomeCampo
      {
        get
        {
          try
          {
            return (string) this[this.tableTuttiCampi.NomeCampoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTuttiCampi.NomeCampoColumn] = (object) value;
      }

      public int IdGlossario
      {
        get
        {
          try
          {
            return (int) this[this.tableTuttiCampi.IdGlossarioColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTuttiCampi.IdGlossarioColumn] = (object) value;
      }

      public string Tipologia
      {
        get
        {
          try
          {
            return (string) this[this.tableTuttiCampi.TipologiaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTuttiCampi.TipologiaColumn] = (object) value;
      }

      public string TipoDato
      {
        get
        {
          try
          {
            return (string) this[this.tableTuttiCampi.TipoDatoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTuttiCampi.TipoDatoColumn] = (object) value;
      }

      public string Alias
      {
        get
        {
          try
          {
            return (string) this[this.tableTuttiCampi.AliasColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTuttiCampi.AliasColumn] = (object) value;
      }

      public bool IsNomeTabellaNull() => this.IsNull(this.tableTuttiCampi.NomeTabellaColumn);

      public void SetNomeTabellaNull() => this[this.tableTuttiCampi.NomeTabellaColumn] = Convert.DBNull;

      public bool IsNomeCampoNull() => this.IsNull(this.tableTuttiCampi.NomeCampoColumn);

      public void SetNomeCampoNull() => this[this.tableTuttiCampi.NomeCampoColumn] = Convert.DBNull;

      public bool IsIdGlossarioNull() => this.IsNull(this.tableTuttiCampi.IdGlossarioColumn);

      public void SetIdGlossarioNull() => this[this.tableTuttiCampi.IdGlossarioColumn] = Convert.DBNull;

      public bool IsTipologiaNull() => this.IsNull(this.tableTuttiCampi.TipologiaColumn);

      public void SetTipologiaNull() => this[this.tableTuttiCampi.TipologiaColumn] = Convert.DBNull;

      public bool IsTipoDatoNull() => this.IsNull(this.tableTuttiCampi.TipoDatoColumn);

      public void SetTipoDatoNull() => this[this.tableTuttiCampi.TipoDatoColumn] = Convert.DBNull;

      public bool IsAliasNull() => this.IsNull(this.tableTuttiCampi.AliasColumn);

      public void SetAliasNull() => this[this.tableTuttiCampi.AliasColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class TuttiCampiRowChangeEvent : EventArgs
    {
      private DataSetReport.TuttiCampiRow eventRow;
      private DataRowAction eventAction;

      public TuttiCampiRowChangeEvent(DataSetReport.TuttiCampiRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public DataSetReport.TuttiCampiRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }
  }
}
