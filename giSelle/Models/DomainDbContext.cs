namespace giSelle.Models
{
    using System.Data.Entity;
    using System.Linq;

    public class DomainDbContext : DbContext
    {
        public DomainDbContext()
            : base("name=DomainContext")
        {
            Database.SetInitializer(new DomainDbContextInitializer());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }
    }

    public class DomainDbContextInitializer : DropCreateDatabaseIfModelChanges<DomainDbContext>
    {
        protected override void Seed(DomainDbContext context)
        {
            // TODO: remove sample data
            var defaultRole = context.Roles.Add(new Role() { Name = "Default Role"});
            context.Users.Add(new User() { Name = "User 1", Role = defaultRole, Cart = new Cart() });
            context.Users.Add(new User() { Name = "User 2", Role = defaultRole, Cart = new Cart() });
            context.Users.Add(new User() { Name = "User 3", Role = defaultRole, Cart = new Cart() });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}