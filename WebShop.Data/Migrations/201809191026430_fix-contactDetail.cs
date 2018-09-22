namespace WebShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixcontactDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactDetails", "Email", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactDetails", "Email");
        }
    }
}
