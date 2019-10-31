using System.Collections.Generic;
using System.Threading.Tasks;
using Everis.back.FAQ.core.models.Enum;

namespace Everis.back.FAQ.core.kiwi.Interface
{
    public interface IBOCrud<T>
    {
        Task<T> get(long id);
        Task<List<T>> getTodas();
        Task<T> set(T objeto, Transaction transaccion);
    }
}
