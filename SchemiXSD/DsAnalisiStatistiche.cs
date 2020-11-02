// Decompiled with JetBrains decompiler
// Type: TheSite.SchemiXSD.DsAnalisiStatistiche
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

namespace TheSite.SchemiXSD
{
  [ToolboxItem(true)]
  [DesignerCategory("code")]
  [DebuggerStepThrough]
  [Serializable]
  public class DsAnalisiStatistiche : DataSet
  {
    private DsAnalisiStatistiche._TableDataTable table_Table;
    private DsAnalisiStatistiche.tblgiudizioDataTable tabletblgiudizio;
    private DsAnalisiStatistiche.ChartRadarDataTable tableChartRadar;

    public DsAnalisiStatistiche()
    {
      this.InitClass();
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      this.Tables.CollectionChanged += changeEventHandler;
      this.Relations.CollectionChanged += changeEventHandler;
    }

    protected DsAnalisiStatistiche(SerializationInfo info, StreamingContext context)
    {
      string s = (string) info.GetValue("XmlSchema", typeof (string));
      if (s != null)
      {
        DataSet dataSet = new DataSet();
        dataSet.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
        if (dataSet.Tables["Table"] != null)
          this.Tables.Add((DataTable) new DsAnalisiStatistiche._TableDataTable(dataSet.Tables["Table"]));
        if (dataSet.Tables[nameof (tblgiudizio)] != null)
          this.Tables.Add((DataTable) new DsAnalisiStatistiche.tblgiudizioDataTable(dataSet.Tables[nameof (tblgiudizio)]));
        if (dataSet.Tables[nameof (ChartRadar)] != null)
          this.Tables.Add((DataTable) new DsAnalisiStatistiche.ChartRadarDataTable(dataSet.Tables[nameof (ChartRadar)]));
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

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public DsAnalisiStatistiche._TableDataTable _Table => this.table_Table;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public DsAnalisiStatistiche.tblgiudizioDataTable tblgiudizio => this.tabletblgiudizio;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public DsAnalisiStatistiche.ChartRadarDataTable ChartRadar => this.tableChartRadar;

    public override DataSet Clone()
    {
      DsAnalisiStatistiche analisiStatistiche = (DsAnalisiStatistiche) base.Clone();
      analisiStatistiche.InitVars();
      return (DataSet) analisiStatistiche;
    }

    protected override bool ShouldSerializeTables() => false;

    protected override bool ShouldSerializeRelations() => false;

    protected override void ReadXmlSerializable(XmlReader reader)
    {
      this.Reset();
      DataSet dataSet = new DataSet();
      int num = (int) dataSet.ReadXml(reader);
      if (dataSet.Tables["Table"] != null)
        this.Tables.Add((DataTable) new DsAnalisiStatistiche._TableDataTable(dataSet.Tables["Table"]));
      if (dataSet.Tables["tblgiudizio"] != null)
        this.Tables.Add((DataTable) new DsAnalisiStatistiche.tblgiudizioDataTable(dataSet.Tables["tblgiudizio"]));
      if (dataSet.Tables["ChartRadar"] != null)
        this.Tables.Add((DataTable) new DsAnalisiStatistiche.ChartRadarDataTable(dataSet.Tables["ChartRadar"]));
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
      this.table_Table = (DsAnalisiStatistiche._TableDataTable) this.Tables["Table"];
      if (this.table_Table != null)
        this.table_Table.InitVars();
      this.tabletblgiudizio = (DsAnalisiStatistiche.tblgiudizioDataTable) this.Tables["tblgiudizio"];
      if (this.tabletblgiudizio != null)
        this.tabletblgiudizio.InitVars();
      this.tableChartRadar = (DsAnalisiStatistiche.ChartRadarDataTable) this.Tables["ChartRadar"];
      if (this.tableChartRadar == null)
        return;
      this.tableChartRadar.InitVars();
    }

    private void InitClass()
    {
      this.DataSetName = nameof (DsAnalisiStatistiche);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/DsAnalisiStatistiche.xsd";
      this.Locale = new CultureInfo("en-US");
      this.CaseSensitive = false;
      this.EnforceConstraints = true;
      this.table_Table = new DsAnalisiStatistiche._TableDataTable();
      this.Tables.Add((DataTable) this.table_Table);
      this.tabletblgiudizio = new DsAnalisiStatistiche.tblgiudizioDataTable();
      this.Tables.Add((DataTable) this.tabletblgiudizio);
      this.tableChartRadar = new DsAnalisiStatistiche.ChartRadarDataTable();
      this.Tables.Add((DataTable) this.tableChartRadar);
    }

    private bool ShouldSerialize_Table() => false;

    private bool ShouldSerializetblgiudizio() => false;

    private bool ShouldSerializeChartRadar() => false;

    private void SchemaChanged(object sender, CollectionChangeEventArgs e)
    {
      if (e.Action != CollectionChangeAction.Remove)
        return;
      this.InitVars();
    }

    public delegate void _TableRowChangeEventHandler(
      object sender,
      DsAnalisiStatistiche._TableRowChangeEvent e);

    public delegate void tblgiudizioRowChangeEventHandler(
      object sender,
      DsAnalisiStatistiche.tblgiudizioRowChangeEvent e);

    public delegate void ChartRadarRowChangeEventHandler(
      object sender,
      DsAnalisiStatistiche.ChartRadarRowChangeEvent e);

    [DebuggerStepThrough]
    public class _TableDataTable : DataTable, IEnumerable
    {
      private DataColumn columnI_RDL;
      private DataColumn columnI_PERCENTUALE;
      private DataColumn columnS_DITTA;
      private DataColumn columnS_DITTAM;
      private DataColumn columnS_SERVIZIO;
      private DataColumn columnS_STATO;
      private DataColumn columnS_DESCRIZIONE;
      private DataColumn columnS_GIORNO;
      private DataColumn columnS_LGIORNO;
      private DataColumn columnS_MESE;
      private DataColumn columnS_LMESE;
      private DataColumn columnS_ANNO;

      internal _TableDataTable()
        : base("Table")
        => this.InitClass();

      internal _TableDataTable(DataTable table)
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

      internal DataColumn I_RDLColumn => this.columnI_RDL;

      internal DataColumn I_PERCENTUALEColumn => this.columnI_PERCENTUALE;

      internal DataColumn S_DITTAColumn => this.columnS_DITTA;

      internal DataColumn S_DITTAMColumn => this.columnS_DITTAM;

      internal DataColumn S_SERVIZIOColumn => this.columnS_SERVIZIO;

      internal DataColumn S_STATOColumn => this.columnS_STATO;

      internal DataColumn S_DESCRIZIONEColumn => this.columnS_DESCRIZIONE;

      internal DataColumn S_GIORNOColumn => this.columnS_GIORNO;

      internal DataColumn S_LGIORNOColumn => this.columnS_LGIORNO;

      internal DataColumn S_MESEColumn => this.columnS_MESE;

      internal DataColumn S_LMESEColumn => this.columnS_LMESE;

      internal DataColumn S_ANNOColumn => this.columnS_ANNO;

      public DsAnalisiStatistiche._TableRow this[int index] => (DsAnalisiStatistiche._TableRow) this.Rows[index];

      public event DsAnalisiStatistiche._TableRowChangeEventHandler _TableRowChanged;

      public event DsAnalisiStatistiche._TableRowChangeEventHandler _TableRowChanging;

      public event DsAnalisiStatistiche._TableRowChangeEventHandler _TableRowDeleted;

      public event DsAnalisiStatistiche._TableRowChangeEventHandler _TableRowDeleting;

      public void Add_TableRow(DsAnalisiStatistiche._TableRow row) => this.Rows.Add((DataRow) row);

      public DsAnalisiStatistiche._TableRow Add_TableRow(
        long I_RDL,
        float I_PERCENTUALE,
        string S_DITTA,
        string S_DITTAM,
        string S_SERVIZIO,
        string S_STATO,
        string S_DESCRIZIONE,
        string S_GIORNO,
        string S_LGIORNO,
        string S_MESE,
        string S_LMESE,
        string S_ANNO)
      {
        DsAnalisiStatistiche._TableRow tableRow = (DsAnalisiStatistiche._TableRow) this.NewRow();
        tableRow.ItemArray = new object[12]
        {
          (object) I_RDL,
          (object) I_PERCENTUALE,
          (object) S_DITTA,
          (object) S_DITTAM,
          (object) S_SERVIZIO,
          (object) S_STATO,
          (object) S_DESCRIZIONE,
          (object) S_GIORNO,
          (object) S_LGIORNO,
          (object) S_MESE,
          (object) S_LMESE,
          (object) S_ANNO
        };
        this.Rows.Add((DataRow) tableRow);
        return tableRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        DsAnalisiStatistiche._TableDataTable tableDataTable = (DsAnalisiStatistiche._TableDataTable) base.Clone();
        tableDataTable.InitVars();
        return (DataTable) tableDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new DsAnalisiStatistiche._TableDataTable();

      internal void InitVars()
      {
        this.columnI_RDL = this.Columns["I_RDL"];
        this.columnI_PERCENTUALE = this.Columns["I_PERCENTUALE"];
        this.columnS_DITTA = this.Columns["S_DITTA"];
        this.columnS_DITTAM = this.Columns["S_DITTAM"];
        this.columnS_SERVIZIO = this.Columns["S_SERVIZIO"];
        this.columnS_STATO = this.Columns["S_STATO"];
        this.columnS_DESCRIZIONE = this.Columns["S_DESCRIZIONE"];
        this.columnS_GIORNO = this.Columns["S_GIORNO"];
        this.columnS_LGIORNO = this.Columns["S_LGIORNO"];
        this.columnS_MESE = this.Columns["S_MESE"];
        this.columnS_LMESE = this.Columns["S_LMESE"];
        this.columnS_ANNO = this.Columns["S_ANNO"];
      }

      private void InitClass()
      {
        this.columnI_RDL = new DataColumn("I_RDL", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnI_RDL);
        this.columnI_PERCENTUALE = new DataColumn("I_PERCENTUALE", typeof (float), (string) null, MappingType.Element);
        this.Columns.Add(this.columnI_PERCENTUALE);
        this.columnS_DITTA = new DataColumn("S_DITTA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnS_DITTA);
        this.columnS_DITTAM = new DataColumn("S_DITTAM", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnS_DITTAM);
        this.columnS_SERVIZIO = new DataColumn("S_SERVIZIO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnS_SERVIZIO);
        this.columnS_STATO = new DataColumn("S_STATO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnS_STATO);
        this.columnS_DESCRIZIONE = new DataColumn("S_DESCRIZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnS_DESCRIZIONE);
        this.columnS_GIORNO = new DataColumn("S_GIORNO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnS_GIORNO);
        this.columnS_LGIORNO = new DataColumn("S_LGIORNO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnS_LGIORNO);
        this.columnS_MESE = new DataColumn("S_MESE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnS_MESE);
        this.columnS_LMESE = new DataColumn("S_LMESE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnS_LMESE);
        this.columnS_ANNO = new DataColumn("S_ANNO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnS_ANNO);
      }

      public DsAnalisiStatistiche._TableRow New_TableRow() => (DsAnalisiStatistiche._TableRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new DsAnalisiStatistiche._TableRow(builder);

      protected override Type GetRowType() => typeof (DsAnalisiStatistiche._TableRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this._TableRowChanged == null)
          return;
        this._TableRowChanged((object) this, new DsAnalisiStatistiche._TableRowChangeEvent((DsAnalisiStatistiche._TableRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this._TableRowChanging == null)
          return;
        this._TableRowChanging((object) this, new DsAnalisiStatistiche._TableRowChangeEvent((DsAnalisiStatistiche._TableRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this._TableRowDeleted == null)
          return;
        this._TableRowDeleted((object) this, new DsAnalisiStatistiche._TableRowChangeEvent((DsAnalisiStatistiche._TableRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this._TableRowDeleting == null)
          return;
        this._TableRowDeleting((object) this, new DsAnalisiStatistiche._TableRowChangeEvent((DsAnalisiStatistiche._TableRow) e.Row, e.Action));
      }

      public void Remove_TableRow(DsAnalisiStatistiche._TableRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class _TableRow : DataRow
    {
      private DsAnalisiStatistiche._TableDataTable table_Table;

      internal _TableRow(DataRowBuilder rb)
        : base(rb)
        => this.table_Table = (DsAnalisiStatistiche._TableDataTable) this.Table;

      public long I_RDL
      {
        get
        {
          try
          {
            return (long) this[this.table_Table.I_RDLColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.table_Table.I_RDLColumn] = (object) value;
      }

      public float I_PERCENTUALE
      {
        get
        {
          try
          {
            return (float) this[this.table_Table.I_PERCENTUALEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.table_Table.I_PERCENTUALEColumn] = (object) value;
      }

      public string S_DITTA
      {
        get
        {
          try
          {
            return (string) this[this.table_Table.S_DITTAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.table_Table.S_DITTAColumn] = (object) value;
      }

      public string S_DITTAM
      {
        get
        {
          try
          {
            return (string) this[this.table_Table.S_DITTAMColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.table_Table.S_DITTAMColumn] = (object) value;
      }

      public string S_SERVIZIO
      {
        get
        {
          try
          {
            return (string) this[this.table_Table.S_SERVIZIOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.table_Table.S_SERVIZIOColumn] = (object) value;
      }

      public string S_STATO
      {
        get
        {
          try
          {
            return (string) this[this.table_Table.S_STATOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.table_Table.S_STATOColumn] = (object) value;
      }

      public string S_DESCRIZIONE
      {
        get
        {
          try
          {
            return (string) this[this.table_Table.S_DESCRIZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.table_Table.S_DESCRIZIONEColumn] = (object) value;
      }

      public string S_GIORNO
      {
        get
        {
          try
          {
            return (string) this[this.table_Table.S_GIORNOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.table_Table.S_GIORNOColumn] = (object) value;
      }

      public string S_LGIORNO
      {
        get
        {
          try
          {
            return (string) this[this.table_Table.S_LGIORNOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.table_Table.S_LGIORNOColumn] = (object) value;
      }

      public string S_MESE
      {
        get
        {
          try
          {
            return (string) this[this.table_Table.S_MESEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.table_Table.S_MESEColumn] = (object) value;
      }

      public string S_LMESE
      {
        get
        {
          try
          {
            return (string) this[this.table_Table.S_LMESEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.table_Table.S_LMESEColumn] = (object) value;
      }

      public string S_ANNO
      {
        get
        {
          try
          {
            return (string) this[this.table_Table.S_ANNOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.table_Table.S_ANNOColumn] = (object) value;
      }

      public bool IsI_RDLNull() => this.IsNull(this.table_Table.I_RDLColumn);

      public void SetI_RDLNull() => this[this.table_Table.I_RDLColumn] = Convert.DBNull;

      public bool IsI_PERCENTUALENull() => this.IsNull(this.table_Table.I_PERCENTUALEColumn);

      public void SetI_PERCENTUALENull() => this[this.table_Table.I_PERCENTUALEColumn] = Convert.DBNull;

      public bool IsS_DITTANull() => this.IsNull(this.table_Table.S_DITTAColumn);

      public void SetS_DITTANull() => this[this.table_Table.S_DITTAColumn] = Convert.DBNull;

      public bool IsS_DITTAMNull() => this.IsNull(this.table_Table.S_DITTAMColumn);

      public void SetS_DITTAMNull() => this[this.table_Table.S_DITTAMColumn] = Convert.DBNull;

      public bool IsS_SERVIZIONull() => this.IsNull(this.table_Table.S_SERVIZIOColumn);

      public void SetS_SERVIZIONull() => this[this.table_Table.S_SERVIZIOColumn] = Convert.DBNull;

      public bool IsS_STATONull() => this.IsNull(this.table_Table.S_STATOColumn);

      public void SetS_STATONull() => this[this.table_Table.S_STATOColumn] = Convert.DBNull;

      public bool IsS_DESCRIZIONENull() => this.IsNull(this.table_Table.S_DESCRIZIONEColumn);

      public void SetS_DESCRIZIONENull() => this[this.table_Table.S_DESCRIZIONEColumn] = Convert.DBNull;

      public bool IsS_GIORNONull() => this.IsNull(this.table_Table.S_GIORNOColumn);

      public void SetS_GIORNONull() => this[this.table_Table.S_GIORNOColumn] = Convert.DBNull;

      public bool IsS_LGIORNONull() => this.IsNull(this.table_Table.S_LGIORNOColumn);

      public void SetS_LGIORNONull() => this[this.table_Table.S_LGIORNOColumn] = Convert.DBNull;

      public bool IsS_MESENull() => this.IsNull(this.table_Table.S_MESEColumn);

      public void SetS_MESENull() => this[this.table_Table.S_MESEColumn] = Convert.DBNull;

      public bool IsS_LMESENull() => this.IsNull(this.table_Table.S_LMESEColumn);

      public void SetS_LMESENull() => this[this.table_Table.S_LMESEColumn] = Convert.DBNull;

      public bool IsS_ANNONull() => this.IsNull(this.table_Table.S_ANNOColumn);

      public void SetS_ANNONull() => this[this.table_Table.S_ANNOColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class _TableRowChangeEvent : EventArgs
    {
      private DsAnalisiStatistiche._TableRow eventRow;
      private DataRowAction eventAction;

      public _TableRowChangeEvent(DsAnalisiStatistiche._TableRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public DsAnalisiStatistiche._TableRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class tblgiudizioDataTable : DataTable, IEnumerable
    {
      private DataColumn columnn_giudizio;
      private DataColumn columndesc_giud;
      private DataColumn columndesc_serv;
      private DataColumn columntip_giudizio;
      private DataColumn columni_percentuale;
      private DataColumn columns_mese;
      private DataColumn columns_lmese;
      private DataColumn columns_anno;

      internal tblgiudizioDataTable()
        : base("tblgiudizio")
        => this.InitClass();

      internal tblgiudizioDataTable(DataTable table)
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

      internal DataColumn n_giudizioColumn => this.columnn_giudizio;

      internal DataColumn desc_giudColumn => this.columndesc_giud;

      internal DataColumn desc_servColumn => this.columndesc_serv;

      internal DataColumn tip_giudizioColumn => this.columntip_giudizio;

      internal DataColumn i_percentualeColumn => this.columni_percentuale;

      internal DataColumn s_meseColumn => this.columns_mese;

      internal DataColumn s_lmeseColumn => this.columns_lmese;

      internal DataColumn s_annoColumn => this.columns_anno;

      public DsAnalisiStatistiche.tblgiudizioRow this[int index] => (DsAnalisiStatistiche.tblgiudizioRow) this.Rows[index];

      public event DsAnalisiStatistiche.tblgiudizioRowChangeEventHandler tblgiudizioRowChanged;

      public event DsAnalisiStatistiche.tblgiudizioRowChangeEventHandler tblgiudizioRowChanging;

      public event DsAnalisiStatistiche.tblgiudizioRowChangeEventHandler tblgiudizioRowDeleted;

      public event DsAnalisiStatistiche.tblgiudizioRowChangeEventHandler tblgiudizioRowDeleting;

      public void AddtblgiudizioRow(DsAnalisiStatistiche.tblgiudizioRow row) => this.Rows.Add((DataRow) row);

      public DsAnalisiStatistiche.tblgiudizioRow AddtblgiudizioRow(
        long n_giudizio,
        string desc_giud,
        string desc_serv,
        string tip_giudizio,
        float i_percentuale,
        string s_mese,
        string s_lmese,
        string s_anno)
      {
        DsAnalisiStatistiche.tblgiudizioRow tblgiudizioRow = (DsAnalisiStatistiche.tblgiudizioRow) this.NewRow();
        tblgiudizioRow.ItemArray = new object[8]
        {
          (object) n_giudizio,
          (object) desc_giud,
          (object) desc_serv,
          (object) tip_giudizio,
          (object) i_percentuale,
          (object) s_mese,
          (object) s_lmese,
          (object) s_anno
        };
        this.Rows.Add((DataRow) tblgiudizioRow);
        return tblgiudizioRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        DsAnalisiStatistiche.tblgiudizioDataTable tblgiudizioDataTable = (DsAnalisiStatistiche.tblgiudizioDataTable) base.Clone();
        tblgiudizioDataTable.InitVars();
        return (DataTable) tblgiudizioDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new DsAnalisiStatistiche.tblgiudizioDataTable();

      internal void InitVars()
      {
        this.columnn_giudizio = this.Columns["n_giudizio"];
        this.columndesc_giud = this.Columns["desc_giud"];
        this.columndesc_serv = this.Columns["desc_serv"];
        this.columntip_giudizio = this.Columns["tip_giudizio"];
        this.columni_percentuale = this.Columns["i_percentuale"];
        this.columns_mese = this.Columns["s_mese"];
        this.columns_lmese = this.Columns["s_lmese"];
        this.columns_anno = this.Columns["s_anno"];
      }

      private void InitClass()
      {
        this.columnn_giudizio = new DataColumn("n_giudizio", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnn_giudizio);
        this.columndesc_giud = new DataColumn("desc_giud", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columndesc_giud);
        this.columndesc_serv = new DataColumn("desc_serv", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columndesc_serv);
        this.columntip_giudizio = new DataColumn("tip_giudizio", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columntip_giudizio);
        this.columni_percentuale = new DataColumn("i_percentuale", typeof (float), (string) null, MappingType.Element);
        this.Columns.Add(this.columni_percentuale);
        this.columns_mese = new DataColumn("s_mese", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columns_mese);
        this.columns_lmese = new DataColumn("s_lmese", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columns_lmese);
        this.columns_anno = new DataColumn("s_anno", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columns_anno);
      }

      public DsAnalisiStatistiche.tblgiudizioRow NewtblgiudizioRow() => (DsAnalisiStatistiche.tblgiudizioRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new DsAnalisiStatistiche.tblgiudizioRow(builder);

      protected override Type GetRowType() => typeof (DsAnalisiStatistiche.tblgiudizioRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.tblgiudizioRowChanged == null)
          return;
        this.tblgiudizioRowChanged((object) this, new DsAnalisiStatistiche.tblgiudizioRowChangeEvent((DsAnalisiStatistiche.tblgiudizioRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.tblgiudizioRowChanging == null)
          return;
        this.tblgiudizioRowChanging((object) this, new DsAnalisiStatistiche.tblgiudizioRowChangeEvent((DsAnalisiStatistiche.tblgiudizioRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.tblgiudizioRowDeleted == null)
          return;
        this.tblgiudizioRowDeleted((object) this, new DsAnalisiStatistiche.tblgiudizioRowChangeEvent((DsAnalisiStatistiche.tblgiudizioRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.tblgiudizioRowDeleting == null)
          return;
        this.tblgiudizioRowDeleting((object) this, new DsAnalisiStatistiche.tblgiudizioRowChangeEvent((DsAnalisiStatistiche.tblgiudizioRow) e.Row, e.Action));
      }

      public void RemovetblgiudizioRow(DsAnalisiStatistiche.tblgiudizioRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class tblgiudizioRow : DataRow
    {
      private DsAnalisiStatistiche.tblgiudizioDataTable tabletblgiudizio;

      internal tblgiudizioRow(DataRowBuilder rb)
        : base(rb)
        => this.tabletblgiudizio = (DsAnalisiStatistiche.tblgiudizioDataTable) this.Table;

      public long n_giudizio
      {
        get
        {
          try
          {
            return (long) this[this.tabletblgiudizio.n_giudizioColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblgiudizio.n_giudizioColumn] = (object) value;
      }

      public string desc_giud
      {
        get
        {
          try
          {
            return (string) this[this.tabletblgiudizio.desc_giudColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblgiudizio.desc_giudColumn] = (object) value;
      }

      public string desc_serv
      {
        get
        {
          try
          {
            return (string) this[this.tabletblgiudizio.desc_servColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblgiudizio.desc_servColumn] = (object) value;
      }

      public string tip_giudizio
      {
        get
        {
          try
          {
            return (string) this[this.tabletblgiudizio.tip_giudizioColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblgiudizio.tip_giudizioColumn] = (object) value;
      }

      public float i_percentuale
      {
        get
        {
          try
          {
            return (float) this[this.tabletblgiudizio.i_percentualeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblgiudizio.i_percentualeColumn] = (object) value;
      }

      public string s_mese
      {
        get
        {
          try
          {
            return (string) this[this.tabletblgiudizio.s_meseColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblgiudizio.s_meseColumn] = (object) value;
      }

      public string s_lmese
      {
        get
        {
          try
          {
            return (string) this[this.tabletblgiudizio.s_lmeseColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblgiudizio.s_lmeseColumn] = (object) value;
      }

      public string s_anno
      {
        get
        {
          try
          {
            return (string) this[this.tabletblgiudizio.s_annoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblgiudizio.s_annoColumn] = (object) value;
      }

      public bool Isn_giudizioNull() => this.IsNull(this.tabletblgiudizio.n_giudizioColumn);

      public void Setn_giudizioNull() => this[this.tabletblgiudizio.n_giudizioColumn] = Convert.DBNull;

      public bool Isdesc_giudNull() => this.IsNull(this.tabletblgiudizio.desc_giudColumn);

      public void Setdesc_giudNull() => this[this.tabletblgiudizio.desc_giudColumn] = Convert.DBNull;

      public bool Isdesc_servNull() => this.IsNull(this.tabletblgiudizio.desc_servColumn);

      public void Setdesc_servNull() => this[this.tabletblgiudizio.desc_servColumn] = Convert.DBNull;

      public bool Istip_giudizioNull() => this.IsNull(this.tabletblgiudizio.tip_giudizioColumn);

      public void Settip_giudizioNull() => this[this.tabletblgiudizio.tip_giudizioColumn] = Convert.DBNull;

      public bool Isi_percentualeNull() => this.IsNull(this.tabletblgiudizio.i_percentualeColumn);

      public void Seti_percentualeNull() => this[this.tabletblgiudizio.i_percentualeColumn] = Convert.DBNull;

      public bool Iss_meseNull() => this.IsNull(this.tabletblgiudizio.s_meseColumn);

      public void Sets_meseNull() => this[this.tabletblgiudizio.s_meseColumn] = Convert.DBNull;

      public bool Iss_lmeseNull() => this.IsNull(this.tabletblgiudizio.s_lmeseColumn);

      public void Sets_lmeseNull() => this[this.tabletblgiudizio.s_lmeseColumn] = Convert.DBNull;

      public bool Iss_annoNull() => this.IsNull(this.tabletblgiudizio.s_annoColumn);

      public void Sets_annoNull() => this[this.tabletblgiudizio.s_annoColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class tblgiudizioRowChangeEvent : EventArgs
    {
      private DsAnalisiStatistiche.tblgiudizioRow eventRow;
      private DataRowAction eventAction;

      public tblgiudizioRowChangeEvent(
        DsAnalisiStatistiche.tblgiudizioRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public DsAnalisiStatistiche.tblgiudizioRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class ChartRadarDataTable : DataTable, IEnumerable
    {
      private DataColumn columnGG;
      private DataColumn columnDELTA;
      private DataColumn columnPRIORITY;
      private DataColumn columnPENALE;
      private DataColumn columnMEDIA;
      private DataColumn columnVARIANZA;

      internal ChartRadarDataTable()
        : base("ChartRadar")
        => this.InitClass();

      internal ChartRadarDataTable(DataTable table)
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

      internal DataColumn GGColumn => this.columnGG;

      internal DataColumn DELTAColumn => this.columnDELTA;

      internal DataColumn PRIORITYColumn => this.columnPRIORITY;

      internal DataColumn PENALEColumn => this.columnPENALE;

      internal DataColumn MEDIAColumn => this.columnMEDIA;

      internal DataColumn VARIANZAColumn => this.columnVARIANZA;

      public DsAnalisiStatistiche.ChartRadarRow this[int index] => (DsAnalisiStatistiche.ChartRadarRow) this.Rows[index];

      public event DsAnalisiStatistiche.ChartRadarRowChangeEventHandler ChartRadarRowChanged;

      public event DsAnalisiStatistiche.ChartRadarRowChangeEventHandler ChartRadarRowChanging;

      public event DsAnalisiStatistiche.ChartRadarRowChangeEventHandler ChartRadarRowDeleted;

      public event DsAnalisiStatistiche.ChartRadarRowChangeEventHandler ChartRadarRowDeleting;

      public void AddChartRadarRow(DsAnalisiStatistiche.ChartRadarRow row) => this.Rows.Add((DataRow) row);

      public DsAnalisiStatistiche.ChartRadarRow AddChartRadarRow(
        long GG,
        long DELTA,
        long PRIORITY,
        long PENALE,
        double MEDIA,
        double VARIANZA)
      {
        DsAnalisiStatistiche.ChartRadarRow chartRadarRow = (DsAnalisiStatistiche.ChartRadarRow) this.NewRow();
        chartRadarRow.ItemArray = new object[6]
        {
          (object) GG,
          (object) DELTA,
          (object) PRIORITY,
          (object) PENALE,
          (object) MEDIA,
          (object) VARIANZA
        };
        this.Rows.Add((DataRow) chartRadarRow);
        return chartRadarRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        DsAnalisiStatistiche.ChartRadarDataTable chartRadarDataTable = (DsAnalisiStatistiche.ChartRadarDataTable) base.Clone();
        chartRadarDataTable.InitVars();
        return (DataTable) chartRadarDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new DsAnalisiStatistiche.ChartRadarDataTable();

      internal void InitVars()
      {
        this.columnGG = this.Columns["GG"];
        this.columnDELTA = this.Columns["DELTA"];
        this.columnPRIORITY = this.Columns["PRIORITY"];
        this.columnPENALE = this.Columns["PENALE"];
        this.columnMEDIA = this.Columns["MEDIA"];
        this.columnVARIANZA = this.Columns["VARIANZA"];
      }

      private void InitClass()
      {
        this.columnGG = new DataColumn("GG", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnGG);
        this.columnDELTA = new DataColumn("DELTA", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDELTA);
        this.columnPRIORITY = new DataColumn("PRIORITY", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPRIORITY);
        this.columnPENALE = new DataColumn("PENALE", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPENALE);
        this.columnMEDIA = new DataColumn("MEDIA", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMEDIA);
        this.columnVARIANZA = new DataColumn("VARIANZA", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnVARIANZA);
      }

      public DsAnalisiStatistiche.ChartRadarRow NewChartRadarRow() => (DsAnalisiStatistiche.ChartRadarRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new DsAnalisiStatistiche.ChartRadarRow(builder);

      protected override Type GetRowType() => typeof (DsAnalisiStatistiche.ChartRadarRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.ChartRadarRowChanged == null)
          return;
        this.ChartRadarRowChanged((object) this, new DsAnalisiStatistiche.ChartRadarRowChangeEvent((DsAnalisiStatistiche.ChartRadarRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.ChartRadarRowChanging == null)
          return;
        this.ChartRadarRowChanging((object) this, new DsAnalisiStatistiche.ChartRadarRowChangeEvent((DsAnalisiStatistiche.ChartRadarRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.ChartRadarRowDeleted == null)
          return;
        this.ChartRadarRowDeleted((object) this, new DsAnalisiStatistiche.ChartRadarRowChangeEvent((DsAnalisiStatistiche.ChartRadarRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.ChartRadarRowDeleting == null)
          return;
        this.ChartRadarRowDeleting((object) this, new DsAnalisiStatistiche.ChartRadarRowChangeEvent((DsAnalisiStatistiche.ChartRadarRow) e.Row, e.Action));
      }

      public void RemoveChartRadarRow(DsAnalisiStatistiche.ChartRadarRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class ChartRadarRow : DataRow
    {
      private DsAnalisiStatistiche.ChartRadarDataTable tableChartRadar;

      internal ChartRadarRow(DataRowBuilder rb)
        : base(rb)
        => this.tableChartRadar = (DsAnalisiStatistiche.ChartRadarDataTable) this.Table;

      public long GG
      {
        get
        {
          try
          {
            return (long) this[this.tableChartRadar.GGColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableChartRadar.GGColumn] = (object) value;
      }

      public long DELTA
      {
        get
        {
          try
          {
            return (long) this[this.tableChartRadar.DELTAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableChartRadar.DELTAColumn] = (object) value;
      }

      public long PRIORITY
      {
        get
        {
          try
          {
            return (long) this[this.tableChartRadar.PRIORITYColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableChartRadar.PRIORITYColumn] = (object) value;
      }

      public long PENALE
      {
        get
        {
          try
          {
            return (long) this[this.tableChartRadar.PENALEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableChartRadar.PENALEColumn] = (object) value;
      }

      public double MEDIA
      {
        get
        {
          try
          {
            return (double) this[this.tableChartRadar.MEDIAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableChartRadar.MEDIAColumn] = (object) value;
      }

      public double VARIANZA
      {
        get
        {
          try
          {
            return (double) this[this.tableChartRadar.VARIANZAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableChartRadar.VARIANZAColumn] = (object) value;
      }

      public bool IsGGNull() => this.IsNull(this.tableChartRadar.GGColumn);

      public void SetGGNull() => this[this.tableChartRadar.GGColumn] = Convert.DBNull;

      public bool IsDELTANull() => this.IsNull(this.tableChartRadar.DELTAColumn);

      public void SetDELTANull() => this[this.tableChartRadar.DELTAColumn] = Convert.DBNull;

      public bool IsPRIORITYNull() => this.IsNull(this.tableChartRadar.PRIORITYColumn);

      public void SetPRIORITYNull() => this[this.tableChartRadar.PRIORITYColumn] = Convert.DBNull;

      public bool IsPENALENull() => this.IsNull(this.tableChartRadar.PENALEColumn);

      public void SetPENALENull() => this[this.tableChartRadar.PENALEColumn] = Convert.DBNull;

      public bool IsMEDIANull() => this.IsNull(this.tableChartRadar.MEDIAColumn);

      public void SetMEDIANull() => this[this.tableChartRadar.MEDIAColumn] = Convert.DBNull;

      public bool IsVARIANZANull() => this.IsNull(this.tableChartRadar.VARIANZAColumn);

      public void SetVARIANZANull() => this[this.tableChartRadar.VARIANZAColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class ChartRadarRowChangeEvent : EventArgs
    {
      private DsAnalisiStatistiche.ChartRadarRow eventRow;
      private DataRowAction eventAction;

      public ChartRadarRowChangeEvent(DsAnalisiStatistiche.ChartRadarRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public DsAnalisiStatistiche.ChartRadarRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }
  }
}
