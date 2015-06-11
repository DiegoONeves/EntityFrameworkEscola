using System;
using System.Collections.Generic;

namespace EntityFrameworkEscola.Domain.Entities
{
    public class Turma
    {
        public Turma()
        {
            AlunoLista = new List<Aluno>();
        }

        public int TurmaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual ICollection<Aluno> AlunoLista { get; set; }

        public override string ToString()
        {
            return String.Format("Turma: {0} - Data Início: {1} - Professor: {2}", Curso.Descricao, DataInicio.ToShortDateString(), Professor.Nome);
        }
    }
}
