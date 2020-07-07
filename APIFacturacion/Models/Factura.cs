using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APIFacturacion.Models
{
    public class Factura
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Nit { get; set; }
        public int ValorTotal { get; set; }
        public int PorcentajeIVA { get; set; }
    }
}