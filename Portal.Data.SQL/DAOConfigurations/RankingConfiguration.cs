using Portal.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portal.Data.Sql.DAOConfigurations
{
    public class RankingConfiguration: IEntityTypeConfiguration<Ranking>
    {
        public void Configure(EntityTypeBuilder<Ranking> builder)
        {
            builder.HasKey(pc => pc.RankingId);
            builder.Property(c => c.PozycjaRanking).IsRequired();
            builder.HasOne(x => x.Uzytkownik)
                .WithMany(x => x.ranking)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.IdUser);
            builder.ToTable("Ranking");
        }
    }

}