using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proagil.Domain;

namespace Proagil.Repository
{
    public class ProagilRepository : IProagilRepository
    {
        public readonly ProagilContext _context;

        public ProagilRepository(ProagilContext context)
        {
            _context = context;
        }

        //GERAIS
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //EVENTOS
        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            if(includePalestrantes)
            {
                query = query
                        .Include(pe => pe.PalestrantesEventos)
                        .ThenInclude(p => p.Palestrante);
            }

            query =query.OrderByDescending(c => c.DataEvento);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetAllEventoAsyncById(int EventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            if(includePalestrantes)
            {
                query = query
                        .Include(pe => pe.PalestrantesEventos)
                        .ThenInclude(p => p.Palestrante);
            }

            query =query.OrderByDescending(c => c.DataEvento)
                                .Where(c => c.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais); 

            if(includePalestrantes)
            {
                query = query
                        .Include(pe => pe.PalestrantesEventos)
                        .ThenInclude(p => p.Palestrante);
            }

            query =query.OrderByDescending(c => c.DataEvento)
                                .Where(c => c.Tema.Contains(tema));

            return await query.ToArrayAsync();
        }

        //PALESTRANTES
        public async Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais);

            if(includeEventos)
            {
                query = query
                        .Include(pe => pe.PalestrantesEventos)
                        .ThenInclude(e => e.Evento);
            }

            query =query.OrderBy(c => c.Nome)
                        .Where(p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Palestrante[]> GetAllPalestranteAsyncByName(string name, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais);

            if(includeEventos)
            {
                query = query
                        .Include(pe => pe.PalestrantesEventos)
                        .ThenInclude(e => e.Evento);
            }

            query =query.OrderBy(c => c.Nome)
                        .Where(p => p.Nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}
