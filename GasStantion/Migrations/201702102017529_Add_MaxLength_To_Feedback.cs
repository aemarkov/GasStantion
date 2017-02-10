namespace GasStantion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_MaxLength_To_Feedback : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserFeedbacks", "Comment", c => c.String(maxLength: 600));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserFeedbacks", "Comment", c => c.String());
        }
    }
}
