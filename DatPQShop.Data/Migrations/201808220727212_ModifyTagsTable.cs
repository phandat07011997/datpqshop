namespace DatPQShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTagsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Tags", "Nane");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Nane", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Tags", "Name");
        }
    }
}
