using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Everis.back.FAQ.core.models.Peticiones.v1.Base;
using Everis.back.FAQ.core.rabbit.Context;

namespace Everis.back.FAQ.core.rabbit.DALC
{
    public class DLACTransacciones<T>
    {
        private readonly FAQContext _context;

        public DLACTransacciones(FAQContext context)
        {
            this._context = context;
        }
        public async Task<T> Actualizar(T objeto)
        {
            _ = _context.Update(objeto);
            _ = _context.SaveChanges();
            return objeto;
        }

        public async Task<T> Crear(T objeto)
        {
            _ = _context.Add(objeto);
            _ = _context.SaveChanges();
            return objeto;
        }

    }
}
