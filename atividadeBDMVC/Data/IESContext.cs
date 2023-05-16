using atividadeBDMVC.Models;
using atividadeBDMVC.Models.Infra;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace atividadeBDMVC.Data
{
    public class IESContext : IdentityDbContext<UsuarioDaAplicacao>
    {
        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<CursoDisciplina> CursoDisciplinas { get; set; }

        //Definicao de relacionamento N:N entre Curso e Disciplina, utilizando o Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CursoDisciplina>().HasKey(cd => new { cd.CursoID, cd.DisciplinaID });

            modelBuilder.Entity<CursoDisciplina>()
                .HasOne(c => c.Curso)
                .WithMany(cd => cd.CursoDisciplinas)
                .HasForeignKey(c => c.CursoID);

            modelBuilder.Entity<CursoDisciplina>()
                .HasOne(d => d.Disciplina)
                .WithMany(cd => cd.CursoDisciplinas)
                .HasForeignKey(d => d.DisciplinaID);
        }
    }
}
