namespace GasStantion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Contacts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactsInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        YandexMapUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactsInfoes");
        }
    }
}
