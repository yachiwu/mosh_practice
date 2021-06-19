namespace mosh_practice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SETBirthdateToCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = CAST('1980-01-01' AS DATETIME) WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
