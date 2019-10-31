using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Everis.back.FAQ.core.models.EntityModel
{
    public class FAQs
    {
        [Key]
        public int Id { get; set; }
        public string Pregunta { get; set; }
        [NotMapped][JsonIgnore]
        public List<Respuestas> Respuestas { get; set; }
    }
}
