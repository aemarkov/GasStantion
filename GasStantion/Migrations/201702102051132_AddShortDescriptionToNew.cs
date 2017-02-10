namespace GasStantion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShortDescriptionToNew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "ShortDescription", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "ShortDescription");
        }
    }
}
