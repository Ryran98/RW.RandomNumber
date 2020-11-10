namespace RW.RandomNumber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHighscoreTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Highscore",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DifficultyId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        RemainingGuesses = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.DifficultyId, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.tb_Highscore", new[] { "DifficultyId" });
            DropTable("dbo.tb_Highscore");
        }
    }
}
