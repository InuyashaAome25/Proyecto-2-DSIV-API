using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Protecto_2_API_REST_DSIV.Models
{
    public class Calculos
    {
        public int ID { get; set; }
        public string Operacion { get; set; }
        public string Resultado { get; set; }
        public string Operador { get; set; }
        public DateTime Fecha { get; set; }
    }
}