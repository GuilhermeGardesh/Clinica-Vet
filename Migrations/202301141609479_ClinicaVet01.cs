namespace Clinica_Vet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClinicaVet01 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Animals", newName: "Animal");
            AlterColumn("dbo.Animal", "Nome", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Animal", "Especie", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animal", "Especie", c => c.String());
            AlterColumn("dbo.Animal", "Nome", c => c.String());
            RenameTable(name: "dbo.Animal", newName: "Animals");
        }
    }
}
