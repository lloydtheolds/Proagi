using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proagil.WEBAPI.model;

namespace Proagil.WEBAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}

        public DbSet<Evento> Eventos { get; set; }

        internal Task FirstOrDefaultAsync(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}