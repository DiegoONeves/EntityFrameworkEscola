using System.Collections.Generic;

namespace EntityFrameworkEscola.Domain.Entities
{
    public class Professor: Pessoa
    {
        public Professor()
        {
            CursoLista = new List<Curso>();
            TurmaLista = new List<Turma>();
        }
        public int ProfessorId { get; set; }

        public virtual ICollection<Curso> CursoLista { get; set; }

        public virtual ICollection<Turma> TurmaLista { get; set; }

        public override string ToString()
        {
            return Nome;
        }

    }
}
