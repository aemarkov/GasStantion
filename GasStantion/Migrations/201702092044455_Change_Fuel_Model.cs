namespace GasStantion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Fuel_Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fuels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FuelName = c.String(nullable: false, maxLength: 10),
                        Price = c.Double(nullable: false),
                        FuelDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.FuelPrices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FuelPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PetroliumName = c.String(nullable: false, maxLength: 10),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Fuels");
        }
    }
}
