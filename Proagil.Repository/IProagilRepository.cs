using System.Threading.Tasks;
using Proagil.Domain;

namespace Proagil.Repository
{
    public interface IProagilRepository
    {
        //GERAL
         void Add<T>(T entity) where T: class; 
         void Update<T>(T entity) where T: class; 
         void Delete<T>(T entity) where T: class; 

         Task<bool> SaveChangesAsync();

         //EVENTOS
        // retorna tds os eventos
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
        // retorna tds os eventos, filtrando o tema
         Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes);
        // retorna tds os eventos, filtrando o Id
         Task<Evento> GetAllEventoAsyncById(int EventoId, bool includePalestrantes);


         //PALESTRANTE
        // retorna um palestrante em expecifico (pelo id)
         Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includeEventos);

        // retorna tds os palestrantes, filtrando pelo nome
         Task<Palestrante[]> GetAllPalestranteAsyncByName(string name, bool includeEventos);
        
         
    }
}