using EntityFrameworkEscola.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkEscola.DataAccess.Map
{
    public class ProfessorMap : EntityTypeConfiguration<Professor>
    {
        public ProfessorMap()
        {
            ToTable("Professor");
            HasKey(x => x.ProfessorId);
            Property(x => x.Nome).HasMaxLength(150).IsRequired();
        }
    }
}
