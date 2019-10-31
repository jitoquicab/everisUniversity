using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Everis.back.FAQ.core.models.Enum;

namespace Everis.back.FAQ.core.rabbit.Interface
{
    public interface IDLACCrud<T>
    {
        Task<T> get(long id);
        Task<List<T>> getTodas();
        Task<T> set(T objeto, Transaction transaccion);
    }
}
