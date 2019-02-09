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
                          where TT.Codigo == Constante.TiposTransaccion.Gasto  & T.EstaAnulada == false
                         select T ).ToList();

            return resul;
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public IEnumerable<Transacciones> GetById(int? id)
        {
            var result = (from T in db.Transacciones
                          join P in db.Periodos on T.PeriodoId equals P.Id
                          join S in db.Statuses on P.StatusId equals S.Id
                          where T.Id == id & T.EstaAnulada == false
                          where S.Codigo == Constante.Statuses.Abierto
                          select T).ToList();

            return result;
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




        [HttpPut]
        [Route("Anular")]
        public HttpResponseMessage Update(Transacciones transaccion)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            var query = db.Transacciones.Single(P => P.Id == transaccion.Id);

            query.EstaAnulada = true;
            query.FechaAnulacion = DateTime.Now.ToString("yyyy-MM-dd");

            db.SaveChanges();

            return resultado;
        }


    }
}
