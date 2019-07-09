namespace UNIFAFIBE.TCC._4Sales.Persistencia.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UNIFAFIBE.TCC._4Sales.Persistencia.Contexto.TCC_Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UNIFAFIBE.TCC._4Sales.Persistencia.Contexto.TCC_Contexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
