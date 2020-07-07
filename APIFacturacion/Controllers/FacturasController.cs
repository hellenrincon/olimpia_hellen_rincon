using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using APIFacturacion.Models;

namespace APIFacturacion.Controllers
{
    public class FacturasController : ApiController
    {
        private Context db = new Context();

        // GET: api/Facturas
        public IQueryable<Factura> GetFacturas()
        {
            return db.Facturas;
        }

        // POST: api/Facturas
        [ResponseType(typeof(Factura))]
        public async Task<IHttpActionResult> PostFactura(Factura[] factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Regex regex = new Regex("[^0-9]");

            List<string> ListError = new List<string>();

            foreach (var item in factura)
            {
                if (item.ValorTotal < 0)
                {
                    ListError.Add("El valor debe ser estrictamente positivo");
                }

                if ((item.PorcentajeIVA >= 0 && item.PorcentajeIVA <= 100))
                {
                    ListError.Add("El valor del Iva es un valor entre 0(%) y 100(%)");
                }

            }

            if (ListError.Count > 0)
            {
                return Ok(ListError);
            }
            else
            {
                db.Facturas.AddRange(factura);
                await db.SaveChangesAsync();
                return Ok(factura);
            }

        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacturaExists(int id)
        {
            return db.Facturas.Count(e => e.Id == id) > 0;
        }
    }
}