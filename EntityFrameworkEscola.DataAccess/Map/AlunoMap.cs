using EntityFrameworkEscola.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkEscola.DataAccess.Map
{
    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        public AlunoMap()
        {
            ToTable("Aluno");
            HasKey(x => x.AlunoId);

            //1:N - 1 aluno DEVE ter 1 turma e 1 turma pode ter muitos alunos
            HasRequired(x => x.Turma)
              .WithMany(x => x.AlunoLista)
               .Map(m => m.MapKey("TurmaId"));

            //*1:1 - 1 aluno deve ter apenas 1 usuário
            HasRequired(x => x.Usuario)
            .WithRequiredPrincipal();
        }
    }
}
