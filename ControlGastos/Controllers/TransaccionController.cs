using ControlGastos.DBContext;
using ControlGastos.Dto;
using ControlGastos.Global;
using ControlGastos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        [Route("GetPeriodos")]
        public IEnumerable<Periodos> GetPeriodos()
        {
            var ano = DateTime.Now.Year;
            var resul = (from p in db.Periodos
                         select p).ToList();

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


        //Metodos para mostrar un listado de transacciones con el concepto y el monto resumido
        [HttpPost]
        [Route("GetResumenIngresos")]
        public List<ResumenTransaccionDto> GetResumenIngresos(FiltroResumenTransacciones filtro)
        {
            var listado = db.Database.SqlQuery<ResumenTransaccionDto>(
                "Exec SP_ResumenIngresos @FechaInicial, @FechaFinal, @ConceptoId, @PeriodoId, @SemanaId, @AreaId",
                new SqlParameter() { ParameterName = "@FechaInicial", SqlDbType = System.Data.SqlDbType.Date, Value = (object)filtro.FechaInicial ?? DBNull.Value },
                new SqlParameter() { ParameterName = "@FechaFinal", SqlDbType = System.Data.SqlDbType.Date, Value = (object)filtro.FechaFinal ?? DBNull.Value },
                new SqlParameter() { ParameterName = "@ConceptoId", SqlDbType = System.Data.SqlDbType.Int, Value = (object)filtro.ConceptoId ?? DBNull.Value },
                new SqlParameter() { ParameterName = "@PeriodoId", SqlDbType = System.Data.SqlDbType.Int, Value = (object)filtro.PeriodoId ?? DBNull.Value },
                new SqlParameter() { ParameterName = "@SemanaId", SqlDbType = System.Data.SqlDbType.Int, Value = (object)filtro.SemanaId ?? DBNull.Value },
                new SqlParameter() { ParameterName = "@AreaId", SqlDbType = System.Data.SqlDbType.Int, Value = (object)filtro.AreaId ?? DBNull.Value });

            return listado.ToList();
        }


        [HttpPost]
        [Route("GetResumenGastos")]
        public List<ResumenTransaccionDto> GetResumenGastos(FiltroResumenTransacciones filtro)
        {
            var listado = db.Database.SqlQuery<ResumenTransaccionDto>(
                 "SP_ResumenGastos @FechaInicial, @FechaFinal, @ConceptoId, @PeriodoId, @SemanaId, @AreaId",
                new SqlParameter() { ParameterName = "@FechaInicial", SqlDbType = System.Data.SqlDbType.Date, Value = (object)filtro.FechaInicial ?? DBNull.Value },
                new SqlParameter() { ParameterName = "@FechaFinal", SqlDbType = System.Data.SqlDbType.Date, Value = (object)filtro.FechaFinal ?? DBNull.Value },
                new SqlParameter() { ParameterName = "@ConceptoId", SqlDbType = System.Data.SqlDbType.Int, Value = (object)filtro.ConceptoId ?? DBNull.Value },
                new SqlParameter() { ParameterName = "@PeriodoId", SqlDbType = System.Data.SqlDbType.Int, Value = (object)filtro.PeriodoId ?? DBNull.Value },
                new SqlParameter() { ParameterName = "@SemanaId", SqlDbType = System.Data.SqlDbType.Int, Value = (object)filtro.SemanaId ?? DBNull.Value },
                new SqlParameter() { ParameterName = "@AreaId", SqlDbType = System.Data.SqlDbType.Int, Value = (object)filtro.AreaId ?? DBNull.Value });

            return listado.ToList();
        }

        [HttpPost]
        [Route("GetEstadoResultado")]
        public List<EstadoResultadoDto> EstadoResultado(FiltroResumenTransacciones filtro)
        {
            var listado = db.Database.SqlQuery<EstadoResultadoDto>(
                "Exec SP_EstadoResultado @FechaInicial, @FechaFinal, @ConceptoId, @PeriodoId, @SemanaId, @AreaId",
                new SqlParameter() { ParameterName = "@FechaInicial", SqlDbType = System.Data.SqlDbType.Date, Value = (object)filtro.FechaInicial ?? DBNull.Value },
                new SqlParameter() { ParameterName = "@FechaFinal", SqlDbType = System.Data.SqlDbType.Date, Value = (object)filtro.FechaFinal ?? DBNull.Value },
                new SqlParameter() { ParameterName = "@ConceptoId", SqlDbType = System.Data.SqlDbType.Int, Value = (object)filtro.ConceptoId ?? DBNull.Value },
                new SqlParameter() { ParameterName = "@PeriodoId", SqlDbType = System.Data.SqlDbType.Int, Value = (object)filtro.PeriodoId ?? DBNull.Value },
                new SqlParameter() { ParameterName = "@SemanaId", SqlDbType = System.Data.SqlDbType.Int, Value = (object)filtro.SemanaId ?? DBNull.Value },
                new SqlParameter() { ParameterName = "@AreaId", SqlDbType = System.Data.SqlDbType.Int, Value = (object)filtro.AreaId ?? DBNull.Value });

            return listado.ToList();
        }

        //Fin de la consulta




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
            transaccion.FechaRegistro = DateTime.Now;
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
            query.FechaAnulacion = DateTime.Now;

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
