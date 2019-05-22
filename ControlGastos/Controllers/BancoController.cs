using ControlGastos.DBContext;
using ControlGastos.Models.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlGastos.Controllers
{
    [RoutePrefix("Api/Banco")]
    public class BancoController : ApiController
    {
        public MyDBcontext db = new MyDBcontext();


        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<banc_Banco> GetAll()
        {
            var resul = db.banc_Bancos.ToList();

            return resul;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IEnumerable<banc_Banco> GetById(int? id)
        {
            var result = (from b in db.banc_Bancos where b.Id == id select b).ToList();

            return result;
        }

        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(banc_Banco banco)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            db.banc_Bancos.Add(banco);
            db.SaveChanges();

            return resultado;
        }


        [HttpPut]
        [Route("Update")]
        public HttpResponseMessage Update(banc_Banco banco)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            var query = db.banc_Bancos.Single(P => P.Id == banco.Id);

            query.Codigo = banco.Codigo;
            query.Sigla = banco.Sigla;
            query.Nombre = banco.Nombre;
            db.SaveChanges();

            return resultado;
        }



        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage Delete(int? id)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            db.banc_Bancos.Remove(db.banc_Bancos.Single(P => P.Id == id));
            db.SaveChanges();

            return resultado;
        }


    }
}
