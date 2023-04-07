using Microsoft.EntityFrameworkCore;
using Escola_API.Models;
using System.Diagnostics.CodeAnalysis;

namespace Escola_API.Data
{
    public class EscolaContext: DbContext
    {
        protected readonly IConfiguration Configuration;
        public EscolaContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("StringConexaoSQLServer"));
        }

        public DbSet<Aluno> Aluno {get; set;}
        public DbSet<Curso> Curso { get; set; }
    }
}