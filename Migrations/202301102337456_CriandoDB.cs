namespace Clinica_Vet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Especie = c.String(),
                        Raca = c.String(),
                        Idade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Animals");
        }
    }
}
