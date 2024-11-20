using Protecto_2_API_REST_DSIV.Models;
using Protecto_2_API_REST_DSIV.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Protecto_2_API_REST_DSIV.Controllers
{
    public class CalculosController : ApiController
    {
        // GET api/<controller>
        public List<Calculos> Get()
        {
            CalculosData calculosData = new CalculosData();
            return calculosData.ListarCalculos();
        }

        // GET api/<controller/orden>
        public List<Calculos> GetCalculosDESC()
        {
            CalculosData calculosData = new CalculosData();
            return calculosData.ListarCalculosDESC();
        }

        // Método para obtener una lista de cálculos por operador
        public Calculos GetByOperador(string operador)
        {
            CalculosData calculosData = new CalculosData();
            return calculosData.ObtenerCalculo(operador);
        }

        // Método para obtener un cálculo por ID
        public Calculos GetById(int idCalculo)
        {
            CalculosData calculosData = new CalculosData();
            return calculosData.ObtenerCalculo(idCalculo);
        }


        // POST api/<controller>
        public bool Post([FromBody] Calculos calculos)
        {
            CalculosData calculosData = new CalculosData();
            return calculosData.InsertCalculo(calculos);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Calculos calculos)
        {
            CalculosData calculosData = new CalculosData();
            return calculosData.UpdateCalculo(calculos);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            CalculosData calculosData = new CalculosData();
            return calculosData.DeleteCalculo(id);
        }
    }
}