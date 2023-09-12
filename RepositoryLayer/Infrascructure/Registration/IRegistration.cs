using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrascructure.Registration
{
    public interface IRegistration<T> where T : BaseEntity
    {
        void Create(T entity);
    }
}
