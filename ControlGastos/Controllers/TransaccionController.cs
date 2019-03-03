using ControlGastos.DBContext;
using ControlGastos.Global;
using ControlGastos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ControlGastos.Controllers
{
    [RoutePrefix("Api/Transaccion")]
    public class TransaccionController : ApiController
    {
        public MyDBcontext db = new MyDBcontext();



        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Transacciones> GetAllTransacciones()
        {
            var resul = (from T in db.Transacciones
                          join TT in db.TiposTrasacciones on T.TipoTransacionId equals TT.Id
                          where T.EstaAnulada == false
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

        [HttpGet]
        [Route("GetRazonesAnulacion")]
        public IEnumerable<RazonesAnulacionTransaccion> GetRazonesAnulacion()
        {
            var resul = db.RazonesAnulacionTransaccion.ToList();

            return resul;
        }


        //Metodo que retorna un resumen de las transacciones por Periodo y Conceptos
        [HttpGet]
        [Route("GetResumemTransacciones")]
        public IEnumerable<Transacciones> GetResumemTransacciones()
        {

            var resul = db.Transacciones.ToList();

            //var querryTransacion = (from Trans in db.Transacciones
            //                         join Per in db.Periodos on Trans.PeriodoId equals Per.Id
            //                         join sem in db.Semanas on Trans.SemanaId equals sem.Id
            //                         join TipTrans in db.TiposTrasacciones on Trans.TipoTransacionId equals TipTrans.Id

            //                         select (new
            //                         {
            //                             TipoTransaccion = TipTrans.Descripcion,
            //                             Periodo = Per.Descripcion,
            //                             Semana = sem.Descripcion,
            //                             TotalMonto = Trans.Monto
            //                         })).ToList();


            //var resumenTransaccion = from r in querryTransacion
            //                         group r.TipoTransaccion by new {
            //                             r.TipoTransaccion,
            //                             r.Periodo,
            //                             r.Semana
            //                         } into tipoTransaccion
            //                         select new
            //                         {
            //                             tipoTransaccion.Key.TipoTransaccion,
            //                             tipoTransaccion.Key.Periodo,
            //                             tipoTransaccion.Key.Semana
            //                         };


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


            var tipoTransaccionGastoId = (from T in db.TiposTrasacciones
                                         where T.Codigo == Constante.TiposTransaccion.Gasto
                                         select T.Id).FirstOrDefault();

            var tipoTransaccionIngresoId = (from T in db.TiposTrasacciones
                                          where T.Codigo == Constante.TiposTransaccion.Ingeso
                                          select T.Id).FirstOrDefault();


            if( transaccion.Origen == "Gasto")
            {
                transaccion.TipoTransacionId = tipoTransaccionGastoId;
            }

            if(transaccion.Origen == "Ingreso")
            {
                transaccion.TipoTransacionId = tipoTransaccionIngresoId;
            }

            transaccion.PeriodoId = periodoActivoId;
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
            query.RazonAnulacionId = transaccion.RazonAnulacionId;
            query.FechaAnulacion = DateTime.Now.ToString("yyyy-MM-dd");

            db.SaveChanges();

            return resultado;
        }


        [HttpGet]
        [Route("HistorialTransaccionAnulada")]
        public IEnumerable<Transacciones> GetTransaccionAnulada()
        {
            var resul = db.Transacciones.Where(P => P.EstaAnulada == true).ToList();

            return resul;
        }

    }
}
