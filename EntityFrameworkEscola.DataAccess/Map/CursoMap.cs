using EntityFrameworkEscola.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkEscola.DataAccess.Map
{
    public class CursoMap : EntityTypeConfiguration<Curso>
    {
        public CursoMap()
        {
            ToTable("Curso");
            HasKey(x => x.CursoId);
            Property(x => x.Descricao).HasMaxLength(150).IsRequired();

            //N:N
            HasMany(x => x.ProfessorLista)
                .WithMany(x => x.CursoLista)
                .Map(m =>
                {
                    m.MapLeftKey("CursoId");
                    m.MapRightKey("ProfessorId");
                    m.ToTable("CursoProfessor");
                });
        }
    }
}
