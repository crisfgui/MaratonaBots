using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseConhecimentoPOAprendiz.Models
{
    public class BaseConhecimentoContext : DbContext
    {
        public BaseConhecimentoContext(DbContextOptions<BaseConhecimentoContext> options) : base(options)
        {

        }

        public DbSet<ItemAcademico> ItemAcademico { get; set; }

    }
}
