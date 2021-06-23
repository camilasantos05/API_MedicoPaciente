using API_MedicoPaciente.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API_MedicoPaciente.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity>
        where TEntity : class, new()
    {
        private readonly IRepository<TEntity> _repository;

        public ServiceBase(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<ActionResult<TEntity>> AddAsync(TEntity entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<ActionResult<TEntity>> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        public async Task<ActionResult<TEntity>> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<ActionResult<TEntity>> UpdateAsync(TEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
