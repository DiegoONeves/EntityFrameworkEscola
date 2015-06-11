using EntityFrameworkEscola.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkEscola.DataAccess.Map
{
    public class TurmaMap : EntityTypeConfiguration<Turma>
    {
        public TurmaMap()
        {
            ToTable("Turma");
            HasKey(x => x.TurmaId);


            HasRequired(x => x.Curso)
            .WithMany()
            .Map(m => m.MapKey("CursoId"));

            HasRequired(x => x.Professor)
            .WithMany(x => x.TurmaLista)
            .Map(m => m.MapKey("ProfessorId"));
        }
    }
}
