using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Everis.back.FAQ.core.models.EntityModel
{
    public class Respuestas
    {
        [Key]
        public int Id { get; set; }
        public int FKIdPregunta { get; set; }
        public string Respuesta { get; set; }
        [ForeignKey("FKIdPregunta")]
        public FAQs fAQs { get; set; }
    }
}
