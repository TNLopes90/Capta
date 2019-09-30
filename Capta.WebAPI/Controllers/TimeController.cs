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
    public class TimeController : ControllerBase
    {
		private readonly IDataContextRepository _repo;
		private readonly IMapper _mapper;

		public TimeController(IDataContextRepository repo, IMapper mapper)
		{
            this._repo = repo;
			this._mapper = mapper;
		}
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var time = await this._repo.GetAllTimes();
                var result = this._mapper.Map<IEnumerable<TimeDTO>>(time);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{timeId}")]
        public async Task<IActionResult> Get(int timeId)
        {
            try
            {
                var time = await this._repo.GetTimeById(timeId, true);
                if(time == null) return NotFound();
                var result = this._mapper.Map<TimeDTO>(time);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,  ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(TimeDTO model)
        {
            try
            {
                var time = this._mapper.Map<Time>(model);
                this._repo.Add(time);
                if(await this._repo.SaveChangesAsync())
                    return Created($"api/time/{model.TimeId}", this._mapper.Map<TimeDTO>(time));
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,  ex.Message);
            }
            return BadRequest();
        }

        [HttpDelete("{timeId}")]
		public async Task<IActionResult> Delete(int timeId)
		{
			try
			{
				var time = await this._repo.GetTimeById(timeId, false);
				if(time == null) return NotFound();

				this._repo.Delete(time);
				if(await this._repo.SaveChangesAsync())
						return Ok();
			}
			catch (Exception ex)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
			return BadRequest();
		}
		
		[HttpPut("{timeId}")]
		public async Task<IActionResult> Put(int timeId, TimeDTO model)
		{
			try
			{
				var time = await this._repo.GetTimeById(timeId, false);
				if(time == null) return NotFound();

                this._mapper.Map(model, time);

				this._repo.Update(time);
				if(await this._repo.SaveChangesAsync())
						return Created($"api/time/{model.TimeId}", this._mapper.Map<TimeDTO>(time));
			}
			catch (Exception ex)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
			return BadRequest();
		}

    }
}