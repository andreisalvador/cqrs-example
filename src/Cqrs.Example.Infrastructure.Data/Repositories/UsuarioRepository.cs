using Cqrs.Example.Core.Data;
using Cqrs.Example.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cqrs.Example.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private readonly CqrsExampleContext _cqrsExampleContext;
        public UsuarioRepository(CqrsExampleContext cqrsExampleContext)
        {
            _cqrsExampleContext = cqrsExampleContext;
        }

        public void Add(Usuario entity)
            => _cqrsExampleContext.Usuarios.Add(entity);

        public async Task<bool> Commit()
            => await _cqrsExampleContext.SaveChangesAsync() > 0;

        public async Task<Usuario> GetById(Guid id)
            => await _cqrsExampleContext.Usuarios.SingleOrDefaultAsync(u => u.Id == id);

        public void Remove(Usuario entity)
            => _cqrsExampleContext.Usuarios.Remove(entity);

        public async Task<IEnumerable<Usuario>> GetWhere(Expression<Func<Usuario, bool>> predicate)
            => await _cqrsExampleContext.Usuarios.Where(predicate).ToListAsync();

        public void Dispose()
        {
            _cqrsExampleContext?.Dispose();
        }

    }
}
