namespace Portfolio_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contact_me : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact_me",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Subject = c.String(),
                        Message = c.String(),
                        InsertDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Regs");
            DropTable("dbo.Contact_me");
        }
    }
}
