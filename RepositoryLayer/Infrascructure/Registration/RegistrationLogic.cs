using DomainLayer;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrascructure.Registration
{
    public class RegistrationLogic<T> : IRegistration<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public RegistrationLogic(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
       

        public void Create(T entity)
        {
        
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }
    }
}
