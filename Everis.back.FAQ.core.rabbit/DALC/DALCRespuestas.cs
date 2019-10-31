using Everis.back.FAQ.core.models.EntityModel;
using Everis.back.FAQ.core.models.Enum;
using Everis.back.FAQ.core.rabbit.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Everis.back.FAQ.core.rabbit.DALC
{
    public class DALCRespuestas<Respuesta>
    {
        private readonly FAQContext _context;

        private readonly DLACTransacciones<Respuestas> _DLACTransaccion;

        public DALCRespuestas(FAQContext context)
        {
            this._context = context;
            _DLACTransaccion = new DLACTransacciones<Respuestas>(context);
        }

        public async Task<Respuestas> get(long id)
        {
            var resp= await _context.Respuestas.Where(x => x.Id == id).Include(r=>r.fAQs).FirstOrDefaultAsync();
            return resp;
        }


        public async Task<List<Respuestas>> getTodas()
        {
            return await _context.Respuestas.Include(r => r.fAQs).ToListAsync();
        }

        public async Task<Respuestas> set(Respuestas objeto, Transaction transaccion)
        {
            switch (transaccion)
            {
                case Transaction.Insert:
                    return await _DLACTransaccion.Crear(objeto);
                case Transaction.Update:
                    return await _DLACTransaccion.Actualizar(objeto);
                default:
                    return objeto;
            }
        }
    }
}
