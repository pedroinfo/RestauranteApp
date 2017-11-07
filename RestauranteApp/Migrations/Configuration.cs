namespace RestauranteApp.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RestauranteApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RestauranteApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Restaurantes.Add(new Models.Restaurante() { Nome = "Restaurante 1" });
            context.Restaurantes.Add(new Models.Restaurante() { Nome = "Restaurante 2" });
            context.Restaurantes.Add(new Models.Restaurante() { Nome = "Restaurante 3" });
            
        }
    }
}
