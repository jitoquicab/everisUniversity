using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Everis.back.FAQ.core.models.Peticiones.v1.Usuarios.Request
{
    public class RequestFAQs
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }

    }
}
