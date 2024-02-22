using Microsoft.EntityFrameworkCore;
using WebApi.Application.Interfaces.Repositories;
using WebApi.Application.Interfaces.UnitOfWorks;
using WebApi.Persistence.Repositories;

namespace WebApi.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
        public int save() => _dbContext.SaveChanges();  
        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_dbContext);
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_dbContext);
    }
}
