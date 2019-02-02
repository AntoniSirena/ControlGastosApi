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
    [RoutePrefix("Api/Persona")]
    public class PersonaController : ApiController
    {
        public MyDBcontext db = new MyDBcontext();


        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Persona> GetAll()
        {
            var resul = db.Personas.ToList();

            return resul;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IEnumerable<Persona> GetById(int? id)
        {
            var result = (from P in db.Personas where P.Id == id select P).ToList();

            return result;
        }



        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(Persona persona)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            db.Personas.Add(persona);
            db.SaveChanges();

            return resultado;
        }


        [HttpPut]
        [Route("Update")]
        public HttpResponseMessage Update(Persona persona)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            var query = db.Personas.Single(P => P.Id == persona.Id);

            query.PrimerNombre = persona.PrimerNombre;
            query.SegundoNombre = persona.SegundoNombre;
            query.PrimerApellido = persona.PrimerApellido;
            query.SegundoApellido = persona.SegundoApellido;
            query.FechaNacimiento = persona.FechaNacimiento;
            query.Telefono = persona.Telefono;
            query.Direccion = persona.Direccion;
            db.SaveChanges();

            return resultado;
        }



        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage Delete(int? id)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            db.Personas.Remove(db.Personas.Single(P => P.Id == id));
            db.SaveChanges();

            return resultado;
        }

    }
}
