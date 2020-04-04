namespace otorino.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Telefono = c.String(),
                        Email = c.String(),
                        Otros = c.String(),
                        ServicioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Servicios", t => t.ServicioId, cascadeDelete: true)
                .Index(t => t.ServicioId);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(),
                        Imagen = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "ServicioId", "dbo.Servicios");
            DropIndex("dbo.Clientes", new[] { "ServicioId" });
            DropTable("dbo.Servicios");
            DropTable("dbo.Clientes");
        }
    }
}
