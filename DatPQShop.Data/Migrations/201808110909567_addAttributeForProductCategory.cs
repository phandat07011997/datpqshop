namespace DatPQShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAttributeForProductCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.ProductCategories", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ProductCategories", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.ProductCategories", "UpdateBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ProductCategories", "MetaKeyword", c => c.String(maxLength: 256));
            AddColumn("dbo.ProductCategories", "MetaDescription", c => c.String(maxLength: 256));
            AddColumn("dbo.ProductCategories", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCategories", "Status");
            DropColumn("dbo.ProductCategories", "MetaDescription");
            DropColumn("dbo.ProductCategories", "MetaKeyword");
            DropColumn("dbo.ProductCategories", "UpdateBy");
            DropColumn("dbo.ProductCategories", "UpdateDate");
            DropColumn("dbo.ProductCategories", "CreatedBy");
            DropColumn("dbo.ProductCategories", "CreatedDate");
        }
    }
}
