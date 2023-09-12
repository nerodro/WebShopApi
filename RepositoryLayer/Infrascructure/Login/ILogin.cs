using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrascructure.Login
{
    public interface ILogin<T> where T : BaseEntity
    {
        T Get(long id);
    }
}
