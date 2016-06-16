using System.Data.Entity.ModelConfiguration;
using Treinamento.Domain.Entidades;

namespace Treinamento.Domain.Repository.Mapping
{
    public class ConvenioMap : EntityTypeConfiguration<Convenio>
    {
        public ConvenioMap()
        {
            HasKey(p => p.Id);

            Property(p => p.Desconto).HasPrecision(5, 2);
        }
    }
}
