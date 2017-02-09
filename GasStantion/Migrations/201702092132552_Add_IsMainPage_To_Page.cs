namespace GasStantion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_IsMainPage_To_Page : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "IsMainPage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "IsMainPage");
        }
    }
}
