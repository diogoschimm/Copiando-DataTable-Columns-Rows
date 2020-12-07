using System.Data;

namespace TrabalhandoDataTable
{
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
}
