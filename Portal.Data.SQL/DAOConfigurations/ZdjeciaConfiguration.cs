using Portal.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Portal.Data.Sql.DAOConfigurations
{
    public class ZdjeciaConfiguration: IEntityTypeConfiguration<Zdjecia>
    {
        public void Configure(EntityTypeBuilder<Zdjecia> builder)
        {
            
            //ustawienie propercji typu Boolean jako kolumna typu tinyint
            
            
            //konfiguracja zależności jeden do wielu 
            builder.HasKey(pc => pc.IdZdjecia);
            builder.HasOne(x => x.Uzytkownik)
                .WithMany(x => x.zdjecia)
                // Konfiguruje sposób, w jaki operacja usuwania jest stosowana
                // do jednostek zależnych w relacji, gdy jednostka główna zostanie
                // usunięta lub relacja zostanie zerwana.
                .OnDelete(DeleteBehavior.Restrict)
                //ustawienie klucza głównego
                .HasForeignKey(x => x.IdUser);
            builder.ToTable("Zdjecia");
        }
    }

}