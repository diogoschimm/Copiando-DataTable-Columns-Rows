using System;
using System.Data;

namespace TrabalhandoDataTable
{
    class Program
    {
        static void Main(string[] args)
        { 
            var dtDadosPk = CriarDataTableWithPk(); 
            Console.WriteLine($"Quantidade de Clientes {dtDadosPk.Rows.Count}");

            var dtFinal = DataTableExtensions.CreateNewDataTable(dtDadosPk);

            for (int i = 0; i < 10; i++)
                dtFinal.AddRowDataTable(dtDadosPk.Rows[0]);

        } 
         
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
    }
}
