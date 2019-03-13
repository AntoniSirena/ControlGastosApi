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
    [RoutePrefix("Api/User")]
    public class UsersController : ApiController
    {
        public MyDBcontext db = new MyDBcontext();


        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Users> GetAll()
        {
            var resul = db.Users.ToList();

            return resul;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IEnumerable<Users> GetById(int? id)
        {
            var result = (from T in db.Users where T.Id == id select T).ToList();

            return result;
        }


        [HttpGet]
        [Route("GetPersonas")]
        public IEnumerable<Personas> GetPersonas()
        {
            var resul = db.Personas.ToList();

            return resul;
        }


        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(Users user)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            db.Users.Add(user);
            db.SaveChanges();

            return resultado;
        }


        [HttpPut]
        [Route("Update")]
        public HttpResponseMessage Update(Users user)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            var query = db.Users.Single(P => P.Id == user.Id);

            query.PersonaId = user.PersonaId;
            query.NombreUsuario = user.NombreUsuario;
            query.Password = user.Password;
            query.Email = user.Email;
            db.SaveChanges();

            return resultado;
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage Delete(int? id)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            db.Users.Remove(db.Users.Single(P => P.Id == id));
            db.SaveChanges();

            return resultado;
        }


    }
}
