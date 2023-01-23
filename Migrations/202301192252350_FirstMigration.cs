namespace ClinicaVet.GestaoVeterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 20),
                        Especie = c.String(nullable: false, maxLength: 20),
                        Raca = c.String(),
                        Idade = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Atendimento",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Diagnostico = c.String(maxLength: 300),
                        Observacoes = c.String(maxLength: 300),
                        AtendimentoIniciado = c.DateTime(nullable: false),
                        AtendimentoFinalizado = c.DateTime(nullable: false),
                        Finalizado = c.Boolean(nullable: false),
                        IdAnimal = c.Int(nullable: false),
                        IdMedicoVeterinario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Animal", t => t.IdAnimal, cascadeDelete: true)
                .ForeignKey("dbo.MedicoVeterinario", t => t.IdMedicoVeterinario, cascadeDelete: true)
                .Index(t => t.IdAnimal)
                .Index(t => t.IdMedicoVeterinario);
            
            CreateTable(
                "dbo.MedicoVeterinario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 35),
                        Descricao = c.String(maxLength: 300),
                        NumeroDeIncricaoCRMV = c.String(nullable: false, maxLength: 10),
                        LocalDoCRMV = c.String(nullable: false, maxLength: 10),
                        CPF = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Atendimento", "IdMedicoVeterinario", "dbo.MedicoVeterinario");
            DropForeignKey("dbo.Atendimento", "IdAnimal", "dbo.Animal");
            DropIndex("dbo.Atendimento", new[] { "IdMedicoVeterinario" });
            DropIndex("dbo.Atendimento", new[] { "IdAnimal" });
            DropTable("dbo.MedicoVeterinario");
            DropTable("dbo.Atendimento");
            DropTable("dbo.Animal");
        }
    }
}
