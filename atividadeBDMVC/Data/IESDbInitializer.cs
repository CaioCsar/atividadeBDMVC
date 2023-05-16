using atividadeBDMVC.Models;
using System.Linq;

namespace atividadeBDMVC.Data
{
    public class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            context.Database.EnsureCreated();

            // INSTITUICAO
            if (context.Instituicoes.Any())
            {
                return;
            }
            var instituicoes = new Instituicao[]
            {
                new Instituicao {Nome = "SENAI", Endereco = "Tancredo Neves"},
                new Instituicao {Nome = "Unit", Endereco = "Farolandia"}
            };
            foreach (Instituicao i in instituicoes)
            {
                context.Instituicoes.Add(i);
            }
            context.SaveChanges();

            //DEPARTAMENTOS
            if (context.Departamentos.Any())
            {
                return;
            }
            var departamentos = new Departamento[]
            {
                new Departamento { Nome="Ciência da Computação", Campus="A2", InstituicaoID = 1},
                new Departamento { Nome="Ciência de Alimentos", Campus="B6", InstituicaoID = 2}
            };
            foreach (Departamento d in departamentos)
            {
                context.Departamentos.Add(d);
            }
            context.SaveChanges();

            // CURSOS
            if (context.Cursos.Any())
            {
                return;
            }
            var cursos = new Curso[]
            {
                new Curso { Nome="Desenvolvimento de Jogos", Turno="matino", NumeroAlunos = 23, DepartamentoID = 1},
                new Curso { Nome="Nutrição", Turno="noturno", NumeroAlunos = 45, DepartamentoID = 2}
            };
            foreach (Curso d in cursos)
            {
                context.Cursos.Add(d);
            }
            context.SaveChanges();

            // DISCIPLINA
            if (context.Disciplinas.Any())
            {
                return;
            }
            var disciplina = new Disciplina[]
            {
                new Disciplina { Nome="Matematica Básica"},
                new Disciplina { Nome="Historia da Informática"}
            };
            foreach (Disciplina d in disciplina)
            {
                context.Disciplinas.Add(d);
            }
            context.SaveChanges();


        }

    }
}
