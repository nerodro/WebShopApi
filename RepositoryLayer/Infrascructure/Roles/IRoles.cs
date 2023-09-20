using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrascructure.Roles
{
    public interface IRoles<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetUsersForRole(long id);
        T Get(long id);
    }
}
