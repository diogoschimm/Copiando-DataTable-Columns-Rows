# Copiando-DataTable-Columns-Rows
Copiando rows e columns de um datatable para outro datatable

## Métodos de Extensão para o Datatable e Método Static para criar um novo Datatable a partir de outro

```csharp
    public static class DataTableExtensions
    {
        public static DataTable CreateNewDataTable(DataTable dtOrigem)
        {
            var newDt = new DataTable();
            foreach (DataColumn dc in dtOrigem.Columns)
                newDt.Columns.Add(dc.ColumnName, dc.DataType);

            return newDt;
        }

        public static void AddRowDataTable(this DataTable dtOrigem, DataRow drToAdd)
        {
            var newRow = dtOrigem.NewRow();
            foreach (DataColumn dc in dtOrigem.Rows)
                newRow[dc.ColumnName] = drToAdd[dc.ColumnName];

            dtOrigem.Rows.Add(newRow);
        }
    }
```

## Método para criar um Datatable com Chave Primária

```csharp
  private static DataTable CriarDataTableWithPk()
  {
      var dt = new DataTable();
      dt.Columns.Add("idCliente", typeof(int));
      dt.Columns.Add("nomeCliente", typeof(string));

      dt.PrimaryKey = new DataColumn[] { dt.Columns["idCliente"] };

      for (int i = 0; i < 10; i++)
      {
          var row = dt.NewRow();
          row["idCliente"] = i + 1;
          row["nomeCliente"] = $"Cliente {i + 1}";

          dt.Rows.Add(row);
      }

      return dt;
  } 
```
