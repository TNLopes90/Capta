using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Capta.Domain;
using Capta.Repository;
using Capta.WebAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capta.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabilidadeController : ControllerBase
    {
        private readonly IDataContextRepository _repo;
		private readonly IMapper _mapper;

		public HabilidadeController(IDataContextRepository repo, IMapper mapper)
		{
            this._repo = repo;
			this._mapper = mapper;
		}
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var habilidade = await this._repo.GetAllHabilidades();
                var result = this._mapper.Map<IEnumerable<HabilidadeDTO>>(habilidade);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        

        [HttpPost]
        public async Task<IActionResult> Post(HabilidadeDTO model)
        {
            try
            {
                var habilidade = this._mapper.Map<Habilidade>(model);
                this._repo.Add(habilidade);
                if(await this._repo.SaveChangesAsync())
                    return Ok(this._mapper.Map<HabilidadeDTO>(habilidade));
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,  ex.Message);
            }
            return BadRequest();
        }

        [HttpDelete("{habilidadeId}")]
		public async Task<IActionResult> Delete(int HabilidadeId)
		{
			try
			{
				var habilidade = await this._repo.GetHabilidadeById(HabilidadeId);
				if(habilidade == null) return NotFound();

				this._repo.Delete(habilidade);
				if(await this._repo.SaveChangesAsync())
                    return Ok();
			}
			catch (Exception ex)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
			return BadRequest();
		}
		
		[HttpPut("{habilidadeId}")]
		public async Task<IActionResult> Put(int habilidadeId, HabilidadeDTO model)
		{
			try
			{
				var habilidade = await this._repo.GetHabilidadeById(habilidadeId);
				if(habilidade == null) return NotFound();

                this._mapper.Map(model, habilidade);

				this._repo.Update(habilidade);
				if(await this._repo.SaveChangesAsync())
                    return Ok(this._mapper.Map<HabilidadeDTO>(habilidade));
			}
			catch (Exception ex)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
			return BadRequest();
		}
    }
}