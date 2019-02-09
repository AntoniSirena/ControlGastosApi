using ControlGastos.DBContext;
using ControlGastos.Global;
using ControlGastos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlGastos.Controllers
{
    [RoutePrefix("Api/Transaccion")]
    public class TransaccionController : ApiController
    {
        public MyDBcontext db = new MyDBcontext();



        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Transacciones> GetAll()
        {
            var resul = (from T in db.Transacciones
                          join TT in db.TiposTrasacciones on T.TipoTransacionId equals TT.Id
                          where TT.Codigo == Constante.TiposTransaccion.Gasto
                          select T ).ToList();

            return resul;
        }


        [HttpGet]
        [Route("GetTioposConceptos")]
        public IEnumerable<TiposConceptos> GetTiposConceptos()
        {
            var resul = db.TiposConceptos.ToList();

            return resul;
        }



        [HttpGet]
        [Route("GetSemanas")]
        public IEnumerable<Semanas> GetSemanas()
        {
            var resul = db.Semanas.ToList();

            return resul;
        }


        [HttpGet]
        [Route("GetAreas")]
        public IEnumerable<Area> GetAreas()
        {
            var resul = db.Areas.ToList();

            return resul;
        }



        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(Transacciones transaccion)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            var periodoActivoId = (from P in db.Periodos
                                   join S in db.Statuses on P.StatusId equals S.Id
                                   where S.Codigo == Constante.Statuses.Abierto & P.EstaActivo == true
                                   select P.Id).FirstOrDefault();


            var tipoTransaccionId = (from T in db.TiposTrasacciones
                                         where T.Codigo == Constante.TiposTransaccion.Gasto
                                         select T.Id).FirstOrDefault();


            transaccion.PeriodoId = periodoActivoId;
            transaccion.TipoTransacionId = tipoTransaccionId;
            transaccion.FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd");
            transaccion.EstaAnulada = false;

            db.Transacciones.Add(transaccion);
            db.SaveChanges();

            return resultado;
        }


        //[HttpPut]
        //[Route("Anular")]
        //public HttpResponseMessage Update(int? int)
        //{
        //    var resultado = new HttpResponseMessage(HttpStatusCode.OK);

        //    var query = db.Personas.Single(P => P.Id == persona.Id);

        //    db.SaveChanges();

        //    return resultado;
        //}


    }
}
