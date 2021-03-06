﻿using ControlGastos.DBContext;
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
    [RoutePrefix("Api/ControlGastos")]
    public class TiposConceptosController : ApiController
    {
        public MyDBcontext db = new MyDBcontext();


        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<TiposConceptos> GetAll()
        {
            var resul = db.TiposConceptos.ToList() ;

            return resul;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IEnumerable<TiposConceptos> GetById(int? id)
        {
            var result =(from T in db.TiposConceptos where T.Id == id select T).ToList();

            return result;
        }


        [HttpGet]
        [Route("GetTiposGastos")]
        public IEnumerable<TiposGastos> GetTiposGastos()
        {
            var resultado = db.TiposGastos.ToList();

            return resultado;
        }

        [HttpGet]
        [Route("GetTiposIngresos")]
        public IEnumerable<TiposIngresos> GetTiposIngresos()
        {
            var resultado = db.TiposIngresos.ToList();

            return resultado;
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

            if(tiposConceptos.Origen == Constante.OrigenTipoConcepto.Gasto)
            {
                query.TipoGastoId = tiposConceptos.TipoGastoId;
            }
            else
            {
                query.TipoIngresoId = tiposConceptos.TipoIngresoId;
            }
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
