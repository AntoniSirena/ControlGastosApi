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
    [RoutePrefix("Api/RazonesAnulacionTransaccion")]
    public class RazonesAnulacionTransaccionController : ApiController
    {
        public MyDBcontext db = new MyDBcontext();


        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<RazonesAnulacionTransaccion> GetAll()
        {
            var resul = db.RazonesAnulacionTransaccion.ToList();

            return resul;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IEnumerable<RazonesAnulacionTransaccion> GetById(int? id)
        {
            var result = (from T in db.RazonesAnulacionTransaccion where T.Id == id select T).ToList();

            return result;
        }



        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(RazonesAnulacionTransaccion razonesAnulacionTransaccion)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            db.RazonesAnulacionTransaccion.Add(razonesAnulacionTransaccion);
            db.SaveChanges();

            return resultado;
        }



        [HttpPut]
        [Route("Update")]
        public HttpResponseMessage Update(RazonesAnulacionTransaccion razonesAnulacionTransaccion)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            var query = db.RazonesAnulacionTransaccion.Single(P => P.Id == razonesAnulacionTransaccion.Id);

            query.Codigo = razonesAnulacionTransaccion.Codigo;
            query.Descripcion = razonesAnulacionTransaccion.Descripcion;
            db.SaveChanges();

            return resultado;
        }



        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage Delete(int? id)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            db.RazonesAnulacionTransaccion.Remove(db.RazonesAnulacionTransaccion.Single(P => P.Id == id));
            db.SaveChanges();

            return resultado;
        }


    }
}
