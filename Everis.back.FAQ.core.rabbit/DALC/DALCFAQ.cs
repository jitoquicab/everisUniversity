using Everis.back.FAQ.core.models.EntityModel;
using Everis.back.FAQ.core.models.Enum;
using Everis.back.FAQ.core.rabbit.Context;
using Everis.back.FAQ.core.rabbit.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everis.back.FAQ.core.rabbit.DALC
{
    public class DALCFAQ: IDLACCrud<FAQs>
    {
        private readonly FAQContext _context;

        private readonly DLACTransacciones<FAQs> _DLACTransaccion;

        public DALCFAQ(FAQContext context)
        {
            this._context = context;
            _DLACTransaccion = new DLACTransacciones<FAQs>(context);
        }

        public async Task<FAQs> get(long id)
        {
            return await _context.FAQs.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        
        public async Task<List<FAQs>> getTodas()
        {
            return await _context.FAQs.ToListAsync();
        }

        public async Task<FAQs> set(FAQs objeto, Transaction transaccion)
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
