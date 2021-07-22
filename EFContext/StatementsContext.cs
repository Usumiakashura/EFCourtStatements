using EFCourtStatements.Models;
using System.Data.Entity;

namespace EFCourtStatements.EFContext
{
    public class StatementsContext : DbContext
    {
        public DbSet<Judge> Judges { get; set; }
        public DbSet<StatInfo> StatementsInfo { get; set; }
        public DbSet<TypeST> TypesSt { get; set; }

        public StatementsContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new StatementsInitializer());
        }
    }
}
