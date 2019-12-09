namespace MVCDotnetProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET SignUpFee= 0, DurationInMonths= 0,DiscountRate= 0, Name= 'Pay as you go' WHERE Id= 1");
            Sql("UPDATE MembershipTypes SET SignUpFee= 30, DurationInMonths= 1,DiscountRate= 10, Name= 'Monthly' WHERE Id= 2");
            Sql("UPDATE MembershipTypes SET SignUpFee= 90, DurationInMonths= 3,DiscountRate= 20, Name= 'Quarterly' WHERE Id= 3");
            Sql("UPDATE MembershipTypes SET SignUpFee= 300, DurationInMonths= 12,DiscountRate= 20, Name= 'Annually' WHERE Id= 4");
        }
        
        public override void Down()
        {
        }
    }
}
