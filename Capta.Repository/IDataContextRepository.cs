using System.Collections.Generic;
using System.Threading.Tasks;
using Capta.Domain;

namespace Capta.Repository
{
    public interface IDataContextRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Jogador> GetJogadorById(int jogadorId, bool incluirHabilidades);

        Task<IEnumerable<Time>> GetAllTimes();
        Task<Time> GetTimeById(int timeId, bool incluirInformacoesJogadores);

        Task<Habilidade> GetHabilidadeById(int habilidadeId);
        Task<IEnumerable<Habilidade>> GetAllHabilidades();
    }
}