using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Everis.back.FAQ.core.rabbit.Interface
{
    public interface IDLACEscritura<T>
    {
        Task<T> get(long id);
        Task<List<T>> getTodas();
    }
}
