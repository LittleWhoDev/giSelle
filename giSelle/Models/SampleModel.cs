namespace giSelle.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SampleModel : DbContext
    {
        // Your context has been configured to use a 'SampleModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'giSelle.Models.SampleModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SampleModel' 
        // connection string in the application configuration file.
        public SampleModel()
            : base("name=SampleModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<SampleEntity> SampleEntities { get; set; }
    }

    public class SampleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}