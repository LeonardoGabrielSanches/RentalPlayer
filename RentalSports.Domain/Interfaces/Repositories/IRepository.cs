using RentalSports.Domain.Entities;
using System;
using System.Collections.Generic;

namespace RentalSports.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
        TEntity Save(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
