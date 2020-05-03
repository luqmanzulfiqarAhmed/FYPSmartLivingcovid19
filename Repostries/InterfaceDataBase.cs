using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartLiving.Repostries
{
    public interface InterfaceDataBase
    {

        Task<object> insert(object obj);
        Task<object> update(string id, object obj);
        Task<object> delete(string id);
        Task<object> retrieveAll(string Id);
        Task<object> retrieve(string id);

    }
}
