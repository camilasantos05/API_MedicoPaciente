using API_MedicoPaciente.Data;
using API_MedicoPaciente.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MedicoPaciente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity> : ControllerBase
        where TEntity : class, new()
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public BaseController(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }


        //GET: api/[controller]
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("GetAll")]
        public virtual IQueryable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("api/[controller]/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TEntity>> GetByIdAsync(Guid id)
        {
            var entidade = await _serviceBase.GetByIdAsync(id);
            if (entidade == null)
            {
                return NotFound();
            }
            return entidade;
        }

        // PUT: api/[controller]/5
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("UpdateAsync")]
        public async Task<ActionResult<TEntity>> UpdateAsync(TEntity entidade)
        {
            return await _serviceBase.UpdateAsync(entidade);
        }

        // POST: api/[controller]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("AddAsync")]
        public async Task<ActionResult<TEntity>> AddAsync(TEntity entidade)
        {
            await _serviceBase.AddAsync(entidade);
            return CreatedAtAction("Get", new { entidade });
        }

        //// DELETE: api/[controller]/5
        [HttpDelete("api/[controller]/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TEntity>> Delete(Guid id)
        {
            var entidade = await _serviceBase.Delete(id);
            if (entidade == null)
            {
                return NotFound();
            }
            return entidade;
        }

    }
}