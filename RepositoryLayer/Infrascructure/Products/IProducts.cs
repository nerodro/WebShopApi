﻿using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Infrascructure.Products
{
    public interface IProducts<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetCompany(long id);
        T Get(long id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
        void RemoveAll(List<T> entity);
    }
}
