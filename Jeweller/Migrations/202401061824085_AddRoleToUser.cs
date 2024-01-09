namespace Jeweller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "admin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "admin");
        }
    }
}
