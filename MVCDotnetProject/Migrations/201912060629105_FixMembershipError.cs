namespace MVCDotnetProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixMembershipError : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id,SignUpFee,DurationInMonths,DiscountRate,Name) VALUES (3, 90, 3, 20,'Quarterly')");
        }
        
        public override void Down()
        {
        }
    }
}
