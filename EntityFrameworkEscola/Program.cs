using EntityFrameworkEscola.DataAccess;
using EntityFrameworkEscola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkEscola
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext db = new DataContext();

            var cursos = db.Cursos
                .Include("ProfessorLista")
                .ToList();


            var curso = cursos.FirstOrDefault(x => x.Numero == "70-486");
            var professor = curso.ProfessorLista.FirstOrDefault(x => x.ProfessorId == 2);



            Turma turma = new Turma();
            turma.DataInicio = DateTime.Now;
            turma.DataTermino = DateTime.Now.AddDays(10);
            turma.Curso = curso;
            turma.Professor = professor;

            Aluno aluno = new Aluno();
            aluno.Nome = "Diego Neves";


            Usuario usuario = new Usuario();
            usuario.Email = "diegoneves1989@gmail.com";
            usuario.Senha = "123456";

            aluno.Usuario = usuario;



            Aluno aluno2 = new Aluno();
            aluno2.Nome = "Raquel Mota";


            Usuario usuario2 = new Usuario();
            usuario2.Email = "raquelmota@gmail.com";
            usuario2.Senha = "123456";

            aluno2.Usuario = usuario2;

            turma.AlunoLista.Add(aluno);
            turma.AlunoLista.Add(aluno2);


            db.Turmas.Add(turma);
            db.SaveChanges();



            var turmas = db.Turmas
                .Include("Professor")
                .Include("Curso")
                .Include("AlunoLista")
                .ToList();

            var usuarios = db.Usuarios
                .ToList();

            foreach (var turmaItem in turmas)
            {
                Console.WriteLine("Turma: "+ turmaItem.Curso.Descricao);
                Console.WriteLine("Início: " + turmaItem.DataInicio.ToShortDateString());
                Console.WriteLine("Previsto: " + turmaItem.DataTermino.ToShortDateString());
                Console.WriteLine("Professor: "+ turmaItem.Professor.Nome);
                Console.WriteLine("------------------------ Alunos Matriculados ------------------------");
                foreach (var alunoItem in turmaItem.AlunoLista)
                {
                    Console.WriteLine(String.Format("Nome: {0} - E-mail: {1}", alunoItem.Nome, usuarios.FirstOrDefault(x => x.UsuarioId == alunoItem.AlunoId).Email));
                }
                Console.WriteLine(Environment.NewLine);
            }

            Console.ReadKey();




        }
    }
}
