namespace CuahangNongduoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3_delete_user_session : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserSessions", "UserID", "dbo.Users");
            DropIndex("dbo.UserSessions", new[] { "UserID" });
            DropTable("dbo.UserSessions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserSessions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        TimeAccess = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.UserSessions", "UserID");
            AddForeignKey("dbo.UserSessions", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}
