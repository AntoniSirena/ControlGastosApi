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
    [RoutePrefix("Api/TransaccionBanco")]
    public class TransaccionBancoController : ApiController
    {
        public MyDBcontext db = new MyDBcontext();


        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<banc_TransaccionesBanco> GetAllTransacciones()
        {
            var resul = (from T in db.banc_TransaccionesBancos
                         join TT in db.banc_TipoTransaccionBancos on T.TipoTransaccionId equals TT.Id
                         orderby T.Id descending
                         where T.EstaActiva == true
                         select T).ToList();

            return resul;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IEnumerable<banc_TransaccionesBanco> GetById(int? id)
        {
            var result = (from T in db.banc_TransaccionesBancos
                          where T.Id == id && T.EstaActiva == true
                          select T).ToList();

            return result;
        }


        [HttpGet]
        [Route("GetTioposTransaccion")]
        public IEnumerable<banc_TipoTransaccionBanco> GetTioposTransaccion()
        {
            var resul = db.banc_TipoTransaccionBancos.ToList();

            return resul;
        }


        [HttpGet]
        [Route("GetBanco")]
        public IEnumerable<banc_Banco> GetBanco()
        {
            var resul = db.banc_Bancos.ToList();

            return resul;
        }

        [HttpGet]
        [Route("GetCuenta/{BancoId}")]
        public IEnumerable<banc_Cuenta> GetCuenta(int? bancoId)
        {
            var resul = (from C in db.banc_Cuentas
                         where C.BancoId == bancoId
                         select C).ToList();

            return resul;
        }

        [HttpGet]
        [Route("GetRazonesAjuste")]
        public IEnumerable<banc_RazonAjuste> GetRazonesAjuste()
        {
            var resul = db.banc_RazonAjustes.ToList();

            return resul;
        }


        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(banc_TransaccionesBanco transaccion)
        {
            var resultado = new HttpResponseMessage(HttpStatusCode.OK);

            var estado = (from s in db.Statuses
                          where s.Codigo == Global.Constante.Statuses.Activa
                          select s).FirstOrDefault();

            var tipoTransaccion = (from T in db.banc_TipoTransaccionBancos
                                   where T.Id == transaccion.TipoTransaccionId
                          select T ).FirstOrDefault();

            //Deposito
            if (tipoTransaccion.Codigo == Global.Constante.TipoTransaccionBanco.Deposito)
            {
                var cuentaOrigen = (from b in db.banc_BalanceCuentas
                                     where b.CuentaId == transaccion.CuentaOrigenId
                                     select b).FirstOrDefault();

                cuentaOrigen.Balance += transaccion.Monto;
                db.SaveChanges();

                transaccion.Origen = "Deposito";                
            }

            //Retiro
            if (tipoTransaccion.Codigo == Global.Constante.TipoTransaccionBanco.Retiro)
            {
                var cuentaOrigen = (from b in db.banc_BalanceCuentas
                                    where b.CuentaId == transaccion.CuentaOrigenId
                                    select b).FirstOrDefault();

                cuentaOrigen.Balance -= transaccion.Monto;
                db.SaveChanges();

                transaccion.Origen = "Retiro";
            }


            //Transferencia
            if (tipoTransaccion.Codigo == Global.Constante.TipoTransaccionBanco.Transferencia)
            {
                var cuentaOrigen = (from b in db.banc_BalanceCuentas
                                    where b.CuentaId == transaccion.CuentaOrigenId
                                    select b).FirstOrDefault();

                var cuentaDestino = (from b in db.banc_BalanceCuentas
                                    where b.CuentaId == transaccion.CuentaDestinoId
                                    select b).FirstOrDefault();

                cuentaOrigen.Balance -= transaccion.Monto;
                cuentaDestino.Balance += transaccion.Monto;
                db.SaveChanges();

                transaccion.Origen = "Transferencia";
            }


            //Ajuste
            if (tipoTransaccion.Codigo == Global.Constante.TipoTransaccionBanco.Ajuste)
            {
                var cuentaOrigen = (from b in db.banc_BalanceCuentas
                                    where b.CuentaId == transaccion.CuentaOrigenId
                                    select b).FirstOrDefault();

                cuentaOrigen.Balance += transaccion.Monto;
                db.SaveChanges();

                transaccion.Origen = "Ajuste";
            }


            transaccion.FechaRegistro = DateTime.Now;
            transaccion.EstadoId = estado.Id;
            transaccion.EstaActiva = true;
            db.banc_TransaccionesBancos.Add(transaccion);
            db.SaveChanges();

            transaccion.NumeroTrans = transaccion.TipoTransaccionBanco.Codigo + "-" + Secuencia(tipoTransaccion.Codigo).ToString();
            transaccion.Sequencia = Secuencia(tipoTransaccion.Codigo);
            db.SaveChanges();

            return resultado;
        }


        //Metodo para crear la secuencia actual de la transaccion
        public int Secuencia(string TipoTransaccion)
        {
            var transaccion = (from T in db.banc_TransaccionesBancos
                               join TT in db.banc_TipoTransaccionBancos on T.TipoTransaccionId equals TT.Id
                               where TT.Codigo == TipoTransaccion
                               orderby T.Sequencia descending
                               select T).FirstOrDefault();

            return transaccion.Sequencia + 1;
        }

    }
}
