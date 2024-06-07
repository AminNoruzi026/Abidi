namespace Abidi.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 300),
                        LastName = c.String(nullable: false, maxLength: 300),
                        PersonalCode = c.String(nullable: false, maxLength: 10),
                        NationalCode = c.String(nullable: false, maxLength: 10),
                        InsertUser = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateUser = c.String(),
                        UpdateDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonFiles",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        FileName = c.String(),
                        FileFormat = c.String(),
                        FileAddress = c.String(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonFiles", "PersonId", "dbo.People");
            DropIndex("dbo.PersonFiles", new[] { "PersonId" });
            DropTable("dbo.Users");
            DropTable("dbo.PersonFiles");
            DropTable("dbo.People");
        }
    }
}
