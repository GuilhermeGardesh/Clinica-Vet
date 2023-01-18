namespace ClinicaVet.GestaoVeterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClinicaVet011 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animal", "Ativo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animal", "Ativo");
        }
    }
}
