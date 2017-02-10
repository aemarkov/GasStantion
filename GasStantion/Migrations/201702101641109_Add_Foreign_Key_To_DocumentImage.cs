namespace GasStantion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Foreign_Key_To_DocumentImage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DocumentImages", "Document_Id", "dbo.Documents");
            DropIndex("dbo.DocumentImages", new[] { "Document_Id" });
            RenameColumn(table: "dbo.DocumentImages", name: "Document_Id", newName: "DocumentId");
            AlterColumn("dbo.DocumentImages", "DocumentId", c => c.Int(nullable: false));
            CreateIndex("dbo.DocumentImages", "DocumentId");
            AddForeignKey("dbo.DocumentImages", "DocumentId", "dbo.Documents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DocumentImages", "DocumentId", "dbo.Documents");
            DropIndex("dbo.DocumentImages", new[] { "DocumentId" });
            AlterColumn("dbo.DocumentImages", "DocumentId", c => c.Int());
            RenameColumn(table: "dbo.DocumentImages", name: "DocumentId", newName: "Document_Id");
            CreateIndex("dbo.DocumentImages", "Document_Id");
            AddForeignKey("dbo.DocumentImages", "Document_Id", "dbo.Documents", "Id");
        }
    }
}
