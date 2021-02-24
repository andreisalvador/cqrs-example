using Cqrs.Example.Core.Data;
using Cqrs.Example.Domain;
using System;

namespace Cqrs.Example.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        public void Add(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Usuario entity)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
