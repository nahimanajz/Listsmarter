﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;

namespace CSharp_intro_1.Repositories
{
    public interface IRepository<T> 
    {
        List<T> GetAll();
        T GetById(Guid id); 
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
        void UpdateByStatus(int currentStatus, int newStatus);
    }
}
