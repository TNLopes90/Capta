using System;
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
	public class JogadorController : ControllerBase
	{
		private readonly IDataContextRepository _repo;
		private readonly IMapper _mapper;

		public JogadorController(IDataContextRepository repo, IMapper mapper)
		{
			this._repo = repo;
			this._mapper = mapper;
		}
        
		[HttpPost]
		public async Task<IActionResult> Post(JogadorDTO model)
    {
			try
			{
				
				var jogador = this._mapper.Map<Jogador>(model);
				this._repo.Add(jogador);
				if(await this._repo.SaveChangesAsync())
						return Created($"api/jogador/{model.JogadorId}", this._mapper.Map<JogadorDTO>(jogador));
			}
			catch (Exception ex)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
			return BadRequest();
		}

		[HttpDelete("{jogadorId}")]
		public async Task<IActionResult> Delete(int jogadorId)
		{
			try
			{
				var jogador = await this._repo.GetJogadorById(jogadorId, false);
				if(jogador == null) return NotFound();

				this._repo.Delete(jogador);
				if(await this._repo.SaveChangesAsync())
						return Ok();
			}
			catch (Exception ex)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
			return BadRequest();
		}
		
		[HttpPut("{jogadorId}")]
		public async Task<IActionResult> Put(int jogadorId, JogadorDTO model)
		{
			try
			{
				var jogador = await this._repo.GetJogadorById(jogadorId, false);
				if(jogador == null) return NotFound();

				this._mapper.Map(model, jogador);

				this._repo.Update(jogador);
				if(await this._repo.SaveChangesAsync())
						return Created($"api/jogador/{model.JogadorId}", this._mapper.Map<JogadorDTO>(jogador));
			}
			catch (Exception ex)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
			return BadRequest();
		}
	}
}