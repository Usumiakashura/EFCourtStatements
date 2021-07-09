using EFCourtStatements.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCourtStatements.EFContext
{
    class StatementsContext : DbContext
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
