using System.Data.Entity;

namespace Conversiecalculator
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ConversieHistory> ConversieHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConversieHistory>()
                .Property(e => e.FromValues)
                .IsFixedLength();

            modelBuilder.Entity<ConversieHistory>()
                .Property(e => e.ToValues)
                .IsFixedLength();
        }
    }
}
