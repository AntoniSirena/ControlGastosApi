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
    [RoutePrefix("Api/Cuenta")]
    public class CuentaController : ApiController
    {
        public MyDBcontext db = new MyDBcontext();

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<banc_Cuenta> GetAll()
        {
            var resul = db.banc_Cuentas.ToList();

            return resul;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IEnumerable<banc_Cuenta> GetById(int? id)
        {
            var result = (from T in db.banc_Cuentas where T.Id == id select T).ToList();

            return result;
        }


        [HttpGet]
        [Route("GetTipoCuenta")]
        public IEnumerable<banc_TipoCuenta> GetTipoCuenta()
        {
            var resul = db.banc_TipoCuentas.ToList();

            return resul;
        }

        [HttpGet]
        [Route("GetBanco")]
        public IEnumerable<banc_Banco> GetBanco()
        {
            var resul = db.banc_Bancos.ToList();

            return resul;
        }


        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(banc_Cuenta cuenta)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            var estado = (from s in db.Statuses
                         where s.Codigo == Global.Constante.Statuses.Activa
                         select s).FirstOrDefault();

            cuenta.EstadoId = estado.Id;
            db.banc_Cuentas.Add(cuenta);
            db.SaveChanges();

            //Bloque para registrar el balance en cero de la cuenta al momento de ser creada

            var balance = new banc_BalanceCuenta();

            balance.CuentaId = cuenta.Id;
            balance.Balance = 0;
            db.banc_BalanceCuentas.Add(balance);
            db.SaveChanges();

            return resultado;
        }


        [HttpPut]
        [Route("Update")]
        public HttpResponseMessage Update(banc_Cuenta cuenta)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            var query = db.banc_Cuentas.Single(P => P.Id == cuenta.Id);

            query.NumeroCuenta = cuenta.NumeroCuenta;
            query.TipoCuentaId = cuenta.TipoCuentaId;
            query.BancoId = cuenta.BancoId;
            db.SaveChanges();

            return resultado;
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage Delete(int? id)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            db.banc_Cuentas.Remove(db.banc_Cuentas.Single(P => P.Id == id));
            db.SaveChanges();

            return resultado;
        }

    }
}
