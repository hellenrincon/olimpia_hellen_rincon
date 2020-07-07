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
    public class CaluladoraController : ApiController
    {


        // POST: api/Numeros
        [ResponseType(typeof(Array))]
        public async Task<IHttpActionResult> PostNumeros(int[] numero)
        {
            List<string> ListNumero = new List<string>();

            foreach (var item in numero)
            {
                int multiplo = 3;
                int result = item % 3;
                if (result.Equals(0))
                {
                    ListNumero.Add(item.ToString() + " SI");
                }
                else
                {
                    ListNumero.Add(item.ToString() + " NO");
                }
               
            }
            return Ok(ListNumero);
        }
    }
}
