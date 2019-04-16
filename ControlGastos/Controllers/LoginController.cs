using ControlGastos.DBContext;
using ControlGastos.Dto;
using ControlGastos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ControlGastos.Controllers
{
    [RoutePrefix("Api/Login")]
    public class LoginController : ApiController
    {

        public MyDBcontext db = new MyDBcontext();


        [HttpPost]
        [Route("Validar")]
        public object Validar(UserDto user)
        {
            var data = new DataDto();

            var validarUser = db.Users.Where(x => x.Password == user.Password && x.Email == user.Email).FirstOrDefault();

            if (validarUser != null)
            {
                data.Resultado = true;
                data.Mensaje = "Bienvenido al Sistema";
            }
            else
            {
                data.Resultado = false;
                data.Mensaje = "Los datos ingresados no son validos";
            }

            return data;
        }

    }
}
