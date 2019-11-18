using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Diagnostics;


namespace WebApplication1.Controllers
{

    
    public class UItem
    {
        public string idtransaccion { get; set; }
        public string datetime { get; set; }
        public string code { get; set; }
        public int sucursal { get; set; }
        public int cantidad { get; set; }
        public int tipodocumento { get; set; }
        public string nrodocumento { get; set; }
        public string dnicliente { get; set; }
        public string nombrecliente { get; set; }
        public string direccioncliente { get; set; }
        public int sistemaproveniente { get; set; }
    }

    public class Item
    {
        public int cantidad { get; set; }
        public string code { get; set; }
    }

    public class response
    {
        public string Result { get; set; }
        public string ErrorCode { get; set; }


    }


    public class Bill
    {
        public string idtransaccion { get; set; }
        public string datetime { get; set; }
        public int sucursal { get; set; }
        public int tipodocumento { get; set; }
        public string nrodocumento { get; set; }
        public string dnicliente { get; set; }
        public string nombrecliente { get; set; }
        public string direccioncliente { get; set; }
        public int sistemaproveniente { get; set; }
        public List<Item> ItemList { get; set; }


    }
    
    [System.Web.Http.Route("api/Prueba/{action}")]
    public class PruebaController : ApiController
    {
        // GET: Prueba

        [System.Web.Http.HttpPost]
        //[System.Web.Http.ActionName("Test")]
        public string Test ( [FromBody]string testString )
        {
            return ("resultado" + testString);

        }

        [System.Web.Http.HttpPost]
        public response PostArticle(UItem item) 
        {
            UItem i = item;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ClassLibrary1.Class1.insertuitem(i.idtransaccion, i.datetime, i.sucursal, i.tipodocumento, i.nrodocumento, i.dnicliente, i.nombrecliente, i.direccioncliente, i.sistemaproveniente, i.cantidad, i.code);
            sw.Stop();
            return new response { Result="MS:" + sw.ElapsedMilliseconds.ToString() };
        }

        [HttpGet]
        public Bill GenerateBill() 
        {
            Bill b = new Bill { datetime = "20190202020202100", dnicliente = null, direccioncliente = null, idtransaccion = "1000", ItemList = new List<Item>(), nombrecliente = null, nrodocumento = "00000", sistemaproveniente = 100, sucursal = 1, tipodocumento = 1 };
            for (int a = 0; a < 100; a++) 
            {
                b.ItemList.Add(new Item { cantidad=2, code="1000"  });
            }
            return b;
        }

        [HttpGet]
        public UItem GenerateItem() 
        {
            return new UItem { cantidad = 2, code = "1000", datetime = "20190202020202100", direccioncliente = null, dnicliente = null, idtransaccion = "1000", nombrecliente = null, nrodocumento = "00000", sistemaproveniente = 100, sucursal = 1, tipodocumento = 1 };
        }

        [System.Web.Http.HttpPost]
        public response PostBill (Bill bill)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ClassLibrary1.Class1.insert_factura(bill.idtransaccion, bill.datetime, bill.sucursal, bill.tipodocumento, bill.nrodocumento, bill.dnicliente, bill.nombrecliente, bill.direccioncliente, bill.sistemaproveniente);
           
            if (bill != null && bill.ItemList!=null && bill.ItemList.Count>0) 
            {
                foreach (Item i in bill.ItemList) 
                {
                    ClassLibrary1.Class1.insert_item(i.cantidad, i.code);

                }
            }
            sw.Stop();
            return new response { Result = "MS:" + sw.ElapsedMilliseconds.ToString() };

        }

    }
}