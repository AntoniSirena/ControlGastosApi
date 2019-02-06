using ControlGastos.DBContext;
using ControlGastos.Dto;
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
    [RoutePrefix("Api/Periodo")]
    public class PeriodoController : ApiController
    {
        public MyDBcontext db = new MyDBcontext();



        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Periodos> GetAll()
        {
            var resul = db.Periodos.ToList();

            return resul;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IEnumerable<Periodos> GetById(int? id)
        {
            var result = (from T in db.Periodos where T.Id == id select T).ToList();

            return result;
        }



        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(Periodos periodo)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);


            var StatuPendienteAbrirId = (from S in db.Statuses
                               where S.Codigo == Constante.Statuses.PendienteAbrir
                               select S.Id).FirstOrDefault();

            periodo.EstaActivo = false;
            periodo.StatusId = StatuPendienteAbrirId;

           
            db.Periodos.Add(periodo);
            db.SaveChanges();

            return resultado;
        }


        [HttpPut]
        [Route("Update")]
        public HttpResponseMessage Update(Periodos periodos)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            var query = db.Periodos.Single(P => P.Id == periodos.Id);

            query.Codigo = periodos.Codigo;
            query.Descripcion = periodos.Descripcion;
            query.FechaApertura = periodos.FechaApertura;
            query.FechaCierre = periodos.FechaCierre;
            db.SaveChanges();

            return resultado;
        }



        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage Delete(int? id)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            db.Periodos.Remove(db.Periodos.Single(P => P.Id == id));
            db.SaveChanges();

            return resultado;
        }


    }

}
