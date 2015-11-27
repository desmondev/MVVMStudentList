namespace MVVMStudentList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentIndexNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "IndexNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "IndexNo");
        }
    }
}
