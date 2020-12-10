using Portal.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portal.Data.Sql.DAOConfigurations
{
    public class OcenyConfiguration: IEntityTypeConfiguration<Oceny>
    {
        public void Configure(EntityTypeBuilder<Oceny> builder)
        {
            builder.HasKey(pc => pc.OcenaId);
            builder.Property(c => c.Like).HasColumnType("tinyint(1)");
            builder.HasOne(x => x.Uzytkownik)
                .WithMany(x => x.oceny)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.IdUser);
            
            builder.ToTable("Oceny");
        }
    }

}