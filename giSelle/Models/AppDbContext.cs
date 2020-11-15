namespace giSelle.Models
{
    using System.Data.Entity;
    using System.Linq;

    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppContext")
        {
            Database.SetInitializer(new AppDbContextInitializer());
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

    public class AppDbContextInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
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