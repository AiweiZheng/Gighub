using System.Data.Entity.ModelConfiguration;
using GigHub.Core.Models;

namespace GigHub.Persistence.EntityConfigurations
{
    public class DescriptionConfiguration : EntityTypeConfiguration<Description>
    {
        public DescriptionConfiguration()
        {
            Property(d => d.Id).IsRequired();

            Property(d => d.Descr).IsRequired();
        }

    }
}