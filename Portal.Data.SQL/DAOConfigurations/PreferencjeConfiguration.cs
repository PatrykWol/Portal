using Portal.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portal.Data.Sql.DAOConfigurations
{
    public class PreferencjeConfiguration: IEntityTypeConfiguration<Preferencje>
    {
        public void Configure(EntityTypeBuilder<Preferencje> builder)
        {
            builder.HasKey(pc => pc.IdPreferencje);
            builder.HasOne(x => x.Uzytkownik)
                .WithMany(x => x.preferencje)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.IdUser);
            builder.ToTable("Preferencje");
        }
    }

}