namespace CuahangNongduoc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2_AddSeed_FixUser_FixUserRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Code", c => c.String());
            AddColumn("dbo.Users", "Account", c => c.String());
            AddColumn("dbo.Users", "PasswordHash", c => c.String());
            AlterColumn("dbo.Roles", "Name", c => c.String());
            DropColumn("dbo.Users", "HashPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "HashPassword", c => c.String());
            AlterColumn("dbo.Roles", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "PasswordHash");
            DropColumn("dbo.Users", "Account");
            DropColumn("dbo.Roles", "Code");
        }
    }
}
