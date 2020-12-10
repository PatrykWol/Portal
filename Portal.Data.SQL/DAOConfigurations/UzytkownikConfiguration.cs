using Portal.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portal.Data.Sql.DAOConfigurations
{
    public class UzytkownikConfiguration: IEntityTypeConfiguration<Uzytkownik>
    {
        public void Configure(EntityTypeBuilder<Uzytkownik> builder)
        {
            builder.HasKey(pc => pc.UserId);
            builder.Property(c => c.IdUser).IsRequired();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.LastName).IsRequired();
            builder.Property(c => c.Login).IsRequired();
            builder.Property(c => c.Password).IsRequired();
            builder.ToTable("Uzytkownik");
        }
    }

}