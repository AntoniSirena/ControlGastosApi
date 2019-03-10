using ControlGastos.DBContext;
using ControlGastos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ControlGastos.Controllers
{
    [RoutePrefix("Api/Area")]
    public class AreaController : ApiController
    {

        public MyDBcontext db = new MyDBcontext();



        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Area> GetAll()
        {
            var resul = db.Areas.ToList();

            return resul;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IEnumerable<Area> GetById(int? id)
        {
            var result = (from T in db.Areas where T.Id == id select T).ToList();

            return result;
        }


        [HttpGet]
        [Route("GetPersona")]
        public IEnumerable<Persona> GetPersona()
        {
            var resul = db.Personas.ToList();

            return resul;
        }



        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(Area area)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            db.Areas.Add(area);
            db.SaveChanges();

            return resultado;
        }


        [HttpPut]
        [Route("Update")]
        public HttpResponseMessage Update(Area area)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            var query = db.Areas.Single(P => P.Id == area.Id);

            query.Codigo = area.Codigo;
            query.Descripcion = area.Descripcion;
            query.PersonaId = area.PersonaId;
            db.SaveChanges();

            return resultado;
        }



        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage Delete(int? id)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            db.Areas.Remove(db.Areas.Single(P => P.Id == id));
            db.SaveChanges();

            return resultado;
        }

    }
}
