using ControlGastos.DBContext;
using ControlGastos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlGastos.Controllers
{
    [RoutePrefix("Api/ControlGastos")]
    public class TiposConceptosController : ApiController
    {
        public MyDBcontext db = new MyDBcontext();


        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<TiposConceptos> GetAll()
        {
            return db.TiposConceptos.ToList();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IEnumerable<TiposConceptos> GetById(int? id)
        {
            return db.TiposConceptos.Where(P => P.Id == id).ToList();
        }


        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(TiposConceptos tiposConceptos)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            db.TiposConceptos.Add(tiposConceptos);
            db.SaveChanges();

            return resultado;
        }


        [HttpPut]
        [Route("Update")]
        public HttpResponseMessage Update(TiposConceptos tiposConceptos)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            var query = db.TiposConceptos.Single(P => P.Id == tiposConceptos.Id);

            query.Codigo = tiposConceptos.Codigo;
            query.Descripcion = tiposConceptos.Descripcion;
            db.SaveChanges();

            return resultado;
        }



        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage Delete(int? id)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            db.TiposConceptos.Remove(db.TiposConceptos.Single(P => P.Id == id));
            db.SaveChanges();

            return resultado;
        }

    }
}
