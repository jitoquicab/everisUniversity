using System;
using System.Collections.Generic;
using System.Text;

namespace Everis.back.FAQ.core.models.Peticiones.v1.Base
{
    public class ResponseBase<T>
    {
        public int codigo { get; set; } = 200;
        public string mensaje { get; set; } = string.Empty;
        public bool estado { get; set; } = true;
        public T datos { get; set; }
    }
}
