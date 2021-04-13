namespace Zeal_Institute.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIntroCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "IntroCourse", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "IntroCourse");
        }
    }
}
