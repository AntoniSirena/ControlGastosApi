﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlGastos.Models.Banco
{
    public class banc_Banco
    {
        [Key]
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Sigla { get; set; }

        public string Nombre { get; set; }

    }
}