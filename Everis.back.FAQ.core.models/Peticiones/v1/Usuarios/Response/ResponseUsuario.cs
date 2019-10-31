using System;
using System.Collections.Generic;
using System.Text;

namespace Everis.back.FAQ.core.models.Peticiones.v1.Usuarios.Response
{
    public class ResponseUsuario
    {
        public long idUsuario { get; set; }
        public string nickname { get; set; }
        public string token { get; set; }
    }
}
