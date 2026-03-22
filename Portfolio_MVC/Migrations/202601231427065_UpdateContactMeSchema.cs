namespace Portfolio_MVC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateContactMeSchema : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.Contact_me SET Name = '' WHERE Name IS NULL");
            Sql("UPDATE dbo.Contact_me SET Email = '' WHERE Email IS NULL");
            Sql("UPDATE dbo.Contact_me SET Subject = '' WHERE Subject IS NULL");
            Sql("UPDATE dbo.Contact_me SET Message = '' WHERE Message IS NULL");

            // STEP 2: Ab NOT NULL constraint lagao
            AlterColumn("dbo.Contact_me", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Contact_me", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Contact_me", "Subject", c => c.String(nullable: false));
            AlterColumn("dbo.Contact_me", "Message", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Contact_me", "Message", c => c.String());
            AlterColumn("dbo.Contact_me", "Subject", c => c.String());
            AlterColumn("dbo.Contact_me", "Email", c => c.String());
            AlterColumn("dbo.Contact_me", "Name", c => c.String());
        }
    }
}
