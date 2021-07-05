namespace mosh_practice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'946e985f-e382-4571-bf21-8f000773f332', N'admintomovie@vidly.com', 0, N'AMd9BqEUlUXFTAa+DICTUuLVuaEbTDUCCUjRmf+eaQANou/jxdjfDN59gSOoV8c1EA==', N'06e50692-22bb-4fd0-9a2d-8b60ad9b0c7f', NULL, 0, 0, NULL, 1, 0, N'admintomovie@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd2a55631-0645-4ee5-a577-c4bd085fec6b', N'lucy860829tw@gmail.com', 0, N'APscEdUAK3jWQlFpaLsUKQ0e+UKo4vVzx8+QARdvaMx+dkcJoJXCGm+0Bj6EIVdQHA==', N'3e4d1eb7-537e-4eb2-aacc-22eacc3233df', NULL, 0, 0, NULL, 1, 0, N'lucy860829tw@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fc1a36d7-8e7c-428e-bde3-bc6a0690b3b0', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'946e985f-e382-4571-bf21-8f000773f332', N'fc1a36d7-8e7c-428e-bde3-bc6a0690b3b0')


");
        }
        
        public override void Down()
        {
        }
    }
}
