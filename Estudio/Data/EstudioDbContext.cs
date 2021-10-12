using Estudio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudio.Data
{
    public class EstudioDbContext: DbContext
    {
        public DbSet<Music> Songs { get; set; }
        public EstudioDbContext(DbContextOptions<EstudioDbContext>options):base(options) //Enlaza nuestra base de datos con el entity framework
        {

        }
    }
}
