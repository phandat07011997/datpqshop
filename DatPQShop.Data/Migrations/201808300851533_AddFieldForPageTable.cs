namespace DatPQShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldForPageTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Pages", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Pages", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Pages", "UpdateBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Pages", "MetaKeyword", c => c.String(maxLength: 256));
            AddColumn("dbo.Pages", "MetaDescription", c => c.String(maxLength: 256));
            AddColumn("dbo.Pages", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "Status");
            DropColumn("dbo.Pages", "MetaDescription");
            DropColumn("dbo.Pages", "MetaKeyword");
            DropColumn("dbo.Pages", "UpdateBy");
            DropColumn("dbo.Pages", "UpdateDate");
            DropColumn("dbo.Pages", "CreatedBy");
            DropColumn("dbo.Pages", "CreatedDate");
        }
    }
}
