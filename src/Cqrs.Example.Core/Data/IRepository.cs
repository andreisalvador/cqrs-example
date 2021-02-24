using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs.Example.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        TEntity GetById(Guid id);
        void Commit();
    }
}
