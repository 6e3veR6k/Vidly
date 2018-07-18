namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationForCustomerModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
        }
    }
}
