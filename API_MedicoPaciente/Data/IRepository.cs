using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API_MedicoPaciente.Data
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        Task<ActionResult<TEntity>> AddAsync(TEntity entity);

        Task<ActionResult<TEntity>> UpdateAsync(TEntity entity);
        Task<ActionResult<TEntity>> Delete(Guid id);
        Task<ActionResult<TEntity>> GetByIdAsync(Guid id);
    }
}