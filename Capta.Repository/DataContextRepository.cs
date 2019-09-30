using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capta.Domain;
using Microsoft.EntityFrameworkCore;

namespace Capta.Repository
{
	public class DataContextRepository : IDataContextRepository
	{
		public DataContext _dataContext { get; }
		public DataContextRepository(DataContext dataContext)
		{
			this._dataContext = dataContext;
			this._dataContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		public void Add<T>(T entity) where T : class
		{
			this._dataContext.Add(entity);
		}

		public void Update<T>(T entity) where T : class
		{
			this._dataContext.Update(entity);
		}

		public void Delete<T>(T entity) where T : class
		{
			this._dataContext.Remove(entity);
		}

		public async Task<bool> SaveChangesAsync()
		{
			return (await this._dataContext.SaveChangesAsync()) > 0;
		}

		public async Task<Jogador> GetJogadorById(int jogadorId, bool incluirHabilidades)
		{
			IQueryable<Jogador> query = this._dataContext.Jogadores;

			if(incluirHabilidades){
				query = query
					.Include(j => j.JogadorHabilidades)
					.ThenInclude(jh => jh.Habilidade);
			}
			
			query = query.Where(j => j.JogadorId == jogadorId);
			return await query.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Time>> GetAllTimes()
		{
			IQueryable<Time> query = this._dataContext.Times;
			return await query.ToArrayAsync();
		}
		public async Task<Time> GetTimeById(int timeId, bool incluirInformacoesJogadores)
		{
			IQueryable<Time> query = this._dataContext.Times;
			if(incluirInformacoesJogadores)
			{
				query = query
					.Include(t => t.Jogadores)
					.ThenInclude(j => j.JogadorHabilidades)
					.ThenInclude(jh => jh.Habilidade);
			}

			query = query.Where(t => t.TimeId == timeId);
			return await query.FirstOrDefaultAsync();
		}

		public async Task<Habilidade> GetHabilidadeById(int habilidadeId)
		{
			IQueryable<Habilidade> query = this._dataContext.Habilidades
				.Where(h => h.HabilidadeId == habilidadeId);
			return await query.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Habilidade>> GetAllHabilidades()
		{
			IQueryable<Habilidade> query = this._dataContext.Habilidades;
			return await query.ToArrayAsync();
		}

	}
}