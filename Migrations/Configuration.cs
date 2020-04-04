namespace otorino.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using otorino.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<otorino.Models.otorinoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(otorino.Models.otorinoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Servicios.AddOrUpdate(x => x.Id,
       new Servicio() { Id = 1, Nombre = "Rinoplastía" },
       new Servicio() { Id = 2, Nombre = "Rinitis" },
       new Servicio() { Id = 3, Nombre = "Congestión" }
       );

            context.Clientes.AddOrUpdate(x => x.Id,
                new Cliente()
                {
                    Id = 1,
                    Nombre = "Maqui",
                    Telefono = "3311223344",
                    Email = "mach@gmail.com",
                    Otros = "Quiero pedir informes",
                    ServicioId = 1

                },
                new Cliente()
                {
                    Id = 2,
                    Nombre = "Maya",
                    Telefono = "3311223344",
                    Email = "maya@gmail.com",
                    Otros = "Quiero pedir informes por favor",
                    ServicioId = 2

                },
                new Cliente()
                {
                    Id = 3,
                    Nombre = "Mayinbu",
                    Telefono = "3311223344",
                    Email = "mayi@gmail.com",
                    Otros = "informes por favor",
                    ServicioId = 3

                }


                );
        }
    }
}
