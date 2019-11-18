using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class Class1
    {


        

        public static void insert_factura(
             string idtransaccion,
         string fecha,
         int sucursal,
         int tipodocumento,
         string nrodocumento,
         string dnicliente,
         string nombrecliente,
         string direccioncliente,
         int sistemaproveniente
            ) 
        {
            BenchDBDataSetTableAdapters.QueriesTableAdapter QTA = new BenchDBDataSetTableAdapters.QueriesTableAdapter();
            QTA.proc_insertar_factura(idtransaccion, fecha, sucursal, tipodocumento, nrodocumento, dnicliente, nombrecliente, direccioncliente, sistemaproveniente);
        }

        public static void insert_item(int cant, string code) 
        {
            BenchDBDataSetTableAdapters.QueriesTableAdapter QTA = new BenchDBDataSetTableAdapters.QueriesTableAdapter();
            QTA.InsertItem(code, cant);
        }

        public static void insertuitem(
             string idtransaccion,
         string fecha,
         int sucursal,
         int tipodocumento,
         string nrodocumento,
         string dnicliente,
         string nombrecliente,
         string direccioncliente,
         int sistemaproveniente,
         int cant,
         string code
         )
        
        {
            BenchDBDataSetTableAdapters.QueriesTableAdapter QTA = new BenchDBDataSetTableAdapters.QueriesTableAdapter();
            QTA.InsertUItem2(code, cant, idtransaccion, fecha, sucursal, tipodocumento, nrodocumento, dnicliente, nombrecliente, direccioncliente, sistemaproveniente);
        }

    }
}
