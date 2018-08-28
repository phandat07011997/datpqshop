namespace DatPQShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuantityField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Quantity");
        }
    }
}
