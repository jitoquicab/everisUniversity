using Everis.back.FAQ.core.models.EntityModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Everis.back.FAQ.core.models.Peticiones.v1.Usuarios.Request
{
    public class RequestRespuesta
    {
        public int Id { get; set; }
        public int FKIdPregunta { get; set; }
        public string Respuesta { get; set; }
        [JsonIgnore]
        [ForeignKey("FKIdPregunta")]
        public FAQs fAQs { get; set; }
    }
}
